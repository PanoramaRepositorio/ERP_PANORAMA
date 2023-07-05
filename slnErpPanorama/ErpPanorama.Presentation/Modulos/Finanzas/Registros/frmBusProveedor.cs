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

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmBusProveedor : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<ProveedorBE> pListaCliente { get; set; }
        public ProveedorBE pProveedorBE { get; set; }
        public Boolean pFlagMultiSelect { get; set; }
        public Boolean pPCredito { get; set; }
        public String pNumeroDescCliente { get; set; }
        public int intTipoBusqueda = 0;

        // Variables para paginacion
        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;
        public int Segundos = 0;

        #endregion

        #region "Eventos"


        public frmBusProveedor()
        {
            InitializeComponent();
        }

        private void frmBusProveedor_Load(object sender, EventArgs e)
        {

                intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);

                HabilitarBotones(false, false, true, true);

                txtDescripcion.Text = pNumeroDescCliente;
            if (gvProveedor.RowCount > 0)
                    gvProveedor.BestFitColumns();

            txtDescripcion.Focus();
        }

        private void txtDescripcion_EditValueChanged(object sender, EventArgs e)
        {
            if (Parametros.bBusquedaTimer)
            {
                timer1.Enabled = true;
                Segundos = 0;
            }
            else
            {
                if (txtDescripcion.Text.ToString().Length >1)
                {
                    if (char.IsNumber(Convert.ToChar(txtDescripcion.Text.Trim().Substring(0, 1))) == true) //Tipo Búsqueda
                        intTipoBusqueda = 1;
                    else
                        intTipoBusqueda = 2;

                    CargarBusqueda();
                }
            }


        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtDescripcion.Text.Length > 1) {
                    SeleccionarRegistro();
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                gcProveedor.Focus();
            }
        }

        private void gvCliente_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SeleccionarRegistro();
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaPrimero;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            cboPagina.EditValue = intPagina;

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            intPagina = intPagina - 1;
            cboPagina.EditValue = intPagina;
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            intPagina = intPagina + 1;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            intPagina = intPaginaUltima;
            cboPagina.EditValue = intPagina;
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);

            CargarBusqueda(intPagina, intRegistrosPorPagina);
        }

        private void txtCantidadRegistros_EditValueChanged(object sender, EventArgs e)
        {
            if (txtCantidadRegistros.Text.Length > 0)
            {
                intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
                CalcularPaginas();
                CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
            }
        }

        private void cboPagina_EditValueChanged(object sender, EventArgs e)
        {
            intPagina = int.Parse(cboPagina.EditValue.ToString());
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);
            CargarBusqueda(int.Parse(cboPagina.EditValue.ToString()), intRegistrosPorPagina);
        }

        #endregion

        #region "Metodos"

        private void CargarBusqueda(int pagina, int registros)
        {
            //if (txtDescripcion.Text.Trim().Length > 2)
            //{
                gcProveedor.DataSource = new ProveedorBL().SeleccionaBusqueda(Parametros.intEmpresaId, 0, txtDescripcion.Text, pagina, registros, intTipoBusqueda);
            //}
        }

        private void CargarBusqueda()
        {
            gcProveedor.DataSource = new ProveedorBL().SeleccionaBusqueda(Parametros.intEmpresaId, 0, txtDescripcion.Text, intPaginaPrimero, intRegistrosPorPagina, intTipoBusqueda);
            //  gcProveedor.DataSource = new ClienteBL().SeleccionaBusqueda(Parametros.intEmpresaId, 0, txtDescripcion.Text, intPaginaPrimero, intRegistrosPorPagina, intTipoBusqueda);
            CalcularPaginas();
            if (intPagina > intPaginaPrimero)
                HabilitarBotones(true, true, true, true);
            if (intPagina < intPaginaUltima)
                HabilitarBotones(true, true, true, true);
            if (intPagina == intPaginaPrimero)
                HabilitarBotones(false, false, true, true);
            if (intPagina == intPaginaUltima)
                HabilitarBotones(true, true, false, false);
            if (intPaginaPrimero == intPaginaUltima)
                HabilitarBotones(false, false, false, false);
        }

        private void SeleccionarRegistro()
        {
            if (gvProveedor.RowCount > 0)
            {
                ProveedorBE objCliente = new ProveedorBE();
                if (pFlagMultiSelect)
                {
                    List<ProveedorBE> lista = new List<ProveedorBE>();
                    foreach (int i in gvProveedor.GetSelectedRows())
                    {
                        objCliente = (ProveedorBE)gvProveedor.GetRow(i);
                        lista.Add(objCliente);
                    }
                    pListaCliente = lista;
                }
                else
                {
                    int index = gvProveedor.FocusedRowHandle;
                    objCliente = (ProveedorBE)gvProveedor.GetRow(index);
                    pProveedorBE = objCliente;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("No existen registros.", "Busqueda Cliente");
            }
        }

        private void CalcularPaginas()
        {
            cboPagina.Properties.Items.Clear();
            intRegistrosTotal = CantidadRegistros();
            if (intRegistrosTotal > 0)
            {
                intPaginaUltima = intRegistrosTotal / intRegistrosPorPagina;
                int Residuo = intRegistrosTotal % intRegistrosPorPagina;
                if (Residuo > 0)
                    intPaginaUltima += 1;
                for (int i = 0; i < intPaginaUltima; i++)
                {
                    cboPagina.Properties.Items.Add(i + 1);
                }
                cboPagina.SelectedIndex = 0;
            }
        }

        private void HabilitarBotones(bool bolFirst, bool bolPrevious, bool bolNext, bool bolLast)
        {
            btnFirst.Enabled = bolFirst;
            btnPrevious.Enabled = bolPrevious;
            btnNext.Enabled = bolNext;
            btnLast.Enabled = bolLast;
        }

        private int CantidadRegistros()
        {
            int intRowCount = 0;
            intRowCount = new ClienteBL().SeleccionaBusquedaCount(Parametros.intEmpresaId, 0, txtDescripcion.Text, intTipoBusqueda);
            return intRowCount;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            Segundos = Segundos + 1;

            if (Segundos > 5)
            {
                if (txtDescripcion.Text.ToString().Length >1)
                {
                    if (char.IsNumber(Convert.ToChar(txtDescripcion.Text.Trim().Substring(0, 1))) == true) //Tipo Búsqueda
                        intTipoBusqueda = 1;
                    else
                        intTipoBusqueda = 2;

                    CargarBusqueda();

                    timer1.Enabled = false;
                }
            }

            if (Segundos > 10)
                timer1.Enabled = false;
        }

    }
}