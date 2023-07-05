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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManActualizaMinorista : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private int IdCliente = 0;
        
        #endregion

        #region "Eventos"

        public frmManActualizaMinorista()
        {
            InitializeComponent();
        }

        private void frmManActualizaMinorista_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboClasificacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblClasificacionClienteFinal), "DescTablaElemento", "IdTablaElemento", true);
            cboClasificacion.EditValue = Parametros.intClasico;
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClienteBE objE_Cliente = null;
                objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                if (objE_Cliente != null)
                {
                    IdCliente = objE_Cliente.IdCliente;
                    txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                    txtDescCliente.Text = objE_Cliente.DescCliente;
                    txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;
                }
                else
                {
                    XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "-" + frm.pClienteBE.DescClasificacionCliente;

                    cboClasificacion.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarIngreso())
                {
                    if (XtraMessageBox.Show("Esta seguro(a) de cambiar al cliente a Mayorista?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ClienteBL objBL_Cliente = new ClienteBL();
                        ClienteBE objE_Cliente = new ClienteBE();
                        objE_Cliente.IdCliente = IdCliente;
                        objE_Cliente.IdClasificacionCliente = Convert.ToInt32(cboClasificacion.EditValue);
                        objE_Cliente.Usuario = Parametros.strUsuarioLogin;
                        objE_Cliente.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Cliente.IdEmpresa = Parametros.intEmpresaId;
                        objBL_Cliente.ActualizaMinorista(objE_Cliente);
                    }

                    XtraMessageBox.Show("El cliente se actualizó a mayorista", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTextos();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboClasificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                btnGrabar.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        #region "Metodos"

        private void LimpiarTextos()
        {
            IdCliente = 0;
            txtNumeroDocumento.Text = "";
            txtDescCliente.Text = "";
            txtTipoCliente.Text = "";

            btnBuscar.Focus();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (IdCliente == 0)
            {
                strMensaje = strMensaje + "- Seleccionar un cliente válido.\n";
                flag = true;
            }

            if (txtNumeroDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar el número de documento.\n";
                flag = true;
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