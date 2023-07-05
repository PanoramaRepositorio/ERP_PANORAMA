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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegClienteCredito : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<ClienteCreditoBE> mLista = new List<ClienteCreditoBE>();

        #endregion

        #region "Eventos"

        public frmRegClienteCredito()
        {
            InitializeComponent();
        }

        private void frmRegClienteCredito_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegClienteCreditoEdit objManClienteCredito = new frmRegClienteCreditoEdit();
                objManClienteCredito.lstClienteCredito = mLista;
                objManClienteCredito.pOperacion = frmRegClienteCreditoEdit.Operacion.Nuevo;
                objManClienteCredito.IdClienteCredito = 0;
                objManClienteCredito.StartPosition = FormStartPosition.CenterParent;
                objManClienteCredito.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                        ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();
                        objE_ClienteCredito.IdClienteCredito = int.Parse(gvClienteCredito.GetFocusedRowCellValue("IdClienteCredito").ToString());
                        objE_ClienteCredito.IdEmpresa = Parametros.intEmpresaId;
                        objE_ClienteCredito.Usuario = Parametros.strUsuarioLogin;
                        objE_ClienteCredito.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        ClienteCreditoBL objBL_ClienteCredito = new ClienteCreditoBL();
                        objBL_ClienteCredito.Elimina(objE_ClienteCredito);
                        XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
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
            Cargar();
        }

        private void tlbMenu_PrintClick()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteClienteCreditoBE> lstReporte = null;
                lstReporte = new ReporteClienteCreditoBL().Listado(Parametros.intEmpresaId,Convert.ToInt32(cboMotivo.EditValue));

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptClienteCredito = new RptVistaReportes();
                        objRptClienteCredito.VerRptClienteCredito(lstReporte);
                        objRptClienteCredito.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string _fileName = "ListadoClienteCreditoles";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvClienteCredito.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvClienteCredito_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtClienteCredito_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusquedaDocumento();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ClienteCreditoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboMotivo.EditValue));
            gcClienteCredito.DataSource = mLista;
        }

        private void CargarBusquedaDocumento()
        {
            gcClienteCredito.DataSource = mLista.Where(obj =>
                                                   obj.DescCliente.ToString().ToUpper().Contains(txtClienteCredito.Text.ToUpper()) ||
                                                   obj.NumeroDocumento.ToString().Contains(txtClienteCredito.Text.ToUpper())
                                             ).ToList();


        }

        public void InicializarModificar()
        {
            if (gvClienteCredito.RowCount > 0)
            {
                ClienteCreditoBE objClienteCredito = new ClienteCreditoBE();
                objClienteCredito.IdClienteCredito = int.Parse(gvClienteCredito.GetFocusedRowCellValue("IdClienteCredito").ToString());

                frmRegClienteCreditoEdit objManClienteCreditoEdit = new frmRegClienteCreditoEdit();
                objManClienteCreditoEdit.pOperacion = frmRegClienteCreditoEdit.Operacion.Modificar;
                objManClienteCreditoEdit.IdClienteCredito = objClienteCredito.IdClienteCredito;
                objManClienteCreditoEdit.StartPosition = FormStartPosition.CenterParent;
                objManClienteCreditoEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
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

            if (gvClienteCredito.GetFocusedRowCellValue("IdClienteCredito").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Cliente Credito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void cboMotivo_EditValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }

        


    }
}