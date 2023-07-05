using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoTiendaMesTipoClienteBL
    {
        public List<ReportePedidoTiendaMesTipoClienteBE> Listado(int IdEmpresa, int IdPersona, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoTiendaMesTipoClienteDL reporte = new ReportePedidoTiendaMesTipoClienteDL();
                return reporte.Listado(IdEmpresa, IdPersona, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoTiendaMesTipoClienteBE> ListadoPorCanalVenta(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoTiendaMesTipoClienteDL reporte = new ReportePedidoTiendaMesTipoClienteDL();
                return reporte.ListadoPorCanalVenta(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }



        public List<ReportePedidoTiendaMesTipoClienteBE> ListadoPorLinea(int IdEmpresa, int IdTienda, int IdLineaProducto, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            try
            {
                ReportePedidoTiendaMesTipoClienteDL reporte = new ReportePedidoTiendaMesTipoClienteDL();
                return reporte.ListadoPorLinea(IdEmpresa, IdTienda, IdLineaProducto, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoTiendaMesTipoClienteBE> ListadoPorLineaHorizontal(int IdEmpresa, int IdTienda, int IdLineaProducto, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            try
            {
                ReportePedidoTiendaMesTipoClienteDL reporte = new ReportePedidoTiendaMesTipoClienteDL();
                return reporte.ListadoPorLineaHorizontal(IdEmpresa, IdTienda, IdLineaProducto, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoTiendaMesTipoClienteBE> ListadoPorLineaCostoHorizontal(int IdEmpresa, int IdTienda, int IdLineaProducto, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            try
            {
                ReportePedidoTiendaMesTipoClienteDL reporte = new ReportePedidoTiendaMesTipoClienteDL();
                return reporte.ListadoPorLineaCostoHorizontal(IdEmpresa, IdTienda, IdLineaProducto, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoTiendaMesTipoClienteBE> ListadoComparativo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoTiendaMesTipoClienteDL reporte = new ReportePedidoTiendaMesTipoClienteDL();
                return reporte.ListadoComparativo(IdEmpresa , FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
