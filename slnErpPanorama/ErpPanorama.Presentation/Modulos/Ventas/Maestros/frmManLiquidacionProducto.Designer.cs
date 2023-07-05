namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManLiquidacionProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManLiquidacionProducto));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboLineaProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvLiquidacionProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLiquidacionProducto = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.activarselecciontoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarselecciontoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.activarselecciontodotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarselecciontodotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolstpExportarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolstpSalir = new System.Windows.Forms.ToolStripButton();
            this.cboSubLineaProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboModeloProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblRegistros = new DevExpress.XtraEditors.LabelControl();
            this.btnTodos = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineaProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLiquidacionProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLiquidacionProducto)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSubLineaProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModeloProducto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(754, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 49;
            this.labelControl2.Text = "Linea Producto:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(499, 32);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 47;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Estado";
            this.gridColumn4.FieldName = "FlagEstado";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 62;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Descuento";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Descuento";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 64;
            // 
            // cboLineaProducto
            // 
            this.cboLineaProducto.Location = new System.Drawing.Point(754, 77);
            this.cboLineaProducto.Name = "cboLineaProducto";
            this.cboLineaProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLineaProducto.Properties.NullText = "";
            this.cboLineaProducto.Size = new System.Drawing.Size(223, 20);
            this.cboLineaProducto.TabIndex = 50;
            this.cboLineaProducto.EditValueChanged += new System.EventHandler(this.cboLineaProducto_EditValueChanged);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "PrecioCD";
            this.gridColumn6.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "PrecioCD";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 76;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Nombre";
            this.gridColumn9.FieldName = "NombreProducto";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 309;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Código";
            this.gridColumn3.FieldName = "CodigoProveedor";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 129;
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
            this.gridColumn1.Caption = "IdProducto";
            this.gridColumn1.FieldName = "IdProducto";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "IdLiquidacionProducto";
            this.gridColumn5.FieldName = "IdLiquidacionProducto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Width = 49;
            // 
            // gvLiquidacionProducto
            // 
            this.gvLiquidacionProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn9,
            this.gridColumn11,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn4});
            this.gvLiquidacionProducto.GridControl = this.gcLiquidacionProducto;
            this.gvLiquidacionProducto.Name = "gvLiquidacionProducto";
            this.gvLiquidacionProducto.OptionsSelection.MultiSelect = true;
            this.gvLiquidacionProducto.OptionsView.ColumnAutoWidth = false;
            this.gvLiquidacionProducto.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "U.M.";
            this.gridColumn11.FieldName = "Abreviatura";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 50;
            // 
            // gcLiquidacionProducto
            // 
            this.gcLiquidacionProducto.ContextMenuStrip = this.mnuContextual;
            this.gcLiquidacionProducto.Location = new System.Drawing.Point(0, 58);
            this.gcLiquidacionProducto.MainView = this.gvLiquidacionProducto;
            this.gcLiquidacionProducto.Name = "gcLiquidacionProducto";
            this.gcLiquidacionProducto.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcLiquidacionProducto.Size = new System.Drawing.Size(748, 394);
            this.gcLiquidacionProducto.TabIndex = 48;
            this.gcLiquidacionProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLiquidacionProducto});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activarselecciontoolStripMenuItem,
            this.desactivarselecciontoolStripMenuItem,
            this.toolStripSeparator3,
            this.activarselecciontodotoolStripMenuItem,
            this.desactivarselecciontodotoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(193, 98);
            // 
            // activarselecciontoolStripMenuItem
            // 
            this.activarselecciontoolStripMenuItem.Name = "activarselecciontoolStripMenuItem";
            this.activarselecciontoolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.activarselecciontoolStripMenuItem.Text = "Selección - Activar";
            this.activarselecciontoolStripMenuItem.ToolTipText = "Activar solo selección";
            this.activarselecciontoolStripMenuItem.Click += new System.EventHandler(this.activarselecciontoolStripMenuItem_Click);
            // 
            // desactivarselecciontoolStripMenuItem
            // 
            this.desactivarselecciontoolStripMenuItem.Name = "desactivarselecciontoolStripMenuItem";
            this.desactivarselecciontoolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.desactivarselecciontoolStripMenuItem.Text = "Selección -  Desactivar";
            this.desactivarselecciontoolStripMenuItem.ToolTipText = "Desactivar solo selección";
            this.desactivarselecciontoolStripMenuItem.Click += new System.EventHandler(this.desactivarselecciontoolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // activarselecciontodotoolStripMenuItem
            // 
            this.activarselecciontodotoolStripMenuItem.Name = "activarselecciontodotoolStripMenuItem";
            this.activarselecciontodotoolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.activarselecciontodotoolStripMenuItem.Text = "Seleccionar Todo";
            this.activarselecciontodotoolStripMenuItem.ToolTipText = "Seleccionar Todo";
            this.activarselecciontodotoolStripMenuItem.Click += new System.EventHandler(this.activarselecciontodotoolStripMenuItem_Click);
            // 
            // desactivarselecciontodotoolStripMenuItem
            // 
            this.desactivarselecciontodotoolStripMenuItem.Name = "desactivarselecciontodotoolStripMenuItem";
            this.desactivarselecciontodotoolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.desactivarselecciontodotoolStripMenuItem.Text = "Deseleccionar Todo";
            this.desactivarselecciontodotoolStripMenuItem.ToolTipText = "Deseleccionar Todo";
            this.desactivarselecciontodotoolStripMenuItem.Click += new System.EventHandler(this.desactivarselecciontodotoolStripMenuItem_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(76, 32);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(417, 20);
            this.txtDescripcion.TabIndex = 46;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstpExportarExcel,
            this.toolStripSeparator1,
            this.toolstpRefrescar,
            this.toolStripSeparator2,
            this.toolstpSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(993, 25);
            this.toolStrip1.TabIndex = 77;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolstpExportarExcel
            // 
            this.toolstpExportarExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpExportarExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolstpExportarExcel.Image")));
            this.toolstpExportarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpExportarExcel.Name = "toolstpExportarExcel";
            this.toolstpExportarExcel.Size = new System.Drawing.Size(23, 22);
            this.toolstpExportarExcel.ToolTipText = "Exportar Excel";
            this.toolstpExportarExcel.Click += new System.EventHandler(this.toolstpExportarExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpRefrescar
            // 
            this.toolstpRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpRefrescar.Image = ((System.Drawing.Image)(resources.GetObject("toolstpRefrescar.Image")));
            this.toolstpRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpRefrescar.Name = "toolstpRefrescar";
            this.toolstpRefrescar.Size = new System.Drawing.Size(23, 22);
            this.toolstpRefrescar.ToolTipText = "Actualizar";
            this.toolstpRefrescar.Click += new System.EventHandler(this.toolstpRefrescar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolstpSalir
            // 
            this.toolstpSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstpSalir.Image = ((System.Drawing.Image)(resources.GetObject("toolstpSalir.Image")));
            this.toolstpSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstpSalir.Name = "toolstpSalir";
            this.toolstpSalir.Size = new System.Drawing.Size(23, 22);
            this.toolstpSalir.ToolTipText = "Salir";
            this.toolstpSalir.Click += new System.EventHandler(this.toolstpSalir_Click);
            // 
            // cboSubLineaProducto
            // 
            this.cboSubLineaProducto.Location = new System.Drawing.Point(754, 119);
            this.cboSubLineaProducto.Name = "cboSubLineaProducto";
            this.cboSubLineaProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSubLineaProducto.Properties.NullText = "";
            this.cboSubLineaProducto.Size = new System.Drawing.Size(223, 20);
            this.cboSubLineaProducto.TabIndex = 50;
            this.cboSubLineaProducto.EditValueChanged += new System.EventHandler(this.cboSubLineaProducto_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(754, 103);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(96, 13);
            this.labelControl3.TabIndex = 49;
            this.labelControl3.Text = "Sub Linea Producto:";
            // 
            // cboModeloProducto
            // 
            this.cboModeloProducto.Location = new System.Drawing.Point(754, 162);
            this.cboModeloProducto.Name = "cboModeloProducto";
            this.cboModeloProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboModeloProducto.Properties.NullText = "";
            this.cboModeloProducto.Size = new System.Drawing.Size(223, 20);
            this.cboModeloProducto.TabIndex = 50;
            this.cboModeloProducto.EditValueChanged += new System.EventHandler(this.cboModeloProducto_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(754, 146);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(99, 13);
            this.labelControl4.TabIndex = 49;
            this.labelControl4.Text = "Modelo de Producto:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(821, 453);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 80;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(902, 453);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 81;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 36);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(58, 13);
            this.labelControl5.TabIndex = 78;
            this.labelControl5.Text = "Descripción:";
            // 
            // lblRegistros
            // 
            this.lblRegistros.Location = new System.Drawing.Point(24, 458);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblRegistros.TabIndex = 49;
            this.lblRegistros.Text = "0 Registros";
            // 
            // btnTodos
            // 
            this.btnTodos.Image = ((System.Drawing.Image)(resources.GetObject("btnTodos.Image")));
            this.btnTodos.Location = new System.Drawing.Point(676, 31);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(72, 21);
            this.btnTodos.TabIndex = 47;
            this.btnTodos.Text = "Todos";
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // frmManLiquidacionProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 481);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lblRegistros);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnTodos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboModeloProducto);
            this.Controls.Add(this.cboSubLineaProducto);
            this.Controls.Add(this.cboLineaProducto);
            this.Controls.Add(this.gcLiquidacionProducto);
            this.Controls.Add(this.txtDescripcion);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManLiquidacionProducto";
            this.Text = "Matenimiento - Liquidación Producto";
            this.Load += new System.EventHandler(this.frmManLiquidacionProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineaProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLiquidacionProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLiquidacionProducto)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSubLineaProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModeloProducto.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        public DevExpress.XtraEditors.LookUpEdit cboLineaProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLiquidacionProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.GridControl gcLiquidacionProducto;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolstpExportarExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolstpRefrescar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolstpSalir;
        public DevExpress.XtraEditors.LookUpEdit cboSubLineaProducto;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboModeloProducto;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblRegistros;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem activarselecciontodotoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem desactivarselecciontodotoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activarselecciontoolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStripMenuItem desactivarselecciontoolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnTodos;

    }
}