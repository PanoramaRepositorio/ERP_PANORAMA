using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProductoIncentivadoDetalleBL
    {
        public List<ProductoIncentivadoDetalleBE> ListaTodosActivo(int IdProductoIncentivado)
        {
            try
            {
                ProductoIncentivadoDetalleDL ProductoIncentivadoDetalle = new ProductoIncentivadoDetalleDL();
                return ProductoIncentivadoDetalle.ListaTodosActivo(IdProductoIncentivado);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProductoIncentivadoDetalleBE pItem)
        {
            try
            {
                ProductoIncentivadoDetalleDL ProductoIncentivadoDetalle = new ProductoIncentivadoDetalleDL();
                ProductoIncentivadoDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProductoIncentivadoDetalleBE pItem)
        {
            try
            {
                ProductoIncentivadoDetalleDL ProductoIncentivadoDetalle = new ProductoIncentivadoDetalleDL();
                ProductoIncentivadoDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProductoIncentivadoDetalleBE pItem)
        {
            try
            {
                ProductoIncentivadoDetalleDL ProductoIncentivadoDetalle = new ProductoIncentivadoDetalleDL();
                ProductoIncentivadoDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
