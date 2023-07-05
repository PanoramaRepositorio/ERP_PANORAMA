namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManRutaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManRutaEdit));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.cboTipoRuta = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboVendedor = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gcRutaDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvRutaDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTxtCodigo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoRuta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcRutaDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRutaDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.cboTipoRuta);
            this.groupControl3.Controls.Add(this.labelControl1);
            this.groupControl3.Controls.Add(this.cboVendedor);
            this.groupControl3.Controls.Add(this.labelControl12);
            this.groupControl3.Controls.Add(this.txtDescripcion);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(954, 62);
            this.groupControl3.TabIndex = 0;
            this.groupControl3.Text = "Datos";
            // 
            // cboTipoRuta
            // 
            this.cboTipoRuta.Location = new System.Drawing.Point(781, 29);
            this.cboTipoRuta.Name = "cboTipoRuta";
            this.cboTipoRuta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboTipoRuta.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cboTipoRuta.Properties.Appearance.Options.UseFont = true;
            this.cboTipoRuta.Properties.Appearance.Options.UseForeColor = true;
            this.cboTipoRuta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoRuta.Properties.NullText = "";
            this.cboTipoRuta.Size = new System.Drawing.Size(103, 20);
            this.cboTipoRuta.TabIndex = 37;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(751, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "Tipo:";
            // 
            // cboVendedor
            // 
            this.cboVendedor.Location = new System.Drawing.Point(469, 29);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboVendedor.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.cboVendedor.Properties.Appearance.Options.UseFont = true;
            this.cboVendedor.Properties.Appearance.Options.UseForeColor = true;
            this.cboVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedor.Properties.NullText = "";
            this.cboVendedor.Size = new System.Drawing.Size(265, 20);
            this.cboVendedor.TabIndex = 37;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(415, 32);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(50, 13);
            this.labelControl12.TabIndex = 36;
            this.labelControl12.Text = "Vendedor:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(103, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(296, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 32);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(58, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Descripción:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(857, 497);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(776, 497);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.modificarToolStripMenuItem,
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
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("modificarToolStripMenuItem.Image")));
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.modificarToolStripMenuItem.Text = "Editar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 64);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(954, 423);
            this.xtraTabControl1.TabIndex = 35;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gcRutaDetalle);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(948, 395);
            this.xtraTabPage1.Text = "Ruta Detalle";
            // 
            // gcRutaDetalle
            // 
            this.gcRutaDetalle.ContextMenuStrip = this.mnuContextual;
            this.gcRutaDetalle.Location = new System.Drawing.Point(1, 3);
            this.gcRutaDetalle.MainView = this.gvRutaDetalle;
            this.gcRutaDetalle.Name = "gcRutaDetalle";
            this.gcRutaDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.gcTxtCodigo});
            this.gcRutaDetalle.Size = new System.Drawing.Size(943, 390);
            this.gcRutaDetalle.TabIndex = 35;
            this.gcRutaDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRutaDetalle});
            // 
            // gvRutaDetalle
            // 
            this.gvRutaDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn11,
            this.gridColumn10,
            this.gridColumn7,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvRutaDetalle.GridControl = this.gcRutaDetalle;
            this.gvRutaDetalle.Name = "gvRutaDetalle";
            this.gvRutaDetalle.OptionsSelection.MultiSelect = true;
            this.gvRutaDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvRutaDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdRuta";
            this.gridColumn1.FieldName = "IdRuta";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdRutaDetalle";
            this.gridColumn11.FieldName = "IdRutaDetalle";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Ruta";
            this.gridColumn10.FieldName = "DescRuta";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            this.gridColumn10.Width = 73;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "IdUbigeo";
            this.gridColumn7.FieldName = "IdUbigeo";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 70;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Departamento";
            this.gridColumn2.FieldName = "NomDpto";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 174;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Provincia";
            this.gridColumn3.FieldName = "NomProv";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 248;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Distrito";
            this.gridColumn4.FieldName = "NomDist";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 265;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Estado";
            this.gridColumn5.FieldName = "FlagEstado";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // gcTxtCodigo
            // 
            this.gcTxtCodigo.AutoHeight = false;
            this.gcTxtCodigo.Name = "gcTxtCodigo";
            // 
            // frmManRutaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 532);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.groupControl3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManRutaEdit";
            this.Load += new System.EventHandler(this.frmManRutaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoRuta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcRutaDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRutaDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTxtCodigo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.GridControl gcRutaDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvRutaDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit gcTxtCodigo;
        public DevExpress.XtraEditors.LookUpEdit cboVendedor;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        public DevExpress.XtraEditors.LookUpEdit cboTipoRuta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}