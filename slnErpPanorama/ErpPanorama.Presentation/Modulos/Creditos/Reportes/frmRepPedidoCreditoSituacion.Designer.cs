namespace ErpPanorama.Presentation.Modulos.Creditos.Reportes
{
    partial class frmRepPedidoCreditoSituacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepPedidoCreditoSituacion));
            this.cboSituacion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSituacion
            // 
            this.cboSituacion.Location = new System.Drawing.Point(86, 56);
            this.cboSituacion.Name = "cboSituacion";
            this.cboSituacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSituacion.Properties.NullText = "";
            this.cboSituacion.Size = new System.Drawing.Size(195, 20);
            this.cboSituacion.TabIndex = 69;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 59);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(47, 13);
            this.labelControl3.TabIndex = 68;
            this.labelControl3.Text = "Situación:";
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(86, 34);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 67;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 66;
            this.labelControl1.Text = "Fecha Hasta: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(86, 12);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 65;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(11, 15);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 13);
            this.lblFecha.TabIndex = 64;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(227, 90);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageIndex = 1;
            this.btnVer.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(129, 90);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 70;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // frmRepPedidoCreditoSituacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 120);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.cboSituacion);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.deFechaHasta);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.deFechaDesde);
            this.Controls.Add(this.lblFecha);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepPedidoCreditoSituacion";
            this.Text = "Reporte Pedido Crédito Situación";
            this.Load += new System.EventHandler(this.frmRepPedidoCreditoSituacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSituacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit cboSituacion;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
    }
}