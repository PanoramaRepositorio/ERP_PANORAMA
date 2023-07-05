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

namespace ErpPanorama.Presentation.Modulos.Maestros.Otros
{
    public partial class frmBuscaTablaElemento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<TablaElementoBE> mLista = new List<TablaElementoBE>();
        public List<TablaElementoBE> pListaProducto { get; set; }
        public TablaElementoBE pTablaElementoBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }
        public int IdTabla = 0;
        
        #endregion

        #region "Eventos"

        public frmBuscaTablaElemento()
        {
            InitializeComponent();
        }

        private void frmBuscaTablaElemento_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvTablaElemento_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvTablaElemento_KeyDown(object sender, KeyEventArgs e)
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
            mLista = new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, IdTabla);
            gcTablaElemento.DataSource = mLista;
        }

        private void SeleccionarRegistro()
        {
            if (gvTablaElemento.RowCount > 0)
            {
                TablaElementoBE objProducto = new TablaElementoBE();
                if (pFlagMultiSelect)
                {
                    List<TablaElementoBE> lista = new List<TablaElementoBE>();
                    foreach (int i in gvTablaElemento.GetSelectedRows())
                    {
                        objProducto = (TablaElementoBE)gvTablaElemento.GetRow(i);
                        lista.Add(objProducto);
                    }
                    pListaProducto = lista;
                }
                else
                {
                    int index = gvTablaElemento.FocusedRowHandle;
                    objProducto = (TablaElementoBE)gvTablaElemento.GetRow(index);
                    pTablaElementoBE = objProducto;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Elemento");
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