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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegNovioRegalo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<NovioRegaloBE> mLista = new List<NovioRegaloBE>();

        #endregion

        #region "Eventos"
        public frmRegNovioRegalo()
        {
            InitializeComponent();
        }

        private void frmRegNovioRegalo_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            //deDesde.EditValue = DateTime.Now;
            deDesde.EditValue = Convert.ToDateTime("01" + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year).AddMonths(-1); //   DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegNovioRegaloEdit objManNovioRegalo = new frmRegNovioRegaloEdit();
                objManNovioRegalo.pOperacion = frmRegNovioRegaloEdit.Operacion.Nuevo;
                objManNovioRegalo.IdNovioRegalo = 0;
                objManNovioRegalo.StartPosition = FormStartPosition.CenterParent;
                objManNovioRegalo.ShowDialog();
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
                        NovioRegaloBE objE_NovioRegalo = new NovioRegaloBE();
                        objE_NovioRegalo.IdNovioRegalo = int.Parse(gvNovioRegalo.GetFocusedRowCellValue("IdNovioRegalo").ToString());
                        objE_NovioRegalo.Usuario = Parametros.strUsuarioLogin;
                        objE_NovioRegalo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_NovioRegalo.IdEmpresa = Parametros.intEmpresaId;

                        NovioRegaloBL objBL_NovioRegalo = new NovioRegaloBL();
                        objBL_NovioRegalo.Elimina(objE_NovioRegalo);
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
                if (mLista.Count > 0)
                {
                    List<ReporteNovioRegaloBE> lstReporte = null;
                    lstReporte = new ReporteNovioRegaloBL().Listado(int.Parse(gvNovioRegalo.GetFocusedRowCellValue("IdNovioRegalo").ToString()), 0);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptNovioRegalo = new RptVistaReportes();
                            objRptNovioRegalo.VerRptNovioRegalo(lstReporte);
                            objRptNovioRegalo.ShowDialog();
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
            string _fileName = "ListadoNovioRegalo";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvNovioRegalo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvNovioRegalo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescCliente_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusquedaCliente();
        }

        private void txtNumeroNovioRegalo_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusquedaNumero();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new NovioRegaloBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcNovioRegalo.DataSource = mLista;
        }

        private void CargarBusquedaCliente()
        {
            gcNovioRegalo.DataSource = mLista.Where(obj =>
                                                   obj.DescNovio.ToUpper().Contains(txtDescCliente.Text.ToUpper())
                                                   || obj.DescNovia.ToUpper().Contains(txtDescCliente.Text.ToUpper())
                                             ).ToList();
        }

        private void CargarBusquedaNumero()
        {
            gcNovioRegalo.DataSource = mLista.Where(obj =>
                                                   obj.Numero.ToString().ToUpper().Contains(txtNumeroNovioRegalo.Text.ToUpper())
                                             ).ToList();
        }

        public void InicializarModificar()
        {
            if (gvNovioRegalo.RowCount > 0)
            {
                NovioRegaloBE objNovioRegalo = new NovioRegaloBE();
                objNovioRegalo.IdNovioRegalo = int.Parse(gvNovioRegalo.GetFocusedRowCellValue("IdNovioRegalo").ToString());

                frmRegNovioRegaloEdit objRegNovioRegaloEdit = new frmRegNovioRegaloEdit();
                objRegNovioRegaloEdit.pOperacion = frmRegNovioRegaloEdit.Operacion.Modificar;
                objRegNovioRegaloEdit.IdNovioRegalo = objNovioRegalo.IdNovioRegalo;
                objRegNovioRegaloEdit.StartPosition = FormStartPosition.CenterParent;
                objRegNovioRegaloEdit.ShowDialog();

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

            if (gvNovioRegalo.GetFocusedRowCellValue("IdNovioRegalo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        private void ImprimirContratotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (mLista.Count > 0)
                {
                    List<ReporteNovioRegaloBE> lstReporte = null;
                    lstReporte = new ReporteNovioRegaloBL().Listado(int.Parse(gvNovioRegalo.GetFocusedRowCellValue("IdNovioRegalo").ToString()), 1);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptNovioRegalo = new RptVistaReportes();
                            objRptNovioRegalo.VerRptNovioRegaloContrato(lstReporte);
                            objRptNovioRegalo.ShowDialog();
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

        private void VerCatalogotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (gvNovioRegalo.RowCount > 0)
                {
                    int IdNovioRegalo = 0;
                    IdNovioRegalo = int.Parse(gvNovioRegalo.GetFocusedRowCellValue("IdNovioRegalo").ToString());

                    List<ReporteProductoCatalogoNovioRegaloBE> lstReporte = null;
                    lstReporte = new ReporteProductoCatalogoNovioRegaloBL().Listado(IdNovioRegalo);

                    if (lstReporte != null)
                    {
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptProductoCatalogoNovioRegalo = new RptVistaReportes();
                            objRptProductoCatalogoNovioRegalo.VerRptProductoCatalogoNovioRegalo(lstReporte);
                            objRptProductoCatalogoNovioRegalo.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}