using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductoCatalogoPromocion2x1BL
    {
        public List<ReporteProductoCatalogoPromocion2x1BE> Listado(int IdPromocion2x1)
        {
            try
            {
                ReporteProductoCatalogoPromocion2x1DL ProductoCatalogoPromocion2x1 = new ReporteProductoCatalogoPromocion2x1DL();
                return ProductoCatalogoPromocion2x1.Listado(IdPromocion2x1);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteProductoCatalogoPromocion2x1BE> ListadoLineaProducto(int IdPromocion2x1, int IdLineaProducto)
        {
            try
            {
                ReporteProductoCatalogoPromocion2x1DL ProductoCatalogoPromocion2x1 = new ReporteProductoCatalogoPromocion2x1DL();
                return ProductoCatalogoPromocion2x1.ListadoLineaProducto(IdPromocion2x1, IdLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteProductoCatalogoPromocion2x1BE> ListadoSubLineaProducto(int IdPromocion2x1, int IdSubLineaProducto)
        {
            try
            {
                ReporteProductoCatalogoPromocion2x1DL ProductoCatalogoPromocion2x1 = new ReporteProductoCatalogoPromocion2x1DL();
                return ProductoCatalogoPromocion2x1.ListadoSubLineaProducto(IdPromocion2x1, IdSubLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
