using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteGuiaRemisionBL
    {
        public List<ReporteGuiaRemisionBE> Listado(int IdEmpresa, int IdGuiaRemision)
        {
            try
            {
                ReporteGuiaRemisionDL GuiaRemision = new ReporteGuiaRemisionDL();
                return GuiaRemision.Listado(IdEmpresa, IdGuiaRemision);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
