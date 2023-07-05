using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTiendaTipoClienteMetaBL
    {
        public List<ReporteTiendaTipoClienteMetaBE> Listado(int IdTienda, int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteTiendaTipoClienteMetaDL Reporte = new ReporteTiendaTipoClienteMetaDL();
                return Reporte.Listado(IdTienda, IdTipoCliente, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteTiendaTipoClienteMetaBE> ListadoVendedor(int IdEmpresa,int IdTienda, int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteTiendaTipoClienteMetaDL Reporte = new ReporteTiendaTipoClienteMetaDL();
                return Reporte.ListadoVendedor(IdEmpresa, IdTienda, IdVendedor, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
