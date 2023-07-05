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

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Maestros
{
    public partial class frmManPiezaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<Dis_PiezaBE> lstDis_Pieza;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public Dis_PiezaBE pDis_PiezaBE { get; set; }

        int _IdDis_Pieza = 0;

        public int IdDis_Pieza
        {
            get { return _IdDis_Pieza; }
            set { _IdDis_Pieza = value; }
        }

        #endregion

        #region "Eventos"
        public frmManPiezaEdit()
        {
            InitializeComponent();
        }

        private void frmManPiezaEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTipoPieza, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoPieza), "DescTablaElemento", "IdTablaElemento", true);
            
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Pieza - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Pieza - Modificar";
                txtDis_Pieza.Text = pDis_PiezaBE.DescDis_Pieza.Trim();
                cboTipoPieza.EditValue = pDis_PiezaBE.IdTipoPieza;
            }

            txtDis_Pieza.Select();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Dis_PiezaBL objBL_Dis_Pieza = new Dis_PiezaBL();

                    Dis_PiezaBE objDis_Pieza = new Dis_PiezaBE();
                    objDis_Pieza.IdDis_Pieza = IdDis_Pieza;
                    objDis_Pieza.DescDis_Pieza = txtDis_Pieza.Text;
                    objDis_Pieza.IdTipoPieza = Convert.ToInt32(cboTipoPieza.EditValue);
                    objDis_Pieza.FlagEstado = true;
                    objDis_Pieza.Usuario = Parametros.strUsuarioLogin;
                    objDis_Pieza.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDis_Pieza.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Dis_Pieza.Inserta(objDis_Pieza);
                    else
                        objBL_Dis_Pieza.Actualiza(objDis_Pieza);

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

            if (txtDis_Pieza.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese Pieza.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDis_Pieza.Where(oB => oB.DescDis_Pieza.ToUpper() == txtDis_Pieza.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Pieza ya existe.\n";
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