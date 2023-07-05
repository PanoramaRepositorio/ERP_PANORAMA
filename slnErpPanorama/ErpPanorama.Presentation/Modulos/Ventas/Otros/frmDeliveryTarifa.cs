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
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmDeliveryTarifa : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
       
        public UbigeoBE oBE;

        #endregion

        #region "Eventos"

        public frmDeliveryTarifa()
        {
            InitializeComponent();
        }

        private void frmDeliveryTarifa_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;

        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);
                cboProvincia.EditValue = Parametros.sIdProvincia;
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                //BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistritoDelivery(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdDistrito", false);
                //cboDistrito.EditValue = Parametros.sIdDistrito;

                BSUtils.LoaderLook(cboDistrito, new ListaPrecioDeliveryBL().ListaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdListaPrecioDelivery", false);
                //cboDistrito.EditValue = Parametros.sIdDistrito;

            }
        }

        private void cboDistrito_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDistrito.EditValue != null)
            {
                //UbigeoBE objE_Ubigeo = null;
                //objE_Ubigeo = new UbigeoBL().Selecciona(cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString());

                ListaPrecioDeliveryBE objE_ListaPrecioDelivery = null;
                objE_ListaPrecioDelivery = new ListaPrecioDeliveryBL().Selecciona(Convert.ToInt32(cboDistrito.EditValue), Parametros.intTiendaId);
                txtTotal.EditValue = objE_ListaPrecioDelivery.TarifaEnvio;
                cboDistrito.Select();    
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtTotal.EditValue) == 0)
            {
                XtraMessageBox.Show("No se puede enviar a este destino, verificar Tarifa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboDistrito.SelectAll();
                cboDistrito.Focus();
                return;
            }

                oBE = new UbigeoBE();
                oBE.DescUbigeo = cboDistrito.Text;
                oBE.TarifaEnvio = Convert.ToDecimal(txtTotal.Text); 
                this.DialogResult = DialogResult.OK;
        }

        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkCallao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCallao.Checked == true)
            {
                cboDepartamento.Enabled = true;
                cboProvincia.Enabled = true;
                cboDepartamento.EditValue = "07";//Callao
            }
            else
            {
                cboDepartamento.Enabled = false;
                cboProvincia.Enabled = false;
                cboDepartamento.EditValue =Parametros.sIdDepartamento;//Lima
            }
        }

        #region "Metodos"
        #endregion
    }
}