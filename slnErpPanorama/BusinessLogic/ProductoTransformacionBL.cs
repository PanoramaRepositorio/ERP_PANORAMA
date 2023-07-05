using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProductoTransformacionBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ProductoTransformacionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ProductoTransformacionDL ProductoTransformacion = new ProductoTransformacionDL();
                return ProductoTransformacion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProductoTransformacionBE SeleccionaProductoCorrelativo(int IdTienda)
        {
            try
            {
                ProductoTransformacionDL ProductoTransformacion = new ProductoTransformacionDL();
                return ProductoTransformacion.SeleccionaProductoCorrelativo(IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProductoTransformacionBE pItem, List<ProductoTransformacionDetalleBE> pListaProductoTransformacionDetalle, MovimientoAlmacenBE pItemMovimiento, List<MovimientoAlmacenDetalleBE> pListaMovimientoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProductoTransformacionDL ProductoTransformacion = new ProductoTransformacionDL();
                    ProductoTransformacionDetalleDL ProductoTransformacionDetalle = new ProductoTransformacionDetalleDL();

                    ////Nota de Ingreso Por Ajuste
                    int IdMovimientoAlmacen = 0;
                    MovimientoAlmacenBL MovimientoAlmacen = new MovimientoAlmacenBL();
                    IdMovimientoAlmacen = MovimientoAlmacen.Inserta(pItemMovimiento, pListaMovimientoDetalle);
                    pItem.IdMovimientoAlmacen = IdMovimientoAlmacen;

                    int IdProductoTransformacion = 0;
                    IdProductoTransformacion = ProductoTransformacion.Inserta(pItem);

                    foreach (ProductoTransformacionDetalleBE item in pListaProductoTransformacionDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdProductoTransformacion = IdProductoTransformacion;
                        ProductoTransformacionDetalle.Inserta(item);
                    }

                    //Actualizar Lista de precio
                    List<ListaPrecioDetalleBE> mListaPrecioDetalle = new List<ListaPrecioDetalleBE>();

                    ListaPrecioDetalleBE objE_ListaPrecioDetalle = new ListaPrecioDetalleBE();
                    objE_ListaPrecioDetalle.IdListaPrecio = 1;
                    objE_ListaPrecioDetalle.CodigoProveedor = pItem.Codigo;
                    objE_ListaPrecioDetalle.IdProducto = pItem.IdProducto;
                    objE_ListaPrecioDetalle.PrecioCD = pItem.PrecioDolar;
                    objE_ListaPrecioDetalle.PrecioAB = pItem.PrecioDolar;
                    objE_ListaPrecioDetalle.Descuento = 0;
                    objE_ListaPrecioDetalle.Maquina = pItem.Maquina;
                    objE_ListaPrecioDetalle.Usuario = pItem.Usuario;
                    objE_ListaPrecioDetalle.IdEmpresa = Parametros.intEmpresaId;
                    objE_ListaPrecioDetalle.FlagEstado = true;
                    mListaPrecioDetalle.Add(objE_ListaPrecioDetalle);

                    ListaPrecioDetalleBL objBL_ListaPrecioDetalle = new ListaPrecioDetalleBL();
                    objBL_ListaPrecioDetalle.ActualizaMasivo(mListaPrecioDetalle, true);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProductoTransformacionBE pItem, List<ProductoTransformacionDetalleBE> pListaProductoTransformacionDetalle, MovimientoAlmacenBE pItemMovimiento, List<MovimientoAlmacenDetalleBE> pListaMovimientoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProductoTransformacionDL ProductoTransformacion = new ProductoTransformacionDL();
                    ProductoTransformacionDetalleDL ProductoTransformacionDetalle = new ProductoTransformacionDetalleDL();

                    //Nota de Salida
                    MovimientoAlmacenBL MovimientoAlmacen = new MovimientoAlmacenBL();
                    MovimientoAlmacenBE objE_MovimientoAlmacen = new MovimientoAlmacenBE();

                    int Cantidad = pListaMovimientoDetalle[0].Cantidad;
                    pItemMovimiento = new MovimientoAlmacenDL().Selecciona(Parametros.intEmpresaId, pItem.IdMovimientoAlmacen);
                    pListaMovimientoDetalle = new MovimientoAlmacenDetalleDL().ListaTodosActivo(Parametros.intEmpresaId, pItem.IdMovimientoAlmacen);
                    pListaMovimientoDetalle[0].Cantidad = Cantidad;

                    MovimientoAlmacen.Actualiza(pItemMovimiento, pListaMovimientoDetalle);

                    foreach (ProductoTransformacionDetalleBE item in pListaProductoTransformacionDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdProductoTransformacion = pItem.IdProductoTransformacion;
                            ProductoTransformacionDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            ProductoTransformacionDetalle.Actualiza(item);
                        }
                    }

                    ProductoTransformacion.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        //public void ActualizaPedido(int IdProductoTransformacion, int IdPedido)
        //{
        //    try
        //    {
        //        ProductoTransformacionDL ProductoTransformacion = new ProductoTransformacionDL();
        //        ProductoTransformacion.ActualizaPedido(IdProductoTransformacion, IdPedido);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        public void Elimina(ProductoTransformacionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProductoTransformacionDL ProductoTransformacion = new ProductoTransformacionDL();
                    ProductoTransformacionDetalleDL ProductoTransformacionDetalle = new ProductoTransformacionDetalleDL();

                    List<ProductoTransformacionDetalleBE> lstProductoTransformacionDetalle = null;
                    lstProductoTransformacionDetalle = ProductoTransformacionDetalle.ListaTodosActivo(pItem.IdProductoTransformacion);

                    foreach (ProductoTransformacionDetalleBE item in lstProductoTransformacionDetalle)
                    {
                        ProductoTransformacionDetalle.Elimina(item);
                    }

                    //Eliminamos el Solicitud Principal
                    ProductoTransformacion.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
