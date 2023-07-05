using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Contabilidad.Rpt;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.ComercioExterior.Registros
{
    public partial class frmRegConConsumo : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ConConsumoBE> mLista = new List<ConConsumoBE>();

        #endregion

        #region "Eventos"

        public frmRegConConsumo()
        {
            InitializeComponent();
        }

        private void frmRegConConsumo_Load(object sender, EventArgs e)
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
                frmRegConConsumoEdit objManDocumentoVenta = new frmRegConConsumoEdit();
                objManDocumentoVenta.pOperacion = frmRegConConsumoEdit.Operacion.Nuevo;
                objManDocumentoVenta.IdConConsumo = 0;
                objManDocumentoVenta.StartPosition = FormStartPosition.CenterParent;
                objManDocumentoVenta.ShowDialog();
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
                        ConConsumoBE objE_ConConsumo = new ConConsumoBE();
                        objE_ConConsumo = new ConConsumoBL().Selecciona(int.Parse(gvDocumento.GetFocusedRowCellValue("IdConConsumo").ToString()));
                        objE_ConConsumo.Usuario = Parametros.strUsuarioLogin;
                        objE_ConConsumo.Maquina = "";

                        ConConsumoBL objBL_ConConsumo = new ConConsumoBL();
                        objBL_ConConsumo.Elimina(objE_ConConsumo);
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

        }

        private void tlbMenu_ExportClick()
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoGastos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumento.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void tlbMenu_ExitClick()
        {
            this.Close();
        }

        private void gvDocumento_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new ConConsumoBL().ListaTodosActivo(Parametros.intEmpresaId);
            gcDocumento.DataSource = mLista;
        }


        public void InicializarModificar()
        {
            if (gvDocumento.RowCount > 0)
            {
                ConConsumoBE objDocumentoVenta = new ConConsumoBE();
                objDocumentoVenta.IdConConsumo = int.Parse(gvDocumento.GetFocusedRowCellValue("IdConConsumo").ToString());
                frmRegConConsumoEdit objRegFacturacionEdit = new frmRegConConsumoEdit();
                objRegFacturacionEdit.pOperacion = frmRegConConsumoEdit.Operacion.Modificar;
                objRegFacturacionEdit.IdConConsumo = objDocumentoVenta.IdConConsumo;
                objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                objRegFacturacionEdit.ShowDialog();

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

            if (gvDocumento.GetFocusedRowCellValue("IdConConsumo").ToString() == "")
            {
                XtraMessageBox.Show("Seleccione un documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                flag = true;
            }

            Cursor = Cursors.Default;
            return flag;
        }

        #endregion


    }
}