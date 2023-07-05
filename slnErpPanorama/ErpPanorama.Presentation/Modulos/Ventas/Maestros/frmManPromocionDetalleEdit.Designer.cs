namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManPromocionDetalleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManPromocionDetalleEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.lblMoneda = new DevExpress.XtraEditors.LabelControl();
            this.txtUM = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrecioVenta = new DevExpress.XtraEditors.TextEdit();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.txtProducto = new DevExpress.XtraEditors.TextEdit();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.deFecha);
            this.grdDatos.Controls.Add(this.lblMoneda);
            this.grdDatos.Controls.Add(this.txtUM);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.txtCantidad);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.txtPrecioVenta);
            this.grdDatos.Controls.Add(this.txtCodigo);
            this.grdDatos.Controls.Add(this.lblPersona);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.btnAceptar);
            this.grdDatos.Controls.Add(this.txtProducto);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(543, 112);
            this.grdDatos.TabIndex = 1;
            this.grdDatos.Text = "Datos";
            // 
            // lblMoneda
            // 
            this.lblMoneda.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneda.Location = new System.Drawing.Point(308, 93);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(0, 14);
            this.lblMoneda.TabIndex = 20;
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
            this.labelControl7.Location = new System.Drawing.Point(164, 71);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(41, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "P. Venta";
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
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.EditValue = "0.00";
            this.txtPrecioVenta.Location = new System.Drawing.Point(211, 68);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Properties.DisplayFormat.FormatString = "n";
            this.txtPrecioVenta.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecioVenta.Properties.Mask.EditMask = "n";
            this.txtPrecioVenta.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecioVenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrecioVenta.Size = new System.Drawing.Size(75, 20);
            this.txtPrecioVenta.TabIndex = 8;
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(83, 25);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(203, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(12, 28);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(47, 13);
            this.lblPersona.TabIndex = 0;
            this.lblPersona.Text = "Producto:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(460, 84);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Producto:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(378, 84);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(83, 46);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Properties.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(407, 20);
            this.txtProducto.TabIndex = 3;
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(390, 24);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.ReadOnly = true;
            this.deFecha.Size = new System.Drawing.Size(100, 20);
            this.deFecha.TabIndex = 21;
            // 
            // frmManPromocionDetalleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 114);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManPromocionDetalleEdit";
            this.Text = "Seleccionar Producto";
            this.Load += new System.EventHandler(this.frmManPromocionDetalleEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl lblMoneda;
        public DevExpress.XtraEditors.TextEdit txtUM;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtPrecioVenta;
        public DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        public DevExpress.XtraEditors.TextEdit txtProducto;
        private DevExpress.XtraEditors.DateEdit deFecha;
    }
}