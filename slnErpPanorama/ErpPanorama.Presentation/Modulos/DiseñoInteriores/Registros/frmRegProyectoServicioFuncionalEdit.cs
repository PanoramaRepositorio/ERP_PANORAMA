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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    public partial class frmRegProyectoServicioFuncionalEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<Dis_DisenoFuncionalBE> mListaDis_DisenoFuncional = new List<Dis_DisenoFuncionalBE>();

        public Dis_DisenoFuncionalBE oBE { get; set; }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdDis_ProyectoServicio = 0;
        public int IdDis_DisenoFuncional = 0;

        #endregion

        #region "Eventos"
        public frmRegProyectoServicioFuncionalEdit()
        {
            InitializeComponent();
        }

        private void frmRegProyectoServicioFuncionalEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboAmbiente, new Dis_AmbienteBL().ListaTodosActivo(Parametros.intEmpresaId), "DescDis_Ambiente", "IdDis_Ambiente", true);
            BSUtils.LoaderLook(cboPieza, new Dis_PiezaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescDis_Pieza", "IdDis_Pieza", true);
            BSUtils.LoaderLook(cboMaterial, new MaterialBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMaterial", "IdMaterial", true);
            BSUtils.LoaderLook(cboEstilo, new Dis_EstiloBL().ListaTodosActivo(Parametros.intEmpresaId), "DescDis_Estilo", "IdDis_Estilo", true);
            BSUtils.LoaderLook(cboForma, new Dis_FormaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescDis_Forma", "IdDis_Forma", true);
            
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Servicio Funcional - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Servicio Funcional - Modificar";
                cboAmbiente.EditValue = oBE.IdDis_Ambiente;
                txtActividad.Text = oBE.DescActividad.Trim();
                cboPieza.EditValue = oBE.IdDis_Pieza;
                txtCantidad.EditValue = oBE.Cantidad;
                cboMaterial.EditValue = oBE.IdMaterial;
                cboEstilo.EditValue = oBE.IdDis_Estilo;
                cboForma.EditValue = oBE.IdDis_Forma;
                txtVolumen.EditValue = oBE.DescVolumen.Trim();
                txtTextura.EditValue = oBE.DescTextura.Trim();
                txtObservacion.EditValue = oBE.Observacion.Trim();
            }

            cboAmbiente.Focus();

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");                
                //txtPrecioVenta.Focus();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtActividad.Text.Trim() == "")
                {
                    XtraMessageBox.Show("La actividad no puede estar vacia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtActividad.SelectAll();
                    txtActividad.Focus();
                    return;
                }

                if (Convert.ToInt32(txtCantidad.EditValue) == 0)
                {
                    XtraMessageBox.Show("La cantidad no puede ser 0", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.SelectAll();
                    txtCantidad.Focus();
                    return;
                }

                oBE = new Dis_DisenoFuncionalBE();
                oBE.IdDis_ProyectoServicio = IdDis_ProyectoServicio;
                oBE.IdDis_DisenoFuncional = IdDis_DisenoFuncional;
                oBE.IdDis_Ambiente = Convert.ToInt32(cboAmbiente.EditValue);
                oBE.DescDis_Ambiente = cboAmbiente.Text;
                oBE.DescActividad = txtActividad.Text.Trim();
                oBE.IdDis_Pieza = Convert.ToInt32(cboPieza.EditValue);
                oBE.DescDis_Pieza = cboPieza.Text;
                oBE.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                oBE.IdMaterial = Convert.ToInt32(cboMaterial.EditValue);
                oBE.DescMaterial = cboMaterial.Text;
                oBE.IdDis_Estilo = 1;// Convert.ToInt32(cboEstilo.EditValue);
                oBE.DescDis_Estilo = cboEstilo.Text;
                oBE.IdDis_Forma = Convert.ToInt32(cboForma.EditValue);
                oBE.DescDis_Forma = cboForma.Text;
                oBE.DescVolumen = txtVolumen.Text.Trim();
                oBE.DescTextura = txtTextura.Text.Trim();
                oBE.Observacion = txtObservacion.Text.Trim();


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