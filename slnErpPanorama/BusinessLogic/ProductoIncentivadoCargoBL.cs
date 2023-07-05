using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProductoIncentivadoCargoBL
    {
        public List<ProductoIncentivadoCargoBE> ListaTodosActivo(int IdProductoIncentivado)
        {
            try
            {
                ProductoIncentivadoCargoDL ProductoIncentivadoCargo = new ProductoIncentivadoCargoDL();
                return ProductoIncentivadoCargo.ListaTodosActivo(IdProductoIncentivado);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProductoIncentivadoCargoBE pItem)
        {
            try
            {
                ProductoIncentivadoCargoDL ProductoIncentivadoCargo = new ProductoIncentivadoCargoDL();
                ProductoIncentivadoCargo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProductoIncentivadoCargoBE pItem)
        {
            try
            {
                ProductoIncentivadoCargoDL ProductoIncentivadoCargo = new ProductoIncentivadoCargoDL();
                ProductoIncentivadoCargo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProductoIncentivadoCargoBE pItem)
        {
            try
            {
                ProductoIncentivadoCargoDL ProductoIncentivadoCargo = new ProductoIncentivadoCargoDL();
                ProductoIncentivadoCargo.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
