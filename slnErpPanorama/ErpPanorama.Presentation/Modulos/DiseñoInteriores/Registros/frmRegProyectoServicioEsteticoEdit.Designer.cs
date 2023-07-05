namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Registros
{
    partial class frmRegProyectoServicioEsteticoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegProyectoServicioEsteticoEdit));
            this.cboForma = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cboMaterial = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.cboTipoColor = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtTextura = new DevExpress.XtraEditors.TextEdit();
            this.txtVolumen = new DevExpress.XtraEditors.TextEdit();
            this.cboEstilo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtObjetivos = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboForma.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoColor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextura.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVolumen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstilo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObjetivos.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboForma
            // 
            this.cboForma.Location = new System.Drawing.Point(306, 96);
            this.cboForma.Name = "cboForma";
            this.cboForma.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboForma.Properties.NullText = "";
            this.cboForma.Size = new System.Drawing.Size(164, 20);
            this.cboForma.TabIndex = 5;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(265, 99);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(34, 13);
            this.labelControl8.TabIndex = 4;
            this.labelControl8.Text = "Forma:";
            // 
            // cboMaterial
            // 
            this.cboMaterial.Location = new System.Drawing.Point(70, 174);
            this.cboMaterial.Name = "cboMaterial";
            this.cboMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMaterial.Properties.NullText = "";
            this.cboMaterial.Size = new System.Drawing.Size(164, 20);
            this.cboMaterial.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 177);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(42, 13);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Material:";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(14, 30);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(50, 13);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "Objetivos:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(395, 221);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = global::ErpPanorama.Presentation.Properties.Resources.Aceptar_16x16;
            this.btnAceptar.ImageIndex = 1;
            this.btnAceptar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(313, 221);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.cboTipoColor);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.labelControl10);
            this.grdDatos.Controls.Add(this.labelControl9);
            this.grdDatos.Controls.Add(this.txtTextura);
            this.grdDatos.Controls.Add(this.txtVolumen);
            this.grdDatos.Controls.Add(this.cboForma);
            this.grdDatos.Controls.Add(this.labelControl8);
            this.grdDatos.Controls.Add(this.cboEstilo);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.cboMaterial);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.labelControl12);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.btnAceptar);
            this.grdDatos.Controls.Add(this.txtObjetivos);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(488, 268);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // cboTipoColor
            // 
            this.cboTipoColor.Location = new System.Drawing.Point(306, 174);
            this.cboTipoColor.Name = "cboTipoColor";
            this.cboTipoColor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoColor.Properties.NullText = "";
            this.cboTipoColor.Size = new System.Drawing.Size(164, 20);
            this.cboTipoColor.TabIndex = 13;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(270, 177);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Color:";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(21, 151);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(42, 13);
            this.labelControl10.TabIndex = 8;
            this.labelControl10.Text = "Textura:";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(19, 125);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(44, 13);
            this.labelControl9.TabIndex = 6;
            this.labelControl9.Text = "Volúmen:";
            // 
            // txtTextura
            // 
            this.txtTextura.Location = new System.Drawing.Point(70, 148);
            this.txtTextura.Name = "txtTextura";
            this.txtTextura.Size = new System.Drawing.Size(400, 20);
            this.txtTextura.TabIndex = 9;
            // 
            // txtVolumen
            // 
            this.txtVolumen.Location = new System.Drawing.Point(70, 122);
            this.txtVolumen.Name = "txtVolumen";
            this.txtVolumen.Size = new System.Drawing.Size(400, 20);
            this.txtVolumen.TabIndex = 7;
            // 
            // cboEstilo
            // 
            this.cboEstilo.Location = new System.Drawing.Point(70, 96);
            this.cboEstilo.Name = "cboEstilo";
            this.cboEstilo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEstilo.Properties.NullText = "";
            this.cboEstilo.Size = new System.Drawing.Size(164, 20);
            this.cboEstilo.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(34, 99);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(29, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Estilo:";
            // 
            // txtObjetivos
            // 
            this.txtObjetivos.Location = new System.Drawing.Point(70, 28);
            this.txtObjetivos.Name = "txtObjetivos";
            this.txtObjetivos.Size = new System.Drawing.Size(400, 62);
            this.txtObjetivos.TabIndex = 1;
            // 
            // frmRegProyectoServicioEsteticoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 256);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegProyectoServicioEsteticoEdit";
            this.Text = "Seleccionar Servicio Estético";
            this.Load += new System.EventHandler(this.frmRegProyectoServicioEsteticoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboForma.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoColor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextura.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVolumen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstilo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObjetivos.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.LookUpEdit cboForma;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        public DevExpress.XtraEditors.LookUpEdit cboMaterial;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtTextura;
        private DevExpress.XtraEditors.TextEdit txtVolumen;
        public DevExpress.XtraEditors.LookUpEdit cboEstilo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit cboTipoColor;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtObjetivos;
    }
}