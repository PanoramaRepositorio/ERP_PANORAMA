using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoTiendaMesTipoClienteVariacionBL
    {
        public List<ReportePedidoTiendaMesTipoClienteVariacionBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoTiendaMesTipoClienteVariacionDL reporte = new ReportePedidoTiendaMesTipoClienteVariacionDL();
                return reporte.Listado(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
