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
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegInmuebleAlquiler : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"


        private List<InmuebleAlquilerBE> mLista = new List<InmuebleAlquilerBE>();

        #endregion

        #region "Eventos"
        public frmRegInmuebleAlquiler()
        {
            InitializeComponent();
        }

        private void frmRegInmuebleAlquiler_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegInmuebleAlquilerEdit objManInmuebleAlquiler = new frmRegInmuebleAlquilerEdit();
                objManInmuebleAlquiler.lstInmuebleAlquiler = mLista;
                objManInmuebleAlquiler.pOperacion = frmRegInmuebleAlquilerEdit.Operacion.Nuevo;
                objManInmuebleAlquiler.IdInmuebleAlquiler = 0;
                objManInmuebleAlquiler.StartPosition = FormStartPosition.CenterParent;
                objManInmuebleAlquiler.ShowDialog();
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
                        InmuebleAlquilerBE objE_InmuebleAlquiler = new InmuebleAlquilerBE();
                        objE_InmuebleAlquiler.IdInmuebleAlquiler = int.Parse(gvInmuebleAlquiler.GetFocusedRowCellValue("IdInmuebleAlquiler").ToString());
                        objE_InmuebleAlquiler.IdEmpresa = Parametros.intEmpresaId;
                        objE_InmuebleAlquiler.Usuario = Parametros.strUsuarioLogin;
                        objE_InmuebleAlquiler.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        InmuebleAlquilerBL objBL_InmuebleAlquiler = new InmuebleAlquilerBL();
                        objBL_InmuebleAlquiler.Elimina(objE_InmuebleAlquiler);
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

            //    List<ReporteInmuebleAlquilerBE> lstReporte = null;
            //    lstReporte = new ReporteInmuebleAlquilerBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboMotivo.EditValue));

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptInmuebleAlquiler = new RptVistaReportes();
            //            objRptInmuebleAlquiler.VerRptInmuebleAlquiler(lstReporte);
            //            objRptInmuebleAlquiler.ShowDialog();
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
            string _fileName = "ListadoInmuebleAlquilerles";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInmuebleAlquiler.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvInmuebleAlquiler_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtInmuebleAlquiler_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusquedaDocumento();
        }


        private void txtInmuebleAlquiler_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusquedaDocumento();
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new InmuebleAlquilerBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcInmuebleAlquiler.DataSource = mLista;
        }

        private void CargarBusquedaDocumento()
        {
            gcInmuebleAlquiler.DataSource = mLista.Where(obj =>
                                                   obj.DescCliente.ToString().ToUpper().Contains(txtInmuebleAlquiler.Text.ToUpper()) //||
                                                   //obj.NumeroDocumento.ToString().Contains(txtInmuebleAlquiler.Text.ToUpper())
                                             ).ToList();


        }

        public void InicializarModificar()
        {
            if (gvInmuebleAlquiler.RowCount > 0)
            {
                InmuebleAlquilerBE objInmuebleAlquiler = new InmuebleAlquilerBE();
                objInmuebleAlquiler.IdInmuebleAlquiler = int.Parse(gvInmuebleAlquiler.GetFocusedRowCellValue("IdInmuebleAlquiler").ToString());

                frmRegInmuebleAlquilerEdit objManInmuebleAlquilerEdit = new frmRegInmuebleAlquilerEdit();
                objManInmuebleAlquilerEdit.pOperacion = frmRegInmuebleAlquilerEdit.Operacion.Modificar;
                objManInmuebleAlquilerEdit.IdInmuebleAlquiler = objInmuebleAlquiler.IdInmuebleAlquiler;
                objManInmuebleAlquilerEdit.StartPosition = FormStartPosition.CenterParent;
                objManInmuebleAlquilerEdit.ShowDialog();

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

            if (gvInmuebleAlquiler.GetFocusedRowCellValue("IdInmuebleAlquiler").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Cliente Credito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion



 
    }
}