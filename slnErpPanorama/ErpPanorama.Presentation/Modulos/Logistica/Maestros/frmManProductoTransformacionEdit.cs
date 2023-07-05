using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Drawing;
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
using ErpPanorama.BusinessLogic;
using ErpPanorama.BusinessEntity;

namespace ErpPanorama.Presentation.Modulos.Logistica.Maestros
{
    public partial class frmManProductoTransformacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        public List<CProductoTransformacionDetalle> mListaProductoTransformacionDetalleOrigen = new List<CProductoTransformacionDetalle>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        int _IdProductoTransformacion = 0;

        public int IdProductoTransformacion
        {
            get { return _IdProductoTransformacion; }
            set { _IdProductoTransformacion = value; }
        }

        public ProductoTransformacionBE pProductoTransformacionBE { get; set; }

        public Operacion pOperacion;

        private int IdMovimientoAlmacen = 0;
        private int IdProducto = 0;
        private int CantidadAnterior = 0;
        private int IdProforma = 0;

        #endregion

        #region "Eventos"

        public frmManProductoTransformacionEdit()
        {
            InitializeComponent();
        }

        private void frmManProductoTransformacionEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboUnidadMedida, new UnidadMedidaBL().ListaTodosActivo(Parametros.intEmpresaId), "Abreviatura", "IdUnidadMedida", true);
            cboUnidadMedida.EditValue = 2;
            BSUtils.LoaderLook(cboVendedor, new PersonaBL().SeleccionaVendedor(Parametros.intEmpresaId), "ApeNom", "IdPersona", true);
            BSUtils.LoaderLook(cboFamilia, new FamiliaProductoBL().ListaTodosActivo(Parametros.intEmpresaId), "DescFamiliaProducto", "IdFamiliaProducto", true);
            txtTipoCambio.EditValue = Parametros.dmlTCMinorista;

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Producto Transformación - Nuevo";
                ObtenerCorrelativo();
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Producto Transformación - Modificar";

                IdProductoTransformacion = pProductoTransformacionBE.IdProductoTransformacion;
                txtCodigo.Text = pProductoTransformacionBE.Codigo;
                txtNombre.Text = pProductoTransformacionBE.NombreProducto;
                cboUnidadMedida.EditValue = pProductoTransformacionBE.IdUnidadMedida;
                txtCantidad.EditValue = pProductoTransformacionBE.Cantidad;
                CantidadAnterior = pProductoTransformacionBE.Cantidad;
                txtCosto.EditValue = pProductoTransformacionBE.Costo;
                txtMargen.EditValue = pProductoTransformacionBE.Margen;
                txtPrecioUnitario.EditValue = pProductoTransformacionBE.PrecioSoles;
                txtTipoCambio.EditValue = pProductoTransformacionBE.TipoCambio;
                txtPrecioDolar.EditValue = pProductoTransformacionBE.PrecioDolar;
                IdMovimientoAlmacen = pProductoTransformacionBE.IdMovimientoAlmacen;
                IdProforma = pProductoTransformacionBE.IdProforma;
                txtCosto.Properties.ReadOnly = true;
                txtMargen.Properties.ReadOnly = true;
                txtPrecioUnitario.Properties.ReadOnly = true;
                txtTipoCambio.Properties.ReadOnly = true;
            }

            //Linea por default
            cboFamilia.EditValue = 1;
            cboLinea.EditValue = 4;
            cboSubLinea.EditValue = 58;
            cboModelo.EditValue = 1094;

            //if (Parametros.strUsuarioLogin == "master")
            //    txtCodigo.Properties.ReadOnly = false;
            //else
                txtCodigo.Properties.ReadOnly = true;




            txtNombre.Select();

            //CargaProductoTransformacionDetalle();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text.Trim() == "")
                {
                    XtraMessageBox.Show("Ingresar el Código del Producto Transformación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                frmManProductoTransformacionalDetalleEdit movDetalle = new frmManProductoTransformacionalDetalleEdit();
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaProductoTransformacionDetalleOrigen.Count == 0)
                        {
                            gvProductoTransformacionDetalle.AddNewRow();
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "IdProductoTransformacion", movDetalle.oBE.IdProductoTransformacion);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "IdProductoTransformacionDetalle", movDetalle.oBE.IdProductoTransformacionDetalle);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "Costo", movDetalle.oBE.Costo);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProductoTransformacionDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaProductoTransformacionDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaProductoTransformacionDetalleOrigen.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvProductoTransformacionDetalle.AddNewRow();
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "IdProductoTransformacion", movDetalle.oBE.IdProductoTransformacion);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "IdProductoTransformacionDetalle", movDetalle.oBE.IdProductoTransformacionDetalle);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "IdProducto", movDetalle.oBE.IdProducto);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "NombreProducto", movDetalle.oBE.NombreProducto);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "Abreviatura", movDetalle.oBE.Abreviatura);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "Cantidad", movDetalle.oBE.Cantidad);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "Costo", movDetalle.oBE.Costo);
                            gvProductoTransformacionDetalle.SetRowCellValue(gvProductoTransformacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvProductoTransformacionDetalle.UpdateCurrentRow();

                            CalculaTotales();

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
            if (mListaProductoTransformacionDetalleOrigen.Count > 0)
            {
                int xposition = 0;

                frmManProductoTransformacionalDetalleEdit movDetalle = new frmManProductoTransformacionalDetalleEdit();
                movDetalle.IdProductoTransformacion = Convert.ToInt32(gvProductoTransformacionDetalle.GetFocusedRowCellValue("IdProductoTransformacion"));
                movDetalle.IdProductoTransformacionDetalle = Convert.ToInt32(gvProductoTransformacionDetalle.GetFocusedRowCellValue("IdProductoTransformacionDetalle"));
                movDetalle.IdProducto = Convert.ToInt32(gvProductoTransformacionDetalle.GetFocusedRowCellValue("IdProducto"));
                movDetalle.txtCodigo.Text = gvProductoTransformacionDetalle.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvProductoTransformacionDetalle.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvProductoTransformacionDetalle.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvProductoTransformacionDetalle.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvProductoTransformacionDetalle.GetFocusedRowCellValue("Costo"));

                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvProductoTransformacionDetalle.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {
                        gvProductoTransformacionDetalle.SetRowCellValue(xposition, "IdEmpresa", movDetalle.oBE.IdEmpresa);
                        gvProductoTransformacionDetalle.SetRowCellValue(xposition, "IdProductoTransformacion", movDetalle.oBE.IdProductoTransformacion);
                        gvProductoTransformacionDetalle.SetRowCellValue(xposition, "IdProductoTransformacionDetalle", movDetalle.oBE.IdProductoTransformacionDetalle);
                        gvProductoTransformacionDetalle.SetRowCellValue(xposition, "IdProducto", movDetalle.oBE.IdProducto);
                        gvProductoTransformacionDetalle.SetRowCellValue(xposition, "CodigoProveedor", movDetalle.oBE.CodigoProveedor);
                        gvProductoTransformacionDetalle.SetRowCellValue(xposition, "NombreProducto", movDetalle.oBE.NombreProducto);
                        gvProductoTransformacionDetalle.SetRowCellValue(xposition, "Abreviatura", movDetalle.oBE.Abreviatura);
                        gvProductoTransformacionDetalle.SetRowCellValue(xposition, "Cantidad", movDetalle.oBE.Cantidad);
                        gvProductoTransformacionDetalle.SetRowCellValue(xposition, "Costo", movDetalle.oBE.Costo);
                        if (pOperacion == Operacion.Modificar && Convert.ToDecimal(gvProductoTransformacionDetalle.GetFocusedRowCellValue("TipoOper")) == Convert.ToInt32(Operacion.Nuevo))
                            gvProductoTransformacionDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                        else
                            gvProductoTransformacionDetalle.SetRowCellValue(xposition, "TipoOper", Convert.ToInt32(Operacion.Modificar));
                        gvProductoTransformacionDetalle.UpdateCurrentRow();

                        CalculaTotales();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (mListaProductoTransformacionDetalleOrigen.Count > 0)
                {
                    if (int.Parse(gvProductoTransformacionDetalle.GetFocusedRowCellValue("IdProducto").ToString()) != 0)
                    {
                        int IdProductoTransformacionDetalle = 0;
                        if (gvProductoTransformacionDetalle.GetFocusedRowCellValue("IdProductoTransformacionDetalle") != null)
                            IdProductoTransformacionDetalle = int.Parse(gvProductoTransformacionDetalle.GetFocusedRowCellValue("IdProductoTransformacionDetalle").ToString());
                        int Item = 0;
                        if (gvProductoTransformacionDetalle.GetFocusedRowCellValue("Item") != null)
                            Item = int.Parse(gvProductoTransformacionDetalle.GetFocusedRowCellValue("Item").ToString());
                        ProductoTransformacionDetalleBE objBE_ProductoTransformacionDetalle = new ProductoTransformacionDetalleBE();
                        objBE_ProductoTransformacionDetalle.IdProductoTransformacionDetalle = IdProductoTransformacionDetalle;
                        objBE_ProductoTransformacionDetalle.IdEmpresa = Parametros.intEmpresaId;
                        objBE_ProductoTransformacionDetalle.Usuario = Parametros.strUsuarioLogin;
                        objBE_ProductoTransformacionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                        ProductoTransformacionDetalleBL objBL_ProductoTransformacionDetalle = new ProductoTransformacionDetalleBL();
                        objBL_ProductoTransformacionDetalle.Elimina(objBE_ProductoTransformacionDetalle);
                        gvProductoTransformacionDetalle.DeleteRow(gvProductoTransformacionDetalle.FocusedRowHandle);
                        gvProductoTransformacionDetalle.RefreshData();

                    }
                    else
                    {
                        gvProductoTransformacionDetalle.DeleteRow(gvProductoTransformacionDetalle.FocusedRowHandle);
                        gvProductoTransformacionDetalle.RefreshData();
                    }

                    CalculaTotales();
                }
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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    ProductoTransformacionBL objBL_ProductoTransformacion = new ProductoTransformacionBL();
                    ProductoTransformacionBE objProductoTransformacion = new ProductoTransformacionBE();
                    objProductoTransformacion.IdProductoTransformacion = IdProductoTransformacion;
                    objProductoTransformacion.IdTienda = Parametros.intTiendaId;
                    objProductoTransformacion.Codigo = txtCodigo.Text.Trim();
                    objProductoTransformacion.NombreProducto = txtNombre.Text.Trim();
                    objProductoTransformacion.IdUnidadMedida = Convert.ToInt32(cboUnidadMedida.EditValue);
                    objProductoTransformacion.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                    objProductoTransformacion.Costo = Convert.ToDecimal(txtCosto.EditValue);
                    objProductoTransformacion.Margen = Convert.ToDecimal(txtMargen.EditValue);
                    objProductoTransformacion.PrecioSoles = Convert.ToDecimal(txtPrecioUnitario.EditValue);
                    objProductoTransformacion.TipoCambio = Convert.ToDecimal(txtTipoCambio.EditValue);
                    objProductoTransformacion.PrecioDolar = Convert.ToDecimal(txtPrecioDolar.EditValue);
                    objProductoTransformacion.IdMovimientoAlmacen = IdMovimientoAlmacen;
                    objProductoTransformacion.IdProforma = IdProforma;
                    objProductoTransformacion.FlagEstado = true;
                    objProductoTransformacion.Usuario = Parametros.strUsuarioLogin;
                    objProductoTransformacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objProductoTransformacion.IdEmpresa = Parametros.intEmpresaId;

                    //ProductoTransformacion Detalle
                    List<ProductoTransformacionDetalleBE> lstProductoTransformacionDetalle = new List<ProductoTransformacionDetalleBE>();

                    //foreach (var item in mListaProductoTransformacionDetalleOrigen)
                    //{
                    //    ProductoTransformacionDetalleBE objE_ProductoTransformacionDetalle = new ProductoTransformacionDetalleBE();
                    //    objE_ProductoTransformacionDetalle.IdProductoTransformacion = item.IdProductoTransformacion;
                    //    objE_ProductoTransformacionDetalle.IdProductoTransformacionDetalle = item.IdProductoTransformacionDetalle;
                    //    objE_ProductoTransformacionDetalle.IdProducto = item.IdProducto;
                    //    objE_ProductoTransformacionDetalle.CodigoProveedor = item.CodigoProveedor;
                    //    objE_ProductoTransformacionDetalle.NombreProducto = item.NombreProducto;
                    //    objE_ProductoTransformacionDetalle.Abreviatura = item.Abreviatura;
                    //    objE_ProductoTransformacionDetalle.Cantidad = item.Cantidad;
                    //    objE_ProductoTransformacionDetalle.Costo = item.Costo;
                    //    objE_ProductoTransformacionDetalle.FlagEstado = true;
                    //    objE_ProductoTransformacionDetalle.TipoOper = item.TipoOper;
                    //    lstProductoTransformacionDetalle.Add(objE_ProductoTransformacionDetalle);
                    //}

                    #region "Nota Salida"
                    MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                    MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                    objMovimientoAlmacen.IdMovimientoAlmacen = IdMovimientoAlmacen;
                    objMovimientoAlmacen.Periodo = Parametros.intPeriodo;
                    objMovimientoAlmacen.IdTipoDocumento = Parametros.intTipoDocNotaSalida;
                    objMovimientoAlmacen.Numero = "000000";
                    objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovIngreso;
                    objMovimientoAlmacen.IdAlmacenOrigen = Parametros.intAlmCentralUcayali;
                    objMovimientoAlmacen.Fecha = Parametros.dtFechaHoraServidor.Date;
                    objMovimientoAlmacen.IdMotivo = Parametros.intMovAjusteInventario;
                    objMovimientoAlmacen.NumeroDocumento = "000000";
                    objMovimientoAlmacen.Referencia = "";
                    objMovimientoAlmacen.Observaciones = "Generado por Transformación de Productos";
                    objMovimientoAlmacen.IdAlmacenDestino = Parametros.intAlmCentralUcayali;
                    objMovimientoAlmacen.IdCliente = null;
                    objMovimientoAlmacen.IdMovimientoAlmacenReferencia = null;
                    objMovimientoAlmacen.FlagEstado = true;
                    objMovimientoAlmacen.Usuario = Parametros.strUsuarioLogin;
                    objMovimientoAlmacen.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objMovimientoAlmacen.IdEmpresa = Parametros.intEmpresaId;
                    objMovimientoAlmacen.IdTienda = Parametros.intTiendaId;

                    //Registro de NI Detalle
                    List<MovimientoAlmacenDetalleBE> lstMovimientoAlmacenDetalle = new List<MovimientoAlmacenDetalleBE>();

                    MovimientoAlmacenDetalleBE objE_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleBE();
                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacenDetalle = 0;
                    objE_MovimientoAlmacenDetalle.IdEmpresa = Parametros.intEmpresaId;
                    objE_MovimientoAlmacenDetalle.IdMovimientoAlmacen = IdMovimientoAlmacen;
                    objE_MovimientoAlmacenDetalle.Item = 1;
                    objE_MovimientoAlmacenDetalle.IdProducto = 0;
                    objE_MovimientoAlmacenDetalle.Cantidad = Convert.ToInt32(txtCantidad.EditValue);
                    objE_MovimientoAlmacenDetalle.CantidadAnt = 0;
                    objE_MovimientoAlmacenDetalle.CostoUnitario = 0;
                    objE_MovimientoAlmacenDetalle.MontoTotal = 0;
                    objE_MovimientoAlmacenDetalle.IdKardex = 0;
                    objE_MovimientoAlmacenDetalle.Observacion = "";
                    objE_MovimientoAlmacenDetalle.FlagEstado = true;
                    objE_MovimientoAlmacenDetalle.Usuario = Parametros.strUsuarioLogin;
                    objE_MovimientoAlmacenDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objE_MovimientoAlmacenDetalle.TipoOper = 1;
                    if(pOperacion == Operacion.Nuevo)
                        objE_MovimientoAlmacenDetalle.CantidadAnt = Convert.ToInt32(txtCantidad.EditValue);
                    else
                        objE_MovimientoAlmacenDetalle.CantidadAnt = CantidadAnterior;
                    lstMovimientoAlmacenDetalle.Add(objE_MovimientoAlmacenDetalle);

                    #endregion


                    if (pOperacion == Operacion.Nuevo)
                    {
                        int IdProducto = 0;
                        IdProducto = GrabarProducto();
                        objProductoTransformacion.IdProducto = IdProducto;
                        lstMovimientoAlmacenDetalle[0].IdProducto = IdProducto;
                        objBL_ProductoTransformacion.Inserta(objProductoTransformacion, lstProductoTransformacionDetalle, objMovimientoAlmacen, lstMovimientoAlmacenDetalle);
                        
                        XtraMessageBox.Show("Código creado correctamente.");
                    }
                    else
                    {
                        objBL_ProductoTransformacion.Actualiza(objProductoTransformacion, lstProductoTransformacionDetalle, objMovimientoAlmacen, lstMovimientoAlmacenDetalle);
                    }

                    Cursor = Cursors.Default;

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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void cboUnidadMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        #endregion

        #region "Metodos"

        private void CalculaTotales()
        {
            try
            {

                decimal deValorVenta = 0;
                decimal deTotal = 0;

                if (mListaProductoTransformacionDetalleOrigen.Count > 0)
                {
                    foreach (var item in mListaProductoTransformacionDetalleOrigen)
                    {
                        deValorVenta = item.Costo;
                        deTotal = deTotal + deValorVenta;
                    }

                    txtPrecioDolar.EditValue = Math.Round(deTotal, 2);

                }
                else
                {
                    txtPrecioDolar.EditValue = 0;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaProductoTransformacionDetalle()
        {
            List<ProductoTransformacionDetalleBE> lstTmpProductoTransformacionDetalle = null;
            lstTmpProductoTransformacionDetalle = new ProductoTransformacionDetalleBL().ListaTodosActivo(IdProductoTransformacion);

            foreach (ProductoTransformacionDetalleBE item in lstTmpProductoTransformacionDetalle)
            {
                CProductoTransformacionDetalle objE_ProductoTransformacionDetalle = new CProductoTransformacionDetalle();
                objE_ProductoTransformacionDetalle.IdProductoTransformacion = item.IdProductoTransformacion;
                objE_ProductoTransformacionDetalle.IdProductoTransformacionDetalle = item.IdProductoTransformacionDetalle;
                objE_ProductoTransformacionDetalle.IdProducto = item.IdProducto;
                objE_ProductoTransformacionDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_ProductoTransformacionDetalle.NombreProducto = item.NombreProducto;
                objE_ProductoTransformacionDetalle.Abreviatura = item.Abreviatura;
                objE_ProductoTransformacionDetalle.Cantidad = item.Cantidad;
                objE_ProductoTransformacionDetalle.Costo = item.Costo;
                objE_ProductoTransformacionDetalle.TipoOper = item.TipoOper;
                mListaProductoTransformacionDetalleOrigen.Add(objE_ProductoTransformacionDetalle);
            }

            bsListado.DataSource = mListaProductoTransformacionDetalleOrigen;
            gcProductoTransformacionDetalle.DataSource = bsListado;
            gcProductoTransformacionDetalle.RefreshDataSource();

            CalculaTotales();
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (txtCodigo.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingresar Código del Producto Transformación.\n";
                flag = true;
            }

            //if (mListaProductoTransformacionDetalleOrigen.Count == 0)
            //{
            //    strMensaje = strMensaje + "- Nos se puede generar el Producto Transformación, mientra no haya productos.\n";
            //    flag = true;
            //}

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private Int32 GrabarProducto()
        {
            ProductoBL objBL_Producto = new ProductoBL();
            ProductoBE objE_Producto = new ProductoBE();

            objE_Producto.IdProducto = 0;
            objE_Producto.CodigoProveedor = txtCodigo.Text;
            objE_Producto.CodigoPanorama = "";
            objE_Producto.IdUnidadMedida = Convert.ToInt32(cboUnidadMedida.EditValue);
            objE_Producto.IdFamiliaProducto = Convert.ToInt32(cboFamilia.EditValue);
            objE_Producto.IdLineaProducto = Convert.ToInt32(cboLinea.EditValue);
            objE_Producto.IdSubLineaProducto = Convert.ToInt32(cboSubLinea.EditValue);
            objE_Producto.IdModeloProducto = Convert.ToInt32(cboModelo.EditValue);
            objE_Producto.IdMaterial = 0;
            objE_Producto.IdMarca = 1;
            objE_Producto.IdProcedencia = 0;
            objE_Producto.NombreProducto = txtNombre.Text;
            objE_Producto.Descripcion = "";
            objE_Producto.Peso = 0;
            objE_Producto.Medida = "";
            objE_Producto.CodigoBarra = "";
            objE_Producto.Imagen = new FuncionBase().Image2Bytes(ErpPanorama.Presentation.Properties.Resources.noImage);
            objE_Producto.Descuento = 0;
            objE_Producto.PrecioAB = 0;
            objE_Producto.PrecioCD = 0;
            objE_Producto.FlagCompuesto = false;
            objE_Producto.FlagEscala = true;
            objE_Producto.FlagDestacado = false;
            objE_Producto.FlagRecomendado = false;
            objE_Producto.FlagObsequio = false;
            objE_Producto.FlagNacional = true;
            objE_Producto.IdProductoArmado = null;
            objE_Producto.Observacion = "Creado por transformación de producto";
            objE_Producto.Fecha = Parametros.dtFechaHoraServidor;
            objE_Producto.IdTipoProducto = Parametros.intProductoAlmacenable;
            objE_Producto.IdSubTipoProducto = 0;
            objE_Producto.FlagEstado = true;
            objE_Producto.Usuario = Parametros.strUsuarioLogin;
            objE_Producto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            objE_Producto.IdEmpresa = Parametros.intEmpresaId;

            //Fotografías del producto
            ProductoFotoBE objE_ProductoFoto = null;
            //objE_ProductoFoto.IdProductoFoto = IdProductoFoto;
            //objE_ProductoFoto.IdProducto = IdProducto;
            //objE_ProductoFoto.Frontal = txtRutaFrontal.Text;
            //objE_ProductoFoto.Lateral = txtRutaLateral.Text;
            //objE_ProductoFoto.Trasera = txtRutaTrasera.Text;
            //objE_ProductoFoto.FlagEstado = true;
            //objE_ProductoFoto.Usuario = Parametros.strUsuarioLogin;
            //objE_ProductoFoto.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //objE_ProductoFoto.IdEmpresa = Parametros.intEmpresaId;

            //Producto Asociado
            List<ProductoAsociadoBE> lstProductoAsociado = new List<ProductoAsociadoBE>();

            //foreach (var item in mLista)
            //{
            //    ProductoAsociadoBE objE_ProductoAsociado = new ProductoAsociadoBE();
            //    objE_ProductoAsociado.IdProductoAsociado = item.IdProductoAsociado;
            //    objE_ProductoAsociado.IdProducto = item.IdProducto;
            //    objE_ProductoAsociado.CodigoProveedor = item.CodigoProveedor;
            //    objE_ProductoAsociado.NombreProducto = item.NombreProducto;
            //    objE_ProductoAsociado.Abreviatura = item.Abreviatura;
            //    objE_ProductoAsociado.Cantidad = item.Cantidad;
            //    objE_ProductoAsociado.Precio = item.Precio;
            //    objE_ProductoAsociado.IdProductoReferencia = item.IdProductoReferencia;
            //    objE_ProductoAsociado.FlagEstado = true;
            //    objE_ProductoAsociado.TipoOper = item.TipoOper;
            //    objE_ProductoAsociado.Usuario = Parametros.strUsuarioLogin;
            //    objE_ProductoAsociado.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
            //    lstProductoAsociado.Add(objE_ProductoAsociado);
            //}

            if (pOperacion == Operacion.Nuevo)
            {
                IdProducto = objBL_Producto.Inserta(objE_Producto, objE_ProductoFoto);
            }
            else
            {
                ////objE_ProductoFoto.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                //objBL_Producto.Actualiza(objE_Producto, objE_ProductoFoto);
            }

            return IdProducto;

        }

        private void ObtenerCorrelativo()
        {
            ProductoTransformacionBE objE_ProductoTransformacion = new ProductoTransformacionBE();
            objE_ProductoTransformacion = new ProductoTransformacionBL().SeleccionaProductoCorrelativo(Parametros.intTiendaId);

            txtCodigo.Text = objE_ProductoTransformacion.Codigo;
        }
        #endregion

        public class CProductoTransformacionDetalle
        {
            public Int32 IdProductoTransformacion { get; set; }
            public Int32 IdProductoTransformacionDetalle { get; set; }
            public Int32 IdProducto { get; set; }
            public String CodigoProveedor { get; set; }
            public String NombreProducto { get; set; }
            public String Abreviatura { get; set; }
            public Int32 Cantidad { get; set; }
            public Decimal Costo { get; set; }
            public Int32 TipoOper { get; set; }

            public CProductoTransformacionDetalle()
            {

            }
        }

        private void cboVendedor_EditValueChanged(object sender, EventArgs e)
        {
            //if (Convert.ToInt32(cboVendedor.EditValue) == 225)
            //{
            //    ProductoTransformacionBE ObjE_Producto = new ProductoTransformacionBE();
            //    ObjE_Producto = new ProductoTransformacionBL().SeleccionaProductoCorrelativo("PT-L");
            //    if (ObjE_Producto != null)
            //    txtCodigo.Text = "PT-L000" + ObjE_Producto.Codigo;//Completar de ceros
            //}else
            //    if (Convert.ToInt32(cboVendedor.EditValue) == 147)
            //{
            //    ProductoTransformacionBE ObjE_Producto = new ProductoTransformacionBE();
            //    ObjE_Producto = new ProductoTransformacionBL().SeleccionaProductoCorrelativo("PT-J");
            //        if(ObjE_Producto != null)
            //            txtCodigo.Text = "PT-J000" + ObjE_Producto.Codigo;//Completar de ceros
            //}else
            //        if (Convert.ToInt32(cboVendedor.EditValue) == 150)
            //{
            //    ProductoTransformacionBE ObjE_Producto = new ProductoTransformacionBE();
            //    ObjE_Producto = new ProductoTransformacionBL().SeleccionaProductoCorrelativo("PT-B");
            //    if (ObjE_Producto != null)
            //        txtCodigo.Text = "PT-B000" + ObjE_Producto.Codigo;//Completar de ceros
            //}


        }

        private void cboFamilia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboFamilia.EditValue != null)
            {
                BSUtils.LoaderLook(cboLinea, new LineaProductoBL().ListaTodosActivoFamilia(Parametros.intEmpresaId, Convert.ToInt32(cboFamilia.EditValue.ToString())), "DescLineaProducto", "IdLineaProducto", true);
            }
        }

        private void cboLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboSubLinea, new SubLineaProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString())), "DescSubLineaProducto", "IdSubLineaProducto", true);
            }
        }

        private void cboSubLinea_EditValueChanged(object sender, EventArgs e)
        {
            if (cboSubLinea.EditValue != null)
            {
                BSUtils.LoaderLook(cboModelo, new ModeloProductoBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToInt32(cboLinea.EditValue.ToString()), Convert.ToInt32(cboSubLinea.EditValue.ToString())), "DescModeloProducto", "IdModeloProducto", true);
            }
        }

        private void txtPrecioUnitario_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtTipoCambio.EditValue) > 0)
            {
                txtPrecioDolar.EditValue = Convert.ToDecimal(txtPrecioUnitario.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
            }
        }

        private void txtTipoCambio_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtTipoCambio.EditValue) > 0)
            {
                txtPrecioDolar.EditValue = Convert.ToDecimal(txtPrecioUnitario.EditValue) / Convert.ToDecimal(txtTipoCambio.EditValue);
            }
        }

        private void txtCosto_EditValueChanged(object sender, EventArgs e)
        {
            //txtPrecioUnitario.EditValue = Convert.ToDecimal(txtCosto.EditValue)*(1+(Convert.ToDecimal(txtMargen.EditValue)/100));
            txtPrecioUnitario.EditValue = Convert.ToDecimal(txtCosto.EditValue) / ((Convert.ToDecimal(txtMargen.EditValue) / 100));
        }

        private void txtMargen_EditValueChanged(object sender, EventArgs e)
        {
            //txtPrecioUnitario.EditValue = Convert.ToDecimal(txtCosto.EditValue) * (1 + (Convert.ToDecimal(txtMargen.EditValue) / 100));
            txtPrecioUnitario.EditValue = Convert.ToDecimal(txtCosto.EditValue) / ((Convert.ToDecimal(txtMargen.EditValue) / 100));
        }

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            //if (pOperacion == Operacion.Nuevo)
            if(IdProforma==0)
            { 
                frmRegProformaEdit frm = new frmRegProformaEdit();
                frm.pOperacion = frmRegProformaEdit.Operacion.Nuevo;
                frm.IdProforma = 0;
                frm.OrigenNuevo = 1;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    IdProforma = frm.IdProforma;
                    txtCosto.EditValue = frm.TotalProforma;
                }
            }
            else
            {
                frmRegProformaEdit frm = new frmRegProformaEdit();
                frm.IdProforma = IdProforma;
                frm.pOperacion = frmRegProformaEdit.Operacion.Modificar;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }

        }
    }
}