namespace ErpPanorama.Presentation.Modulos.Creditos.Consultas
{
    partial class frmConSeparacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConSeparacion));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSaldo = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalAbono = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalCargo = new DevExpress.XtraEditors.TextEdit();
            this.gcEstadoCuenta = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.VerDocumentoVentatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verpedidotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvEstadoCuenta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.txtTipoCliente = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescCliente = new DevExpress.XtraEditors.TextEdit();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAbono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCargo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEstadoCuenta)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEstadoCuenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(652, 494);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 13);
            this.labelControl1.TabIndex = 71;
            this.labelControl1.Text = "TOTALES:";
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSaldo.EditValue = "0.00";
            this.txtSaldo.Location = new System.Drawing.Point(871, 491);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Properties.Appearance.Options.UseFont = true;
            this.txtSaldo.Properties.DisplayFormat.FormatString = "n";
            this.txtSaldo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldo.Properties.Mask.EditMask = "n";
            this.txtSaldo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaldo.Properties.ReadOnly = true;
            this.txtSaldo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSaldo.Size = new System.Drawing.Size(70, 20);
            this.txtSaldo.TabIndex = 70;
            // 
            // txtTotalAbono
            // 
            this.txtTotalAbono.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalAbono.EditValue = "0.00";
            this.txtTotalAbono.Location = new System.Drawing.Point(795, 491);
            this.txtTotalAbono.Name = "txtTotalAbono";
            this.txtTotalAbono.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalAbono.Properties.Appearance.Options.UseFont = true;
            this.txtTotalAbono.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalAbono.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalAbono.Properties.Mask.EditMask = "n";
            this.txtTotalAbono.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalAbono.Properties.ReadOnly = true;
            this.txtTotalAbono.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalAbono.Size = new System.Drawing.Size(70, 20);
            this.txtTotalAbono.TabIndex = 69;
            // 
            // txtTotalCargo
            // 
            this.txtTotalCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotalCargo.EditValue = "0.00";
            this.txtTotalCargo.Location = new System.Drawing.Point(719, 491);
            this.txtTotalCargo.Name = "txtTotalCargo";
            this.txtTotalCargo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCargo.Properties.Appearance.Options.UseFont = true;
            this.txtTotalCargo.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalCargo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalCargo.Properties.Mask.EditMask = "n";
            this.txtTotalCargo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalCargo.Properties.ReadOnly = true;
            this.txtTotalCargo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalCargo.Size = new System.Drawing.Size(70, 20);
            this.txtTotalCargo.TabIndex = 68;
            // 
            // gcEstadoCuenta
            // 
            this.gcEstadoCuenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcEstadoCuenta.ContextMenuStrip = this.mnuContextual;
            this.gcEstadoCuenta.Location = new System.Drawing.Point(0, 103);
            this.gcEstadoCuenta.MainView = this.gvEstadoCuenta;
            this.gcEstadoCuenta.Name = "gcEstadoCuenta";
            this.gcEstadoCuenta.Size = new System.Drawing.Size(1230, 383);
            this.gcEstadoCuenta.TabIndex = 67;
            this.gcEstadoCuenta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEstadoCuenta});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VerDocumentoVentatoolStripMenuItem,
            this.verpedidotoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(189, 48);
            // 
            // VerDocumentoVentatoolStripMenuItem
            // 
            this.VerDocumentoVentatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultas_16x16;
            this.VerDocumentoVentatoolStripMenuItem.Name = "VerDocumentoVentatoolStripMenuItem";
            this.VerDocumentoVentatoolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.VerDocumentoVentatoolStripMenuItem.Text = "Ver Documento Venta";
            this.VerDocumentoVentatoolStripMenuItem.Click += new System.EventHandler(this.VerDocumentoVentatoolStripMenuItem_Click);
            // 
            // verpedidotoolStripMenuItem
            // 
            this.verpedidotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultas_16x16;
            this.verpedidotoolStripMenuItem.Name = "verpedidotoolStripMenuItem";
            this.verpedidotoolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.verpedidotoolStripMenuItem.Text = "Ver Pedido";
            this.verpedidotoolStripMenuItem.Click += new System.EventHandler(this.verpedidotoolStripMenuItem_Click);
            // 
            // gvEstadoCuenta
            // 
            this.gvEstadoCuenta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14});
            this.gvEstadoCuenta.GridControl = this.gcEstadoCuenta;
            this.gvEstadoCuenta.GroupPanelText = "Resultado de la Busqueda";
            this.gvEstadoCuenta.Name = "gvEstadoCuenta";
            this.gvEstadoCuenta.OptionsView.ColumnAutoWidth = false;
            this.gvEstadoCuenta.OptionsView.ShowGroupPanel = false;
            this.gvEstadoCuenta.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvEstadoCuenta_RowStyle);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "N° Documento";
            this.gridColumn2.FieldName = "NumeroDocumento";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 80;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "F. Separación";
            this.gridColumn3.FieldName = "FechaSeparacion";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "F. Pago";
            this.gridColumn10.FieldName = "FechaPago";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
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
            this.gridColumn9.VisibleIndex = 3;
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
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 380;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Cargo S/";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Cargo";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Abono S/";
            this.gridColumn1.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "Abono";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Saldo S/";
            this.gridColumn5.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "Saldo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdPedido";
            this.gridColumn6.FieldName = "IdPedido";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ingresado Por";
            this.gridColumn7.FieldName = "Usuario";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            this.gridColumn7.Width = 125;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Origen";
            this.gridColumn11.FieldName = "Origen";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Auditado";
            this.gridColumn12.FieldName = "FlagAuditado";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            this.gridColumn12.Width = 52;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "IdDocumentoVenta";
            this.gridColumn13.FieldName = "IdDocumentoVenta";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "IdCliente";
            this.gridColumn14.FieldName = "IdCliente";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.deHasta);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.deDesde);
            this.groupControl1.Controls.Add(this.cboMotivo);
            this.groupControl1.Controls.Add(this.labelControl21);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.txtTipoCliente);
            this.groupControl1.Controls.Add(this.btnBuscar);
            this.groupControl1.Controls.Add(this.txtDescCliente);
            this.groupControl1.Controls.Add(this.txtNumeroDocumento);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 25);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1230, 76);
            this.groupControl1.TabIndex = 65;
            this.groupControl1.Text = "Criterios de Búsqueda";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(7, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 91;
            this.labelControl2.Text = "Desde:";
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(172, 25);
            this.deHasta.Name = "deHasta";
            this.deHasta.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deHasta.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.deHasta.Properties.ShowPopupShadow = false;
            this.deHasta.Properties.ShowToday = false;
            this.deHasta.Size = new System.Drawing.Size(80, 20);
            this.deHasta.TabIndex = 94;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(134, 28);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 93;
            this.labelControl3.Text = "Hasta:";
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(48, 25);
            this.deDesde.Name = "deDesde";
            this.deDesde.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deDesde.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.deDesde.Properties.ShowPopupShadow = false;
            this.deDesde.Properties.ShowToday = false;
            this.deDesde.Size = new System.Drawing.Size(80, 20);
            this.deDesde.TabIndex = 92;
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(805, 25);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Properties.NullText = "";
            this.cboMotivo.Size = new System.Drawing.Size(123, 20);
            this.cboMotivo.TabIndex = 90;
            this.cboMotivo.EditValueChanged += new System.EventHandler(this.cboMotivo_EditValueChanged);
            // 
            // labelControl21
            // 
            this.labelControl21.Location = new System.Drawing.Point(763, 27);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(36, 13);
            this.labelControl21.TabIndex = 89;
            this.labelControl21.Text = "Motivo:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(934, 24);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 82;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtTipoCliente
            // 
            this.txtTipoCliente.Location = new System.Drawing.Point(758, 51);
            this.txtTipoCliente.Name = "txtTipoCliente";
            this.txtTipoCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTipoCliente.Properties.MaxLength = 100;
            this.txtTipoCliente.Properties.ReadOnly = true;
            this.txtTipoCliente.Size = new System.Drawing.Size(170, 20);
            this.txtTipoCliente.TabIndex = 81;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(374, 24);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(26, 20);
            this.btnBuscar.TabIndex = 79;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescCliente
            // 
            this.txtDescCliente.Location = new System.Drawing.Point(406, 24);
            this.txtDescCliente.Name = "txtDescCliente";
            this.txtDescCliente.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescCliente.Properties.MaxLength = 50;
            this.txtDescCliente.Size = new System.Drawing.Size(351, 20);
            this.txtDescCliente.TabIndex = 80;
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(269, 24);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 15;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(99, 20);
            this.txtNumeroDocumento.TabIndex = 78;
            this.txtNumeroDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstpImprimir,
            this.toolStripSeparator3,
            this.toolstpExportarExcel,
            this.toolStripSeparator1,
            this.toolstpRefrescar,
            this.toolStripSeparator2,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1230, 25);
            this.toolStrip1.TabIndex = 64;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstpImprimir
            // 
            this.toolstpImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpImprimir.Image = ((System.Drawing.Image)(resources.GetObject("toolstpImprimir.Image")));
            this.toolstpImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpImprimir.Name = "toolstpImprimir";
            this.toolstpImprimir.Size = new System.Drawing.Size(23, 22);
            this.toolstpImprimir.ToolTipText = "Imprimir Estado de Cuenta";
            this.toolstpImprimir.Click += new System.EventHandler(this.toolstpImprimir_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpExportarExcel
            // 
            this.toolstpExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolstpExportarExcel.Image")));
            this.toolstpExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExportarExcel.Name = "toolstpExportarExcel";
            this.toolstpExportarExcel.Size = new System.Drawing.Size(23, 22);
            this.toolstpExportarExcel.ToolTipText = "Exportar Excel";
            this.toolstpExportarExcel.Click += new System.EventHandler(this.toolstpExportarExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpRefrescar
            // 
            this.toolstpRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("toolstpRefrescar.Image")));
            this.toolstpRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpRefrescar.Name = "toolstpRefrescar";
            this.toolstpRefrescar.Size = new System.Drawing.Size(23, 22);
            this.toolstpRefrescar.ToolTipText = "Actualizar";
            this.toolstpRefrescar.Click += new System.EventHandler(this.toolstpRefrescar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpSalir
            // 
            this.toolstpSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolstpSalir.Image")));
            this.toolstpSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpSalir.Name = "toolstpSalir";
            this.toolstpSalir.Size = new System.Drawing.Size(23, 22);
            this.toolstpSalir.ToolTipText = "Salir";
            this.toolstpSalir.Click += new System.EventHandler(this.toolstpSalir_Click);
            // 
            // frmConSeparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 513);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtSaldo);
            this.Controls.Add(this.txtTotalAbono);
            this.Controls.Add(this.txtTotalCargo);
            this.Controls.Add(this.gcEstadoCuenta);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmConSeparacion";
            this.Text = "Consulta de Separación";
            this.Load += new System.EventHandler(this.frmConSeparacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalAbono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCargo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEstadoCuenta)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvEstadoCuenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSaldo;
        private DevExpress.XtraEditors.TextEdit txtTotalAbono;
        private DevExpress.XtraEditors.TextEdit txtTotalCargo;
        private DevExpress.XtraGrid.GridControl gcEstadoCuenta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEstadoCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.TextEdit txtTipoCliente;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescCliente;
        private DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstpImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolstpExportarExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolstpRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        public DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem VerDocumentoVentatoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verpedidotoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
    }
}