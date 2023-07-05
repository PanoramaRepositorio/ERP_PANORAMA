using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegSalidaBulto : DevExpress.XtraEditors.XtraForm
    {
        public frmRegSalidaBulto()
        {
            InitializeComponent();
        }

        private void frmRegSalidaBulto_Load(object sender, EventArgs e)
        {
            txtNumero.Select();
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    BultoBE objE_Bulto = null;
                    objE_Bulto = new BultoBL().SeleccionaNumeroBulto(Parametros.intEmpresaId, txtNumero.Text.Trim(), Parametros.intBULRecibido);
                    if (objE_Bulto != null)
                    {
                        if (objE_Bulto.FlagInventario == false)
                        {
                            BultoBL objBL_Bulto = new BultoBL();
                            objBL_Bulto.ActualizaTransito(Parametros.intEmpresaId, objE_Bulto.IdBulto);

                            lblMensaje.Text = "El Bulto N°" + objE_Bulto.NumeroBulto + " está listo para Descargar";
                            //XtraMessageBox.Show("El Bulto se descargó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txtNumero.Text = "";
                            txtNumero.Focus();            
                        }else
                        lblMensaje.Text = "El Bulto N° " + objE_Bulto.NumeroBulto + " está en tránsito";

                    }
                    else
                    {
                        lblMensaje.Text = "El bulto "+ txtNumero.Text +" no existe por favor verifique.";
                        txtNumero.Text = "";
                        txtNumero.Focus();     
                        //XtraMessageBox.Show("El numero de bulto no existe por favor verifique.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    //gcBulto.DataSource = new BultoBL().ListaNumeroBulto();
                    //gcBulto.RefreshDataSource();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}