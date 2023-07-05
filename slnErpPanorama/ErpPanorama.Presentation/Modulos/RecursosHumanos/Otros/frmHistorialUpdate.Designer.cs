namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    partial class frmHistorialUpdate
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
            this.gcMarcacion = new DevExpress.XtraGrid.GridControl();
            this.gvMarcacion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcMarcacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcacion)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMarcacion
            // 
            this.gcMarcacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcMarcacion.Location = new System.Drawing.Point(1, 1);
            this.gcMarcacion.MainView = this.gvMarcacion;
            this.gcMarcacion.Name = "gcMarcacion";
            this.gcMarcacion.Size = new System.Drawing.Size(997, 318);
            this.gcMarcacion.TabIndex = 0;
            this.gcMarcacion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMarcacion});
            // 
            // gvMarcacion
            // 
            this.gvMarcacion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gvMarcacion.GridControl = this.gcMarcacion;
            this.gvMarcacion.Name = "gvMarcacion";
            this.gvMarcacion.OptionsView.ColumnAutoWidth = false;
            this.gvMarcacion.OptionsView.ShowGroupPanel = false;
            this.gvMarcacion.OptionsView.ShowViewCaption = true;
            this.gvMarcacion.ViewCaption = "Clocking";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdTempCheckinout";
            this.gridColumn1.FieldName = "IdTempCheckinout";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdCheckinout";
            this.gridColumn2.FieldName = "IdCheckinout";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Dni";
            this.gridColumn3.FieldName = "Dni";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nombres";
            this.gridColumn4.FieldName = "ApeNom";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 240;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Fecha";
            this.gridColumn5.FieldName = "Fecha";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "F. Original";
            this.gridColumn6.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn6.FieldName = "FechaOriginal";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 133;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "F. Modificado";
            this.gridColumn7.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn7.FieldName = "FechaUpdate";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 138;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "F. Registro";
            this.gridColumn8.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "FechaRegistro";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 134;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Usuario Reg";
            this.gridColumn9.FieldName = "UsuarioRegistro";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 5;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Máquina Reg";
            this.gridColumn10.FieldName = "MaquinaRegistro";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 100;
            // 
            // frmHistorialUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 323);
            this.Controls.Add(this.gcMarcacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmHistorialUpdate";
            this.Text = "Historial de Modificación";
            this.Load += new System.EventHandler(this.frmHistorialUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMarcacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarcacion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMarcacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMarcacion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
    }
}