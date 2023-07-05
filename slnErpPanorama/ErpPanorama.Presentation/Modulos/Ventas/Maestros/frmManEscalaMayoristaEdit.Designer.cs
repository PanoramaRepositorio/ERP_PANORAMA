namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManEscalaMayoristaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManEscalaMayoristaEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescuento = new DevExpress.XtraEditors.TextEdit();
            this.chkGeneral = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboFamiliaProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboFormaPago = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrecio_Del = new DevExpress.XtraEditors.TextEdit();
            this.txtPrecio_Al = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkVenta = new DevExpress.XtraEditors.CheckEdit();
            this.chkPreventa = new DevExpress.XtraEditors.CheckEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGeneral.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFamiliaProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio_Del.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio_Al.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreventa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.txtDescuento);
            this.grdDatos.Controls.Add(this.chkGeneral);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.cboFamiliaProducto);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.cboFormaPago);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtPrecio_Del);
            this.grdDatos.Controls.Add(this.txtPrecio_Al);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(406, 128);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos Escala";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(267, 76);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Descuento:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.EditValue = "0.00";
            this.txtDescuento.Location = new System.Drawing.Point(326, 73);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Properties.Appearance.Options.UseFont = true;
            this.txtDescuento.Properties.DisplayFormat.FormatString = "n2";
            this.txtDescuento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDescuento.Properties.Mask.EditMask = "n2";
            this.txtDescuento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDescuento.Properties.Mask.ShowPlaceHolders = false;
            this.txtDescuento.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDescuento.Properties.MaxLength = 10;
            this.txtDescuento.Size = new System.Drawing.Size(74, 20);
            this.txtDescuento.TabIndex = 13;
            // 
            // chkGeneral
            // 
            this.chkGeneral.Location = new System.Drawing.Point(299, 99);
            this.chkGeneral.Name = "chkGeneral";
            this.chkGeneral.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkGeneral.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkGeneral.Properties.Appearance.Options.UseBackColor = true;
            this.chkGeneral.Properties.Appearance.Options.UseFont = true;
            this.chkGeneral.Properties.Caption = "General";
            this.chkGeneral.Size = new System.Drawing.Size(100, 20);
            this.chkGeneral.TabIndex = 12;
            this.chkGeneral.CheckedChanged += new System.EventHandler(this.chkGeneral_CheckedChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 76);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(19, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Del:";
            // 
            // cboFamiliaProducto
            // 
            this.cboFamiliaProducto.Location = new System.Drawing.Point(94, 26);
            this.cboFamiliaProducto.Name = "cboFamiliaProducto";
            this.cboFamiliaProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFamiliaProducto.Properties.NullText = "";
            this.cboFamiliaProducto.Size = new System.Drawing.Size(306, 20);
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
            this.cboFormaPago.Size = new System.Drawing.Size(306, 20);
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
            // txtPrecio_Del
            // 
            this.txtPrecio_Del.EditValue = "0.00";
            this.txtPrecio_Del.Location = new System.Drawing.Point(93, 73);
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
            this.txtPrecio_Del.TabIndex = 9;
            // 
            // txtPrecio_Al
            // 
            this.txtPrecio_Al.EditValue = "0.00";
            this.txtPrecio_Al.Location = new System.Drawing.Point(189, 73);
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
            this.txtPrecio_Al.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(172, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(13, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Al:";
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
            this.btnCancelar.Location = new System.Drawing.Point(324, 134);
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
            this.btnGrabar.Location = new System.Drawing.Point(243, 134);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManEscalaMayoristaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 166);
            this.Controls.Add(this.chkVenta);
            this.Controls.Add(this.chkPreventa);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManEscalaMayoristaEdit";
            this.Load += new System.EventHandler(this.frmManDescuentoMayoristaLineaPagoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGeneral.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFamiliaProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio_Del.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecio_Al.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreventa.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.TextEdit txtPrecio_Del;
        public DevExpress.XtraEditors.TextEdit txtPrecio_Al;
        public DevExpress.XtraEditors.LookUpEdit cboFormaPago;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboFamiliaProducto;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit chkPreventa;
        private DevExpress.XtraEditors.CheckEdit chkVenta;
        private DevExpress.XtraEditors.CheckEdit chkGeneral;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.TextEdit txtDescuento;
    }
}