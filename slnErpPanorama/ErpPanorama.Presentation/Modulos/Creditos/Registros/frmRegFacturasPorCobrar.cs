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
using DevExpress.XtraGrid.Views.Grid;
using ErpPanorama.Presentation.Modulos.Creditos.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;

namespace ErpPanorama.Presentation.Modulos.Creditos.Registros
{
    public partial class frmRegFacturasPorCobrar : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<FacturaPorCobrarBE> mLista = new List<FacturaPorCobrarBE>();
        private List<EstadoCuentaClienteBE> mListaEstadoCuenta = new List<EstadoCuentaClienteBE>();

        #endregion

        #region "Eventos"

        public frmRegFacturasPorCobrar()
        {
            InitializeComponent();
        }

        private void frmRegFacturasPorCobrar_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            deDesde.EditValue = Convert.ToDateTime("01/01/2019");
            deHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionDocContable), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = 350;

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Cargar();
            CargarPagos();
        }

        private void gvDocumentoVenta_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            try
            {
                object obj = gvDocumentoVenta.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["DiasVencimiento"]);
                    if (objDocRetiro != null)
                    {
                        decimal IdTipoDocumento = decimal.Parse(objDocRetiro.ToString());
                        if (IdTipoDocumento > 0)
                        {
                            gvDocumentoVenta.Columns["DiasVencimiento"].AppearanceCell.ForeColor = Color.Red;
                            gvDocumentoVenta.Columns["DiasVencimiento"].AppearanceCell.Font = new Font(this.Font, FontStyle.Bold);
                        }
                        else
                       if (IdTipoDocumento == 0)
                        {
                            gvDocumentoVenta.Columns["DiasVencimiento"].AppearanceCell.ForeColor = Color.Orange;
                            gvDocumentoVenta.Columns["DiasVencimiento"].AppearanceCell.Font = new Font(this.Font, FontStyle.Bold);
                        }
                        else
                        {
                            gvDocumentoVenta.Columns["DiasVencimiento"].AppearanceCell.ForeColor = Color.Green;
                            gvDocumentoVenta.Columns["DiasVencimiento"].AppearanceCell.Font = new Font(this.Font, FontStyle.Bold);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolstpImprimir_Click(object sender, EventArgs e)
        {

        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            Cargar();
            CargarPagos();
        }

        private void toolstpExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoFacturaPorCobrar";
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

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cobrarfacturatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mLista.Count > 0)
            {
                FacturaPorCobrarBE objE_DocumentoVenta = (FacturaPorCobrarBE)gvDocumentoVenta.GetRow(gvDocumentoVenta.FocusedRowHandle);
                frmCobrarFactura frm = new frmCobrarFactura();
                frm.IdPedido = Convert.ToInt32(objE_DocumentoVenta.IdPedido);
                frm.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                frm.IdCliente = objE_DocumentoVenta.IdCliente;
                frm.IdTipoDocumento = objE_DocumentoVenta.IdTipoDocumento;
                frm.IdTipoCliente = objE_DocumentoVenta.IdTipoCliente;
                frm.IdTipoClasificacionCliente = objE_DocumentoVenta.IdClasificacionCliente;
                frm.IdMoneda = objE_DocumentoVenta.IdMoneda;
                frm.TotalFactura = objE_DocumentoVenta.Total;
                frm.NumeroFactura = objE_DocumentoVenta.Numero;//objE_DocumentoVenta.Numero.Substring(3, objE_DocumentoVenta.Numero.Length-1);
                frm.IdEmpresa = objE_DocumentoVenta.IdEmpresa;
                frm.StartPosition = FormStartPosition.CenterParent;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Cargar();
                }
            }

        }

        private void gvDocumentoVenta_DoubleClick(object sender, EventArgs e)
        {
            if (gvDocumentoVenta.RowCount > 0)
            {
                FacturaPorCobrarBE objE_DocumentoVenta = (FacturaPorCobrarBE)gvDocumentoVenta.GetRow(gvDocumentoVenta.FocusedRowHandle);

                frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                frm.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                frm.mnuContextual.Enabled = false;
                frm.btnGrabar.Enabled = false;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void verpedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvDocumentoVenta.RowCount > 0)
            {
                int IdPedido = 0;
                IdPedido = int.Parse(gvDocumentoVenta.GetFocusedRowCellValue("IdPedido").ToString());
                if (IdPedido.ToString() != "")
                {
                    frmRegPedidoEdit frm = new frmRegPedidoEdit();
                    frm.IdPedido = IdPedido;
                    frm.pOperacion = frmRegPedidoEdit.Operacion.Consultar;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }

            }
        }

        private void verdocumentoventatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvDocumentoVenta.RowCount > 0)
            {
                FacturaPorCobrarBE objE_DocumentoVenta = (FacturaPorCobrarBE)gvDocumentoVenta.GetRow(gvDocumentoVenta.FocusedRowHandle);

                frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                frm.IdDocumentoVenta = objE_DocumentoVenta.IdDocumentoVenta;
                frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                frm.mnuContextual.Enabled = false;
                frm.btnGrabar.Enabled = false;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

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
                        frmRegEstadoCuentaCliente frm = new frmRegEstadoCuentaCliente();
                        frm.IdCliente = IdCliente;
                        frm.NumeroDocumento = objE_Cliente.NumeroDocumento;
                        frm.DescCliente = objE_Cliente.DescCliente;
                        frm.Origen = 1;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }


                    //if (IdCliente.ToString() != "")
                    //{
                    //    //if (objE_Cliente.IdTipoCliente  == Parametros.intTipClienteMayorista)
                    //    if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                    //    {
                    //        ////var objE_EstadoCuenta;
                    //        //EstadoCuentaBE objE_EstadoCuenta = null;
                    //        //objE_EstadoCuenta = (EstadoCuentaBE)gvPedido.GetFocusedRow();

                    //        ////XtraMessageBox.Show(objE_EstadoCuenta.DescCliente +"   "+ objE_EstadoCuenta.Concepto, this.Text);

                    //        frmRegEstadoCuentaCliente frm = new frmRegEstadoCuentaCliente();
                    //        frm.IdCliente = IdCliente;
                    //        frm.NumeroDocumento = objE_Cliente.NumeroDocumento;
                    //        frm.DescCliente = objE_Cliente.DescCliente;
                    //        frm.IdMotivoVenta = IdMotivo;
                    //        frm.Origen = 1;
                    //        frm.StartPosition = FormStartPosition.CenterParent;
                    //        frm.ShowDialog();
                    //    }
                    //    //else
                    //    //{
                    //    //    //SeparacionBE objE_Separacion = null;
                    //    //    //objE_Separacion = (SeparacionBE)gvPedido.GetFocusedRow();

                    //    //    frmRegEstadoCuentaCliente frm = new frmRegEstadoCuentaCliente();
                    //    //    frm.IdCliente = IdCliente;
                    //    //    frm.NumeroDocumento = objE_Cliente.NumeroDocumento;//  gvPedido.GetFocusedRowCellValue("NumeroDocumento").ToString();
                    //    //    frm.DescCliente = objE_Cliente.DescCliente;// gvPedido.GetFocusedRowCellValue("DescCliente").ToString();
                    //    //    frm.IdMotivoVenta = IdMotivo;
                    //    //    frm.Origen = 1;
                    //    //    frm.StartPosition = FormStartPosition.CenterParent;
                    //    //    frm.ShowDialog();
                    //    //}
                    //}
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Seleccionar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verestadocuentapagotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEstadoCuentaCliente.RowCount > 0)
                {
                    int IdCliente = 0;
                    IdCliente = int.Parse(gvEstadoCuentaCliente.GetFocusedRowCellValue("IdCliente").ToString());

                    ClienteBE objE_Cliente = new ClienteBE();
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intEmpresaId, IdCliente);

                    if (IdCliente.ToString() != "")
                    {
                        frmRegEstadoCuentaCliente frm = new frmRegEstadoCuentaCliente();
                        frm.IdCliente = IdCliente;
                        frm.NumeroDocumento = objE_Cliente.NumeroDocumento;
                        frm.DescCliente = objE_Cliente.DescCliente;
                        frm.Origen = 1;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Seleccionar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new FacturaPorCobrarBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboSituacion.EditValue), Convert.ToDateTime(deDesde.DateTime.ToShortDateString()), Convert.ToDateTime(deHasta.DateTime.ToShortDateString()));
            gcDocumentoVenta.DataSource = mLista;

        }

        private void CargarPagos()
        {
            mListaEstadoCuenta = new EstadoCuentaClienteBL().ListaTodosActivo(Parametros.intEmpresaId, 0, "A", Parametros.intSitPendienteCon);
            gcEstadoCuentaCliente.DataSource = mListaEstadoCuenta;
        }
        #endregion


    }
}