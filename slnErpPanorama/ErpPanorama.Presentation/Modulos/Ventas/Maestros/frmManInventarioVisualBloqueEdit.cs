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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManInventarioVisualBloqueEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<InventarioVisualBloqueBE> lstInventarioVisualBloque;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public InventarioVisualBloqueBE pInventarioVisualBloqueBE { get; set; }

        int _IdInventarioVisualBloque = 0;

        public int IdInventarioVisualBloque
        {
            get { return _IdInventarioVisualBloque; }
            set { _IdInventarioVisualBloque = value; }
        }

        #endregion

        #region "Eventos"

        public frmManInventarioVisualBloqueEdit()
        {
            InitializeComponent();
        }

        private void frmManInventarioVisualBloqueEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);
            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Bloque- Nuevo";

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Bloque - Modificar";
                cboTienda.EditValue = pInventarioVisualBloqueBE.IdTienda;
                txtBloque.EditValue = pInventarioVisualBloqueBE.DescBloque;
            }

            txtBloque.Select();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    InventarioVisualBloqueBE objInventarioVisualBloque = new InventarioVisualBloqueBE();
                    InventarioVisualBloqueBL objBL_InventarioVisualBloque = new InventarioVisualBloqueBL();

                    objInventarioVisualBloque.IdInventarioVisualBloque = IdInventarioVisualBloque;
                    objInventarioVisualBloque.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    objInventarioVisualBloque.DescBloque = txtBloque.Text.Trim();
                    objInventarioVisualBloque.FlagEstado = true;

                    if (pOperacion == Operacion.Nuevo)
                        objBL_InventarioVisualBloque.Inserta(objInventarioVisualBloque);
                    else
                        objBL_InventarioVisualBloque.Actualiza(objInventarioVisualBloque);

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

        private void cboTienda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtBloque_KeyPress(object sender, KeyPressEventArgs e)
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


            if (cboTienda.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar Tienda.\n";
                flag = true;
            }

            if (txtBloque.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese BLoque.\n";
                flag = true;
            }

            if (pOperacion == Operacion.Nuevo)
            {
                var Buscar = lstInventarioVisualBloque.Where(oB => oB.IdTienda == Convert.ToInt32(cboTienda.EditValue)  && oB.DescBloque == Convert.ToString(txtBloque.Text.Trim())).ToList();
                if (Buscar.Count > 0)
                {
                    strMensaje = strMensaje + "- BLoque ya existe.\n";
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