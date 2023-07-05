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
    public partial class frmManMarca : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MarcaBE> mLista = new List<MarcaBE>();

        #endregion

        #region "Eventos"

        public frmManMarca()
        {
            InitializeComponent();
        }

        private void frmManMarca_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManMarcaEdit objManMarca = new frmManMarcaEdit();
                objManMarca.lstMarca = mLista;
                objManMarca.pOperacion = frmManMarcaEdit.Operacion.Nuevo;
                objManMarca.IdMarca = 0;
                objManMarca.StartPosition = FormStartPosition.CenterParent;
                objManMarca.ShowDialog();
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
                        MarcaBE objE_Marca = new MarcaBE();
                        objE_Marca.IdMarca = int.Parse(gvMarca.GetFocusedRowCellValue("IdMarca").ToString());
                        objE_Marca.Usuario = Parametros.strUsuarioLogin;
                        objE_Marca.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Marca.IdEmpresa = Parametros.intEmpresaId;

                        MarcaBL objBL_Marca = new MarcaBL();
                        objBL_Marca.Elimina(objE_Marca);
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

                List<ReporteMarcaBE> lstReporte = null;
                lstReporte = new ReporteMarcaBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptMarca= new RptVistaReportes();
                        objRptMarca.VerRptMarca(lstReporte);
                        objRptMarca.ShowDialog();
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
            string _fileName = "ListadoMarcaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMarca.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMarca_DoubleClick(object sender, EventArgs e)
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
            mLista = new MarcaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcMarca.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcMarca.DataSource = mLista.Where(obj =>
                                                   obj.DescMarca.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvMarca.RowCount > 0)
            {
                MarcaBE objMarca = new MarcaBE();
                objMarca.IdMarca = int.Parse(gvMarca.GetFocusedRowCellValue("IdMarca").ToString());
                objMarca.DescMarca = gvMarca.GetFocusedRowCellValue("DescMarca").ToString();
                objMarca.FlagEstado = Convert.ToBoolean(gvMarca.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManMarcaEdit objManMarcaEdit = new frmManMarcaEdit();
                objManMarcaEdit.pOperacion = frmManMarcaEdit.Operacion.Modificar;
                objManMarcaEdit.IdMarca = objMarca.IdMarca;
                objManMarcaEdit.pMarcaBE = objMarca;
                objManMarcaEdit.StartPosition = FormStartPosition.CenterParent;
                objManMarcaEdit.ShowDialog();

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

            if (gvMarca.GetFocusedRowCellValue("IdMarca").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Marca", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
        
    }
}