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

namespace ErpPanorama.Presentation.Modulos.RecursosHumanos.Registros
{
    public partial class frmRegContrato : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ContratoBE> mLista = new List<ContratoBE>();
       

        #endregion

        #region "Eventos"

        public frmRegContrato()
        {
            InitializeComponent();
        }

        private void frmRegContrato_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            txtPeriodo.EditValue = Parametros.intPeriodo;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmRegContratoEdit objManContrato = new frmRegContratoEdit();
                objManContrato.lstContrato = mLista;
                objManContrato.pOperacion = frmRegContratoEdit.Operacion.Nuevo;
                objManContrato.IdContrato = 0;
                objManContrato.StartPosition = FormStartPosition.CenterParent;
                objManContrato.ShowDialog();
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
                        ContratoBE objE_Contrato = new ContratoBE();
                        objE_Contrato.IdContrato = int.Parse(gvContrato.GetFocusedRowCellValue("IdContrato").ToString());
                        objE_Contrato.Usuario = Parametros.strUsuarioLogin;
                        objE_Contrato.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Contrato.IdEmpresa = Parametros.intEmpresaId;

                        ContratoBL objBL_Contrato = new ContratoBL();
                        objBL_Contrato.Elimina(objE_Contrato);
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

            //   List<ReporteContratoBE> lstReporte = null;
            //   lstReporte = new ReporteContratoBL().Listado(Parametros.intEmpresaId,Parametros.intSoles);

            //    if (lstReporte != null)
            //    {
            //        if (lstReporte.Count > 0)
            //        {
            //            RptVistaReportes objRptContrato = new RptVistaReportes();
            //            objRptContrato.VerRptContrato(lstReporte);
            //            objRptContrato.ShowDialog();
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
            string _fileName = "ListadoContrato";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvContrato.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvContrato_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtApeNom_EditValueChanged(object sender, EventArgs e)
        {
            CargarBusqueda();
        }
       
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ContratoBL().ListaTodosActivo(Convert.ToInt32(txtPeriodo.EditValue),"0");
            gcContrato.DataSource = mLista;
            lblTotalRegistros.Text = mLista.Count().ToString() + " Registros encontrados";
        }

        private void CargarBusqueda()
        {
            gcContrato.DataSource = mLista.Where(obj =>
                                                   obj.ApeNom.ToUpper().Contains(txtApeNom.Text.ToUpper())).ToList();
        }

        public void InicializarModificar()
        {
            if (gvContrato.RowCount > 0)
            {
                ContratoBE objContrato = new ContratoBE();
                objContrato.IdContrato = int.Parse(gvContrato.GetFocusedRowCellValue("IdContrato").ToString());

                frmRegContratoEdit objManContratoEdit = new frmRegContratoEdit();
                objManContratoEdit.pOperacion = frmRegContratoEdit.Operacion.Modificar;
                objManContratoEdit.IdContrato = objContrato.IdContrato;
                objManContratoEdit.StartPosition = FormStartPosition.CenterParent;
                objManContratoEdit.ShowDialog();

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

            if (gvContrato.GetFocusedRowCellValue("IdContrato").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una Contrato", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }


        #endregion


        private void gvContrato_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvContrato.RowCount.ToString() + " Registros encontrados";
        }

        private void gvContrato_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                //object obj = gvContrato.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    //object ojbFechaInicio = View.GetRowCellValue(e.RowHandle, View.Columns["FechaInicio"]);
                    object ojbFechaFin = View.GetRowCellValue(e.RowHandle, View.Columns["FechaVen"]);
                    if (ojbFechaFin != null)
                    {
                        DateTime FechaFin = DateTime.Parse(ojbFechaFin.ToString());
                        int  Diferencia = Convert.ToInt32((Convert.ToDateTime(FechaFin) - Convert.ToDateTime(DateTime.Now)).TotalDays);
                        if(Diferencia > 0 && Diferencia <= 15)
                        {
                            e.Appearance.BackColor = Color.DarkOrange;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }

                        if (Diferencia <= 0)
                        {
                            e.Appearance.BackColor = Color.Red;
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
    }
}