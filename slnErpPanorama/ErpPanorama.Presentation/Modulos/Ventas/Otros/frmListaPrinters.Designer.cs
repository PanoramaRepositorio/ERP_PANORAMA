namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmListaPrinters
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaPrinters));
            this.lstImpresora = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.nudCopias = new System.Windows.Forms.NumericUpDown();
            this.lblCopias = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopias)).BeginInit();
            this.SuspendLayout();
            // 
            // lstImpresora
            // 
            this.lstImpresora.LargeImageList = this.imageList1;
            this.lstImpresora.Location = new System.Drawing.Point(-2, 39);
            this.lstImpresora.Name = "lstImpresora";
            this.lstImpresora.Size = new System.Drawing.Size(297, 268);
            this.lstImpresora.SmallImageList = this.imageList1;
            this.lstImpresora.TabIndex = 0;
            this.lstImpresora.UseCompatibleStateImageBehavior = false;
            this.lstImpresora.View = System.Windows.Forms.View.List;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "print_16x16.gif");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(211, 313);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(130, 313);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(159, 14);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Seleccionar una impresora";
            // 
            // nudCopias
            // 
            this.nudCopias.Location = new System.Drawing.Point(62, 315);
            this.nudCopias.Name = "nudCopias";
            this.nudCopias.Size = new System.Drawing.Size(47, 21);
            this.nudCopias.TabIndex = 8;
            this.nudCopias.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblCopias
            // 
            this.lblCopias.Location = new System.Drawing.Point(5, 318);
            this.lblCopias.Name = "lblCopias";
            this.lblCopias.Size = new System.Drawing.Size(51, 13);
            this.lblCopias.TabIndex = 9;
            this.lblCopias.Text = "N° Copias:";
            // 
            // frmListaPrinters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 342);
            this.Controls.Add(this.lblCopias);
            this.Controls.Add(this.nudCopias);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lstImpresora);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListaPrinters";
            this.Text = "Listado de Impresoras";
            this.Load += new System.EventHandler(this.frmListaPrinters_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCopias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lstImpresora;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.NumericUpDown nudCopias;
        private DevExpress.XtraEditors.LabelControl lblCopias;
    }
}