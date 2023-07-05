using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmBusPedido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        int _IdPedido = 0;

        public int IdPedido
        {
            get { return _IdPedido; }
            set { _IdPedido = value; }
        }

        int _IdDocumentoVenta = 0;

        public int IdDocumentoVenta
        {
            get { return _IdDocumentoVenta; }
            set { _IdDocumentoVenta = value; }
        }

        public PedidoBE pPedidoBE { get; set; }


        #endregion

        #region "Eventos"

        public frmBusPedido()
        {
            InitializeComponent();
        }

        private void frmBusPedido_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            txtNumeroPedido.Select();
            txtNumeroPedido.Focus();
            
        }

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNumeroPedido.Text.Trim().Length > 1)
                {
                    PedidoBE objE_Pedido = null;
                    //objE_Pedido = new PedidoBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroPedido.Text.Trim());
                    pPedidoBE = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.EditValue), txtNumeroPedido.Text.Trim());
                    if (pPedidoBE != null)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("El Número de pedido no existe y/o está anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    //if (objE_Pedido != null)
                    //{
                    //    IdPedido = objE_Pedido.IdPedido;
                    //    DocumentoVentaBL objBL_Documento = new DocumentoVentaBL();
                    //    objBL_Documento.ActualizaVinculoPedido(IdDocumentoVenta, IdPedido);
                    //    XtraMessageBox.Show("Documento vinculado correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    this.Close();
                    //}
                    //else
                    //{
                    //    XtraMessageBox.Show("El Número de pedido no existe y/o anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                    
                }
            }
        }
        #endregion
    }
}