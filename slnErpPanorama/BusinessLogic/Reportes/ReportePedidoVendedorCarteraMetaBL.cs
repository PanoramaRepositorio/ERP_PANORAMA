using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoVendedorCarteraMetaBL
    {
        public List<ReportePedidoVendedorCarteraMetaBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorCarteraMetaDL reporte = new ReportePedidoVendedorCarteraMetaDL();
                return reporte.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoVendedorCarteraMetaBE> ListadoDetalle(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoVendedorCarteraMetaDL reporte = new ReportePedidoVendedorCarteraMetaDL();
                return reporte.ListadoDetalle(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReportePedidoVendedorCarteraMetaBE> ListadoSueldo(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            try
            {
                ReportePedidoVendedorCarteraMetaDL reporte = new ReportePedidoVendedorCarteraMetaDL();
                return reporte.ListadoSueldo(IdVendedor, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
