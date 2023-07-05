using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Maestros
{
    public partial class frmManTipificacionesEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<TipificacionesBE> lstTablaElemento;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TablaElementoBE pTablaElementoBE { get; set; }

        int _IdTabla = 0;

        public int IdTabla
        {
            get { return _IdTabla; }
            set { _IdTabla = value; }
        }

        int _IdTablaElemento = 0;

        public int IdTablaElemento
        {
            get { return _IdTablaElemento; }
            set { _IdTablaElemento = value; }
        }

        #endregion

        #region "Eventos"

        public frmManTipificacionesEdit()
        {
            InitializeComponent();
        }

        private void frmManTablaElementoEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTabla, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, 73) , "DescTablaElemento", "IdTablaElemento", true);   // Tipo de gestión
            cboTabla.EditValue = IdTablaElemento;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Tipificación - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Tipificación - Modificar";
                txtDescTipificacion.Text = pTablaElementoBE.DescTablaElemento;
            }

            txtDescTipificacion.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                   TipificacionesBL objBL_Tipificaciones = new TipificacionesBL();

                    TipificacionesBE objTablaElemento = new TipificacionesBE();
                    objTablaElemento.DescTipificacion = txtDescTipificacion.Text;
                    objTablaElemento.IdTabla = IdTabla;
                    objTablaElemento.IdTablaElemento = Convert.ToInt32(cboTabla.EditValue);

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Tipificaciones.Inserta(objTablaElemento);
                    else
                        objBL_Tipificaciones.Actualiza(objTablaElemento);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboTabla.Text))
            {
                strMensaje = strMensaje + "- Seleccionar la tabla.\n";
                flag = true;
            }

            if (txtDescTipificacion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstTablaElemento.Where(oB => oB.DescTipificacion.ToUpper() == txtDescTipificacion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La descripción ya existe.\n";
                    flag = true;
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        #endregion

        
    }
}