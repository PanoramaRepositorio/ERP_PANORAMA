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
using ErpPanorama.Presentation.Modulos.Ventas.Reportes;
using ErpPanorama.Presentation.Modulos.Ventas.Consultas;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManClienteMayoristaAgenda : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ClienteBE> mLista = new List<ClienteBE>();

        // Variables para paginacion
        private int intPagina = 1;
        private int intRegistrosPorPagina = 0;
        private int intRegistrosTotal = 0;
        private int intPaginaPrimero = 1;
        private int intPaginaUltima = 0;
        
        #endregion

        #region "Eventos"

        public frmManClienteMayoristaAgenda()
        {
            InitializeComponent();
        }

        private void frmManClienteMayoristaAgenda_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            intRegistrosPorPagina = int.Parse(txtCantidadRegistros.Text);
            CalcularPaginas();
            CargarBusqueda(intPagina, intRegistrosPorPagina);
            HabilitarBotones(false, false, true, true);

            CargarBusqueda();
        }

        private void tlbMenu_NewClick()
        {
            XtraMessageBox.Show("Para registrar una agenda, Ud. debe seleccionar al cliente y elegir la opción editar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);

            //try
            //{
            //    frmManClienteMayoristaAgendaEdit objManClientel = new frmManClienteMayoristaAgendaEdit();
            //    objManClientel.lstCliente = mLista;
            //    objManClientel.pOperacion = frmManClienteMayoristaAgendaEdit.Operacion.Nuevo;
            //    objManClientel.IdCliente = 0;
            //    objManClientel.StartPosition = FormStartPosition.CenterParent;
            //    objManClientel.ShowDialog();
            //    CargarBusqueda();
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_EditClick()
        {
            InicializarModificar();
        }

        private void tlbMenu_DeleteClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        ClienteBE objE_Clientel = new ClienteBE();
                        objE_Clientel.IdCliente = int.Parse(gvCliente.GetFocusedRowCellValue("IdCliente").ToString());
                        objE_Clientel.Usuario = Parametros.strUsuarioLogin;
                        objE_Clientel.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Clientel.IdEmpresa = Parametros.intEmpresaId;

                        ClienteBL objBL_Cliente = new ClienteBL();
                        objBL_Cliente.Elimina(objE_Clientel);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarBusqueda();
                    }
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_RefreshClick()
        {
            CargarBusqueda();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvCliente.RowCount > 0)
                {
                    List<ReporteClienteListaGeneralBE> lstReporte = null;
                    lstReporte = new ReporteClienteListaGeneralBL().ListadoGeneral(Parametros.intEmpresaId);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptMovimientoAlmacen = new RptVistaReportes();
                            objRptMovimientoAlmacen.VerRptClienteGeneral(lstReporte);
                            objRptMovimientoAlmacen.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoClienteles";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCliente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCliente_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtCliente_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
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
            gcCliente.DataSource = new ClienteBL().SeleccionaBusqueda(Parametros.intEmpresaId, Parametros.intTipClienteMayorista, txtCliente.Text, pagina, registros,0);
        }

        private void CargarBusqueda()
        {
            gcCliente.DataSource = new ClienteBL().SeleccionaBusqueda(Parametros.intEmpresaId, Parametros.intTipClienteMayorista, txtCliente.Text, intPaginaPrimero, intRegistrosPorPagina,0);
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

        public void InicializarModificar()
        {
            if (gvCliente.RowCount > 0)
            {
                ClienteBE objCliente = new ClienteBE();
                objCliente.IdCliente = int.Parse(gvCliente.GetFocusedRowCellValue("IdCliente").ToString());
                objCliente.DescCliente = gvCliente.GetFocusedRowCellValue("DescCliente").ToString();

                frmManClienteMayoristaAgendaEdit objManClienteEdit = new frmManClienteMayoristaAgendaEdit();
                objManClienteEdit.pOperacion = frmManClienteMayoristaAgendaEdit.Operacion.Modificar;
                objManClienteEdit.IdCliente = objCliente.IdCliente;
                objManClienteEdit.DescCliente = objCliente.DescCliente;
                objManClienteEdit.StartPosition = FormStartPosition.CenterParent;
                objManClienteEdit.ShowDialog();

                CargarBusqueda();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
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
            intRowCount = new ClienteBL().SeleccionaBusquedaCount(Parametros.intEmpresaId, Parametros.intTipClienteMayorista, txtCliente.Text,0);
            return intRowCount;
        }


        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvCliente.GetFocusedRowCellValue("IdCliente").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

       
    }
}