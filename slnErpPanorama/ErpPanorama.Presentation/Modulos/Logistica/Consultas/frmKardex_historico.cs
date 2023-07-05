using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using ErpPanorama.Presentation.Modulos.ComercioExterior.Registros;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Modulos.Logistica.Registros;

namespace ErpPanorama.Presentation.Modulos.Logistica.Consultas
{
    public partial class frmKardex_historico : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        List<KardexBE> mLista = new List<KardexBE>();
        private int IdProducto = 0;

        #endregion

        #region "Eventos"

        public frmKardex_historico()
        {
            InitializeComponent();
        }

        private void frmKardex_historico_Load(object sender, EventArgs e)
        {
            deDesde.EditValue = Convert.ToDateTime("01/01/"+ Parametros.intPeriodo); //DateTime.Now;
            //deDesde.EditValue = Convert.ToDateTime("28/07/" + Parametros.intPeriodo); //DateTime.Now;
            deHasta.EditValue = DateTime.Now;

            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", false);
            cboTienda.EditValue = Parametros.intTiendaId;
            txtCodigo.Select();
        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {
            if (cboTienda.EditValue != null)
            {
                BSUtils.LoaderLook(cboAlmacen, new AlmacenBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescAlmacen", "IdAlmacen", true);
                //cboAlmacen.EditValue = Parametros.intAlmCentralUcayali;
            }
        }

        private void toolstpExportarExcel_Click(object sender, EventArgs e)
        {
            string _msg = "Se genero el archivo excel de forma satisfactoria en la siguiente ubicación.\n{0}";
            string _fileName = "ListaKardexProducto_" + txtCodigo.Text.Trim();
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.ShowDialog(this);
            if (f.SelectedPath != "")
            {
                Cursor = Cursors.AppStarting;
                gvInventarioDetalle.ExportToXls(f.SelectedPath + @"\" + _fileName + ".xls");
                string _nM = string.Format(_msg, f.SelectedPath + @"\" + _fileName + ".xls");
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

        private void txtCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //   ProductoBE objE_Producto = null;
            //    objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
            //    if (objE_Producto != null)
            //    {
            //        IdProducto = objE_Producto.IdProducto;
            //        txtCodigo.Text = objE_Producto.CodigoProveedor;
            //        txtDescripcion.Text = objE_Producto.NombreProducto;

            //        btnConsultar.Focus();
            //    }
            //    else
            //    {
            //        XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusProducto frm = new frmBusProducto();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pProductoBE != null)
                {
                    IdProducto = frm.pProductoBE.IdProducto;
                    txtCodigo.Text = frm.pProductoBE.CodigoProveedor;
                    txtDescripcion.Text = frm.pProductoBE.NombreProducto;
                }

                btnConsultar.Focus();
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                optCodigo.Checked = true;
                txtCodigo.Select();
            }
            if (keyData == Keys.F6)
            {
                optHangTag.Checked = true;
                txtCodigo.Select();
                //txtCodigo.SelectAll();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gvInventarioDetalle_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

        }

        private void gvInventarioDetalle_RowStyle(object sender, RowStyleEventArgs e)
        {
            try
            {
                object obj = gvInventarioDetalle.GetRow(e.RowHandle);

                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    object objDocRetiro = View.GetRowCellValue(e.RowHandle, View.Columns["CodTipoDocumento"]);
                    object objDocRetiro2 = View.GetRowCellValue(e.RowHandle, View.Columns["Observacion"]);
                    if (objDocRetiro != null)
                    {
                        string IdTipoDocumento = objDocRetiro.ToString();
                        if (IdTipoDocumento == "INV")
                        {
                            e.Appearance.BackColor = Color.LightGreen;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                        else
                        if (IdTipoDocumento == "AJU")
                        {
                            e.Appearance.BackColor = Color.LightGray;
                            e.Appearance.BackColor2 = Color.Cyan;
                        }
                    }

                    if (objDocRetiro2 != null)
                    {
                        string IdTipoDocumento = objDocRetiro2.ToString();
                        if (IdTipoDocumento == "Reservado para Pedido(TRANSITO)")
                        {
                            e.Appearance.BackColor = Color.Orange;
                            e.Appearance.BackColor2 = Color.SeaShell;
                        }
                    }

                    if (objDocRetiro2 != null)
                    {
                        string IdTipoDocumento = objDocRetiro2.ToString();
                        if (IdTipoDocumento == "Reservado para PREVENTA")
                        {
                            e.Appearance.BackColor = Color.Peru;
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

        private void gvInventarioDetalle_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            FilaDoubleClick(view, pt);
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
            if (gvInventarioDetalle.RowCount > 0)
            {
                int IdKardex = 0;
                int IdTipoDocumento = 0;
                IdKardex = int.Parse(gvInventarioDetalle.GetFocusedRowCellValue("IdKardex").ToString());
                IdTipoDocumento = int.Parse(gvInventarioDetalle.GetFocusedRowCellValue("IdTipoDocumento").ToString());

                if (IdTipoDocumento == Parametros.intTipoDocFacturaCompra)
                {
                    frmManFacturaCompraEdit frm = new frmManFacturaCompraEdit();
                    frm.IdFacturaCompra = IdKardex;
                    frm.pOperacion = frmManFacturaCompraEdit.Operacion.Modificar;
                    frm.bntImportarDocumento.Enabled = false;
                    frm.btnGrabar.Enabled = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }

                if (IdTipoDocumento == Parametros.intTipoDocNotaCredito)
                {
                    frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                    frm.IdDocumentoVenta = IdKardex;
                    frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                    frm.mnuContextual.Enabled = false;
                    frm.btnGrabar.Enabled = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }

                if (IdTipoDocumento == Parametros.intTipoDocNotaIngreso)
                {
                    frmRegNotaIngresoEdit frm = new frmRegNotaIngresoEdit();
                    frm.IdMovimientoAlmacen = IdKardex;
                    frm.pOperacion = frmRegNotaIngresoEdit.Operacion.Modificar;
                    //frm.mnuContextual.Enabled = false;
                    frm.btnGrabar.Enabled = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }

                if (IdTipoDocumento == Parametros.intTipoDocNotaSalida)
                {
                    frmRegNotaSalidaEdit frm = new frmRegNotaSalidaEdit();
                    frm.IdMovimientoAlmacen = IdKardex;
                    frm.pOperacion = frmRegNotaSalidaEdit.Operacion.Modificar;
                    //frm.mnuContextual.Enabled = false;
                    frm.btnGrabar.Enabled = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }

                if (IdTipoDocumento == 877 || IdTipoDocumento == Parametros.intTipoDocPedidoVenta) //Transito - Nuevo
                {
                    frmRegPedidoEdit frm = new frmRegPedidoEdit();
                    frm.IdPedido = IdKardex;
                    frm.pOperacion = frmRegPedidoEdit.Operacion.Consultar;
                    //frm.DesHabilitar();
                    //frm.DesHabilitarCabecera();
                    //frm.DesHabilitarEdition();
                    //frm.cboTipoVenta.Enabled = false;
                    //frm.btnDelivery.Enabled = false;
                    //frm.btnGrabar.Enabled = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();

                    //PedidoBE objPedido = new PedidoBE();
                    //objPedido.IdPedido = IdKardex;
                    //frmRegPedidoEdit objRegPedidoEdit = new frmRegPedidoEdit();
                    //objRegPedidoEdit.pOperacion = frmRegPedidoEdit.Operacion.Modificar;
                    //objRegPedidoEdit.IdPedido = objPedido.IdPedido;
                    //objRegPedidoEdit.StartPosition = FormStartPosition.CenterParent;
                    //objRegPedidoEdit.btnGrabar.Enabled = true;
                    //objRegPedidoEdit.ShowDialog();

                }

                if (IdTipoDocumento == Parametros.intTipoDocBoletaVenta || IdTipoDocumento == Parametros.intTipoDocFacturaVenta || IdTipoDocumento == Parametros.intTipoDocTicketBoleta || IdTipoDocumento == Parametros.intTipoDocTicketFactura || IdTipoDocumento == Parametros.intTipoDocFacturaElectronica || IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica) //Ventas
                {
                    frmRegFacturacionEdit frm = new frmRegFacturacionEdit();
                    frm.IdDocumentoVenta = IdKardex;
                    frm.pOperacion = frmRegFacturacionEdit.Operacion.Modificar;
                    frm.mnuContextual.Enabled = false;
                    frm.btnGrabar.Enabled = false;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }



                //Cargar();
            }
            else
            {
                MessageBox.Show("No se puede abrir este tipo de documento");
            }
        }

        private void toolstpImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                List<ReporteKardexAlmacenBE> lstReporte = null;
                lstReporte = new ReporteKardexAlmacenBL().Listado(Parametros.intEmpresaId, Convert.ToInt32(cboAlmacen.EditValue), IdProducto, deDesde.DateTime, deHasta.DateTime);
                //gcInventarioDetalle.DataSource = mLista;

                if (lstReporte != null)
                {
                    if (lstReporte.Count > 0)
                    {
                        RptVistaReportes objRptAnuncio = new RptVistaReportes();
                        objRptAnuncio.VerRptKardexPorAlmacen(lstReporte, deDesde.DateTime.ToShortDateString(), deDesde.DateTime.ToShortDateString());
                        objRptAnuncio.ShowDialog();
                    }
                    else
                        XtraMessageBox.Show("No hay información para el periodo seleccionado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void optCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (optCodigo.Checked)
            {
                txtCodigo.Select();
            }
        }

        private void optHangTag_CheckedChanged(object sender, EventArgs e)
        {
            if (optHangTag.Checked)
            {
                txtCodigo.Select();
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            //449 - 182677
                if (e.KeyCode == Keys.Enter)
            {
                if (txtCodigo.Text.Length > 0)
                {
                    if (optCodigo.Checked)
                    {
                        ProductoBE objE_Producto = null;

                        int Resultado = 0; //add 240616
                        Resultado = new ProductoBL().SeleccionaBusquedaCount(txtCodigo.Text.Trim());

                        if (Resultado == 0)
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCodigo.SelectAll();
                            return;
                        }
                        if (Resultado == 1)
                        {
                            ProductoBE objE_Producto2 = null;
                            objE_Producto2 = new ProductoBL().SeleccionaParteCodigo(Parametros.intEmpresaId, txtCodigo.Text.Trim());
                            objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objE_Producto2.CodigoProveedor);
                        }
                        else
                        {
                            frmBusProducto objBusProducto = new frmBusProducto();
                            objBusProducto.pDescripcion = txtCodigo.Text.Trim();
                            objBusProducto.ShowDialog();
                            if (objBusProducto.pProductoBE != null)
                            {
                                objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objBusProducto.pProductoBE.CodigoProveedor);
                            }
                            else
                            {
                                txtCodigo.Select();
                                return;
                            }

                        }

                        //ProductoBE objE_Producto = null;
                        //objE_Producto = new ProductoBL().Selecciona(Parametros.intEmpresaId, Parametros.intTiendaId, objBusProducto.pProductoBE.CodigoProveedor);
                        if (objE_Producto != null)
                        {
                            IdProducto = objE_Producto.IdProducto;
                            txtCodigo.Text = objE_Producto.CodigoProveedor;
                            txtDescripcion.Text = objE_Producto.NombreProducto;

                            //btnConsultar.Focus();
                            txtCodigo.SelectAll();
                            Cargar();
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                    //Hang Tag

                    if (optHangTag.Checked)
                    {
                        ProductoBE objE_Producto = null;

                        if (txtCodigo.Text.Trim().Length > 6)
                            //objE_Producto = new ProductoBL().SeleccionaCodigoBarraInventario(txtCodigo.Text.Trim()); //Codigo de Barras de Importación
                            objE_Producto = new ProductoBL().SeleccionaCodigoBarra(Parametros.intEmpresaId, Parametros.intTiendaId, txtCodigo.Text.Trim());
                        else
                            objE_Producto = new ProductoBL().SeleccionaID(Parametros.intEmpresaId, Parametros.intTiendaId, Convert.ToInt32(txtCodigo.Text.Trim()));
                        if (objE_Producto != null)
                        {
                            IdProducto = objE_Producto.IdProducto;
                            txtCodigo.Text = objE_Producto.CodigoProveedor;
                            txtDescripcion.Text = objE_Producto.NombreProducto;

                            //btnConsultar.Focus();
                            txtCodigo.SelectAll();
                            Cargar();
                        }
                        else
                        {
                            XtraMessageBox.Show("El código de producto no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

            }
        }

        private void btnVerFoto_Click(object sender, EventArgs e)
        {
            if (IdProducto > 0)
            {
                frmVerFotoProducto objfrmVerfoto = new frmVerFotoProducto();
                objfrmVerfoto.IdProducto = IdProducto;
                objfrmVerfoto.Show();
            }
        }

        #endregion

        #region "Metodos"

        private void Cargar()
        {
            Cursor = Cursors.WaitCursor;
            mLista = new KardexBL().ListaInventarioDetalle20(Parametros.intEmpresaId, Convert.ToInt32(cboAlmacen.EditValue), IdProducto, deDesde.DateTime, deHasta.DateTime);
            gcInventarioDetalle.DataSource = mLista;


            int TotalIngresos = 0;
            int TotalSalidas = 0;
            int Saldo = 0;
            int TotalCompra = 0;
            int TotalNotaCredito = 0;
            int TotalTransito = 0;
            int TotalVenta = 0;

            foreach (var item in mLista)
            {
                TotalIngresos = TotalIngresos + item.Ingresos;
                TotalSalidas = TotalSalidas + item.Salidas;

                //Sumatorias
                if (item.IdTipoDocumento == Parametros.intTipoDocFacturaCompra)
                {
                    TotalCompra += item.Ingresos;
                }

                if (item.IdTipoDocumento == Parametros.intTipoDocNotaCredito)
                {
                    TotalNotaCredito += item.Ingresos;
                }

                if (item.IdTipoDocumento == 877) //Transito - Nuevo
                {
                    TotalTransito += item.Salidas;
                }

                if (item.IdTipoDocumento == Parametros.intTipoDocBoletaVenta || item.IdTipoDocumento == Parametros.intTipoDocFacturaVenta || item.IdTipoDocumento == Parametros.intTipoDocTicketBoleta || item.IdTipoDocumento == Parametros.intTipoDocTicketFactura || item.IdTipoDocumento == Parametros.intTipoDocPedidoVenta) //Ventas
                {
                    TotalVenta += item.Salidas;
                }
            }

            txtTotalIngresos.EditValue = TotalIngresos;
            txtTotalSalidas.EditValue = TotalSalidas;
            txtTotalCompras.EditValue = TotalCompra;
            txtTotalNotaCredito.EditValue = TotalNotaCredito;
            txtTotalTransito.EditValue = TotalTransito;
            txtTotalVentas.EditValue = TotalVenta;


            Saldo = TotalIngresos - TotalSalidas;

            if (Saldo >= 0)
	        {
		        txtSaldo.EditValue = Saldo;
	        }
            else
            {
                txtSaldo.EditValue = 0;
            }


            Cursor = Cursors.Default;
        }

        public void CargarCodigo(int IdAlmacen, int IdProducto)
        {
            Cursor = Cursors.WaitCursor;
            mLista = new KardexBL().ListaInventarioDetalle(Parametros.intEmpresaId, Convert.ToInt32(cboAlmacen.EditValue), IdProducto, deDesde.DateTime, deHasta.DateTime);
            gcInventarioDetalle.DataSource = mLista;


            int TotalIngresos = 0;
            int TotalSalidas = 0;
            int Saldo = 0;

            foreach (var item in mLista)
            {
                TotalIngresos = TotalIngresos + item.Ingresos;
                TotalSalidas = TotalSalidas + item.Salidas;
            }

            txtTotalIngresos.EditValue = TotalIngresos;
            txtTotalSalidas.EditValue = TotalSalidas;

            Saldo = TotalIngresos - TotalSalidas;

            if (Saldo >= 0)
            {
                txtSaldo.EditValue = Saldo;
            }
            else
            {
                txtSaldo.EditValue = 0;
            }


            Cursor = Cursors.Default;
        }


        #endregion

        private void chkInvAnt_CheckedChanged(object sender, EventArgs e)
        {
            if(chkInvAnt.Checked)
                deDesde.EditValue = Convert.ToDateTime("28/07/2017");
            else
                deDesde.EditValue = Convert.ToDateTime("06/01/2019");

        }
    }
}