using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Reflection;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using ErpPanorama.Presentation.Utils;
using ErpPanorama.Presentation.Modulos.Ventas.Otros;
using ErpPanorama.Presentation.Modulos.Logistica.Otros;
using ErpPanorama.Presentation.Modulos.Contabilidad.Registros;
using ErpPanorama.BusinessEntity;
using ErpPanorama.BusinessLogic;

namespace ErpPanorama.Presentation.Modulos.Logistica.Registros
{
    public partial class frmRegHojaInstalacionEdit : DevExpress.XtraEditors.XtraForm
    {
        #region "Propiedades"

        private List<HojaInstalacionBE> mListaInstalacionReserva = new List<HojaInstalacionBE>();
        public List<HojaInstalacionBE> lstHojaInstalacion;
        public List<CHojaInstalacionDetalle> mListaHojaInstalacionDetalleOrigen = new List<CHojaInstalacionDetalle>();
        public List<PedidoDetalleBE> mListaPedidoDetalle = new List<PedidoDetalleBE>();
        public HojaInstalacionDetalleBE pHojaInstalacionDetallePedidoBE;
        public List<PedidoDetalleBE> mListaPedidoDetalleServicio = new List<PedidoDetalleBE>();

        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public Operacion pOperacion { get; set; }

        public HojaInstalacionBE pHojaInstalacionBE { get; set; }

        int _IdHojaInstalacion = 0;

        public int IdHojaInstalacion
        {
            get { return _IdHojaInstalacion; }
            set { _IdHojaInstalacion = value; }
        }

        public int IdCliente = 0;
        public string DescCliente = "";
        public string Direccion = "";
        public int Origen = 0;
        public int IdPedido = 0;

        #endregion

        #region "Eventos"

        public frmRegHojaInstalacionEdit()
        {
            InitializeComponent();
        }

        private void frmRegHojaInstalacionEdit_Load(object sender, EventArgs e)
        {
            BSUtils.LoaderLook(cboTurno, new TablaElementoBL().ListaTodosActivoPorTabla(Parametros.intEmpresaId, Parametros.intTblTurno), "DescTablaElemento", "IdTablaElemento", false);
            BSUtils.LoaderLook(cboDepartamento, new UbigeoBL().SeleccionaDepartamento(), "NomDpto", "IdDepartamento", false);
            cboDepartamento.EditValue = Parametros.sIdDepartamento;
            

            if (pOperacion == Operacion.Nuevo)
            {
                this.Text = "Hoja Instalación - Nuevo";

                //CargarReserva();
                //this.Size = new Size(1278, 598);

                //de Pedido
                if (Origen == 1)//Pedido
                {
                    CHojaInstalacionDetalle objE_HojaInstalacionDetalle = new CHojaInstalacionDetalle();
                    objE_HojaInstalacionDetalle.IdHojaInstalacion = 0;
                    objE_HojaInstalacionDetalle.IdHojaInstalacionDetalle = 0;
                    objE_HojaInstalacionDetalle.IdPedido = pHojaInstalacionDetallePedidoBE.IdPedido;
                    IdPedido = pHojaInstalacionDetallePedidoBE.IdPedido;
                    objE_HojaInstalacionDetalle.NumeroPedido = pHojaInstalacionDetallePedidoBE.NumeroPedido;
                    objE_HojaInstalacionDetalle.Total = pHojaInstalacionDetallePedidoBE.Total;
                    objE_HojaInstalacionDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo);
                    mListaHojaInstalacionDetalleOrigen.Add(objE_HojaInstalacionDetalle);

                    bsListadoPedido.DataSource = mListaHojaInstalacionDetalleOrigen;
                    gcHojaInstalacionDetalle.DataSource = bsListadoPedido;
                    gcHojaInstalacionDetalle.RefreshDataSource();

                    txtDescCliente.Text = DescCliente;
                    txtDireccion.Text = Direccion;
                    txtTotal.EditValue = pHojaInstalacionDetallePedidoBE.Total;
                }
                cboDistrito.EditValue = 0;
            }
            else if (pOperacion == Operacion.Modificar)
            {
                this.Text = "Hoja Instalación - Modificar";

                string IdDepartamento = string.Empty;
                string IdProvincia = string.Empty;
                string IdDistrito = string.Empty;

                HojaInstalacionBE objE_Hoja = new HojaInstalacionBE();
                objE_Hoja = new HojaInstalacionBL().Selecciona(IdHojaInstalacion);

                //IdHojaInstalacion = objE_Hoja.IdHojaInstalacion;
                deFecha.EditValue = objE_Hoja.Fecha;
                cboTurno.EditValue = objE_Hoja.IdTurno;
                IdCliente = objE_Hoja.IdCliente;
                txtDescCliente.Text = objE_Hoja.DescCliente;
                txtDireccion.Text = objE_Hoja.Direccion;
                txtReferencia.Text = objE_Hoja.Referencia;
                txtObservacion.Text = objE_Hoja.Observacion;
                //cboDepartamento.EditValue

                if (objE_Hoja.IdUbigeo.Trim() != "")
                    IdDepartamento = objE_Hoja.IdUbigeo.Substring(0, 2);
                cboDepartamento.EditValue = IdDepartamento;
                if (objE_Hoja.IdUbigeo.Trim() != "")
                    IdProvincia = objE_Hoja.IdUbigeo.Substring(2, 2);
                cboProvincia.EditValue = IdProvincia;
                if (objE_Hoja.IdUbigeo.Trim() != "")
                    IdDistrito = objE_Hoja.IdUbigeo.Substring(4, 2);
                cboDistrito.EditValue = IdDistrito;

                //cboTienda.EditValue = pHojaInstalacionBE.IdTienda;
                //cboAlmacen.EditValue = pHojaInstalacionBE.IdAlmacen;
                //txtDescripcion.Text = pHojaInstalacionBE.DescHojaInstalacion;
            }

            CargaHojaInstalacionDetalle();
            CargarPedidoDetalle();
            CargarPedidoDetalleServicio();
            CargarReserva();

            CalculaTotales();

            if (Origen == 1)
            {
                //Permisos Sólo para álmacen.
                toolStripSeparator1.Visible = false;
                asignapersonatoolStripMenuItem.Visible = false;
                eliminarpersonaToolStripMenuItem.Visible = false;
            }


                txtObservacion.Select();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                ValidarSabadoTarde();
                //Validar Feriados

                Cursor = Cursors.WaitCursor;
                if (!ValidarIngreso())
                {
                    HojaInstalacionBL objBL_HojaInstalacion = new HojaInstalacionBL();
                    HojaInstalacionBE objHojaInstalacion = new HojaInstalacionBE();
                    //objHojaInstalacion.IdAlmacen = Convert.ToInt32(cboAlmacen.EditValue);
                    objHojaInstalacion.IdHojaInstalacion = IdHojaInstalacion;
                    objHojaInstalacion.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    objHojaInstalacion.IdTurno = Convert.ToInt32(cboTurno.EditValue);
                    objHojaInstalacion.IdCliente = IdCliente;
                    objHojaInstalacion.IdUbigeo = cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString();
                    objHojaInstalacion.Direccion = txtDireccion.Text;
                    objHojaInstalacion.Referencia = txtReferencia.Text;
                    objHojaInstalacion.Observacion = txtObservacion.Text;
                    objHojaInstalacion.FlagReserva = true;
                    objHojaInstalacion.FlagEstado = true;
                    objHojaInstalacion.Usuario = Parametros.strUsuarioLogin;
                    objHojaInstalacion.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                    objHojaInstalacion.IdEmpresa = Parametros.intEmpresaId;

                    //DescuentoClientePromocion Detalle
                    List<HojaInstalacionDetalleBE> lstHojaInstalacionDetalle = new List<HojaInstalacionDetalleBE>();

                    foreach (var item in mListaHojaInstalacionDetalleOrigen)
                    {
                        HojaInstalacionDetalleBE objE_HojaInstalacionDetalle = new HojaInstalacionDetalleBE();
                        objE_HojaInstalacionDetalle.IdHojaInstalacion = item.IdHojaInstalacion;
                        objE_HojaInstalacionDetalle.IdHojaInstalacionDetalle = item.IdHojaInstalacionDetalle;
                        objE_HojaInstalacionDetalle.IdPedido = item.IdPedido;
                        objE_HojaInstalacionDetalle.NumeroPedido = item.NumeroPedido;
                        objE_HojaInstalacionDetalle.FlagEstado = true;
                        objE_HojaInstalacionDetalle.TipoOper = item.TipoOper;
                        objE_HojaInstalacionDetalle.Usuario = Parametros.strUsuarioLogin;
                        objE_HojaInstalacionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();
                        lstHojaInstalacionDetalle.Add(objE_HojaInstalacionDetalle);
                    }

                    if (pOperacion == Operacion.Nuevo)
                        objBL_HojaInstalacion.Inserta(objHojaInstalacion, lstHojaInstalacionDetalle);
                    else
                        objBL_HojaInstalacion.Actualiza(objHojaInstalacion, lstHojaInstalacionDetalle);

                    Cursor = Cursors.Default;

                    XtraMessageBox.Show("El servicio se realizará en el distrito de " + cboDistrito.Text ,this.Text);

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

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamento.EditValue != null)
            {
                BSUtils.LoaderLook(cboProvincia, new UbigeoBL().SeleccionaProvincia(cboDepartamento.EditValue.ToString()), "NomProv", "IdProvincia", false);
                cboProvincia.EditValue = Parametros.sIdProvincia;
            }
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProvincia.EditValue != null)
            {
                BSUtils.LoaderLook(cboDistrito, new UbigeoBL().SeleccionaDistrito(cboDepartamento.EditValue.ToString(), cboProvincia.EditValue.ToString()), "NomDist", "IdDistrito", false);
                cboDistrito.EditValue = Parametros.sIdDistrito;
            }

        }

        private void cboDistrito_EditValueChanged(object sender, EventArgs e)
        {
            //if (cboDistrito.EditValue != null)
            //{
            //    //UbigeoBE objE_Ubigeo = null;
            //    //objE_Ubigeo = new UbigeoBL().Selecciona(cboDepartamento.EditValue.ToString() + cboProvincia.EditValue.ToString() + cboDistrito.EditValue.ToString());

            //    ListaPrecioDeliveryBE objE_ListaPrecioDelivery = null;
            //    objE_ListaPrecioDelivery = new ListaPrecioDeliveryBL().Selecciona(Convert.ToInt32(cboDistrito.EditValue));
            //    txtTotal.EditValue = objE_ListaPrecioDelivery.TarifaEnvio;
            //    cboDistrito.Select();
            //}

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
                    //txtNumeroDocumento.Text = frm.pClienteBE.NumeroDocumento;
                    txtDescCliente.Text = frm.pClienteBE.DescCliente;
                    txtDireccion.Text = frm.pClienteBE.AbrevDomicilio + " " + frm.pClienteBE.Direccion;
                    //IdTipoCliente = frm.pClienteBE.IdTipoCliente;
                    //IdClasificacionCliente = frm.pClienteBE.IdClasificacionCliente;
                }
            }

            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkCallao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCallao.Checked == true)
            {
                cboDepartamento.Enabled = true;
                cboProvincia.Enabled = true;
                cboDepartamento.EditValue = "07";//Callao
            }
            else
            {
                cboDepartamento.Enabled = false;
                cboProvincia.Enabled = false;
                cboDepartamento.EditValue = Parametros.sIdDepartamento;//Lima
            }
        }


        private void asignapersonatoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvPedidoDetalleInstalacion.RowCount > 0)
            {
                frmRegAsignarPersona frm = new frmRegAsignarPersona();
                frm.IdPedidoDetalle = int.Parse(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdPedidoDetalle").ToString());
                frm.Origen = 1;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                CargarPedidoDetalleServicio();
            }

        }

        private void eliminarpersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gvPedidoDetalleInstalacion.RowCount > 0)
            {
                PedidoDetalleBL objBL_PedidoDetalle = new PedidoDetalleBL();
                objBL_PedidoDetalle.ActualizaPersonaServicio(int.Parse(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdPedidoDetalle").ToString()), 0);
                CargarPedidoDetalleServicio();
            }
        }

        private void nuevopedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmBusPedido movDetalle = new frmBusPedido();
                movDetalle.StartPosition = FormStartPosition.CenterParent;
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.pPedidoBE != null)
                    {
                        if (movDetalle.pPedidoBE.IdSituacion == Parametros.intPVAnulado)
                        {
                            XtraMessageBox.Show("No se puede agregar un pedido Anulado.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        //Verficar Pedido existente
                        HojaInstalacionDetalleBE ObjE_Hoja = null;
                        ObjE_Hoja = new HojaInstalacionDetalleBL().SeleccionaPedido(movDetalle.pPedidoBE.IdPedido);
                        if(ObjE_Hoja!=null)
                        {
                            string mensajeInstalacion = "";
                            if (ObjE_Hoja.Fecha > DateTime.Now)
                                mensajeInstalacion = "se instalará el ";
                            else
                                mensajeInstalacion = "fue instalado el ";
                            XtraMessageBox.Show("El pedido " + mensajeInstalacion + "día " + ObjE_Hoja.Fecha.ToShortDateString().ToString(),this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        if (mListaHojaInstalacionDetalleOrigen.Count == 0)
                        {
                            gvHojaInstalacionDetalle.AddNewRow();
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "IdHojaInstalacionDetalle", 0);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "IdHojaInstalacion", IdHojaInstalacion);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "IdPedido", movDetalle.pPedidoBE.IdPedido);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "NumeroPedido", movDetalle.pPedidoBE.Numero);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "IdSituacion", movDetalle.pPedidoBE.IdSituacion);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "DescSituacion", movDetalle.pPedidoBE.DescSituacion);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "Total", movDetalle.pPedidoBE.Total);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvHojaInstalacionDetalle.UpdateCurrentRow();

                            CalculaTotales();

                            return;

                        }
                        if (mListaHojaInstalacionDetalleOrigen.Count > 0)
                        {
                            var Buscar = mListaHojaInstalacionDetalleOrigen.Where(oB => oB.IdPedido == movDetalle.pPedidoBE.IdPedido).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El Pedido ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            gvHojaInstalacionDetalle.AddNewRow();
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "IdHojaInstalacionDetalle", 0);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "IdHojaInstalacion", IdHojaInstalacion);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "IdPedido", movDetalle.pPedidoBE.IdPedido);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "NumeroPedido", movDetalle.pPedidoBE.Numero);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "IdSituacion", movDetalle.pPedidoBE.IdSituacion);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "DescSituacion", movDetalle.pPedidoBE.DescSituacion);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "Total", movDetalle.pPedidoBE.Total);
                            gvHojaInstalacionDetalle.SetRowCellValue(gvHojaInstalacionDetalle.FocusedRowHandle, "TipoOper", Convert.ToInt32(Operacion.Nuevo));
                            gvHojaInstalacionDetalle.UpdateCurrentRow();

                            CalculaTotales();

                        }

                        //Grabar Detalle
                        CargaPedidoDetalleManual(movDetalle.pPedidoBE.IdPedido);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void eliminarpedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int IdHojaInstalacionDetalle = 0;
                IdHojaInstalacionDetalle = int.Parse(gvHojaInstalacionDetalle.GetFocusedRowCellValue("IdHojaInstalacionDetalle").ToString());
                HojaInstalacionDetalleBE objBE_HojaInstalacionDetalle = new HojaInstalacionDetalleBE();
                objBE_HojaInstalacionDetalle.IdHojaInstalacionDetalle = IdHojaInstalacionDetalle;
                objBE_HojaInstalacionDetalle.IdEmpresa = Parametros.intEmpresaId;
                objBE_HojaInstalacionDetalle.Usuario = Parametros.strUsuarioLogin;
                objBE_HojaInstalacionDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                HojaInstalacionDetalleBL objBL_HojaInstalacionDetalle = new HojaInstalacionDetalleBL();
                objBL_HojaInstalacionDetalle.Elimina(objBE_HojaInstalacionDetalle);
                gvHojaInstalacionDetalle.DeleteRow(gvHojaInstalacionDetalle.FocusedRowHandle);
                gvHojaInstalacionDetalle.RefreshData();

                CalculaTotales();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void deFecha_EditValueChanged(object sender, EventArgs e)
        {
            ValidarSabadoTarde();
        }

        private void cboTurno_EditValueChanged(object sender, EventArgs e)
        {
            ValidarSabadoTarde();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (IdCliente == 0)
                {
                    XtraMessageBox.Show("Seleccionar un cliente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (IdPedido == 0)
                {
                    XtraMessageBox.Show("No se puede ingresar por esta opción, solo está disponible desde Pedido de Ventas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ////Total Mayor a 7500
                //decimal decPrecio = 0;

                frmRegVentaDetalle movDetalle = new frmRegVentaDetalle();
                movDetalle.IdTipoCliente = Parametros.intTipClienteFinal; //IdTipoCliente;
                movDetalle.IdClasificacionCliente = Parametros.intClasico;//IdClasificacionCliente;
                movDetalle.IdMoneda = Parametros.intSoles; //Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.IdEmpresa = Parametros.intEmpresaId; //Convert.ToInt32(cboEmpresa.EditValue);
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    if (movDetalle.oBE != null)
                    {
                        if (mListaPedidoDetalleServicio.Count == 0)
                        {
                            PedidoDetalleBL objBL_PedidoDetalle = new PedidoDetalleBL();
                            PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                            objE_PedidoDetalle.IdEmpresa = movDetalle.oBE.IdEmpresa;
                            objE_PedidoDetalle.IdPedido = IdPedido;
                            objE_PedidoDetalle.IdPedidoDetalle = 0;
                            objE_PedidoDetalle.Item = 0;
                            objE_PedidoDetalle.IdProducto = movDetalle.oBE.IdProducto;
                            objE_PedidoDetalle.CodigoProveedor = movDetalle.oBE.CodigoProveedor;
                            objE_PedidoDetalle.NombreProducto = movDetalle.oBE.NombreProducto;
                            objE_PedidoDetalle.Abreviatura = movDetalle.oBE.Abreviatura;
                            objE_PedidoDetalle.Cantidad = movDetalle.oBE.Cantidad;
                            objE_PedidoDetalle.CantidadAnt = movDetalle.oBE.CantidadAnt;

                            if (Convert.ToDecimal(txtTotal.EditValue) >= 7500)
                            {
                                objE_PedidoDetalle.PrecioUnitario = 0;
                                objE_PedidoDetalle.PorcentajeDescuento = 0;
                                objE_PedidoDetalle.Descuento = 0;
                                objE_PedidoDetalle.PrecioVenta = 0;
                                objE_PedidoDetalle.ValorVenta = 0;
                            }
                            else
                            {
                                objE_PedidoDetalle.PrecioUnitario = movDetalle.oBE.PrecioUnitario;
                                objE_PedidoDetalle.PorcentajeDescuento = movDetalle.oBE.PorcentajeDescuento;
                                objE_PedidoDetalle.Descuento = movDetalle.oBE.Descuento;
                                objE_PedidoDetalle.PrecioVenta = movDetalle.oBE.PrecioUnitario;
                                objE_PedidoDetalle.ValorVenta = movDetalle.oBE.ValorVenta;
                            }

                            objE_PedidoDetalle.Observacion = "Servicio de Instalación";
                            objE_PedidoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                            objE_PedidoDetalle.IdKardex = movDetalle.oBE.IdKardex;
                            objE_PedidoDetalle.IdAlmacen = movDetalle.oBE.IdAlmacen;
                            objE_PedidoDetalle.FlagMuestra = false;
                            objE_PedidoDetalle.FlagRegalo = false;
                            objE_PedidoDetalle.FlagBultoCerrado = false;
                            objE_PedidoDetalle.IdPromocion = 0;
                            objE_PedidoDetalle.DescPromocion = "";
                            objE_PedidoDetalle.FlagEstado = true;
                            objE_PedidoDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo); //movDetalle.oBE.TipoOper;



                            objBL_PedidoDetalle.Inserta(objE_PedidoDetalle);

                            //CargarPedidoDetalle();
                            CargarPedidoDetalleServicio();

                            return;

                        }
                        if (mListaPedidoDetalleServicio.Count > 0)
                        {
                            var Buscar = mListaPedidoDetalleServicio.Where(oB => oB.IdProducto == movDetalle.oBE.IdProducto).ToList();
                            if (Buscar.Count > 0)
                            {
                                XtraMessageBox.Show("El código de producto ya existe", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            PedidoDetalleBL objBL_PedidoDetalle = new PedidoDetalleBL();
                            PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                            objE_PedidoDetalle.IdEmpresa = movDetalle.oBE.IdEmpresa;
                            objE_PedidoDetalle.IdPedido = IdPedido;
                            objE_PedidoDetalle.IdPedidoDetalle = 0;
                            objE_PedidoDetalle.Item = 0;
                            objE_PedidoDetalle.IdProducto = movDetalle.oBE.IdProducto;
                            objE_PedidoDetalle.CodigoProveedor = movDetalle.oBE.CodigoProveedor;
                            objE_PedidoDetalle.NombreProducto = movDetalle.oBE.NombreProducto;
                            objE_PedidoDetalle.Abreviatura = movDetalle.oBE.Abreviatura;
                            objE_PedidoDetalle.Cantidad = movDetalle.oBE.Cantidad;
                            objE_PedidoDetalle.CantidadAnt = movDetalle.oBE.CantidadAnt;
                            if (Convert.ToDecimal(txtTotal.EditValue) >= 7500)
                            {
                                objE_PedidoDetalle.PrecioUnitario = 0;
                                objE_PedidoDetalle.PorcentajeDescuento = 0;
                                objE_PedidoDetalle.Descuento = 0;
                                objE_PedidoDetalle.PrecioVenta = 0;
                                objE_PedidoDetalle.ValorVenta = 0;
                            }
                            else
                            {
                                objE_PedidoDetalle.PrecioUnitario = movDetalle.oBE.PrecioUnitario;
                                objE_PedidoDetalle.PorcentajeDescuento = movDetalle.oBE.PorcentajeDescuento;
                                objE_PedidoDetalle.Descuento = movDetalle.oBE.Descuento;
                                objE_PedidoDetalle.PrecioVenta = movDetalle.oBE.PrecioUnitario;
                                objE_PedidoDetalle.ValorVenta = movDetalle.oBE.ValorVenta;
                            }
                            objE_PedidoDetalle.Observacion = "Servicio de Instalación";
                            objE_PedidoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                            objE_PedidoDetalle.IdKardex = movDetalle.oBE.IdKardex;
                            objE_PedidoDetalle.IdAlmacen = movDetalle.oBE.IdAlmacen;
                            objE_PedidoDetalle.FlagMuestra = false;
                            objE_PedidoDetalle.FlagRegalo = false;
                            objE_PedidoDetalle.FlagBultoCerrado = false;
                            objE_PedidoDetalle.IdPromocion = 0;
                            objE_PedidoDetalle.DescPromocion = "";
                            objE_PedidoDetalle.FlagEstado = true;
                            objE_PedidoDetalle.TipoOper = Convert.ToInt32(Operacion.Nuevo); //movDetalle.oBE.TipoOper;

                            objBL_PedidoDetalle.Inserta(objE_PedidoDetalle);
                            //CargarPedidoDetalle();
                            CargarPedidoDetalleServicio();
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
            if (mListaPedidoDetalleServicio.Count > 0)
            {
                int IdPedidoDetalle = 0;
                int xposition = 0;

                frmRegVentaDetalle movDetalle = new frmRegVentaDetalle();
                movDetalle.IdEmpresa = Parametros.intEmpresaId; //Convert.ToInt32(cboEmpresa.EditValue);
                movDetalle.IdTipoCliente = Parametros.intTipClienteFinal;//IdTipoCliente;
                movDetalle.IdClasificacionCliente = Parametros.intClasico;//IdClasificacionCliente;
                movDetalle.IdMoneda = Parametros.intSoles;//Convert.ToInt32(cboMoneda.EditValue);
                movDetalle.IdPedido = Convert.ToInt32(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdPedido"));
                movDetalle.IdPedidoDetalle = Convert.ToInt32(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdPedidoDetalle"));
                IdPedidoDetalle = Convert.ToInt32(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdPedidoDetalle")); ;
                movDetalle.intCorrelativo = Convert.ToInt32(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("Item"));
                movDetalle.IdProducto = Convert.ToInt32(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdProducto"));
                movDetalle.IdLineaProducto = Convert.ToInt32(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdLineaProducto"));
                movDetalle.txtCodigo.Text = gvPedidoDetalleInstalacion.GetFocusedRowCellValue("CodigoProveedor").ToString();
                movDetalle.txtProducto.Text = gvPedidoDetalleInstalacion.GetFocusedRowCellValue("NombreProducto").ToString();
                movDetalle.txtUM.Text = gvPedidoDetalleInstalacion.GetFocusedRowCellValue("Abreviatura").ToString();
                movDetalle.txtCantidad.EditValue = Convert.ToInt32(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("Cantidad"));
                movDetalle.txtPrecioUnitario.EditValue = Convert.ToDecimal(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("PrecioUnitario"));
                movDetalle.txtDescuento.EditValue = Convert.ToDecimal(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("PorcentajeDescuento"));
                movDetalle.txtPrecioVenta.EditValue = Convert.ToDecimal(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("PrecioVenta"));
                movDetalle.txtValorVenta.EditValue = Convert.ToDecimal(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("ValorVenta"));
                movDetalle.chkMuestra.EditValue = Convert.ToBoolean(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("FlagMuestra"));
                movDetalle.IdKardex = Convert.ToInt32(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdKardex"));
                movDetalle.PorcentajeDescuentoInicial = Convert.ToDecimal(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("PorcentajeDescuentoInicial"));
                if (movDetalle.ShowDialog() == DialogResult.OK)
                {
                    xposition = gvPedidoDetalleInstalacion.FocusedRowHandle;

                    if (movDetalle.oBE != null)
                    {

                        PedidoDetalleBL objBL_PedidoDetalle = new PedidoDetalleBL();
                        PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                        objE_PedidoDetalle.IdEmpresa = movDetalle.oBE.IdEmpresa;
                        objE_PedidoDetalle.IdPedido = IdPedido;
                        objE_PedidoDetalle.IdPedidoDetalle = IdPedidoDetalle;
                        objE_PedidoDetalle.Item = 0;
                        objE_PedidoDetalle.IdProducto = movDetalle.oBE.IdProducto;
                        objE_PedidoDetalle.CodigoProveedor = movDetalle.oBE.CodigoProveedor;
                        objE_PedidoDetalle.NombreProducto = movDetalle.oBE.NombreProducto;
                        objE_PedidoDetalle.Abreviatura = movDetalle.oBE.Abreviatura;
                        objE_PedidoDetalle.Cantidad = movDetalle.oBE.Cantidad;
                        objE_PedidoDetalle.CantidadAnt = movDetalle.oBE.CantidadAnt;
                        objE_PedidoDetalle.PrecioUnitario = movDetalle.oBE.PrecioUnitario;
                        objE_PedidoDetalle.PorcentajeDescuento = movDetalle.oBE.PorcentajeDescuento;
                        objE_PedidoDetalle.Descuento = movDetalle.oBE.Descuento;
                        objE_PedidoDetalle.PrecioVenta = movDetalle.oBE.PrecioUnitario;
                        objE_PedidoDetalle.ValorVenta = movDetalle.oBE.ValorVenta;
                        objE_PedidoDetalle.Observacion = "Servicio de Instalación";
                        objE_PedidoDetalle.CodAfeIGV = Parametros.strGravadoOnerosa;
                        objE_PedidoDetalle.IdKardex = movDetalle.oBE.IdKardex;
                        objE_PedidoDetalle.IdAlmacen = movDetalle.oBE.IdAlmacen;
                        objE_PedidoDetalle.FlagMuestra = false;
                        objE_PedidoDetalle.FlagRegalo = false;
                        objE_PedidoDetalle.FlagBultoCerrado = false;
                        objE_PedidoDetalle.IdPromocion = 0;
                        objE_PedidoDetalle.DescPromocion = "";
                        objE_PedidoDetalle.FlagEstado = true;
                        objE_PedidoDetalle.TipoOper = Convert.ToInt32(Operacion.Modificar); //movDetalle.oBE.TipoOper;

                        objBL_PedidoDetalle.Actualiza(objE_PedidoDetalle);
                        //CargarPedidoDetalle();
                        CargarPedidoDetalleServicio();

                    }
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPedidoDetalleInstalacion.RowCount > 0)
                {
                    int IdPedidoDetalle = 0;
                    if (gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdPedidoDetalle") != null)
                        IdPedidoDetalle = int.Parse(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdPedidoDetalle").ToString());
                    PedidoDetalleBE objBE_PedidoDetalle = new PedidoDetalleBE();
                    objBE_PedidoDetalle.IdPedidoDetalle = IdPedidoDetalle;
                    objBE_PedidoDetalle.IdEmpresa = Parametros.intEmpresaId;
                    objBE_PedidoDetalle.IdTienda = Parametros.intTiendaId;
                    objBE_PedidoDetalle.Periodo = Parametros.intPeriodo;
                    objBE_PedidoDetalle.Numero = "";// txtNumero.Text;
                    objBE_PedidoDetalle.Fecha = Convert.ToDateTime(deFecha.DateTime.ToShortDateString());
                    //objBE_PedidoDetalle.IdTipoDocumento = Convert.ToInt32(cboDocumento.EditValue);
                    //objBE_PedidoDetalle.IdFormaPago = Convert.ToInt32(cboFormaPago.EditValue);
                    objBE_PedidoDetalle.IdProducto = int.Parse(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdProducto").ToString());
                    objBE_PedidoDetalle.Cantidad = int.Parse(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("Cantidad").ToString());
                    //objBE_PedidoDetalle.IdAlmacen = int.Parse(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdAlmacen").ToString());
                    objBE_PedidoDetalle.IdAlmacen = gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdAlmacen") == null ? (Int32?)null : int.Parse(gvPedidoDetalleInstalacion.GetFocusedRowCellValue("IdAlmacen").ToString());//Almacen
                    objBE_PedidoDetalle.FlagPreventa = false;
                    objBE_PedidoDetalle.Usuario = Parametros.strUsuarioLogin;
                    objBE_PedidoDetalle.Maquina = WindowsIdentity.GetCurrent().Name.ToString();

                    PedidoDetalleBL objBL_PedidoDetalle = new PedidoDetalleBL();
                    objBL_PedidoDetalle.Elimina(objBE_PedidoDetalle);
                    gvPedidoDetalleInstalacion.DeleteRow(gvPedidoDetalleInstalacion.FocusedRowHandle);
                    gvPedidoDetalleInstalacion.RefreshData();

                    //CargarPedidoDetalle();
                    CargarPedidoDetalleServicio();
                    CalculaTotales();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cargarserviciosugeridotoolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Metodos"
        private void CargarPedidoDetalle()
        {
            if (Origen == 1 && pOperacion == Operacion.Nuevo)
            {
                mListaPedidoDetalle = new PedidoDetalleBL().ListaTodosActivoInstalacionPedido(IdPedido,0);
                gcPedidoDetalle.DataSource = mListaPedidoDetalle;
            }
            else
            {
                mListaPedidoDetalle = new PedidoDetalleBL().ListaTodosActivoInstalacion(IdHojaInstalacion, 0);
                gcPedidoDetalle.DataSource = mListaPedidoDetalle;
            }
        }

        private void CargarPedidoDetalleServicio()
        {
            if (Origen == 1 && pOperacion == Operacion.Nuevo)
            {
                mListaPedidoDetalleServicio = new PedidoDetalleBL().ListaTodosActivoInstalacionPedido(IdPedido,1);
                gcPedidoDetalleInstalacion.DataSource = mListaPedidoDetalleServicio;
            }
            else
            {
                mListaPedidoDetalleServicio = new PedidoDetalleBL().ListaTodosActivoInstalacion(IdHojaInstalacion, 1);
                gcPedidoDetalleInstalacion.DataSource = mListaPedidoDetalleServicio;
            }
        }

        private void CalculaTotales()
        {
            try
            {
                decimal decTotal = 0;

                for (int i = 0; i < gvHojaInstalacionDetalle.RowCount; i++)
                {
                    if (Convert.ToInt32(gvHojaInstalacionDetalle.GetRowCellValue(i, (gvHojaInstalacionDetalle.Columns["IdSituacion"]))) != Parametros.intPVAnulado)
                    {
                        decTotal = decTotal + Convert.ToDecimal(gvHojaInstalacionDetalle.GetRowCellValue(i, (gvHojaInstalacionDetalle.Columns["Total"])));
                    }
                }
                txtTotal.EditValue = decTotal;

                if (decTotal >= 7500)
                {
                    lblMensaje.Text = "Se realizarán las instalaciones para este servicio completamente GRATIS! *** (Supera los S/7500)";
                    lblMensaje.ForeColor = Color.Blue;
                }
                    
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargaHojaInstalacionDetalle()
        {
            List<HojaInstalacionDetalleBE> lstTmpHojaInstalacionDetalle = null;
            lstTmpHojaInstalacionDetalle = new HojaInstalacionDetalleBL().ListaTodosActivo(IdHojaInstalacion);

            foreach (HojaInstalacionDetalleBE item in lstTmpHojaInstalacionDetalle)
            {
                CHojaInstalacionDetalle objE_HojaInstalacionDetalle = new CHojaInstalacionDetalle();
                objE_HojaInstalacionDetalle.IdHojaInstalacion = item.IdHojaInstalacion;
                objE_HojaInstalacionDetalle.IdHojaInstalacionDetalle = item.IdHojaInstalacionDetalle;
                objE_HojaInstalacionDetalle.IdPedido = item.IdPedido;
                objE_HojaInstalacionDetalle.NumeroPedido = item.NumeroPedido;
                objE_HojaInstalacionDetalle.IdSituacion = item.IdSituacion;
                objE_HojaInstalacionDetalle.DescSituacion = item.DescSituacion;
                objE_HojaInstalacionDetalle.Total = item.Total;
                objE_HojaInstalacionDetalle.TipoOper = item.TipoOper;
                mListaHojaInstalacionDetalleOrigen.Add(objE_HojaInstalacionDetalle);
            }

            bsListadoPedido.DataSource = mListaHojaInstalacionDetalleOrigen;
            gcHojaInstalacionDetalle.DataSource = bsListadoPedido;
            gcHojaInstalacionDetalle.RefreshDataSource();

            //CalculaTotales();
        }

        private void CargarReserva()
        {
            //grpReservaSemanal.Visible = true;
            mListaInstalacionReserva = new HojaInstalacionBL().ListaTodosActivo(Parametros.intEmpresaId, Convert.ToDateTime(DateTime.Now), Convert.ToDateTime(DateTime.Now.AddDays(15)));
            gcReserva.DataSource = mListaInstalacionReserva;
        }

        private bool ValidarIngreso()
        {
            bool flag = false;
            string strMensaje = "No se pudo registrar:\n";

            if (string.IsNullOrEmpty(cboTurno.Text))
            {
                strMensaje = strMensaje + "- Seleccionar un Turno.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(deFecha.Text))
            {
                strMensaje = strMensaje + "- Seleccionar una Fecha.\n";
                flag = true;
            }

            if (string.IsNullOrEmpty(cboDistrito.Text))
            {
                strMensaje = strMensaje + "- Seleccionar Distrito.\n";
                flag = true;
            }

            if (txtDireccion.Text.Trim().ToString() == "")
            {
                strMensaje = strMensaje + "- Ingrese la Dirección.\n";
                flag = true;
            }

            if (IdCliente ==0)
            {
                strMensaje = strMensaje + "- Ingrese el Cliente.\n";
                flag = true;
            }

            //if (mListaPedidoDetalle.Count == 0)
            //{
            //    strMensaje = strMensaje + "- Agregar pedidos asociados a este servicio.\n-Pedido Debe tener por lo menos un código que sea producto y no servicio.\n";
            //    flag = true;
            //}

            //if (mListaPedidoDetalleServicio.Count == 0 && Parametros.intPerfilId != Parametros.intPerAdministrador)
            //{
            //    strMensaje = strMensaje + "- Agregar servicios de instalación.\n";
            //    flag = true;
            //}

            if (pOperacion == Operacion.Nuevo)
            {
                HojaInstalacionBE objE_Hoja = null;
                objE_Hoja = new HojaInstalacionBL().SeleccionaFechaTurno(Convert.ToInt32(cboTurno.EditValue), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

                if (objE_Hoja != null)
                {
                    strMensaje = strMensaje + "- La Fecha y el turno ya existe.\n";
                    flag = true;
                }
            }
            else
            {
                HojaInstalacionBE objE_HojaAct = null;
                objE_HojaAct = new HojaInstalacionBL().Selecciona(IdHojaInstalacion);
                if(objE_HojaAct != null)
                {
                    if(objE_HojaAct.Fecha != deFecha.DateTime || objE_HojaAct.IdTurno != Convert.ToInt32(cboTurno.EditValue))
                    {
                        HojaInstalacionBE objE_Hoja = null;
                        objE_Hoja = new HojaInstalacionBL().SeleccionaFechaTurno(Convert.ToInt32(cboTurno.EditValue), Convert.ToDateTime(deFecha.DateTime.ToShortDateString()));

                        if (objE_Hoja != null)
                        {
                            strMensaje = strMensaje + "- La Fecha y el turno ya existe.\n";
                            flag = true;
                        }
                    }
                }
            }

            if (flag)
            {
                XtraMessageBox.Show(strMensaje, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Cursor = Cursors.Default;
            }
            return flag;
        }

        private void ValidarSabadoTarde()
        {
            //if (Convert.ToInt32(deFecha.DateTime.DayOfWeek) == 6 && Convert.ToInt32(cboTurno.EditValue) == 17 && Origen ==1)
            //{
            //    XtraMessageBox.Show("No se puede reservar Sábado por la Tarde.\nConsulte con el centro de distribución.", this.Text);
            //    return;
            //}

            if (Convert.ToInt32(deFecha.DateTime.DayOfWeek) == 7 && Origen == 1)
            {
                XtraMessageBox.Show("No se puede reservar Domingo, Ud debe seleccionar un día hábil y disponible para el servicio.\nConsulte con el centro de distribución.", this.Text);
                return; 
            }

        }

        private void CargaPedidoDetalleManual(int IdPedidoManual)
        {
            List<PedidoDetalleBE> lstTmpPedidoDetalle = null;
            lstTmpPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedidoManual);

            foreach (PedidoDetalleBE item in lstTmpPedidoDetalle)
            {
                PedidoDetalleBE objE_PedidoDetalle = new PedidoDetalleBE();
                objE_PedidoDetalle.IdEmpresa = item.IdEmpresa;
                objE_PedidoDetalle.IdPedido = item.IdPedido;
                objE_PedidoDetalle.IdPedidoDetalle = item.IdPedidoDetalle;
                objE_PedidoDetalle.Item = item.Item;
                objE_PedidoDetalle.IdProducto = item.IdProducto;
                objE_PedidoDetalle.CodigoProveedor = item.CodigoProveedor;
                objE_PedidoDetalle.NombreProducto = item.NombreProducto;
                objE_PedidoDetalle.Abreviatura = item.Abreviatura;
                objE_PedidoDetalle.Cantidad = item.Cantidad;
                objE_PedidoDetalle.CantidadAnt = item.CantidadAnt;
                objE_PedidoDetalle.PrecioUnitario = item.PrecioUnitario;
                objE_PedidoDetalle.PorcentajeDescuento = item.PorcentajeDescuento;
                objE_PedidoDetalle.Descuento = item.Descuento;
                objE_PedidoDetalle.PrecioVenta = item.PrecioVenta;
                objE_PedidoDetalle.ValorVenta = item.ValorVenta;
                objE_PedidoDetalle.Observacion = item.Observacion;
                objE_PedidoDetalle.CodAfeIGV = item.CodAfeIGV;
                objE_PedidoDetalle.IdKardex = item.IdKardex;
                objE_PedidoDetalle.IdAlmacen = item.IdAlmacen; //add
                objE_PedidoDetalle.FlagMuestra = item.FlagMuestra;
                objE_PedidoDetalle.FlagRegalo = item.FlagRegalo;
                objE_PedidoDetalle.IdPromocion = item.IdPromocion;
                objE_PedidoDetalle.DescPromocion = item.DescPromocion;
                objE_PedidoDetalle.FlagBultoCerrado = item.FlagBultoCerrado;
                objE_PedidoDetalle.FlagNacional = item.FlagNacional;
                objE_PedidoDetalle.PorcentajeDescuentoInicial = 0;
                objE_PedidoDetalle.IdLineaProducto = 0;
                objE_PedidoDetalle.TipoOper = item.TipoOper;
                mListaPedidoDetalle.Add(objE_PedidoDetalle);
            }

            bsListadoDetalle.DataSource = mListaPedidoDetalle;
            gcPedidoDetalle.DataSource = bsListadoDetalle;
            gcPedidoDetalle.RefreshDataSource();


            //CalculaTotales();

        }

        #endregion

        public class CHojaInstalacionDetalle
        {
            public Int32 IdHojaInstalacion { get; set; }
            public Int32 IdHojaInstalacionDetalle { get; set; }
            public Int32 IdPedido { get; set; }
            public String NumeroPedido { get; set; }
            public Int32 IdSituacion { get; set; }
            public String DescSituacion { get; set; }
            public Decimal Total { get; set; }
            public Boolean FlagEstado { get; set; }
            public Int32 TipoOper { get; set; }

            public CHojaInstalacionDetalle()
            {

            }
        }

    }
}