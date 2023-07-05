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
    public partial class frmManUnidadMedida : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<UnidadMedidaBE> mLista = new List<UnidadMedidaBE>();

        #endregion

        #region "Eventos" 

        public frmManUnidadMedida()
        {
            InitializeComponent();
        }

        private void frmManUnidadMedida_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManUnidadMedidaEdit objManUnidadMedida = new frmManUnidadMedidaEdit();
                objManUnidadMedida.lstUnidadMedida = mLista;
                objManUnidadMedida.pOperacion = frmManUnidadMedidaEdit.Operacion.Nuevo;
                objManUnidadMedida.IdUnidadMedida = 0;
                objManUnidadMedida.StartPosition = FormStartPosition.CenterParent;
                objManUnidadMedida.ShowDialog();
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
                        UnidadMedidaBE objE_UnidadMedida = new UnidadMedidaBE();
                        objE_UnidadMedida.IdUnidadMedida = int.Parse(gvUnidadMedida.GetFocusedRowCellValue("IdUnidadMedida").ToString());
                        objE_UnidadMedida.Usuario = Parametros.strUsuarioLogin;
                        objE_UnidadMedida.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_UnidadMedida.IdEmpresa = Parametros.intEmpresaId;

                        UnidadMedidaBL objBL_UnidadMedida = new UnidadMedidaBL();
                        objBL_UnidadMedida.Elimina(objE_UnidadMedida);
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

                List<ReporteUnidadMedidaBE> lstReporte = null;
                lstReporte = new ReporteUnidadMedidaBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptUnidadMedida = new RptVistaReportes();
                        objRptUnidadMedida.VerRptUnidadMedida(lstReporte);
                        objRptUnidadMedida.ShowDialog();
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
            string _fileName = "ListadoUnidadMedidaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvUnidadMedida.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvUnidadMedida_DoubleClick(object sender, EventArgs e)
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
            mLista = new UnidadMedidaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcUnidadMedida.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcUnidadMedida.DataSource = mLista.Where(obj =>
                                                   obj.DescUnidadMedida.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvUnidadMedida.RowCount > 0)
            {
                UnidadMedidaBE objUnidadMedida = new UnidadMedidaBE();
                objUnidadMedida.IdUnidadMedida = int.Parse(gvUnidadMedida.GetFocusedRowCellValue("IdUnidadMedida").ToString());
                objUnidadMedida.DescUnidadMedida = gvUnidadMedida.GetFocusedRowCellValue("DescUnidadMedida").ToString();
                objUnidadMedida.Abreviatura = gvUnidadMedida.GetFocusedRowCellValue("Abreviatura").ToString();
                objUnidadMedida.IdEmpresa = int.Parse(gvUnidadMedida.GetFocusedRowCellValue("IdEmpresa").ToString());
                objUnidadMedida.FlagEstado = Convert.ToBoolean(gvUnidadMedida.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManUnidadMedidaEdit objManUnidadMedidaEdit = new frmManUnidadMedidaEdit();
                objManUnidadMedidaEdit.pOperacion = frmManUnidadMedidaEdit.Operacion.Modificar;
                objManUnidadMedidaEdit.IdUnidadMedida = objUnidadMedida.IdUnidadMedida;
                objManUnidadMedidaEdit.pUnidadMedidaBE = objUnidadMedida;
                objManUnidadMedidaEdit.StartPosition = FormStartPosition.CenterParent;
                objManUnidadMedidaEdit.ShowDialog();

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

            if (gvUnidadMedida.GetFocusedRowCellValue("IdUnidadMedida").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Unidad de Medida", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}