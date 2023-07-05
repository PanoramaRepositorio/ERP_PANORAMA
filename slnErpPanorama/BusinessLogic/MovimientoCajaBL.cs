using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MovimientoCajaBL
    {
        public List<MovimientoCajaBE> ListaTodosActivo(int IdCaja, DateTime Fecha)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                return MovimientoCaja.ListaTodosActivo(IdCaja, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoCajaBE> ListaTodasCajas(int Anio, int Mes)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                return MovimientoCaja.ListaTodasCajas(Anio, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoCajaBE> ListaDocumentoVenta(int IdDocumentoVenta)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                return MovimientoCaja.ListaDocumentoVenta(IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoCajaBE> ListaPedido(int IdPedido)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                return MovimientoCaja.ListaPedido(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoCajaBE> ListaPagos(int IdPago)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                return MovimientoCaja.ListaPagos(IdPago);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoCajaBE> ListaFormaPago(int IdDocumentoVenta)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                return MovimientoCaja.ListaFormaPago(IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoCajaBE Selecciona(int IdMovimientoCaja)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                MovimientoCajaBE objEmp = MovimientoCaja.Selecciona(IdMovimientoCaja);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoCajaBE SeleccionaSolicitudPrestamo(int IdSolicitudPrestamo)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                MovimientoCajaBE objEmp = MovimientoCaja.SeleccionaSolicitudPrestamo(IdSolicitudPrestamo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoCajaBE SeleccionaNumero(int IdEmpresa, int IdTipoDocumento, string NumeroDocumento)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                MovimientoCajaBE objEmp = MovimientoCaja.SeleccionaNumero(IdEmpresa, IdTipoDocumento, NumeroDocumento);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(MovimientoCajaBE pItem)
        {
            try
            {
                //int IdMovimientoCaja = 0;
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                return MovimientoCaja.Inserta(pItem);
                //return IdMovimientoCaja;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MovimientoCajaBE pItem)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                MovimientoCaja.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaEstado(int IdMovimientoCaja)
        {
            try
            {
                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                MovimientoCaja.ActualizaEstado(IdMovimientoCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void RecuperaDocumentoVenta(MovimientoCajaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    bool bTienePedido = true;
                    DocumentoVentaBE objBE_Documento = new DocumentoVentaBE();
                    objBE_Documento = new DocumentoVentaDL().Selecciona(Convert.ToInt32(pItem.IdDocumentoVenta));
                    if (objBE_Documento != null)
                    {
                        //Verificamos si tiene Pedido
                        if (objBE_Documento.IdPedido != null)
                        {
                            //Anulamos el pedido
                            PedidoDL objDL_Pedido = new PedidoDL();
                            objDL_Pedido.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(objBE_Documento.IdPedido), Parametros.intFacturado,0,"CAJA",pItem.Usuario,pItem.Maquina);
                            bTienePedido = true;
                        }
                        else
                        {
                            bTienePedido = false;
                        }
                    }

                    //Hacemos el movimiento para el detalle del kardex
                    List<DocumentoVentaDetalleBE> ListaDocumentoVentaDetalle = null;
                    ListaDocumentoVentaDetalle = new DocumentoVentaDetalleDL().ListaTodosActivo(Convert.ToInt32(pItem.IdDocumentoVenta));
                    foreach (DocumentoVentaDetalleBE item in ListaDocumentoVentaDetalle)
                    {
                        /*int IdKardex = 0;

                        //Establecemos el almacen correspondiente de acuerdo a la tienda
                        int IdAlmacen = 0;

                        if (objBE_Documento.IdTienda == Parametros.intTiendaUcayali)
                        {
                            if (bTienePedido)
                            {
                                IdAlmacen = Parametros.intAlmCentral;
                            }
                            else
                            {
                                IdAlmacen = Parametros.intAlmTiendaUcayali;
                            }
                        }

                        if (objBE_Documento.IdTienda == Parametros.intTiendaAndahuaylas)
                        {
                            IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                        }

                        if (objBE_Documento.IdTienda == Parametros.intTiendaKonceptos) IdAlmacen = Parametros.intAlmAnaquelesKonceptos;

                        //Insertar Kardex
                        KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = 0;
                        objE_Kardex.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                        objE_Kardex.Periodo = objBE_Documento.Periodo;
                        objE_Kardex.FechaMovimiento = objBE_Documento.Fecha;
                        objE_Kardex.IdAlmacen = IdAlmacen;
                        objE_Kardex.IdProducto = item.IdProducto;
                        objE_Kardex.Cantidad = item.Cantidad;
                        objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                        objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                        objE_Kardex.Observacion = "Salida por Documento de Venta";
                        objE_Kardex.TipoMovimiento = "S";
                        objE_Kardex.MontoUnitarioCompra = item.ValorVenta;
                        objE_Kardex.PrecioCostoPromedio = 0;
                        objE_Kardex.MontoTotalCompra = 0;
                        objE_Kardex.FlagEstado = true;
                        objE_Kardex.Usuario = pItem.Usuario;
                        objE_Kardex.Maquina = pItem.Maquina;

                        KardexBE objE_KardexValorizado = new KardexBE();
                        objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intIdPanoramaDistribuidores, objBE_Documento.IdTienda, IdAlmacen, item.IdProducto);

                        if (objE_KardexValorizado != null)
                        {
                            objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                            objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                        }

                        KardexDL objDL_Kardex = new KardexDL();
                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(Parametros.intIdPanoramaDistribuidores, objBE_Documento.IdTienda, IdAlmacen, item.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                            objE_Stock.IdAlmacen = IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = 0;
                            objE_Stock.ValorDescuenta = item.Cantidad;
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
                            objE_Stock.Periodo = objBE_Documento.Periodo;
                            objE_Stock.IdAlmacen = IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }*/
                    }

                    //Recupera el Documento de Venta
                    DocumentoVentaDL objDL_DocumentoVenta = new DocumentoVentaDL();
                    objDL_DocumentoVenta.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdDocumentoVenta), Parametros.intDVCancelado);

                    //Recupera el movimiento de caja
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    MovimientoCaja.ActualizaEstado(Convert.ToInt32(pItem.IdMovimientoCaja));

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MovimientoCajaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    bool bTienePedido = true;

                    DocumentoVentaBE objBE_Documento = new DocumentoVentaBE();
                    objBE_Documento = new DocumentoVentaDL().Selecciona(Convert.ToInt32(pItem.IdDocumentoVenta));
                    if (objBE_Documento != null)
                    {
                        if(objBE_Documento.IdTipoDocumento==Parametros.intTipoDocNotaCredito|| objBE_Documento.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                        {
                            //Eliminar 
                        }else
                        {
                            //Verificamos si tiene Pedido 
                            if (objBE_Documento.IdPedido != null)
                            {
                                //Anulamos el pedido
                                PedidoDL objDL_Pedido = new PedidoDL();
                                objDL_Pedido.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(objBE_Documento.IdPedido), Parametros.intPVGenerado, 0, "CAJA", pItem.Usuario, pItem.Maquina);
                                bTienePedido = true;
                            }
                            else
                            {
                                bTienePedido = false;

                                //Hacemos el movimiento para el detalle del kardex //add 130815
                                List<DocumentoVentaDetalleBE> ListaDocumentoVentaDetalle = null;
                                ListaDocumentoVentaDetalle = new DocumentoVentaDetalleDL().ListaTodosActivo(Convert.ToInt32(pItem.IdDocumentoVenta));
                                foreach (DocumentoVentaDetalleBE item in ListaDocumentoVentaDetalle)
                                {
                                    //int IdKardex = 0;

                                    //Establecemos el almacen correspondiente de acuerdo a la tienda
                                    int IdAlmacen = 0;

                                    if (objBE_Documento.IdTienda == Parametros.intTiendaUcayali)
                                    {
                                        if (bTienePedido)
                                        {
                                            IdAlmacen = Parametros.intAlmCentral;
                                        }
                                        else
                                        {
                                            IdAlmacen = Parametros.intAlmTiendaUcayali;
                                        }
                                    }

                                    if (objBE_Documento.IdTienda == Parametros.intTiendaAndahuaylas)
                                    {
                                        IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                                    }

                                    if (objBE_Documento.IdTienda == Parametros.intTiendaKonceptos) IdAlmacen = Parametros.intAlmAnaquelesKonceptos;
                                    if (objBE_Documento.IdTienda == Parametros.intTiendaPrescott) IdAlmacen = Parametros.intAlmPrescott;

                                    //Verificar el stock
                                    List<StockBE> lstStock = new List<StockBE>();
                                    StockDL objDL_Stock = new StockDL();
                                    lstStock = objDL_Stock.ListaProducto(Parametros.intIdPanoramaDistribuidores, objBE_Documento.IdTienda, IdAlmacen, item.IdProducto);
                                    if (lstStock.Count > 0)
                                    {
                                        //Actualizamos Stock
                                        StockBE objE_Stock = new StockBE();
                                        objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                                        objE_Stock.IdAlmacen = IdAlmacen;
                                        objE_Stock.IdProducto = item.IdProducto;
                                        objE_Stock.ValorIncrementa = item.Cantidad;
                                        objE_Stock.ValorDescuenta = 0;
                                        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                        objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
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
                                        objE_Stock.Periodo = objBE_Documento.Periodo;
                                        objE_Stock.IdAlmacen = IdAlmacen;
                                        objE_Stock.IdProducto = item.IdProducto;
                                        objE_Stock.Cantidad = item.Cantidad;
                                        objE_Stock.PrecioCostoPromedio = 0; //objE_Kardex.PrecioCostoPromedio;
                                        objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                                        objE_Stock.FlagEstado = true;
                                        objE_Stock.Usuario = pItem.Usuario;
                                        objE_Stock.Maquina = pItem.Maquina;

                                        objDL_Stock.Inserta(objE_Stock);
                                    }
                                }
                            }

                            //Anulamos el Documento de Venta
                            DocumentoVentaDL objDL_DocumentoVenta = new DocumentoVentaDL();
                            objDL_DocumentoVenta.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdDocumentoVenta), Parametros.intDVAnulado);
                        }
                    }

                    #region "Anterior"
                    
                    ////Hacemos el movimiento para el detalle del kardex
                    //List<DocumentoVentaDetalleBE> ListaDocumentoVentaDetalle = null;
                    //ListaDocumentoVentaDetalle = new DocumentoVentaDetalleDL().ListaTodosActivo(Convert.ToInt32(pItem.IdDocumentoVenta));
                    //foreach (DocumentoVentaDetalleBE item in ListaDocumentoVentaDetalle)
                    //{
                    //    //int IdKardex = 0;

                    //    //Establecemos el almacen correspondiente de acuerdo a la tienda
                    //    int IdAlmacen = 0;

                    //    if (objBE_Documento.IdTienda == Parametros.intTiendaUcayali)
                    //    {
                    //        if (bTienePedido)
                    //        {
                    //            IdAlmacen = Parametros.intAlmCentral;
                    //        }
                    //        else
                    //        {
                    //            IdAlmacen = Parametros.intAlmTiendaUcayali;
                    //        }
                            
                    //    }

                    //    if (objBE_Documento.IdTienda == Parametros.intTiendaAndahuaylas)
                    //    {
                    //        IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                    //    }

                    //    if (objBE_Documento.IdTienda == Parametros.intTiendaKonceptos) IdAlmacen = Parametros.intAlmAnaquelesKonceptos;
                    //    if (objBE_Documento.IdTienda == Parametros.intTiendaPrescott) IdAlmacen = Parametros.intAlmPrescott;


                    //    ////Insertar Kardex
                    //    //KardexBE objE_Kardex = new KardexBE();
                    //    //objE_Kardex.IdKardex = 0;
                    //    //objE_Kardex.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                    //    //objE_Kardex.Periodo = objBE_Documento.Periodo;
                    //    //objE_Kardex.FechaMovimiento = objBE_Documento.Fecha;
                    //    //objE_Kardex.IdAlmacen = IdAlmacen;
                    //    //objE_Kardex.IdProducto = item.IdProducto;
                    //    //objE_Kardex.Cantidad = item.Cantidad;
                    //    //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                    //    //objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                    //    //objE_Kardex.Observacion = "Ingreso por Anulación de Documento de Venta";
                    //    //objE_Kardex.TipoMovimiento = "I";
                    //    //objE_Kardex.MontoUnitarioCompra = item.ValorVenta;
                    //    //objE_Kardex.PrecioCostoPromedio = 0;
                    //    //objE_Kardex.MontoTotalCompra = 0;
                    //    //objE_Kardex.FlagEstado = true;
                    //    //objE_Kardex.Usuario = pItem.Usuario;
                    //    //objE_Kardex.Maquina = pItem.Maquina;

                    //    //KardexBE objE_KardexValorizado = new KardexBE();
                    //    //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intIdPanoramaDistribuidores, objBE_Documento.IdTienda, IdAlmacen, item.IdProducto);

                    //    //if (objE_KardexValorizado != null)
                    //    //{
                    //    //    objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                    //    //    objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                    //    //}

                    //    //KardexDL objDL_Kardex = new KardexDL();
                    //    //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                    //    //Verificar el stock
                    //    List<StockBE> lstStock = new List<StockBE>();
                    //    StockDL objDL_Stock = new StockDL();
                    //    lstStock = objDL_Stock.ListaProducto(Parametros.intIdPanoramaDistribuidores, objBE_Documento.IdTienda, IdAlmacen, item.IdProducto);
                    //    if (lstStock.Count > 0)
                    //    {
                    //        //Actualizamos Stock
                    //        StockBE objE_Stock = new StockBE();
                    //        objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                    //        objE_Stock.IdAlmacen = IdAlmacen;
                    //        objE_Stock.IdProducto = item.IdProducto;
                    //        objE_Stock.ValorIncrementa = item.Cantidad;
                    //        objE_Stock.ValorDescuenta = 0;
                    //        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                    //        objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                    //        objE_Stock.Usuario = pItem.Usuario;
                    //        objE_Stock.Maquina = pItem.Maquina;

                    //        objDL_Stock.ActualizaCantidades(objE_Stock);
                    //    }
                    //    else
                    //    {
                    //        //Insertamos Stock
                    //        StockBE objE_Stock = new StockBE();
                    //        objE_Stock.IdStock = 0;
                    //        objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                    //        objE_Stock.Periodo = objBE_Documento.Periodo;
                    //        objE_Stock.IdAlmacen = IdAlmacen;
                    //        objE_Stock.IdProducto = item.IdProducto;
                    //        objE_Stock.Cantidad = item.Cantidad;
                    //        objE_Stock.PrecioCostoPromedio = 0; //objE_Kardex.PrecioCostoPromedio;
                    //        objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                    //        objE_Stock.FlagEstado = true;
                    //        objE_Stock.Usuario = pItem.Usuario;
                    //        objE_Stock.Maquina = pItem.Maquina;

                    //        objDL_Stock.Inserta(objE_Stock);
                    //    }
                    //}

                    #endregion

                    ////Anulamos el Documento de Venta
                    //DocumentoVentaDL objDL_DocumentoVenta = new DocumentoVentaDL();
                    //objDL_DocumentoVenta.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdDocumentoVenta), Parametros.intDVAnulado);

                    //Anulamos el movimiento de caja
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    MovimientoCaja.Elimina(pItem);

                    //Anulamos Pago de Horas Extras
                    HoraExtraBL objBL_HoraExtra = new HoraExtraBL();
                    objBL_HoraExtra.ActualizaEliminaMovimientoCaja(pItem.IdMovimientoCaja);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}