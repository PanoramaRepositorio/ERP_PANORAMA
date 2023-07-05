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
using ErpPanorama.Presentation.Modulos.Logistica.Registros;
using ErpPanorama.Presentation.Modulos.Creditos.Consultas;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic.Reportes;
using ErpPanorama.BusinessEntity.Reportes;

namespace ErpPanorama.Presentation.Modulos.Ventas.Reportes
{
    public partial class frmRepPedidoRango : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<ReportePedidoBE> mLista = new List<ReportePedidoBE>();
        
        #endregion

        #region "Eventos"

        public frmRepPedidoRango()
        {
            InitializeComponent();
        }

        private void frmRepPedidoRango_Load(object sender, EventArgs e)
        {

            List<TiendaBE> lTienda = new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId);
            List<TablaElementoBE> lTipoCliente = new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblTipoCliente);
            lTipoCliente.RemoveAt(0);

            lTienda.Insert(0, new TiendaBE { DescTienda = "--TODOS--", IdTienda = 0 });
            lTipoCliente.Insert(0, new TablaElementoBE { DescTablaElemento = "--TODOS--", IdTablaElemento = 0 });

            BSUtils.LoaderLook(cboTienda, lTienda, "DescTienda", "IdTienda", true);
            BSUtils.LoaderLook(cboTipoCliente, lTipoCliente, "DescTablaElemento", "IdTablaElemento", true);

            this.Location = new Point(0, 0);
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            compraperfectatoolStripMenuItem.Visible = false;
            pedidoauditadotoolStripMenuItem.Visible = false;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        
   
        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoPedidoRango";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvPedido.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xlsx");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region "Metodos"

        private void Cargar()
        {
            int TipoConsulta = 0;
            if (chkAutoservicio.Checked)TipoConsulta = 1;

            DataTable dtPedido = new DataTable();
            mLista = new ReportePedidoBL().ListaReporte(Convert.ToInt32(cboTienda.EditValue), Convert.ToInt32(cboTipoCliente.EditValue), deDesde.DateTime, deHasta.DateTime, TipoConsulta);
            dtPedido = FuncionBase.ToDataTable(mLista);
            gcPedido.DataSource = dtPedido;
        }
        #endregion

       
        private void gvPedido_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvPedido.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdTipoDocumento"]);
                    if (objDocRetiro != null)
                    {
                        int IdTipoDocumento = int.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento != Parametros.intTipoDocPedidoVenta)
                        {
                            e.Appearance.BackColor = Color.LightGreen;
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