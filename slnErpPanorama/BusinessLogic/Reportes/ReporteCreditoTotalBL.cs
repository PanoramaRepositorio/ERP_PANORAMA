using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCreditoTotalBL
    {
        public List<ReporteCreditoTotalBE> Listado(int Periodo, int OrderByColumn, string OrderByType)
        {
            try
            {
                ReporteCreditoTotalDL ReporteCreditoTotal = new ReporteCreditoTotalDL();
                return ReporteCreditoTotal.Listado(Periodo, OrderByColumn, OrderByType);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
