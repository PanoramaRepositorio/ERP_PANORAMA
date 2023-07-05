using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class SolicitudPrestamoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<SolicitudPrestamoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                SolicitudPrestamoDL SolicitudPrestamo = new SolicitudPrestamoDL();
                return SolicitudPrestamo.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudPrestamoBE> ListaPersona(int IdPersona)
        {
            try
            {
                SolicitudPrestamoDL SolicitudPrestamo = new SolicitudPrestamoDL();
                return SolicitudPrestamo.ListaPersona(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudPrestamoBE Selecciona(int IdEmpresa, int IdSolicitudPrestamo)
        {
            try
            {
                SolicitudPrestamoDL SolicitudPrestamo = new SolicitudPrestamoDL();
                return SolicitudPrestamo.Selecciona(IdEmpresa, IdSolicitudPrestamo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudPrestamoBE SeleccionaNumero(int IdEmpresa, int Periodo, int IdTipoDocumento, string Numero)
        {
            try
            {
                SolicitudPrestamoDL SolicitudPrestamo = new SolicitudPrestamoDL();
                return SolicitudPrestamo.SeleccionaNumero(IdEmpresa, Periodo, IdTipoDocumento, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudPrestamoBE> ListaFecha(int IdEmpresa, int IdTipoDocumento, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                SolicitudPrestamoDL SolicitudPrestamo = new SolicitudPrestamoDL();
                return SolicitudPrestamo.ListaFecha(IdEmpresa, IdTipoDocumento, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SolicitudPrestamoBE pItem, List<SolicitudPrestamoDetalleBE> pListaSolicitudPrestamoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudPrestamoDL SolicitudPrestamo = new SolicitudPrestamoDL();
                    SolicitudPrestamoDetalleDL SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleDL();

                    int IdSolicitudPrestamo = 0;
                    IdSolicitudPrestamo = SolicitudPrestamo.Inserta(pItem);

                    foreach (SolicitudPrestamoDetalleBE item in pListaSolicitudPrestamoDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdSolicitudPrestamo = IdSolicitudPrestamo;
                        SolicitudPrestamoDetalle.Inserta(item);
                    }

                    #region "MovimientoCaja"
                    if (pItem.Metodo == 3)
                    {
                        PagosBL objBL_Pagos = new PagosBL();

                        //Datos del Recibo de Pago
                        PagosBE objPago = new PagosBE();
                        objPago.IdPago = 0;
                        objPago.IdPedido = 0;//IdPedido == 0 ? (int?)null : IdPedido;
                        objPago.IdSolicitudPrestamo = IdSolicitudPrestamo;
                        objPago.IdCaja = pItem.IdCaja;
                        objPago.Fecha = pItem.FechaCaja;
                        objPago.IdTipoDocumento = Parametros.intTipoDocRetiroCaja;
                        string Numero = "";
                        Numero = "Falta Caja";
                        objPago.NumeroDocumento = Numero;
                        objPago.IdCondicionPago = Parametros.intEfectivo;
                        objPago.Concepto = "FALTANTE DE CAJA";
                        objPago.IdMoneda = Parametros.intSoles;
                        objPago.TipoCambio = pItem.TipoCambio;
                        objPago.ImporteSoles = pItem.TotalPago;
                        objPago.ImporteDolares = pItem.TotalPago / pItem.TipoCambio;
                        objPago.FlagEstado = true;
                        objPago.Usuario = pItem.Usuario;
                        objPago.Maquina = pItem.Maquina;
                        objPago.IdEmpresa = pItem.IdEmpresa;

                        //Datos del Movimiento de Caja
                        List<MovimientoCajaBE> lstMovimientoCaja = new List<MovimientoCajaBE>();

                        MovimientoCajaBE objMovimientoCaja = new MovimientoCajaBE();
                        objMovimientoCaja.IdMovimientoCaja = 0;
                        objMovimientoCaja.IdCaja = pItem.IdCaja;
                        objMovimientoCaja.Fecha = pItem.FechaCaja;
                        objMovimientoCaja.IdTipoDocumento = Parametros.intTipoDocRetiroCaja;
                        objMovimientoCaja.NumeroDocumento = "Falta Caja";
                        objMovimientoCaja.IdFormaPago = Parametros.intContado;
                        objMovimientoCaja.IdCondicionPago = Parametros.intEfectivo;
                        objMovimientoCaja.TipoMovimiento = "S";
                        objMovimientoCaja.Concepto = "FALTANTE DE CAJA";
                        objMovimientoCaja.IdMoneda = Parametros.intSoles;
                        objMovimientoCaja.TipoCambio = pItem.TipoCambio;
                        objMovimientoCaja.ImporteSoles = pItem.TotalPago;
                        objMovimientoCaja.ImporteDolares = pItem.TotalPago / pItem.TipoCambio;
                        objMovimientoCaja.IdPersona = pItem.IdPersona;
                        objMovimientoCaja.Observacion = pItem.Motivo;
                        objMovimientoCaja.FlagEstado = true;
                        objMovimientoCaja.Usuario = pItem.Usuario;
                        objMovimientoCaja.Maquina = pItem.Maquina;
                        objMovimientoCaja.IdEmpresa = pItem.IdEmpresa;
                        lstMovimientoCaja.Add(objMovimientoCaja);

                        EstadoCuentaBE objE_EstadoCuenta = null;
                        SeparacionBE objE_Separacion = null;

                        objBL_Pagos.Inserta(objPago, lstMovimientoCaja, objE_EstadoCuenta, objE_Separacion);
                    }

                    #endregion


                    //Actualizamos el correlativo del Proforma
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Periodo);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SolicitudPrestamoBE pItem, List<SolicitudPrestamoDetalleBE> pListaSolicitudPrestamoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudPrestamoDL SolicitudPrestamo = new SolicitudPrestamoDL();
                    SolicitudPrestamoDetalleDL SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleDL();


                    foreach (SolicitudPrestamoDetalleBE item in pListaSolicitudPrestamoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdSolicitudPrestamo = pItem.IdSolicitudPrestamo;
                            if (item.TipoMovimiento == "C")
                            {
                                SolicitudPrestamoDetalle.Inserta(item);
                            }
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            if (item.TipoMovimiento == "C")
                            {
                                SolicitudPrestamoDetalle.Actualiza(item);
                            }
                        }
                    }

                    SolicitudPrestamo.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SolicitudPrestamoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudPrestamoDL SolicitudPrestamo = new SolicitudPrestamoDL();
                    SolicitudPrestamoDetalleDL SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleDL();

                    List<SolicitudPrestamoDetalleBE> ListaSolicitudDetalle = null;
                    ListaSolicitudDetalle = new SolicitudPrestamoDetalleDL().ListaTodosActivo(pItem.IdSolicitudPrestamo);

                    foreach (SolicitudPrestamoDetalleBE item in ListaSolicitudDetalle)
                    {
                        SolicitudPrestamoDetalle.Elimina(item);
                    }

                    SolicitudPrestamo.Elimina(pItem);

                    ts.Complete();
                }


            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaPersonaAprueba(int IdSolicitudPrestamo, int IdPersona)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudPrestamoDL SolicitudPrestamo = new SolicitudPrestamoDL();
                    SolicitudPrestamo.ActualizaPersonaAprueba(IdSolicitudPrestamo, IdPersona);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
