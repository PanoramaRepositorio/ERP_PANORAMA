namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Maestros
{
    partial class frmProveedorCuenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedorCuenta));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoCuenta = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCCI = new DevExpress.XtraEditors.TextEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.txtCuenta = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.cboBanco = new DevExpress.XtraEditors.LookUpEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCCI.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBanco.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cboTipoCuenta);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtCCI);
            this.groupControl1.Controls.Add(this.labelControl22);
            this.groupControl1.Controls.Add(this.txtCuenta);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.cboMoneda);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.cboBanco);
            this.groupControl1.Location = new System.Drawing.Point(2, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(336, 142);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Cuentas";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 73);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(62, 13);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Tipo Cuenta:";
            // 
            // cboTipoCuenta
            // 
            this.cboTipoCuenta.Location = new System.Drawing.Point(75, 69);
            this.cboTipoCuenta.Name = "cboTipoCuenta";
            this.cboTipoCuenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoCuenta.Properties.DropDownRows = 12;
            this.cboTipoCuenta.Size = new System.Drawing.Size(239, 20);
            this.cboTipoCuenta.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 121);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "CCI:";
            // 
            // txtCCI
            // 
            this.txtCCI.Location = new System.Drawing.Point(75, 118);
            this.txtCCI.Name = "txtCCI";
            this.txtCCI.Properties.MaxLength = 35;
            this.txtCCI.Size = new System.Drawing.Size(239, 20);
            this.txtCCI.TabIndex = 4;
            this.txtCCI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCCI_KeyPress);
            // 
            // labelControl22
            // 
            this.labelControl22.Location = new System.Drawing.Point(19, 99);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(39, 13);
            this.labelControl22.TabIndex = 32;
            this.labelControl22.Text = "Cuenta:";
            // 
            // txtCuenta
            // 
            this.txtCuenta.Location = new System.Drawing.Point(75, 96);
            this.txtCuenta.Name = "txtCuenta";
            this.txtCuenta.Properties.MaxLength = 35;
            this.txtCuenta.Size = new System.Drawing.Size(239, 20);
            this.txtCuenta.TabIndex = 3;
            this.txtCuenta.TextChanged += new System.EventHandler(this.txtCuenta_TextChanged);
            this.txtCuenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuenta_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "Moneda:";
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(75, 47);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Size = new System.Drawing.Size(99, 20);
            this.cboMoneda.TabIndex = 1;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(9, 30);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(33, 13);
            this.labelControl11.TabIndex = 29;
            this.labelControl11.Text = "Banco:";
            // 
            // cboBanco
            // 
            this.cboBanco.Location = new System.Drawing.Point(75, 26);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBanco.Properties.DropDownRows = 12;
            this.cboBanco.Size = new System.Drawing.Size(239, 20);
            this.cboBanco.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancelar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.btn_salir;
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(176, 156);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 22);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(95, 156);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(79, 22);
            this.btnGrabar.TabIndex = 0;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(69, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "(Ingrese las cuentas Sin guiones Ni espacios)";
            // 
            // frmProveedorCuenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 179);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProveedorCuenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cuentas proveedor";
            this.Load += new System.EventHandler(this.frmProveedorCuenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCCI.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBanco.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtCCI;
        public DevExpress.XtraEditors.TextEdit txtCuenta;
        private DevExpress.XtraEditors.LookUpEdit cboBanco;
        private DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.LookUpEdit cboTipoCuenta;
        private System.Windows.Forms.Label label1;
    }
}