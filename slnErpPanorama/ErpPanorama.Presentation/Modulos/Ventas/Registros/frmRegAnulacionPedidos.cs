using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using System.Security.Principal;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegAnulacionPedidos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        
        #endregion

        #region "Eventos"

        public frmRegAnulacionPedidos()
        {
            InitializeComponent();
        }

        private void frmRegAnulacionPedidos_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            txtNumero.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMotivo.Text.Trim().Length < 2)
                {
                    XtraMessageBox.Show("Ingresar el motivo de anulación del Pedido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMotivo.Focus();
                    return;
                }

                PedidoBE objE_Pedido = null;
                objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumero.Text.Trim());
                if (objE_Pedido == null)
                {
                    XtraMessageBox.Show("El pedido de venta no existe, por favor verifique", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (objE_Pedido.IdSituacion == Parametros.intPVAnulado)
                {
                    XtraMessageBox.Show("El pedido ya está anulado por favor, verifique si el número ingresado es correcto.\n" + objE_Pedido.DescCliente +"\n"+ objE_Pedido.Observacion, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (XtraMessageBox.Show("Esta seguro de eliminar el Pedido de venta N° " + txtNumero.Text.Trim() + " de: " + objE_Pedido.DescCliente + "\nTipo de Cliente: " + objE_Pedido.DescTipoCliente + "\nForma Pago: " + objE_Pedido.DescFormaPago + "\nFecha: " + objE_Pedido.Fecha.ToShortDateString() + "\nTotal: " + objE_Pedido.CodMoneda + objE_Pedido.Total + "\nTienda: " + objE_Pedido.DescTienda + "\nVendedor: " + objE_Pedido.DescVendedor, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    List<DocumentoVentaBE> lstDocumentoVenta = new List<DocumentoVentaBE>();
                    lstDocumentoVenta = new DocumentoVentaBL().SeleccionaPedido(objE_Pedido.IdPedido);

                    string CadenaMsg = "";
                    foreach (DocumentoVentaBE item in lstDocumentoVenta)
                    {
                        CadenaMsg += item.CodTipoDocumento +"  "+ item.Serie + "-" + item.Numero + "\n";
                    }

                    if(lstDocumentoVenta.Count() > 0)
                    {
                        XtraMessageBox.Show("El pedido No se puede Anular, Tiene comprobantes asociados de:\n"+ lstDocumentoVenta[0].RazonSocial +":\n" + CadenaMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    PedidoBL objBL_Pedido = new PedidoBL();
                    objE_Pedido.Usuario = Parametros.strUsuarioLogin;
                    objE_Pedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_Pedido.Observacion = txtMotivo.Text.Trim();

                    objBL_Pedido.Elimina(objE_Pedido);
                    XtraMessageBox.Show("El pedido de venta se anuló correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNumero.Text = "";
                    txtMotivo.Text = string.Empty;
                }

            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                txtMotivo.Focus();
            }
            
        }

        #region "Metodos"

        #endregion

        
    }
}