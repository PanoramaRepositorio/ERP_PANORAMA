using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteUnidadMedidaBL
    {
        public List<ReporteUnidadMedidaBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteUnidadMedidaDL UnidadMedida = new ReporteUnidadMedidaDL();
                return UnidadMedida.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
