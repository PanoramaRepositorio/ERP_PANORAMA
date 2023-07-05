namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    partial class frmManSolicitudCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManSolicitudCompra));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
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
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvSolicitudCompra = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSolicitudCompra = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.actualizafecharecepcionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vercatalogotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vercatalogosolestoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verclasificacionpreciofototoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generarfacuracompratoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalCantidad = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalItems = new DevExpress.XtraEditors.TextEdit();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitudCompra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSolicitudCompra)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalItems.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(157, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 13);
            this.labelControl1.TabIndex = 56;
            this.labelControl1.Text = "N° Documento:";
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
            this.gridColumn11.VisibleIndex = 10;
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
            this.gridColumn9.VisibleIndex = 8;
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
            this.gridColumn8.VisibleIndex = 7;
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
            this.gridColumn4.VisibleIndex = 6;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Proveedor";
            this.gridColumn7.FieldName = "DescProveedor";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
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
            this.gridColumn13.VisibleIndex = 4;
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
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(236, 28);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Size = new System.Drawing.Size(111, 20);
            this.txtNumeroDocumento.TabIndex = 57;
            this.txtNumeroDocumento.ToolTip = "Periodo";
            this.txtNumeroDocumento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumeroDocumento_KeyUp);
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdEmpresa";
            this.gridColumn1.FieldName = "IdEmpresa";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gvSolicitudCompra
            // 
            this.gvSolicitudCompra.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.gvSolicitudCompra.GridControl = this.gcSolicitudCompra;
            this.gvSolicitudCompra.Name = "gvSolicitudCompra";
            this.gvSolicitudCompra.OptionsSelection.MultiSelect = true;
            this.gvSolicitudCompra.OptionsView.ColumnAutoWidth = false;
            this.gvSolicitudCompra.OptionsView.ShowGroupPanel = false;
            this.gvSolicitudCompra.ColumnFilterChanged += new System.EventHandler(this.gvSolicitudCompra_ColumnFilterChanged);
            this.gvSolicitudCompra.DoubleClick += new System.EventHandler(this.gvSolicitudCompra_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdSolicitudCompra";
            this.gridColumn2.FieldName = "IdSolicitudCompra";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "F. Embarque";
            this.gridColumn14.FieldName = "FechaEmbarque";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "N° Factura";
            this.gridColumn15.FieldName = "NumeroFactura";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 12;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "IdProveedor";
            this.gridColumn16.FieldName = "IdProveedor";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Observación";
            this.gridColumn17.FieldName = "Observacion";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 13;
            this.gridColumn17.Width = 157;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Items";
            this.gridColumn18.FieldName = "Items";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 11;
            // 
            // gcSolicitudCompra
            // 
            this.gcSolicitudCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcSolicitudCompra.ContextMenuStrip = this.mnuContextual;
            this.gcSolicitudCompra.Location = new System.Drawing.Point(0, 54);
            this.gcSolicitudCompra.MainView = this.gvSolicitudCompra;
            this.gcSolicitudCompra.Name = "gcSolicitudCompra";
            this.gcSolicitudCompra.Size = new System.Drawing.Size(1350, 443);
            this.gcSolicitudCompra.TabIndex = 55;
            this.gcSolicitudCompra.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSolicitudCompra});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actualizafecharecepcionToolStripMenuItem,
            this.vercatalogotoolStripMenuItem,
            this.vercatalogosolestoolStripMenuItem1,
            this.verclasificacionpreciofototoolStripMenuItem,
            this.toolStripSeparator1,
            this.generarfacuracompratoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.ShowCheckMargin = true;
            this.mnuContextual.Size = new System.Drawing.Size(294, 120);
            // 
            // actualizafecharecepcionToolStripMenuItem
            // 
            this.actualizafecharecepcionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("actualizafecharecepcionToolStripMenuItem.Image")));
            this.actualizafecharecepcionToolStripMenuItem.Name = "actualizafecharecepcionToolStripMenuItem";
            this.actualizafecharecepcionToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.actualizafecharecepcionToolStripMenuItem.Text = "Actualiza Fecha de Recepción";
            this.actualizafecharecepcionToolStripMenuItem.Click += new System.EventHandler(this.actualizafecharecepcionToolStripMenuItem_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(290, 6);
            // 
            // generarfacuracompratoolStripMenuItem
            // 
            this.generarfacuracompratoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.FacturaCompra_32x32;
            this.generarfacuracompratoolStripMenuItem.Name = "generarfacuracompratoolStripMenuItem";
            this.generarfacuracompratoolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.generarfacuracompratoolStripMenuItem.Text = "Crear Factura De Compra";
            this.generarfacuracompratoolStripMenuItem.Click += new System.EventHandler(this.generarfacuracompratoolStripMenuItem_Click);
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
            this.txtPeriodo.TabIndex = 54;
            this.txtPeriodo.ToolTip = "Periodo";
            this.txtPeriodo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPeriodo_KeyUp);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(9, 31);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 53;
            this.labelControl7.Text = "Periodo:";
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(1350, 24);
            this.tlbMenu.TabIndex = 52;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotal.EditValue = "0.00";
            this.txtTotal.Location = new System.Drawing.Point(882, 500);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(98, 20);
            this.txtTotal.TabIndex = 82;
            // 
            // labelControl27
            // 
            this.labelControl27.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl27.Appearance.Options.UseFont = true;
            this.labelControl27.Location = new System.Drawing.Point(841, 503);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(35, 13);
            this.labelControl27.TabIndex = 81;
            this.labelControl27.Text = "Total :";
            // 
            // txtTotalCantidad
            // 
            this.txtTotalCantidad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalCantidad.EditValue = "0";
            this.txtTotalCantidad.Location = new System.Drawing.Point(981, 500);
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalCantidad.Properties.Appearance.Options.UseFont = true;
            this.txtTotalCantidad.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalCantidad.Properties.Mask.EditMask = "n";
            this.txtTotalCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalCantidad.Properties.ReadOnly = true;
            this.txtTotalCantidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalCantidad.Size = new System.Drawing.Size(77, 20);
            this.txtTotalCantidad.TabIndex = 82;
            // 
            // txtTotalItems
            // 
            this.txtTotalItems.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalItems.EditValue = "0";
            this.txtTotalItems.Location = new System.Drawing.Point(1059, 500);
            this.txtTotalItems.Name = "txtTotalItems";
            this.txtTotalItems.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalItems.Properties.Appearance.Options.UseFont = true;
            this.txtTotalItems.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalItems.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalItems.Properties.Mask.EditMask = "n";
            this.txtTotalItems.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalItems.Properties.ReadOnly = true;
            this.txtTotalItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalItems.Size = new System.Drawing.Size(77, 20);
            this.txtTotalItems.TabIndex = 82;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalRegistros.Location = new System.Drawing.Point(32, 503);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblTotalRegistros.TabIndex = 56;
            this.lblTotalRegistros.Text = "0 Registros";
            // 
            // frmManSolicitudCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 523);
            this.Controls.Add(this.txtTotalItems);
            this.Controls.Add(this.txtTotalCantidad);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.labelControl27);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.gcSolicitudCompra);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.tlbMenu);
            this.Name = "frmManSolicitudCompra";
            this.Text = "Solicitud Compra - Mantenimiento";
            this.Load += new System.EventHandler(this.frmManSolicitudCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSolicitudCompra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSolicitudCompra)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalItems.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
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
        public DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSolicitudCompra;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl gcSolicitudCompra;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem actualizafecharecepcionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vercatalogotoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vercatalogosolestoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verclasificacionpreciofototoolStripMenuItem;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem generarfacuracompratoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.TextEdit txtTotalCantidad;
        private DevExpress.XtraEditors.TextEdit txtTotalItems;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;

    }
}