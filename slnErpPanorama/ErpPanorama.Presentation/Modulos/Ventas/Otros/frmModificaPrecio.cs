using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmModificaPrecio : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        
        
        #endregion

        #region "Eventos"

        public frmModificaPrecio()
        {
            InitializeComponent();
        }

        private void frmModificaPrecio_Load(object sender, EventArgs e)
        {
            txtPrecio.EditValue = PrecioUnitario;
            txtPorDesc.EditValue = Descuento;
            ActivaControles(false);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PrecioUnitario = Convert.ToDecimal(txtPrecio.EditValue);
            Descuento = Convert.ToDecimal(txtPorDesc.EditValue);
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAutoriza_Click(object sender, EventArgs e)
        {
                frmAutorizacionUsuario frmAutoriza = new frmAutorizacionUsuario();
                frmAutoriza.StartPosition = FormStartPosition.CenterParent;
                frmAutoriza.ShowDialog();

                if (frmAutoriza.Edita && frmAutoriza.FlagMaster)
                {

                    if (Parametros.strUsuarioLogin == "master" || Parametros.strUsuarioLogin == "ltapia" || 
                       frmAutoriza.IdPerfil == Parametros.intPerAdministrador || frmAutoriza.IdPerfil == Parametros.intPerAnalistaProducto
                       || Parametros.strUsuarioLogin == "focampo")
                    {
                        txtPrecio.Enabled = true;
                    }
                    else
                    {
                        txtPrecio.Enabled = false;
                    }

                    ActivaControles(true);
                    txtPrecio.Focus();
                }
        }

        #endregion

        #region "Metodos"

        private void ActivaControles(bool value)
        {
            //txtPrecio.Enabled = false;
            txtPorDesc.Enabled = value;
            btnAceptar.Enabled = value;
        }

        #endregion

        
    }
}