namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    partial class frmManEstudioRealizadoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManEstudioRealizadoEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMesAnioFin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtGradoObtenido = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMesAnioInicio = new DevExpress.XtraEditors.TextEdit();
            this.cboNivelEstudio = new DevExpress.XtraEditors.LookUpEdit();
            this.lblEmpresa = new DevExpress.XtraEditors.LabelControl();
            this.lblMoneda = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCentroEstudio = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMesAnioFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGradoObtenido.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMesAnioInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNivelEstudio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCentroEstudio.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtMesAnioFin);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtGradoObtenido);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.txtMesAnioInicio);
            this.grdDatos.Controls.Add(this.cboNivelEstudio);
            this.grdDatos.Controls.Add(this.lblEmpresa);
            this.grdDatos.Controls.Add(this.lblMoneda);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.txtCentroEstudio);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.btnAceptar);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(565, 165);
            this.grdDatos.TabIndex = 2;
            this.grdDatos.Text = "Datos";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(215, 113);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(122, 13);
            this.labelControl6.TabIndex = 36;
            this.labelControl6.Text = "Ejemplo : OCTUBRE-2010";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(215, 92);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(111, 13);
            this.labelControl4.TabIndex = 35;
            this.labelControl4.Text = "Ejemplo : MARZO-1999";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 114);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 33;
            this.labelControl2.Text = "Mes-Año-Fin";
            // 
            // txtMesAnioFin
            // 
            this.txtMesAnioFin.Location = new System.Drawing.Point(107, 111);
            this.txtMesAnioFin.Name = "txtMesAnioFin";
            this.txtMesAnioFin.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMesAnioFin.Properties.MaxLength = 20;
            this.txtMesAnioFin.Size = new System.Drawing.Size(102, 20);
            this.txtMesAnioFin.TabIndex = 34;
            this.txtMesAnioFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMesAnioFin_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(80, 13);
            this.labelControl1.TabIndex = 31;
            this.labelControl1.Text = "Grado Obtenido:";
            // 
            // txtGradoObtenido
            // 
            this.txtGradoObtenido.Location = new System.Drawing.Point(107, 67);
            this.txtGradoObtenido.Name = "txtGradoObtenido";
            this.txtGradoObtenido.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtGradoObtenido.Properties.MaxLength = 150;
            this.txtGradoObtenido.Size = new System.Drawing.Size(453, 20);
            this.txtGradoObtenido.TabIndex = 32;
            this.txtGradoObtenido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGradoObtenido_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 92);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Mes-Año-Inicio:";
            // 
            // txtMesAnioInicio
            // 
            this.txtMesAnioInicio.Location = new System.Drawing.Point(107, 89);
            this.txtMesAnioInicio.Name = "txtMesAnioInicio";
            this.txtMesAnioInicio.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMesAnioInicio.Properties.MaxLength = 20;
            this.txtMesAnioInicio.Size = new System.Drawing.Size(102, 20);
            this.txtMesAnioInicio.TabIndex = 30;
            this.txtMesAnioInicio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMesAnioInicio_KeyPress);
            // 
            // cboNivelEstudio
            // 
            this.cboNivelEstudio.Location = new System.Drawing.Point(107, 24);
            this.cboNivelEstudio.Name = "cboNivelEstudio";
            this.cboNivelEstudio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNivelEstudio.Properties.NullText = "";
            this.cboNivelEstudio.Size = new System.Drawing.Size(147, 20);
            this.cboNivelEstudio.TabIndex = 22;
            this.cboNivelEstudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNivelEstudio_KeyPress);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.Location = new System.Drawing.Point(12, 27);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(65, 13);
            this.lblEmpresa.TabIndex = 21;
            this.lblEmpresa.Text = "Nivel Estudio:";
            // 
            // lblMoneda
            // 
            this.lblMoneda.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoneda.Location = new System.Drawing.Point(308, 93);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(0, 14);
            this.lblMoneda.TabIndex = 20;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(12, 49);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(95, 13);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "Centro de Estudios:";
            // 
            // txtCentroEstudio
            // 
            this.txtCentroEstudio.Location = new System.Drawing.Point(107, 46);
            this.txtCentroEstudio.Name = "txtCentroEstudio";
            this.txtCentroEstudio.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCentroEstudio.Properties.MaxLength = 150;
            this.txtCentroEstudio.Size = new System.Drawing.Size(453, 20);
            this.txtCentroEstudio.TabIndex = 16;
            this.txtCentroEstudio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCentroEstudio_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(485, 135);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(404, 135);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmManEstudioRealizadoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 165);
            this.Controls.Add(this.grdDatos);
            this.Name = "frmManEstudioRealizadoEdit";
            this.Text = "Estudios Realizados";
            this.Load += new System.EventHandler(this.frmManEstudioRealizadoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMesAnioFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGradoObtenido.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMesAnioInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNivelEstudio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCentroEstudio.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.TextEdit txtMesAnioInicio;
        public DevExpress.XtraEditors.LookUpEdit cboNivelEstudio;
        private DevExpress.XtraEditors.LabelControl lblEmpresa;
        private DevExpress.XtraEditors.LabelControl lblMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.TextEdit txtCentroEstudio;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        public DevExpress.XtraEditors.TextEdit txtGradoObtenido;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtMesAnioFin;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}