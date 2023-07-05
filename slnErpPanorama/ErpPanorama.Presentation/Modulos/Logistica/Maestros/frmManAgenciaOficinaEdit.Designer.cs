namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    partial class frmManAgenciaOficinaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManAgenciaOficinaEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.cboDepartamento = new DevExpress.XtraEditors.LookUpEdit();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.cboProvincia = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.cboDistrito = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtTelefono = new DevExpress.XtraEditors.TextEdit();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescAgencia = new DevExpress.XtraEditors.TextEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.txtDireccion = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescAgencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.cboDepartamento);
            this.grdDatos.Controls.Add(this.txtObservacion);
            this.grdDatos.Controls.Add(this.cboProvincia);
            this.grdDatos.Controls.Add(this.labelControl16);
            this.grdDatos.Controls.Add(this.cboDistrito);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.labelControl18);
            this.grdDatos.Controls.Add(this.txtTelefono);
            this.grdDatos.Controls.Add(this.labelControl19);
            this.grdDatos.Controls.Add(this.txtDescAgencia);
            this.grdDatos.Controls.Add(this.labelControl20);
            this.grdDatos.Controls.Add(this.txtDireccion);
            this.grdDatos.Controls.Add(this.lblPersona);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.btnAceptar);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(769, 223);
            this.grdDatos.TabIndex = 2;
            this.grdDatos.Text = "Datos";
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Location = new System.Drawing.Point(91, 48);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartamento.Properties.NullText = "";
            this.cboDepartamento.Size = new System.Drawing.Size(181, 20);
            this.cboDepartamento.TabIndex = 13;
            this.cboDepartamento.EditValueChanged += new System.EventHandler(this.cboDepartamento_EditValueChanged);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(91, 117);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.MaxLength = 200;
            this.txtObservacion.Size = new System.Drawing.Size(439, 57);
            this.txtObservacion.TabIndex = 25;
            // 
            // cboProvincia
            // 
            this.cboProvincia.Location = new System.Drawing.Point(331, 49);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProvincia.Properties.NullText = "";
            this.cboProvincia.Size = new System.Drawing.Size(199, 20);
            this.cboProvincia.TabIndex = 15;
            this.cboProvincia.EditValueChanged += new System.EventHandler(this.cboProvincia_EditValueChanged);
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(12, 119);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(64, 13);
            this.labelControl16.TabIndex = 24;
            this.labelControl16.Text = "Observación:";
            // 
            // cboDistrito
            // 
            this.cboDistrito.Location = new System.Drawing.Point(580, 48);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDistrito.Properties.NullText = "";
            this.cboDistrito.Size = new System.Drawing.Size(175, 20);
            this.cboDistrito.TabIndex = 17;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(13, 96);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(46, 13);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Telefono:";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(536, 51);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(38, 13);
            this.labelControl18.TabIndex = 16;
            this.labelControl18.Text = "Distrito:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(91, 93);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(181, 20);
            this.txtTelefono.TabIndex = 1;
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(279, 51);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(47, 13);
            this.labelControl19.TabIndex = 14;
            this.labelControl19.Text = "Provincia:";
            // 
            // txtDescAgencia
            // 
            this.txtDescAgencia.Location = new System.Drawing.Point(91, 25);
            this.txtDescAgencia.Name = "txtDescAgencia";
            this.txtDescAgencia.Size = new System.Drawing.Size(439, 20);
            this.txtDescAgencia.TabIndex = 1;
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(12, 51);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(73, 13);
            this.labelControl20.TabIndex = 12;
            this.labelControl20.Text = "Departamento:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(91, 70);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDireccion.Properties.MaxLength = 100;
            this.txtDireccion.Size = new System.Drawing.Size(664, 20);
            this.txtDireccion.TabIndex = 19;
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(12, 28);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(42, 13);
            this.lblPersona.TabIndex = 0;
            this.lblPersona.Text = "Agencia:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Dirección:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(680, 190);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(598, 190);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmManAgenciaOficinaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 226);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManAgenciaOficinaEdit";
            this.Text = "Mantenimiento - Agencia Oficina";
            this.Load += new System.EventHandler(this.frmManAgenciaOficinaEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTelefono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescAgencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDireccion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtDescAgencia;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        public DevExpress.XtraEditors.TextEdit txtTelefono;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        public DevExpress.XtraEditors.LookUpEdit cboDepartamento;
        public DevExpress.XtraEditors.LookUpEdit cboProvincia;
        public DevExpress.XtraEditors.LookUpEdit cboDistrito;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.TextEdit txtDireccion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}