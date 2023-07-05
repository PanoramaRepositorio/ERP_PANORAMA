namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmModificaPrecioPublicitario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModificaPrecioPublicitario));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.txtPorDesc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrecio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtMultiplica = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDivide = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMultiplica.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDivide.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(162, 69);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 57;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(81, 69);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtPorDesc
            // 
            this.txtPorDesc.EditValue = "0.00";
            this.txtPorDesc.Location = new System.Drawing.Point(94, 34);
            this.txtPorDesc.Name = "txtPorDesc";
            this.txtPorDesc.Properties.DisplayFormat.FormatString = "n";
            this.txtPorDesc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPorDesc.Properties.Mask.EditMask = "n";
            this.txtPorDesc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPorDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPorDesc.Size = new System.Drawing.Size(97, 20);
            this.txtPorDesc.TabIndex = 62;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 61;
            this.labelControl1.Text = "% Descuento :";
            // 
            // txtPrecio
            // 
            this.txtPrecio.EditValue = "0.00";
            this.txtPrecio.Location = new System.Drawing.Point(94, 12);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Properties.DisplayFormat.FormatString = "n";
            this.txtPrecio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecio.Properties.Mask.EditMask = "n";
            this.txtPrecio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrecio.Size = new System.Drawing.Size(97, 20);
            this.txtPrecio.TabIndex = 60;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(16, 15);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(76, 13);
            this.labelControl8.TabIndex = 59;
            this.labelControl8.Text = "Precio Unitario :";
            // 
            // txtMultiplica
            // 
            this.txtMultiplica.EditValue = "0";
            this.txtMultiplica.Location = new System.Drawing.Point(213, 12);
            this.txtMultiplica.Name = "txtMultiplica";
            this.txtMultiplica.Properties.EditFormat.FormatString = "n2";
            this.txtMultiplica.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMultiplica.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMultiplica.Size = new System.Drawing.Size(24, 20);
            this.txtMultiplica.TabIndex = 0;
            this.txtMultiplica.EditValueChanged += new System.EventHandler(this.txtMultiplica_EditValueChanged);
            this.txtMultiplica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMultiplica_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Location = new System.Drawing.Point(197, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(8, 13);
            this.labelControl2.TabIndex = 64;
            this.labelControl2.Text = "X";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Location = new System.Drawing.Point(247, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(6, 13);
            this.labelControl3.TabIndex = 66;
            this.labelControl3.Text = "/";
            // 
            // txtDivide
            // 
            this.txtDivide.EditValue = "0";
            this.txtDivide.Location = new System.Drawing.Point(263, 12);
            this.txtDivide.Name = "txtDivide";
            this.txtDivide.Properties.EditFormat.FormatString = "n2";
            this.txtDivide.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDivide.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDivide.Size = new System.Drawing.Size(24, 20);
            this.txtDivide.TabIndex = 65;
            this.txtDivide.EditValueChanged += new System.EventHandler(this.txtDivide_EditValueChanged);
            this.txtDivide.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDivide_KeyPress);
            // 
            // frmModificaPrecioPublicitario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 104);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtDivide);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtMultiplica);
            this.Controls.Add(this.txtPorDesc);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModificaPrecioPublicitario";
            this.Text = "Modificar Precio";
            this.Load += new System.EventHandler(this.frmModificaPrecioPublicitario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPorDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMultiplica.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDivide.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.TextEdit txtPorDesc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPrecio;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtMultiplica;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDivide;
    }
}