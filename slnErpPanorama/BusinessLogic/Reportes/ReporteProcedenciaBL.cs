using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProcedenciaBL
    {
        public List<ReporteProcedenciaBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteProcedenciaDL Procedencia = new ReporteProcedenciaDL();
                return Procedencia.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
