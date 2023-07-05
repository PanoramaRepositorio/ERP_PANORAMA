using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteMetasBL
    {
        public List<ReporteMetasBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteMetasDL Metas = new ReporteMetasDL();
                return Metas.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
