namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    partial class frmManUbicacionProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManUbicacionProducto));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.gcProducto = new DevExpress.XtraGrid.GridControl();
            this.mnuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.importartoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarporcodigotoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importarporhangtagtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.cboPagina = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCantidadRegistros = new DevExpress.XtraEditors.TextEdit();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.prgFactura = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).BeginInit();
            this.mnuContextual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(756, 24);
            this.tlbMenu.TabIndex = 0;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // gcProducto
            // 
            this.gcProducto.ContextMenuStrip = this.mnuContextual;
            this.gcProducto.Location = new System.Drawing.Point(0, 53);
            this.gcProducto.MainView = this.gvProducto;
            this.gcProducto.Name = "gcProducto";
            this.gcProducto.Size = new System.Drawing.Size(756, 400);
            this.gcProducto.TabIndex = 53;
            this.gcProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducto});
            // 
            // mnuContextual
            // 
            this.mnuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importartoolStripMenuItem});
            this.mnuContextual.Name = "contextMenuStrip1";
            this.mnuContextual.Size = new System.Drawing.Size(121, 26);
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
            this.importarporcodigotoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importarporcodigotoolStripMenuItem.Image")));
            this.importarporcodigotoolStripMenuItem.Name = "importarporcodigotoolStripMenuItem";
            this.importarporcodigotoolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importarporcodigotoolStripMenuItem.Text = "Por Código";
            this.importarporcodigotoolStripMenuItem.ToolTipText = "[Codigo],[Ubicación]";
            this.importarporcodigotoolStripMenuItem.Click += new System.EventHandler(this.importarporcodigotoolStripMenuItem_Click);
            // 
            // importarporhangtagtoolStripMenuItem
            // 
            this.importarporhangtagtoolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("importarporhangtagtoolStripMenuItem.Image")));
            this.importarporhangtagtoolStripMenuItem.Name = "importarporhangtagtoolStripMenuItem";
            this.importarporhangtagtoolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importarporhangtagtoolStripMenuItem.Text = "Por HangTag";
            this.importarporhangtagtoolStripMenuItem.ToolTipText = "[HangTag],[Ubicación]";
            this.importarporhangtagtoolStripMenuItem.Click += new System.EventHandler(this.importarporhangtagtoolStripMenuItem_Click);
            // 
            // gvProducto
            // 
            this.gvProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn10,
            this.gridColumn6,
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn9});
            this.gvProducto.GridControl = this.gcProducto;
            this.gvProducto.Name = "gvProducto";
            this.gvProducto.OptionsView.ShowGroupPanel = false;
            this.gvProducto.DoubleClick += new System.EventHandler(this.gvProducto_DoubleClick);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdEmpresa";
            this.gridColumn8.FieldName = "IdEmpresa";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "IdUbicacionProducto";
            this.gridColumn7.FieldName = "IdUbicacionProducto";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "IdTienda";
            this.gridColumn10.FieldName = "IdTienda";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdAlmacen";
            this.gridColumn6.FieldName = "IdAlmacen";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Almacén";
            this.gridColumn4.FieldName = "DescAlmacen";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 125;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdProducto";
            this.gridColumn1.FieldName = "IdProducto";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Código";
            this.gridColumn2.FieldName = "CodigoProveedor";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 78;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Descripción";
            this.gridColumn5.FieldName = "NombreProducto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 351;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "U.M";
            this.gridColumn3.FieldName = "Abreviatura";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 41;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ubicación";
            this.gridColumn9.FieldName = "DescUbicacion";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 4;
            this.gridColumn9.Width = 109;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(76, 27);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(481, 20);
            this.txtDescripcion.TabIndex = 52;
            this.txtDescripcion.EditValueChanged += new System.EventHandler(this.txtDescripcion_EditValueChanged);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(12, 30);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(58, 13);
            this.lblPersona.TabIndex = 51;
            this.lblPersona.Text = "Descripción:";
            // 
            // cboPagina
            // 
            this.cboPagina.Location = new System.Drawing.Point(396, 459);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPagina.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboPagina.Size = new System.Drawing.Size(46, 20);
            this.cboPagina.TabIndex = 50;
            this.cboPagina.EditValueChanged += new System.EventHandler(this.cboPagina_EditValueChanged);
            // 
            // txtCantidadRegistros
            // 
            this.txtCantidadRegistros.EditValue = "18";
            this.txtCantidadRegistros.Location = new System.Drawing.Point(443, 459);
            this.txtCantidadRegistros.Name = "txtCantidadRegistros";
            this.txtCantidadRegistros.Properties.Mask.EditMask = "\\d{0,3}";
            this.txtCantidadRegistros.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCantidadRegistros.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCantidadRegistros.Size = new System.Drawing.Size(30, 20);
            this.txtCantidadRegistros.TabIndex = 47;
            this.txtCantidadRegistros.EditValueChanged += new System.EventHandler(this.txtCantidadRegistros_EditValueChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(334, 459);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 20);
            this.btnNext.TabIndex = 48;
            this.btnNext.Tag = "";
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(365, 459);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 20);
            this.btnLast.TabIndex = 49;
            this.btnLast.Tag = "";
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(303, 459);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 20);
            this.btnPrevious.TabIndex = 46;
            this.btnPrevious.Tag = "";
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(272, 459);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 20);
            this.btnFirst.TabIndex = 45;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // prgFactura
            // 
            this.prgFactura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prgFactura.Location = new System.Drawing.Point(12, 463);
            this.prgFactura.Name = "prgFactura";
            this.prgFactura.Size = new System.Drawing.Size(253, 10);
            this.prgFactura.TabIndex = 158;
            // 
            // frmManUbicacionProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 485);
            this.Controls.Add(this.prgFactura);
            this.Controls.Add(this.gcProducto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.cboPagina);
            this.Controls.Add(this.txtCantidadRegistros);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManUbicacionProducto";
            this.Text = "Ubicación Producto - Mantenimiento";
            this.Load += new System.EventHandler(this.frmManUbicacionProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).EndInit();
            this.mnuContextual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prgFactura.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraGrid.GridControl gcProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraEditors.ComboBoxEdit cboPagina;
        private DevExpress.XtraEditors.TextEdit txtCantidadRegistros;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private System.Windows.Forms.ContextMenuStrip mnuContextual;
        private System.Windows.Forms.ToolStripMenuItem importartoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarporcodigotoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importarporhangtagtoolStripMenuItem;
        private DevExpress.XtraEditors.ProgressBarControl prgFactura;
    }
}