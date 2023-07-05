using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMovimientoCajaBL
    {
        public List<ReporteMovimientoCajaBE> Listado(int IdEmpresa,int IdCaja, DateTime Fecha)
        {
            try
            {
                ReporteMovimientoCajaDL MovimientoCaja = new ReporteMovimientoCajaDL();
                return MovimientoCaja.Listado(IdEmpresa,IdCaja, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteMovimientoCajaBE> ListadoTienda(int IdEmpresa,int IdCaja, DateTime Fecha)
        {
            try
            {
                ReporteMovimientoCajaDL MovimientoCaja = new ReporteMovimientoCajaDL();
                return MovimientoCaja.ListadoTienda(IdEmpresa, IdCaja, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteMovimientoCajaBE> ListadoTarjeta(int IdTienda, int IdCaja, DateTime Fecha)
        {
            try
            {
                ReporteMovimientoCajaDL MovimientoCaja = new ReporteMovimientoCajaDL();
                return MovimientoCaja.ListadoTarjeta(IdTienda, IdCaja, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteMovimientoCajaBE> ListadoDocumento(int IdEmpresa, int IdCaja, DateTime Fecha)
        {
            try
            {
                ReporteMovimientoCajaDL MovimientoCaja = new ReporteMovimientoCajaDL();
                return MovimientoCaja.ListadoDocumento(IdEmpresa, IdCaja, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteMovimientoCajaBE> ListadoDocumentoTienda(int IdEmpresa, int IdTienda, DateTime Fecha)
        {
            try
            {
                ReporteMovimientoCajaDL MovimientoCaja = new ReporteMovimientoCajaDL();
                return MovimientoCaja.ListadoDocumentoTienda(IdEmpresa, IdTienda, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteMovimientoCajaBE> ListadoDocumentoResumen(int IdEmpresa, int IdCaja, DateTime Fecha)
        {
            try
            {
                ReporteMovimientoCajaDL MovimientoCaja = new ReporteMovimientoCajaDL();
                return MovimientoCaja.ListadoDocumentoResumen(IdEmpresa, IdCaja, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteMovimientoCajaBE> ListadoDiferenciaDiario(int IdEmpresa, int IdTienda, int IdCaja, int IdTiempo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteMovimientoCajaDL MovimientoCaja = new ReporteMovimientoCajaDL();
                return MovimientoCaja.ListadoDiferenciaDiario(IdEmpresa, IdTienda, IdCaja, IdTiempo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteMovimientoCajaBE> ListadoDiferenciaMensual(int IdEmpresa, int IdTienda, int IdCaja, int IdTiempo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteMovimientoCajaDL MovimientoCaja = new ReporteMovimientoCajaDL();
                return MovimientoCaja.ListadoDiferenciaMensual(IdEmpresa, IdTienda, IdCaja, IdTiempo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }


    }
}
