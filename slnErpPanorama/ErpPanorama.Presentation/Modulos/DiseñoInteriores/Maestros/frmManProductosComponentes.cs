using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Maestros
{
    public partial class frmManProductosComponentes : DevExpress.XtraEditors.XtraForm
    {
        public ProductoComponenteBE oBE;
        public int IdProductoComponente = 0;
        public int IdProducto = 0;
        public string DescComponente = "";

        public int IdMaterial = 0;
        public string DescMaterial = "";
        public int IdColor = 0;
        public string DescColor = "";
        public int IdUnidadMedida = 0;
        public string DescUnidadMedida = "";

        public int cAncho = 0;
        public int cLargo = 0;
        public int cAlto = 0;
        public int cProfundidad = 0;
        public int Cantidad = 0;

        public string TipoOper = "";
        public int Boton = 0;
        public frmManProductosComponentes()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManProductosComponentes_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboMaterial, new MaterialBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMaterial", "IdMaterial", true);
            cboMaterial.EditValue = IdMaterial;

            BSUtils.LoaderLook(cboColor, new ColorBL().ListaTodosActivo(Parametros.intEmpresaId), "DescColor", "IdColor", true);
            cboColor.EditValue = IdColor;

            BSUtils.LoaderLook(cboUnidadMedida, new UnidadMedidaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescUnidadMedida", "IdUnidadMedida", true);
            cboUnidadMedida.EditValue = IdUnidadMedida;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCuenta.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingrese la descripción del componente o parte!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCuenta.SelectAll();
                    txtCuenta.Focus();
                    return;
                }
                oBE = new ProductoComponenteBE();

                oBE.IdProductoComponente = IdProductoComponente;
                oBE.IdProducto = IdProducto;
                oBE.DescComponente = DescComponente;
                oBE.IdMaterial = IdMaterial;
                oBE.DescMaterial = DescMaterial;
                oBE.IdColor = IdColor;
                oBE.DescColor = DescColor;
                oBE.cAncho = cAncho;
                oBE.cLargo = cLargo;
                oBE.cAncho = cAlto;
                oBE.cLargo = cProfundidad;
                oBE.cLargo = Cantidad;

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCuenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);
            //if (e.KeyChar == '-' || e.KeyChar == ' ')
            //{
            //    e.Handled = true;
            //}
        }

        private void txtCCI_KeyPress(object sender, KeyPressEventArgs e)
        {
            //base.OnKeyPress(e);
            //if (e.KeyChar == '-' || e.KeyChar == ' ')
            //{
            //    e.Handled = true;
            //}
        }
    }
}