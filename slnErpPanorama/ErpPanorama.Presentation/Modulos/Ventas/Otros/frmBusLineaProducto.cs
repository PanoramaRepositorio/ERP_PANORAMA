using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmBusLineaProducto : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<LineaProductoBE> mLista = new List<LineaProductoBE>();
        public List<LineaProductoBE> pListaProducto { get; set; }
        public LineaProductoBE pLineaProductoBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }
        public int IdAlmacen = 0;
        
        #endregion

        #region "Eventos"

        public frmBusLineaProducto()
        {
            InitializeComponent();
        }

        private void frmBusLineaProducto_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvLineaProducto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvLineaProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarRegistro();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new LineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcLineaProducto.DataSource = mLista;
        }

        private void SeleccionarRegistro()
        {
            if (gvLineaProducto.RowCount > 0)
            {
                LineaProductoBE objProducto = new LineaProductoBE();
                if (pFlagMultiSelect)
                {
                    List<LineaProductoBE> lista = new List<LineaProductoBE>();
                    foreach (int i in gvLineaProducto.GetSelectedRows())
                    {
                        objProducto = (LineaProductoBE)gvLineaProducto.GetRow(i);
                        lista.Add(objProducto);
                    }
                    pListaProducto = lista;
                }
                else
                {
                    int index = gvLineaProducto.FocusedRowHandle;
                    objProducto = (LineaProductoBE)gvLineaProducto.GetRow(index);
                    pLineaProductoBE = objProducto;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Linea Producto");
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                SeleccionarRegistro();
            }
        }

        #endregion

        
    }
}