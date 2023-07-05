namespace ErpPanorama.Presentation.Modulos.Logistica.Reportes
{
    partial class frmRepInventarioBultoSector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepInventarioBultoSector));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboSector = new DevExpress.XtraEditors.LookUpEdit();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.rdgSector = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.cboSector.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgSector.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(227, 113);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageOptions.ImageIndex = 1;
            this.btnVer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(129, 113);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 5;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 22);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 13);
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "Sector: ";
            // 
            // cboSector
            // 
            this.cboSector.Location = new System.Drawing.Point(56, 19);
            this.cboSector.Name = "cboSector";
            this.cboSector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSector.Properties.NullText = "";
            this.cboSector.Size = new System.Drawing.Size(246, 20);
            this.cboSector.TabIndex = 12;
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Location = new System.Drawing.Point(22, 102);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(89, 17);
            this.chkStock.TabIndex = 13;
            this.chkStock.Text = "Incluir Stocks";
            this.chkStock.UseVisualStyleBackColor = true;
            this.chkStock.Visible = false;
            // 
            // rdgSector
            // 
            this.rdgSector.Location = new System.Drawing.Point(56, 45);
            this.rdgSector.Name = "rdgSector";
            this.rdgSector.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Resumen"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Incluir Stocks"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "Detalle"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Bultos vs Anaqueles")});
            this.rdgSector.Size = new System.Drawing.Size(246, 51);
            this.rdgSector.TabIndex = 15;
            // 
            // frmRepInventarioBultoSector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 147);
            this.Controls.Add(this.rdgSector);
            this.Controls.Add(this.chkStock);
            this.Controls.Add(this.cboSector);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepInventarioBultoSector";
            this.Text = "Inventario Bultos Por Sector";
            this.Load += new System.EventHandler(this.frmRepInventarioBultoSector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSector.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdgSector.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LookUpEdit cboSector;
        private System.Windows.Forms.CheckBox chkStock;
        private DevExpress.XtraEditors.RadioGroup rdgSector;
    }
}