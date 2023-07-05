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
    public partial class frmManPieza : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<Dis_PiezaBE> mLista = new List<Dis_PiezaBE>();

        #endregion

        #region "Eventos"

        public frmManPieza()
        {
            InitializeComponent();
        }

        private void frmManPieza_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }


        private void tlbMenu_NewClick()
        {
            try
            {
                frmManPiezaEdit objManDis_Pieza = new frmManPiezaEdit();
                objManDis_Pieza.lstDis_Pieza = mLista;
                objManDis_Pieza.pOperacion = frmManPiezaEdit.Operacion.Nuevo;
                objManDis_Pieza.IdDis_Pieza = 0;
                objManDis_Pieza.StartPosition = FormStartPosition.CenterParent;
                objManDis_Pieza.ShowDialog();
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
                        Dis_PiezaBE objE_Dis_Pieza = new Dis_PiezaBE();
                        objE_Dis_Pieza.IdDis_Pieza = int.Parse(gvDis_Pieza.GetFocusedRowCellValue("IdDis_Pieza").ToString());
                        objE_Dis_Pieza.Usuario = Parametros.strUsuarioLogin;
                        objE_Dis_Pieza.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Dis_Pieza.IdEmpresa = Parametros.intEmpresaId;

                        Dis_PiezaBL objBL_Dis_Pieza = new Dis_PiezaBL();
                        objBL_Dis_Pieza.Elimina(objE_Dis_Pieza);
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

                //    List<ReporteDis_PiezaBE> lstReporte = null;
                //    lstReporte = new ReporteDis_PiezaBL().Listado(Parametros.intEmpresaId);

                //    if (lstReporte != null)
                //    {
                //        if (lstReporte.Count > 0)
                //        {
                //            RptVistaReportes objRptDis_Pieza = new RptVistaReportes();
                //            objRptDis_Pieza.VerRptDis_Pieza(lstReporte);
                //            objRptDis_Pieza.ShowDialog();
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
            string _fileName = "ListadoPiezaes";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDis_Pieza.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPieza_DoubleClick(object sender, EventArgs e)
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
            mLista = new Dis_PiezaBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDis_Pieza.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcDis_Pieza.DataSource = mLista.Where(obj =>
                                                   obj.DescDis_Pieza.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvDis_Pieza.RowCount > 0)
            {
                Dis_PiezaBE objDis_Pieza = new Dis_PiezaBE();
                objDis_Pieza.IdDis_Pieza = int.Parse(gvDis_Pieza.GetFocusedRowCellValue("IdDis_Pieza").ToString());
                objDis_Pieza.IdTipoPieza = int.Parse(gvDis_Pieza.GetFocusedRowCellValue("IdTipoPieza").ToString());
                objDis_Pieza.DescDis_Pieza = gvDis_Pieza.GetFocusedRowCellValue("DescDis_Pieza").ToString();
                objDis_Pieza.FlagEstado = Convert.ToBoolean(gvDis_Pieza.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManPiezaEdit objManDis_PiezaEdit = new frmManPiezaEdit();
                objManDis_PiezaEdit.pOperacion = frmManPiezaEdit.Operacion.Modificar;
                objManDis_PiezaEdit.IdDis_Pieza = objDis_Pieza.IdDis_Pieza;
                objManDis_PiezaEdit.pDis_PiezaBE = objDis_Pieza;
                objManDis_PiezaEdit.StartPosition = FormStartPosition.CenterParent;
                objManDis_PiezaEdit.ShowDialog();

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

            if (gvDis_Pieza.GetFocusedRowCellValue("IdDis_Pieza").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Pieza", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}