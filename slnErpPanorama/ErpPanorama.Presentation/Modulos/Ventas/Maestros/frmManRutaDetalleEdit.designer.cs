namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManRutaDetalleEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManRutaDetalleEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.cboDepartamento = new DevExpress.XtraEditors.LookUpEdit();
            this.cboProvincia = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDistrito = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.cboDepartamento);
            this.grdDatos.Controls.Add(this.cboProvincia);
            this.grdDatos.Controls.Add(this.cboDistrito);
            this.grdDatos.Controls.Add(this.labelControl18);
            this.grdDatos.Controls.Add(this.labelControl19);
            this.grdDatos.Controls.Add(this.labelControl20);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(793, 57);
            this.grdDatos.TabIndex = 1;
            this.grdDatos.Text = "Datos";
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Location = new System.Drawing.Point(86, 25);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartamento.Properties.NullText = "";
            this.cboDepartamento.Size = new System.Drawing.Size(181, 20);
            this.cboDepartamento.TabIndex = 21;
            this.cboDepartamento.EditValueChanged += new System.EventHandler(this.cboDepartamento_EditValueChanged);
            // 
            // cboProvincia
            // 
            this.cboProvincia.Location = new System.Drawing.Point(326, 26);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProvincia.Properties.NullText = "";
            this.cboProvincia.Size = new System.Drawing.Size(199, 20);
            this.cboProvincia.TabIndex = 23;
            this.cboProvincia.EditValueChanged += new System.EventHandler(this.cboProvincia_EditValueChanged);
            // 
            // cboDistrito
            // 
            this.cboDistrito.Location = new System.Drawing.Point(575, 25);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDistrito.Properties.NullText = "";
            this.cboDistrito.Size = new System.Drawing.Size(206, 20);
            this.cboDistrito.TabIndex = 25;
            // 
            // labelControl18
            // 
            this.labelControl18.Location = new System.Drawing.Point(531, 28);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(38, 13);
            this.labelControl18.TabIndex = 24;
            this.labelControl18.Text = "Distrito:";
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(274, 28);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(47, 13);
            this.labelControl19.TabIndex = 22;
            this.labelControl19.Text = "Provincia:";
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(7, 28);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(73, 13);
            this.labelControl20.TabIndex = 20;
            this.labelControl20.Text = "Departamento:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(706, 63);
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
            this.btnAceptar.Location = new System.Drawing.Point(624, 63);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 18;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmManRutaDetalleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 93);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManRutaDetalleEdit";
            this.Text = "Seleccionar Ubigeo";
            this.Load += new System.EventHandler(this.frmManRutaDetalleEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        public DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnAceptar;
        public DevExpress.XtraEditors.LookUpEdit cboDepartamento;
        public DevExpress.XtraEditors.LookUpEdit cboProvincia;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        public DevExpress.XtraEditors.LookUpEdit cboDistrito;
    }
}