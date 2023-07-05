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

namespace ErpPanorama.Presentation.Modulos.DiseñoInteriores.Maestros
{
    public partial class frmManEstilo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<Dis_EstiloBE> mLista = new List<Dis_EstiloBE>();

        #endregion

        #region "Eventos"

        public frmManEstilo()
        {
            InitializeComponent();
        }

        private void frmManEstilo_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }


        private void tlbMenu_NewClick()
        {
            try
            {
                frmManEstiloEdit objManDis_Estilo = new frmManEstiloEdit();
                objManDis_Estilo.lstDis_Estilo = mLista;
                objManDis_Estilo.pOperacion = frmManEstiloEdit.Operacion.Nuevo;
                objManDis_Estilo.IdDis_Estilo = 0;
                objManDis_Estilo.StartPosition = FormStartPosition.CenterParent;
                objManDis_Estilo.ShowDialog();
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
                        Dis_EstiloBE objE_Dis_Estilo = new Dis_EstiloBE();
                        objE_Dis_Estilo.IdDis_Estilo = int.Parse(gvDis_Estilo.GetFocusedRowCellValue("IdDis_Estilo").ToString());
                        objE_Dis_Estilo.Usuario = Parametros.strUsuarioLogin;
                        objE_Dis_Estilo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Dis_Estilo.IdEmpresa = Parametros.intEmpresaId;

                        Dis_EstiloBL objBL_Dis_Estilo = new Dis_EstiloBL();
                        objBL_Dis_Estilo.Elimina(objE_Dis_Estilo);
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

                //    List<ReporteDis_EstiloBE> lstReporte = null;
                //    lstReporte = new ReporteDis_EstiloBL().Listado(Parametros.intEmpresaId);

                //    if (lstReporte != null)
                //    {
                //        if (lstReporte.Count > 0)
                //        {
                //            RptVistaReportes objRptDis_Estilo = new RptVistaReportes();
                //            objRptDis_Estilo.VerRptDis_Estilo(lstReporte);
                //            objRptDis_Estilo.ShowDialog();
                //        }
                //        else
                //            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }
                //    Cursor = Cursors.Default;
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
            string _fileName = "ListadoEstiloes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDis_Estilo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvEstilo_DoubleClick(object sender, EventArgs e)
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
            mLista = new Dis_EstiloBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDis_Estilo.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDis_Estilo.DataSource = mLista.Where(obj =>
                                                   obj.DescDis_Estilo.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDis_Estilo.RowCount > 0)
            {
                Dis_EstiloBE objDis_Estilo = new Dis_EstiloBE();
                objDis_Estilo.IdDis_Estilo = int.Parse(gvDis_Estilo.GetFocusedRowCellValue("IdDis_Estilo").ToString());
                objDis_Estilo.DescDis_Estilo = gvDis_Estilo.GetFocusedRowCellValue("DescDis_Estilo").ToString();
                objDis_Estilo.FlagEstado = Convert.ToBoolean(gvDis_Estilo.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManEstiloEdit objManDis_EstiloEdit = new frmManEstiloEdit();
                objManDis_EstiloEdit.pOperacion = frmManEstiloEdit.Operacion.Modificar;
                objManDis_EstiloEdit.IdDis_Estilo = objDis_Estilo.IdDis_Estilo;
                objManDis_EstiloEdit.pDis_EstiloBE = objDis_Estilo;
                objManDis_EstiloEdit.StartPosition = FormStartPosition.CenterParent;
                objManDis_EstiloEdit.ShowDialog();

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

            if (gvDis_Estilo.GetFocusedRowCellValue("IdDis_Estilo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Estilo", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}