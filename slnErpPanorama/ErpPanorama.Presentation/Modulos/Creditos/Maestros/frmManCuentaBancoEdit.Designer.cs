namespace ErpPanorama.Presentation.Modulos.Creditos.Maestros
{
    partial class frmManCuentaBancoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManCuentaBancoEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.txtSaldo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtCCI = new DevExpress.XtraEditors.TextEdit();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtOficina = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtTitular = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoCuenta = new DevExpress.XtraEditors.LookUpEdit();
            this.cboBanco = new DevExpress.XtraEditors.LookUpEdit();
            this.txtNumeroCuenta = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtLineaCredito = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCCI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOficina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitular.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBanco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineaCredito.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(399, 211);
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
            this.btnGrabar.Location = new System.Drawing.Point(318, 211);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl8);
            this.grdDatos.Controls.Add(this.txtLineaCredito);
            this.grdDatos.Controls.Add(this.txtSaldo);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.txtCCI);
            this.grdDatos.Controls.Add(this.cboMoneda);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtOficina);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.txtTitular);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.cboTipoCuenta);
            this.grdDatos.Controls.Add(this.cboBanco);
            this.grdDatos.Controls.Add(this.txtNumeroCuenta);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.lblDescripcion);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(479, 205);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // txtSaldo
            // 
            this.txtSaldo.EditValue = "0";
            this.txtSaldo.Location = new System.Drawing.Point(405, 137);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.Properties.MaxLength = 50;
            this.txtSaldo.Properties.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(69, 20);
            this.txtSaldo.TabIndex = 15;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(337, 140);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(65, 13);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "S. Disponible:";
            // 
            // txtCCI
            // 
            this.txtCCI.Location = new System.Drawing.Point(97, 137);
            this.txtCCI.Name = "txtCCI";
            this.txtCCI.Properties.MaxLength = 50;
            this.txtCCI.Size = new System.Drawing.Size(234, 20);
            this.txtCCI.TabIndex = 13;
            this.txtCCI.ToolTip = "Código de cuenta interbancaria";
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(301, 49);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.NullText = "";
            this.cboMoneda.Size = new System.Drawing.Size(173, 20);
            this.cboMoneda.TabIndex = 5;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 140);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(22, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "CCI:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(253, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Moneda:";
            // 
            // txtOficina
            // 
            this.txtOficina.Location = new System.Drawing.Point(97, 114);
            this.txtOficina.Name = "txtOficina";
            this.txtOficina.Properties.MaxLength = 50;
            this.txtOficina.Size = new System.Drawing.Size(377, 20);
            this.txtOficina.TabIndex = 11;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 117);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(37, 13);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Oficina:";
            // 
            // txtTitular
            // 
            this.txtTitular.Location = new System.Drawing.Point(97, 92);
            this.txtTitular.Name = "txtTitular";
            this.txtTitular.Properties.MaxLength = 50;
            this.txtTitular.Size = new System.Drawing.Size(377, 20);
            this.txtTitular.TabIndex = 9;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 95);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Titular:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 52);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(62, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Tipo Cuenta:";
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.Location = new System.Drawing.Point(97, 49);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoCuenta.Properties.NullText = "";
            this.cboTipoCuenta.Size = new System.Drawing.Size(150, 20);
            this.cboTipoCuenta.TabIndex = 3;
            // 
            // cboBanco
            // 
            this.cboBanco.Location = new System.Drawing.Point(97, 28);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBanco.Properties.NullText = "";
            this.cboBanco.Size = new System.Drawing.Size(377, 20);
            this.cboBanco.TabIndex = 1;
            // 
            // txtNumeroCuenta
            // 
            this.txtNumeroCuenta.Location = new System.Drawing.Point(97, 70);
            this.txtNumeroCuenta.Name = "txtNumeroCuenta";
            this.txtNumeroCuenta.Properties.MaxLength = 50;
            this.txtNumeroCuenta.Size = new System.Drawing.Size(377, 20);
            this.txtNumeroCuenta.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Numero Cuenta:";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(12, 31);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(33, 13);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Banco:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 163);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(67, 13);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "Línea Crédito:";
            // 
            // txtLineaCredito
            // 
            this.txtLineaCredito.EditValue = "0.00";
            this.txtLineaCredito.Location = new System.Drawing.Point(97, 160);
            this.txtLineaCredito.Name = "txtLineaCredito";
            this.txtLineaCredito.Properties.DisplayFormat.FormatString = "n";
            this.txtLineaCredito.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLineaCredito.Properties.Mask.EditMask = "n";
            this.txtLineaCredito.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLineaCredito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLineaCredito.Size = new System.Drawing.Size(150, 20);
            this.txtLineaCredito.TabIndex = 17;
            // 
            // frmManCuentaBancoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 246);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManCuentaBancoEdit";
            this.Load += new System.EventHandler(this.frmManCuentaBancoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCCI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOficina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitular.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBanco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineaCredito.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtNumeroCuenta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.LookUpEdit cboMoneda;
        public DevExpress.XtraEditors.LookUpEdit cboBanco;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboTipoCuenta;
        private DevExpress.XtraEditors.TextEdit txtCCI;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtOficina;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtTitular;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSaldo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        public DevExpress.XtraEditors.TextEdit txtLineaCredito;
    }
}