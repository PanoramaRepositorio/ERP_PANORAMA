namespace ErpPanorama.Presentation.Modulos.Creditos.Reportes
{
    partial class frmRepEstadoCuentaNumeroDias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepEstadoCuentaNumeroDias));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboDias = new System.Windows.Forms.ComboBox();
            this.chkClasifica = new System.Windows.Forms.CheckBox();
            this.cboClasificacion = new DevExpress.XtraEditors.LookUpEdit();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasificacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(199, 93);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageIndex = 1;
            this.btnVer.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(101, 93);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 8;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(56, 12);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(65, 20);
            this.txtPeriodo.TabIndex = 49;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(10, 15);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 48;
            this.labelControl7.Text = "Periodo:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 63);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 13);
            this.labelControl4.TabIndex = 50;
            this.labelControl4.Text = "Días:";
            // 
            // cboDias
            // 
            this.cboDias.FormattingEnabled = true;
            this.cboDias.Items.AddRange(new object[] {
            "30",
            "45",
            "60",
            "Todo"});
            this.cboDias.Location = new System.Drawing.Point(56, 60);
            this.cboDias.Name = "cboDias";
            this.cboDias.Size = new System.Drawing.Size(121, 21);
            this.cboDias.TabIndex = 51;
            // 
            // chkClasifica
            // 
            this.chkClasifica.AutoSize = true;
            this.chkClasifica.Location = new System.Drawing.Point(358, 15);
            this.chkClasifica.Name = "chkClasifica";
            this.chkClasifica.Size = new System.Drawing.Size(88, 17);
            this.chkClasifica.TabIndex = 52;
            this.chkClasifica.Text = "Clasificación:";
            this.chkClasifica.UseVisualStyleBackColor = true;
            this.chkClasifica.CheckedChanged += new System.EventHandler(this.chkClasifica_CheckedChanged);
            // 
            // cboClasificacion
            // 
            this.cboClasificacion.Enabled = false;
            this.cboClasificacion.Location = new System.Drawing.Point(454, 12);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClasificacion.Properties.NullText = "";
            this.cboClasificacion.Size = new System.Drawing.Size(100, 20);
            this.cboClasificacion.TabIndex = 53;
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(56, 36);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Properties.NullText = "";
            this.cboMotivo.Size = new System.Drawing.Size(121, 20);
            this.cboMotivo.TabIndex = 55;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 39);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 54;
            this.labelControl1.Text = "Motivo:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(127, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(209, 21);
            this.dateTimePicker1.TabIndex = 56;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // frmRepEstadoCuentaNumeroDias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 149);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.cboMotivo);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboClasificacion);
            this.Controls.Add(this.chkClasifica);
            this.Controls.Add(this.cboDias);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepEstadoCuentaNumeroDias";
            this.Text = "Reporte Créditos x Días";
            this.Load += new System.EventHandler(this.frmRepEstadoCuentaNumeroDias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasificacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox cboDias;
        private System.Windows.Forms.CheckBox chkClasifica;
        public DevExpress.XtraEditors.LookUpEdit cboClasificacion;
        public DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}