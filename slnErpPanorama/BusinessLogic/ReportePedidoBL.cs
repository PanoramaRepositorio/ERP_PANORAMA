using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;
using ErpPanorama.BusinessEntity.Reportes;
using ErpPanorama.DataLogic.Reportes;

namespace ErpPanorama.BusinessLogic.Reportes
{
   public class ReportePedidoBL
    {
        public ReportePedidoBL() { }
        public List<ReportePedidoBE> ListaReporte(int IdTienda, int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            try
            {
                ReportePedidoDL reporte = new ReportePedidoDL();
                return reporte.ListaReporte(IdTienda, IdTipoCliente, FechaDesde, FechaHasta, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
