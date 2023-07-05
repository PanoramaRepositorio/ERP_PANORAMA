using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTipoCambioBL
    {
        public List<ReporteTipoCambioBE> Listado(int IdEmpresa, int IdMoneda)
        {
            try
            {
                ReporteTipoCambioDL TipoCambio = new ReporteTipoCambioDL();
                return TipoCambio.Listado(IdEmpresa, IdMoneda);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
