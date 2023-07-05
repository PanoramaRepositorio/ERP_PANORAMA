namespace ErpPanorama.Presentation.Modulos.Ecommerce
{
    partial class frmRegPedidoDetalleEditWeb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegPedidoDetalleEditWeb));
            this.txtProducto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.txtPrecioUnitario = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.txtPrecioVenta = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtUM = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.labelControl28 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl27 = new DevExpress.XtraEditors.LabelControl();
            this.optHangTag = new System.Windows.Forms.RadioButton();
            this.optCodigo = new System.Windows.Forms.RadioButton();
            this.btnAplicarPrecioAB = new DevExpress.XtraEditors.SimpleButton();
            this.btnCalcula = new DevExpress.XtraEditors.SimpleButton();
            this.btnCantidadBulto = new DevExpress.XtraEditors.SimpleButton();
            this.btnAutorizarAutoservicio = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditaPrecio = new DevExpress.XtraEditors.SimpleButton();
            this.lblMoneda = new DevExpress.XtraEditors.LabelControl();
            this.chkMuestra = new DevExpress.XtraEditors.CheckEdit();
            this.lblMensaje = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtObservacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtValorVenta = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescuento = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.lblDescPromocion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioUnitario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMuestra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(83, 46);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Properties.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(407, 20);
            this.txtProducto.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Producto:";
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(12, 28);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(37, 13);
            this.lblPersona.TabIndex = 0;
            this.lblPersona.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(83, 25);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(178, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.EditValue = "0.00";
            this.txtPrecioUnitario.Location = new System.Drawing.Point(224, 68);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Properties.DisplayFormat.FormatString = "n";
            this.txtPrecioUnitario.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrecioUnitario.Properties.Mask.EditMask = "n";
            this.txtPrecioUnitario.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrecioUnitario.Properties.ReadOnly = true;
            this.txtPrecioUnitario.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrecioUnitario.Size = new System.Drawing.Size(75, 20);
            this.txtPrecioUnitario.TabIndex = 8;
            this.txtPrecioUnitario.EditValueChanged += new System.EventHandler(this.txtPrecioUnitario_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 71);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(47, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Cantidad:";
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
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
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
            this.txtPrecioVenta.Properties.ReadOnly = true;
            this.txtPrecioVenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrecioVenta.Size = new System.Drawing.Size(75, 20);
            this.txtPrecioVenta.TabIndex = 12;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 93);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(41, 13);
            this.labelControl7.TabIndex = 11;
            this.labelControl7.Text = "P. Venta";
            // 
            // txtUM
            // 
            this.txtUM.Location = new System.Drawing.Point(496, 46);
            this.txtUM.Name = "txtUM";
            this.txtUM.Properties.ReadOnly = true;
            this.txtUM.Size = new System.Drawing.Size(39, 20);
            this.txtUM.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(164, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "P. Unitario:";
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.lblDescPromocion);
            this.grdDatos.Controls.Add(this.labelControl28);
            this.grdDatos.Controls.Add(this.labelControl27);
            this.grdDatos.Controls.Add(this.optHangTag);
            this.grdDatos.Controls.Add(this.optCodigo);
            this.grdDatos.Controls.Add(this.btnAplicarPrecioAB);
            this.grdDatos.Controls.Add(this.btnCalcula);
            this.grdDatos.Controls.Add(this.btnCantidadBulto);
            this.grdDatos.Controls.Add(this.btnAutorizarAutoservicio);
            this.grdDatos.Controls.Add(this.btnEditaPrecio);
            this.grdDatos.Controls.Add(this.lblMoneda);
            this.grdDatos.Controls.Add(this.chkMuestra);
            this.grdDatos.Controls.Add(this.lblMensaje);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.txtObservacion);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.txtValorVenta);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.txtDescuento);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtUM);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.txtPrecioVenta);
            this.grdDatos.Controls.Add(this.txtCantidad);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.txtPrecioUnitario);
            this.grdDatos.Controls.Add(this.txtCodigo);
            this.grdDatos.Controls.Add(this.lblPersona);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.btnAceptar);
            this.grdDatos.Controls.Add(this.txtProducto);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(543, 188);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            this.grdDatos.Paint += new System.Windows.Forms.PaintEventHandler(this.grdDatos_Paint);
            // 
            // labelControl28
            // 
            this.labelControl28.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl28.Appearance.Options.UseFont = true;
            this.labelControl28.Location = new System.Drawing.Point(434, 28);
            this.labelControl28.Name = "labelControl28";
            this.labelControl28.Size = new System.Drawing.Size(13, 13);
            this.labelControl28.TabIndex = 28;
            this.labelControl28.Text = "F6";
            // 
            // labelControl27
            // 
            this.labelControl27.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl27.Appearance.Options.UseFont = true;
            this.labelControl27.Location = new System.Drawing.Point(333, 28);
            this.labelControl27.Name = "labelControl27";
            this.labelControl27.Size = new System.Drawing.Size(13, 13);
            this.labelControl27.TabIndex = 29;
            this.labelControl27.Text = "F5";
            // 
            // optHangTag
            // 
            this.optHangTag.AutoSize = true;
            this.optHangTag.Location = new System.Drawing.Point(360, 26);
            this.optHangTag.Name = "optHangTag";
            this.optHangTag.Size = new System.Drawing.Size(71, 17);
            this.optHangTag.TabIndex = 27;
            this.optHangTag.Text = "Hang Tag";
            this.optHangTag.UseVisualStyleBackColor = true;
            this.optHangTag.CheckedChanged += new System.EventHandler(this.optHangTag_CheckedChanged);
            // 
            // optCodigo
            // 
            this.optCodigo.AutoSize = true;
            this.optCodigo.Checked = true;
            this.optCodigo.Location = new System.Drawing.Point(275, 26);
            this.optCodigo.Name = "optCodigo";
            this.optCodigo.Size = new System.Drawing.Size(58, 17);
            this.optCodigo.TabIndex = 26;
            this.optCodigo.TabStop = true;
            this.optCodigo.Text = "Código";
            this.optCodigo.UseVisualStyleBackColor = true;
            this.optCodigo.CheckedChanged += new System.EventHandler(this.optCodigo_CheckedChanged);
            // 
            // btnAplicarPrecioAB
            // 
            this.btnAplicarPrecioAB.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Promocion_16x16;
            this.btnAplicarPrecioAB.Location = new System.Drawing.Point(480, 68);
            this.btnAplicarPrecioAB.Name = "btnAplicarPrecioAB";
            this.btnAplicarPrecioAB.Size = new System.Drawing.Size(26, 20);
            this.btnAplicarPrecioAB.TabIndex = 25;
            this.btnAplicarPrecioAB.ToolTip = "Aplicar precio CD Soles";
            this.btnAplicarPrecioAB.Click += new System.EventHandler(this.btnAplicarPrecioAB_Click);
            // 
            // btnCalcula
            // 
            this.btnCalcula.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Calculator_16x16;
            this.btnCalcula.Location = new System.Drawing.Point(448, 68);
            this.btnCalcula.Name = "btnCalcula";
            this.btnCalcula.Size = new System.Drawing.Size(26, 20);
            this.btnCalcula.TabIndex = 24;
            this.btnCalcula.ToolTip = "Precio Para Clientes Publicitarios";
            this.btnCalcula.Click += new System.EventHandler(this.btnCalcula_Click);
            // 
            // btnCantidadBulto
            // 
            this.btnCantidadBulto.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Bultos_16x16;
            this.btnCantidadBulto.Location = new System.Drawing.Point(509, 68);
            this.btnCantidadBulto.Name = "btnCantidadBulto";
            this.btnCantidadBulto.Size = new System.Drawing.Size(26, 20);
            this.btnCantidadBulto.TabIndex = 23;
            this.btnCantidadBulto.ToolTip = "Venta x bulto cerrado";
            this.btnCantidadBulto.Click += new System.EventHandler(this.btnCantidadBulto_Click);
            // 
            // btnAutorizarAutoservicio
            // 
            this.btnAutorizarAutoservicio.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.AutoServicio_16x16;
            this.btnAutorizarAutoservicio.Location = new System.Drawing.Point(509, 23);
            this.btnAutorizarAutoservicio.Name = "btnAutorizarAutoservicio";
            this.btnAutorizarAutoservicio.Size = new System.Drawing.Size(26, 20);
            this.btnAutorizarAutoservicio.TabIndex = 23;
            this.btnAutorizarAutoservicio.ToolTip = "Deshabilitar Venta por Autservicio";
            this.btnAutorizarAutoservicio.Click += new System.EventHandler(this.btnAutorizarAutoservicio_Click);
            // 
            // btnEditaPrecio
            // 
            this.btnEditaPrecio.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Autoriza_16x16;
            this.btnEditaPrecio.Location = new System.Drawing.Point(416, 68);
            this.btnEditaPrecio.Name = "btnEditaPrecio";
            this.btnEditaPrecio.Size = new System.Drawing.Size(26, 20);
            this.btnEditaPrecio.TabIndex = 23;
            this.btnEditaPrecio.ToolTip = "Aplicar descuento Extra";
            this.btnEditaPrecio.Click += new System.EventHandler(this.btnEditaPrecio_Click);
            // 
            // lblMoneda
            // 
            this.lblMoneda.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneda.Appearance.Options.UseFont = true;
            this.lblMoneda.Location = new System.Drawing.Point(308, 93);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(0, 14);
            this.lblMoneda.TabIndex = 20;
            // 
            // chkMuestra
            // 
            this.chkMuestra.Enabled = false;
            this.chkMuestra.Location = new System.Drawing.Point(12, 135);
            this.chkMuestra.Name = "chkMuestra";
            this.chkMuestra.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkMuestra.Properties.Appearance.Options.UseFont = true;
            this.chkMuestra.Properties.Caption = "Exhibición";
            this.chkMuestra.Size = new System.Drawing.Size(69, 20);
            this.chkMuestra.TabIndex = 17;
            this.chkMuestra.Visible = false;
            this.chkMuestra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkMuestra_KeyPress);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Appearance.Options.UseForeColor = true;
            this.lblMensaje.Location = new System.Drawing.Point(83, 136);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(216, 13);
            this.lblMensaje.TabIndex = 15;
            this.lblMensaje.Text = "Este producto sólo se vende por autoservicio";
            this.lblMensaje.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 115);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 13);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "Observación";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(83, 112);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Size = new System.Drawing.Size(452, 20);
            this.txtObservacion.TabIndex = 16;
            this.txtObservacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservacion_KeyPress);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(164, 93);
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
            this.txtValorVenta.Properties.ReadOnly = true;
            this.txtValorVenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtValorVenta.Size = new System.Drawing.Size(75, 20);
            this.txtValorVenta.TabIndex = 14;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(308, 72);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "% Dscto:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.EditValue = "0";
            this.txtDescuento.Location = new System.Drawing.Point(359, 68);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.txtDescuento.Properties.Appearance.Options.UseFont = true;
            this.txtDescuento.Properties.Appearance.Options.UseForeColor = true;
            this.txtDescuento.Properties.DisplayFormat.FormatString = "n";
            this.txtDescuento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDescuento.Properties.Mask.EditMask = "n";
            this.txtDescuento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDescuento.Properties.ReadOnly = true;
            this.txtDescuento.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDescuento.Size = new System.Drawing.Size(51, 20);
            this.txtDescuento.TabIndex = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(460, 154);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageOptions.ImageIndex = 1;
            this.btnAceptar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(379, 154);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // lblDescPromocion
            // 
            this.lblDescPromocion.AutoSize = true;
            this.lblDescPromocion.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescPromocion.ForeColor = System.Drawing.Color.Red;
            this.lblDescPromocion.Location = new System.Drawing.Point(193, 149);
            this.lblDescPromocion.Name = "lblDescPromocion";
            this.lblDescPromocion.Size = new System.Drawing.Size(0, 25);
            this.lblDescPromocion.TabIndex = 30;
            // 
            // frmRegPedidoDetalleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 189);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegPedidoDetalleEdit";
            this.Text = "Seleccionar Producto";
            this.Load += new System.EventHandler(this.frmRegPedidoDetalleEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioUnitario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrecioVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMuestra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValorVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtProducto;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.TextEdit txtCodigo;
        public DevExpress.XtraEditors.TextEdit txtPrecioUnitario;
        public DevExpress.XtraEditors.TextEdit txtPrecioVenta;
        public DevExpress.XtraEditors.TextEdit txtUM;
        public DevExpress.XtraEditors.TextEdit txtObservacion;
        public DevExpress.XtraEditors.TextEdit txtValorVenta;
        public DevExpress.XtraEditors.TextEdit txtDescuento;
        public DevExpress.XtraEditors.CheckEdit chkMuestra;
        private DevExpress.XtraEditors.LabelControl lblMoneda;
        private DevExpress.XtraEditors.SimpleButton btnEditaPrecio;
        private DevExpress.XtraEditors.SimpleButton btnCalcula;
        private DevExpress.XtraEditors.SimpleButton btnAplicarPrecioAB;
        private System.Windows.Forms.RadioButton optHangTag;
        private System.Windows.Forms.RadioButton optCodigo;
        private DevExpress.XtraEditors.LabelControl labelControl28;
        private DevExpress.XtraEditors.LabelControl labelControl27;
        private DevExpress.XtraEditors.SimpleButton btnCantidadBulto;
        private DevExpress.XtraEditors.SimpleButton btnAutorizarAutoservicio;
        private DevExpress.XtraEditors.LabelControl lblMensaje;
        private System.Windows.Forms.Label lblDescPromocion;
    }
}