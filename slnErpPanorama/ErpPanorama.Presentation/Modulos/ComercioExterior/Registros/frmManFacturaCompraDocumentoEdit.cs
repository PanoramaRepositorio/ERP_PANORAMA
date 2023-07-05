using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Security.Principal;
using System.Reflection;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmManFacturaCompraDocumentoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<FacturaCompraDetalleBE> mLista;
        List<FacturaCompraDetalleBE> mListaFacturaDetalle = new List<FacturaCompraDetalleBE>();
        int _IdFacturaCompra = 0;

        public int IdFacturaCompra
        {
            get { return _IdFacturaCompra; }
            set { _IdFacturaCompra = value; }
        }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }
        #endregion

        #region "Eventos"

        public frmManFacturaCompraDocumentoEdit()
        {
            InitializeComponent();
        }

        private void frmManFacturaCompraDocumentoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intPanoraramaDistribuidores;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocFacturaVenta;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {

                if (XtraMessageBox.Show("Está seguro de Importar la factura usando como referencia el Documento de venta de " + cboEmpresa.Text +" N° "+ txtSerie.Text.Trim() + "-" + txtNumero.Text.Trim() + "? \nEsto Incrementará stock a: " + Parametros.strEmpresaNombre, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DocumentoVentaBE objE_DocumentoVenta = null;
                    objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text.Trim(), txtNumero.Text.Trim());
                    if (objE_DocumentoVenta == null)
                    {
                        XtraMessageBox.Show("El documento de venta no existe, por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        //Establecemos los datos de la factura de compra
                        FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                        objE_FacturaCompra.IdFacturaCompra = 0;
                        objE_FacturaCompra.IdEmpresa = Parametros.intEmpresaId;
                        objE_FacturaCompra.Periodo = Parametros.intPeriodo;
                        objE_FacturaCompra.IdTipoDocumento = Parametros.intTipoDocFacturaCompra;
                        objE_FacturaCompra.NumeroDocumento = objE_DocumentoVenta.Serie + "-"+ objE_DocumentoVenta.Numero;

                        foreach (ProveedorBE item in Parametros.pListaProveedores)
                        {
                            if (item.DescProveedor == cboEmpresa.Text)
                            {
                                objE_FacturaCompra.IdProveedor = item.IdProveedor;
                            }
                        }

                        objE_FacturaCompra.IdFormaPago = objE_DocumentoVenta.IdFormaPago;
                        objE_FacturaCompra.FechaCompra = objE_DocumentoVenta.Fecha;
                        objE_FacturaCompra.FechaRecepcion = null;
                        objE_FacturaCompra.TipoRegistro = "A";
                        objE_FacturaCompra.Importe = objE_DocumentoVenta.Total;
                        objE_FacturaCompra.IdMoneda = objE_DocumentoVenta.IdMoneda;
                        objE_FacturaCompra.TipoCambio = objE_DocumentoVenta.TipoCambio;
                        objE_FacturaCompra.Cantidad = objE_DocumentoVenta.TotalCantidad;
                        objE_FacturaCompra.Observacion = "Ingreso Automatico por Documento de Venta";
                        objE_FacturaCompra.FlagRecibido = false;
                        objE_FacturaCompra.FlagMuestra = false;
                        objE_FacturaCompra.FlagEstado = true;
                        objE_FacturaCompra.Usuario = Parametros.strUsuarioLogin;
                        objE_FacturaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        List<FacturaCompraBE> mListaFactura = new List<FacturaCompraBE>();
                        mListaFactura = new FacturaCompraBL().ListaProveedor(objE_FacturaCompra.IdEmpresa, objE_FacturaCompra.IdProveedor, objE_DocumentoVenta.Serie + "-" + objE_DocumentoVenta.Numero);

                        if (mListaFactura.Count > 0)
                        {
                            XtraMessageBox.Show("La Factura de Compra ya existe en la base de datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {

                            //Traemos la información de detalle del Documento

                            List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
                            lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(objE_DocumentoVenta.IdDocumentoVenta);

                            //Recorremos para el detalle de la Factura
                            foreach (DocumentoVentaDetalleBE item in lstTmpDocumentoVentaDetalle)
                            {
                                FacturaCompraDetalleBE objE_FacturaCompraDetalle = new FacturaCompraDetalleBE();
                                objE_FacturaCompraDetalle.IdFacturaCompraDetalle = 0;
                                objE_FacturaCompraDetalle.IdFacturaCompra = 0;
                                objE_FacturaCompraDetalle.IdProducto = item.IdProducto;
                                objE_FacturaCompraDetalle.CodigoProveedor = item.CodigoProveedor;
                                objE_FacturaCompraDetalle.NombreProducto = item.NombreProducto;
                                objE_FacturaCompraDetalle.NumeroBultos = 0;
                                objE_FacturaCompraDetalle.Cantidad = item.Cantidad;
                                objE_FacturaCompraDetalle.CantidadUM = 0;
                                objE_FacturaCompraDetalle.PrecioUnitario = item.PrecioVenta;
                                objE_FacturaCompraDetalle.SubTotal = item.ValorVenta;

                                //foreach (UnidadMedidaBE item2 in Parametros.pListaUnidadMedida)
                                //{
                                //    if (item2.Abreviatura.Trim() == item.Abreviatura)
                                //    {
                                //        objE_FacturaCompraDetalle.IdUnidadMedida = item2.IdUnidadMedida;
                                //    }
                                //}

                                objE_FacturaCompraDetalle.FlagEstado = true;
                                objE_FacturaCompraDetalle.Usuario = Parametros.strUsuarioLogin;
                                objE_FacturaCompraDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                                objE_FacturaCompraDetalle.IdEmpresa = Parametros.intEmpresaId;
                                //objE_FacturaCompraDetalle.Imagen = new FuncionBase().Image2Bytes(ErpPanorama.Presentation.Properties.Resources.noImage);

                                mListaFacturaDetalle.Add(objE_FacturaCompraDetalle);

                            }

                            FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();
                            objBL_FacturaCompra.InsertaDocumentoVenta(objE_FacturaCompra, mListaFacturaDetalle);

                            XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        this.DialogResult = DialogResult.OK;
                        //this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text.Trim(), txtNumero.Text.Trim());
            if (objE_DocumentoVenta == null)
            {
                XtraMessageBox.Show("El documento de venta de " + cboEmpresa.Text + " N° " + txtSerie.Text.Trim() + "-" + txtNumero.Text.Trim() + " no existe, por favor verifique \nIngresar todos los números incluyendo ceros a la izquierda", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Verificar con Facturacion
                frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
                objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                objRegFacturacionEdit.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                objRegFacturacionEdit.btnGrabar.Enabled = false;
                objRegFacturacionEdit.mnuContextual.Enabled = false;
                objRegFacturacionEdit.ShowDialog();
            }
        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConsultar_Click(sender, e);
            }
        }

        #endregion

        #region "Metodos"


        #endregion


    }
}