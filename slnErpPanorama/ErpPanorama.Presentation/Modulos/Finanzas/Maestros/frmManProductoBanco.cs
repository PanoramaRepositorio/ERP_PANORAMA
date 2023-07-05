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

namespace ErpPanorama.Presentation.Modulos.Finanzas.Maestros
{
    public partial class frmManProductoBanco : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        List<BancoProductoBE> mLista = new List<BancoProductoBE>();

        #endregion

        #region "Eventos"

        public frmManProductoBanco()
        {
            InitializeComponent();
        }

        private void frmManProductoBanco_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }


        private void tlbMenu_NewClick()
        {
            try
            {
                frmManProductoBancoEdit objManBancoProducto = new frmManProductoBancoEdit();
                objManBancoProducto.lstBancoProducto = mLista;
                objManBancoProducto.pOperacion = frmManProductoBancoEdit.Operacion.Nuevo;
                objManBancoProducto.IdBancoProducto = 0;
                objManBancoProducto.IdBanco = 0; // Convert.ToInt32(cboBanco.EditValue);
                objManBancoProducto.StartPosition = FormStartPosition.CenterParent;
                objManBancoProducto.ShowDialog();
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
                        BancoProductoBE objE_BancoProducto = new BancoProductoBE();
                        objE_BancoProducto.IdBancoProducto = int.Parse(gvBancoProducto.GetFocusedRowCellValue("IdBancoProducto").ToString());
                        objE_BancoProducto.Usuario = Parametros.strUsuarioLogin;
                        objE_BancoProducto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_BancoProducto.IdEmpresa = Parametros.intEmpresaId;

                        BancoProductoBL objBL_BancoProducto = new BancoProductoBL();
                        objBL_BancoProducto.Elimina(objE_BancoProducto);
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

            //    List<ReporteBancoProductoBE> lstReporte = null;
            //    lstReporte = new ReporteBancoProductoBL().Listado(Parametros.intEmpresaId, 0);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptBancoProducto = new RptVistaReportes();
            //            objRptBancoProducto.VerRptBancoProducto(lstReporte);
            //            objRptBancoProducto.ShowDialog();
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
            string _fileName = "ListadoBancoProductos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvBancoProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvBancoProducto_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }


        #endregion

        #region "Métodos"
        private void Cargar()
        {
            mLista = new BancoProductoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcBancoProducto.DataSource = mLista;
            //lblTotalRegistros.Text = gvBancoProducto.RowCount.ToString() + " Registros";
        }

        //private void CargarBusqueda()
        //{
        //    gcBancoProducto.DataSource = mLista.Where(obj =>
        //                                           obj.DescBanco.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        //}

        public void InicializarModificar()
        {
            if (gvBancoProducto.RowCount > 0)
            {
                BancoProductoBE objBancoProducto = new BancoProductoBE();
                objBancoProducto.IdBancoProducto = int.Parse(gvBancoProducto.GetFocusedRowCellValue("IdBancoProducto").ToString());
                objBancoProducto.IdBanco = int.Parse(gvBancoProducto.GetFocusedRowCellValue("IdBanco").ToString());

                frmManProductoBancoEdit objManBancoProductoEdit = new frmManProductoBancoEdit();
                objManBancoProductoEdit.pOperacion = frmManProductoBancoEdit.Operacion.Modificar;
                objManBancoProductoEdit.IdBancoProducto = objBancoProducto.IdBancoProducto;
                objManBancoProductoEdit.IdBanco = objBancoProducto.IdBanco;
                objManBancoProductoEdit.StartPosition = FormStartPosition.CenterParent;
                objManBancoProductoEdit.ShowDialog();

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

            if (gvBancoProducto.GetFocusedRowCellValue("IdBancoProducto").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Prestamo Banco", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }
        #endregion


    }
}