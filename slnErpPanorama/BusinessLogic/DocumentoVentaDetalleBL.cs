using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DocumentoVentaDetalleBL
    {
        public List<DocumentoVentaDetalleBE> ListaTodosActivo(int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                return DocumentoVentaDetalle.ListaTodosActivo(IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }



        public List<DocumentoVentaDetalleBE> ListaTodosActivoFE(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                return DocumentoVentaDetalle.ListaTodosActivoFE(IdEmpresa, IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaDetalleBE> ListaTodosActivoFE_RER(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                return DocumentoVentaDetalle.ListaTodosActivoFE_RER(IdEmpresa, IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaDetalleBE> ListaPedido(int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                return DocumentoVentaDetalle.ListaPedido(IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        
        public void Inserta(DocumentoVentaDetalleBE pItem)
        {
            try
            {
                DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                DocumentoVentaDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DocumentoVentaDetalleBE pItem)
        {
            try
            {
                DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                DocumentoVentaDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DocumentoVentaDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Eliminar el detalle del pedido
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaDetalle.Elimina(pItem);

                    int IdKardex = 0;

                    //Establecemos el almacen correspondiente de acuerdo a la tienda
                    int IdAlmacen = 0;

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                    {
                        IdAlmacen = Parametros.intAlmCentral;
                    }

                    if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                    {
                        IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                    }

                    if (pItem.IdTienda == Parametros.intTiendaKonceptos) IdAlmacen = Parametros.intAlmAnaquelesKonceptos;

                    if (pItem.IdDocumentoVentaDetalle != 0)
                    {
                        //Insertar Kardex
                        KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = 0;
                        objE_Kardex.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                        objE_Kardex.Periodo = pItem.Periodo;
                        objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        objE_Kardex.IdAlmacen = IdAlmacen;
                        objE_Kardex.IdProducto = pItem.IdProducto;
                        objE_Kardex.Cantidad = pItem.Cantidad;
                        objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                        objE_Kardex.NumeroDocumento = pItem.Numero;
                        objE_Kardex.Observacion = "Ingreso Por Eliminación de Pedido de Venta";
                        objE_Kardex.TipoMovimiento = "I";
                        objE_Kardex.MontoUnitarioCompra = pItem.ValorVenta;
                        objE_Kardex.PrecioCostoPromedio = 0;
                        objE_Kardex.MontoTotalCompra = 0;
                        objE_Kardex.FlagEstado = true;
                        objE_Kardex.Usuario = pItem.Usuario;
                        objE_Kardex.Maquina = pItem.Maquina;

                        KardexBE objE_KardexValorizado = new KardexBE();
                        objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, IdAlmacen, pItem.IdProducto);

                        if (objE_KardexValorizado != null)
                        {
                            objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                            objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * pItem.Cantidad;
                        }

                        KardexDL objDL_Kardex = new KardexDL();
                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, IdAlmacen, pItem.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                            objE_Stock.IdAlmacen = IdAlmacen;
                            objE_Stock.IdProducto = pItem.IdProducto;
                            objE_Stock.ValorIncrementa = pItem.Cantidad;
                            objE_Stock.ValorDescuenta = 0;
                            objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.ActualizaCantidades(objE_Stock);
                        }
                        else
                        {
                            //Insertamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdStock = 0;
                            objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = IdAlmacen;
                            objE_Stock.IdProducto = pItem.IdProducto;
                            objE_Stock.Cantidad = pItem.Cantidad;
                            objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }
                    }
                    
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaFisico(DocumentoVentaDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Eliminar el detalle del pedido
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaDetalle.EliminaFisico(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaDetalleBE> ListaEmpresaTraslado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                return DocumentoVentaDetalle.ListaEmpresaTraslado(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}

