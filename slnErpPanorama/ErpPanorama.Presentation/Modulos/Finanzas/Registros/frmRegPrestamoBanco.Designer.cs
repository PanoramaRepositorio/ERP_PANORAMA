namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    partial class frmRegPrestamoBanco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPrestamoBanco));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gcPrestamoBanco = new DevExpress.XtraGrid.GridControl();
            this.gvPrestamoBanco = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblTotalRegistros = new System.Windows.Forms.Label();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcPrestamoBancoDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvPrestamoBancoDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboSituacion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcPrestamoBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrestamoBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcPrestamoBancoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrestamoBancoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Margin = new System.Windows.Forms.Padding(4);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1314, 67);
            this.tlbMenu.TabIndex = 49;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tblMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // gcPrestamoBanco
            // 
            this.gcPrestamoBanco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcPrestamoBanco.Location = new System.Drawing.Point(3, 0);
            this.gcPrestamoBanco.MainView = this.gvPrestamoBanco;
            this.gcPrestamoBanco.Name = "gcPrestamoBanco";
            this.gcPrestamoBanco.Size = new System.Drawing.Size(1306, 288);
            this.gcPrestamoBanco.TabIndex = 50;
            this.gcPrestamoBanco.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPrestamoBanco});
            // 
            // gvPrestamoBanco
            // 
            this.gvPrestamoBanco.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn16,
            this.gridColumn18,
            this.gridColumn17,
            this.gridColumn19,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38});
            this.gvPrestamoBanco.GridControl = this.gcPrestamoBanco;
            this.gvPrestamoBanco.Name = "gvPrestamoBanco";
            this.gvPrestamoBanco.OptionsSelection.MultiSelect = true;
            this.gvPrestamoBanco.OptionsView.ColumnAutoWidth = false;
            this.gvPrestamoBanco.OptionsView.ShowFooter = true;
            this.gvPrestamoBanco.OptionsView.ShowGroupPanel = false;
            this.gvPrestamoBanco.OptionsView.ShowViewCaption = true;
            this.gvPrestamoBanco.ViewCaption = "PRESTAMOS";
            this.gvPrestamoBanco.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvPrestamoBanco_RowClick);
            this.gvPrestamoBanco.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvPrestamoBanco_RowStyle);
            this.gvPrestamoBanco.DoubleClick += new System.EventHandler(this.gvPrestamoBanco_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdPrestamoBanco";
            this.gridColumn1.FieldName = "IdPrestamoBanco";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdEmpresa";
            this.gridColumn2.FieldName = "IdEmpresa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdCuentaBanco";
            this.gridColumn3.FieldName = "IdCuentaBanco";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "N° Préstamo";
            this.gridColumn4.FieldName = "NumeroPrestamo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 149;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Banco";
            this.gridColumn16.FieldName = "DescBanco";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 0;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Moneda";
            this.gridColumn18.FieldName = "DescMoneda";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 4;
            this.gridColumn18.Width = 50;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Titular";
            this.gridColumn17.FieldName = "Titular";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 13;
            this.gridColumn17.Width = 154;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Número Cuenta";
            this.gridColumn19.FieldName = "NumeroCuenta";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Width = 123;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Cuenta Cargo";
            this.gridColumn5.FieldName = "CuentaCargo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 163;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Fecha";
            this.gridColumn6.FieldName = "Fecha";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "F. Vencimiento";
            this.gridColumn7.FieldName = "FechaVencimiento";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Prestamo";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Prestamo";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Prestamo", "{0:#,0.00}")});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "SaldoPrestamo";
            this.gridColumn9.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "SaldoPrestamo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaldoPrestamo", "{0:#,0.00}")});
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "SaldoInteres";
            this.gridColumn10.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "SaldoInteres";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaldoInteres", "{0:#,0.00}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "TotalInteres";
            this.gridColumn11.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "TotalInteres";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalInteres", "{0:#,0.00}")});
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdMoneda";
            this.gridColumn12.FieldName = "IdMoneda";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "TEA";
            this.gridColumn13.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "TEA";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 43;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Tasa int Moratorio";
            this.gridColumn14.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "TasaIntMoratorio";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "FlagEstado";
            this.gridColumn15.FieldName = "FlagEstado";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "Línea Crédito";
            this.gridColumn36.FieldName = "LineaCredito";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowEdit = false;
            this.gridColumn36.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Tipo Préstamo";
            this.gridColumn37.FieldName = "DescTipoPrestamo";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.OptionsColumn.AllowFocus = false;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 1;
            this.gridColumn37.Width = 97;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistros.AutoSize = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(36, 265);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(61, 13);
            this.lblTotalRegistros.TabIndex = 51;
            this.lblTotalRegistros.Text = "0 Registros";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 30);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.lblTotalRegistros);
            this.splitContainerControl1.Panel1.Controls.Add(this.gcPrestamoBanco);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcPrestamoBancoDetalle);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1312, 585);
            this.splitContainerControl1.SplitterPosition = 293;
            this.splitContainerControl1.TabIndex = 52;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcPrestamoBancoDetalle
            // 
            this.gcPrestamoBancoDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcPrestamoBancoDetalle.Location = new System.Drawing.Point(3, 1);
            this.gcPrestamoBancoDetalle.MainView = this.gvPrestamoBancoDetalle;
            this.gcPrestamoBancoDetalle.Name = "gcPrestamoBancoDetalle";
            this.gcPrestamoBancoDetalle.Size = new System.Drawing.Size(1306, 285);
            this.gcPrestamoBancoDetalle.TabIndex = 51;
            this.gcPrestamoBancoDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPrestamoBancoDetalle});
            // 
            // gvPrestamoBancoDetalle
            // 
            this.gvPrestamoBancoDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn27,
            this.gridColumn26,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn31});
            this.gvPrestamoBancoDetalle.GridControl = this.gcPrestamoBancoDetalle;
            this.gvPrestamoBancoDetalle.Name = "gvPrestamoBancoDetalle";
            this.gvPrestamoBancoDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvPrestamoBancoDetalle.OptionsView.ShowFooter = true;
            this.gvPrestamoBancoDetalle.OptionsView.ShowGroupPanel = false;
            this.gvPrestamoBancoDetalle.OptionsView.ShowViewCaption = true;
            this.gvPrestamoBancoDetalle.ViewCaption = "DETALLE";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "IdPrestamoBancoDetalle";
            this.gridColumn20.FieldName = "IdPrestamoBancoDetalle";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "IdPrestamoBanco";
            this.gridColumn21.FieldName = "IdPrestamoBanco";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "N° Cuota";
            this.gridColumn22.FieldName = "NumeroCuota";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 0;
            this.gridColumn22.Width = 88;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "F. Vencimiento";
            this.gridColumn23.FieldName = "FechaVencimiento";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 1;
            this.gridColumn23.Width = 102;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Saldo Pendiente";
            this.gridColumn24.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn24.FieldName = "SaldoPendiente";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 2;
            this.gridColumn24.Width = 102;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Amortización";
            this.gridColumn25.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn25.FieldName = "Amortizacion";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            this.gridColumn25.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amortizacion", "{0:#,0.00}")});
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 3;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Interés";
            this.gridColumn27.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn27.FieldName = "Interes";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.OptionsColumn.AllowFocus = false;
            this.gridColumn27.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Interes", "{0:#,0.00}")});
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 5;
            this.gridColumn27.Width = 121;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Envío Información";
            this.gridColumn26.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn26.FieldName = "EnvioInformacion";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.AllowFocus = false;
            this.gridColumn26.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "EnvioInformacion", "{0:#,0.00}")});
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 4;
            this.gridColumn26.Width = 123;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Desgravamen";
            this.gridColumn28.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn28.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn28.FieldName = "Desgravamen";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.AllowFocus = false;
            this.gridColumn28.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Desgravamen", "{0:#,0.00}")});
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 6;
            this.gridColumn28.Width = 89;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Interes Moratorio";
            this.gridColumn29.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn29.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn29.FieldName = "Seguro";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsColumn.AllowFocus = false;
            this.gridColumn29.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Seguro", "{0:#,0.00}")});
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 7;
            this.gridColumn29.Width = 100;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "Total Pagar";
            this.gridColumn30.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn30.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn30.FieldName = "TotalPagar";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.OptionsColumn.AllowFocus = false;
            this.gridColumn30.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPagar", "{0:#,0.00}")});
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 8;
            this.gridColumn30.Width = 114;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "IdSituacion";
            this.gridColumn32.FieldName = "IdSituacion";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowEdit = false;
            this.gridColumn32.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Situación";
            this.gridColumn33.FieldName = "DescSituacion";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowFocus = false;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 9;
            // 
            // gridColumn34
            // 
            this.gridColumn34.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.gridColumn34.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn34.Caption = "F. Pago";
            this.gridColumn34.DisplayFormat.FormatString = "d";
            this.gridColumn34.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn34.FieldName = "FechaPago";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.OptionsColumn.AllowFocus = false;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 10;
            // 
            // gridColumn35
            // 
            this.gridColumn35.AppearanceCell.ForeColor = System.Drawing.Color.Gray;
            this.gridColumn35.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn35.Caption = "Usuario Pago";
            this.gridColumn35.FieldName = "UsuarioPago";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.OptionsColumn.AllowFocus = false;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 11;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "FlagEstado";
            this.gridColumn31.FieldName = "FlagEstado";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.OptionsColumn.AllowFocus = false;
            // 
            // cboSituacion
            // 
            this.cboSituacion.Location = new System.Drawing.Point(824, 4);
            this.cboSituacion.Name = "cboSituacion";
            this.cboSituacion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboSituacion.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cboSituacion.Properties.Appearance.Options.UseFont = true;
            this.cboSituacion.Properties.Appearance.Options.UseForeColor = true;
            this.cboSituacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSituacion.Properties.NullText = "";
            this.cboSituacion.Size = new System.Drawing.Size(153, 20);
            this.cboSituacion.TabIndex = 96;
            this.cboSituacion.EditValueChanged += new System.EventHandler(this.cboSituacion_EditValueChanged);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(771, 7);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(47, 13);
            this.labelControl12.TabIndex = 95;
            this.labelControl12.Text = "Situación:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(983, 4);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 94;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gridColumn38
            // 
            this.gridColumn38.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn38.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn38.Caption = "Obs";
            this.gridColumn38.FieldName = "Observacion";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowEdit = false;
            this.gridColumn38.OptionsColumn.AllowFocus = false;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 14;
            // 
            // frmRegPrestamoBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 615);
            this.Controls.Add(this.cboSituacion);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegPrestamoBanco";
            this.Text = "Préstamo Banco - Mantenimiento";
            this.Load += new System.EventHandler(this.frmRegPrestamoBanco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcPrestamoBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrestamoBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcPrestamoBancoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPrestamoBancoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.GridControl gcPrestamoBanco;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPrestamoBanco;
        private System.Windows.Forms.Label lblTotalRegistros;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcPrestamoBancoDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPrestamoBancoDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        public DevExpress.XtraEditors.LookUpEdit cboSituacion;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
    }
}