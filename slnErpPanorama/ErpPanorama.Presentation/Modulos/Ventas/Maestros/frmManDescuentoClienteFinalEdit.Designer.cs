namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManDescuentoClienteFinalEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManDescuentoClienteFinalEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.cboTipoPrecio = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.chkOpcional = new DevExpress.XtraEditors.CheckEdit();
            this.txtPorDesc = new DevExpress.XtraEditors.TextEdit();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidadMax = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtCantidadMin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboClasificacion = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoPrecio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpcional.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorDesc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasificacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.cboClasificacion);
            this.grdDatos.Controls.Add(this.cboTipoPrecio);
            this.grdDatos.Controls.Add(this.labelControl13);
            this.grdDatos.Controls.Add(this.chkOpcional);
            this.grdDatos.Controls.Add(this.txtPorDesc);
            this.grdDatos.Controls.Add(this.labelControl17);
            this.grdDatos.Controls.Add(this.txtCantidadMax);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtCantidadMin);
            this.grdDatos.Controls.Add(this.labelControl7);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(308, 118);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // cboTipoPrecio
            // 
            this.cboTipoPrecio.Location = new System.Drawing.Point(86, 68);
            this.cboTipoPrecio.Name = "cboTipoPrecio";
            this.cboTipoPrecio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoPrecio.Properties.NullText = "";
            this.cboTipoPrecio.Size = new System.Drawing.Size(65, 20);
            this.cboTipoPrecio.TabIndex = 7;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(6, 71);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(56, 13);
            this.labelControl13.TabIndex = 6;
            this.labelControl13.Text = "Tipo Precio:";
            // 
            // chkOpcional
            // 
            this.chkOpcional.Location = new System.Drawing.Point(3, 94);
            this.chkOpcional.Name = "chkOpcional";
            this.chkOpcional.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkOpcional.Properties.Appearance.Options.UseFont = true;
            this.chkOpcional.Properties.Caption = "Opcional";
            this.chkOpcional.Size = new System.Drawing.Size(75, 19);
            this.chkOpcional.TabIndex = 10;
            // 
            // txtPorDesc
            // 
            this.txtPorDesc.EditValue = "0";
            this.txtPorDesc.Location = new System.Drawing.Point(233, 69);
            this.txtPorDesc.Name = "txtPorDesc";
            this.txtPorDesc.Properties.DisplayFormat.FormatString = "n";
            this.txtPorDesc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPorDesc.Properties.Mask.EditMask = "n";
            this.txtPorDesc.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPorDesc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPorDesc.Size = new System.Drawing.Size(45, 20);
            this.txtPorDesc.TabIndex = 9;
            // 
            // labelControl17
            // 
            this.labelControl17.Location = new System.Drawing.Point(157, 72);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(72, 13);
            this.labelControl17.TabIndex = 8;
            this.labelControl17.Text = "% Descuento :";
            // 
            // txtCantidadMax
            // 
            this.txtCantidadMax.EditValue = "0";
            this.txtCantidadMax.Location = new System.Drawing.Point(233, 46);
            this.txtCantidadMax.Name = "txtCantidadMax";
            this.txtCantidadMax.Properties.DisplayFormat.FormatString = "f0";
            this.txtCantidadMax.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCantidadMax.Properties.Mask.EditMask = "f0";
            this.txtCantidadMax.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCantidadMax.Properties.MaxLength = 4;
            this.txtCantidadMax.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCantidadMax.Size = new System.Drawing.Size(65, 20);
            this.txtCantidadMax.TabIndex = 5;
            this.txtCantidadMax.ToolTip = "Periodo";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(157, 50);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Cantidad Max:";
            // 
            // txtCantidadMin
            // 
            this.txtCantidadMin.EditValue = "0";
            this.txtCantidadMin.Location = new System.Drawing.Point(86, 46);
            this.txtCantidadMin.Name = "txtCantidadMin";
            this.txtCantidadMin.Properties.DisplayFormat.FormatString = "f0";
            this.txtCantidadMin.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCantidadMin.Properties.Mask.EditMask = "f0";
            this.txtCantidadMin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCantidadMin.Properties.MaxLength = 4;
            this.txtCantidadMin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCantidadMin.Size = new System.Drawing.Size(65, 20);
            this.txtCantidadMin.TabIndex = 3;
            this.txtCantidadMin.ToolTip = "Periodo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(6, 49);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(66, 13);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Cantidad Min:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(223, 124);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(137, 124);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 28);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Clasificación: ";
            // 
            // cboClasificacion
            // 
            this.cboClasificacion.Location = new System.Drawing.Point(86, 25);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboClasificacion.Properties.NullText = "";
            this.cboClasificacion.Size = new System.Drawing.Size(212, 20);
            this.cboClasificacion.TabIndex = 1;
            // 
            // frmManDescuentoClienteFinalEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 159);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManDescuentoClienteFinalEdit";
            this.Load += new System.EventHandler(this.frmManDescuentoClienteFinalEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoPrecio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpcional.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorDesc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboClasificacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.TextEdit txtCantidadMin;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        public DevExpress.XtraEditors.TextEdit txtCantidadMax;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPorDesc;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.CheckEdit chkOpcional;
        public DevExpress.XtraEditors.LookUpEdit cboTipoPrecio;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboClasificacion;
    }
}