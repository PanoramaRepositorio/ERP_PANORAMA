using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Security.Principal;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Columns;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Funciones;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Ventas.Maestros;
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Ventas.Registros
{
    public partial class frmRegProformaEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        
        public List<CProformaDetalle> mListaProformaDetalleOrigen = new List<CProformaDetalle>();
        public List<DescuentoClienteFinalBE> mListaDescuentoClienteFinal = new List<DescuentoClienteFinalBE>();
        public List<DescuentoClienteMayoristaBE> mListaDescuentoClienteMayorista = new List<DescuentoClienteMayoristaBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        int _IdProforma = 0;

        public int IdProforma
        {
            get { return _IdProforma; }
            set { _IdProforma = value; }
        }

        public bool bNuevo = true;

        private int IdCliente = 0;
        private int IdTipoCliente = 0;
        private int IdClasificacionCliente = 0;
        private int? IdDis_ProyectoServicio ;
        public int OrigenNuevo = 0; //1: Producto Transformado
        public decimal TotalProforma = 0;
        #endregion

        #region "Eventos"

        public frmRegProformaEdit()
        {
            InitializeComponent();
        }

        private void frmRegProformaEdit_Load(object sender, EventArgs e)
        {
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboDocumento, new ModuloDocumentoBL().ListaTodosActivo(Parametros.intModVentas, 0), "CodTipoDocumento", "IdTipoDocumento", true);
            cboDocumento.EditValue = Parametros.intTipoDocProforma;
            deFecha.EditValue = DateTime.Now;
            BSUtils.LoaderLook(cboMoneda, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblMoneda), "DescTablaElemento", "IdTablaElemento", true);
            cboMoneda.EditValue = Parametros.intSoles;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            cboVendedor.EditValue = Parametros.intPersonaId;
            BSUtils.LoaderLook(cboFormaPago, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblFormaPago), "DescTablaElemento", "IdTablaElemento", true);
            cboFormaPago.EditValue = Parametros.intContado;
            BSUtils.LoaderLook(cboSituacion, new TablaElementoBL().ListaTodosActivo(Parametros.intEmpresaId, Parametros.intTblSituacionProformaVenta), "DescTablaElemento", "IdTablaElemento", true);
            cboSituacion.EditValue = Parametros.intPFGenerado;
            BSUtils.LoaderLook(cboFinanciera, CargarClienteEntidad(), "Descripcion", "Id", true);
            cboFinanciera.EditValue = 0;

            CargarDescuentoClienteFinal();
            CargarDescuentoClienteMayorista();

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Proforma Venta - Nuevo";

                ObtenerCorrelativo();

                //Especificamos los datos del cliente general
                IdCliente = Parametros.intIdClienteGeneral;
                IdTipoCliente = Parametros.intTipClienteFinal;
                txtNumeroDocumento.Text = Parametros.strNumeroCliente;
                txtDescCliente.Text = Parametros.strDescCliente;
                IdClasificacionCliente = Parametros.intClasico;
                txtTipoCliente.Text = "CLIENTE FINAL" + '-' + "CLASICO";
                txtDireccion.Text = Parametros.strDireccion;

                if (OrigenNuevo == 1)
                {
                    cboVendedor.EditValue = Parametros.intPersonaId;
                    txtObservaciones.Text = "Producto Transformado";
                }

            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Proforma Venta - Modificar";

                ProformaBE objE_Proforma = null;
                objE_Proforma = new ProformaBL().Selecciona(IdProforma);

                IdProforma = objE_Proforma.IdProforma;
                cboDocumento.EditValue = objE_Proforma.IdTipoDocumento;
                txtNumero.Text = objE_Proforma.Numero;
                deFecha.EditValue = objE_Proforma.Fecha;
                cboMoneda.EditValue = objE_Proforma.IdMoneda;
                txtTipoCambio.EditValue = objE_Proforma.TipoCambio;
                txtNumeroDocumento.Text = objE_Proforma.NumeroDocumento;
                cboFormaPago.EditValue = objE_Proforma.IdFormaPago;
                cboSituacion.EditValue = objE_Proforma.IdSituacion;
                cboVendedor.EditValue = objE_Proforma.IdVendedor;
                IdCliente = objE_Proforma.IdCliente;
                txtNumeroDocumento.Text = objE_Proforma.NumeroDocumento;
                IdTipoCliente = objE_Proforma.IdTipoCliente;
                txtDescCliente.Text = objE_Proforma.DescCliente;
                if (IdTipoCliente == Parametros.intTipClienteFinal)
                    txtTipoCliente.Text = objE_Proforma.DescTipoCliente + "-" + objE_Proforma.DescClasificacionCliente;
                else
                    txtTipoCliente.Text = objE_Proforma.DescTipoCliente;
                txtDescCliente.Text = objE_Proforma.DescCliente;
                txtTipoCliente.Text = objE_Proforma.DescTipoCliente;
                txtDireccion.Text = objE_Proforma.Direccion;
                txtTotalCantidad.EditValue = objE_Proforma.TotalCantidad;
                txtSubTotal.EditValue = objE_Proforma.SubTotal;
                txtImpuesto.EditValue = objE_Proforma.Igv;
                txtTotal.EditValue = objE_Proforma.Total;
                txtObservaciones.Text = objE_Proforma.Observacion;
                IdDis_ProyectoServicio = objE_Proforma.IdDis_ProyectoServicio;//ADD
                cboFinanciera.EditValue = objE_Proforma.IdClienteEntidad;
            }

            txtNumeroDocumento.Focus();
            CargaProformaDetalle();
            //CalculaTotales();
        }

        private void frmRegProformaEdit_Shown(object sender, EventArgs e)
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
                //txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Compra.ToString());
                txtTipoCambio.EditValue = decimal.Parse(objE_TipoCambio.Venta.ToString());
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

                        txtTipoCliente.Text = frm.pClienteBE.DescTipoCliente;
                    }
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
                    txtTipoCliente.Text = objManCliente.TipoClasificacion;
                    IdClasificacionCliente = objManCliente.IdClasificacionCliente;
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
                frmRegProformaDetalleEdit movDetalle = new frmRegProformaDetalleEdit();
                int i = 0;
                if (mListaProformaDetalleOrigen.Count > 0)
                    i = mListaProformaDetalleOrigen.Max(ob => Convert.ToInt32(ob.Item));
                movDetalle.intCorrelativo = Convert.ToInt32(i) + 1;
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaProformaDetalleOrigen.Count == 0)
                        {
                            gvProformaDetalle.AddNewRow();
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "IdProforma", movDetalle.oBE.IdProforma);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "IdProformaDetalle", movDetalle.oBE.IdProformaDetalle);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "FlagAprobacion", movDetalle.oBE.FlagAprobacion);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProformaDetalle.UpdateCurrentRow();

                            bNuevo = movDetalle.bNuevo;

                            CalculaTotales();

                            btnNuevo.Focus();

                            return;

                        }
                        if (mListaProformaDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaProformaDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvProformaDetalle.AddNewRow();
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "IdProforma", movDetalle.oBE.IdProforma);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "IdProformaDetalle", movDetalle.oBE.IdProformaDetalle);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "Item", movDetalle.oBE.Item);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "Descuento", movDetalle.oBE.Descuento);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "ValorVenta", movDetalle.oBE.ValorVenta);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "Observacion", movDetalle.oBE.Observacion);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "FlagAprobacion", movDetalle.oBE.FlagAprobacion);
                            gvProformaDetalle.SetRowCellValue(gvProformaDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProformaDetalle.UpdateCurrentRow();

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (mListaProformaDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmRegProformaDetalleEdit movDetalle = new frmRegProformaDetalleEdit();
                movDetalle.IdTipoCliente = IdTipoCliente;
                movDetalle.IdClasificacionCliente = IdClasificacionCliente;
                movDetalle.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.IdProforma = Convert.ToInt32(gvProformaDetalle.GetFocusedRowCellValue("IdProforma"));
                movDetalle.IdProformaDetalle = Convert.ToInt32(gvProformaDetalle.GetFocusedRowCellValue("IdProformaDetalle"));
                movDetalle.intCorrelativo = Convert.ToInt32(gvProformaDetalle.GetFocusedRowCellValue("Item"));
                movDetalle.IdProducto = Convert.ToInt32(gvProformaDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.IdLineaProducto = Convert.ToInt32(gvProformaDetalle.GetFocusedRowCellValue("IdLineaProducto"));
                movDetalle.txtCodigo.Text = gvProformaDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvProformaDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvProformaDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvProformaDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvProformaDetalle.GetFocusedRowCellValue("PrecioUnitario"));
                movDetalle.txtDescuento.EditValue = Convert.ToDecimal(gvProformaDetalle.GetFocusedRowCellValue("PorcentajeDescuento"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvProformaDetalle.GetFocusedRowCellValue("PrecioVenta"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvProformaDetalle.GetFocusedRowCellValue("ValorVenta"));
                movDetalle.txtObservacion.Text = gvProformaDetalle.GetFocusedRowCellValue("Observacion").ToString();
                movDetalle.chkAprobado.Checked = bool.Parse(gvProformaDetalle.GetFocusedRowCellValue("FlagAprobacion").ToString());
              
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvProformaDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvProformaDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvProformaDetalle.SetRowCellValue(xposition, "IdProforma", movDetalle.oBE.IdProforma);
                        gvProformaDetalle.SetRowCellValue(xposition, "IdProformaDetalle", movDetalle.oBE.IdProformaDetalle);
                        gvProformaDetalle.SetRowCellValue(xposition, "Item", movDetalle.oBE.Item);
                        gvProformaDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvProformaDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvProformaDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvProformaDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvProformaDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvProformaDetalle.SetRowCellValue(xposition, "PrecioUnitario", movDetalle.oBE.PrecioUnitario);
                        gvProformaDetalle.SetRowCellValue(xposition, "PorcentajeDescuento", movDetalle.oBE.PorcentajeDescuento);
                        gvProformaDetalle.SetRowCellValue(xposition, "Descuento", movDetalle.oBE.Descuento);
                        gvProformaDetalle.SetRowCellValue(xposition, "PrecioVenta", movDetalle.oBE.PrecioVenta);
                        gvProformaDetalle.SetRowCellValue(xposition, "ValorVenta", movDetalle.oBE.ValorVenta);
                        gvProformaDetalle.SetRowCellValue(xposition, "Observacion", movDetalle.oBE.Observacion);
                        gvProformaDetalle.SetRowCellValue(xposition, "FlagAprobacion", movDetalle.oBE.FlagAprobacion);
                        gvProformaDetalle.SetRowCellValue(xposition, "IdLineaProducto", movDetalle.oBE.IdLineaProducto);
                        gvProformaDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvProformaDetalle.UpdateCurrentRow();

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
                int IdProformaDetalle = 0;
                if (gvProformaDetalle.GetFocusedRowCellValue("IdProformaDetalle") != null)
                    IdProformaDetalle = int.Parse(gvProformaDetalle.GetFocusedRowCellValue("IdProformaDetalle").ToString());
                int Item = 0;
                if (gvProformaDetalle.GetFocusedRowCellValue("Item") != null)
                    Item = int.Parse(gvProformaDetalle.GetFocusedRowCellValue("Item").ToString());
                ProformaDetalleBE objBE_ProformaDetalle = new ProformaDetalleBE();
                objBE_ProformaDetalle.IdProformaDetalle = IdProformaDetalle;
                objBE_ProformaDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_ProformaDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_ProformaDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                ProformaDetalleBL objBL_ProformaDetalle = new ProformaDetalleBL();
                objBL_ProformaDetalle.Elimina(objBE_ProformaDetalle);
                gvProformaDetalle.DeleteRow(gvProformaDetalle.FocusedRowHandle);
                gvProformaDetalle.RefreshData();

                //RegeneraItem
                int i = 0;
                int cuenta = 0;
                foreach (var item in mListaProformaDetalleOrigen)
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                CalculaTotales();

                if (!ValidarIngreso())
                {
                    ProformaBL objBL_Proforma = new ProformaBL();
                    ProformaBE objProforma = new ProformaBE();

                    objProforma.IdProforma = IdProforma;
                    objProforma.Periodo = Parametros.intPeriodo;
                    objProforma.Mes = deFecha.DateTime.Month;
                    objProforma.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    objProforma.Numero = txtNumero.Text;
                    objProforma.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objProforma.IdCliente = IdCliente;
                    objProforma.NumeroDocumento = txtNumeroDocumento.Text;
                    objProforma.DescCliente = txtDescCliente.Text;
                    objProforma.Direccion = txtDireccion.Text;
                    objProforma.IdMoneda = Convert.ToInt32(cboMoneda.EditValue);
                    objProforma.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objProforma.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objProforma.IdVendedor = Convert.ToInt32(cboVendedor.EditValue);
                    objProforma.TotalCantidad = Convert.ToInt32(txtTotalCantidad.EditValue);
                    objProforma.SubTotal = Convert.ToDecimal(txtSubTotal.EditValue);
                    objProforma.PorcentajeImpuesto = Parametros.dmlIGV;
                    objProforma.Igv = Convert.ToDecimal(txtImpuesto.EditValue);
                    objProforma.Total = Convert.ToDecimal(txtTotal.EditValue);
                    objProforma.Observacion = txtObservaciones.Text;
                    objProforma.IdSituacion = Convert.ToInt32(cboSituacion.EditValue);
                    objProforma.IdDis_ProyectoServicio = IdDis_ProyectoServicio;
                    objProforma.IdClienteEntidad = Convert.ToInt32(cboFinanciera.EditValue);
                    objProforma.FlagEstado = true;
                    objProforma.Usuario = Parametros.strUsuarioLogin;
                    objProforma.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objProforma.IdEmpresa = Parametros.intEmpresaId;
                   

                    //Documento Vneta Detalle
                    List<ProformaDetalleBE> lstProformaDetalle = new List<ProformaDetalleBE>();

                    foreach (var item in mListaProformaDetalleOrigen)
                    {
                        ProformaDetalleBE objE_ProformaDetalle = new ProformaDetalleBE();
                        objE_ProformaDetalle.IdEmpresa = item.IdEmpresa;
                        objE_ProformaDetalle.IdProforma = item.IdProforma;
                        objE_ProformaDetalle.IdProformaDetalle = item.IdProformaDetalle;
                        objE_ProformaDetalle.Item = item.Item;
                        objE_ProformaDetalle.IdProducto = item.IdProducto;
                        objE_ProformaDetalle.CodigoProveedor = item.CodigoProveedor;
                        objE_ProformaDetalle.NombreProducto = item.NombreProducto;
                        objE_ProformaDetalle.Abreviatura = item.Abreviatura;
                        objE_ProformaDetalle.Cantidad = item.Cantidad;
                        objE_ProformaDetalle.PrecioUnitario = item.PrecioUnitario;
                        objE_ProformaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                        objE_ProformaDetalle.Descuento = item.Descuento;
                        objE_ProformaDetalle.PrecioVenta = item.PrecioVenta;
                        objE_ProformaDetalle.ValorVenta = item.ValorVenta;
                        objE_ProformaDetalle.Observacion = item.Observacion;
                        objE_ProformaDetalle.FlagAprobacion = item.FlagAprobacion;
                        objE_ProformaDetalle.FlagEstado = true;
                        objE_ProformaDetalle.TipoOper = item.TipoOper;
                        lstProformaDetalle.Add(objE_ProformaDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                    {
                        ObtenerCorrelativo();
                        objProforma.Numero = txtNumero.Text;
                        IdProforma = objBL_Proforma.Inserta(objProforma, lstProformaDetalle);
                    }
                    else
                    {
                        objBL_Proforma.Actualiza(objProforma, lstProformaDetalle);
                    }

                    TotalProforma = Convert.ToDecimal(txtTotal.EditValue);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
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

                        if (gvProformaDetalle.RowCount > 0)
                        {
                            gvProformaDetalle.RefreshData();

                            for (int i = 0; i < gvProformaDetalle.RowCount; i++)
                            {
                                int IdProducto = 0;
                                int IdLineaProducto = 0;
                                decimal decDescuentoOriginal = 0;
                                decimal decDescuento = 0;
                                decimal decPrecioVenta = 0;
                                decimal decValorVenta = 0;
                                decimal decDescuentoEstablecido = 0;

                                IdProducto = int.Parse(gvProformaDetalle.GetRowCellValue(i, "IdProducto").ToString());
                                decDescuentoEstablecido = decimal.Parse(gvProformaDetalle.GetRowCellValue(i, "PorcentajeDescuento").ToString());

                                StockBE objE_Stock = null;
                                objE_Stock = new StockBL().SeleccionaIdProductoPrecio(Parametros.intTiendaId, Parametros.intAlmCentralUcayali, IdProducto);
                                if (objE_Stock != null)
                                {
                                    IdLineaProducto = objE_Stock.IdLineaProducto;
                                    if (decDescuentoEstablecido > objE_Stock.Descuento)
                                        decDescuentoOriginal = decDescuentoEstablecido;
                                    else
                                        decDescuentoOriginal = objE_Stock.Descuento;
                                }

                                foreach (var itemdescuento in mListaDescuentoClienteMayorista)
                                {
                                    if (Convert.ToInt32(cboFormaPago.EditValue) == itemdescuento.IdFormaPago && IdLineaProducto == itemdescuento.IdLineaProducto && decTotal >= itemdescuento.MontoMin && decTotal <= itemdescuento.MontoMax && itemdescuento.FlagPreVenta == false)
                                    {
                                        decDescuento = itemdescuento.PorDescuento;
                                        if (decDescuentoOriginal > decDescuento)
                                        {
                                            
                                                gvProformaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuentoOriginal);
                                                decPrecioVenta = Math.Round(decimal.Parse(gvProformaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuentoOriginal) / 100), 2);
                                                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvProformaDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                gvProformaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                gvProformaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                            
                                        }
                                        else
                                        {
                                           
                                                gvProformaDetalle.SetRowCellValue(i, "PorcentajeDescuento", decDescuento);
                                                decPrecioVenta = Math.Round(decimal.Parse(gvProformaDetalle.GetRowCellValue(i, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100), 2);
                                                decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvProformaDetalle.GetRowCellValue(i, "Cantidad").ToString());
                                                gvProformaDetalle.SetRowCellValue(i, "PrecioVenta", decPrecioVenta);
                                                gvProformaDetalle.SetRowCellValue(i, "ValorVenta", decValorVenta);
                                            
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            
            //CalculaTotales();
        }

        private void establecerdescuentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Parametros.strUsuarioLogin == "master" || Parametros.intPerfilId == Parametros.intPerAdministrador
                || Parametros.strUsuarioLogin == "rcastañeda" || Parametros.strUsuarioLogin == "liliana" 
                || Parametros.strUsuarioLogin == "dhuaman" || Parametros.strUsuarioLogin == "focampo")
            {
                frmEstablecerDescuento objDescuento = new frmEstablecerDescuento();
                objDescuento.StartPosition = FormStartPosition.CenterParent;
                if (objDescuento.ShowDialog() == DialogResult.OK)
                {
                    for (int i = 0; i < gvProformaDetalle.SelectedRowsCount; i++)
                    {
                        decimal decDescuento = 0;
                        decimal decPrecioVenta = 0;
                        decimal decValorVenta = 0;

                        int row = gvProformaDetalle.GetSelectedRows()[i];
                        decDescuento = decimal.Parse(objDescuento.Descuento.ToString());
                        gvProformaDetalle.SetRowCellValue(row, "PorcentajeDescuento", decDescuento);

                        decPrecioVenta = decimal.Parse(gvProformaDetalle.GetRowCellValue(row, "PrecioUnitario").ToString()) * ((100 - decDescuento) / 100);
                        decValorVenta = Math.Round(decPrecioVenta, 2) * decimal.Parse(gvProformaDetalle.GetRowCellValue(row, "Cantidad").ToString());
                        gvProformaDetalle.SetRowCellValue(row, "PrecioVenta", decPrecioVenta);
                        gvProformaDetalle.SetRowCellValue(row, "ValorVenta", decValorVenta);

                    }
                }

                gvProformaDetalle.RefreshData();

                CalculaTotales();
            }
            else
            {
                XtraMessageBox.Show("Ud. no tiene los permisos para esta operación", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtNumeroProyecto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //Traemos la información de la Dis_ProyectoServicio
                    Dis_ProyectoServicioBE objE_Dis_ProyectoServicio = null;
                    objE_Dis_ProyectoServicio = new Dis_ProyectoServicioBL().SeleccionaNumero(Parametros.intPeriodo, txtNumeroProyecto.Text.Trim());
                    if (objE_Dis_ProyectoServicio != null)
                    {
                        IdDis_ProyectoServicio = objE_Dis_ProyectoServicio.IdDis_ProyectoServicio;
                        txtNumeroProyecto.Text = objE_Dis_ProyectoServicio.Numero;
                        cboVendedor.EditValue = objE_Dis_ProyectoServicio.IdAsesor;
                        cboMoneda.EditValue = objE_Dis_ProyectoServicio.IdMoneda;
                        txtTipoCambio.EditValue = objE_Dis_ProyectoServicio.TipoCambio;
                        IdCliente = objE_Dis_ProyectoServicio.IdCliente;
                        txtNumeroDocumento.Text = objE_Dis_ProyectoServicio.NumeroDocumento;
                        txtDescCliente.Text = objE_Dis_ProyectoServicio.DescCliente;
                        //txtTipoCliente.Text = objE_Dis_ProyectoServicio.DescTipoCliente;
                        txtDireccion.Text = objE_Dis_ProyectoServicio.Direccion;


                        //Selecciona TipoCliente
                        ClienteBE objE_Cliente = null;
                        objE_Cliente = new ClienteBL().SeleccionaNumero(Parametros.intEmpresaId, objE_Dis_ProyectoServicio.NumeroDocumento);
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
                        }
                        else
                        {
                            XtraMessageBox.Show("El número de documento de cliente no existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void CargarDescuentoClienteFinal()
        {
            mListaDescuentoClienteFinal = new DescuentoClienteFinalBL().ListaTodosActivo(Parametros.intEmpresaId);
        }

        private void CargarDescuentoClienteMayorista()
        {
            mListaDescuentoClienteMayorista = new DescuentoClienteMayoristaBL().ListaTodosActivo(Parametros.intEmpresaId, 0, 0);
        }

        private void CalcularValoresGrilla(int IdMoneda)
        {
            try
            {
                if (gvProformaDetalle.RowCount > 0)
                {
                    if (IdMoneda == Parametros.intSoles)
                    {
                        int posicion = 0;
                        foreach (var item in mListaProformaDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["PrecioUnitario"]).ToString()) * decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }

                            gvProformaDetalle.SetRowCellValue(posicion, gvProformaDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvProformaDetalle.SetRowCellValue(posicion, gvProformaDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvProformaDetalle.SetRowCellValue(posicion, gvProformaDetalle.Columns["ValorVenta"], decValorVenta);
                            posicion++;
                        }
                    }
                    else
                    {
                        int posicion = 0;
                        foreach (var item in mListaProformaDetalleOrigen)
                        {
                            decimal decPrecioUnitario = 0;
                            decimal decPorcentajeDescuento = 0;
                            decimal decPrecioVenta = 0;
                            decimal decValorVenta = 0;
                            if (IdTipoCliente == Parametros.intTipClienteMayorista)
                            {
                                decPrecioUnitario = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMayorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);
                            }
                            else
                            {
                                decPrecioUnitario = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["PrecioUnitario"]).ToString()) / decimal.Parse(Parametros.dmlTCMinorista.ToString());
                                decPorcentajeDescuento = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["PorcentajeDescuento"]).ToString());
                                decPrecioVenta = decPrecioUnitario * ((100 - decPorcentajeDescuento) / 100);
                                decValorVenta = decimal.Parse(gvProformaDetalle.GetRowCellValue(posicion, gvProformaDetalle.Columns["Cantidad"]).ToString()) * Math.Round(decPrecioVenta, 2);

                            }
                            gvProformaDetalle.SetRowCellValue(posicion, gvProformaDetalle.Columns["PrecioUnitario"], decPrecioUnitario);
                            gvProformaDetalle.SetRowCellValue(posicion, gvProformaDetalle.Columns["PrecioVenta"], decPrecioVenta);
                            gvProformaDetalle.SetRowCellValue(posicion, gvProformaDetalle.Columns["ValorVenta"], decValorVenta);
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

        private void ObtenerCorrelativo()
        {
            try
            {
                List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                string sNumero = "";
                string sSerie = "";
                mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocProforma, Parametros.intPeriodo);
                if (mListaNumero.Count > 0)
                {
                    sNumero = FuncionBase.AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    sSerie = FuncionBase.AgregarCaracter((mListaNumero[0].Serie).ToString(), "0", 3);
                }
                txtNumero.Text = sNumero;
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

            if (txtNumero.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- El nímero del documento no puede estar vacío.\n";
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

            if (cboVendedor.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar un vendedor.\n";
                flag = true;
            }

            if (cboSituacion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar la situación de la proforma de venta.\n";
                flag = true;
            }

            if (cboFormaPago.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Seleccionar la forma de pago.\n";
                flag = true;
            }

            if (mListaProformaDetalleOrigen.Count == 0)
            {
                strMensaje = strMensaje + "- Nos se puede generar la proforma, mientra no haya productos.\n";
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

                if (mListaProformaDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaProformaDetalleOrigen)
                    {
                        intTotalCantidad = intTotalCantidad + item.Cantidad;
                        deValorVenta = item.ValorVenta;
                        deTotal = deTotal + deValorVenta;
                    }

                    txtTotal.EditValue = Math.Round(deTotal, 2);
                    deSubTotal = deTotal / decimal.Parse(Parametros.dblIGV.ToString());
                    txtSubTotal.EditValue = deSubTotal;
                    deImpuesto = deTotal - deSubTotal;
                    txtImpuesto.EditValue = Math.Round(deImpuesto, 2);
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
            ColumnView View = (ColumnView)gcProformaDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvProformaDetalle.FocusedRowHandle + 1, column, searchText);
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
            ColumnView View = (ColumnView)gcProformaDetalle.FocusedView;
            // obtaining the column bound to the Country field 
            GridColumn column = View.Columns[Column];
            GridColumn columnbus = View.Columns["Cantidad"];
            if (column != null)
            {
                // locating the row 
                int rhFound = View.LocateByDisplayText(gvProformaDetalle.FocusedRowHandle + 1, column, searchText);
                // focusing the cell 
                if (rhFound != 0)
                {
                    View.FocusedRowHandle = rhFound;
                    View.FocusedColumn = columnbus;
                }
            }
        }

        private void CargaProformaDetalle()
        {
            List<ProformaDetalleBE> lstTmpProformaDetalle = null;
            lstTmpProformaDetalle = new ProformaDetalleBL().ListaTodosActivo(Parametros.intEmpresaId, IdProforma);

            foreach (ProformaDetalleBE item in lstTmpProformaDetalle)
            {
                CProformaDetalle objE_ProformaDetalle = new CProformaDetalle();
                objE_ProformaDetalle.IdEmpresa = item.IdEmpresa;
                objE_ProformaDetalle.IdProforma = item.IdProforma;
                objE_ProformaDetalle.IdProformaDetalle = item.IdProformaDetalle;
                objE_ProformaDetalle.Item = item.Item;
                objE_ProformaDetalle.IdProducto = item.IdProducto;
                objE_ProformaDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_ProformaDetalle.NombreProducto = item.NombreProducto;
                objE_ProformaDetalle.Abreviatura = item.Abreviatura;
                objE_ProformaDetalle.Cantidad = item.Cantidad;
                objE_ProformaDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_ProformaDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_ProformaDetalle.Descuento = item.Descuento;
                objE_ProformaDetalle.PrecioVenta = item.PrecioVenta;
                objE_ProformaDetalle.ValorVenta = item.ValorVenta;
                objE_ProformaDetalle.Observacion = item.Observacion;
                objE_ProformaDetalle.FlagAprobacion = item.FlagAprobacion;
                objE_ProformaDetalle.PorcentajeDescuentoInicial = 0;
                objE_ProformaDetalle.IdLineaProducto = 0;
                objE_ProformaDetalle.TipoOper = item.TipoOper;
                mListaProformaDetalleOrigen.Add(objE_ProformaDetalle);
            }

            bsListado.DataSource = mListaProformaDetalleOrigen;
            gcProformaDetalle.DataSource = bsListado;
            gcProformaDetalle.RefreshDataSource();
        }

        #endregion

        public class CProformaDetalle
        {
            public Int32 IdEmpresa { get; set; }
            public Int32 IdProforma { get; set; }
            public Int32 IdProformaDetalle { get; set; }
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
            public String Observacion { get; set; }
            public Boolean FlagAprobacion { get; set; }
            public Int32 Stock { get; set; }
            public Decimal PorcentajeDescuentoInicial { get; set; }
            public Int32 IdLineaProducto { get; set; }
            public Int32 TipoOper { get; set; }

            public CProformaDetalle()
            {

            }
        }

        private void txtNumeroFactura_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                        //Tramoes la información del detalle de la FacturaCompra
                        List<FacturaCompraDetalleBE> lstTmpFacturaCompraDetalle = null;
                        lstTmpFacturaCompraDetalle = new FacturaCompraDetalleBL().ListaNumeroPrecioABCD(Parametros.intEmpresaId, txtNumeroFacturaCompra.Text.Trim());



                        int nItem = 1;
                        foreach (FacturaCompraDetalleBE item in lstTmpFacturaCompraDetalle)
                        {
                            CProformaDetalle objE_ProformaDetalle = new CProformaDetalle();

                            objE_ProformaDetalle.IdEmpresa = item.IdEmpresa;
                            objE_ProformaDetalle.IdProforma = 0;
                            objE_ProformaDetalle.IdProformaDetalle = 0;
                            objE_ProformaDetalle.Item = nItem;
                            objE_ProformaDetalle.IdProducto = item.IdProducto;
                            objE_ProformaDetalle.CodigoProveedor = item.CodigoProveedor;
                            objE_ProformaDetalle.NombreProducto = item.NombreProducto;
                            objE_ProformaDetalle.Abreviatura = item.Abreviatura;
                            objE_ProformaDetalle.Cantidad = 1;
                            objE_ProformaDetalle.PrecioUnitario = 1;//
                            objE_ProformaDetalle.PorcentajeDescuento =0;//
                            objE_ProformaDetalle.Descuento = 0;
                            objE_ProformaDetalle.PrecioVenta = 1;//
                            objE_ProformaDetalle.ValorVenta = 1;//
                            objE_ProformaDetalle.Observacion = "Importado de Factura Compra";
                            objE_ProformaDetalle.FlagAprobacion = true;
                            objE_ProformaDetalle.TipoOper = item.TipoOper;

                            #region "Asignar PrecioAB Y CD"

                            if (Convert.ToInt32(cboMoneda.EditValue) == Parametros.intSoles)
                            {
                                if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                {
                                    objE_ProformaDetalle.PrecioUnitario = item.PrecioABSoles;
                                    if (item.FlagDescuentoAB)
                                        objE_ProformaDetalle.PorcentajeDescuento = item.DescuentoAB;
                                    else
                                        objE_ProformaDetalle.PorcentajeDescuento = item.Descuento;

                                    objE_ProformaDetalle.PrecioVenta = objE_ProformaDetalle.PrecioUnitario * ((100 - objE_ProformaDetalle.PorcentajeDescuento) / 100);
                                    objE_ProformaDetalle.ValorVenta = objE_ProformaDetalle.PrecioVenta * objE_ProformaDetalle.Cantidad;
                                    //txtPrecioVenta.EditValue = Convert.ToDecimal(txtPrecioUnitario.Text) * ((100 - Convert.ToDecimal(txtDescuento.Text)) / 100);
                                    //txtValorVenta.EditValue = Convert.ToDecimal(txtPrecioVenta.Text) * Convert.ToDecimal(txtCantidad.Text);
                                }
                                else
                                {
                                    objE_ProformaDetalle.PrecioUnitario = item.PrecioCDSoles;
                                    objE_ProformaDetalle.PorcentajeDescuento = item.Descuento;
                                    objE_ProformaDetalle.PrecioVenta = objE_ProformaDetalle.PrecioUnitario * ((100 - objE_ProformaDetalle.PorcentajeDescuento) / 100);
                                    objE_ProformaDetalle.ValorVenta = objE_ProformaDetalle.PrecioVenta * objE_ProformaDetalle.Cantidad;
                                }
                            }
                            else
                            {
                                if (IdTipoCliente == Parametros.intTipClienteMayorista)
                                {
                                    objE_ProformaDetalle.PrecioUnitario = item.PrecioAB;
                                    if (item.FlagDescuentoAB)
                                        objE_ProformaDetalle.PorcentajeDescuento = item.DescuentoAB;
                                    else
                                        objE_ProformaDetalle.PorcentajeDescuento = item.Descuento;

                                    objE_ProformaDetalle.PrecioVenta = objE_ProformaDetalle.PrecioUnitario * ((100 - objE_ProformaDetalle.PorcentajeDescuento) / 100);
                                    objE_ProformaDetalle.ValorVenta = objE_ProformaDetalle.PrecioVenta * objE_ProformaDetalle.Cantidad;
                                }
                                else
                                {
                                    objE_ProformaDetalle.PrecioUnitario = item.PrecioCD;
                                    objE_ProformaDetalle.PorcentajeDescuento = item.Descuento;
                                    objE_ProformaDetalle.PrecioVenta = objE_ProformaDetalle.PrecioUnitario * ((100 - objE_ProformaDetalle.PorcentajeDescuento) / 100);
                                    objE_ProformaDetalle.ValorVenta = objE_ProformaDetalle.PrecioVenta * objE_ProformaDetalle.Cantidad;
                                }
                            }
                            #endregion

                            mListaProformaDetalleOrigen.Add(objE_ProformaDetalle);

                            nItem = nItem + 1;
                        }

                        bsListado.DataSource = mListaProformaDetalleOrigen;
                        gcProformaDetalle.DataSource = bsListado;
                        gcProformaDetalle.RefreshDataSource();

                        CalculaTotales();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private DataTable CargarClienteEntidad()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", Type.GetType("System.Int32"));
            dt.Columns.Add("Descripcion", Type.GetType("System.String"));
            DataRow dr;
            dr = dt.NewRow();
            dr["Id"] = 0;
            dr["Descripcion"] = "NINGUNO";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 175381;
            dr["Descripcion"] = "BBVA BANCO CONTINENTAL";
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr["Id"] = 1;
            dr["Descripcion"] = "LISTA DE NOVIOS";
            dt.Rows.Add(dr);

            return dt;
        }


    }
}