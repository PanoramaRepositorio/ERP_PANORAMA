namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepPedidoVendedorFormaPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepPedidoVendedorFormaPago));
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.chkResumen = new System.Windows.Forms.CheckBox();
            this.optRango = new System.Windows.Forms.RadioButton();
            this.optDia = new System.Windows.Forms.RadioButton();
            this.optAnio = new System.Windows.Forms.RadioButton();
            this.optMes = new System.Windows.Forms.RadioButton();
            this.optSemana = new System.Windows.Forms.RadioButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(101, 50);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 21;
            this.deFechaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaHasta_KeyPress);
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(101, 28);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 19;
            this.deFechaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaDesde_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(275, 190);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageIndex = 1;
            this.btnVer.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(177, 190);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 22;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.chkResumen);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.btnVer);
            this.grdDatos.Controls.Add(this.optRango);
            this.grdDatos.Controls.Add(this.optDia);
            this.grdDatos.Controls.Add(this.deFechaHasta);
            this.grdDatos.Controls.Add(this.deFechaDesde);
            this.grdDatos.Controls.Add(this.optAnio);
            this.grdDatos.Controls.Add(this.optMes);
            this.grdDatos.Controls.Add(this.optSemana);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(369, 226);
            this.grdDatos.TabIndex = 27;
            this.grdDatos.Text = "Datos";
            // 
            // chkResumen
            // 
            this.chkResumen.AutoSize = true;
            this.chkResumen.Location = new System.Drawing.Point(23, 196);
            this.chkResumen.Name = "chkResumen";
            this.chkResumen.Size = new System.Drawing.Size(70, 17);
            this.chkResumen.TabIndex = 25;
            this.chkResumen.Text = "Resumen";
            this.chkResumen.UseVisualStyleBackColor = true;
            // 
            // optRango
            // 
            this.optRango.AutoSize = true;
            this.optRango.Checked = true;
            this.optRango.Location = new System.Drawing.Point(26, 164);
            this.optRango.Name = "optRango";
            this.optRango.Size = new System.Drawing.Size(68, 17);
            this.optRango.TabIndex = 26;
            this.optRango.TabStop = true;
            this.optRango.Text = "R. Fecha";
            this.optRango.UseVisualStyleBackColor = true;
            // 
            // optDia
            // 
            this.optDia.AutoSize = true;
            this.optDia.Enabled = false;
            this.optDia.Location = new System.Drawing.Point(26, 141);
            this.optDia.Name = "optDia";
            this.optDia.Size = new System.Drawing.Size(40, 17);
            this.optDia.TabIndex = 26;
            this.optDia.Text = "Dia";
            this.optDia.UseVisualStyleBackColor = true;
            // 
            // optAnio
            // 
            this.optAnio.AutoSize = true;
            this.optAnio.Enabled = false;
            this.optAnio.Location = new System.Drawing.Point(26, 72);
            this.optAnio.Name = "optAnio";
            this.optAnio.Size = new System.Drawing.Size(44, 17);
            this.optAnio.TabIndex = 25;
            this.optAnio.Text = "Año";
            this.optAnio.UseVisualStyleBackColor = true;
            // 
            // optMes
            // 
            this.optMes.AutoSize = true;
            this.optMes.Enabled = false;
            this.optMes.Location = new System.Drawing.Point(26, 95);
            this.optMes.Name = "optMes";
            this.optMes.Size = new System.Drawing.Size(44, 17);
            this.optMes.TabIndex = 24;
            this.optMes.Text = "Mes";
            this.optMes.UseVisualStyleBackColor = true;
            // 
            // optSemana
            // 
            this.optSemana.AutoSize = true;
            this.optSemana.Enabled = false;
            this.optSemana.Location = new System.Drawing.Point(26, 118);
            this.optSemana.Name = "optSemana";
            this.optSemana.Size = new System.Drawing.Size(63, 17);
            this.optSemana.TabIndex = 25;
            this.optSemana.Text = "Semana";
            this.optSemana.UseVisualStyleBackColor = true;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(26, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Fecha Hasta: ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(26, 31);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Fecha Desde: ";
            // 
            // frmRepPedidoVendedorFormaPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 224);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepPedidoVendedorFormaPago";
            this.Text = "Resumen de Ventas - FormaPago";
            this.Load += new System.EventHandler(this.frmRepPedidoVendedorFormaPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private System.Windows.Forms.CheckBox chkResumen;
        private System.Windows.Forms.RadioButton optRango;
        private System.Windows.Forms.RadioButton optDia;
        private System.Windows.Forms.RadioButton optAnio;
        private System.Windows.Forms.RadioButton optMes;
        private System.Windows.Forms.RadioButton optSemana;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}