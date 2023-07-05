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
using ErpPanorama.Presentation.Modulos.Logistica.Registros;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManAgencia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<AgenciaBE> mLista = new List<AgenciaBE>();

        #endregion

        #region "Eventos"
        public frmManAgencia()
        {
            InitializeComponent();
        }

        private void frmManAgencia_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManAgenciaEdit objManAgencia = new frmManAgenciaEdit();
                objManAgencia.lstAgencia = mLista;
                objManAgencia.pOperacion = frmManAgenciaEdit.Operacion.Nuevo;
                objManAgencia.IdAgencia = 0;
                objManAgencia.StartPosition = FormStartPosition.CenterParent;
                objManAgencia.ShowDialog();
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
                        AgenciaBE objE_Agencia = new AgenciaBE();
                        objE_Agencia.IdAgencia = int.Parse(gvAgencia.GetFocusedRowCellValue("IdAgencia").ToString());
                        objE_Agencia.Usuario = Parametros.strUsuarioLogin;
                        objE_Agencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        AgenciaBL objBL_Agencia = new AgenciaBL();
                        objBL_Agencia.Elimina(objE_Agencia);
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

            //    List<ReporteAgenciaBE> lstReporte = null;
            //    lstReporte = new ReporteAgenciaBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptAgencia = new RptVistaReportes();
            //            objRptAgencia.VerRptAgencia(lstReporte);
            //            objRptAgencia.ShowDialog();
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
            string _fileName = "ListadoAgencia";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvAgencia.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvAgencia_DoubleClick(object sender, EventArgs e)
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
            //CargarBusqueda();
            frmRegGestionPedidoDespachoEdit frmDes = new frmRegGestionPedidoDespachoEdit();
            frmDes.Show();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new AgenciaBL().ListaTodosActivo();
            gcAgencia.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
            gcAgencia.DataSource = mLista.Where(obj =>
                                                   obj.DescAgencia.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvAgencia.RowCount > 0)
            {
                AgenciaBE objAgencia = new AgenciaBE();
                objAgencia.IdAgencia = int.Parse(gvAgencia.GetFocusedRowCellValue("IdAgencia").ToString());
                objAgencia.Ruc = gvAgencia.GetFocusedRowCellValue("Ruc").ToString();
                objAgencia.DescAgencia = gvAgencia.GetFocusedRowCellValue("DescAgencia").ToString();
                objAgencia.Direccion = gvAgencia.GetFocusedRowCellValue("Direccion").ToString();
                objAgencia.IdUbigeo = gvAgencia.GetFocusedRowCellValue("IdUbigeo").ToString();
                objAgencia.Referencia = gvAgencia.GetFocusedRowCellValue("Referencia").ToString();
                objAgencia.Telefono = gvAgencia.GetFocusedRowCellValue("Telefono").ToString();
                objAgencia.Email = gvAgencia.GetFocusedRowCellValue("Email").ToString();
                objAgencia.Contacto = gvAgencia.GetFocusedRowCellValue("Contacto").ToString();
                objAgencia.PaginaWeb = gvAgencia.GetFocusedRowCellValue("PaginaWeb").ToString();
                objAgencia.Observacion = gvAgencia.GetFocusedRowCellValue("Observacion").ToString();
                objAgencia.FlagEstado = Convert.ToBoolean(gvAgencia.GetFocusedRowCellValue("FlagEstado").ToString());

                frmManAgenciaEdit objManAgenciaEdit = new frmManAgenciaEdit();
                objManAgenciaEdit.pOperacion = frmManAgenciaEdit.Operacion.Modificar;
                objManAgenciaEdit.IdAgencia = objAgencia.IdAgencia;
                objManAgenciaEdit.pAgenciaBE = objAgencia;
                objManAgenciaEdit.StartPosition = FormStartPosition.CenterParent;
                objManAgenciaEdit.ShowDialog();

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

            if (gvAgencia.GetFocusedRowCellValue("IdAgencia").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Agencia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

    }
}