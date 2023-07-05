namespace ErpPanorama.Presentation.Modulos.Finanzas.Maestros
{
    partial class frmManProductoBancoEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManProductoBancoEdit));
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtLineaCredito = new DevExpress.XtraEditors.TextEdit();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.cboBanco = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMontoDisponible = new DevExpress.XtraEditors.TextEdit();
            this.txtMontoUtilizado = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineaCredito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBanco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoDisponible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoUtilizado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 78);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(67, 13);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Línea Crédito:";
            // 
            // txtLineaCredito
            // 
            this.txtLineaCredito.EditValue = "0.00";
            this.txtLineaCredito.Location = new System.Drawing.Point(97, 75);
            this.txtLineaCredito.Name = "txtLineaCredito";
            this.txtLineaCredito.Properties.DisplayFormat.FormatString = "n";
            this.txtLineaCredito.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtLineaCredito.Properties.Mask.EditMask = "n";
            this.txtLineaCredito.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLineaCredito.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtLineaCredito.Size = new System.Drawing.Size(150, 20);
            this.txtLineaCredito.TabIndex = 7;
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(301, 49);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.NullText = "";
            this.cboMoneda.Size = new System.Drawing.Size(173, 20);
            this.cboMoneda.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(253, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Moneda:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 52);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(70, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Tipo Producto:";
            // 
            // cboTipoProducto
            // 
            this.cboTipoProducto.Location = new System.Drawing.Point(97, 49);
            this.cboTipoProducto.Name = "cboTipoProducto";
            this.cboTipoProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoProducto.Properties.NullText = "";
            this.cboTipoProducto.Size = new System.Drawing.Size(150, 20);
            this.cboTipoProducto.TabIndex = 3;
            // 
            // cboBanco
            // 
            this.cboBanco.Location = new System.Drawing.Point(97, 28);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBanco.Properties.NullText = "";
            this.cboBanco.Size = new System.Drawing.Size(377, 20);
            this.cboBanco.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(12, 31);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(33, 13);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Banco:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(399, 115);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.ImageOptions.Image")));
            this.btnGrabar.ImageOptions.ImageIndex = 1;
            this.btnGrabar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(318, 115);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.labelControl8);
            this.grdDatos.Controls.Add(this.txtLineaCredito);
            this.grdDatos.Controls.Add(this.cboMoneda);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.cboTipoProducto);
            this.grdDatos.Controls.Add(this.cboBanco);
            this.grdDatos.Controls.Add(this.lblDescripcion);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(501, 109);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(31, 192);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(67, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Línea Crédito:";
            this.labelControl4.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 166);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Línea Crédito:";
            this.labelControl2.Visible = false;
            // 
            // txtMontoDisponible
            // 
            this.txtMontoDisponible.EditValue = "0.00";
            this.txtMontoDisponible.Location = new System.Drawing.Point(116, 189);
            this.txtMontoDisponible.Name = "txtMontoDisponible";
            this.txtMontoDisponible.Properties.DisplayFormat.FormatString = "n";
            this.txtMontoDisponible.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMontoDisponible.Properties.Mask.EditMask = "n";
            this.txtMontoDisponible.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMontoDisponible.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMontoDisponible.Size = new System.Drawing.Size(150, 20);
            this.txtMontoDisponible.TabIndex = 11;
            this.txtMontoDisponible.Visible = false;
            // 
            // txtMontoUtilizado
            // 
            this.txtMontoUtilizado.EditValue = "0.00";
            this.txtMontoUtilizado.Location = new System.Drawing.Point(116, 163);
            this.txtMontoUtilizado.Name = "txtMontoUtilizado";
            this.txtMontoUtilizado.Properties.DisplayFormat.FormatString = "n";
            this.txtMontoUtilizado.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtMontoUtilizado.Properties.Mask.EditMask = "n";
            this.txtMontoUtilizado.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtMontoUtilizado.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMontoUtilizado.Size = new System.Drawing.Size(150, 20);
            this.txtMontoUtilizado.TabIndex = 9;
            this.txtMontoUtilizado.Visible = false;
            // 
            // frmManProductoBancoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 147);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.txtMontoDisponible);
            this.Controls.Add(this.txtMontoUtilizado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManProductoBancoEdit";
            this.Load += new System.EventHandler(this.frmManProductoBancoEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtLineaCredito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBanco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoDisponible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMontoUtilizado.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl8;
        public DevExpress.XtraEditors.TextEdit txtLineaCredito;
        public DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboTipoProducto;
        public DevExpress.XtraEditors.LookUpEdit cboBanco;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtMontoDisponible;
        public DevExpress.XtraEditors.TextEdit txtMontoUtilizado;
    }
}