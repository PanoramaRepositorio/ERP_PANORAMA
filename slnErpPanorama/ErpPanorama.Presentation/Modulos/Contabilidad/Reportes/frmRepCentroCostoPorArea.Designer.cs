namespace ErpPanorama.Presentation.Modulos.Contabilidad.Reportes
{
    partial class frmRepCentroCostoPorArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepCentroCostoPorArea));
            this.pieChart = new DevExpress.XtraCharts.ChartControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.cboTipoReporte = new DevExpress.XtraEditors.LookUpEdit();
            this.cboMes = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboPeriodo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcReporte = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.imprimirtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvReporte = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcCodGrupo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescGrupo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDebeUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDebeMN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDescCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.pieChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoReporte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReporte)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pieChart
            // 
            this.pieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pieChart.Legend.Name = "Default Legend";
            this.pieChart.Legend.Title.Text = "Reporte ";
            this.pieChart.Legend.Title.Visible = true;
            this.pieChart.Location = new System.Drawing.Point(0, 0);
            this.pieChart.Name = "pieChart";
            this.pieChart.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.pieChart.Size = new System.Drawing.Size(768, 461);
            this.pieChart.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.cboTipoReporte);
            this.groupBox1.Controls.Add(this.cboMes);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.cboPeriodo);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(424, 18);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(84, 23);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboTipoReporte
            // 
            this.cboTipoReporte.Location = new System.Drawing.Point(313, 20);
            this.cboTipoReporte.Name = "cboTipoReporte";
            this.cboTipoReporte.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoReporte.Properties.NullText = "";
            this.cboTipoReporte.Size = new System.Drawing.Size(105, 20);
            this.cboTipoReporte.TabIndex = 5;
            this.cboTipoReporte.EditValueChanged += new System.EventHandler(this.cboTipoReporte_EditValueChanged);
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(174, 20);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.NullText = "";
            this.cboMes.Size = new System.Drawing.Size(104, 20);
            this.cboMes.TabIndex = 3;
            this.cboMes.EditValueChanged += new System.EventHandler(this.cboMes_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(284, 23);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Tipo:";
            // 
            // cboPeriodo
            // 
            this.cboPeriodo.Location = new System.Drawing.Point(35, 20);
            this.cboPeriodo.Name = "cboPeriodo";
            this.cboPeriodo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPeriodo.Properties.NullText = "";
            this.cboPeriodo.Size = new System.Drawing.Size(104, 20);
            this.cboPeriodo.TabIndex = 1;
            this.cboPeriodo.EditValueChanged += new System.EventHandler(this.cboPeriodo_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(145, 23);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mes:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Año:";
            // 
            // gcReporte
            // 
            this.gcReporte.ContextMenuStrip = this.mnuContextual;
            this.gcReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcReporte.Location = new System.Drawing.Point(0, 0);
            this.gcReporte.MainView = this.gvReporte;
            this.gcReporte.Name = "gcReporte";
            this.gcReporte.Size = new System.Drawing.Size(395, 461);
            this.gcReporte.TabIndex = 0;
            this.gcReporte.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReporte});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imprimirtoolStripMenuItem});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.Size = new System.Drawing.Size(121, 26);
            // 
            // imprimirtoolStripMenuItem
            // 
            this.imprimirtoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("imprimirtoolStripMenuItem.Image")));
            this.imprimirtoolStripMenuItem.Name = "imprimirtoolStripMenuItem";
            this.imprimirtoolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.imprimirtoolStripMenuItem.Text = "Imprimir";
            this.imprimirtoolStripMenuItem.Click += new System.EventHandler(this.imprimirtoolStripMenuItem_Click);
            // 
            // gvReporte
            // 
            this.gvReporte.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcCodGrupo,
            this.gcMes,
            this.gcDescGrupo,
            this.gcDebeUS,
            this.gcDebeMN,
            this.gcCodCuenta,
            this.gcDescCuenta});
            this.gvReporte.GridControl = this.gcReporte;
            this.gvReporte.Name = "gvReporte";
            this.gvReporte.OptionsSelection.MultiSelect = true;
            this.gvReporte.OptionsView.ColumnAutoWidth = false;
            this.gvReporte.OptionsView.ShowFooter = true;
            this.gvReporte.OptionsView.ShowGroupPanel = false;
            this.gvReporte.OptionsView.ShowViewCaption = true;
            this.gvReporte.ViewCaption = "GASTOS POR AREA";
            // 
            // gcCodGrupo
            // 
            this.gcCodGrupo.Caption = "C. Costo";
            this.gcCodGrupo.FieldName = "CodGrupo";
            this.gcCodGrupo.Name = "gcCodGrupo";
            this.gcCodGrupo.OptionsColumn.AllowEdit = false;
            this.gcCodGrupo.OptionsColumn.AllowFocus = false;
            this.gcCodGrupo.Width = 50;
            // 
            // gcMes
            // 
            this.gcMes.Caption = "Mes";
            this.gcMes.FieldName = "Mes";
            this.gcMes.Name = "gcMes";
            this.gcMes.OptionsColumn.AllowEdit = false;
            this.gcMes.OptionsColumn.AllowFocus = false;
            this.gcMes.Visible = true;
            this.gcMes.VisibleIndex = 0;
            this.gcMes.Width = 28;
            // 
            // gcDescGrupo
            // 
            this.gcDescGrupo.Caption = "Centro Costo";
            this.gcDescGrupo.FieldName = "DescGrupo";
            this.gcDescGrupo.Name = "gcDescGrupo";
            this.gcDescGrupo.OptionsColumn.AllowEdit = false;
            this.gcDescGrupo.OptionsColumn.AllowFocus = false;
            this.gcDescGrupo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DescGrupo", "{0} Registros")});
            this.gcDescGrupo.Visible = true;
            this.gcDescGrupo.VisibleIndex = 1;
            this.gcDescGrupo.Width = 158;
            // 
            // gcDebeUS
            // 
            this.gcDebeUS.Caption = "Importe US$";
            this.gcDebeUS.DisplayFormat.FormatString = "#,0.00";
            this.gcDebeUS.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcDebeUS.FieldName = "DebeUS";
            this.gcDebeUS.Name = "gcDebeUS";
            this.gcDebeUS.OptionsColumn.AllowEdit = false;
            this.gcDebeUS.OptionsColumn.AllowFocus = false;
            this.gcDebeUS.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DebeUS", "{0:#,0.00}")});
            this.gcDebeUS.Visible = true;
            this.gcDebeUS.VisibleIndex = 2;
            this.gcDebeUS.Width = 99;
            // 
            // gcDebeMN
            // 
            this.gcDebeMN.Caption = "Importe S/";
            this.gcDebeMN.DisplayFormat.FormatString = "#,0.00";
            this.gcDebeMN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcDebeMN.FieldName = "DebeMN";
            this.gcDebeMN.Name = "gcDebeMN";
            this.gcDebeMN.OptionsColumn.AllowEdit = false;
            this.gcDebeMN.OptionsColumn.AllowFocus = false;
            this.gcDebeMN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DebeMN", "{0:#,0.00}")});
            this.gcDebeMN.Visible = true;
            this.gcDebeMN.VisibleIndex = 3;
            this.gcDebeMN.Width = 86;
            // 
            // gcCodCuenta
            // 
            this.gcCodCuenta.Caption = "Cuenta";
            this.gcCodCuenta.FieldName = "CodCuenta";
            this.gcCodCuenta.Name = "gcCodCuenta";
            this.gcCodCuenta.OptionsColumn.AllowEdit = false;
            this.gcCodCuenta.OptionsColumn.AllowFocus = false;
            this.gcCodCuenta.Width = 55;
            // 
            // gcDescCuenta
            // 
            this.gcDescCuenta.Caption = "Cuenta";
            this.gcDescCuenta.FieldName = "DescCuenta";
            this.gcDescCuenta.Name = "gcDescCuenta";
            this.gcDescCuenta.OptionsColumn.AllowEdit = false;
            this.gcDescCuenta.OptionsColumn.AllowFocus = false;
            this.gcDescCuenta.Width = 300;
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Location = new System.Drawing.Point(880, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMoneda.Location = new System.Drawing.Point(928, 24);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.NullText = "";
            this.cboMoneda.Size = new System.Drawing.Size(163, 20);
            this.cboMoneda.TabIndex = 2;
            this.cboMoneda.EditValueChanged += new System.EventHandler(this.cboMoneda_EditValueChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.ImageOptions.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(1097, 22);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Location = new System.Drawing.Point(4, 53);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcReporte);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.pieChart);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1168, 461);
            this.splitContainerControl1.SplitterPosition = 395;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // frmRepCentroCostoPorArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 526);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelControl3);
            this.Name = "frmRepCentroCostoPorArea";
            this.Text = "Reporte por Centro de Costo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRepCentroCostoPorArea_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pieChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoReporte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReporte)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl pieChart;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraGrid.GridControl gcReporte;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReporte;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodGrupo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescGrupo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDebeUS;
        private DevExpress.XtraGrid.Columns.GridColumn gcDebeMN;
        private DevExpress.XtraGrid.Columns.GridColumn gcMes;
        public DevExpress.XtraEditors.LookUpEdit cboPeriodo;
        public DevExpress.XtraEditors.LookUpEdit cboMoneda;
        public DevExpress.XtraEditors.LookUpEdit cboMes;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn gcDescCuenta;
        public DevExpress.XtraEditors.LookUpEdit cboTipoReporte;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem imprimirtoolStripMenuItem;
    }
}