using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReportePersonaBL
    {
        public List<ReportePersonaBE> Listado(int IdPersona)
        {
            try
            {
                ReportePersonaDL Personal = new ReportePersonaDL();
                return Personal.Listado(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
