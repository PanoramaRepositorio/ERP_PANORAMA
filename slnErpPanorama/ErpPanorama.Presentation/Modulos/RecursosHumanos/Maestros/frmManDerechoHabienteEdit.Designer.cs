namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    partial class frmManDerechoHabienteEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManDerechoHabienteEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.chkEPS = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtOcupacion = new DevExpress.XtraEditors.TextEdit();
            this.lblAño = new DevExpress.XtraEditors.LabelControl();
            this.deFechaNac = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroDocumento = new DevExpress.XtraEditors.TextEdit();
            this.cboParentesco = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboSexo = new DevExpress.XtraEditors.LookUpEdit();
            this.lblEmpresa = new DevExpress.XtraEditors.LabelControl();
            this.lblMoneda = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtApeNom = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEPS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOcupacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaNac.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaNac.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParentesco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSexo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApeNom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.chkEPS);
            this.grdDatos.Controls.Add(this.labelControl12);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.txtOcupacion);
            this.grdDatos.Controls.Add(this.lblAño);
            this.grdDatos.Controls.Add(this.deFechaNac);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtNumeroDocumento);
            this.grdDatos.Controls.Add(this.cboParentesco);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.cboSexo);
            this.grdDatos.Controls.Add(this.lblEmpresa);
            this.grdDatos.Controls.Add(this.lblMoneda);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.txtApeNom);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.btnAceptar);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(565, 199);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // chkEPS
            // 
            this.chkEPS.Location = new System.Drawing.Point(98, 158);
            this.chkEPS.Name = "chkEPS";
            this.chkEPS.Properties.Caption = "";
            this.chkEPS.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkEPS.Size = new System.Drawing.Size(19, 22);
            this.chkEPS.TabIndex = 14;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(12, 163);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(22, 13);
            this.labelControl12.TabIndex = 13;
            this.labelControl12.Text = "EPS:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 138);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Ocupación:";
            // 
            // txtOcupacion
            // 
            this.txtOcupacion.Location = new System.Drawing.Point(100, 135);
            this.txtOcupacion.Name = "txtOcupacion";
            this.txtOcupacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOcupacion.Size = new System.Drawing.Size(453, 20);
            this.txtOcupacion.TabIndex = 12;
            this.txtOcupacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOcupacion_KeyPress);
            // 
            // lblAño
            // 
            this.lblAño.Location = new System.Drawing.Point(12, 117);
            this.lblAño.Name = "lblAño";
            this.lblAño.Size = new System.Drawing.Size(79, 13);
            this.lblAño.TabIndex = 9;
            this.lblAño.Text = "Fch Nacimiento: ";
            // 
            // deFechaNac
            // 
            this.deFechaNac.EditValue = null;
            this.deFechaNac.Location = new System.Drawing.Point(100, 114);
            this.deFechaNac.Name = "deFechaNac";
            this.deFechaNac.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaNac.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaNac.Size = new System.Drawing.Size(100, 20);
            this.deFechaNac.TabIndex = 10;
            this.deFechaNac.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaNac_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 71);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(19, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Dni:";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Location = new System.Drawing.Point(83, 68);
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.Properties.MaxLength = 8;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(85, 20);
            this.txtNumeroDocumento.TabIndex = 5;
            this.txtNumeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDocumento_KeyPress);
            // 
            // cboParentesco
            // 
            this.cboParentesco.Location = new System.Drawing.Point(83, 46);
            this.cboParentesco.Name = "cboParentesco";
            this.cboParentesco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboParentesco.Properties.NullText = "";
            this.cboParentesco.Size = new System.Drawing.Size(147, 20);
            this.cboParentesco.TabIndex = 3;
            this.cboParentesco.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboParentesco_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Parentesco:";
            // 
            // cboSexo
            // 
            this.cboSexo.Location = new System.Drawing.Point(83, 24);
            this.cboSexo.Name = "cboSexo";
            this.cboSexo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSexo.Properties.NullText = "";
            this.cboSexo.Size = new System.Drawing.Size(147, 20);
            this.cboSexo.TabIndex = 1;
            this.cboSexo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboSexo_KeyPress);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Location = new System.Drawing.Point(12, 27);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(28, 13);
            this.lblEmpresa.TabIndex = 0;
            this.lblEmpresa.Text = "Sexo:";
            // 
            // lblMoneda
            // 
            this.lblMoneda.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneda.Location = new System.Drawing.Point(308, 93);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(0, 14);
            this.lblMoneda.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 93);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(79, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Apellidos y Nom:";
            // 
            // txtApeNom
            // 
            this.txtApeNom.Location = new System.Drawing.Point(100, 91);
            this.txtApeNom.Name = "txtApeNom";
            this.txtApeNom.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtApeNom.Size = new System.Drawing.Size(453, 20);
            this.txtApeNom.TabIndex = 7;
            this.txtApeNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApeNom_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(478, 166);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(397, 166);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmManDerechoHabienteEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 201);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManDerechoHabienteEdit";
            this.Text = "Derecho Habientes";
            this.Load += new System.EventHandler(this.frmManDerechoHabienteEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEPS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOcupacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaNac.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaNac.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboParentesco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSexo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApeNom.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl lblMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.TextEdit txtApeNom;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        public DevExpress.XtraEditors.LookUpEdit cboSexo;
        private DevExpress.XtraEditors.LabelControl lblEmpresa;
        public DevExpress.XtraEditors.LookUpEdit cboParentesco;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtOcupacion;
        private DevExpress.XtraEditors.LabelControl lblAño;
        public DevExpress.XtraEditors.TextEdit txtNumeroDocumento;
        public DevExpress.XtraEditors.DateEdit deFechaNac;
        private DevExpress.XtraEditors.CheckEdit chkEPS;
        private DevExpress.XtraEditors.LabelControl labelControl12;
    }
}