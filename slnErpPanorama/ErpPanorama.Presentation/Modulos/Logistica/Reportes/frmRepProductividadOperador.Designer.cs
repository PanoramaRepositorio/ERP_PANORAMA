namespace ErpPanorama.Presentation.Modulos.Logistica.Reportes
{
    partial class frmRepProductividadOperador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepProductividadOperador));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optDetalleV = new System.Windows.Forms.RadioButton();
            this.optResumen = new System.Windows.Forms.RadioButton();
            this.optDetalleH = new System.Windows.Forms.RadioButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.btnCancelar);
            this.groupControl1.Controls.Add(this.optDetalleH);
            this.groupControl1.Controls.Add(this.btnConsultar);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.deFechaHasta);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.deFechaDesde);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(371, 180);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Criterios de Busqueda";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optDetalleV);
            this.groupBox1.Controls.Add(this.optResumen);
            this.groupBox1.Location = new System.Drawing.Point(17, 72);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(334, 46);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // optDetalleV
            // 
            this.optDetalleV.AutoSize = true;
            this.optDetalleV.Checked = true;
            this.optDetalleV.Location = new System.Drawing.Point(180, 18);
            this.optDetalleV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optDetalleV.Name = "optDetalleV";
            this.optDetalleV.Size = new System.Drawing.Size(58, 17);
            this.optDetalleV.TabIndex = 0;
            this.optDetalleV.TabStop = true;
            this.optDetalleV.Text = "Detalle";
            this.optDetalleV.UseVisualStyleBackColor = true;
            // 
            // optResumen
            // 
            this.optResumen.AutoSize = true;
            this.optResumen.Location = new System.Drawing.Point(23, 18);
            this.optResumen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optResumen.Name = "optResumen";
            this.optResumen.Size = new System.Drawing.Size(69, 17);
            this.optResumen.TabIndex = 0;
            this.optResumen.Text = "&Resumen";
            this.optResumen.UseVisualStyleBackColor = true;
            // 
            // optDetalleH
            // 
            this.optDetalleH.AutoSize = true;
            this.optDetalleH.Location = new System.Drawing.Point(17, 131);
            this.optDetalleH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.optDetalleH.Name = "optDetalleH";
            this.optDetalleH.Size = new System.Drawing.Size(109, 17);
            this.optDetalleH.TabIndex = 0;
            this.optDetalleH.Text = "Detalle &Horizontal";
            this.optDetalleH.UseVisualStyleBackColor = true;
            this.optDetalleH.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(277, 131);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnConsultar.ImageOptions.Image")));
            this.btnConsultar.Location = new System.Drawing.Point(180, 132);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(91, 22);
            this.btnConsultar.TabIndex = 5;
            this.btnConsultar.Text = "Ver Informe";
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 26);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(34, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Desde:";
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(58, 49);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.deFechaHasta.Properties.ShowPopupShadow = false;
            this.deFechaHasta.Properties.ShowToday = false;
            this.deFechaHasta.Size = new System.Drawing.Size(106, 20);
            this.deFechaHasta.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(17, 52);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Hasta:";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(58, 26);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Properties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Simple;
            this.deFechaDesde.Properties.ShowPopupShadow = false;
            this.deFechaDesde.Properties.ShowToday = false;
            this.deFechaDesde.Size = new System.Drawing.Size(106, 20);
            this.deFechaDesde.TabIndex = 1;
            // 
            // frmRepProductividadOperador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 164);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepProductividadOperador";
            this.Text = "Reporte Productividad Operador";
            this.Load += new System.EventHandler(this.frmRepProductividadOperador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnConsultar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optDetalleV;
        private System.Windows.Forms.RadioButton optResumen;
        private System.Windows.Forms.RadioButton optDetalleH;
    }
}