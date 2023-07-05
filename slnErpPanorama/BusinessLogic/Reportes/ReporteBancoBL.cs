using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteBancoBL
    {
        public List<ReporteBancoBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteBancoDL Banco = new ReporteBancoDL();
                return Banco.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}