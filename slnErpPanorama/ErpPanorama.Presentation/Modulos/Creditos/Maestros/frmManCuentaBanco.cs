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
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Creditos.Maestros
{
    public partial class frmManCuentaBanco : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<CuentaBancoBE> mLista = new List<CuentaBancoBE>();

        #endregion

        #region "Eventos"

        public frmManCuentaBanco()
        {
            InitializeComponent();
        }

        private void frmManCuentaBanco_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            //BSUtils.LoaderLook(cboBanco, new BancoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescBanco", "IdBanco", true);
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManCuentaBancoEdit objManCuentaBanco = new frmManCuentaBancoEdit();
                objManCuentaBanco.lstCuentaBanco = mLista;
                objManCuentaBanco.pOperacion = frmManCuentaBancoEdit.Operacion.Nuevo;
                objManCuentaBanco.IdCuentaBanco = 0;
                objManCuentaBanco.IdBanco = 0; // Convert.ToInt32(cboBanco.EditValue);
                objManCuentaBanco.StartPosition = FormStartPosition.CenterParent;
                objManCuentaBanco.ShowDialog();
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
                        CuentaBancoBE objE_CuentaBanco = new CuentaBancoBE();
                        objE_CuentaBanco.IdCuentaBanco = int.Parse(gvCuentaBanco.GetFocusedRowCellValue("IdCuentaBanco").ToString());
                        objE_CuentaBanco.Usuario = Parametros.strUsuarioLogin;
                        objE_CuentaBanco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_CuentaBanco.IdEmpresa = Parametros.intEmpresaId;

                        CuentaBancoBL objBL_CuentaBanco = new CuentaBancoBL();
                        objBL_CuentaBanco.Elimina(objE_CuentaBanco);
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
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteCuentaBancoBE> lstReporte = null;
                lstReporte = new ReporteCuentaBancoBL().Listado(Parametros.intEmpresaId, 0);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptCuentaBanco = new RptVistaReportes();
                        objRptCuentaBanco.VerRptCuentaBanco(lstReporte);
                        objRptCuentaBanco.ShowDialog();
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
            string _fileName = "ListadoCuentaBancos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCuentaBanco.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCuentaBanco_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CuentaBancoBL().ListaTodosActivo(0);
            gcCuentaBanco.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCuentaBanco.DataSource = mLista.Where(obj =>
                                                   obj.DescBanco.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCuentaBanco.RowCount > 0)
            {
                CuentaBancoBE objCuentaBanco = new CuentaBancoBE();
                objCuentaBanco.IdCuentaBanco = int.Parse(gvCuentaBanco.GetFocusedRowCellValue("IdCuentaBanco").ToString());
                objCuentaBanco.IdBanco = int.Parse(gvCuentaBanco.GetFocusedRowCellValue("IdBanco").ToString());

                frmManCuentaBancoEdit objManCuentaBancoEdit = new frmManCuentaBancoEdit();
                objManCuentaBancoEdit.pOperacion = frmManCuentaBancoEdit.Operacion.Modificar;
                objManCuentaBancoEdit.IdCuentaBanco = objCuentaBanco.IdCuentaBanco;
                objManCuentaBancoEdit.IdBanco = objCuentaBanco.IdBanco;
                objManCuentaBancoEdit.StartPosition = FormStartPosition.CenterParent;
                objManCuentaBancoEdit.ShowDialog();

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

            if (gvCuentaBanco.GetFocusedRowCellValue("IdCuentaBanco").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Cuenta Banco", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {

        }





    }
}