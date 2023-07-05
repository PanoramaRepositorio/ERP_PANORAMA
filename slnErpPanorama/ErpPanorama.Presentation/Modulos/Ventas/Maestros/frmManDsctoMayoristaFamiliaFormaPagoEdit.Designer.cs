namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManDsctoMayoristaFamiliaFormaPagoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManDsctoMayoristaFamiliaFormaPagoEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrecio_Del = new DevExpress.XtraEditors.TextEdit();
            this.txtPrecio_Al = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.chkAdicional = new DevExpress.XtraEditors.CheckEdit();
            this.cboFamiliaProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboFormaPago = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDsctoMayorista = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkVenta = new DevExpress.XtraEditors.CheckEdit();
            this.chkPreventa = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio_Del.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio_Al.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAdicional.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFamiliaProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDsctoMayorista.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreventa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.txtPrecio_Del);
            this.grdDatos.Controls.Add(this.txtPrecio_Al);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.chkAdicional);
            this.grdDatos.Controls.Add(this.cboFamiliaProducto);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.cboFormaPago);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtDsctoMayorista);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(450, 128);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 77);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(19, 13);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "Del:";
            // 
            // txtPrecio_Del
            // 
            this.txtPrecio_Del.EditValue = "0.00";
            this.txtPrecio_Del.Location = new System.Drawing.Point(93, 74);
            this.txtPrecio_Del.Name = "txtPrecio_Del";
            this.txtPrecio_Del.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio_Del.Properties.Appearance.Options.UseFont = true;
            this.txtPrecio_Del.Properties.DisplayFormat.FormatString = "n2";
            this.txtPrecio_Del.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecio_Del.Properties.Mask.EditMask = "n2";
            this.txtPrecio_Del.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecio_Del.Properties.Mask.ShowPlaceHolders = false;
            this.txtPrecio_Del.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrecio_Del.Properties.MaxLength = 10;
            this.txtPrecio_Del.Size = new System.Drawing.Size(75, 20);
            this.txtPrecio_Del.TabIndex = 16;
            // 
            // txtPrecio_Al
            // 
            this.txtPrecio_Al.EditValue = "0.00";
            this.txtPrecio_Al.Location = new System.Drawing.Point(189, 74);
            this.txtPrecio_Al.Name = "txtPrecio_Al";
            this.txtPrecio_Al.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio_Al.Properties.Appearance.Options.UseFont = true;
            this.txtPrecio_Al.Properties.DisplayFormat.FormatString = "n2";
            this.txtPrecio_Al.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecio_Al.Properties.Mask.EditMask = "n2";
            this.txtPrecio_Al.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecio_Al.Properties.Mask.ShowPlaceHolders = false;
            this.txtPrecio_Al.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrecio_Al.Properties.MaxLength = 10;
            this.txtPrecio_Al.Size = new System.Drawing.Size(74, 20);
            this.txtPrecio_Al.TabIndex = 14;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(172, 77);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(13, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Al:";
            // 
            // chkAdicional
            // 
            this.chkAdicional.Location = new System.Drawing.Point(340, 102);
            this.chkAdicional.Name = "chkAdicional";
            this.chkAdicional.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkAdicional.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkAdicional.Properties.Appearance.Options.UseBackColor = true;
            this.chkAdicional.Properties.Appearance.Options.UseFont = true;
            this.chkAdicional.Properties.Caption = "Adicional";
            this.chkAdicional.Size = new System.Drawing.Size(100, 20);
            this.chkAdicional.TabIndex = 12;
            // 
            // cboFamiliaProducto
            // 
            this.cboFamiliaProducto.Location = new System.Drawing.Point(93, 26);
            this.cboFamiliaProducto.Name = "cboFamiliaProducto";
            this.cboFamiliaProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFamiliaProducto.Properties.NullText = "";
            this.cboFamiliaProducto.Size = new System.Drawing.Size(348, 20);
            this.cboFamiliaProducto.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(82, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Familia Producto:";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.Location = new System.Drawing.Point(93, 49);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFormaPago.Properties.NullText = "";
            this.cboFormaPago.Size = new System.Drawing.Size(347, 20);
            this.cboFormaPago.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Forma Pago:";
            // 
            // txtDsctoMayorista
            // 
            this.txtDsctoMayorista.EditValue = "0.00";
            this.txtDsctoMayorista.Location = new System.Drawing.Point(364, 74);
            this.txtDsctoMayorista.Name = "txtDsctoMayorista";
            this.txtDsctoMayorista.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDsctoMayorista.Properties.Appearance.Options.UseFont = true;
            this.txtDsctoMayorista.Properties.DisplayFormat.FormatString = "n2";
            this.txtDsctoMayorista.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDsctoMayorista.Properties.Mask.EditMask = "n2";
            this.txtDsctoMayorista.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDsctoMayorista.Properties.Mask.ShowPlaceHolders = false;
            this.txtDsctoMayorista.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDsctoMayorista.Properties.MaxLength = 10;
            this.txtDsctoMayorista.Size = new System.Drawing.Size(75, 20);
            this.txtDsctoMayorista.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(279, 79);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(81, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Dscto Mayorista:";
            // 
            // chkVenta
            // 
            this.chkVenta.Location = new System.Drawing.Point(324, 181);
            this.chkVenta.Name = "chkVenta";
            this.chkVenta.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkVenta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkVenta.Properties.Appearance.Options.UseBackColor = true;
            this.chkVenta.Properties.Appearance.Options.UseFont = true;
            this.chkVenta.Properties.Caption = "Venta PV";
            this.chkVenta.Size = new System.Drawing.Size(75, 20);
            this.chkVenta.TabIndex = 11;
            // 
            // chkPreventa
            // 
            this.chkPreventa.Location = new System.Drawing.Point(221, 181);
            this.chkPreventa.Name = "chkPreventa";
            this.chkPreventa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkPreventa.Properties.Appearance.Options.UseFont = true;
            this.chkPreventa.Properties.Caption = "Preventa";
            this.chkPreventa.Size = new System.Drawing.Size(75, 20);
            this.chkPreventa.TabIndex = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(366, 134);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(285, 134);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManDsctoMayoristaFamiliaFormaPagoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 166);
            this.Controls.Add(this.chkVenta);
            this.Controls.Add(this.chkPreventa);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManDsctoMayoristaFamiliaFormaPagoEdit";
            this.Load += new System.EventHandler(this.frmManDescuentoMayoristaLineaPagoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio_Del.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio_Al.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAdicional.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFamiliaProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDsctoMayorista.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreventa.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.TextEdit txtDsctoMayorista;
        public DevExpress.XtraEditors.LookUpEdit cboFormaPago;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboFamiliaProducto;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chkPreventa;
        private DevExpress.XtraEditors.CheckEdit chkVenta;
        private DevExpress.XtraEditors.CheckEdit chkAdicional;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.TextEdit txtPrecio_Del;
        public DevExpress.XtraEditors.TextEdit txtPrecio_Al;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}