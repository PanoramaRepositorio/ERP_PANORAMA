namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepPedidoPreventa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepPedidoPreventa));
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.chkResumen = new System.Windows.Forms.CheckBox();
            this.gcReportePedidoCodigo = new DevExpress.XtraGrid.GridControl();
            this.gvReportePedidoCodigo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.gboReporte = new System.Windows.Forms.GroupBox();
            this.optCodigo = new System.Windows.Forms.RadioButton();
            this.optPedido = new System.Windows.Forms.RadioButton();
            this.optPedidoCodigo = new System.Windows.Forms.RadioButton();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReportePedidoCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportePedidoCodigo)).BeginInit();
            this.gboReporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(83, 29);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 9;
            this.deFechaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaHasta_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Fecha Hasta: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(83, 7);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 7;
            this.deFechaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaDesde_KeyPress);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(10, 10);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(286, 110);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageIndex = 1;
            this.btnVer.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(103, 110);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 10;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // chkResumen
            // 
            this.chkResumen.AutoSize = true;
            this.chkResumen.Location = new System.Drawing.Point(302, 12);
            this.chkResumen.Name = "chkResumen";
            this.chkResumen.Size = new System.Drawing.Size(84, 17);
            this.chkResumen.TabIndex = 26;
            this.chkResumen.Text = "Consolidado";
            this.chkResumen.UseVisualStyleBackColor = true;
            this.chkResumen.Visible = false;
            // 
            // gcReportePedidoCodigo
            // 
            this.gcReportePedidoCodigo.Location = new System.Drawing.Point(16, 168);
            this.gcReportePedidoCodigo.MainView = this.gvReportePedidoCodigo;
            this.gcReportePedidoCodigo.Name = "gcReportePedidoCodigo";
            this.gcReportePedidoCodigo.Size = new System.Drawing.Size(714, 139);
            this.gcReportePedidoCodigo.TabIndex = 82;
            this.gcReportePedidoCodigo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReportePedidoCodigo});
            this.gcReportePedidoCodigo.Visible = false;
            // 
            // gvReportePedidoCodigo
            // 
            this.gvReportePedidoCodigo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn15,
            this.gridColumn14,
            this.gridColumn13,
            this.gridColumn12,
            this.gridColumn23,
            this.gridColumn17,
            this.gridColumn19,
            this.gridColumn16,
            this.gridColumn18});
            this.gvReportePedidoCodigo.GridControl = this.gcReportePedidoCodigo;
            this.gvReportePedidoCodigo.Name = "gvReportePedidoCodigo";
            this.gvReportePedidoCodigo.OptionsView.ColumnAutoWidth = false;
            this.gvReportePedidoCodigo.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Fecha";
            this.gridColumn3.FieldName = "Fecha";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 49;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tienda";
            this.gridColumn5.FieldName = "DescTienda";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 58;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Numero";
            this.gridColumn11.FieldName = "Numero";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "NumeroDocumento";
            this.gridColumn10.FieldName = "NumeroDocumento";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Cliente";
            this.gridColumn9.FieldName = "DescCliente";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            this.gridColumn9.Width = 26;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Vendedor";
            this.gridColumn8.FieldName = "DescVendedor";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 29;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Moneda";
            this.gridColumn7.FieldName = "CodMoneda";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 30;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Total";
            this.gridColumn6.FieldName = "Total";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 24;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Forma Pago";
            this.gridColumn4.FieldName = "DescFormaPago";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            this.gridColumn4.Width = 36;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "CodigoProveedor";
            this.gridColumn2.FieldName = "CodigoProveedor";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 8;
            this.gridColumn2.Width = 20;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "NombreProducto";
            this.gridColumn1.FieldName = "NombreProducto";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Abreviatura";
            this.gridColumn15.FieldName = "Abreviatura";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 10;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Linea";
            this.gridColumn14.FieldName = "DescLineaProducto";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 11;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "SubLineaProducto";
            this.gridColumn13.FieldName = "DescSubLineaProducto";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "ModeloProducto";
            this.gridColumn12.FieldName = "DescModeloProducto";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 13;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "P. Venta";
            this.gridColumn23.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn23.FieldName = "PrecioVenta";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 16;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Cantidad";
            this.gridColumn17.FieldName = "Cantidad";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 15;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "PrecioAB";
            this.gridColumn16.FieldNameSortGroup = "PrecioAB";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 14;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Descuento";
            this.gridColumn18.FieldName = "Descuento";
            this.gridColumn18.Name = "gridColumn18";
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.btnExportar.ImageIndex = 1;
            this.btnExportar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(201, 110);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(79, 23);
            this.btnExportar.TabIndex = 83;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // gboReporte
            // 
            this.gboReporte.Controls.Add(this.optCodigo);
            this.gboReporte.Controls.Add(this.optPedido);
            this.gboReporte.Controls.Add(this.optPedidoCodigo);
            this.gboReporte.Location = new System.Drawing.Point(10, 57);
            this.gboReporte.Name = "gboReporte";
            this.gboReporte.Size = new System.Drawing.Size(270, 47);
            this.gboReporte.TabIndex = 84;
            this.gboReporte.TabStop = false;
            this.gboReporte.Text = "Filtro";
            // 
            // optCodigo
            // 
            this.optCodigo.AutoSize = true;
            this.optCodigo.Location = new System.Drawing.Point(82, 20);
            this.optCodigo.Name = "optCodigo";
            this.optCodigo.Size = new System.Drawing.Size(58, 17);
            this.optCodigo.TabIndex = 1;
            this.optCodigo.Text = "&Código";
            this.optCodigo.UseVisualStyleBackColor = true;
            // 
            // optPedido
            // 
            this.optPedido.AutoSize = true;
            this.optPedido.Checked = true;
            this.optPedido.Location = new System.Drawing.Point(6, 20);
            this.optPedido.Name = "optPedido";
            this.optPedido.Size = new System.Drawing.Size(57, 17);
            this.optPedido.TabIndex = 0;
            this.optPedido.TabStop = true;
            this.optPedido.Text = "&Pedido";
            this.optPedido.UseVisualStyleBackColor = true;
            // 
            // optPedidoCodigo
            // 
            this.optPedidoCodigo.AutoSize = true;
            this.optPedidoCodigo.Location = new System.Drawing.Point(157, 20);
            this.optPedidoCodigo.Name = "optPedidoCodigo";
            this.optPedidoCodigo.Size = new System.Drawing.Size(94, 17);
            this.optPedidoCodigo.TabIndex = 2;
            this.optPedidoCodigo.Text = "P&edido/Código";
            this.optPedidoCodigo.UseVisualStyleBackColor = true;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "SubTotal";
            this.gridColumn19.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn19.FieldName = "ValorVenta";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 17;
            // 
            // frmRepPedidoPreventa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 144);
            this.Controls.Add(this.gboReporte);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.gcReportePedidoCodigo);
            this.Controls.Add(this.chkResumen);
            this.Controls.Add(this.deFechaHasta);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.deFechaDesde);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepPedidoPreventa";
            this.Text = "Reporte Pedido - Preventa";
            this.Load += new System.EventHandler(this.frmRepPedidoPreventa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReportePedidoCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvReportePedidoCodigo)).EndInit();
            this.gboReporte.ResumeLayout(false);
            this.gboReporte.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        private System.Windows.Forms.CheckBox chkResumen;
        private DevExpress.XtraGrid.GridControl gcReportePedidoCodigo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvReportePedidoCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        public DevExpress.XtraEditors.SimpleButton btnExportar;
        private System.Windows.Forms.GroupBox gboReporte;
        private System.Windows.Forms.RadioButton optCodigo;
        private System.Windows.Forms.RadioButton optPedido;
        private System.Windows.Forms.RadioButton optPedidoCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
    }
}