namespace ErpPanorama.Presentation.Modulos.Ecommerce
{
    partial class frmDeliveryTarifaWeb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeliveryTarifaWeb));
            this.cboDepartamento = new DevExpress.XtraEditors.LookUpEdit();
            this.cboProvincia = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDistrito = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.chkCallao = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCallao.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Enabled = false;
            this.cboDepartamento.Location = new System.Drawing.Point(95, 21);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartamento.Properties.NullText = "";
            this.cboDepartamento.Size = new System.Drawing.Size(225, 20);
            this.cboDepartamento.TabIndex = 7;
            this.cboDepartamento.EditValueChanged += new System.EventHandler(this.cboDepartamento_EditValueChanged);
            // 
            // cboProvincia
            // 
            this.cboProvincia.Enabled = false;
            this.cboProvincia.Location = new System.Drawing.Point(95, 43);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProvincia.Properties.NullText = "";
            this.cboProvincia.Size = new System.Drawing.Size(225, 20);
            this.cboProvincia.TabIndex = 9;
            this.cboProvincia.EditValueChanged += new System.EventHandler(this.cboProvincia_EditValueChanged);
            // 
            // cboDistrito
            // 
            this.cboDistrito.Location = new System.Drawing.Point(95, 65);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDistrito.Properties.NullText = "";
            this.cboDistrito.Size = new System.Drawing.Size(225, 20);
            this.cboDistrito.TabIndex = 11;
            this.cboDistrito.EditValueChanged += new System.EventHandler(this.cboDistrito_EditValueChanged);
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(12, 68);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(38, 13);
            this.labelControl18.TabIndex = 10;
            this.labelControl18.Text = "Distrito:";
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(12, 45);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(47, 13);
            this.labelControl19.TabIndex = 8;
            this.labelControl19.Text = "Provincia:";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(12, 24);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(73, 13);
            this.labelControl20.TabIndex = 6;
            this.labelControl20.Text = "Departamento:";
            // 
            // txtTotal
            // 
            this.txtTotal.EditValue = "0.00";
            this.txtTotal.Location = new System.Drawing.Point(408, 65);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.ReadOnly = true;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(77, 20);
            this.txtTotal.TabIndex = 41;
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(350, 68);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(49, 13);
            this.labelControl10.TabIndex = 40;
            this.labelControl10.Text = "Tarifa S/";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(410, 106);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 43;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageOptions.ImageIndex = 1;
            this.btnAceptar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(329, 106);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 42;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.chkCallao);
            this.grdDatos.Controls.Add(this.labelControl20);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.labelControl19);
            this.grdDatos.Controls.Add(this.btnAceptar);
            this.grdDatos.Controls.Add(this.labelControl18);
            this.grdDatos.Controls.Add(this.txtTotal);
            this.grdDatos.Controls.Add(this.cboDistrito);
            this.grdDatos.Controls.Add(this.labelControl10);
            this.grdDatos.Controls.Add(this.cboProvincia);
            this.grdDatos.Controls.Add(this.cboDepartamento);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(499, 142);
            this.grdDatos.TabIndex = 44;
            this.grdDatos.Text = "Ubicación";
            // 
            // chkCallao
            // 
            this.chkCallao.Enabled = false;
            this.chkCallao.Location = new System.Drawing.Point(12, 103);
            this.chkCallao.Name = "chkCallao";
            this.chkCallao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkCallao.Properties.Appearance.Options.UseFont = true;
            this.chkCallao.Properties.Caption = "Provincia y Callao";
            this.chkCallao.Size = new System.Drawing.Size(130, 20);
            this.chkCallao.TabIndex = 44;
            this.chkCallao.CheckedChanged += new System.EventHandler(this.chkCallao_CheckedChanged);
            // 
            // frmDeliveryTarifaWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 135);
            this.Controls.Add(this.grdDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDeliveryTarifaWeb";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Delivery - Tarifa Web";
            this.Load += new System.EventHandler(this.frmDeliveryTarifaWeb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkCallao.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit cboDepartamento;
        public DevExpress.XtraEditors.LookUpEdit cboProvincia;
        public DevExpress.XtraEditors.LookUpEdit cboDistrito;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        public DevExpress.XtraEditors.CheckEdit chkCallao;
    }
}