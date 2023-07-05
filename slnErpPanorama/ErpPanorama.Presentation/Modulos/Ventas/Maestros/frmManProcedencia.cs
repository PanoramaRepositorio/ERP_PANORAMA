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
    public partial class frmManProcedencia : DevExpress.XtraEditors.XtraForm
    {
        #region "Procedimientos"
        
        
        private List<ProcedenciaBE> mLista = new List<ProcedenciaBE>();
        
        #endregion

        #region "Eventos"

        public frmManProcedencia()
        {
            InitializeComponent();
        }

        private void frmManProcedencia_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManProcedenciaEdit objManProcedencia = new frmManProcedenciaEdit();
                objManProcedencia.lstProcedencia = mLista;
                objManProcedencia.pOperacion = frmManProcedenciaEdit.Operacion.Nuevo;
                objManProcedencia.IdProcedencia = 0;
                objManProcedencia.StartPosition = FormStartPosition.CenterParent;
                objManProcedencia.ShowDialog();
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
                        ProcedenciaBE objE_Procedencia = new ProcedenciaBE();
                        objE_Procedencia.IdProcedencia = int.Parse(gvProcedencia.GetFocusedRowCellValue("IdProcedencia").ToString());
                        objE_Procedencia.Usuario = Parametros.strUsuarioLogin;
                        objE_Procedencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Procedencia.IdEmpresa = Parametros.intEmpresaId;

                        ProcedenciaBL objBL_Procedencia = new ProcedenciaBL();
                        objBL_Procedencia.Elimina(objE_Procedencia);
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

                List<ReporteProcedenciaBE> lstReporte = null;
                lstReporte = new ReporteProcedenciaBL().Listado(Parametros.intEmpresaId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptProcedencia = new RptVistaReportes();
                        objRptProcedencia.VerRptProcedencia(lstReporte);
                        objRptProcedencia.ShowDialog();
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
            string _fileName = "ListadoProcedenciaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProcedencia.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvProcedencia_DoubleClick(object sender, EventArgs e)
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
            mLista = new ProcedenciaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcProcedencia.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcProcedencia.DataSource = mLista.Where(obj =>
                                                   obj.DescProcedencia.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvProcedencia.RowCount > 0)
            {
                ProcedenciaBE objProcedencia = new ProcedenciaBE();
                objProcedencia.IdProcedencia = int.Parse(gvProcedencia.GetFocusedRowCellValue("IdProcedencia").ToString());
                objProcedencia.DescProcedencia = gvProcedencia.GetFocusedRowCellValue("DescProcedencia").ToString();
                objProcedencia.FlagEstado = Convert.ToBoolean(gvProcedencia.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManProcedenciaEdit objManProcedenciaEdit = new frmManProcedenciaEdit();
                objManProcedenciaEdit.pOperacion = frmManProcedenciaEdit.Operacion.Modificar;
                objManProcedenciaEdit.IdProcedencia = objProcedencia.IdProcedencia;
                objManProcedenciaEdit.pProcedenciaBE = objProcedencia;
                objManProcedenciaEdit.StartPosition = FormStartPosition.CenterParent;
                objManProcedenciaEdit.ShowDialog();

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

            if (gvProcedencia.GetFocusedRowCellValue("IdProcedencia").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Procedencia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

       
    }
}