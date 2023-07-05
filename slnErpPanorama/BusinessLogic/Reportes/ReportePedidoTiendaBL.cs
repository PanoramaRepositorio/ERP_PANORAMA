using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoTiendaBL
    {
        public List<ReportePedidoTiendaBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoTiendaDL reporte = new ReportePedidoTiendaDL();
                return reporte.Listado(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
