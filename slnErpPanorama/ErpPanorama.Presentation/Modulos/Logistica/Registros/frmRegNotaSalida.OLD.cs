using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Logistica.Consultas;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Logistica.Rpt;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegNotaSalida : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MovimientoAlmacenBE> mLista = new List<MovimientoAlmacenBE>();

        DataTable dt = new DataTable();
        
        #endregion

        #region "Eventos"

        public frmRegNotaSalida()
        {
            InitializeComponent();
        }

        private void frmRegNotaSalida_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = DateTime.Now.Year;
            cboMes.EditValue = DateTime.Now.Month;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosCombo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = Parametros.intTiendaId;

            Cargar();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                if (Convert.ToInt32(cboTienda.EditValue) == 0)
                {
                    cboAlmacen.EditValue = 0;
                }
                else
                {
                    BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
                }
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegNotaSalidaEdit objManMovimientoAlmacen = new frmRegNotaSalidaEdit();
                objManMovimientoAlmacen.lstMovimientoAlmacen = mLista;
                objManMovimientoAlmacen.pOperacion = frmRegNotaSalidaEdit.Operacion.Nuevo;
                objManMovimientoAlmacen.IdMovimientoAlmacen = 0;
                objManMovimientoAlmacen.StartPosition = FormStartPosition.CenterParent;
                objManMovimientoAlmacen.btnGrabar.Enabled = true;
                //objManMovimientoAlmacen.ShowDialog();
                if (objManMovimientoAlmacen.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
                    
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
                        if (Convert.ToBoolean(gvMovimientoAlmacen.GetFocusedRowCellValue("FlagRecibido").ToString()) == true)
                        {
                            XtraMessageBox.Show("No se puede eliminar una nota de salida (RECEPCIONADA), Ud. debe eliminar primero la Nota de Ingreso.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Cursor = Cursors.Default;
                            return;
                        }
                        if (Convert.ToBoolean(gvMovimientoAlmacen.GetFocusedRowCellValue("FlagEstado").ToString()) == false)
                        {
                            XtraMessageBox.Show("La nota de salida está eliminada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Cursor = Cursors.Default;
                            return;
                        }
                        if (Convert.ToInt32(gvMovimientoAlmacen.GetFocusedRowCellValue("IdPedido").ToString()) > 0)
                        {
                            XtraMessageBox.Show("Esta nota de salida tiene como origen un pedido, no se puede eliminar\nSi ud. desea eliminar debe eliminar el N° pedido.",this.Text,MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor = Cursors.Default;
                            return;
                        }

                        if (Convert.ToBoolean(gvMovimientoAlmacen.GetFocusedRowCellValue("FlagDespachado").ToString()) == true)
                        {
                            XtraMessageBox.Show("No se puede eliminar, La nota de salida ya fue despachada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            Cursor = Cursors.Default;
                            return;
                        }

                        //string Usuario = Parametros.strUsuarioLogin;
                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (!frmAutoriza.Edita)
                        {
                            Cursor = Cursors.Default;
                            return;
                        }

                        if (frmAutoriza.Usuario == "almacen1" || frmAutoriza.Usuario == "almacen2")
                        {
                            Cursor = Cursors.Default;
                            XtraMessageBox.Show(this.Text, "Por favor generar con otro usuario.\nAcceso restringido!");
                            return;
                        }

                        string Observacion = "";
                        frmObservacion frmObserva = new frmObservacion();
                        frmObserva.StartPosition = FormStartPosition.CenterParent;
                        if (frmObserva.ShowDialog() == DialogResult.OK)
                        {
                            Observacion = frmObserva.strObservacion;

                            MovimientoAlmacenBE objE_MovimientoAlmacen = null;
                            objE_MovimientoAlmacen = new MovimientoAlmacenBL().Selecciona(Parametros.intEmpresaId, Convert.ToInt32(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString()));
                            objE_MovimientoAlmacen.Usuario = frmAutoriza.Usuario;// Parametros.strUsuarioLogin;
                            objE_MovimientoAlmacen.ObservacionElimina = Observacion;
                            objE_MovimientoAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_MovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;

                            MovimientoAlmacenBL objBL_MovimientoAlmancen = new MovimientoAlmacenBL();
                            objBL_MovimientoAlmancen.Elimina(objE_MovimientoAlmacen);
                            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
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
                    ReporteNotaSalidaBE objE_MovimientoAlmacen = new ReporteNotaSalidaBE();
                    objE_MovimientoAlmacen.IdMovimientoAlmacen = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());
                    objE_MovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;

                    List<ReporteNotaSalidaBE> lstReporte = null;
                    lstReporte = new ReporteNotaSalidaBL().Listado(Parametros.intEmpresaId, objE_MovimientoAlmacen.IdMovimientoAlmacen);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptMovimientoAlmacen = new RptVistaReportes();
                            objRptMovimientoAlmacen.VerRptNotaSalida(lstReporte);
                            objRptMovimientoAlmacen.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string _fileName = "ListadoMovimientoAlmacenes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMovimientoAlmacen.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMovimientoAlmacen_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumero_EditValueChanged(object sender, EventArgs e)
        {
            //CargarBusqueda();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void bultosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvMovimientoAlmacen.RowCount > 0)
                {
                    frmConBultosInvolucrados objBultosInvolucrados = new frmConBultosInvolucrados();
                    objBultosInvolucrados.Periodo = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("Periodo").ToString());
                    objBultosInvolucrados.IdTipoDocumento = Parametros.intTipoDocNotaSalida;
                    objBultosInvolucrados.Numero = gvMovimientoAlmacen.GetFocusedRowCellValue("Numero").ToString();
                    objBultosInvolucrados.StartPosition = FormStartPosition.CenterParent;
                    objBultosInvolucrados.ShowDialog();

                    Cargar();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvMovimientoAlmacen_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvMovimientoAlmacen.GetRow(e.RowHandle);
                object objMov = gvMovimientoAlmacen.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objRecibido = View.GetRowCellValue(e.RowHandle, View.Columns["FlagRecibido"]);
                    object objMotivo = View.GetRowCellValue(e.RowHandle, View.Columns["IdMotivo"]);
                    if (objRecibido != null)
                    {
                        bool FlagRecibido = bool.Parse(objRecibido.ToString());
                        int IdMotivo = int.Parse(objMotivo.ToString());
                        if (FlagRecibido)
                        {
                            //int IdMotivo = int.Parse(objMotivo.ToString());
                            if (IdMotivo == Parametros.intMovReparacionTaller || IdMotivo == Parametros.intMovTransferenciaAndahuaylas || IdMotivo == Parametros.intMovTransferenciaUcayali || IdMotivo == Parametros.intMovMuestrasUcayali || IdMotivo == Parametros.intMovMuestrasAndahuaylas || IdMotivo == Parametros.intAutoservicioUcayali || IdMotivo == Parametros.intMovAutoservicioAndahuaylas)
                                e.Appearance.ForeColor = Color.Blue;
                        }
                        if (IdMotivo == Parametros.intMovMermas)
                            e.Appearance.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imprimirguiaremisiontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                MovimientoAlmacenBE objE_MovimientoAlmacen = (MovimientoAlmacenBE)gvMovimientoAlmacen.GetRow(gvMovimientoAlmacen.FocusedRowHandle);

                string dirFacturacion = "<No Especificado>";
                string dirDestinoTienda = "<No Especificado>";
                string DescCliente = "";
                string NumeroDocDestino = "";
                String DirguiaRem = ""; //Dirección Destino de Guía de remisión.
                int IdAlmacenDestino = 0;
                int IdCliente = 0;
                objE_MovimientoAlmacen.IdTienda = Convert.ToInt32(cboTienda.EditValue);


                //Origen
                if (Convert.ToInt32(cboTienda.EditValue) == Parametros.intTiendaUcayali)
                {
                    dirFacturacion = Parametros.strDireccionUcayali;
                }
                if (objE_MovimientoAlmacen.IdTienda == Parametros.intTiendaAndahuaylas)
                {
                    dirFacturacion = Parametros.strDireccionAndahuaylas;
                }
                if (objE_MovimientoAlmacen.IdTienda == Parametros.intTiendaKonceptos)
                {
                    dirFacturacion = Parametros.strDireccionMegaplaza;
                }
                if (objE_MovimientoAlmacen.IdTienda == Parametros.intTiendaPrescott)
                {
                    dirFacturacion = Parametros.strDireccionPrescott;
                }

                if (objE_MovimientoAlmacen.IdTienda == Parametros.intTiendaAviacion)
                {
                    dirFacturacion = Parametros.strDireccionAviacion;
                }

                if (objE_MovimientoAlmacen.IdTienda == Parametros.intTiendaMegaplaza)
                {
                    dirFacturacion = Parametros.strDireccionMegaplaza;
                }

                List<ReporteMovimientoAlmacenGuiaRemisionBE> lstReporte = null;
                lstReporte = new ReporteMovimientoAlmacenGuiaRemisionBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(objE_MovimientoAlmacen.IdMovimientoAlmacen));

                IdAlmacenDestino = lstReporte[0].IdAlmacenDestino;
                IdCliente= lstReporte[0].IdCliente;

                //Destino
                if (IdAlmacenDestino == Parametros.intAlmCentralUcayali)
                {
                    dirDestinoTienda = Parametros.strDireccionUcayali;
                }
                if (IdAlmacenDestino == Parametros.intAlmTiendaUcayali)
                {
                    dirDestinoTienda = Parametros.strDireccionUcayali;
                }
                if (IdAlmacenDestino == Parametros.intAlmTiendaAndahuaylas)
                {
                    dirDestinoTienda = Parametros.strDireccionAndahuaylas;
                }
                if (IdAlmacenDestino == Parametros.intAlmKonceptos)
                {
                    dirDestinoTienda = Parametros.strDireccionMegaplaza;
                }
                if (IdAlmacenDestino == Parametros.intAlmTiendaPrescott)
                {
                    dirDestinoTienda = Parametros.strDireccionPrescott;
                }

                if (IdAlmacenDestino == Parametros.intAlmTiendaAviacion)
                {
                    dirDestinoTienda = Parametros.strDireccionAviacion;
                }
                if (IdAlmacenDestino == Parametros.intAlmTiendaMegaplaza)
                {
                    dirDestinoTienda = Parametros.strDireccionMegaplaza;
                }


                //Dirección del Proveedor
                ClienteBE ObjE_Cliente = new ClienteBE();
                ObjE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);
                if (ObjE_Cliente != null && lstReporte[0].IdPedido == 0)
                {
                    NumeroDocDestino = ObjE_Cliente.NumeroDocumento;
                    DescCliente = ObjE_Cliente.DescCliente;
                    DirguiaRem = ObjE_Cliente.AbrevDomicilio + " " + ObjE_Cliente.Direccion + " " + ObjE_Cliente.NumDireccion ;
                }
                else
                {
                    NumeroDocDestino = Parametros.strEmpresaRuc;
                    DescCliente = Parametros.strEmpresaNombre;
                }


                //Impresión de Reporte
                rptGuiaRemisionPanoramaAlmacen objReporteGuia = new rptGuiaRemisionPanoramaAlmacen();

                #region "Direccion"
                frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                frm.ShowDialog();


                if (frm.DireccionGuiaPrint == "" && DirguiaRem == "")
                {
                    DirguiaRem = dirDestinoTienda;
                }
                else if (frm.DireccionGuiaPrint != "")
                {
                    DirguiaRem = frm.DireccionGuiaPrint;
                }

                #endregion

                objReporteGuia.SetDataSource(lstReporte);

                objReporteGuia.SetParameterValue("dirFac", dirFacturacion);
                objReporteGuia.SetParameterValue("dirGuia", DirguiaRem);
                objReporteGuia.SetParameterValue("DescCliente", DescCliente);//Parametros.strEmpresaNombre);
                objReporteGuia.SetParameterValue("NumeroDocDestino", NumeroDocDestino);//Parametros.strEmpresaRuc);


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

                    if (printer.ToUpper().StartsWith("(G)"))
                    {
                        found = true;
                        PrintOptions bufPO = objReporteGuia.PrintOptions;
                        prtSetting.PrinterName = prtName;
                        objReporteGuia.PrintOptions.PrinterName = prtName;

                        int rawKind = -1;
                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                        {
                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                            {
                                rawKind = prtSetting.PaperSizes[i].RawKind;
                                objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                break;
                            }
                        }
                        if (rawKind == -1)
                        {
                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora (G) Nombre para Guía Panorama no ha sido encontrada.");

                }
                objReporteGuia.PrintToPrinter(1, false, 0, 0);
            }
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }
        }

        private void despachartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvMovimientoAlmacen.RowCount > 0)
            {
                bool FlagDespachado = false;
                FlagDespachado = bool.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("FlagDespachado").ToString());

                if (!FlagDespachado)
                {
                    if (XtraMessageBox.Show("Está seguro de despachar esta nota de salida?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int IdMovimientoAlmacen = 0;
                        IdMovimientoAlmacen = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());

                        MovimientoAlmacenBL ojbBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                        ojbBL_MovimientoAlmacen.ActualizaDespachado(IdMovimientoAlmacen, true);
                        gvMovimientoAlmacen.SetRowCellValue(gvMovimientoAlmacen.FocusedRowHandle, "FlagDespachado", true);

                        XtraMessageBox.Show("Se despachó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    XtraMessageBox.Show("La nota de salida ya está despachada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                optCodigo.Checked = true;
                txtCodigo.Select();
            }
            if (keyData == Keys.F6)
            {
                optHangTag.Checked = true;
                txtCodigo.Select();
                //txtCodigo.SelectAll();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new MovimientoAlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovSalida);
            dt = FuncionBase.ToDataTable(mLista);
            gcMovimientoAlmacen.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            //if (Parametros.intPerfilId == Parametros.intPerAdministrador )
            //{
                mLista = new MovimientoAlmacenBL().SeleccionaNumero(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), 0, 0, Parametros.intTipMovSalida, txtNumero.Text);
                gcMovimientoAlmacen.DataSource = mLista;
            //}
            //else
            //{
            //    mLista = new MovimientoAlmacenBL().SeleccionaNumero(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovSalida, txtNumero.Text);
            //    gcMovimientoAlmacen.DataSource = mLista;

            //    //gcMovimientoAlmacen.DataSource = mLista.Where(obj =>
            //    //                       obj.Numero.ToUpper().Contains(txtNumero.Text.ToUpper())).ToList();
            //}

        }

        private void CargarBusquedaCodigo(int IdProducto)
        {
            mLista = new MovimientoAlmacenBL().ListaCodigo(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovSalida, IdProducto);
            dt = FuncionBase.ToDataTable(mLista);
            gcMovimientoAlmacen.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvMovimientoAlmacen.RowCount > 0)
            {
                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();
                objMovimientoAlmacen.IdMovimientoAlmacen = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());

                int IdMotivo = 0;
                IdMotivo = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMotivo").ToString());

                frmRegNotaSalidaEdit objManMovimientoAlmacenEdit = new frmRegNotaSalidaEdit();
                objManMovimientoAlmacenEdit.pOperacion = frmRegNotaSalidaEdit.Operacion.Modificar;
                objManMovimientoAlmacenEdit.IdMovimientoAlmacen = objMovimientoAlmacen.IdMovimientoAlmacen;
                objManMovimientoAlmacenEdit.StartPosition = FormStartPosition.CenterParent;
                //if (IdMotivo == Parametros.intMovFaltanteOrigen || IdMotivo == Parametros.intMovMermas)
                //    objManMovimientoAlmacenEdit.btnGrabar.Enabled = false;
                //else
                //    objManMovimientoAlmacenEdit.btnGrabar.Enabled = true;

                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "almacen2" || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen || Parametros.intPerfilId == Parametros.intPerSupervisorAlmacen)
                    objManMovimientoAlmacenEdit.btnGrabar.Enabled = true;
                else
                    objManMovimientoAlmacenEdit.btnGrabar.Enabled = false;
                //objManMovimientoAlmacenEdit.ShowDialog();
                if (objManMovimientoAlmacenEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
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
                if (gvMovimientoAlmacen.RowCount > 0)
                {
                    MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();
                    objMovimientoAlmacen.IdMovimientoAlmacen = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());

                    frmRegNotaSalidaEdit objManMovimientoAlmacenEdit = new frmRegNotaSalidaEdit();
                    objManMovimientoAlmacenEdit.pOperacion = frmRegNotaSalidaEdit.Operacion.Modificar;
                    objManMovimientoAlmacenEdit.IdMovimientoAlmacen = objMovimientoAlmacen.IdMovimientoAlmacen;
                    objManMovimientoAlmacenEdit.StartPosition = FormStartPosition.CenterParent;
                    objManMovimientoAlmacenEdit.btnGrabar.Enabled = false;
                    if (objManMovimientoAlmacenEdit.ShowDialog() == DialogResult.OK)
                    {
                        Cargar();
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo editar");
                }
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un documento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }






        #endregion

        private void recibirfisicotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool RecibidoFisico = bool.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("FlagRecibidoFisico").ToString());
            bool FlagEstado = bool.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("FlagEstado").ToString());
            string Numero = gvMovimientoAlmacen.GetFocusedRowCellValue("Numero").ToString();
            int IdAlmacenDestino = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdAlmacenDestino").ToString());

            if (FlagEstado)
            {
                if (!RecibidoFisico)
                {
                    if (IdAlmacenDestino == Parametros.intAlmCentralUcayali )
                    {
                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (frmAutoriza.Edita)
                        {
                            MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                            int IdMovimientoAlmacen = 0;
                            IdMovimientoAlmacen = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());

                            objBL_MovimientoAlmacen.ActualizaRecibidoFisico(IdMovimientoAlmacen, true, frmAutoriza.Usuario);
                            XtraMessageBox.Show("Nota de Salida recepcionada correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtNumero.Text = Numero;
                            CargarBusqueda();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede recibir, la nota de salida tiene otro destino\nPor favor verifique!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
            else {
                XtraMessageBox.Show("La nota de salida está anulada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gvMovimientoAlmacen_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvMovimientoAlmacen.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocumento = View.GetRowCellValue(e.RowHandle, View.Columns["FlagEstado"]);
                    if (objDocumento != null)
                    {
                        bool IdTipoDocumento = bool.Parse(objDocumento.ToString());
                        if (!IdTipoDocumento)
                        {
                            e.Appearance.BackColor = Color.Gray;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Length > 0)
                {
                    if (optCodigo.Checked)
                    {
                        ProductoBE objE_Producto = null;

                        int Resultado = 0; //add 240616
                        Resultado = new ProductoBL().SeleccionaBusquedaCount(txtCodigo.Text.Trim());

                        if (Resultado == 0)
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCodigo.SelectAll();
                            return;
                        }
                        if (Resultado == 1)
                        {
                            ProductoBE objE_Producto2 = null;
                            objE_Producto2 = new ProductoBL().SeleccionaParteCodigo(Parametros.intEmpresaId, txtCodigo.Text.Trim());
                            objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objE_Producto2.CodigoProveedor);
                        }
                        else
                        {
                            frmBusProducto objBusProducto = new frmBusProducto();
                            objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                            objBusProducto.ShowDialog();
                            if (objBusProducto.pProductoBE != null)
                            {
                                objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objBusProducto.pProductoBE.CodigoProveedor);
                            }
                            else
                            {
                                txtCodigo.Select();
                                return;
                            }

                        }

                        if (objE_Producto != null)
                        {
                            //IdProducto = objE_Producto.IdProducto;
                            txtCodigo.Text = objE_Producto.CodigoProveedor;
                            //txtDescripcion.Text = objE_Producto.NombreProducto;

                            txtCodigo.SelectAll();
                            CargarBusquedaCodigo(objE_Producto.IdProducto);
                            //Cargar();
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    //Hang Tag

                    if (optHangTag.Checked)
                    {
                        ProductoBE objE_Producto = null;

                        if (txtCodigo.Text.Trim().Length > 6)
                            //objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(txtCodigo.Text.Trim()); //Codigo de Barras de Importación
                            objE_Producto = new ProductoBL().SeleccionaCodigoBarra(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
                        else
                            objE_Producto = new ProductoBL().SeleccionaID(Parametros.intEmpresaId, Parametros.intTiendaId, Convert.ToInt32(txtCodigo.Text.Trim()));
                        if (objE_Producto != null)
                        {
                            //IdProducto = objE_Producto.IdProducto;
                            //txtCodigo.Text = objE_Producto.CodigoProveedor;
                            //txtDescripcion.Text = objE_Producto.NombreProducto;

                            txtCodigo.SelectAll();
                            CargarBusquedaCodigo(objE_Producto.IdProducto);
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void optCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (optCodigo.Checked)
            {
                txtCodigo.Select();
            }
        }

        private void optHangTag_CheckedChanged(object sender, EventArgs e)
        {
            if (optHangTag.Checked)
            {
                txtCodigo.Select();
            }
        }

        private void imprimirgruiaremisiondesglosabletoolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (mLista.Count > 0)
            {
                MovimientoAlmacenBE objE_MovimientoAlmacen = (MovimientoAlmacenBE)gvMovimientoAlmacen.GetRow(gvMovimientoAlmacen.FocusedRowHandle);

                string dirFacturacion = "<No Especificado>";
                string dirDestinoTienda = "<No Especificado>";
                string DescCliente = "";
                string NumeroDocDestino = "";
                String DirguiaRem = ""; //Dirección Destino de Guía de remisión.
                int IdAlmacenDestino = 0;
                int IdCliente = 0;
                objE_MovimientoAlmacen.IdTienda = Convert.ToInt32(cboTienda.EditValue);


                //Origen
                if (Convert.ToInt32(cboTienda.EditValue) == Parametros.intTiendaUcayali)
                {
                    dirFacturacion = Parametros.strDireccionUcayali;
                }
                if (objE_MovimientoAlmacen.IdTienda == Parametros.intTiendaAndahuaylas)
                {
                    dirFacturacion = Parametros.strDireccionAndahuaylas;
                }
                if (objE_MovimientoAlmacen.IdTienda == Parametros.intTiendaKonceptos)
                {
                    dirFacturacion = Parametros.strDireccionMegaplaza;
                }
                if (objE_MovimientoAlmacen.IdTienda == Parametros.intTiendaPrescott)
                {
                    dirFacturacion = Parametros.strDireccionPrescott;
                }

                if (objE_MovimientoAlmacen.IdTienda == Parametros.intTiendaAviacion)
                {
                    dirFacturacion = Parametros.strDireccionAviacion;
                }

                if (objE_MovimientoAlmacen.IdTienda == Parametros.intTiendaMegaplaza)
                {
                    dirFacturacion = Parametros.strDireccionMegaplaza;
                }

                List<ReporteMovimientoAlmacenGuiaRemisionBE> lstReporte = null;
                lstReporte = new ReporteMovimientoAlmacenGuiaRemisionBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(objE_MovimientoAlmacen.IdMovimientoAlmacen));

                IdAlmacenDestino = lstReporte[0].IdAlmacenDestino;
                IdCliente = lstReporte[0].IdCliente;

                //Destino
                if (IdAlmacenDestino == Parametros.intAlmCentralUcayali)
                {
                    dirDestinoTienda = Parametros.strDireccionUcayali;
                }
                if (IdAlmacenDestino == Parametros.intAlmTiendaUcayali)
                {
                    dirDestinoTienda = Parametros.strDireccionUcayali;
                }
                if (IdAlmacenDestino == Parametros.intAlmTiendaAndahuaylas)
                {
                    dirDestinoTienda = Parametros.strDireccionAndahuaylas;
                }
                if (IdAlmacenDestino == Parametros.intAlmKonceptos)
                {
                    dirDestinoTienda = Parametros.strDireccionMegaplaza;
                }
                if (IdAlmacenDestino == Parametros.intAlmTiendaPrescott)
                {
                    dirDestinoTienda = Parametros.strDireccionPrescott;
                }

                if (IdAlmacenDestino == Parametros.intAlmTiendaAviacion)
                {
                    dirDestinoTienda = Parametros.strDireccionAviacion;
                }
                if (IdAlmacenDestino == Parametros.intAlmTiendaMegaplaza)
                {
                    dirDestinoTienda = Parametros.strDireccionMegaplaza;
                }


                //Dirección del Proveedor
                ClienteBE ObjE_Cliente = new ClienteBE();
                ObjE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);
                if (ObjE_Cliente != null && lstReporte[0].IdPedido == 0)
                {
                    NumeroDocDestino = ObjE_Cliente.NumeroDocumento;
                    DescCliente = ObjE_Cliente.DescCliente;
                    DirguiaRem = ObjE_Cliente.AbrevDomicilio + " " + ObjE_Cliente.Direccion + " " + ObjE_Cliente.NumDireccion;
                }
                else
                {
                    NumeroDocDestino = Parametros.strEmpresaRuc;
                    DescCliente = Parametros.strEmpresaNombre;
                }


                //Impresión de Reporte
                rptGuiaRemisionDesglosablePanoramaAlmacen objReporteGuia = new rptGuiaRemisionDesglosablePanoramaAlmacen();

                #region "Direccion"
                frmModificarDireccionGuia frm = new frmModificarDireccionGuia();
                frm.ShowDialog();


                if (frm.DireccionGuiaPrint == "" && DirguiaRem == "")
                {
                    DirguiaRem = dirDestinoTienda;
                }
                else if (frm.DireccionGuiaPrint != "")
                {
                    DirguiaRem = frm.DireccionGuiaPrint;
                }

                #endregion

                objReporteGuia.SetDataSource(lstReporte);

                objReporteGuia.SetParameterValue("dirFac", dirFacturacion);
                objReporteGuia.SetParameterValue("dirGuia", DirguiaRem);
                objReporteGuia.SetParameterValue("DescCliente", DescCliente);//Parametros.strEmpresaNombre);
                objReporteGuia.SetParameterValue("NumeroDocDestino", NumeroDocDestino);//Parametros.strEmpresaRuc);


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

                    if (printer.ToUpper().StartsWith("(G)"))
                    {
                        found = true;
                        PrintOptions bufPO = objReporteGuia.PrintOptions;
                        prtSetting.PrinterName = prtName;
                        objReporteGuia.PrintOptions.PrinterName = prtName;

                        int rawKind = -1;
                        CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
                        for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
                        {
                            if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
                            {
                                rawKind = prtSetting.PaperSizes[i].RawKind;
                                objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
                                break;
                            }
                        }
                        if (rawKind == -1)
                        {
                            MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    }
                }

                if (!found)
                {
                    MessageBox.Show("La impresora (G) Nombre para Guía Panorama no ha sido encontrada.");

                }
                objReporteGuia.PrintToPrinter(1, false, 0, 0);
            }
        }
    }
}