namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManMetasComisionEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManMetasComisionEdit));
            this.txtMinimo = new DevExpress.XtraEditors.TextEdit();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.txtBono = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaximo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboCargo = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBono.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaximo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCargo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMinimo
            // 
            this.txtMinimo.EditValue = "0.00";
            this.txtMinimo.Location = new System.Drawing.Point(66, 73);
            this.txtMinimo.Name = "txtMinimo";
            this.txtMinimo.Properties.DisplayFormat.FormatString = "n";
            this.txtMinimo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMinimo.Properties.Mask.EditMask = "n";
            this.txtMinimo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMinimo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMinimo.Size = new System.Drawing.Size(84, 20);
            this.txtMinimo.TabIndex = 2;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.txtBono);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.txtMaximo);
            this.groupControl3.Controls.Add(this.labelControl4);
            this.groupControl3.Controls.Add(this.txtMinimo);
            this.groupControl3.Controls.Add(this.cboCargo);
            this.groupControl3.Controls.Add(this.cboTienda);
            this.groupControl3.Controls.Add(this.labelControl2);
            this.groupControl3.Controls.Add(this.labelControl3);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(0, 0);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(410, 127);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Datos";
            // 
            // txtBono
            // 
            this.txtBono.EditValue = "0.00";
            this.txtBono.Location = new System.Drawing.Point(66, 97);
            this.txtBono.Name = "txtBono";
            this.txtBono.Properties.DisplayFormat.FormatString = "n";
            this.txtBono.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtBono.Properties.Mask.EditMask = "n";
            this.txtBono.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBono.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBono.Size = new System.Drawing.Size(84, 20);
            this.txtBono.TabIndex = 4;
            this.txtBono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBono_KeyPress);
            this.txtBono.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBono_KeyUp);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(13, 100);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(28, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Bono:";
            // 
            // txtMaximo
            // 
            this.txtMaximo.EditValue = "0.00";
            this.txtMaximo.Location = new System.Drawing.Point(214, 75);
            this.txtMaximo.Name = "txtMaximo";
            this.txtMaximo.Properties.DisplayFormat.FormatString = "n";
            this.txtMaximo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMaximo.Properties.Mask.EditMask = "n";
            this.txtMaximo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMaximo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMaximo.Size = new System.Drawing.Size(84, 20);
            this.txtMaximo.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(168, 78);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Maximo:";
            // 
            // cboCargo
            // 
            this.cboCargo.Location = new System.Drawing.Point(66, 48);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCargo.Properties.NullText = "";
            this.cboCargo.Size = new System.Drawing.Size(299, 20);
            this.cboCargo.TabIndex = 1;
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(66, 25);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(299, 20);
            this.cboTienda.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 30);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Tienda:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(33, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Cargo:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 76);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Minimo:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(322, 133);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(241, 133);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 0;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManMetasComisionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 170);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManMetasComisionEdit";
            this.Load += new System.EventHandler(this.frmManMetasComisionEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMinimo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBono.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaximo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCargo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.TextEdit txtMinimo;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        public DevExpress.XtraEditors.LookUpEdit cboCargo;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.TextEdit txtBono;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        public DevExpress.XtraEditors.TextEdit txtMaximo;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}