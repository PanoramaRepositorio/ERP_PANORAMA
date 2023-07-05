namespace ErpPanorama.Presentation.Modulos.Maestros.Otros
{
    partial class frmBuscaTablaElemento
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
            this.gcTablaElemento = new DevExpress.XtraGrid.GridControl();
            this.gvTablaElemento = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcTablaElemento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTablaElemento)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTablaElemento
            // 
            this.gcTablaElemento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTablaElemento.Location = new System.Drawing.Point(0, 0);
            this.gcTablaElemento.MainView = this.gvTablaElemento;
            this.gcTablaElemento.Name = "gcTablaElemento";
            this.gcTablaElemento.Size = new System.Drawing.Size(385, 306);
            this.gcTablaElemento.TabIndex = 47;
            this.gcTablaElemento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTablaElemento});
            // 
            // gvTablaElemento
            // 
            this.gvTablaElemento.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3});
            this.gvTablaElemento.GridControl = this.gcTablaElemento;
            this.gvTablaElemento.Name = "gvTablaElemento";
            this.gvTablaElemento.OptionsView.ShowGroupPanel = false;
            this.gvTablaElemento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvTablaElemento_KeyDown);
            this.gvTablaElemento.DoubleClick += new System.EventHandler(this.gvTablaElemento_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdEmpresa";
            this.gridColumn1.FieldName = "IdEmpresa";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "IdTabla";
            this.gridColumn4.FieldName = "IdTabla";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdTablaElemento";
            this.gridColumn2.FieldName = "IdTablaElemento";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Abreviatura";
            this.gridColumn5.FieldName = "Abreviatura";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descripción";
            this.gridColumn3.FieldName = "DescTablaElemento";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 200;
            // 
            // frmBuscaTablaElemento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 306);
            this.Controls.Add(this.gcTablaElemento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBuscaTablaElemento";
            this.Text = "Búsqueda Elemento";
            this.Load += new System.EventHandler(this.frmBuscaTablaElemento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTablaElemento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTablaElemento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTablaElemento;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTablaElemento;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}