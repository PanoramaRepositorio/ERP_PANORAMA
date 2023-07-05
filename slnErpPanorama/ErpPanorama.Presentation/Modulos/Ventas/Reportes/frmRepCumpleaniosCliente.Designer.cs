namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepCumpleaniosCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepCumpleaniosCliente));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCumpleanios = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboMes = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.gcReporteCumpleanios = new DevExpress.XtraGrid.GridControl();
            this.gvReporteCumpleanios = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas.WaitForm2), true, true);
            this.labelControl31 = new DevExpress.XtraEditors.LabelControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReporteCumpleanios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReporteCumpleanios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.labelControl31);
            this.panel1.Controls.Add(this.btnCumpleanios);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.cboTienda);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.cboMes);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Controls.Add(this.btnConsultar);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1697, 35);
            this.panel1.TabIndex = 78;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnCumpleanios
            // 
            this.btnCumpleanios.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Birthday_16x16;
            this.btnCumpleanios.Location = new System.Drawing.Point(984, 10);
            this.btnCumpleanios.Name = "btnCumpleanios";
            this.btnCumpleanios.Size = new System.Drawing.Size(111, 20);
            this.btnCumpleanios.TabIndex = 61;
            this.btnCumpleanios.Text = "Envio de correo";
            this.btnCumpleanios.Click += new System.EventHandler(this.btnCumpleanios_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.simpleButton1.Location = new System.Drawing.Point(464, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(111, 20);
            this.simpleButton1.TabIndex = 60;
            this.simpleButton1.Text = "Exportar Excel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(50, 10);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(147, 20);
            this.cboTienda.TabIndex = 59;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 13);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 58;
            this.labelControl3.Text = "Tienda:";
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(232, 10);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.DropDownRows = 9;
            this.cboMes.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.cboMes.Size = new System.Drawing.Size(134, 20);
            this.cboMes.TabIndex = 57;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(203, 13);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 56;
            this.labelControl2.Text = "Mes:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(372, 10);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 13;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gcReporteCumpleanios
            // 
            this.gcReporteCumpleanios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcReporteCumpleanios.Location = new System.Drawing.Point(1, 40);
            this.gcReporteCumpleanios.MainView = this.gvReporteCumpleanios;
            this.gcReporteCumpleanios.Name = "gcReporteCumpleanios";
            this.gcReporteCumpleanios.Size = new System.Drawing.Size(1696, 735);
            this.gcReporteCumpleanios.TabIndex = 79;
            this.gcReporteCumpleanios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReporteCumpleanios});
            this.gcReporteCumpleanios.Click += new System.EventHandler(this.gcReporteCumpleanios_Click);
            // 
            // gvReporteCumpleanios
            // 
            this.gvReporteCumpleanios.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn18,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn15,
            this.gridColumn16,
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
            this.gridColumn17,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21});
            this.gvReporteCumpleanios.GridControl = this.gcReporteCumpleanios;
            this.gvReporteCumpleanios.Name = "gvReporteCumpleanios";
            this.gvReporteCumpleanios.OptionsSelection.MultiSelect = true;
            this.gvReporteCumpleanios.OptionsView.ColumnAutoWidth = false;
            this.gvReporteCumpleanios.OptionsView.ShowFooter = true;
            this.gvReporteCumpleanios.OptionsView.ShowGroupPanel = false;
            this.gvReporteCumpleanios.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvReporteCumpleanios_RowStyle);
            this.gvReporteCumpleanios.DoubleClick += new System.EventHandler(this.gvReporteCumpleanios_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdCliente";
            this.gridColumn1.FieldName = "IdCliente";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "N° Documento";
            this.gridColumn18.FieldName = "NumeroDocumento";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 0;
            this.gridColumn18.Width = 84;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Cliente";
            this.gridColumn2.FieldName = "DescCliente";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "DescCliente", "{0} Registros")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 280;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fecha Nac.";
            this.gridColumn3.DisplayFormat.FormatString = "d";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "FechaNac";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Teléfono";
            this.gridColumn4.FieldName = "Telefono";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 80;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Celular";
            this.gridColumn15.FieldName = "Celular";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 5;
            this.gridColumn15.Width = 80;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Otro Tel.";
            this.gridColumn16.FieldName = "OtroTelefono";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 6;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Email";
            this.gridColumn5.FieldName = "Email";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 185;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tickets";
            this.gridColumn6.FieldName = "Tickets";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Width = 44;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Total  S/";
            this.gridColumn7.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "TotalSoles";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "F.Registro";
            this.gridColumn8.FieldName = "FechaRegistro";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 8;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "TK Mes";
            this.gridColumn9.FieldName = "TicketMes";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TicketMes", "{0:#.##}")});
            this.gridColumn9.Width = 42;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "T. Mes S/";
            this.gridColumn10.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "TotalMes";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalMes", "{0:#.##}")});
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Día";
            this.gridColumn11.FieldName = "Dia";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 39;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Departamento";
            this.gridColumn12.FieldName = "NomDpto";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 9;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Provincia";
            this.gridColumn13.FieldName = "NomProv";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Distrito";
            this.gridColumn14.FieldName = "NomDist";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 11;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Dirección";
            this.gridColumn17.FieldName = "Direccion";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 12;
            this.gridColumn17.Width = 270;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Tipo Cliente";
            this.gridColumn19.FieldName = "TipoCliente";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 13;
            this.gridColumn19.Width = 98;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "IdTipoCliente";
            this.gridColumn20.FieldName = "IdTipoCliente";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "NroCorreo";
            this.gridColumn21.FieldName = "NroCorreo";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.OptionsColumn.AllowEdit = false;
            this.gridColumn21.OptionsColumn.AllowFocus = false;
            this.gridColumn21.OptionsColumn.TabStop = false;
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 14;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // labelControl31
            // 
            this.labelControl31.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl31.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.labelControl31.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.labelControl31.Appearance.Options.UseBackColor = true;
            this.labelControl31.Appearance.Options.UseFont = true;
            this.labelControl31.Location = new System.Drawing.Point(965, 13);
            this.labelControl31.Name = "labelControl31";
            this.labelControl31.Size = new System.Drawing.Size(13, 12);
            this.labelControl31.TabIndex = 126;
            this.labelControl31.Text = "F8";
            // 
            // frmRepCumpleaniosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1697, 786);
            this.Controls.Add(this.gcReporteCumpleanios);
            this.Controls.Add(this.panel1);
            this.Name = "frmRepCumpleaniosCliente";
            this.Text = "Reporte de Cumpleaños de Clientes";
            this.Load += new System.EventHandler(this.frmRepCumpleaniosCliente_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReporteCumpleanios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReporteCumpleanios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraScheduler.UI.MonthEdit cboMes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReporteCumpleanios;
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
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gcReporteCumpleanios;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraEditors.SimpleButton btnCumpleanios;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.LabelControl labelControl31;
    }
}