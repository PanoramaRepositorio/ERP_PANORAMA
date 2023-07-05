namespace ErpPanorama.Presentation.Modulos.Contabilidad.Reportes
{
    partial class frmRepDocumentoVentaEmpresaSerie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepDocumentoVentaEmpresaSerie));
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.chkEmpresaTodo = new System.Windows.Forms.CheckBox();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.cboDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.chkDocumentoTodo = new System.Windows.Forms.CheckBox();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.gboReporte = new System.Windows.Forms.GroupBox();
            this.rdbFecha = new System.Windows.Forms.RadioButton();
            this.rdbEmpresa = new System.Windows.Forms.RadioButton();
            this.rdbSerie = new System.Windows.Forms.RadioButton();
            this.cboSerie = new DevExpress.XtraEditors.LookUpEdit();
            this.chkSerieTodo = new System.Windows.Forms.CheckBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).BeginInit();
            this.gboReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSerie.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Enabled = false;
            this.cboEmpresa.Location = new System.Drawing.Point(84, 83);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(416, 20);
            this.cboEmpresa.TabIndex = 63;
            this.cboEmpresa.EditValueChanged += new System.EventHandler(this.cboEmpresa_EditValueChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 86);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(45, 13);
            this.labelControl8.TabIndex = 60;
            this.labelControl8.Text = "Empresa:";
            // 
            // chkEmpresaTodo
            // 
            this.chkEmpresaTodo.AutoSize = true;
            this.chkEmpresaTodo.Checked = true;
            this.chkEmpresaTodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEmpresaTodo.Location = new System.Drawing.Point(11, 63);
            this.chkEmpresaTodo.Name = "chkEmpresaTodo";
            this.chkEmpresaTodo.Size = new System.Drawing.Size(120, 17);
            this.chkEmpresaTodo.TabIndex = 54;
            this.chkEmpresaTodo.Text = "Todas las Empresas";
            this.chkEmpresaTodo.UseVisualStyleBackColor = true;
            this.chkEmpresaTodo.CheckedChanged += new System.EventHandler(this.chkEmpresaTodo_CheckedChanged);
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(84, 32);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 50;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 35);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 13);
            this.labelControl1.TabIndex = 49;
            this.labelControl1.Text = "Fecha Hasta: ";
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(84, 10);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 48;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(11, 13);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(69, 13);
            this.lblFecha.TabIndex = 47;
            this.lblFecha.Text = "Fecha Desde: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(434, 205);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 52;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageIndex = 1;
            this.btnVer.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(336, 205);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 51;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // cboDocumento
            // 
            this.cboDocumento.Enabled = false;
            this.cboDocumento.Location = new System.Drawing.Point(84, 136);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDocumento.Properties.NullText = "";
            this.cboDocumento.Size = new System.Drawing.Size(69, 20);
            this.cboDocumento.TabIndex = 73;
            this.cboDocumento.EditValueChanged += new System.EventHandler(this.cboDocumento_EditValueChanged);
            // 
            // chkDocumentoTodo
            // 
            this.chkDocumentoTodo.AutoSize = true;
            this.chkDocumentoTodo.Checked = true;
            this.chkDocumentoTodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDocumentoTodo.Location = new System.Drawing.Point(11, 113);
            this.chkDocumentoTodo.Name = "chkDocumentoTodo";
            this.chkDocumentoTodo.Size = new System.Drawing.Size(133, 17);
            this.chkDocumentoTodo.TabIndex = 75;
            this.chkDocumentoTodo.Text = "Todos los Documentos";
            this.chkDocumentoTodo.UseVisualStyleBackColor = true;
            this.chkDocumentoTodo.CheckedChanged += new System.EventHandler(this.chkDocummentoTodo_CheckedChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 139);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(58, 13);
            this.labelControl7.TabIndex = 74;
            this.labelControl7.Text = "Documento:";
            // 
            // gboReporte
            // 
            this.gboReporte.Controls.Add(this.rdbFecha);
            this.gboReporte.Controls.Add(this.rdbEmpresa);
            this.gboReporte.Controls.Add(this.rdbSerie);
            this.gboReporte.Location = new System.Drawing.Point(11, 171);
            this.gboReporte.Name = "gboReporte";
            this.gboReporte.Size = new System.Drawing.Size(245, 57);
            this.gboReporte.TabIndex = 77;
            this.gboReporte.TabStop = false;
            this.gboReporte.Text = "Agrupado por";
            // 
            // rdbFecha
            // 
            this.rdbFecha.AutoSize = true;
            this.rdbFecha.Checked = true;
            this.rdbFecha.Location = new System.Drawing.Point(13, 24);
            this.rdbFecha.Name = "rdbFecha";
            this.rdbFecha.Size = new System.Drawing.Size(54, 17);
            this.rdbFecha.TabIndex = 2;
            this.rdbFecha.TabStop = true;
            this.rdbFecha.Text = "Fecha";
            this.rdbFecha.UseVisualStyleBackColor = true;
            // 
            // rdbEmpresa
            // 
            this.rdbEmpresa.AutoSize = true;
            this.rdbEmpresa.Location = new System.Drawing.Point(153, 24);
            this.rdbEmpresa.Name = "rdbEmpresa";
            this.rdbEmpresa.Size = new System.Drawing.Size(66, 17);
            this.rdbEmpresa.TabIndex = 1;
            this.rdbEmpresa.Text = "Empresa";
            this.rdbEmpresa.UseVisualStyleBackColor = true;
            // 
            // rdbSerie
            // 
            this.rdbSerie.AutoSize = true;
            this.rdbSerie.Location = new System.Drawing.Point(84, 24);
            this.rdbSerie.Name = "rdbSerie";
            this.rdbSerie.Size = new System.Drawing.Size(49, 17);
            this.rdbSerie.TabIndex = 0;
            this.rdbSerie.Text = "Serie";
            this.rdbSerie.UseVisualStyleBackColor = true;
            // 
            // cboSerie
            // 
            this.cboSerie.Enabled = false;
            this.cboSerie.Location = new System.Drawing.Point(234, 136);
            this.cboSerie.Name = "cboSerie";
            this.cboSerie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSerie.Properties.NullText = "";
            this.cboSerie.Size = new System.Drawing.Size(69, 20);
            this.cboSerie.TabIndex = 78;
            // 
            // chkSerieTodo
            // 
            this.chkSerieTodo.AutoSize = true;
            this.chkSerieTodo.Checked = true;
            this.chkSerieTodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSerieTodo.Location = new System.Drawing.Point(192, 113);
            this.chkSerieTodo.Name = "chkSerieTodo";
            this.chkSerieTodo.Size = new System.Drawing.Size(103, 17);
            this.chkSerieTodo.TabIndex = 79;
            this.chkSerieTodo.Text = "Todas las Series";
            this.chkSerieTodo.UseVisualStyleBackColor = true;
            this.chkSerieTodo.CheckedChanged += new System.EventHandler(this.chkSerieTodo_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(192, 139);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 80;
            this.labelControl2.Text = "Serie:";
            // 
            // frmRepDocumentoVentaEmpresaSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 240);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.chkSerieTodo);
            this.Controls.Add(this.cboSerie);
            this.Controls.Add(this.gboReporte);
            this.Controls.Add(this.chkDocumentoTodo);
            this.Controls.Add(this.cboDocumento);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.chkEmpresaTodo);
            this.Controls.Add(this.deFechaHasta);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.deFechaDesde);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnVer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepDocumentoVentaEmpresaSerie";
            this.Text = "Reporte de Ventas por Empresa y Serie";
            this.Load += new System.EventHandler(this.frmRepDocumentoVentaEmpresaSerie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).EndInit();
            this.gboReporte.ResumeLayout(false);
            this.gboReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSerie.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.CheckBox chkEmpresaTodo;
        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        public DevExpress.XtraEditors.LookUpEdit cboDocumento;
        private System.Windows.Forms.CheckBox chkDocumentoTodo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.GroupBox gboReporte;
        private System.Windows.Forms.RadioButton rdbEmpresa;
        private System.Windows.Forms.RadioButton rdbSerie;
        public DevExpress.XtraEditors.LookUpEdit cboSerie;
        private System.Windows.Forms.RadioButton rdbFecha;
        private System.Windows.Forms.CheckBox chkSerieTodo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}