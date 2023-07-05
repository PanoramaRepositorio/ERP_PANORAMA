using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CotizacionBL
    {
        public List<CotizacionBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes)
        {
            try
            {
                CotizacionDL Cotizacion = new CotizacionDL();
                return Cotizacion.ListaTodosActivo(IdEmpresa, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CotizacionBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                CotizacionDL Cotizacion = new CotizacionDL();
                return Cotizacion.ListaFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CotizacionBE> ListaNumero(int Periodo, string NumeroCotizacion)
        {
            try
            {
                CotizacionDL Cotizacion = new CotizacionDL();
                return Cotizacion.ListaNumero(Periodo, NumeroCotizacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CotizacionBE> ListaPedido(int Periodo, string NumeroPedido)
        {
            try
            {
                CotizacionDL Cotizacion = new CotizacionDL();
                return Cotizacion.ListaPedido(Periodo, NumeroPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CotizacionBE Selecciona(int IdEmpresa, int IdCotizacion)
        {
            try
            {
                CotizacionDL Cotizacion = new CotizacionDL();
                CotizacionBE objEmp = Cotizacion.Selecciona(IdEmpresa,IdCotizacion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CotizacionBE pItem, EstadoCuentaBE objEstadoCuenta, SeparacionBE objSeparacion)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CotizacionDL Cotizacion = new CotizacionDL();
                    int IdCotizacion = 0;
                    IdCotizacion = Cotizacion.Inserta(pItem);

                    if (objEstadoCuenta != null)
                    {
                        EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                        objEstadoCuenta.IdCotizacion = IdCotizacion;
                        EstadoCuenta.Inserta(objEstadoCuenta);
                    }

                    if (objSeparacion != null)
                    {
                        SeparacionDL Separacion = new SeparacionDL();
                        objSeparacion.IdCotizacion = IdCotizacion;
                        Separacion.Inserta(objSeparacion);
                    }

                    ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                    ClienteCredito.ActualizaLineaCreditoUtilizada(pItem.IdEmpresa, pItem.IdCliente, pItem.Total, 0,pItem.IdMotivo);

                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, Parametros.intTipoDocCotizacionCredito, pItem.Periodo);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CotizacionBE pItem)
        {
            try
            {
                CotizacionDL Cotizacion = new CotizacionDL();
                Cotizacion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CotizacionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CotizacionDL Cotizacion = new CotizacionDL();
                    Cotizacion.Elimina(pItem);

                    EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                    EstadoCuenta.EliminaCotizacion(pItem.IdCotizacion);

                    SeparacionDL Separacion = new SeparacionDL();
                    Separacion.EliminaCotizacion(pItem.IdCotizacion);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}


