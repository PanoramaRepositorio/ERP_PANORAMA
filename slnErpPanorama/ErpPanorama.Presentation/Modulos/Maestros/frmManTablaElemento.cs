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

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManTablaElemento : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<TablaElementoBE> mLista = new List<TablaElementoBE>();

        public int IdTabla { get; set; }
        
        #endregion

        #region "Eventos"

        public frmManTablaElemento()
        {
            InitializeComponent();
        }

        private void frmManTablaElemento_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManTablaElementoEdit objManTablaElemento = new frmManTablaElementoEdit();
                objManTablaElemento.lstTablaElemento = mLista;
                objManTablaElemento.pOperacion = frmManTablaElementoEdit.Operacion.Nuevo;
                objManTablaElemento.IdTabla = IdTabla;
                objManTablaElemento.IdTablaElemento = 0;
                objManTablaElemento.StartPosition = FormStartPosition.CenterParent;
                objManTablaElemento.ShowDialog();
                Cargar();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!ValidarIngreso())
                    {
                        TablaElementoBE objE_TablaElemento = new TablaElementoBE();
                        objE_TablaElemento.IdTablaElemento = int.Parse(gvTablaElemento.GetFocusedRowCellValue("IdTablaElemento").ToString());
                        objE_TablaElemento.Usuario = Parametros.strUsuarioLogin;
                        objE_TablaElemento.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TablaElemento.IdEmpresa = Parametros.intEmpresaId;

                        TablaElementoBL objBL_TablaElemento = new TablaElementoBL();
                        objBL_TablaElemento.Elimina(objE_TablaElemento);
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

        private void gvTablaElemento_DoubleClick(object sender, EventArgs e)
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
            mLista = new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, IdTabla);
            gcTablaElemento.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTablaElemento.DataSource = mLista.Where(obj =>
                                                   obj.DescTablaElemento.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTablaElemento.RowCount > 0)
            {
                TablaElementoBE objTablaElemento = new TablaElementoBE();
                objTablaElemento.IdTabla = int.Parse(gvTablaElemento.GetFocusedRowCellValue("IdTabla").ToString());
                objTablaElemento.IdTablaElemento = int.Parse(gvTablaElemento.GetFocusedRowCellValue("IdTablaElemento").ToString());
                objTablaElemento.DescTabla = gvTablaElemento.GetFocusedRowCellValue("DescTabla").ToString();
                objTablaElemento.Abreviatura = gvTablaElemento.GetFocusedRowCellValue("Abreviatura").ToString();
                objTablaElemento.DescTablaElemento = gvTablaElemento.GetFocusedRowCellValue("DescTablaElemento").ToString();
                objTablaElemento.FlagEstado = Convert.ToBoolean(gvTablaElemento.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManTablaElementoEdit objManTablaEdit = new frmManTablaElementoEdit();
                objManTablaEdit.pOperacion = frmManTablaElementoEdit.Operacion.Modificar;
                objManTablaEdit.IdTabla = objTablaElemento.IdTabla;
                objManTablaEdit.IdTablaElemento = objTablaElemento.IdTablaElemento;
                objManTablaEdit.pTablaElementoBE = objTablaElemento;
                objManTablaEdit.StartPosition = FormStartPosition.CenterParent;
                objManTablaEdit.ShowDialog();

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

            if (gvTablaElemento.GetFocusedRowCellValue("IdTablaElemento").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un elemento", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion
        
    }
}