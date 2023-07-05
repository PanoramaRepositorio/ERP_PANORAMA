using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePedidoTipoClienteOperadorBL
    {

        public List<ReportePedidoTipoClienteOperadorBE> Listado(int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReportePedidoTipoClienteOperadorDL reporte = new ReportePedidoTipoClienteOperadorDL();
                return reporte.Listado(IdTipoCliente,FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public List<ReportePedidoTipoClienteOperadorBE> ListadoContado(int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        //{
        //    try
        //    {
        //        ReportePedidoTipoClienteOperadorDL reporte = new ReportePedidoTipoClienteOperadorDL();
        //        return reporte.ListadoContado(IdTipoCliente, FechaDesde, FechaHasta);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
    }
}
