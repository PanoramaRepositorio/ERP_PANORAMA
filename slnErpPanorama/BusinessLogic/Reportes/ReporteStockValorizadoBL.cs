using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteStockValorizadoBL
    {
        public List<ReporteStockValorizadoBE> Listado(int IdEmpresa, DateTime Fecha)
        {
            try
            {
                ReporteStockValorizadoDL reporte = new ReporteStockValorizadoDL();
                return reporte.Listado(IdEmpresa, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
