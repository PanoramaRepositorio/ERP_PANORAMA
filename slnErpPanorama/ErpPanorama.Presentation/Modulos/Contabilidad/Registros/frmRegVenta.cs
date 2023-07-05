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
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.Presentation.Modulos.Ventas.Registros;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Rpt;
using CrystalDecisions.CrystalReports.Engine;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Contabilidad.Registros
{
    public partial class frmRegVenta : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CDocumentoVentaDetalle> mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();
        public List<DescuentoClienteMayoristaBE> mListaDescuentoClienteMayorista = new List<DescuentoClienteMayoristaBE>();


        private int IdDocumentoReferencia = 0;
        private int IdCliente = 0;
        private int IdTipoCliente = 0;
        private int IdClasificacionCliente = 0;
        private bool bMoroso = false;


        private int IdPedido = 0;

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion;

        public bool bNuevo = true;
        public bool bNumeracionAutomatica = false;
        #endregion

        #region "Eventos"

        public frmRegVenta()
        {
            InitializeComponent();
        }

        private void frmRegVenta_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboDocumentoReferencia, new ModuloDocumentoBL().ListaVentasNC(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", false);

            BSUtils.LoaderLook(cboEmpresa, new EmpresaBL().ListaTodosActivo(0), "RazonSocial", "IdEmpresa", true);
            cboEmpresa.EditValue = Parametros.intIdPanoramaDistribuidores;
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboDocumento, CargarTipoDocumento(), "Descripcion", "Id", false);
            cboDocumento.EditValue = 9;
            BSUtils.LoaderLook(cboMotivo, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblMotivoVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboMotivo.EditValue = Parametros.intMotivoVenta;
            txtPeriodo.EditValue = Parametros.intPeriodo;
            BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intEmpresaId), "DescTienda", "IdTienda", true);

            this.pOperacion = Operacion.Nuevo;

            //Especificamos los datos del cliente general
            IdCliente = Parametros.intIdClienteGeneral;
            IdTipoCliente = Parametros.intTipClienteFinal;
            txtNumeroDocumento.Text = Parametros.strNumeroCliente;
            txtDescCliente.Text = Parametros.strDescCliente;
            IdClasificacionCliente = Parametros.intClasico;
            txtTipoCliente.Text = "CLIENTE FINAL" + '-' + "CLASICO";
            txtDireccion.Text = Parametros.strDireccion;

            CargaDocumentoVentaDetalle(0);
            cboEmpresa.Select();
        }

        private void frmRegVenta_Shown(object sender, EventArgs e)
        {
            bool bolFlag = false;

            TipoCambioBE objE_TipoCambio = null;
            objE_TipoCambio = new TipoCambioBL().Selecciona(Parametros.intEmpresaId, Parametros.dtFechaHoraServidor);
            if (objE_TipoCambio == null)
            {
                XtraMessageBox.Show("Falta ingresar Tipo de Cambio del Día", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                bolFlag = true;
            }
            else
            {
                txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Compra.ToString());
            }

            if (bolFlag)
            {
                this.Close();
            }
        }

        private void cboMoneda_EditValueChanged(object sender, EventArgs e)
        {
            int intIdMoneda = 0;
            intIdMoneda = int.Parse(cboMoneda.EditValue.ToString());
            CalcularValoresGrilla(intIdMoneda);
            CalculaTotales();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusCliente frm = new frmBusCliente();
                frm.pFlagMultiSelect = false;
                frm.ShowDialog();
                if (frm.pClienteBE != null)
                {
                    IdCliente = frm.pClienteBE.IdCliente;
                    txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;
                    IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    IdClasificacionCliente = frm.pClienteBE.IdClasificacionCliente;

                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente + "-" + frm.pClienteBE.DescClasificacionCliente;
                        //cboMoneda.EditValue = Parametros.intSoles;
                    }
                    else
                    {
                        //if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                        //{
                        //    cboMoneda.EditValue = Parametros.intSoles;
                        //}
                        //else
                        //{
                        //    cboMoneda.EditValue = Parametros.intDolares;
                        //}

                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;
                    }

                    ClienteCreditoBE objE_ClienteCreditoMoroso = null;
                    objE_ClienteCreditoMoroso = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Convert.ToInt32(cboMotivo.EditValue));
                    if (objE_ClienteCreditoMoroso != null)
                    {
                        if (objE_ClienteCreditoMoroso.IdClasificacionCliente == Parametros.intMoroso)
                        {
                            XtraMessageBox.Show("El cliente seleccionado es MOROSO se le aplicará en sus compras solamente un 10% de Descuento.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bMoroso = true;
                        }
                    }


                    btnNuevo.Focus();
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumeroDocumento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ClienteBE objE_Cliente = null;
                objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, txtNumeroDocumento.Text.Trim());
                if (objE_Cliente != null)
                {
                    IdCliente = objE_Cliente.IdCliente;
                    txtNumeroDocumento.Text = objE_Cliente.NumeroDocumento;
                    txtDescCliente.Text = objE_Cliente.DescCliente;
                    txtDireccion.Text = objE_Cliente.AbrevDomicilio + " " + objE_Cliente.Direccion;
                    IdTipoCliente = objE_Cliente.IdTipoCliente;
                    IdClasificacionCliente = objE_Cliente.IdClasificacionCliente;
                    if (IdTipoCliente == Convert.ToInt32(Parametros.intTipClienteFinal))
                    {
                        txtTipoCliente.Text = objE_Cliente.DescTipoCliente + "-" + objE_Cliente.DescClasificacionCliente;
                        //cboMoneda.EditValue = Parametros.intSoles;
                    }
                    else
                    {
                        //if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                        //{
                        //    cboMoneda.EditValue = Parametros.intSoles;
                        //}
                        //else
                        //{
                        //    cboMoneda.EditValue = Parametros.intDolares;
                        //}

                        txtTipoCliente.Text = objE_Cliente.DescTipoCliente;
                    }

                    ClienteCreditoBE objE_ClienteCreditoMoroso = null;
                    objE_ClienteCreditoMoroso = new ClienteCreditoBL().SeleccionaCliente(Parametros.intEmpresaId, IdCliente, Parametros.intMotivoVenta);
                    if (objE_ClienteCreditoMoroso != null)
                    {
                        if (objE_ClienteCreditoMoroso.IdClasificacionCliente == Parametros.intMoroso)
                        {
                            XtraMessageBox.Show("El cliente seleccionado es MOROSO se le aplicará en sus compras solamente un 10% de Descuento.\n", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bMoroso = true;
                        }
                    }

                    cboVendedor.Focus();
                }
                else
                {
                    XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                frmManClienteMinoristaEdit objManCliente = new frmManClienteMinoristaEdit();
                //objManClientel.lstCliente = mLista;
                objManCliente.pOperacion = frmManClienteMinoristaEdit.Operacion.Nuevo;
                objManCliente.IdCliente = 0;
                objManCliente.StartPosition = FormStartPosition.CenterParent;
                if (objManCliente.ShowDialog() == DialogResult.OK)
                {
                    txtNumeroDocumento.Text = objManCliente.NumeroDocumento;
                    txtDescCliente.Text = objManCliente.DescCliente;
                    txtDireccion.Text = objManCliente.AbrevDocimicilio + ' ' + objManCliente.Direccion;
                    IdClasificacionCliente = objManCliente.IdClasificacionCliente;
                    txtTipoCliente.Text = objManCliente.TipoClasificacion;
                    ClienteBE objE_Cliente = null;
                    objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intIdPanoramaDistribuidores, objManCliente.NumeroDocumento);
                    if (objE_Cliente != null)
                    {
                        IdCliente = objE_Cliente.IdCliente;
                    }
                }

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroDocumento.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                frmRegVentaDetalle movDetalle = new frmRegVentaDetalle();
                int i = 0;
                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                    i = mListaDocumentoVentaDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaDocumentoVentaDetalleOrigen.Count == 0)
                        {
                            gvDocumentoVentaDetalle.AddNewRow();
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDocumentoVentaDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            CalculaTotales();

                            btnNuevo.Focus();

                            return;

                        }
                        if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvDocumentoVentaDetalle.AddNewRow();
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdKardex", movDetalle.oBE.IdKardex);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "Stock", 0);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvDocumentoVentaDetalle.SetRowCellValue(gvDocumentoVentaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvDocumentoVentaDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            CalculaTotales();

                            btnNuevo.Focus();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void modificarprecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mListaDocumentoVentaDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmRegVentaDetalle movDetalle = new frmRegVentaDetalle();
                movDetalle.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.IdDocumentoVenta = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdDocumentoVenta"));
                movDetalle.IdDocumentoVentaDetalle = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle"));
                movDetalle.intCorrelativo = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Item"));
                movDetalle.IdProducto = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.IdLineaProducto = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdLineaProducto"));
                movDetalle.txtCodigo.Text = gvDocumentoVentaDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvDocumentoVentaDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvDocumentoVentaDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvDocumentoVentaDetalle.GetFocusedRowCellValue("PrecioUnitario"));
                movDetalle.txtDescuento.EditValue = Convert.ToDecimal(gvDocumentoVentaDetalle.GetFocusedRowCellValue("PorcentajeDescuento"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvDocumentoVentaDetalle.GetFocusedRowCellValue("PrecioVenta"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvDocumentoVentaDetalle.GetFocusedRowCellValue("ValorVenta"));
                movDetalle.chkMuestra.EditValue = Convert.ToBoolean(gvDocumentoVentaDetalle.GetFocusedRowCellValue("FlagMuestra"));
                movDetalle.IdKardex = Convert.ToInt32(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdKardex"));
                movDetalle.PorcentajeDescuentoInicial = Convert.ToDecimal(gvDocumentoVentaDetalle.GetFocusedRowCellValue("PorcentajeDescuentoInicial"));
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvDocumentoVentaDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdDocumentoVenta", movDetalle.oBE.IdDocumentoVenta);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdDocumentoVentaDetalle", movDetalle.oBE.IdDocumentoVentaDetalle);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "Item", movDetalle.oBE.Item);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "CantidadAnt", movDetalle.oBE.CantidadAnt);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "Descuento", movDetalle.oBE.Descuento);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "ValorVenta", movDetalle.oBE.ValorVenta);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdKardex", movDetalle.oBE.IdKardex);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "FlagMuestra", movDetalle.oBE.FlagMuestra);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "FlagRegalo", movDetalle.oBE.FlagRegalo);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "Stock", 0);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PrecioUnitarioInicial", 0);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "PorcentajeDescuentoInicial", movDetalle.oBE.PorcentajeDescuentoInicial);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                        gvDocumentoVentaDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvDocumentoVentaDetalle.UpdateCurrentRow();

                        bNuevo = movDetalle.bNuevo;

                        CalculaTotales();

                        btnNuevo.Focus();
                    }
                }
            }
        }


        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdDocumentoVentaDetalle = 0;
                if (gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle") != null)
                    IdDocumentoVentaDetalle = int.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("IdDocumentoVentaDetalle").ToString());
                int Item = 0;
                if (gvDocumentoVentaDetalle.GetFocusedRowCellValue("Item") != null)
                    Item = int.Parse(gvDocumentoVentaDetalle.GetFocusedRowCellValue("Item").ToString());
                DocumentoVentaDetalleBE objBE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                objBE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = IdDocumentoVentaDetalle;
                objBE_DocumentoVentaDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_DocumentoVentaDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_DocumentoVentaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                DocumentoVentaDetalleBL objBL_DocumentoVentaDetalle = new DocumentoVentaDetalleBL();
                objBL_DocumentoVentaDetalle.Elimina(objBE_DocumentoVentaDetalle);
                gvDocumentoVentaDetalle.DeleteRow(gvDocumentoVentaDetalle.FocusedRowHandle);
                gvDocumentoVentaDetalle.RefreshData();

                //RegeneraItem
                int i = 0;
                int cuenta = 0;
                foreach (var item in mListaDocumentoVentaDetalleOrigen)
                {
                    item.Item = Convert.ToByte(cuenta + 1);
                    cuenta++;
                    i++;
                }

                CalculaTotales();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmMenuAgregar_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void tsmMenuEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.nuevoToolStripMenuItem_Click(sender, e);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarToolStripMenuItem_Click(sender, e);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            this.modificarprecioToolStripMenuItem_Click(sender, e);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                CalculaTotales();

                if (!ValidarIngreso())
                {
                    if (bNumeracionAutomatica)
                    {
                        if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intIdPanoramaDistribuidores)
                        {
                            if (txtSerie.Text == "F009" || txtSerie.Text == "B009")
                            {
                                //Permitido
                            }
                            else
                            {
                                XtraMessageBox.Show("No se puede registrar manualmente documentos electrónicos de " + cboEmpresa.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                Cursor = Cursors.Default;
                                return;
                            }
                        }
                    }

                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    if (IdPedido == 0) objDocumentoVenta.IdPedido = null;
                    else objDocumentoVenta.IdPedido = IdPedido;
                    objDocumentoVenta.Periodo = Convert.ToInt32(txtPeriodo.Text); //Parametros.intPeriodo;
                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                    objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);

                    string Numero = "";
                    if (bNumeracionAutomatica)
                    {
                        //Obtener el numero del documento relacionado a la serie
                        List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                        mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoSerie(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text);
                        if (mListaNumero.Count > 0)
                        {
                            Numero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", mListaNumero[0].NumeroCaracter);
                        }
                        else
                        {
                            XtraMessageBox.Show("La serie no existe, por favor verificar.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    else
                        Numero = txtNumero.Text;

                    objDocumentoVenta.Serie = txtSerie.Text;
                    objDocumentoVenta.Numero = Numero;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = IdCliente;
                    objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                    objDocumentoVenta.DescCliente = txtDescCliente.Text;
                    objDocumentoVenta.Direccion = txtDireccion.Text;
                    objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objDocumentoVenta.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                    objDocumentoVenta.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                    objDocumentoVenta.PorcentajeDescuento = 0;
                    objDocumentoVenta.Descuentos = 0;
                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                    objDocumentoVenta.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                    objDocumentoVenta.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objDocumentoVenta.Observacion = "DOC. GENERADO POR CONTABILIDAD | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objDocumentoVenta.IdAlmacen = Parametros.intAlmTiendaUcayali;

                    objDocumentoVenta.IdDocumentoReferencia = IdDocumentoReferencia;  //  Convert.ToInt32(cboDocumentoReferencia.EditValue);
                    //objDocumentoVenta.SerieReferencia = txtSerieReferencia.Text.Trim();
                    //objDocumentoVenta.NumeroReferencia = txtNumeroReferencia.Text.Trim();

                    //Documento Vneta Detalle
                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                    {
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                        objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = item.IdDocumentoVentaDetalle;
                        objE_DocumentoVentaDetalle.Item = item.Item;
                        objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                        objE_DocumentoVentaDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                        lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                    }

                    //Movimiento Caja

                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();


                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();


                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_DocumentoVenta.InsertaContabilidad(objDocumentoVenta, lstDocumentoVentaDetalle);
                    }
                    else
                    {
                        objBL_DocumentoVenta.ActualizaContabilidad(objDocumentoVenta, lstDocumentoVentaDetalle);
                    }
                    this.Close();
                }
                //Preguntar si Continua registrando
                if (XtraMessageBox.Show("Continuar registrando Documento de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmRegVenta frmRegVentaConta = new frmRegVenta();
                    frmRegVentaConta.Show();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumeroPedido_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información del Pedido
                    PedidoBE objE_Pedido = null;
                    objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.Text), txtNumeroPedido.Text.Trim());
                    if (objE_Pedido != null)
                    {
                        if (objE_Pedido.IdSituacion == Parametros.intFacturado)
                        {
                            XtraMessageBox.Show("El N° Pedido ya esta cancelado, no se puede facturar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        IdPedido = objE_Pedido.IdPedido;
                        txtNumeroPedido.Text = objE_Pedido.Numero;
                        cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                        cboMoneda.EditValue = objE_Pedido.IdMoneda;
                        txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                        IdCliente = objE_Pedido.IdCliente;
                        IdTipoCliente = objE_Pedido.IdTipoCliente;
                        txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                        txtDescCliente.Text = objE_Pedido.DescCliente;
                        txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                        txtDireccion.Text = objE_Pedido.Direccion;
                        cboVendedor.EditValue = objE_Pedido.IdVendedor;
                        cboMotivo.EditValue = objE_Pedido.IdMotivo;
                        cboTienda.EditValue = objE_Pedido.IdTienda;

                        SeteaDocumentoDetalle();

                        //Traemos la información del detalle del Pedido
                        List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                        lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);
                        int nItem = 1;
                        foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                        {
                            CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                            objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoDetalle.IdDocumentoVenta = 0;
                            objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                            objE_DocumentoDetalle.Item = nItem;
                            objE_DocumentoDetalle.IdProducto = item.IdProducto;
                            objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                            objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                            objE_DocumentoDetalle.Cantidad = item.Cantidad;
                            objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                            objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                            objE_DocumentoDetalle.Descuento = item.Descuento;
                            objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                            objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                            objE_DocumentoDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                            objE_DocumentoDetalle.FlagMuestra = false;
                            objE_DocumentoDetalle.FlagRegalo = false;
                            objE_DocumentoDetalle.Stock = 0;
                            objE_DocumentoDetalle.TipoOper = item.TipoOper;
                            mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                            nItem = nItem + 1;
                        }

                        bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                        gcDocumentoVentaDetalle.DataSource = bsListado;
                        gcDocumentoVentaDetalle.RefreshDataSource();

                        CalculaTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                if (bNumeracionAutomatica)
                {
                    NumeracionDocumentoBE objE_NumeracionDocumento = new NumeracionDocumentoBE();
                    objE_NumeracionDocumento = new NumeracionDocumentoBL().SeleccionaNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), Parametros.intPeriodo, txtSerie.Text.Trim());
                    txtNumero.EditValue = objE_NumeracionDocumento.Numero + 1;
                }
                else
                {
                    txtNumero.Text = "";
                }

                txtNumero.Focus();
            }
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtNumeroDocumento.Focus();
            }
        }

        private void cboEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                deFecha.Focus();
            }
        }

        private void deFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                cboDocumento.Focus();
            }
        }

        private void cboDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                txtSerie.Focus();
            }
        }

        private void txtNumeroDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void cboVendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                btnNuevo.Focus();
            }
        }

        private void btnGrabarAnular_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                CalculaTotales();

                if (!ValidarIngreso())
                {
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    if (IdPedido == 0) objDocumentoVenta.IdPedido = null;
                    else objDocumentoVenta.IdPedido = IdPedido;
                    objDocumentoVenta.Periodo = Convert.ToInt32(txtPeriodo.Text);// Parametros.intPeriodo;
                    objDocumentoVenta.Mes = deFecha.DateTime.Month;
                    objDocumentoVenta.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objDocumentoVenta.Serie = txtSerie.Text;
                    objDocumentoVenta.Numero = txtNumero.Text;
                    objDocumentoVenta.IdDocumentoReferencia = null;
                    objDocumentoVenta.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objDocumentoVenta.IdCliente = IdCliente;
                    objDocumentoVenta.NumeroDocumento = txtNumeroDocumento.Text;
                    objDocumentoVenta.DescCliente = txtDescCliente.Text;
                    objDocumentoVenta.Direccion = txtDireccion.Text;
                    objDocumentoVenta.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objDocumentoVenta.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objDocumentoVenta.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objDocumentoVenta.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objDocumentoVenta.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                    objDocumentoVenta.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                    objDocumentoVenta.PorcentajeDescuento = 0;
                    objDocumentoVenta.Descuentos = 0;
                    objDocumentoVenta.PorcentajeImpuesto = Parametros.dmlIGV;
                    objDocumentoVenta.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                    objDocumentoVenta.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objDocumentoVenta.Observacion = "DOC. GENERADO Y ANULADO POR CONTABILIDAD | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdSituacion = Parametros.intDVAnulado;
                    objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                    objDocumentoVenta.FlagEstado = true;
                    objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                    objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objDocumentoVenta.IdAlmacen = Parametros.intAlmTiendaUcayali;

                    //Documento Vneta Detalle
                    List<DocumentoVentaDetalleBE> lstDocumentoVentaDetalle = new List<DocumentoVentaDetalleBE>();

                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                    {
                        DocumentoVentaDetalleBE objE_DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                        objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                        objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;
                        objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = item.IdDocumentoVentaDetalle;
                        objE_DocumentoVentaDetalle.Item = item.Item;
                        objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                        objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                        objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                        objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                        objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                        objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                        objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                        objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                        objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                        objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                        objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                        objE_DocumentoVentaDetalle.FlagEstado = true;
                        objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                        lstDocumentoVentaDetalle.Add(objE_DocumentoVentaDetalle);
                    }

                    //Movimiento Caja

                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();


                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();


                    if (pOperacion == Operacion.Nuevo)
                    {
                        objBL_DocumentoVenta.InsertaContabilidad(objDocumentoVenta, lstDocumentoVentaDetalle);
                    }
                    else
                    {
                        objBL_DocumentoVenta.ActualizaContabilidad(objDocumentoVenta, lstDocumentoVentaDetalle);
                    }

                    //anula el documento venta
                    DocumentoVentaBE objE_DocumentoVenta = new DocumentoVentaBE();
                    objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(lstDocumentoVentaDetalle[0].IdDocumentoVenta);

                    //DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    objBL_DocumentoVenta.Elimina(objE_DocumentoVenta);
                    XtraMessageBox.Show("El registro se Anuló correctamente", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                //Preguntar si Continua registrando
                if (XtraMessageBox.Show("Continuar registrando Documento de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmRegVenta frmRegVentaConta = new frmRegVenta();
                    frmRegVentaConta.Show();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        #endregion

        #region "Metodos"

        private void SeteaDocumentoDetalle()
        {
            mListaDocumentoVentaDetalleOrigen.Clear();
            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoVentaDetalle.DataSource = bsListado;
            gcDocumentoVentaDetalle.RefreshDataSource();
        }

        private void CargarDescuentoClienteMayorista()
        {
            mListaDescuentoClienteMayorista = new DescuentoClienteMayoristaBL().ListaTodosActivo(Parametros.intEmpresaId, 0, 0);
        }

        private void txtTotal_EditValueChanged(object sender, EventArgs e)
        {
            if (bNuevo)
            {
                if (IdTipoCliente == Parametros.intTipClienteMayorista)
                {
                    if (Convert.ToDecimal(txtTotal.Text) > 0)
                    {
                        decimal decTotal = 0;

                        if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                        {
                            decTotal = Convert.ToDecimal(txtTotal.Text) / Convert.ToDecimal(Parametros.dmlTCMayorista);
                        }
                        else
                        {
                            decTotal = Convert.ToDecimal(txtTotal.Text);
                        }

                        if (gvDocumentoVentaDetalle.RowCount > 0)
                        {
                            gvDocumentoVentaDetalle.RefreshData();

                            for (int i = 0; i < gvDocumentoVentaDetalle.RowCount; i++)
                            {
                                int IdProducto = 0;
                                int IdLineaProducto = 0;
                                decimal decDescuentoOriginal = 0;
                                decimal decDescuento = 0;
                                decimal decPrecioVenta = 0;
                                decimal decValorVenta = 0;

                                IdProducto = int.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "IdProducto").ToString());
                                StockBE objE_Stock = null;
                                objE_Stock = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);
                                if (objE_Stock != null)
                                {
                                    IdLineaProducto = objE_Stock.IdLineaProducto;
                                    decDescuentoOriginal = objE_Stock.Descuento;
                                }

                                foreach (var itemdescuento in mListaDescuentoClienteMayorista)
                                {
                                    if (Convert.ToInt32(cboFormaPago.EditValue) == itemdescuento.IdFormaPago && IdLineaProducto == itemdescuento.IdLineaProducto && decTotal >= itemdescuento.MontoMin && decTotal <= itemdescuento.MontoMax)
                                    {
                                        decDescuento = itemdescuento.PorDescuento;
                                        if (decDescuentoOriginal > decDescuento)
                                        {
                                            if (bMoroso)
                                            {
                                                decimal decDescuentoMoroso = 10;
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                                                decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100);
                                                decValorVenta = decPrecioVenta * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                            }
                                            else
                                            {
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoOriginal);
                                                decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoOriginal) / 100);
                                                decValorVenta = decPrecioVenta * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                            }
                                        }
                                        else
                                        {
                                            if (bMoroso)
                                            {
                                                decimal decDescuentoMoroso = 10;
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoMoroso);
                                                decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoMoroso) / 100);
                                                decValorVenta = decPrecioVenta * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                            }
                                            else
                                            {
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuento);
                                                decPrecioVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                                                decValorVenta = decPrecioVenta * decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                gvDocumentoVentaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            CalculaTotales();
        }

        private void CalcularValoresGrilla(int IdMoneda)
        {
            try
            {
                if (gvDocumentoVentaDetalle.RowCount > 0)
                {
                    if (IdMoneda == Parametros.intSoles)
                    {
                        int posicion = 0;
                        foreach (var item in mListaDocumentoVentaDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;
                            }

                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["ValorVenta"], decValorVenta);
                            posicion++;
                        }
                    }
                    else
                    {
                        int posicion = 0;
                        foreach (var item in mListaDocumentoVentaDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvDocumentoVentaDetalle.GetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["Cantidad"]).ToString()) * decPrecioVenta;

                            }
                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvDocumentoVentaDetalle.SetRowCellValue(posicion, gvDocumentoVentaDetalle.Columns["ValorVenta"], decValorVenta);
                            posicion++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtSerie.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar la serie del documento de venta.\n";
                flag = true;
            }

            if (txtNumero.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar el numero del  documento de venta.\n";
                flag = true;
            }

            if (IdCliente == 0)
            {
                strMensaje = strMensaje + "- Seleccionar un cliente válido.\n";
                flag = true;
            }

            if (cboDocumento.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar el tipo de documento.\n";
                flag = true;
            }

            if (cboFormaPago.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar la forma de pago.\n";
                flag = true;
            }

            if (mListaDocumentoVentaDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar la venta, mientra no haya productos.\n";
                flag = true;
            }

            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text.Trim(), txtNumero.Text.Trim());
            if (objE_DocumentoVenta != null)
            {
                strMensaje = strMensaje + "- El documento de venta ya existe.\n";
                flag = true;
            }


            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void CalculaTotales()
        {
            try
            {
                decimal deImpuesto = 0;
                decimal deValorVenta = 0;
                decimal deSubTotal = 0;
                decimal deTotal = 0;
                int intTotalCantidad = 0;

                if (mListaDocumentoVentaDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                    {
                        intTotalCantidad = intTotalCantidad + item.Cantidad;
                        deValorVenta = item.ValorVenta;
                        deTotal = deTotal + deValorVenta;
                    }

                    txtTotal.EditValue = Math.Round(deTotal, 2);
                    deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                    txtSubTotal.EditValue = deSubTotal;
                    deImpuesto = deTotal - deSubTotal;
                    txtImpuesto.EditValue = deImpuesto;
                    txtTotalCantidad.EditValue = intTotalCantidad;

                }
                else
                {
                    txtTotalCantidad.EditValue = 0;
                    txtSubTotal.EditValue = 0;
                    txtImpuesto.EditValue = 0;
                    txtTotal.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColumRowFocus(string searchText, string Column)
        {
            // obtaining the focused view 
            ColumnView View = (ColumnView)gcDocumentoVentaDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvDocumentoVentaDetalle.FocusedRowHandle + 1, column, searchText);
                // focusing the cell 
                if (rhFound != 0)
                {
                    View.FocusedRowHandle = rhFound;
                    View.FocusedColumn = column;
                }
            }

        }

        private void ColumRowFocusCantidad(string searchText, string Column)
        {
            // obtaining the focused view 
            ColumnView View = (ColumnView)gcDocumentoVentaDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            GridColumn columnbus = View.Columns["Cantidad"];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvDocumentoVentaDetalle.FocusedRowHandle + 1, column, searchText);
                // focusing the cell 
                if (rhFound != 0)
                {
                    View.FocusedRowHandle = rhFound;
                    View.FocusedColumn = columnbus;
                }
            }

        }

        private void CargaDocumentoVentaDetalle(int IdDocumentoVenta)
        {
            List<DocumentoVentaDetalleBE> lstTmpDocumentoVentaDetalle = null;
            lstTmpDocumentoVentaDetalle = new DocumentoVentaDetalleBL().ListaTodosActivo(IdDocumentoVenta);

            foreach (DocumentoVentaDetalleBE item in lstTmpDocumentoVentaDetalle)
            {
                CDocumentoVentaDetalle objE_DocumentoVentaDetalle = new CDocumentoVentaDetalle();
                objE_DocumentoVentaDetalle.IdEmpresa = item.IdEmpresa;
                objE_DocumentoVentaDetalle.IdDocumentoVenta = item.IdDocumentoVenta;
                objE_DocumentoVentaDetalle.IdDocumentoVentaDetalle = item.IdDocumentoVentaDetalle;
                objE_DocumentoVentaDetalle.Item = item.Item;
                objE_DocumentoVentaDetalle.IdProducto = item.IdProducto;
                objE_DocumentoVentaDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_DocumentoVentaDetalle.NombreProducto = item.NombreProducto;
                objE_DocumentoVentaDetalle.Abreviatura = item.Abreviatura;
                objE_DocumentoVentaDetalle.Cantidad = item.Cantidad;
                objE_DocumentoVentaDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_DocumentoVentaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_DocumentoVentaDetalle.Descuento = item.Descuento;
                objE_DocumentoVentaDetalle.PrecioVenta = item.PrecioVenta;
                objE_DocumentoVentaDetalle.ValorVenta = item.ValorVenta;
                objE_DocumentoVentaDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                objE_DocumentoVentaDetalle.FlagMuestra = item.FlagMuestra;
                objE_DocumentoVentaDetalle.FlagRegalo = item.FlagRegalo;
                objE_DocumentoVentaDetalle.Stock = 0;
                objE_DocumentoVentaDetalle.PorcentajeDescuentoInicial = 0;
                objE_DocumentoVentaDetalle.IdLineaProducto = 0;
                objE_DocumentoVentaDetalle.TipoOper = item.TipoOper;
                mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoVentaDetalle);
            }

            bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
            gcDocumentoVentaDetalle.DataSource = bsListado;
            gcDocumentoVentaDetalle.RefreshDataSource();

            CalculaTotales();
        }

        private DataTable CargarTipoDocumento()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 12;
            dr["Descripcion"] = "BEE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 13;
            dr["Descripcion"] = "FEE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 11;
            dr["Descripcion"] = "NCE";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 9;
            dr["Descripcion"] = "BOV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 26;
            dr["Descripcion"] = "FAV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 90;
            dr["Descripcion"] = "TKV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 91;
            dr["Descripcion"] = "TKF";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 36;
            dr["Descripcion"] = "NCV";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 97;
            dr["Descripcion"] = "FAT";
            dt.Rows.Add(dr);
            return dt;
        }

        #endregion

        private void cboEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboEmpresa.EditValue) == Parametros.intCoronaImportadores)
            {
                BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intCoronaImportadores), "DescTienda", "IdTienda", true);
            }
            else
            {
                BSUtils.LoaderLook(cboTienda, new TiendaBL().ListaTodosActivo(Parametros.intPanoraramaDistribuidores), "DescTienda", "IdTienda", true);
            }

        }

        private void cboTienda_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cboDocumento_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocBoletaElectronica || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaElectronica || Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocNotaCreditoElectronica)
            {
                txtNumero.Properties.ReadOnly = true;
                bNumeracionAutomatica = true;
            }
            else
            {
                txtNumero.Properties.ReadOnly = false;
                bNumeracionAutomatica = false;
            }
        }

        private void txtNumeroReferencia_KeyDown(object sender, KeyEventArgs e)
        {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información del Pedido
                    //CambioBE objE_Cambio = null;
                    //objE_Cambio = new CambioBL().SeleccionaTipoDocumento(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                    //if (objE_Cambio != null)
                    //{
                    //IdCambio = objE_Cambio.IdCambio;
                    //NumeroDevolucion = objE_Cambio.Numero;
                    //CodigoNC = objE_Cambio.CodigoNC;
                    //if (objE_Cambio.FlagRecibido)//Change Recibido
                    //{
                    DocumentoVentaBE objE_DocumentoVenta = null;
                    objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumentoReferencia.EditValue), txtSerieReferencia.Text.Trim(), txtNumeroReferencia.Text.Trim());
                    if (objE_DocumentoVenta != null)
                    {
                        cboEmpresa.EditValue = objE_DocumentoVenta.IdEmpresa;
                        IdDocumentoReferencia = Convert.ToInt32(objE_DocumentoVenta.IdDocumentoVenta);
                        IdPedido = objE_DocumentoVenta.IdPedido == null ? 0 : Convert.ToInt32(objE_DocumentoVenta.IdPedido);

                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().Selecciona(IdPedido);

                        if (objE_Pedido != null)
                        {
                            txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                        }
                        else
                        {
                            txtTipoCambio.EditValue = objE_DocumentoVenta.TipoCambio;
                        }

                        txtNumeroPedido.Text = objE_DocumentoVenta.NumeroPedido;
                        cboFormaPago.EditValue = objE_DocumentoVenta.IdFormaPago;
                        cboMoneda.EditValue = objE_DocumentoVenta.IdMoneda;
                        IdCliente = objE_DocumentoVenta.IdCliente;
                        IdTipoCliente = objE_DocumentoVenta.IdTipoCliente;
                        IdClasificacionCliente = objE_DocumentoVenta.IdClasificacionCliente;
                        txtNumeroDocumento.Text = objE_DocumentoVenta.NumeroDocumento;
                        txtDescCliente.Text = objE_DocumentoVenta.DescCliente;
                        if (IdTipoCliente == Parametros.intTipClienteFinal)
                            txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente + "-" + objE_DocumentoVenta.DescClasificacionCliente;
                        else
                        txtTipoCliente.Text = objE_DocumentoVenta.DescTipoCliente;
                        txtDireccion.Text = objE_DocumentoVenta.Direccion;
                        cboVendedor.EditValue = objE_DocumentoVenta.IdVendedor;
                        txtTotalCantidad.EditValue = objE_DocumentoVenta.TotalCantidad;
                        txtSubTotal.EditValue = objE_DocumentoVenta.SubTotal;
                        txtImpuesto.EditValue = objE_DocumentoVenta.Igv;
                        txtTotal.EditValue = objE_DocumentoVenta.Total;
                        //txtTotalBruto.EditValue = objE_DocumentoVenta.TotalBruto;


                        SeteaDocumentoDetalle();

                        //Traemos la información del detalle de la devolución
                        List<DocumentoVentaDetalleBE> lstTmpCambioDetalle = null;
                        lstTmpCambioDetalle = new DocumentoVentaDetalleBL().ListaTodosActivoFE(objE_DocumentoVenta.IdEmpresa, IdDocumentoReferencia);

                        int Item = 1;
                        //  decTotalVentaDolares = 0;
                        foreach (DocumentoVentaDetalleBE item in lstTmpCambioDetalle)
                        {
                            CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                            objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                            objE_DocumentoDetalle.IdDocumentoVenta = 0;
                            objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                            objE_DocumentoDetalle.Item = Item;
                            objE_DocumentoDetalle.IdProducto = item.IdProducto;
                            objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                            objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                            objE_DocumentoDetalle.Cantidad = item.Cantidad;
                            //objE_DocumentoDetalle.CantidadAnt = item.Cantidad;
                            objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                            objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                            objE_DocumentoDetalle.Descuento = 0;
                            objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                            objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                            //objE_DocumentoDetalle.CodAfeIGV = item.CodAfeIGV;
                            objE_DocumentoDetalle.IdKardex = 0;
                            objE_DocumentoDetalle.FlagMuestra = false;
                            objE_DocumentoDetalle.FlagRegalo = false;
                            objE_DocumentoDetalle.Stock = 0;
                            objE_DocumentoDetalle.TipoOper = item.TipoOper;
                            mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                            //   decTotalVentaDolares = decTotalVentaDolares + item.ValorVentaDolares;
                        }

                        bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                        gcDocumentoVentaDetalle.DataSource = bsListado;
                        gcDocumentoVentaDetalle.RefreshDataSource();

                        CalculaTotales();

                        mnuContextual.Enabled = false;
                    }
                }
           
             //}
 

        }


        public class CDocumentoVentaDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdDocumentoVenta { get; set; }
            public Int32 IdDocumentoVentaDetalle { get; set; }
            public Int32 Item { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal PrecioUnitario { get; set; }
            public Decimal PorcentajeDescuento { get; set; }
            public Decimal Descuento { get; set; }
            public Decimal PrecioVenta { get; set; }
            public Decimal ValorVenta { get; set; }
            public Int32 IdKardex { get; set; }
            public Boolean FlagMuestra { get; set; }
            public Boolean FlagRegalo { get; set; }
            public Int32 Stock { get; set; }
            public Decimal PorcentajeDescuentoInicial { get; set; }
            public Int32 IdLineaProducto { get; set; }
            public Int32 TipoOper { get; set; }

            public CDocumentoVentaDetalle()
            {

            }
        }
    }
}


 