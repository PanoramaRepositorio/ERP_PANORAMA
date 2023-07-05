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
    public partial class frmManMetasLineaProductoEdit : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"


        public List<MetasLineaProductoBE> lstMetasLineaProducto;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdMetasLineaProducto = 0;

        public int IdMetasLineaProducto
        {
            get { return _IdMetasLineaProducto; }
            set { _IdMetasLineaProducto = value; }
        }

        #endregion

        #region "Eventos"
        public frmManMetasLineaProductoEdit()
        {
            InitializeComponent();
        }

        private void frmManMetasLineaProductoEdit_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescLineaProducto", "IdLineaProducto", true);
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = 1;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "MetasLineaProducto - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "MetasLineaProducto - Modificar";

                MetasLineaProductoBE objE_MetasLineaProducto = new MetasLineaProductoBE();
                objE_MetasLineaProducto = new MetasLineaProductoBL().Selecciona(Parametros.intEmpresaId, IdMetasLineaProducto);

                cboLinea.EditValue = objE_MetasLineaProducto.IdLineaProducto;
                cboVendedor.EditValue = objE_MetasLineaProducto.IdVendedor;
                txtPeriodo.EditValue = objE_MetasLineaProducto.Periodo;
                cboMes.EditValue = objE_MetasLineaProducto.Mes;
                txtImporte.Text = Convert.ToString(objE_MetasLineaProducto.Importe);
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
                    MetasLineaProductoBL objBL_MetasLineaProducto = new MetasLineaProductoBL();
                    MetasLineaProductoBE objE_MetasLineaProducto = new MetasLineaProductoBE();

                    objE_MetasLineaProducto.IdMetasLineaProducto = IdMetasLineaProducto;
                    objE_MetasLineaProducto.IdEmpresa = Parametros.intEmpresaId;
                    objE_MetasLineaProducto.IdLineaProducto = Convert.ToInt32(cboLinea.EditValue);
                    objE_MetasLineaProducto.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objE_MetasLineaProducto.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objE_MetasLineaProducto.Mes = Convert.ToInt32(cboMes.EditValue);
                    objE_MetasLineaProducto.Importe = Convert.ToDecimal(txtImporte.Text.Trim());
                    objE_MetasLineaProducto.FlagEstado = true;
                    objE_MetasLineaProducto.Usuario = Parametros.strUsuarioLogin;
                    objE_MetasLineaProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_MetasLineaProducto.Inserta(objE_MetasLineaProducto);
                    else
                        objBL_MetasLineaProducto.Actualiza(objE_MetasLineaProducto);

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
                var Buscar = lstMetasLineaProducto.Where(oB => oB.DescLineaProducto.ToUpper() == cboLinea.Text.ToUpper() && oB.DescVendedor.ToUpper() == cboVendedor.Text.ToUpper() && oB.Periodo == Convert.ToInt32(txtPeriodo.EditValue) && oB.Mes == Convert.ToInt32(cboMes.EditValue)).ToList();
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