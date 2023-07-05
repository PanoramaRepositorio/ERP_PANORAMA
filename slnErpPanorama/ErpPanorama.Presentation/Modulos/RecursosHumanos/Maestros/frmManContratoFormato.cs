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
    public partial class frmManContratoFormato : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ContratoFormatoBE> mLista = new List<ContratoFormatoBE>();

        #endregion

        #region "Eventos"

        public frmManContratoFormato()
        {
            InitializeComponent();
        }

        private void frmManContratoFormato_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManContratoFormatoEdit objManContratoFormato = new frmManContratoFormatoEdit();
                objManContratoFormato.lstContratoFormato = mLista;
                objManContratoFormato.pOperacion = frmManContratoFormatoEdit.Operacion.Nuevo;
                objManContratoFormato.IdContratoFormato = 0;
                objManContratoFormato.StartPosition = FormStartPosition.CenterParent;
                objManContratoFormato.ShowDialog();
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
                        ContratoFormatoBE objE_ContratoFormato = new ContratoFormatoBE();
                        objE_ContratoFormato.IdContratoFormato = int.Parse(gvContratoFormato.GetFocusedRowCellValue("IdContratoFormato").ToString());
                        objE_ContratoFormato.Usuario = Parametros.strUsuarioLogin;
                        objE_ContratoFormato.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_ContratoFormato.IdEmpresa = Parametros.intEmpresaId;

                        ContratoFormatoBL objBL_ContratoFormato = new ContratoFormatoBL();
                        objBL_ContratoFormato.Elimina(objE_ContratoFormato);
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

            //   List<ReporteContratoFormatoBE> lstReporte = null;
            //   lstReporte = new ReporteContratoFormatoBL().Listado(Parametros.intEmpresaId,Parametros.intSoles);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptContratoFormato = new RptVistaReportes();
            //            objRptContratoFormato.VerRptContratoFormato(lstReporte);
            //            objRptContratoFormato.ShowDialog();
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
            string _fileName = "ListadoContratoFormato";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvContratoFormato.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
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
            mLista = new ContratoFormatoBL().ListaFormato(Parametros.intEmpresaId);
            gcContratoFormato.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcContratoFormato.DataSource = mLista.Where(obj =>
                                                   obj.Descripcion.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvContratoFormato.RowCount > 0)
            {
                ContratoFormatoBE objContratoFormato = new ContratoFormatoBE();
                objContratoFormato.IdContratoFormato = int.Parse(gvContratoFormato.GetFocusedRowCellValue("IdContratoFormato").ToString());

                frmManContratoFormatoEdit objManContratoFormatoEdit = new frmManContratoFormatoEdit();
                objManContratoFormatoEdit.pOperacion = frmManContratoFormatoEdit.Operacion.Modificar;
                objManContratoFormatoEdit.IdContratoFormato = objContratoFormato.IdContratoFormato;
                objManContratoFormatoEdit.StartPosition = FormStartPosition.CenterParent;
                objManContratoFormatoEdit.ShowDialog();

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

            if (gvContratoFormato.GetFocusedRowCellValue("IdContratoFormato").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un contrato", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void gvContratoFormato_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }


    }
}