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
   public class ReporteFacturacionBL
    {
        public ReporteFacturacionBL()  {  }
        public List<ReporteFacturacionBE> ListaReporte(int IdTienda, int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteFacturacionDL reporte = new ReporteFacturacionDL();
                return reporte.ListaReporte(IdTienda, IdTipoCliente, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
