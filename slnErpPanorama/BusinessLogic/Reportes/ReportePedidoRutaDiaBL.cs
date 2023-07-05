using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;


namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoRutaDiaBL
    {
        public List<ReportePedidoRutaDiaBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoRutaDiaDL reporte = new ReportePedidoRutaDiaDL();
                return reporte.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
