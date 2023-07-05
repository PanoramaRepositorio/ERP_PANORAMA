using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ErpPanorama.Presentation.Modulos.Logistica.Rpt;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegSolicitudProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<SolicitudProductoBE> mLista = new List<SolicitudProductoBE>();

        #endregion

        #region "Eventos"

        public frmRegSolicitudProducto()
        {
            InitializeComponent();
        }

        private void frmRegSolicitudProducto_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = Parametros.intPeriodo;
            cboMes.EditValue = DateTime.Now.Month;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegSolicitudProductoEdit objManSolicitudProducto = new frmRegSolicitudProductoEdit();
                objManSolicitudProducto.lstSolicitudProducto = mLista;
                objManSolicitudProducto.pOperacion = frmRegSolicitudProductoEdit.Operacion.Nuevo;
                objManSolicitudProducto.IdSolicitudProducto = 0;
                objManSolicitudProducto.StartPosition = FormStartPosition.CenterParent;
                objManSolicitudProducto.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        SolicitudProductoBE objE_SolicitudProducto = new SolicitudProductoBE();
                        objE_SolicitudProducto.IdSolicitudProducto = int.Parse(gvSolicitudProducto.GetFocusedRowCellValue("IdSolicitudProducto").ToString());
                        objE_SolicitudProducto.Usuario = Parametros.strUsuarioLogin;
                        objE_SolicitudProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_SolicitudProducto.IdEmpresa = Parametros.intEmpresaId;

                        SolicitudProductoBL objBL_SolicitudProducto = new SolicitudProductoBL();
                        objBL_SolicitudProducto.Elimina(objE_SolicitudProducto);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    bool flagEnviado = true;
                    flagEnviado = bool.Parse(gvSolicitudProducto.GetFocusedRowCellValue("FlagEnviado").ToString());
                    if (flagEnviado)
                    {
                        SolicitudProductoBE objE_SolicitudProducto = new SolicitudProductoBE();
                        objE_SolicitudProducto.IdSolicitudProducto = int.Parse(gvSolicitudProducto.GetFocusedRowCellValue("IdSolicitudProducto").ToString());
                        objE_SolicitudProducto.IdEmpresa = Parametros.intEmpresaId;

                        if(!Parametros.bImpresionSPDirecto)
                        {
                            SolicitudProductoBL objBL_SolicitudProducto = new SolicitudProductoBL();
                            objBL_SolicitudProducto.ActualizaFechaImpresion(objE_SolicitudProducto);
                        }

                        List<ReporteSolicitudProductoBE> lstReporte = null;
                        lstReporte = new ReporteSolicitudProductoBL().Listado(Parametros.intEmpresaId, objE_SolicitudProducto.IdSolicitudProducto);

                        #region "Codigo Barras"

                        iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                        bc.TextAlignment = Element.ALIGN_LEFT;
                        bc.Code = lstReporte[0].Numero;
                        bc.StartStopText = false;
                        bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                        bc.Extended = true;
                        bc.BarHeight = 27;
                        lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                        #endregion

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                objRptSolicitudProducto.VerRptSolicitudProducto(lstReporte);
                                objRptSolicitudProducto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede imprimir la solicitud porque no ha sido enviada almacén de anaqueles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                   
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoSolicitudProductos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvSolicitudProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvSolicitudProducto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void enviarAlmanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    bool flagEnviado = true;
                    flagEnviado = bool.Parse(gvSolicitudProducto.GetFocusedRowCellValue("FlagEnviado").ToString());
                    if (flagEnviado)
                    {
                        XtraMessageBox.Show("La solicitud ya fué enviada", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        SolicitudProductoBE objE_SolicitudProducto = new SolicitudProductoBE();
                        objE_SolicitudProducto.IdSolicitudProducto = int.Parse(gvSolicitudProducto.GetFocusedRowCellValue("IdSolicitudProducto").ToString());
                        objE_SolicitudProducto.IdEmpresa = Parametros.intEmpresaId;
                        objE_SolicitudProducto.FlagEnviado = true;

                        SolicitudProductoBL objBL_SolicitudProducto = new SolicitudProductoBL();
                        objBL_SolicitudProducto.ActualizaEnvio(objE_SolicitudProducto);
                        //XtraMessageBox.Show("La solicitud se envío almacén de anaqueles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if(Parametros.bImpresionSPDirecto)
                        {
                            objBL_SolicitudProducto.ActualizaFechaImpresion(objE_SolicitudProducto);
                            ImpresionSolicitudProducto(objE_SolicitudProducto.IdSolicitudProducto);
                        }else
                        {
                            objE_SolicitudProducto = new SolicitudProductoBL().Selecciona(Parametros.intEmpresaId, int.Parse(gvSolicitudProducto.GetFocusedRowCellValue("IdSolicitudProducto").ToString()));
                            XtraMessageBox.Show("La solicitud se envío almacén\nFecha Delivery: " + objE_SolicitudProducto.FechaDelivery.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        Cargar();
                        
                    }
                    
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImpresionSolicitudProducto(int IdSolicitudProducto)
        {
            List<ReporteSolicitudProductoBE> lstReporte = null;
            lstReporte = new ReporteSolicitudProductoBL().Listado(Parametros.intEmpresaId, IdSolicitudProducto);

            if (Parametros.intTiendaId != Parametros.intTiendaUcayali)
            {
                #region "Codigo Barras"
                iTextSharp.text.pdf.Barcode128 bc = new Barcode128();
                bc.TextAlignment = Element.ALIGN_LEFT;
                bc.Code = lstReporte[0].Numero;
                bc.StartStopText = false;
                bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                bc.Extended = true;
                bc.BarHeight = 27;
                lstReporte[0].CodigoBarraNumero = new FuncionBase().Image2Bytes(bc.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));

                #endregion

                if (lstReporte.Count > 0)
                {
                    rptSolicitudProducto1 objReporteGuia = new rptSolicitudProducto1();
                    objReporteGuia.SetDataSource(lstReporte);

                    #region "Buscar Impresora ..."
                    bool found = false;
                    PrinterSettings prtSetting = new PrinterSettings();
                    foreach (string prtName in PrinterSettings.InstalledPrinters)
                    {
                        string printer = "";
                        if (prtName.StartsWith("\\\\"))
                        {
                            printer = prtName.Substring(3);
                            printer = printer.Substring(printer.IndexOf("\\") + 1);
                        }
                        else
                            printer = prtName;

                        if (printer.ToUpper().StartsWith("(SP)"))
                        {
                            found = true;
                            PrintOptions bufPO = objReporteGuia.PrintOptions;
                            prtSetting.PrinterName = prtName;
                            objReporteGuia.PrintOptions.PrinterName = prtName;

                            Impresion.Imprimir(objReporteGuia, prtSetting.PrinterName, 1, 0, 0, CrystalDecisions.Shared.PaperSize.DefaultPaperSize);///addd
                            break;
                        }
                    }

                    if (!found)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("La impresora (SP) Nombre para Solicitud de Producto no ha sido encontrada.");
                        return;
                    }
                    MessageBox.Show("La Solicitud se imprimió correctamente\nFecha Delivery: " + lstReporte[0].FechaImpresion.ToShortDateString().ToString());
                }
                #endregion
            }
            else
            {
                string AlmacenOrigen = "";
                if(lstReporte.Count>0)
                {
                    AlmacenOrigen = lstReporte[0].DescAlmacen;
                }
                MessageBox.Show("Llamar a: "+ AlmacenOrigen + ", para coordinar la impresión.");
            }

        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new SolicitudProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));
            gcSolicitudProducto.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcSolicitudProducto.DataSource = mLista.Where(obj =>
                                                   obj.Numero.ToUpper().Contains(txtNumero.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvSolicitudProducto.RowCount > 0)
            {
                bool flagEnviado = true;
                flagEnviado = bool.Parse(gvSolicitudProducto.GetFocusedRowCellValue("FlagEnviado").ToString());
                if (flagEnviado)
                {
                    XtraMessageBox.Show("No se puede modificar la solicitud ya fué enviada almacén de anaqueles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    SolicitudProductoBE objSolicitudProducto = new SolicitudProductoBE();
                    objSolicitudProducto.IdSolicitudProducto = int.Parse(gvSolicitudProducto.GetFocusedRowCellValue("IdSolicitudProducto").ToString());

                    frmRegSolicitudProductoEdit objManSolicitudProductolEdit = new frmRegSolicitudProductoEdit();
                    objManSolicitudProductolEdit.pOperacion = frmRegSolicitudProductoEdit.Operacion.Modificar;
                    objManSolicitudProductolEdit.IdSolicitudProducto = objSolicitudProducto.IdSolicitudProducto;
                    objManSolicitudProductolEdit.StartPosition = FormStartPosition.CenterParent;
                    objManSolicitudProductolEdit.btnGrabar.Enabled = false;
                    //objManSolicitudProductolEdit.ShowDialog();
                    if (objManSolicitudProductolEdit.ShowDialog() == DialogResult.OK)
                    {
                        Cargar();
                    }
                }
                else
                {
                    SolicitudProductoBE objSolicitudProducto = new SolicitudProductoBE();
                    objSolicitudProducto.IdSolicitudProducto = int.Parse(gvSolicitudProducto.GetFocusedRowCellValue("IdSolicitudProducto").ToString());

                    frmRegSolicitudProductoEdit objManSolicitudProductolEdit = new frmRegSolicitudProductoEdit();
                    objManSolicitudProductolEdit.pOperacion = frmRegSolicitudProductoEdit.Operacion.Modificar;
                    objManSolicitudProductolEdit.IdSolicitudProducto = objSolicitudProducto.IdSolicitudProducto;
                    objManSolicitudProductolEdit.StartPosition = FormStartPosition.CenterParent;
                    objManSolicitudProductolEdit.btnGrabar.Enabled = true;
                    ///objManSolicitudProductolEdit.ShowDialog();
                    if (objManSolicitudProductolEdit.ShowDialog() == DialogResult.OK)
                    {
                        Cargar();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvSolicitudProducto.GetFocusedRowCellValue("IdSolicitudProducto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Solicitud", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void ImprimirAsesoriatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    bool flagEnviado = true;
                    flagEnviado = bool.Parse(gvSolicitudProducto.GetFocusedRowCellValue("FlagEnviado").ToString());
                    if (flagEnviado)
                    {
                        SolicitudProductoBE objE_SolicitudProducto = new SolicitudProductoBE();
                        objE_SolicitudProducto.IdSolicitudProducto = int.Parse(gvSolicitudProducto.GetFocusedRowCellValue("IdSolicitudProducto").ToString());
                        objE_SolicitudProducto.IdEmpresa = Parametros.intEmpresaId;

                        SolicitudProductoBL objBL_SolicitudProducto = new SolicitudProductoBL();
                        objBL_SolicitudProducto.ActualizaFechaImpresion(objE_SolicitudProducto);

                        List<ReporteSolicitudProductoBE> lstReporte = null;
                        lstReporte = new ReporteSolicitudProductoBL().Listado(Parametros.intEmpresaId, objE_SolicitudProducto.IdSolicitudProducto);

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptSolicitudProducto = new RptVistaReportes();
                                objRptSolicitudProducto.VerRptSolicitudProductoAsesoria(lstReporte);
                                objRptSolicitudProducto.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede imprimir la solicitud porque no ha sido enviada almacén de anaqueles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void recibirsolicitudtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    bool FlagRecibido = true;
                    int IdTiendaOrigen = 0;
                    FlagRecibido = bool.Parse(gvSolicitudProducto.GetFocusedRowCellValue("FlagRecibido").ToString());
                    IdTiendaOrigen = int.Parse(gvSolicitudProducto.GetFocusedRowCellValue("IdTiendaOrigen").ToString());
                    if (FlagRecibido)
                    {
                        XtraMessageBox.Show("La solicitud ya fué recbidida almacén de anaqueles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (Parametros.intTiendaId == IdTiendaOrigen)
                        {
                            frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                            frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                            frmAutoriza.ShowDialog();

                            if (frmAutoriza.Edita)
                            {                           
                            SolicitudProductoBE objE_SolicitudProducto = new SolicitudProductoBE();
                            objE_SolicitudProducto.IdSolicitudProducto = int.Parse(gvSolicitudProducto.GetFocusedRowCellValue("IdSolicitudProducto").ToString());
                            objE_SolicitudProducto.IdEmpresa = Parametros.intEmpresaId;
                            objE_SolicitudProducto.FlagRecibido = true;
                            objE_SolicitudProducto.Usuario = frmAutoriza.Usuario;

                            SolicitudProductoBL objBL_SolicitudProducto = new SolicitudProductoBL();
                            objBL_SolicitudProducto.ActualizaRecibido(objE_SolicitudProducto);
                            XtraMessageBox.Show("La solicitud se envío almacén de anaqueles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                          }
                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no puede recibir esta solicitud, Verificar Tienda Origen.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }

                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporteDetalle_Click(object sender, EventArgs e)
        {
            frmRepSolicitudProductoDetalle frm = new frmRepSolicitudProductoDetalle();
            frm.ShowDialog();
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}