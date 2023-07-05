using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMuestraBL
    {
        public List<ReporteMuestraBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteMuestraDL Muestra = new ReporteMuestraDL();
                return Muestra.Listado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
