using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProductoAsociadoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ProductoAsociadoBE> ListaTodosActivo(int IdProducto)
        {
            try
            {
                ProductoAsociadoDL ProductoAsociado = new ProductoAsociadoDL();
                return ProductoAsociado.ListaTodosActivo(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProductoComponenteBE> ListaTodosActivoComponente(int IdProducto)
        {
            try
            {
                ProductoAsociadoDL ProductoAsociado = new ProductoAsociadoDL();
                return ProductoAsociado.ListaTodosActivoComponente(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ProductoAsociadoBE pItem)
        {
            try
            {
                ProductoAsociadoDL ProductoAsociado = new ProductoAsociadoDL();
                ProductoAsociado.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(List<ProductoAsociadoBE> pListaItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProductoAsociadoDL ProductoAsociado = new ProductoAsociadoDL();

                    foreach (ProductoAsociadoBE item in pListaItem)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            ProductoAsociado.Inserta(item);
                        }
                        else //if (item.TipoOper == Convert.ToInt32(Operacion.Modificar))
                        {
                            ProductoAsociado.Actualiza(item);
                        }
                        //else
                        //{
                        //    //Actualizamos el detalle de la solicitud de producto
                        //    ProductoAsociadoDetalle.Actualiza(item);
                        //}
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta2(List<ProductoAsociadoBE> pListaItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProductoAsociadoDL ProductoAsociado = new ProductoAsociadoDL();

                    foreach (ProductoAsociadoBE item in pListaItem)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            ProductoAsociado.Inserta2(item);
                        }
                        else //if (item.TipoOper == Convert.ToInt32(Operacion.Modificar))
                        {
                            ProductoAsociado.Actualiza(item);
                        }
                        //else
                        //{
                        //    //Actualizamos el detalle de la solicitud de producto
                        //    ProductoAsociadoDetalle.Actualiza(item);
                        //}
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void Actualiza(ProductoAsociadoBE pItem)
        {
            try
            {
                ProductoAsociadoDL ProductoAsociado = new ProductoAsociadoDL();
                ProductoAsociado.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProductoAsociadoBE pItem)
        {
            try
            {
                ProductoAsociadoDL ProductoAsociado = new ProductoAsociadoDL();
                ProductoAsociado.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
