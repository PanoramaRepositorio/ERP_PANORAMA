using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Registros
{
    public partial class frmRegCabeceraDetalle : DevExpress.XtraEditors.XtraForm
    {

        #region "Propiedades"

        private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        #endregion

        #region "Eventos"

        public frmRegCabeceraDetalle()
        {
            InitializeComponent();
        }

        private void frmRegCabeceraDetalle_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            gcDocumentoVenta.DataSource = new DocumentoVentaBL().ListaComparaCabeceraDetalle(0, FechaInicio, FechaFin);
        }
        #endregion

        private void gvDocumentoVenta_DoubleClick(object sender, EventArgs e)
        {
            if (gvDocumentoVenta.RowCount > 0)
            {
                DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();
                objDocumentoVenta.IdDocumentoVenta = int.Parse(gvDocumentoVenta.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
                objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                objRegFacturacionEdit.IdDocumentoVenta = objDocumentoVenta.IdDocumentoVenta;
                objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                objRegFacturacionEdit.btnGrabar.Enabled = false;
                objRegFacturacionEdit.mnuContextual.Enabled = false;
                objRegFacturacionEdit.ShowDialog();

                Cargar();
            }
            else
            {
                MessageBox.Show("No se pudo editar");
            }
        }
    }
}