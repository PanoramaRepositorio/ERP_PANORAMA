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
    public partial class frmManCajaEmpresa : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<CajaEmpresaBE> mLista = new List<CajaEmpresaBE>();

        public int IdTienda { get; set; }
        public int IdCaja { get; set; }

        #endregion

        #region "Eventos"
        public frmManCajaEmpresa()
        {
            InitializeComponent();
        }

        private void frmManCajaEmpresa_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmManCajaEmpresaEdit objManCajaEmpresa = new frmManCajaEmpresaEdit();
                objManCajaEmpresa.lstCajaEmpresa = mLista;
                objManCajaEmpresa.pOperacion = frmManCajaEmpresaEdit.Operacion.Nuevo;
                objManCajaEmpresa.IdTienda = IdTienda;
                objManCajaEmpresa.IdCaja = IdCaja;
                objManCajaEmpresa.IdCajaEmpresa = 0;
                objManCajaEmpresa.StartPosition = FormStartPosition.CenterParent;
                objManCajaEmpresa.ShowDialog();
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
                        CajaEmpresaBE objE_CajaEmpresa = new CajaEmpresaBE();
                        objE_CajaEmpresa.IdCajaEmpresa = int.Parse(gvCajaEmpresa.GetFocusedRowCellValue("IdCajaEmpresa").ToString());
                        objE_CajaEmpresa.Usuario = Parametros.strUsuarioLogin;
                        objE_CajaEmpresa.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_CajaEmpresa.IdEmpresa = Parametros.intEmpresaId;

                        CajaEmpresaBL objCajaEmpresa = new CajaEmpresaBL();
                        objCajaEmpresa.Elimina(objE_CajaEmpresa);
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

        private void gvCajaEmpresa_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CajaEmpresaBL().ListaTodosActivo(Parametros.intEmpresaId, IdTienda, IdCaja);
            gcCajaEmpresa.DataSource = mLista;
        }

        public void InicializarModificar()
        {
            if (gvCajaEmpresa.RowCount > 0)
            {
                CajaEmpresaBE objCajaEmpresa = new CajaEmpresaBE();
                objCajaEmpresa.IdEmpresa = int.Parse(gvCajaEmpresa.GetFocusedRowCellValue("IdEmpresa").ToString());
                objCajaEmpresa.IdTienda = int.Parse(gvCajaEmpresa.GetFocusedRowCellValue("IdTienda").ToString());
                objCajaEmpresa.IdCaja = int.Parse(gvCajaEmpresa.GetFocusedRowCellValue("IdCaja").ToString());
                objCajaEmpresa.IdTipoFormato = int.Parse(gvCajaEmpresa.GetFocusedRowCellValue("IdTipoFormato").ToString());
                objCajaEmpresa.IdCajaEmpresa = int.Parse(gvCajaEmpresa.GetFocusedRowCellValue("IdCajaEmpresa").ToString());
                objCajaEmpresa.SerieBoleta = gvCajaEmpresa.GetFocusedRowCellValue("SerieBoleta").ToString();
                objCajaEmpresa.SerieFactura = gvCajaEmpresa.GetFocusedRowCellValue("SerieFactura").ToString();
                objCajaEmpresa.FlagEstado = Convert.ToBoolean(gvCajaEmpresa.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManCajaEmpresaEdit objManTablaEdit = new frmManCajaEmpresaEdit();
                objManTablaEdit.pOperacion = frmManCajaEmpresaEdit.Operacion.Modificar;
                objManTablaEdit.IdEmpresa = objCajaEmpresa.IdEmpresa;
                objManTablaEdit.IdTienda = objCajaEmpresa.IdTienda;
                objManTablaEdit.IdCaja = objCajaEmpresa.IdCaja;
                objManTablaEdit.IdTipoFormato = objCajaEmpresa.IdTipoFormato;
                //objManTablaEdit.pCajaEmpresaBE.IdTipoFormato = objCajaEmpresa.IdTipoFormato; //add
                objManTablaEdit.IdCajaEmpresa = objCajaEmpresa.IdCajaEmpresa;
                objManTablaEdit.pCajaEmpresaBE = objCajaEmpresa;
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

            if (gvCajaEmpresa.GetFocusedRowCellValue("IdCajaEmpresa").ToString() == "")
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