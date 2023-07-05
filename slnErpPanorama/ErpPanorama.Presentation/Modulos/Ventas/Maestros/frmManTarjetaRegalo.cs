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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManTarjetaRegalo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TarjetaRegaloBE> mLista = new List<TarjetaRegaloBE>();

        #endregion

        #region "Eventos"
        public frmManTarjetaRegalo()
        {
            InitializeComponent();
        }

        private void frmManTarjetaRegalo_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0,0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }
        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTarjetaRegaloEdit objManTarjetaRegalo = new frmManTarjetaRegaloEdit();
                objManTarjetaRegalo.lstTarjetaRegalo = mLista;
                objManTarjetaRegalo.pOperacion = frmManTarjetaRegaloEdit.Operacion.Nuevo;
                objManTarjetaRegalo.IdTarjetaRegalo = 0;
                objManTarjetaRegalo.StartPosition = FormStartPosition.CenterParent;
                objManTarjetaRegalo.ShowDialog();
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
                        TarjetaRegaloBE objE_TarjetaRegalo = new TarjetaRegaloBE();
                        objE_TarjetaRegalo.IdTarjetaRegalo = int.Parse(gvTarjetaRegalo.GetFocusedRowCellValue("IdTarjetaRegalo").ToString());
                        objE_TarjetaRegalo.Usuario = Parametros.strUsuarioLogin;
                        objE_TarjetaRegalo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TarjetaRegalo.IdEmpresa = Parametros.intEmpresaId;

                        TarjetaRegaloBL objBL_TarjetaRegalo = new TarjetaRegaloBL();
                        objBL_TarjetaRegalo.Elimina(objE_TarjetaRegalo);
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
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReporteTarjetaRegaloBE> lstReporte = null;
            //    lstReporte = new ReporteTarjetaRegaloBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTarjetaRegalo = new RptVistaReportes();
            //            objRptTarjetaRegalo.VerRptTarjetaRegalo(lstReporte);
            //            objRptTarjetaRegalo.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoTarjetaRegalos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTarjetaRegalo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTarjetaRegalo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new TarjetaRegaloBL().ListaTodosActivo(Parametros.intEmpresaId,0);
            gcTarjetaRegalo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTarjetaRegalo.DataSource = mLista.Where(obj =>
                                                   obj.Numero.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTarjetaRegalo.RowCount > 0)
            {
                TarjetaRegaloBE objTarjetaRegalo = new TarjetaRegaloBE();
                objTarjetaRegalo.IdTarjetaRegalo = int.Parse(gvTarjetaRegalo.GetFocusedRowCellValue("IdTarjetaRegalo").ToString());
                objTarjetaRegalo.Numero = gvTarjetaRegalo.GetFocusedRowCellValue("Numero").ToString();
                objTarjetaRegalo.FlagEstado = Convert.ToBoolean(gvTarjetaRegalo.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTarjetaRegaloEdit objManTarjetaRegaloEdit = new frmManTarjetaRegaloEdit();
                objManTarjetaRegaloEdit.pOperacion = frmManTarjetaRegaloEdit.Operacion.Modificar;
                objManTarjetaRegaloEdit.IdTarjetaRegalo = objTarjetaRegalo.IdTarjetaRegalo;
                objManTarjetaRegaloEdit.pTarjetaRegaloBE = objTarjetaRegalo;
                objManTarjetaRegaloEdit.StartPosition = FormStartPosition.CenterParent;
                objManTarjetaRegaloEdit.ShowDialog();

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

            if (gvTarjetaRegalo.GetFocusedRowCellValue("IdTarjetaRegalo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Tarjeta de Regalo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

        private void imprimirDocumentolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    int IdEmpresa = 0;
            //    int IdTipoDocumento = 0;
            //    string TipoDoc = "";
            //    string NumeroDocumento = "";
            //    string Serie = "";
            //    string Numero = "";

            //    if (mLista.Count > 0)
            //    {
            //        IdEmpresa = int.Parse(gvTarjetaRegalo.GetFocusedRowCellValue("IdEmpresa").ToString());
            //        IdTipoDocumento = int.Parse(gvTarjetaRegalo.GetFocusedRowCellValue("IdTipoDocumento").ToString());
            //        TipoDoc = gvTarjetaRegalo.GetFocusedRowCellValue("CodTipoDocumento").ToString();
            //        NumeroDocumento = gvTarjetaRegalo.GetFocusedRowCellValue("NumeroDocumento").ToString();
            //        Serie = NumeroDocumento.Substring(0, 3);
            //        Numero = NumeroDocumento.Substring(4, 6);
            //    }

            //    string dirFacturacion = "<No Especificado>";

            //    if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2)
            //    {
            //        dirFacturacion = Parametros.strDireccionUcayali2;
            //    }
            //    else
            //    {
            //        dirFacturacion = Parametros.strDireccionUcayali;
            //    }
            //    if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)
            //    {
            //        dirFacturacion = Parametros.strDireccionAndahuaylas;
            //    }
            //    if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)
            //    {
            //        dirFacturacion = Parametros.strDireccionMegaplaza;
            //    }
            //    if (Parametros.intTiendaId == Parametros.intTiendaPrescott)
            //    {
            //        dirFacturacion = Parametros.strDireccionPrescott;
            //    }

            //    if (TipoDoc == "TKV")
            //    {
            //        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            //        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            //        frmAutoriza.ShowDialog();

            //        if (frmAutoriza.Edita)
            //        {
            //            if (frmAutoriza.Usuario == "rcastañeda" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador)
            //            {
            //                #region "Ticket TKV"
            //                DocumentoVentaBE objDocumento = null;
            //                objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento, Serie, Numero);

            //                TalonBE objTalon = null;
            //                objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, IdTipoDocumento);


            //                if (objDocumento != null)
            //                {
            //                    CreaTicket ticket = new CreaTicket();

            //                    #region "Busca Impresora"
            //                    bool found = false;
            //                    PrinterSettings prtSetting = new PrinterSettings();
            //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
            //                    {
            //                        string printer = "";
            //                        if (prtName.StartsWith("\\\\"))
            //                        {
            //                            printer = prtName.Substring(3);
            //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
            //                        }
            //                        else
            //                            printer = prtName;

            //                        if (printer.ToUpper().StartsWith(objTalon.Impresora))//StartsWith("(T)"))
            //                        {
            //                            found = true;
            //                            ticket.impresora = @printer;
            //                        }
            //                    }

            //                    if (!found)
            //                    {
            //                        MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
            //                    }
            //                    #endregion

            //                    //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
            //                    //ticket.TextoCentro(dirFacturacion);
            //                    //ticket.TextoCentro("RUC: 20330676826");
            //                    ticket.TextoCentro(objTalon.NombreComercial);
            //                    ticket.TextoCentro(Parametros.strEmpresaNombre);
            //                    ticket.TextoCentro(objTalon.DireccionFiscal);
            //                    //if (objTalon.IdEmpresa == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
            //                    if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
            //                    ticket.TextoCentro(Parametros.strEmpresaRuc);
            //                    ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
            //                    ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
            //                    ticket.TextoIzquierda(TipoDoc + Serie + "-" + Numero + "  " + objDocumento.Fecha.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            //                    ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja);
            //                    ticket.TextoIzquierda("CLIENTE:" + objDocumento.DescCliente);
            //                    ticket.LineasGuion();
            //                    ticket.EncabezadoVenta();

            //                    List<DocumentoVentaDetalleBE> lstReporte = null;
            //                    lstReporte = new DocumentoVentaDetalleBL().ListaTodosActivo(objDocumento.IdDocumentoVenta);

            //                    foreach (var item in lstReporte)
            //                    {
            //                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
            //                        //ticket.AgregaArticuloDetalle(item.NombreProducto.PadRight(, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
            //                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
            //                    }
            //                    ticket.LineasTotales();
            //                    if (objDocumento.TotalBruto > objDocumento.Total) //add 20 may 15
            //                    {
            //                        ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(objDocumento.TotalBruto), 2));
            //                        ticket.AgregaTotales("Descuento", Math.Round((Convert.ToDouble(objDocumento.TotalBruto) - Convert.ToDouble(objDocumento.Total)) * -1, 2));
            //                    }
            //                    ticket.AgregaTotales("Total a Pagar", Math.Round(Convert.ToDouble(objDocumento.Total), 2)); // imprime linea con total
            //                    ticket.TextoIzquierda("");
            //                    ticket.TextoIzquierda("Ven:" + objDocumento.DescVendedor);
            //                    ticket.TextoIzquierda("Ped:" + objDocumento.NumeroPedido);
            //                    ticket.TextoIzquierda("");
            //                    ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
            //                    ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
            //                    ticket.TextoCentro("");
            //                    ticket.TextoCentro("GRACIAS POR SU COMPRA");
            //                    ticket.TextoIzquierda("");
            //                    ticket.TextoCentro(objTalon.PaginaWeb);
            //                    if (objDocumento.IdPromocionProxima > 0)
            //                    {
            //                        ticket.CortaTicket();
            //                        ticket.TextoCentro("=========================================");
            //                        PromocionProximaBE ojbPromocion = new PromocionProximaBE();
            //                        ojbPromocion = new PromocionProximaBL().Selecciona(objDocumento.IdPromocionProxima);
            //                        ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
            //                        ticket.TextoCentro("=========================================");
            //                    }
            //                    //ticket.TextoCentro("=========================================");
            //                    //ticket.TextoCentro("¡FELICIDADES!");
            //                    //ticket.TextoCentro("Ganaste 10% dscto.");
            //                    //ticket.TextoCentro("en LÍNEA NAVIDEÑA 2016 en las marcas:");
            //                    //ticket.TextoCentro("SANTINI – MIRO – MONTEFIORI – MARANELO");
            //                    //ticket.TextoCentro("valido del 14 al 28 de Octubre del 2016");
            //                    //ticket.TextoCentro("Dscto no acumulable con otras promociones");
            //                    //ticket.TextoCentro("=========================================");
            //                    ticket.CortaTicket();

            //                }

            //                #endregion
            //            }
            //            else
            //            {
            //                XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación\nNo se puede imprimir un duplicado de Ticket.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //        }
            //    }
            //    else
            //        if (TipoDoc == "TKF")
            //    {
            //        frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
            //        frmAutoriza.StartPosition = FormStartPosition.CenterParent;
            //        frmAutoriza.ShowDialog();

            //        if (frmAutoriza.Edita)
            //        {
            //            if (frmAutoriza.Usuario == "rcastañeda" || frmAutoriza.Usuario == "master" || frmAutoriza.Usuario == "ltapia" || frmAutoriza.IdPerfil == Parametros.intPerAdministrador)
            //            {
            //                #region "Ticket TKF"


            //                DocumentoVentaBE objDocumento = null;
            //                objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento, Serie, Numero);

            //                TalonBE objTalon = null;
            //                objTalon = new TalonBL().SeleccionaCajaDocumento(IdEmpresa, Parametros.intTiendaId, Parametros.intCajaId, IdTipoDocumento);

            //                if (objDocumento != null)
            //                {

            //                    CreaTicket ticket = new CreaTicket();

            //                    #region "Busca Impresora"
            //                    bool found = false;
            //                    PrinterSettings prtSetting = new PrinterSettings();
            //                    foreach (string prtName in PrinterSettings.InstalledPrinters)
            //                    {
            //                        string printer = "";
            //                        if (prtName.StartsWith("\\\\"))
            //                        {
            //                            printer = prtName.Substring(3);
            //                            printer = printer.Substring(printer.IndexOf("\\") + 1);
            //                        }
            //                        else
            //                            printer = prtName;

            //                        if (printer.ToUpper().StartsWith(objTalon.Impresora))//StartsWith("(T)"))
            //                        {
            //                            found = true;
            //                            ticket.impresora = @printer;
            //                        }
            //                    }

            //                    if (!found)
            //                    {
            //                        MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
            //                    }
            //                    #endregion

            //                    //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
            //                    //ticket.TextoCentro(dirFacturacion);
            //                    //ticket.TextoCentro("RUC: 20330676826");
            //                    ticket.TextoCentro(objTalon.NombreComercial);
            //                    ticket.TextoCentro(Parametros.strEmpresaNombre);
            //                    ticket.TextoCentro(objTalon.DireccionFiscal);
            //                    //if (objTalon.IdEmpresa == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
            //                    if (objTalon.IdTienda == Parametros.intTiendaMegaplaza) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
            //                    ticket.TextoCentro(Parametros.strEmpresaRuc);
            //                    ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
            //                    ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
            //                    //ticket.TextoIzquierda(TipoDoc + objTalon.NumeroSerie + "-" + Numero + "  " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            //                    ticket.TextoIzquierda(TipoDoc + Serie + "-" + Numero + "  " + objDocumento.Fecha.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
            //                    ticket.TextoIzquierda("CAJA: " + objTalon.DescCaja);
            //                    ticket.TextoIzquierdaNLineas("CLIENTE: " + objDocumento.DescCliente);
            //                    ticket.TextoIzquierda("RUC: " + objDocumento.NumeroDocumento);
            //                    ticket.TextoIzquierdaNLineas("DIR: " + objDocumento.Direccion);
            //                    ticket.LineasGuion();
            //                    ticket.EncabezadoVenta();

            //                    List<DocumentoVentaDetalleBE> lstReporte = null;
            //                    lstReporte = new DocumentoVentaDetalleBL().ListaTodosActivo(objDocumento.IdDocumentoVenta);

            //                    foreach (var item in lstReporte)
            //                    {
            //                        ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
            //                        //ticket.AgregaArticuloDetalle(item.NombreProducto, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
            //                        ticket.AgregaArticuloDetalle(item.NombreProducto + new string(' ', 20), Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
            //                    }
            //                    ticket.LineasTotales();
            //                    if (objDocumento.TotalBruto > objDocumento.Total) //add 20 may 15
            //                    {
            //                        ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(objDocumento.TotalBruto), 2));
            //                        ticket.AgregaTotales("Descuento", Math.Round((Convert.ToDouble(objDocumento.TotalBruto) - Convert.ToDouble(objDocumento.Total)) * -1, 2));
            //                    }
            //                    ticket.AgregaTotales("SubTotal", Math.Round(Convert.ToDouble(objDocumento.SubTotal), 2));
            //                    ticket.AgregaTotales("IGV", Math.Round(Convert.ToDouble(objDocumento.Igv), 2));
            //                    ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(objDocumento.Total), 2));
            //                    ticket.TextoIzquierda("");
            //                    ticket.TextoIzquierdaNLineas("SON:" + FuncionBase.Enletras(Math.Round(Convert.ToDouble(objDocumento.Total), 2).ToString()) + " Soles");
            //                    ticket.TextoIzquierda("");
            //                    ticket.TextoIzquierda("Ven:" + objDocumento.DescVendedor);
            //                    ticket.TextoIzquierda("Ped:" + objDocumento.NumeroPedido);
            //                    ticket.TextoIzquierda("");
            //                    ticket.TextoCentro("UNA VEZ SALIDA LA MERCADERIA NO SE ACEPTAN");
            //                    ticket.TextoCentro("CAMBIOS NI DEVOLUCIONES");
            //                    ticket.TextoCentro("GRACIAS POR SU COMPRA");
            //                    ticket.TextoIzquierda("");
            //                    //ticket.TextoCentro("www.panoramadistribuidores.com");
            //                    ticket.TextoCentro(objTalon.PaginaWeb);
            //                    if (objDocumento.IdPromocionProxima > 0)
            //                    {
            //                        ticket.CortaTicket();
            //                        ticket.TextoCentro("=========================================");
            //                        PromocionProximaBE ojbPromocion = new PromocionProximaBE();
            //                        ojbPromocion = new PromocionProximaBL().Selecciona(objDocumento.IdPromocionProxima);
            //                        ticket.TextoIzquierdaNLineas(ojbPromocion.Mensaje);
            //                        ticket.TextoCentro("=========================================");
            //                    }
            //                    ticket.CortaTicket();


            //                }
            //                #endregion
            //            }
            //            else
            //            {
            //                XtraMessageBox.Show("Ud. no esta autorizado para realizar esta operación\nNo se puede imprimir un duplicado de Ticket.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            }
            //        }
            //    }
            //    else
            //        if (TipoDoc == "BOV")
            //    {
            //        DocumentoVentaBE objDocumento = null;
            //        objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento, Serie, Numero);

            //        List<ReporteDocumentoVentaBE> lstReporte = null;
            //        //lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objDocumento.IdPedido));
            //        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(objDocumento.IdDocumentoVenta);

            //        rptBoletaPanorama objReporteGuia = new rptBoletaPanorama();
            //        objReporteGuia.SetDataSource(lstReporte);

            //        bool found = false;
            //        PrinterSettings prtSetting = new PrinterSettings();
            //        foreach (string prtName in PrinterSettings.InstalledPrinters)
            //        {
            //            string printer = "";
            //            if (prtName.StartsWith("\\\\"))
            //            {
            //                printer = prtName.Substring(3);
            //                printer = printer.Substring(printer.IndexOf("\\") + 1);
            //            }
            //            else
            //                printer = prtName;

            //            if (printer.ToUpper().StartsWith("(B)"))
            //            {
            //                found = true;
            //                PrintOptions bufPO = objReporteGuia.PrintOptions;
            //                prtSetting.PrinterName = prtName;
            //                objReporteGuia.PrintOptions.PrinterName = prtName;

            //                int rawKind = -1;
            //                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
            //                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
            //                {
            //                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
            //                    {
            //                        rawKind = prtSetting.PaperSizes[i].RawKind;
            //                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //                        break;
            //                    }
            //                }
            //                if (rawKind == -1)
            //                {
            //                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //                break;
            //            }
            //        }

            //        if (!found)
            //        {
            //            MessageBox.Show("La impresora (B) Nombre para Boleta Panorama no ha sido encontrada.");

            //        }
            //        objReporteGuia.PrintToPrinter(1, false, 0, 0);
            //    }
            //    else
            //                        if (TipoDoc == "FAV")
            //    {
            //        DocumentoVentaBE objDocumento = null;
            //        objDocumento = new DocumentoVentaBL().SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento, Serie, Numero);

            //        List<ReporteDocumentoVentaBE> lstReporte = null;
            //        //lstReporte = new ReporteDocumentoVentaBL().Listado(Parametros.intPeriodo, Convert.ToInt32(objDocumento.IdPedido));
            //        lstReporte = new ReporteDocumentoVentaBL().ListadoDocumento(objDocumento.IdDocumentoVenta);

            //        rptFacturaPanorama objReporteGuia = new rptFacturaPanorama();
            //        objReporteGuia.SetDataSource(lstReporte);

            //        bool found = false;
            //        PrinterSettings prtSetting = new PrinterSettings();
            //        foreach (string prtName in PrinterSettings.InstalledPrinters)
            //        {
            //            string printer = "";
            //            if (prtName.StartsWith("\\\\"))
            //            {
            //                printer = prtName.Substring(3);
            //                printer = printer.Substring(printer.IndexOf("\\") + 1);
            //            }
            //            else
            //                printer = prtName;

            //            if (printer.ToUpper().StartsWith("(F)"))
            //            {
            //                found = true;
            //                PrintOptions bufPO = objReporteGuia.PrintOptions;
            //                prtSetting.PrinterName = prtName;
            //                objReporteGuia.PrintOptions.PrinterName = prtName;

            //                int rawKind = -1;
            //                CrystalDecisions.CrystalReports.Engine.TextObject crTxt = (CrystalDecisions.CrystalReports.Engine.TextObject)objReporteGuia.ReportDefinition.ReportObjects["PAPERNAME"];
            //                for (int i = 0; i < prtSetting.PaperSizes.Count; i++)
            //                {
            //                    if (prtSetting.PaperSizes[i].PaperName.Trim().ToUpper() == crTxt.Text.Trim().ToUpper())
            //                    {
            //                        rawKind = prtSetting.PaperSizes[i].RawKind;
            //                        objReporteGuia.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)rawKind;
            //                        break;
            //                    }
            //                }
            //                if (rawKind == -1)
            //                {
            //                    MessageBox.Show("La impresora seleccionada no contiene tipo papel requerido [" + crTxt.Text + "]!\r\nNo podrá imprimir este tipo de documento hasta registre el tipo de papel en su impresora.\r\n\r\nComuníquese con personal de sistemas.", "Impresora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //                break;
            //            }
            //        }

            //        if (!found)
            //        {
            //            MessageBox.Show("La impresora (F) Nombre para Boleta Panorama no ha sido encontrada.");

            //        }
            //        objReporteGuia.PrintToPrinter(1, false, 0, 0);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}