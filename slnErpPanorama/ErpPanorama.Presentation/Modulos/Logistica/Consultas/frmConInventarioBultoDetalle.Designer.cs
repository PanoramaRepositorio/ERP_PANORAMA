namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    partial class frmConInventarioBultoDetalle
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
            this.gcInventarioBultoDetalle = new DevExpress.XtraGrid.GridControl();
            this.gvInventarioBultoDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUnidadMedida = new DevExpress.XtraEditors.TextEdit();
            this.lblDescripcion = new DevExpress.XtraEditors.LabelControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.txtNombreProducto = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcInventarioBultoDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInventarioBultoDetalle)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidadMedida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreProducto.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcInventarioBultoDetalle
            // 
            this.gcInventarioBultoDetalle.Location = new System.Drawing.Point(0, 45);
            this.gcInventarioBultoDetalle.MainView = this.gvInventarioBultoDetalle;
            this.gcInventarioBultoDetalle.Name = "gcInventarioBultoDetalle";
            this.gcInventarioBultoDetalle.Size = new System.Drawing.Size(761, 342);
            this.gcInventarioBultoDetalle.TabIndex = 55;
            this.gcInventarioBultoDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvInventarioBultoDetalle});
            // 
            // gvInventarioBultoDetalle
            // 
            this.gvInventarioBultoDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn8,
            this.gridColumn7,
            this.gridColumn6,
            this.gridColumn5,
            this.gridColumn1,
            this.gridColumn10,
            this.gridColumn4,
            this.gridColumn9,
            this.gridColumn11});
            this.gvInventarioBultoDetalle.GridControl = this.gcInventarioBultoDetalle;
            this.gvInventarioBultoDetalle.Name = "gvInventarioBultoDetalle";
            this.gvInventarioBultoDetalle.OptionsView.ColumnAutoWidth = false;
            this.gvInventarioBultoDetalle.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "IdEmpresa";
            this.gridColumn2.FieldName = "IdEmpresa";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Periodo";
            this.gridColumn3.FieldName = "Periodo";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IdAlmacen";
            this.gridColumn8.FieldName = "IdAlmacen";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Almacen";
            this.gridColumn7.FieldName = "DescAlmacen";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 150;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Fecha";
            this.gridColumn6.FieldName = "FechaMovimiento";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "N° Bulto";
            this.gridColumn5.FieldName = "NumeroBulto";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Documento";
            this.gridColumn1.FieldName = "CodTipoDocumento";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "N° Documento";
            this.gridColumn10.FieldName = "NumeroDocumento";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 90;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ingresos";
            this.gridColumn4.FieldName = "Ingresos";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 80;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Salidas";
            this.gridColumn9.FieldName = "Salidas";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            this.gridColumn9.Width = 80;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Stock";
            this.gridColumn11.FieldName = "Stock";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 7;
            this.gridColumn11.Width = 85;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txtUnidadMedida);
            this.panel1.Controls.Add(this.lblDescripcion);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.txtNombreProducto);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(761, 39);
            this.panel1.TabIndex = 56;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(612, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 13);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "U.M:";
            // 
            // txtUnidadMedida
            // 
            this.txtUnidadMedida.Location = new System.Drawing.Point(641, 12);
            this.txtUnidadMedida.Name = "txtUnidadMedida";
            this.txtUnidadMedida.Properties.MaxLength = 50;
            this.txtUnidadMedida.Properties.ReadOnly = true;
            this.txtUnidadMedida.Size = new System.Drawing.Size(50, 20);
            this.txtUnidadMedida.TabIndex = 18;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Location = new System.Drawing.Point(8, 16);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(37, 13);
            this.lblDescripcion.TabIndex = 17;
            this.lblDescripcion.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(51, 13);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.MaxLength = 50;
            this.txtCodigo.Properties.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(137, 20);
            this.txtCodigo.TabIndex = 15;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(194, 13);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Properties.MaxLength = 50;
            this.txtNombreProducto.Properties.ReadOnly = true;
            this.txtNombreProducto.Size = new System.Drawing.Size(412, 20);
            this.txtNombreProducto.TabIndex = 14;
            // 
            // frmConInventarioBultoDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 383);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gcInventarioBultoDetalle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConInventarioBultoDetalle";
            this.Text = "Movimiento Inventario de Bultos";
            this.Load += new System.EventHandler(this.frmConInventarioBultoDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcInventarioBultoDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvInventarioBultoDetalle)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnidadMedida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombreProducto.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcInventarioBultoDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gvInventarioBultoDetalle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUnidadMedida;
        private DevExpress.XtraEditors.LabelControl lblDescripcion;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        private DevExpress.XtraEditors.TextEdit txtNombreProducto;
    }
}