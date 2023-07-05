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
    public partial class frmRegProyectoServicioEsteticoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<Dis_DisenoEsteticoBE> mListaDis_DisenoEstetico = new List<Dis_DisenoEsteticoBE>();

        public Dis_DisenoEsteticoBE oBE { get; set; }

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public int IdDis_ProyectoServicio = 0;
        public int IdDis_DisenoEstetico = 0;

        #endregion

        #region "Eventos"
        public frmRegProyectoServicioEsteticoEdit()
        {
            InitializeComponent();
        }

        private void frmRegProyectoServicioEsteticoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboEstilo, new Dis_EstiloBL().ListaTodosActivo(Parametros.intEmpresaId), "DescDis_Estilo", "IdDis_Estilo", true);
            BSUtils.LoaderLook(cboForma, new Dis_FormaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescDis_Forma", "IdDis_Forma", true);
            BSUtils.LoaderLook(cboMaterial, new MaterialBL().ListaTodosActivo(Parametros.intEmpresaId), "DescMaterial", "IdMaterial", true);
            BSUtils.LoaderLook(cboTipoColor, new Dis_TipoColorBL().ListaTodosActivo(Parametros.intEmpresaId), "DescDis_TipoColor", "IdDis_TipoColor", true);


            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Servicio Estetico - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Servicio Estetico - Modificar";
                txtObjetivos.EditValue = oBE.Objetivos;
                cboEstilo.EditValue = oBE.IdDis_Estilo;
                cboForma.EditValue = oBE.IdDis_Forma;
                txtVolumen.EditValue = oBE.DescVolumen;
                txtTextura.EditValue = oBE.DescTextura;
                cboMaterial.EditValue = oBE.IdMaterial;
                cboTipoColor.EditValue = oBE.IdDis_TipoColor;
           }

            cboEstilo.Focus();
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
                if (txtObjetivos.Text.Trim() == "")
                {
                    XtraMessageBox.Show("El objetivo no puede estar vacio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtObjetivos.SelectAll();
                    txtObjetivos.Focus();
                    return;
                }
                oBE = new Dis_DisenoEsteticoBE();
                oBE.IdDis_ProyectoServicio = IdDis_ProyectoServicio;
                oBE.IdDis_DisenoEstetico = IdDis_DisenoEstetico;
                oBE.Objetivos = txtObjetivos.Text;
                oBE.IdDis_Estilo = Convert.ToInt32(cboEstilo.EditValue);
                oBE.DescDis_Estilo = cboEstilo.Text;
                oBE.IdDis_Forma = Convert.ToInt32(cboForma.EditValue);
                oBE.DescDis_Forma = cboForma.Text;
                oBE.DescVolumen = txtVolumen.Text.Trim();
                oBE.DescTextura = txtTextura.Text.Trim();
                oBE.IdMaterial = Convert.ToInt32(cboMaterial.EditValue);
                oBE.DescMaterial = cboMaterial.Text;
                oBE.IdDis_TipoColor = Convert.ToInt32(cboTipoColor.EditValue);
                oBE.DescDis_TipoColor = cboTipoColor.Text;
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