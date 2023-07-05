namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros
{
    partial class frmConAusenciaLeyenda
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
            this.gcMotivoAusencia = new DevExpress.XtraGrid.GridControl();
            this.gvMotivoAusencia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFalta = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit3 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.textEdit5 = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.textEdit6 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textEdit7 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMotivoAusencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMotivoAusencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFalta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMotivoAusencia
            // 
            this.gcMotivoAusencia.Location = new System.Drawing.Point(2, 0);
            this.gcMotivoAusencia.MainView = this.gvMotivoAusencia;
            this.gcMotivoAusencia.Name = "gcMotivoAusencia";
            this.gcMotivoAusencia.Size = new System.Drawing.Size(453, 320);
            this.gcMotivoAusencia.TabIndex = 21;
            this.gcMotivoAusencia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMotivoAusencia});
            // 
            // gvMotivoAusencia
            // 
            this.gvMotivoAusencia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvMotivoAusencia.GridControl = this.gcMotivoAusencia;
            this.gvMotivoAusencia.Name = "gvMotivoAusencia";
            this.gvMotivoAusencia.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "IdMotivoAusencia";
            this.gridColumn1.FieldName = "IdMotivoAusencia";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
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
            this.gridColumn3.Caption = "Descripción";
            this.gridColumn3.FieldName = "DescMotivoAusencia";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 307;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Estado";
            this.gridColumn4.FieldName = "FlagEstado";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Width = 69;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Abrev.";
            this.gridColumn5.FieldName = "Abreviatura";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 128;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(22, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Falta ó Días no Marcados:";
            // 
            // txtFalta
            // 
            this.txtFalta.EditValue = "F";
            this.txtFalta.Location = new System.Drawing.Point(159, 330);
            this.txtFalta.Name = "txtFalta";
            this.txtFalta.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtFalta.Properties.Appearance.Options.UseForeColor = true;
            this.txtFalta.Properties.ReadOnly = true;
            this.txtFalta.Size = new System.Drawing.Size(33, 20);
            this.txtFalta.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(22, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Orden de Concatenación:";
            // 
            // textEdit1
            // 
            this.textEdit1.EditValue = "D";
            this.textEdit1.Location = new System.Drawing.Point(159, 369);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.textEdit1.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit1.Properties.ReadOnly = true;
            this.textEdit1.Size = new System.Drawing.Size(33, 20);
            this.textEdit1.TabIndex = 23;
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "VC";
            this.textEdit2.Location = new System.Drawing.Point(198, 369);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.textEdit2.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit2.Properties.ReadOnly = true;
            this.textEdit2.Size = new System.Drawing.Size(33, 20);
            this.textEdit2.TabIndex = 23;
            // 
            // textEdit3
            // 
            this.textEdit3.EditValue = "JT";
            this.textEdit3.Location = new System.Drawing.Point(237, 369);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.textEdit3.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit3.Properties.ReadOnly = true;
            this.textEdit3.Size = new System.Drawing.Size(33, 20);
            this.textEdit3.TabIndex = 23;
            // 
            // textEdit4
            // 
            this.textEdit4.EditValue = "R";
            this.textEdit4.Location = new System.Drawing.Point(276, 369);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.textEdit4.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit4.Properties.ReadOnly = true;
            this.textEdit4.Size = new System.Drawing.Size(33, 20);
            this.textEdit4.TabIndex = 23;
            // 
            // textEdit5
            // 
            this.textEdit5.EditValue = "A";
            this.textEdit5.Location = new System.Drawing.Point(315, 369);
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.textEdit5.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit5.Properties.ReadOnly = true;
            this.textEdit5.Size = new System.Drawing.Size(33, 20);
            this.textEdit5.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(105, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Ejemplo:";
            // 
            // textEdit6
            // 
            this.textEdit6.EditValue = "DA";
            this.textEdit6.Location = new System.Drawing.Point(159, 399);
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.textEdit6.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit6.Properties.ReadOnly = true;
            this.textEdit6.Size = new System.Drawing.Size(39, 20);
            this.textEdit6.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(204, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "=  Descanso + Asistencia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(89, 352);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Vacaciones:";
            // 
            // textEdit7
            // 
            this.textEdit7.EditValue = "VC";
            this.textEdit7.Location = new System.Drawing.Point(159, 349);
            this.textEdit7.Name = "textEdit7";
            this.textEdit7.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.textEdit7.Properties.Appearance.Options.UseForeColor = true;
            this.textEdit7.Properties.ReadOnly = true;
            this.textEdit7.Size = new System.Drawing.Size(33, 20);
            this.textEdit7.TabIndex = 23;
            // 
            // frmConAusenciaLeyenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 427);
            this.Controls.Add(this.textEdit5);
            this.Controls.Add(this.textEdit4);
            this.Controls.Add(this.textEdit3);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.textEdit6);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.textEdit7);
            this.Controls.Add(this.txtFalta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gcMotivoAusencia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConAusenciaLeyenda";
            this.Text = "Leyenda - Ausencia Personal";
            this.Load += new System.EventHandler(this.frmConAusenciaLeyenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMotivoAusencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMotivoAusencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFalta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit7.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMotivoAusencia;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMotivoAusencia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtFalta;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.TextEdit textEdit5;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit textEdit6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit textEdit7;
    }
}