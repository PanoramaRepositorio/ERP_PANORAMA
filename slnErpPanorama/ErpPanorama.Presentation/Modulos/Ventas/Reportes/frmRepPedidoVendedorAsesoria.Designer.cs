namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepPedidoVendedorAsesoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepPedidoVendedorAsesoria));
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvReporteVenta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcReporteVenta = new DevExpress.XtraGrid.GridControl();
            this.optResumen = new System.Windows.Forms.RadioButton();
            this.optDetalle = new System.Windows.Forms.RadioButton();
            this.optSueldo = new System.Windows.Forms.RadioButton();
            this.gboReporte = new System.Windows.Forms.GroupBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.cboMes = new DevExpress.XtraScheduler.UI.MonthEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvReporteVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReporteVenta)).BeginInit();
            this.gboReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(6, 15);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 13);
            this.lblFecha.TabIndex = 81;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Sueldo bruto";
            this.gridColumn17.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn17.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn17.FieldName = "SueldoBruto";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 17;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Bono Meta";
            this.gridColumn16.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn16.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn16.FieldName = "BonoMeta";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 16;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Comisión Registro Cliente";
            this.gridColumn15.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "RegCliSueldo";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 15;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Bono Venta Intermediaria";
            this.gridColumn14.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "BonoVentaIntermediaria";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 14;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Bono Venta";
            this.gridColumn13.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn13.FieldName = "BonoVenta";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 13;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Sueldo Básico";
            this.gridColumn12.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "Basico";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 12;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Alcance Meta";
            this.gridColumn11.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn11.FieldName = "AlcanceMeta";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 11;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Meta";
            this.gridColumn10.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Meta";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Total Venta";
            this.gridColumn9.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "TotalVenta";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 9;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Cant. Reg. Cliente";
            this.gridColumn7.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "CanRegCliente";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            // 
            // btnExportar
            // 
            this.btnExportar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.btnExportar.ImageOptions.ImageIndex = 1;
            this.btnExportar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(191, 116);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(79, 23);
            this.btnExportar.TabIndex = 89;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "CanRegCliente";
            this.gridColumn1.FieldName = "CanRegCliente";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // gridColumn37
            // 
            this.gridColumn37.Caption = "Tienda";
            this.gridColumn37.FieldName = "DescTienda";
            this.gridColumn37.Name = "gridColumn37";
            this.gridColumn37.OptionsColumn.AllowEdit = false;
            this.gridColumn37.OptionsColumn.AllowFocus = false;
            this.gridColumn37.Visible = true;
            this.gridColumn37.VisibleIndex = 2;
            this.gridColumn37.Width = 83;
            // 
            // gridColumn35
            // 
            this.gridColumn35.Caption = "Cargo";
            this.gridColumn35.FieldName = "Cargo";
            this.gridColumn35.Name = "gridColumn35";
            this.gridColumn35.OptionsColumn.AllowEdit = false;
            this.gridColumn35.OptionsColumn.AllowFocus = false;
            this.gridColumn35.Visible = true;
            this.gridColumn35.VisibleIndex = 1;
            this.gridColumn35.Width = 88;
            // 
            // gridColumn33
            // 
            this.gridColumn33.Caption = "Vendedor";
            this.gridColumn33.FieldName = "DescVendedor";
            this.gridColumn33.Name = "gridColumn33";
            this.gridColumn33.OptionsColumn.AllowEdit = false;
            this.gridColumn33.OptionsColumn.AllowFocus = false;
            this.gridColumn33.Visible = true;
            this.gridColumn33.VisibleIndex = 0;
            // 
            // gvReporteVenta
            // 
            this.gvReporteVenta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn33,
            this.gridColumn35,
            this.gridColumn37,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn7,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn18,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17});
            this.gvReporteVenta.GridControl = this.gcReporteVenta;
            this.gvReporteVenta.Name = "gvReporteVenta";
            this.gvReporteVenta.OptionsView.ColumnAutoWidth = false;
            this.gvReporteVenta.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CanVentaIntermediaria";
            this.gridColumn2.FieldName = "CanVentaIntermediaria";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Total Venta Intermediaria";
            this.gridColumn5.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn5.FieldName = "TotalVentaIntermediaria";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 143;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Total Venta Asesoria";
            this.gridColumn4.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "TotalVentaAsesoria";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "TotalVentaTienda";
            this.gridColumn18.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn18.FieldName = "TotalVentaTienda";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 7;
            // 
            // gcReporteVenta
            // 
            this.gcReporteVenta.Location = new System.Drawing.Point(6, 223);
            this.gcReporteVenta.MainView = this.gvReporteVenta;
            this.gcReporteVenta.Name = "gcReporteVenta";
            this.gcReporteVenta.Size = new System.Drawing.Size(484, 196);
            this.gcReporteVenta.TabIndex = 88;
            this.gcReporteVenta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReporteVenta});
            this.gcReporteVenta.Visible = false;
            // 
            // optResumen
            // 
            this.optResumen.AutoSize = true;
            this.optResumen.Enabled = false;
            this.optResumen.Location = new System.Drawing.Point(82, 20);
            this.optResumen.Name = "optResumen";
            this.optResumen.Size = new System.Drawing.Size(69, 17);
            this.optResumen.TabIndex = 1;
            this.optResumen.Text = "Resumen";
            this.optResumen.UseVisualStyleBackColor = true;
            // 
            // optDetalle
            // 
            this.optDetalle.AutoSize = true;
            this.optDetalle.Enabled = false;
            this.optDetalle.Location = new System.Drawing.Point(6, 20);
            this.optDetalle.Name = "optDetalle";
            this.optDetalle.Size = new System.Drawing.Size(70, 17);
            this.optDetalle.TabIndex = 0;
            this.optDetalle.Text = "Detallado";
            this.optDetalle.UseVisualStyleBackColor = true;
            // 
            // optSueldo
            // 
            this.optSueldo.AutoSize = true;
            this.optSueldo.Checked = true;
            this.optSueldo.Location = new System.Drawing.Point(157, 20);
            this.optSueldo.Name = "optSueldo";
            this.optSueldo.Size = new System.Drawing.Size(93, 17);
            this.optSueldo.TabIndex = 2;
            this.optSueldo.TabStop = true;
            this.optSueldo.Text = "Remuneración";
            this.optSueldo.UseVisualStyleBackColor = true;
            // 
            // gboReporte
            // 
            this.gboReporte.Controls.Add(this.optResumen);
            this.gboReporte.Controls.Add(this.optDetalle);
            this.gboReporte.Controls.Add(this.optSueldo);
            this.gboReporte.Location = new System.Drawing.Point(6, 60);
            this.gboReporte.Name = "gboReporte";
            this.gboReporte.Size = new System.Drawing.Size(270, 50);
            this.gboReporte.TabIndex = 85;
            this.gboReporte.TabStop = false;
            this.gboReporte.Text = "Filtro";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 83;
            this.labelControl1.Text = "Fecha Hasta: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(79, 12);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 82;
            this.deFechaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaDesde_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(276, 116);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 87;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageOptions.ImageIndex = 1;
            this.btnVer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(93, 116);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 86;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(79, 34);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 84;
            this.deFechaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaHasta_KeyPress);
            // 
            // cboMes
            // 
            this.cboMes.Location = new System.Drawing.Point(219, 12);
            this.cboMes.Name = "cboMes";
            this.cboMes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMes.Properties.DropDownRows = 12;
            this.cboMes.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.cboMes.Size = new System.Drawing.Size(110, 20);
            this.cboMes.TabIndex = 91;
            this.cboMes.SelectedIndexChanged += new System.EventHandler(this.cboMes_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(190, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 90;
            this.labelControl2.Text = "Mes:";
            // 
            // frmRepPedidoVendedorAsesoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 153);
            this.Controls.Add(this.cboMes);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.gcReporteVenta);
            this.Controls.Add(this.gboReporte);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.deFechaDesde);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.deFechaHasta);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepPedidoVendedorAsesoria";
            this.Text = "Reporte - Pedido Vendedor Asesoria";
            this.Load += new System.EventHandler(this.frmRepPedidoVendedorAsesoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvReporteVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReporteVenta)).EndInit();
            this.gboReporte.ResumeLayout(false);
            this.gboReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMes.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        public DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReporteVenta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gcReporteVenta;
        private System.Windows.Forms.RadioButton optResumen;
        private System.Windows.Forms.RadioButton optDetalle;
        private System.Windows.Forms.RadioButton optSueldo;
        private System.Windows.Forms.GroupBox gboReporte;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraScheduler.UI.MonthEdit cboMes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}