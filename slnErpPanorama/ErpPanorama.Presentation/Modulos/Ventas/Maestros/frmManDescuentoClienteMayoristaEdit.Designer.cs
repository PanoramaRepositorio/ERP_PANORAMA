namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManDescuentoClienteMayoristaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManDescuentoClienteMayoristaEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.chkVenta = new DevExpress.XtraEditors.CheckEdit();
            this.chkPreventa = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboLineaProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboFormaPago = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescuento = new DevExpress.XtraEditors.TextEdit();
            this.txtMontoMax = new DevExpress.XtraEditors.TextEdit();
            this.txtMontoMin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreventa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineaProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoMin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.chkVenta);
            this.grdDatos.Controls.Add(this.chkPreventa);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.cboLineaProducto);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.cboFormaPago);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtDescuento);
            this.grdDatos.Controls.Add(this.txtMontoMax);
            this.grdDatos.Controls.Add(this.txtMontoMin);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(406, 128);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // chkVenta
            // 
            this.chkVenta.Location = new System.Drawing.Point(319, 99);
            this.chkVenta.Name = "chkVenta";
            this.chkVenta.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.chkVenta.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkVenta.Properties.Appearance.Options.UseBackColor = true;
            this.chkVenta.Properties.Appearance.Options.UseFont = true;
            this.chkVenta.Properties.Caption = "Venta PV";
            this.chkVenta.Size = new System.Drawing.Size(75, 19);
            this.chkVenta.TabIndex = 11;
            // 
            // chkPreventa
            // 
            this.chkPreventa.Location = new System.Drawing.Point(216, 99);
            this.chkPreventa.Name = "chkPreventa";
            this.chkPreventa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkPreventa.Properties.Appearance.Options.UseFont = true;
            this.chkPreventa.Properties.Caption = "Preventa";
            this.chkPreventa.Size = new System.Drawing.Size(75, 19);
            this.chkPreventa.TabIndex = 10;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 98);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Descuento:";
            // 
            // cboLineaProducto
            // 
            this.cboLineaProducto.Location = new System.Drawing.Point(93, 50);
            this.cboLineaProducto.Name = "cboLineaProducto";
            this.cboLineaProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLineaProducto.Properties.NullText = "";
            this.cboLineaProducto.Size = new System.Drawing.Size(306, 20);
            this.cboLineaProducto.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Línea Producto:";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.Location = new System.Drawing.Point(93, 28);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFormaPago.Properties.NullText = "";
            this.cboFormaPago.Size = new System.Drawing.Size(306, 20);
            this.cboFormaPago.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Forma Pago:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.EditValue = "0.00";
            this.txtDescuento.Location = new System.Drawing.Point(93, 95);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Properties.Appearance.Options.UseFont = true;
            this.txtDescuento.Properties.DisplayFormat.FormatString = "n2";
            this.txtDescuento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDescuento.Properties.Mask.EditMask = "n2";
            this.txtDescuento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDescuento.Properties.Mask.ShowPlaceHolders = false;
            this.txtDescuento.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDescuento.Size = new System.Drawing.Size(100, 20);
            this.txtDescuento.TabIndex = 9;
            // 
            // txtMontoMax
            // 
            this.txtMontoMax.EditValue = "0.00";
            this.txtMontoMax.Location = new System.Drawing.Point(299, 73);
            this.txtMontoMax.Name = "txtMontoMax";
            this.txtMontoMax.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoMax.Properties.Appearance.Options.UseFont = true;
            this.txtMontoMax.Properties.DisplayFormat.FormatString = "n2";
            this.txtMontoMax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMontoMax.Properties.Mask.EditMask = "n2";
            this.txtMontoMax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMontoMax.Properties.Mask.ShowPlaceHolders = false;
            this.txtMontoMax.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMontoMax.Size = new System.Drawing.Size(100, 20);
            this.txtMontoMax.TabIndex = 7;
            // 
            // txtMontoMin
            // 
            this.txtMontoMin.EditValue = "0.00";
            this.txtMontoMin.Location = new System.Drawing.Point(93, 72);
            this.txtMontoMin.Name = "txtMontoMin";
            this.txtMontoMin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoMin.Properties.Appearance.Options.UseFont = true;
            this.txtMontoMin.Properties.DisplayFormat.FormatString = "n2";
            this.txtMontoMin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMontoMin.Properties.Mask.EditMask = "n2";
            this.txtMontoMin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMontoMin.Properties.Mask.ShowPlaceHolders = false;
            this.txtMontoMin.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtMontoMin.Size = new System.Drawing.Size(100, 20);
            this.txtMontoMin.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(201, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Monto Max US$:";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 75);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(79, 13);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "Monto Min. US$:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(324, 134);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(243, 134);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManDescuentoClienteMayoristaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 161);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManDescuentoClienteMayoristaEdit";
            this.Load += new System.EventHandler(this.frmManDescuentoClienteMayoristaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkPreventa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineaProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoMin.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.TextEdit txtDescuento;
        public DevExpress.XtraEditors.TextEdit txtMontoMax;
        public DevExpress.XtraEditors.TextEdit txtMontoMin;
        public DevExpress.XtraEditors.LookUpEdit cboFormaPago;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboLineaProducto;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit chkPreventa;
        private DevExpress.XtraEditors.CheckEdit chkVenta;
    }
}