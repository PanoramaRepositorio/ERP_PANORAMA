namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    partial class frmManBulto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManBulto));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.cboProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.cboDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.gcBulto = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.descargarunoanaquelestoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descargartodorecibidotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarfaltanteorigentoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvBulto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            this.lblMensaje = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBulto)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvBulto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(794, 24);
            this.tlbMenu.TabIndex = 0;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            this.tlbMenu.Load += new System.EventHandler(this.tlbMenu_Load);
            // 
            // cboProveedor
            // 
            this.cboProveedor.Location = new System.Drawing.Point(69, 30);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProveedor.Properties.NullText = "";
            this.cboProveedor.Size = new System.Drawing.Size(279, 20);
            this.cboProveedor.TabIndex = 11;
            this.cboProveedor.EditValueChanged += new System.EventHandler(this.cboProveedor_EditValueChanged);
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(9, 33);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(54, 13);
            this.labelControl18.TabIndex = 10;
            this.labelControl18.Text = "Proveedor:";
            // 
            // cboDocumento
            // 
            this.cboDocumento.Location = new System.Drawing.Point(469, 30);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDocumento.Properties.NullText = "";
            this.cboDocumento.Size = new System.Drawing.Size(111, 20);
            this.cboDocumento.TabIndex = 13;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(367, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(96, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "N° Factura Compra:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(586, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gcBulto
            // 
            this.gcBulto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcBulto.ContextMenuStrip = this.mnuContextual;
            this.gcBulto.Location = new System.Drawing.Point(0, 80);
            this.gcBulto.MainView = this.gvBulto;
            this.gcBulto.Name = "gcBulto";
            this.gcBulto.Size = new System.Drawing.Size(793, 416);
            this.gcBulto.TabIndex = 32;
            this.gcBulto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBulto});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.descargarunoanaquelestoolStripMenuItem,
            this.descargartodorecibidotoolStripMenuItem,
            this.generarfaltanteorigentoolStripMenuItem});
            this.mnuContextual.Name = "mnuContextual";
            this.mnuContextual.Size = new System.Drawing.Size(341, 70);
            // 
            // descargarunoanaquelestoolStripMenuItem
            // 
            this.descargarunoanaquelestoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.Bultos_16x16;
            this.descargarunoanaquelestoolStripMenuItem.Name = "descargarunoanaquelestoolStripMenuItem";
            this.descargarunoanaquelestoolStripMenuItem.Size = new System.Drawing.Size(340, 22);
            this.descargarunoanaquelestoolStripMenuItem.Text = "Abastecer 1 Bulto --> Anaquel (si stock 0 Anaquel)";
            this.descargarunoanaquelestoolStripMenuItem.ToolTipText = "Descarga un bulto a anaquel si es Nuevo o Stock Cero";
            this.descargarunoanaquelestoolStripMenuItem.Click += new System.EventHandler(this.descargarunoanaquelestoolStripMenuItem_Click);
            // 
            // descargartodorecibidotoolStripMenuItem
            // 
            this.descargartodorecibidotoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.LiquidacionProducto_16x16;
            this.descargartodorecibidotoolStripMenuItem.Name = "descargartodorecibidotoolStripMenuItem";
            this.descargartodorecibidotoolStripMenuItem.Size = new System.Drawing.Size(340, 22);
            this.descargartodorecibidotoolStripMenuItem.Text = "Abastecer Todo --> Anaquel";
            this.descargartodorecibidotoolStripMenuItem.Click += new System.EventHandler(this.descargartodorecibidotoolStripMenuItem_Click);
            // 
            // generarfaltanteorigentoolStripMenuItem
            // 
            this.generarfaltanteorigentoolStripMenuItem.Image = global::ErpPanorama.Presentation.Properties.Resources.NotaSalida_16x16;
            this.generarfaltanteorigentoolStripMenuItem.Name = "generarfaltanteorigentoolStripMenuItem";
            this.generarfaltanteorigentoolStripMenuItem.Size = new System.Drawing.Size(340, 22);
            this.generarfaltanteorigentoolStripMenuItem.Text = "Generar N/S x Faltantes de Origen";
            this.generarfaltanteorigentoolStripMenuItem.ToolTipText = "Nota de Salida por Faltante de llegada";
            this.generarfaltanteorigentoolStripMenuItem.Click += new System.EventHandler(this.generarfaltanteorigentoolStripMenuItem_Click);
            // 
            // gvBulto
            // 
            this.gvBulto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn3,
            this.gridColumn8});
            this.gvBulto.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvBulto.GridControl = this.gcBulto;
            this.gvBulto.Name = "gvBulto";
            this.gvBulto.OptionsView.AllowCellMerge = true;
            this.gvBulto.OptionsView.ColumnAutoWidth = false;
            this.gvBulto.OptionsView.ShowGroupPanel = false;
            this.gvBulto.DoubleClick += new System.EventHandler(this.gvBulto_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdEmpresa";
            this.gridColumn2.FieldName = "IdEmpresa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdBulto";
            this.gridColumn1.FieldName = "IdBulto";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Código";
            this.gridColumn5.FieldName = "CodigoProveedor";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 118;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Descripción";
            this.gridColumn4.FieldName = "NombreProducto";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 380;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "U.M";
            this.gridColumn7.FieldName = "Abreviatura";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Cantidad";
            this.gridColumn6.FieldName = "Cantidad";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Situación";
            this.gridColumn3.FieldName = "Situacion";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 125;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Recibido";
            this.gridColumn8.FieldName = "FlagEstado";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn8.Width = 61;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(9, 505);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(79, 13);
            this.lblDescripcion.TabIndex = 34;
            this.lblDescripcion.Text = "Cantidad Bultos:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(94, 502);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Properties.MaxLength = 50;
            this.txtCantidad.Properties.ReadOnly = true;
            this.txtCantidad.Size = new System.Drawing.Size(96, 20);
            this.txtCantidad.TabIndex = 33;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 55);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 35;
            this.labelControl2.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(69, 52);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.MaxLength = 50;
            this.txtCodigo.Size = new System.Drawing.Size(137, 20);
            this.txtCodigo.TabIndex = 36;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // prgFactura
            // 
            this.prgFactura.Location = new System.Drawing.Point(199, 512);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(583, 10);
            this.prgFactura.TabIndex = 43;
            // 
            // lblMensaje
            // 
            this.lblMensaje.Location = new System.Drawing.Point(451, 497);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(12, 13);
            this.lblMensaje.TabIndex = 44;
            this.lblMensaje.Text = "...";
            // 
            // frmManBulto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 529);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.prgFactura);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.gcBulto);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboDocumento);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboProveedor);
            this.Controls.Add(this.labelControl18);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManBulto";
            this.Text = "Bulto - Mantenimiento";
            this.Load += new System.EventHandler(this.frmManBulto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcBulto)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvBulto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        public DevExpress.XtraEditors.LookUpEdit cboProveedor;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        public DevExpress.XtraEditors.LookUpEdit cboDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.GridControl gcBulto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvBulto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem descargarunoanaquelestoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarfaltanteorigentoolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.ToolStripMenuItem descargartodorecibidotoolStripMenuItem;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
        private DevExpress.XtraEditors.LabelControl lblMensaje;
    }
}