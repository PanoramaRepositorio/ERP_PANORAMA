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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegDevolucionBultos : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<BultoBE> mLista = new List<BultoBE>();

        #endregion

        #region "Eventos"

        public frmRegDevolucionBultos()
        {
            InitializeComponent();
        }

        private void frmRegDevolucionBultos_Load(object sender, EventArgs e)
        {
            CargarBusqueda();
        }


        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaBultosTransferidos";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvBulto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            CargarBusqueda();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNumero.Text.Trim().Length > 0)
                {
                    gcBulto.DataSource = new BultoBL().ListaNumeroBulto(Parametros.intEmpresaId, txtNumero.Text.Trim(), Parametros.intBULTransferido);
                    gcBulto.RefreshDataSource();
                }
            }
        }

        private void gvBulto_DoubleClick(object sender, EventArgs e)
        {

            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void txtProducto_EditValueChanged(object sender, EventArgs e)
        {
            if (txtProducto.Text.ToString().Trim().Length > 2)
            {
                CargarBusqueda();
            }

        }

        

        #endregion

        #region "Metodos"

        private void CargarBusqueda()
        {

            gcBulto.DataSource = new BultoBL().ListaTransferidos(Parametros.intEmpresaId, txtProducto.Text);
            gcBulto.RefreshDataSource();
        }

       
        public void InicializarModificar()
        {
            if (gvBulto.RowCount > 0)
            {
                int IdBulto = int.Parse(gvBulto.GetFocusedRowCellValue("IdBulto").ToString());

                frmRegDevolucionBultosEdit objManBultoEdit = new frmRegDevolucionBultosEdit();
                objManBultoEdit.pOperacion = frmRegDevolucionBultosEdit.Operacion.Modificar;
                objManBultoEdit.IdBulto = IdBulto;
                objManBultoEdit.SituacionBulto = Parametros.intBULTransferido;
                objManBultoEdit.StartPosition = FormStartPosition.CenterParent;
                objManBultoEdit.ShowDialog();

                CargarBusqueda();
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

        #endregion

        

        
    }
}