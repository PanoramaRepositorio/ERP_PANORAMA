using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic.Reportes
{
    public class ReporteDerechoHabienteBL
    {
        public List<ReporteDerechoHabienteBE> Listado(int IdPersona)
        {
            try
            {
                ReporteDerechoHabienteDL Personal = new ReporteDerechoHabienteDL();
                return Personal.Listado(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
