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
    public partial class frmManAreasEdit : DevExpress.XtraEditors.XtraForm
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

        public frmManAreasEdit()
        {
            InitializeComponent();
        }

        private void frmManAreasEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTabla, new TablaElementoBL().ListaTodosActivo(Parametros.intIdPanoramaDistribuidores, 79) , "DescTablaElemento", "IdTablaElemento", true);   // Unidad de negocio
            //cboTabla.EditValue = -1;
            BSUtils.LoaderLook(cboCentroCosto, new TablaElementoBL().ListaTodosActivo(Parametros.intIdPanoramaDistribuidores, 80), "DescTablaElemento", "IdTablaElemento", true);   // Centro de costo
            //cboCentroCosto.EditValue = -1;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Areas - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Areas - Modificar";
                txtDescAreas.Text = pTablaElementoBE.DescTablaElemento;
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
                    FAreasBL objBL_FAreas = new FAreasBL();

                    FAreasBE objFAreas = new FAreasBE();
                    objFAreas.DescArea = txtDescAreas.Text.Trim();
                    objFAreas.IdTablaUnidadNegocio = 79;
                    objFAreas.IdTablaElementoUnidadNegocio = Convert.ToInt32(cboTabla.EditValue);
                    objFAreas.IdTablaCentroCosto = 80;
                    objFAreas.IdTablaElementoCentroCosto = Convert.ToInt32(cboCentroCosto.EditValue);

                    if (pOperacion == Operacion.Nuevo)
                        objBL_FAreas.Inserta(objFAreas);
                    else
                        objBL_FAreas.Actualiza(objFAreas);

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

            if (txtDescAreas.Text.Trim().ToString() == "")
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