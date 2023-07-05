using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteClienteListaGeneralBL
    {
        public List<ReporteClienteListaGeneralBE> ListadoGeneral(int IdEmpresa)
        {
            try
            {
                ReporteClienteListaGeneralDL ClienteGeneral = new ReporteClienteListaGeneralDL();
                return ClienteGeneral.ListadoGeneral(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
