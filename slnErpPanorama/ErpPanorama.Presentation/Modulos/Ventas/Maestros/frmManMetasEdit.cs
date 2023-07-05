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
    public partial class frmManMetasEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<MetasBE> lstMetas;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdMeta = 0;

        public int IdMeta
        {
            get { return _IdMeta; }
            set { _IdMeta = value; }
        }

        int _IdEmpresa = 0;

        public int IdEmpresa
        {
            get { return _IdEmpresa; }
            set { _IdEmpresa = value; }
        }

        #endregion

        #region "Eventos"
        public frmManMetasEdit()
        {
            InitializeComponent();
        }

        private void frmManMetasEdit_Load(object sender, EventArgs e)
        {

            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(IdEmpresa), "DescTienda", "IdTienda", true);
            //cboTienda.EditValue = 1;
            BSUtils.LoaderLook(cboCargo, CargarCargo(), "Descripcion", "Id", false);
            cboCargo.EditValue = 35;
            BSUtils.LoaderLook(cboMes, CargarMes(), "Descripcion", "Id", false);
            cboMes.EditValue = 1;
            txtPeriodo.EditValue = Parametros.intPeriodo;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Metas - Nuevo";
                cboMes.Select();
            }

            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Metas - Modificar";

                MetasBE objE_Metas = new MetasBE();
                objE_Metas = new MetasBL().Selecciona(IdEmpresa, IdMeta);
                txtPeriodo.EditValue = objE_Metas.Periodo;
                cboTienda.EditValue = objE_Metas.IdTienda;
                cboMes.EditValue = objE_Metas.Mes;
                cboCargo.EditValue = objE_Metas.IdCargo;
                txtImporte.EditValue = objE_Metas.Importe;
                txtImporteFinal.EditValue = objE_Metas.ImporteFinal;
                txtImporteMayorista.EditValue = objE_Metas.ImporteMayorista;
                txtImporteDiseno.EditValue = objE_Metas.ImporteDiseno;
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
                    MetasBL objBL_Metas = new MetasBL();
                    MetasBE objE_Metas = new MetasBE();

                    objE_Metas.IdMeta = IdMeta;
                    objE_Metas.IdEmpresa = IdEmpresa;
                    objE_Metas.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objE_Metas.Periodo = Convert.ToInt32(txtPeriodo.EditValue);
                    objE_Metas.Mes = Convert.ToInt32(cboMes.EditValue);
                    objE_Metas.IdCargo = Convert.ToInt32(cboCargo.EditValue);
                    objE_Metas.Importe = Convert.ToDecimal(txtImporte.Text.Trim());
                    objE_Metas.ImporteFinal = Convert.ToDecimal(txtImporteFinal.EditValue);
                    objE_Metas.ImporteMayorista = Convert.ToDecimal(txtImporteMayorista.EditValue);
                    objE_Metas.ImporteDiseno = Convert.ToDecimal(txtImporteDiseno.EditValue);
                    objE_Metas.FlagEstado = true;
                    objE_Metas.Usuario = Parametros.strUsuarioLogin;
                    objE_Metas.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    if (pOperacion == Operacion.Nuevo)
                        objBL_Metas.Inserta(objE_Metas);
                    else
                        objBL_Metas.Actualiza(objE_Metas);

                    this.DialogResult = DialogResult.OK;
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

        private void cboCargo_EditValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cboCargo.EditValue) == Parametros.intPerSupervisorVentasPiso)
            //{
                    
            //}
        }

        private void txtImporteFinal_EditValueChanged(object sender, EventArgs e)
        {
            //CalcularTotal();
        }

        private void txtImporteMayorista_EditValueChanged(object sender, EventArgs e)
        {
            //CalcularTotal();
        }

        private void txtImporteDiseno_EditValueChanged(object sender, EventArgs e)
        {
            //CalcularTotal();
        }

        private void txtImporteFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalcularTotal();
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtImporteMayorista_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalcularTotal();
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtImporteDiseno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CalcularTotal();
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
                MetasBE objE_Metas = null;
                objE_Metas = new MetasBL().SeleccionaCargoMes(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(txtPeriodo.EditValue), Convert.ToInt32(cboMes.EditValue), Convert.ToInt32(cboCargo.EditValue));
                if (objE_Metas != null)
                {
                    strMensaje = strMensaje + "- la meta ya existe.\n";
                    flag = true;
                }
            }


            //if (pOperacion == Operacion.Nuevo)
            //{
            //    var Buscar = lstMetas.Where(oB =>
            //            oB.DescTienda.ToUpper() == cboTienda.Text.ToUpper() && 
            //            oB.Cargo.ToUpper() == cboCargo.Text.ToUpper() &&
            //            oB.Periodo == Convert.ToInt32(txtPeriodo.EditValue) &&
            //            oB.Mes == Convert.ToInt32(cboMes.EditValue)).ToList();
            //    if (Buscar.Count > 0)
            //    {
            //        strMensaje = strMensaje + "- la meta ya existe.\n";
            //        flag = true;
            //    }
            //}

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
            dr["Id"] = 225;
            dr["Descripcion"] = "ASESOR DE VENTAS DE PISO MASTER";
            dt.Rows.Add(dr);
            dr = dt.NewRow();

            dr["Id"] = 467;
            dr["Descripcion"] = "ASESOR DE DISEÑO DE INTERIOR JUNIOR";
            dt.Rows.Add(dr);
            dr = dt.NewRow();

            dr["Id"] = 120;
            dr["Descripcion"] = "ASESOR DE DISEÑO DE INTERIOR MASTER";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 469;
            dr["Descripcion"] = "ASESOR DE DISEÑO DE INTERIORES SENIOR";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 51;
            dr["Descripcion"] = "ADMINSTRADOR DE TIENDA";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 391;
            dr["Descripcion"] = "SUB ADMINSTRADOR DE TIENDA";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 288;
            dr["Descripcion"] = "ASESOR DE VENTAS PART-TIME";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 15;
            dr["Descripcion"] = "CAJERO(A)";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 462;
            dr["Descripcion"] = "AUXILIAR DE TIENDA";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 402;
            dr["Descripcion"] = "JEFE DE PRODUCCIÓN";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 465;
            dr["Descripcion"] = "VENDEDOR ECOMMERCE";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Id"] = 626;
            dr["Descripcion"] = "WHATSAPP";
            dt.Rows.Add(dr);



            return dt;
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

        private void CalcularTotal()
        {
            decimal TotalMeta = 0;
            TotalMeta = Convert.ToDecimal(txtImporteFinal.EditValue) + Convert.ToDecimal(txtImporteMayorista.EditValue) + Convert.ToDecimal(txtImporteDiseno.EditValue);
            txtImporte.EditValue = TotalMeta;
        }


        #endregion

    }
}