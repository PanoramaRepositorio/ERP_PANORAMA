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
using ErpPanorama.Presentation.Modulos.RecursosHumanos.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegPersonaTrabajo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<PersonaTrabajoBE> mLista = new List<PersonaTrabajoBE>();

        #endregion

        #region "Eventos"
        public frmRegPersonaTrabajo()
        {
            InitializeComponent();
        }

        private void frmRegPersonaTrabajo_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = Parametros.intPeriodo;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegPersonaTrabajoEdit objManPersonaTrabajo = new frmRegPersonaTrabajoEdit();
                objManPersonaTrabajo.lstPersonaTrabajo = mLista;
                objManPersonaTrabajo.pOperacion = frmRegPersonaTrabajoEdit.Operacion.Nuevo;
                objManPersonaTrabajo.IdPersonaTrabajo = 0;
                objManPersonaTrabajo.StartPosition = FormStartPosition.CenterParent;
                if (objManPersonaTrabajo.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
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
                        PersonaTrabajoBE objE_PersonaTrabajo = new PersonaTrabajoBE();
                        objE_PersonaTrabajo.IdPersonaTrabajo = int.Parse(gvPersonaTrabajo.GetFocusedRowCellValue("IdPersonaTrabajo").ToString());
                        objE_PersonaTrabajo.Usuario = Parametros.strUsuarioLogin;
                        objE_PersonaTrabajo.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_PersonaTrabajo.IdEmpresa = Parametros.intEmpresaId;

                        PersonaTrabajoBL objBL_PersonaTrabajo = new PersonaTrabajoBL();
                        objBL_PersonaTrabajo.Elimina(objE_PersonaTrabajo);
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

                List<ReportePersonaTrabajoBE> lstReporte = null;
                lstReporte = new ReportePersonaTrabajoBL().Listado(int.Parse(gvPersonaTrabajo.GetFocusedRowCellValue("IdPersonaTrabajo").ToString()), Parametros.intUsuarioId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptPersonaTrabajo = new RptVistaReportes();
                        objRptPersonaTrabajo.VerRptPersonaTrabajo(lstReporte);
                        objRptPersonaTrabajo.ShowDialog();
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
            string _fileName = "ListadoPersonaTrabajo";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPersonaTrabajo.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPersonaTrabajo_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtApeNom_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void gvPersonaTrabajo_ColumnFilterChanged(object sender, EventArgs e)
        {
            //lblTotalRegistros.Text = gvPersonaTrabajo.RowCount.ToString() + " Registros encontrados";
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new PersonaTrabajoBL().ListaTodosActivo(Convert.ToInt32(txtPeriodo.EditValue));
            gcPersonaTrabajo.DataSource = mLista;
            //lblTotalRegistros.Text = mLista.Count().ToString() + " Registros encontrados";
        }

        private void CargarBusqueda()
        {
            //gcPersonaTrabajo.DataSource = mLista.Where(obj =>
            //                                       obj.ApeNom.ToUpper().Contains(txtApeNom.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvPersonaTrabajo.RowCount > 0)
            {
                PersonaTrabajoBE objPersonaTrabajo = new PersonaTrabajoBE();
                objPersonaTrabajo.IdPersonaTrabajo = int.Parse(gvPersonaTrabajo.GetFocusedRowCellValue("IdPersonaTrabajo").ToString());

                frmRegPersonaTrabajoEdit objManPersonaTrabajoEdit = new frmRegPersonaTrabajoEdit();
                objManPersonaTrabajoEdit.pOperacion = frmRegPersonaTrabajoEdit.Operacion.Modificar;
                objManPersonaTrabajoEdit.IdPersonaTrabajo = objPersonaTrabajo.IdPersonaTrabajo;
                objManPersonaTrabajoEdit.StartPosition = FormStartPosition.CenterParent;
                if (objManPersonaTrabajoEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
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
                if(Parametros.intPerfilId == Parametros.intPerAdministrador|| Parametros.intPerfilId == Parametros.intPerJefeRRHH|| Parametros.intPerfilId == Parametros.intPerAsistenteRRHH || Parametros.intPerfilId == Parametros.intPerAuditorCajaDespacho)
                InicializarModificar();
            }
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvPersonaTrabajo.GetFocusedRowCellValue("IdPersonaTrabajo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un registro", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }




        #endregion

        private void txtPeriodo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Cargar();
            }
        }

        private void imprimirpublicaciontoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReportePersonaTrabajoBE> lstReporte = null;
                lstReporte = new ReportePersonaTrabajoBL().Listado(int.Parse(gvPersonaTrabajo.GetFocusedRowCellValue("IdPersonaTrabajo").ToString()), Parametros.intUsuarioId);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptPersonaTrabajo = new RptVistaReportes();
                        objRptPersonaTrabajo.VerRptPersonaTrabajoPublicacion(lstReporte);
                        objRptPersonaTrabajo.ShowDialog();
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

        private void copialistatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            int IdPersonaTrabajo = 0;
            IdPersonaTrabajo = int.Parse(gvPersonaTrabajo.GetFocusedRowCellValue("IdPersonaTrabajo").ToString());

            frmRegPersonaTrabajoCopia frm = new frmRegPersonaTrabajoCopia();
            frm.IdPersonaTrabajo = IdPersonaTrabajo;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                XtraMessageBox.Show("La copia se realizó correctamente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Cargar();
            }
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }
    }
}