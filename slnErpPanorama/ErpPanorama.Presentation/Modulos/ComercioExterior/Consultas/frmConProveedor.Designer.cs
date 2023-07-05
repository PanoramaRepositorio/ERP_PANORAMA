namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Consultas
{
    partial class frmConProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConProveedor));
            this.gcProveedor = new DevExpress.XtraGrid.GridControl();
            this.gvProveedor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtProveedor = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProveedor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcProveedor
            // 
            this.gcProveedor.Location = new System.Drawing.Point(0, 33);
            this.gcProveedor.MainView = this.gvProveedor;
            this.gcProveedor.Name = "gcProveedor";
            this.gcProveedor.Size = new System.Drawing.Size(534, 427);
            this.gcProveedor.TabIndex = 16;
            this.gcProveedor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProveedor});
            // 
            // gvProveedor
            // 
            this.gvProveedor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gvProveedor.GridControl = this.gcProveedor;
            this.gvProveedor.Name = "gvProveedor";
            this.gvProveedor.OptionsView.ShowGroupPanel = false;
            this.gvProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvProveedor_KeyPress);
            this.gvProveedor.DoubleClick += new System.EventHandler(this.gvProveedor_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "RUC";
            this.gridColumn1.FieldName = "NumeroDocumento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Razón Social";
            this.gridColumn2.FieldName = "DescProveedor";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 354;
            // 
            // txtProveedor
            // 
            this.txtProveedor.Location = new System.Drawing.Point(67, 7);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(374, 20);
            this.txtProveedor.TabIndex = 15;
            this.txtProveedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtProveedor_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(3, 10);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(58, 13);
            this.lblPersona.TabIndex = 14;
            this.lblPersona.Text = "Descripción:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(447, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 21);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmConProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 466);
            this.Controls.Add(this.gcProveedor);
            this.Controls.Add(this.txtProveedor);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConProveedor";
            this.Text = "Proveedor";
            this.Load += new System.EventHandler(this.frmConProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProveedor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcProveedor;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit txtProveedor;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
    }
}