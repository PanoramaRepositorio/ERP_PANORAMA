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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegCambio : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CambioBE> mLista = new List<CambioBE>();

        #endregion

        #region "Eventos"

        public frmRegCambio()
        {
            InitializeComponent();
        }

        private void frmRegCambio_Load(object sender, EventArgs e)
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
                frmRegCambioEdit objManCambio = new frmRegCambioEdit();
                objManCambio.lstCambio = mLista;
                objManCambio.pOperacion = frmRegCambioEdit.Operacion.Nuevo;
                objManCambio.IdCambio = 0;
                objManCambio.StartPosition = FormStartPosition.CenterParent;
                objManCambio.ShowDialog();
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
                        CambioBE objE_Cambio = (CambioBE)gvCambio.GetRow(gvCambio.FocusedRowHandle);
                        objE_Cambio.Usuario = Parametros.strUsuarioLogin;
                        objE_Cambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Cambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());

                        //if(objE_Cambio.IdDocumentoVentaNcv>0)
                        //{
                        //    XtraMessageBox.Show("No se puede anular, el documento tiene nota de crédito.");
                        //}

                        CambioBL objBL_Cambio = new CambioBL();
                        objBL_Cambio.Elimina(objE_Cambio);
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
                    //bool flagAprobado = true;
                    //flagAprobado = bool.Parse(gvCambio.GetFocusedRowCellValue("FlagAprobado").ToString());
                    //if (flagAprobado)
                    //{

                    int IdEmpresa = 0;
                    IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                    if (IdEmpresa == Parametros.intPanoraramaDistribuidores || IdEmpresa == Parametros.intCoronaImportadores || IdEmpresa == Parametros.intTapiaTarrilloEleazar || IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia || IdEmpresa == Parametros.intTapiaCalderonOlgaLidia)
                    {
                        string NumeroNotaCredito = "";
                        NumeroNotaCredito = gvCambio.GetFocusedRowCellValue("NumeroNotaCredito").ToString();

                        //if (NumeroNotaCredito.Length == 0)
                        //{
                        //    XtraMessageBox.Show("La devolución que desea imprimir, requiere que se genere la nota de crédito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}
                        //else
                        //{
                        List<ReporteCambioBE> lstReporte = null;
                        lstReporte = new ReporteCambioBL().Listado(int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptCambio = new RptVistaReportes();
                                objRptCambio.VerRptCambioCambio(lstReporte);
                                objRptCambio.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        //}
                    }
                    else
                    {
                        List<ReporteCambioBE> lstReporte = null;
                        lstReporte = new ReporteCambioBL().Listado(int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString()));

                        if (lstReporte != null)
                        {
                            if (lstReporte.Count > 0)
                            {
                                RptVistaReportes objRptCambio = new RptVistaReportes();
                                objRptCambio.VerRptCambioCambio(lstReporte);
                                objRptCambio.ShowDialog();
                            }
                            else
                                XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    //}
                    //else
                    //    XtraMessageBox.Show("La solicitud de devolución no se puede imprimir porque no ha sido aprobada\n por favor comunicarse con la supervisora de ventas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string _fileName = "ListadoCambios";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCambio.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }

        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCambio_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void aprobarsolicitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                    frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                    frmAutoriza.ShowDialog();

                    if (frmAutoriza.Edita)
                    {
                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "etapia" || frmAutoriza.Usuario == "mtapia" || frmAutoriza.Usuario == "pmoscaiza" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.Usuario == "liliana")
                        {
                            CambioBE objE_Cambio = (CambioBE)gvCambio.GetRow(gvCambio.FocusedRowHandle);
                            CambioBL objBL_Cambio = new CambioBL();

                            objBL_Cambio.ActualizaAprobado(objE_Cambio.IdEmpresa, objE_Cambio.IdCambio, true, frmAutoriza.IdPersona);

                            XtraMessageBox.Show("La solicitud de devolución de aprobó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Cursor = Cursors.Default;

                            Cargar();


                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void anulardevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "yosorio" || Parametros.strUsuarioLogin == "jrodriguez" || Parametros.strUsuarioLogin == "jvasquez" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "almacen2" || Parametros.strUsuarioLogin == "lordinola" || Parametros.strUsuarioLogin == "pmoscaiza"|| Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen)
                    {
                        bool flagRecibido = true;
                        flagRecibido = bool.Parse(gvCambio.GetFocusedRowCellValue("FlagRecibido").ToString());
                        if (!flagRecibido)
                        {
                            //int IdEmpresaEmisora = 0;
                            //IdEmpresaEmisora = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                            //if (IdEmpresaEmisora == Parametros.intPanoraramaDistribuidores || IdEmpresaEmisora == Parametros.intCoronaImportadores || IdEmpresaEmisora == Parametros.intTapiaTarrilloEleazar || IdEmpresaEmisora == Parametros.intHuamanBramonTeodoraAmalia || IdEmpresaEmisora == Parametros.intTapiaCalderonOlgaLidia)
                            //{
                            //    string NumeroNotaCredito = "";
                            //    NumeroNotaCredito = gvCambio.GetFocusedRowCellValue("NumeroNotaCredito").ToString();
                            //if (NumeroNotaCredito.Length > 0)
                            //{
                            //        CambioBE objCambio = new CambioBE();
                            //        objCambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                            //        objCambio.IdTienda = int.Parse(gvCambio.GetFocusedRowCellValue("IdTienda").ToString());
                            //        objCambio.IdCambio = int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString());
                            //        objCambio.Periodo = int.Parse(gvCambio.GetFocusedRowCellValue("Periodo").ToString());
                            //        objCambio.Fecha = DateTime.Parse(gvCambio.GetFocusedRowCellValue("Fecha").ToString());
                            //        objCambio.Numero = gvCambio.GetFocusedRowCellValue("Numero").ToString();
                            //        objCambio.Usuario = Parametros.strUsuarioLogin;
                            //        objCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                            //        List<CambioDetalleBE> mListaCambioDetalle = null;
                            //        mListaCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objCambio.IdCambio);

                            //        CambioBL objBL_Cambio = new CambioBL();
                            //        objBL_Cambio.ActualizaRecibido(objCambio, mListaCambioDetalle);

                            //        XtraMessageBox.Show("La solicitud de devolución se recibió correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //        Cargar();
                            //        Cursor = Cursors.Default;
                            //    //}
                            //    //else
                            //    //{
                            //    //    XtraMessageBox.Show("La nota de credito no esta generado para este tipo de documento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //    //    Cursor = Cursors.Default;
                            //    //}
                            //}
                            //else
                            //{
                            CambioBE objCambio = new CambioBE();
                            objCambio.IdTipoDocumento = int.Parse(gvCambio.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                            objCambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                            objCambio.IdTienda = int.Parse(gvCambio.GetFocusedRowCellValue("IdTienda").ToString());
                            objCambio.IdCambio = int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString());
                            objCambio.Periodo = int.Parse(gvCambio.GetFocusedRowCellValue("Periodo").ToString());
                            objCambio.Fecha = DateTime.Parse(gvCambio.GetFocusedRowCellValue("Fecha").ToString());
                            objCambio.Numero = gvCambio.GetFocusedRowCellValue("Numero").ToString();
                            objCambio.Usuario = Parametros.strUsuarioLogin;
                            objCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                            List<CambioDetalleBE> mListaCambioDetalle = null;
                            mListaCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objCambio.IdCambio);

                            CambioBL objBL_Cambio = new CambioBL();
                            objBL_Cambio.ActualizaRecibido(objCambio, mListaCambioDetalle);

                            XtraMessageBox.Show("La solicitud de devolución se recibió correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                            Cursor = Cursors.Default;
                            //}
                        }
                        else
                        {
                            XtraMessageBox.Show("La solicitud de devolución esta recibida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                    }

                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void anularrecibimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    bool flagRecibido = true;
                    flagRecibido = bool.Parse(gvCambio.GetFocusedRowCellValue("FlagRecibido").ToString());
                    if (flagRecibido)
                    {
                        if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "yosorio" || Parametros.strUsuarioLogin == "jrodriguez" || Parametros.strUsuarioLogin == "jvasquez" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "pmoscaiza")
                        {
                            int IdEmpresaEmisora = 0;
                            IdEmpresaEmisora = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                            if (IdEmpresaEmisora == Parametros.intPanoraramaDistribuidores || IdEmpresaEmisora == Parametros.intCoronaImportadores || IdEmpresaEmisora == Parametros.intTapiaTarrilloEleazar || IdEmpresaEmisora == Parametros.intHuamanBramonTeodoraAmalia || IdEmpresaEmisora == Parametros.intTapiaCalderonOlgaLidia)
                            {
                                string NumeroNotaCredito = "";
                                NumeroNotaCredito = gvCambio.GetFocusedRowCellValue("NumeroNotaCredito").ToString();
                                if (NumeroNotaCredito.Length > 0)
                                {
                                    CambioBE objCambio = new CambioBE();
                                    objCambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                                    objCambio.IdTienda = int.Parse(gvCambio.GetFocusedRowCellValue("IdTienda").ToString());
                                    objCambio.IdCambio = int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString());
                                    objCambio.Periodo = int.Parse(gvCambio.GetFocusedRowCellValue("Periodo").ToString());
                                    objCambio.Fecha = DateTime.Parse(gvCambio.GetFocusedRowCellValue("Fecha").ToString());
                                    objCambio.Numero = gvCambio.GetFocusedRowCellValue("Numero").ToString();
                                    objCambio.Usuario = Parametros.strUsuarioLogin;
                                    objCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                    List<CambioDetalleBE> mListaCambioDetalle = null;
                                    mListaCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objCambio.IdCambio);

                                    CambioBL objBL_Cambio = new CambioBL();
                                    objBL_Cambio.AnulaRecibido(objCambio, mListaCambioDetalle);

                                    XtraMessageBox.Show("La anulación se realizó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Cargar();
                                    Cursor = Cursors.Default;
                                }
                                else
                                {
                                    XtraMessageBox.Show("La nota de credito no esta generado para este tipo de documento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    Cursor = Cursors.Default;
                                }
                            }
                            else
                            {
                                CambioBE objCambio = new CambioBE();
                                objCambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                                objCambio.IdTienda = int.Parse(gvCambio.GetFocusedRowCellValue("IdTienda").ToString());
                                objCambio.IdCambio = int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString());
                                objCambio.Periodo = int.Parse(gvCambio.GetFocusedRowCellValue("Periodo").ToString());
                                objCambio.Fecha = DateTime.Parse(gvCambio.GetFocusedRowCellValue("Fecha").ToString());
                                objCambio.Numero = gvCambio.GetFocusedRowCellValue("Numero").ToString();
                                objCambio.Usuario = Parametros.strUsuarioLogin;
                                objCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                List<CambioDetalleBE> mListaCambioDetalle = null;
                                mListaCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objCambio.IdCambio);

                                CambioBL objBL_Cambio = new CambioBL();
                                objBL_Cambio.AnulaRecibido(objCambio, mListaCambioDetalle);

                                XtraMessageBox.Show("La anulación se realizó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Cursor = Cursors.Default;
                            }

                        }
                        else
                        {
                            XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Cursor = Cursors.Default;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("No se puede efectuar la anulación porque la solicutud de devolución no esta recibida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cambiarclienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mLista.Count > 0)
                {
                    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "liliana" || Parametros.strUsuarioLogin == "mtapia" || Parametros.strUsuarioLogin == "marjorie" || Parametros.strUsuarioLogin == "pmoscaiza")
                    {
                        //Validar Periodo
                        DateTime Fecha;
                        Fecha = DateTime.Parse(gvCambio.GetRowCellValue(gvCambio.FocusedRowHandle, "Fecha").ToString());
                        PeriodoBE objBE_Periodo = new PeriodoBE();
                        objBE_Periodo = new PeriodoBL().Selecciona(Fecha.Year, Fecha.Month);
                        if (objBE_Periodo != null)
                        {
                            if (objBE_Periodo.FlagEstado == false)
                            {
                                XtraMessageBox.Show("No se puede realizar ningún cambio, el periodo está cerrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        //Documento
                        CambioBE objE_Cambio = (CambioBE)gvCambio.GetRow(gvCambio.FocusedRowHandle);
                        frmCambiarRazonSocial objDescuento = new frmCambiarRazonSocial();
                        objDescuento.IdCambio = objE_Cambio.IdCambio;
                        objDescuento.Origen = 2;
                        objDescuento.StartPosition = FormStartPosition.CenterParent;
                        if (objDescuento.ShowDialog() == DialogResult.OK)
                        {
                            Cargar();
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Cursor = Cursors.Default;
                    }
                }


                //if (mLista.Count > 0)
                //{
                //    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "liliana" || Parametros.strUsuarioLogin == "mtapia" || Parametros.strUsuarioLogin == "marjorie" || Parametros.strUsuarioLogin == "pmoscaiza")
                //    {
                //        CambioBE objE_Cambio = (CambioBE)gvCambio.GetRow(gvCambio.FocusedRowHandle);
                //        frmCambiarCliente objDescuento = new frmCambiarCliente();
                //        objDescuento.IdCambio = objE_Cambio.IdCambio;
                //        objDescuento.StartPosition = FormStartPosition.CenterParent;
                //        if (objDescuento.ShowDialog() == DialogResult.OK)
                //        {
                //            Cargar();
                //        }
                //    }
                //    else
                //    {
                //        XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        Cursor = Cursors.Default;
                //    }

                //}

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportarexcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "jvasquez" || Parametros.strUsuarioLogin == "mtapia" || Parametros.strUsuarioLogin == "marjorie")
                {
                    frmExportarExcelDevoluciones objExportar = new frmExportarExcelDevoluciones();
                    objExportar.StartPosition = FormStartPosition.CenterParent;
                    objExportar.ShowDialog();

                }
                else
                {
                    XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Cursor = Cursors.Default;
                }


            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void mnuContextual_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CambioBL().ListaTodosActivo(0, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Parametros.intTipoDocCambios);
            gcCambio.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCambio.DataSource = mLista.Where(obj =>
                                                   obj.Numero.ToUpper().Contains(txtNumero.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCambio.RowCount > 0)
            {
                CambioBE objCambio = new CambioBE();
                objCambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                objCambio.IdCambio = int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString());

                frmRegCambioEdit objManCambiolEdit = new frmRegCambioEdit();
                objManCambiolEdit.pOperacion = frmRegCambioEdit.Operacion.Modificar;
                objManCambiolEdit.IdCambio = objCambio.IdCambio;
                objManCambiolEdit.IdEmpresa = objCambio.IdEmpresa;
                objManCambiolEdit.StartPosition = FormStartPosition.CenterParent;
                objManCambiolEdit.btnGrabar.Enabled = true;
                objManCambiolEdit.ShowDialog();

                Cargar();

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

            if (gvCambio.GetFocusedRowCellValue("IdCambio").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Solicitud", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}