namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmModificaPrecio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificaPrecio));
            this.txtPrecio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPorDesc = new DevExpress.XtraEditors.TextEdit();
            this.btnAutoriza = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrecio
            // 
            this.txtPrecio.EditValue = "0.00";
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(95, 12);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Properties.DisplayFormat.FormatString = "n";
            this.txtPrecio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecio.Properties.Mask.EditMask = "n";
            this.txtPrecio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrecio.Size = new System.Drawing.Size(97, 20);
            this.txtPrecio.TabIndex = 1;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(17, 15);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(76, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Precio Unitario :";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "% Descuento :";
            // 
            // txtPorDesc
            // 
            this.txtPorDesc.EditValue = "0.00";
            this.txtPorDesc.Location = new System.Drawing.Point(95, 34);
            this.txtPorDesc.Name = "txtPorDesc";
            this.txtPorDesc.Properties.DisplayFormat.FormatString = "n";
            this.txtPorDesc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPorDesc.Properties.Mask.EditMask = "n";
            this.txtPorDesc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPorDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPorDesc.Size = new System.Drawing.Size(97, 20);
            this.txtPorDesc.TabIndex = 3;
            // 
            // btnAutoriza
            // 
            this.btnAutoriza.Image = global::ErpPanorama.Presentation.Properties.Resources.Autoriza_16x16;
            this.btnAutoriza.ImageIndex = 0;
            this.btnAutoriza.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAutoriza.Location = new System.Drawing.Point(198, 31);
            this.btnAutoriza.Name = "btnAutoriza";
            this.btnAutoriza.Size = new System.Drawing.Size(26, 23);
            this.btnAutoriza.TabIndex = 55;
            this.btnAutoriza.Click += new System.EventHandler(this.btnAutoriza_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(117, 69);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(36, 69);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmModificaPrecio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 104);
            this.Controls.Add(this.btnAutoriza);
            this.Controls.Add(this.txtPorDesc);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.labelControl8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModificaPrecio";
            this.Text = "Modificar Precio";
            this.Load += new System.EventHandler(this.frmModificaPrecio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorDesc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPrecio;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.TextEdit txtPorDesc;
        private DevExpress.XtraEditors.SimpleButton btnAutoriza;
    }
}