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
    public partial class frmManMetaConversionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<MetaConversionBE> lstMetaConversion;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdMetaConversion = 0;

        public int IdMetaConversion
        {
            get { return _IdMetaConversion; }
            set { _IdMetaConversion = value; }
        }

        #endregion

        #region "Eventos"
        public frmManMetaConversionEdit()
        {
            InitializeComponent();
        }

        private void frmManMetaConversionEdit_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = 1;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Meta Conversión - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Meta Conversión - Modificar";

                MetaConversionBE objE_MetaConversion = new MetaConversionBE();
                objE_MetaConversion = new MetaConversionBL().Selecciona(IdMetaConversion);

                cboTienda.EditValue = objE_MetaConversion.IdTienda;
                txtPeriodo.EditValue = objE_MetaConversion.Periodo;
                cboMes.EditValue = objE_MetaConversion.Mes;
                txtImporte.Text = Convert.ToString(objE_MetaConversion.Importe);
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
                    MetaConversionBL objBL_MetaConversion = new MetaConversionBL();
                    MetaConversionBE objE_MetaConversion = new MetaConversionBE();

                    objE_MetaConversion.IdMetaConversion = IdMetaConversion;
                    objE_MetaConversion.IdEmpresa = Parametros.intEmpresaId;
                    objE_MetaConversion.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objE_MetaConversion.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objE_MetaConversion.Mes = Convert.ToInt32(cboMes.EditValue);
                    objE_MetaConversion.Importe = Convert.ToDecimal(txtImporte.Text.Trim());
                    objE_MetaConversion.FlagEstado = true;
                    objE_MetaConversion.Usuario = Parametros.strUsuarioLogin;
                    objE_MetaConversion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_MetaConversion.Inserta(objE_MetaConversion);
                    else
                        objBL_MetaConversion.Actualiza(objE_MetaConversion);

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

        private void txtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboTienda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboMes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
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
                var Buscar = lstMetaConversion.Where(oB => oB.DescTienda.ToUpper() == cboTienda.Text.ToUpper() && oB.Periodo == Convert.ToInt32(txtPeriodo.EditValue) && oB.Mes == Convert.ToInt32(cboMes.EditValue)).ToList();
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