using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;

namespace ErpPanorama.Presentation.Modulos.Creditos.Consultas
{
    public partial class frmConEstadoCuenta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<EstadoCuentaBE> mLista = new List<EstadoCuentaBE>();

        public int IdCliente = 0;

        public string NumeroDocumento = "";
        public string DescCliente = "";
        public int IdMotivoVenta = 0;
        public int Origen = 0;
        
        #endregion

        #region "Eventos"

        public frmConEstadoCuenta()
        {
            InitializeComponent();
        }

        private void frmConEstadoCuenta_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = Convert.ToDateTime("01/01/2013");
            deHasta.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;

            //cargar según tipo
            if (Origen == 1) //Desde Consulta de saldos
            {
                txtNumeroDocumento.Text = NumeroDocumento;
                txtDescCliente.Text = DescCliente;
                cboMotivo.EditValue = IdMotivoVenta;
                btnConsultar_Click(sender, e);
            }

        }

        private void toolstpImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                if (IdCliente == 0)
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (gvEstadoCuenta.RowCount > 0)
                {
                    List<ReporteEstadoCuentaCabeceraBE> lstReporte = null;
                    lstReporte = new ReporteEstadoCuentaCabeceraBL().Listado(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));

                    if (lstReporte != null)
                    {
                        //Listar el datalle del reporte

                        List<ReporteEstadoCuentaDetalleBE> lstReporteEstadoCuentaDetalle = null;
                        lstReporteEstadoCuentaDetalle = new ReporteEstadoCuentaDetalleBL().Listado(deDesde.DateTime, deHasta.DateTime, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
                        if (lstReporte.Count > 0)
                        {
                            RptVistaReportes objRptAccUsu = new RptVistaReportes();
                            objRptAccUsu.VerRptEstadoCuenta(lstReporte, lstReporteEstadoCuentaDetalle,cboMotivo.Text);
                            objRptAccUsu.ShowDialog();
                        }
                        else
                            XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    Cursor = Cursors.Default;
                }


            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListadoEstadoCuenta";
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvEstadoCuenta.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
                XtraMessageBox.Show(_nM, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Cursor = Cursors.Default;
            }
        }

        private void toolstpRefrescar_Click(object sender, EventArgs e)
        {
            if (IdCliente == 0)
            {
                XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Cargar();
        }

        private void toolstpSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.pNumeroDescCliente = txtNumeroDocumento.Text.Trim();
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    ClienteCreditoBE objE_ClienteCredito = new ClienteCreditoBE();
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;
                    btnConsultar.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (IdCliente == 0)
            {
                XtraMessageBox.Show("Seleccione un Cliente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CargarLineaCredito();
            Cargar();
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnBuscar_Click(sender, e);

                //numero o cadena
                if (char.IsNumber(Convert.ToChar(txtNumeroDocumento.Text.Trim().Substring(0, 1))) == true)
                {
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                        txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                        txtDescCliente.Text = objE_Cliente.DescCliente;
                        txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                        Cargar();
                        CargarLineaCredito();
                        cboMotivo.Focus();

                        //Verificar TipoCliente
                        if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteFinal && objE_Cliente.IdClasificacionCliente != Parametros.intBlack)
                        {
                            XtraMessageBox.Show("Atención! El cliente es MINORISTA se recomienda registrar en el estado de cuenta Soles", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    btnBuscar_Click(sender, e);
                }

            }
        }

        private void cboMotivo_EditValueChanged(object sender, EventArgs e)
        {
            CargarLineaCredito();
            Cargar();
        }

        private void VerDocumentoVentatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEstadoCuenta.RowCount > 0)
                {
                    var Pedido = gvEstadoCuenta.GetFocusedRowCellValue("IdPedido");
                    if (Pedido != null)
                    {
                        int IdPedido = 0;
                        string Numero = "";

                        IdPedido = int.Parse(gvEstadoCuenta.GetFocusedRowCellValue("IdPedido").ToString());

                        frmRegVentaPedido objVentaPedido = new frmRegVentaPedido();
                        objVentaPedido.IdPedido = IdPedido;
                        objVentaPedido.NumeroPedido = Numero;
                        objVentaPedido.StartPosition = FormStartPosition.CenterParent;
                        objVentaPedido.Show();
                    }
                    else
                    {
                        var DocumentoVenta = gvEstadoCuenta.GetFocusedRowCellValue("IdDocumentoVenta");
                        if (DocumentoVenta != null)
                        {
                            int IdDocumentoVenta = 0;
                            IdDocumentoVenta = int.Parse(gvEstadoCuenta.GetFocusedRowCellValue("IdDocumentoVenta").ToString());

                            if (IdDocumentoVenta > 0)
                            {
                                frmRegFacturacionEdit objRegFacturacionEdit = new frmRegFacturacionEdit();
                                objRegFacturacionEdit.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                                objRegFacturacionEdit.IdDocumentoVenta = IdDocumentoVenta;
                                objRegFacturacionEdit.StartPosition = FormStartPosition.CenterParent;
                                objRegFacturacionEdit.btnGrabar.Enabled = false;
                                objRegFacturacionEdit.mnuContextual.Enabled = false;
                                objRegFacturacionEdit.ShowDialog();
                            }
                            else
                            {
                                XtraMessageBox.Show("No existe documentos asociados para este movimiento.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\nNo tiene asociado un pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvEstadoCuenta_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvEstadoCuenta.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["IdPedido"]);
                    if (objDocRetiro != null)
                    {
                        e.Appearance.BackColor = Color.LightGreen;
                        e.Appearance.BackColor2 = Color.SeaShell;
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void verpedidotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEstadoCuenta.RowCount > 0)
                {
                    int IdPedido = 0;

                    IdPedido = int.Parse(gvEstadoCuenta.GetFocusedRowCellValue("IdPedido").ToString());
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
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message + "\n Verificar si es pedido.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            mLista = new EstadoCuentaBL().ListaCliente(deDesde.DateTime, deHasta.DateTime, IdCliente,Convert.ToInt32(cboMotivo.EditValue));
            gcEstadoCuenta.DataSource = mLista;

            if (mLista.Count > 0)
            {
                decimal decTotalCargo = 0;
                decimal decTotalAbono = 0;
                decimal decSaldo = 0;

                foreach (var item in mLista)
                {
                    decTotalCargo = decTotalCargo + item.CreditoCargo;
                    decTotalAbono = decTotalAbono + item.PagoAbono;
                }

                txtTotalCargo.EditValue = decTotalCargo;
                txtTotalAbono.EditValue = decTotalAbono;
                decSaldo = decTotalCargo - decTotalAbono;
                txtSaldo.EditValue = decSaldo;
            }
        }

        private void CargarLineaCredito()
        {
            ClienteCreditoBE objE_ClienteCredito = null;
            objE_ClienteCredito = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
            if (objE_ClienteCredito != null)
            {
                txtLineaCredito.EditValue = objE_ClienteCredito.LineaCredito;
                txtLineaCreditoUtilizada.EditValue = objE_ClienteCredito.LineaCreditoUtilizada;
                txtLineaCreditoDisponible.EditValue = objE_ClienteCredito.LineaCreditoDisponible;
            }
            else
            {
                txtLineaCredito.EditValue = 0;
                txtLineaCreditoUtilizada.EditValue = 0;
                txtLineaCreditoDisponible.EditValue = 0;
            }
        }

        #endregion


    }
}