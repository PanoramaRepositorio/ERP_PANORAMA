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

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmConNotaSalidaPendiente : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"
        private List<MovimientoAlmacenBE> mLista = new List<MovimientoAlmacenBE>();

        #endregion

        #region "Eventos"

        public frmConNotaSalidaPendiente()
        {
            InitializeComponent();
        }

        private void frmConNotaSalidaPendiente_Load(object sender, EventArgs e)
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
            mLista = new MovimientoAlmacenBL().ListaPendientes(Parametros.intEmpresaId, Convert.ToInt32(txtPeriodo.EditValue), 0, Convert.ToInt32(cboAlmacen.EditValue), Parametros.intTipMovSalida, Convert.ToDateTime(dateTimePicker1.Value), Convert.ToDateTime(dateTimePicker2.Value) );
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
    }
}