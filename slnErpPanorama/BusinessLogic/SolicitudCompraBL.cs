using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class SolicitudCompraBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<SolicitudCompraBE> ListaTodosActivo(int IdEmpresa, int Periodo)
        {
            try
            {
                SolicitudCompraDL SolicitudCompra = new SolicitudCompraDL();
                return SolicitudCompra.ListaTodosActivo(IdEmpresa,Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudCompraBE> ListaProveedor(int IdEmpresa, int IdProveedor, string NumeroDocumento)
        {
            try
            {
                SolicitudCompraDL SolicitudCompra = new SolicitudCompraDL();
                return SolicitudCompra.ListaProveedor(IdEmpresa, IdProveedor, NumeroDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudCompraBE Selecciona(int IdEmpresa, int IdSolicitudCompra)
        {
            try
            {
                SolicitudCompraDL SolicitudCompra = new SolicitudCompraDL();
                return SolicitudCompra.Selecciona(IdEmpresa, IdSolicitudCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudCompraBE SeleccionaNumero(int IdProveedor, string Numero)
        {
            try
            {
                SolicitudCompraDL SolicitudCompra = new SolicitudCompraDL();
                return SolicitudCompra.SeleccionaNumero(IdProveedor, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SolicitudCompraBE pItem, List<SolicitudCompraDetalleBE> pListaSolicitudCompraDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudCompraDL SolicitudCompra = new SolicitudCompraDL();
                    SolicitudCompraDetalleDL SolicitudCompraDetalle = new SolicitudCompraDetalleDL();
                    Int32 intIdSolicitudCompra = 0;

                    //Insertamos la cabecera de la factura de compra
                    intIdSolicitudCompra = SolicitudCompra.Inserta(pItem);

                    foreach (SolicitudCompraDetalleBE item in pListaSolicitudCompraDetalle)
                    {
                        //Insertamos el producto si no existe
                        int IdProducto = 0;

                         ProductoBE objE_Producto = new ProductoDL().SeleccionaCodigoProveedor(item.IdEmpresa, item.CodigoProveedor);
                        if (objE_Producto == null)
                        {
                            ProductoBE objProducto = new ProductoBE();
                            objProducto.IdProducto = 0;
                            objProducto.IdEmpresa = item.IdEmpresa;
                            objProducto.CodigoProveedor = item.CodigoProveedor;
                            objProducto.CodigoPanorama = "";
                            objProducto.IdUnidadMedida = item.IdUnidadMedida;
                            if (pItem.FlagMuestra == true)
                            {
                                objProducto.IdLineaProducto = 10;
                            }
                            else
                            {
                                objProducto.IdLineaProducto = 0;
                            }
                            objProducto.IdSubLineaProducto = 0;
                            objProducto.IdModeloProducto = 0;
                            objProducto.IdMaterial = 0;
                            objProducto.IdMarca = 1;
                            objProducto.IdProcedencia = 0;
                            objProducto.NombreProducto = item.NombreProducto;
                            objProducto.Descripcion = "";
                            objProducto.Peso = 0;
                            objProducto.Medida = "";
                            objProducto.Imagen = item.Imagen;
                            objProducto.PrecioAB = 0;
                            objProducto.PrecioCD = 0;
                            objProducto.Descuento = 0;
                            objProducto.FlagCompuesto = false;
                            objProducto.FlagObsequio = false;
                            objProducto.FlagEscala = true;
                            objProducto.FlagDestacado = false;
                            objProducto.FlagRecomendado = false;
                            objProducto.Observacion = "Producto insertado de la Solicitud de compra";
                            objProducto.Fecha = pItem.FechaCompra;
                            objProducto.IdTipoProducto = Parametros.intProductoAlmacenable;
                            objProducto.IdSubTipoProducto = 0;
                            objProducto.FlagEstado = true;
                            objProducto.Usuario = pItem.Usuario;
                            objProducto.Maquina = pItem.Maquina;

                            //Nacional
                            if (objProducto.FlagNacional)
                            {
                                objProducto.FlagEscala = false;//add 221215
                                objProducto.FlagNacional = true;                  
                            }


                            IdProducto = new ProductoDL().Inserta(objProducto);
                        }
                        else
                        {
                            //Si existe traemos el IdProduto
                            IdProducto = objE_Producto.IdProducto;

                            if (Parametros.intEmpresaId == Parametros.intPanoraramaDistribuidores)
                            { 
                                //Actualizamos la fecha de compra y el FlagEstado = True
                                ProductoBE objE_ProductoActualiza = new ProductoBE();
                                objE_ProductoActualiza.IdProducto = IdProducto;
                                objE_ProductoActualiza.Fecha = pItem.FechaCompra;

                                ProductoDL objDL_Producto = new ProductoDL();
                                objDL_Producto.ActualizaFecha(objE_ProductoActualiza);                            
                            }

                        }



                        //Insertamos el detalle de la factura de compra
                        item.IdSolicitudCompra = intIdSolicitudCompra;
                        item.IdProducto = IdProducto;
                        SolicitudCompraDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
                
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SolicitudCompraBE pItem, List<SolicitudCompraDetalleBE> pListaSolicitudCompraDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudCompraDL SolicitudCompra = new SolicitudCompraDL();
                    SolicitudCompraDetalleDL SolicitudCompraDetalle = new SolicitudCompraDetalleDL();

                    foreach (SolicitudCompraDetalleBE item in pListaSolicitudCompraDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdSolicitudCompra = pItem.IdSolicitudCompra;
                            SolicitudCompraDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la factura de compra
                            SolicitudCompraDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos la factura de compra
                    SolicitudCompra.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SolicitudCompraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudCompraDL SolicitudCompra = new SolicitudCompraDL();
                    SolicitudCompraDetalleDL SolicitudCompraDetalle = new SolicitudCompraDetalleDL();


                    //tradicional
                    List<SolicitudCompraDetalleBE> lstSolicitudCompraDetalle = null;
                    lstSolicitudCompraDetalle = new SolicitudCompraDetalleDL().ListaTodosActivo(pItem.IdEmpresa, pItem.IdSolicitudCompra);
                    foreach (SolicitudCompraDetalleBE item in lstSolicitudCompraDetalle)
                    {
                        /*
                        //Actualizamos Stock
                        StockDL objDL_Stock = new StockDL();
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                        objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                        objE_Stock.IdProducto = item.IdProducto;
                        objE_Stock.ValorIncrementa = 0;
                        objE_Stock.ValorDescuenta = item.Cantidad;
                        objE_Stock.PrecioCostoPromedio = 0;
                        objE_Stock.CostoTotal = 0;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.ActualizaCantidades(objE_Stock);*/

                        //Elimina el detalle de la factura de compra
                        SolicitudCompraDetalle.Elimina(item);
                    }

                    //Eliminar la factura de compra
                    SolicitudCompra.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaFechaRecepcion(SolicitudCompraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudCompraDL SolicitudCompra = new SolicitudCompraDL();
                  
                    //Eliminar la factura de compra
                    SolicitudCompra.ActualizaFechaRecepcion(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
