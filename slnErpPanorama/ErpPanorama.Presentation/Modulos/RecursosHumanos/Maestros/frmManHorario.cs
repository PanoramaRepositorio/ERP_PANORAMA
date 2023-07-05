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

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Maestros
{
    public partial class frmManHorario : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<HorarioBE> mLista = new List<HorarioBE>();
        
        #endregion

        #region "Eventos"

        public frmManHorario()
        {
            InitializeComponent();
        }

        private void frmManHorario_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManHorarioEdit objManHorario = new frmManHorarioEdit();
                objManHorario.lstHorario = mLista;
                objManHorario.pOperacion = frmManHorarioEdit.Operacion.Nuevo;
                objManHorario.IdHorario = 0;
                objManHorario.StartPosition = FormStartPosition.CenterParent;
                objManHorario.ShowDialog();
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
                        HorarioBE objE_Horario = new HorarioBE();
                        objE_Horario.IdHorario = int.Parse(gvHorario.GetFocusedRowCellValue("IdHorario").ToString());
                        objE_Horario.Usuario = Parametros.strUsuarioLogin;
                        objE_Horario.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Horario.IdEmpresa = Parametros.intEmpresaId;

                        HorarioBL objBL_Horario = new HorarioBL();
                        objBL_Horario.Elimina(objE_Horario);
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
            //try
            //{
            //    Cursor = Cursors.WaitCursor;

            //   List<ReporteHorarioBE> lstReporte = null;
            //   lstReporte = new ReporteHorarioBL().Listado(Parametros.intEmpresaId,Parametros.intSoles);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptHorario = new RptVistaReportes();
            //            objRptHorario.VerRptHorario(lstReporte);
            //            objRptHorario.ShowDialog();
            //        }
            //        else
            //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    }
            //    Cursor = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    Cursor = Cursors.Default;
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoHorario";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvHorario.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvHorario_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new HorarioBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcHorario.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcHorario.DataSource = mLista.Where(obj =>
                                                   obj.DescHorario.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvHorario.RowCount > 0)
            {
                HorarioBE objHorario = new HorarioBE();
                objHorario.IdHorario = int.Parse(gvHorario.GetFocusedRowCellValue("IdHorario").ToString());
                objHorario.DescHorario = gvHorario.GetFocusedRowCellValue("DescHorario").ToString();
                objHorario.FechaIni = DateTime.Parse(gvHorario.GetFocusedRowCellValue("FechaIni").ToString());
                objHorario.FechaFin = DateTime.Parse(gvHorario.GetFocusedRowCellValue("FechaFin").ToString());

                frmManHorarioEdit objManHorarioEdit = new frmManHorarioEdit();
                objManHorarioEdit.pOperacion = frmManHorarioEdit.Operacion.Modificar;
                objManHorarioEdit.IdHorario = objHorario.IdHorario;
                objManHorarioEdit.pHorarioBE = objHorario;
                objManHorarioEdit.StartPosition = FormStartPosition.CenterParent;
                objManHorarioEdit.ShowDialog();

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

            if (gvHorario.GetFocusedRowCellValue("IdHorario").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Horario", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        
    }
}