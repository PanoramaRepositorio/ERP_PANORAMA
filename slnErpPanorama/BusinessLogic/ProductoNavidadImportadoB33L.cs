using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProductoNavidadImportadoB33L
    {
        public ProductoNavidadImportadoBE Selecciona(int IdProducto)
        {
            try
            {
                ProductoNavidadImportadoDL Producto = new ProductoNavidadImportadoDL();
                return Producto.Selecciona(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int ListaProductoPrecioBusquedaCount(int IdTienda, string pFiltro)
        {
            try
            {
                ProductoNavidadImportadoDL ProductoNavidadImportado = new ProductoNavidadImportadoDL();
                return ProductoNavidadImportado.ListaProductoPrecioBusquedaCount(IdTienda, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoNavidadImportadoBE> ListaProductoPrecio(int IdTienda, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                ProductoNavidadImportadoDL ProductoNavidadImportado = new ProductoNavidadImportadoDL();
                return ProductoNavidadImportado.ListaProductoPrecio(IdTienda, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
