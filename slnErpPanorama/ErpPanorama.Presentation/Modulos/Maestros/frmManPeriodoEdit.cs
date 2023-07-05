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

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManPeriodoEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"


        public List<PeriodoBE> lstPeriodo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public PeriodoBE pPeriodoBE { get; set; }

        int _IdPeriodo = 0;

        public int IdPeriodo
        {
            get { return _IdPeriodo; }
            set { _IdPeriodo = value; }
        }

        #endregion

        #region "Eventos"
        public frmManPeriodoEdit()
        {
            InitializeComponent();
        }

        private void frmManPeriodoEdit_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = 1;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Periodo - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Periodo - Modificar";
                txtPeriodo.EditValue = pPeriodoBE.Periodo;
                cboMes.EditValue = pPeriodoBE.Mes;
            }

            txtPeriodo.Select();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    PeriodoBL objBL_Periodo = new PeriodoBL();
                    PeriodoBE objPeriodo = new PeriodoBE();

                    objPeriodo.IdPeriodo = IdPeriodo;
                    objPeriodo.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objPeriodo.Mes = Convert.ToInt32(cboMes.EditValue);
                    objPeriodo.FlagEstado = true;
                    objPeriodo.Usuario = Parametros.strUsuarioLogin;
                    objPeriodo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Periodo.Inserta(objPeriodo);
                    else
                        objBL_Periodo.Actualiza(objPeriodo);

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


            if (txtPeriodo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Periodo.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstPeriodo.Where(oB => oB.Periodo == Convert.ToInt32(txtPeriodo.EditValue) && oB.Mes == Convert.ToInt32(cboMes.EditValue)).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- El Periodo ya existe.\n";
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

        private DataTable CargarMes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "Enero";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 2;
            dr["Descripcion"] = "Febrero";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 3;
            dr["Descripcion"] = "Marzo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 4;
            dr["Descripcion"] = "Abril";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 5;
            dr["Descripcion"] = "Mayo";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 6;
            dr["Descripcion"] = "Junio";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 7;
            dr["Descripcion"] = "Julio";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 8;
            dr["Descripcion"] = "Agosto";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "Septiembre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 10;
            dr["Descripcion"] = "Octubre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["Descripcion"] = "Noviembre";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "Diciembre";
            dt.Rows.Add(dr);

            return dt;
        }

        #endregion


    }
}