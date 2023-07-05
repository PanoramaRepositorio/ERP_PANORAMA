namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepPedidoRutaMes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepPedidoRutaMes));
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.optMes = new System.Windows.Forms.RadioButton();
            this.optSemana = new System.Windows.Forms.RadioButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.optDia = new System.Windows.Forms.RadioButton();
            this.cboTipoBus = new DevExpress.XtraEditors.LookUpEdit();
            this.optAnio = new System.Windows.Forms.RadioButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoBus.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(99, 50);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 9;
            this.deFechaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaHasta_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 53);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Fecha Hasta: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(99, 28);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 7;
            this.deFechaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaDesde_KeyPress);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(26, 31);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(167, 163);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageIndex = 1;
            this.btnVer.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(69, 163);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 10;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // optMes
            // 
            this.optMes.AutoSize = true;
            this.optMes.Checked = true;
            this.optMes.Location = new System.Drawing.Point(26, 95);
            this.optMes.Name = "optMes";
            this.optMes.Size = new System.Drawing.Size(44, 17);
            this.optMes.TabIndex = 24;
            this.optMes.TabStop = true;
            this.optMes.Text = "Mes";
            this.optMes.UseVisualStyleBackColor = true;
            // 
            // optSemana
            // 
            this.optSemana.AutoSize = true;
            this.optSemana.Location = new System.Drawing.Point(26, 118);
            this.optSemana.Name = "optSemana";
            this.optSemana.Size = new System.Drawing.Size(63, 17);
            this.optSemana.TabIndex = 25;
            this.optSemana.Text = "Semana";
            this.optSemana.UseVisualStyleBackColor = true;
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.optDia);
            this.grdDatos.Controls.Add(this.cboTipoBus);
            this.grdDatos.Controls.Add(this.optAnio);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.optMes);
            this.grdDatos.Controls.Add(this.deFechaHasta);
            this.grdDatos.Controls.Add(this.optSemana);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.deFechaDesde);
            this.grdDatos.Controls.Add(this.lblFecha);
            this.grdDatos.Controls.Add(this.btnVer);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(275, 200);
            this.grdDatos.TabIndex = 17;
            this.grdDatos.Text = "Datos";
            // 
            // optDia
            // 
            this.optDia.AutoSize = true;
            this.optDia.Location = new System.Drawing.Point(26, 141);
            this.optDia.Name = "optDia";
            this.optDia.Size = new System.Drawing.Size(40, 17);
            this.optDia.TabIndex = 26;
            this.optDia.Text = "Dia";
            this.optDia.UseVisualStyleBackColor = true;
            // 
            // cboTipoBus
            // 
            this.cboTipoBus.Location = new System.Drawing.Point(295, 50);
            this.cboTipoBus.Name = "cboTipoBus";
            this.cboTipoBus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoBus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Dia", "Dia"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Semana", "Semana"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Mes", "Mes"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Anio", "Anio")});
            this.cboTipoBus.Properties.NullText = "";
            this.cboTipoBus.Size = new System.Drawing.Size(49, 20);
            this.cboTipoBus.TabIndex = 16;
            this.cboTipoBus.Visible = false;
            // 
            // optAnio
            // 
            this.optAnio.AutoSize = true;
            this.optAnio.Location = new System.Drawing.Point(26, 72);
            this.optAnio.Name = "optAnio";
            this.optAnio.Size = new System.Drawing.Size(44, 17);
            this.optAnio.TabIndex = 25;
            this.optAnio.Text = "Año";
            this.optAnio.UseVisualStyleBackColor = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(295, 31);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Tipo:";
            this.labelControl2.Visible = false;
            // 
            // frmRepPedidoRutaMes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 196);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepPedidoRutaMes";
            this.Text = "Reporte x Ruta x Mes";
            this.Load += new System.EventHandler(this.frmRepPedidoRutaMes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoBus.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        private System.Windows.Forms.RadioButton optMes;
        private System.Windows.Forms.RadioButton optSemana;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private System.Windows.Forms.RadioButton optDia;
        private System.Windows.Forms.RadioButton optAnio;
        public DevExpress.XtraEditors.LookUpEdit cboTipoBus;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}