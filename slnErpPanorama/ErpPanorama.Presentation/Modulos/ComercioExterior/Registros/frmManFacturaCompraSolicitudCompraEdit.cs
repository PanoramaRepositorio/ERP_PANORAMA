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
using ErpPanorama.Presentation.Modulos.ComercioExterior.Otros;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmManFacturaCompraSolicitudCompraEdit : DevExpress.XtraEditors.XtraForm
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
        public int IdProveedor = 0;
        public string NumeroSolicitudCompra = "";

        #endregion

        #region "Eventos"
        Boolean EstadoProcedencia=false;

        public frmManFacturaCompraSolicitudCompraEdit()
        {
            InitializeComponent();
        }

        private void frmManFacturaCompraSolicitudCompraEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboProveedor, new ProveedorBL().ListaTodosActivo(0), "DescProveedor", "IdProveedor", true);
            //cboProveedor.EditValue = Parametros.intPanoraramaDistribuidores;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocSolicitudCompra;
            txtNumero.Text = NumeroSolicitudCompra;
            cboProveedor.EditValue = IdProveedor;
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(txtNumeroFactura.Text))
                {
                    Cursor = Cursors.Default;
                    XtraMessageBox.Show("Ingresar el número de factura", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (XtraMessageBox.Show("Está seguro de Importar la Solicitud de Compra usando como referencia el Documento de venta de " + cboProveedor.Text + " N° " + txtNumero.Text.Trim() + "?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //frmOrigenFactura frm = new frmOrigenFactura();
                    //frm.StartPosition = FormStartPosition.CenterParent;
                    //if (frm.ShowDialog() == DialogResult.OK)
                    //{
                    //    EstadoProcedencia = frm.bNacional;
                    //}

                    //Vincular a la Factura
                    ///Código aquí
                    SolicitudCompraBE objE_SolicitudCompra = null;
                    objE_SolicitudCompra = new SolicitudCompraBL().SeleccionaNumero(Convert.ToInt32(cboProveedor.EditValue),txtNumero.Text.Trim());
                    if (objE_SolicitudCompra == null)
                    {
                        Cursor = Cursors.Default;
                        XtraMessageBox.Show("La Solicitud de compra no existe, por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (objE_SolicitudCompra.NumeroFactura != "")
                        {
                            Cursor = Cursors.Default;
                            XtraMessageBox.Show("No se Pudo Generar, La Solicitud de compra ya se generó con la factura N°"+ objE_SolicitudCompra.NumeroFactura +", por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        //Establecemos los datos de la factura de compra
                        FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();
                        objE_FacturaCompra.IdFacturaCompra = 0;
                        objE_FacturaCompra.IdEmpresa = Parametros.intEmpresaId;
                        objE_FacturaCompra.Periodo = Parametros.intPeriodo;
                        objE_FacturaCompra.IdTipoDocumento = Parametros.intTipoDocFacturaCompra;
                        objE_FacturaCompra.NumeroDocumento = txtNumeroFactura.Text.Trim();//objE_SolicitudCompra.NumeroDocumento;
                        objE_FacturaCompra.IdProveedor = objE_SolicitudCompra.IdProveedor;
                        objE_FacturaCompra.IdFormaPago = objE_SolicitudCompra.IdFormaPago;
                        objE_FacturaCompra.FechaCompra = objE_SolicitudCompra.FechaCompra;
                        objE_FacturaCompra.FechaRecepcion = null;//objE_SolicitudCompra.FechaRecepcion;
                        objE_FacturaCompra.TipoRegistro = "A";
                        objE_FacturaCompra.Importe = objE_SolicitudCompra.Importe;
                        objE_FacturaCompra.IdMoneda = objE_SolicitudCompra.IdMoneda;
                        objE_FacturaCompra.TipoCambio = objE_SolicitudCompra.TipoCambio;
                        objE_FacturaCompra.Cantidad = objE_SolicitudCompra.Cantidad;
                        objE_FacturaCompra.Observacion = "Ingreso Automático por Solicitud de Compra";
                        objE_FacturaCompra.FlagRecibido = false;
                        objE_FacturaCompra.FlagMuestra = false;
                        objE_FacturaCompra.IdSolicitudCompra = objE_SolicitudCompra.IdSolicitudCompra;
                        objE_FacturaCompra.FlagEstado = true;
                        objE_FacturaCompra.Usuario = Parametros.strUsuarioLogin;
                        objE_FacturaCompra.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        //objE_FacturaCompra.FlagNacional = EstadoProcedencia;

                        List<FacturaCompraBE> mListaFactura = new List<FacturaCompraBE>();
                        mListaFactura = new FacturaCompraBL().ListaProveedor(objE_FacturaCompra.IdEmpresa, objE_FacturaCompra.IdProveedor, objE_SolicitudCompra.NumeroDocumento);

                        if (mListaFactura.Count > 0)
                        {
                            Cursor = Cursors.Default;
                            XtraMessageBox.Show("La Factura de Compra ya existe en la base de datos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else
                        {

                        //Traemos la información de detalle del Documento

                        List<SolicitudCompraDetalleBE> lstTmpSolicitudCompraDetalle = null;
                        lstTmpSolicitudCompraDetalle = new SolicitudCompraDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, objE_SolicitudCompra.IdSolicitudCompra);

                        //Recorremos para el detalle de la Factura
                        foreach (SolicitudCompraDetalleBE item in lstTmpSolicitudCompraDetalle)
                        {
                            FacturaCompraDetalleBE objE_FacturaCompraDetalle = new FacturaCompraDetalleBE();
                            objE_FacturaCompraDetalle.IdFacturaCompraDetalle = 0;
                            objE_FacturaCompraDetalle.IdFacturaCompra = 0;
                            objE_FacturaCompraDetalle.IdProducto = item.IdProducto;
                            objE_FacturaCompraDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_FacturaCompraDetalle.NombreProducto = item.NombreProducto;
                            objE_FacturaCompraDetalle.NumeroBultos = item.NumeroBultos;
                            objE_FacturaCompraDetalle.Cantidad = item.Cantidad;
                            objE_FacturaCompraDetalle.CantidadUM = item.Cantidad/item.NumeroBultos;
                            objE_FacturaCompraDetalle.PrecioUnitario = item.PrecioUnitario;
                            objE_FacturaCompraDetalle.SubTotal = item.SubTotal;
                            objE_FacturaCompraDetalle.IdUnidadMedida = item.IdUnidadMedida;
                            objE_FacturaCompraDetalle.Abreviatura = item.Abreviatura;
                            objE_FacturaCompraDetalle.FlagEstado = true;
                            objE_FacturaCompraDetalle.Usuario = Parametros.strUsuarioLogin;
                            objE_FacturaCompraDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_FacturaCompraDetalle.IdEmpresa = Parametros.intEmpresaId;
                                //objE_FacturaCompraDetalle.Imagen = new FuncionBase().Image2Bytes(ErpPanorama.Presentation.Properties.Resources.noImage);
                            //objE_FacturaCompraDetalle.FlagNacional = objE_FacturaCompra.FlagNacional;
                                mListaFacturaDetalle.Add(objE_FacturaCompraDetalle);

                        }

                        FacturaCompraBL objBL_FacturaCompra = new FacturaCompraBL();
                        objBL_FacturaCompra.Inserta(objE_FacturaCompra, mListaFacturaDetalle);

                        ////Actualizar fecha de rececepcion
                        //if (objE_SolicitudCompra.FechaRecepcion != null)
                        //{
                        //    FacturaCompraBE objFacturaCompraR = new FacturaCompraBE();
                        //    objFacturaCompraR.IdFacturaCompra = IdFacturaCompra;
                        //    objFacturaCompraR.FechaRecepcion = objE_SolicitudCompra.FechaRecepcion;

                        //    objBL_FacturaCompra.ActualizaFechaRecepcion(objFacturaCompraR);
                        //}


                        XtraMessageBox.Show("La Importacion se realizó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                        Cursor = Cursors.Default;
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
            SolicitudCompraBE objE_SolicitudCompra = null;
            objE_SolicitudCompra = new SolicitudCompraBL().SeleccionaNumero(Convert.ToInt32(cboProveedor.EditValue), txtNumero.Text.Trim());
            if (objE_SolicitudCompra == null)
            {
                XtraMessageBox.Show("El documento de venta de " + cboProveedor.Text + " N° " + txtNumero.Text.Trim() + " no existe, por favor verifique \nIngresar todos los números incluyendo ceros a la izquierda", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Verificar con Facturacion
                frmManSolicitudCompraEdit objRegFacturacionEdit = new frmManSolicitudCompraEdit();
                objRegFacturacionEdit.pOperacion = frmManSolicitudCompraEdit.Operacion.Modificar;
                objRegFacturacionEdit.IdSolicitudCompra = objE_SolicitudCompra.IdSolicitudCompra;
                objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                objRegFacturacionEdit.btnGrabar.Enabled = false;
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