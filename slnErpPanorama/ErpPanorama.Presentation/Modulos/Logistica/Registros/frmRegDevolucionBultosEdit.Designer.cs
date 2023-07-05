namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegDevolucionBultosEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegDevolucionBultosEdit));
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.txtObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtAgrupacion = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaIngreso = new DevExpress.XtraEditors.DateEdit();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.txtNumeroBulto = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboBloque = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboSector = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboAlmacen = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombreProducto = new DevExpress.XtraEditors.TextEdit();
            this.txtCantidad = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboGerentePostVenta = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl25 = new DevExpress.XtraEditors.LabelControl();
            this.cboAsesorServicio = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigoProveedor = new DevExpress.XtraEditors.TextEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrupacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIngreso.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIngreso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroBulto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBloque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSector.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreProducto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGerentePostVenta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAsesorServicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageIndex = 0;
            this.btnCancelar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(598, 160);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(77, 104);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservacion.Properties.MaxLength = 50;
            this.txtObservacion.Size = new System.Drawing.Size(393, 40);
            this.txtObservacion.TabIndex = 133;
            this.txtObservacion.UseOptimizedRendering = true;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(9, 107);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(64, 13);
            this.labelControl9.TabIndex = 132;
            this.labelControl9.Text = "Observación:";
            // 
            // txtAgrupacion
            // 
            this.txtAgrupacion.Location = new System.Drawing.Point(430, 79);
            this.txtAgrupacion.Name = "txtAgrupacion";
            this.txtAgrupacion.Properties.MaxLength = 2;
            this.txtAgrupacion.Size = new System.Drawing.Size(40, 20);
            this.txtAgrupacion.TabIndex = 14;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(366, 81);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(58, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Agrupación:";
            // 
            // deFechaIngreso
            // 
            this.deFechaIngreso.EditValue = null;
            this.deFechaIngreso.Location = new System.Drawing.Point(606, 79);
            this.deFechaIngreso.Name = "deFechaIngreso";
            this.deFechaIngreso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaIngreso.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaIngreso.Properties.ReadOnly = true;
            this.deFechaIngreso.Size = new System.Drawing.Size(100, 20);
            this.deFechaIngreso.TabIndex = 16;
            // 
            // lblFecha
            // 
            this.lblFecha.Location = new System.Drawing.Point(524, 82);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(76, 13);
            this.lblFecha.TabIndex = 15;
            this.lblFecha.Text = "Fecha Ingreso: ";
            // 
            // txtNumeroBulto
            // 
            this.txtNumeroBulto.Location = new System.Drawing.Point(246, 79);
            this.txtNumeroBulto.Name = "txtNumeroBulto";
            this.txtNumeroBulto.Properties.MaxLength = 15;
            this.txtNumeroBulto.Size = new System.Drawing.Size(103, 20);
            this.txtNumeroBulto.TabIndex = 12;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(178, 82);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(64, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Código Bulto:";
            // 
            // cboBloque
            // 
            this.cboBloque.Location = new System.Drawing.Point(497, 57);
            this.cboBloque.Name = "cboBloque";
            this.cboBloque.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBloque.Properties.NullText = "";
            this.cboBloque.Size = new System.Drawing.Size(209, 20);
            this.cboBloque.TabIndex = 8;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(455, 60);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Bloque:";
            // 
            // cboSector
            // 
            this.cboSector.Location = new System.Drawing.Point(278, 57);
            this.cboSector.Name = "cboSector";
            this.cboSector.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSector.Properties.NullText = "";
            this.cboSector.Size = new System.Drawing.Size(171, 20);
            this.cboSector.TabIndex = 6;
            this.cboSector.EditValueChanged += new System.EventHandler(this.cboSector_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(237, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(35, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Sector:";
            // 
            // cboAlmacen
            // 
            this.cboAlmacen.Location = new System.Drawing.Point(77, 57);
            this.cboAlmacen.Name = "cboAlmacen";
            this.cboAlmacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAlmacen.Properties.NullText = "";
            this.cboAlmacen.Properties.ReadOnly = true;
            this.cboAlmacen.Size = new System.Drawing.Size(154, 20);
            this.cboAlmacen.TabIndex = 4;
            this.cboAlmacen.EditValueChanged += new System.EventHandler(this.cboAlmacen_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 60);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(44, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Almacén:";
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(186, 35);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Properties.MaxLength = 6;
            this.txtNombreProducto.Properties.ReadOnly = true;
            this.txtNombreProducto.Size = new System.Drawing.Size(520, 20);
            this.txtNombreProducto.TabIndex = 2;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(77, 79);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Properties.DisplayFormat.FormatString = "f0";
            this.txtCantidad.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCantidad.Properties.Mask.EditMask = "f0";
            this.txtCantidad.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtCantidad.Properties.MaxLength = 4;
            this.txtCantidad.Size = new System.Drawing.Size(92, 20);
            this.txtCantidad.TabIndex = 10;
            this.txtCantidad.ToolTip = "Periodo";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(9, 82);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(47, 13);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Cantidad:";
            // 
            // cboGerentePostVenta
            // 
            this.cboGerentePostVenta.Location = new System.Drawing.Point(471, 654);
            this.cboGerentePostVenta.Name = "cboGerentePostVenta";
            this.cboGerentePostVenta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGerentePostVenta.Properties.NullText = "";
            this.cboGerentePostVenta.Size = new System.Drawing.Size(239, 20);
            this.cboGerentePostVenta.TabIndex = 40;
            // 
            // labelControl25
            // 
            this.labelControl25.Location = new System.Drawing.Point(359, 657);
            this.labelControl25.Name = "labelControl25";
            this.labelControl25.Size = new System.Drawing.Size(99, 13);
            this.labelControl25.TabIndex = 39;
            this.labelControl25.Text = "Gerente Post-Venta:";
            // 
            // cboAsesorServicio
            // 
            this.cboAsesorServicio.Location = new System.Drawing.Point(88, 654);
            this.cboAsesorServicio.Name = "cboAsesorServicio";
            this.cboAsesorServicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboAsesorServicio.Properties.NullText = "";
            this.cboAsesorServicio.Size = new System.Drawing.Size(250, 20);
            this.cboAsesorServicio.TabIndex = 38;
            // 
            // labelControl24
            // 
            this.labelControl24.Location = new System.Drawing.Point(12, 657);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(77, 13);
            this.labelControl24.TabIndex = 37;
            this.labelControl24.Text = "Asesor Servicio:";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(77, 35);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Properties.MaxLength = 6;
            this.txtCodigoProveedor.Properties.ReadOnly = true;
            this.txtCodigoProveedor.Size = new System.Drawing.Size(103, 20);
            this.txtCodigoProveedor.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(9, 38);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(47, 13);
            this.lblDescripcion.TabIndex = 0;
            this.lblDescripcion.Text = "Producto:";
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.txtObservacion);
            this.grdDatos.Controls.Add(this.labelControl9);
            this.grdDatos.Controls.Add(this.txtAgrupacion);
            this.grdDatos.Controls.Add(this.labelControl6);
            this.grdDatos.Controls.Add(this.deFechaIngreso);
            this.grdDatos.Controls.Add(this.lblFecha);
            this.grdDatos.Controls.Add(this.txtNumeroBulto);
            this.grdDatos.Controls.Add(this.labelControl5);
            this.grdDatos.Controls.Add(this.cboBloque);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.cboSector);
            this.grdDatos.Controls.Add(this.labelControl2);
            this.grdDatos.Controls.Add(this.cboAlmacen);
            this.grdDatos.Controls.Add(this.labelControl1);
            this.grdDatos.Controls.Add(this.txtNombreProducto);
            this.grdDatos.Controls.Add(this.txtCantidad);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Controls.Add(this.cboGerentePostVenta);
            this.grdDatos.Controls.Add(this.labelControl25);
            this.grdDatos.Controls.Add(this.cboAsesorServicio);
            this.grdDatos.Controls.Add(this.labelControl24);
            this.grdDatos.Controls.Add(this.txtCodigoProveedor);
            this.grdDatos.Controls.Add(this.lblDescripcion);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(712, 151);
            this.grdDatos.TabIndex = 3;
            this.grdDatos.Text = "Datos";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Image = ((System.Drawing.Image)(resources.GetObject("btnGrabar.Image")));
            this.btnGrabar.ImageIndex = 1;
            this.btnGrabar.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnGrabar.Location = new System.Drawing.Point(517, 160);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 4;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // frmRegDevolucionBultosEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 188);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.grdDatos);
            this.Controls.Add(this.btnGrabar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegDevolucionBultosEdit";
            this.Load += new System.EventHandler(this.frmRegDevolucionBultosEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgrupacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIngreso.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaIngreso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumeroBulto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBloque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSector.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreProducto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGerentePostVenta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAsesorServicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.MemoEdit txtObservacion;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtAgrupacion;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.DateEdit deFechaIngreso;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.TextEdit txtNumeroBulto;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        public DevExpress.XtraEditors.LookUpEdit cboBloque;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        public DevExpress.XtraEditors.LookUpEdit cboSector;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboAlmacen;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNombreProducto;
        public DevExpress.XtraEditors.TextEdit txtCantidad;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        public DevExpress.XtraEditors.LookUpEdit cboGerentePostVenta;
        private DevExpress.XtraEditors.LabelControl labelControl25;
        public DevExpress.XtraEditors.LookUpEdit cboAsesorServicio;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.TextEdit txtCodigoProveedor;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        public DevExpress.XtraEditors.SimpleButton btnGrabar;
    }
}