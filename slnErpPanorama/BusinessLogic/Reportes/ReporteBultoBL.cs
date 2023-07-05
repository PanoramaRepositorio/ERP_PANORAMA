using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteBultoBL
    {
        public List<ReporteBultoBE> Listado(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                ReporteBultoDL Bulto = new ReporteBultoDL();
                return Bulto.Listado(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
