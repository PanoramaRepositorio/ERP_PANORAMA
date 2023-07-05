namespace ErpPanorama.Presentation.Modulos.Maestros.Otros
{
    partial class frmBuscaPersona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaPersona));
            this.gcPersona = new DevExpress.XtraGrid.GridControl();
            this.gvPersona = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtPersona = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersona)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersona.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPersona
            // 
            this.gcPersona.Location = new System.Drawing.Point(1, 40);
            this.gcPersona.MainView = this.gvPersona;
            this.gcPersona.Name = "gcPersona";
            this.gcPersona.Size = new System.Drawing.Size(452, 427);
            this.gcPersona.TabIndex = 8;
            this.gcPersona.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPersona});
            // 
            // gvPersona
            // 
            this.gvPersona.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gvPersona.GridControl = this.gcPersona;
            this.gvPersona.Name = "gvPersona";
            this.gvPersona.OptionsView.ShowGroupPanel = false;
            this.gvPersona.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvPersona_KeyPress);
            this.gvPersona.DoubleClick += new System.EventHandler(this.gvPersona_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdPersona";
            this.gridColumn1.FieldName = "IdPersona";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Apellidos y Nombres";
            this.gridColumn2.FieldName = "ApeNom";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // txtPersona
            // 
            this.txtPersona.Location = new System.Drawing.Point(47, 14);
            this.txtPersona.Name = "txtPersona";
            this.txtPersona.Size = new System.Drawing.Size(325, 20);
            this.txtPersona.TabIndex = 7;
            this.txtPersona.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPersona_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(4, 17);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(43, 13);
            this.lblPersona.TabIndex = 6;
            this.lblPersona.Text = "Persona:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(378, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 21);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            // 
            // frmBuscaPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 466);
            this.Controls.Add(this.gcPersona);
            this.Controls.Add(this.txtPersona);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscaPersona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Búsqueda de Persona";
            this.Load += new System.EventHandler(this.frmBuscaPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPersona)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersona.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcPersona;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPersona;
        private DevExpress.XtraEditors.TextEdit txtPersona;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}