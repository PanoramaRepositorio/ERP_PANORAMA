namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class frmRegVentaPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegVentaPedido));
            this.gcDocumentoVenta = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.verestadocuentatoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verdetalletoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificardocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvDocumentoVenta = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtCodigo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblPedido = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumentoVenta)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumentoVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcDocumentoVenta
            // 
            this.gcDocumentoVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcDocumentoVenta.ContextMenuStrip = this.mnuContextual;
            this.gcDocumentoVenta.Location = new System.Drawing.Point(1, 32);
            this.gcDocumentoVenta.MainView = this.gvDocumentoVenta;
            this.gcDocumentoVenta.Name = "gcDocumentoVenta";
            this.gcDocumentoVenta.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtCodigo});
            this.gcDocumentoVenta.Size = new System.Drawing.Size(1294, 271);
            this.gcDocumentoVenta.TabIndex = 18;
            this.gcDocumentoVenta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDocumentoVenta});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verestadocuentatoolStripMenuItem,
            this.verdetalletoolStripMenuItem,
            this.modificardocumentoToolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(255, 70);
            // 
            // verestadocuentatoolStripMenuItem
            // 
            this.verestadocuentatoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultar_16x16;
            this.verestadocuentatoolStripMenuItem.Name = "verestadocuentatoolStripMenuItem";
            this.verestadocuentatoolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.verestadocuentatoolStripMenuItem.Text = "Ver Estado de Cuenta";
            this.verestadocuentatoolStripMenuItem.Click += new System.EventHandler(this.verestadocuentatoolStripMenuItem_Click);
            // 
            // verdetalletoolStripMenuItem
            // 
            this.verdetalletoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("verdetalletoolStripMenuItem.Image")));
            this.verdetalletoolStripMenuItem.Name = "verdetalletoolStripMenuItem";
            this.verdetalletoolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.verdetalletoolStripMenuItem.Text = "Ver Detalle";
            this.verdetalletoolStripMenuItem.Visible = false;
            this.verdetalletoolStripMenuItem.Click += new System.EventHandler(this.verdetalletoolStripMenuItem_Click);
            // 
            // modificardocumentoToolStripMenuItem
            // 
            this.modificardocumentoToolStripMenuItem.Enabled = false;
            this.modificardocumentoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificardocumentoToolStripMenuItem.Image")));
            this.modificardocumentoToolStripMenuItem.Name = "modificardocumentoToolStripMenuItem";
            this.modificardocumentoToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.modificardocumentoToolStripMenuItem.Text = "Modificar Numero de Documento";
            this.modificardocumentoToolStripMenuItem.Visible = false;
            this.modificardocumentoToolStripMenuItem.Click += new System.EventHandler(this.modificardocumentoToolStripMenuItem_Click);
            // 
            // gvDocumentoVenta
            // 
            this.gvDocumentoVenta.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn12,
            this.gridColumn2,
            this.gridColumn10,
            this.gridColumn8,
            this.gridColumn13,
            this.gridColumn5,
            this.gridColumn16,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20});
            this.gvDocumentoVenta.GridControl = this.gcDocumentoVenta;
            this.gvDocumentoVenta.Name = "gvDocumentoVenta";
            this.gvDocumentoVenta.OptionsSelection.MultiSelect = true;
            this.gvDocumentoVenta.OptionsView.ColumnAutoWidth = false;
            this.gvDocumentoVenta.OptionsView.ShowGroupPanel = false;
            this.gvDocumentoVenta.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gvDocumentoVenta_RowStyle);
            this.gvDocumentoVenta.DoubleClick += new System.EventHandler(this.gvDocumentoVenta_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdEmpresa";
            this.gridColumn1.FieldName = "IdEmpresa";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Razón Social";
            this.gridColumn3.FieldName = "RazonSocial";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 85;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IdDocumentoVenta";
            this.gridColumn4.FieldName = "IdDocumentoVenta";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Width = 60;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "IdTipoDocumento";
            this.gridColumn12.FieldName = "IdTipoDocumento";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Doc";
            this.gridColumn2.FieldName = "CodTipoDocumento";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 34;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Serie";
            this.gridColumn10.FieldName = "Serie";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 40;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Numero";
            this.gridColumn8.FieldName = "Numero";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Fecha";
            this.gridColumn13.FieldName = "Fecha";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Cliente";
            this.gridColumn5.FieldName = "DescCliente";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 250;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Tipo Cliente";
            this.gridColumn16.FieldName = "DescTipoCliente";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 12;
            this.gridColumn16.Width = 87;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Mon";
            this.gridColumn6.FieldName = "CodMoneda";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 33;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Total";
            this.gridColumn7.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn7.FieldName = "Total";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 60;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Vendedor";
            this.gridColumn9.FieldName = "DescVendedor";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 13;
            this.gridColumn9.Width = 175;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Caja";
            this.gridColumn11.FieldName = "DescCaja";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 14;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "N° Pedido";
            this.gridColumn14.FieldName = "NumeroPedido";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 1;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Forma Pago";
            this.gridColumn15.FieldName = "DescFormaPago";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 7;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "IdSituacionContable";
            this.gridColumn17.FieldName = "IdSituacionContable";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Estado";
            this.gridColumn18.FieldName = "DescSituacionContable";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 10;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "IdCliente";
            this.gridColumn19.FieldName = "IdCliente";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.AllowEdit = false;
            this.gridColumn19.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Fecha Estado";
            this.gridColumn20.FieldName = "FechaContable";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.OptionsColumn.AllowEdit = false;
            this.gridColumn20.OptionsColumn.AllowFocus = false;
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 11;
            // 
            // gcTxtCodigo
            // 
            this.gcTxtCodigo.AutoHeight = false;
            this.gcTxtCodigo.Name = "gcTxtCodigo";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(84, 18);
            this.labelControl2.TabIndex = 67;
            this.labelControl2.Text = "N° Pedido :";
            // 
            // lblPedido
            // 
            this.lblPedido.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPedido.Appearance.Options.UseFont = true;
            this.lblPedido.Location = new System.Drawing.Point(113, 8);
            this.lblPedido.Name = "lblPedido";
            this.lblPedido.Size = new System.Drawing.Size(0, 18);
            this.lblPedido.TabIndex = 68;
            // 
            // txtTotal
            // 
            this.txtTotal.EditValue = "0.00";
            this.txtTotal.Location = new System.Drawing.Point(754, 6);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(87, 20);
            this.txtTotal.TabIndex = 70;
            // 
            // labelControl27
            // 
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl27.Appearance.Options.UseFont = true;
            this.labelControl27.Location = new System.Drawing.Point(712, 9);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(35, 13);
            this.labelControl27.TabIndex = 69;
            this.labelControl27.Text = "Total :";
            // 
            // btnExportar
            // 
            this.btnExportar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.btnExportar.ImageOptions.ImageIndex = 1;
            this.btnExportar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(1058, 2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 71;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistros.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRegistros.Appearance.Options.UseFont = true;
            this.lblTotalRegistros.Location = new System.Drawing.Point(12, 309);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(138, 13);
            this.lblTotalRegistros.TabIndex = 69;
            this.lblTotalRegistros.Text = "0 Registros encontrados";
            // 
            // frmRegVentaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 330);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.labelControl27);
            this.Controls.Add(this.lblPedido);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.gcDocumentoVenta);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegVentaPedido";
            this.Text = "Consulta Documento de Venta";
            this.Load += new System.EventHandler(this.frmRegVentaPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcDocumentoVenta)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDocumentoVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcDocumentoVenta;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDocumentoVenta;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtCodigo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblPedido;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem modificardocumentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verdetalletoolStripMenuItem;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private System.Windows.Forms.ToolStripMenuItem verestadocuentatoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
    }
}