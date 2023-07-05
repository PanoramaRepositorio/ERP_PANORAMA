namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManPromocionEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManPromocionEdit));
            this.tsmMenuSelText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuAgregar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmMenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.bsListado = new System.Windows.Forms.BindingSource(this.components);
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPromocionDetalle = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarprecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvPromocionDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.cboTipoCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboFormaPago = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMontoMax = new DevExpress.XtraEditors.TextEdit();
            this.txtMontoMin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromocionDetalle)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvPromocionDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoMin.Properties)).BeginInit();
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
            this.menuStrip1.Size = new System.Drawing.Size(681, 24);
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
            // txtTotal
            // 
            this.txtTotal.EditValue = "0.00";
            this.txtTotal.Location = new System.Drawing.Point(594, 36);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(75, 20);
            this.txtTotal.TabIndex = 116;
            this.txtTotal.Visible = false;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Location = new System.Drawing.Point(553, 39);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(35, 13);
            this.labelControl10.TabIndex = 115;
            this.labelControl10.Text = "Total :";
            this.labelControl10.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(600, 296);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 118;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(519, 296);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 117;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gcPromocionDetalle;
            this.gridView1.Name = "gridView1";
            // 
            // gcPromocionDetalle
            // 
            this.gcPromocionDetalle.ContextMenuStrip = this.mnuContextual;
            this.gcPromocionDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcPromocionDetalle.Location = new System.Drawing.Point(0, 0);
            this.gcPromocionDetalle.MainView = this.gvPromocionDetalle;
            this.gcPromocionDetalle.Name = "gcPromocionDetalle";
            this.gcPromocionDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtCodigo});
            this.gcPromocionDetalle.Size = new System.Drawing.Size(670, 200);
            this.gcPromocionDetalle.TabIndex = 0;
            this.gcPromocionDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPromocionDetalle,
            this.gridView1});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.modificarprecioToolStripMenuItem,
            this.eliminarToolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(118, 70);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripMenuItem.Image")));
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // modificarprecioToolStripMenuItem
            // 
            this.modificarprecioToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarprecioToolStripMenuItem.Image")));
            this.modificarprecioToolStripMenuItem.Name = "modificarprecioToolStripMenuItem";
            this.modificarprecioToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.modificarprecioToolStripMenuItem.Text = "Editar";
            this.modificarprecioToolStripMenuItem.Click += new System.EventHandler(this.modificarprecioToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // gvPromocionDetalle
            // 
            this.gvPromocionDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn6,
            this.gcCodigo,
            this.gridColumn10,
            this.gridColumn9,
            this.gridColumn8,
            this.gridColumn12,
            this.gridColumn7});
            this.gvPromocionDetalle.GridControl = this.gcPromocionDetalle;
            this.gvPromocionDetalle.Name = "gvPromocionDetalle";
            this.gvPromocionDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvPromocionDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdCombo";
            this.gridColumn3.FieldName = "IdCombo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdComboDetalle";
            this.gridColumn1.FieldName = "IdComboDetalle";
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
            this.gridColumn8.Caption = "Cantidad";
            this.gridColumn8.FieldName = "Cantidad";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 3;
            this.gridColumn8.Width = 55;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "P. Venta";
            this.gridColumn12.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn12.FieldName = "Precio";
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
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gcPromocionDetalle);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(670, 200);
            this.xtraTabPage1.Text = "Productos";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(4, 62);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(676, 228);
            this.xtraTabControl1.TabIndex = 114;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // cboTipoCliente
            // 
            this.cboTipoCliente.Location = new System.Drawing.Point(451, 9);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoCliente.Properties.NullText = "";
            this.cboTipoCliente.Size = new System.Drawing.Size(218, 20);
            this.cboTipoCliente.TabIndex = 123;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(374, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(60, 13);
            this.labelControl3.TabIndex = 122;
            this.labelControl3.Text = "Tipo Cliente:";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.Location = new System.Drawing.Point(95, 10);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFormaPago.Properties.NullText = "";
            this.cboFormaPago.Size = new System.Drawing.Size(262, 20);
            this.cboFormaPago.TabIndex = 121;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 120;
            this.labelControl2.Text = "Forma Pago:";
            // 
            // txtMontoMax
            // 
            this.txtMontoMax.EditValue = "0.00";
            this.txtMontoMax.Location = new System.Drawing.Point(257, 36);
            this.txtMontoMax.Name = "txtMontoMax";
            this.txtMontoMax.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoMax.Properties.Appearance.Options.UseFont = true;
            this.txtMontoMax.Properties.DisplayFormat.FormatString = "n2";
            this.txtMontoMax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMontoMax.Properties.Mask.EditMask = "n2";
            this.txtMontoMax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMontoMax.Properties.Mask.ShowPlaceHolders = false;
            this.txtMontoMax.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMontoMax.Size = new System.Drawing.Size(100, 20);
            this.txtMontoMax.TabIndex = 127;
            // 
            // txtMontoMin
            // 
            this.txtMontoMin.EditValue = "0.00";
            this.txtMontoMin.Location = new System.Drawing.Point(95, 36);
            this.txtMontoMin.Name = "txtMontoMin";
            this.txtMontoMin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoMin.Properties.Appearance.Options.UseFont = true;
            this.txtMontoMin.Properties.DisplayFormat.FormatString = "n2";
            this.txtMontoMin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMontoMin.Properties.Mask.EditMask = "n2";
            this.txtMontoMin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMontoMin.Properties.Mask.ShowPlaceHolders = false;
            this.txtMontoMin.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMontoMin.Size = new System.Drawing.Size(77, 20);
            this.txtMontoMin.TabIndex = 125;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(191, 39);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(60, 13);
            this.labelControl4.TabIndex = 126;
            this.labelControl4.Text = "Monto Max :";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(16, 39);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(56, 13);
            this.labelControl7.TabIndex = 124;
            this.labelControl7.Text = "Monto Min :";
            // 
            // frmManPromocionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 331);
            this.Controls.Add(this.cboTipoCliente);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboFormaPago);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtMontoMax);
            this.Controls.Add(this.txtMontoMin);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.xtraTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManPromocionEdit";
            this.Load += new System.EventHandler(this.frmManPromocionEdit_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPromocionDetalle)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvPromocionDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoMin.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmMenuSelText;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuAgregar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuEliminar;
        private System.Windows.Forms.BindingSource bsListado;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gcPromocionDetalle;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarprecioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPromocionDetalle;
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
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        public DevExpress.XtraEditors.LookUpEdit cboTipoCliente;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboFormaPago;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtMontoMax;
        public DevExpress.XtraEditors.TextEdit txtMontoMin;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}