namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegInventarioAnaqueles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegInventarioAnaqueles));
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.lblRegistros = new DevExpress.XtraEditors.LabelControl();
            this.gcInventarioAnaqueles = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrartodotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvInventarioAnaqueles = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chkHangTag = new System.Windows.Forms.CheckBox();
            this.btnNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuSelText = new System.Windows.Forms.ToolStripMenuItem();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.cboAlmacen = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnBuscarPersona = new DevExpress.XtraEditors.SimpleButton();
            this.txtPersona = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPersonaApoyo = new DevExpress.XtraEditors.TextEdit();
            this.lblDes = new DevExpress.XtraEditors.LabelControl();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInventarioAnaqueles)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInventarioAnaqueles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonaApoyo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(592, 27);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 20);
            this.btnConsultar.TabIndex = 119;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.EditValue = "0";
            this.txtTotal.Location = new System.Drawing.Point(756, 433);
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
            this.txtTotal.TabIndex = 86;
            // 
            // labelControl27
            // 
            this.labelControl27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl27.Location = new System.Drawing.Point(662, 436);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(88, 13);
            this.labelControl27.TabIndex = 85;
            this.labelControl27.Text = "Cantidad Total :";
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistros.Location = new System.Drawing.Point(25, 436);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblRegistros.TabIndex = 84;
            this.lblRegistros.Text = "0 Registros";
            // 
            // gcInventarioAnaqueles
            // 
            this.gcInventarioAnaqueles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcInventarioAnaqueles.ContextMenuStrip = this.mnuContextual;
            this.gcInventarioAnaqueles.Location = new System.Drawing.Point(0, 0);
            this.gcInventarioAnaqueles.MainView = this.gvInventarioAnaqueles;
            this.gcInventarioAnaqueles.Name = "gcInventarioAnaqueles";
            this.gcInventarioAnaqueles.Size = new System.Drawing.Size(1362, 427);
            this.gcInventarioAnaqueles.TabIndex = 83;
            this.gcInventarioAnaqueles.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInventarioAnaqueles});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.mostrartodotoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(146, 70);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // mostrartodotoolStripMenuItem
            // 
            this.mostrartodotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultar_16x16;
            this.mostrartodotoolStripMenuItem.Name = "mostrartodotoolStripMenuItem";
            this.mostrartodotoolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.mostrartodotoolStripMenuItem.Text = "Mostrar Todo";
            this.mostrartodotoolStripMenuItem.Click += new System.EventHandler(this.mostrartodotoolStripMenuItem_Click);
            // 
            // gvInventarioAnaqueles
            // 
            this.gvInventarioAnaqueles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gridColumn12});
            this.gvInventarioAnaqueles.GridControl = this.gcInventarioAnaqueles;
            this.gvInventarioAnaqueles.Name = "gvInventarioAnaqueles";
            this.gvInventarioAnaqueles.OptionsView.ColumnAutoWidth = false;
            this.gvInventarioAnaqueles.OptionsView.ShowGroupPanel = false;
            this.gvInventarioAnaqueles.ColumnFilterChanged += new System.EventHandler(this.gvInventarioAnaqueles_ColumnFilterChanged);
            this.gvInventarioAnaqueles.DoubleClick += new System.EventHandler(this.gvInventarioAnaqueles_DoubleClick);
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
            this.gridColumn11.Caption = "IdInventarioAnaqueles";
            this.gridColumn11.FieldName = "IdInventarioAnaqueles";
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
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
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
            this.gridColumn6.Width = 160;
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
            this.gcCodigo.VisibleIndex = 2;
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
            this.gridColumn10.VisibleIndex = 3;
            this.gridColumn10.Width = 350;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "U.M";
            this.gridColumn7.FieldName = "Abreviatura";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
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
            this.gcCantidad.VisibleIndex = 5;
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
            this.gridColumn2.VisibleIndex = 6;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "TipoOper";
            this.gridColumn15.FieldName = "TipoOper";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Observación";
            this.gridColumn9.FieldName = "Observacion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 220;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Persona";
            this.gridColumn12.FieldName = "DescVendedor";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            this.gridColumn12.Width = 254;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(232, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(33, 13);
            this.labelControl2.TabIndex = 119;
            this.labelControl2.Text = "Fecha:";
            // 
            // chkHangTag
            // 
            this.chkHangTag.AutoSize = true;
            this.chkHangTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkHangTag.Location = new System.Drawing.Point(15, 7);
            this.chkHangTag.Name = "chkHangTag";
            this.chkHangTag.Size = new System.Drawing.Size(69, 17);
            this.chkHangTag.TabIndex = 118;
            this.chkHangTag.Text = "&HangTag";
            this.chkHangTag.UseVisualStyleBackColor = false;
            this.chkHangTag.CheckedChanged += new System.EventHandler(this.chkHangTag_CheckedChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::ErpPanorama.Presentation.Properties.Resources.Add_16x16;
            this.btnNuevo.ImageIndex = 1;
            this.btnNuevo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(12, 26);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(67, 23);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.ToolTip = "Nuevo , Si el check esta activado buscará por HangTag";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageIndex = 1;
            this.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(158, 26);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(67, 23);
            this.btnEliminar.TabIndex = 84;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageIndex = 1;
            this.btnEditar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(85, 26);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(67, 23);
            this.btnEditar.TabIndex = 85;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMenuAgregar,
            this.tsmMenuEliminar,
            this.tsmMenuSelText});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 24);
            this.menuStrip1.TabIndex = 119;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Visible = false;
            // 
            // tsmMenuAgregar
            // 
            this.tsmMenuAgregar.Name = "tsmMenuAgregar";
            this.tsmMenuAgregar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmMenuAgregar.Size = new System.Drawing.Size(61, 20);
            this.tsmMenuAgregar.Text = "Agregar";
            this.tsmMenuAgregar.Click += new System.EventHandler(this.tsmMenuAgregar_Click);
            // 
            // tsmMenuEliminar
            // 
            this.tsmMenuEliminar.Name = "tsmMenuEliminar";
            this.tsmMenuEliminar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.tsmMenuEliminar.Size = new System.Drawing.Size(62, 20);
            this.tsmMenuEliminar.Text = "Eliminar";
            this.tsmMenuEliminar.Click += new System.EventHandler(this.tsmMenuEliminar_Click);
            // 
            // tsmMenuSelText
            // 
            this.tsmMenuSelText.Name = "tsmMenuSelText";
            this.tsmMenuSelText.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmMenuSelText.Size = new System.Drawing.Size(55, 20);
            this.tsmMenuSelText.Text = "SelText";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(1050, 28);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.MaxLength = 50;
            this.txtCodigo.Size = new System.Drawing.Size(300, 20);
            this.txtCodigo.TabIndex = 113;
            this.txtCodigo.EditValueChanged += new System.EventHandler(this.txtCodigo_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(373, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 13);
            this.labelControl4.TabIndex = 116;
            this.labelControl4.Text = "Tienda:";
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(415, 7);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(171, 20);
            this.cboTienda.TabIndex = 117;
            this.cboTienda.EditValueChanged += new System.EventHandler(this.cboTienda_EditValueChanged);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Location = new System.Drawing.Point(415, 28);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAlmacen.Properties.NullText = "";
            this.cboAlmacen.Size = new System.Drawing.Size(171, 20);
            this.cboAlmacen.TabIndex = 115;
            this.cboAlmacen.EditValueChanged += new System.EventHandler(this.cboAlmacen_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(365, 28);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(44, 13);
            this.labelControl6.TabIndex = 114;
            this.labelControl6.Text = "Almacén:";
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
            this.splitContainer1.Panel1.Controls.Add(this.btnBuscarPersona);
            this.splitContainer1.Panel1.Controls.Add(this.txtPersona);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.txtPersonaApoyo);
            this.splitContainer1.Panel1.Controls.Add(this.lblDes);
            this.splitContainer1.Panel1.Controls.Add(this.btnExportar);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel1.Controls.Add(this.btnConsultar);
            this.splitContainer1.Panel1.Controls.Add(this.chkHangTag);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodigo);
            this.splitContainer1.Panel1.Controls.Add(this.btnNuevo);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl4);
            this.splitContainer1.Panel1.Controls.Add(this.btnEliminar);
            this.splitContainer1.Panel1.Controls.Add(this.deFecha);
            this.splitContainer1.Panel1.Controls.Add(this.cboTienda);
            this.splitContainer1.Panel1.Controls.Add(this.cboAlmacen);
            this.splitContainer1.Panel1.Controls.Add(this.btnEditar);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtTotal);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl27);
            this.splitContainer1.Panel2.Controls.Add(this.lblRegistros);
            this.splitContainer1.Panel2.Controls.Add(this.gcInventarioAnaqueles);
            this.splitContainer1.Size = new System.Drawing.Size(1362, 525);
            this.splitContainer1.SplitterDistance = 62;
            this.splitContainer1.TabIndex = 120;
            // 
            // btnBuscarPersona
            // 
            this.btnBuscarPersona.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPersona.Image")));
            this.btnBuscarPersona.Location = new System.Drawing.Point(1004, 29);
            this.btnBuscarPersona.Name = "btnBuscarPersona";
            this.btnBuscarPersona.Size = new System.Drawing.Size(26, 20);
            this.btnBuscarPersona.TabIndex = 128;
            this.btnBuscarPersona.Click += new System.EventHandler(this.btnBuscarPersona_Click);
            // 
            // txtPersona
            // 
            this.txtPersona.Location = new System.Drawing.Point(745, 6);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.Properties.ReadOnly = true;
            this.txtPersona.Size = new System.Drawing.Size(282, 20);
            this.txtPersona.TabIndex = 126;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(699, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 124;
            this.labelControl1.Text = "Usuario:";
            // 
            // txtPersonaApoyo
            // 
            this.txtPersonaApoyo.Location = new System.Drawing.Point(745, 28);
            this.txtPersonaApoyo.Name = "txtPersonaApoyo";
            this.txtPersonaApoyo.Properties.ReadOnly = true;
            this.txtPersonaApoyo.Size = new System.Drawing.Size(259, 20);
            this.txtPersonaApoyo.TabIndex = 127;
            // 
            // lblDes
            // 
            this.lblDes.Location = new System.Drawing.Point(700, 24);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(39, 26);
            this.lblDes.TabIndex = 125;
            this.lblDes.Text = "Persona\r\nApoyo:";
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.btnExportar.ImageIndex = 1;
            this.btnExportar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(592, 3);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 121;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(273, 27);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFecha.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.deFecha.Properties.ShowPopupShadow = false;
            this.deFecha.Properties.ShowToday = false;
            this.deFecha.Size = new System.Drawing.Size(80, 20);
            this.deFecha.TabIndex = 120;
            // 
            // frmRegInventarioAnaqueles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 525);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmRegInventarioAnaqueles";
            this.Text = "Inventario Anaqueles";
            this.Load += new System.EventHandler(this.frmRegInventarioAnaqueles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInventarioAnaqueles)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvInventarioAnaqueles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPersona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonaApoyo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.LabelControl lblRegistros;
        private DevExpress.XtraGrid.GridControl gcInventarioAnaqueles;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInventarioAnaqueles;
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
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.CheckBox chkHangTag;
        public DevExpress.XtraEditors.SimpleButton btnNuevo;
        public DevExpress.XtraEditors.SimpleButton btnEliminar;
        public DevExpress.XtraEditors.SimpleButton btnEditar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuAgregar;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuEliminar;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuSelText;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        public DevExpress.XtraEditors.LookUpEdit cboAlmacen;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.DateEdit deFecha;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private System.Windows.Forms.ToolStripMenuItem mostrartodotoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.SimpleButton btnBuscarPersona;
        private DevExpress.XtraEditors.TextEdit txtPersona;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPersonaApoyo;
        private DevExpress.XtraEditors.LabelControl lblDes;
    }
}