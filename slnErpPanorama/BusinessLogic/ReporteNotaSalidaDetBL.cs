using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;
using ErpPanorama.BusinessEntity.Reportes;
using ErpPanorama.DataLogic.Reportes;

namespace ErpPanorama.BusinessLogic.Reportes
{
   public class ReporteNotaSalidaDetBL
    {
        public ReporteNotaSalidaDetBL()  {  }
        public List<ReporteNotaSalidaDetBE> ListaReporte(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento)
        {
            try
            {
                ReporteNotaSalidaDetDL reporte = new ReporteNotaSalidaDetDL();
                return reporte.ListaReporte(IdEmpresa, Periodo, Mes, IdAlmacenOrigen, IdTipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
