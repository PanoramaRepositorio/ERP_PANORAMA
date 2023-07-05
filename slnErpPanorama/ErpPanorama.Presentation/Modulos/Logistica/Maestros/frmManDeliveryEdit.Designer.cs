namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    partial class frmManDeliveryEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManDeliveryEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.chkCallao = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.cboDistrito = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.cboProvincia = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDepartamento = new DevExpress.XtraEditors.LookUpEdit();
            this.txtTotala = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalp = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCallao.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotala.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.txtTotalp);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.txtTotala);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.btnGrabar);
            this.grdDatos.Controls.Add(this.txtDescripcion);
            this.grdDatos.Controls.Add(this.chkCallao);
            this.grdDatos.Controls.Add(this.labelControl20);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.labelControl19);
            this.grdDatos.Controls.Add(this.labelControl18);
            this.grdDatos.Controls.Add(this.txtTotal);
            this.grdDatos.Controls.Add(this.cboDistrito);
            this.grdDatos.Controls.Add(this.labelControl10);
            this.grdDatos.Controls.Add(this.cboProvincia);
            this.grdDatos.Controls.Add(this.cboDepartamento);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(498, 183);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            this.grdDatos.Paint += new System.Windows.Forms.PaintEventHandler(this.grdDatos_Paint);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 90);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Descripción:";
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(331, 153);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 11;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(95, 87);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(390, 20);
            this.txtDescripcion.TabIndex = 9;
            // 
            // chkCallao
            // 
            this.chkCallao.Location = new System.Drawing.Point(355, 112);
            this.chkCallao.Name = "chkCallao";
            this.chkCallao.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkCallao.Properties.Appearance.Options.UseFont = true;
            this.chkCallao.Properties.Caption = "Provincia y Callao";
            this.chkCallao.Size = new System.Drawing.Size(130, 20);
            this.chkCallao.TabIndex = 10;
            this.chkCallao.CheckedChanged += new System.EventHandler(this.chkCallao_CheckedChanged);
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(12, 24);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(73, 13);
            this.labelControl20.TabIndex = 0;
            this.labelControl20.Text = "Departamento:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(410, 153);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(12, 45);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(47, 13);
            this.labelControl19.TabIndex = 2;
            this.labelControl19.Text = "Provincia:";
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(12, 68);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(38, 13);
            this.labelControl18.TabIndex = 4;
            this.labelControl18.Text = "Distrito:";
            // 
            // txtTotal
            // 
            this.txtTotal.EditValue = "0.00";
            this.txtTotal.Location = new System.Drawing.Point(126, 113);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(77, 20);
            this.txtTotal.TabIndex = 7;
            // 
            // cboDistrito
            // 
            this.cboDistrito.Location = new System.Drawing.Point(95, 65);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDistrito.Properties.NullText = "";
            this.cboDistrito.Size = new System.Drawing.Size(225, 20);
            this.cboDistrito.TabIndex = 5;
            this.cboDistrito.EditValueChanged += new System.EventHandler(this.cboDistrito_EditValueChanged);
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Location = new System.Drawing.Point(17, 117);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(79, 13);
            this.labelControl10.TabIndex = 6;
            this.labelControl10.Text = "Tarifa Lima S/";
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
            this.cboProvincia.TabIndex = 3;
            this.cboProvincia.EditValueChanged += new System.EventHandler(this.cboProvincia_EditValueChanged);
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
            this.cboDepartamento.TabIndex = 1;
            this.cboDepartamento.EditValueChanged += new System.EventHandler(this.cboDepartamento_EditValueChanged);
            // 
            // txtTotala
            // 
            this.txtTotala.EditValue = "0.00";
            this.txtTotala.Location = new System.Drawing.Point(126, 134);
            this.txtTotala.Name = "txtTotala";
            this.txtTotala.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotala.Properties.Appearance.Options.UseFont = true;
            this.txtTotala.Properties.DisplayFormat.FormatString = "n";
            this.txtTotala.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotala.Properties.Mask.EditMask = "n";
            this.txtTotala.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotala.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotala.Size = new System.Drawing.Size(77, 20);
            this.txtTotala.TabIndex = 14;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(17, 138);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(100, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Tarifa Aviación S/";
            // 
            // txtTotalp
            // 
            this.txtTotalp.EditValue = "0.00";
            this.txtTotalp.Location = new System.Drawing.Point(126, 155);
            this.txtTotalp.Name = "txtTotalp";
            this.txtTotalp.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTotalp.Properties.Appearance.Options.UseFont = true;
            this.txtTotalp.Properties.DisplayFormat.FormatString = "n";
            this.txtTotalp.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalp.Properties.Mask.EditMask = "n";
            this.txtTotalp.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalp.Size = new System.Drawing.Size(77, 20);
            this.txtTotalp.TabIndex = 16;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(17, 160);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(100, 13);
            this.labelControl3.TabIndex = 15;
            this.labelControl3.Text = "Tarifa Prescott S/";
            // 
            // frmManDeliveryEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 186);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManDeliveryEdit";
            this.Load += new System.EventHandler(this.frmManDeliveryEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCallao.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotala.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        public DevExpress.XtraEditors.CheckEdit chkCallao;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        public DevExpress.XtraEditors.LookUpEdit cboDistrito;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        public DevExpress.XtraEditors.LookUpEdit cboProvincia;
        public DevExpress.XtraEditors.LookUpEdit cboDepartamento;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.TextEdit txtTotalp;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtTotala;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}