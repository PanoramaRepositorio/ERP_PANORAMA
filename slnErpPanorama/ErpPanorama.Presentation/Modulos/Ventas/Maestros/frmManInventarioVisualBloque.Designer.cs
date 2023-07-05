namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManInventarioVisualBloque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManInventarioVisualBloque));
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.gvInventarioVisualBloque = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcInventarioVisualBloque = new DevExpress.XtraGrid.GridControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.tlbMenu = new ErpPanorama.Presentation.ControlUser.UIToolBar();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInventarioVisualBloque)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInventarioVisualBloque)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(72, 31);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Properties.MaxLength = 50;
            this.txtDescripcion.Size = new System.Drawing.Size(247, 20);
            this.txtDescripcion.TabIndex = 49;
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // gvInventarioVisualBloque
            // 
            this.gvInventarioVisualBloque.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn4});
            this.gvInventarioVisualBloque.GridControl = this.gcInventarioVisualBloque;
            this.gvInventarioVisualBloque.Name = "gvInventarioVisualBloque";
            this.gvInventarioVisualBloque.OptionsView.ColumnAutoWidth = false;
            this.gvInventarioVisualBloque.OptionsView.ShowGroupPanel = false;
            this.gvInventarioVisualBloque.DoubleClick += new System.EventHandler(this.gvInventarioVisualBloque_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdInventarioVisualBloque";
            this.gridColumn1.FieldName = "IdInventarioVisualBloque";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "IdTienda";
            this.gridColumn3.FieldName = "IdTienda";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tienda";
            this.gridColumn6.FieldName = "DescTienda";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 140;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Bloque";
            this.gridColumn8.FieldName = "DescBloque";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            this.gridColumn8.Width = 217;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Estado";
            this.gridColumn4.FieldName = "FlagEstado";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Width = 20;
            // 
            // gcInventarioVisualBloque
            // 
            this.gcInventarioVisualBloque.Location = new System.Drawing.Point(0, 57);
            this.gcInventarioVisualBloque.MainView = this.gvInventarioVisualBloque;
            this.gcInventarioVisualBloque.Name = "gcInventarioVisualBloque";
            this.gcInventarioVisualBloque.Size = new System.Drawing.Size(400, 319);
            this.gcInventarioVisualBloque.TabIndex = 51;
            this.gcInventarioVisualBloque.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInventarioVisualBloque});
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(327, 30);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 21);
            this.btnBuscar.TabIndex = 50;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // tlbMenu
            // 
            this.tlbMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlbMenu.Ensamblado = "";
            this.tlbMenu.Location = new System.Drawing.Point(0, 0);
            this.tlbMenu.Name = "tlbMenu";
            this.tlbMenu.Size = new System.Drawing.Size(401, 24);
            this.tlbMenu.TabIndex = 47;
            this.tlbMenu.NewClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateNewClick(this.tlbMenu_NewClick);
            this.tlbMenu.EditClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateEditClick(this.tlbMenu_EditClick);
            this.tlbMenu.DeleteClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateDeleteClick(this.tlbMenu_DeleteClick);
            this.tlbMenu.RefreshClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateRefreshClick(this.tlbMenu_RefreshClick);
            this.tlbMenu.PrintClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegatePrintClick(this.tlbMenu_PrintClick);
            this.tlbMenu.ExportClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExportClick(this.tlbMenu_ExportClick);
            this.tlbMenu.ExitClick += new ErpPanorama.Presentation.ControlUser.UIToolBar.delegateExitClick(this.tlbMenu_ExitClick);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 48;
            this.labelControl1.Text = "Descripción:";
            // 
            // frmManInventarioVisualBloque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 377);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.gcInventarioVisualBloque);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tlbMenu);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManInventarioVisualBloque";
            this.Text = "Mantenimiento - Visual Bloque";
            this.Load += new System.EventHandler(this.frmManInventarioVisualBloque_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInventarioVisualBloque)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInventarioVisualBloque)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInventarioVisualBloque;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.GridControl gcInventarioVisualBloque;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private ControlUser.UIToolBar tlbMenu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}