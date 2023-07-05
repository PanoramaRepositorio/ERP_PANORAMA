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
    public partial class frmManEstudioRealizadoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public EstudioRealizadoBE oBE;

        public int IdPersona = 0;
        public int IdEstudioRealizado = 0;

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

        public frmManEstudioRealizadoEdit()
        {
            InitializeComponent();
        }

        private void frmManEstudioRealizadoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboNivelEstudio, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblNivelEstudio), "DescTablaElemento", "IdTablaElemento", true);

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Estudios Realizados - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Estudios Realizados - Modificar";

                EstudioRealizadoBE objE_EstudioRealizado = null;
                objE_EstudioRealizado = new EstudioRealizadoBL().Selecciona(IdPersona, IdEstudioRealizado);

                cboNivelEstudio.EditValue = objE_EstudioRealizado.IdNivelEstudio;
                txtCentroEstudio.EditValue = objE_EstudioRealizado.CentroEstudio;
                txtGradoObtenido.Text = objE_EstudioRealizado.GradoObtenido;
                txtMesAnioInicio.Text = objE_EstudioRealizado.MesAnioIncio;
                txtMesAnioFin.EditValue = objE_EstudioRealizado.MesAnioFin;
                
            }

            cboNivelEstudio.Select();
        }

        private void cboNivelEstudio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtCentroEstudio.Focus();
            }
        }

        private void txtCentroEstudio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtGradoObtenido.Focus();
            }
        }

        private void txtGradoObtenido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtMesAnioInicio.Focus();
            }
        }

        private void txtMesAnioInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtMesAnioFin.Focus();
            }
        }

        private void txtMesAnioFin_KeyPress(object sender, KeyPressEventArgs e)
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
                if (txtCentroEstudio.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el centro de estudios.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCentroEstudio.SelectAll();
                    txtCentroEstudio.Focus();
                    return;
                }

                if (txtGradoObtenido.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar los Apellidos y Nombres", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtGradoObtenido.SelectAll();
                    txtGradoObtenido.Focus();
                    return;
                }

                oBE = new EstudioRealizadoBE();
                oBE.IdPersona = IdPersona;
                oBE.IdEstudioRealizado = IdEstudioRealizado;
                oBE.IdNivelEstudio = Convert.ToInt32(cboNivelEstudio.EditValue);
                oBE.DescNivelEstudio = cboNivelEstudio.Text;
                oBE.CentroEstudio = txtCentroEstudio.Text;
                oBE.GradoObtenido = txtGradoObtenido.Text;
                oBE.MesAnioIncio = txtMesAnioInicio.Text;
                oBE.MesAnioFin = txtMesAnioFin.Text;

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

        
        #region "Metodos"

        #endregion

        
        
    }
}