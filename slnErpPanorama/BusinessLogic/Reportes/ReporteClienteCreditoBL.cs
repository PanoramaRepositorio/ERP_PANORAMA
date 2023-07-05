using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteClienteCreditoBL
    {
        public List<ReporteClienteCreditoBE> Listado(int IdEmpresa, int IdMotivo)
        {
            try
            {
                ReporteClienteCreditoDL ClienteCredito = new ReporteClienteCreditoDL();
                return ClienteCredito.Listado(IdEmpresa, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
