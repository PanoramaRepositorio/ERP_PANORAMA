using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;


namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    public partial class frmRegCodigoBarra : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public string strCodigoBarra = "";
        private int IdProducto = 0;
        public bool bCodigoBarras = false;

        #endregion

        #region "Eventos"

        public frmRegCodigoBarra()
        {
            InitializeComponent();
        }

        private void frmRegCodigoBarra_Load(object sender, EventArgs e)
        {
            txtCodigoBarra.Text = strCodigoBarra;
            txtCodigoBarra.Enabled = bCodigoBarras;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusProducto frm = new frmBusProducto();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pProductoBE != null)
                {
                    IdProducto = frm.pProductoBE.IdProducto;
                    txtCodigo.Text = frm.pProductoBE.CodigoProveedor;
                    txtNombreProducto.Text = frm.pProductoBE.NombreProducto;
                }

                btnGrabar.Focus();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (IdProducto == 0)
            {
                XtraMessageBox.Show("Debe ingresar un código de producto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ProductoBE> lstProducto = new List<ProductoBE>();
            ProductoBE ObjE_producto = new ProductoBE();
            ObjE_producto.IdProducto = IdProducto;
            ObjE_producto.CodigoBarra = txtCodigoBarra.Text.Trim();
            lstProducto.Add(ObjE_producto);
            
            ProductoBL ObjBL_producto = new ProductoBL();
            ObjBL_producto.ActualizaCodigoBarraIdProducto(lstProducto);
            //XtraMessageBox.Show("código de producto Asociado correctamente: " + txtCodigo.Text.Trim() +" = "+ txtCodigoBarra.Text.Trim() , this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion



        #region "Metodos"


        #endregion

    }
}