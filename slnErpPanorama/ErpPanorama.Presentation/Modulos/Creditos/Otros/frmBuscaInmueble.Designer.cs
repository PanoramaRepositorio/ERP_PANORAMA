namespace ErpPanorama.Presentation.Modulos.Creditos.Otros
{
    partial class frmBuscaInmueble
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscaInmueble));
            this.gcInmueble = new DevExpress.XtraGrid.GridControl();
            this.gvInmueble = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtInmueble = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcInmueble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInmueble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInmueble.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcInmueble
            // 
            this.gcInmueble.Location = new System.Drawing.Point(1, 40);
            this.gcInmueble.MainView = this.gvInmueble;
            this.gcInmueble.Name = "gcInmueble";
            this.gcInmueble.Size = new System.Drawing.Size(820, 427);
            this.gcInmueble.TabIndex = 12;
            this.gcInmueble.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInmueble});
            // 
            // gvInmueble
            // 
            this.gvInmueble.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gvInmueble.GridControl = this.gcInmueble;
            this.gvInmueble.Name = "gvInmueble";
            this.gvInmueble.OptionsView.ShowGroupPanel = false;
            this.gvInmueble.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInmueble_KeyUp);
            this.gvInmueble.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvInmueble_KeyPress);
            this.gvInmueble.DoubleClick += new System.EventHandler(this.gvInmueble_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdInmueble";
            this.gridColumn1.FieldName = "IdInmueble";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Empresa";
            this.gridColumn3.FieldName = "RazonSocial";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 193;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descripción";
            this.gridColumn2.FieldName = "DescInmueble";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 258;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tipo";
            this.gridColumn4.FieldName = "DescTipoInmueble";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Width = 140;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Dirección";
            this.gridColumn5.FieldName = "Direccion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 260;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Alquiler";
            this.gridColumn6.DisplayFormat.FormatString = "#0.00";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "PrecioAlquiler";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 91;
            // 
            // txtInmueble
            // 
            this.txtInmueble.Location = new System.Drawing.Point(58, 14);
            this.txtInmueble.Name = "txtInmueble";
            this.txtInmueble.Size = new System.Drawing.Size(467, 20);
            this.txtInmueble.TabIndex = 11;
            this.txtInmueble.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInmueble_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(4, 17);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(48, 13);
            this.lblPersona.TabIndex = 10;
            this.lblPersona.Text = "Inmueble:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(531, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 21);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            // 
            // frmBuscaInmueble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 466);
            this.Controls.Add(this.gcInmueble);
            this.Controls.Add(this.txtInmueble);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscaInmueble";
            this.Text = "Búsqueda de Inmuebles";
            this.Load += new System.EventHandler(this.frmBuscaInmueble_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcInmueble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInmueble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInmueble.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcInmueble;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInmueble;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit txtInmueble;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}