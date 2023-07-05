namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmBusClienteTelefonos
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
            this.gcTelefonos = new DevExpress.XtraGrid.GridControl();
            this.gvTelefonos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcTelefonos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTelefonos)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTelefonos
            // 
            this.gcTelefonos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTelefonos.Location = new System.Drawing.Point(0, 0);
            this.gcTelefonos.MainView = this.gvTelefonos;
            this.gcTelefonos.Name = "gcTelefonos";
            this.gcTelefonos.Size = new System.Drawing.Size(284, 261);
            this.gcTelefonos.TabIndex = 9;
            this.gcTelefonos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTelefonos});
            // 
            // gvTelefonos
            // 
            this.gvTelefonos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gvTelefonos.GridControl = this.gcTelefonos;
            this.gvTelefonos.Name = "gvTelefonos";
            this.gvTelefonos.OptionsView.ShowGroupPanel = false;
            this.gvTelefonos.DoubleClick += new System.EventHandler(this.gvTelefonos_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdCliente";
            this.gridColumn1.FieldName = "IdCliente";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Teléfonos";
            this.gridColumn2.FieldName = "Telefonos";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // frmBusClienteTelefonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.gcTelefonos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBusClienteTelefonos";
            this.Text = "Busca Teléfono Cliente";
            this.Load += new System.EventHandler(this.frmBusClienteTelefonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcTelefonos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTelefonos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcTelefonos;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTelefonos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}