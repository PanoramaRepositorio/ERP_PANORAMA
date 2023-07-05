namespace ErpPanorama.Presentation.Modulos.MesaAyuda.Registros
{
    partial class frmSincronizaPedido
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
            this.gcMarca1 = new DevExpress.XtraGrid.GridControl();
            this.gvMarca1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMarca2 = new DevExpress.XtraGrid.GridControl();
            this.gvMarca2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.dragDropEvents1 = new DevExpress.Utils.DragDrop.DragDropEvents(this.components);
            this.dragDropEvents2 = new DevExpress.Utils.DragDrop.DragDropEvents(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcMarca1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarca1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMarca2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarca2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMarca1
            // 
            this.gcMarca1.Location = new System.Drawing.Point(12, 38);
            this.gcMarca1.MainView = this.gvMarca1;
            this.gcMarca1.Name = "gcMarca1";
            this.gcMarca1.Size = new System.Drawing.Size(540, 467);
            this.gcMarca1.TabIndex = 0;
            this.gcMarca1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMarca1});
            // 
            // gvMarca1
            // 
            this.behaviorManager1.SetBehaviors(this.gvMarca1, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.DragDrop.DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), true, true, true, this.dragDropEvents1)))});
            this.gvMarca1.GridControl = this.gcMarca1;
            this.gvMarca1.Name = "gvMarca1";
            // 
            // gcMarca2
            // 
            this.gcMarca2.Location = new System.Drawing.Point(558, 38);
            this.gcMarca2.MainView = this.gvMarca2;
            this.gcMarca2.Name = "gcMarca2";
            this.gcMarca2.Size = new System.Drawing.Size(539, 467);
            this.gcMarca2.TabIndex = 1;
            this.gcMarca2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMarca2});
            // 
            // gvMarca2
            // 
            this.behaviorManager1.SetBehaviors(this.gvMarca2, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.DragDrop.DragDropBehavior.Create(typeof(DevExpress.XtraGrid.Extensions.ColumnViewDragDropSource), false, false, false, this.dragDropEvents2)))});
            this.gvMarca2.GridControl = this.gcMarca2;
            this.gvMarca2.Name = "gvMarca2";
            this.gvMarca2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            // 
            // frmSincronizaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 637);
            this.Controls.Add(this.gcMarca2);
            this.Controls.Add(this.gcMarca1);
            this.Name = "frmSincronizaPedido";
            this.Text = "frmSincronizaPedido";
            this.Load += new System.EventHandler(this.frmSincronizaPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMarca1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarca1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMarca2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMarca2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcMarca1;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMarca1;
        private DevExpress.XtraGrid.GridControl gcMarca2;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMarca2;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.Utils.DragDrop.DragDropEvents dragDropEvents1;
        private DevExpress.Utils.DragDrop.DragDropEvents dragDropEvents2;
    }
}