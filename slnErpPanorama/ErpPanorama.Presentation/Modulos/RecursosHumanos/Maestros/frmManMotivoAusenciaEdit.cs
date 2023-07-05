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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManMotivoAusenciaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<MotivoAusenciaBE> lstMotivoAusencia;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public MotivoAusenciaBE pMotivoAusenciaBE { get; set; }

        int _IdMotivoAusencia = 0;

        public int IdMotivoAusencia
        {
            get { return _IdMotivoAusencia; }
            set { _IdMotivoAusencia = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManMotivoAusenciaEdit()
        {
            InitializeComponent();
        }

        private void frmManMotivoAusenciaEdit_Load(object sender, EventArgs e)
        {
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Motivo de Ausencia - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Motivo de Ausencia - Modificar";
                txtDescripcion.Text = pMotivoAusenciaBE.DescMotivoAusencia.Trim();
                txtAbreviatura.Text = pMotivoAusenciaBE.Abreviatura;

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
                    MotivoAusenciaBL objBL_MotivoAusencia = new MotivoAusenciaBL();
                    MotivoAusenciaBE objMotivoAusencia = new MotivoAusenciaBE();
                    objMotivoAusencia.IdMotivoAusencia = IdMotivoAusencia;
                    objMotivoAusencia.DescMotivoAusencia = txtDescripcion.Text;
                    objMotivoAusencia.Abreviatura = txtAbreviatura.Text;
                    objMotivoAusencia.FlagEstado = true;
                    objMotivoAusencia.Usuario = Parametros.strUsuarioLogin;
                    objMotivoAusencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objMotivoAusencia.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_MotivoAusencia.Inserta(objMotivoAusencia);
                    else
                        objBL_MotivoAusencia.Actualiza(objMotivoAusencia);

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
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstMotivoAusencia.Where(oB => oB.DescMotivoAusencia.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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