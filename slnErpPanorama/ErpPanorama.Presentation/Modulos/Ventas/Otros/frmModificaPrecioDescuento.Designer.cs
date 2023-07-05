namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmModificaPrecioDescuento
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
            this.txtPorDesc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrecio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.btnAutoriza = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.rgDescuentoB = new DevExpress.XtraEditors.RadioGroup();
            this.optDosCinco = new System.Windows.Forms.RadioButton();
            this.optSieteCinco = new System.Windows.Forms.RadioButton();
            this.optDiez = new System.Windows.Forms.RadioButton();
            this.gboDescuento = new System.Windows.Forms.GroupBox();
            this.optCinco = new System.Windows.Forms.RadioButton();
            this.optTrece = new System.Windows.Forms.RadioButton();
            this.txtMotivo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDescuentoB.Properties)).BeginInit();
            this.gboDescuento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPorDesc
            // 
            this.txtPorDesc.EditValue = "0.00";
            this.txtPorDesc.Enabled = false;
            this.txtPorDesc.Location = new System.Drawing.Point(98, 112);
            this.txtPorDesc.Name = "txtPorDesc";
            this.txtPorDesc.Properties.DisplayFormat.FormatString = "n";
            this.txtPorDesc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPorDesc.Properties.Mask.EditMask = "n";
            this.txtPorDesc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPorDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPorDesc.Size = new System.Drawing.Size(97, 20);
            this.txtPorDesc.TabIndex = 5;
            this.txtPorDesc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorDesc_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 115);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "% Descuento :";
            // 
            // txtPrecio
            // 
            this.txtPrecio.EditValue = "0.00";
            this.txtPrecio.Enabled = false;
            this.txtPrecio.Location = new System.Drawing.Point(98, 90);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Properties.DisplayFormat.FormatString = "n";
            this.txtPrecio.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecio.Properties.Mask.EditMask = "n";
            this.txtPrecio.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrecio.Size = new System.Drawing.Size(97, 20);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(25, 93);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(67, 13);
            this.labelControl8.TabIndex = 2;
            this.labelControl8.Text = "Precio Venta :";
            // 
            // btnAutoriza
            // 
            this.btnAutoriza.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Autoriza_16x16;
            this.btnAutoriza.ImageOptions.ImageIndex = 0;
            this.btnAutoriza.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAutoriza.Location = new System.Drawing.Point(381, 46);
            this.btnAutoriza.Name = "btnAutoriza";
            this.btnAutoriza.Size = new System.Drawing.Size(26, 23);
            this.btnAutoriza.TabIndex = 1;
            this.btnAutoriza.Click += new System.EventHandler(this.btnAutoriza_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(229, 160);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageOptions.ImageIndex = 1;
            this.btnAceptar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(148, 160);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // rgDescuentoB
            // 
            this.rgDescuentoB.Location = new System.Drawing.Point(16, 19);
            this.rgDescuentoB.Name = "rgDescuentoB";
            this.rgDescuentoB.Size = new System.Drawing.Size(335, 47);
            this.rgDescuentoB.TabIndex = 0;
            // 
            // optDosCinco
            // 
            this.optDosCinco.AutoSize = true;
            this.optDosCinco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.optDosCinco.Location = new System.Drawing.Point(31, 35);
            this.optDosCinco.Name = "optDosCinco";
            this.optDosCinco.Size = new System.Drawing.Size(55, 17);
            this.optDosCinco.TabIndex = 1;
            this.optDosCinco.TabStop = true;
            this.optDosCinco.Text = "2.5%";
            this.optDosCinco.UseVisualStyleBackColor = true;
            this.optDosCinco.CheckedChanged += new System.EventHandler(this.optDosCinco_CheckedChanged);
            // 
            // optSieteCinco
            // 
            this.optSieteCinco.AutoSize = true;
            this.optSieteCinco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.optSieteCinco.Location = new System.Drawing.Point(176, 35);
            this.optSieteCinco.Name = "optSieteCinco";
            this.optSieteCinco.Size = new System.Drawing.Size(55, 17);
            this.optSieteCinco.TabIndex = 3;
            this.optSieteCinco.TabStop = true;
            this.optSieteCinco.Text = "7.5%";
            this.optSieteCinco.UseVisualStyleBackColor = true;
            this.optSieteCinco.CheckedChanged += new System.EventHandler(this.optSieteCinco_CheckedChanged);
            // 
            // optDiez
            // 
            this.optDiez.AutoSize = true;
            this.optDiez.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.optDiez.Location = new System.Drawing.Point(250, 35);
            this.optDiez.Name = "optDiez";
            this.optDiez.Size = new System.Drawing.Size(52, 17);
            this.optDiez.TabIndex = 4;
            this.optDiez.TabStop = true;
            this.optDiez.Text = "10%";
            this.optDiez.UseVisualStyleBackColor = true;
            this.optDiez.CheckedChanged += new System.EventHandler(this.optDiez_CheckedChanged);
            // 
            // gboDescuento
            // 
            this.gboDescuento.Controls.Add(this.optDiez);
            this.gboDescuento.Controls.Add(this.optSieteCinco);
            this.gboDescuento.Controls.Add(this.optCinco);
            this.gboDescuento.Controls.Add(this.optDosCinco);
            this.gboDescuento.Controls.Add(this.rgDescuentoB);
            this.gboDescuento.Location = new System.Drawing.Point(4, 3);
            this.gboDescuento.Name = "gboDescuento";
            this.gboDescuento.Size = new System.Drawing.Size(364, 79);
            this.gboDescuento.TabIndex = 0;
            this.gboDescuento.TabStop = false;
            this.gboDescuento.Text = "Descuento";
            // 
            // optCinco
            // 
            this.optCinco.AutoSize = true;
            this.optCinco.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.optCinco.Location = new System.Drawing.Point(103, 35);
            this.optCinco.Name = "optCinco";
            this.optCinco.Size = new System.Drawing.Size(45, 17);
            this.optCinco.TabIndex = 2;
            this.optCinco.TabStop = true;
            this.optCinco.Text = "5%";
            this.optCinco.UseVisualStyleBackColor = true;
            this.optCinco.CheckedChanged += new System.EventHandler(this.optCinco_CheckedChanged);
            // 
            // optTrece
            // 
            this.optTrece.AutoSize = true;
            this.optTrece.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.optTrece.Location = new System.Drawing.Point(342, 111);
            this.optTrece.Name = "optTrece";
            this.optTrece.Size = new System.Drawing.Size(52, 17);
            this.optTrece.TabIndex = 6;
            this.optTrece.TabStop = true;
            this.optTrece.Text = "13%";
            this.optTrece.UseVisualStyleBackColor = true;
            this.optTrece.Visible = false;
            this.optTrece.CheckedChanged += new System.EventHandler(this.optTrece_CheckedChanged);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(98, 134);
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
            this.txtMotivo.Size = new System.Drawing.Size(307, 20);
            this.txtMotivo.TabIndex = 8;
            this.txtMotivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMotivo_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(56, 137);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Motivo:";
            // 
            // frmModificaPrecioDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 191);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.optTrece);
            this.Controls.Add(this.btnAutoriza);
            this.Controls.Add(this.txtPorDesc);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.gboDescuento);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmModificaPrecioDescuento";
            this.Text = "Modifica Descuento";
            this.Load += new System.EventHandler(this.frmModificaPrecioDescuento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPorDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgDescuentoB.Properties)).EndInit();
            this.gboDescuento.ResumeLayout(false);
            this.gboDescuento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMotivo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAutoriza;
        private DevExpress.XtraEditors.TextEdit txtPorDesc;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPrecio;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.RadioGroup rgDescuentoB;
        private System.Windows.Forms.RadioButton optDosCinco;
        private System.Windows.Forms.RadioButton optSieteCinco;
        private System.Windows.Forms.RadioButton optDiez;
        private System.Windows.Forms.GroupBox gboDescuento;
        private System.Windows.Forms.RadioButton optCinco;
        private System.Windows.Forms.RadioButton optTrece;
        private DevExpress.XtraEditors.ComboBoxEdit txtMotivo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}