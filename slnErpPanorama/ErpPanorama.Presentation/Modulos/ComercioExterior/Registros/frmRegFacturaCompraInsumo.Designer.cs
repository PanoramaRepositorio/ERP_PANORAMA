namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    partial class frmRegFacturaCompraInsumo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegFacturaCompraInsumo));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvFacturaCompraInsumo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcFacturaCompraInsumo = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.actualizafecharecepcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vercatalogotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vercatalogosolestoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verclasificacionpreciofototoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturaCompraInsumo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturaCompraInsumo)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1303, 24);
            this.tlbMenu.TabIndex = 53;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Usuario";
            this.gridColumn17.FieldName = "Usuario";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 10;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Recibido";
            this.gridColumn12.FieldName = "FlagRecibido";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
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
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Importe";
            this.gridColumn10.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "Importe";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            this.gridColumn10.Width = 95;
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
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdFacturaCompra";
            this.gridColumn2.FieldName = "IdFacturaCompra";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdEmpresa";
            this.gridColumn1.FieldName = "IdEmpresa";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gvFacturaCompraInsumo
            // 
            this.gvFacturaCompraInsumo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn17});
            this.gvFacturaCompraInsumo.GridControl = this.gcFacturaCompraInsumo;
            this.gvFacturaCompraInsumo.Name = "gvFacturaCompraInsumo";
            this.gvFacturaCompraInsumo.OptionsSelection.MultiSelect = true;
            this.gvFacturaCompraInsumo.OptionsView.ColumnAutoWidth = false;
            this.gvFacturaCompraInsumo.OptionsView.ShowGroupPanel = false;
            // 
            // gcFacturaCompraInsumo
            // 
            this.gcFacturaCompraInsumo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcFacturaCompraInsumo.ContextMenuStrip = this.mnuContextual;
            this.gcFacturaCompraInsumo.Location = new System.Drawing.Point(0, 54);
            this.gcFacturaCompraInsumo.MainView = this.gvFacturaCompraInsumo;
            this.gcFacturaCompraInsumo.Name = "gcFacturaCompraInsumo";
            this.gcFacturaCompraInsumo.Size = new System.Drawing.Size(1303, 475);
            this.gcFacturaCompraInsumo.TabIndex = 56;
            this.gcFacturaCompraInsumo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvFacturaCompraInsumo});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizafecharecepcionToolStripMenuItem,
            this.vercatalogotoolStripMenuItem,
            this.vercatalogosolestoolStripMenuItem1,
            this.verclasificacionpreciofototoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.ShowCheckMargin = true;
            this.mnuContextual.Size = new System.Drawing.Size(294, 92);
            // 
            // actualizafecharecepcionToolStripMenuItem
            // 
            this.actualizafecharecepcionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("actualizafecharecepcionToolStripMenuItem.Image")));
            this.actualizafecharecepcionToolStripMenuItem.Name = "actualizafecharecepcionToolStripMenuItem";
            this.actualizafecharecepcionToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.actualizafecharecepcionToolStripMenuItem.Text = "Actualiza Fecha de Recepción";
            // 
            // vercatalogotoolStripMenuItem
            // 
            this.vercatalogotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.vercatalogotoolStripMenuItem.Name = "vercatalogotoolStripMenuItem";
            this.vercatalogotoolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.vercatalogotoolStripMenuItem.Text = "Ver Catálogo - Precio Mayorista Dolar";
            // 
            // vercatalogosolestoolStripMenuItem1
            // 
            this.vercatalogosolestoolStripMenuItem1.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.vercatalogosolestoolStripMenuItem1.Name = "vercatalogosolestoolStripMenuItem1";
            this.vercatalogosolestoolStripMenuItem1.Size = new System.Drawing.Size(293, 22);
            this.vercatalogosolestoolStripMenuItem1.Text = "Ver Catalógo - Precio Minorista Soles";
            // 
            // verclasificacionpreciofototoolStripMenuItem
            // 
            this.verclasificacionpreciofototoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.DisenoProyecto_16x16;
            this.verclasificacionpreciofototoolStripMenuItem.Name = "verclasificacionpreciofototoolStripMenuItem";
            this.verclasificacionpreciofototoolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.verclasificacionpreciofototoolStripMenuItem.Text = "Ver Clasificación / Precio / Foto";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(236, 28);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(111, 20);
            this.txtNumeroDocumento.TabIndex = 58;
            this.txtNumeroDocumento.ToolTip = "Periodo";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(157, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 57;
            this.labelControl1.Text = "N° Documento:";
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(55, 28);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(65, 20);
            this.txtPeriodo.TabIndex = 55;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(9, 31);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 54;
            this.labelControl7.Text = "Periodo:";
            // 
            // frmRegFacturaCompraInsumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 526);
            this.Controls.Add(this.tlbMenu);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gcFacturaCompraInsumo);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.labelControl7);
            this.Name = "frmRegFacturaCompraInsumo";
            this.Text = "Factura Compra Insumo - Mantenimiento";
            this.Load += new System.EventHandler(this.frmRegFacturaCompraInsumo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvFacturaCompraInsumo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcFacturaCompraInsumo)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvFacturaCompraInsumo;
        private DevExpress.XtraGrid.GridControl gcFacturaCompraInsumo;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem actualizafecharecepcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vercatalogotoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vercatalogosolestoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verclasificacionpreciofototoolStripMenuItem;
        public DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}