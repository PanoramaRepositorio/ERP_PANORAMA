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

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManHorarioEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        public List<HorarioBE> lstHorario;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public HorarioBE pHorarioBE { get; set; }

        int _IdHorario = 0;

        public int IdHorario
        {
            get { return _IdHorario; }
            set { _IdHorario = value; }
        }
        
        #endregion

        #region "Eventos"

        public frmManHorarioEdit()
        {
            InitializeComponent();
        }

        private void frmManHorarioEdit_Load(object sender, EventArgs e)
        {
            
            deFechaIni.EditValue = DateTime.Now;
            deFechaFin.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Horario Laboral - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Horario Laboral - Modificar";

                txtDescHorario.Text = pHorarioBE.DescHorario;
                deFechaIni.EditValue = pHorarioBE.FechaIni;
                deFechaFin.EditValue = pHorarioBE.FechaFin;
                txtObservacion.Text = pHorarioBE.Observacion;
            }

            txtDescHorario.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    HorarioBL objBL_Horario = new HorarioBL();

                    HorarioBE objHorario = new HorarioBE();
                    objHorario.IdHorario = IdHorario;
                    objHorario.DescHorario = txtDescHorario.Text;
                    objHorario.FechaIni = Convert.ToDateTime(deFechaIni.Text);
                    objHorario.FechaFin = Convert.ToDateTime(deFechaFin.Text);
                    objHorario.Observacion = txtObservacion.Text;
                    objHorario.FlagEstado = true;
                    objHorario.Usuario = Parametros.strUsuarioLogin;
                    objHorario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objHorario.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Horario.Inserta(objHorario);
                    else
                        objBL_Horario.Actualiza(objHorario);

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

            if (txtDescHorario.Text.Trim().ToString() == "0.00")
            {
                strMensaje = strMensaje + "- Ingrese el nombre del horario.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstHorario.Where(oB => oB.DescHorario == txtDescHorario.Text).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El nombre del horario ya existe.\n";
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