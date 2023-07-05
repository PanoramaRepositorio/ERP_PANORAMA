namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    partial class frmRegCajaEgresoAdd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegCajaEgresoAdd));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.txtNombres = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldoInicial = new DevExpress.XtraEditors.TextEdit();
            this.deHasta = new DevExpress.XtraEditors.DateEdit();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.bsListado = new System.Windows.Forms.BindingSource(this.components);
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNroRecibo = new DevExpress.XtraEditors.TextEdit();
            this.deFechaRecibo = new DevExpress.XtraEditors.DateEdit();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoInicial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroRecibo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaRecibo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaRecibo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.deFechaRecibo);
            this.grdDatos.Controls.Add(this.label6);
            this.grdDatos.Controls.Add(this.txtNroRecibo);
            this.grdDatos.Controls.Add(this.label5);
            this.grdDatos.Controls.Add(this.txtNombres);
            this.grdDatos.Controls.Add(this.label4);
            this.grdDatos.Controls.Add(this.pictureBox3);
            this.grdDatos.Controls.Add(this.pictureBox2);
            this.grdDatos.Controls.Add(this.pictureBox1);
            this.grdDatos.Controls.Add(this.label3);
            this.grdDatos.Controls.Add(this.txtSaldoInicial);
            this.grdDatos.Controls.Add(this.deHasta);
            this.grdDatos.Controls.Add(this.cboEmpresa);
            this.grdDatos.Controls.Add(this.label2);
            this.grdDatos.Controls.Add(this.label1);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(498, 137);
            this.grdDatos.TabIndex = 3;
            this.grdDatos.Text = "Datos de Operación";
            // 
            // txtNombres
            // 
            this.txtNombres.EditValue = "";
            this.txtNombres.Location = new System.Drawing.Point(97, 23);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Properties.EditFormat.FormatString = "#,0.00";
            this.txtNombres.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNombres.Properties.Mask.EditMask = "n2";
            this.txtNombres.Properties.MaxLength = 30;
            this.txtNombres.Properties.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(362, 20);
            this.txtNombres.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 122;
            this.label4.Text = "Nombres:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ErpPanorama.Presentation.Properties.Resources.TopeEmpresa_32x321;
            this.pictureBox3.Location = new System.Drawing.Point(248, 115);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(18, 17);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 121;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ErpPanorama.Presentation.Properties.Resources.Periodo1;
            this.pictureBox2.Location = new System.Drawing.Point(248, 93);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 17);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 120;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ErpPanorama.Presentation.Properties.Resources.Tienda_32x321;
            this.pictureBox1.Location = new System.Drawing.Point(465, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 19);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 119;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Saldo Inicial:";
            // 
            // txtSaldoInicial
            // 
            this.txtSaldoInicial.EditValue = "0.00";
            this.txtSaldoInicial.Location = new System.Drawing.Point(97, 112);
            this.txtSaldoInicial.Name = "txtSaldoInicial";
            this.txtSaldoInicial.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtSaldoInicial.Properties.Appearance.Options.UseFont = true;
            this.txtSaldoInicial.Properties.EditFormat.FormatString = "#,0.00";
            this.txtSaldoInicial.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSaldoInicial.Properties.Mask.EditMask = "n2";
            this.txtSaldoInicial.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSaldoInicial.Properties.MaxLength = 30;
            this.txtSaldoInicial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSaldoInicial.Size = new System.Drawing.Size(147, 20);
            this.txtSaldoInicial.TabIndex = 5;
            // 
            // deHasta
            // 
            this.deHasta.EditValue = null;
            this.deHasta.Location = new System.Drawing.Point(97, 91);
            this.deHasta.Name = "deHasta";
            this.deHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deHasta.Size = new System.Drawing.Size(147, 20);
            this.deHasta.TabIndex = 4;
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(97, 44);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.DropDownRows = 5;
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(362, 20);
            this.cboEmpresa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Fecha Apertura:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Empresa:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(164, 141);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 21);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(259, 141);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(91, 21);
            this.simpleButton2.TabIndex = 29;
            this.simpleButton2.Text = "&Cancelar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(12, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "Nro. Recibo:";
            // 
            // txtNroRecibo
            // 
            this.txtNroRecibo.Location = new System.Drawing.Point(97, 65);
            this.txtNroRecibo.Name = "txtNroRecibo";
            this.txtNroRecibo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtNroRecibo.Properties.Appearance.Options.UseFont = true;
            this.txtNroRecibo.Properties.MaxLength = 120;
            this.txtNroRecibo.Size = new System.Drawing.Size(127, 20);
            this.txtNroRecibo.TabIndex = 2;
            // 
            // deFechaRecibo
            // 
            this.deFechaRecibo.EditValue = null;
            this.deFechaRecibo.Location = new System.Drawing.Point(312, 65);
            this.deFechaRecibo.Name = "deFechaRecibo";
            this.deFechaRecibo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaRecibo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaRecibo.Size = new System.Drawing.Size(146, 20);
            this.deFechaRecibo.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label6.Location = new System.Drawing.Point(235, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 133;
            this.label6.Text = "Fecha Recibo:";
            // 
            // frmRegCajaEgresoAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 166);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnGuardar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegCajaEgresoAdd";
            this.Text = "Registra Apertura de Caja";
            this.Load += new System.EventHandler(this.frmRegCajaEgresoAdd_Load);
            this.Shown += new System.EventHandler(this.frmRegPrestamoBancoEdit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaldoInicial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNroRecibo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaRecibo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaRecibo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private System.Windows.Forms.BindingSource bsListado;
        private DevExpress.XtraEditors.DateEdit deHasta;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.TextEdit txtSaldoInicial;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtNombres;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.DateEdit deFechaRecibo;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtNroRecibo;
    }
}