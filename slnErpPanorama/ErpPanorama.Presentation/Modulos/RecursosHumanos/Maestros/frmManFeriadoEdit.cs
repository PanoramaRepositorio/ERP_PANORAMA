using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using System.Security.Principal;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManFeriadoEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<FeriadoBE> lstFeriado;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public FeriadoBE pFeriadoBE { get; set; }

        int _IdFeriado = 0;

        public int IdFeriado
        {
            get { return _IdFeriado; }
            set { _IdFeriado = value; }
        }

        #endregion

        #region "Eventos"

        public frmManFeriadoEdit()
        {
            InitializeComponent();
        }

        private void frmManFeriadoEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Feriado - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Feriado - Modificar";

                deFecha.EditValue = pFeriadoBE.Fecha;
                txtDescFeriado.Text = pFeriadoBE.DescFeriado;
            }

            txtDescFeriado.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    FeriadoBL objBL_Feriado = new FeriadoBL();

                    FeriadoBE objFeriado = new FeriadoBE();
                    objFeriado.IdFeriado = IdFeriado;
                    objFeriado.Fecha = Convert.ToDateTime(deFecha.Text);
                    objFeriado.Periodo = deFecha.DateTime.Year;
                    objFeriado.Mes = deFecha.DateTime.Month;
                    objFeriado.DescFeriado = txtDescFeriado.Text;
                    objFeriado.FlagEstado = true;
                    objFeriado.Usuario = Parametros.strUsuarioLogin;
                    objFeriado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objFeriado.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Feriado.Inserta(objFeriado);
                    else
                        objBL_Feriado.Actualiza(objFeriado);

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

            if (deFecha.Text == string.Empty)
            {
                strMensaje = strMensaje + "- Ingrese Fecha.\n";
                flag = true;
            }

            if (txtDescFeriado.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el nombre del Feriado.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstFeriado.Where(oB => oB.Fecha == Convert.ToDateTime(deFecha.DateTime.ToShortDateString())).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- La fecha del Feriado ya existe.\n";
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