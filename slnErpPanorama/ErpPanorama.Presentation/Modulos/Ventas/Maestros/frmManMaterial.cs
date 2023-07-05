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

namespace ErpPanorama.Presentation.Modulos.Ventas.Maestros
{
    public partial class frmManMaterial : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        
        private List<MaterialBE> mLista = new List<MaterialBE>();

        #endregion

        #region "Eventos"

        public frmManMaterial()
        {
            InitializeComponent();
        }

        private void frmManMaterial_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManMaterialEdit objManMaterial = new frmManMaterialEdit();
                objManMaterial.lstMaterial = mLista;
                objManMaterial.pOperacion = frmManMaterialEdit.Operacion.Nuevo;
                objManMaterial.IdMaterial = 0;
                objManMaterial.StartPosition = FormStartPosition.CenterParent;
                objManMaterial.ShowDialog();
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
                        MaterialBE objE_Material = new MaterialBE();
                        objE_Material.IdMaterial = int.Parse(gvMaterial.GetFocusedRowCellValue("IdMaterial").ToString());
                        objE_Material.Usuario = Parametros.strUsuarioLogin;
                        objE_Material.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Material.IdEmpresa = Parametros.intEmpresaId;

                        MaterialBL objBL_Material = new MaterialBL();
                        objBL_Material.Elimina(objE_Material);
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

                List<ReporteMaterialBE> lstReporte = null;
                lstReporte = new ReporteMaterialBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMaterial = new RptVistaReportes();
                        objRptMaterial.VerRptMaterial(lstReporte);
                        objRptMaterial.ShowDialog();
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
            string _fileName = "ListadoMateriales";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMaterial.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMaterial_DoubleClick(object sender, EventArgs e)
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
            mLista = new MaterialBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcMaterial.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcMaterial.DataSource = mLista.Where(obj =>
                                                   obj.DescMaterial.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvMaterial.RowCount > 0)
            {
                MaterialBE objMaterial = new MaterialBE();
                objMaterial.IdMaterial = int.Parse(gvMaterial.GetFocusedRowCellValue("IdMaterial").ToString());
                objMaterial.DescMaterial = gvMaterial.GetFocusedRowCellValue("DescMaterial").ToString();
                objMaterial.FlagEstado = Convert.ToBoolean(gvMaterial.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManMaterialEdit objManMaterialEdit = new frmManMaterialEdit();
                objManMaterialEdit.pOperacion = frmManMaterialEdit.Operacion.Modificar;
                objManMaterialEdit.IdMaterial = objMaterial.IdMaterial;
                objManMaterialEdit.pMaterialBE = objMaterial;
                objManMaterialEdit.StartPosition = FormStartPosition.CenterParent;
                objManMaterialEdit.ShowDialog();

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

            if (gvMaterial.GetFocusedRowCellValue("IdMaterial").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Material", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        
    }
}