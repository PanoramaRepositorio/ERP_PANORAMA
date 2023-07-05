using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Funciones;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegGenerarGuiaRemision : DevExpress.XtraEditors.XtraForm
    {

        #region Propiedades
       public List<CDocumentoVentaDetalle> mListaPEdidoDetalleOrigen = new List<CDocumentoVentaDetalle>();
        

       private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        int _IdDocumentoVenta = 0;
        int _IdPedido;

        public int IdDocumentoVenta
        {
            get { return _IdDocumentoVenta; }
            set { _IdDocumentoVenta = value; }
        }
        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        private int IdTienda = Parametros.intTiendaId;
        private int IdCliente = 0;
        private int IdTipoCliente = 0;
        //private int IdPedido;
        private int IdClasificacionCliente = 0;
        //private int IdClasificacionClienteAsociado = 0;
        private string Serie;
        private string Numero;
        private int IdNumeracionDocumento = 0;

         

        #endregion
        public frmRegGenerarGuiaRemision()
        {
            InitializeComponent();
        }

        private void frmRegGenerarGuiaRemision2_Load(object sender, EventArgs e)
        {
            
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intPanoraramaDistribuidores;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocGuiaRemision;
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboDescAgencia, new AgenciaBL().ListaTodosActivo(), "DescAgencia", "IdAgencia", true);

            cboDocumento.Enabled = false;

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);
            txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
            txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
            txtDireccion.Text = objE_DocumentoVenta.Direccion;
            
        }
        private void cboSerie_EditValueChanged(object sender, EventArgs e)
        {
            List<NumeracionDocumentoBE> lst_Numeracion = new List<NumeracionDocumentoBE>();
            lst_Numeracion = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), cboSerie.Text);
            txtSerie.Text = cboSerie.Text;
            txtNumero.EditValue = lst_Numeracion[0].Numero.ToString();
            IdNumeracionDocumento = lst_Numeracion[0].IdNumeracionDocumento;
        }

        private void cboDocumento_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboSerie, new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo), "Serie", "Serie", true);
        }

        private void btnEditNumeracionDocumento_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketBoleta || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura)
            {
                XtraMessageBox.Show("No se puede alterar la numeración de un Ticket de Venta.\nConsulte con su administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NumeracionDocumentoBE objNumeracionDocumento = new NumeracionDocumentoBE();
            objNumeracionDocumento.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            objNumeracionDocumento.IdNumeracionDocumento = IdNumeracionDocumento;
            objNumeracionDocumento.Periodo = Parametros.intPeriodo;
            objNumeracionDocumento.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
            objNumeracionDocumento.Serie = cboSerie.Text;
            objNumeracionDocumento.Numero = Convert.ToInt32(txtNumero.Text);
            objNumeracionDocumento.FlagEstado = true;

            frmManNumeracionDocumentoEdit objManNumeracionDocumentoEdit = new frmManNumeracionDocumentoEdit();
            objManNumeracionDocumentoEdit.pOperacion = frmManNumeracionDocumentoEdit.Operacion.ConsultarEditar;
            objManNumeracionDocumentoEdit.IdNumeracionDocumento = objNumeracionDocumento.IdNumeracionDocumento;
            objManNumeracionDocumentoEdit.pNumeracionDocumentoBE = objNumeracionDocumento;
            objManNumeracionDocumentoEdit.cboEmpresa.Enabled = false;
            objManNumeracionDocumentoEdit.cboDocumento.Enabled = false;

            objManNumeracionDocumentoEdit.StartPosition = FormStartPosition.CenterParent;
            objManNumeracionDocumentoEdit.ShowDialog();

            if (objManNumeracionDocumentoEdit.DialogResult == DialogResult.OK)
            {
                txtNumero.EditValue = objManNumeracionDocumentoEdit.intNumero;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    IdClasificacionCliente = frm.pClienteBE.IdClasificacionCliente;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {


            List<DocumentoVentaDetalleBE> mListaPEdidoDetalleOrigen = null;
            mListaPEdidoDetalleOrigen = new DocumentoVentaDetalleBL().ListaTodosActivo(IdDocumentoVenta);

            List<PedidoDetalleBE> mListaPedidoDetalleOrigen = null;
            mListaPedidoDetalleOrigen = new PedidoDetalleBL().ListaTodosActivo(IdPedido);

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);
            try
            { 
                if(Convert.ToInt32(objE_DocumentoVenta.IdTipoDocumento) == Parametros.intTipoDocBoletaVenta)//SI ES BOLETA DE VENTA
                {
                    
                        if (mListaPedidoDetalleOrigen.Count <= 6)
                        {
                            InsertarDocumentoVenta();
                                if (XtraMessageBox.Show("Esta seguro de imprimir la boleta de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                //imprimir
                                #region "Impresion"
                                if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intPanoraramaDistribuidores)//Verificando Panorama
                                {
                                    frmMsgPrintDoc frm = new frmMsgPrintDoc();
                                    frm.ShowDialog();
                                    if (frm.TipoFormatoPrint == 1)
                                    {
                                        //ImpresionDirecta();
                                    }
                                    else if (frm.TipoFormatoPrint == 2)
                                    {
                                        //ImpresionDirectaDesglosable();
                                    }
                                }
                                else
                                    if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores) //Verificando Corona
                                {
                                    frmMsgPrintDoc frm = new frmMsgPrintDoc();
                                    frm.ShowDialog();
                                    if (frm.TipoFormatoPrint == 1)
                                    {
                                        //ImpresionDirecta();
                                    }
                                    else if (frm.TipoFormatoPrint == 2)
                                    {
                                        //ImpresionDirectaDesglosable();
                                    }
                                }
                                else
                                {
                                    //ImpresionDirectaDesglosable();
                                }
                                #endregion
                            }

                        }
                    else
                    {
                        InsertarDocumentoVentaVarios(6);
                        if (XtraMessageBox.Show("Esta seguro de imprimir la boleta de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //imprimir
                        }
                    }
                }
                   
                        //Cargar();
            }
            catch (Exception)
            {

                throw;
            }

            
            this.Close();
            return;
        }



        #region Metodos
        private void InsertarDocumentoVenta()
        {
            
                try
                {
                    //Obtener datos de Cabecera
                    DocumentoVentaBE objE_DocumentoVenta = null;
                    objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);
                    objE_DocumentoVenta.IdTipoDocumento = Parametros.intTipoDocGuiaRemision;
                    objE_DocumentoVenta.Direccion = txtDireccion.Text;
                    objE_DocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();

                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo);
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text);
                    if (mListaNumero.Count > 0)
                    {
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                        Serie = mListaNumero[0].Serie;
                    }
                    objE_DocumentoVenta.Serie = Serie;
                    objE_DocumentoVenta.Numero = Numero;


                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    //Obetener Detalle de DocumentoVenta

                    List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                    lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(IdDocumentoVenta);

                    objBL_DocumentoVenta.Inserta(objE_DocumentoVenta, lstTmpDocumentoVentaDetalle);

                }
                catch (Exception)
                {

                    throw;
                }

            //}
        }
        private void InsertarDocumentoVentaVarios(int items)
        {
            //if (!ValidarIngreso())
            List<PedidoDetalleBE> mListaPedidoDetalleOrigen = null;
            mListaPedidoDetalleOrigen = new PedidoDetalleBL().ListaTodosActivo(IdPedido);
            //{
            int Contador = 0;

                if (mListaPedidoDetalleOrigen.Count % items == 0)
                {
                    Contador = mListaPedidoDetalleOrigen.Count / items;
                }
                else
                {
                    Contador = Convert.ToInt32((mListaPedidoDetalleOrigen.Count / items) + 1);
                }

                int row = 0;

                for (int i = 0; i < Contador; i++)
                {
                    //Documento Venta Detalle
                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();
                    int fila = 0;
                    int cuenta = 0;
                    if (i > 0)
                    {
                        fila = row;
                    }

                    for (int y = fila; y < mListaPedidoDetalleOrigen.Count; y++)
                    {
                        if (cuenta == items)
                        {
                            y = row;
                            break;
                        }
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                        objE_DocumentoVentaDetalle.IdEmpresa = mListaPedidoDetalleOrigen[row].IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = 0;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = 0;
                        objE_DocumentoVentaDetalle.Item = mListaPEdidoDetalleOrigen[row].Item;
                        objE_DocumentoVentaDetalle.IdProducto = mListaPEdidoDetalleOrigen[row].IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = mListaPEdidoDetalleOrigen[row].CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = mListaPEdidoDetalleOrigen[row].NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = mListaPEdidoDetalleOrigen[row].Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = mListaPEdidoDetalleOrigen[row].Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = mListaPEdidoDetalleOrigen[row].PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = mListaPEdidoDetalleOrigen[row].PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = mListaPEdidoDetalleOrigen[row].Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = mListaPEdidoDetalleOrigen[row].PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = mListaPEdidoDetalleOrigen[row].ValorVenta;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(mListaPEdidoDetalleOrigen[row].IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = mListaPEdidoDetalleOrigen[row].FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = mListaPEdidoDetalleOrigen[row].FlagRegalo;
                        //objE_DocumentoVentaDetalle.IdPromocion = mListaPEdidoDetalleOrigen[row].IdPromocion;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = mListaPEdidoDetalleOrigen[row].TipoOper;
                        lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);

                        row = row + 1;
                        cuenta = cuenta + 1;
                    }

                    //Calcula Montos Totales

                    decimal deImpuesto = 0;
                    decimal deValorVenta = 0;
                    decimal deSubTotal = 0;
                    decimal deTotal = 0;
                    //decimal deTotalBruto = 0;
                    int intTotalCantidad = 0;

                    if (lstDocumentoVentaDetalle.Count > 0)
                    {
                        foreach (var item in lstDocumentoVentaDetalle)
                        {
                            intTotalCantidad = intTotalCantidad + item.Cantidad;
                            deValorVenta = item.ValorVenta;
                            deTotal = deTotal + deValorVenta;
                        }

                        deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                        deImpuesto = deTotal - deSubTotal;
                    }

                    //Descuentos Adicionales por Cabecera
                    //if (Convert.ToDecimal(txtDescuento.EditValue) > 0)
                    //{
                    //    deTotalBruto = deTotal;
                    //    deTotal = Math.Round(deTotal * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100), 2);
                    //    deSubTotal = Math.Round(deTotal / decimal.Parse(Parametros.dblIGV.ToString()), 2);
                    //    deImpuesto = deTotal - deSubTotal;
                    //}



                    //Generamos el documento cabecera.

                    DocumentoVentaBE objE_DocumentoVenta = null;
                    objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(IdDocumentoVenta);
                    objE_DocumentoVenta.IdTipoDocumento = Parametros.intTipoDocGuiaRemision;
                    //objDocumentoVenta.IdPedido = IdPedido == 0 ? (int?)null : IdPedido;
                    objE_DocumentoVenta.Direccion = txtDireccion.Text;
                    objE_DocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());

                    //Obtener el numero del documento relacionado a la serie
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();

                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo);
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text);
                    if (mListaNumero.Count > 0)
                    {
                        Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                        Serie = mListaNumero[0].Serie;
                    }
                    objE_DocumentoVenta.Serie = Serie;
                    objE_DocumentoVenta.Numero = Numero;

                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    objBL_DocumentoVenta.Inserta(objE_DocumentoVenta, lstDocumentoVentaDetalle);
                    
                }
            //}
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdCliente == 0)
            {
                strMensaje = strMensaje + "- Seleccionar un cliente válido.\n";
                flag = true;
            }

            if (cboDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar el tipo de documento.\n";
                flag = true;
            }

            //if (mListaPEdidoDetalleOrigen.Count == 0)
            //{
            //    strMensaje = strMensaje + "- Nos se puede generar la venta, mientra no haya productos.\n";
            //    flag = true;
            //}

            //if (txtNumeroDocumento.Text.Trim().Length < 11 && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) // Validar RUC DE ASOCIADO .. FALTA
            //{
            //    XtraMessageBox.Show("No se puede generar una factura con un ruc no válido.\nConsulte con su Administrador.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    flag = true;
            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }


        #endregion

        private void cboDescAgencia_EditValueChanged(object sender, EventArgs e)
        {
            AgenciaBE objAgencia = new AgenciaBE();
            objAgencia = new AgenciaBL().Selecciona(Convert.ToInt32(cboDescAgencia.EditValue));

            if (objAgencia != null)
            {
                txtDireccion.EditValue = objAgencia.Direccion;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}