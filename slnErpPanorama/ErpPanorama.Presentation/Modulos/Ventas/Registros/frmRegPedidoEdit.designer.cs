using System;
using System.Windows.Forms;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class frmRegPedidoEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPedidoEdit));
            this.gcTxtCodigo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.btn_Mayorista = new System.Windows.Forms.Button();
            this.chkIngresoMayorista = new System.Windows.Forms.CheckBox();
            this.btnKiraEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnKira2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnKira1 = new DevExpress.XtraEditors.SimpleButton();
            this.lblTotalSinDscCumple = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalSinDscCumple = new DevExpress.XtraEditors.TextEdit();
            this.chkPtFlores = new DevExpress.XtraEditors.CheckEdit();
            this.txtTotNavidad = new DevExpress.XtraEditors.TextEdit();
            this.lblTotNavidad = new DevExpress.XtraEditors.LabelControl();
            this.txtTotReligioso = new DevExpress.XtraEditors.TextEdit();
            this.lblTotReligioso = new DevExpress.XtraEditors.LabelControl();
            this.txtTotRegular = new DevExpress.XtraEditors.TextEdit();
            this.lblTotRegular = new DevExpress.XtraEditors.LabelControl();
            this.lblDsctoCumple = new DevExpress.XtraEditors.LabelControl();
            this.txtDsctoCumple = new DevExpress.XtraEditors.TextEdit();
            this.txtICBPER = new DevExpress.XtraEditors.TextEdit();
            this.labelControl29 = new DevExpress.XtraEditors.LabelControl();
            this.bntVerNS = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargarVale = new DevExpress.XtraEditors.SimpleButton();
            this.btnEliminarDsctoVale = new System.Windows.Forms.Button();
            this.btnEliminarVale = new System.Windows.Forms.Button();
            this.chkVale = new DevExpress.XtraEditors.CheckEdit();
            this.btnClientePromocion = new DevExpress.XtraEditors.SimpleButton();
            this.cboClientePromocion = new DevExpress.XtraEditors.LookUpEdit();
            this.btnEliminarEncuesta = new DevExpress.XtraEditors.SimpleButton();
            this.gcDiseñador = new DevExpress.XtraEditors.GroupControl();
            this.btnBuscarDiseñador = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombreDiseñador = new DevExpress.XtraEditors.TextEdit();
            this.txtDniDiseñador = new DevExpress.XtraEditors.TextEdit();
            this.chkCompraPerfecta = new DevExpress.XtraEditors.CheckEdit();
            this.btnEliminarCumpleanios = new DevExpress.XtraEditors.SimpleButton();
            this.btnPromocion = new DevExpress.XtraEditors.SimpleButton();
            this.chkDescuentoExtraVenta = new DevExpress.XtraEditors.CheckEdit();
            this.grdDatosFacturacion = new DevExpress.XtraEditors.GroupControl();
            this.cboClienteAsociado = new DevExpress.XtraEditors.LookUpEdit();
            this.lblFacturara = new DevExpress.XtraEditors.LabelControl();
            this.txtDireccionAsociado = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumentoAsociado = new DevExpress.XtraEditors.TextEdit();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.cboAsesor = new DevExpress.XtraEditors.LookUpEdit();
            this.lblAsesor = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoDocumentoBusqueda = new DevExpress.XtraEditors.LookUpEdit();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTipoVenta = new DevExpress.XtraEditors.LookUpEdit();
            this.btnClienteAsociado = new DevExpress.XtraEditors.SimpleButton();
            this.cboCombo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.txtTipoCliente = new DevExpress.XtraEditors.TextEdit();
            this.deFechaVencimiento = new DevExpress.XtraEditors.DateEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalCantidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtSubTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalBruto = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalDscto2x1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.txtImpuesto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.lblIdPedido = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.txtObservaciones = new DevExpress.XtraEditors.MemoEdit();
            this.txtNumeroProforma = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.cboCaja = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.cboVendedor = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.gcPedidoDetalle = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarprecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.establecerdescuentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descuentocupontoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.establecerpreciopublicitariotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.establecerdescuentocerotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarpromocion2x1toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.utilizarprecioucayalitoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvPedidoDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPorcentajeDescuento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLineaProducto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnNuevoCliente = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDireccion = new DevExpress.XtraEditors.TextEdit();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtTipoCambio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboFormaPago = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.txtTotal2x1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescuento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl26 = new DevExpress.XtraEditors.LabelControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.chkPreventa = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.bsListado = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuSelText = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNumeroPedido = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.lblMensaje = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtSaldoDisponible = new DevExpress.XtraEditors.TextEdit();
            this.gcSaldoDisponible = new DevExpress.XtraEditors.GroupControl();
            this.btnDelivery = new DevExpress.XtraEditors.SimpleButton();
            this.lblMensajePedido = new DevExpress.XtraEditors.LabelControl();
            this.panelPreventa = new System.Windows.Forms.Panel();
            this.btnEnviarAlmacen = new DevExpress.XtraEditors.SimpleButton();
            this.txtNumeroContrato = new DevExpress.XtraEditors.TextEdit();
            this.btnInstalacion = new DevExpress.XtraEditors.SimpleButton();
            this.btnDescuentoValeMarca = new DevExpress.XtraEditors.SimpleButton();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.txtMP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalSinDscCumple.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPtFlores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotNavidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotReligioso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotRegular.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDsctoCumple.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtICBPER.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClientePromocion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiseñador)).BeginInit();
            this.gcDiseñador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreDiseñador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDniDiseñador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompraPerfecta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDescuentoExtraVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatosFacturacion)).BeginInit();
            this.grdDatosFacturacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboClienteAsociado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccionAsociado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumentoAsociado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAsesor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumentoBusqueda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCombo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaVencimiento.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaVencimiento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBruto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDscto2x1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpuesto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroProforma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPedidoDetalle)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPedidoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal2x1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreventa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPedido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoDisponible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSaldoDisponible)).BeginInit();
            this.gcSaldoDisponible.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroContrato.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMP.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTxtCodigo
            // 
            this.gcTxtCodigo.AutoHeight = false;
            this.gcTxtCodigo.Name = "gcTxtCodigo";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1066, 530);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.btn_Mayorista);
            this.xtraTabPage1.Controls.Add(this.chkIngresoMayorista);
            this.xtraTabPage1.Controls.Add(this.btnKiraEliminar);
            this.xtraTabPage1.Controls.Add(this.btnKira2);
            this.xtraTabPage1.Controls.Add(this.btnKira1);
            this.xtraTabPage1.Controls.Add(this.lblTotalSinDscCumple);
            this.xtraTabPage1.Controls.Add(this.txtTotalSinDscCumple);
            this.xtraTabPage1.Controls.Add(this.chkPtFlores);
            this.xtraTabPage1.Controls.Add(this.txtTotNavidad);
            this.xtraTabPage1.Controls.Add(this.lblTotNavidad);
            this.xtraTabPage1.Controls.Add(this.txtTotReligioso);
            this.xtraTabPage1.Controls.Add(this.lblTotReligioso);
            this.xtraTabPage1.Controls.Add(this.txtTotRegular);
            this.xtraTabPage1.Controls.Add(this.lblTotRegular);
            this.xtraTabPage1.Controls.Add(this.lblDsctoCumple);
            this.xtraTabPage1.Controls.Add(this.txtDsctoCumple);
            this.xtraTabPage1.Controls.Add(this.txtICBPER);
            this.xtraTabPage1.Controls.Add(this.labelControl29);
            this.xtraTabPage1.Controls.Add(this.bntVerNS);
            this.xtraTabPage1.Controls.Add(this.btnCargarVale);
            this.xtraTabPage1.Controls.Add(this.btnEliminarDsctoVale);
            this.xtraTabPage1.Controls.Add(this.btnEliminarVale);
            this.xtraTabPage1.Controls.Add(this.chkVale);
            this.xtraTabPage1.Controls.Add(this.btnClientePromocion);
            this.xtraTabPage1.Controls.Add(this.cboClientePromocion);
            this.xtraTabPage1.Controls.Add(this.btnEliminarEncuesta);
            this.xtraTabPage1.Controls.Add(this.gcDiseñador);
            this.xtraTabPage1.Controls.Add(this.chkCompraPerfecta);
            this.xtraTabPage1.Controls.Add(this.btnEliminarCumpleanios);
            this.xtraTabPage1.Controls.Add(this.btnPromocion);
            this.xtraTabPage1.Controls.Add(this.chkDescuentoExtraVenta);
            this.xtraTabPage1.Controls.Add(this.grdDatosFacturacion);
            this.xtraTabPage1.Controls.Add(this.labelControl23);
            this.xtraTabPage1.Controls.Add(this.cboAsesor);
            this.xtraTabPage1.Controls.Add(this.lblAsesor);
            this.xtraTabPage1.Controls.Add(this.cboTipoDocumentoBusqueda);
            this.xtraTabPage1.Controls.Add(this.cboMotivo);
            this.xtraTabPage1.Controls.Add(this.cboTipoVenta);
            this.xtraTabPage1.Controls.Add(this.btnClienteAsociado);
            this.xtraTabPage1.Controls.Add(this.cboCombo);
            this.xtraTabPage1.Controls.Add(this.labelControl19);
            this.xtraTabPage1.Controls.Add(this.btnEditar);
            this.xtraTabPage1.Controls.Add(this.btnEliminar);
            this.xtraTabPage1.Controls.Add(this.btnNuevo);
            this.xtraTabPage1.Controls.Add(this.txtTipoCliente);
            this.xtraTabPage1.Controls.Add(this.deFechaVencimiento);
            this.xtraTabPage1.Controls.Add(this.labelControl16);
            this.xtraTabPage1.Controls.Add(this.txtTotalCantidad);
            this.xtraTabPage1.Controls.Add(this.labelControl18);
            this.xtraTabPage1.Controls.Add(this.txtSubTotal);
            this.xtraTabPage1.Controls.Add(this.labelControl14);
            this.xtraTabPage1.Controls.Add(this.txtTotalBruto);
            this.xtraTabPage1.Controls.Add(this.txtTotalDscto2x1);
            this.xtraTabPage1.Controls.Add(this.labelControl24);
            this.xtraTabPage1.Controls.Add(this.txtTotal);
            this.xtraTabPage1.Controls.Add(this.labelControl25);
            this.xtraTabPage1.Controls.Add(this.labelControl10);
            this.xtraTabPage1.Controls.Add(this.txtImpuesto);
            this.xtraTabPage1.Controls.Add(this.labelControl9);
            this.xtraTabPage1.Controls.Add(this.lblIdPedido);
            this.xtraTabPage1.Controls.Add(this.labelControl20);
            this.xtraTabPage1.Controls.Add(this.txtObservaciones);
            this.xtraTabPage1.Controls.Add(this.txtNumeroProforma);
            this.xtraTabPage1.Controls.Add(this.labelControl15);
            this.xtraTabPage1.Controls.Add(this.labelControl21);
            this.xtraTabPage1.Controls.Add(this.cboCaja);
            this.xtraTabPage1.Controls.Add(this.labelControl22);
            this.xtraTabPage1.Controls.Add(this.labelControl13);
            this.xtraTabPage1.Controls.Add(this.cboVendedor);
            this.xtraTabPage1.Controls.Add(this.labelControl12);
            this.xtraTabPage1.Controls.Add(this.txtNumero);
            this.xtraTabPage1.Controls.Add(this.labelControl11);
            this.xtraTabPage1.Controls.Add(this.cboEmpresa);
            this.xtraTabPage1.Controls.Add(this.labelControl8);
            this.xtraTabPage1.Controls.Add(this.gcPedidoDetalle);
            this.xtraTabPage1.Controls.Add(this.btnNuevoCliente);
            this.xtraTabPage1.Controls.Add(this.btnBuscar);
            this.xtraTabPage1.Controls.Add(this.txtDireccion);
            this.xtraTabPage1.Controls.Add(this.txtDescCliente);
            this.xtraTabPage1.Controls.Add(this.txtNumeroDocumento);
            this.xtraTabPage1.Controls.Add(this.labelControl5);
            this.xtraTabPage1.Controls.Add(this.txtTipoCambio);
            this.xtraTabPage1.Controls.Add(this.labelControl3);
            this.xtraTabPage1.Controls.Add(this.cboMoneda);
            this.xtraTabPage1.Controls.Add(this.labelControl2);
            this.xtraTabPage1.Controls.Add(this.cboFormaPago);
            this.xtraTabPage1.Controls.Add(this.labelControl1);
            this.xtraTabPage1.Controls.Add(this.deFecha);
            this.xtraTabPage1.Controls.Add(this.labelControl4);
            this.xtraTabPage1.Controls.Add(this.cboDocumento);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1064, 505);
            this.xtraTabPage1.Text = "Pedido de Venta";
            // 
            // btn_Mayorista
            // 
            this.btn_Mayorista.BackColor = System.Drawing.Color.LimeGreen;
            this.btn_Mayorista.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btn_Mayorista.ForeColor = System.Drawing.Color.White;
            this.btn_Mayorista.Image = global::ErpPanorama.Presentation.Properties.Resources.SolicitudDevolucion_16x161;
            this.btn_Mayorista.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Mayorista.Location = new System.Drawing.Point(414, 123);
            this.btn_Mayorista.Name = "btn_Mayorista";
            this.btn_Mayorista.Size = new System.Drawing.Size(86, 27);
            this.btn_Mayorista.TabIndex = 148;
            this.btn_Mayorista.Text = "Mayorista";
            this.btn_Mayorista.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Mayorista.UseVisualStyleBackColor = false;
            this.btn_Mayorista.Visible = false;
            // 
            // chkIngresoMayorista
            // 
            this.chkIngresoMayorista.AutoSize = true;
            this.chkIngresoMayorista.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkIngresoMayorista.ForeColor = System.Drawing.Color.Blue;
            this.chkIngresoMayorista.Location = new System.Drawing.Point(302, 128);
            this.chkIngresoMayorista.Name = "chkIngresoMayorista";
            this.chkIngresoMayorista.Size = new System.Drawing.Size(109, 17);
            this.chkIngresoMayorista.TabIndex = 147;
            this.chkIngresoMayorista.Text = "Ingreso rápido";
            this.chkIngresoMayorista.UseVisualStyleBackColor = true;
            this.chkIngresoMayorista.Visible = false;
            // 
            // btnKiraEliminar
            // 
            this.btnKiraEliminar.AllowFocus = false;
            this.btnKiraEliminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKiraEliminar.ImageOptions.Image")));
            this.btnKiraEliminar.ImageOptions.ImageIndex = 1;
            this.btnKiraEliminar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnKiraEliminar.Location = new System.Drawing.Point(465, 129);
            this.btnKiraEliminar.Name = "btnKiraEliminar";
            this.btnKiraEliminar.Size = new System.Drawing.Size(131, 23);
            this.btnKiraEliminar.TabIndex = 146;
            this.btnKiraEliminar.Text = "Eliminar Promo Kira";
            this.btnKiraEliminar.Visible = false;
            // 
            // btnKira2
            // 
            this.btnKira2.AllowFocus = false;
            this.btnKira2.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.GiftCard_16x1611;
            this.btnKira2.ImageOptions.ImageIndex = 1;
            this.btnKira2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnKira2.Location = new System.Drawing.Point(724, 129);
            this.btnKira2.Name = "btnKira2";
            this.btnKira2.Size = new System.Drawing.Size(123, 23);
            this.btnKira2.TabIndex = 145;
            this.btnKira2.Text = "KIRA-COJ-PERU-2";
            this.btnKira2.Visible = false;
            // 
            // btnKira1
            // 
            this.btnKira1.AllowFocus = false;
            this.btnKira1.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.GiftCard_16x161;
            this.btnKira1.ImageOptions.ImageIndex = 1;
            this.btnKira1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnKira1.Location = new System.Drawing.Point(597, 129);
            this.btnKira1.Name = "btnKira1";
            this.btnKira1.Size = new System.Drawing.Size(123, 23);
            this.btnKira1.TabIndex = 144;
            this.btnKira1.Text = "KIRA-COJ-PERU-1";
            this.btnKira1.Visible = false;
            // 
            // lblTotalSinDscCumple
            // 
            this.lblTotalSinDscCumple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalSinDscCumple.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalSinDscCumple.Appearance.Options.UseFont = true;
            this.lblTotalSinDscCumple.Location = new System.Drawing.Point(823, 430);
            this.lblTotalSinDscCumple.Name = "lblTotalSinDscCumple";
            this.lblTotalSinDscCumple.Size = new System.Drawing.Size(153, 13);
            this.lblTotalSinDscCumple.TabIndex = 143;
            this.lblTotalSinDscCumple.Text = "Total SinDsctoCumpleaños:";
            // 
            // txtTotalSinDscCumple
            // 
            this.txtTotalSinDscCumple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalSinDscCumple.EditValue = "0.00";
            this.txtTotalSinDscCumple.Location = new System.Drawing.Point(981, 426);
            this.txtTotalSinDscCumple.Name = "txtTotalSinDscCumple";
            this.txtTotalSinDscCumple.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalSinDscCumple.Properties.Appearance.Options.UseFont = true;
            this.txtTotalSinDscCumple.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalSinDscCumple.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalSinDscCumple.Properties.Mask.EditMask = "n";
            this.txtTotalSinDscCumple.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalSinDscCumple.Properties.ReadOnly = true;
            this.txtTotalSinDscCumple.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalSinDscCumple.Size = new System.Drawing.Size(75, 20);
            this.txtTotalSinDscCumple.TabIndex = 142;
            // 
            // chkPtFlores
            // 
            this.chkPtFlores.Location = new System.Drawing.Point(237, 126);
            this.chkPtFlores.Name = "chkPtFlores";
            this.chkPtFlores.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkPtFlores.Properties.Appearance.ForeColor = System.Drawing.Color.OliveDrab;
            this.chkPtFlores.Properties.Appearance.Options.UseFont = true;
            this.chkPtFlores.Properties.Appearance.Options.UseForeColor = true;
            this.chkPtFlores.Properties.Caption = "Arreglo Flores Personalizado";
            this.chkPtFlores.Size = new System.Drawing.Size(191, 20);
            this.chkPtFlores.TabIndex = 141;
            // 
            // txtTotNavidad
            // 
            this.txtTotNavidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotNavidad.EditValue = "0.00";
            this.txtTotNavidad.Location = new System.Drawing.Point(478, 478);
            this.txtTotNavidad.Name = "txtTotNavidad";
            this.txtTotNavidad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotNavidad.Properties.Appearance.ForeColor = System.Drawing.Color.Green;
            this.txtTotNavidad.Properties.Appearance.Options.UseFont = true;
            this.txtTotNavidad.Properties.Appearance.Options.UseForeColor = true;
            this.txtTotNavidad.Properties.DisplayFormat.FormatString = "n";
            this.txtTotNavidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotNavidad.Properties.Mask.EditMask = "n";
            this.txtTotNavidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotNavidad.Properties.ReadOnly = true;
            this.txtTotNavidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotNavidad.Size = new System.Drawing.Size(75, 20);
            this.txtTotNavidad.TabIndex = 140;
            this.txtTotNavidad.Visible = false;
            // 
            // lblTotNavidad
            // 
            this.lblTotNavidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotNavidad.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotNavidad.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblTotNavidad.Appearance.Options.UseFont = true;
            this.lblTotNavidad.Appearance.Options.UseForeColor = true;
            this.lblTotNavidad.Location = new System.Drawing.Point(396, 482);
            this.lblTotNavidad.Name = "lblTotNavidad";
            this.lblTotNavidad.Size = new System.Drawing.Size(77, 13);
            this.lblTotNavidad.TabIndex = 139;
            this.lblTotNavidad.Text = "TotalNavidad:";
            this.lblTotNavidad.Visible = false;
            // 
            // txtTotReligioso
            // 
            this.txtTotReligioso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotReligioso.EditValue = "0.00";
            this.txtTotReligioso.Location = new System.Drawing.Point(289, 478);
            this.txtTotReligioso.Name = "txtTotReligioso";
            this.txtTotReligioso.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotReligioso.Properties.Appearance.ForeColor = System.Drawing.Color.Green;
            this.txtTotReligioso.Properties.Appearance.Options.UseFont = true;
            this.txtTotReligioso.Properties.Appearance.Options.UseForeColor = true;
            this.txtTotReligioso.Properties.DisplayFormat.FormatString = "n";
            this.txtTotReligioso.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotReligioso.Properties.Mask.EditMask = "n";
            this.txtTotReligioso.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotReligioso.Properties.ReadOnly = true;
            this.txtTotReligioso.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotReligioso.Size = new System.Drawing.Size(75, 20);
            this.txtTotReligioso.TabIndex = 138;
            this.txtTotReligioso.Visible = false;
            // 
            // lblTotReligioso
            // 
            this.lblTotReligioso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotReligioso.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotReligioso.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblTotReligioso.Appearance.Options.UseFont = true;
            this.lblTotReligioso.Appearance.Options.UseForeColor = true;
            this.lblTotReligioso.Location = new System.Drawing.Point(204, 482);
            this.lblTotReligioso.Name = "lblTotReligioso";
            this.lblTotReligioso.Size = new System.Drawing.Size(83, 13);
            this.lblTotReligioso.TabIndex = 137;
            this.lblTotReligioso.Text = "TotalReligioso:";
            this.lblTotReligioso.Visible = false;
            // 
            // txtTotRegular
            // 
            this.txtTotRegular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotRegular.EditValue = "0.00";
            this.txtTotRegular.Location = new System.Drawing.Point(87, 478);
            this.txtTotRegular.Name = "txtTotRegular";
            this.txtTotRegular.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.txtTotRegular.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.txtTotRegular.Properties.Appearance.ForeColor = System.Drawing.Color.Green;
            this.txtTotRegular.Properties.Appearance.Options.UseBackColor = true;
            this.txtTotRegular.Properties.Appearance.Options.UseFont = true;
            this.txtTotRegular.Properties.Appearance.Options.UseForeColor = true;
            this.txtTotRegular.Properties.DisplayFormat.FormatString = "n";
            this.txtTotRegular.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotRegular.Properties.Mask.EditMask = "n";
            this.txtTotRegular.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotRegular.Properties.ReadOnly = true;
            this.txtTotRegular.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotRegular.Size = new System.Drawing.Size(75, 20);
            this.txtTotRegular.TabIndex = 136;
            this.txtTotRegular.Visible = false;
            // 
            // lblTotRegular
            // 
            this.lblTotRegular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotRegular.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotRegular.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblTotRegular.Appearance.Options.UseFont = true;
            this.lblTotRegular.Appearance.Options.UseForeColor = true;
            this.lblTotRegular.Location = new System.Drawing.Point(5, 482);
            this.lblTotRegular.Name = "lblTotRegular";
            this.lblTotRegular.Size = new System.Drawing.Size(76, 13);
            this.lblTotRegular.TabIndex = 135;
            this.lblTotRegular.Text = "TotalRegular:";
            this.lblTotRegular.Visible = false;
            // 
            // lblDsctoCumple
            // 
            this.lblDsctoCumple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDsctoCumple.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblDsctoCumple.Appearance.Options.UseForeColor = true;
            this.lblDsctoCumple.Location = new System.Drawing.Point(617, 430);
            this.lblDsctoCumple.Name = "lblDsctoCumple";
            this.lblDsctoCumple.Size = new System.Drawing.Size(96, 13);
            this.lblDsctoCumple.TabIndex = 134;
            this.lblDsctoCumple.Text = "Dscto. Cumpleaños:";
            // 
            // txtDsctoCumple
            // 
            this.txtDsctoCumple.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDsctoCumple.EditValue = "0.00";
            this.txtDsctoCumple.Location = new System.Drawing.Point(715, 426);
            this.txtDsctoCumple.Name = "txtDsctoCumple";
            this.txtDsctoCumple.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtDsctoCumple.Properties.Appearance.Options.UseForeColor = true;
            this.txtDsctoCumple.Properties.DisplayFormat.FormatString = "n";
            this.txtDsctoCumple.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDsctoCumple.Properties.Mask.EditMask = "n";
            this.txtDsctoCumple.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDsctoCumple.Properties.ReadOnly = true;
            this.txtDsctoCumple.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDsctoCumple.Size = new System.Drawing.Size(75, 20);
            this.txtDsctoCumple.TabIndex = 133;
            // 
            // txtICBPER
            // 
            this.txtICBPER.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtICBPER.EditValue = "0.00";
            this.txtICBPER.Location = new System.Drawing.Point(858, 478);
            this.txtICBPER.Name = "txtICBPER";
            this.txtICBPER.Properties.DisplayFormat.FormatString = "n";
            this.txtICBPER.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtICBPER.Properties.Mask.EditMask = "n";
            this.txtICBPER.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtICBPER.Properties.ReadOnly = true;
            this.txtICBPER.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtICBPER.Size = new System.Drawing.Size(73, 20);
            this.txtICBPER.TabIndex = 132;
            // 
            // labelControl29
            // 
            this.labelControl29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl29.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl29.Appearance.Options.UseFont = true;
            this.labelControl29.Location = new System.Drawing.Point(810, 482);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(43, 13);
            this.labelControl29.TabIndex = 131;
            this.labelControl29.Text = "ICBPER:";
            // 
            // bntVerNS
            // 
            this.bntVerNS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntVerNS.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntVerNS.ImageOptions.Image")));
            this.bntVerNS.ImageOptions.ImageIndex = 1;
            this.bntVerNS.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.bntVerNS.Location = new System.Drawing.Point(373, 430);
            this.bntVerNS.Name = "bntVerNS";
            this.bntVerNS.Size = new System.Drawing.Size(75, 23);
            this.bntVerNS.TabIndex = 130;
            this.bntVerNS.Text = "Ver N/S";
            this.bntVerNS.ToolTip = "Ver Notas de Salidas";
            this.bntVerNS.Click += new System.EventHandler(this.bntVerNS_Click);
            // 
            // btnCargarVale
            // 
            this.btnCargarVale.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCargarVale.ImageOptions.Image")));
            this.btnCargarVale.Location = new System.Drawing.Point(990, 123);
            this.btnCargarVale.Name = "btnCargarVale";
            this.btnCargarVale.Size = new System.Drawing.Size(51, 23);
            this.btnCargarVale.TabIndex = 126;
            this.btnCargarVale.Text = "Vale";
            this.btnCargarVale.ToolTipTitle = "Vale de Promoción";
            this.btnCargarVale.Click += new System.EventHandler(this.btnCargarVale_Click);
            // 
            // btnEliminarDsctoVale
            // 
            this.btnEliminarDsctoVale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEliminarDsctoVale.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnEliminarDsctoVale.ForeColor = System.Drawing.Color.Red;
            this.btnEliminarDsctoVale.Location = new System.Drawing.Point(581, 133);
            this.btnEliminarDsctoVale.Name = "btnEliminarDsctoVale";
            this.btnEliminarDsctoVale.Size = new System.Drawing.Size(156, 23);
            this.btnEliminarDsctoVale.TabIndex = 129;
            this.btnEliminarDsctoVale.Text = "Eliminar +10% Dscto Vale";
            this.btnEliminarDsctoVale.UseVisualStyleBackColor = false;
            this.btnEliminarDsctoVale.Visible = false;
            this.btnEliminarDsctoVale.Click += new System.EventHandler(this.bntEliminarDsctoVale_Click);
            // 
            // btnEliminarVale
            // 
            this.btnEliminarVale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnEliminarVale.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnEliminarVale.ForeColor = System.Drawing.Color.Red;
            this.btnEliminarVale.Location = new System.Drawing.Point(423, 133);
            this.btnEliminarVale.Name = "btnEliminarVale";
            this.btnEliminarVale.Size = new System.Drawing.Size(156, 23);
            this.btnEliminarVale.TabIndex = 129;
            this.btnEliminarVale.Text = "Eliminar &Vale de S/ 50.00";
            this.btnEliminarVale.UseVisualStyleBackColor = false;
            this.btnEliminarVale.Visible = false;
            this.btnEliminarVale.Click += new System.EventHandler(this.btnEliminarVale_Click);
            // 
            // chkVale
            // 
            this.chkVale.Location = new System.Drawing.Point(347, 135);
            this.chkVale.Name = "chkVale";
            this.chkVale.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkVale.Properties.Appearance.ForeColor = System.Drawing.Color.Green;
            this.chkVale.Properties.Appearance.Options.UseFont = true;
            this.chkVale.Properties.Appearance.Options.UseForeColor = true;
            this.chkVale.Properties.Caption = "Vale S/50";
            this.chkVale.Size = new System.Drawing.Size(81, 20);
            this.chkVale.TabIndex = 126;
            this.chkVale.Visible = false;
            this.chkVale.CheckedChanged += new System.EventHandler(this.chkVale_CheckedChanged);
            // 
            // btnClientePromocion
            // 
            this.btnClientePromocion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClientePromocion.ImageOptions.Image")));
            this.btnClientePromocion.Location = new System.Drawing.Point(863, 125);
            this.btnClientePromocion.Name = "btnClientePromocion";
            this.btnClientePromocion.Size = new System.Drawing.Size(89, 20);
            this.btnClientePromocion.TabIndex = 128;
            this.btnClientePromocion.Text = "-% Afiliados";
            this.btnClientePromocion.ToolTip = "Ver promoción por Club o Campaña.";
            this.btnClientePromocion.ToolTipTitle = "Descuento por Cliente Financiero";
            this.btnClientePromocion.Click += new System.EventHandler(this.btnClientePromocion_Click);
            // 
            // cboClientePromocion
            // 
            this.cboClientePromocion.Location = new System.Drawing.Point(675, 128);
            this.cboClientePromocion.Name = "cboClientePromocion";
            this.cboClientePromocion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboClientePromocion.Properties.Appearance.ForeColor = System.Drawing.Color.Green;
            this.cboClientePromocion.Properties.Appearance.Options.UseFont = true;
            this.cboClientePromocion.Properties.Appearance.Options.UseForeColor = true;
            this.cboClientePromocion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClientePromocion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IdDescuentoClientePromocion", "IdDescuentoClientePromocion", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion", 50, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descuento", "Dscto", 20, DevExpress.Utils.FormatType.Numeric, "#,0.00", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FechaFin", "Hasta", 20, DevExpress.Utils.FormatType.DateTime, "d MMM", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Items", "Items", 15, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.cboClientePromocion.Properties.DropDownRows = 10;
            this.cboClientePromocion.Properties.NullText = "";
            this.cboClientePromocion.Size = new System.Drawing.Size(277, 20);
            this.cboClientePromocion.TabIndex = 126;
            this.cboClientePromocion.Visible = false;
            this.cboClientePromocion.EditValueChanged += new System.EventHandler(this.cboClientePromocion_EditValueChanged);
            // 
            // btnEliminarEncuesta
            // 
            this.btnEliminarEncuesta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarEncuesta.ImageOptions.Image")));
            this.btnEliminarEncuesta.Location = new System.Drawing.Point(635, 105);
            this.btnEliminarEncuesta.Name = "btnEliminarEncuesta";
            this.btnEliminarEncuesta.Size = new System.Drawing.Size(157, 20);
            this.btnEliminarEncuesta.TabIndex = 124;
            this.btnEliminarEncuesta.Text = "Eliminar Dscto Encuesta";
            this.btnEliminarEncuesta.ToolTipTitle = "Productos en Promoción";
            this.btnEliminarEncuesta.Visible = false;
            this.btnEliminarEncuesta.Click += new System.EventHandler(this.btnEliminarEncuesta_Click);
            // 
            // gcDiseñador
            // 
            this.gcDiseñador.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gcDiseñador.Controls.Add(this.btnBuscarDiseñador);
            this.gcDiseñador.Controls.Add(this.labelControl28);
            this.gcDiseñador.Controls.Add(this.txtNombreDiseñador);
            this.gcDiseñador.Controls.Add(this.txtDniDiseñador);
            this.gcDiseñador.Location = new System.Drawing.Point(10, 97);
            this.gcDiseñador.Name = "gcDiseñador";
            this.gcDiseñador.ShowCaption = false;
            this.gcDiseñador.Size = new System.Drawing.Size(444, 24);
            this.gcDiseñador.TabIndex = 122;
            this.gcDiseñador.Text = "Datos de Facturación";
            this.gcDiseñador.Visible = false;
            // 
            // btnBuscarDiseñador
            // 
            this.btnBuscarDiseñador.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarDiseñador.ImageOptions.Image")));
            this.btnBuscarDiseñador.Location = new System.Drawing.Point(150, 2);
            this.btnBuscarDiseñador.Name = "btnBuscarDiseñador";
            this.btnBuscarDiseñador.Size = new System.Drawing.Size(26, 20);
            this.btnBuscarDiseñador.TabIndex = 120;
            this.btnBuscarDiseñador.Click += new System.EventHandler(this.btnBuscarDiseñador_Click);
            // 
            // labelControl28
            // 
            this.labelControl28.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl28.Appearance.Options.UseFont = true;
            this.labelControl28.Location = new System.Drawing.Point(5, 5);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(60, 13);
            this.labelControl28.TabIndex = 116;
            this.labelControl28.Text = "Diseñador:";
            // 
            // txtNombreDiseñador
            // 
            this.txtNombreDiseñador.EditValue = "";
            this.txtNombreDiseñador.Location = new System.Drawing.Point(178, 2);
            this.txtNombreDiseñador.Name = "txtNombreDiseñador";
            this.txtNombreDiseñador.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombreDiseñador.Properties.Appearance.Options.UseForeColor = true;
            this.txtNombreDiseñador.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreDiseñador.Properties.MaxLength = 100;
            this.txtNombreDiseñador.Properties.ReadOnly = true;
            this.txtNombreDiseñador.Size = new System.Drawing.Size(261, 20);
            this.txtNombreDiseñador.TabIndex = 118;
            // 
            // txtDniDiseñador
            // 
            this.txtDniDiseñador.EditValue = "";
            this.txtDniDiseñador.Location = new System.Drawing.Point(67, 2);
            this.txtDniDiseñador.Name = "txtDniDiseñador";
            this.txtDniDiseñador.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDniDiseñador.Properties.Appearance.Options.UseForeColor = true;
            this.txtDniDiseñador.Properties.MaxLength = 15;
            this.txtDniDiseñador.Size = new System.Drawing.Size(82, 20);
            this.txtDniDiseñador.TabIndex = 119;
            this.txtDniDiseñador.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDniDiseñador_KeyUp);
            // 
            // chkCompraPerfecta
            // 
            this.chkCompraPerfecta.EditValue = true;
            this.chkCompraPerfecta.Location = new System.Drawing.Point(902, 100);
            this.chkCompraPerfecta.Name = "chkCompraPerfecta";
            this.chkCompraPerfecta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkCompraPerfecta.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.chkCompraPerfecta.Properties.Appearance.Options.UseFont = true;
            this.chkCompraPerfecta.Properties.Appearance.Options.UseForeColor = true;
            this.chkCompraPerfecta.Properties.Caption = "C. Perfecta";
            this.chkCompraPerfecta.Size = new System.Drawing.Size(88, 20);
            this.chkCompraPerfecta.TabIndex = 113;
            this.chkCompraPerfecta.Visible = false;
            // 
            // btnEliminarCumpleanios
            // 
            this.btnEliminarCumpleanios.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarCumpleanios.ImageOptions.Image")));
            this.btnEliminarCumpleanios.Location = new System.Drawing.Point(795, 105);
            this.btnEliminarCumpleanios.Name = "btnEliminarCumpleanios";
            this.btnEliminarCumpleanios.Size = new System.Drawing.Size(157, 20);
            this.btnEliminarCumpleanios.TabIndex = 124;
            this.btnEliminarCumpleanios.Text = "Eliminar Dscto Cumpleaño";
            this.btnEliminarCumpleanios.ToolTipTitle = "Productos en Promoción";
            this.btnEliminarCumpleanios.Visible = false;
            this.btnEliminarCumpleanios.Click += new System.EventHandler(this.btnEliminarCumpleanios_Click);
            // 
            // btnPromocion
            // 
            this.btnPromocion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPromocion.ImageOptions.Image")));
            this.btnPromocion.Location = new System.Drawing.Point(958, 125);
            this.btnPromocion.Name = "btnPromocion";
            this.btnPromocion.Size = new System.Drawing.Size(26, 20);
            this.btnPromocion.TabIndex = 123;
            this.btnPromocion.ToolTip = "Ver productos en promoción por el valor de esta compra.";
            this.btnPromocion.ToolTipTitle = "Productos en Promoción";
            this.btnPromocion.Click += new System.EventHandler(this.btnPromocion_Click);
            // 
            // chkDescuentoExtraVenta
            // 
            this.chkDescuentoExtraVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkDescuentoExtraVenta.Location = new System.Drawing.Point(373, 452);
            this.chkDescuentoExtraVenta.Name = "chkDescuentoExtraVenta";
            this.chkDescuentoExtraVenta.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkDescuentoExtraVenta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkDescuentoExtraVenta.Properties.Appearance.Options.UseBackColor = true;
            this.chkDescuentoExtraVenta.Properties.Appearance.Options.UseFont = true;
            this.chkDescuentoExtraVenta.Properties.Caption = "Dscto Venta Navidad";
            this.chkDescuentoExtraVenta.Size = new System.Drawing.Size(154, 20);
            this.chkDescuentoExtraVenta.TabIndex = 113;
            this.chkDescuentoExtraVenta.Visible = false;
            // 
            // grdDatosFacturacion
            // 
            this.grdDatosFacturacion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.grdDatosFacturacion.Controls.Add(this.cboClienteAsociado);
            this.grdDatosFacturacion.Controls.Add(this.lblFacturara);
            this.grdDatosFacturacion.Controls.Add(this.txtDireccionAsociado);
            this.grdDatosFacturacion.Controls.Add(this.txtNumeroDocumentoAsociado);
            this.grdDatosFacturacion.Location = new System.Drawing.Point(256, 100);
            this.grdDatosFacturacion.Name = "grdDatosFacturacion";
            this.grdDatosFacturacion.ShowCaption = false;
            this.grdDatosFacturacion.Size = new System.Drawing.Size(692, 28);
            this.grdDatosFacturacion.TabIndex = 122;
            this.grdDatosFacturacion.Text = "Datos de Facturación";
            this.grdDatosFacturacion.Visible = false;
            // 
            // cboClienteAsociado
            // 
            this.cboClienteAsociado.Location = new System.Drawing.Point(67, 3);
            this.cboClienteAsociado.Name = "cboClienteAsociado";
            this.cboClienteAsociado.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboClienteAsociado.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cboClienteAsociado.Properties.Appearance.Options.UseFont = true;
            this.cboClienteAsociado.Properties.Appearance.Options.UseForeColor = true;
            this.cboClienteAsociado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClienteAsociado.Properties.NullText = "";
            this.cboClienteAsociado.Size = new System.Drawing.Size(247, 20);
            this.cboClienteAsociado.TabIndex = 117;
            this.cboClienteAsociado.EditValueChanged += new System.EventHandler(this.cboClienteAsociado_EditValueChanged);
            // 
            // lblFacturara
            // 
            this.lblFacturara.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFacturara.Appearance.Options.UseFont = true;
            this.lblFacturara.Location = new System.Drawing.Point(5, 6);
            this.lblFacturara.Name = "lblFacturara";
            this.lblFacturara.Size = new System.Drawing.Size(56, 13);
            this.lblFacturara.TabIndex = 116;
            this.lblFacturara.Text = "Factura a:";
            // 
            // txtDireccionAsociado
            // 
            this.txtDireccionAsociado.Location = new System.Drawing.Point(408, 3);
            this.txtDireccionAsociado.Name = "txtDireccionAsociado";
            this.txtDireccionAsociado.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccionAsociado.Properties.MaxLength = 100;
            this.txtDireccionAsociado.Properties.ReadOnly = true;
            this.txtDireccionAsociado.Size = new System.Drawing.Size(270, 20);
            this.txtDireccionAsociado.TabIndex = 118;
            // 
            // txtNumeroDocumentoAsociado
            // 
            this.txtNumeroDocumentoAsociado.Location = new System.Drawing.Point(320, 3);
            this.txtNumeroDocumentoAsociado.Name = "txtNumeroDocumentoAsociado";
            this.txtNumeroDocumentoAsociado.Properties.MaxLength = 15;
            this.txtNumeroDocumentoAsociado.Properties.ReadOnly = true;
            this.txtNumeroDocumentoAsociado.Size = new System.Drawing.Size(82, 20);
            this.txtNumeroDocumentoAsociado.TabIndex = 119;
            // 
            // labelControl23
            // 
            this.labelControl23.Location = new System.Drawing.Point(12, 78);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(47, 13);
            this.labelControl23.TabIndex = 121;
            this.labelControl23.Text = "Direccion:";
            // 
            // cboAsesor
            // 
            this.cboAsesor.Location = new System.Drawing.Point(65, 99);
            this.cboAsesor.Name = "cboAsesor";
            this.cboAsesor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboAsesor.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cboAsesor.Properties.Appearance.Options.UseFont = true;
            this.cboAsesor.Properties.Appearance.Options.UseForeColor = true;
            this.cboAsesor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAsesor.Properties.NullText = "";
            this.cboAsesor.Size = new System.Drawing.Size(184, 20);
            this.cboAsesor.TabIndex = 115;
            // 
            // lblAsesor
            // 
            this.lblAsesor.Location = new System.Drawing.Point(7, 102);
            this.lblAsesor.Name = "lblAsesor";
            this.lblAsesor.Size = new System.Drawing.Size(52, 13);
            this.lblAsesor.TabIndex = 114;
            this.lblAsesor.Text = "Diseñador:";
            // 
            // cboTipoDocumentoBusqueda
            // 
            this.cboTipoDocumentoBusqueda.Location = new System.Drawing.Point(872, 10);
            this.cboTipoDocumentoBusqueda.Name = "cboTipoDocumentoBusqueda";
            this.cboTipoDocumentoBusqueda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoDocumentoBusqueda.Properties.NullText = "";
            this.cboTipoDocumentoBusqueda.Size = new System.Drawing.Size(101, 20);
            this.cboTipoDocumentoBusqueda.TabIndex = 79;
            this.cboTipoDocumentoBusqueda.ToolTip = "Seleccionar tipo de documento para Importar";
            this.cboTipoDocumentoBusqueda.EditValueChanged += new System.EventHandler(this.cboMotivo_EditValueChanged);
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(468, 9);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Properties.NullText = "";
            this.cboMotivo.Size = new System.Drawing.Size(87, 20);
            this.cboMotivo.TabIndex = 79;
            this.cboMotivo.EditValueChanged += new System.EventHandler(this.cboMotivo_EditValueChanged);
            // 
            // cboTipoVenta
            // 
            this.cboTipoVenta.Location = new System.Drawing.Point(741, 76);
            this.cboTipoVenta.Name = "cboTipoVenta";
            this.cboTipoVenta.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cboTipoVenta.Properties.Appearance.Options.UseForeColor = true;
            this.cboTipoVenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoVenta.Properties.DropDownRows = 10;
            this.cboTipoVenta.Properties.NullText = "";
            this.cboTipoVenta.Size = new System.Drawing.Size(140, 20);
            this.cboTipoVenta.TabIndex = 79;
            this.cboTipoVenta.EditValueChanged += new System.EventHandler(this.cboTipoVenta_EditValueChanged);
            // 
            // btnClienteAsociado
            // 
            this.btnClienteAsociado.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClienteAsociado.ImageOptions.Image")));
            this.btnClienteAsociado.Location = new System.Drawing.Point(654, 54);
            this.btnClienteAsociado.Name = "btnClienteAsociado";
            this.btnClienteAsociado.Size = new System.Drawing.Size(26, 20);
            this.btnClienteAsociado.TabIndex = 78;
            this.btnClienteAsociado.ToolTipTitle = "Cliente Asociado";
            this.btnClienteAsociado.Click += new System.EventHandler(this.btnClienteAsociado_Click);
            // 
            // cboCombo
            // 
            this.cboCombo.Location = new System.Drawing.Point(941, 53);
            this.cboCombo.Name = "cboCombo";
            this.cboCombo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCombo.Properties.NullText = "";
            this.cboCombo.Size = new System.Drawing.Size(114, 20);
            this.cboCombo.TabIndex = 26;
            this.cboCombo.EditValueChanged += new System.EventHandler(this.cboCombo_EditValueChanged);
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(884, 56);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(37, 13);
            this.labelControl19.TabIndex = 77;
            this.labelControl19.Text = "Combo:";
            // 
            // btnEditar
            // 
            this.btnEditar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.ImageOptions.Image")));
            this.btnEditar.ImageOptions.ImageIndex = 1;
            this.btnEditar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(88, 125);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(67, 23);
            this.btnEditar.TabIndex = 32;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AllowFocus = false;
            this.btnEliminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.Image")));
            this.btnEliminar.ImageOptions.ImageIndex = 1;
            this.btnEliminar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(161, 125);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 33;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.ImageOptions.Image")));
            this.btnNuevo.ImageOptions.ImageIndex = 1;
            this.btnNuevo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(9, 125);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(73, 23);
            this.btnNuevo.TabIndex = 31;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Location = new System.Drawing.Point(685, 53);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoCliente.Properties.MaxLength = 100;
            this.txtTipoCliente.Properties.ReadOnly = true;
            this.txtTipoCliente.Size = new System.Drawing.Size(167, 20);
            this.txtTipoCliente.TabIndex = 24;
            this.txtTipoCliente.EditValueChanged += new System.EventHandler(this.txtTipoCliente_EditValueChanged);
            // 
            // deFechaVencimiento
            // 
            this.deFechaVencimiento.EditValue = null;
            this.deFechaVencimiento.Location = new System.Drawing.Point(685, 32);
            this.deFechaVencimiento.Name = "deFechaVencimiento";
            this.deFechaVencimiento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaVencimiento.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaVencimiento.Size = new System.Drawing.Size(90, 20);
            this.deFechaVencimiento.TabIndex = 15;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(623, 35);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(57, 13);
            this.labelControl16.TabIndex = 14;
            this.labelControl16.Text = "Fecha Vcto:";
            // 
            // txtTotalCantidad
            // 
            this.txtTotalCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalCantidad.EditValue = "0";
            this.txtTotalCantidad.Location = new System.Drawing.Point(558, 426);
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalCantidad.Properties.Mask.EditMask = "n";
            this.txtTotalCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalCantidad.Properties.ReadOnly = true;
            this.txtTotalCantidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalCantidad.Size = new System.Drawing.Size(49, 20);
            this.txtTotalCantidad.TabIndex = 33;
            // 
            // labelControl18
            // 
            this.labelControl18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl18.Location = new System.Drawing.Point(481, 430);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(74, 13);
            this.labelControl18.TabIndex = 32;
            this.labelControl18.Text = "Total Cantidad:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSubTotal.EditValue = "0.00";
            this.txtSubTotal.Location = new System.Drawing.Point(617, 478);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Properties.DisplayFormat.FormatString = "n";
            this.txtSubTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSubTotal.Properties.Mask.EditMask = "n";
            this.txtSubTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSubTotal.Properties.ReadOnly = true;
            this.txtSubTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSubTotal.Size = new System.Drawing.Size(67, 20);
            this.txtSubTotal.TabIndex = 35;
            // 
            // labelControl14
            // 
            this.labelControl14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl14.Location = new System.Drawing.Point(567, 482);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(46, 13);
            this.labelControl14.TabIndex = 34;
            this.labelControl14.Text = "SubTotal:";
            // 
            // txtTotalBruto
            // 
            this.txtTotalBruto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalBruto.EditValue = "0.00";
            this.txtTotalBruto.Location = new System.Drawing.Point(981, 455);
            this.txtTotalBruto.Name = "txtTotalBruto";
            this.txtTotalBruto.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalBruto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalBruto.Properties.Mask.EditMask = "n";
            this.txtTotalBruto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalBruto.Properties.ReadOnly = true;
            this.txtTotalBruto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalBruto.Size = new System.Drawing.Size(75, 20);
            this.txtTotalBruto.TabIndex = 39;
            // 
            // txtTotalDscto2x1
            // 
            this.txtTotalDscto2x1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalDscto2x1.EditValue = "0.00";
            this.txtTotalDscto2x1.Location = new System.Drawing.Point(858, 455);
            this.txtTotalDscto2x1.Name = "txtTotalDscto2x1";
            this.txtTotalDscto2x1.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalDscto2x1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalDscto2x1.Properties.Mask.EditMask = "n";
            this.txtTotalDscto2x1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalDscto2x1.Properties.ReadOnly = true;
            this.txtTotalDscto2x1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalDscto2x1.Size = new System.Drawing.Size(73, 20);
            this.txtTotalDscto2x1.TabIndex = 39;
            // 
            // labelControl24
            // 
            this.labelControl24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl24.Location = new System.Drawing.Point(796, 458);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(58, 13);
            this.labelControl24.TabIndex = 38;
            this.labelControl24.Text = "Total Dscto:";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.EditValue = "0.00";
            this.txtTotal.Location = new System.Drawing.Point(981, 478);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(75, 20);
            this.txtTotal.TabIndex = 39;
            this.txtTotal.EditValueChanged += new System.EventHandler(this.txtTotal_EditValueChanged);
            // 
            // labelControl25
            // 
            this.labelControl25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl25.Location = new System.Drawing.Point(933, 458);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(43, 13);
            this.labelControl25.TabIndex = 38;
            this.labelControl25.Text = "T. Bruto:";
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(941, 482);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(35, 13);
            this.labelControl10.TabIndex = 38;
            this.labelControl10.Text = "Total :";
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtImpuesto.EditValue = "0.00";
            this.txtImpuesto.Location = new System.Drawing.Point(715, 478);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Properties.DisplayFormat.FormatString = "n";
            this.txtImpuesto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtImpuesto.Properties.Mask.EditMask = "n";
            this.txtImpuesto.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtImpuesto.Properties.ReadOnly = true;
            this.txtImpuesto.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtImpuesto.Size = new System.Drawing.Size(75, 20);
            this.txtImpuesto.TabIndex = 37;
            // 
            // labelControl9
            // 
            this.labelControl9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl9.Location = new System.Drawing.Point(692, 482);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(21, 13);
            this.labelControl9.TabIndex = 36;
            this.labelControl9.Text = "IGV:";
            // 
            // lblIdPedido
            // 
            this.lblIdPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIdPedido.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblIdPedido.Appearance.Options.UseForeColor = true;
            this.lblIdPedido.Location = new System.Drawing.Point(24, 453);
            this.lblIdPedido.Name = "lblIdPedido";
            this.lblIdPedido.Size = new System.Drawing.Size(36, 13);
            this.lblIdPedido.TabIndex = 30;
            this.lblIdPedido.Text = "623625";
            // 
            // labelControl20
            // 
            this.labelControl20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl20.Location = new System.Drawing.Point(8, 434);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(75, 13);
            this.labelControl20.TabIndex = 30;
            this.labelControl20.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtObservaciones.Location = new System.Drawing.Point(86, 433);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Properties.MaxLength = 200;
            this.txtObservaciones.Size = new System.Drawing.Size(285, 39);
            this.txtObservaciones.TabIndex = 31;
            // 
            // txtNumeroProforma
            // 
            this.txtNumeroProforma.Location = new System.Drawing.Point(973, 10);
            this.txtNumeroProforma.Name = "txtNumeroProforma";
            this.txtNumeroProforma.Properties.MaxLength = 6;
            this.txtNumeroProforma.Size = new System.Drawing.Size(83, 20);
            this.txtNumeroProforma.TabIndex = 9;
            this.txtNumeroProforma.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroProforma_KeyDown);
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(841, 13);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(25, 13);
            this.labelControl15.TabIndex = 8;
            this.labelControl15.Text = "Ref.:";
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(426, 12);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(36, 13);
            this.labelControl21.TabIndex = 29;
            this.labelControl21.Text = "Motivo:";
            // 
            // cboCaja
            // 
            this.cboCaja.Location = new System.Drawing.Point(941, 76);
            this.cboCaja.Name = "cboCaja";
            this.cboCaja.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCaja.Properties.DropDownRows = 12;
            this.cboCaja.Properties.NullText = "";
            this.cboCaja.Size = new System.Drawing.Size(113, 20);
            this.cboCaja.TabIndex = 30;
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl22.Appearance.Options.UseFont = true;
            this.labelControl22.Location = new System.Drawing.Point(656, 80);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(80, 13);
            this.labelControl22.TabIndex = 29;
            this.labelControl22.Text = "Tipo de Venta:";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(884, 79);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(55, 13);
            this.labelControl13.TabIndex = 29;
            this.labelControl13.Text = "Despachar:";
            // 
            // cboVendedor
            // 
            this.cboVendedor.Location = new System.Drawing.Point(65, 32);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboVendedor.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cboVendedor.Properties.Appearance.Options.UseFont = true;
            this.cboVendedor.Properties.Appearance.Options.UseForeColor = true;
            this.cboVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedor.Properties.NullText = "";
            this.cboVendedor.Size = new System.Drawing.Size(325, 20);
            this.cboVendedor.TabIndex = 11;
            this.cboVendedor.EditValueChanged += new System.EventHandler(this.cboVendedor_EditValueChanged);
            this.cboVendedor.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cboVendedor_EditValueChanging);
            this.cboVendedor.TextChanged += new System.EventHandler(this.cboVendedor_TextChanged);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(11, 35);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(50, 13);
            this.labelControl12.TabIndex = 10;
            this.labelControl12.Text = "Vendedor:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(608, 9);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.MaxLength = 7;
            this.txtNumero.Properties.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(76, 20);
            this.txtNumero.TabIndex = 5;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(561, 13);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(41, 13);
            this.labelControl11.TabIndex = 4;
            this.labelControl11.Text = "Número:";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(65, 9);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Properties.ReadOnly = true;
            this.cboEmpresa.Size = new System.Drawing.Size(325, 20);
            this.cboEmpresa.TabIndex = 1;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 12);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(45, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Empresa:";
            // 
            // gcPedidoDetalle
            // 
            this.gcPedidoDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcPedidoDetalle.ContextMenuStrip = this.mnuContextual;
            this.gcPedidoDetalle.Location = new System.Drawing.Point(-1, 154);
            this.gcPedidoDetalle.MainView = this.gvPedidoDetalle;
            this.gcPedidoDetalle.Name = "gcPedidoDetalle";
            this.gcPedidoDetalle.Size = new System.Drawing.Size(1073, 269);
            this.gcPedidoDetalle.TabIndex = 29;
            this.gcPedidoDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPedidoDetalle});
            // 
            // mnuContextual
            // 
            this.mnuContextual.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.modificarprecioToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.toolStripSeparator1,
            this.establecerdescuentoToolStripMenuItem,
            this.descuentocupontoolStripMenuItem,
            this.establecerpreciopublicitariotoolStripMenuItem,
            this.toolStripSeparator2,
            this.establecerdescuentocerotoolStripMenuItem,
            this.eliminarpromocion2x1toolStripMenuItem,
            this.toolStripSeparator3,
            this.utilizarprecioucayalitoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(271, 256);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // modificarprecioToolStripMenuItem
            // 
            this.modificarprecioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarprecioToolStripMenuItem.Image")));
            this.modificarprecioToolStripMenuItem.Name = "modificarprecioToolStripMenuItem";
            this.modificarprecioToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.modificarprecioToolStripMenuItem.Text = "Editar";
            this.modificarprecioToolStripMenuItem.Visible = false;
            this.modificarprecioToolStripMenuItem.Click += new System.EventHandler(this.modificarprecioToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // establecerdescuentoToolStripMenuItem
            // 
            this.establecerdescuentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("establecerdescuentoToolStripMenuItem.Image")));
            this.establecerdescuentoToolStripMenuItem.Name = "establecerdescuentoToolStripMenuItem";
            this.establecerdescuentoToolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.establecerdescuentoToolStripMenuItem.Text = "Establecer Descuento";
            this.establecerdescuentoToolStripMenuItem.Click += new System.EventHandler(this.establecerdescuentoToolStripMenuItem_Click);
            // 
            // descuentocupontoolStripMenuItem
            // 
            this.descuentocupontoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("descuentocupontoolStripMenuItem.Image")));
            this.descuentocupontoolStripMenuItem.Name = "descuentocupontoolStripMenuItem";
            this.descuentocupontoolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.descuentocupontoolStripMenuItem.Text = "Descuento Próxima Compra";
            this.descuentocupontoolStripMenuItem.ToolTipText = "Establece el descuento por la segunda compra";
            this.descuentocupontoolStripMenuItem.Click += new System.EventHandler(this.descuentocupontoolStripMenuItem_Click);
            // 
            // establecerpreciopublicitariotoolStripMenuItem
            // 
            this.establecerpreciopublicitariotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Calculator_16x16;
            this.establecerpreciopublicitariotoolStripMenuItem.Name = "establecerpreciopublicitariotoolStripMenuItem";
            this.establecerpreciopublicitariotoolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.establecerpreciopublicitariotoolStripMenuItem.Text = "Establecer Precio Cliente Publicitario";
            this.establecerpreciopublicitariotoolStripMenuItem.Click += new System.EventHandler(this.establecerpreciopublicitariotoolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(267, 6);
            // 
            // establecerdescuentocerotoolStripMenuItem
            // 
            this.establecerdescuentocerotoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("establecerdescuentocerotoolStripMenuItem.Image")));
            this.establecerdescuentocerotoolStripMenuItem.Name = "establecerdescuentocerotoolStripMenuItem";
            this.establecerdescuentocerotoolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.establecerdescuentocerotoolStripMenuItem.Text = "Eliminar Descuento 0%";
            this.establecerdescuentocerotoolStripMenuItem.Click += new System.EventHandler(this.establecerdescuentocerotoolStripMenuItem_Click);
            // 
            // eliminarpromocion2x1toolStripMenuItem
            // 
            this.eliminarpromocion2x1toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarpromocion2x1toolStripMenuItem.Image")));
            this.eliminarpromocion2x1toolStripMenuItem.Name = "eliminarpromocion2x1toolStripMenuItem";
            this.eliminarpromocion2x1toolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.eliminarpromocion2x1toolStripMenuItem.Text = "Eliminar Promoción 2x1 / 3x2  / 6x3";
            this.eliminarpromocion2x1toolStripMenuItem.Click += new System.EventHandler(this.eliminarpromocion2x1toolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(267, 6);
            // 
            // utilizarprecioucayalitoolStripMenuItem
            // 
            this.utilizarprecioucayalitoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("utilizarprecioucayalitoolStripMenuItem.Image")));
            this.utilizarprecioucayalitoolStripMenuItem.Name = "utilizarprecioucayalitoolStripMenuItem";
            this.utilizarprecioucayalitoolStripMenuItem.Size = new System.Drawing.Size(270, 26);
            this.utilizarprecioucayalitoolStripMenuItem.Text = "Establecer Precio de Promoción";
            this.utilizarprecioucayalitoolStripMenuItem.Click += new System.EventHandler(this.utilizarprecioucayalitoolStripMenuItem_Click);
            // 
            // gvPedidoDetalle
            // 
            this.gvPedidoDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn11,
            this.gridColumn3,
            this.gridColumn4,
            this.gcCodigo,
            this.gridColumn10,
            this.gridColumn28,
            this.gridColumn7,
            this.gcCantidad,
            this.gridColumn20,
            this.gridColumn8,
            this.gcPorcentajeDescuento,
            this.gridColumn14,
            this.gridColumn13,
            this.gridColumn17,
            this.gcObservacion,
            this.gridColumn12,
            this.gridColumn6,
            this.gridColumn19,
            this.gridColumn22,
            this.gridColumn18,
            this.gridColumn16,
            this.gridColumn5,
            this.gridColumn2,
            this.gcLineaProducto,
            this.gridColumn15,
            this.gridColumn9,
            this.gridColumn21,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35});
            this.gvPedidoDetalle.GridControl = this.gcPedidoDetalle;
            this.gvPedidoDetalle.Name = "gvPedidoDetalle";
            this.gvPedidoDetalle.OptionsSelection.MultiSelect = true;
            this.gvPedidoDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvPedidoDetalle.OptionsView.ShowGroupPanel = false;
            this.gvPedidoDetalle.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvPedidoDetalle_RowStyle);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdPedido";
            this.gridColumn1.FieldName = "IdPedido";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdPedidoDetalle";
            this.gridColumn11.FieldName = "IdPedidoDetalle";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Item";
            this.gridColumn3.FieldName = "Item";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 39;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IdProducto";
            this.gridColumn4.FieldName = "IdProducto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCodigo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.ColumnEdit = this.gcTxtCodigo;
            this.gcCodigo.FieldName = "CodigoProveedor";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.AllowEdit = false;
            this.gcCodigo.OptionsColumn.AllowFocus = false;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 1;
            this.gcCodigo.Width = 106;
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Descripción";
            this.gridColumn10.FieldName = "NombreProducto";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 310;
            // 
            // gridColumn28
            // 
            this.gridColumn28.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn28.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn28.Caption = "Medida";
            this.gridColumn28.FieldName = "Medida";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.AllowFocus = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 3;
            this.gridColumn28.Width = 80;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "U.M";
            this.gridColumn7.FieldName = "Abreviatura";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 50;
            // 
            // gcCantidad
            // 
            this.gcCantidad.AppearanceHeader.Options.UseTextOptions = true;
            this.gcCantidad.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcCantidad.Caption = "Cant.";
            this.gcCantidad.FieldName = "Cantidad";
            this.gcCantidad.Name = "gcCantidad";
            this.gcCantidad.OptionsColumn.AllowEdit = false;
            this.gcCantidad.OptionsColumn.AllowFocus = false;
            this.gcCantidad.Visible = true;
            this.gcCantidad.VisibleIndex = 5;
            this.gcCantidad.Width = 40;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "CantidadAnt";
            this.gridColumn20.FieldName = "CantidadAnt";
            this.gridColumn20.Name = "gridColumn20";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "P.Unitario";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "PrecioUnitario";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 60;
            // 
            // gcPorcentajeDescuento
            // 
            this.gcPorcentajeDescuento.AppearanceHeader.Options.UseTextOptions = true;
            this.gcPorcentajeDescuento.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcPorcentajeDescuento.Caption = "% Dscto";
            this.gcPorcentajeDescuento.DisplayFormat.FormatString = "#,0.00";
            this.gcPorcentajeDescuento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPorcentajeDescuento.FieldName = "PorcentajeDescuento";
            this.gcPorcentajeDescuento.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPorcentajeDescuento.Name = "gcPorcentajeDescuento";
            this.gcPorcentajeDescuento.OptionsColumn.AllowEdit = false;
            this.gcPorcentajeDescuento.OptionsColumn.AllowFocus = false;
            this.gcPorcentajeDescuento.Visible = true;
            this.gcPorcentajeDescuento.VisibleIndex = 7;
            this.gcPorcentajeDescuento.Width = 60;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn14.Caption = "Descuento";
            this.gridColumn14.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "P.Venta";
            this.gridColumn13.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "PrecioVenta";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 8;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn17.Caption = "V. Venta";
            this.gridColumn17.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "ValorVenta";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 9;
            // 
            // gcObservacion
            // 
            this.gcObservacion.AppearanceHeader.Options.UseTextOptions = true;
            this.gcObservacion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcObservacion.Caption = "Observación";
            this.gcObservacion.FieldName = "Observacion";
            this.gcObservacion.Name = "gcObservacion";
            this.gcObservacion.OptionsColumn.AllowEdit = false;
            this.gcObservacion.OptionsColumn.AllowFocus = false;
            this.gcObservacion.Visible = true;
            this.gcObservacion.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdKardex";
            this.gridColumn12.FieldName = "IdKardex";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdAlmacen";
            this.gridColumn6.FieldName = "IdAlmacen";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Muestra";
            this.gridColumn19.FieldName = "FlagMuestra";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 11;
            this.gridColumn19.Width = 55;
            // 
            // gridColumn22
            // 
            this.gridColumn22.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.gridColumn22.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.gridColumn22.AppearanceCell.Options.UseFont = true;
            this.gridColumn22.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn22.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn22.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn22.Caption = "Promoción";
            this.gridColumn22.FieldName = "DescPromocion";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 12;
            this.gridColumn22.Width = 58;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Autoservicio";
            this.gridColumn18.FieldName = "FlagRegalo";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 13;
            this.gridColumn18.Width = 80;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Stock";
            this.gridColumn16.FieldName = "Stock";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "PrecioUnitarioInicial";
            this.gridColumn5.FieldName = "PrecioUnitarioInicial";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "PorcentajeDescuentoInicial";
            this.gridColumn2.FieldName = "PorcentajeDescuentoInicial";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gcLineaProducto
            // 
            this.gcLineaProducto.Caption = "IdLineaProducto";
            this.gcLineaProducto.FieldName = "IdLineaProducto";
            this.gcLineaProducto.Name = "gcLineaProducto";
            this.gcLineaProducto.OptionsColumn.AllowEdit = false;
            this.gcLineaProducto.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "TipoOper";
            this.gridColumn15.FieldName = "TipoOper";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "IdPromocion";
            this.gridColumn9.FieldName = "IdPromocion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Bulto";
            this.gridColumn21.FieldName = "FlagBultoCerrado";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "FlagNacional";
            this.gridColumn23.FieldName = "FlagNacional";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "IdAlmacenOrigen";
            this.gridColumn24.FieldName = "IdAlmacenOrigen";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IdMovimientoAlmacenDetalle";
            this.gridColumn25.FieldName = "IdMovimientoAlmacenDetalle";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "IdMarca";
            this.gridColumn26.FieldName = "IdMarca";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "CodAfeIGV";
            this.gridColumn27.FieldName = "CodAfeIGV";
            this.gridColumn27.MinWidth = 21;
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.OptionsColumn.AllowFocus = false;
            this.gridColumn27.Width = 81;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "IdFamiliaProducto";
            this.gridColumn29.FieldName = "IdFamiliaProducto";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "FlagEscala";
            this.gridColumn30.FieldName = "FlagEscala";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Obs Escala";
            this.gridColumn31.FieldName = "ObsEscala";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.OptionsColumn.AllowFocus = false;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 14;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "Familia";
            this.gridColumn32.FieldName = "DescFamiliaProducto";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowEdit = false;
            this.gridColumn32.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "IdPromocion2";
            this.gridColumn33.FieldName = "IdPromocion2";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "FlagCompuesto";
            this.gridColumn34.FieldName = "FlagCompuesto";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "FlagFijarDescuento";
            this.gridColumn35.FieldName = "FlagFijarDescuento";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.OptionsColumn.AllowFocus = false;
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoCliente.ImageOptions.Image")));
            this.btnNuevoCliente.Location = new System.Drawing.Point(855, 54);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Size = new System.Drawing.Size(26, 20);
            this.btnNuevoCliente.TabIndex = 25;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(153, 54);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 22;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(65, 75);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Properties.MaxLength = 100;
            this.txtDireccion.Size = new System.Drawing.Size(585, 20);
            this.txtDireccion.TabIndex = 28;
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(185, 54);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Properties.ReadOnly = true;
            this.txtDescCliente.Size = new System.Drawing.Size(465, 20);
            this.txtDescCliente.TabIndex = 23;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(65, 54);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(82, 20);
            this.txtNumeroDocumento.TabIndex = 21;
            this.txtNumeroDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyUp);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 57);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 20;
            this.labelControl5.Text = "Cliente:";
            // 
            // txtTipoCambio
            // 
            this.txtTipoCambio.EditValue = "0.00";
            this.txtTipoCambio.Location = new System.Drawing.Point(1003, 32);
            this.txtTipoCambio.Name = "txtTipoCambio";
            this.txtTipoCambio.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTipoCambio.Properties.Appearance.Options.UseFont = true;
            this.txtTipoCambio.Properties.DisplayFormat.FormatString = "n2";
            this.txtTipoCambio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTipoCambio.Properties.Mask.EditMask = "n2";
            this.txtTipoCambio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTipoCambio.Properties.Mask.ShowPlaceHolders = false;
            this.txtTipoCambio.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTipoCambio.Properties.ReadOnly = true;
            this.txtTipoCambio.Size = new System.Drawing.Size(52, 20);
            this.txtTipoCambio.TabIndex = 19;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(980, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(17, 13);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "TC:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(829, 31);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.NullText = "";
            this.cboMoneda.Size = new System.Drawing.Size(145, 20);
            this.cboMoneda.TabIndex = 17;
            this.cboMoneda.EditValueChanged += new System.EventHandler(this.cboMoneda_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(781, 35);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 13);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Moneda:";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.Location = new System.Drawing.Point(468, 32);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFormaPago.Properties.NullText = "";
            this.cboFormaPago.Size = new System.Drawing.Size(145, 20);
            this.cboFormaPago.TabIndex = 13;
            this.cboFormaPago.EditValueChanged += new System.EventHandler(this.cboFormaPago_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(401, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Forma Pago:";
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(739, 9);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Size = new System.Drawing.Size(90, 20);
            this.deFecha.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(698, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(33, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Fecha:";
            // 
            // cboDocumento
            // 
            this.cboDocumento.Enabled = false;
            this.cboDocumento.Location = new System.Drawing.Point(1037, 99);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDocumento.Properties.NullText = "";
            this.cboDocumento.Size = new System.Drawing.Size(18, 20);
            this.cboDocumento.TabIndex = 3;
            // 
            // txtTotal2x1
            // 
            this.txtTotal2x1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal2x1.EditValue = "0.00";
            this.txtTotal2x1.Location = new System.Drawing.Point(725, 502);
            this.txtTotal2x1.Name = "txtTotal2x1";
            this.txtTotal2x1.Properties.DisplayFormat.FormatString = "n";
            this.txtTotal2x1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal2x1.Properties.Mask.EditMask = "n";
            this.txtTotal2x1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal2x1.Properties.ReadOnly = true;
            this.txtTotal2x1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal2x1.Size = new System.Drawing.Size(51, 20);
            this.txtTotal2x1.TabIndex = 39;
            this.txtTotal2x1.Visible = false;
            // 
            // labelControl7
            // 
            this.labelControl7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl7.Location = new System.Drawing.Point(673, 505);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 38;
            this.labelControl7.Text = "Total 2x1:";
            this.labelControl7.Visible = false;
            // 
            // txtDescuento
            // 
            this.txtDescuento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDescuento.EditValue = "0.000000000000000";
            this.txtDescuento.Location = new System.Drawing.Point(560, 501);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDescuento.Properties.Mask.EditMask = "n";
            this.txtDescuento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDescuento.Properties.ReadOnly = true;
            this.txtDescuento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescuento.Size = new System.Drawing.Size(107, 20);
            this.txtDescuento.TabIndex = 39;
            this.txtDescuento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescuento_KeyDown);
            // 
            // labelControl26
            // 
            this.labelControl26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl26.Location = new System.Drawing.Point(510, 504);
            this.labelControl26.Name = "labelControl26";
            this.labelControl26.Size = new System.Drawing.Size(45, 13);
            this.labelControl26.TabIndex = 38;
            this.labelControl26.Text = "% Dscto:";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1072, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 560);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1072, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 560);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1072, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 560);
            // 
            // labelControl27
            // 
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl27.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl27.Appearance.Options.UseFont = true;
            this.labelControl27.Appearance.Options.UseForeColor = true;
            this.labelControl27.Location = new System.Drawing.Point(607, 525);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(69, 13);
            this.labelControl27.TabIndex = 8;
            this.labelControl27.Text = "N° Contrato:";
            this.labelControl27.Visible = false;
            // 
            // chkPreventa
            // 
            this.chkPreventa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPreventa.Location = new System.Drawing.Point(6, 533);
            this.chkPreventa.Name = "chkPreventa";
            this.chkPreventa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkPreventa.Properties.Appearance.Options.UseFont = true;
            this.chkPreventa.Properties.Caption = "Preventa";
            this.chkPreventa.Size = new System.Drawing.Size(75, 20);
            this.chkPreventa.TabIndex = 1;
            this.chkPreventa.CheckedChanged += new System.EventHandler(this.chkPreventa_CheckedChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(989, 531);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(909, 531);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMenuAgregar,
            this.tsmMenuEliminar,
            this.tsmMenuSelText});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1070, 24);
            this.menuStrip1.TabIndex = 110;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // tsmMenuAgregar
            // 
            this.tsmMenuAgregar.Name = "tsmMenuAgregar";
            this.tsmMenuAgregar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmMenuAgregar.Size = new System.Drawing.Size(61, 20);
            this.tsmMenuAgregar.Text = "Agregar";
            // 
            // tsmMenuEliminar
            // 
            this.tsmMenuEliminar.Name = "tsmMenuEliminar";
            this.tsmMenuEliminar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmMenuEliminar.Size = new System.Drawing.Size(62, 20);
            this.tsmMenuEliminar.Text = "Eliminar";
            // 
            // tsmMenuSelText
            // 
            this.tsmMenuSelText.Name = "tsmMenuSelText";
            this.tsmMenuSelText.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmMenuSelText.Size = new System.Drawing.Size(55, 20);
            this.tsmMenuSelText.Text = "SelText";
            // 
            // txtNumeroPedido
            // 
            this.txtNumeroPedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNumeroPedido.Location = new System.Drawing.Point(146, 533);
            this.txtNumeroPedido.Name = "txtNumeroPedido";
            this.txtNumeroPedido.Properties.MaxLength = 7;
            this.txtNumeroPedido.Size = new System.Drawing.Size(74, 20);
            this.txtNumeroPedido.TabIndex = 112;
            this.txtNumeroPedido.ToolTip = "Ingresar los 7 digitos del N° Pedido";
            this.txtNumeroPedido.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroPedido_KeyUp);
            // 
            // labelControl17
            // 
            this.labelControl17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl17.Location = new System.Drawing.Point(90, 536);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(51, 13);
            this.labelControl17.TabIndex = 111;
            this.labelControl17.Text = "N° Pedido:";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMensaje.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblMensaje.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblMensaje.Appearance.Options.UseFont = true;
            this.lblMensaje.Appearance.Options.UseForeColor = true;
            this.lblMensaje.Location = new System.Drawing.Point(501, 535);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 16);
            this.lblMensaje.TabIndex = 113;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(5, 7);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(113, 16);
            this.labelControl6.TabIndex = 111;
            this.labelControl6.Text = "Saldo Disponible: ";
            // 
            // txtSaldoDisponible
            // 
            this.txtSaldoDisponible.EditValue = "0.00";
            this.txtSaldoDisponible.Location = new System.Drawing.Point(120, 3);
            this.txtSaldoDisponible.Name = "txtSaldoDisponible";
            this.txtSaldoDisponible.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoDisponible.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtSaldoDisponible.Properties.Appearance.Options.UseFont = true;
            this.txtSaldoDisponible.Properties.Appearance.Options.UseForeColor = true;
            this.txtSaldoDisponible.Properties.DisplayFormat.FormatString = "n";
            this.txtSaldoDisponible.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldoDisponible.Properties.Mask.EditMask = "n";
            this.txtSaldoDisponible.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaldoDisponible.Properties.ReadOnly = true;
            this.txtSaldoDisponible.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSaldoDisponible.Size = new System.Drawing.Size(63, 22);
            this.txtSaldoDisponible.TabIndex = 35;
            // 
            // gcSaldoDisponible
            // 
            this.gcSaldoDisponible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gcSaldoDisponible.Appearance.BackColor = System.Drawing.Color.Maroon;
            this.gcSaldoDisponible.Appearance.Options.UseBackColor = true;
            this.gcSaldoDisponible.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gcSaldoDisponible.Controls.Add(this.txtSaldoDisponible);
            this.gcSaldoDisponible.Controls.Add(this.labelControl6);
            this.gcSaldoDisponible.Location = new System.Drawing.Point(229, 529);
            this.gcSaldoDisponible.Name = "gcSaldoDisponible";
            this.gcSaldoDisponible.ShowCaption = false;
            this.gcSaldoDisponible.Size = new System.Drawing.Size(187, 28);
            this.gcSaldoDisponible.TabIndex = 122;
            this.gcSaldoDisponible.Text = "Datos de Facturación";
            this.gcSaldoDisponible.Visible = false;
            // 
            // btnDelivery
            // 
            this.btnDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelivery.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelivery.ImageOptions.Image")));
            this.btnDelivery.ImageOptions.ImageIndex = 1;
            this.btnDelivery.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDelivery.Location = new System.Drawing.Point(419, 532);
            this.btnDelivery.Name = "btnDelivery";
            this.btnDelivery.Size = new System.Drawing.Size(75, 23);
            this.btnDelivery.TabIndex = 124;
            this.btnDelivery.Text = "&Delivery";
            this.btnDelivery.ToolTip = "Servicio de Envío";
            this.btnDelivery.Click += new System.EventHandler(this.btnDelivery_Click);
            // 
            // lblMensajePedido
            // 
            this.lblMensajePedido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMensajePedido.Appearance.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensajePedido.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMensajePedido.Appearance.Options.UseFont = true;
            this.lblMensajePedido.Appearance.Options.UseForeColor = true;
            this.lblMensajePedido.Location = new System.Drawing.Point(256, 532);
            this.lblMensajePedido.Name = "lblMensajePedido";
            this.lblMensajePedido.Size = new System.Drawing.Size(0, 13);
            this.lblMensajePedido.TabIndex = 111;
            // 
            // panelPreventa
            // 
            this.panelPreventa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelPreventa.BackColor = System.Drawing.Color.Yellow;
            this.panelPreventa.Location = new System.Drawing.Point(3, 530);
            this.panelPreventa.Name = "panelPreventa";
            this.panelPreventa.Size = new System.Drawing.Size(83, 25);
            this.panelPreventa.TabIndex = 125;
            this.panelPreventa.Visible = false;
            // 
            // btnEnviarAlmacen
            // 
            this.btnEnviarAlmacen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnviarAlmacen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviarAlmacen.ImageOptions.Image")));
            this.btnEnviarAlmacen.ImageOptions.ImageIndex = 1;
            this.btnEnviarAlmacen.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEnviarAlmacen.Location = new System.Drawing.Point(868, 531);
            this.btnEnviarAlmacen.Name = "btnEnviarAlmacen";
            this.btnEnviarAlmacen.Size = new System.Drawing.Size(116, 23);
            this.btnEnviarAlmacen.TabIndex = 2;
            this.btnEnviarAlmacen.Text = "&Enviar a Almacén";
            this.btnEnviarAlmacen.Visible = false;
            this.btnEnviarAlmacen.Click += new System.EventHandler(this.btnEnviarAlmacen_Click);
            // 
            // txtNumeroContrato
            // 
            this.txtNumeroContrato.Location = new System.Drawing.Point(677, 520);
            this.txtNumeroContrato.Name = "txtNumeroContrato";
            this.txtNumeroContrato.Properties.MaxLength = 6;
            this.txtNumeroContrato.Size = new System.Drawing.Size(83, 20);
            this.txtNumeroContrato.TabIndex = 9;
            this.txtNumeroContrato.Visible = false;
            this.txtNumeroContrato.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumeroContrato_KeyDown);
            // 
            // btnInstalacion
            // 
            this.btnInstalacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInstalacion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInstalacion.ImageOptions.Image")));
            this.btnInstalacion.ImageOptions.ImageIndex = 1;
            this.btnInstalacion.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnInstalacion.Location = new System.Drawing.Point(498, 532);
            this.btnInstalacion.Name = "btnInstalacion";
            this.btnInstalacion.Size = new System.Drawing.Size(90, 23);
            this.btnInstalacion.TabIndex = 124;
            this.btnInstalacion.Text = "&Instalación";
            this.btnInstalacion.ToolTip = "Servicio de Instalación";
            this.btnInstalacion.Click += new System.EventHandler(this.btnInstalacion_Click);
            // 
            // btnDescuentoValeMarca
            // 
            this.btnDescuentoValeMarca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDescuentoValeMarca.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.ValeMarca_16x16;
            this.btnDescuentoValeMarca.Location = new System.Drawing.Point(591, 532);
            this.btnDescuentoValeMarca.Name = "btnDescuentoValeMarca";
            this.btnDescuentoValeMarca.Size = new System.Drawing.Size(51, 23);
            this.btnDescuentoValeMarca.TabIndex = 126;
            this.btnDescuentoValeMarca.Text = "Kira";
            this.btnDescuentoValeMarca.ToolTipTitle = "Vale de Promoción";
            this.btnDescuentoValeMarca.Click += new System.EventHandler(this.btnDescuentoValeMarca_Click);
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Location = new System.Drawing.Point(728, 0);
            this.popupContainerEdit1.MenuManager = this.barManager1;
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Size = new System.Drawing.Size(100, 20);
            this.popupContainerEdit1.TabIndex = 131;
            this.popupContainerEdit1.Visible = false;
            // 
            // txtMP
            // 
            this.txtMP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMP.EditValue = "0.00";
            this.txtMP.Location = new System.Drawing.Point(729, 536);
            this.txtMP.Name = "txtMP";
            this.txtMP.Properties.DisplayFormat.FormatString = "n";
            this.txtMP.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMP.Properties.Mask.EditMask = "n";
            this.txtMP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMP.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMP.Size = new System.Drawing.Size(62, 20);
            this.txtMP.TabIndex = 134;
            this.txtMP.Visible = false;
            // 
            // labelControl30
            // 
            this.labelControl30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl30.Location = new System.Drawing.Point(651, 539);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(76, 13);
            this.labelControl30.TabIndex = 133;
            this.labelControl30.Text = "Comisión MP S/:";
            this.labelControl30.Visible = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(792, 536);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(55, 20);
            this.simpleButton1.TabIndex = 136;
            this.simpleButton1.Text = "APLICAR";
            this.simpleButton1.ToolTipTitle = "Vale de Promoción";
            this.simpleButton1.Visible = false;
            // 
            // frmRegPedidoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 560);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtMP);
            this.Controls.Add(this.labelControl30);
            this.Controls.Add(this.popupContainerEdit1);
            this.Controls.Add(this.btnDescuentoValeMarca);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEnviarAlmacen);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.lblMensajePedido);
            this.Controls.Add(this.btnInstalacion);
            this.Controls.Add(this.btnDelivery);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.gcSaldoDisponible);
            this.Controls.Add(this.txtNumeroPedido);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.chkPreventa);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.panelPreventa);
            this.Controls.Add(this.txtNumeroContrato);
            this.Controls.Add(this.labelControl27);
            this.Controls.Add(this.txtTotal2x1);
            this.Controls.Add(this.labelControl26);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Controls.Add(this.menuStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegPedidoEdit";
            this.Text = "Mantenimiento - Pedido";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegPedidoEdit_Closing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegPedidoEdit_FormClosed);
            this.Load += new System.EventHandler(this.frmRegPedidoEdit_Load);
            this.Shown += new System.EventHandler(this.frmRegPedidoEdit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalSinDscCumple.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPtFlores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotNavidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotReligioso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotRegular.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDsctoCumple.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtICBPER.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClientePromocion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDiseñador)).EndInit();
            this.gcDiseñador.ResumeLayout(false);
            this.gcDiseñador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreDiseñador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDniDiseñador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCompraPerfecta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDescuentoExtraVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatosFacturacion)).EndInit();
            this.grdDatosFacturacion.ResumeLayout(false);
            this.grdDatosFacturacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboClienteAsociado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccionAsociado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumentoAsociado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAsesor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumentoBusqueda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCombo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaVencimiento.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaVencimiento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBruto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalDscto2x1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImpuesto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservaciones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroProforma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPedidoDetalle)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPedidoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCambio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal2x1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreventa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroPedido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoDisponible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSaldoDisponible)).EndInit();
            this.gcSaldoDisponible.ResumeLayout(false);
            this.gcSaldoDisponible.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroContrato.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMP.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void FormIsClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton btnNuevoCliente;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDireccion;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.TextEdit txtTipoCambio;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboFormaPago;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.DateEdit deFecha;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.LookUpEdit cboDocumento;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        public DevExpress.XtraEditors.LookUpEdit cboVendedor;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.BindingSource bsListado;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuSelText;
        public DevExpress.XtraEditors.LookUpEdit cboCaja;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.TextEdit txtNumeroProforma;
        private DevExpress.XtraEditors.CheckEdit chkPreventa;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.MemoEdit txtObservaciones;
        private DevExpress.XtraEditors.TextEdit txtTotalCantidad;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit txtSubTotal;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtImpuesto;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        public DevExpress.XtraEditors.DateEdit deFechaVencimiento;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.TextEdit txtTipoCliente;
        private System.Windows.Forms.ToolStripMenuItem modificarprecioToolStripMenuItem;
        private DevExpress.XtraEditors.TextEdit txtNumeroPedido;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.SimpleButton btnEliminar;
        public DevExpress.XtraEditors.SimpleButton btnNuevo;
        public DevExpress.XtraEditors.SimpleButton btnEditar;
        public DevExpress.XtraEditors.LookUpEdit cboCombo;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem establecerdescuentoToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnClienteAsociado;
        public DevExpress.XtraEditors.LookUpEdit cboTipoVenta;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraGrid.GridControl gcPedidoDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPedidoDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gcPorcentajeDescuento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gcObservacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gcLineaProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        public DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.CheckEdit chkDescuentoExtraVenta;
        public DevExpress.XtraEditors.LookUpEdit cboAsesor;
        private DevExpress.XtraEditors.LabelControl lblAsesor;
        public DevExpress.XtraEditors.LookUpEdit cboClienteAsociado;
        private DevExpress.XtraEditors.LabelControl lblFacturara;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumentoAsociado;
        private DevExpress.XtraEditors.TextEdit txtDireccionAsociado;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.GroupControl grdDatosFacturacion;
        private DevExpress.XtraEditors.SimpleButton btnPromocion;
        private DevExpress.XtraEditors.LabelControl lblMensaje;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtSaldoDisponible;
        private DevExpress.XtraEditors.GroupControl gcSaldoDisponible;
        public DevExpress.XtraEditors.SimpleButton btnDelivery;
        private DevExpress.XtraEditors.SimpleButton btnEliminarCumpleanios;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.LabelControl lblMensajePedido;
        private DevExpress.XtraEditors.SimpleButton btnEliminarEncuesta;
        private System.Windows.Forms.ToolStripMenuItem establecerdescuentocerotoolStripMenuItem;
        private System.Windows.Forms.Panel panelPreventa;
        public DevExpress.XtraEditors.LookUpEdit cboClientePromocion;
        private DevExpress.XtraEditors.SimpleButton btnClientePromocion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.TextEdit txtTotalDscto2x1;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.TextEdit txtTotalBruto;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        private DevExpress.XtraEditors.TextEdit txtTotal2x1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        public DevExpress.XtraEditors.SimpleButton btnEnviarAlmacen;
        private DevExpress.XtraEditors.TextEdit txtDescuento;
        private DevExpress.XtraEditors.LabelControl labelControl26;
        private DevExpress.XtraEditors.CheckEdit chkVale;
        private DevExpress.XtraEditors.CheckEdit chkCompraPerfecta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem eliminarpromocion2x1toolStripMenuItem;
        private DevExpress.XtraEditors.TextEdit txtNumeroContrato;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraEditors.GroupControl gcDiseñador;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.TextEdit txtNombreDiseñador;
        private DevExpress.XtraEditors.TextEdit txtDniDiseñador;
        private DevExpress.XtraEditors.SimpleButton btnBuscarDiseñador;
        public DevExpress.XtraEditors.SimpleButton btnInstalacion;
        private System.Windows.Forms.Button btnEliminarVale;
        private DevExpress.XtraEditors.SimpleButton btnCargarVale;
        public DevExpress.XtraEditors.LookUpEdit cboTipoDocumentoBusqueda;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        public DevExpress.XtraEditors.SimpleButton bntVerNS;
        private System.Windows.Forms.ToolStripMenuItem descuentocupontoolStripMenuItem;
        private System.Windows.Forms.Button btnEliminarDsctoVale;
        private DevExpress.XtraEditors.SimpleButton btnDescuentoValeMarca;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private System.Windows.Forms.ToolStripMenuItem establecerpreciopublicitariotoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem utilizarprecioucayalitoolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl lblIdPedido;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraEditors.TextEdit txtICBPER;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtMP;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraEditors.LabelControl lblDsctoCumple;
        private DevExpress.XtraEditors.TextEdit txtDsctoCumple;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtCodigo;
        private DevExpress.XtraEditors.TextEdit txtTotNavidad;
        private DevExpress.XtraEditors.LabelControl lblTotNavidad;
        private DevExpress.XtraEditors.TextEdit txtTotReligioso;
        private DevExpress.XtraEditors.LabelControl lblTotReligioso;
        private DevExpress.XtraEditors.TextEdit txtTotRegular;
        private DevExpress.XtraEditors.LabelControl lblTotRegular;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraEditors.CheckEdit chkPtFlores;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraEditors.LabelControl lblTotalSinDscCumple;
        private DevExpress.XtraEditors.TextEdit txtTotalSinDscCumple;
        public DevExpress.XtraEditors.SimpleButton btnKiraEliminar;
        public DevExpress.XtraEditors.SimpleButton btnKira2;
        public DevExpress.XtraEditors.SimpleButton btnKira1;
        private CheckBox chkIngresoMayorista;
        private Button btn_Mayorista;
    }
}