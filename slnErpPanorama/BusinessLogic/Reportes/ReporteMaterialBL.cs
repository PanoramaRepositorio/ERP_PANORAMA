using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMaterialBL
    {
        public List<ReporteMaterialBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteMaterialDL Material = new ReporteMaterialDL();
                return Material.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
