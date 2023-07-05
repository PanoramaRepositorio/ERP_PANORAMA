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
    public partial class frmManTurno : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TurnoBE> mLista = new List<TurnoBE>();

        #endregion

        #region "Eventos"
        public frmManTurno()
        {
            InitializeComponent();
        }

        private void frmManTurno_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }
        
        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTurnoEdit objManTurno = new frmManTurnoEdit();
                objManTurno.lstTurno = mLista;
                objManTurno.pOperacion = frmManTurnoEdit.Operacion.Nuevo;
                objManTurno.IdTurno = 0;
                objManTurno.StartPosition = FormStartPosition.CenterParent;
                objManTurno.ShowDialog();
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
                        TurnoBE objE_Turno = new TurnoBE();
                        objE_Turno.IdTurno = int.Parse(gvTurno.GetFocusedRowCellValue("IdTurno").ToString());
                        objE_Turno.Usuario = Parametros.strUsuarioLogin;
                        objE_Turno.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Turno.IdEmpresa = Parametros.intEmpresaId;

                        TurnoBL objBL_Turno = new TurnoBL();
                        objBL_Turno.Elimina(objE_Turno);
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

            //   List<ReporteTurnoBE> lstReporte = null;
            //   lstReporte = new ReporteTurnoBL().Listado(Parametros.intEmpresaId,Parametros.intSoles);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptTurno = new RptVistaReportes();
            //            objRptTurno.VerRptTurno(lstReporte);
            //            objRptTurno.ShowDialog();
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
            string _fileName = "ListadoTurno";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTurno.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTurno_DoubleClick(object sender, EventArgs e)
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
            mLista = new TurnoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcTurno.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcTurno.DataSource = mLista.Where(obj =>
                                                   obj.DescTurno.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvTurno.RowCount > 0)
            {
                TurnoBE objTurno = new TurnoBE();
                objTurno.IdTurno = int.Parse(gvTurno.GetFocusedRowCellValue("IdTurno").ToString());
                objTurno.IdEmpresa = int.Parse(gvTurno.GetFocusedRowCellValue("IdEmpresa").ToString());
                objTurno.DescTurno = gvTurno.GetFocusedRowCellValue("DescTurno").ToString();
                objTurno.TotalHorasRef = Decimal.Parse(gvTurno.GetFocusedRowCellValue("TotalHorasRef").ToString());
                objTurno.TotalHorasTrab = Decimal.Parse(gvTurno.GetFocusedRowCellValue("TotalHorasTrab").ToString());
                objTurno.Observacion = gvTurno.GetFocusedRowCellValue("Observacion").ToString();

                frmManTurnoEdit objManTurnoEdit = new frmManTurnoEdit();
                objManTurnoEdit.pOperacion = frmManTurnoEdit.Operacion.Modificar;
                objManTurnoEdit.IdTurno = objTurno.IdTurno;
                objManTurnoEdit.pTurnoBE = objTurno;
                objManTurnoEdit.StartPosition = FormStartPosition.CenterParent;
                objManTurnoEdit.ShowDialog();

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

            if (gvTurno.GetFocusedRowCellValue("IdTurno").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Turno", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}