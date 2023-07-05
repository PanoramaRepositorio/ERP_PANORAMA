namespace ErpPanorama.Presentation.Modulos.Maestros.Consultas
{
    partial class frmConConexiones
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblTotalRegistros = new DevExpress.XtraEditors.LabelControl();
            this.bntConsultar = new DevExpress.XtraEditors.SimpleButton();
            this.gcConexionSQL = new DevExpress.XtraGrid.GridControl();
            this.gvConexionSQL = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcConexionSQL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConexionSQL)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblTotalRegistros);
            this.groupControl1.Controls.Add(this.bntConsultar);
            this.groupControl1.Controls.Add(this.gcConexionSQL);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1607, 531);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Conexiones Entrantes";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalRegistros.Location = new System.Drawing.Point(35, 502);
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(54, 13);
            this.lblTotalRegistros.TabIndex = 2;
            this.lblTotalRegistros.Text = "0 Registros";
            // 
            // bntConsultar
            // 
            this.bntConsultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bntConsultar.Image = global::ErpPanorama.Presentation.Properties.Resources.Consultar_16x16;
            this.bntConsultar.Location = new System.Drawing.Point(581, 496);
            this.bntConsultar.Name = "bntConsultar";
            this.bntConsultar.Size = new System.Drawing.Size(263, 25);
            this.bntConsultar.TabIndex = 1;
            this.bntConsultar.Text = "&Consultar F5";
            this.bntConsultar.Click += new System.EventHandler(this.bntConsultar_Click);
            // 
            // gcConexionSQL
            // 
            this.gcConexionSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcConexionSQL.Location = new System.Drawing.Point(2, 21);
            this.gcConexionSQL.MainView = this.gvConexionSQL;
            this.gcConexionSQL.Name = "gcConexionSQL";
            this.gcConexionSQL.Size = new System.Drawing.Size(1605, 469);
            this.gcConexionSQL.TabIndex = 0;
            this.gcConexionSQL.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvConexionSQL});
            // 
            // gvConexionSQL
            // 
            this.gvConexionSQL.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.gvConexionSQL.GridControl = this.gcConexionSQL;
            this.gvConexionSQL.Name = "gvConexionSQL";
            this.gvConexionSQL.OptionsSelection.MultiSelect = true;
            this.gvConexionSQL.OptionsView.ColumnAutoWidth = false;
            this.gvConexionSQL.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Sesión";
            this.gridColumn1.FieldName = "session_id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 51;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "HostName";
            this.gridColumn2.FieldName = "hostname";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 124;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "F. Conexion";
            this.gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "login_time";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 121;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Último Proceso";
            this.gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "last_batch";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 119;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Transporte";
            this.gridColumn5.FieldName = "net_transport";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 102;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "N° Lecturas";
            this.gridColumn6.FieldName = "num_reads";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowFocus = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 67;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "N° Escrituras";
            this.gridColumn7.FieldName = "num_writes";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.AllowFocus = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 76;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "last_read";
            this.gridColumn8.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn8.FieldName = "last_read";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.AllowFocus = false;
            this.gridColumn8.Width = 69;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "last_write";
            this.gridColumn9.DisplayFormat.FormatString = "dd/MM/yyyy hh:mm tt";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn9.FieldName = "last_write";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.Width = 104;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tamaño Paquete";
            this.gridColumn10.FieldName = "net_packet_size";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.AllowFocus = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 10;
            this.gridColumn10.Width = 93;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Dirección IP";
            this.gridColumn11.FieldName = "client_net_address";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 2;
            this.gridColumn11.Width = 113;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Tamaño Paquete";
            this.gridColumn12.FieldName = "net_packet_size";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.AllowFocus = false;
            this.gridColumn12.Width = 103;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "CPU";
            this.gridColumn13.FieldName = "cpu";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowFocus = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 11;
            this.gridColumn13.Width = 51;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Status";
            this.gridColumn14.FieldName = "status";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowFocus = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            this.gridColumn14.Width = 84;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Programa";
            this.gridColumn15.FieldName = "program_name";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.OptionsColumn.AllowFocus = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 12;
            this.gridColumn15.Width = 256;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Proceso Host";
            this.gridColumn16.FieldName = "hostprocess";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.OptionsColumn.AllowFocus = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 14;
            this.gridColumn16.Width = 89;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Comando";
            this.gridColumn17.FieldName = "cmd";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.AllowEdit = false;
            this.gridColumn17.OptionsColumn.AllowFocus = false;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 4;
            this.gridColumn17.Width = 114;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Login";
            this.gridColumn18.FieldName = "loginame";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.AllowEdit = false;
            this.gridColumn18.OptionsColumn.AllowFocus = false;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 13;
            this.gridColumn18.Width = 95;
            // 
            // frmConConexiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1607, 531);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmConConexiones";
            this.Text = "Consulta - Conexiones";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmConConexiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcConexionSQL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvConexionSQL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcConexionSQL;
        private DevExpress.XtraGrid.Views.Grid.GridView gvConexionSQL;
        private DevExpress.XtraEditors.SimpleButton bntConsultar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.LabelControl lblTotalRegistros;

    }
}