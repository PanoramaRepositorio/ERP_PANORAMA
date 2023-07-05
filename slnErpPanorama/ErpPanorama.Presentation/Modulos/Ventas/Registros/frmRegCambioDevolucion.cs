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
    public partial class frmRegCambioDevolucion : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<CambioBE> mLista = new List<CambioBE>();
        
        #endregion

        #region "Eventos"

        public frmRegCambioDevolucion()
        {
            InitializeComponent();
        }

        private void frmRegCambioDevolucion_Load(object sender, EventArgs e)
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
                frmRegCambioDevolucionEdit objManCambio = new frmRegCambioDevolucionEdit();
                objManCambio.lstCambio = mLista;
                objManCambio.pOperacion = frmRegCambioDevolucionEdit.Operacion.Nuevo;
                objManCambio.IdCambio = 0;
                objManCambio.StartPosition = FormStartPosition.CenterParent;
                if (objManCambio.ShowDialog() == DialogResult.OK)
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
                        CambioBE objE_Cambio = (CambioBE)gvCambio.GetRow(gvCambio.FocusedRowHandle);
                        objE_Cambio.Usuario = Parametros.strUsuarioLogin;
                        objE_Cambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Cambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());

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
                    bool flagAprobado = true;
                    flagAprobado = bool.Parse(gvCambio.GetFocusedRowCellValue("FlagAprobado").ToString());
                    if (flagAprobado)
                    {

                        int IdEmpresa = 0;
                        IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                        if (IdEmpresa == Parametros.intPanoraramaDistribuidores || IdEmpresa == Parametros.intCoronaImportadores || IdEmpresa == Parametros.intTapiaTarrilloEleazar || IdEmpresa == Parametros.intHuamanBramonTeodoraAmalia || IdEmpresa == Parametros.intTapiaCalderonOlgaLidia)
                        {
                            List<ReporteCambioBE> lstReporte = null;
                            lstReporte = new ReporteCambioBL().Listado(int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString()));

                            if (lstReporte != null)
                            {
                                if (lstReporte.Count > 0)
                                {
                                    lstReporte = FunctionDscCumpleanios(lstReporte);
                                    RptVistaReportes objRptCambio = new RptVistaReportes();
                                    objRptCambio.VerRptCambio(lstReporte);
                                    objRptCambio.ShowDialog();
                                }
                                else
                                    XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            
                        }
                        else
                        {
                            List<ReporteCambioBE> lstReporte = null;
                            lstReporte = new ReporteCambioBL().Listado(int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString()));

                            if (lstReporte != null)
                            {
                                if (lstReporte.Count > 0)
                                {
                                    lstReporte = FunctionDscCumpleanios(lstReporte);
                                    RptVistaReportes objRptCambio = new RptVistaReportes();
                                    objRptCambio.VerRptCambio(lstReporte);
                                    objRptCambio.ShowDialog();
                                }
                                else
                                    XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                        XtraMessageBox.Show("La solicitud de devolución no se puede imprimir porque no ha sido aprobada\n por favor comunicarse con la supervisora de ventas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<ReporteCambioBE> FunctionDscCumpleanios(List<ReporteCambioBE> lisReporteCambioBE)
        {
            try
            {
                var eCambio = lisReporteCambioBE.FirstOrDefault(x => x.FlagCumpleanios == true);
                if (eCambio != null)
                {
                    if (eCambio.FlagCumpleanios)
                    {
                        List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(eCambio.IdDocumentoVenta);

                        decimal detotalDsctoCumple = 0;
                        foreach (var item in lisReporteCambioBE)
                        {
                            var eDocumentoVentaDet = lstTmpDocumentoVentaDetalle.FirstOrDefault(x => x.IdProducto == item.IdProducto);
                            if (eDocumentoVentaDet != null)
                            {
                                detotalDsctoCumple = new PedidoBL().lgDescuentoPorCumpleanios(detotalDsctoCumple, eDocumentoVentaDet.IdMarca, eDocumentoVentaDet.PorcentajeDescuento, item.ValorVenta);
                            }
                        }
                        lisReporteCambioBE.ToList().ForEach(s =>
                        {
                            s.TotalDscCumpleanios = detotalDsctoCumple;
                        });
                    }
                }
                return lisReporteCambioBE;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return lisReporteCambioBE;
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
                    bool flagAprobado = bool.Parse(gvCambio.GetFocusedRowCellValue("FlagAprobado").ToString());
                    if (flagAprobado)
                    {
                        XtraMessageBox.Show("La solicitud de devolución ya se aprobó", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                        return;
                    }

                    frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                     frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                     frmAutoriza.ShowDialog();

                     if (frmAutoriza.Edita)
                     {
                        CambioBE objE_Cambio = (CambioBE)gvCambio.GetRow(gvCambio.FocusedRowHandle);
                        CambioBL objBL_Cambio = new CambioBL();
                        if (frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "oguevara" || frmAutoriza.Usuario == "dhuaman" 
                            || frmAutoriza.IdPerfil == Parametros.intSupervisoraVentaPisoDiseno  || frmAutoriza.IdPerfil == Parametros.intPerSupervisorVentasPiso 
                            || frmAutoriza.IdPerfil == Parametros.intPerAdministrador            || frmAutoriza.IdPerfil == Parametros.intPerAsistenteCreditos 
                            || frmAutoriza.IdPerfil == Parametros.intPerSubAdministrador         || frmAutoriza.IdPerfil == Parametros.intPerHelpDesk
                            || frmAutoriza.Usuario == "oherrera" || frmAutoriza.Usuario == "eprado" || frmAutoriza.Usuario == "kangeles" || frmAutoriza.Usuario == "kconcha" || frmAutoriza.Usuario == "focampo") 
                        {
                            
                             objBL_Cambio.ActualizaAprobado(objE_Cambio.IdEmpresa, objE_Cambio.IdCambio, true, frmAutoriza.IdPersona);
                       
                             XtraMessageBox.Show("La solicitud de devolución se aprobó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                             Cursor = Cursors.Default;

                             Cargar();
                         }
                        else
                        if (objE_Cambio.DescTipoCliente == "CLIENTE MAYORISTA" && frmAutoriza.IdPerfil == Parametros.intPerJefeCanalMayorista)
                        {
                            objBL_Cambio.ActualizaAprobado(objE_Cambio.IdEmpresa, objE_Cambio.IdCambio, true, frmAutoriza.IdPersona);

                            XtraMessageBox.Show("La solicitud de devolución se aprobó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void recibirdevolucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    bool FlagRecibido = bool.Parse(gvCambio.GetFocusedRowCellValue("FlagRecibido").ToString());
                    if (FlagRecibido)
                    {
                        XtraMessageBox.Show("La solicitud de devolución ya se recibió", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cursor = Cursors.Default;
                        return;
                    }

                    bool flagAprobado = true;
                    flagAprobado = bool.Parse(gvCambio.GetFocusedRowCellValue("FlagAprobado").ToString());
                    if (flagAprobado)
                    {
                        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                        frmAutoriza.ShowDialog();

                        if (frmAutoriza.Edita)
                        {
                            if (frmAutoriza.Usuario == "master" || frmAutoriza.IdPerfil == Parametros.intPerSupervisorAlmacenTienda || 
                                frmAutoriza.IdPerfil == Parametros.intPerJefeAlmacen || frmAutoriza.IdPerfil == Parametros.intPerAdministrador || 
                                frmAutoriza.IdPerfil == Parametros.intPerSupervisorAlmacen || frmAutoriza.IdPerfil == Parametros.intPerAsistenteAlmacen || 
                                frmAutoriza.IdPerfil == Parametros.intPerSupervisorVentasPiso && Parametros.intTiendaId == Parametros.intTiendaMegaplaza || 
                                frmAutoriza.IdPerfil == Parametros.intPerHelpDesk || frmAutoriza.IdPerfil == Parametros.intPerCoordinadorAlmacen ||
                                frmAutoriza.IdPerfil == Parametros.intPerAdministradorTienda )
                            {
                                bool flagRecibido = true;
                                flagRecibido = bool.Parse(gvCambio.GetFocusedRowCellValue("FlagRecibido").ToString());
                                if (!flagRecibido)
                                {
                                    int IdEmpresaEmisora = 0;
                                    IdEmpresaEmisora = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());

                                    if (IdEmpresaEmisora == Parametros.intPanoraramaDistribuidores 
                                        || IdEmpresaEmisora == Parametros.intCoronaImportadores 
                                        || IdEmpresaEmisora == Parametros.intTapiaTarrilloEleazar 
                                        || IdEmpresaEmisora == Parametros.intHuamanBramonTeodoraAmalia 
                                        || IdEmpresaEmisora == Parametros.intTapiaCalderonOlgaLidia)
                                    {
                                        CambioBE objCambio = new CambioBE();

                                        objCambio.IdTipoDocumento = int.Parse(gvCambio.GetFocusedRowCellValue("IdTipoDocumento").ToString());
                                        objCambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                                        objCambio.IdTienda = int.Parse(gvCambio.GetFocusedRowCellValue("IdTienda").ToString());
                                        objCambio.IdCambio = int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString());
                                        objCambio.Periodo = int.Parse(gvCambio.GetFocusedRowCellValue("Periodo").ToString());
                                        objCambio.Fecha = DateTime.Parse(gvCambio.GetFocusedRowCellValue("Fecha").ToString());
                                        objCambio.Numero = gvCambio.GetFocusedRowCellValue("Numero").ToString();
                                        objCambio.Usuario = frmAutoriza.Usuario; // Parametros.strUsuarioLogin;
                                        objCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                        objCambio.IdPersonaRecibido = frmAutoriza.IdPersona; //  Parametros.intPersonaId;

                                        List<CambioDetalleBE> mListaCambioDetalle = null;
                                        mListaCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objCambio.IdCambio);

                                        CambioBL objBL_Cambio = new CambioBL();
                                        objBL_Cambio.ActualizaRecibido(objCambio, mListaCambioDetalle);

                                        XtraMessageBox.Show("La solicitud de devolución se recibió correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Cargar();
                                        Cursor = Cursors.Default;
                                    }
                                    else
                                    {
                                        CambioBL objBL_Cambio = new CambioBL();
                                        CambioBE objCambio = new CambioBE();
                                        objCambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                                        objCambio.IdTienda = int.Parse(gvCambio.GetFocusedRowCellValue("IdTienda").ToString());
                                        objCambio.IdCambio = int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString());
                                        objCambio.Periodo = int.Parse(gvCambio.GetFocusedRowCellValue("Periodo").ToString());
                                        objCambio.Fecha = DateTime.Parse(gvCambio.GetFocusedRowCellValue("Fecha").ToString());
                                        objCambio.Numero = gvCambio.GetFocusedRowCellValue("Numero").ToString();
                                        objCambio.Usuario = frmAutoriza.Usuario; // Parametros.strUsuarioLogin;
                                        objCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                        objCambio.IdPersonaRecibido = frmAutoriza.IdPersona;  //Parametros.intPersonaId;

                                        objBL_Cambio.ActualizaSituacion(objCambio.IdEmpresa, objCambio.IdCambio, true, frmAutoriza.IdPersona); //add 280616
                                        gvCambio.SetRowCellValue(gvCambio.FocusedRowHandle, "FlagRecibido", true);

                                        XtraMessageBox.Show("La solicitud de devolución se recibió correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Cursor = Cursors.Default;
                                    }
                                }
                                else
                                {
                                    XtraMessageBox.Show("La solicitud de devolución esta recibida.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    Cursor = Cursors.Default;
                                }


                                Cursor = Cursors.Default;

                                Cargar();
                            }
                            else
                            {
                                XtraMessageBox.Show("Ud. no tiene los permisos para esta operación\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("La solicitud de devolución no se puede recibir porque no ha sido APROBADA\n por favor comunicarse con la supervisora de ventas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "omoreno" || Parametros.strUsuarioLogin == "jrodriguez" || Parametros.strUsuarioLogin == "aflores" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "pmoscaiza" || Parametros.intPerfilId == Parametros.intPerSupervisorAlmacenTienda || Parametros.intPerfilId == Parametros.intPerAsistenteAlmacen || Parametros.intPerfilId == Parametros.intPerHelpDesk)
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
                                CambioBL objBL_Cambio = new CambioBL();
                                CambioBE objCambio = new CambioBE();
                                objCambio.IdEmpresa = int.Parse(gvCambio.GetFocusedRowCellValue("IdEmpresa").ToString());
                                objCambio.IdTienda = int.Parse(gvCambio.GetFocusedRowCellValue("IdTienda").ToString());
                                objCambio.IdCambio = int.Parse(gvCambio.GetFocusedRowCellValue("IdCambio").ToString());
                                objCambio.Periodo = int.Parse(gvCambio.GetFocusedRowCellValue("Periodo").ToString());
                                objCambio.Fecha = DateTime.Parse(gvCambio.GetFocusedRowCellValue("Fecha").ToString());
                                objCambio.Numero = gvCambio.GetFocusedRowCellValue("Numero").ToString();
                                objCambio.Usuario = Parametros.strUsuarioLogin;
                                objCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                                objBL_Cambio.ActualizaSituacion(objCambio.IdEmpresa, objCambio.IdCambio, false, Parametros.intPersonaId); //add 280616
                                gvCambio.SetRowCellValue(gvCambio.FocusedRowHandle, "FlagRecibido", false);

                                //List<CambioDetalleBE> mListaCambioDetalle = null;
                                //mListaCambioDetalle = new CambioDetalleBL().ListaTodosActivo(objCambio.IdCambio);
                                //objBL_Cambio.AnulaRecibido(objCambio, mListaCambioDetalle);

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
                    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "liliana" || Parametros.strUsuarioLogin == "mtapia" || Parametros.strUsuarioLogin == "marjorie" || Parametros.strUsuarioLogin == "pmoscaiza"|| Parametros.intPerfilId == Parametros.intPerSupervisorVentasPiso || Parametros.intPerfilId == Parametros.intPerHelpDesk)
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

                if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || Parametros.strUsuarioLogin == "aflores" || Parametros.strUsuarioLogin == "mtapia" || Parametros.strUsuarioLogin == "marjorie" || Parametros.strUsuarioLogin == "dhuaman" || Parametros.intPerfilId == Parametros.intPerHelpDesk)
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

        private void btnConsultarMasInformacion_Click(object sender, EventArgs e)
        {

        }

        private void gvCambio_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvCambio.RowCount.ToString() + " Registros encontrados";
        }

        private void cboMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CambioBL().ListaTodosActivo(0, Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Parametros.intTipoDocCambiosDevoluciones);
            gcCambio.DataSource = mLista;
            lblTotalRegistros.Text = mLista.Count.ToString() + " Registros encontrados";
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

                frmRegCambioDevolucionEdit objManCambiolEdit = new frmRegCambioDevolucionEdit();
                objManCambiolEdit.pOperacion = frmRegCambioDevolucionEdit.Operacion.Modificar;
                objManCambiolEdit.IdCambio = objCambio.IdCambio;
                objManCambiolEdit.IdEmpresa = objCambio.IdEmpresa;
                objManCambiolEdit.StartPosition = FormStartPosition.CenterParent;
                objManCambiolEdit.btnGrabar.Enabled = true;
                if (objManCambiolEdit.ShowDialog() == DialogResult.OK)
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