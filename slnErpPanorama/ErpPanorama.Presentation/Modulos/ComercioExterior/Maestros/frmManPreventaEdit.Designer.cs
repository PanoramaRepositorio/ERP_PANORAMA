namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros
{
    partial class frmManPreventaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManPreventaEdit));
            this.tsmMenuSelText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.bsListado = new System.Windows.Forms.BindingSource(this.components);
            this.txtTotalVenta = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPreventaDetalle = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarprecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvPreventaDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtCodigo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescPreventa = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.txtObservacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalCantidad = new DevExpress.XtraEditors.TextEdit();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPreventaDetalle)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPreventaDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescPreventa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tsmMenuSelText
            // 
            this.tsmMenuSelText.Name = "tsmMenuSelText";
            this.tsmMenuSelText.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmMenuSelText.Size = new System.Drawing.Size(56, 20);
            this.tsmMenuSelText.Text = "SelText";
            // 
            // tsmMenuAgregar
            // 
            this.tsmMenuAgregar.Name = "tsmMenuAgregar";
            this.tsmMenuAgregar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmMenuAgregar.Size = new System.Drawing.Size(61, 20);
            this.tsmMenuAgregar.Text = "Agregar";
            this.tsmMenuAgregar.Click += new System.EventHandler(this.tsmMenuAgregar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMenuAgregar,
            this.tsmMenuEliminar,
            this.tsmMenuSelText});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(838, 24);
            this.menuStrip1.TabIndex = 119;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // tsmMenuEliminar
            // 
            this.tsmMenuEliminar.Name = "tsmMenuEliminar";
            this.tsmMenuEliminar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmMenuEliminar.Size = new System.Drawing.Size(62, 20);
            this.tsmMenuEliminar.Text = "Eliminar";
            this.tsmMenuEliminar.Click += new System.EventHandler(this.tsmMenuEliminar_Click);
            // 
            // txtTotalVenta
            // 
            this.txtTotalVenta.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalVenta.EditValue = "0";
            this.txtTotalVenta.Location = new System.Drawing.Point(640, 480);
            this.txtTotalVenta.Name = "txtTotalVenta";
            this.txtTotalVenta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalVenta.Properties.Appearance.Options.UseFont = true;
            this.txtTotalVenta.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalVenta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalVenta.Properties.Mask.EditMask = "n0";
            this.txtTotalVenta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalVenta.Properties.ReadOnly = true;
            this.txtTotalVenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalVenta.Size = new System.Drawing.Size(75, 20);
            this.txtTotalVenta.TabIndex = 12;
            // 
            // labelControl10
            // 
            this.labelControl10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Location = new System.Drawing.Point(521, 484);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(35, 13);
            this.labelControl10.TabIndex = 10;
            this.labelControl10.Text = "Total :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(732, 522);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(651, 522);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 13;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcPreventaDetalle;
            this.gridView1.Name = "gridView1";
            // 
            // gcPreventaDetalle
            // 
            this.gcPreventaDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcPreventaDetalle.ContextMenuStrip = this.mnuContextual;
            this.gcPreventaDetalle.Location = new System.Drawing.Point(0, 0);
            this.gcPreventaDetalle.MainView = this.gvPreventaDetalle;
            this.gcPreventaDetalle.Name = "gcPreventaDetalle";
            this.gcPreventaDetalle.Size = new System.Drawing.Size(788, 382);
            this.gcPreventaDetalle.TabIndex = 0;
            this.gcPreventaDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPreventaDetalle,
            this.gridView1});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.modificarprecioToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.toolStripSeparator1,
            this.importartoolStripMenuItem,
            this.exportartoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(121, 120);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // modificarprecioToolStripMenuItem
            // 
            this.modificarprecioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarprecioToolStripMenuItem.Image")));
            this.modificarprecioToolStripMenuItem.Name = "modificarprecioToolStripMenuItem";
            this.modificarprecioToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.modificarprecioToolStripMenuItem.Text = "Editar";
            this.modificarprecioToolStripMenuItem.Click += new System.EventHandler(this.modificarprecioToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // importartoolStripMenuItem
            // 
            this.importartoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importartoolStripMenuItem.Image")));
            this.importartoolStripMenuItem.Name = "importartoolStripMenuItem";
            this.importartoolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.importartoolStripMenuItem.Tag = "";
            this.importartoolStripMenuItem.Text = "Importar";
            this.importartoolStripMenuItem.ToolTipText = "[CodigoProveedor],[Cantidad]";
            this.importartoolStripMenuItem.Click += new System.EventHandler(this.importartoolStripMenuItem_Click);
            // 
            // exportartoolStripMenuItem
            // 
            this.exportartoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportartoolStripMenuItem.Image")));
            this.exportartoolStripMenuItem.Name = "exportartoolStripMenuItem";
            this.exportartoolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exportartoolStripMenuItem.Text = "Exportar";
            this.exportartoolStripMenuItem.Click += new System.EventHandler(this.exportartoolStripMenuItem_Click);
            // 
            // gvPreventaDetalle
            // 
            this.gvPreventaDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn6,
            this.gcCodigo,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn12,
            this.gridColumn7,
            this.gridColumn2});
            this.gvPreventaDetalle.GridControl = this.gcPreventaDetalle;
            this.gvPreventaDetalle.Name = "gvPreventaDetalle";
            this.gvPreventaDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvPreventaDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdPreventa";
            this.gridColumn3.FieldName = "IdPreventa";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdPreventaDetalle";
            this.gridColumn1.FieldName = "IdPreventaDetalle";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdProducto";
            this.gridColumn6.FieldName = "IdProducto";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.ColumnEdit = this.gcTxtCodigo;
            this.gcCodigo.FieldName = "CodigoProveedor";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 120;
            // 
            // gcTxtCodigo
            // 
            this.gcTxtCodigo.AutoHeight = false;
            this.gcTxtCodigo.Name = "gcTxtCodigo";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Descripción";
            this.gridColumn10.FieldName = "NombreProducto";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 1;
            this.gridColumn10.Width = 354;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "U.M";
            this.gridColumn9.FieldName = "Abreviatura";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            this.gridColumn9.Width = 29;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "C. Propuesta";
            this.gridColumn8.FieldName = "Cantidad";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 81;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "C. Venta";
            this.gridColumn12.FieldName = "CantidadVenta";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            this.gridColumn12.Width = 80;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "TipoOper";
            this.gridColumn7.FieldName = "TipoOper";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Diferencia";
            this.gridColumn2.FieldName = "Diferencia";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 5;
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gcPreventaDetalle);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(788, 382);
            this.xtraTabPage1.Text = "Productos";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Descripción:";
            // 
            // txtDescPreventa
            // 
            this.txtDescPreventa.Location = new System.Drawing.Point(93, 12);
            this.txtDescPreventa.Name = "txtDescPreventa";
            this.txtDescPreventa.Size = new System.Drawing.Size(439, 20);
            this.txtDescPreventa.TabIndex = 1;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(23, 64);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(794, 410);
            this.xtraTabControl1.TabIndex = 8;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(554, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Desde:";
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(732, 12);
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
            this.deHasta.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(694, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Hasta:";
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(594, 12);
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
            this.deDesde.TabIndex = 3;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(93, 34);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(719, 20);
            this.txtObservacion.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(23, 37);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(64, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Observación:";
            // 
            // txtTotalCantidad
            // 
            this.txtTotalCantidad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTotalCantidad.EditValue = "0";
            this.txtTotalCantidad.Location = new System.Drawing.Point(562, 480);
            this.txtTotalCantidad.Name = "txtTotalCantidad";
            this.txtTotalCantidad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalCantidad.Properties.Appearance.Options.UseFont = true;
            this.txtTotalCantidad.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalCantidad.Properties.Mask.EditMask = "n0";
            this.txtTotalCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalCantidad.Properties.ReadOnly = true;
            this.txtTotalCantidad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalCantidad.Size = new System.Drawing.Size(75, 20);
            this.txtTotalCantidad.TabIndex = 11;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalRegistros.Location = new System.Drawing.Point(28, 483);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(117, 13);
            this.lblTotalRegistros.TabIndex = 9;
            this.lblTotalRegistros.Text = "0 Registros encontrados";
            // 
            // prgFactura
            // 
            this.prgFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prgFactura.Location = new System.Drawing.Point(193, 482);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(319, 18);
            this.prgFactura.TabIndex = 127;
            // 
            // frmManPreventaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 557);
            this.Controls.Add(this.prgFactura);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.deHasta);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.deDesde);
            this.Controls.Add(this.txtTotalCantidad);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtTotalVenta);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDescPreventa);
            this.Controls.Add(this.xtraTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManPreventaEdit";
            this.Load += new System.EventHandler(this.frmManPreventaEdit_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPreventaDetalle)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPreventaDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescPreventa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmMenuSelText;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuAgregar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuEliminar;
        private System.Windows.Forms.BindingSource bsListado;
        private DevExpress.XtraEditors.TextEdit txtTotalVenta;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gcPreventaDetalle;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarprecioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPreventaDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDescPreventa;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private DevExpress.XtraEditors.TextEdit txtObservacion;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTotalCantidad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importartoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportartoolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;

    }
}