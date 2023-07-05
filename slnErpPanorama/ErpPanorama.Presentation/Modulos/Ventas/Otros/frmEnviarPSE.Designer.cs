namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmEnviarPSE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnviarPSE));
            this.prgEnvio = new DevExpress.XtraEditors.ProgressBarControl();
            this.btnEnviar = new DevExpress.XtraEditors.SimpleButton();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.nudVeces = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.prgEnvio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVeces)).BeginInit();
            this.SuspendLayout();
            // 
            // prgEnvio
            // 
            this.prgEnvio.Location = new System.Drawing.Point(10, 10);
            this.prgEnvio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prgEnvio.Name = "prgEnvio";
            this.prgEnvio.Size = new System.Drawing.Size(584, 27);
            this.prgEnvio.TabIndex = 0;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Appearance.Options.UseFont = true;
            this.btnEnviar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEnviar.ImageOptions.Image")));
            this.btnEnviar.Location = new System.Drawing.Point(447, 41);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(150, 36);
            this.btnEnviar.TabIndex = 1;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Location = new System.Drawing.Point(185, 51);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 13);
            this.lblMensaje.TabIndex = 2;
            // 
            // nudVeces
            // 
            this.nudVeces.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudVeces.Location = new System.Drawing.Point(55, 47);
            this.nudVeces.Name = "nudVeces";
            this.nudVeces.Size = new System.Drawing.Size(64, 23);
            this.nudVeces.TabIndex = 3;
            this.nudVeces.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Repetir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Veces";
            // 
            // frmEnviarPSE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 93);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nudVeces);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.prgEnvio);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEnviarPSE";
            this.Text = "Enviar documentos Pendientes al PSE";
            this.Load += new System.EventHandler(this.frmEnviarPSE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prgEnvio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVeces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ProgressBarControl prgEnvio;
        private DevExpress.XtraEditors.SimpleButton btnEnviar;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.NumericUpDown nudVeces;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}