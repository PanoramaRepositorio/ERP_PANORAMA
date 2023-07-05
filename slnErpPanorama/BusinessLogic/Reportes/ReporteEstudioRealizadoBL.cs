using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteEstudioRealizadoBL
    {
        public List<ReporteEstudioRealizadoBE> Listado(int IdPersona)
        {
            try
            {
                ReporteEstudioRealizadoDL Personal = new ReporteEstudioRealizadoDL();
                return Personal.Listado(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
