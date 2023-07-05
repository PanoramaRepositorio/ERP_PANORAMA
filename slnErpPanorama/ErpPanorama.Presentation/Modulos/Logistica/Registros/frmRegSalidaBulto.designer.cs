namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegSalidaBulto
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
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblMensaje = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(111, 20);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.Properties.Appearance.Options.UseFont = true;
            this.txtNumero.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumero.Properties.MaxLength = 50;
            this.txtNumero.Size = new System.Drawing.Size(193, 32);
            this.txtNumero.TabIndex = 20;
            this.txtNumero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(19, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(86, 25);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "N° Bulto:";
            // 
            // lblMensaje
            // 
            this.lblMensaje.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lblMensaje.Location = new System.Drawing.Point(19, 63);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(0, 19);
            this.lblMensaje.TabIndex = 23;
            // 
            // frmRegSalidaBulto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 97);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegSalidaBulto";
            this.Text = "Salida Bulto";
            this.Load += new System.EventHandler(this.frmRegSalidaBulto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblMensaje;


    }
}