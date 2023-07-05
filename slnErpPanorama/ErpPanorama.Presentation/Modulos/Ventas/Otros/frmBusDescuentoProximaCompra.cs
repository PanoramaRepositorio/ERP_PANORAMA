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
using ErpPanorama.Presentation.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Ventas.Otros
{
    public partial class frmBusDescuentoProximaCompra : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        public int IdPedido { get; set; }
        public string NumeroPedido { get; set; }
        public decimal Descuento { get; set; }

        public int IdCliente = 0;
        public int IdDocumentoVenta = 0;

        public DateTime FechaDesde;
        public DateTime FechaHasta;


        #endregion

        #region "Eventos"

        public frmBusDescuentoProximaCompra()
        {
            InitializeComponent();
        }

        private void frmBusDescuentoProximaCompra_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDocumentoReferencia, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentasReferencia, 0), "CodTipoDocumento", "IdTipoDocumento", false);

        }

        private void gvDocumentoVenta_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
        }

        private void verdetalletoolStripMenuItem_Click(object sender, EventArgs e)
        {
            InicializarModificar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoDocumentoVenta_" + NumeroPedido;
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvDocumentoVenta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void txtNumeroReferencia_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    DocumentoVentaBE objE_DocumentoVenta = null;
                    objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Parametros.intIdPanoramaDistribuidores, Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                    if (objE_DocumentoVenta != null)
                    {
                        IdCliente = 0;
                        IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                        Cargar();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        Cargar();
                    }
                    else
                    {
                        XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pNumeroDescCliente = txtNumeroDocumento.Text;
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    Cargar();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (gvDocumentoVenta.RowCount > 0)
            {
                Descuento = Decimal .Parse(gvDocumentoVenta.GetFocusedRowCellValue("PorcentajeDescuento").ToString());
                IdDocumentoVenta = Int32.Parse(gvDocumentoVenta.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                this.DialogResult = DialogResult.OK;
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            gcDocumentoVenta.DataSource = new DocumentoVentaBL().ListaDescuentoProxima(IdCliente, IdDocumentoVenta);
            lblTotalRegistros.Text = gvDocumentoVenta.RowCount.ToString() + " Registros encontrados";
        }

        public void InicializarModificar()
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
                objRegFacturacionEdit.mnuContextual.Enabled = true;
                objRegFacturacionEdit.ShowDialog();
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
                }
                else
                {
                    MessageBox.Show("No se pudo editar");
                }
            }
        }

        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}