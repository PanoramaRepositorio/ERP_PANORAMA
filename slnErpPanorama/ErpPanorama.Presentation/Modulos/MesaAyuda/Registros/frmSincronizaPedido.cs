using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ErpPanorama.Presentation.Modulos.MesaAyuda.Registros
{
    public partial class frmSincronizaPedido : DevExpress.XtraEditors.XtraForm
    {
        List<MarcaBE> mLista = new List<MarcaBE>();
        List<MarcaBE> mLista2 = new List<MarcaBE>();

        int insertedIndex = -1;

        public frmSincronizaPedido()
        {
            InitializeComponent();
        }

        private void frmSincronizaPedido_Load(object sender, EventArgs e)
        {
            Cargar();





            ////behaviorManager1.Attach<DragDropBehavior>(gcMarca2, behavior =>
            ////{
            ////    behavior.DragDrop += Behavior_DragDrop1;
            ////});

            ////behaviorManager1.Attach<DragDropBehavior>(gcMarca1, behavior =>
            ////{
            ////    behavior.DragDrop += Behavior_DragDrop;
            ////});
            ////Controls.Remove(gcMarca2);
            //// xtraScrollableControl1.Controls.Add(gridControl3);
            //XtraUserControl xtraUserControl1 = new XtraUserControl();
            //xtraUserControl1.Size = gcMarca2.Size;
            //xtraUserControl1.Controls.Add(gcMarca2);
            ////xtraScrollableControl1.Controls.Add(xtraUserControl1);


        }
        private void Behavior_DragDrop1(object sender, DevExpress.Utils.DragDrop.DragDropEventArgs e)
        {

        }

        private void Cargar()
        {
            mLista = new MarcaBL().ListaTodosActivo(Parametros.intEmpresaId);
            mLista2 = new MarcaBL().ListaTodosActivo(Parametros.intEmpresaId);

            gcMarca1.DataSource = mLista;
            gcMarca2.DataSource = mLista2;
        }



        private void Behavior_DragDrop(object sender, DevExpress.Utils.DragDrop.DragDropEventArgs e)
        {
            GridControl targetGrid = (e.Target as GridView).GridControl;
            GridControl sourcetGrid = (e.Source as GridView).GridControl;

            GridView view = gvMarca2;// gridView2;
            int[] indexes = (int[])e.Data;
            var targetTable = targetGrid.DataSource as DataTable;
            var sourceTable = sourcetGrid.DataSource as DataTable;

            DataRow tmpRow = targetTable.NewRow();
            tmpRow.ItemArray = sourceTable.Rows[indexes[0]].ItemArray;
            sourceTable.Rows.RemoveAt(indexes[0]);

            GridHitInfo hitInfo = view.CalcHitInfo(targetGrid.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y)));
            insertedIndex = hitInfo.RowHandle;
            if (insertedIndex >= 0)
                targetTable.Rows.InsertAt(tmpRow, insertedIndex);
            else
                targetTable.Rows.InsertAt(tmpRow, targetTable.Rows.Count);
            e.Action = DragDropActions.None;

            string Valor = gvMarca2.GetRowCellValue(insertedIndex, "IdMarca").ToString();
            MessageBox.Show("Cod:" + Valor);
        }



    }
}