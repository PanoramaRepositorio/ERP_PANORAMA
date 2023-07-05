namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    partial class frmRegTrackingEmbalaje
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
            this.btnFinalizar = new DevExpress.XtraEditors.SimpleButton();
            this.btnIniciar = new DevExpress.XtraEditors.SimpleButton();
            this.txtNumero = new DevExpress.XtraEditors.TextEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gvPedido = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPedido = new DevExpress.XtraGrid.GridControl();
            this.txtCodigo = new DevExpress.XtraEditors.TextEdit();
            this.cboPersona = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPersonalPicking = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPedido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersona.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(811, 35);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(100, 23);
            this.btnFinalizar.TabIndex = 2;
            this.btnFinalizar.Text = "&Finalizar";
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(705, 35);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(100, 23);
            this.btnIniciar.TabIndex = 2;
            this.btnIniciar.Text = "&Iniciar";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(77, 37);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 0;
            this.txtNumero.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNumero_KeyUp);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Cant. Total";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 88;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Items";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 46;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn6.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn6.Caption = "Checkeado Por";
            this.gridColumn6.FieldName = "IdChequeador";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 258;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn5.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn5.Caption = "F. Fin Chequeo";
            this.gridColumn5.FieldName = "FechaChequeado";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 128;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gridColumn4.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn4.Caption = "F. Inicio Chequeo";
            this.gridColumn4.FieldName = "FechaChequeo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 128;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Picking Por";
            this.gridColumn3.FieldName = "IdAuxiliar";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 128;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "F. Picking";
            this.gridColumn2.FieldName = "FechaPicking";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 128;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "N° Pedido";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 66;
            // 
            // gvPedido
            // 
            this.gvPedido.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gvPedido.GridControl = this.gcPedido;
            this.gvPedido.Name = "gvPedido";
            this.gvPedido.OptionsEditForm.BindingMode = DevExpress.XtraGrid.Views.Grid.EditFormBindingMode.Direct;
            this.gvPedido.OptionsView.ShowGroupPanel = false;
            this.gvPedido.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gvPedido.OptionsView.ShowViewCaption = true;
            this.gvPedido.ViewCaption = "SITUACION PEDIDO";
            // 
            // gcPedido
            // 
            this.gcPedido.Location = new System.Drawing.Point(5, 63);
            this.gcPedido.MainView = this.gvPedido;
            this.gcPedido.Name = "gcPedido";
            this.gcPedido.Size = new System.Drawing.Size(988, 184);
            this.gcPedido.TabIndex = 3;
            this.gcPedido.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPedido});
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(315, 37);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Properties.DisplayFormat.FormatString = "f0";
            this.txtCodigo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtCodigo.Size = new System.Drawing.Size(50, 20);
            this.txtCodigo.TabIndex = 5;
            // 
            // cboPersona
            // 
            this.cboPersona.Location = new System.Drawing.Point(371, 37);
            this.cboPersona.Name = "cboPersona";
            this.cboPersona.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.cboPersona.Properties.Appearance.Options.UseForeColor = true;
            this.cboPersona.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPersona.Properties.NullText = "";
            this.cboPersona.Size = new System.Drawing.Size(328, 20);
            this.cboPersona.TabIndex = 6;
            // 
            // lblPersonalPicking
            // 
            this.lblPersonalPicking.Location = new System.Drawing.Point(229, 40);
            this.lblPersonalPicking.Name = "lblPersonalPicking";
            this.lblPersonalPicking.Size = new System.Drawing.Size(80, 13);
            this.lblPersonalPicking.TabIndex = 4;
            this.lblPersonalPicking.Text = "Personal Picking:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "N° Pedido:";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtCodigo);
            this.groupControl1.Controls.Add(this.cboPersona);
            this.groupControl1.Controls.Add(this.lblPersonalPicking);
            this.groupControl1.Controls.Add(this.gcPedido);
            this.groupControl1.Controls.Add(this.btnFinalizar);
            this.groupControl1.Controls.Add(this.btnIniciar);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtNumero);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(998, 297);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Datos";
            // 
            // frmRegTrackingEmbalaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 297);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmRegTrackingEmbalaje";
            this.Text = "frmRegTrackingEmbalaje";
            this.Load += new System.EventHandler(this.frmRegTrackingEmbalaje_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNumero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcPedido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPersona.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnFinalizar;
        private DevExpress.XtraEditors.SimpleButton btnIniciar;
        private DevExpress.XtraEditors.TextEdit txtNumero;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPedido;
        private DevExpress.XtraGrid.GridControl gcPedido;
        private DevExpress.XtraEditors.TextEdit txtCodigo;
        public DevExpress.XtraEditors.LookUpEdit cboPersona;
        private DevExpress.XtraEditors.LabelControl lblPersonalPicking;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
    }
}