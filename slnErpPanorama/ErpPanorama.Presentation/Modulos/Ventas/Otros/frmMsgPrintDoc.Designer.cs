namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmMsgPrintDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMsgPrintDoc));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnContinuo = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnDesglosable = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(233, 45);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnContinuo
            // 
            this.btnContinuo.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuo.Image")));
            this.btnContinuo.ImageIndex = 1;
            this.btnContinuo.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnContinuo.Location = new System.Drawing.Point(39, 45);
            this.btnContinuo.Name = "btnContinuo";
            this.btnContinuo.Size = new System.Drawing.Size(91, 23);
            this.btnContinuo.TabIndex = 11;
            this.btnContinuo.Text = "Continuo";
            this.btnContinuo.Click += new System.EventHandler(this.btnContinuo_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(37, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(297, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "El documento tiene dos formatos, seleccionar el tipo de papel.";
            // 
            // btnDesglosable
            // 
            this.btnDesglosable.Image = ((System.Drawing.Image)(resources.GetObject("btnDesglosable.Image")));
            this.btnDesglosable.ImageIndex = 1;
            this.btnDesglosable.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDesglosable.Location = new System.Drawing.Point(136, 45);
            this.btnDesglosable.Name = "btnDesglosable";
            this.btnDesglosable.Size = new System.Drawing.Size(91, 23);
            this.btnDesglosable.TabIndex = 11;
            this.btnDesglosable.Text = "Desglosable";
            this.btnDesglosable.Click += new System.EventHandler(this.btnDesglosable_Click);
            // 
            // frmMsgPrintDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 89);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDesglosable);
            this.Controls.Add(this.btnContinuo);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMsgPrintDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Formato";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnContinuo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnDesglosable;
    }
}