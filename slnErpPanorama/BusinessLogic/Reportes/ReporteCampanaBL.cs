using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCampanaBL
    {
        public List<ReporteCampanaBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteCampanaDL Campana = new ReporteCampanaDL();
                return Campana.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
