
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

namespace ErpPanorama.Presentation.Modulos.MesaAyuda.Registros
{
    public partial class frmRegIncidencia : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<IncidenciaBE> mLista = new List<IncidenciaBE>();

        #endregion

        #region "Eventos"

        public frmRegIncidencia()
        {
            InitializeComponent();
        }

        private void frmRegIncidencia_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            Cargar();



        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegIncidenciaEdit objManIncidencia = new frmRegIncidenciaEdit();
                objManIncidencia.lstIncidencia = mLista;
                objManIncidencia.pOperacion = frmRegIncidenciaEdit.Operacion.Nuevo;
                objManIncidencia.IdIncidencia = 0;
                objManIncidencia.StartPosition = FormStartPosition.CenterParent;
                objManIncidencia.ShowDialog();
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
                if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerAdministrador)
                {
                    if (XtraMessageBox.Show("Esta seguro de eliminar el registro?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (!ValidarIngreso())
                        {
                            IncidenciaBE objE_Incidencia = new IncidenciaBE();
                            objE_Incidencia.IdIncidencia = int.Parse(gvIncidencia.GetFocusedRowCellValue("IdIncidencia").ToString());
                            objE_Incidencia.Usuario = Parametros.strUsuarioLogin;
                            objE_Incidencia.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                            objE_Incidencia.IdEmpresa = Parametros.intEmpresaId;

                            IncidenciaBL objBL_Incidencia = new IncidenciaBL();
                            objBL_Incidencia.Elimina(objE_Incidencia);
                            XtraMessageBox.Show("El registro se eliminó correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Cargar();
                        }
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

            //    List<ReporteIncidenciaBE> lstReporte = null;
            //    lstReporte = new ReporteIncidenciaBL().Listado(Parametros.intEmpresaId);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptIncidencia = new RptVistaReportes();
            //            objRptIncidencia.VerRptIncidencia(lstReporte);
            //            objRptIncidencia.ShowDialog();
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
            string _fileName = "ListadoIncidencias";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvIncidencia.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvIncidencia_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gcIncidencia_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarBusquedaNumero();
            }
        }

        private void gvIncidencia_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvIncidencia.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdEstado"]);
                    if (objDocRetiro != null)
                    {
                        int IdTipoDocumento = int.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == 189)
                        {
                            e.Appearance.BackColor = Color.LightGoldenrodYellow;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento == 190)
                        {
                            e.Appearance.BackColor = Color.Orange;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (IdTipoDocumento == 191)
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new IncidenciaBL().ListaFecha(Parametros.intEmpresaId, deDesde.DateTime, deHasta.DateTime);
            gcIncidencia.DataSource = mLista;
            lblTotalRegistros.Text = mLista.Count().ToString() + " Registros Encontrados";
        }

        private void CargarBusquedaNumero()
        {
            if (txtNumero.Text.Length > 0)
            {
                mLista = new IncidenciaBL().ListaNumero(Parametros.intPeriodo, txtNumero.Text.Trim());
                gcIncidencia.DataSource = mLista;
                lblTotalRegistros.Text = mLista.Count().ToString() + " Registros Encontrados";
            }

        }

        private void CargarBusqueda()
        {
            //gcIncidencia.DataSource = mLista.Where(obj =>
            //                                       obj.DescIncidencia.ToUpper().Contains(txtDescripcion.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvIncidencia.RowCount > 0)
            {
                IncidenciaBE objIncidencia = new IncidenciaBE();
                objIncidencia.IdIncidencia = int.Parse(gvIncidencia.GetFocusedRowCellValue("IdIncidencia").ToString());
                objIncidencia.Fecha = DateTime.Parse(gvIncidencia.GetFocusedRowCellValue("Fecha").ToString());
                objIncidencia.Numero = gvIncidencia.GetFocusedRowCellValue("Numero").ToString();
                objIncidencia.IdSolicitante = int.Parse(gvIncidencia.GetFocusedRowCellValue("IdSolicitante").ToString());
                objIncidencia.Descripcion = gvIncidencia.GetFocusedRowCellValue("Descripcion").ToString();
                objIncidencia.Solucion = gvIncidencia.GetFocusedRowCellValue("Solucion").ToString();
                objIncidencia.IdResponsable = int.Parse(gvIncidencia.GetFocusedRowCellValue("IdResponsable").ToString());
                //if (gvIncidencia.GetFocusedRowCellValue("FechaCierre").ToString().Length == 0)
                //    objIncidencia.FechaCierre = null;
                //else
                //    objIncidencia.FechaCierre = DateTime.Parse(gvIncidencia.GetFocusedRowCellValue("FechaCierre").ToString());
                objIncidencia.IdPrioridad = int.Parse(gvIncidencia.GetFocusedRowCellValue("IdPrioridad").ToString());
                objIncidencia.IdEstado = int.Parse(gvIncidencia.GetFocusedRowCellValue("IdEstado").ToString());
                objIncidencia.FlagEstado = Convert.ToBoolean(gvIncidencia.GetFocusedRowCellValue("FlagEstado").ToString());

                frmRegIncidenciaEdit objManIncidenciaEdit = new frmRegIncidenciaEdit();
                objManIncidenciaEdit.pOperacion = frmRegIncidenciaEdit.Operacion.Modificar;
                objManIncidenciaEdit.IdIncidencia = objIncidencia.IdIncidencia;
                objManIncidenciaEdit.pIncidenciaBE = objIncidencia;
                objManIncidenciaEdit.StartPosition = FormStartPosition.CenterParent;
                objManIncidenciaEdit.ShowDialog();

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

            if (gvIncidencia.GetFocusedRowCellValue("IdIncidencia").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione Incidencia", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion



    }
}