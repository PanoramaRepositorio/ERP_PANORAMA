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


namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmProductoStockBulto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<PromocionBultoDetalleBE> mLista = new List<PromocionBultoDetalleBE>();
        public Int32 IdProducto = 0;
        public Int32 TotalAlmacen = 0;
        public Int32 TotalCantidad = 0;
        public Int32 IdFormaPago = 0;
        public Int32 IdTipoCliente = 0;

        #endregion

        #region "Eventos"

        public frmProductoStockBulto()
        {
            InitializeComponent();
        }

        private void frmProductoStockBulto_Load(object sender, EventArgs e)
        {
            Cargar();
            if (mLista.Count == 0)
            {
                XtraMessageBox.Show("No existe código para la venta por Bultos, Consulte con su Administrador.", this.Text,MessageBoxButtons.OK,MessageBoxIcon.Stop);
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int CantidadCodigo = 0;
            foreach (var item in mLista)
            {
                if (item.CantidadPedida > 0)
                { 
                    if (item.CantidadPedida > item.CantidadBultos)
                    {
                        XtraMessageBox.Show("La cantidad solicitada no debe ser mayor al Total de Bultos.", this.Text);
                        return;
                    }

                    TotalAlmacen = TotalAlmacen + 1;
                    //TotalCantidad = TotalCantidad + item.CantidadPedida;
                    TotalCantidad = item.CantidadBulto * item.CantidadPedida;
                    CantidadCodigo = CantidadCodigo + 1;
                    IdProducto = item.IdProducto;
                }
            }

            if (CantidadCodigo > 1)
            {
                XtraMessageBox.Show("No se puede vender más de un Código, Consulte con su Administrador.", this.Text);
                return;
            }

            if (CantidadCodigo == 0)
            {
                XtraMessageBox.Show("Ingresar la cantidad de bulto en un código, Consulte con su Administrador.", this.Text);
                return;
            }


            this.DialogResult = DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new PromocionBultoDetalleBL().ListaTipoClienteFormapago(Parametros.intEmpresaId, IdTipoCliente, IdFormaPago, DateTime.Now);
            gcProducto.DataSource = mLista;

            if (mLista.Count == 0)
            {
                btnAceptar.Enabled = false;
            }
        }


        #endregion

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusqueda();
            }
        }

        private void CargarBusqueda()
        {
            gcProducto.DataSource = mLista.Where(obj =>
                                                   obj.CodigoProveedor.ToUpper().Contains(txtCodigo.Text.ToUpper())).ToList();
        }

        private void txtCodigo_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

    }
}