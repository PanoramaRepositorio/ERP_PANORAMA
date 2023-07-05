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
    public partial class frmManSubTipificacionesEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<SubTipificacionesBE> lstTablaElemento;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public TablaElementoBE pTablaElementoBE { get; set; }

        public SubTipificacionesBE pSubTipificacionesBE { get; set; }

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
        int _IdSubTipificacion = 0;
        public int IdSubTipificacion
        {
            get { return _IdSubTipificacion; }
            set { _IdSubTipificacion = value; }
        }
        int _IdTipificacion = 0;
        public int IdTipificacion
        {
            get { return _IdTipificacion; }
            set { _IdTipificacion = value; }
        }
        int _IdArea = 0;
        public int IdArea
        {
            get { return _IdArea; }
            set { _IdArea = value; }
        }
        #endregion

        #region "Eventos"

        public frmManSubTipificacionesEdit()
        {
            InitializeComponent();
        }

        private void frmManSubTipificacionesEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTabla, new TipificacionesBL().Listar("") , "DescTipificacion", "IdTipificacion", true);   // Tipificacion
            cboTabla.EditValue = pSubTipificacionesBE.IdTipificacion;

            BSUtils.LoaderLook(cboAreas, new FAreasBL().Listar(""), "DescArea", "IdArea", true);   // Areas
            cboAreas.EditValue = pSubTipificacionesBE.IdArea;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Sub Tipificación - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Sub Tipificación - Modificar";
                txtDescSubTipificacion.Text = pSubTipificacionesBE.DescSubTipificacion;
            }

            cboTabla.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                   SubTipificacionesBL objBL_Tipificaciones = new SubTipificacionesBL();

                   SubTipificacionesBE objTipificaciones = new SubTipificacionesBE();
                    objTipificaciones.IdTipificacion= Convert.ToInt32(cboTabla.EditValue);
                    objTipificaciones.IdSubTipificacion = pSubTipificacionesBE.IdSubTipificacion;
                    objTipificaciones.DescSubTipificacion = txtDescSubTipificacion.Text;
                    objTipificaciones.IdArea = Convert.ToInt32(cboAreas.EditValue);

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Tipificaciones.Inserta(objTipificaciones);
                    else
                        objBL_Tipificaciones.Actualiza(objTipificaciones);

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

            if (txtDescSubTipificacion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                //var Buscar = lstTablaElemento.Where(oB => oB.DescSubTipificacion.ToUpper() == txtDescSubTipificacion.Text.ToUpper()).ToList();
                //if (Buscar.Count > 0)
                //{
                //    strMensaje = strMensaje + "- La descripción ya existe.\n";
                //    flag = true;
                //}
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