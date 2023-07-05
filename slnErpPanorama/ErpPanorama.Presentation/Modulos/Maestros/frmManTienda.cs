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

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManTienda : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TiendaBE> mLista = new List<TiendaBE>();
           
        #endregion

        #region "Eventos"

        public frmManTienda()
        {
            InitializeComponent();
        }

        private void frmManTienda_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaCombo(), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId; //Parametros.intIdPanoramaDistribuidores;

            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTiendaEdit objManTienda = new frmManTiendaEdit();
                objManTienda.lstTienda = mLista;
                objManTienda.pOperacion = frmManTiendaEdit.Operacion.Nuevo;
                objManTienda.IdTienda = 0;
                objManTienda.StartPosition = FormStartPosition.CenterParent;
                objManTienda.ShowDialog();
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
                        TiendaBE objE_Tienda = new TiendaBE();
                        objE_Tienda.IdTienda = int.Parse(gvTienda.GetFocusedRowCellValue("IdTienda").ToString());
                        objE_Tienda.Usuario = Parametros.strUsuarioLogin;
                        objE_Tienda.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Tienda.IdEmpresa = Parametros.intEmpresaId;

                        TiendaBL objBL_Tienda = new TiendaBL();
                        objBL_Tienda.Elimina(objE_Tienda);
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

                List<ReporteTiendaBE> lstReporte = null;
                lstReporte = new ReporteTiendaBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptTienda = new RptVistaReportes();
                        objRptTienda.VerRptTienda(lstReporte);
                        objRptTienda.ShowDialog();
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
            string _fileName = "ListadoTiendaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTienda.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTienda_DoubleClick(object sender, EventArgs e)
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
            mLista = new TiendaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue));
            gcTienda.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTienda.DataSource = mLista.Where(obj =>
                                                   obj.DescTienda.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTienda.RowCount > 0)
            {
                TiendaBE objTienda = new TiendaBE();
                objTienda.IdEmpresa = int.Parse(gvTienda.GetFocusedRowCellValue("IdEmpresa").ToString());
                objTienda.IdTienda = int.Parse(gvTienda.GetFocusedRowCellValue("IdTienda").ToString());
                objTienda.DescTienda = gvTienda.GetFocusedRowCellValue("DescTienda").ToString();
                objTienda.Direccion = gvTienda.GetFocusedRowCellValue("Direccion").ToString();
                objTienda.FlagEstado = Convert.ToBoolean(gvTienda.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTiendaEdit objManTiendaEdit = new frmManTiendaEdit();
                objManTiendaEdit.pOperacion = frmManTiendaEdit.Operacion.Modificar;
                objManTiendaEdit.IdTienda = objTienda.IdTienda;
                objManTiendaEdit.pTiendaBE = objTienda;
                objManTiendaEdit.StartPosition = FormStartPosition.CenterParent;
                objManTiendaEdit.ShowDialog();

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

            if (gvTienda.GetFocusedRowCellValue("IdTienda").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Tienda", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            Cargar();
        }


        
    }
}