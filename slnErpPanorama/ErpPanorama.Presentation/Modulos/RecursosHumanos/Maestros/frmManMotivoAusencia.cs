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
    public partial class frmManMotivoAusencia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<MotivoAusenciaBE> mLista = new List<MotivoAusenciaBE>();
        
        #endregion

        #region "Eventos"

        public frmManMotivoAusencia()
        {
            InitializeComponent();
        }

        private void frmManMotivoAusencia_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManMotivoAusenciaEdit objManMotivoAusencia = new frmManMotivoAusenciaEdit();
                objManMotivoAusencia.lstMotivoAusencia = mLista;
                objManMotivoAusencia.pOperacion = frmManMotivoAusenciaEdit.Operacion.Nuevo;
                objManMotivoAusencia.IdMotivoAusencia = 0;
                objManMotivoAusencia.StartPosition = FormStartPosition.CenterParent;
                objManMotivoAusencia.ShowDialog();
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
                        MotivoAusenciaBE objE_MotivoAusencia = new MotivoAusenciaBE();
                        objE_MotivoAusencia.IdMotivoAusencia = int.Parse(gvMotivoAusencia.GetFocusedRowCellValue("IdMotivoAusencia").ToString());
                        objE_MotivoAusencia.Usuario = Parametros.strUsuarioLogin;
                        objE_MotivoAusencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MotivoAusencia.IdEmpresa = Parametros.intEmpresaId;

                        MotivoAusenciaBL objBL_MotivoAusencia = new MotivoAusenciaBL();
                        objBL_MotivoAusencia.Elimina(objE_MotivoAusencia);
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

            //    List<ReporteMotivoAusenciaElementoBE> lstReporte = null;
            //    lstReporte = new ReporteMotivoAusenciaElementoBL().Listado();

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptMotivoAusenciaElemento = new RptVistaReportes();
            //            objRptMotivoAusenciaElemento.VerRptMotivoAusenciaElemento(lstReporte);
            //            objRptMotivoAusenciaElemento.ShowDialog();
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
            string _fileName = "ListadoMotivoAusenciaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMotivoAusencia.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvMotivoAusencia_DoubleClick(object sender, EventArgs e)
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
            mLista = new MotivoAusenciaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcMotivoAusencia.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcMotivoAusencia.DataSource = mLista.Where(obj =>
                                                   obj.DescMotivoAusencia.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvMotivoAusencia.RowCount > 0)
            {
                MotivoAusenciaBE objMotivoAusencia = new MotivoAusenciaBE();
                objMotivoAusencia.IdMotivoAusencia = int.Parse(gvMotivoAusencia.GetFocusedRowCellValue("IdMotivoAusencia").ToString());
                objMotivoAusencia.DescMotivoAusencia = gvMotivoAusencia.GetFocusedRowCellValue("DescMotivoAusencia").ToString();
                objMotivoAusencia.Abreviatura = gvMotivoAusencia.GetFocusedRowCellValue("Abreviatura").ToString();
                objMotivoAusencia.FlagEstado = Convert.ToBoolean(gvMotivoAusencia.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManMotivoAusenciaEdit objManMotivoAusenciaEdit = new frmManMotivoAusenciaEdit();
                objManMotivoAusenciaEdit.pOperacion = frmManMotivoAusenciaEdit.Operacion.Modificar;
                objManMotivoAusenciaEdit.IdMotivoAusencia = objMotivoAusencia.IdMotivoAusencia;
                objManMotivoAusenciaEdit.pMotivoAusenciaBE = objMotivoAusencia;
                objManMotivoAusenciaEdit.StartPosition = FormStartPosition.CenterParent;
                objManMotivoAusenciaEdit.ShowDialog();

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

            if (gvMotivoAusencia.GetFocusedRowCellValue("IdMotivoAusencia").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una MotivoAusencia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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