namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    partial class frmRegConConsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegConConsumo));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.gcDocumento = new DevExpress.XtraGrid.GridControl();
            this.gvDocumento = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumento)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1301, 24);
            this.tlbMenu.TabIndex = 64;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.prgFactura);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.deHasta);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.deDesde);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1301, 35);
            this.panel1.TabIndex = 65;
            // 
            // prgFactura
            // 
            this.prgFactura.Location = new System.Drawing.Point(613, 6);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(201, 21);
            this.prgFactura.TabIndex = 66;
            this.prgFactura.Visible = false;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(277, 7);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Desde:";
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(191, 7);
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
            this.deHasta.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(153, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Hasta:";
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(53, 7);
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
            this.deDesde.TabIndex = 9;
            // 
            // gcDocumento
            // 
            this.gcDocumento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDocumento.Location = new System.Drawing.Point(0, 59);
            this.gcDocumento.MainView = this.gvDocumento;
            this.gcDocumento.Name = "gcDocumento";
            this.gcDocumento.Size = new System.Drawing.Size(1301, 477);
            this.gcDocumento.TabIndex = 66;
            this.gcDocumento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDocumento});
            // 
            // gvDocumento
            // 
            this.gvDocumento.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
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
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn22,
            this.gridColumn23,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28,
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31,
            this.gridColumn32,
            this.gridColumn33,
            this.gridColumn34,
            this.gridColumn35,
            this.gridColumn36,
            this.gridColumn37,
            this.gridColumn38,
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41});
            this.gvDocumento.GridControl = this.gcDocumento;
            this.gvDocumento.Name = "gvDocumento";
            this.gvDocumento.OptionsSelection.MultiSelect = true;
            this.gvDocumento.OptionsView.ColumnAutoWidth = false;
            this.gvDocumento.OptionsView.ShowGroupPanel = false;
            this.gvDocumento.DoubleClick += new System.EventHandler(this.gvDocumento_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdConConsumo";
            this.gridColumn1.FieldName = "IdConConsumo";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "RazonSocial";
            this.gridColumn2.FieldName = "RazonSocial";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Periodo";
            this.gridColumn3.FieldName = "Periodo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tienda";
            this.gridColumn4.FieldName = "DescTienda";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Area";
            this.gridColumn5.FieldName = "DescArea";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Cuo";
            this.gridColumn6.FieldName = "Cuo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "N° Cuo";
            this.gridColumn7.FieldName = "NumeroCuo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Fecha";
            this.gridColumn8.FieldName = "Fecha";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "F. Vencimiento";
            this.gridColumn9.FieldName = "FechaVencimiento";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tipo CP";
            this.gridColumn10.FieldName = "IdConTipoComprobantePago";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 8;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Serie CP";
            this.gridColumn11.FieldName = "Serie";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 9;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "PeriodoDua";
            this.gridColumn12.FieldName = "PeriodoDua";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 10;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Número";
            this.gridColumn13.FieldName = "Numero";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "N° Inicial";
            this.gridColumn14.FieldName = "NumeroInicial";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 12;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Tipo D.I.";
            this.gridColumn15.FieldName = "IdTipoDocumento";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 13;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "N° Documento";
            this.gridColumn16.FieldName = "NumeroDocumento";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 14;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Proveedor";
            this.gridColumn17.FieldName = "DescProveedor";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 15;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Código";
            this.gridColumn18.FieldName = "IdConPlanContable";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 16;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Detalle";
            this.gridColumn19.FieldName = "DescConPlanContable";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 17;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Base Imponible";
            this.gridColumn20.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn20.FieldName = "BaseImponible";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 18;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "IGV";
            this.gridColumn21.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn21.FieldName = "Igv";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 19;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "BaseImponible2";
            this.gridColumn22.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn22.FieldName = "BaseImponible2";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.OptionsColumn.AllowEdit = false;
            this.gridColumn22.OptionsColumn.AllowFocus = false;
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 20;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "IGV2";
            this.gridColumn23.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn23.FieldName = "Igv2";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 21;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "BaseImponibleSCF";
            this.gridColumn24.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn24.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn24.FieldName = "BaseImponibleSCF";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 22;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IGV SCF";
            this.gridColumn25.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn25.FieldName = "IgvSCF";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 23;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "ImporteANG";
            this.gridColumn26.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn26.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn26.FieldName = "ImporteANG";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.OptionsColumn.AllowEdit = false;
            this.gridColumn26.OptionsColumn.AllowFocus = false;
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 24;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "ISC";
            this.gridColumn27.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn27.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn27.FieldName = "Isc";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.OptionsColumn.AllowEdit = false;
            this.gridColumn27.OptionsColumn.AllowFocus = false;
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 25;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Otro Cargo";
            this.gridColumn28.FieldName = "OtroCargo";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.OptionsColumn.AllowEdit = false;
            this.gridColumn28.OptionsColumn.AllowFocus = false;
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 26;
            // 
            // gridColumn29
            // 
            this.gridColumn29.Caption = "Importe";
            this.gridColumn29.FieldName = "Importe";
            this.gridColumn29.Name = "gridColumn29";
            this.gridColumn29.OptionsColumn.AllowEdit = false;
            this.gridColumn29.OptionsColumn.AllowFocus = false;
            this.gridColumn29.Visible = true;
            this.gridColumn29.VisibleIndex = 27;
            // 
            // gridColumn30
            // 
            this.gridColumn30.Caption = "T.C.";
            this.gridColumn30.FieldName = "TipoCambio";
            this.gridColumn30.Name = "gridColumn30";
            this.gridColumn30.OptionsColumn.AllowEdit = false;
            this.gridColumn30.OptionsColumn.AllowFocus = false;
            this.gridColumn30.Visible = true;
            this.gridColumn30.VisibleIndex = 28;
            // 
            // gridColumn31
            // 
            this.gridColumn31.Caption = "Importe US$";
            this.gridColumn31.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn31.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn31.FieldName = "ImporteDolares";
            this.gridColumn31.Name = "gridColumn31";
            this.gridColumn31.OptionsColumn.AllowEdit = false;
            this.gridColumn31.OptionsColumn.AllowFocus = false;
            this.gridColumn31.Visible = true;
            this.gridColumn31.VisibleIndex = 29;
            // 
            // gridColumn32
            // 
            this.gridColumn32.Caption = "F. Referencia";
            this.gridColumn32.FieldName = "FechaReferencia";
            this.gridColumn32.Name = "gridColumn32";
            this.gridColumn32.OptionsColumn.AllowEdit = false;
            this.gridColumn32.OptionsColumn.AllowFocus = false;
            this.gridColumn32.Visible = true;
            this.gridColumn32.VisibleIndex = 30;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Tipo CP ref.";
            this.gridColumn33.FieldName = "IdConTipoComprobantePagoReferencia";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowFocus = false;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 31;
            // 
            // gridColumn34
            // 
            this.gridColumn34.Caption = "Serie Ref.";
            this.gridColumn34.FieldName = "SerieReferencia";
            this.gridColumn34.Name = "gridColumn34";
            this.gridColumn34.OptionsColumn.AllowEdit = false;
            this.gridColumn34.OptionsColumn.AllowFocus = false;
            this.gridColumn34.Visible = true;
            this.gridColumn34.VisibleIndex = 32;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Cda";
            this.gridColumn35.FieldName = "Cda";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.OptionsColumn.AllowFocus = false;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 33;
            // 
            // gridColumn36
            // 
            this.gridColumn36.Caption = "N° CP Ref.";
            this.gridColumn36.FieldName = "NumeroReferencia";
            this.gridColumn36.Name = "gridColumn36";
            this.gridColumn36.OptionsColumn.AllowEdit = false;
            this.gridColumn36.OptionsColumn.AllowFocus = false;
            this.gridColumn36.Visible = true;
            this.gridColumn36.VisibleIndex = 34;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "F. Depósito";
            this.gridColumn37.FieldName = "FechaDeposito";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.OptionsColumn.AllowFocus = false;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 35;
            // 
            // gridColumn38
            // 
            this.gridColumn38.Caption = "N° Deposito";
            this.gridColumn38.FieldName = "NumeroDeposito";
            this.gridColumn38.Name = "gridColumn38";
            this.gridColumn38.OptionsColumn.AllowEdit = false;
            this.gridColumn38.OptionsColumn.AllowFocus = false;
            this.gridColumn38.Visible = true;
            this.gridColumn38.VisibleIndex = 36;
            // 
            // gridColumn39
            // 
            this.gridColumn39.Caption = "Retención";
            this.gridColumn39.FieldName = "FlagRetencion";
            this.gridColumn39.Name = "gridColumn39";
            this.gridColumn39.OptionsColumn.AllowEdit = false;
            this.gridColumn39.OptionsColumn.AllowFocus = false;
            this.gridColumn39.Visible = true;
            this.gridColumn39.VisibleIndex = 37;
            // 
            // gridColumn40
            // 
            this.gridColumn40.Caption = "Estado";
            this.gridColumn40.FieldName = "IdEstado";
            this.gridColumn40.Name = "gridColumn40";
            this.gridColumn40.OptionsColumn.AllowEdit = false;
            this.gridColumn40.OptionsColumn.AllowFocus = false;
            this.gridColumn40.Visible = true;
            this.gridColumn40.VisibleIndex = 38;
            // 
            // gridColumn41
            // 
            this.gridColumn41.Caption = "FlagEstado";
            this.gridColumn41.FieldName = "FlagEstado";
            this.gridColumn41.Name = "gridColumn41";
            this.gridColumn41.OptionsColumn.AllowEdit = false;
            this.gridColumn41.OptionsColumn.AllowFocus = false;
            // 
            // frmRegConConsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 536);
            this.Controls.Add(this.gcDocumento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmRegConConsumo";
            this.Text = "Consumo - Mantenimiento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegConConsumo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private DevExpress.XtraGrid.GridControl gcDocumento;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;

    }
}