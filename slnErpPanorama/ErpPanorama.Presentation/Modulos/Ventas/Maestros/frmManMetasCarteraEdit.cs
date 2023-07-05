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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManMetasCarteraEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"


        public List<MetasCarteraBE> lstMetasCartera;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdMetasCartera = 0;

        public int IdMetasCartera
        {
            get { return _IdMetasCartera; }
            set { _IdMetasCartera = value; }
        }

        #endregion

        #region "Eventos"
        public frmManMetasCarteraEdit()
        {
            InitializeComponent();
        }

        private void frmManMetasCarteraEdit_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboRuta, new RutaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescRuta", "IdRuta", true);
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = 1;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "MetasCartera - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "MetasCartera - Modificar";

                MetasCarteraBE objE_MetasCartera = new MetasCarteraBE();
                objE_MetasCartera = new MetasCarteraBL().Selecciona(Parametros.intEmpresaId, IdMetasCartera);

                cboRuta.EditValue = objE_MetasCartera.IdRuta;
                txtPeriodo.EditValue = objE_MetasCartera.Periodo;
                cboMes.EditValue = objE_MetasCartera.Mes;
                txtImporte.Text = Convert.ToString(objE_MetasCartera.Importe);
            }

            txtImporte.Select();
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    MetasCarteraBL objBL_MetasCartera = new MetasCarteraBL();
                    MetasCarteraBE objE_MetasCartera = new MetasCarteraBE();

                    objE_MetasCartera.IdMetasCartera = IdMetasCartera;
                    objE_MetasCartera.IdEmpresa = Parametros.intEmpresaId;
                    objE_MetasCartera.IdRuta = Convert.ToInt32(cboRuta.EditValue);
                    objE_MetasCartera.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objE_MetasCartera.Mes = Convert.ToInt32(cboMes.EditValue);
                    objE_MetasCartera.Importe = Convert.ToDecimal(txtImporte.Text.Trim());
                    objE_MetasCartera.FlagEstado = true;
                    objE_MetasCartera.Usuario = Parametros.strUsuarioLogin;
                    objE_MetasCartera.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_MetasCartera.Inserta(objE_MetasCartera);
                    else
                        objBL_MetasCartera.Actualiza(objE_MetasCartera);

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

            if (txtImporte.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Importe.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstMetasCartera.Where(oB => oB.DescRuta.ToUpper() == cboRuta.Text.ToUpper() && oB.Periodo == Convert.ToInt32(txtPeriodo.EditValue) && oB.Mes == Convert.ToInt32(cboMes.EditValue)).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- la meta ya existe.\n";
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