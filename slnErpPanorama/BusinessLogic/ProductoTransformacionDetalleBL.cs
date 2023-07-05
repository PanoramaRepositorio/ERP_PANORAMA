using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProductoTransformacionDetalleBL
    {
        public List<ProductoTransformacionDetalleBE> ListaTodosActivo(int IdProductoTransformacion)
        {
            try
            {
                ProductoTransformacionDetalleDL ProductoTransformacionDetalle = new ProductoTransformacionDetalleDL();
                return ProductoTransformacionDetalle.ListaTodosActivo(IdProductoTransformacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProductoTransformacionDetalleBE pItem)
        {
            try
            {
                ProductoTransformacionDetalleDL ProductoTransformacionDetalle = new ProductoTransformacionDetalleDL();
                ProductoTransformacionDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProductoTransformacionDetalleBE pItem)
        {
            try
            {
                ProductoTransformacionDetalleDL ProductoTransformacionDetalle = new ProductoTransformacionDetalleDL();
                ProductoTransformacionDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProductoTransformacionDetalleBE pItem)
        {
            try
            {
                ProductoTransformacionDetalleDL ProductoTransformacionDetalle = new ProductoTransformacionDetalleDL();
                ProductoTransformacionDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
