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

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Consultas
{
    public partial class frmRepVacacionesDias : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<PersonaBE> mLista = new List<PersonaBE>();
        private bool bCargo = false;
        #endregion

        #region "Eventos"

        public frmRepVacacionesDias()
        {
            InitializeComponent();
        }

        private void frmRepVacaciones_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);

            List<EmpresaBE> lEmpresa = new EmpresaBL().ListaTodosActivo(0);
            lEmpresa = lEmpresa.Where(x =>   x.IdEmpresa == Parametros.intPanoraramaDistribuidores || x.IdEmpresa == Parametros.intDecoratex ).ToList();
            lEmpresa.Insert(0, new EmpresaBE { IdEmpresa = 0, RazonSocial = "<TODAS>" });
            BSUtils.LoaderLook(cboEmpresa, lEmpresa, "RazonSocial", "IdEmpresa", true);

            List<AreaBE> lArea = new AreaBL().ListaTodosActivo(Parametros.intEmpresaId);
            lArea.Insert(0, new AreaBE { IdArea= 0, DescArea= "<TODAS>" });
            BSUtils.LoaderLook(cboArea, lArea , "DescArea", "IdArea", true);

            List<TiendaBE> lTienda = new TiendaBL().ListaTodosActivo(Parametros.intPanoraramaDistribuidores);// Parametros.intEmpresaId
            lTienda.Insert(0, new TiendaBE { IdTienda = 0, DescTienda = "<TODAS>" });
            BSUtils.LoaderLook(cboTienda, lTienda, "DescTienda", "IdTienda", true);

            Cargar();
        }

        private void cboArea_EditValueChanged(object sender, EventArgs e)
        {
            //List<TablaElementoBE> lTablaElementoBE = new TablaElementoBL().ListaTodosActivoPorTablaExterna(Parametros.intEmpresaId, Parametros.intTblCargos, Convert.ToInt32(cboArea.EditValue));
            //if ( Convert.ToInt32( cboArea.EditValue) == 0)
            //{
            //    lTablaElementoBE.Insert(0, new TablaElementoBE { IdTablaElemento = 0, DescTablaElemento = "<TODOS>" });
            //}
            //BSUtils.LoaderLook(cboCargo, lTablaElementoBE, "DescTablaElemento", "IdTablaElemento", true);
            this.CargarBusqueda();
        }

        private void cboCargo_EditValueChanged(object sender, EventArgs e)
        {
            this.CargarBusqueda();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                //frmRepVacacionesEdit objManPersonal = new frmRepVacacionesEdit();
                //objManPersonal.pOperacion = frmRepVacacionesEdit.Operacion.Nuevo;
                //objManPersonal.IdPersona = 0;
                //objManPersonal.StartPosition = FormStartPosition.CenterParent;
                //if (objManPersonal.ShowDialog() == DialogResult.OK)
                //{
                //    Cargar();
                //}
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tlbMenu_EditClick()
        {
        }

        private void tlbMenu_DeleteClick()
        {
         
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
                List<PersonaBE> lPersonalReporte = CargarListaBusqueda();
                if (lPersonalReporte != null)
                {
                    if (lPersonalReporte.Count > 0)
                    {
                        List<ReporteVacacionesDiasBE> lReporteVacacionesDias = new List<ReporteVacacionesDiasBE>();
                        foreach (var item in lPersonalReporte)
                        {
                            ReporteVacacionesDiasBE eReporteVacacionesDias = new ReporteVacacionesDiasBE();
                            eReporteVacacionesDias.RazonSocial = item.RazonSocial;
                            eReporteVacacionesDias.DescTienda = item.DescTienda;
                            eReporteVacacionesDias.DescTipoDocumento = item.DescTipoDocumento;
                            eReporteVacacionesDias.Dni = item.Dni;
                            eReporteVacacionesDias.ApeNom = item.ApeNom;
                            eReporteVacacionesDias.FechaIngreso = item.FechaIngreso;
                            eReporteVacacionesDias.DiasVacaciones = item.DiasVacaciones;
                            eReporteVacacionesDias.DescCargo = item.DescCargo;
                            eReporteVacacionesDias.DescArea = item.DescArea;
                            lReporteVacacionesDias.Add(eReporteVacacionesDias);
                        }


                      RptVistaReportes objRptPersonal = new RptVistaReportes();
                        objRptPersonal.VerRptVacacionesDias(lReporteVacacionesDias);
                        objRptPersonal.ShowDialog();
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
            string _fileName = "ListadoVacacionesDias";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPersonal.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvPersonal_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }
        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarModificar();
            }
        }
        public void InicializarModificar()
        {
            if (gvPersonal.RowCount > 0)
            {
                int IdPersona = int.Parse(gvPersonal.GetFocusedRowCellValue("IdPersona").ToString());
                string ApeNom = gvPersonal.GetFocusedRowCellValue("ApeNom").ToString();
                DateTime FechaIngreso = DateTime.Parse(gvPersonal.GetFocusedRowCellValue("FechaIngreso").ToString());
                int DiasVacacionesPendientes = int.Parse(gvPersonal.GetFocusedRowCellValue("DiasVacaciones").ToString());
                
                List<VacacionesBE> mLista = new VacacionesBL().ListaTodosActivo(DateTime.Now.Year);
                mLista = mLista.Where(x => x.IdPersona == IdPersona && x.FechaDesde >= FechaIngreso).ToList();
                frmRepVacacionesDiasEdit objManVacacionesDiasEdit = new frmRepVacacionesDiasEdit();
                objManVacacionesDiasEdit.pOperacion = frmRepVacacionesDiasEdit.Operacion.Modificar;
                objManVacacionesDiasEdit.ApeNom = ApeNom;
                objManVacacionesDiasEdit.FechaIngreso = FechaIngreso;
                objManVacacionesDiasEdit.DiasVacacionesPendientes = DiasVacacionesPendientes;
                objManVacacionesDiasEdit.lstVacaciones = mLista;
                objManVacacionesDiasEdit.StartPosition = FormStartPosition.CenterParent;
                objManVacacionesDiasEdit.ShowDialog();
            }
            else
            {
                XtraMessageBox.Show("Seleccione una Personal", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                Cargar();
            }
        }

        private void txtDescripcion_KeyUp(object sender, KeyEventArgs e)
        {
            CargarBusqueda();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }
        private void gvPersonal_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPersonal.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    
                    object objDiasVacaciones = View.GetRowCellValue(e.RowHandle, View.Columns["DiasVacaciones"]);
                    if (objDiasVacaciones != null)
                    {
                        if (Convert.ToInt32(objDiasVacaciones) == 0)
                        {
                            object FechaIngresoObj = View.GetRowCellValue(e.RowHandle, View.Columns["FechaIngreso"]);
                            string FechaHoy = DateTime.Now.ToString("dd-MM-yyyy");
                            DateTime dFechaHoy = Convert.ToDateTime(FechaHoy);
                            DateTime dFechaIngresoAdd = Convert.ToDateTime(FechaIngresoObj).AddYears(1);

                            if (dFechaIngresoAdd > dFechaHoy)
                            {
                                gvPersonal.Columns["DiasVacaciones"].AppearanceCell.BackColor = Color.White;
                                gvPersonal.Columns["DiasVacaciones"].AppearanceCell.BackColor2 = Color.White;
                            }
                            else
                            {
                                gvPersonal.Columns["DiasVacaciones"].AppearanceCell.BackColor = Color.SkyBlue;
                                gvPersonal.Columns["DiasVacaciones"].AppearanceCell.BackColor2 = Color.White;
                            }
                        }
                        else if(Convert.ToInt32(objDiasVacaciones) > 0)
                        {
                            gvPersonal.Columns["DiasVacaciones"].AppearanceCell.BackColor = Color.Green;
                            gvPersonal.Columns["DiasVacaciones"].AppearanceCell.BackColor2 = Color.White;
                        }
                        else{
                            gvPersonal.Columns["DiasVacaciones"].AppearanceCell.BackColor = Color.Salmon;
                            gvPersonal.Columns["DiasVacaciones"].AppearanceCell.BackColor2 = Color.White;
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
            mLista = new PersonaBL().ListaTodosActivo(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboTienda.EditValue));
            int iEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
            if (iEmpresa != 0)
            {
                mLista = mLista.Where(x=> x.IdEmpresa == iEmpresa).ToList();
            }
            gcPersonal.DataSource = mLista;
            lblTotalRegistros.Text = gvPersonal.RowCount.ToString() + " Registros";
        }


        private void CargarBusqueda()
        {
            gcPersonal.DataSource = CargarListaBusqueda();
            lblTotalRegistros.Text = gvPersonal.RowCount.ToString() + " Registros";
        }

        private List<PersonaBE> CargarListaBusqueda()
        {
            int iArea = Convert.ToInt32(cboArea.EditValue);
            int iCargo = Convert.ToInt32(cboCargo.EditValue);

            if (iArea == 0)
            {
                return mLista.Where(obj => obj.Dni.ToUpper().Contains(txtDescripcion.Text.ToUpper()) ||
                                                   obj.ApeNom.ToUpper().Contains(txtDescripcion.Text.ToUpper())
                                                   ).ToList();
            }
            else
            {
                return mLista.Where(obj => obj.ApeNom.ToUpper().Contains(txtDescripcion.Text.ToUpper())
                                                  &&  obj.ApeNom.ToUpper().Contains(txtDescripcion.Text.ToUpper())
                                                  && obj.IdArea == iArea 
                                                  ).ToList();
            }
            
        }

        private bool ValidarIngreso()
        {
            bool flag = false;

            if (gvPersonal.GetFocusedRowCellValue("IdPersona").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Personal", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            Cargar();
            CargarBusqueda();
        }

        private void gvPersonal_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvPersonal.RowCount.ToString() + " Registros";
        }

        private void tlbMenu_Load(object sender, EventArgs e)
        {

        }

        private void tlbMenu_Excel_Click(object sender, EventArgs e)
        {
            tlbMenu_ExportClick();
        }

        private void tlbMenu_Print_Click(object sender, EventArgs e)
        {
            tlbMenu_PrintClick();
        }

        private void tlbMenu_Exit_Click(object sender, EventArgs e)
        {
            tlbMenu_ExitClick();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            Cargar();
            CargarBusqueda();
        }
    }
}