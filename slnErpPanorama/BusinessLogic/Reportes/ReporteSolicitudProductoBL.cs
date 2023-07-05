using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteSolicitudProductoBL
    {
        public List<ReporteSolicitudProductoBE> Listado(int IdEmpresa, int IdSolicitudProducto)
        {
            try
            {
                ReporteSolicitudProductoDL SolicitudProducto = new ReporteSolicitudProductoDL();
                return SolicitudProducto.Listado(IdEmpresa, IdSolicitudProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
