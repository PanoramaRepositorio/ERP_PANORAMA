namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
	partial class frmManLineaProductoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManLineaProductoEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLineaProducto = new DevExpress.XtraEditors.TextEdit();
            this.cboFamilia = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineaProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFamilia.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(402, 98);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(321, 98);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.cboFamilia);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtNumero);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.btnGrabar);
            this.grdDatos.Controls.Add(this.txtLineaProducto);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(485, 129);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 52);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(41, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Número:";
            // 
            // txtNumero
            // 
            this.txtNumero.EditValue = "0";
            this.txtNumero.Location = new System.Drawing.Point(74, 49);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Properties.DisplayFormat.FormatString = "f0";
            this.txtNumero.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtNumero.Properties.Mask.EditMask = "f0";
            this.txtNumero.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtNumero.Properties.MaxLength = 4;
            this.txtNumero.Size = new System.Drawing.Size(65, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.ToolTip = "Periodo";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 75);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Descripcion:";
            // 
            // txtLineaProducto
            // 
            this.txtLineaProducto.Location = new System.Drawing.Point(74, 72);
            this.txtLineaProducto.Name = "txtLineaProducto";
            this.txtLineaProducto.Size = new System.Drawing.Size(403, 20);
            this.txtLineaProducto.TabIndex = 3;
            // 
            // cboFamilia
            // 
            this.cboFamilia.Location = new System.Drawing.Point(74, 24);
            this.cboFamilia.Name = "cboFamilia";
            this.cboFamilia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFamilia.Properties.NullText = "";
            this.cboFamilia.Size = new System.Drawing.Size(181, 20);
            this.cboFamilia.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 27);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Familia:";
            // 
            // frmManLineaProductoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 128);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManLineaProductoEdit";
            this.Load += new System.EventHandler(this.frmManLineaProductoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineaProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFamilia.Properties)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtLineaProducto;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboFamilia;

    }
}