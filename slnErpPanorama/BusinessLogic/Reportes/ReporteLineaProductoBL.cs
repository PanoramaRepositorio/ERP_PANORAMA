using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteLineaProductoBL
    {
        public List<ReporteLineaProductoBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteLineaProductoDL LineaProducto = new ReporteLineaProductoDL();
                return LineaProducto.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
