using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManDerechoHabienteEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public DerechoHabienteBE oBE;

        public int IdPersona = 0;
        public int IdDerechoHabiente = 0;

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

        public frmManDerechoHabienteEdit()
        {
            InitializeComponent();
        }

        private void frmManDerechoHabienteEdit_Load(object sender, EventArgs e)
        {

            BSUtils.LoaderLook(cboSexo, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSexo), "DescTablaElemento", "IdTablaElemento", true);
            BSUtils.LoaderLook(cboParentesco, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblParentesco), "DescTablaElemento", "IdTablaElemento", true);

            deFechaNac.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Derecho Habiente - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Derecho Habiente - Modificar";

                DerechoHabienteBE objE_DerechoHabiente = null;
                objE_DerechoHabiente = new DerechoHabienteBL().Selecciona(IdPersona,IdDerechoHabiente);

                cboSexo.EditValue = objE_DerechoHabiente.IdSexo;
                cboParentesco.EditValue = objE_DerechoHabiente.IdParentesco;
                txtNumeroDocumento.Text = objE_DerechoHabiente.NumeroDocumento;
                txtApeNom.Text = objE_DerechoHabiente.ApeNom;
                deFechaNac.EditValue = objE_DerechoHabiente.FechaNac;
                txtOcupacion.Text = objE_DerechoHabiente.Ocupacion;
                chkEPS.Checked = objE_DerechoHabiente.FlagEps;
            }

            cboSexo.Select();
        }

        private void cboSexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                cboParentesco.Focus();
            }
        }

        private void cboParentesco_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtNumeroDocumento.Focus();
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtApeNom.Focus();
            }
        }

        private void txtApeNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                deFechaNac.Focus();
            }
        }

        private void deFechaNac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtOcupacion.Focus();
            }
        }

        private void txtOcupacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnAceptar.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroDocumento.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el numero de dni.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumeroDocumento.SelectAll();
                    txtNumeroDocumento.Focus();
                    return;
                }

                if (txtApeNom.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar los Apellidos y Nombres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtApeNom.SelectAll();
                    txtApeNom.Focus();
                    return;
                }

                oBE = new DerechoHabienteBE();
                oBE.IdPersona = IdPersona;
                oBE.IdDerechoHabiente = IdDerechoHabiente;
                oBE.IdSexo = Convert.ToInt32(cboSexo.EditValue);
                oBE.DescSexo = cboSexo.Text;
                oBE.IdParentesco = Convert.ToInt32(cboParentesco.EditValue);
                oBE.DescParentesco = cboParentesco.Text;
                oBE.NumeroDocumento = txtNumeroDocumento.Text;
                oBE.ApeNom = txtApeNom.Text;
                oBE.FechaNac = Convert.ToDateTime(deFechaNac.EditValue);
                oBE.Ocupacion = txtOcupacion.Text;
                oBE.FlagEps = chkEPS.Checked;
                
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        #endregion

        
        #region "Propiedades"
        
        #endregion

        
    }
}