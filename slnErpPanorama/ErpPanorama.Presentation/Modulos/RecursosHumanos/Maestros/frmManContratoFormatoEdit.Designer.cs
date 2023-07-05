namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    partial class frmManContratoFormatoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManContratoFormatoEdit));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditarElemento = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoContrato = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTitulo = new DevExpress.XtraEditors.TextEdit();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.txtFirma = new DevExpress.XtraEditors.MemoEdit();
            this.txtCuerpo = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoContrato.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitulo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuerpo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnGrabar);
            this.groupControl1.Controls.Add(this.btnCancelar);
            this.groupControl1.Controls.Add(this.btnEditarElemento);
            this.groupControl1.Controls.Add(this.memoEdit1);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.cboTipoContrato);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtTitulo);
            this.groupControl1.Controls.Add(this.txtDescripcion);
            this.groupControl1.Controls.Add(this.txtFirma);
            this.groupControl1.Controls.Add(this.txtCuerpo);
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1017, 727);
            this.groupControl1.TabIndex = 10;
            this.groupControl1.Text = "Formato";
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(666, 697);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 11;
            this.btnGrabar.Text = "&Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(747, 697);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditarElemento
            // 
            this.btnEditarElemento.Location = new System.Drawing.Point(939, 26);
            this.btnEditarElemento.Name = "btnEditarElemento";
            this.btnEditarElemento.Size = new System.Drawing.Size(48, 23);
            this.btnEditarElemento.TabIndex = 44;
            this.btnEditarElemento.Text = "Edit";
            this.btnEditarElemento.Click += new System.EventHandler(this.btnEditarElemento_Click);
            // 
            // memoEdit1
            // 
            this.memoEdit1.EditValue = resources.GetString("memoEdit1.EditValue");
            this.memoEdit1.Location = new System.Drawing.Point(828, 100);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.ReadOnly = true;
            this.memoEdit1.Size = new System.Drawing.Size(177, 591);
            this.memoEdit1.TabIndex = 43;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(485, 32);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 13);
            this.labelControl4.TabIndex = 42;
            this.labelControl4.Text = "Tipo Contrato:";
            // 
            // cboTipoContrato
            // 
            this.cboTipoContrato.Location = new System.Drawing.Point(561, 29);
            this.cboTipoContrato.Name = "cboTipoContrato";
            this.cboTipoContrato.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoContrato.Properties.NullText = "";
            this.cboTipoContrato.Size = new System.Drawing.Size(372, 20);
            this.cboTipoContrato.TabIndex = 41;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(828, 81);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(62, 13);
            this.labelControl8.TabIndex = 40;
            this.labelControl8.Text = "ETIQUETAS";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(21, 630);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(35, 13);
            this.labelControl5.TabIndex = 37;
            this.labelControl5.Text = "Firma:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(21, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 13);
            this.labelControl3.TabIndex = 35;
            this.labelControl3.Text = "Cuerpo:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(21, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(35, 13);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "Título:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "Descripcion:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(85, 55);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Properties.MaxLength = 60;
            this.txtTitulo.Size = new System.Drawing.Size(737, 20);
            this.txtTitulo.TabIndex = 34;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(85, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(394, 20);
            this.txtDescripcion.TabIndex = 32;
            // 
            // txtFirma
            // 
            this.txtFirma.EditValue = "__________________________________\t\t\t\t___________________________________________" +
    "_____\r\nELEAZAR TAPIA TARRILLO\t\t\t\t\t\t@NOMBREPERSONA\r\nDNI. 06861114                " +
    " \t\t\t\t\t\t@DNIPERSONA";
            this.txtFirma.Location = new System.Drawing.Point(85, 632);
            this.txtFirma.Name = "txtFirma";
            this.txtFirma.Properties.MaxLength = 2000;
            this.txtFirma.Properties.ReadOnly = true;
            this.txtFirma.Size = new System.Drawing.Size(737, 59);
            this.txtFirma.TabIndex = 38;
            // 
            // txtCuerpo
            // 
            this.txtCuerpo.Location = new System.Drawing.Point(85, 79);
            this.txtCuerpo.Name = "txtCuerpo";
            this.txtCuerpo.Size = new System.Drawing.Size(737, 547);
            this.txtCuerpo.TabIndex = 36;
            // 
            // frmManContratoFormatoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 730);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManContratoFormatoEdit";
            this.Load += new System.EventHandler(this.frmManContratoFormatoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoContrato.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitulo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFirma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCuerpo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.LookUpEdit cboTipoContrato;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTitulo;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.MemoEdit txtFirma;
        private DevExpress.XtraEditors.MemoEdit txtCuerpo;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton btnEditarElemento;
    }
}