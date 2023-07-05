namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegInventarioAgregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegInventarioAgregar));
            this.btnEditar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEliminar = new DevExpress.XtraEditors.SimpleButton();
            this.btnNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.gcInventario = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ImportartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportarporHangTagtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvInventario = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.cboAlmacen = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.bsListado = new System.Windows.Forms.BindingSource(this.components);
            this.chkHangTag = new System.Windows.Forms.CheckBox();
            this.lblRegistros = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.chkUbicacion = new System.Windows.Forms.CheckBox();
            this.btnBuscarPersona = new DevExpress.XtraEditors.SimpleButton();
            this.txtPersonaApoyo = new DevExpress.XtraEditors.TextEdit();
            this.lblDes = new DevExpress.XtraEditors.LabelControl();
            this.txtPersona = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboAlmacenPiso = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInventario)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonaApoyo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenPiso.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEditar
            // 
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageIndex = 1;
            this.btnEditar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(88, 7);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(67, 23);
            this.btnEditar.TabIndex = 85;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageIndex = 1;
            this.btnEliminar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(161, 7);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(67, 23);
            this.btnEliminar.TabIndex = 84;
            this.btnEliminar.Text = "E&liminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::ErpPanorama.Presentation.Properties.Resources.Add_16x16;
            this.btnNuevo.ImageIndex = 1;
            this.btnNuevo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(15, 7);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(67, 23);
            this.btnNuevo.TabIndex = 83;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(1103, 490);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(91, 23);
            this.btnGrabar.TabIndex = 86;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // gcInventario
            // 
            this.gcInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gcInventario.ContextMenuStrip = this.mnuContextual;
            this.gcInventario.Location = new System.Drawing.Point(10, 55);
            this.gcInventario.MainView = this.gvInventario;
            this.gcInventario.Name = "gcInventario";
            this.gcInventario.Size = new System.Drawing.Size(1194, 429);
            this.gcInventario.TabIndex = 88;
            this.gcInventario.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInventario});
            this.gcInventario.Click += new System.EventHandler(this.gcInventario_Click);
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.toolStripSeparator1,
            this.ImportartoolStripMenuItem,
            this.ImportarporHangTagtoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(193, 98);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // ImportartoolStripMenuItem
            // 
            this.ImportartoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.ImportartoolStripMenuItem.Name = "ImportartoolStripMenuItem";
            this.ImportartoolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ImportartoolStripMenuItem.Text = "Importar por Código";
            this.ImportartoolStripMenuItem.ToolTipText = "[Codigo],[Descripcion],[UM],[Cantidad],[Ubicacion],[Observación]";
            this.ImportartoolStripMenuItem.Click += new System.EventHandler(this.ImportartoolStripMenuItem_Click);
            // 
            // ImportarporHangTagtoolStripMenuItem
            // 
            this.ImportarporHangTagtoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.ImportarporHangTagtoolStripMenuItem.Name = "ImportarporHangTagtoolStripMenuItem";
            this.ImportarporHangTagtoolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.ImportarporHangTagtoolStripMenuItem.Text = "Importar por HangTag";
            this.ImportarporHangTagtoolStripMenuItem.ToolTipText = "[HangTag],[Descripcion],[UM],[Cantidad],[Ubicacion],[Observación]";
            this.ImportarporHangTagtoolStripMenuItem.Click += new System.EventHandler(this.ImportarporHangTagtoolStripMenuItem_Click);
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
            this.gridColumn9});
            this.gvInventario.GridControl = this.gcInventario;
            this.gvInventario.Name = "gvInventario";
            this.gvInventario.OptionsSelection.MultiSelect = true;
            this.gvInventario.OptionsView.ColumnAutoWidth = false;
            this.gvInventario.OptionsView.ShowGroupPanel = false;
            this.gvInventario.DoubleClick += new System.EventHandler(this.gvInventario_DoubleClick);
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
            this.gridColumn11.FieldName = "IdMovimientoAlmacenDetalle";
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
            this.gcCodigo.FieldName = "CodigoProveedor";
            this.gcCodigo.Name = "gcCodigo";
            this.gcCodigo.OptionsColumn.AllowEdit = false;
            this.gcCodigo.OptionsColumn.AllowFocus = false;
            this.gcCodigo.Visible = true;
            this.gcCodigo.VisibleIndex = 0;
            this.gcCodigo.Width = 132;
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
            this.gridColumn10.Width = 276;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "U.M";
            this.gridColumn7.FieldName = "Abreviatura";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
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
            this.gcCantidad.VisibleIndex = 3;
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
            this.gridColumn2.VisibleIndex = 4;
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
            this.gridColumn9.VisibleIndex = 5;
            this.gridColumn9.Width = 224;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(260, 12);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 13);
            this.labelControl4.TabIndex = 120;
            this.labelControl4.Text = "Tienda:";
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(302, 9);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Properties.ReadOnly = true;
            this.cboTienda.Size = new System.Drawing.Size(171, 20);
            this.cboTienda.TabIndex = 121;
            this.cboTienda.EditValueChanged += new System.EventHandler(this.cboTienda_EditValueChanged);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Location = new System.Drawing.Point(302, 29);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAlmacen.Properties.DropDownRows = 10;
            this.cboAlmacen.Properties.NullText = "";
            this.cboAlmacen.Size = new System.Drawing.Size(171, 20);
            this.cboAlmacen.TabIndex = 119;
            this.cboAlmacen.EditValueChanged += new System.EventHandler(this.cboAlmacen_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(252, 32);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(44, 13);
            this.labelControl6.TabIndex = 118;
            this.labelControl6.Text = "Almacén:";
            // 
            // chkHangTag
            // 
            this.chkHangTag.AutoSize = true;
            this.chkHangTag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkHangTag.Location = new System.Drawing.Point(700, 9);
            this.chkHangTag.Name = "chkHangTag";
            this.chkHangTag.Size = new System.Drawing.Size(96, 17);
            this.chkHangTag.TabIndex = 122;
            this.chkHangTag.Text = "Def. &Hang Tag";
            this.chkHangTag.UseVisualStyleBackColor = false;
            // 
            // lblRegistros
            // 
            this.lblRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRegistros.Location = new System.Drawing.Point(15, 494);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblRegistros.TabIndex = 123;
            this.lblRegistros.Text = "0 Registros";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.EditValue = "0";
            this.txtTotal.Location = new System.Drawing.Point(541, 493);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n0";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(87, 20);
            this.txtTotal.TabIndex = 125;
            // 
            // labelControl27
            // 
            this.labelControl27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl27.Appearance.Options.UseFont = true;
            this.labelControl27.Location = new System.Drawing.Point(447, 496);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(88, 13);
            this.labelControl27.TabIndex = 124;
            this.labelControl27.Text = "Cantidad Total :";
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Image = global::ErpPanorama.Presentation.Properties.Resources.Excel_16x16;
            this.btnExportar.ImageIndex = 1;
            this.btnExportar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnExportar.Location = new System.Drawing.Point(1006, 490);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(91, 23);
            this.btnExportar.TabIndex = 84;
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // prgFactura
            // 
            this.prgFactura.Location = new System.Drawing.Point(147, 492);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(294, 21);
            this.prgFactura.TabIndex = 126;
            this.prgFactura.Visible = false;
            // 
            // chkUbicacion
            // 
            this.chkUbicacion.AutoSize = true;
            this.chkUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkUbicacion.Location = new System.Drawing.Point(700, 32);
            this.chkUbicacion.Name = "chkUbicacion";
            this.chkUbicacion.Size = new System.Drawing.Size(95, 17);
            this.chkUbicacion.TabIndex = 122;
            this.chkUbicacion.Text = "&Def. Ubicación";
            this.chkUbicacion.UseVisualStyleBackColor = false;
            // 
            // btnBuscarPersona
            // 
            this.btnBuscarPersona.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPersona.Image")));
            this.btnBuscarPersona.Location = new System.Drawing.Point(1178, 29);
            this.btnBuscarPersona.Name = "btnBuscarPersona";
            this.btnBuscarPersona.Size = new System.Drawing.Size(26, 20);
            this.btnBuscarPersona.TabIndex = 129;
            this.btnBuscarPersona.Click += new System.EventHandler(this.btnBuscarPersona_Click);
            // 
            // txtPersonaApoyo
            // 
            this.txtPersonaApoyo.Location = new System.Drawing.Point(846, 30);
            this.txtPersonaApoyo.Name = "txtPersonaApoyo";
            this.txtPersonaApoyo.Properties.ReadOnly = true;
            this.txtPersonaApoyo.Size = new System.Drawing.Size(354, 20);
            this.txtPersonaApoyo.TabIndex = 128;
            // 
            // lblDes
            // 
            this.lblDes.Location = new System.Drawing.Point(801, 25);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(39, 26);
            this.lblDes.TabIndex = 127;
            this.lblDes.Text = "Persona\r\nApoyo:";
            // 
            // txtPersona
            // 
            this.txtPersona.Location = new System.Drawing.Point(846, 9);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.Properties.ReadOnly = true;
            this.txtPersona.Size = new System.Drawing.Size(358, 20);
            this.txtPersona.TabIndex = 131;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(800, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 130;
            this.labelControl1.Text = "Usuario:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(483, 32);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(23, 13);
            this.labelControl2.TabIndex = 118;
            this.labelControl2.Text = "Piso:";
            // 
            // cboAlmacenPiso
            // 
            this.cboAlmacenPiso.Location = new System.Drawing.Point(512, 29);
            this.cboAlmacenPiso.Name = "cboAlmacenPiso";
            this.cboAlmacenPiso.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenPiso.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cboAlmacenPiso.Properties.Appearance.Options.UseFont = true;
            this.cboAlmacenPiso.Properties.Appearance.Options.UseForeColor = true;
            this.cboAlmacenPiso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAlmacenPiso.Properties.DropDownRows = 10;
            this.cboAlmacenPiso.Properties.NullText = "";
            this.cboAlmacenPiso.Size = new System.Drawing.Size(171, 20);
            this.cboAlmacenPiso.TabIndex = 119;
            // 
            // frmRegInventarioAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 519);
            this.Controls.Add(this.txtPersona);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnBuscarPersona);
            this.Controls.Add(this.txtPersonaApoyo);
            this.Controls.Add(this.lblDes);
            this.Controls.Add(this.prgFactura);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.chkUbicacion);
            this.Controls.Add(this.chkHangTag);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.cboTienda);
            this.Controls.Add(this.cboAlmacenPiso);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboAlmacen);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.gcInventario);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.labelControl27);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegInventarioAgregar";
            this.Text = "Inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegInventarioAgregar_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegInventarioAgregar_FormClosed);
            this.Load += new System.EventHandler(this.frmRegInventarioAgregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcInventario)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonaApoyo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenPiso.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnEditar;
        public DevExpress.XtraEditors.SimpleButton btnEliminar;
        public DevExpress.XtraEditors.SimpleButton btnNuevo;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraGrid.GridControl gcInventario;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gcCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        public DevExpress.XtraEditors.LookUpEdit cboAlmacen;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.BindingSource bsListado;
        private System.Windows.Forms.CheckBox chkHangTag;
        private DevExpress.XtraEditors.LabelControl lblRegistros;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        public DevExpress.XtraGrid.Views.Grid.GridView gvInventario;
        public DevExpress.XtraEditors.SimpleButton btnExportar;
        private System.Windows.Forms.ToolStripMenuItem ImportartoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportarporHangTagtoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.CheckBox chkUbicacion;
        private DevExpress.XtraEditors.SimpleButton btnBuscarPersona;
        private DevExpress.XtraEditors.TextEdit txtPersonaApoyo;
        private DevExpress.XtraEditors.LabelControl lblDes;
        private DevExpress.XtraEditors.TextEdit txtPersona;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboAlmacenPiso;
    }
}