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
    public partial class frmManContratoAsesoriaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<Dis_ContratoAsesoriaBE> lstDis_ContratoAsesoria;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        //public Dis_ContratoAsesoriaBE pDis_ContratoAsesoriaBE { get; set; }

        int _IdDis_ContratoAsesoria = 0;

        public int IdDis_ContratoAsesoria
        {
            get { return _IdDis_ContratoAsesoria; }
            set { _IdDis_ContratoAsesoria = value; }
        }

        #endregion

        #region "Eventos"

        public frmManContratoAsesoriaEdit()
        {
            InitializeComponent();
        }

        private void frmManContratoAsesoriaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Contrato de Asesoria - Nuevo";
                //txtDis_ContratoAsesoria.Text = pDis_ContratoAsesoriaBE.DescDis_ContratoAsesoria.Trim();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Contrato de Asesoria - Modificar";

                Dis_ContratoAsesoriaBE objE_Dis_ContratoAsesoriaBE = new Dis_ContratoAsesoriaBE();
                objE_Dis_ContratoAsesoriaBE = new Dis_ContratoAsesoriaBL().Selecciona(IdDis_ContratoAsesoria);

                txtDescripcion.Text = objE_Dis_ContratoAsesoriaBE.Descripcion;
                txtTitulo.Text = objE_Dis_ContratoAsesoriaBE.Titulo;
                txtCuerpo.Text = objE_Dis_ContratoAsesoriaBE.CuerpoSustantivo;
                txtProcedimiento.Text = objE_Dis_ContratoAsesoriaBE.Procedimiento;
                txtPlazoCosto.Text = objE_Dis_ContratoAsesoriaBE.PlazoCosto;
                txtPublicidad.Text = objE_Dis_ContratoAsesoriaBE.Publicidad;
                txtVersion.Text = objE_Dis_ContratoAsesoriaBE.Version;
            }

            txtDescripcion.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    Dis_ContratoAsesoriaBL objBL_Dis_ContratoAsesoria = new Dis_ContratoAsesoriaBL();
                    Dis_ContratoAsesoriaBE objDis_ContratoAsesoria = new Dis_ContratoAsesoriaBE();

                    objDis_ContratoAsesoria.IdDis_ContratoAsesoria = IdDis_ContratoAsesoria;
                    objDis_ContratoAsesoria.Descripcion = txtDescripcion.Text;
                    objDis_ContratoAsesoria.Titulo = txtTitulo.Text;
                    objDis_ContratoAsesoria.CuerpoSustantivo = txtCuerpo.Text;
                    objDis_ContratoAsesoria.Procedimiento = txtProcedimiento.Text;
                    objDis_ContratoAsesoria.PlazoCosto = txtPlazoCosto.Text;
                    objDis_ContratoAsesoria.Publicidad = txtPublicidad.Text;
                    objDis_ContratoAsesoria.Version = txtVersion.Text;
                    objDis_ContratoAsesoria.FlagEstado = true;
                    objDis_ContratoAsesoria.Usuario = Parametros.strUsuarioLogin;
                    objDis_ContratoAsesoria.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDis_ContratoAsesoria.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Dis_ContratoAsesoria.Inserta(objDis_ContratoAsesoria);
                    else
                        objBL_Dis_ContratoAsesoria.Actualiza(objDis_ContratoAsesoria);

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

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese nombre de contrato.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstDis_ContratoAsesoria.Where(oB => oB.Descripcion.ToUpper() == txtDescripcion.Text.ToUpper() || oB.Version.ToUpper() == txtVersion.Text.ToUpper()).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "-El contrato ya existe.\n";
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