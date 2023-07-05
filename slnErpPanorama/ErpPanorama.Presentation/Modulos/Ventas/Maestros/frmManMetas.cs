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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManMetas : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MetasBE> mLista = new List<MetasBE>();

        #endregion

        #region "Eventos"
        public frmManMetas()
        {
            InitializeComponent();
        }

        private void frmManMetas_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intEmpresaId;
            txtPeriodo.EditValue = DateTime.Now.Year;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManMetasEdit objManMetas = new frmManMetasEdit();
                objManMetas.lstMetas = mLista;
                objManMetas.pOperacion = frmManMetasEdit.Operacion.Nuevo;
                objManMetas.IdMeta = 0;
                objManMetas.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objManMetas.StartPosition = FormStartPosition.CenterParent;
                if(objManMetas.ShowDialog()==DialogResult.OK)
                {
                    Cargar();
                }
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
                        MetasBE objE_Metas = new MetasBE();
                        objE_Metas.IdMeta = int.Parse(gvMetas.GetFocusedRowCellValue("IdMeta").ToString());
                        objE_Metas.Usuario = Parametros.strUsuarioLogin;
                        objE_Metas.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Metas.IdEmpresa = Parametros.intEmpresaId;

                        MetasBL objBL_Metas = new MetasBL();
                        objBL_Metas.Elimina(objE_Metas);
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

                List<ReporteMetasBE> lstReporte = null;
                lstReporte = new ReporteMetasBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMetas = new RptVistaReportes();
                        objRptMetas.VerRptMetas(lstReporte);
                        objRptMetas.ShowDialog();
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
            string _fileName = "ListadoMetas";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMetas.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMetas_DoubleClick(object sender, EventArgs e)
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
            mLista = new MetasBL().ListaPeriodo(Convert.ToInt32(cboEmpresa.EditValue),Convert.ToInt32(txtPeriodo.EditValue),0);
            gcMetas.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcMetas.DataSource = mLista.Where(obj => obj.DescTienda.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.Cargo.ToUpper().Contains(txtDescripcion.Text.ToUpper()) || obj.NombreMes.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvMetas.RowCount > 0)
            {
                MetasBE objMetas = new MetasBE();
                objMetas.IdMeta = int.Parse(gvMetas.GetFocusedRowCellValue("IdMeta").ToString());
                objMetas.Mes = int.Parse(gvMetas.GetFocusedRowCellValue("Mes").ToString());
                //if (objMetas.Mes < DateTime.Now.Month)
                //{
                //    XtraMessageBox.Show("No se puede modificar la meta de un mes anterior",this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                frmManMetasEdit objManMetasEdit = new frmManMetasEdit();
                objManMetasEdit.pOperacion = frmManMetasEdit.Operacion.Modificar;
                objManMetasEdit.IdMeta = objMetas.IdMeta;
                objManMetasEdit.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                objManMetasEdit.StartPosition = FormStartPosition.CenterParent;
                if (objManMetasEdit.ShowDialog() == DialogResult.OK)
                {
                    int intFoco = gvMetas.FocusedRowHandle;
                    Cargar();
                    gvMetas.FocusedRowHandle = intFoco;
                }
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


            if (gvMetas.GetFocusedRowCellValue("IdMeta").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Meta", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            int Mes = int.Parse(gvMetas.GetFocusedRowCellValue("Mes").ToString());
            if (Mes < DateTime.Now.Month)
            {
                XtraMessageBox.Show("No se puede modificar/eliminar la meta de un mes anterior", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}