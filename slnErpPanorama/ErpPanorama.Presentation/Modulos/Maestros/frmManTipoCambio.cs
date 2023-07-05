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

namespace ErpPanorama.Presentation.Modulos.Maestros
{
    public partial class frmManTipoCambio : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<TipoCambioBE> mLista = new List<TipoCambioBE>();

        #endregion

        #region "Eventos"
        
        public frmManTipoCambio()
        {
            InitializeComponent();
        }

        private void frmManTipoCambio_Load(object sender, EventArgs e)
        {
            tlbMenu.Ensamblado = this.Tag.ToString();
            deFecha.EditValue = DateTime.Now;
            Cargar();
        }

        private void tlbMenu_NewClick()
        {
            try
            {
                frmManTipoCambioEdit objManTipoCambio = new frmManTipoCambioEdit();
                objManTipoCambio.lstTipoCambio = mLista;
                objManTipoCambio.pOperacion = frmManTipoCambioEdit.Operacion.Nuevo;
                objManTipoCambio.IdTipoCambio = 0;
                objManTipoCambio.StartPosition = FormStartPosition.CenterParent;
                objManTipoCambio.ShowDialog();
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
                        TipoCambioBE objE_TipoCambio = new TipoCambioBE();
                        objE_TipoCambio.IdTipoCambio = int.Parse(gvTipoCambio.GetFocusedRowCellValue("IdTipoCambio").ToString());
                        objE_TipoCambio.Usuario = Parametros.strUsuarioLogin;
                        objE_TipoCambio.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_TipoCambio.IdEmpresa = Parametros.intEmpresaId;

                        TipoCambioBL objBL_TipoCambio = new TipoCambioBL();
                        objBL_TipoCambio.Elimina(objE_TipoCambio);
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

               List<ReporteTipoCambioBE> lstReporte = null;
               lstReporte = new ReporteTipoCambioBL().Listado(Parametros.intEmpresaId,Parametros.intSoles);

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptTipoCambio = new RptVistaReportes();
                        objRptTipoCambio.VerRptTipoCambio(lstReporte);
                        objRptTipoCambio.ShowDialog();
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
            string _fileName = "ListadoTipoCambio";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvTipoCambio.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvTipoCambio_DoubleClick(object sender, EventArgs e)
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
            mLista = new TipoCambioBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intSoles);
            gcTipoCambio.DataSource = mLista;
        }

        private void CargarBusqueda()
        {
             gcTipoCambio.DataSource = mLista.Where(obj =>
                                                   obj.Fecha.ToShortDateString().Contains(Convert.ToDateTime(deFecha.EditValue).ToShortDateString())).ToList();                                    
        }

        public void InicializarModificar()
        {
            if (gvTipoCambio.RowCount > 0)
            {
                TipoCambioBE objTipoCambio = new TipoCambioBE();
                objTipoCambio.IdTipoCambio = int.Parse(gvTipoCambio.GetFocusedRowCellValue("IdTipoCambio").ToString());
                objTipoCambio.IdMoneda = int.Parse(gvTipoCambio.GetFocusedRowCellValue("IdMoneda").ToString());
                objTipoCambio.Fecha = DateTime.Parse(gvTipoCambio.GetFocusedRowCellValue("Fecha").ToString());
                objTipoCambio.Compra = Decimal.Parse(gvTipoCambio.GetFocusedRowCellValue("Compra").ToString());
                objTipoCambio.Venta = Decimal.Parse(gvTipoCambio.GetFocusedRowCellValue("Venta").ToString());
                objTipoCambio.CompraSunat = Decimal.Parse(gvTipoCambio.GetFocusedRowCellValue("CompraSunat").ToString());
                objTipoCambio.VentaSunat = Decimal.Parse(gvTipoCambio.GetFocusedRowCellValue("VentaSunat").ToString());

                frmManTipoCambioEdit objManTipoCambioEdit = new frmManTipoCambioEdit();
                objManTipoCambioEdit.pOperacion = frmManTipoCambioEdit.Operacion.Modificar;
                objManTipoCambioEdit.IdTipoCambio = objTipoCambio.IdTipoCambio;
                objManTipoCambioEdit.pTipoCambioBE = objTipoCambio;
                objManTipoCambioEdit.StartPosition = FormStartPosition.CenterParent;
                objManTipoCambioEdit.ShowDialog();

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

            if (gvTipoCambio.GetFocusedRowCellValue("IdTipoCambio").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione una TipoCambio", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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