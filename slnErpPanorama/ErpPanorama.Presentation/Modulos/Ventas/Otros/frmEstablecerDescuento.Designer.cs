namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmEstablecerDescuento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstablecerDescuento));
            this.txtPorDesc = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMotivo = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPorDesc
            // 
            this.txtPorDesc.EditValue = "0.00";
            this.txtPorDesc.Location = new System.Drawing.Point(95, 12);
            this.txtPorDesc.Name = "txtPorDesc";
            this.txtPorDesc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtPorDesc.Properties.Appearance.Options.UseFont = true;
            this.txtPorDesc.Properties.DisplayFormat.FormatString = "n";
            this.txtPorDesc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPorDesc.Properties.Mask.EditMask = "n";
            this.txtPorDesc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPorDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPorDesc.Size = new System.Drawing.Size(97, 20);
            this.txtPorDesc.TabIndex = 1;
            this.txtPorDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorDesc_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(442, 60);
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
            this.btnAceptar.Location = new System.Drawing.Point(361, 60);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(17, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "% Descuento :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(53, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Motivo:";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(95, 34);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtMotivo.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMotivo.Properties.Items.AddRange(new object[] {
            "FALTO CAMBIAR LA ETIQUETA POR: ",
            "ORDEN DE GERENCIA - SRA AMALIA",
            "ORDEN DE GERENCIA - SR ELEAZAR",
            "PRODUCTO CON FALLA POR: ",
            "OUTLET POR:"});
            this.txtMotivo.Properties.MaxLength = 50;
            this.txtMotivo.Size = new System.Drawing.Size(422, 20);
            this.txtMotivo.TabIndex = 3;
            this.txtMotivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMotivo_KeyPress);
            // 
            // frmEstablecerDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 95);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.txtPorDesc);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEstablecerDescuento";
            this.Text = "Establecer %  al grupo seleccionado";
            this.Load += new System.EventHandler(this.frmEstablecerDescuento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPorDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtPorDesc;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit txtMotivo;
    }
}