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
    public partial class frmManCaja : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        private List<CajaBE> mLista = new List<CajaBE>();
        
        #endregion

        #region "Eventos"

        public frmManCaja()
        {
            InitializeComponent();
        }

        private void frmManCaja_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManCajaEdit objManCaja = new frmManCajaEdit();
                objManCaja.lstCaja = mLista;
                objManCaja.pOperacion = frmManCajaEdit.Operacion.Nuevo;
                objManCaja.IdCaja = 0;
                objManCaja.StartPosition = FormStartPosition.CenterParent;
                objManCaja.ShowDialog();
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
                        CajaBE objE_Caja = new CajaBE();
                        objE_Caja.IdCaja = int.Parse(gvCaja.GetFocusedRowCellValue("IdCaja").ToString());
                        objE_Caja.Usuario = Parametros.strUsuarioLogin;
                        objE_Caja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Caja.IdEmpresa = Parametros.intEmpresaId;

                        CajaBL objBL_Elimina = new CajaBL();
                        objBL_Elimina.Elimina(objE_Caja);
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

                List<ReporteCajaBE> lstReporte = null;
                lstReporte = new ReporteCajaBL().Listado(Parametros.intEmpresaId, 0);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptCaja = new RptVistaReportes();
                        objRptCaja.VerRptCaja(lstReporte);
                        objRptCaja.ShowDialog();
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
            string _fileName = "ListadoCajaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCaja.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvCaja_DoubleClick(object sender, EventArgs e)
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

        private void asignarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvCaja.RowCount > 0)
            {
                int IdCaja = int.Parse(gvCaja.GetFocusedRowCellValue("IdCaja").ToString());
                int IdTienda = int.Parse(gvCaja.GetFocusedRowCellValue("IdTienda").ToString());

                frmManCajaCajero objManCajaCajero = new frmManCajaCajero();
                objManCajaCajero.IdTienda = IdTienda;
                objManCajaCajero.IdCaja = IdCaja;
                objManCajaCajero.StartPosition = FormStartPosition.CenterParent;
                objManCajaCajero.ShowDialog();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new CajaBL().ListaTodosActivo(Parametros.intEmpresaId,0);
            gcCaja.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcCaja.DataSource = mLista.Where(obj =>
                                                   obj.DescCaja.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvCaja.RowCount > 0)
            {
                CajaBE objCaja = new CajaBE();
                objCaja.IdTienda = int.Parse(gvCaja.GetFocusedRowCellValue("IdTienda").ToString());
                objCaja.IdCaja = int.Parse(gvCaja.GetFocusedRowCellValue("IdCaja").ToString());
                objCaja.DescCaja = gvCaja.GetFocusedRowCellValue("DescCaja").ToString();
                objCaja.Mac = gvCaja.GetFocusedRowCellValue("Mac").ToString();
                objCaja.FlagVenta = Convert.ToBoolean(gvCaja.GetFocusedRowCellValue("FlagVenta").ToString());
                objCaja.FlagEstado = Convert.ToBoolean(gvCaja.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManCajaEdit objManCajaEdit = new frmManCajaEdit();
                objManCajaEdit.pOperacion = frmManCajaEdit.Operacion.Modificar;
                objManCajaEdit.IdCaja = objCaja.IdCaja;
                objManCajaEdit.pCajaBE = objCaja;
                objManCajaEdit.StartPosition = FormStartPosition.CenterParent;
                objManCajaEdit.ShowDialog();

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

            if (gvCaja.GetFocusedRowCellValue("IdCaja").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Caja", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void asignarempresatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvCaja.RowCount > 0)
            {
                int IdCaja = int.Parse(gvCaja.GetFocusedRowCellValue("IdCaja").ToString());
                int IdTienda = int.Parse(gvCaja.GetFocusedRowCellValue("IdTienda").ToString());

                frmManCajaEmpresa objManCajaCajero = new frmManCajaEmpresa();
                objManCajaCajero.IdTienda = IdTienda;
                objManCajaCajero.IdCaja = IdCaja;
                objManCajaCajero.StartPosition = FormStartPosition.CenterParent;
                objManCajaCajero.ShowDialog();
            }
        }

      
    }
}