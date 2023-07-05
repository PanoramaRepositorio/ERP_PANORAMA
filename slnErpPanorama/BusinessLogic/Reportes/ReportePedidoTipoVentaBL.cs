using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoTipoVentaBL
    {
        public List<ReportePedidoTipoVentaBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdTipoVenta)
        {
            try
            {
                ReportePedidoTipoVentaDL reporte = new ReportePedidoTipoVentaDL();
                return reporte.Listado(FechaDesde, FechaHasta, IdTipoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoTipoVentaBE> ListadoDetalle(DateTime FechaDesde, DateTime FechaHasta, int IdTipoVenta)
        {
            try
            {
                ReportePedidoTipoVentaDL reporte = new ReportePedidoTipoVentaDL();
                return reporte.ListadoDetalle(FechaDesde, FechaHasta, IdTipoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoTipoVentaBE> ListadoEcommerce(DateTime FechaDesde, DateTime FechaHasta, Int32 DetalleVentas)
        {
            try
            {
                ReportePedidoTipoVentaDL reporte = new ReportePedidoTipoVentaDL();
                return reporte.ListadoEcommerce(FechaDesde, FechaHasta, DetalleVentas);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
