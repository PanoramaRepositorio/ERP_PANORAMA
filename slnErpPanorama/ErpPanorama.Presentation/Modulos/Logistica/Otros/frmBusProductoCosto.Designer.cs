namespace ErpPanorama.Presentation.Modulos.Logistica.Otros
{
    partial class frmBusProductoCosto
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
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.lblPersona = new DevExpress.XtraEditors.LabelControl();
            this.cboPagina = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtCantidadRegistros = new DevExpress.XtraEditors.TextEdit();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnLast = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnFirst = new DevExpress.XtraEditors.SimpleButton();
            this.gcProducto = new DevExpress.XtraGrid.GridControl();
            this.gvProducto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.picImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(63, 12);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(338, 20);
            this.txtDescripcion.TabIndex = 47;
            this.txtDescripcion.EditValueChanged += new System.EventHandler(this.txtDescripcion_EditValueChanged);
            this.txtDescripcion.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDescripcion_KeyUp);
            // 
            // lblPersona
            // 
            this.lblPersona.Location = new System.Drawing.Point(10, 15);
            this.lblPersona.Name = "lblPersona";
            this.lblPersona.Size = new System.Drawing.Size(47, 13);
            this.lblPersona.TabIndex = 48;
            this.lblPersona.Text = "Producto:";
            // 
            // cboPagina
            // 
            this.cboPagina.Location = new System.Drawing.Point(397, 484);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPagina.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboPagina.Size = new System.Drawing.Size(46, 20);
            this.cboPagina.TabIndex = 59;
            this.cboPagina.EditValueChanged += new System.EventHandler(this.cboPagina_EditValueChanged);
            // 
            // txtCantidadRegistros
            // 
            this.txtCantidadRegistros.EditValue = "18";
            this.txtCantidadRegistros.Location = new System.Drawing.Point(444, 484);
            this.txtCantidadRegistros.Name = "txtCantidadRegistros";
            this.txtCantidadRegistros.Properties.Mask.EditMask = "\\d{0,3}";
            this.txtCantidadRegistros.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtCantidadRegistros.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCantidadRegistros.Size = new System.Drawing.Size(30, 20);
            this.txtCantidadRegistros.TabIndex = 60;
            this.txtCantidadRegistros.EditValueChanged += new System.EventHandler(this.txtCantidadRegistros_EditValueChanged);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(335, 484);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 20);
            this.btnNext.TabIndex = 57;
            this.btnNext.Tag = "";
            this.btnNext.Text = ">";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(366, 484);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(30, 20);
            this.btnLast.TabIndex = 58;
            this.btnLast.Tag = "";
            this.btnLast.Text = ">>";
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(304, 484);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(30, 20);
            this.btnPrevious.TabIndex = 56;
            this.btnPrevious.Tag = "";
            this.btnPrevious.Text = "<";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(273, 484);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(30, 20);
            this.btnFirst.TabIndex = 55;
            this.btnFirst.Text = "<<";
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // gcProducto
            // 
            this.gcProducto.Location = new System.Drawing.Point(1, 91);
            this.gcProducto.MainView = this.gvProducto;
            this.gcProducto.Name = "gcProducto";
            this.gcProducto.Size = new System.Drawing.Size(828, 387);
            this.gcProducto.TabIndex = 54;
            this.gcProducto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvProducto});
            // 
            // gvProducto
            // 
            this.gvProducto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn11,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn9,
            this.gridColumn4,
            this.gridColumn7,
            this.gridColumn3,
            this.gridColumn8,
            this.gridColumn6});
            this.gvProducto.GridControl = this.gcProducto;
            this.gvProducto.Name = "gvProducto";
            this.gvProducto.OptionsView.ColumnAutoWidth = false;
            this.gvProducto.OptionsView.ShowGroupPanel = false;
            this.gvProducto.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvProducto_FocusedRowChanged);
            this.gvProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvProducto_KeyDown);
            this.gvProducto.DoubleClick += new System.EventHandler(this.gvProducto_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdProducto";
            this.gridColumn1.FieldName = "IdProducto";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "IdLineaProducto";
            this.gridColumn11.FieldName = "IdLineaProducto";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Código";
            this.gridColumn2.FieldName = "CodigoProveedor";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 120;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Descripción";
            this.gridColumn5.FieldName = "NombreProducto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 343;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Medida";
            this.gridColumn9.FieldName = "Medida";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "U.M";
            this.gridColumn4.FieldName = "Abreviatura";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 45;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Ubicación";
            this.gridColumn7.FieldName = "DescUbicacion";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 60;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceCell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceCell.Options.UseForeColor = true;
            this.gridColumn3.Caption = "Stock";
            this.gridColumn3.FieldName = "Cantidad";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 50;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Costo Unitario US$";
            this.gridColumn8.DisplayFormat.FormatString = "#,0.00";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "CostoUnitario";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Costo Unitario S/";
            this.gridColumn6.FieldName = "CostoUnitarioSoles";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            // 
            // picImage
            // 
            this.picImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImage.Location = new System.Drawing.Point(745, 2);
            this.picImage.Margin = new System.Windows.Forms.Padding(1);
            this.picImage.MinimumSize = new System.Drawing.Size(85, 85);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(85, 85);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 64;
            this.picImage.TabStop = false;
            // 
            // frmBusProductoCosto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 509);
            this.Controls.Add(this.picImage);
            this.Controls.Add(this.cboPagina);
            this.Controls.Add(this.txtCantidadRegistros);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.gcProducto);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblPersona);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBusProductoCosto";
            this.Text = "Búsqueda Producto";
            this.Load += new System.EventHandler(this.frmBusProductoCosto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPagina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadRegistros.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
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
        private DevExpress.XtraGrid.GridControl gcProducto;
        private DevExpress.XtraGrid.Views.Grid.GridView gvProducto;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.PictureBox picImage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}