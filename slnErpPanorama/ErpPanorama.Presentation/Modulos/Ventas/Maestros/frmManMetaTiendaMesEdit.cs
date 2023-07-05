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
    public partial class frmManMetaTiendaMesEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<MetaTiendaMesBE> lstMetaTiendaMes;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdMetaTiendaMes = 0;

        public int IdMetaTiendaMes
        {
            get { return _IdMetaTiendaMes; }
            set { _IdMetaTiendaMes = value; }
        }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }

        public int IdTienda = 0;
        public int IdTipoCliente = 0;
        public int Periodo = Parametros.intPeriodo;
        public int Mes = 0;


        #endregion

        #region "Eventos"

        public frmManMetaTiendaMesEdit()
        {
            InitializeComponent();
        }

        private void frmManMetaTiendaMesEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            //cboTienda.EditValue = 1;
            BSUtils.LoaderLook(cboTipoCliente, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTipoCliente), "DescTablaElemento", "IdTablaElemento", false);
            cboTipoCliente.EditValue = Parametros.intTipClienteFinal;
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = 1;
            txtPeriodo.EditValue = Parametros.intPeriodo;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "MetaTiendaMes - Nuevo";
                txtPeriodo.EditValue = Periodo;
                cboMes.EditValue = Mes;
                cboTienda.EditValue = IdTienda;
                cboTipoCliente.EditValue = IdTipoCliente;
                txtImporte.Select();
            }

            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "MetaTiendaMes - Modificar";

                MetaTiendaMesBE objE_MetaTiendaMes = new MetaTiendaMesBE();
                objE_MetaTiendaMes = new MetaTiendaMesBL().Selecciona(IdMetaTiendaMes);
                txtPeriodo.EditValue = objE_MetaTiendaMes.Periodo;
                cboTienda.EditValue = objE_MetaTiendaMes.IdTienda;
                cboMes.EditValue = objE_MetaTiendaMes.Mes;
                cboTipoCliente.EditValue = objE_MetaTiendaMes.IdTipoCliente;
                txtImporte.Text = Convert.ToString(objE_MetaTiendaMes.Importe);
                txtImporte.Select();
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    MetaTiendaMesBL objBL_MetaTiendaMes = new MetaTiendaMesBL();
                    MetaTiendaMesBE objE_MetaTiendaMes = new MetaTiendaMesBE();

                    objE_MetaTiendaMes.IdMetaTiendaMes = IdMetaTiendaMes;
                    objE_MetaTiendaMes.IdEmpresa = Parametros.intEmpresaId;
                    objE_MetaTiendaMes.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objE_MetaTiendaMes.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objE_MetaTiendaMes.Mes = Convert.ToInt32(cboMes.EditValue);
                    objE_MetaTiendaMes.IdTipoCliente = Convert.ToInt32(cboTipoCliente.EditValue);
                    objE_MetaTiendaMes.Importe = Convert.ToDecimal(txtImporte.Text.Trim());
                    objE_MetaTiendaMes.FlagEstado = true;
                    objE_MetaTiendaMes.Usuario = Parametros.strUsuarioLogin;
                    objE_MetaTiendaMes.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_MetaTiendaMes.Inserta(objE_MetaTiendaMes);
                    else
                        objBL_MetaTiendaMes.Actualiza(objE_MetaTiendaMes);

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

            if (cboTienda.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar Tienda.\n";
                flag = true;
            }

            if (cboTipoCliente.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar Tipo de Cliente.\n";
                flag = true;
            }

            if (cboMes.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar Mes.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                MetaTiendaMesBE objE_MetaTiendaMes = null;
                objE_MetaTiendaMes = new MetaTiendaMesBL().SeleccionaTiendaTipoCliente(Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboTipoCliente.EditValue), Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue));
                if (objE_MetaTiendaMes != null)
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

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

    }
}