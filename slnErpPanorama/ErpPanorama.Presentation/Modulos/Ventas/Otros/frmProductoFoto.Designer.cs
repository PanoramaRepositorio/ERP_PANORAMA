namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmProductoFoto
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
            this.picImage = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.EditValue = global::ErpPanorama.Presentation.Properties.Resources.noImage;
            this.picImage.Location = new System.Drawing.Point(0, -1);
            this.picImage.Name = "picImage";
            this.picImage.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.picImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picImage.Size = new System.Drawing.Size(439, 421);
            this.picImage.TabIndex = 28;
            // 
            // frmProductoFoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 422);
            this.Controls.Add(this.picImage);
            this.Name = "frmProductoFoto";
            this.Text = "Producto Foto";
            this.Load += new System.EventHandler(this.frmProductoFoto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picImage;
    }
}