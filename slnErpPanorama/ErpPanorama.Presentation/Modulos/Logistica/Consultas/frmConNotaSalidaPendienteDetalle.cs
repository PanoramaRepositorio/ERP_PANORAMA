using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using System.Web.UI.WebControls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConNotaSalidaPendienteDetalle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<MovimientoAlmacenBE> mLista = new List<MovimientoAlmacenBE>();

        #endregion

        #region "Eventos"

        public frmConNotaSalidaPendienteDetalle()
        {
            InitializeComponent();
        }

        private void frmConNotaSalidaPendienteDetalle_Load(object sender, EventArgs e)
        {
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, 0), "DescAlmacen", "IdAlmacen", true);

            Cargar();
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new MovimientoAlmacenBL().ListaPendientesDetalle(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), 0, Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovSalida, Convert.ToDateTime(dateTimePicker1.Value), Convert.ToDateTime(dateTimePicker2.Value) );
            gcMovimientoAlmacen.DataSource = mLista;
            lblTotalRegistros.Text = gvMovimientoAlmacen.RowCount.ToString() + " Registros";
        }

        #endregion

        private void gvMovimientoAlmacen_DoubleClick(object sender, EventArgs e)
        {
            if (gvMovimientoAlmacen.RowCount > 0)
            {
                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();
                objMovimientoAlmacen.IdMovimientoAlmacen = int.Parse(gvMovimientoAlmacen.GetFocusedRowCellValue("IdMovimientoAlmacen").ToString());

                frmRegNotaSalidaEdit objManMovimientoAlmacenEdit = new frmRegNotaSalidaEdit();
                objManMovimientoAlmacenEdit.pOperacion = frmRegNotaSalidaEdit.Operacion.Modificar;
                objManMovimientoAlmacenEdit.IdMovimientoAlmacen = objMovimientoAlmacen.IdMovimientoAlmacen;
                objManMovimientoAlmacenEdit.StartPosition = FormStartPosition.CenterParent;
                objManMovimientoAlmacenEdit.btnGrabar.Enabled = false;
                if (objManMovimientoAlmacenEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaNotaSalidaPendiente";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvMovimientoAlmacen.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void gvMovimientoAlmacen_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //try
            //{
            //    object obj = gvMovimientoAlmacen.GetRow(e.RowHandle);

            //    DevExpress.XtraGrid.Views.Grid.GridView View = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //    if (e.RowHandle >= 0)
            //    {
            //        object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdMovimientoAlmacen"]);
            //        if (objDocRetiro != null)
            //        {
            //            int IdTipoDocumento = Convert.ToInt32(objDocRetiro.ToString());
            //            if (Convert.ToInt32(IdTipoDocumento)%2==0)
            //            {
            //                e.Appearance.BackColor = Color.LightGreen;
            //                e.Appearance.BackColor2 = Color.SeaShell;
            //            }
            //            else
            //            {
            //                e.Appearance.BackColor = Color.LightGoldenrodYellow;
            //                e.Appearance.BackColor2 = Color.SeaShell;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}