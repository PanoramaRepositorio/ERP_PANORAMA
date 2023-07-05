namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegInventarioAnaquelesEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegInventarioAnaquelesEdit));
            this.txtObservacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.cboAlmacen = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnModificarBarras = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.txtUbicacion = new DevExpress.XtraEditors.TextEdit();
            this.optHangTag = new System.Windows.Forms.RadioButton();
            this.optCodigo = new System.Windows.Forms.RadioButton();
            this.lblMoneda = new DevExpress.XtraEditors.LabelControl();
            this.txtUM = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtProducto = new DevExpress.XtraEditors.TextEdit();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(97, 141);
            this.txtObservacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txtObservacion.Properties.Appearance.Options.UseForeColor = true;
            this.txtObservacion.Size = new System.Drawing.Size(329, 22);
            this.txtObservacion.TabIndex = 19;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 145);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 16);
            this.labelControl3.TabIndex = 18;
            this.labelControl3.Text = "Observación:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 260);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(44, 16);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Tienda:";
            this.labelControl4.Visible = false;
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(97, 257);
            this.cboTienda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Properties.ReadOnly = true;
            this.cboTienda.Size = new System.Drawing.Size(160, 22);
            this.cboTienda.TabIndex = 15;
            this.cboTienda.Visible = false;
            this.cboTienda.EditValueChanged += new System.EventHandler(this.cboTienda_EditValueChanged);
            this.cboTienda.Click += new System.EventHandler(this.cboTienda_EditValueChanged);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Location = new System.Drawing.Point(325, 257);
            this.cboAlmacen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAlmacen.Properties.NullText = "";
            this.cboAlmacen.Properties.ReadOnly = true;
            this.cboAlmacen.Size = new System.Drawing.Size(299, 22);
            this.cboAlmacen.TabIndex = 17;
            this.cboAlmacen.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(267, 260);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 16);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Almacén:";
            this.labelControl2.Visible = false;
            // 
            // btnModificarBarras
            // 
            this.btnModificarBarras.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.edit;
            this.btnModificarBarras.ImageOptions.ImageIndex = 1;
            this.btnModificarBarras.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnModificarBarras.Location = new System.Drawing.Point(502, 44);
            this.btnModificarBarras.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnModificarBarras.Name = "btnModificarBarras";
            this.btnModificarBarras.Size = new System.Drawing.Size(125, 43);
            this.btnModificarBarras.TabIndex = 12;
            this.btnModificarBarras.Text = "Modificar \r\nCódigo de barra";
            this.btnModificarBarras.ToolTip = "Modificar Codigo de Barras de Importación";
            this.btnModificarBarras.Click += new System.EventHandler(this.btnModificarBarras_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(446, 139);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 12;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(97, 112);
            this.txtUbicacion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUbicacion.Properties.Appearance.Options.UseBackColor = true;
            this.txtUbicacion.Size = new System.Drawing.Size(138, 22);
            this.txtUbicacion.TabIndex = 10;
            this.txtUbicacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUbicacion_KeyPress);
            // 
            // optHangTag
            // 
            this.optHangTag.AutoSize = true;
            this.optHangTag.Location = new System.Drawing.Point(336, 30);
            this.optHangTag.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optHangTag.Name = "optHangTag";
            this.optHangTag.Size = new System.Drawing.Size(117, 21);
            this.optHangTag.TabIndex = 3;
            this.optHangTag.Text = "Hang Tag [F6]";
            this.optHangTag.UseVisualStyleBackColor = true;
            this.optHangTag.CheckedChanged += new System.EventHandler(this.optHangTag_CheckedChanged);
            // 
            // optCodigo
            // 
            this.optCodigo.AutoSize = true;
            this.optCodigo.Checked = true;
            this.optCodigo.Location = new System.Drawing.Point(234, 30);
            this.optCodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optCodigo.Name = "optCodigo";
            this.optCodigo.Size = new System.Drawing.Size(101, 21);
            this.optCodigo.TabIndex = 2;
            this.optCodigo.TabStop = true;
            this.optCodigo.Text = "Código [F5]";
            this.optCodigo.UseVisualStyleBackColor = true;
            this.optCodigo.CheckedChanged += new System.EventHandler(this.optCodigo_CheckedChanged);
            // 
            // lblMoneda
            // 
            this.lblMoneda.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneda.Appearance.Options.UseFont = true;
            this.lblMoneda.Location = new System.Drawing.Point(359, 114);
            this.lblMoneda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(0, 18);
            this.lblMoneda.TabIndex = 11;
            // 
            // txtUM
            // 
            this.txtUM.Location = new System.Drawing.Point(190, 83);
            this.txtUM.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUM.Name = "txtUM";
            this.txtUM.Properties.ReadOnly = true;
            this.txtUM.Size = new System.Drawing.Size(45, 22);
            this.txtUM.TabIndex = 6;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 115);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(59, 16);
            this.labelControl7.TabIndex = 9;
            this.labelControl7.Text = "Ubicación:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(97, 83);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Properties.DisplayFormat.FormatString = "f0";
            this.txtCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCantidad.Properties.Mask.EditMask = "f0";
            this.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCantidad.Properties.MaxLength = 4;
            this.txtCantidad.Size = new System.Drawing.Size(87, 22);
            this.txtCantidad.TabIndex = 8;
            this.txtCantidad.ToolTip = "Periodo";
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 87);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(55, 16);
            this.labelControl6.TabIndex = 7;
            this.labelControl6.Text = "Cantidad:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(97, 29);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(131, 22);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(14, 33);
            this.lblPersona.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(44, 16);
            this.lblPersona.TabIndex = 0;
            this.lblPersona.Text = "Código:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(540, 139);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 59);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 16);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(97, 55);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Properties.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(399, 22);
            this.txtProducto.TabIndex = 5;
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.txtObservacion);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.btnModificarBarras);
            this.grdDatos.Controls.Add(this.btnGrabar);
            this.grdDatos.Controls.Add(this.txtUbicacion);
            this.grdDatos.Controls.Add(this.optHangTag);
            this.grdDatos.Controls.Add(this.optCodigo);
            this.grdDatos.Controls.Add(this.lblMoneda);
            this.grdDatos.Controls.Add(this.txtUM);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.txtCantidad);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.txtCodigo);
            this.grdDatos.Controls.Add(this.lblPersona);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtProducto);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(633, 186);
            this.grdDatos.TabIndex = 1;
            this.grdDatos.Text = "Datos";
            // 
            // frmRegInventarioAnaquelesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 193);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.cboTienda);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboAlmacen);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRegInventarioAnaquelesEdit";
            this.Text = "Seleccionar Producto";
            this.Load += new System.EventHandler(this.frmRegInventarioAnaquelesEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit txtObservacion;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        public DevExpress.XtraEditors.LookUpEdit cboAlmacen;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnModificarBarras;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.TextEdit txtUbicacion;
        private System.Windows.Forms.RadioButton optHangTag;
        private System.Windows.Forms.RadioButton optCodigo;
        private DevExpress.XtraEditors.LabelControl lblMoneda;
        public DevExpress.XtraEditors.TextEdit txtUM;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtProducto;
        private DevExpress.XtraEditors.GroupControl grdDatos;

    }
}