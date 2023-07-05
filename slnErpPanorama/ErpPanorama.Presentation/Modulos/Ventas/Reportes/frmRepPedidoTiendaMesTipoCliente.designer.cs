namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    partial class frmRepPedidoTiendaMesTipoCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRepPedidoTiendaMesTipoCliente));
            this.deFechaHasta = new DevExpress.XtraEditors.DateEdit();
            this.deFechaDesde = new DevExpress.XtraEditors.DateEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnVer = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraEditors.GroupControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.txtPeriodo = new DevExpress.XtraEditors.TextEdit();
            this.gcOpciones = new DevExpress.XtraEditors.GroupControl();
            this.optComparativo = new System.Windows.Forms.RadioButton();
            this.optGeneral = new System.Windows.Forms.RadioButton();
            this.optResumen = new System.Windows.Forms.RadioButton();
            this.optVaracion = new System.Windows.Forms.RadioButton();
            this.optDetalle = new System.Windows.Forms.RadioButton();
            this.optCanalVenta = new System.Windows.Forms.RadioButton();
            this.grdDetalle = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.ChkLineaProductoTodo = new System.Windows.Forms.CheckBox();
            this.cboLinea = new DevExpress.XtraEditors.LookUpEdit();
            this.chkTiendaTodo = new System.Windows.Forms.CheckBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboTienda = new DevExpress.XtraEditors.LookUpEdit();
            this.chkEmpresaTodo = new System.Windows.Forms.CheckBox();
            this.cboEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.optRango = new System.Windows.Forms.RadioButton();
            this.optDia = new System.Windows.Forms.RadioButton();
            this.optAnio = new System.Windows.Forms.RadioButton();
            this.optMes = new System.Windows.Forms.RadioButton();
            this.optSemana = new System.Windows.Forms.RadioButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            this.grdDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOpciones)).BeginInit();
            this.gcOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).BeginInit();
            this.grdDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLinea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // deFechaHasta
            // 
            this.deFechaHasta.EditValue = null;
            this.deFechaHasta.Location = new System.Drawing.Point(100, 74);
            this.deFechaHasta.Name = "deFechaHasta";
            this.deFechaHasta.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaHasta.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaHasta.Size = new System.Drawing.Size(100, 20);
            this.deFechaHasta.TabIndex = 21;
            this.deFechaHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaHasta_KeyPress);
            // 
            // deFechaDesde
            // 
            this.deFechaDesde.EditValue = null;
            this.deFechaDesde.Location = new System.Drawing.Point(100, 52);
            this.deFechaDesde.Name = "deFechaDesde";
            this.deFechaDesde.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaDesde.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.deFechaDesde.Size = new System.Drawing.Size(100, 20);
            this.deFechaDesde.TabIndex = 19;
            this.deFechaDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deFechaDesde_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.ImageOptions.Image")));
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(386, 298);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 23;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnVer
            // 
            this.btnVer.ImageOptions.Image = global::ErpPanorama.Presentation.Properties.Resources.m_Reportes_16x16;
            this.btnVer.ImageOptions.ImageIndex = 1;
            this.btnVer.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnVer.Location = new System.Drawing.Point(288, 298);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(92, 23);
            this.btnVer.TabIndex = 22;
            this.btnVer.Text = "Ver Informe";
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Controls.Add(this.textEdit1);
            this.grdDatos.Controls.Add(this.txtPeriodo);
            this.grdDatos.Controls.Add(this.gcOpciones);
            this.grdDatos.Controls.Add(this.grdDetalle);
            this.grdDatos.Controls.Add(this.chkEmpresaTodo);
            this.grdDatos.Controls.Add(this.cboEmpresa);
            this.grdDatos.Controls.Add(this.labelControl8);
            this.grdDatos.Controls.Add(this.optRango);
            this.grdDatos.Controls.Add(this.optDia);
            this.grdDatos.Controls.Add(this.btnCancelar);
            this.grdDatos.Controls.Add(this.btnVer);
            this.grdDatos.Controls.Add(this.deFechaHasta);
            this.grdDatos.Controls.Add(this.optAnio);
            this.grdDatos.Controls.Add(this.deFechaDesde);
            this.grdDatos.Controls.Add(this.optMes);
            this.grdDatos.Controls.Add(this.optSemana);
            this.grdDatos.Controls.Add(this.labelControl3);
            this.grdDatos.Controls.Add(this.labelControl4);
            this.grdDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdDatos.Location = new System.Drawing.Point(0, 0);
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.Size = new System.Drawing.Size(565, 335);
            this.grdDatos.TabIndex = 24;
            this.grdDatos.Text = "Datos";
            this.grdDatos.Paint += new System.Windows.Forms.PaintEventHandler(this.grdDatos_Paint);
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "01";
            this.textEdit1.Location = new System.Drawing.Point(100, 116);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.DisplayFormat.FormatString = "f0";
            this.textEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEdit1.Properties.Mask.EditMask = "f0";
            this.textEdit1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEdit1.Properties.MaxLength = 4;
            this.textEdit1.Size = new System.Drawing.Size(55, 20);
            this.textEdit1.TabIndex = 127;
            this.textEdit1.ToolTip = "Periodo";
            this.textEdit1.Visible = false;
            // 
            // txtPeriodo
            // 
            this.txtPeriodo.EditValue = "2016";
            this.txtPeriodo.Location = new System.Drawing.Point(100, 95);
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Properties.DisplayFormat.FormatString = "f0";
            this.txtPeriodo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPeriodo.Properties.Mask.EditMask = "f0";
            this.txtPeriodo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPeriodo.Properties.MaxLength = 4;
            this.txtPeriodo.Size = new System.Drawing.Size(55, 20);
            this.txtPeriodo.TabIndex = 127;
            this.txtPeriodo.ToolTip = "Periodo";
            this.txtPeriodo.Visible = false;
            // 
            // gcOpciones
            // 
            this.gcOpciones.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.gcOpciones.Controls.Add(this.optComparativo);
            this.gcOpciones.Controls.Add(this.optGeneral);
            this.gcOpciones.Controls.Add(this.optResumen);
            this.gcOpciones.Controls.Add(this.optVaracion);
            this.gcOpciones.Controls.Add(this.optDetalle);
            this.gcOpciones.Controls.Add(this.optCanalVenta);
            this.gcOpciones.Location = new System.Drawing.Point(95, 166);
            this.gcOpciones.Name = "gcOpciones";
            this.gcOpciones.ShowCaption = false;
            this.gcOpciones.Size = new System.Drawing.Size(458, 40);
            this.gcOpciones.TabIndex = 123;
            // 
            // optComparativo
            // 
            this.optComparativo.AutoSize = true;
            this.optComparativo.Location = new System.Drawing.Point(300, 14);
            this.optComparativo.Name = "optComparativo";
            this.optComparativo.Size = new System.Drawing.Size(86, 17);
            this.optComparativo.TabIndex = 129;
            this.optComparativo.Text = "&Comparativo";
            this.optComparativo.UseVisualStyleBackColor = true;
            // 
            // optGeneral
            // 
            this.optGeneral.AutoSize = true;
            this.optGeneral.Checked = true;
            this.optGeneral.Location = new System.Drawing.Point(8, 14);
            this.optGeneral.Name = "optGeneral";
            this.optGeneral.Size = new System.Drawing.Size(62, 17);
            this.optGeneral.TabIndex = 128;
            this.optGeneral.TabStop = true;
            this.optGeneral.Text = "&General";
            this.optGeneral.UseVisualStyleBackColor = true;
            // 
            // optResumen
            // 
            this.optResumen.AutoSize = true;
            this.optResumen.Location = new System.Drawing.Point(228, 14);
            this.optResumen.Name = "optResumen";
            this.optResumen.Size = new System.Drawing.Size(69, 17);
            this.optResumen.TabIndex = 128;
            this.optResumen.Text = "&Resumen";
            this.optResumen.UseVisualStyleBackColor = true;
            // 
            // optVaracion
            // 
            this.optVaracion.AutoSize = true;
            this.optVaracion.Location = new System.Drawing.Point(173, 14);
            this.optVaracion.Name = "optVaracion";
            this.optVaracion.Size = new System.Drawing.Size(49, 17);
            this.optVaracion.TabIndex = 128;
            this.optVaracion.Text = "&Meta";
            this.optVaracion.UseVisualStyleBackColor = true;
            this.optVaracion.CheckedChanged += new System.EventHandler(this.optVaracion_CheckedChanged);
            // 
            // optDetalle
            // 
            this.optDetalle.AutoSize = true;
            this.optDetalle.Location = new System.Drawing.Point(387, 14);
            this.optDetalle.Name = "optDetalle";
            this.optDetalle.Size = new System.Drawing.Size(58, 17);
            this.optDetalle.TabIndex = 128;
            this.optDetalle.Text = "&Detalle";
            this.optDetalle.UseVisualStyleBackColor = true;
            this.optDetalle.CheckedChanged += new System.EventHandler(this.optDetalle_CheckedChanged);
            // 
            // optCanalVenta
            // 
            this.optCanalVenta.AutoSize = true;
            this.optCanalVenta.Location = new System.Drawing.Point(73, 14);
            this.optCanalVenta.Name = "optCanalVenta";
            this.optCanalVenta.Size = new System.Drawing.Size(98, 17);
            this.optCanalVenta.TabIndex = 128;
            this.optCanalVenta.Text = "&Canal de Venta";
            this.optCanalVenta.UseVisualStyleBackColor = true;
            // 
            // grdDetalle
            // 
            this.grdDetalle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.grdDetalle.Controls.Add(this.labelControl1);
            this.grdDetalle.Controls.Add(this.ChkLineaProductoTodo);
            this.grdDetalle.Controls.Add(this.cboLinea);
            this.grdDetalle.Controls.Add(this.chkTiendaTodo);
            this.grdDetalle.Controls.Add(this.labelControl2);
            this.grdDetalle.Controls.Add(this.cboTienda);
            this.grdDetalle.Enabled = false;
            this.grdDetalle.Location = new System.Drawing.Point(26, 212);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.ShowCaption = false;
            this.grdDetalle.Size = new System.Drawing.Size(500, 70);
            this.grdDetalle.TabIndex = 123;
            this.grdDetalle.Text = "Datos de Facturación";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 128;
            this.labelControl1.Text = "Linea:";
            // 
            // ChkLineaProductoTodo
            // 
            this.ChkLineaProductoTodo.AutoSize = true;
            this.ChkLineaProductoTodo.Checked = true;
            this.ChkLineaProductoTodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkLineaProductoTodo.Location = new System.Drawing.Point(431, 37);
            this.ChkLineaProductoTodo.Name = "ChkLineaProductoTodo";
            this.ChkLineaProductoTodo.Size = new System.Drawing.Size(55, 17);
            this.ChkLineaProductoTodo.TabIndex = 127;
            this.ChkLineaProductoTodo.Text = "Todas";
            this.ChkLineaProductoTodo.UseVisualStyleBackColor = true;
            this.ChkLineaProductoTodo.CheckedChanged += new System.EventHandler(this.ChkLineaProductoTodo_CheckedChanged);
            // 
            // cboLinea
            // 
            this.cboLinea.Location = new System.Drawing.Point(56, 35);
            this.cboLinea.Name = "cboLinea";
            this.cboLinea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLinea.Properties.NullText = "";
            this.cboLinea.Size = new System.Drawing.Size(369, 20);
            this.cboLinea.TabIndex = 63;
            // 
            // chkTiendaTodo
            // 
            this.chkTiendaTodo.AutoSize = true;
            this.chkTiendaTodo.Checked = true;
            this.chkTiendaTodo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTiendaTodo.Location = new System.Drawing.Point(431, 15);
            this.chkTiendaTodo.Name = "chkTiendaTodo";
            this.chkTiendaTodo.Size = new System.Drawing.Size(55, 17);
            this.chkTiendaTodo.TabIndex = 67;
            this.chkTiendaTodo.Text = "Todas";
            this.chkTiendaTodo.UseVisualStyleBackColor = true;
            this.chkTiendaTodo.CheckedChanged += new System.EventHandler(this.chkTienda_CheckedChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 13);
            this.labelControl2.TabIndex = 64;
            this.labelControl2.Text = "Tienda: ";
            // 
            // cboTienda
            // 
            this.cboTienda.Enabled = false;
            this.cboTienda.Location = new System.Drawing.Point(56, 12);
            this.cboTienda.Name = "cboTienda";
            this.cboTienda.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboTienda.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cboTienda.Properties.Appearance.Options.UseFont = true;
            this.cboTienda.Properties.Appearance.Options.UseForeColor = true;
            this.cboTienda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTienda.Properties.NullText = "";
            this.cboTienda.Size = new System.Drawing.Size(369, 20);
            this.cboTienda.TabIndex = 66;
            // 
            // chkEmpresaTodo
            // 
            this.chkEmpresaTodo.AutoSize = true;
            this.chkEmpresaTodo.Location = new System.Drawing.Point(457, 27);
            this.chkEmpresaTodo.Name = "chkEmpresaTodo";
            this.chkEmpresaTodo.Size = new System.Drawing.Size(55, 17);
            this.chkEmpresaTodo.TabIndex = 126;
            this.chkEmpresaTodo.Text = "Todas";
            this.chkEmpresaTodo.UseVisualStyleBackColor = true;
            this.chkEmpresaTodo.CheckedChanged += new System.EventHandler(this.chkEmpresaTodo_CheckedChanged);
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.Location = new System.Drawing.Point(82, 24);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEmpresa.Properties.NullText = "";
            this.cboEmpresa.Size = new System.Drawing.Size(369, 20);
            this.cboEmpresa.TabIndex = 125;
            this.cboEmpresa.EditValueChanged += new System.EventHandler(this.cboEmpresa_EditValueChanged);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(26, 27);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(45, 13);
            this.labelControl8.TabIndex = 124;
            this.labelControl8.Text = "Empresa:";
            // 
            // optRango
            // 
            this.optRango.AutoSize = true;
            this.optRango.Checked = true;
            this.optRango.Location = new System.Drawing.Point(25, 188);
            this.optRango.Name = "optRango";
            this.optRango.Size = new System.Drawing.Size(68, 17);
            this.optRango.TabIndex = 26;
            this.optRango.TabStop = true;
            this.optRango.Text = "R. Fecha";
            this.optRango.UseVisualStyleBackColor = true;
            // 
            // optDia
            // 
            this.optDia.AutoSize = true;
            this.optDia.Enabled = false;
            this.optDia.Location = new System.Drawing.Point(26, 165);
            this.optDia.Name = "optDia";
            this.optDia.Size = new System.Drawing.Size(40, 17);
            this.optDia.TabIndex = 26;
            this.optDia.Text = "Dia";
            this.optDia.UseVisualStyleBackColor = true;
            // 
            // optAnio
            // 
            this.optAnio.AutoSize = true;
            this.optAnio.Enabled = false;
            this.optAnio.Location = new System.Drawing.Point(26, 96);
            this.optAnio.Name = "optAnio";
            this.optAnio.Size = new System.Drawing.Size(44, 17);
            this.optAnio.TabIndex = 25;
            this.optAnio.Text = "Año";
            this.optAnio.UseVisualStyleBackColor = true;
            // 
            // optMes
            // 
            this.optMes.AutoSize = true;
            this.optMes.Enabled = false;
            this.optMes.Location = new System.Drawing.Point(26, 119);
            this.optMes.Name = "optMes";
            this.optMes.Size = new System.Drawing.Size(44, 17);
            this.optMes.TabIndex = 24;
            this.optMes.Text = "Mes";
            this.optMes.UseVisualStyleBackColor = true;
            // 
            // optSemana
            // 
            this.optSemana.AutoSize = true;
            this.optSemana.Enabled = false;
            this.optSemana.Location = new System.Drawing.Point(26, 142);
            this.optSemana.Name = "optSemana";
            this.optSemana.Size = new System.Drawing.Size(63, 17);
            this.optSemana.TabIndex = 25;
            this.optSemana.Text = "Semana";
            this.optSemana.UseVisualStyleBackColor = true;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(26, 77);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(67, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Fecha Hasta: ";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(26, 55);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(69, 13);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Fecha Desde: ";
            // 
            // frmRepPedidoTiendaMesTipoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 333);
            this.Controls.Add(this.grdDatos);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRepPedidoTiendaMesTipoCliente";
            this.Text = "Reporte de Ventas  x Tienda x T. Cliente";
            this.Load += new System.EventHandler(this.frmRepPedidoTiendaMesTipoCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaHasta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaDesde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            this.grdDatos.ResumeLayout(false);
            this.grdDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcOpciones)).EndInit();
            this.gcOpciones.ResumeLayout(false);
            this.gcOpciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).EndInit();
            this.grdDetalle.ResumeLayout(false);
            this.grdDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboLinea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTienda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmpresa.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit deFechaHasta;
        private DevExpress.XtraEditors.DateEdit deFechaDesde;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        public DevExpress.XtraEditors.SimpleButton btnVer;
        private DevExpress.XtraEditors.GroupControl grdDatos;
        private System.Windows.Forms.RadioButton optDia;
        private System.Windows.Forms.RadioButton optAnio;
        private System.Windows.Forms.RadioButton optMes;
        private System.Windows.Forms.RadioButton optSemana;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.RadioButton optRango;
        private System.Windows.Forms.CheckBox chkTiendaTodo;
        public DevExpress.XtraEditors.LookUpEdit cboTienda;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        public DevExpress.XtraEditors.LookUpEdit cboLinea;
        private DevExpress.XtraEditors.GroupControl grdDetalle;
        public DevExpress.XtraEditors.LookUpEdit cboEmpresa;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.CheckBox chkEmpresaTodo;
        private System.Windows.Forms.CheckBox ChkLineaProductoTodo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl gcOpciones;
        private System.Windows.Forms.RadioButton optResumen;
        private System.Windows.Forms.RadioButton optCanalVenta;
        private System.Windows.Forms.RadioButton optDetalle;
        private System.Windows.Forms.RadioButton optGeneral;
        private System.Windows.Forms.RadioButton optVaracion;
        public DevExpress.XtraEditors.TextEdit textEdit1;
        public DevExpress.XtraEditors.TextEdit txtPeriodo;
        private System.Windows.Forms.RadioButton optComparativo;
    }
}