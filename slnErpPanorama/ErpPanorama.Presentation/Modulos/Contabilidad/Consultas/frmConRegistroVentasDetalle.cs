using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Contabilidad.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Consultas
{
    public partial class frmConRegistroVentasDetalle : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        #endregion

        #region "Eventos"
        public frmConRegistroVentasDetalle()
        {
            InitializeComponent();
        }

        private void frmConRegistroVentasDetalle_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = DateTime.Now;
            deHasta.EditValue = DateTime.Now;
            Cargar();
        }
        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaVentaDetalle";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumento.ExportToXlsx(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xlsx");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
        }

        private void gvDocumento_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }


        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new DocumentoVentaBL().ListaGeneralDetalle(0, deDesde.DateTime, deHasta.DateTime);
            gcDocumento.DataSource = mLista;

            //CalcularTotalDocumentos();

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
            if (gvDocumento.RowCount > 0)
            {
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();
                objDocumentoVenta.IdDocumentoVenta = int.Parse(gvDocumento.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
                objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                objRegFacturacionEdit.IdDocumentoVenta = objDocumentoVenta.IdDocumentoVenta;
                objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                if (objRegFacturacionEdit.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }

        private void CalcularTotalDocumentos()
        {
            //try
            //{
            //    decimal decTotal = 0;

            //    for (int i = 0; i < gvDocumento.RowCount; i++)
            //    {
            //        decTotal = decTotal + Convert.ToDecimal(gvDocumento.GetRowCellValue(i, (gvDocumento.Columns["Total"])));
            //    }
            //    txtTotal.EditValue = decTotal;
            //    lblTotalRegistros.Text = gvDocumento.RowCount.ToString() + " Registros";
            //}
            //catch (Exception ex)
            //{
            //    XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        #endregion

    }
}