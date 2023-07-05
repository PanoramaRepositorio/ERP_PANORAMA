namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    partial class frmRegMuestraEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegMuestraEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.optHangTag = new System.Windows.Forms.RadioButton();
            this.optCodigo = new System.Windows.Forms.RadioButton();
            this.lblMoneda = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtValorVenta = new DevExpress.XtraEditors.TextEdit();
            this.txtUM = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrecioVenta = new DevExpress.XtraEditors.TextEdit();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtProducto = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.btnGrabar);
            this.grdDatos.Controls.Add(this.optHangTag);
            this.grdDatos.Controls.Add(this.optCodigo);
            this.grdDatos.Controls.Add(this.lblMoneda);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.txtValorVenta);
            this.grdDatos.Controls.Add(this.txtUM);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.txtPrecioVenta);
            this.grdDatos.Controls.Add(this.txtCantidad);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.txtCodigo);
            this.grdDatos.Controls.Add(this.lblPersona);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtProducto);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(543, 150);
            this.grdDatos.TabIndex = 1;
            this.grdDatos.Text = "Datos";
            // 
            // optHangTag
            // 
            this.optHangTag.AutoSize = true;
            this.optHangTag.Checked = true;
            this.optHangTag.Location = new System.Drawing.Point(270, 26);
            this.optHangTag.Name = "optHangTag";
            this.optHangTag.Size = new System.Drawing.Size(71, 17);
            this.optHangTag.TabIndex = 25;
            this.optHangTag.TabStop = true;
            this.optHangTag.Text = "Hang Tag";
            this.optHangTag.UseVisualStyleBackColor = true;
            this.optHangTag.CheckedChanged += new System.EventHandler(this.optHangTag_CheckedChanged);
            // 
            // optCodigo
            // 
            this.optCodigo.AutoSize = true;
            this.optCodigo.Location = new System.Drawing.Point(206, 26);
            this.optCodigo.Name = "optCodigo";
            this.optCodigo.Size = new System.Drawing.Size(58, 17);
            this.optCodigo.TabIndex = 24;
            this.optCodigo.Text = "Código";
            this.optCodigo.UseVisualStyleBackColor = true;
            this.optCodigo.CheckedChanged += new System.EventHandler(this.optCodigo_CheckedChanged);
            // 
            // lblMoneda
            // 
            this.lblMoneda.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneda.Location = new System.Drawing.Point(308, 93);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(0, 14);
            this.lblMoneda.TabIndex = 20;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(177, 93);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(41, 13);
            this.labelControl4.TabIndex = 13;
            this.labelControl4.Text = "V. Venta";
            // 
            // txtValorVenta
            // 
            this.txtValorVenta.EditValue = "0.00";
            this.txtValorVenta.Location = new System.Drawing.Point(224, 90);
            this.txtValorVenta.Name = "txtValorVenta";
            this.txtValorVenta.Properties.DisplayFormat.FormatString = "n";
            this.txtValorVenta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtValorVenta.Properties.Mask.EditMask = "n";
            this.txtValorVenta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtValorVenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorVenta.Size = new System.Drawing.Size(75, 20);
            this.txtValorVenta.TabIndex = 14;
            // 
            // txtUM
            // 
            this.txtUM.Location = new System.Drawing.Point(496, 46);
            this.txtUM.Name = "txtUM";
            this.txtUM.Properties.ReadOnly = true;
            this.txtUM.Size = new System.Drawing.Size(39, 20);
            this.txtUM.TabIndex = 4;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 93);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(41, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "P. Venta";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.EditValue = "0.00";
            this.txtPrecioVenta.Location = new System.Drawing.Point(83, 90);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Properties.DisplayFormat.FormatString = "n";
            this.txtPrecioVenta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecioVenta.Properties.Mask.EditMask = "n";
            this.txtPrecioVenta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecioVenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrecioVenta.Size = new System.Drawing.Size(75, 20);
            this.txtPrecioVenta.TabIndex = 12;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(83, 68);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Properties.DisplayFormat.FormatString = "f0";
            this.txtCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCantidad.Properties.Mask.EditMask = "f0";
            this.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCantidad.Properties.MaxLength = 4;
            this.txtCantidad.Size = new System.Drawing.Size(75, 20);
            this.txtCantidad.TabIndex = 6;
            this.txtCantidad.ToolTip = "Periodo";
            this.txtCantidad.EditValueChanged += new System.EventHandler(this.txtCantidad_EditValueChanged);
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 71);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(47, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Cantidad:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(83, 25);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(112, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(12, 28);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(37, 13);
            this.lblPersona.TabIndex = 0;
            this.lblPersona.Text = "Código:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(83, 46);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Properties.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(407, 20);
            this.txtProducto.TabIndex = 3;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(460, 123);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(379, 123);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 26;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmRegMuestraEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 152);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegMuestraEdit";
            this.Text = "Seleccina Producto";
            this.Load += new System.EventHandler(this.frmRegMuestraEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private System.Windows.Forms.RadioButton optHangTag;
        private System.Windows.Forms.RadioButton optCodigo;
        private DevExpress.XtraEditors.LabelControl lblMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.TextEdit txtValorVenta;
        public DevExpress.XtraEditors.TextEdit txtUM;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit txtPrecioVenta;
        public DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtProducto;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
    }
}