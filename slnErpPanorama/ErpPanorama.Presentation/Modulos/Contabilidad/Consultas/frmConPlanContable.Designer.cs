namespace ErpPanorama.Presentation.Modulos.Contabilidad.Consultas
{
    partial class frmConPlanContable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConPlanContable));
            this.gcConPlanContable = new DevExpress.XtraGrid.GridControl();
            this.gvConPlanContable = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtConPlanContable = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcConPlanContable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConPlanContable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConPlanContable.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcConPlanContable
            // 
            this.gcConPlanContable.Location = new System.Drawing.Point(1, 33);
            this.gcConPlanContable.MainView = this.gvConPlanContable;
            this.gcConPlanContable.Name = "gcConPlanContable";
            this.gcConPlanContable.Size = new System.Drawing.Size(534, 427);
            this.gcConPlanContable.TabIndex = 12;
            this.gcConPlanContable.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConPlanContable});
            // 
            // gvConPlanContable
            // 
            this.gvConPlanContable.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gvConPlanContable.GridControl = this.gcConPlanContable;
            this.gvConPlanContable.Name = "gvConPlanContable";
            this.gvConPlanContable.OptionsView.ShowGroupPanel = false;
            this.gvConPlanContable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.gvConPlanContable_KeyPress);
            this.gvConPlanContable.DoubleClick += new System.EventHandler(this.gvConPlanContable_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "N° Cuenta";
            this.gridColumn1.FieldName = "IdConPlanContable";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Descripción";
            this.gridColumn2.FieldName = "Descripcion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 354;
            // 
            // txtConPlanContable
            // 
            this.txtConPlanContable.Location = new System.Drawing.Point(68, 7);
            this.txtConPlanContable.Name = "txtConPlanContable";
            this.txtConPlanContable.Size = new System.Drawing.Size(374, 20);
            this.txtConPlanContable.TabIndex = 11;
            this.txtConPlanContable.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtConPlanContable_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(4, 10);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(58, 13);
            this.lblPersona.TabIndex = 10;
            this.lblPersona.Text = "Descripción:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(448, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 21);
            this.btnBuscar.TabIndex = 9;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmConPlanContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 466);
            this.Controls.Add(this.gcConPlanContable);
            this.Controls.Add(this.txtConPlanContable);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConPlanContable";
            this.Text = "Plan Contable";
            this.Load += new System.EventHandler(this.frmConPlanContable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcConPlanContable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConPlanContable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConPlanContable.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcConPlanContable;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConPlanContable;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit txtConPlanContable;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
    }
}