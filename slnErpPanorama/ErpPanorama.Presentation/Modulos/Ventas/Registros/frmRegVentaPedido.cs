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
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using ErpPanorama.Presentation.Modulos.Creditos.Consultas;
using ErpPanorama.Presentation.Modulos.Creditos.Registros;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegVentaPedido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<DocumentoVentaBE> mLista = new List<DocumentoVentaBE>();

        public int IdPedido { get; set; }
        public string NumeroPedido { get; set; }
        public int IdVendedor = 0;

        public DateTime FechaDesde;
        public DateTime FechaHasta;

        #endregion

        #region "Eventos"

        public frmRegVentaPedido()
        {
            InitializeComponent();
        }

        private void frmRegVentaPedido_Load(object sender, EventArgs e)
        {
            if (IdVendedor == 0)
            {
                lblPedido.Text = NumeroPedido;
                Cargar();
                CalcularTotalDocumentos();
            }
            else
            {
                lblPedido.Text = "";
                labelControl2.Text = "Documentos Facturados por Vendedor";
                verdetalletoolStripMenuItem.Enabled = false;
                modificardocumentoToolStripMenuItem.Enabled = false;
                CargarVentaVendedor();
                CalcularTotalDocumentos();                
            }

        }

        private void modificardocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvDocumentoVenta.RowCount > 0)
            {
                frmActualizaDocumentoVenta objDocumentoVenta = new frmActualizaDocumentoVenta();
                objDocumentoVenta.IdEmpresa = int.Parse(gvDocumentoVenta.GetFocusedRowCellValue("IdEmpresa").ToString());
                objDocumentoVenta.IdDocumentoVenta = int.Parse(gvDocumentoVenta.GetFocusedRowCellValue("IdDocumentoVenta").ToString());
                objDocumentoVenta.Serie = gvDocumentoVenta.GetFocusedRowCellValue("Serie").ToString();
                objDocumentoVenta.Numero = gvDocumentoVenta.GetFocusedRowCellValue("Numero").ToString();
                objDocumentoVenta.StartPosition = FormStartPosition.CenterParent;
                objDocumentoVenta.ShowDialog();

                Cargar();
            }
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

        private void gvDocumentoVenta_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvDocumentoVenta.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdTipoDocumento"]);
                    object objDocSituacion = View.GetRowCellValue(e.RowHandle, View.Columns["IdSituacionContable"]);
                    if (objDocRetiro != null)
                    {
                        int IdTipoDocumento = int.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento == Parametros.intTipoDocNotaCredito|| IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }

                    if (objDocSituacion != null)
                    {
                        int IdSituacion = int.Parse(objDocSituacion.ToString());
                        if (IdSituacion == Parametros.intSitPagadoCon)
                        {
                            //e.Appearance.ForeColor = Color.GreenYellow;
                            //e.Appearance.BackColor2 = Color.SeaShell;
                            //gvDocumentoVenta.Columns["DescSituacionContable"].AppearanceCell.BackColor = Color.GreenYellow;
                            //gvDocumentoVenta.Columns["DescSituacionContable"].AppearanceCell.BackColor2 = Color.SeaShell;

                            gvDocumentoVenta.Columns["DescSituacionContable"].AppearanceCell.ForeColor = Color.Green;
                            gvDocumentoVenta.Columns["DescSituacionContable"].AppearanceCell.Font = new Font(gvDocumentoVenta.Columns["DescSituacionContable"].AppearanceCell.Font, FontStyle.Bold);
                        }
                        else
                        {
                            gvDocumentoVenta.Columns["DescSituacionContable"].AppearanceCell.ForeColor = Color.Black;
                            gvDocumentoVenta.Columns["DescSituacionContable"].AppearanceCell.Font = new Font(gvDocumentoVenta.Columns["DescSituacionContable"].AppearanceCell.Font, FontStyle.Regular);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            gcDocumentoVenta.DataSource = new DocumentoVentaBL().SeleccionaPedido(IdPedido);
            lblTotalRegistros.Text = gvDocumentoVenta.RowCount.ToString() + " Registros encontrados";
        }

        private void CargarVentaVendedor()
        {
            gcDocumentoVenta.DataSource = new DocumentoVentaBL().ListaVendedor(IdVendedor, FechaDesde, FechaHasta);
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
                //objRegFacturacionEdit.ShowDialog();

                if (objRegFacturacionEdit.ShowDialog() == DialogResult.OK)
                {
                    if (IdVendedor == 0)
                    {
                        Cargar();
                    }
                    else
                    {
                        CargarVentaVendedor();
                    }
                }
                ////Cargar();
                //if (IdVendedor == 0)
                //{
                //    Cargar();
                //}
                //else
                //{
                //    CargarVentaVendedor();
                //}

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
                    //objRegFacturacionEdit.ShowDialog();

                    if (objRegFacturacionEdit.ShowDialog() == DialogResult.OK)
                    {
                        //Cargar();
                        if (IdVendedor == 0)
                        {
                            Cargar();
                        }
                        else
                        {
                            CargarVentaVendedor();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo editar");
                }
            }
        }

        private void CalcularTotalDocumentos()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvDocumentoVenta.RowCount; i++)
                {
                    //if (Convert.ToInt32(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["IdTipoDocumento"]))) != Parametros.intTipoDocNotaCredito)
                    //{
                    //    decTotal = decTotal + Convert.ToDecimal(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["Total"])));
                    //}
                    //else
                    //{
                    //    decTotal = decTotal - Convert.ToDecimal(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["Total"])));
                    //}
                    decTotal = decTotal + Convert.ToDecimal(gvDocumentoVenta.GetRowCellValue(i, (gvDocumentoVenta.Columns["Total"])));

                }
                txtTotal.EditValue = decTotal;

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        #endregion

        private void verestadocuentatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvDocumentoVenta.RowCount > 0)
                {
                    int IdCliente = 0;
                    IdCliente = int.Parse(gvDocumentoVenta.GetFocusedRowCellValue("IdCliente").ToString());

                    ClienteBE objE_Cliente = new ClienteBE();
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                    if (IdCliente.ToString() != "")
                    {
                        if(Parametros.intPerfilId == Parametros.intPerAdministrador)
                        {
                            frmRegEstadoCuentaCliente frm = new frmRegEstadoCuentaCliente();
                            frm.IdCliente = IdCliente;
                            frm.NumeroDocumento = objE_Cliente.NumeroDocumento;
                            frm.DescCliente = objE_Cliente.DescCliente;
                            frm.Origen = 1;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                        else
                        {
                            frmConEstadoCuentaCliente frm = new frmConEstadoCuentaCliente();
                            frm.IdCliente = IdCliente;
                            frm.NumeroDocumento = objE_Cliente.NumeroDocumento;
                            frm.DescCliente = objE_Cliente.DescCliente;
                            frm.Origen = 1;
                            frm.StartPosition = FormStartPosition.CenterParent;
                            frm.ShowDialog();
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Seleccionar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}