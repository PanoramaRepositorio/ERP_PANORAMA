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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegReciboPago : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<PagosBE> mLista = new List<PagosBE>();

        DataTable dt = new DataTable();
        
        #endregion

        #region "Eventos"

        public frmRegReciboPago()
        {
            InitializeComponent();
        }

        private void frmRegReciboPago_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            cboTienda.EditValue = Parametros.intTiendaId;
            cboCaja.EditValue = Parametros.intCajaId;
            //BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTiendaId), "DescCaja", "IdCaja", true);

            //cboCaja.EditValue = Parametros.intCajaId;
            deFecha.EditValue = DateTime.Now;
            deFechaHasta.EditValue = DateTime.Now;

            Cargar();


            if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "rcastañeda" || Parametros.strUsuarioLogin == "mmendozac"
                || Parametros.strUsuarioLogin == "nillanes" || Parametros.intPerfilId == Parametros.intPerAdministrador)
            {
                cboEmpresa.Enabled = true;
                cboTienda.Enabled = true;
                cboCaja.Enabled = true;

                btnConsultarTodo.Visible = true;
                lblFechaHasta.Visible = true;
                deFechaHasta.Visible = true;
            }
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegReciboPagoEdit objManReciboPago = new frmRegReciboPagoEdit();
                objManReciboPago.lstPago = new PagosBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue),Convert.ToDateTime(deFecha.EditValue), Parametros.intTipoDocReciboPago);
                objManReciboPago.pOperacion = frmRegReciboPagoEdit.Operacion.Nuevo;
                objManReciboPago.IdPago = 0;
                objManReciboPago.FechaD = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                objManReciboPago.StartPosition = FormStartPosition.CenterParent;
                objManReciboPago.ShowDialog();

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
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro, Esto podría afectar el estado de cuenta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        //Datos del Recibo de Pago
                       PagosBE objE_Pagos = new PagosBE();
                        objE_Pagos.IdPago = int.Parse(gvReciboPago.GetFocusedRowCellValue("IdPago").ToString());
                        objE_Pagos.Usuario = Parametros.strUsuarioLogin;
                        objE_Pagos.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Pagos.IdEmpresa = Parametros.intEmpresaId;

                        //Datos del Movimiento de Caja
                        MovimientoCajaBE objE_MovimientoCaja = null;
                        objE_MovimientoCaja = new MovimientoCajaBL().SeleccionaNumero(int.Parse(gvReciboPago.GetFocusedRowCellValue("IdEmpresa").ToString()), Parametros.intTipoDocReciboPago, gvReciboPago.GetFocusedRowCellValue("NumeroDocumento").ToString());
                        objE_MovimientoCaja.Usuario = objE_Pagos.Usuario;

                        PagosBL objBL_Pagos = new PagosBL();
                        objBL_Pagos.Elimina(objE_Pagos, objE_MovimientoCaja);
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
            if (gvReciboPago.RowCount > 0)
            {
                int IdPagoDocumento =  int.Parse(gvReciboPago.GetFocusedRowCellValue("IdPago").ToString());
                //Imprimir(IdPagoDocumento);
            }
         
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoReciboPago";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvReciboPago.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvReciboPago_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void deFecha_EditValueChanged(object sender, EventArgs e)
        {
            if (deFecha.DateTime > Convert.ToDateTime("01/01/2000"))
            {
                ValidarCierre();
            }
        }

        private void cboCaja_EditValueChanged(object sender, EventArgs e)
        {
            if (deFecha.DateTime > Convert.ToDateTime("01/01/2000"))
            {
                ValidarCierre();
            }
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            dt = FuncionBase.ToDataTable(new PagosBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboCaja.EditValue), Convert.ToDateTime(deFecha.EditValue), Convert.ToDateTime(deFecha.EditValue), Parametros.intTipoDocReciboPago));
            gcReciboPago.DataSource = dt;
        }

        public void InicializarModificar()
        {
            if (gvReciboPago.RowCount > 0)
            {
                List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();
                lstMovimientoCaja = new MovimientoCajaBL().ListaPagos(int.Parse(gvReciboPago.GetFocusedRowCellValue("IdPago").ToString()));

                if (lstMovimientoCaja != null)
                {
                    if (lstMovimientoCaja.Count() > 1)
                    {
                        XtraMessageBox.Show("No se puede Editar un documento que tiene diferentes medios de pagos \nSe recomienda eliminar el documento y generar otro, Esto podría afectar el estado de cuenta \nConsulte con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }


                PagosBE objReciboPago = new PagosBE();
                objReciboPago.IdPago = int.Parse(gvReciboPago.GetFocusedRowCellValue("IdPago").ToString());
                objReciboPago.Fecha = DateTime.Parse(gvReciboPago.GetFocusedRowCellValue("Fecha").ToString());

                frmRegReciboPagoEdit objRegReciboPagoEdit = new frmRegReciboPagoEdit();
                objRegReciboPagoEdit.pOperacion = frmRegReciboPagoEdit.Operacion.Modificar;
                objRegReciboPagoEdit.IdPago = objReciboPago.IdPago;
                objRegReciboPagoEdit.FechaD = objReciboPago.Fecha;
                objRegReciboPagoEdit.vCodigoGiftCard = gvReciboPago.GetFocusedRowCellValue("CodigoGiftCard").ToString();
                objRegReciboPagoEdit.StartPosition = FormStartPosition.CenterParent;
                objRegReciboPagoEdit.ShowDialog();

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

            if (gvReciboPago.GetFocusedRowCellValue("IdPago").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void ValidarCierre()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<CajaCierreBE> Obj_CajaCierre = new List<CajaCierreBE>();
                Obj_CajaCierre = new CajaCierreBL().ListaFechaCaja(Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()), Convert.ToInt32(cboCaja.EditValue));

                if (Obj_CajaCierre.Count > 0)
                {
                    XtraMessageBox.Show("La Caja está Cerrada!, no se puede modificar, Consulte con su administrador", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    DesHabilitarBotones();
                }
                else
                {
                    HabilitarBotones();
                    Cargar();
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HabilitarBotones()
        {
            tlbMenu.Enabled = true;
            gcReciboPago.Enabled = true;
        }

        private void DesHabilitarBotones()
        {
            tlbMenu.Enabled = false;
            gcReciboPago.Enabled = false;
        }

        private void Imprimir(int IdPagoI)
        {
            PagosBE objE_Pago = null;
            objE_Pago = new PagosBL().Selecciona(Parametros.intEmpresaId, IdPagoI);

            if (objE_Pago != null)
            {
                string dirFacturacion = "<No Especificado>";

                if (Parametros.intTiendaId == Parametros.intTiendaUcayali && Parametros.intCajaId == Parametros.intCajaToldo2 || Parametros.intCajaId == Parametros.intCaja7)
                {
                    dirFacturacion = Parametros.strDireccionUcayali2;
                }
                else
                {
                    dirFacturacion = Parametros.strDireccionUcayali;
                }

                if (Parametros.intTiendaId == Parametros.intTiendaAndahuaylas)
                {
                    dirFacturacion = Parametros.strDireccionAndahuaylas;
                }
                if (Parametros.intTiendaId == Parametros.intTiendaKonceptos)
                {
                    dirFacturacion = Parametros.strDireccionMegaplaza;
                }
                if (Parametros.intTiendaId == Parametros.intTiendaPrescott)
                {
                    dirFacturacion = Parametros.strDireccionPrescott;
                }

                #region "Ticket Pago"

                //TalonBE objTalon = null;
                //objTalon = new TalonBL().SeleccionaCajaDocumento(Parametros.intEmpresaId, Parametros.intTiendaId, Parametros.intCajaId, Parametros.intTipoDocReciboPago);

                CreaTicket ticket = new CreaTicket();

                #region "Busca Impresora"
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

                    //if (printer.ToUpper().StartsWith(objTalon.Impresora))//("(T)"))
                    if (printer.ToUpper().StartsWith("(T)"))
                    {
                        found = true;
                        ticket.impresora = @printer;
                    }
                }

                if (!found)
                {
                    //MessageBox.Show("La impresora " + objTalon.Impresora + " Nombre para Ticket no ha sido encontrada.");
                    MessageBox.Show("La impresora (T) Nombre para Ticket no ha sido encontrada.");
                }
                #endregion

                string MonedaLetra = "";
                decimal ImportePago = 0;
                if (objE_Pago.IdMoneda == Parametros.intSoles)
                {
                    MonedaLetra = " Soles";
                    ImportePago = objE_Pago.ImporteSoles;
                }
                else
                {
                    MonedaLetra = " Dolares";
                    ImportePago = objE_Pago.ImporteDolares;
                }


                //ticket.AbreCajon();  //abre el cajon

                //ticket.TextoCentro("PANORAMA DISTRIBUIDORES S.A");
                //ticket.TextoCentro(dirFacturacion);
                //ticket.TextoCentro("RUC: 20330676826");
                //ticket.TextoCentro(objTalon.NombreComercial);
                ticket.TextoCentro(Parametros.strEmpresaNombre);
                ticket.TextoCentro(dirFacturacion);
                if (Parametros.intEmpresaId == Parametros.intCoronaImportadores) ticket.TextoCentro("INDEPENDENCIA - LIMA - LIMA");
                ticket.TextoIzquierda("");
                //ticket.TextoCentro(Parametros.strEmpresaRuc);
                //ticket.TextoCentro("AUT: " + objTalon.NumeroAutoriza);
                //ticket.TextoCentro("SERIE: " + objTalon.SerieImpresora);
                ticket.TextoIzquierda("RECIBO N° " + objE_Pago.NumeroDocumento + "     " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                ticket.TextoIzquierda("TIENDA: " + Parametros.strDescTienda);
                ticket.TextoIzquierda("USUARIO: " + Parametros.strUsuarioLogin);
                ticket.TextoIzquierda("CAJA: " + Parametros.strDescCaja);
                ticket.LineasGuion();
                //ticket.EncabezadoVenta();
                ticket.TextoIzquierdaNLineas("RECIBI DE: " + objE_Pago.DescCliente);
                ticket.LineasGuion();
                ticket.TextoIzquierdaNLineas("La Cantidad de: " + FuncionBase.Enletras(Math.Round(Convert.ToDouble(ImportePago), 2).ToString()) + MonedaLetra);
                ticket.LineasGuion();
                ticket.TextoIzquierdaNLineas("CONCEPTO: " + objE_Pago.Concepto);
                ticket.TextoIzquierda("");

                //ticket.AgregaArticuloCodigo(Convert.ToInt32(item.Cantidad), Convert.ToString(item.Abreviatura), Convert.ToString(item.CodigoProveedor));
                //ticket.AgregaArticuloDetalle(item.NombreProducto, Convert.ToDouble(Math.Round(item.PrecioVenta, 2)), Convert.ToDouble(Math.Round(item.ValorVenta, 2)));
                ////}
                ticket.LineasTotales();
                //if (Convert.ToDouble(txtTotalBruto.EditValue) > Convert.ToDouble(txtTotal.EditValue)) //add 20 may 15
                //{
                //    ticket.AgregaTotales("Total", Math.Round(Convert.ToDouble(txtTotalBruto.EditValue), 2));
                //    ticket.AgregaTotales("Descuento 2x1", Math.Round((Convert.ToDouble(txtTotalBruto.EditValue) - Convert.ToDouble(txtTotal.EditValue)) * -1, 2));
                //}


                ticket.TextoDerecha("Total " + objE_Pago.CodMoneda +" "+ Math.Round(Convert.ToDouble(ImportePago), 2)); // imprime linea con total
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("");
                ticket.TextoIzquierda("");
                ticket.TextoCentro(new String('-', Parametros.strEmpresaNombre.Length));
                ticket.TextoCentro(Parametros.strEmpresaNombre);
                //ticket.TextoIzquierda("");
                //ticket.TextoCentro("www.panoramadistribuidores.com");
                ticket.CortaTicket();

                #endregion

            }

        }

        #endregion

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue)), "DescTienda", "IdTienda", true);
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
        }

        private void btnConsultarTodo_Click(object sender, EventArgs e)
        {
            dt = FuncionBase.ToDataTable(new PagosBL().ListaTodosActivo(Parametros.intEmpresaId, 0, Convert.ToDateTime(deFecha.EditValue), Convert.ToDateTime(deFechaHasta.EditValue), Parametros.intTipoDocReciboPago));
            gcReciboPago.DataSource = dt;
        }

        private void lblFechaHasta_Click(object sender, EventArgs e)
        {

        }

        private void deFechaHasta_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}