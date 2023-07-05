namespace ErpPanorama.Presentation.Modulos.Finanzas.Maestros
{
    partial class frmManTablas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManTablas));
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gcTabla = new DevExpress.XtraGrid.GridControl();
            this.mnuElementos = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.elementoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvTabla = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTabla)).BeginInit();
            this.mnuElementos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTabla)).BeginInit();
            this.SuspendLayout();
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(471, 24);
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
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(392, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 18;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(76, 31);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(310, 20);
            this.txtDescripcion.TabIndex = 17;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Descripción:";
            // 
            // gcTabla
            // 
            this.gcTabla.ContextMenuStrip = this.mnuElementos;
            this.gcTabla.Location = new System.Drawing.Point(0, 57);
            this.gcTabla.MainView = this.gvTabla;
            this.gcTabla.Name = "gcTabla";
            this.gcTabla.Size = new System.Drawing.Size(471, 448);
            this.gcTabla.TabIndex = 15;
            this.gcTabla.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTabla});
            // 
            // mnuElementos
            // 
            this.mnuElementos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.elementoToolStripMenuItem});
            this.mnuElementos.Name = "contextMenuStrip1";
            this.mnuElementos.Size = new System.Drawing.Size(130, 26);
            // 
            // elementoToolStripMenuItem
            // 
            this.elementoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("elementoToolStripMenuItem.Image")));
            this.elementoToolStripMenuItem.Name = "elementoToolStripMenuItem";
            this.elementoToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.elementoToolStripMenuItem.Text = "Elementos";
            this.elementoToolStripMenuItem.Click += new System.EventHandler(this.elementoToolStripMenuItem_Click);
            // 
            // gvTabla
            // 
            this.gvTabla.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.gvTabla.GridControl = this.gcTabla;
            this.gvTabla.Name = "gvTabla";
            this.gvTabla.OptionsView.ShowGroupPanel = false;
            this.gvTabla.DoubleClick += new System.EventHandler(this.gvTabla_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdTabla";
            this.gridColumn1.FieldName = "IdTabla";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdEmpresa";
            this.gridColumn2.FieldName = "IdEmpresa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descripción";
            this.gridColumn3.FieldName = "DescTabla";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 383;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Estado";
            this.gridColumn4.FieldName = "FlagEstado";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 69;
            // 
            // frmManTablas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 506);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gcTabla);
            this.Controls.Add(this.tlbMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManTablas";
            this.Text = "Tablas de Gestión de Ingresos y Egresos";
            this.Load += new System.EventHandler(this.frmManTabla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTabla)).EndInit();
            this.mnuElementos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gcTabla;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTabla;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.ContextMenuStrip mnuElementos;
        private System.Windows.Forms.ToolStripMenuItem elementoToolStripMenuItem;
    }
}