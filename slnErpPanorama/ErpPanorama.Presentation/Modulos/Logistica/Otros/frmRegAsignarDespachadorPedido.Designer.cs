namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    partial class frmRegAsignarDespachadorPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegAsignarDespachadorPedido));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtBultos = new DevExpress.XtraEditors.TextEdit();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.cboVendedor = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.chkChequeo = new System.Windows.Forms.CheckBox();
            this.chkEmbalaje = new System.Windows.Forms.CheckBox();
            this.chkDespachado = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBultos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl12);
            this.grdDatos.Controls.Add(this.txtBultos);
            this.grdDatos.Controls.Add(this.txtCodigo);
            this.grdDatos.Controls.Add(this.cboVendedor);
            this.grdDatos.Controls.Add(this.lblDescripcion);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(514, 80);
            this.grdDatos.TabIndex = 18;
            this.grdDatos.Text = "Datos";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(346, 52);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(33, 13);
            this.labelControl12.TabIndex = 7;
            this.labelControl12.Text = "Bultos:";
            // 
            // txtBultos
            // 
            this.txtBultos.EditValue = "0";
            this.txtBultos.Location = new System.Drawing.Point(394, 49);
            this.txtBultos.Name = "txtBultos";
            this.txtBultos.Properties.DisplayFormat.FormatString = "f0";
            this.txtBultos.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtBultos.Properties.Mask.EditMask = "f0";
            this.txtBultos.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtBultos.Properties.MaxLength = 4;
            this.txtBultos.Size = new System.Drawing.Size(108, 20);
            this.txtBultos.TabIndex = 8;
            this.txtBultos.ToolTip = "Periodo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(66, 27);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.DisplayFormat.FormatString = "f0";
            this.txtCodigo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 6;
            this.txtCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCodigo_KeyUp);
            // 
            // cboVendedor
            // 
            this.cboVendedor.Location = new System.Drawing.Point(172, 27);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboVendedor.Properties.NullText = "";
            this.cboVendedor.Size = new System.Drawing.Size(330, 20);
            this.cboVendedor.TabIndex = 5;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(15, 30);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(45, 13);
            this.lblDescripcion.TabIndex = 4;
            this.lblDescripcion.Text = "Personal:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(427, 86);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(346, 86);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 19;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // chkChequeo
            // 
            this.chkChequeo.AutoSize = true;
            this.chkChequeo.Location = new System.Drawing.Point(24, 90);
            this.chkChequeo.Name = "chkChequeo";
            this.chkChequeo.Size = new System.Drawing.Size(69, 17);
            this.chkChequeo.TabIndex = 21;
            this.chkChequeo.Text = "&Chequeo";
            this.chkChequeo.UseVisualStyleBackColor = true;
            this.chkChequeo.CheckedChanged += new System.EventHandler(this.chkChequeo_CheckedChanged);
            // 
            // chkEmbalaje
            // 
            this.chkEmbalaje.AutoSize = true;
            this.chkEmbalaje.Location = new System.Drawing.Point(99, 90);
            this.chkEmbalaje.Name = "chkEmbalaje";
            this.chkEmbalaje.Size = new System.Drawing.Size(69, 17);
            this.chkEmbalaje.TabIndex = 22;
            this.chkEmbalaje.Text = "&Embalaje";
            this.chkEmbalaje.UseVisualStyleBackColor = true;
            this.chkEmbalaje.CheckedChanged += new System.EventHandler(this.chkEmbalaje_CheckedChanged);
            // 
            // chkDespachado
            // 
            this.chkDespachado.AutoSize = true;
            this.chkDespachado.Location = new System.Drawing.Point(174, 90);
            this.chkDespachado.Name = "chkDespachado";
            this.chkDespachado.Size = new System.Drawing.Size(85, 17);
            this.chkDespachado.TabIndex = 22;
            this.chkDespachado.Text = "&Despachado";
            this.chkDespachado.UseVisualStyleBackColor = true;
            this.chkDespachado.CheckedChanged += new System.EventHandler(this.chkDespachado_CheckedChanged);
            // 
            // frmRegAsignarDespachadorPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 120);
            this.Controls.Add(this.chkDespachado);
            this.Controls.Add(this.chkEmbalaje);
            this.Controls.Add(this.chkChequeo);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegAsignarDespachadorPedido";
            this.Text = "Asignar Despachador";
            this.Load += new System.EventHandler(this.frmRegAsignarDespachadorPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBultos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboVendedor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        public DevExpress.XtraEditors.LookUpEdit cboVendedor;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        public DevExpress.XtraEditors.TextEdit txtBultos;
        private System.Windows.Forms.CheckBox chkChequeo;
        private System.Windows.Forms.CheckBox chkEmbalaje;
        private System.Windows.Forms.CheckBox chkDespachado;
    }
}