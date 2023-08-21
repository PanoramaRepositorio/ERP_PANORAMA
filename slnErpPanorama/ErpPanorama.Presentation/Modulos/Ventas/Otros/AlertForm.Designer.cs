
namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class AlertForm
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
            this.lblMensaje = new System.Windows.Forms.Label();
            this.pictureBoxCandado = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCandado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lblMensaje.Location = new System.Drawing.Point(163, 95);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(80, 27);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "label1";
            // 
            // pictureBoxCandado
            // 
            this.pictureBoxCandado.InitialImage = null;
            this.pictureBoxCandado.Location = new System.Drawing.Point(216, 256);
            this.pictureBoxCandado.Name = "pictureBoxCandado";
            this.pictureBoxCandado.Size = new System.Drawing.Size(106, 78);
            this.pictureBoxCandado.TabIndex = 2;
            this.pictureBoxCandado.TabStop = false;
            this.pictureBoxCandado.Click += new System.EventHandler(this.pictureBoxCandado_Click);
            // 
            // AlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxCandado);
            this.Controls.Add(this.lblMensaje);
            this.Name = "AlertForm";
            this.Text = "Cierre de CAJA";
            this.Load += new System.EventHandler(this.AlertForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCandado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.PictureBox pictureBoxCandado;
    }
}