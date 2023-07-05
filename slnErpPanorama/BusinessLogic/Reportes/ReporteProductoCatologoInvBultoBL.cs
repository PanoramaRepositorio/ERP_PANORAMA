using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductoCatologoInvBultoBL
    {
        public List<ReporteProductoCatologoInvBultoBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteProductoCatologoInvBultoDL ProductoCatologoInvBulto = new ReporteProductoCatologoInvBultoDL();
                return ProductoCatologoInvBulto.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteProductoCatologoInvBultoBE> ListadoPreNavidad(int IdEmpresa)
        {
            try
            {
                ReporteProductoCatologoInvBultoDL ProductoCatologoInvBulto = new ReporteProductoCatologoInvBultoDL();
                return ProductoCatologoInvBulto.ListadoPreNavidad(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
