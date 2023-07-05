namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegGestionInventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegGestionInventario));
            this.chkHangTag = new System.Windows.Forms.CheckBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.tsmMenuSelText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImportarBulto = new DevExpress.XtraEditors.SimpleButton();
            this.btnImportarAnaquel = new DevExpress.XtraEditors.SimpleButton();
            this.btnPersonal = new DevExpress.XtraEditors.SimpleButton();
            this.btnVerPersonal = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.lblRegistros = new DevExpress.XtraEditors.LabelControl();
            this.gcInventario = new DevExpress.XtraGrid.GridControl();
            this.gvInventario = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtCodigo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // chkHangTag
            // 
            this.chkHangTag.AutoSize = true;
            this.chkHangTag.Location = new System.Drawing.Point(14, 23);
            this.chkHangTag.Name = "chkHangTag";
            this.chkHangTag.Size = new System.Drawing.Size(15, 14);
            this.chkHangTag.TabIndex = 118;
            this.chkHangTag.UseVisualStyleBackColor = true;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(265, 23);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 13);
            this.labelControl4.TabIndex = 116;
            this.labelControl4.Text = "Tienda:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(640, 20);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.MaxLength = 50;
            this.txtCodigo.Size = new System.Drawing.Size(212, 20);
            this.txtCodigo.TabIndex = 113;
            this.txtCodigo.EditValueChanged += new System.EventHandler(this.txtCodigo_EditValueChanged);
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(118, 48);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.tsmMenuAgregar_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.tsmMenuEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Add_16x16;
            this.btnNuevo.ImageOptions.ImageIndex = 1;
            this.btnNuevo.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(35, 17);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(67, 23);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.ToolTip = "Nuevo , Si el check esta activado buscará por HangTag";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.ImageOptions.Image")));
            this.btnEliminar.ImageOptions.ImageIndex = 1;
            this.btnEliminar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(181, 17);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(67, 23);
            this.btnEliminar.TabIndex = 84;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(307, 20);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(181, 20);
            this.cboTienda.TabIndex = 117;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(597, 23);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(37, 13);
            this.lblDescripcion.TabIndex = 112;
            this.lblDescripcion.Text = "Código:";
            // 
            // tsmMenuSelText
            // 
            this.tsmMenuSelText.Name = "tsmMenuSelText";
            this.tsmMenuSelText.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmMenuSelText.Size = new System.Drawing.Size(55, 20);
            this.tsmMenuSelText.Text = "SelText";
            // 
            // tsmMenuEliminar
            // 
            this.tsmMenuEliminar.Name = "tsmMenuEliminar";
            this.tsmMenuEliminar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmMenuEliminar.Size = new System.Drawing.Size(62, 20);
            this.tsmMenuEliminar.Text = "Eliminar";
            this.tsmMenuEliminar.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // tsmMenuAgregar
            // 
            this.tsmMenuAgregar.Name = "tsmMenuAgregar";
            this.tsmMenuAgregar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmMenuAgregar.Size = new System.Drawing.Size(61, 20);
            this.tsmMenuAgregar.Text = "Agregar";
            this.tsmMenuAgregar.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMenuAgregar,
            this.tsmMenuEliminar,
            this.tsmMenuSelText});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1524, 24);
            this.menuStrip1.TabIndex = 119;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.ImageOptions.Image")));
            this.btnEditar.ImageOptions.ImageIndex = 1;
            this.btnEditar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(108, 17);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(67, 23);
            this.btnEditar.TabIndex = 85;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.btnPersonal);
            this.splitContainer1.Panel1.Controls.Add(this.btnVerPersonal);
            this.splitContainer1.Panel1.Controls.Add(this.btnVer);
            this.splitContainer1.Panel1.Controls.Add(this.btnConsultar);
            this.splitContainer1.Panel1.Controls.Add(this.btnExportar);
            this.splitContainer1.Panel1.Controls.Add(this.chkHangTag);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodigo);
            this.splitContainer1.Panel1.Controls.Add(this.btnNuevo);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainer1.Panel1.Controls.Add(this.btnEliminar);
            this.splitContainer1.Panel1.Controls.Add(this.cboTienda);
            this.splitContainer1.Panel1.Controls.Add(this.lblDescripcion);
            this.splitContainer1.Panel1.Controls.Add(this.btnEditar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtTotal);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl27);
            this.splitContainer1.Panel2.Controls.Add(this.lblRegistros);
            this.splitContainer1.Panel2.Controls.Add(this.gcInventario);
            this.splitContainer1.Size = new System.Drawing.Size(1524, 666);
            this.splitContainer1.SplitterDistance = 60;
            this.splitContainer1.TabIndex = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImportarBulto);
            this.groupBox1.Controls.Add(this.btnImportarAnaquel);
            this.groupBox1.Location = new System.Drawing.Point(1147, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 41);
            this.groupBox1.TabIndex = 90;
            this.groupBox1.TabStop = false;
            // 
            // btnImportarBulto
            // 
            this.btnImportarBulto.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Bultos_16x16;
            this.btnImportarBulto.ImageOptions.ImageIndex = 1;
            this.btnImportarBulto.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnImportarBulto.Location = new System.Drawing.Point(6, 12);
            this.btnImportarBulto.Name = "btnImportarBulto";
            this.btnImportarBulto.Size = new System.Drawing.Size(103, 23);
            this.btnImportarBulto.TabIndex = 122;
            this.btnImportarBulto.Text = "Importar Bulto";
            this.btnImportarBulto.ToolTip = "Capturar la Cantidad de Bultos";
            this.btnImportarBulto.Click += new System.EventHandler(this.btnImportarBulto_Click);
            // 
            // btnImportarAnaquel
            // 
            this.btnImportarAnaquel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImportarAnaquel.ImageOptions.Image")));
            this.btnImportarAnaquel.ImageOptions.ImageIndex = 1;
            this.btnImportarAnaquel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnImportarAnaquel.Location = new System.Drawing.Point(115, 12);
            this.btnImportarAnaquel.Name = "btnImportarAnaquel";
            this.btnImportarAnaquel.Size = new System.Drawing.Size(67, 23);
            this.btnImportarAnaquel.TabIndex = 122;
            this.btnImportarAnaquel.Text = "I. Anaq.";
            this.btnImportarAnaquel.ToolTip = "Importar Inventario de Anaqueles";
            this.btnImportarAnaquel.Click += new System.EventHandler(this.btnImportarAnaquel_Click);
            // 
            // btnPersonal
            // 
            this.btnPersonal.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.ComisionVendedor_16x161;
            this.btnPersonal.Location = new System.Drawing.Point(570, 20);
            this.btnPersonal.Name = "btnPersonal";
            this.btnPersonal.Size = new System.Drawing.Size(25, 20);
            this.btnPersonal.TabIndex = 123;
            this.btnPersonal.Text = "Consultar";
            this.btnPersonal.Visible = false;
            // 
            // btnVerPersonal
            // 
            this.btnVerPersonal.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVerPersonal.ImageOptions.ImageIndex = 1;
            this.btnVerPersonal.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVerPersonal.Location = new System.Drawing.Point(1049, 17);
            this.btnVerPersonal.Name = "btnVerPersonal";
            this.btnVerPersonal.Size = new System.Drawing.Size(92, 23);
            this.btnVerPersonal.TabIndex = 122;
            this.btnVerPersonal.Text = "Por Persona";
            this.btnVerPersonal.Click += new System.EventHandler(this.btnVerPersona_Click);
            // 
            // btnVer
            // 
            this.btnVer.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageOptions.ImageIndex = 1;
            this.btnVer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(951, 17);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 121;
            this.btnVer.Text = "Por Tienda";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(494, 20);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(73, 20);
            this.btnConsultar.TabIndex = 120;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.btnExportar.ImageOptions.ImageIndex = 1;
            this.btnExportar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(870, 17);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 119;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.EditValue = "0";
            this.txtTotal.Location = new System.Drawing.Point(620, 579);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.DisplayFormat.FormatString = "d";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "d";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(87, 20);
            this.txtTotal.TabIndex = 89;
            // 
            // labelControl27
            // 
            this.labelControl27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl27.Appearance.Options.UseFont = true;
            this.labelControl27.Location = new System.Drawing.Point(526, 582);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(88, 13);
            this.labelControl27.TabIndex = 88;
            this.labelControl27.Text = "Cantidad Total :";
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistros.Location = new System.Drawing.Point(14, 582);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblRegistros.TabIndex = 87;
            this.lblRegistros.Text = "0 Registros";
            // 
            // gcInventario
            // 
            this.gcInventario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcInventario.ContextMenuStrip = this.mnuContextual;
            this.gcInventario.Location = new System.Drawing.Point(0, 0);
            this.gcInventario.MainView = this.gvInventario;
            this.gcInventario.Name = "gcInventario";
            this.gcInventario.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtCodigo});
            this.gcInventario.Size = new System.Drawing.Size(1524, 573);
            this.gcInventario.TabIndex = 83;
            this.gcInventario.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInventario});
            // 
            // gvInventario
            // 
            this.gvInventario.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn11,
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn4,
            this.gcCodigo,
            this.gridColumn10,
            this.gridColumn7,
            this.gcCantidad,
            this.gridColumn2,
            this.gridColumn15,
            this.gridColumn9,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn16,
            this.gridColumn18});
            this.gvInventario.GridControl = this.gcInventario;
            this.gvInventario.Name = "gvInventario";
            this.gvInventario.OptionsSelection.MultiSelect = true;
            this.gvInventario.OptionsView.ColumnAutoWidth = false;
            this.gvInventario.OptionsView.ShowGroupPanel = false;
            this.gvInventario.ColumnFilterChanged += new System.EventHandler(this.gvInventario_ColumnFilterChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdEmpresa";
            this.gridColumn1.FieldName = "IdMovimientoAlmancen";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdInventario";
            this.gridColumn11.FieldName = "IdInventario";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdTienda";
            this.gridColumn3.FieldName = "IdTienda";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Tienda";
            this.gridColumn5.FieldName = "DescTienda";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdAlmacen";
            this.gridColumn8.FieldName = "IdAlmacen";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Almacen";
            this.gridColumn6.FieldName = "DescAlmacen";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IdProducto";
            this.gridColumn4.FieldName = "IdProducto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            // 
            // gcCodigo
            // 
            this.gcCodigo.Caption = "Código";
            this.gcCodigo.ColumnEdit = this.gcTxtCodigo;
            this.gcCodigo.FieldName = "CodigoProveedor";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.AllowEdit = false;
            this.gcCodigo.OptionsColumn.AllowFocus = false;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 3;
            this.gcCodigo.Width = 100;
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
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 249;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "U.M";
            this.gridColumn7.FieldName = "Abreviatura";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 50;
            // 
            // gcCantidad
            // 
            this.gcCantidad.Caption = "Cantidad";
            this.gcCantidad.FieldName = "Cantidad";
            this.gcCantidad.Name = "gcCantidad";
            this.gcCantidad.OptionsColumn.AllowEdit = false;
            this.gcCantidad.OptionsColumn.AllowFocus = false;
            this.gcCantidad.Visible = true;
            this.gcCantidad.VisibleIndex = 6;
            this.gcCantidad.Width = 60;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ubicación";
            this.gridColumn2.FieldName = "Ubicacion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "IdPersona";
            this.gridColumn15.FieldName = "IdPersona";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Encargado";
            this.gridColumn9.FieldName = "DescVendedor";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            this.gridColumn9.Width = 235;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Fecha";
            this.gridColumn12.FieldName = "Fecha";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Observación";
            this.gridColumn13.FieldName = "Observacion";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 10;
            this.gridColumn13.Width = 187;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "P. Apoyo";
            this.gridColumn14.FieldName = "ApeNom2";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 9;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Piso";
            this.gridColumn16.FieldName = "DescAlmacenPiso";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 2;
            this.gridColumn16.Width = 51;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "F. Registro";
            this.gridColumn18.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn18.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn18.FieldName = "FechaRegistro";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 11;
            this.gridColumn18.Width = 136;
            // 
            // frmRegGestionInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 666);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmRegGestionInventario";
            this.Text = "Registro de Gestión de Inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegGestionInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkHangTag;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        public DevExpress.XtraEditors.SimpleButton btnNuevo;
        public DevExpress.XtraEditors.SimpleButton btnEliminar;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuSelText;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuAgregar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public DevExpress.XtraEditors.SimpleButton btnEditar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        private DevExpress.XtraGrid.GridControl gcInventario;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInventario;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        public DevExpress.XtraEditors.SimpleButton btnVerPersonal;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.LabelControl lblRegistros;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        public DevExpress.XtraEditors.SimpleButton btnImportarBulto;
        private DevExpress.XtraEditors.SimpleButton btnPersonal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        public DevExpress.XtraEditors.SimpleButton btnImportarAnaquel;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
    }
}