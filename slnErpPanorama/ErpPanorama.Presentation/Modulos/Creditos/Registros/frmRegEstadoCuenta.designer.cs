namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    partial class frmRegEstadoCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegEstadoCuenta));
            this.gcEstadoCuenta = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VerDocumentoVentatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imprimircomprobantetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvEstadoCuenta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtTipoCliente = new DevExpress.XtraEditors.TextEdit();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.btnPago = new DevExpress.XtraEditors.SimpleButton();
            this.btnCredito = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcEstadoCuenta)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEstadoCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcEstadoCuenta
            // 
            this.gcEstadoCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcEstadoCuenta.ContextMenuStrip = this.mnuContextual;
            this.gcEstadoCuenta.Location = new System.Drawing.Point(0, 109);
            this.gcEstadoCuenta.MainView = this.gvEstadoCuenta;
            this.gcEstadoCuenta.Name = "gcEstadoCuenta";
            this.gcEstadoCuenta.Size = new System.Drawing.Size(950, 412);
            this.gcEstadoCuenta.TabIndex = 25;
            this.gcEstadoCuenta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEstadoCuenta});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerDocumentoVentatoolStripMenuItem,
            this.imprimircomprobantetoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(242, 48);
            // 
            // VerDocumentoVentatoolStripMenuItem
            // 
            this.VerDocumentoVentatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultas_16x16;
            this.VerDocumentoVentatoolStripMenuItem.Name = "VerDocumentoVentatoolStripMenuItem";
            this.VerDocumentoVentatoolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.VerDocumentoVentatoolStripMenuItem.Text = "Ver Documento Venta";
            this.VerDocumentoVentatoolStripMenuItem.Click += new System.EventHandler(this.VerDocumentoVentatoolStripMenuItem_Click);
            // 
            // imprimircomprobantetoolStripMenuItem
            // 
            this.imprimircomprobantetoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimircomprobantetoolStripMenuItem.Image")));
            this.imprimircomprobantetoolStripMenuItem.Name = "imprimircomprobantetoolStripMenuItem";
            this.imprimircomprobantetoolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.imprimircomprobantetoolStripMenuItem.Text = "Imprimir Comprobante - Banco";
            this.imprimircomprobantetoolStripMenuItem.Click += new System.EventHandler(this.imprimircomprobantetoolStripMenuItem_Click);
            // 
            // gvEstadoCuenta
            // 
            this.gvEstadoCuenta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn11,
            this.gridColumn12});
            this.gvEstadoCuenta.GridControl = this.gcEstadoCuenta;
            this.gvEstadoCuenta.GroupPanelText = "Resultado de la Busqueda";
            this.gvEstadoCuenta.Name = "gvEstadoCuenta";
            this.gvEstadoCuenta.OptionsView.ColumnAutoWidth = false;
            this.gvEstadoCuenta.OptionsView.ShowGroupPanel = false;
            this.gvEstadoCuenta.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvEstadoCuenta_RowStyle);
            this.gvEstadoCuenta.DoubleClick += new System.EventHandler(this.gvEstadoCuenta_DoubleClick);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdEmpresa";
            this.gridColumn5.FieldName = "IdEmpresa";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "N° Correlativo";
            this.gridColumn6.FieldName = "IdEstadoCuenta";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 80;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Periodo";
            this.gridColumn1.FieldName = "Periodo";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Width = 70;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° Documento";
            this.gridColumn2.FieldName = "NumeroDocumento";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "F. Crédito";
            this.gridColumn3.FieldName = "FechaCredito";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "F. Depósito";
            this.gridColumn10.FieldName = "FechaDeposito";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 80;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "F. Vencimiento";
            this.gridColumn9.FieldName = "FechaVencimiento";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 85;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Concepto";
            this.gridColumn4.FieldName = "Concepto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 374;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Importe US$";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Importe";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 90;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tipo";
            this.gridColumn7.FieldName = "TipoMovimiento";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 60;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdPedido";
            this.gridColumn11.FieldName = "IdPedido";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdCuentaBancoDetalle";
            this.gridColumn12.FieldName = "IdCuentaBancoDetalle";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboMotivo);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Controls.Add(this.txtDescCliente);
            this.groupControl1.Controls.Add(this.txtNumeroDocumento);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(950, 52);
            this.groupControl1.TabIndex = 24;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(623, 24);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cboMotivo.Properties.Appearance.Options.UseForeColor = true;
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Properties.NullText = "";
            this.cboMotivo.Size = new System.Drawing.Size(123, 20);
            this.cboMotivo.TabIndex = 83;
            this.cboMotivo.EditValueChanged += new System.EventHandler(this.cboMotivo_EditValueChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(752, 24);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 78;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(579, 27);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(36, 13);
            this.labelControl21.TabIndex = 82;
            this.labelControl21.Text = "Motivo:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(160, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 75;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(192, 24);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Size = new System.Drawing.Size(378, 20);
            this.txtDescCliente.TabIndex = 76;
            this.txtDescCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescCliente_KeyUp);
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(55, 24);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(99, 20);
            this.txtNumeroDocumento.TabIndex = 74;
            this.txtNumeroDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyUp);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 73;
            this.labelControl5.Text = "Cliente:";
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Location = new System.Drawing.Point(741, 82);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoCliente.Properties.MaxLength = 100;
            this.txtTipoCliente.Properties.ReadOnly = true;
            this.txtTipoCliente.Size = new System.Drawing.Size(170, 20);
            this.txtTipoCliente.TabIndex = 77;
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(950, 24);
            this.tlbMenu.TabIndex = 23;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // btnPago
            // 
            this.btnPago.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPago.ImageOptions.Image")));
            this.btnPago.Location = new System.Drawing.Point(8, 80);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(83, 23);
            this.btnPago.TabIndex = 79;
            this.btnPago.Text = "Pago";
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // btnCredito
            // 
            this.btnCredito.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Add_16x16;
            this.btnCredito.Location = new System.Drawing.Point(97, 80);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(76, 23);
            this.btnCredito.TabIndex = 80;
            this.btnCredito.Text = "Cargo";
            this.btnCredito.Click += new System.EventHandler(this.btnCredito_Click);
            // 
            // frmRegEstadoCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 521);
            this.Controls.Add(this.txtTipoCliente);
            this.Controls.Add(this.btnCredito);
            this.Controls.Add(this.btnPago);
            this.Controls.Add(this.gcEstadoCuenta);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegEstadoCuenta";
            this.Text = "Estado de Cuenta";
            this.Load += new System.EventHandler(this.frmRegEstadoCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcEstadoCuenta)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvEstadoCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcEstadoCuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEstadoCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.TextEdit txtTipoCliente;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.SimpleButton btnPago;
        private DevExpress.XtraEditors.SimpleButton btnCredito;
        public DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem VerDocumentoVentatoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.ToolStripMenuItem imprimircomprobantetoolStripMenuItem;
    }
}