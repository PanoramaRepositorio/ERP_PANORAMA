namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    partial class frmConsulltaCumpleaño
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
            this.gcCumpleaños = new DevExpress.XtraGrid.GridControl();
            this.gvCumpleaños = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.picImage = new DevExpress.XtraEditors.PictureEdit();
            this.txtNombres = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gcCumpleaños)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCumpleaños)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcCumpleaños
            // 
            this.gcCumpleaños.Location = new System.Drawing.Point(3, 50);
            this.gcCumpleaños.MainView = this.gvCumpleaños;
            this.gcCumpleaños.Name = "gcCumpleaños";
            this.gcCumpleaños.Size = new System.Drawing.Size(634, 275);
            this.gcCumpleaños.TabIndex = 0;
            this.gcCumpleaños.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCumpleaños});
            // 
            // gvCumpleaños
            // 
            this.gvCumpleaños.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
            this.gvCumpleaños.GridControl = this.gcCumpleaños;
            this.gvCumpleaños.Name = "gvCumpleaños";
            this.gvCumpleaños.OptionsView.ShowGroupPanel = false;
            this.gvCumpleaños.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvCumpleaños_RowClick);
            this.gvCumpleaños.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCumpleaños_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nombres";
            this.gridColumn1.FieldName = "Nombres";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Width = 183;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.Caption = "Apellidos";
            this.gridColumn2.FieldName = "ApeNom";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 252;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Dni";
            this.gridColumn3.FieldName = "Dni";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Width = 115;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tienda";
            this.gridColumn4.FieldName = "DescTienda";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 97;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Area";
            this.gridColumn5.FieldName = "DescArea";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 129;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Cargo";
            this.gridColumn6.FieldName = "DescCargo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 138;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "IdPersona";
            this.gridColumn7.FieldName = "IdPersona";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Location = new System.Drawing.Point(22, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(357, 23);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "LISTADO DE ONOMASTICOS DEL DIA";
            // 
            // picImage
            // 
            this.picImage.EditValue = global::ErpPanorama.Presentation.Properties.Resources.NoImagePerson;
            this.picImage.Location = new System.Drawing.Point(643, 50);
            this.picImage.Name = "picImage";
            this.picImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.picImage.Size = new System.Drawing.Size(226, 275);
            this.picImage.TabIndex = 2;
            // 
            // txtNombres
            // 
            this.txtNombres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombres.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtNombres.ForeColor = System.Drawing.Color.Navy;
            this.txtNombres.Location = new System.Drawing.Point(651, 277);
            this.txtNombres.Multiline = true;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(211, 20);
            this.txtNombres.TabIndex = 4;
            this.txtNombres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmConsulltaCumpleaño
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 337);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gcCumpleaños);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsulltaCumpleaño";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ALERTA DE CUMPLEAÑOS";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCumple_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcCumpleaños)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCumpleaños)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcCumpleaños;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCumpleaños;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.PictureEdit picImage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.TextBox txtNombres;
    }
}