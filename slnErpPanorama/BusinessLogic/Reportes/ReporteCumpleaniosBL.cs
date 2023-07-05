using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCumpleaniosBL
    {
        public List<ReporteCumpleaniosBE> Listado(int Mes,bool FlagApoyo)
        {
            try
            {
                ReporteCumpleaniosDL Caja = new ReporteCumpleaniosDL();
                return Caja.Listado(Mes, FlagApoyo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
