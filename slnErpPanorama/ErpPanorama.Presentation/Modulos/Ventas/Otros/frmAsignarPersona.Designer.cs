namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmAsignarPersona
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
            this.txtPIN = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPIN.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPIN
            // 
            this.txtPIN.Location = new System.Drawing.Point(12, 12);
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Properties.PasswordChar = '☻';
            this.txtPIN.Size = new System.Drawing.Size(284, 20);
            this.txtPIN.TabIndex = 0;
            this.txtPIN.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPIN_KeyUp);
            // 
            // frmAsignarPersona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 53);
            this.Controls.Add(this.txtPIN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsignarPersona";
            this.Text = "Ingresar PIN";
            this.Load += new System.EventHandler(this.frmAsignarPersona_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPIN.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPIN;
    }
}