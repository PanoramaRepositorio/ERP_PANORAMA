namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    partial class frmBusCliente
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
            this.components = new System.ComponentModel.Container();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.cboPagina = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCantidadRegistros = new DevExpress.XtraEditors.TextEdit();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.gcCliente = new DevExpress.XtraGrid.GridControl();
            this.gvCliente = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(56, 6);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(505, 20);
            this.txtDescripcion.TabIndex = 10;
            this.txtDescripcion.EditValueChanged += new System.EventHandler(this.txtDescripcion_EditValueChanged);
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(13, 9);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(37, 13);
            this.lblPersona.TabIndex = 9;
            this.lblPersona.Text = "Cliente:";
            // 
            // cboPagina
            // 
            this.cboPagina.Location = new System.Drawing.Point(296, 441);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPagina.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboPagina.Size = new System.Drawing.Size(46, 20);
            this.cboPagina.TabIndex = 16;
            this.cboPagina.EditValueChanged += new System.EventHandler(this.cboPagina_EditValueChanged);
            // 
            // txtCantidadRegistros
            // 
            this.txtCantidadRegistros.EditValue = "18";
            this.txtCantidadRegistros.Location = new System.Drawing.Point(343, 441);
            this.txtCantidadRegistros.Name = "txtCantidadRegistros";
            this.txtCantidadRegistros.Properties.Mask.EditMask = "\\d{0,3}";
            this.txtCantidadRegistros.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCantidadRegistros.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCantidadRegistros.Size = new System.Drawing.Size(30, 20);
            this.txtCantidadRegistros.TabIndex = 17;
            this.txtCantidadRegistros.EditValueChanged += new System.EventHandler(this.txtCantidadRegistros_EditValueChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(234, 441);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 20);
            this.btnNext.TabIndex = 14;
            this.btnNext.Tag = "";
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(265, 441);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 20);
            this.btnLast.TabIndex = 15;
            this.btnLast.Tag = "";
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(203, 441);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 20);
            this.btnPrevious.TabIndex = 13;
            this.btnPrevious.Tag = "";
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(172, 441);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 20);
            this.btnFirst.TabIndex = 12;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // gcCliente
            // 
            this.gcCliente.Location = new System.Drawing.Point(-4, 34);
            this.gcCliente.MainView = this.gvCliente;
            this.gcCliente.Name = "gcCliente";
            this.gcCliente.Size = new System.Drawing.Size(580, 401);
            this.gcCliente.TabIndex = 20;
            this.gcCliente.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCliente});
            // 
            // gvCliente
            // 
            this.gvCliente.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn25,
            this.gridColumn24,
            this.gridColumn1,
            this.gridColumn23,
            this.gridColumn18,
            this.gridColumn3,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gvCliente.GridControl = this.gcCliente;
            this.gvCliente.Name = "gvCliente";
            this.gvCliente.OptionsView.ShowGroupPanel = false;
            this.gvCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvCliente_KeyDown);
            this.gvCliente.DoubleClick += new System.EventHandler(this.gvCliente_DoubleClick);
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "IdCliente";
            this.gridColumn25.FieldName = "IdCliente";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.AllowEdit = false;
            this.gridColumn25.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "IdEmpresa";
            this.gridColumn24.FieldName = "IdEmpresa";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.AllowEdit = false;
            this.gridColumn24.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Documento";
            this.gridColumn1.FieldName = "AbrevDocumento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 70;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "N° Documento";
            this.gridColumn23.FieldName = "NumeroDocumento";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.OptionsColumn.AllowEdit = false;
            this.gridColumn23.OptionsColumn.AllowFocus = false;
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 1;
            this.gridColumn23.Width = 100;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Cliente";
            this.gridColumn18.FieldName = "DescCliente";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            this.gridColumn18.Width = 380;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "AbrevDomicilio";
            this.gridColumn3.FieldName = "AbrevDomicilio";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Dirección";
            this.gridColumn2.FieldName = "Direccion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "NumDireccion";
            this.gridColumn4.FieldName = "NumDireccion";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IdTipoCliente";
            this.gridColumn6.FieldName = "IdTipoCliente";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "DescTipoCliente";
            this.gridColumn5.FieldName = "DescTipoCliente";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "IdClasificacionCliente";
            this.gridColumn7.FieldName = "IdClasificacionCliente";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "DescClasificacionCliente";
            this.gridColumn8.FieldName = "DescClasificacionCliente";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "FechaNac";
            this.gridColumn9.FieldName = "FechaNac";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmBusCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 466);
            this.Controls.Add(this.gcCliente);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblPersona);
            this.Controls.Add(this.cboPagina);
            this.Controls.Add(this.txtCantidadRegistros);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBusCliente";
            this.Text = "Búsqueda Cliente";
            this.Load += new System.EventHandler(this.frmBusCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LabelControl lblPersona;
        private DevExpress.XtraEditors.ComboBoxEdit cboPagina;
        private DevExpress.XtraEditors.TextEdit txtCantidadRegistros;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnLast;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private DevExpress.XtraEditors.SimpleButton btnFirst;
        private DevExpress.XtraGrid.GridControl gcCliente;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCliente;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private System.Windows.Forms.Timer timer1;
    }
}