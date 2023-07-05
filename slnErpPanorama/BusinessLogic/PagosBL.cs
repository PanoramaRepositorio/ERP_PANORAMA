using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PagosBL
    {
        public List<PagosBE> ListaTodosActivo(int IdEmpresa, int IdCaja, DateTime Fecha, DateTime FechaHasta, int IdTipoDocumento)
        {
            try
            {
                PagosDL Pagos = new PagosDL();
                return Pagos.ListaTodosActivo(IdEmpresa, IdCaja, Fecha, FechaHasta, IdTipoDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PagosBE> ListaNotaCredito(int IdEmpresa, int IdCaja)
        {
            try
            {
                PagosDL Pagos = new PagosDL();
                return Pagos.ListaNotaCredito(IdEmpresa, IdCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PagosBE> ListaAsesoria(int IdEmpresa, int IdDis_ProyectoServicio, int IdDis_ContratoFabricacion, int TipoConsulta)
        {
            try
            {
                PagosDL Pagos = new PagosDL();
                return Pagos.ListaAsesoria(IdEmpresa, IdDis_ProyectoServicio, IdDis_ContratoFabricacion, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PagosBE Selecciona(int IdEmpresa, int IdPagos)
        {
            try
            {
                PagosDL Pagos = new PagosDL();
                PagosBE objEmp = Pagos.Selecciona(IdEmpresa, IdPagos);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public PagosBE SeleccionaHoraExtra(int IdEmpresa, int IdHoraExtra)
        {
            try
            {
                PagosDL Pagos = new PagosDL();
                PagosBE objEmp = Pagos.SeleccionaHoraExtra(IdEmpresa, IdHoraExtra);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PagosBE SeleccionaNotaCredito(int IdEmpresa, int IdTipoDocumento, string NumeroDocumento)
        {
            try
            {
                PagosDL Pagos = new PagosDL();
                PagosBE objEmp = Pagos.SeleccionaNotaCredito(IdEmpresa, IdTipoDocumento, NumeroDocumento);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PagosBE SeleccionaNumero(int IdEmpresa, int IdTipoDocumento, string NumeroDocumento)
        {
            try
            {
                PagosDL Pagos = new PagosDL();
                PagosBE objEmp = Pagos.SeleccionaNumero(IdEmpresa, IdTipoDocumento, NumeroDocumento);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(PagosBE pItem, List<MovimientoCajaBE> pListaCajaBE, /*MovimientoCajaBE pMovimientoCaja*/ EstadoCuentaBE pEstadoCuenta, SeparacionBE pSeparacion)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    PagosDL Pago = new PagosDL();

                    //Insertamos en Movimiento de Caja
                    int IdMovimientoCaja = 0;
                    int IdPago = 0;

                    //MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    //IdMovimientoCaja = MovimientoCaja.Inserta(pMovimientoCaja);

                    //Insertamos el recibo de pago
                    //PagosDL Pago = new PagosDL();
                    //pItem.IdMovimientoCaja = IdMovimientoCaja;
                    IdPago = Pago.Inserta(pItem);

                    //Insertamos el movimiento de caja
                    foreach (MovimientoCajaBE item in pListaCajaBE)
                    {
                        //Insertamos el detalle movimientoCaja
                        item.IdPago = IdPago;
                        IdMovimientoCaja = MovimientoCaja.Inserta(item);
                    }

                    ////Insertamos en Movimiento de Caja
                    //int IdMovimientoCaja = 0;
                    //MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    //IdMovimientoCaja =  MovimientoCaja.Inserta(pMovimientoCaja);
                    EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                    EstadoCuentaClienteDL EstadoCuentaCliente = new EstadoCuentaClienteDL();
                    

                    if (pEstadoCuenta != null)
                    { 
                        //Estado de cuenta
                        EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                        pEstadoCuenta.IdMovimientoCaja = IdMovimientoCaja;
                        EstadoCuenta.Inserta(pEstadoCuenta);

                        ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                        if (pItem.TipoMovimiento == "C")
                            ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pEstadoCuenta.IdCliente, pEstadoCuenta.Importe, 0, pEstadoCuenta.IdMotivo);
                        else
                            ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pEstadoCuenta.IdCliente, 0, pEstadoCuenta.Importe, pEstadoCuenta.IdMotivo);

                        //add 13-02-19
                        #region "EstadoCuentaCliente"
                        objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                        objE_EstadoCuentaCliente.IdEmpresa = pEstadoCuenta.IdEmpresa;
                        objE_EstadoCuentaCliente.Periodo = pEstadoCuenta.Periodo;
                        objE_EstadoCuentaCliente.IdCliente = pEstadoCuenta.IdCliente;
                        objE_EstadoCuentaCliente.NumeroDocumento = pEstadoCuenta.NumeroDocumento;
                        objE_EstadoCuentaCliente.Fecha = pEstadoCuenta.FechaCredito;
                        objE_EstadoCuentaCliente.Concepto = pEstadoCuenta.Concepto;
                        objE_EstadoCuentaCliente.FechaVencimiento = pEstadoCuenta.FechaVencimiento;
                        objE_EstadoCuentaCliente.IdMoneda = Parametros.intDolares;
                        objE_EstadoCuentaCliente.Importe = pEstadoCuenta.Importe;
                        objE_EstadoCuentaCliente.TipoMovimiento = pEstadoCuenta.TipoMovimiento;
                        objE_EstadoCuentaCliente.IdMotivo = pEstadoCuenta.IdMotivo;
                        objE_EstadoCuentaCliente.IdDocumentoVenta = pEstadoCuenta.IdDocumentoVenta;
                        objE_EstadoCuentaCliente.IdPedido = pEstadoCuenta.IdPedido;
                        objE_EstadoCuentaCliente.IdMovimientoCaja = pEstadoCuenta.IdMovimientoCaja;
                        objE_EstadoCuentaCliente.IdCuentaBancoDetalle = pEstadoCuenta.IdCuentaBancoDetalle;
                        objE_EstadoCuentaCliente.IdPersona = pEstadoCuenta.IdUsuario;
                        objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                        objE_EstadoCuentaCliente.FechaRegistro = pEstadoCuenta.FechaCredito;
                        objE_EstadoCuentaCliente.Observacion = pEstadoCuenta.Observacion;
                        objE_EstadoCuentaCliente.Saldo = pEstadoCuenta.Importe;
                        objE_EstadoCuentaCliente.FlagEstado = true;
                        objE_EstadoCuentaCliente.Usuario = pEstadoCuenta.Usuario;
                        objE_EstadoCuentaCliente.Maquina = pEstadoCuenta.Maquina;

                        EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                        #endregion

                    }

                    if (pSeparacion != null)
                    {
                        //Separacion
                        SeparacionDL Separacion = new SeparacionDL();
                        pSeparacion.IdMovimientoCaja = IdMovimientoCaja;
                        Separacion.Inserta(pSeparacion);

                        ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                        if (pItem.TipoMovimiento == "C")
                            ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pSeparacion.IdCliente, pSeparacion.Importe, 0, pSeparacion.IdMotivo);
                        else
                            ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pSeparacion.IdCliente, 0, pSeparacion.Importe, pSeparacion.IdMotivo);

                        //add 13-02-19
                        #region "EstadoCuentaCliente"
                        objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                        objE_EstadoCuentaCliente.IdEmpresa = pSeparacion.IdEmpresa;
                        objE_EstadoCuentaCliente.Periodo = pSeparacion.Periodo;
                        objE_EstadoCuentaCliente.IdCliente = pSeparacion.IdCliente;
                        objE_EstadoCuentaCliente.NumeroDocumento = pSeparacion.NumeroDocumento;
                        objE_EstadoCuentaCliente.Fecha = pSeparacion.FechaSeparacion;
                        objE_EstadoCuentaCliente.Concepto = pSeparacion.Concepto;
                        objE_EstadoCuentaCliente.FechaVencimiento = pSeparacion.FechaVencimiento;
                        objE_EstadoCuentaCliente.IdMoneda = Parametros.intSoles;
                        objE_EstadoCuentaCliente.Importe = pSeparacion.Importe;
                        objE_EstadoCuentaCliente.TipoMovimiento = pSeparacion.TipoMovimiento;
                        objE_EstadoCuentaCliente.IdMotivo = pSeparacion.IdMotivo;
                        objE_EstadoCuentaCliente.IdDocumentoVenta = pSeparacion.IdDocumentoVenta;
                        objE_EstadoCuentaCliente.IdPedido = pSeparacion.IdPedido;
                        objE_EstadoCuentaCliente.IdMovimientoCaja = pSeparacion.IdMovimientoCaja;
                        objE_EstadoCuentaCliente.IdCuentaBancoDetalle = pSeparacion.IdCuentaBancoDetalle;
                        objE_EstadoCuentaCliente.IdPersona = pSeparacion.IdUsuario;
                        objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                        objE_EstadoCuentaCliente.FechaRegistro = pSeparacion.FechaSeparacion;
                        objE_EstadoCuentaCliente.Observacion = pSeparacion.Observacion;
                        objE_EstadoCuentaCliente.Saldo = pSeparacion.Importe;
                        objE_EstadoCuentaCliente.FlagEstado = true;
                        objE_EstadoCuentaCliente.Usuario = pSeparacion.Usuario;
                        objE_EstadoCuentaCliente.Maquina = pSeparacion.Maquina;

                        EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                        #endregion

                    }


                    //Actualizamos el Pedido de Venta
                    //PedidoDL Pedido = new PedidoDL();

                    //PedidoBE objE_Pedido = null;
                    //objE_Pedido = Pedido.Selecciona(Convert.ToInt32(pItem.IdPedido));
                    //if (objE_Pedido != null)
                    //{
                    //    Pedido.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado);                  
                    //}

                    ts.Complete();

                    return IdPago;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PagosBE pItem,List<MovimientoCajaBE> pListaCajaBE /*MovimientoCajaBE pMovimientoCaja*/, EstadoCuentaBE pEstadoCuenta, SeparacionBE pSeparacion)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    PagosDL Pago = new PagosDL();

                    //Actualizamos el recibo de pago
                    Pago.Actualiza(pItem);

                    //Insertamos en Movimiento de Caja
                    //MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    //MovimientoCaja.Actualiza(pMovimientoCaja);

                    //Insertamos en Estado de Cuenta
                    EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                    EstadoCuenta.Actualiza(pEstadoCuenta);

                    if (pEstadoCuenta != null)
                    {
                        ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                        if (pItem.TipoMovimiento == "C")
                            ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pEstadoCuenta.IdCliente, pEstadoCuenta.Importe, pEstadoCuenta.ImporteAnt, pEstadoCuenta.IdMotivo);
                        else
                            ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pEstadoCuenta.IdCliente, pEstadoCuenta.ImporteAnt, pEstadoCuenta.Importe, pEstadoCuenta.IdMotivo);
                    }

                    //Insertamos en Separacion
                    SeparacionDL Separacion = new SeparacionDL();
                    Separacion.Actualiza(pSeparacion);

                    if (pSeparacion != null)
                    {
                        ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                        if (pItem.TipoMovimiento == "C")
                            ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pSeparacion.IdCliente, pSeparacion.Importe, pSeparacion.ImporteAnt, pSeparacion.IdMotivo);
                        else
                            ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pSeparacion.IdCliente, pSeparacion.ImporteAnt, pSeparacion.Importe, pSeparacion.IdMotivo);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PagosBE pItem, MovimientoCajaBE pMovimientoCaja)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Eliminamos el recibo de pago
                    PagosDL Pago = new PagosDL();
                    Pago.Elimina(pItem);

                    if (pMovimientoCaja != null)
                    {
                        //Eliminamos en Movimiento de Caja
                        MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                        MovimientoCaja.Elimina(pMovimientoCaja);
                    }

                    //Eliminamos en Estado de cuenta
                    EstadoCuentaBE objE_EstadoCuenta = null;
                    EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                    objE_EstadoCuenta = EstadoCuenta.SeleccionaMovimientoCaja(pMovimientoCaja.IdMovimientoCaja);

                    if (objE_EstadoCuenta != null)
                    {
                        EstadoCuenta.Elimina(objE_EstadoCuenta);
                    }

                    //Eliminamos en Separacion
                    SeparacionBE objE_Separacion = null;
                    SeparacionDL Separacion = new SeparacionDL();
                    objE_Separacion = Separacion.SeleccionaMovimientoCaja(pMovimientoCaja.IdMovimientoCaja);

                    if (objE_Separacion != null)
                    {
                        Separacion.Elimina(objE_Separacion);
                    }

                    //Eliminamos en Estado de cuenta Cliente
                    EstadoCuentaClienteBE objE_EstadoCuentaCliente = null;
                    EstadoCuentaClienteDL EstadoCuentaCliente = new EstadoCuentaClienteDL();
                    objE_EstadoCuentaCliente = EstadoCuentaCliente.SeleccionaMovimientoCaja(pMovimientoCaja.IdMovimientoCaja);
                    if (objE_EstadoCuentaCliente != null)
                    {
                        EstadoCuentaCliente.Elimina(objE_EstadoCuentaCliente);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNotaCredito(string NumeroDocumento, int IdDocumentoVenta)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Actualizamos el recibo de pago
                    PagosDL Pago = new PagosDL();
                    Pago.ActualizaNotaCredito(NumeroDocumento, IdDocumentoVenta);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaProyectoServicio(int IdPago, int IdDis_ProyectoServicio)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Actualizamos el recibo de pago
                    PagosDL Pago = new PagosDL();
                    Pago.ActualizaProyectoServicio(IdPago, IdDis_ProyectoServicio);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}

