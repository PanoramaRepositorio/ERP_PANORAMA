namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmAsociarCodigo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsociarCodigo));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.optHangTag = new System.Windows.Forms.RadioButton();
            this.optCodigo = new System.Windows.Forms.RadioButton();
            this.lblMoneda = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtProducto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtUbicacion = new DevExpress.XtraEditors.TextEdit();
            this.txtUM = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtUM2 = new DevExpress.XtraEditors.TextEdit();
            this.txtUbicacion2 = new DevExpress.XtraEditors.TextEdit();
            this.optHangTag2 = new System.Windows.Forms.RadioButton();
            this.optCodigo2 = new System.Windows.Forms.RadioButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtProducto2 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.txtUM);
            this.grdDatos.Controls.Add(this.txtUbicacion);
            this.grdDatos.Controls.Add(this.optHangTag);
            this.grdDatos.Controls.Add(this.optCodigo);
            this.grdDatos.Controls.Add(this.lblMoneda);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.txtCodigo);
            this.grdDatos.Controls.Add(this.lblPersona);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtProducto);
            this.grdDatos.Location = new System.Drawing.Point(12, 31);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(624, 91);
            this.grdDatos.TabIndex = 2;
            this.grdDatos.Text = "Datos";
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(448, 276);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(107, 36);
            this.btnGrabar.TabIndex = 5;
            this.btnGrabar.Text = "Aplicar Cambios";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // optHangTag
            // 
            this.optHangTag.AutoSize = true;
            this.optHangTag.Location = new System.Drawing.Point(484, 23);
            this.optHangTag.Name = "optHangTag";
            this.optHangTag.Size = new System.Drawing.Size(94, 17);
            this.optHangTag.TabIndex = 3;
            this.optHangTag.Text = "Hang Tag [F6]";
            this.optHangTag.UseVisualStyleBackColor = true;
            // 
            // optCodigo
            // 
            this.optCodigo.AutoSize = true;
            this.optCodigo.Checked = true;
            this.optCodigo.Location = new System.Drawing.Point(397, 23);
            this.optCodigo.Name = "optCodigo";
            this.optCodigo.Size = new System.Drawing.Size(81, 17);
            this.optCodigo.TabIndex = 2;
            this.optCodigo.TabStop = true;
            this.optCodigo.Text = "Código [F5]";
            this.optCodigo.UseVisualStyleBackColor = true;
            // 
            // lblMoneda
            // 
            this.lblMoneda.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneda.Appearance.Options.UseFont = true;
            this.lblMoneda.Location = new System.Drawing.Point(308, 93);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(0, 14);
            this.lblMoneda.TabIndex = 9;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(83, 24);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(282, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyDown);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(12, 27);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(37, 13);
            this.lblPersona.TabIndex = 0;
            this.lblPersona.Text = "Código:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(561, 276);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 36);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(47, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Producto:";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(83, 45);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Properties.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(536, 20);
            this.txtProducto.TabIndex = 5;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 69);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 6;
            this.labelControl7.Text = "Ubicación:";
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(83, 66);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUbicacion.Properties.Appearance.Options.UseBackColor = true;
            this.txtUbicacion.Properties.ReadOnly = true;
            this.txtUbicacion.Size = new System.Drawing.Size(237, 20);
            this.txtUbicacion.TabIndex = 7;
            // 
            // txtUM
            // 
            this.txtUM.Location = new System.Drawing.Point(326, 66);
            this.txtUM.Name = "txtUM";
            this.txtUM.Properties.ReadOnly = true;
            this.txtUM.Size = new System.Drawing.Size(39, 20);
            this.txtUM.TabIndex = 8;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(219, 142);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(152, 13);
            this.labelControl6.TabIndex = 3;
            this.labelControl6.Text = "CODIGO QUE SE ELIMINARÁ";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(219, 12);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(154, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "CODIGO QUE PERMANECERÁ";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtUM2);
            this.groupControl1.Controls.Add(this.txtUbicacion2);
            this.groupControl1.Controls.Add(this.optHangTag2);
            this.groupControl1.Controls.Add(this.optCodigo2);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtCodigo2);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtProducto2);
            this.groupControl1.Location = new System.Drawing.Point(12, 161);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(624, 91);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Datos";
            // 
            // txtUM2
            // 
            this.txtUM2.Location = new System.Drawing.Point(326, 66);
            this.txtUM2.Name = "txtUM2";
            this.txtUM2.Properties.ReadOnly = true;
            this.txtUM2.Size = new System.Drawing.Size(39, 20);
            this.txtUM2.TabIndex = 8;
            // 
            // txtUbicacion2
            // 
            this.txtUbicacion2.Location = new System.Drawing.Point(83, 66);
            this.txtUbicacion2.Name = "txtUbicacion2";
            this.txtUbicacion2.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUbicacion2.Properties.Appearance.Options.UseBackColor = true;
            this.txtUbicacion2.Properties.ReadOnly = true;
            this.txtUbicacion2.Size = new System.Drawing.Size(237, 20);
            this.txtUbicacion2.TabIndex = 7;
            // 
            // optHangTag2
            // 
            this.optHangTag2.AutoSize = true;
            this.optHangTag2.Location = new System.Drawing.Point(484, 23);
            this.optHangTag2.Name = "optHangTag2";
            this.optHangTag2.Size = new System.Drawing.Size(71, 17);
            this.optHangTag2.TabIndex = 3;
            this.optHangTag2.Text = "Hang Tag";
            this.optHangTag2.UseVisualStyleBackColor = true;
            // 
            // optCodigo2
            // 
            this.optCodigo2.AutoSize = true;
            this.optCodigo2.Checked = true;
            this.optCodigo2.Location = new System.Drawing.Point(397, 23);
            this.optCodigo2.Name = "optCodigo2";
            this.optCodigo2.Size = new System.Drawing.Size(58, 17);
            this.optCodigo2.TabIndex = 2;
            this.optCodigo2.TabStop = true;
            this.optCodigo2.Text = "Código";
            this.optCodigo2.UseVisualStyleBackColor = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(308, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(0, 14);
            this.labelControl2.TabIndex = 9;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(49, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Ubicación:";
            // 
            // txtCodigo2
            // 
            this.txtCodigo2.Location = new System.Drawing.Point(83, 24);
            this.txtCodigo2.Name = "txtCodigo2";
            this.txtCodigo2.Size = new System.Drawing.Size(282, 20);
            this.txtCodigo2.TabIndex = 1;
            this.txtCodigo2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodigo2_KeyDown);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 27);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(37, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Código:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 48);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(47, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Producto:";
            // 
            // txtProducto2
            // 
            this.txtProducto2.Location = new System.Drawing.Point(83, 45);
            this.txtProducto2.Name = "txtProducto2";
            this.txtProducto2.Properties.ReadOnly = true;
            this.txtProducto2.Size = new System.Drawing.Size(536, 20);
            this.txtProducto2.TabIndex = 5;
            // 
            // frmAsociarCodigo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 320);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAsociarCodigo";
            this.Text = "Asociar Código";
            this.Load += new System.EventHandler(this.frmAsociarCodigo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUM2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUbicacion2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProducto2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private System.Windows.Forms.RadioButton optHangTag;
        private System.Windows.Forms.RadioButton optCodigo;
        private DevExpress.XtraEditors.LabelControl lblMoneda;
        public DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtProducto;
        public DevExpress.XtraEditors.TextEdit txtUbicacion;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit txtUM;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        public DevExpress.XtraEditors.TextEdit txtUM2;
        public DevExpress.XtraEditors.TextEdit txtUbicacion2;
        private System.Windows.Forms.RadioButton optHangTag2;
        private System.Windows.Forms.RadioButton optCodigo2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtCodigo2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.TextEdit txtProducto2;
    }
}