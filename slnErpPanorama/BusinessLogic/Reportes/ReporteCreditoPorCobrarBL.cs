using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCreditoPorCobrarBL
    {
        public List<ReporteCreditoPorCobrarBE> Listado()
        {
            try
            {
                ReporteCreditoPorCobrarDL ReporteCreditoPorCobrar = new ReporteCreditoPorCobrarDL();
                return ReporteCreditoPorCobrar.Listado();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
