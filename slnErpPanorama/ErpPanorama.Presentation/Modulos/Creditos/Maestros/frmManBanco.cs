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

namespace ErpPanorama.Presentation.Modulos.Creditos.Maestros
{
    public partial class frmManBanco : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<BancoBE> mLista = new List<BancoBE>();

        #endregion

        #region "Eventos"

        public frmManBanco()
        {
            InitializeComponent();
        }

        private void frmManBanco_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManBancoEdit objManBanco = new frmManBancoEdit();
                objManBanco.lstBanco = mLista;
                objManBanco.pOperacion = frmManBancoEdit.Operacion.Nuevo;
                objManBanco.IdBanco = 0;
                objManBanco.StartPosition = FormStartPosition.CenterParent;
                objManBanco.ShowDialog();
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
                        BancoBE objE_Banco = new BancoBE();
                        objE_Banco.IdBanco = int.Parse(gvBanco.GetFocusedRowCellValue("IdBanco").ToString());
                        objE_Banco.Usuario = Parametros.strUsuarioLogin;
                        objE_Banco.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Banco.IdEmpresa = Parametros.intEmpresaId;

                        BancoBL objBL_Banco = new BancoBL();
                        objBL_Banco.Elimina(objE_Banco);
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

                List<ReporteBancoBE> lstReporte = null;
                lstReporte = new ReporteBancoBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptBanco = new RptVistaReportes();
                        objRptBanco.VerRptBanco(lstReporte);
                        objRptBanco.ShowDialog();
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
            string _fileName = "ListadoBancoes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvBanco.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvBanco_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new BancoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcBanco.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcBanco.DataSource = mLista.Where(obj =>
                                                   obj.DescBanco.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvBanco.RowCount > 0)
            {
                BancoBE objBanco = new BancoBE();
                objBanco.IdEmpresa = int.Parse(gvBanco.GetFocusedRowCellValue("IdEmpresa").ToString());
                objBanco.IdBanco = int.Parse(gvBanco.GetFocusedRowCellValue("IdBanco").ToString());
                objBanco.DescBanco = gvBanco.GetFocusedRowCellValue("DescBanco").ToString();
                objBanco.Abreviatura = gvBanco.GetFocusedRowCellValue("Abreviatura").ToString();
                objBanco.FlagEstado = Convert.ToBoolean(gvBanco.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManBancoEdit objManBancoEdit = new frmManBancoEdit();
                objManBancoEdit.pOperacion = frmManBancoEdit.Operacion.Modificar;
                objManBancoEdit.IdBanco = objBanco.IdBanco;
                objManBancoEdit.pBancoBE = objBanco;
                objManBancoEdit.StartPosition = FormStartPosition.CenterParent;
                objManBancoEdit.ShowDialog();

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

            if (gvBanco.GetFocusedRowCellValue("IdBanco").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Banco", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }else
            {
                int IdBan = int.Parse(gvBanco.GetFocusedRowCellValue("IdBanco").ToString());
                if(IdBan == 0)
                {
                    XtraMessageBox.Show("No se puede eliminar el valor por defecto", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    flag = true;
                }

            }

            

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
    }
}