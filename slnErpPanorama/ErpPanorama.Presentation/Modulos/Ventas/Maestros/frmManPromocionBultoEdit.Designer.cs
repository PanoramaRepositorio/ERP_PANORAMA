namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManPromocionBultoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManPromocionBultoEdit));
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPromocionBultoDetalle = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarprecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.importartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarporcodigotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarporhangtagtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvPromocionBultoDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deDesde = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescPromocionBulto = new DevExpress.XtraEditors.TextEdit();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.tsmMenuSelText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.bsListado = new System.Windows.Forms.BindingSource(this.components);
            this.picImage = new System.Windows.Forms.PictureBox();
            this.cboTipoCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboFormaPago = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.gcTxtCodigo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromocionBultoDetalle)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPromocionBultoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescPromocionBulto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(429, 23);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(383, 20);
            this.cboEmpresa.TabIndex = 148;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcPromocionBultoDetalle;
            this.gridView1.Name = "gridView1";
            // 
            // gcPromocionBultoDetalle
            // 
            this.gcPromocionBultoDetalle.ContextMenuStrip = this.mnuContextual;
            this.gcPromocionBultoDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPromocionBultoDetalle.Location = new System.Drawing.Point(0, 0);
            this.gcPromocionBultoDetalle.MainView = this.gvPromocionBultoDetalle;
            this.gcPromocionBultoDetalle.Name = "gcPromocionBultoDetalle";
            this.gcPromocionBultoDetalle.Size = new System.Drawing.Size(778, 356);
            this.gcPromocionBultoDetalle.TabIndex = 0;
            this.gcPromocionBultoDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPromocionBultoDetalle,
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
            this.importartoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importarporcodigotoolStripMenuItem,
            this.importarporhangtagtoolStripMenuItem});
            this.importartoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importartoolStripMenuItem.Image")));
            this.importartoolStripMenuItem.Name = "importartoolStripMenuItem";
            this.importartoolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.importartoolStripMenuItem.Text = "Importar";
            // 
            // importarporcodigotoolStripMenuItem
            // 
            this.importarporcodigotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.importarporcodigotoolStripMenuItem.Name = "importarporcodigotoolStripMenuItem";
            this.importarporcodigotoolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.importarporcodigotoolStripMenuItem.Text = "Por Código";
            this.importarporcodigotoolStripMenuItem.ToolTipText = "[Codigo],[Dscto]";
            this.importarporcodigotoolStripMenuItem.Click += new System.EventHandler(this.importarporcodigotoolStripMenuItem_Click);
            // 
            // importarporhangtagtoolStripMenuItem
            // 
            this.importarporhangtagtoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.importarporhangtagtoolStripMenuItem.Name = "importarporhangtagtoolStripMenuItem";
            this.importarporhangtagtoolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.importarporhangtagtoolStripMenuItem.Text = "Por HangTag";
            this.importarporhangtagtoolStripMenuItem.ToolTipText = "[HangTag],[Dscto]";
            this.importarporhangtagtoolStripMenuItem.Click += new System.EventHandler(this.importarporhangtagtoolStripMenuItem_Click);
            // 
            // exportartoolStripMenuItem
            // 
            this.exportartoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exportartoolStripMenuItem.Image")));
            this.exportartoolStripMenuItem.Name = "exportartoolStripMenuItem";
            this.exportartoolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.exportartoolStripMenuItem.Text = "Exportar";
            this.exportartoolStripMenuItem.Click += new System.EventHandler(this.exportartoolStripMenuItem_Click);
            // 
            // gvPromocionBultoDetalle
            // 
            this.gvPromocionBultoDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gvPromocionBultoDetalle.GridControl = this.gcPromocionBultoDetalle;
            this.gvPromocionBultoDetalle.Name = "gvPromocionBultoDetalle";
            this.gvPromocionBultoDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvPromocionBultoDetalle.OptionsView.ShowGroupPanel = false;
            this.gvPromocionBultoDetalle.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvPromocionBultoDetalle_RowClick);
            this.gvPromocionBultoDetalle.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvPromocionBultoDetalle_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdPromocion2x1Detalle";
            this.gridColumn1.FieldName = "IdPromocion2x1Detalle";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdPromocion2x1";
            this.gridColumn2.FieldName = "IdPromocion2x1";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "HangTag";
            this.gridColumn3.FieldName = "IdProducto";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Código";
            this.gridColumn4.FieldName = "CodigoProveedor";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 152;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "NombreProducto";
            this.gridColumn5.FieldName = "NombreProducto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 284;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "U.M.";
            this.gridColumn6.FieldName = "Abreviatura";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 62;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "FlagEstado";
            this.gridColumn7.FieldName = "FlagEstado";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "TipoOper";
            this.gridColumn8.FieldName = "TipoOper";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "F. Recepción";
            this.gridColumn9.FieldName = "Fecha";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "% Dscto";
            this.gridColumn10.FieldName = "Descuento";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.ToolTip = "Aumenta el descuento final después de todo Cálculo";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 5;
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalRegistros.Location = new System.Drawing.Point(41, 464);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(117, 13);
            this.lblTotalRegistros.TabIndex = 158;
            this.lblTotalRegistros.Text = "0 Registros encontrados";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(567, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 153;
            this.labelControl2.Text = "Desde:";
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(732, 44);
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
            this.deHasta.TabIndex = 156;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(696, 47);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 155;
            this.labelControl3.Text = "Hasta:";
            // 
            // deDesde
            // 
            this.deDesde.EditValue = null;
            this.deDesde.Location = new System.Drawing.Point(607, 44);
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
            this.deDesde.TabIndex = 154;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 145;
            this.labelControl1.Text = "Descripción:";
            // 
            // txtDescPromocionBulto
            // 
            this.txtDescPromocionBulto.Location = new System.Drawing.Point(93, 23);
            this.txtDescPromocionBulto.Name = "txtDescPromocionBulto";
            this.txtDescPromocionBulto.Size = new System.Drawing.Size(263, 20);
            this.txtDescPromocionBulto.TabIndex = 146;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(23, 71);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(784, 384);
            this.xtraTabControl1.TabIndex = 157;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gcPromocionBultoDetalle);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(778, 356);
            this.xtraTabPage1.Text = "Productos";
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
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMenuAgregar,
            this.tsmMenuEliminar,
            this.tsmMenuSelText});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip1.TabIndex = 162;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // tsmMenuEliminar
            // 
            this.tsmMenuEliminar.Name = "tsmMenuEliminar";
            this.tsmMenuEliminar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmMenuEliminar.Size = new System.Drawing.Size(62, 20);
            this.tsmMenuEliminar.Text = "Eliminar";
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(816, 26);
            this.picImage.Margin = new System.Windows.Forms.Padding(1);
            this.picImage.MinimumSize = new System.Drawing.Size(85, 85);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(333, 423);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 163;
            this.picImage.TabStop = false;
            // 
            // cboTipoCliente
            // 
            this.cboTipoCliente.Location = new System.Drawing.Point(93, 45);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoCliente.Properties.NullText = "";
            this.cboTipoCliente.Size = new System.Drawing.Size(263, 20);
            this.cboTipoCliente.TabIndex = 150;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(23, 48);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 13);
            this.labelControl5.TabIndex = 149;
            this.labelControl5.Text = "Tipo Cliente:";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.Location = new System.Drawing.Point(429, 45);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFormaPago.Properties.NullText = "";
            this.cboFormaPago.Size = new System.Drawing.Size(127, 20);
            this.cboFormaPago.TabIndex = 152;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(362, 47);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(61, 13);
            this.labelControl4.TabIndex = 151;
            this.labelControl4.Text = "Forma Pago:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(711, 462);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 161;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(630, 462);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 160;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(378, 26);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(45, 13);
            this.labelControl8.TabIndex = 147;
            this.labelControl8.Text = "Empresa:";
            // 
            // prgFactura
            // 
            this.prgFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prgFactura.Location = new System.Drawing.Point(210, 464);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(375, 18);
            this.prgFactura.TabIndex = 159;
            // 
            // gcTxtCodigo
            // 
            this.gcTxtCodigo.AutoHeight = false;
            this.gcTxtCodigo.Name = "gcTxtCodigo";
            // 
            // frmManPromocionBultoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 491);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.lblTotalRegistros);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.deHasta);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.deDesde);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDescPromocionBulto);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.cboTipoCliente);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.prgFactura);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManPromocionBultoEdit";
            this.Load += new System.EventHandler(this.frmManPromocionBultoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromocionBultoDetalle)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPromocionBultoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescPromocionBulto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gcPromocionBultoDetalle;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarprecioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importartoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarporcodigotoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarporhangtagtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportartoolStripMenuItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPromocionBultoDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deDesde;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDescPromocionBulto;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuSelText;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuAgregar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuEliminar;
        private System.Windows.Forms.BindingSource bsListado;
        private System.Windows.Forms.PictureBox picImage;
        public DevExpress.XtraEditors.LookUpEdit cboTipoCliente;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit cboFormaPago;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}