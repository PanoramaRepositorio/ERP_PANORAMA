using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    public partial class frmRegAsignarDespachadorPedido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        #endregion

        #region "Eventos"

        public frmRegAsignarDespachadorPedido()
        {
            InitializeComponent();
        }

        private void frmRegAsignarDespachadorPedido_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaAuxiliar(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            //cboVendedor.Focus();
            txtCodigo.Select();
            txtCodigo.SelectAll();
            //txtCodigo.Focus();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (!ValidarIngreso())
                {
                    MovimientoPedidoBL objBL_MovimientoPedido = new MovimientoPedidoBL();

                    if (chkChequeo.Checked)
                    {
                        MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();

                        PedidoBL objBL_Pedido = new PedidoBL();
                        objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Parametros.intEnChequeo, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());

                        //Chequeador
                        objE_MovimientoPedido.IdPedido = IdPedido;
                        objE_MovimientoPedido.IdChequeador = Convert.ToInt32(cboVendedor.EditValue);
                        objBL_MovimientoPedido.ActualizaChequeador(objE_MovimientoPedido);

                        //Cierre chequeo
                        objE_MovimientoPedido.IdPedido = IdPedido;
                        objE_MovimientoPedido.Chequeado = true;
                        objBL_MovimientoPedido.ActualizaCierreChequeado(objE_MovimientoPedido);
                    }

                    if (chkEmbalaje.Checked)
                    {
                        MovimientoPedidoBE objE_MovimientoPedido = new MovimientoPedidoBE();

                        //Inicio de embalaje
                        objE_MovimientoPedido.IdPedido = IdPedido;
                        objE_MovimientoPedido.IdEmbalador = Convert.ToInt32(cboVendedor.EditValue);
                        objE_MovimientoPedido.Embalado = true;
                        objE_MovimientoPedido.FlagCierre = false;
                        objE_MovimientoPedido.CantidadBulto = Convert.ToInt32(txtBultos.EditValue);
                        objBL_MovimientoPedido.ActualizaCierreEmbalaje2(objE_MovimientoPedido);

                        //Cierre de embalaje
                        objE_MovimientoPedido.IdPedido = IdPedido;
                        objE_MovimientoPedido.IdEmbalador = Convert.ToInt32(cboVendedor.EditValue);
                        objE_MovimientoPedido.Embalado = true;
                        objE_MovimientoPedido.FlagCierre = true;
                        objE_MovimientoPedido.CantidadBulto = Convert.ToInt32(txtBultos.EditValue);
                        objBL_MovimientoPedido.ActualizaCierreEmbalaje2(objE_MovimientoPedido);
                    }

                    if (chkDespachado.Checked)
                    {
                        PedidoBL objBL_Pedido = new PedidoBL();
                        PedidoBE objE_Pedido = new PedidoBE();

                        MovimientoPedidoBE objMovimientoPedido = new MovimientoPedidoBE();
                        objE_Pedido = objBL_Pedido.Selecciona(IdPedido);
                        if (objE_Pedido.IdSituacion == Parametros.intFacturado)
                        {
                            objMovimientoPedido.IdPedido = IdPedido;
                            objMovimientoPedido.CantidadBulto = Convert.ToInt32(txtBultos.Text);
                            objMovimientoPedido.IdDespachador = Convert.ToInt32(cboVendedor.EditValue);

                            objBL_MovimientoPedido.ActualizaOrigenDespacho(IdPedido, "Despacho");
                            objBL_MovimientoPedido.ActualizaDespachador(objMovimientoPedido);
                            objBL_Pedido.ActualizaSituacionAlmacen(Parametros.intIdPanoramaDistribuidores, IdPedido, Parametros.intEnAlmacenDespacho, Parametros.strUsuarioLogin, WindowsIdentity.GetCurrent().Name.ToString());

                        }
                        else
                        {
                            XtraMessageBox.Show("No se puede despachar, Por favor verifique si el pedido se encuentra en estado FACTURADO.",this.Text);
                        }
                    }

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

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txtCodigo.Text.Trim().Length > 0)
                {
                    cboVendedor.EditValue = Convert.ToInt32(txtCodigo.Text.Trim());
                    btnGrabar.Focus();
                }
            }
        }


        #region "Metodos"
        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (cboVendedor.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar Personal.\n";
                flag = true;
            }

            if (chkEmbalaje.Checked)
            {
                if (Convert.ToInt32(txtBultos.EditValue) == 0)
                {
                    strMensaje = strMensaje + "- Ingresar la cantidad de bultos.\n";
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

        private void chkDespachado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDespachado.Checked)
            {
                chkChequeo.Checked = true;
                chkEmbalaje.Checked = true;
                chkChequeo.Enabled = false;
                chkEmbalaje.Enabled = false;
            }
            else
            {
                chkChequeo.Checked = false;
                chkEmbalaje.Checked = false;
                chkChequeo.Enabled = true;
                chkEmbalaje.Enabled = true;
            }
        }

        private void chkChequeo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkEmbalaje_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEmbalaje.Checked)
            {
                chkChequeo.Checked = true;
                chkChequeo.Enabled = false;
            }
            else
            {
                chkChequeo.Checked = false;
                chkChequeo.Enabled = true;
            }
        }
    }
}