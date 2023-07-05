using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ErpPanorama.Presentation
{
    public class WaitDialog : Form
    {
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabNumero;
        private DevExpress.XtraTab.XtraTabPage xtraTabBoolean;
        private DevExpress.XtraTab.XtraTabPage xtraTabCadena;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcSueldo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSueldo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private Button button1;
        private DevExpress.Utils.WaitDialogForm dlg = null;

        public void CreateWaitDialog()
        {
            dlg = new DevExpress.Utils.WaitDialogForm("Loading Components...");
        }

        public void CreateWaitDialog(string Titulo, string Mensaje)
        {
            dlg = new DevExpress.Utils.WaitDialogForm(Mensaje, Titulo);
        }

        public void CreateWaitDialog(string Titulo, string Mensaje, Size size, Form frm)
        {
            dlg = new DevExpress.Utils.WaitDialogForm(Mensaje, Titulo, size, frm);
        }

        public void SetWaitDialogCaption(string fCaption)
        {
            if (dlg != null)
                dlg.Caption = fCaption;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (dlg != null) dlg.Close();
        }

        public void Cerrar()
        {
            dlg.Close();
        }

        private void InitializeComponent()
        {
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabNumero = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcSueldo = new DevExpress.XtraGrid.GridControl();
            this.gvSueldo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabBoolean = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabCadena = new DevExpress.XtraTab.XtraTabPage();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabNumero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSueldo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSueldo)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Location = new System.Drawing.Point(110, 23);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabNumero;
            this.xtraTabControl1.Size = new System.Drawing.Size(302, 185);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabNumero,
            this.xtraTabBoolean,
            this.xtraTabCadena});
            // 
            // xtraTabNumero
            // 
            this.xtraTabNumero.Controls.Add(this.groupControl1);
            this.xtraTabNumero.Name = "xtraTabNumero";
            this.xtraTabNumero.Size = new System.Drawing.Size(296, 157);
            this.xtraTabNumero.Text = "Configuración";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.gcSueldo);
            this.groupControl1.Location = new System.Drawing.Point(8, 14);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(285, 317);
            this.groupControl1.TabIndex = 3;
            // 
            // gcSueldo
            // 
            this.gcSueldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSueldo.Location = new System.Drawing.Point(2, 20);
            this.gcSueldo.MainView = this.gvSueldo;
            this.gcSueldo.Name = "gcSueldo";
            this.gcSueldo.Size = new System.Drawing.Size(281, 295);
            this.gcSueldo.TabIndex = 0;
            this.gcSueldo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSueldo});
            // 
            // gvSueldo
            // 
            this.gvSueldo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gvSueldo.GridControl = this.gcSueldo;
            this.gvSueldo.Name = "gvSueldo";
            this.gvSueldo.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Parametro";
            this.gridColumn1.FieldName = "IdParametro";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 199;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Valor";
            this.gridColumn2.FieldName = "Numero";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 259;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Descripción";
            this.gridColumn3.FieldName = "Descripcion";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowFocus = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 367;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Número";
            this.gridColumn4.FieldName = "Numero";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.AllowFocus = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "FlagEstado";
            this.gridColumn5.FieldName = "FlagEstado";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            // 
            // xtraTabBoolean
            // 
            this.xtraTabBoolean.Name = "xtraTabBoolean";
            this.xtraTabBoolean.Size = new System.Drawing.Size(296, 157);
            this.xtraTabBoolean.Text = "Estado";
            // 
            // xtraTabCadena
            // 
            this.xtraTabCadena.Name = "xtraTabCadena";
            this.xtraTabCadena.Size = new System.Drawing.Size(296, 157);
            this.xtraTabCadena.Text = "Cadena";
            // 
            // button1
            // 
            this.button1.Image = global::ErpPanorama.Presentation.Properties.Resources.Feriado_32x32;
            this.button1.Location = new System.Drawing.Point(496, 239);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // WaitDialog
            // 
            this.ClientSize = new System.Drawing.Size(916, 414);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "WaitDialog";
            this.Load += new System.EventHandler(this.WaitDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabNumero.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSueldo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSueldo)).EndInit();
            this.ResumeLayout(false);

        }

        private void WaitDialog_Load(object sender, EventArgs e)
        {
   
        }

    }
}
