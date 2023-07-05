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
    public partial class frmManInventarioVisualModuloEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<InventarioVisualModuloBE> lstInventarioVisualModulo;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public InventarioVisualModuloBE pInventarioVisualModuloBE { get; set; }

        int _IdInventarioVisualModulo = 0;

        public int IdInventarioVisualModulo
        {
            get { return _IdInventarioVisualModulo; }
            set { _IdInventarioVisualModulo = value; }
        }

        int _IdInventarioVisualBloque = 0;

        public int IdInventarioVisualBloque
        {
            get { return _IdInventarioVisualBloque; }
            set { _IdInventarioVisualBloque = value; }
        }

        int _IdTienda = 0;

        public int IdTienda
        {
            get { return _IdTienda; }
            set { _IdTienda = value; }
        }

        #endregion

        #region "Eventos"

        public frmManInventarioVisualModuloEdit()
        {
            InitializeComponent();
        }

        private void frmManInventarioVisualModuloEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            cboTienda.EditValue = IdTienda;
            BSUtils.LoaderLook(cboBloque, new InventarioVisualBloqueBL().ListaTodosActivoTienda(IdTienda), "DescBloque", "IdInventarioVisualBloque", true);
            cboBloque.EditValue = IdInventarioVisualBloque;
            

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "InventarioVisualModulo - Nuevo";
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "InventarioVisualModulo - Modificar";
                cboTienda.EditValue = pInventarioVisualModuloBE.IdTienda;
                cboBloque.EditValue = pInventarioVisualModuloBE.IdInventarioVisualBloque;
                txtDescripcion.Text = pInventarioVisualModuloBE.DescModulo;
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
                    InventarioVisualModuloBL objBL_InventarioVisualModulo = new InventarioVisualModuloBL();

                    InventarioVisualModuloBE objInventarioVisualModulo = new InventarioVisualModuloBE();
                    objInventarioVisualModulo.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objInventarioVisualModulo.IdInventarioVisualBloque = Convert.ToInt32(cboBloque.EditValue);
                    objInventarioVisualModulo.IdInventarioVisualModulo = IdInventarioVisualModulo;
                    objInventarioVisualModulo.DescModulo = txtDescripcion.Text;
                    objInventarioVisualModulo.FlagEstado = true;
                    //objInventarioVisualModulo.Usuario = Parametros.strUsuarioLogin;
                    //objInventarioVisualModulo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    //objInventarioVisualModulo.IdEmpresa = Parametros.intEmpresaId;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_InventarioVisualModulo.Inserta(objInventarioVisualModulo);
                    else
                        objBL_InventarioVisualModulo.Actualiza(objInventarioVisualModulo);

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

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboBloque, new InventarioVisualBloqueBL().ListaTodosActivoTienda(Convert.ToInt32(cboTienda.EditValue)), "DescBloque", "IdInventarioVisualBloque", true);
        }

        #endregion

        #region "Metodos"

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";
            
            if (string.IsNullOrEmpty(cboTienda.Text))
            {
                strMensaje = strMensaje + "- Seleccionar una Tienda.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(cboBloque.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un Bloque.\n";
                flag = true;
            }

            if (txtDescripcion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la descripción.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstInventarioVisualModulo.Where(oB => oB.DescModulo.ToUpper() == txtDescripcion.Text.ToUpper()).ToList();
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