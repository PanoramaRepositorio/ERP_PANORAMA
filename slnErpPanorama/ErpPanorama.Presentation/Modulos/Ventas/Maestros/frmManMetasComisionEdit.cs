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
    public partial class frmManMetasComisionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<MetasComisionBE> lstMetasComision;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdMetaComision = 0;

        public int IdMetaComision
        {
            get { return _IdMetaComision; }
            set { _IdMetaComision = value; }
        }

        #endregion

        #region "Metodos"
        public frmManMetasComisionEdit()
        {
            InitializeComponent();
        }

        private void frmManMetasComisionEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = 1;
            BSUtils.LoaderLook(cboCargo, CargarCargo(), "Descripcion", "Id", false);
            cboCargo.EditValue = 35;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Metas Comision - Nuevo";
                txtMinimo.Select();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Metas Comision - Modificar";

                MetasComisionBE objE_MetasComision = new MetasComisionBE();
                objE_MetasComision = new MetasComisionBL().Selecciona(Parametros.intEmpresaId, IdMetaComision);

                cboTienda.EditValue = objE_MetasComision.IdTienda;
                cboCargo.EditValue = objE_MetasComision.IdCargo;
                txtMinimo.Text = Convert.ToString(objE_MetasComision.CriterioMinimo);
                txtMaximo.Text = Convert.ToString(objE_MetasComision.CriterioMaximo);
                txtBono.Text = Convert.ToString(objE_MetasComision.Bono);
                txtBono.Select();
            }

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    MetasComisionBL objBL_MetasComision = new MetasComisionBL();
                    MetasComisionBE objE_MetasComision = new MetasComisionBE();

                    objE_MetasComision.IdMetaComision = IdMetaComision;
                    objE_MetasComision.IdEmpresa = Parametros.intEmpresaId;
                    objE_MetasComision.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objE_MetasComision.IdCargo = Convert.ToInt32(cboCargo.EditValue);
                    objE_MetasComision.CriterioMinimo = Convert.ToDecimal(txtMinimo.Text.Trim());
                    objE_MetasComision.CriterioMaximo = Convert.ToDecimal(txtMaximo.Text.Trim());
                    objE_MetasComision.Bono = Convert.ToDecimal(txtBono.Text.Trim());
                    objE_MetasComision.FlagEstado = true;
                    objE_MetasComision.Usuario = Parametros.strUsuarioLogin;
                    objE_MetasComision.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_MetasComision.Inserta(objE_MetasComision);
                    else
                        objBL_MetasComision.Actualiza(objE_MetasComision);

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

            if (txtMinimo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese el Importe.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstMetasComision.Where(oB => oB.DescTienda.ToUpper() == cboTienda.Text.ToUpper() && oB.Cargo.ToUpper() == cboCargo.Text.ToUpper() && oB.CriterioMinimo == Convert.ToDecimal(txtMinimo.Text.Trim()) && oB.CriterioMaximo == Convert.ToDecimal(txtMaximo.Text.Trim())).ToList();
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

        private DataTable CargarCargo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 35;
            dr["Descripcion"] = "ASESOR DE VENTAS DE PISO JUNIOR";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 44;
            dr["Descripcion"] = "ASESOR DE VENTAS DE PISO SENIOR";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 37;
            dr["Descripcion"] = "ASESOR DE VENTAS DE CARTERA";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 225;
            dr["Descripcion"] = "ASESOR DE VENTAS DE PISO MASTER";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 120;
            dr["Descripcion"] = "ASESOR DE DISEÑO DE INTERIOR";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 51;
            dr["Descripcion"] = "SUPERVISORA DE VENTAS DE PISO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 288;
            dr["Descripcion"] = "ASESOR DE VENTAS DE PISO PART-TIME";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 15;
            dr["Descripcion"] = "CAJERO(A)";
            dt.Rows.Add(dr);
            return dt;
        }


        #endregion

        private void txtBono_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void txtBono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnGrabar.Focus();
            }
        }
    }
}