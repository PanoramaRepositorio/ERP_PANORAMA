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
    public partial class frmBusClienteAsociado : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        public List<ClienteAsociadoBE> pListaCliente { get; set; }
        public ClienteAsociadoBE pClienteAsociadoBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }

        // Variables para paginacion
        public int IdCliente = 0;
        
        #endregion

        #region "Eventos"

        public frmBusClienteAsociado()
        {
            InitializeComponent();
        }

        private void frmBusClienteAsociado_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvClienteAsociado_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvClienteAsociado_KeyDown(object sender, KeyEventArgs e)
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
            gcClienteAsociado.DataSource = new ClienteAsociadoBL().ListaTodosActivo(Parametros.intEmpresaId, IdCliente);

        }

        private void SeleccionarRegistro()
        {
            if (gvClienteAsociado.RowCount > 0)
            {
                ClienteAsociadoBE objClienteAsociado = new ClienteAsociadoBE();
                if (pFlagMultiSelect)
                {
                    List<ClienteAsociadoBE> lista = new List<ClienteAsociadoBE>();
                    foreach (int i in gvClienteAsociado.GetSelectedRows())
                    {
                        objClienteAsociado = (ClienteAsociadoBE)gvClienteAsociado.GetRow(i);
                        lista.Add(objClienteAsociado);
                    }
                    pListaCliente = lista;
                }
                else
                {
                    int index = gvClienteAsociado.FocusedRowHandle;
                    objClienteAsociado = (ClienteAsociadoBE)gvClienteAsociado.GetRow(index);
                    pClienteAsociadoBE = objClienteAsociado;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Cliente");
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