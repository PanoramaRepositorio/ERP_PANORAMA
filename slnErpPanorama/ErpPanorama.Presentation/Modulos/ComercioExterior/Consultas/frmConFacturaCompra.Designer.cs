namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas
{
    partial class frmConFacturaCompra
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
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.gcFacturaCompra = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.vercatalogotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vercatalogosolestoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verclasificacionpreciofototoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvFacturaCompra = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkIncluirVenta = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturaCompra)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturaCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncluirVenta.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1303, 24);
            this.tlbMenu.TabIndex = 1;
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            this.tlbMenu.Load += new System.EventHandler(this.tlbMenu_Load);
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(247, 30);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(111, 20);
            this.txtNumeroDocumento.TabIndex = 55;
            this.txtNumeroDocumento.ToolTip = "Periodo";
            this.txtNumeroDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(168, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 54;
            this.labelControl1.Text = "N° Documento:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(66, 30);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(65, 20);
            this.txtPeriodo.TabIndex = 53;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(20, 33);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 52;
            this.labelControl7.Text = "Periodo:";
            // 
            // gcFacturaCompra
            // 
            this.gcFacturaCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFacturaCompra.ContextMenuStrip = this.mnuContextual;
            this.gcFacturaCompra.Location = new System.Drawing.Point(0, 56);
            this.gcFacturaCompra.MainView = this.gvFacturaCompra;
            this.gcFacturaCompra.Name = "gcFacturaCompra";
            this.gcFacturaCompra.Size = new System.Drawing.Size(1303, 458);
            this.gcFacturaCompra.TabIndex = 56;
            this.gcFacturaCompra.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFacturaCompra});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vercatalogotoolStripMenuItem,
            this.vercatalogosolestoolStripMenuItem1,
            this.verclasificacionpreciofototoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.ShowCheckMargin = true;
            this.mnuContextual.Size = new System.Drawing.Size(294, 70);
            // 
            // vercatalogotoolStripMenuItem
            // 
            this.vercatalogotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.vercatalogotoolStripMenuItem.Name = "vercatalogotoolStripMenuItem";
            this.vercatalogotoolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.vercatalogotoolStripMenuItem.Text = "Ver Catálogo - Precio Mayorista Dolar";
            this.vercatalogotoolStripMenuItem.Click += new System.EventHandler(this.vercatalogotoolStripMenuItem_Click);
            // 
            // vercatalogosolestoolStripMenuItem1
            // 
            this.vercatalogosolestoolStripMenuItem1.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.vercatalogosolestoolStripMenuItem1.Name = "vercatalogosolestoolStripMenuItem1";
            this.vercatalogosolestoolStripMenuItem1.Size = new System.Drawing.Size(293, 22);
            this.vercatalogosolestoolStripMenuItem1.Text = "Ver Catalógo - Precio Minorista Soles";
            this.vercatalogosolestoolStripMenuItem1.Click += new System.EventHandler(this.vercatalogosolestoolStripMenuItem1_Click);
            // 
            // verclasificacionpreciofototoolStripMenuItem
            // 
            this.verclasificacionpreciofototoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.DisenoProyecto_16x16;
            this.verclasificacionpreciofototoolStripMenuItem.Name = "verclasificacionpreciofototoolStripMenuItem";
            this.verclasificacionpreciofototoolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.verclasificacionpreciofototoolStripMenuItem.Text = "Ver Clasificación / Precio / Foto";
            this.verclasificacionpreciofototoolStripMenuItem.Click += new System.EventHandler(this.verclasificacionpreciofototoolStripMenuItem_Click);
            // 
            // gvFacturaCompra
            // 
            this.gvFacturaCompra.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn13,
            this.gridColumn7,
            this.gridColumn4,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn17,
            this.gridColumn18});
            this.gvFacturaCompra.GridControl = this.gcFacturaCompra;
            this.gvFacturaCompra.Name = "gvFacturaCompra";
            this.gvFacturaCompra.OptionsSelection.MultiSelect = true;
            this.gvFacturaCompra.OptionsView.ColumnAutoWidth = false;
            this.gvFacturaCompra.OptionsView.ShowGroupPanel = false;
            this.gvFacturaCompra.DoubleClick += new System.EventHandler(this.gvFacturaCompra_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdEmpresa";
            this.gridColumn1.FieldName = "IdEmpresa";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdFacturaCompra";
            this.gridColumn2.FieldName = "IdFacturaCompra";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Documento";
            this.gridColumn3.FieldName = "CodTipoDocumento";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "N° Documento";
            this.gridColumn5.FieldName = "NumeroDocumento";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 80;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Fecha";
            this.gridColumn6.FieldName = "FechaCompra";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "F. Recepción";
            this.gridColumn13.FieldName = "FechaRecepcion";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Proveedor";
            this.gridColumn7.FieldName = "DescProveedor";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 292;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Forma Pago";
            this.gridColumn4.FieldName = "FormaPago";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Moneda";
            this.gridColumn8.FieldName = "Moneda";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 60;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "T.C";
            this.gridColumn9.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "TipoCambio";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 46;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Cantidad";
            this.gridColumn11.FieldName = "Cantidad";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 85;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Recibido";
            this.gridColumn12.FieldName = "FlagRecibido";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn14.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn14.Caption = "% Ventas";
            this.gridColumn14.DisplayFormat.FormatString = "P";
            this.gridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn14.FieldName = "PorcentajeVenta";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 9;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn15.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn15.Caption = "Cant. Venta";
            this.gridColumn15.FieldName = "CantidadVenta";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 10;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Usuario";
            this.gridColumn17.FieldName = "Usuario";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 11;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Nacional";
            this.gridColumn18.FieldName = "FlagNacional";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 12;
            // 
            // chkIncluirVenta
            // 
            this.chkIncluirVenta.Location = new System.Drawing.Point(977, 30);
            this.chkIncluirVenta.Name = "chkIncluirVenta";
            this.chkIncluirVenta.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.chkIncluirVenta.Properties.Appearance.Options.UseForeColor = true;
            this.chkIncluirVenta.Properties.Caption = "Incluir Venta al Editar";
            this.chkIncluirVenta.Size = new System.Drawing.Size(128, 20);
            this.chkIncluirVenta.TabIndex = 57;
            // 
            // frmConFacturaCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 526);
            this.Controls.Add(this.chkIncluirVenta);
            this.Controls.Add(this.gcFacturaCompra);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmConFacturaCompra";
            this.Text = "Consulta - FacturaCompra";
            this.Load += new System.EventHandler(this.frmConFacturaCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturaCompra)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturaCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIncluirVenta.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        public DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.GridControl gcFacturaCompra;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFacturaCompra;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.CheckEdit chkIncluirVenta;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem vercatalogotoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vercatalogosolestoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verclasificacionpreciofototoolStripMenuItem;
    }
}