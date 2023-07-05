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
    public partial class frmManCajaCajero : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<CajaCajeroBE> mLista = new List<CajaCajeroBE>();

        public int IdTienda { get; set; }
        public int IdCaja { get; set; }

        #endregion

        #region "Eventos"

        public frmManCajaCajero()
        {
            InitializeComponent();
        }

        private void frmManCajaCajero_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManCajaCajeroEdit objManCajaCajero = new frmManCajaCajeroEdit();
                objManCajaCajero.lstCajaCajero = mLista;
                objManCajaCajero.pOperacion = frmManCajaCajeroEdit.Operacion.Nuevo;
                objManCajaCajero.IdTienda = IdTienda;
                objManCajaCajero.IdCaja = IdCaja;
                objManCajaCajero.IdCajaCajero = 0;
                objManCajaCajero.StartPosition = FormStartPosition.CenterParent;
                objManCajaCajero.ShowDialog();
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
                        CajaCajeroBE objE_CajaCajero = new CajaCajeroBE();
                        objE_CajaCajero.IdCajaCajero = int.Parse(gvCajaCajero.GetFocusedRowCellValue("IdCajaCajero").ToString());
                        objE_CajaCajero.Usuario = Parametros.strUsuarioLogin;
                        objE_CajaCajero.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_CajaCajero.IdEmpresa = Parametros.intEmpresaId;

                        CajaCajeroBL objCajaCajero = new CajaCajeroBL();
                        objCajaCajero.Elimina(objE_CajaCajero);
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

        private void gvCajaCajero_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CajaCajeroBL().ListaTodosActivo(Parametros.intEmpresaId, IdTienda, IdCaja);
            gcCajaCajero.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvCajaCajero.RowCount > 0)
            {
                CajaCajeroBE objCajaCajero = new CajaCajeroBE();
                objCajaCajero.IdTienda = int.Parse(gvCajaCajero.GetFocusedRowCellValue("IdTienda").ToString());
                objCajaCajero.IdCaja = int.Parse(gvCajaCajero.GetFocusedRowCellValue("IdCaja").ToString());
                objCajaCajero.IdCajaCajero = int.Parse(gvCajaCajero.GetFocusedRowCellValue("IdCajaCajero").ToString());
                objCajaCajero.IdPersona = int.Parse(gvCajaCajero.GetFocusedRowCellValue("IdPersona").ToString());
                objCajaCajero.ApeNom = gvCajaCajero.GetFocusedRowCellValue("ApeNom").ToString();
                objCajaCajero.FlagEstado = Convert.ToBoolean(gvCajaCajero.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManCajaCajeroEdit objManTablaEdit = new frmManCajaCajeroEdit();
                objManTablaEdit.pOperacion = frmManCajaCajeroEdit.Operacion.Modificar;
                objManTablaEdit.IdTienda = objCajaCajero.IdTienda;
                objManTablaEdit.IdCaja = objCajaCajero.IdCaja;
                objManTablaEdit.IdCajaCajero = objCajaCajero.IdCajaCajero;
                objManTablaEdit.pCajaCajeroBE = objCajaCajero;
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

            if (gvCajaCajero.GetFocusedRowCellValue("IdCajaCajero").ToString() == "")
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