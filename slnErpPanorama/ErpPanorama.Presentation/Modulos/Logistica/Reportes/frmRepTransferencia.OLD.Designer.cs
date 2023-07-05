namespace ErpPanorama.Presentation.Modulos.Logistica.Reportes
{
    partial class frmRepTransferencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepTransferencia));
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.cboAlmacen = new DevExpress.XtraEditors.LookUpEdit();
            this.cboAlmacenDestino = new DevExpress.XtraEditors.LookUpEdit();
            this.cboMotivo = new DevExpress.XtraEditors.LookUpEdit();
            this.chkMotivo = new DevExpress.XtraEditors.CheckEdit();
            this.chkAlmacenDestino = new DevExpress.XtraEditors.CheckEdit();
            this.chkResumen = new DevExpress.XtraEditors.CheckEdit();
            this.chkAlmacenOrigen = new DevExpress.XtraEditors.CheckEdit();
            this.chkRecibido = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenDestino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMotivo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlmacenDestino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkResumen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlmacenOrigen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRecibido.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(126, 34);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 3;
            this.deFechaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaHasta_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Fecha Hasta: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(126, 13);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 1;
            this.deFechaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaDesde_KeyPress);
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(15, 16);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 13);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(346, 168);
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
            this.btnVer.Location = new System.Drawing.Point(248, 168);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 10;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Location = new System.Drawing.Point(126, 57);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAlmacen.Properties.NullText = "";
            this.cboAlmacen.Size = new System.Drawing.Size(248, 20);
            this.cboAlmacen.TabIndex = 5;
            this.cboAlmacen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboAlmacen_KeyPress);
            // 
            // cboAlmacenDestino
            // 
            this.cboAlmacenDestino.Location = new System.Drawing.Point(126, 80);
            this.cboAlmacenDestino.Name = "cboAlmacenDestino";
            this.cboAlmacenDestino.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAlmacenDestino.Properties.NullText = "";
            this.cboAlmacenDestino.Size = new System.Drawing.Size(248, 20);
            this.cboAlmacenDestino.TabIndex = 7;
            this.cboAlmacenDestino.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboAlmacenDestino_KeyPress);
            // 
            // cboMotivo
            // 
            this.cboMotivo.Location = new System.Drawing.Point(126, 103);
            this.cboMotivo.Name = "cboMotivo";
            this.cboMotivo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMotivo.Properties.NullText = "";
            this.cboMotivo.Size = new System.Drawing.Size(248, 20);
            this.cboMotivo.TabIndex = 9;
            this.cboMotivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboMotivo_KeyPress);
            // 
            // chkMotivo
            // 
            this.chkMotivo.EditValue = true;
            this.chkMotivo.Location = new System.Drawing.Point(15, 103);
            this.chkMotivo.Name = "chkMotivo";
            this.chkMotivo.Properties.Caption = "Motivo:";
            this.chkMotivo.Size = new System.Drawing.Size(102, 19);
            this.chkMotivo.TabIndex = 8;
            this.chkMotivo.ToolTip = "Check Desactivado, para Todos los Motivos";
            this.chkMotivo.CheckedChanged += new System.EventHandler(this.chkMotivo_CheckedChanged);
            // 
            // chkAlmacenDestino
            // 
            this.chkAlmacenDestino.EditValue = true;
            this.chkAlmacenDestino.Location = new System.Drawing.Point(15, 81);
            this.chkAlmacenDestino.Name = "chkAlmacenDestino";
            this.chkAlmacenDestino.Properties.Caption = "Almacén Destino:";
            this.chkAlmacenDestino.Size = new System.Drawing.Size(104, 19);
            this.chkAlmacenDestino.TabIndex = 6;
            this.chkAlmacenDestino.ToolTip = "Check Desactivado, para Todos los almacenes";
            this.chkAlmacenDestino.CheckedChanged += new System.EventHandler(this.chkAlmacenDestino_CheckedChanged);
            // 
            // chkResumen
            // 
            this.chkResumen.Location = new System.Drawing.Point(18, 170);
            this.chkResumen.Name = "chkResumen";
            this.chkResumen.Properties.Caption = "Resumen";
            this.chkResumen.Size = new System.Drawing.Size(102, 19);
            this.chkResumen.TabIndex = 8;
            // 
            // chkAlmacenOrigen
            // 
            this.chkAlmacenOrigen.EditValue = true;
            this.chkAlmacenOrigen.Location = new System.Drawing.Point(16, 58);
            this.chkAlmacenOrigen.Name = "chkAlmacenOrigen";
            this.chkAlmacenOrigen.Properties.Caption = "Almacén Origen:";
            this.chkAlmacenOrigen.Size = new System.Drawing.Size(104, 19);
            this.chkAlmacenOrigen.TabIndex = 6;
            this.chkAlmacenOrigen.ToolTip = "Check Desactivado, para Todos los almacenes";
            this.chkAlmacenOrigen.CheckedChanged += new System.EventHandler(this.chkAlmacenOrigen_CheckedChanged);
            // 
            // chkRecibido
            // 
            this.chkRecibido.Location = new System.Drawing.Point(124, 129);
            this.chkRecibido.Name = "chkRecibido";
            this.chkRecibido.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.chkRecibido.Properties.Appearance.Options.UseForeColor = true;
            this.chkRecibido.Properties.Caption = "Solo pendientes de Ingreso";
            this.chkRecibido.Size = new System.Drawing.Size(250, 19);
            this.chkRecibido.TabIndex = 8;
            this.chkRecibido.ToolTip = "Check Desactivado, para Todos los Motivos";
            this.chkRecibido.CheckedChanged += new System.EventHandler(this.chkMotivo_CheckedChanged);
            // 
            // frmRepTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 208);
            this.Controls.Add(this.chkAlmacenOrigen);
            this.Controls.Add(this.chkAlmacenDestino);
            this.Controls.Add(this.chkResumen);
            this.Controls.Add(this.chkRecibido);
            this.Controls.Add(this.chkMotivo);
            this.Controls.Add(this.cboMotivo);
            this.Controls.Add(this.cboAlmacenDestino);
            this.Controls.Add(this.cboAlmacen);
            this.Controls.Add(this.deFechaHasta);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.deFechaDesde);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepTransferencia";
            this.Text = "Reporte de Transferencia entre Sucursales";
            this.Load += new System.EventHandler(this.frmRepTransferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenDestino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMotivo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlmacenDestino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkResumen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAlmacenOrigen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRecibido.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        public DevExpress.XtraEditors.LookUpEdit cboAlmacen;
        public DevExpress.XtraEditors.LookUpEdit cboAlmacenDestino;
        public DevExpress.XtraEditors.LookUpEdit cboMotivo;
        private DevExpress.XtraEditors.CheckEdit chkMotivo;
        private DevExpress.XtraEditors.CheckEdit chkAlmacenDestino;
        private DevExpress.XtraEditors.CheckEdit chkResumen;
        private DevExpress.XtraEditors.CheckEdit chkAlmacenOrigen;
        private DevExpress.XtraEditors.CheckEdit chkRecibido;
    }
}