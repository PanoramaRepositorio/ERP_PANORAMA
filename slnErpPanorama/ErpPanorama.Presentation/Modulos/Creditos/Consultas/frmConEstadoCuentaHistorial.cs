using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Creditos.Consultas
{
    public partial class frmConEstadoCuentaHistorial : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EstadoCuentaHistorialBE> mLista = new List<EstadoCuentaHistorialBE>();

        #endregion

        #region "Eventos"

        public frmConEstadoCuentaHistorial()
        {
            InitializeComponent();
        }

        private void frmConEstadoCuentaHistorial_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;
            BSUtils.LoaderLook(cboTipoRegistro , CargarTipoRegistro(), "Descripcion", "Id", true);

            deDesde.Focus();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }
        #endregion

        #region "Metodos"


        private void Cargar()
        {
            mLista = new EstadoCuentaHistorialBL().ListaFecha(Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()), Convert.ToInt32(cboMotivo.EditValue), cboTipoRegistro.Text);
            gcProducto.DataSource = mLista;

            lblTotalRegistros.Text = mLista.Count().ToString() + " Registros";
        }
        #endregion

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoAuditoriaEliminadoEstadoCuenta";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvProducto.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private DataTable CargarTipoRegistro()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.String"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = "E";
            dr["Descripcion"] = "ELIMINADO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = "94";
            dr["Descripcion"] = "AGREGADO";
            dt.Rows.Add(dr);

            return dt;
        }


    }
}