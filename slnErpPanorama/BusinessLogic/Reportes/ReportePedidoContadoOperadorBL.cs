using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoContadoOperadorBL
    {
        public List<ReportePedidoContadoOperadorBE> Listado(int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoContadoOperadorDL reporte = new ReportePedidoContadoOperadorDL();
                return reporte.Listado(IdTipoCliente, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
