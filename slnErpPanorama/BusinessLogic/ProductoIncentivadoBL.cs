using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProductoIncentivadoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ProductoIncentivadoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ProductoIncentivadoDL ProductoIncentivado = new ProductoIncentivadoDL();
                return ProductoIncentivado.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProductoIncentivadoBE pItem, List<ProductoIncentivadoDetalleBE> pListaProductoIncentivadoDetalle, List<ProductoIncentivadoCargoBE> pListaProductoIncentivadoCargo)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProductoIncentivadoDL ProductoIncentivado = new ProductoIncentivadoDL();
                    ProductoIncentivadoDetalleDL ProductoIncentivadoDetalle = new ProductoIncentivadoDetalleDL();
                    ProductoIncentivadoCargoDL ProductoIncentivadoCargo = new ProductoIncentivadoCargoDL();

                    int IdProductoIncentivado = 0;
                    IdProductoIncentivado = ProductoIncentivado.Inserta(pItem);

                    foreach (ProductoIncentivadoDetalleBE item in pListaProductoIncentivadoDetalle)
                    {
                        //Insertamos el detalle del cargo
                        item.IdProductoIncentivado = IdProductoIncentivado;
                        ProductoIncentivadoDetalle.Inserta(item);
                    }

                    foreach (ProductoIncentivadoCargoBE item in pListaProductoIncentivadoCargo)
                    {
                        //Insertamos el detalle del cargo
                        item.IdProductoIncentivado = IdProductoIncentivado;
                        ProductoIncentivadoCargo.Inserta(item);
                    }


                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProductoIncentivadoBE pItem, List<ProductoIncentivadoDetalleBE> pListaProductoIncentivadoDetalle, List<ProductoIncentivadoCargoBE> pListaProductoIncentivadoCargo)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProductoIncentivadoDL ProductoIncentivado = new ProductoIncentivadoDL();
                    ProductoIncentivadoDetalleDL ProductoIncentivadoDetalle = new ProductoIncentivadoDetalleDL();
                    ProductoIncentivadoCargoDL ProductoIncentivadoCargo = new ProductoIncentivadoCargoDL();


                    foreach (ProductoIncentivadoDetalleBE item in pListaProductoIncentivadoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdProductoIncentivado = pItem.IdProductoIncentivado;
                            ProductoIncentivadoDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            ProductoIncentivadoDetalle.Actualiza(item);
                        }
                    }

                    
                    foreach (ProductoIncentivadoCargoBE item in pListaProductoIncentivadoCargo)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del Cargo
                            item.IdProductoIncentivado = pItem.IdProductoIncentivado;
                            ProductoIncentivadoCargo.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle del Cargo
                            ProductoIncentivadoCargo.Actualiza(item);
                        }
                    }


                    ProductoIncentivado.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProductoIncentivadoBE pItem)
        {
            try
            {
                ProductoIncentivadoDL ProductoIncentivado = new ProductoIncentivadoDL();
                ProductoIncentivado.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
