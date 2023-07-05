using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Utils;

namespace ErpPanorama.Presentation.Modulos.Finanzas.Registros
{
    public partial class frmRegPrestamoBanco : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        List<PrestamoBancoBE> mLista = new List<PrestamoBancoBE>();
        List<PrestamoBancoDetalleBE> mListaDetalle = new List<PrestamoBancoDetalleBE>();

        #endregion

        #region "Eventos"
        public frmRegPrestamoBanco()
        {
            InitializeComponent();
        }

        private void frmRegPrestamoBanco_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();

            BSUtils.LoaderLook(cboSituacion, CargarSituacion(), "Descripcion", "Id", false);
            cboSituacion.EditValue = 350;

            Cargar();
        }


        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegPrestamoBancoEdit objManPrestamoBanco = new frmRegPrestamoBancoEdit();
                objManPrestamoBanco.lstPrestamoBanco = mLista;
                objManPrestamoBanco.pOperacion = frmRegPrestamoBancoEdit.Operacion.Nuevo;
                objManPrestamoBanco.IdPrestamoBanco = 0;
                objManPrestamoBanco.IdCuentaBanco = 0; // Convert.ToInt32(cboBanco.EditValue);
                objManPrestamoBanco.StartPosition = FormStartPosition.CenterParent;
                objManPrestamoBanco.ShowDialog();
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
                        PrestamoBancoBE objE_PrestamoBanco = new PrestamoBancoBE();
                        objE_PrestamoBanco.IdPrestamoBanco = int.Parse(gvPrestamoBanco.GetFocusedRowCellValue("IdPrestamoBanco").ToString());
                        objE_PrestamoBanco.Usuario = Parametros.strUsuarioLogin;
                        objE_PrestamoBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PrestamoBanco.IdEmpresa = Parametros.intEmpresaId;

                        PrestamoBancoBL objBL_PrestamoBanco = new PrestamoBancoBL();
                        objBL_PrestamoBanco.Elimina(objE_PrestamoBanco);
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

        private void tblMenu_PrintClick()
        {
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //    List<ReportePrestamoBancoBE> lstReporte = null;
            //    lstReporte = new ReportePrestamoBancoBL().Listado(Parametros.intEmpresaId, 0);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptPrestamoBanco = new RptVistaReportes();
            //            objRptPrestamoBanco.VerRptPrestamoBanco(lstReporte);
            //            objRptPrestamoBanco.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPrestamoBancos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPrestamoBanco.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPrestamoBanco_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void gvPrestamoBanco_RowClick(object sender, RowClickEventArgs e)
        {
            if (gvPrestamoBanco.RowCount > 0)
            {
                int IdPrestamoBanco = 0;
                IdPrestamoBanco = int.Parse(gvPrestamoBanco.GetFocusedRowCellValue("IdPrestamoBanco").ToString());

                mListaDetalle = new PrestamoBancoDetalleBL().ListaTodosActivo(IdPrestamoBanco, 0);
                gcPrestamoBancoDetalle.DataSource = mListaDetalle;
            }
        }

        private void gvPrestamoBanco_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPrestamoBanco.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocCuenta = View.GetRowCellValue(e.RowHandle, View.Columns["NumeroCuenta"]);
                    object objDocCargo = View.GetRowCellValue(e.RowHandle, View.Columns["CuentaCargo"]);
                    if (objDocCuenta != null)
                    {
                        if (objDocCuenta.ToString() != objDocCargo.ToString())
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Métodos"
        private void Cargar()
        {
            mLista = new PrestamoBancoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboSituacion.EditValue));
            gcPrestamoBanco.DataSource = mLista;
            lblTotalRegistros.Text = gvPrestamoBanco.RowCount.ToString() + " Registros";
        }

        //private void CargarBusqueda()
        //{
        //    gcPrestamoBanco.DataSource = mLista.Where(obj =>
        //                                           obj.DescBanco.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        //}

        public void InicializarModificar()
        {
            if (gvPrestamoBanco.RowCount > 0)
            {
                PrestamoBancoBE objPrestamoBanco = new PrestamoBancoBE();
                objPrestamoBanco.IdPrestamoBanco = int.Parse(gvPrestamoBanco.GetFocusedRowCellValue("IdPrestamoBanco").ToString());
                objPrestamoBanco.IdCuentaBanco = int.Parse(gvPrestamoBanco.GetFocusedRowCellValue("IdCuentaBanco").ToString());

                frmRegPrestamoBancoEdit objManPrestamoBancoEdit = new frmRegPrestamoBancoEdit();
                objManPrestamoBancoEdit.pOperacion = frmRegPrestamoBancoEdit.Operacion.Modificar;
                objManPrestamoBancoEdit.IdPrestamoBanco = objPrestamoBanco.IdPrestamoBanco;
                objManPrestamoBancoEdit.IdCuentaBanco = objPrestamoBanco.IdCuentaBanco;
                objManPrestamoBancoEdit.StartPosition = FormStartPosition.CenterParent;
                objManPrestamoBancoEdit.ShowDialog();

                int intFoco = gvPrestamoBanco.FocusedRowHandle;
                Cargar();
                gvPrestamoBanco.FocusedRowHandle = intFoco;

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

            if (gvPrestamoBanco.GetFocusedRowCellValue("IdPrestamoBanco").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Prestamo Banco", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        private DataTable CargarSituacion()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "TODOS";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 283;
            dr["Descripcion"] = "PENDIENTES";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 284;
            dr["Descripcion"] = "CANCELADO";
            dt.Rows.Add(dr);
            return dt;
        }

        #endregion

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void cboSituacion_EditValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}