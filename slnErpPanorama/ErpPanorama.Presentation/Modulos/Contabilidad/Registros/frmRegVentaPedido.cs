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
    public partial class frmRegVentaPedido : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CDocumentoVentaDetalle> mListaDocumentoVentaDetalleOrigen = new List<CDocumentoVentaDetalle>();
        public List<DescuentoClienteMayoristaBE> mListaDescuentoClienteMayorista = new List<DescuentoClienteMayoristaBE>();



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

        #endregion

        #region "Eventos"
        public frmRegVentaPedido()
        {
            InitializeComponent();
        }

        private void frmRegVentaPedido_Load(object sender, EventArgs e)
        {
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
            cboTienda.EditValue = Parametros.intTiendaId;
            

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

        private void frmRegVentaPedido_Shown(object sender, EventArgs e)
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
                            //var Buscar = mListaDocumentoVentaDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            //if (Buscar.Count > 0)
                            //{
                            //    XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //    return;
                            //}
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
            Grabar();
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
                    //if (IdPedido > 0)
                    //{
                    //    //Traemos la información del Pedido
                    //    PedidoBE objE_Pedido = null;
                    //    objE_Pedido = new PedidoBL().SeleccionaNumero(Convert.ToInt32(txtPeriodo.Text), txtNumeroPedido.Text.Trim());
                    //    if (objE_Pedido != null)
                    //    {
                    //        if (objE_Pedido.IdSituacion == Parametros.intFacturado)
                    //        {
                    //            XtraMessageBox.Show("El N° Pedido ya esta cancelado, no se puede facturar", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //            return;
                    //        }

                    //        IdPedido = objE_Pedido.IdPedido;
                    //        txtNumeroPedido.Text = objE_Pedido.Numero;
                    //        cboFormaPago.EditValue = objE_Pedido.IdFormaPago;
                    //        cboMoneda.EditValue = objE_Pedido.IdMoneda;
                    //        txtTipoCambio.EditValue = objE_Pedido.TipoCambio;
                    //        IdCliente = objE_Pedido.IdCliente;
                    //        IdTipoCliente = objE_Pedido.IdTipoCliente;
                    //        txtNumeroDocumento.Text = objE_Pedido.NumeroDocumento;
                    //        txtDescCliente.Text = objE_Pedido.DescCliente;
                    //        txtTipoCliente.Text = objE_Pedido.DescTipoCliente;
                    //        txtDireccion.Text = objE_Pedido.Direccion;
                    //        cboVendedor.EditValue = objE_Pedido.IdVendedor;
                    //        cboMotivo.EditValue = objE_Pedido.IdMotivo;
                    //        cboTienda.EditValue = objE_Pedido.IdTienda;

                    //        SeteaDocumentoDetalle();

                    //        //Traemos la información del detalle del Pedido
                    //        List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
                    //        lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);
                    //        int nItem = 1;
                    //        foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
                    //        {
                    //            CDocumentoVentaDetalle objE_DocumentoDetalle = new CDocumentoVentaDetalle();
                    //            objE_DocumentoDetalle.IdEmpresa = item.IdEmpresa;
                    //            objE_DocumentoDetalle.IdDocumentoVenta = 0;
                    //            objE_DocumentoDetalle.IdDocumentoVentaDetalle = 0;
                    //            objE_DocumentoDetalle.Item = nItem;
                    //            objE_DocumentoDetalle.IdProducto = item.IdProducto;
                    //            objE_DocumentoDetalle.CodigoProveedor = item.CodigoProveedor;
                    //            objE_DocumentoDetalle.NombreProducto = item.NombreProducto;
                    //            objE_DocumentoDetalle.Abreviatura = item.Abreviatura;
                    //            objE_DocumentoDetalle.Cantidad = item.Cantidad;
                    //            objE_DocumentoDetalle.PrecioUnitario = item.PrecioUnitario;
                    //            objE_DocumentoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                    //            objE_DocumentoDetalle.Descuento = item.Descuento;
                    //            objE_DocumentoDetalle.PrecioVenta = item.PrecioVenta;
                    //            objE_DocumentoDetalle.ValorVenta = item.ValorVenta;
                    //            objE_DocumentoDetalle.IdKardex = Convert.ToInt32(item.IdKardex);
                    //            objE_DocumentoDetalle.FlagMuestra = false;
                    //            objE_DocumentoDetalle.FlagRegalo = false;
                    //            objE_DocumentoDetalle.Stock = 0;
                    //            objE_DocumentoDetalle.TipoOper = item.TipoOper;
                    //            mListaDocumentoVentaDetalleOrigen.Add(objE_DocumentoDetalle);

                    //            nItem = nItem + 1;
                    //        }

                    //        bsListado.DataSource = mListaDocumentoVentaDetalleOrigen;
                    //        gcDocumentoVentaDetalle.DataSource = bsListado;
                    //        gcDocumentoVentaDetalle.RefreshDataSource();

                    //        CalculaTotales();
                    //    }
                    //}
                    //else
                    //{
                        btnGrabar.Focus();
                    //}

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
                    objDocumentoVenta.IdTienda = Parametros.intTiendaId;
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
                    MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                    objE_MovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = txtSerie.Text + "-" + txtNumero.Text;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intEfectivo;// Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                    objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_MovimientoCaja.FlagEstado = false;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                    DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                    objE_Pago.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objE_Pago.IdDocumentoVenta = 0;
                    objE_Pago.IdDocumentoVentaPago = 0;
                    objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_Pago.NumeroDocumento = txtSerie.Text + "-" + txtNumero.Text;
                    objE_Pago.IdCondicionPago = Parametros.intContado;// Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_Pago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objE_Pago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_Pago.Importe = Convert.ToDecimal(txtTotal.EditValue);
                    objE_Pago.FlagEstado = false;
                    objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    lstDocumentoVentaPago.Add(objE_Pago);


                    if (pOperacion == Operacion.Nuevo)
                    {
                        //GrabarPedido();

                        //objBL_DocumentoVenta.InsertaContabilidad(objDocumentoVenta, lstDocumentoVentaDetalle);
                        objBL_DocumentoVenta.InsertaDocumentoContadoEmergency(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
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
                    frmRegVentaPedido frmRegVentaConta = new frmRegVentaPedido();
                    frmRegVentaConta.Show();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5) txtNumeroPedido.Select();
            //if (keyData == Keys.F5) Grabar();


            return base.ProcessCmdKey(ref msg, keyData);
        }


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
            BSUtils.LoaderLook(cboCaja, new CajaBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboTienda.EditValue)), "DescCaja", "IdCaja", true);
            cboCaja.EditValue = Parametros.intCajaId;
        }

        private void cboTienda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                deFecha.Focus();
            }
        }

        private void txtNumeroDocumento_KeyDown(object sender, KeyEventArgs e)
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
                        cboMoneda.EditValue = Parametros.intSoles;
                    }
                    else
                    {
                        if (Convert.ToInt32(cboFormaPago.EditValue) == Parametros.intContado)
                        {
                            cboMoneda.EditValue = Parametros.intSoles;
                        }
                        else
                        {
                            cboMoneda.EditValue = Parametros.intDolares;
                        }

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

            if (cboCaja.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar Caja.\n";
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
                strMensaje = strMensaje + "- No se puede generar la venta, mientra no haya productos.\n";
                flag = true;
            }

            if (IdCliente == Parametros.intIdClienteGeneral && Convert.ToDecimal(txtTotal.EditValue) >= 700)
            {
                strMensaje = strMensaje + "No se puede imprimir un comprobante como " + txtDescCliente.Text + ", el importe es mayor a S/700\nConsulte con su Administrador.\n";
                flag = true;
            }

            if (IdCliente == Parametros.intIdClienteGeneral && Convert.ToDecimal(txtTotal.EditValue) >= 700)
            {
                strMensaje = strMensaje + "No se puede imprimir un comprobante como " + txtDescCliente.Text + ", el importe es mayor a S/700\nConsulte con su Administrador.\n";
                flag = true;
            }

            if (txtNumeroDocumento.Text.Trim().Length < 11 && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) // Validar RUC DE ASOCIADO .. FALTA
            {
                strMensaje = strMensaje + "- No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador\n";
                flag = true;
            }


            DocumentoVentaBE objE_DocumentoVenta = null;
            objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text.Trim(), txtNumero.Text.Trim());
            if(objE_DocumentoVenta != null)
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

        private bool ValidarIngresoVarios()
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

            if (cboCaja.Text == "")
            {
                strMensaje = strMensaje + "- Seleccionar Caja.\n";
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
                strMensaje = strMensaje + "- No se puede generar la venta, mientra no haya productos.\n";
                flag = true;
            }

            if (IdCliente == Parametros.intIdClienteGeneral && Convert.ToDecimal(txtTotal.EditValue) >= 700)
            {
                strMensaje = strMensaje + "No se puede imprimir un comprobante como " + txtDescCliente.Text + ", el importe es mayor a S/ 700\nConsulte con su Administrador.\n";
                flag = true;
            }

            if (IdCliente == Parametros.intIdClienteGeneral && Convert.ToDecimal(txtTotal.EditValue) >= 700)
            {
                strMensaje = strMensaje + "No se puede imprimir un comprobante como " + txtDescCliente.Text + ", el importe es mayor a S/ 700\nConsulte con su Administrador.\n";
                flag = true;
            }

            if (txtNumeroDocumento.Text.Trim().Length < 11 && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocTicketFactura && Convert.ToInt32(cboDocumento.EditValue) == Parametros.intTipoDocFacturaVenta) // Validar RUC DE ASOCIADO .. FALTA
            {
                strMensaje = strMensaje + "- No se puede imprimir una factura con un ruc no válido: " + cboEmpresa.Text + ",  \nConsulte con su Administrador\n";
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

        private void Grabar()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //add for generate
                IdPedido = 0;

                CalculaTotales();

                if (!ValidarIngreso())
                {
                    DocumentoVentaBL objBL_DocumentoVenta = new DocumentoVentaBL();
                    DocumentoVentaBE objDocumentoVenta = new DocumentoVentaBE();

                    objDocumentoVenta.IdDocumentoVenta = 0;
                    objDocumentoVenta.IdTienda = Convert.ToInt32(cboTienda.EditValue);
                    if (IdPedido == 0) objDocumentoVenta.IdPedido = null;
                    else objDocumentoVenta.IdPedido = IdPedido;
                    objDocumentoVenta.Periodo = Convert.ToInt32(txtPeriodo.Text); //Parametros.intPeriodo;
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
                    objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA SOS | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                    objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
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
                    MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                    MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                    objE_MovimientoCaja.IdMovimientoCaja = 0;
                    objE_MovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                    objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_MovimientoCaja.NumeroDocumento = txtSerie.Text + "-" + txtNumero.Text;
                    objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objE_MovimientoCaja.IdCondicionPago = Parametros.intEfectivo;// Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_MovimientoCaja.TipoMovimiento = "I";
                    objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                    objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_MovimientoCaja.FlagEstado = true;
                    objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                    //Documento Venta Pago
                    List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                    DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                    objE_Pago.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objE_Pago.IdDocumentoVenta = 0;
                    objE_Pago.IdDocumentoVentaPago = 0;
                    objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objE_Pago.NumeroDocumento = txtSerie.Text + "-" + txtNumero.Text;
                    objE_Pago.IdCondicionPago = Parametros.intContado;// Convert.ToInt32(cboCondicionPago.EditValue);
                    objE_Pago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objE_Pago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objE_Pago.Importe = Convert.ToDecimal(txtTotal.EditValue);
                    objE_Pago.FlagEstado = true;
                    objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    lstDocumentoVentaPago.Add(objE_Pago);


                    if (pOperacion == Operacion.Nuevo)
                    {
                        if (txtNumeroPedido.Text.Trim().Length > 3)
                        {
                            GrabarPedido();
                            objDocumentoVenta.IdPedido = IdPedido;
                            objE_MovimientoCaja.IdPedido= IdPedido;
                        }

                        //objBL_DocumentoVenta.InsertaContabilidad(objDocumentoVenta, lstDocumentoVentaDetalle);
                        objBL_DocumentoVenta.InsertaDocumentoContadoEmergency(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
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
                    frmRegVentaPedido frmRegVentaConta = new frmRegVentaPedido();
                    frmRegVentaConta.Show();
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GrabarVarios()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                //add for generate
                IdPedido = 0;
                int NumeroInicio = 23115;
                int NumeroFin = 23183;

                CalculaTotales();

                if (!ValidarIngresoVarios ())
                {
                    for (int i = NumeroInicio; i <= NumeroFin; i++)
                    {
                        txtNumero.EditValue = FuncionBase.AgregarCaracter(NumeroInicio.ToString(), "0", 6); ;

                        DocumentoVentaBE objE_DocumentoVenta = null;
                        objE_DocumentoVenta = new DocumentoVentaBL().SeleccionaSerieNumero(Convert.ToInt32(cboEmpresa.EditValue), Convert.ToInt32(cboDocumento.EditValue), txtSerie.Text.Trim(), txtNumero.Text.Trim());
                        if (objE_DocumentoVenta != null)
                        {
                            XtraMessageBox.Show("El documento de venta ya existe", this.Text);
                            return;
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
                        objDocumentoVenta.Observacion = "DOC. GENERADO POR VENTA SOS | " + Parametros.strUsuarioLogin + " | " + WindowsIdentity.GetCurrent().Name.ToString();
                        objDocumentoVenta.IdSituacion = Parametros.intDVCancelado;
                        objDocumentoVenta.IdPersonaRegistro = Parametros.intPersonaId;
                        objDocumentoVenta.FlagEstado = true;
                        objDocumentoVenta.Usuario = Parametros.strUsuarioLogin;
                        objDocumentoVenta.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objDocumentoVenta.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                        objDocumentoVenta.IdAlmacen = Parametros.intAlmTiendaUcayali;


                        //Documento Venta Detalle
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
                        MovimientoCajaBL objBL_MovimientoCaja = new MovimientoCajaBL();
                        MovimientoCajaBE objE_MovimientoCaja = new MovimientoCajaBE();
                        objE_MovimientoCaja.IdMovimientoCaja = 0;
                        objE_MovimientoCaja.IdCaja = Convert.ToInt32(cboCaja.EditValue);
                        objE_MovimientoCaja.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_MovimientoCaja.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_MovimientoCaja.NumeroDocumento = txtSerie.Text + "-" + txtNumero.Text;
                        objE_MovimientoCaja.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                        objE_MovimientoCaja.IdCondicionPago = Parametros.intEfectivo;// Convert.ToInt32(cboCondicionPago.EditValue);
                        objE_MovimientoCaja.TipoMovimiento = "I";
                        objE_MovimientoCaja.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                        objE_MovimientoCaja.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.ImporteSoles = Convert.ToDecimal(txtTotal.EditValue);
                        objE_MovimientoCaja.ImporteDolares = Convert.ToDecimal(txtTotal.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_MovimientoCaja.FlagEstado = true;
                        objE_MovimientoCaja.Usuario = Parametros.strUsuarioLogin;
                        objE_MovimientoCaja.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        objE_MovimientoCaja.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);

                        //Documento Venta Pago
                        List<DocumentoVentaPagoBE> lstDocumentoVentaPago = new List<DocumentoVentaPagoBE>();
                        DocumentoVentaPagoBE objE_Pago = new DocumentoVentaPagoBE();
                        objE_Pago.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                        objE_Pago.IdDocumentoVenta = 0;
                        objE_Pago.IdDocumentoVentaPago = 0;
                        objE_Pago.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                        objE_Pago.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                        objE_Pago.NumeroDocumento = txtSerie.Text + "-" + txtNumero.Text;
                        objE_Pago.IdCondicionPago = Parametros.intContado;// Convert.ToInt32(cboCondicionPago.EditValue);
                        objE_Pago.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                        objE_Pago.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                        objE_Pago.Importe = Convert.ToDecimal(txtTotal.EditValue);
                        objE_Pago.FlagEstado = true;
                        objE_Pago.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                        lstDocumentoVentaPago.Add(objE_Pago);


                        if (pOperacion == Operacion.Nuevo)
                        {
                            if (txtNumeroPedido.Text.Trim().Length > 3)
                            {
                                GrabarPedido();
                                objDocumentoVenta.IdPedido = IdPedido;
                                objE_MovimientoCaja.IdPedido = IdPedido;
                            }

                            //objBL_DocumentoVenta.InsertaContabilidad(objDocumentoVenta, lstDocumentoVentaDetalle);
                            objBL_DocumentoVenta.InsertaDocumentoContadoEmergency(objDocumentoVenta, lstDocumentoVentaDetalle, objE_MovimientoCaja, lstDocumentoVentaPago);
                        }

                        NumeroInicio = NumeroInicio + 1;
                      }

                    XtraMessageBox.Show("Se generó los documentos de la serie " + txtSerie.Text +" desde "+ NumeroInicio + " hasta " + NumeroFin, this.Text);
                    this.Close();

                    ////Preguntar si Continua registrando
                    //if (XtraMessageBox.Show("Continuar registrando Documento de venta?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    //{
                    //    frmRegVentaPedido frmRegVentaConta = new frmRegVentaPedido();
                    //    frmRegVentaConta.Show();
                    //}
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GrabarPedido()
        {
            try
            {
                if (!ValidarIngreso())
                {
                    //Int32 IdPedido2 = 0;

                    PedidoBL objBL_Pedido = new PedidoBL();
                    PedidoBE objPedido = new PedidoBE();

                    objPedido.IdPedido = 0;
                    objPedido.IdTienda = Convert.ToInt32(cboTienda.EditValue);//Parametros.intTiendaId;
                    objPedido.IdCampana = 3;
                    objPedido.Periodo = Parametros.intPeriodo;
                    objPedido.Mes = deFecha.DateTime.Month;
                    objPedido.IdProforma = null;
                    objPedido.IdTipoDocumento = Parametros.intTipoDocPedidoVenta;// Convert.ToInt32(cboDocumento.EditValue);
                    objPedido.Serie = "0";
                    objPedido.Numero = txtNumeroPedido.Text;
                    objPedido.IdPedidoReferencia = null;//IdPedidoReferencia;
                    objPedido.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objPedido.FechaVencimiento = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objPedido.FechaCancelacion = (DateTime?)null;
                    objPedido.IdCliente = IdCliente;
                    objPedido.NumeroDocumento = txtNumeroDocumento.Text;
                    objPedido.DescCliente = txtDescCliente.Text;
                    objPedido.Direccion = txtDireccion.Text;
                    objPedido.IdClienteAsociado = null; //Add  *****verificar null
                    objPedido.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objPedido.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objPedido.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objPedido.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                    objPedido.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                    objPedido.PorcentajeDescuento = 0;// Convert.ToDecimal(txtDescuento.EditValue);
                    objPedido.PorcentajeImpuesto = Parametros.dmlIGV;
                    objPedido.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                    objPedido.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objPedido.TotalBruto = 0;// Convert.ToDecimal(txtTotalBruto.EditValue);
                    objPedido.Observacion = "";// txtObservaciones.Text; //Agregar si es liquidacion **************
                    objPedido.IdCombo = 0;// Convert.ToInt32(cboCombo.EditValue);
                    objPedido.Despachar = cboCaja.Text;
                    objPedido.IdTipoVenta = 0;// Convert.ToInt32(cboTipoVenta.EditValue);
                    objPedido.IdMotivo = Convert.ToInt32(cboMotivo.EditValue);
                    objPedido.IdAsesor = 0; // Convert.ToInt32(cboAsesor.EditValue);
                    objPedido.IdAsesorExterno = 0;// IdAsesorExterno; //Convert.ToInt32(cboAsesorExterno.EditValue); 
                    objPedido.FlagPreVenta = false;// chkPreventa.Checked;
                    //objPedido.FlagEstado = true;
                    objPedido.Usuario = Parametros.strUsuarioLogin;
                    objPedido.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objPedido.IdEmpresa = Convert.ToInt32(cboEmpresa.EditValue);
                    objPedido.bOrigenFlagPreVenta = false;// bOrigenFlagPreventa;
                    objPedido.FlagImpresionRus = false;// FlagImpresionRus;
                    objPedido.IdContratoFabricacion = 0;// IdContratoFabricacion;
                    objPedido.IdProyectoServicio = 0;// IdProyectoServicio;
                    objPedido.IdNovioRegalo = 0;// IdNovioRegalo;

                    //Pedido Detalle
                    List<PedidoDetalleBE> lstPedidoDetalle = new List<PedidoDetalleBE>();

                    foreach (var item in mListaDocumentoVentaDetalleOrigen)
                    {
                        PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                        objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                        objE_PedidoDetalle.IdPedido = 0;// item.IdPedido;
                        objE_PedidoDetalle.IdPedidoDetalle = 0; // item.IdPedidoDetalle;
                        objE_PedidoDetalle.Item = item.Item;
                        objE_PedidoDetalle.IdProducto = item.IdProducto;
                        objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                        objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                        objE_PedidoDetalle.Cantidad = item.Cantidad;
                        objE_PedidoDetalle.CantidadAnt = 0;// item.CantidadAnt;
                        objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                        objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        objE_PedidoDetalle.Descuento = item.Descuento;
                        objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                        objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                        if (item.FlagMuestra)
                            objE_PedidoDetalle.Observacion = "MUESTRA";
                        else
                            objE_PedidoDetalle.Observacion = "";// item.Observacion;
                        objE_PedidoDetalle.IdKardex = item.IdKardex;
                        objE_PedidoDetalle.IdAlmacen = item.IdAlmacen;
                        objE_PedidoDetalle.IdAlmacenOrigen = item.IdAlmacen;// item.IdAlmacenOrigen;
                        objE_PedidoDetalle.IdMovimientoAlmacenDetalle = 0;// item.IdMovimientoAlmacenDetalle;
                        objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                        objE_PedidoDetalle.FlagRegalo = false;
                        objE_PedidoDetalle.FlagBultoCerrado = false;// item.FlagBultoCerrado;
                        objE_PedidoDetalle.IdPromocion = 0;// item.IdPromocion;
                        objE_PedidoDetalle.DescPromocion = "";// item.DescPromocion;
                        objE_PedidoDetalle.FlagEstado = true;
                        objE_PedidoDetalle.TipoOper = item.TipoOper;
                        lstPedidoDetalle.Add(objE_PedidoDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        //ObtenerCorrelativo();

                        if (IdTipoCliente == Parametros.intTipClienteMayorista || IdClasificacionCliente == Parametros.intBlack)///add 110915
                        {
                            objPedido.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMayorista);
                        }
                        else
                        {
                            objPedido.TipoCambio = Convert.ToDecimal(Parametros.dmlTCMinorista);
                        }

                        objPedido.IdSituacion = Parametros.intPVGenerado;
                        IdPedido = objBL_Pedido.InsertaManual(objPedido, lstPedidoDetalle);

                        //PedidoBE objE_Pedido = null;
                        //objE_Pedido = new PedidoBL().Selecciona(IdPedido);


                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #endregion


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
            public Int32 IdAlmacen { get; set; }
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