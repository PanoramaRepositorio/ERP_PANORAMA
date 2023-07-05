using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;


namespace ErpPanorama.BusinessLogic
{
    public class ProductoFotoBL
    {
        public List<ProductoFotoBE> ListaTodosActivo(int IdProducto)
        {
            try
            {
                ProductoFotoDL ProductoFotol = new ProductoFotoDL();
                return ProductoFotol.ListaTodosActivo(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProductoFotoBE pItem)
        {
            try
            {
                ProductoFotoDL ProductoFoto = new ProductoFotoDL();
                ProductoFoto.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProductoFotoBE pItem)
        {
            try
            {
                ProductoFotoDL ProductoFoto = new ProductoFotoDL();
                ProductoFoto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaVarios(ProductoFotoBE pItem)
        {
            try
            {
               using (TransactionScope ts = new TransactionScope())
                {
                    if (pItem != null)
                    {
                        ProductoBE obj_ProductoBE = null;
                        ProductoDL Producto = new ProductoDL();
                        obj_ProductoBE = Producto.SeleccionaIDTodos(pItem.IdProducto);

                        if (obj_ProductoBE != null) //Verifica si Existe el producto
                        {
                            ProductoFotoBE obj_ProductoFotoBE = null;
                            ProductoFotoDL ProductoFoto = new ProductoFotoDL();
                            obj_ProductoFotoBE = ProductoFoto.Selecciona(pItem.IdProducto);

                            if (obj_ProductoFotoBE == null)
                            {
                                ProductoFoto.Inserta(pItem);

                            }
                            else 
                            {
                                if(pItem.Frontal != null)
                                {
                                    pItem.IdProductoFoto = obj_ProductoFotoBE.IdProductoFoto;
                                    pItem.Lateral = obj_ProductoFotoBE.Lateral;
                                    pItem.Trasera = obj_ProductoFotoBE.Trasera;
                                    pItem.FlagEstado = true;
                                }
                                else if (pItem.Lateral != null)
                                {
                                    pItem.IdProductoFoto = obj_ProductoFotoBE.IdProductoFoto;
                                    pItem.Frontal = obj_ProductoFotoBE.Frontal;
                                    pItem.Trasera = obj_ProductoFotoBE.Trasera;
                                    pItem.FlagEstado = true;
                                }
                                else if (pItem.Trasera != null)
                                {
                                    pItem.IdProductoFoto = obj_ProductoFotoBE.IdProductoFoto;
                                    pItem.Frontal = obj_ProductoFotoBE.Frontal;
                                    pItem.Lateral = obj_ProductoFotoBE.Lateral;
                                    pItem.FlagEstado = true;
                                }
                              ProductoFoto.Actualiza(pItem);
                            }
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProductoFotoBE pItem)
        {
            try
            {
                ProductoFotoDL ProductoFoto = new ProductoFotoDL();
                ProductoFoto.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
