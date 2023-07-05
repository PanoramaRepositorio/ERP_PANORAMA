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
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas
{
    public partial class frmConFacturaCompraEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        List<FacturaCompraDetalleBE> mLista;
        List<FacturaCompraDetalleBE> mListaFacturaDetalle = new List<FacturaCompraDetalleBE>();
        int _IdFacturaCompra = 0;
        private bool bNacional = false;
        public bool bMostrarVenta = false;

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

        public frmConFacturaCompraEdit()
        {
            InitializeComponent();
        }

        private void frmConFacturaCompraEdit_Load(object sender, EventArgs e)
        {
            //Obtenemos la lista de proveedores
            Parametros.pListaProveedores = new ProveedorBL().ListaTodosActivo(Parametros.intEmpresaId);

            //Obtenemos la lista de Forma de Pago
            Parametros.pListaFormaPago = new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago);

            //Obtenemos la lista de Unidades de Medida
            Parametros.pListaUnidadMedida = new UnidadMedidaBL().ListaTodosActivo(Parametros.intEmpresaId);

            BSUtils.LoaderLook(cboDocumento, new TipoDocumentoBL().ListaTodosActivo(Parametros.intEmpresaId), "CodTipoDocumento", "IdTipoDocumento", false);
            BSUtils.LoaderLook(cboFormaPago, Parametros.pListaFormaPago, "DescTablaElemento", "IdTablaElemento", false);
            BSUtils.LoaderLook(cboProveedor, Parametros.pListaProveedores, "DescProveedor", "IdProveedor", false);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", false);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Factura Compra - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Factura Compra - Modificar";

                FacturaCompraBE objE_FacturaCompra = new FacturaCompraBE();

                objE_FacturaCompra = new FacturaCompraBL().Selecciona(Parametros.intEmpresaId, IdFacturaCompra);

                cboDocumento.EditValue = objE_FacturaCompra.IdTipoDocumento;
                txtNumero.Text = objE_FacturaCompra.NumeroDocumento;
                deFecha.EditValue = objE_FacturaCompra.FechaCompra;
                deFechaRecepcion.EditValue = objE_FacturaCompra.FechaRecepcion;
                cboFormaPago.EditValue = objE_FacturaCompra.IdFormaPago;
                cboProveedor.EditValue = objE_FacturaCompra.IdProveedor;
                cboMoneda.EditValue = objE_FacturaCompra.IdMoneda;
                txtTipoCambio.EditValue = objE_FacturaCompra.TipoCambio;
                txtCantidad.EditValue = objE_FacturaCompra.Cantidad;
                txtImporte.EditValue = objE_FacturaCompra.Importe;
                txtObservaciones.Text = objE_FacturaCompra.Observacion;
                lblUsuario.Text = objE_FacturaCompra.Usuario;
                lblFechaRegistro.Text = objE_FacturaCompra.FechaRegistro.ToString();

                //if (bMostrarVenta)
                //{
                //    this.Size = new Size(903, 585);
                //    gvFacturaCompraDetalle.Columns["CantidadVenta"].Visible = true;
                //    gvFacturaCompraDetalle.Columns["ImporteVenta"].Visible = true;
                //}

            }

            Cargar();
        }



        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region "Metodos"



        private void Cargar()
        {
            mLista = new FacturaCompraDetalleBL().ListaTodosStock(Parametros.intEmpresaId, IdFacturaCompra);
            gcFacturaCompraDetalle.DataSource = mLista;
        }

        private void CargarFoto()
        {
            mLista = new FacturaCompraDetalleBL().ListaTodosImagen(Parametros.intEmpresaId, IdFacturaCompra);
            gcFacturaCompraDetalle.DataSource = mLista;
        }

        #endregion

        private void chkMostrarFoto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarFoto.Checked)
            {
                CargarFoto();
                gridColumn24.Visible = true;
                gvFacturaCompraDetalle.RowHeight = 75;
                this.WindowState = FormWindowState.Maximized;

                //this.Size = new Size(1087, 693);
            }
            else
            {
                Cargar();
                gridColumn24.Visible = false;
                gvFacturaCompraDetalle.RowHeight = -1;
            }
        }
    }
}