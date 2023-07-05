namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    partial class frmManDescuentoClienteFechaCompraEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManDescuentoClienteFechaCompraEdit));
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboLineaProducto = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboFormaPago = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescuento = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineaProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.deFechaHasta);
            this.grdDatos.Controls.Add(this.deFechaDesde);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.labelControl8);
            this.grdDatos.Controls.Add(this.cboTipoCliente);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.cboLineaProducto);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.cboFormaPago);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.txtDescuento);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(406, 146);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.Text = "Datos";
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(299, 94);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 9;
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(93, 93);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 7;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(243, 97);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(50, 13);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Fecha Fin:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 97);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(61, 13);
            this.labelControl8.TabIndex = 6;
            this.labelControl8.Text = "Fecha Inicio:";
            // 
            // cboTipoCliente
            // 
            this.cboTipoCliente.Location = new System.Drawing.Point(93, 27);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoCliente.Properties.NullText = "";
            this.cboTipoCliente.Size = new System.Drawing.Size(306, 20);
            this.cboTipoCliente.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 30);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Tipo Cliente:";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 120);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(55, 13);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Descuento:";
            // 
            // cboLineaProducto
            // 
            this.cboLineaProducto.Location = new System.Drawing.Point(93, 72);
            this.cboLineaProducto.Name = "cboLineaProducto";
            this.cboLineaProducto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLineaProducto.Properties.NullText = "";
            this.cboLineaProducto.Size = new System.Drawing.Size(306, 20);
            this.cboLineaProducto.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(75, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Línea Producto:";
            // 
            // cboFormaPago
            // 
            this.cboFormaPago.Location = new System.Drawing.Point(93, 50);
            this.cboFormaPago.Name = "cboFormaPago";
            this.cboFormaPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFormaPago.Properties.NullText = "";
            this.cboFormaPago.Size = new System.Drawing.Size(306, 20);
            this.cboFormaPago.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Forma Pago:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.EditValue = "0.00";
            this.txtDescuento.Location = new System.Drawing.Point(93, 117);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Properties.Appearance.Options.UseFont = true;
            this.txtDescuento.Properties.DisplayFormat.FormatString = "n2";
            this.txtDescuento.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDescuento.Properties.Mask.EditMask = "n2";
            this.txtDescuento.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDescuento.Properties.Mask.ShowPlaceHolders = false;
            this.txtDescuento.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtDescuento.Size = new System.Drawing.Size(100, 20);
            this.txtDescuento.TabIndex = 11;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(321, 152);
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
            this.btnGrabar.Location = new System.Drawing.Point(240, 152);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmManDescuentoClienteFechaCompraEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 186);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManDescuentoClienteFechaCompraEdit";
            this.Load += new System.EventHandler(this.frmManDescuentoClienteFechaCompraEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLineaProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFormaPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grdDatos;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.LookUpEdit cboLineaProducto;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboFormaPago;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.TextEdit txtDescuento;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        public DevExpress.XtraEditors.LookUpEdit cboTipoCliente;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.DateEdit deFechaHasta;
        public DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}