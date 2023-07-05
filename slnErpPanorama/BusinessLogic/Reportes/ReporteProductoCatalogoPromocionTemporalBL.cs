using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductoCatalogoPromocionTemporalBL
    {
        public List<ReporteProductoCatalogoPromocionTemporalBE> Listado(int IdPromocionTemporal)
        {
            try
            {
                ReporteProductoCatalogoPromocionTemporalDL ProductoCatalogoPromocionTemporal = new ReporteProductoCatalogoPromocionTemporalDL();
                return ProductoCatalogoPromocionTemporal.Listado(IdPromocionTemporal);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteProductoCatalogoPromocionTemporalBE> ListadoLineaProducto(int IdPromocionTemporal, int IdLineaProducto)
        {
            try
            {
                ReporteProductoCatalogoPromocionTemporalDL ProductoCatalogoPromocionTemporal = new ReporteProductoCatalogoPromocionTemporalDL();
                return ProductoCatalogoPromocionTemporal.ListadoLineaProducto(IdPromocionTemporal, IdLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteProductoCatalogoPromocionTemporalBE> ListadoSubLineaProducto(int IdPromocionTemporal, int IdSubLineaProducto)
        {
            try
            {
                ReporteProductoCatalogoPromocionTemporalDL ProductoCatalogoPromocionTemporal = new ReporteProductoCatalogoPromocionTemporalDL();
                return ProductoCatalogoPromocionTemporal.ListadoSubLineaProducto(IdPromocionTemporal, IdSubLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
