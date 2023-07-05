using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTicketVendedorBL
    {
        public List<ReporteTicketVendedorBE> Listado(Int32 IdTienda,DateTime FechaDesde, DateTime FechaHasta, Int32 TipoReporte)
        {
            try
            {
                ReporteTicketVendedorDL Empresa = new ReporteTicketVendedorDL();
                return Empresa.Listado(IdTienda, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteTicketVendedorBE> ListadoCartera(Int32 IdTienda, DateTime FechaDesde, DateTime FechaHasta, Int32 TipoReporte)
        {
            try
            {
                ReporteTicketVendedorDL Empresa = new ReporteTicketVendedorDL();
                return Empresa.ListadoCartera(IdTienda, FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
