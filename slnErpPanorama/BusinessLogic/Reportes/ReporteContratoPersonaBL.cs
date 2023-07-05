using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteContratoPersonaBL
    {
        public List<ReporteContratoPersonaBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteContratoPersonaDL ReporteContratoPersona = new ReporteContratoPersonaDL();
                return ReporteContratoPersona.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
