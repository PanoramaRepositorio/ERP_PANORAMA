using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PlanillaRHBL
    {
       

        public List<PlanillaRHBE> PlanillaRH(int dias)
        {
            try
            {
                PlanillaRHDL Planilla = new PlanillaRHDL();
                return Planilla.PlanillaRH( dias);
            }
            catch (Exception ex)
            { throw ex; }
        }

      
    }
}
