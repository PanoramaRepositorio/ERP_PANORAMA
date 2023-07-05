using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTransferenciaBultoBL
    {
        public List<ReporteTransferenciaBultoBE> Listado(int IdEmpresa, int IdTransferenciaBulto)
        {
            try
            {
                ReporteTransferenciaBultoDL TransferenciaBulto = new ReporteTransferenciaBultoDL();
                return TransferenciaBulto.Listado(IdEmpresa, IdTransferenciaBulto);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
