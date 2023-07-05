using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CreditoPeriodoBL
    {
        public List<CreditoPeriodoBE> ListaTodosActivo()
        {
            try
            {
                CreditoPeriodoDL CreditoPeriodo = new CreditoPeriodoDL();
                return CreditoPeriodo.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
