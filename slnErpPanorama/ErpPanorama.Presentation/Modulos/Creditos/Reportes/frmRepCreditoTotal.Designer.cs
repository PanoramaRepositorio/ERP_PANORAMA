namespace ErpPanorama.Presentation.Modulos.Creditos.Reportes
{
    partial class frmRepCreditoTotal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepCreditoTotal));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.gboReporte = new System.Windows.Forms.GroupBox();
            this.optTotal = new System.Windows.Forms.RadioButton();
            this.optRazonSocial = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optDescendente = new System.Windows.Forms.RadioButton();
            this.optAscendente = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            this.gboReporte.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(146, 176);
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
            this.btnVer.Location = new System.Drawing.Point(48, 176);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 8;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.Location = new System.Drawing.Point(122, 12);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(65, 20);
            this.txtPeriodo.TabIndex = 51;
            this.txtPeriodo.ToolTip = "Periodo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(76, 15);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 13);
            this.labelControl7.TabIndex = 50;
            this.labelControl7.Text = "Periodo:";
            // 
            // gboReporte
            // 
            this.gboReporte.Controls.Add(this.optTotal);
            this.gboReporte.Controls.Add(this.optRazonSocial);
            this.gboReporte.Location = new System.Drawing.Point(12, 43);
            this.gboReporte.Name = "gboReporte";
            this.gboReporte.Size = new System.Drawing.Size(262, 48);
            this.gboReporte.TabIndex = 52;
            this.gboReporte.TabStop = false;
            this.gboReporte.Text = "Ordenado por";
            // 
            // optTotal
            // 
            this.optTotal.AutoSize = true;
            this.optTotal.Location = new System.Drawing.Point(117, 20);
            this.optTotal.Name = "optTotal";
            this.optTotal.Size = new System.Drawing.Size(82, 17);
            this.optTotal.TabIndex = 1;
            this.optTotal.Text = "Monto Total";
            this.optTotal.UseVisualStyleBackColor = true;
            // 
            // optRazonSocial
            // 
            this.optRazonSocial.AutoSize = true;
            this.optRazonSocial.Checked = true;
            this.optRazonSocial.Location = new System.Drawing.Point(6, 20);
            this.optRazonSocial.Name = "optRazonSocial";
            this.optRazonSocial.Size = new System.Drawing.Size(85, 17);
            this.optRazonSocial.TabIndex = 0;
            this.optRazonSocial.TabStop = true;
            this.optRazonSocial.Text = "Razon Social";
            this.optRazonSocial.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optDescendente);
            this.groupBox1.Controls.Add(this.optAscendente);
            this.groupBox1.Location = new System.Drawing.Point(12, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(104, 67);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Forma";
            // 
            // optDescendente
            // 
            this.optDescendente.AutoSize = true;
            this.optDescendente.Location = new System.Drawing.Point(6, 43);
            this.optDescendente.Name = "optDescendente";
            this.optDescendente.Size = new System.Drawing.Size(88, 17);
            this.optDescendente.TabIndex = 1;
            this.optDescendente.Tag = "Desc";
            this.optDescendente.Text = "Descendente";
            this.optDescendente.UseVisualStyleBackColor = true;
            // 
            // optAscendente
            // 
            this.optAscendente.AutoSize = true;
            this.optAscendente.Checked = true;
            this.optAscendente.Location = new System.Drawing.Point(6, 20);
            this.optAscendente.Name = "optAscendente";
            this.optAscendente.Size = new System.Drawing.Size(82, 17);
            this.optAscendente.TabIndex = 0;
            this.optAscendente.TabStop = true;
            this.optAscendente.Tag = "Asc";
            this.optAscendente.Text = "Ascendente";
            this.optAscendente.UseVisualStyleBackColor = true;
            // 
            // frmRepCreditoTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 212);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboReporte);
            this.Controls.Add(this.txtPeriodo);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepCreditoTotal";
            this.Text = "Reporte Crédito Total";
            this.Load += new System.EventHandler(this.frmRepCreditoTotal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            this.gboReporte.ResumeLayout(false);
            this.gboReporte.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.GroupBox gboReporte;
        private System.Windows.Forms.RadioButton optTotal;
        private System.Windows.Forms.RadioButton optRazonSocial;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optDescendente;
        private System.Windows.Forms.RadioButton optAscendente;
    }
}