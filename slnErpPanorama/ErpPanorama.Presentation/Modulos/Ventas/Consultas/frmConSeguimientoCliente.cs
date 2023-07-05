using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Maestros.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Consultas
{
    public partial class frmConSeguimientoCliente : DevExpress.XtraEditors.XtraForm
    {
        private List<ClienteBE> mLista = new List<ClienteBE>();

        private int TipoReporte = 0;

        public frmConSeguimientoCliente()
        {
            InitializeComponent();
        }

        private void frmConSeguimientoCliente_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = Convert.ToDateTime("01/01/" + DateTime.Now.AddYears(-1).Year);
            deHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboRuta, new RutaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescRuta", "IdRuta", true);
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaCargo(Parametros.intEmpresaId, Parametros.intGestorCartera), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionCliente), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intSITClienteActivo;
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {

            if(chkLineas.Checked == true)
                TipoReporte =0;
            else
                TipoReporte = 1;

            mLista = new ClienteBL().ListaTodosActivoRuta(Convert.ToInt32(cboRuta.EditValue), 0, deDesde.DateTime, deHasta.DateTime, TipoReporte);
            gcCliente.DataSource = mLista;
            lblTotalRegistros.Text = mLista.Count() + " Registros Encontrados";
            //cboVendedor.Text = mLista[0].DescVendedor;
        }

        private void cboRuta_EditValueChanged(object sender, EventArgs e)
        {
            if (cboRuta.EditValue != "")
            {
                RutaBE objE_Ruta = null;
                objE_Ruta = new RutaBL().Selecciona(Parametros.intEmpresaId,Convert.ToInt32(cboRuta.EditValue));
                if (objE_Ruta != null)
                {
                    cboVendedor.EditValue = objE_Ruta.IdVendedor;
                }
            }
            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoClienteMayoristaSeguimiento";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvCliente.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }


        private void gvCliente_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gvCliente.RowCount > 0)
            {
                DataRow dr;
                int IdCliente = 0;
                dr = gvCliente.GetDataRow(e.RowHandle);
                IdCliente = int.Parse(dr["IdCliente"].ToString());
            }
        }

        private void FilaDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                InicializarConsultar();
            }
        }

        public void InicializarConsultar()
        {
            if (gvCliente.RowCount > 0)
            {
                ClienteBE objClientel = new ClienteBE();
                objClientel.IdCliente = int.Parse(gvCliente.GetFocusedRowCellValue("IdCliente").ToString());

                frmManClienteMayoristaEdit objManClientelEdit = new frmManClienteMayoristaEdit();
                objManClientelEdit.pOperacion = frmManClienteMayoristaEdit.Operacion.Modificar;
                objManClientelEdit.IdCliente = objClientel.IdCliente;
                objManClientelEdit.StartPosition = FormStartPosition.CenterParent;
                objManClientelEdit.btnGrabar.Enabled = true;
                objManClientelEdit.ShowDialog();

            }
        }

        private void gvCliente_DoubleClick(object sender, EventArgs e)
        {
            //GridView view = (GridView)sender;
            //Point pt = view.GridControl.PointToClient(Control.MousePosition);
            //FilaDoubleClick(view, pt);
        }

        private void modificartoolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarConsultar();
        }

        private void gvCliente_ColumnFilterChanged(object sender, EventArgs e)
        {
            lblTotalRegistros.Text = gvCliente.RowCount.ToString() + " Registros Encontrados";
        }
    }
}