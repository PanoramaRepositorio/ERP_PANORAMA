namespace ErpPanorama.Presentation.Modulos.Maestros
{
    partial class frmManNumeracionDocumentoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManNumeracionDocumentoEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.txtSerie = new DevExpress.XtraEditors.TextEdit();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroCaracter = new DevExpress.XtraEditors.TextEdit();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.cboDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkFacturacion = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroCaracter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFacturacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(377, 213);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 28);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(282, 213);
            this.btnGrabar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(87, 28);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.txtSerie);
            this.grdDatos.Controls.Add(this.cboTienda);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Controls.Add(this.cboEmpresa);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.txtNumeroCaracter);
            this.grdDatos.Controls.Add(this.txtPeriodo);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.txtNumero);
            this.grdDatos.Controls.Add(this.cboDocumento);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(469, 201);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // txtSerie
            // 
            this.txtSerie.EditValue = "0";
            this.txtSerie.Location = new System.Drawing.Point(87, 141);
            this.txtSerie.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(70, 22);
            this.txtSerie.TabIndex = 9;
            this.txtSerie.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSerie_KeyPress);
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(87, 36);
            this.cboEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(376, 22);
            this.cboEmpresa.TabIndex = 1;
            this.cboEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboEmpresa_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 39);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(55, 16);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Empresa:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(176, 172);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(53, 16);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Longitud:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 118);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 16);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Periodo:";
            // 
            // txtNumeroCaracter
            // 
            this.txtNumeroCaracter.EditValue = "6";
            this.txtNumeroCaracter.Location = new System.Drawing.Point(236, 168);
            this.txtNumeroCaracter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumeroCaracter.Name = "txtNumeroCaracter";
            this.txtNumeroCaracter.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtNumeroCaracter.Properties.Appearance.Options.UseFont = true;
            this.txtNumeroCaracter.Properties.Mask.EditMask = "f0";
            this.txtNumeroCaracter.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumeroCaracter.Size = new System.Drawing.Size(70, 24);
            this.txtNumeroCaracter.TabIndex = 13;
            this.txtNumeroCaracter.ToolTip = "Número de caracteres que genera el número EJEMPLO: 4 = 0001, Completa de ceros a " +
    "la izquierda ";
            this.txtNumeroCaracter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroCaracter_KeyPress);
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.EditValue = "0";
            this.txtPeriodo.Location = new System.Drawing.Point(87, 114);
            this.txtPeriodo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Size = new System.Drawing.Size(70, 22);
            this.txtPeriodo.TabIndex = 7;
            this.txtPeriodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPeriodo_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 172);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 16);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.EditValue = "0";
            this.txtNumero.Location = new System.Drawing.Point(87, 168);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.Mask.EditMask = "f0";
            this.txtNumero.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumero.Size = new System.Drawing.Size(70, 22);
            this.txtNumero.TabIndex = 11;
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // cboDocumento
            // 
            this.cboDocumento.Location = new System.Drawing.Point(87, 86);
            this.cboDocumento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDocumento.Name = "cboDocumento";
            this.cboDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDocumento.Properties.NullText = "";
            this.cboDocumento.Size = new System.Drawing.Size(376, 22);
            this.cboDocumento.TabIndex = 5;
            this.cboDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDocumento_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 89);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 16);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Documento:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 145);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(35, 16);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Serie:";
            // 
            // chkFacturacion
            // 
            this.chkFacturacion.Location = new System.Drawing.Point(13, 211);
            this.chkFacturacion.Name = "chkFacturacion";
            this.chkFacturacion.Properties.Caption = "Mostrar en facturación";
            this.chkFacturacion.Size = new System.Drawing.Size(165, 20);
            this.chkFacturacion.TabIndex = 1;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(13, 64);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(44, 16);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Tienda:";
            // 
            // cboTienda
            // 
            this.cboTienda.Location = new System.Drawing.Point(87, 61);
            this.cboTienda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(376, 22);
            this.cboTienda.TabIndex = 3;
            this.cboTienda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboEmpresa_KeyPress);
            // 
            // frmManNumeracionDocumentoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 254);
            this.Controls.Add(this.chkFacturacion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManNumeracionDocumentoEdit";
            this.Load += new System.EventHandler(this.frmManNumeracionDocumentoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSerie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroCaracter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFacturacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.TextEdit txtSerie;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtNumeroCaracter;
        private DevExpress.XtraEditors.TextEdit txtPeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        public DevExpress.XtraEditors.LookUpEdit cboDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkFacturacion;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}