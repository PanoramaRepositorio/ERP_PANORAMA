using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMarcaBL
    {
        public List<ReporteMarcaBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteMarcaDL Marca = new ReporteMarcaDL();
                return Marca.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}