using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTalonBL
    {
        public List<ReporteTalonBE> Listado()
        {
            try
            {
                ReporteTalonDL Talon = new ReporteTalonDL();
                return Talon.Listado();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
