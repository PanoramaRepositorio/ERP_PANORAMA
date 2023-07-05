namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    partial class frmManPersonaCuentaBancariaEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManPersonaCuentaBancariaEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtObservacion = new DevExpress.XtraEditors.TextEdit();
            this.cboTipoCuenta = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboBanco = new DevExpress.XtraEditors.LookUpEdit();
            this.lblEmpresa = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroCuenta = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.chkdefault = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBanco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroCuenta.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.chkdefault);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.txtObservacion);
            this.grdDatos.Controls.Add(this.cboTipoCuenta);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.cboMoneda);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.cboBanco);
            this.grdDatos.Controls.Add(this.lblEmpresa);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtNumeroCuenta);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.btnAceptar);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(570, 140);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 73);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Observación:";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(83, 70);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Size = new System.Drawing.Size(470, 20);
            this.txtObservacion.TabIndex = 9;
            this.txtObservacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtObservacion_KeyPress);
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.Location = new System.Drawing.Point(83, 46);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoCuenta.Properties.NullText = "";
            this.cboTipoCuenta.Size = new System.Drawing.Size(147, 20);
            this.cboTipoCuenta.TabIndex = 5;
            this.cboTipoCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboTipoCuenta_KeyPress);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 49);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(62, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Tipo Cuenta:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(308, 24);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.NullText = "";
            this.cboMoneda.Size = new System.Drawing.Size(147, 20);
            this.cboMoneda.TabIndex = 3;
            this.cboMoneda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMoneda_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(237, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Moneda:";
            // 
            // cboBanco
            // 
            this.cboBanco.Location = new System.Drawing.Point(83, 24);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBanco.Properties.NullText = "";
            this.cboBanco.Size = new System.Drawing.Size(147, 20);
            this.cboBanco.TabIndex = 1;
            this.cboBanco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboBanco_KeyPress);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Location = new System.Drawing.Point(12, 27);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(33, 13);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Banco:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(248, 49);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "N° Cuenta:";
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(308, 46);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNumeroCuenta.Size = new System.Drawing.Size(245, 20);
            this.txtNumeroCuenta.TabIndex = 7;
            this.txtNumeroCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroCuenta_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(478, 106);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageOptions.ImageIndex = 1;
            this.btnAceptar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(397, 106);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // chkdefault
            // 
            this.chkdefault.AutoSize = true;
            this.chkdefault.Location = new System.Drawing.Point(84, 95);
            this.chkdefault.Name = "chkdefault";
            this.chkdefault.Size = new System.Drawing.Size(152, 17);
            this.chkdefault.TabIndex = 12;
            this.chkdefault.Text = "Activar cuenta por default";
            this.chkdefault.UseVisualStyleBackColor = true;
            // 
            // frmManPersonaCuentaBancariaEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 136);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManPersonaCuentaBancariaEdit";
            this.Load += new System.EventHandler(this.frmManPersonaCuentaBancaria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBanco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroCuenta.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtObservacion;
        public DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LookUpEdit cboBanco;
        private DevExpress.XtraEditors.LabelControl lblEmpresa;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        public DevExpress.XtraEditors.LookUpEdit cboTipoCuenta;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtNumeroCuenta;
        private System.Windows.Forms.CheckBox chkdefault;
    }
}