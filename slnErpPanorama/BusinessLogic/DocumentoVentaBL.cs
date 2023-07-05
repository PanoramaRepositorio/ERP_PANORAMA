using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DocumentoVentaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<DocumentoVentaBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaTodosActivo(IdEmpresa, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> Lista(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.Lista(IdEmpresa, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaGeneral(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaGeneral(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaGeneralPD(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaGeneralPD(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<DocumentoVentaBE> ListaGeneralDetalle(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaGeneralDetalle(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaVendedor(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaVendedor(IdVendedor, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaSerieNumero(int IdTipoDocumento, string Serie, string Numero)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaSerieNumero(IdTipoDocumento, Serie, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListadoPedido(int IdPedido)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListadoPedido(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListadoPedidoConta(int IdPedido)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListadoPedidoConta(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaDescuentoProxima(int IdCliente, int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaDescuentoProxima(IdCliente, IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaMesCumpleanos(int Anio, int Mes, int IdCliente)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaMesCumpleanos(Anio,Mes,IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaEmpresaPeriodo(int Periodo)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaEmpresaPeriodo(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaEmpresaPeriodo_VentaRER(int Periodo)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaEmpresaPeriodoVentasa_RER(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaConsolidadoComercioAmigo(string Periodo)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaConsolidadoComercioAmigo(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaPeriodoGeneral(int Periodo)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaPeriodoGeneral(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaPeriodoCobranzas(int Periodo)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaPeriodoCobranzas(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaPeriodoTiendas(int Periodo)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaPeriodoTiendas(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> CanalesVentas(int Periodo)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaCanalesVentas(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaEmpresaFecha(int IdRegimenTributario, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaEmpresaFecha(IdRegimenTributario, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaProducto(int IdProducto, DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaProducto(IdProducto, FechaDesde, FechaHasta, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaComparaCabeceraDetalle(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaComparaCabeceraDetalle(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> SeleccionaPedido(int IdPedido)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.SeleccionaPedido(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE Selecciona(int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.Selecciona(IdDocumentoVenta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE SeleccionaEnvioValido(int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaEnvioValido(IdDocumentoVenta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE SeleccionaEnvioValido_RER(int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaEnvioValido_RER(IdDocumentoVenta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public DocumentoVentaBE SeleccionaGanador22(int IdTienda)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaGanador22(IdTienda);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE SeleccionaFE(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaFE(IdEmpresa, IdDocumentoVenta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE SeleccionaFE_RER(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaFE_RER(IdEmpresa, IdDocumentoVenta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public DocumentoVentaBE SeleccionaGuiaFE(int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaGuiaFE(IdDocumentoVenta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE SeleccionaGuiaFETicket(int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaGuiaFETicket(IdDocumentoVenta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE SeleccionaSerieNumero(int IdEmpresa, int IdTipoDocumento, string Serie, string Numero)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaSerieNumero(IdEmpresa, IdTipoDocumento,Serie,Numero);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE SeleccionaTotalCambio(int IdEmpresa, int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaTotalCambio(IdEmpresa, IdDocumentoVenta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE SeleccionaEmpresaPeriodo(int IdEmpresa, int Periodo, int Mes)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaEmpresaPeriodo(IdEmpresa, Periodo, Mes);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE SeleccionaEmpresaPeriodoDia(int IdEmpresa, int Periodo, int Mes)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaEmpresaPeriodoDia(IdEmpresa, Periodo, Mes);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public DocumentoVentaBE SeleccionaEmpresaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVentaBE objEmp = DocumentoVenta.SeleccionaEmpresaFecha(IdEmpresa, FechaDesde, FechaHasta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        #region "Autoservicio"

        public Int32 InsertaAutoservicio(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle, MovimientoCajaBE pCajaBE, List<DocumentoVentaPagoBE> pListaDocumentoVentaPago)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    if (pItem.IdTipoDocumento == Parametros.intTipoDocTicketBoleta || pItem.IdTipoDocumento == Parametros.intTipoDocTicketFactura)
                    {
                        PromocionProximaBE objE_PromocionProxima = null;
                        objE_PromocionProxima = new PromocionProximaBL().SeleccionaActivo(pItem.IdTienda, pItem.IdFormaPago, pItem.IdTipoCliente, pItem.Total);//pItem.IdTipoCliente);
                        if (objE_PromocionProxima != null)
                            pItem.IdPromocionProxima = objE_PromocionProxima.IdPromocionProxima;
                    }

                    //Insertar Documento Venta
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = DocumentoVenta.Inserta(pItem);

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                    {
                        pItem.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    }

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                       
                        //int IdKardex = 0;
                        ////Insertar Kardex
                        //KardexBE objE_Kardex = new KardexBE();
                        //objE_Kardex.IdKardex = 0;
                        //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                        //objE_Kardex.Periodo = pItem.Periodo;
                        //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        //objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                        //objE_Kardex.IdProducto = item.IdProducto;
                        //objE_Kardex.Cantidad = item.Cantidad;
                        //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                        //objE_Kardex.NumeroDocumento = pItem.Numero;
                        //objE_Kardex.Observacion = "Salida Por Documento de Venta - Autoservicio";
                        //objE_Kardex.TipoMovimiento = "S";
                        //objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                        //objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                        //objE_Kardex.MontoTotalCompra = item.ValorVenta;
                        //objE_Kardex.FlagEstado = true;
                        //objE_Kardex.Usuario = pItem.Usuario;
                        //objE_Kardex.Maquina = pItem.Maquina;

                        //KardexBE objE_KardexValorizado = new KardexBE();
                        //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                        //if (objE_KardexValorizado != null)
                        //{
                        //    objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                        //    objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                        //}

                        //KardexDL objDL_Kardex = new KardexDL();
                        //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = 0;
                            objE_Stock.ValorDescuenta = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0; //objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.ActualizaCantidades(objE_Stock);
                        }
                        else
                        {
                            //Insertamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdStock = 0;
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0; // objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }

                        //Insertamos el detalle del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        item.IdKardex = 0;//IdKardex;
                        DocumentoVentaDetalle.Inserta(item);
                    }

                    //Insertamos el movimiento de caja
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    pCajaBE.IdDocumentoVenta = IdDocumentoVenta;
                    MovimientoCaja.Inserta(pCajaBE);

                    foreach (DocumentoVentaPagoBE item in pListaDocumentoVentaPago)
                    {
                        //Insertamos el pago del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        DocumentoVentaPago.Inserta(item);
                    }

                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoSerie(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Serie);

                    ts.Complete();

                    return IdDocumentoVenta;

                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaAutoservicio(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle, MovimientoCajaBE pCajaBE, List<DocumentoVentaPagoBE> pListaDocumentoVentaPago)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                    {
                        pItem.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    }

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //int IdKardex = 0;
                            ////Insertar Kardex
                            //KardexBE objE_Kardex = new KardexBE();
                            //objE_Kardex.IdKardex = 0;
                            //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            //objE_Kardex.Periodo = pItem.Periodo;
                            //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            //objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                            //objE_Kardex.IdProducto = item.IdProducto;
                            //objE_Kardex.Cantidad = item.Cantidad;
                            //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                            //objE_Kardex.NumeroDocumento = pItem.Numero;
                            //objE_Kardex.Observacion = "Salida Por Documento de Venta - Autoservicio";
                            //objE_Kardex.TipoMovimiento = "S";
                            //objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                            //objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                            //objE_Kardex.MontoTotalCompra = item.ValorVenta;
                            //objE_Kardex.FlagEstado = true;
                            //objE_Kardex.Usuario = pItem.Usuario;
                            //objE_Kardex.Maquina = pItem.Maquina;

                            //KardexBE objE_KardexValorizado = new KardexBE();
                            //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                            //if (objE_KardexValorizado != null)
                            //{
                            //    objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                            //    objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                            //}

                            //KardexDL objDL_Kardex = new KardexDL();
                            //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = pItem.IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = 0;
                                objE_Stock.ValorDescuenta = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.ActualizaCantidades(objE_Stock);
                            }
                            else
                            {
                                //Insertamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdStock = 0;
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = pItem.IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;//objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }

                            //Insertamos el detalle del documento de venta
                            item.IdDocumentoVenta = pItem.IdDocumentoVenta;
                            item.IdKardex = 0;//IdKardex;
                            DocumentoVentaDetalle.Inserta(item);
                        }
                        else
                        {
                            ////Actualizar Kardex
                            //KardexBE objE_Kardex = new KardexBE();
                            //objE_Kardex.IdKardex = Convert.ToInt32(item.IdKardex);
                            //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            //objE_Kardex.Periodo = pItem.Periodo;
                            //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            //objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                            //objE_Kardex.IdProducto = item.IdProducto;
                            //objE_Kardex.Cantidad = item.Cantidad;
                            //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                            //objE_Kardex.NumeroDocumento = pItem.Numero;
                            //objE_Kardex.Observacion = "Salida Por Documento de Venta";
                            //objE_Kardex.TipoMovimiento = "S";
                            //objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                            //objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                            //objE_Kardex.MontoTotalCompra = item.ValorVenta;
                            //objE_Kardex.FlagEstado = true;
                            //objE_Kardex.Usuario = pItem.Usuario;
                            //objE_Kardex.Maquina = pItem.Maquina;

                            //KardexBE objE_KardexValorizado = new KardexBE();
                            //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                            //if (objE_KardexValorizado != null)
                            //{
                            //    decimal dmlPCP = 0;
                            //    decimal dmlCostoTotal = 0;

                            //    if (objE_KardexValorizado.Saldo != 0)
                            //    {
                            //        //Calcula Precio Costo Promedio
                            //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                            //        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;

                            //        objE_Kardex.PrecioCostoPromedio = dmlPCP;
                            //        objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                            //    }

                            //}
                            //else
                            //{
                            //    objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                            //}

                            //KardexDL objDL_Kardex = new KardexDL();
                            //objDL_Kardex.Actualiza(objE_Kardex);

                            //Actualizar Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = item.Cantidad;
                            objE_Stock.ValorDescuenta = item.CantidadAnt;
                            objE_Stock.PrecioCostoPromedio =0;//objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;//objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            StockDL objDL_Stock = new StockDL();
                            objDL_Stock.ActualizaCantidades(objE_Stock);

                            //Actualizamos el detalle del documento venta
                            DocumentoVentaDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos el movimiento de caja
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    MovimientoCaja.Actualiza(pCajaBE);

                    foreach (DocumentoVentaPagoBE item in pListaDocumentoVentaPago)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdDocumentoVenta = pItem.IdDocumentoVenta;
                            DocumentoVentaPago.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            DocumentoVentaPago.Actualiza(item);
                        }
                    }

                    //Actualizamos el documento venta
                    DocumentoVenta.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaAutoservicio(DocumentoVentaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    int IdEmpresa = 0;
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    List<DocumentoVentaDetalleBE> ListaDocumentoVentaDetalle = null;
                    ListaDocumentoVentaDetalle = new DocumentoVentaDetalleDL().ListaTodosActivo(pItem.IdDocumentoVenta);

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    else
                        IdEmpresa = pItem.IdEmpresa;

                    foreach (DocumentoVentaDetalleBE item in ListaDocumentoVentaDetalle)
                    {
                        //int IdKardex = 0;
                        ////Insertar Kardex
                        //KardexBE objE_Kardex = new KardexBE();
                        //objE_Kardex.IdKardex = 0;
                        //objE_Kardex.IdEmpresa = IdEmpresa;
                        //objE_Kardex.Periodo = pItem.Periodo;
                        //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        //objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                        //objE_Kardex.IdProducto = item.IdProducto;
                        //objE_Kardex.Cantidad = item.Cantidad;
                        //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                        //objE_Kardex.NumeroDocumento = pItem.Numero;
                        //objE_Kardex.Observacion = "Ingreso por Anulación de Documento de Venta";
                        //objE_Kardex.TipoMovimiento = "I";
                        //objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                        //objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                        //objE_Kardex.MontoTotalCompra = item.ValorVenta;
                        //objE_Kardex.FlagEstado = true;
                        //objE_Kardex.Usuario = pItem.Usuario;
                        //objE_Kardex.Maquina = pItem.Maquina;

                        //KardexBE objE_KardexValorizado = new KardexBE();
                        //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                        //if (objE_KardexValorizado != null)
                        //{
                        //    objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                        //    objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                        //}

                        //KardexDL objDL_Kardex = new KardexDL();
                        //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = item.Cantidad;
                            objE_Stock.ValorDescuenta = 0;
                            objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.ActualizaCantidades(objE_Stock);
                        }
                        else
                        {
                            //Insertamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdStock = 0;
                            objE_Stock.IdEmpresa = IdEmpresa;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }

                        //borramos el detalle del documento de venta
                        DocumentoVentaDetalle.Elimina(item);
                    }

                    //Eliminamos el movimiento de caja
                    MovimientoCajaBE objE_MovimientoCaja = null;
                    string NumeroDocumentoVenta = "";
                    NumeroDocumentoVenta = pItem.Serie + "-" + pItem.Numero;
                    objE_MovimientoCaja = new MovimientoCajaDL().SeleccionaNumero(pItem.IdEmpresa, pItem.IdTipoDocumento, NumeroDocumentoVenta);
                    if (objE_MovimientoCaja != null)
                    {
                        MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                        MovimientoCaja.Elimina(objE_MovimientoCaja);
                    }

                    List<DocumentoVentaPagoBE> ListaDocumentoVentaPago = null;
                    ListaDocumentoVentaPago = new DocumentoVentaPagoDL().ListaTodosActivo(IdEmpresa, pItem.IdDocumentoVenta);
                    foreach (DocumentoVentaPagoBE item in ListaDocumentoVentaPago)
                    {
                        //Eliminanos el pago del documento de venta
                        DocumentoVentaPago.Elimina(item);
                    }

                    //Actualiza la anulación del documento de venta
                    DocumentoVenta.ActualizaSituacion(IdEmpresa, pItem.IdDocumentoVenta, Parametros.intDVAnulado);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaObsequioCosto(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                DocumentoVenta.ActualizaObsequioCosto(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion

        public Int32 Inserta(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();

                    //Insertar Documento Venta
                    int IdDocumentoVenta = 0;
                    int IdEmpresaCorrelativo = pItem.IdEmpresa;

                    IdDocumentoVenta = DocumentoVenta.Inserta(pItem);
                   
                    if (pItem.IdEmpresa == 13)
                    {
                        if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        {
                            pItem.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                        }
                    }
                                       
                    if (pItem.IdTipoDocumento == Parametros.intTipoDocFacturaVentaTraslado || pItem.IdTipoDocumento == Parametros.intTipoDocBoletaVentaTraslado)
                    {
                        foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                        {
                            item.IdDocumentoVenta = IdDocumentoVenta;
                            DocumentoVentaDetalle.Inserta(item);
                        }
                    }else{
                        foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                        {
                           //Insertamos el detalle del documento de venta
                            item.IdDocumentoVenta = IdDocumentoVenta;
                            //item.IdKardex = IdKardex;
                            DocumentoVentaDetalle.Inserta(item);
                        }                        
                    }

                    ClienteBE objE_Cliente = new ClienteBE();
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intIdPanoramaDistribuidores, pItem.IdCliente);

                    //Estado de cuenta de cliente
                    #region "Credito, Contraentrega y Copagan"
                    if (pItem.IdTipoDocumento == Parametros.intTipoDocBoletaVenta || pItem.IdTipoDocumento == Parametros.intTipoDocFacturaVenta|| pItem.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || pItem.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                    {
                        if (pItem.IdFormaPago == Parametros.intContraEntrega || pItem.IdFormaPago == Parametros.intCredito || pItem.IdFormaPago == Parametros.intCopagan)
                        {
                            if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                            {
                                string TipoDoc = "03";
                                if (pItem.IdTipoDocumento == Parametros.intTipoDocFacturaVenta || pItem.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                                    TipoDoc = "01";

                                #region "EstadoCuentaCliente"

                                decimal Total = pItem.Total;

                                PedidoBE objE_Pedido = null;
                                objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));

                                Total = objE_Pedido.Total;

                                //decimal TipoCambioPedido = pItem.TipoCambioPedido == 0? Convert.ToDecimal(Parametros.dmlTCMayorista) : pItem.TipoCambioPedido;
                                //if (pItem.IdMoneda == Parametros.intSoles) Total = Math.Round((pItem.Total / objE_Pedido.TipoCambio), 2);
                                //if (pItem.IdMoneda == Parametros.intSoles) Total = Math.Round((pItem.Total / Convert.ToDecimal(Parametros.dmlTCMayorista)), 2);


                                //Datos del estado de cuenta
                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                objE_EstadoCuentaCliente.NumeroDocumento = TipoDoc + "-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                objE_EstadoCuentaCliente.Concepto = pItem.DescFormaPago + " N° " + pItem.NumeroPedido;
                                objE_EstadoCuentaCliente.FechaVencimiento = pItem.FechaVencimiento;
                                objE_EstadoCuentaCliente.IdMoneda = Parametros.intDolares;
                                objE_EstadoCuentaCliente.Importe = Total;
                                objE_EstadoCuentaCliente.TipoMovimiento = "C";
                                objE_EstadoCuentaCliente.IdMotivo = pItem.IdMotivo;
                                objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                objE_EstadoCuentaCliente.Saldo = Total;
                                objE_EstadoCuentaCliente.FlagEstado = true;
                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                #endregion
                            }
                            else //CF
                            {
                                string TipoDoc = "03";
                                if (pItem.IdTipoDocumento == Parametros.intTipoDocFacturaVenta || pItem.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                                    TipoDoc = "01";

                                #region "EstadoCuentaCliente"
                                decimal Total = pItem.Total;

                                PedidoBE objE_Pedido = null;
                                objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));
                                Total = objE_Pedido.Total;


                                //decimal TipoCambioPedido = pItem.TipoCambioPedido == 0 ? Convert.ToDecimal(Parametros.dmlTCMinorista) : pItem.TipoCambioPedido;
                                //if (pItem.IdMoneda == Parametros.intDolares) Total = Math.Round((pItem.Total * objE_Pedido.TipoCambio), 2);
                                //if (pItem.IdMoneda == Parametros.intDolares) Total = Math.Round((pItem.Total * Convert.ToDecimal(Parametros.dmlTCMinorista)), 2);

                                //Datos del estado de cuenta
                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                objE_EstadoCuentaCliente.NumeroDocumento = TipoDoc + "-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                objE_EstadoCuentaCliente.Concepto = pItem.DescFormaPago + " N° " + pItem.NumeroPedido;
                                objE_EstadoCuentaCliente.FechaVencimiento = pItem.FechaVencimiento;
                                objE_EstadoCuentaCliente.IdMoneda = Parametros.intSoles;
                                objE_EstadoCuentaCliente.Importe = Total;
                                objE_EstadoCuentaCliente.TipoMovimiento = "C";
                                objE_EstadoCuentaCliente.IdMotivo = pItem.IdMotivo;
                                objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                objE_EstadoCuentaCliente.Saldo = Total;
                                objE_EstadoCuentaCliente.FlagEstado = true;
                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                #endregion
                            }
                        }
                    }


                    #endregion

                    //En caso que sea nota de credito
                    #region "Nota Credito"
                    if (pItem.IdTipoDocumento == Parametros.intTipoDocNotaCredito|| pItem.IdTipoDocumento ==Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        if (pListaDocumentoVentaDetalle[0].IdProducto == Parametros.intIdProductoReajuste)
                        {
                            int IdMotivo = Parametros.intMotivoVenta;
                            string Numero = "";
                            Numero = "NCV" + "-" + pItem.Serie + "-" + pItem.Numero;

                            CambioDL objDL_Cambio = new CambioDL();
                            objDL_Cambio.ActualizaNotaCredito(pItem.IdEmpresa, pItem.IdCambio, IdDocumentoVenta, Numero);

                            PedidoBE objE_Pedido = null;
                            objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));
                            if (objE_Pedido != null) IdMotivo = objE_Pedido.IdMotivo;

                            //ClienteBE objE_Cliente = new ClienteBE();
                            //objE_Cliente = new ClienteBL().Selecciona(Parametros.intIdPanoramaDistribuidores, pItem.IdCliente);


                            if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                            {
                                //Datos del estado de cuenta
                                EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();

                                objE_EstadoCuenta.IdEstadoCuenta = 0;
                                objE_EstadoCuenta.IdEmpresa = pItem.IdEmpresa;
                                objE_EstadoCuenta.Periodo = pItem.Periodo;
                                objE_EstadoCuenta.IdCliente = pItem.IdCliente;
                                objE_EstadoCuenta.NumeroDocumento = "SD " + pItem.NumeroDevolucion;
                                objE_EstadoCuenta.FechaCredito = pItem.Fecha;
                                objE_EstadoCuenta.FechaDeposito = null;
                                objE_EstadoCuenta.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuenta.FechaVencimiento = null;
                                objE_EstadoCuenta.Importe = pItem.TotalVentaDolares;
                                objE_EstadoCuenta.ImporteAnt = pItem.TotalVentaDolares;
                                objE_EstadoCuenta.TipoMovimiento = "A";
                                objE_EstadoCuenta.IdMotivo = IdMotivo; //Parametros.intMotivoVenta;//Verificar para NAVIDAD
                                objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuenta.IdUsuario = pItem.IdUsuario;
                                objE_EstadoCuenta.Observacion = "";
                                objE_EstadoCuenta.FlagEstado = true;
                                objE_EstadoCuenta.Usuario = pItem.Usuario;
                                objE_EstadoCuenta.Maquina = pItem.Maquina;

                                objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);

                                #region "EstadocuentaCliente"
                                //Datos del estado de cuenta
                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                objE_EstadoCuentaCliente.NumeroDocumento = "07-" + pItem.Serie + "-" + pItem.Numero.Trim();//txtNumero.Text;
                                objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                objE_EstadoCuentaCliente.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuentaCliente.FechaVencimiento = null;
                                objE_EstadoCuentaCliente.IdMoneda = Parametros.intDolares;
                                objE_EstadoCuentaCliente.Importe = objE_EstadoCuenta.Importe;
                                objE_EstadoCuentaCliente.TipoMovimiento = "A";
                                objE_EstadoCuentaCliente.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                objE_EstadoCuentaCliente.Saldo = objE_EstadoCuenta.Importe;
                                objE_EstadoCuentaCliente.FlagEstado = true;
                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                #endregion
                            }
                            else
                            {
                                SeparacionBE objE_Separacion = new SeparacionBE();
                                SeparacionBL objBL_Separacion = new SeparacionBL();

                                objE_Separacion.IdSeparacion = 0;
                                objE_Separacion.IdEmpresa = pItem.IdEmpresa;
                                objE_Separacion.Periodo = pItem.Periodo;
                                objE_Separacion.IdCliente = pItem.IdCliente;
                                objE_Separacion.NumeroDocumento = "SD " + pItem.NumeroDevolucion;
                                objE_Separacion.FechaSeparacion = pItem.Fecha;
                                objE_Separacion.FechaPago = null;
                                objE_Separacion.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_Separacion.FechaVencimiento = null;
                                objE_Separacion.Importe = pItem.Total;
                                objE_Separacion.ImporteAnt = pItem.Total;
                                objE_Separacion.TipoMovimiento = "A";
                                objE_Separacion.IdMotivo = IdMotivo; //Parametros.intMotivoVenta;//Verificar para NAVIDAD
                                objE_Separacion.IdDocumentoVenta = IdDocumentoVenta;
                                objE_Separacion.IdUsuario = pItem.IdUsuario;
                                objE_Separacion.Observacion = "";
                                objE_Separacion.FlagEstado = true;
                                objE_Separacion.Usuario = pItem.Usuario;
                                objE_Separacion.Maquina = pItem.Maquina;

                                objBL_Separacion.Inserta(objE_Separacion);

                                #region "EstadocuentaCliente"
                                //Datos del estado de cuenta
                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                objE_EstadoCuentaCliente.NumeroDocumento = "07-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                objE_EstadoCuentaCliente.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero;
                                objE_EstadoCuentaCliente.FechaVencimiento = null;
                                objE_EstadoCuentaCliente.IdMoneda = Parametros.intSoles;
                                objE_EstadoCuentaCliente.Importe = objE_Separacion.Importe;
                                objE_EstadoCuentaCliente.TipoMovimiento = "A";
                                objE_EstadoCuentaCliente.IdMotivo = objE_Separacion.IdMotivo;
                                objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                objE_EstadoCuentaCliente.Saldo = objE_Separacion.Importe;
                                objE_EstadoCuentaCliente.FlagEstado = true;
                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                #endregion
                            }

                        }
                        else
                        {
                            string Numero = "";
                            Numero = "NCV" + "-" + pItem.Serie + "-" + pItem.Numero;

                            CambioDL objDL_Cambio = new CambioDL();
                            objDL_Cambio.ActualizaNotaCredito(pItem.IdEmpresa, pItem.IdCambio, IdDocumentoVenta, Numero);

                            //Generación del estado de cuenta en caso devoluciones en caso de mayoristas

                            //Traemos los datos del pedido para especificar el cliente principal
                            if (pItem.IdPedido != null)
                            {
                                PedidoBE objE_Pedido = null;
                                objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));

                                if (objE_Pedido != null)
                                {
                                    if (objE_Pedido.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Pedido.IdClasificacionCliente == Parametros.intBlack)
                                    {
                                        //Datos del estado de cuenta
                                        EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                        EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();

                                        objE_EstadoCuenta.IdEstadoCuenta = 0;
                                        objE_EstadoCuenta.IdEmpresa = pItem.IdEmpresa;
                                        objE_EstadoCuenta.Periodo = pItem.Periodo;
                                        objE_EstadoCuenta.IdCliente = objE_Pedido.IdCliente;
                                        objE_EstadoCuenta.NumeroDocumento = "SD " + pItem.NumeroDevolucion;
                                        objE_EstadoCuenta.FechaCredito = pItem.Fecha;
                                        objE_EstadoCuenta.FechaDeposito = null;
                                        objE_EstadoCuenta.Concepto = "DEVOLUCION" + " NC " + pItem.Serie + "-" + pItem.Numero.Trim();
                                        objE_EstadoCuenta.FechaVencimiento = null;
                                        objE_EstadoCuenta.Importe = pItem.TotalVentaDolares;
                                        objE_EstadoCuenta.ImporteAnt = pItem.TotalVentaDolares;
                                        objE_EstadoCuenta.TipoMovimiento = "A";
                                        objE_EstadoCuenta.IdMotivo = objE_Pedido.IdMotivo; //Parametros.intMotivoVenta;//Verificar para NAVIDAD
                                        objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVenta;
                                        objE_EstadoCuenta.IdUsuario = pItem.IdUsuario;
                                        objE_EstadoCuenta.Observacion = "";
                                        objE_EstadoCuenta.FlagEstado = true;
                                        objE_EstadoCuenta.Usuario = pItem.Usuario;
                                        objE_EstadoCuenta.Maquina = pItem.Maquina;

                                        objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);

                                        #region "EstadocuentaCliente"
                                        //Datos del estado de cuenta
                                        EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                        EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                        objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                        objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                        objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                        objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                        objE_EstadoCuentaCliente.NumeroDocumento = "07-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                        objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                        objE_EstadoCuentaCliente.Concepto = "DEVOLUCION" + " NC " + pItem.Serie + "-" + pItem.Numero.Trim();
                                        objE_EstadoCuentaCliente.FechaVencimiento = null;
                                        objE_EstadoCuentaCliente.IdMoneda = Parametros.intDolares;
                                        objE_EstadoCuentaCliente.Importe = objE_EstadoCuenta.Importe;
                                        objE_EstadoCuentaCliente.TipoMovimiento = "A";
                                        objE_EstadoCuentaCliente.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                        objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                        objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                        objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                        objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                        objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                        objE_EstadoCuentaCliente.Saldo = objE_EstadoCuenta.Importe;
                                        objE_EstadoCuentaCliente.FlagEstado = true;
                                        objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                        objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                        objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                        #endregion

                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    //Actualiza la cancelación del pedido
                    PedidoDL Pedido = new PedidoDL();
                    Pedido.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado,0,"",pItem.Usuario,pItem.Maquina);

                            ////Actualizamos la numeración del documento //antes
                            //NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                            //objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(IdEmpresaCorrelativo, pItem.IdTipoDocumento, Parametros.intPeriodo);

                            //Actualizamos la numeración del documento //ADD 230718
                            NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoSerie(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Serie);   //

                    ts.Complete();
                    return IdDocumentoVenta;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta_EC(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle, int pIdEstadoCuenta, decimal pTipoCambio, int pMoneda)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();

                    //Insertar Documento Venta
                    int IdDocumentoVenta = 0;
                    int IdEmpresaCorrelativo = pItem.IdEmpresa;

                    IdDocumentoVenta = DocumentoVenta.Inserta(pItem);

                    if (pItem.IdEmpresa == 13)
                    {
                        if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        {
                            pItem.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                        }
                    }

                    if (pItem.IdTipoDocumento == Parametros.intTipoDocFacturaVentaTraslado || pItem.IdTipoDocumento == Parametros.intTipoDocBoletaVentaTraslado)
                    {
                        foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                        {
                            item.IdDocumentoVenta = IdDocumentoVenta;
                            DocumentoVentaDetalle.Inserta(item);
                        }
                    }
                    else
                    {
                        foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                        {
                            //Insertamos el detalle del documento de venta
                            item.IdDocumentoVenta = IdDocumentoVenta;
                            //item.IdKardex = IdKardex;
                            DocumentoVentaDetalle.Inserta(item);
                        }
                    }

                    ClienteBE objE_Cliente = new ClienteBE();
                    objE_Cliente = new ClienteBL().Selecciona(Parametros.intIdPanoramaDistribuidores, pItem.IdCliente);

                    //Estado de cuenta de cliente
                    #region "Credito, Contraentrega y Copagan"
                    if (pItem.IdTipoDocumento == Parametros.intTipoDocBoletaVenta || pItem.IdTipoDocumento == Parametros.intTipoDocFacturaVenta || pItem.IdTipoDocumento == Parametros.intTipoDocBoletaElectronica || pItem.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                    {
                        if (pItem.IdFormaPago == Parametros.intContraEntrega || pItem.IdFormaPago == Parametros.intCredito || pItem.IdFormaPago == Parametros.intCopagan)
                        {
                            if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                            {
                                string TipoDoc = "03";
                                if (pItem.IdTipoDocumento == Parametros.intTipoDocFacturaVenta || pItem.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                                    TipoDoc = "01";

                                #region "EstadoCuentaCliente"

                                decimal Total = pMoneda == 5 ? Math.Round(pItem.Total / pTipoCambio, 2) : pItem.Total;  // pTipoCambio == 5? Math.Round(pItem.Total / pTipoCambioPedido, 2) : pItem.Total;   // Math.Round( pItem.Total / pTipoCambioPedido, 2);

                                PedidoBE objE_Pedido = null;
                                objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));

                                Total = pMoneda == 5 ? Math.Round(pItem.Total / pTipoCambio, 2) : pItem.Total;    //objE_Pedido.Total;

                                //decimal TipoCambioPedido = pItem.TipoCambioPedido == 0? Convert.ToDecimal(Parametros.dmlTCMayorista) : pItem.TipoCambioPedido;
                                //if (pItem.IdMoneda == Parametros.intSoles) Total = Math.Round((pItem.Total / objE_Pedido.TipoCambio), 2);
                                //if (pItem.IdMoneda == Parametros.intSoles) Total = Math.Round((pItem.Total / Convert.ToDecimal(Parametros.dmlTCMayorista)), 2);

                                //Datos del estado de cuenta
                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                objE_EstadoCuentaCliente.NumeroDocumento = TipoDoc + "-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                objE_EstadoCuentaCliente.Concepto = pItem.DescFormaPago + " N° " + pItem.NumeroPedido;
                                objE_EstadoCuentaCliente.FechaVencimiento = pItem.FechaVencimiento;
                                objE_EstadoCuentaCliente.IdMoneda = Parametros.intDolares;
                                objE_EstadoCuentaCliente.Importe = Total;
                                objE_EstadoCuentaCliente.TipoMovimiento = "C";
                                objE_EstadoCuentaCliente.IdMotivo = pItem.IdMotivo;
                                objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                objE_EstadoCuentaCliente.Saldo = Total;
                                objE_EstadoCuentaCliente.FlagEstado = true;
                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                #endregion
                            }
                            else //CF
                            {
                                string TipoDoc = "03";
                                if (pItem.IdTipoDocumento == Parametros.intTipoDocFacturaVenta || pItem.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica)
                                    TipoDoc = "01";

                                #region "EstadoCuentaCliente"
                                decimal Total = pItem.Total;

                                PedidoBE objE_Pedido = null;
                                objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));
                                Total = objE_Pedido.Total;


                                //decimal TipoCambioPedido = pItem.TipoCambioPedido == 0 ? Convert.ToDecimal(Parametros.dmlTCMinorista) : pItem.TipoCambioPedido;
                                //if (pItem.IdMoneda == Parametros.intDolares) Total = Math.Round((pItem.Total * objE_Pedido.TipoCambio), 2);
                                //if (pItem.IdMoneda == Parametros.intDolares) Total = Math.Round((pItem.Total * Convert.ToDecimal(Parametros.dmlTCMinorista)), 2);

                                //Datos del estado de cuenta
                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                objE_EstadoCuentaCliente.NumeroDocumento = TipoDoc + "-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                objE_EstadoCuentaCliente.Concepto = pItem.DescFormaPago + " N° " + pItem.NumeroPedido;
                                objE_EstadoCuentaCliente.FechaVencimiento = pItem.FechaVencimiento;
                                objE_EstadoCuentaCliente.IdMoneda = Parametros.intSoles;
                                objE_EstadoCuentaCliente.Importe = Total;
                                objE_EstadoCuentaCliente.TipoMovimiento = "C";
                                objE_EstadoCuentaCliente.IdMotivo = pItem.IdMotivo;
                                objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                objE_EstadoCuentaCliente.Saldo = Total;
                                objE_EstadoCuentaCliente.FlagEstado = true;
                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                #endregion
                            }
                        }
                    }


                    #endregion

                    //En caso que sea nota de credito
                    #region "Nota Credito"
                    if (pItem.IdTipoDocumento == Parametros.intTipoDocNotaCredito || pItem.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        if (pListaDocumentoVentaDetalle[0].IdProducto == Parametros.intIdProductoReajuste)
                        {
                            int IdMotivo = Parametros.intMotivoVenta;
                            string Numero = "";
                            Numero = "NCE" + "-" + pItem.Serie + "-" + pItem.Numero;

                            CambioDL objDL_Cambio = new CambioDL();
                            objDL_Cambio.ActualizaNotaCredito(pItem.IdEmpresa, pItem.IdCambio, IdDocumentoVenta, Numero);

                            PedidoBE objE_Pedido = null;
                            objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));
                            if (objE_Pedido != null) IdMotivo = objE_Pedido.IdMotivo;

                            //ClienteBE objE_Cliente = new ClienteBE();
                            //objE_Cliente = new ClienteBL().Selecciona(Parametros.intIdPanoramaDistribuidores, pItem.IdCliente);

                            if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                            {
                                //Datos del estado de cuenta
                                EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();

                                objE_EstadoCuenta.IdEstadoCuenta = 0;
                                objE_EstadoCuenta.IdEmpresa = pItem.IdEmpresa;
                                objE_EstadoCuenta.Periodo = pItem.Periodo;
                                objE_EstadoCuenta.IdCliente = pItem.IdCliente;
                                objE_EstadoCuenta.NumeroDocumento = "SD " + pItem.NumeroDevolucion;
                                objE_EstadoCuenta.FechaCredito = pItem.Fecha;
                                objE_EstadoCuenta.FechaDeposito = null;
                                objE_EstadoCuenta.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuenta.FechaVencimiento = null;
                                objE_EstadoCuenta.Importe = pItem.TotalVentaDolares;
                                objE_EstadoCuenta.ImporteAnt = pItem.TotalVentaDolares;
                                objE_EstadoCuenta.TipoMovimiento = "A";
                                objE_EstadoCuenta.IdMotivo = IdMotivo; //Parametros.intMotivoVenta;//Verificar para NAVIDAD
                                objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuenta.IdUsuario = pItem.IdUsuario;
                                objE_EstadoCuenta.Observacion = "";
                                objE_EstadoCuenta.FlagEstado = true;
                                objE_EstadoCuenta.Usuario = pItem.Usuario;
                                objE_EstadoCuenta.Maquina = pItem.Maquina;

                                objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);

                                #region "EstadocuentaCliente"
                                //Datos del estado de cuenta
                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                objE_EstadoCuentaCliente.NumeroDocumento = "07-" + pItem.Serie + "-" + pItem.Numero.Trim();//txtNumero.Text;
                                objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                objE_EstadoCuentaCliente.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuentaCliente.FechaVencimiento = null;
                                objE_EstadoCuentaCliente.IdMoneda = Parametros.intDolares;
                                objE_EstadoCuentaCliente.Importe = objE_EstadoCuenta.Importe;
                                objE_EstadoCuentaCliente.TipoMovimiento = "A";
                                objE_EstadoCuentaCliente.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                objE_EstadoCuentaCliente.Saldo = objE_EstadoCuenta.Importe;
                                objE_EstadoCuentaCliente.FlagEstado = true;
                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                #endregion
                            }
                            else
                            {
                                SeparacionBE objE_Separacion = new SeparacionBE();
                                SeparacionBL objBL_Separacion = new SeparacionBL();

                                objE_Separacion.IdSeparacion = 0;
                                objE_Separacion.IdEmpresa = pItem.IdEmpresa;
                                objE_Separacion.Periodo = pItem.Periodo;
                                objE_Separacion.IdCliente = pItem.IdCliente;
                                objE_Separacion.NumeroDocumento = "SD " + pItem.NumeroDevolucion;
                                objE_Separacion.FechaSeparacion = pItem.Fecha;
                                objE_Separacion.FechaPago = null;
                                objE_Separacion.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_Separacion.FechaVencimiento = null;
                                objE_Separacion.Importe = pItem.Total;
                                objE_Separacion.ImporteAnt = pItem.Total;
                                objE_Separacion.TipoMovimiento = "A";
                                objE_Separacion.IdMotivo = IdMotivo; //Parametros.intMotivoVenta;//Verificar para NAVIDAD
                                objE_Separacion.IdDocumentoVenta = IdDocumentoVenta;
                                objE_Separacion.IdUsuario = pItem.IdUsuario;
                                objE_Separacion.Observacion = "";
                                objE_Separacion.FlagEstado = true;
                                objE_Separacion.Usuario = pItem.Usuario;
                                objE_Separacion.Maquina = pItem.Maquina;

                                objBL_Separacion.Inserta(objE_Separacion);

                                #region "EstadocuentaCliente"
                                //Datos del estado de cuenta
                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                objE_EstadoCuentaCliente.NumeroDocumento = "07-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                objE_EstadoCuentaCliente.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero;
                                objE_EstadoCuentaCliente.FechaVencimiento = null;
                                objE_EstadoCuentaCliente.IdMoneda = Parametros.intSoles;
                                objE_EstadoCuentaCliente.Importe = objE_Separacion.Importe;
                                objE_EstadoCuentaCliente.TipoMovimiento = "A";
                                objE_EstadoCuentaCliente.IdMotivo = objE_Separacion.IdMotivo;
                                objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                objE_EstadoCuentaCliente.Saldo = objE_Separacion.Importe;
                                objE_EstadoCuentaCliente.FlagEstado = true;
                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                #endregion
                            }

                        }
                        else
                        {
                            string Numero = "";
                            Numero = "NCE" + "-" + pItem.Serie + "-" + pItem.Numero;

                            CambioDL objDL_Cambio = new CambioDL();
                            objDL_Cambio.ActualizaNotaCredito(pItem.IdEmpresa, pItem.IdCambio, IdDocumentoVenta, Numero); // Actualiza la tabla Cambios

                            //Generación del estado de cuenta en caso devoluciones en caso de mayoristas

                            //Traemos los datos del pedido para especificar el cliente principal
                            if (pItem.IdPedido != null)
                            {
                                PedidoBE objE_Pedido = null;
                                objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));

                                if (objE_Pedido != null)
                                {
                                    if (objE_Pedido.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Pedido.IdClasificacionCliente == Parametros.intBlack)
                                    {
                                        //Datos del estado de cuenta
                                        EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                        EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();

                                        objE_EstadoCuenta.IdEstadoCuenta = 0;
                                        objE_EstadoCuenta.IdEmpresa = pItem.IdEmpresa;
                                        objE_EstadoCuenta.Periodo = pItem.Periodo;
                                        objE_EstadoCuenta.IdCliente = objE_Pedido.IdCliente;
                                        objE_EstadoCuenta.NumeroDocumento = "SD " + pItem.NumeroDevolucion;
                                        objE_EstadoCuenta.FechaCredito = pItem.Fecha;
                                        objE_EstadoCuenta.FechaDeposito = null;
                                        objE_EstadoCuenta.Concepto = "DEVOLUCION" + " NC " + pItem.Serie + "-" + pItem.Numero.Trim();
                                        objE_EstadoCuenta.FechaVencimiento = null;
                                        objE_EstadoCuenta.Importe = pItem.TotalVentaDolares;
                                        objE_EstadoCuenta.ImporteAnt = pItem.TotalVentaDolares;
                                        objE_EstadoCuenta.TipoMovimiento = "A";
                                        objE_EstadoCuenta.IdMotivo = objE_Pedido.IdMotivo; //Parametros.intMotivoVenta;//Verificar para NAVIDAD
                                        objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVenta;
                                        objE_EstadoCuenta.IdUsuario = pItem.IdUsuario;
                                        objE_EstadoCuenta.Observacion = "";
                                        objE_EstadoCuenta.FlagEstado = true;
                                        objE_EstadoCuenta.Usuario = pItem.Usuario;
                                        objE_EstadoCuenta.Maquina = pItem.Maquina;

                                        objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);

                                        #region "EstadocuentaCliente"
                                        //Datos del estado de cuenta
                                        EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                        EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                        objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                        objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                        objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                        objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                        objE_EstadoCuentaCliente.NumeroDocumento = "07-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                        objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                        objE_EstadoCuentaCliente.Concepto = "DEVOLUCION" + " NC " + pItem.Serie + "-" + pItem.Numero.Trim();
                                        objE_EstadoCuentaCliente.FechaVencimiento = null;
                                        objE_EstadoCuentaCliente.IdMoneda = Parametros.intDolares;
                                        objE_EstadoCuentaCliente.Importe = objE_EstadoCuenta.Importe;
                                        objE_EstadoCuentaCliente.TipoMovimiento = "A";
                                        objE_EstadoCuentaCliente.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                        objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                        objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                        objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                        objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                        objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                        objE_EstadoCuentaCliente.Saldo = objE_EstadoCuenta.Importe;
                                        objE_EstadoCuentaCliente.FlagEstado = true;
                                        objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                        objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                        objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                        #endregion

                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    //En caso que sea nota de debito electronica
                    #region "Nota Debito"
                    if (pItem.IdTipoDocumento == Parametros.intTipoDocNotaDebitoElectronica  || pItem.IdTipoDocumento == Parametros.intTipoDocNotaDebitoElectronica)
                    {
                        if (pListaDocumentoVentaDetalle[0].IdProducto == Parametros.intIdProductoReajuste)
                        {
                            int IdMotivo = Parametros.intMotivoVenta;
                            string Numero = "";
                            Numero = "NCE" + "-" + pItem.Serie + "-" + pItem.Numero;

                            //CambioDL objDL_Cambio = new CambioDL();
                            //objDL_Cambio.ActualizaNotaCredito(pItem.IdEmpresa, pItem.IdCambio, IdDocumentoVenta, Numero);

                            //PedidoBE objE_Pedido = null;
                            //objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));
                            //if (objE_Pedido != null) IdMotivo = objE_Pedido.IdMotivo;

                            if (objE_Cliente.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Cliente.IdClasificacionCliente == Parametros.intBlack)
                            {
                                //Datos del estado de cuenta
                                EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();

                                objE_EstadoCuenta.IdEstadoCuenta = 0;
                                objE_EstadoCuenta.IdEmpresa = pItem.IdEmpresa;
                                objE_EstadoCuenta.Periodo = pItem.Periodo;
                                objE_EstadoCuenta.IdCliente = pItem.IdCliente;
                                objE_EstadoCuenta.NumeroDocumento = "SD " + pItem.NumeroDevolucion;
                                objE_EstadoCuenta.FechaCredito = pItem.Fecha;
                                objE_EstadoCuenta.FechaDeposito = null;
                                objE_EstadoCuenta.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuenta.FechaVencimiento = null;
                                objE_EstadoCuenta.Importe = pItem.TotalVentaDolares;
                                objE_EstadoCuenta.ImporteAnt = pItem.TotalVentaDolares;
                                objE_EstadoCuenta.TipoMovimiento = "A";
                                objE_EstadoCuenta.IdMotivo = IdMotivo; //Parametros.intMotivoVenta;//Verificar para NAVIDAD
                                objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuenta.IdUsuario = pItem.IdUsuario;
                                objE_EstadoCuenta.Observacion = "";
                                objE_EstadoCuenta.FlagEstado = true;
                                objE_EstadoCuenta.Usuario = pItem.Usuario;
                                objE_EstadoCuenta.Maquina = pItem.Maquina;

                                objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);

                                #region "EstadocuentaCliente"
                                //Datos del estado de cuenta
                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                objE_EstadoCuentaCliente.NumeroDocumento = "07-" + pItem.Serie + "-" + pItem.Numero.Trim();//txtNumero.Text;
                                objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                objE_EstadoCuentaCliente.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuentaCliente.FechaVencimiento = null;
                                objE_EstadoCuentaCliente.IdMoneda = Parametros.intDolares;
                                objE_EstadoCuentaCliente.Importe = objE_EstadoCuenta.Importe;
                                objE_EstadoCuentaCliente.TipoMovimiento = "A";
                                objE_EstadoCuentaCliente.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                objE_EstadoCuentaCliente.Saldo = objE_EstadoCuenta.Importe;
                                objE_EstadoCuentaCliente.FlagEstado = true;
                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                #endregion
                            }
                            else
                            {
                                SeparacionBE objE_Separacion = new SeparacionBE();
                                SeparacionBL objBL_Separacion = new SeparacionBL();

                                objE_Separacion.IdSeparacion = 0;
                                objE_Separacion.IdEmpresa = pItem.IdEmpresa;
                                objE_Separacion.Periodo = pItem.Periodo;
                                objE_Separacion.IdCliente = pItem.IdCliente;
                                objE_Separacion.NumeroDocumento = "SD " + pItem.NumeroDevolucion;
                                objE_Separacion.FechaSeparacion = pItem.Fecha;
                                objE_Separacion.FechaPago = null;
                                objE_Separacion.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_Separacion.FechaVencimiento = null;
                                objE_Separacion.Importe = pItem.Total;
                                objE_Separacion.ImporteAnt = pItem.Total;
                                objE_Separacion.TipoMovimiento = "A";
                                objE_Separacion.IdMotivo = IdMotivo; //Parametros.intMotivoVenta;//Verificar para NAVIDAD
                                objE_Separacion.IdDocumentoVenta = IdDocumentoVenta;
                                objE_Separacion.IdUsuario = pItem.IdUsuario;
                                objE_Separacion.Observacion = "";
                                objE_Separacion.FlagEstado = true;
                                objE_Separacion.Usuario = pItem.Usuario;
                                objE_Separacion.Maquina = pItem.Maquina;

                                objBL_Separacion.Inserta(objE_Separacion);

                                #region "EstadocuentaCliente"
                                //Datos del estado de cuenta
                                EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                objE_EstadoCuentaCliente.NumeroDocumento = "07-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                objE_EstadoCuentaCliente.Concepto = "REAJUSTE DE PRECIO NC-" + pItem.Serie + "-" + pItem.Numero;
                                objE_EstadoCuentaCliente.FechaVencimiento = null;
                                objE_EstadoCuentaCliente.IdMoneda = Parametros.intSoles;
                                objE_EstadoCuentaCliente.Importe = objE_Separacion.Importe;
                                objE_EstadoCuentaCliente.TipoMovimiento = "A";
                                objE_EstadoCuentaCliente.IdMotivo = objE_Separacion.IdMotivo;
                                objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                objE_EstadoCuentaCliente.Saldo = objE_Separacion.Importe;
                                objE_EstadoCuentaCliente.FlagEstado = true;
                                objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                #endregion
                            }

                        }
                        else
                        {
                            string Numero = "";
                            //Numero = "NCE" + "-" + pItem.Serie + "-" + pItem.Numero;
                            //CambioDL objDL_Cambio = new CambioDL();
                            //objDL_Cambio.ActualizaNotaCredito(pItem.IdEmpresa, pItem.IdCambio, IdDocumentoVenta, Numero); // Actualiza la tabla Cambios

                            //Generación del estado de cuenta en caso devoluciones en caso de mayoristas

                            //Traemos los datos del pedido para especificar el cliente principal
                            if (pItem.IdPedido != null)
                            {
                                PedidoBE objE_Pedido = null;
                                objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));

                                if (objE_Pedido != null)
                                {
                                    if (objE_Pedido.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Pedido.IdClasificacionCliente == Parametros.intBlack)
                                    {
                                        //Datos del estado de cuenta
                                        EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                        EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();

                                        objE_EstadoCuenta.IdEstadoCuenta = 0;
                                        objE_EstadoCuenta.IdEmpresa = pItem.IdEmpresa;
                                        objE_EstadoCuenta.Periodo = pItem.Periodo;
                                        objE_EstadoCuenta.IdCliente = objE_Pedido.IdCliente;
                                        objE_EstadoCuenta.NumeroDocumento = "DB" + pItem.NumeroReferencia; // pItem.NumeroDevolucion;
                                        objE_EstadoCuenta.FechaCredito = pItem.Fecha;
                                        objE_EstadoCuenta.FechaDeposito = null;
                                        objE_EstadoCuenta.Concepto = "" + " ND " + pItem.Serie + "-" + pItem.Numero.Trim();
                                        objE_EstadoCuenta.FechaVencimiento = null;
                                        objE_EstadoCuenta.Importe = pItem.TotalVentaDolares;
                                        objE_EstadoCuenta.ImporteAnt = pItem.TotalVentaDolares;
                                        objE_EstadoCuenta.TipoMovimiento = "C";
                                        objE_EstadoCuenta.IdMotivo = objE_Pedido.IdMotivo; //Parametros.intMotivoVenta;//Verificar para NAVIDAD
                                        objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVenta;
                                        objE_EstadoCuenta.IdUsuario = pItem.IdUsuario;
                                        objE_EstadoCuenta.Observacion = "";
                                        objE_EstadoCuenta.FlagEstado = true;
                                        objE_EstadoCuenta.Usuario = pItem.Usuario;
                                        objE_EstadoCuenta.Maquina = pItem.Maquina;

                                        objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);

                                        #region "EstadocuentaCliente"
                                        //Datos del estado de cuenta
                                        EstadoCuentaClienteBE objE_EstadoCuentaCliente = new EstadoCuentaClienteBE();
                                        EstadoCuentaClienteBL objBL_EstadoCuentaCliente = new EstadoCuentaClienteBL();

                                        objE_EstadoCuentaCliente.IdEstadoCuentaCliente = 0;
                                        objE_EstadoCuentaCliente.IdEmpresa = Parametros.intEmpresaId;
                                        objE_EstadoCuentaCliente.Periodo = Parametros.intPeriodo;
                                        objE_EstadoCuentaCliente.IdCliente = pItem.IdCliente;
                                        objE_EstadoCuentaCliente.NumeroDocumento = "08-" + pItem.Serie + "-" + pItem.Numero.Trim();
                                        objE_EstadoCuentaCliente.Fecha = pItem.Fecha;
                                        objE_EstadoCuentaCliente.Concepto = "" + " ND " + pItem.Serie + "-" + pItem.Numero.Trim();
                                        objE_EstadoCuentaCliente.FechaVencimiento = null;
                                        objE_EstadoCuentaCliente.IdMoneda = Parametros.intDolares;
                                        objE_EstadoCuentaCliente.Importe = objE_EstadoCuenta.Importe;
                                        objE_EstadoCuentaCliente.TipoMovimiento = "C";
                                        objE_EstadoCuentaCliente.IdMotivo = objE_EstadoCuenta.IdMotivo;
                                        objE_EstadoCuentaCliente.IdDocumentoVenta = IdDocumentoVenta;
                                        objE_EstadoCuentaCliente.IdPersona = pItem.IdVendedor;
                                        objE_EstadoCuentaCliente.UsuarioRegistro = pItem.Usuario;
                                        objE_EstadoCuentaCliente.IdPedido = Convert.ToInt32(pItem.IdPedido);
                                        objE_EstadoCuentaCliente.FechaRegistro = pItem.Fecha;
                                        objE_EstadoCuentaCliente.Saldo = objE_EstadoCuenta.Importe;
                                        objE_EstadoCuentaCliente.FlagEstado = true;
                                        objE_EstadoCuentaCliente.Usuario = Parametros.strUsuarioLogin;
                                        objE_EstadoCuentaCliente.Maquina = pItem.Maquina;

                                        objBL_EstadoCuentaCliente.Inserta(objE_EstadoCuentaCliente);
                                        #endregion

                                    }
                                }
                            }
                        }
                    }
                    #endregion


                    //Actualiza la cancelación del pedido
                    PedidoDL Pedido = new PedidoDL();
                    Pedido.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado, 0, "", pItem.Usuario, pItem.Maquina);

                    // Actualizamos el IdDocumentoVenta en EstadoCuenta y EECC Separación (siempre y cuando es cliente final )
                    DocumentoVentaDL objDL_DocumentoVentaEstado = new DocumentoVentaDL();
                    objDL_DocumentoVentaEstado.ActualizaIdDocumentoVentaEnEstadoCuenta(IdDocumentoVenta, pIdEstadoCuenta);

                    ////Actualizamos la numeración del documento //antes
                    //NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    //objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(IdEmpresaCorrelativo, pItem.IdTipoDocumento, Parametros.intPeriodo);

                    //Actualizamos la numeración del documento //ADD 230718
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoSerie(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Serie);   //

                    ts.Complete();
                    return IdDocumentoVenta;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle del documento deventa
                            item.IdDocumentoVenta = pItem.IdDocumentoVenta;
                            DocumentoVentaDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle del documento venta
                            DocumentoVentaDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos el documento venta
                    DocumentoVenta.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DocumentoVentaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    int IdEmpresa = 0;
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    List<DocumentoVentaDetalleBE> ListaDocumentoVentaDetalle = null;
                    ListaDocumentoVentaDetalle = new DocumentoVentaDetalleDL().ListaTodosActivo(pItem.IdDocumentoVenta);

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    else
                        IdEmpresa = pItem.IdEmpresa;

                    foreach (DocumentoVentaDetalleBE item in ListaDocumentoVentaDetalle)
                    {
                        #region "Nota de Credito"
                        if (pItem.IdTipoDocumento == Parametros.intTipoDocNotaCredito|| pItem.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                        {
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

                            ////Insertar Kardex
                            //KardexBE objE_Kardex = new KardexBE();
                            //objE_Kardex.IdKardex = 0;
                            //objE_Kardex.IdEmpresa = IdEmpresa;
                            //objE_Kardex.Periodo = pItem.Periodo;
                            //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            //objE_Kardex.IdAlmacen = IdAlmacen;
                            //objE_Kardex.IdProducto = item.IdProducto;
                            //objE_Kardex.Cantidad = item.Cantidad;
                            //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                            //objE_Kardex.NumeroDocumento = pItem.Numero;
                            //objE_Kardex.Observacion = "Ingreso Por Eliminación Documento de Venta";
                            //objE_Kardex.TipoMovimiento = "I";
                            //objE_Kardex.MontoUnitarioCompra = item.ValorVenta;
                            //objE_Kardex.PrecioCostoPromedio = item.ValorVenta;
                            //objE_Kardex.MontoTotalCompra = item.ValorVenta;
                            //objE_Kardex.FlagEstado = true;
                            //objE_Kardex.Usuario = pItem.Usuario;
                            //objE_Kardex.Maquina = pItem.Maquina;

                            //KardexBE objE_KardexValorizado = new KardexBE();
                            //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                            //if (objE_KardexValorizado != null)
                            //{
                            //    decimal dmlPCP = 0;
                            //    decimal dmlCostoTotal = 0;

                            //    if (objE_KardexValorizado.Saldo != 0)
                            //    {
                            //        //Calcula Precio Costo Promedio
                            //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                            //        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;

                            //        objE_Kardex.PrecioCostoPromedio = dmlPCP;
                            //        objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                            //    }

                            //}
                            //else
                            //{
                            //    objE_Kardex.PrecioCostoPromedio = item.ValorVenta;
                            //}

                            //KardexDL objDL_Kardex = new KardexDL();
                            //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(IdEmpresa, pItem.IdTienda, IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = IdEmpresa;
                                objE_Stock.IdAlmacen = pItem.IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = item.Cantidad;
                                objE_Stock.ValorDescuenta = 0;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0; //objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;
                                objDL_Stock.ActualizaCantidades(objE_Stock);
                            }
                            else
                            {
                                //Insertamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdStock = 0;
                                objE_Stock.IdEmpresa = IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = pItem.IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }
                        }
                        #endregion

                        #region "Autoservicio
                        if (pItem.NumeroPedido == "" )
                        {
                            int IdKardex = 0;

                            //Establecemos el almacen correspondiente de acuerdo a la tienda
                            int IdAlmacen = 0;

                            if (pItem.IdTienda == Parametros.intTiendaUcayali)
                            {
                                //IdAlmacen = Parametros.intAlmCentral;
                                IdAlmacen = Parametros.intAlmTiendaUcayali;
                            }

                            if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                            {
                                IdAlmacen = Parametros.intAlmTiendaAndahuaylas;

                            }

                            if (pItem.IdTienda == Parametros.intTiendaKonceptos) IdAlmacen = Parametros.intAlmAnaquelesKonceptos;
                            if (pItem.IdTienda == Parametros.intTiendaPrescott) IdAlmacen = Parametros.intAlmPrescott;

                            ////Insertar Kardex
                            //KardexBE objE_Kardex = new KardexBE();
                            //objE_Kardex.IdKardex = 0;
                            //objE_Kardex.IdEmpresa = IdEmpresa;
                            //objE_Kardex.Periodo = pItem.Periodo;
                            //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            //objE_Kardex.IdAlmacen = IdAlmacen;
                            //objE_Kardex.IdProducto = item.IdProducto;
                            //objE_Kardex.Cantidad = item.Cantidad;
                            //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                            //objE_Kardex.NumeroDocumento = pItem.Numero;
                            //objE_Kardex.Observacion = "Ingreso Por Eliminación Documento de Venta";
                            //objE_Kardex.TipoMovimiento = "I";
                            //objE_Kardex.MontoUnitarioCompra = item.ValorVenta;
                            //objE_Kardex.PrecioCostoPromedio = item.ValorVenta;
                            //objE_Kardex.MontoTotalCompra = item.ValorVenta;
                            //objE_Kardex.FlagEstado = true;
                            //objE_Kardex.Usuario = pItem.Usuario;
                            //objE_Kardex.Maquina = pItem.Maquina;

                            //KardexBE objE_KardexValorizado = new KardexBE();
                            //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                            //if (objE_KardexValorizado != null)
                            //{
                            //    decimal dmlPCP = 0;
                            //    decimal dmlCostoTotal = 0;

                            //    if (objE_KardexValorizado.Saldo != 0)
                            //    {
                            //        //Calcula Precio Costo Promedio
                            //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                            //        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;

                            //        objE_Kardex.PrecioCostoPromedio = dmlPCP;
                            //        objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                            //    }

                            //}
                            //else
                            //{
                            //    objE_Kardex.PrecioCostoPromedio = item.ValorVenta;
                            //}

                            //KardexDL objDL_Kardex = new KardexDL();
                            //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(IdEmpresa, pItem.IdTienda, IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = IdEmpresa;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = item.Cantidad;
                                objE_Stock.ValorDescuenta = 0;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0; ///objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;
                                objDL_Stock.ActualizaCantidades(objE_Stock);
                            }
                            else
                            {
                                //Insertamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdStock = 0;
                                objE_Stock.IdEmpresa = IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0; // objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }
                        }
                        #endregion

                        ////borramos el detalle del documento de venta
                        //DocumentoVentaDetalle.Elimina(item);
                    }

                    //Eliminamos el estado de cuenta asociado al documento de venta
                    EstadoCuentaDL objDL_EstadoCuenta = new EstadoCuentaDL();
                    objDL_EstadoCuenta.EliminaDocumentoVenta(pItem.IdDocumentoVenta);

                    //Eliminamos el estado de cuenta Cliente asociado al documento de venta
                    EstadoCuentaClienteDL objDL_EstadoCuentaCliente = new EstadoCuentaClienteDL();
                    objDL_EstadoCuentaCliente.EliminaDocumentoVenta(pItem.IdDocumentoVenta);

                    //Eliminamos el estado de cuenta Separación asociado al documento de venta
                    SeparacionDL objDL_Separacion = new SeparacionDL();
                    objDL_Separacion.EliminaDocumentoVenta(pItem.IdDocumentoVenta);

                    //Actualiza la anulación del documento de venta
                    DocumentoVenta.ActualizaSituacion(pItem.IdEmpresa, pItem.IdDocumentoVenta, Parametros.intDVAnulado);

                    //Eliminamos el Pedido Asociado al documento de venta

                    if (pItem.IdPedido != null)
                    {
                        PedidoDL Pedido = new PedidoDL();
                        PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                        List<PedidoDetalleBE> ListaPedidoDetalle = null;
                        ListaPedidoDetalle = new PedidoDetalleDL().ListaTodosActivo(Convert.ToInt32(pItem.IdPedido));

                        foreach (PedidoDetalleBE item in ListaPedidoDetalle)
                        {
                        
                            //Eliminamos el movimiento de caja
                            /*MovimientoCajaBE objE_MovimientoCaja = null;
                            string NumeroDucumentoVenta = "";
                            NumeroDucumentoVenta = pItem.Serie + "-" + pItem.Numero;
                            objE_MovimientoCaja = new MovimientoCajaDL().SeleccionaNumero(pItem.IdTipoDocumento, NumeroDucumentoVenta);
                            if (objE_MovimientoCaja != null)
                            {
                                MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                                objE_MovimientoCaja.Usuario = pItem.Usuario;
                                objE_MovimientoCaja.Maquina = pItem.Maquina;
                                MovimientoCaja.Elimina(objE_MovimientoCaja);
                            }*/

                            List<DocumentoVentaPagoBE> ListaDocumentoVentaPago = null;
                            ListaDocumentoVentaPago = new DocumentoVentaPagoDL().ListaTodosActivo(pItem.IdEmpresa, pItem.IdDocumentoVenta);
                            foreach (DocumentoVentaPagoBE itempago in ListaDocumentoVentaPago)
                            {
                                //Eliminanos el pago del documento de venta
                                DocumentoVentaPago.Elimina(itempago);
                            }

                            if (pItem.IdTipoDocumento == Parametros.intTipoDocNotaCredito || pItem.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                            {
                                //No Actualiza nada
                            }else
                            {
                                //Actualiza la anulación del pedido
                                Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, Convert.ToInt32(pItem.IdPedido), Parametros.intPVGenerado, 0, "", pItem.Usuario, pItem.Maquina);
                            }
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        #region "Documento Venta Contado"

        public Int32 InsertaDocumentoContado(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle, MovimientoCajaBE pCajaBE, List<DocumentoVentaPagoBE> pListaDocumentoVentaPago)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    if (pItem.IdTipoDocumento == Parametros.intTipoDocTicketBoleta || pItem.IdTipoDocumento == Parametros.intTipoDocTicketFactura)
                    {
                        PromocionProximaBE objE_PromocionProxima = null;
                        objE_PromocionProxima = new PromocionProximaBL().SeleccionaActivo(pItem.IdTienda, pItem.IdFormaPago, pItem.IdTipoCliente, pItem.Total);//pItem.IdTipoCliente);
                        if (objE_PromocionProxima != null)
                            pItem.IdPromocionProxima = objE_PromocionProxima.IdPromocionProxima;
                    }

                    //Insertar Documento Venta
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = DocumentoVenta.Inserta(pItem);

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                    {
                        pItem.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    }

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                        //Insertamos el detalle del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        //item.IdKardex = IdKardex;
                        DocumentoVentaDetalle.Inserta(item);
                    }

                    //Insertamos el movimiento de caja
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    pCajaBE.IdDocumentoVenta = IdDocumentoVenta;
                    MovimientoCaja.Inserta(pCajaBE);

                    foreach (DocumentoVentaPagoBE item in pListaDocumentoVentaPago)
                    {
                        //Insertamos el pago del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        DocumentoVentaPago.Inserta(item);
                    }

                    //Actualiza Numeracion Documenteos Maestro
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();

                    if (pItem.IdEmpresa == Parametros.intPanoraramaDistribuidores)
                    {
                        objDL_NumeracionDocumento.ActualizaCorrelativoSerie(pCajaBE.IdEmpresa, pItem.IdTipoDocumento, pItem.Serie);
                    }
                    else
                    {
                        objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pCajaBE.IdEmpresa, pItem.IdTipoDocumento, Parametros.intPeriodo);
                    }

                    //Actualiza la anulación del pedido
                    PedidoDL Pedido = new PedidoDL();
                    Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado, 0,"", pItem.Usuario, pItem.Maquina);

                    
                    ts.Complete();
                    return IdDocumentoVenta;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Int32 InsertaDocumentoContadoWeb(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle, MovimientoCajaBE pCajaBE, List<DocumentoVentaPagoBE> pListaDocumentoVentaPago)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    if (pItem.IdTipoDocumento == Parametros.intTipoDocTicketBoleta || pItem.IdTipoDocumento == Parametros.intTipoDocTicketFactura)
                    {
                        PromocionProximaBE objE_PromocionProxima = null;
                        objE_PromocionProxima = new PromocionProximaBL().SeleccionaActivo(pItem.IdTienda, pItem.IdFormaPago, pItem.IdTipoCliente, pItem.Total);//pItem.IdTipoCliente);
                        if (objE_PromocionProxima != null)
                            pItem.IdPromocionProxima = objE_PromocionProxima.IdPromocionProxima;
                    }

                    //Insertar Documento Venta
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = DocumentoVenta.InsertaWeb(pItem);

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                    {
                        pItem.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    }

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                        //Insertamos el detalle del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        //item.IdKardex = IdKardex;
                        DocumentoVentaDetalle.Inserta(item);
                    }

                    //Insertamos el movimiento de caja
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    pCajaBE.IdDocumentoVenta = IdDocumentoVenta;
                    MovimientoCaja.Inserta(pCajaBE);

                    foreach (DocumentoVentaPagoBE item in pListaDocumentoVentaPago)
                    {
                        //Insertamos el pago del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        DocumentoVentaPago.Inserta(item);
                    }

                    //Actualiza Numeracion Documenteos Maestro
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();

                    if (pItem.IdEmpresa == Parametros.intPanoraramaDistribuidores)
                    {
                        objDL_NumeracionDocumento.ActualizaCorrelativoSerie(pCajaBE.IdEmpresa, pItem.IdTipoDocumento, pItem.Serie);
                    }
                    else
                    {
                        objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pCajaBE.IdEmpresa, pItem.IdTipoDocumento, Parametros.intPeriodo);
                    }

                    //Actualiza la anulación del pedido
                    PedidoDL Pedido = new PedidoDL();
                    Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado, 0, "", pItem.Usuario, pItem.Maquina);


                    ts.Complete();
                    return IdDocumentoVenta;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Int32 InsertaDocumentoContadoContinuo(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle, MovimientoCajaBE pCajaBE, List<DocumentoVentaPagoBE> pListaDocumentoVentaPago, bool NumeracionAutomatica)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    //Insertar Documento Venta
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = DocumentoVenta.Inserta(pItem);

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                    {
                        pItem.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    }

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                        //Insertamos el detalle del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        item.IdKardex = null;
                        DocumentoVentaDetalle.Inserta(item);
                    }

                    //Insertamos el movimiento de caja
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    pCajaBE.IdDocumentoVenta = IdDocumentoVenta;
                    MovimientoCaja.Inserta(pCajaBE);

                    foreach (DocumentoVentaPagoBE item in pListaDocumentoVentaPago)
                    {
                        //Insertamos el pago del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        DocumentoVentaPago.Inserta(item);
                    }

                    if (NumeracionAutomatica == true)
                    { 
                        NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                        objDL_NumeracionDocumento.ActualizaCorrelativoSerie(pCajaBE.IdEmpresa, pItem.IdTipoDocumento, pItem.Serie);                    
                    }

                    if (pItem.IdEmpresa == 13)
                    {
                        //Actualiza la anulación del pedido
                        PedidoDL Pedido = new PedidoDL();
                        Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado, 0, "", pItem.Usuario, pItem.Maquina);
                    }
                    ts.Complete();

                    return IdDocumentoVenta;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDocumentoContado(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle, MovimientoCajaBE pCajaBE, List<DocumentoVentaPagoBE> pListaDocumentoVentaPago)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdDocumentoVenta = pItem.IdDocumentoVenta;
                            item.IdKardex = null;
                            DocumentoVentaDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle del documento venta
                            DocumentoVentaDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos el movimiento de caja
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    MovimientoCaja.Actualiza(pCajaBE);

                    foreach (DocumentoVentaPagoBE item in pListaDocumentoVentaPago)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdDocumentoVenta = pItem.IdDocumentoVenta;
                            DocumentoVentaPago.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            DocumentoVentaPago.Actualiza(item);
                        }
                    }

                    //Actualizamos el documento venta
                    DocumentoVenta.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumeroSerie(DocumentoVentaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();

                    //Actualizamos el documento venta
                    DocumentoVenta.ActualizaSerieNumero(pItem.IdEmpresa, pItem.IdDocumentoVenta, pItem.Serie, pItem.Numero);

                    //Actualizamos el documento venta pago
                    DocumentoVentaPago.ActualizaSerieNumero(pItem.IdEmpresa, pItem.Serie, pItem.Numero);

                    //Actualizamos el documento venta 
                    MovimientoCaja.ActualizaSerieNumero(pItem.IdEmpresa, pItem.IdDocumentoVenta, pItem.Serie, pItem.Numero);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCliente(int IdDocumentoVenta, int IdCliente, string NumeroDocumento, string DescCliente, string Direccion)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                   
                    //Actualizamos el documento venta
                    DocumentoVenta.ActualizaCliente(IdDocumentoVenta, IdCliente, NumeroDocumento, DescCliente, Direccion);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaFecha(int IdEmpresa, int IdDocumentoVenta, DateTime Fecha)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();

                    //Actualizamos el documento venta
                    DocumentoVenta.ActualizaFecha(IdEmpresa, IdDocumentoVenta, Fecha);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaVinculoPedido(int IdDocumentoVenta, int IdPedido)
        {
            try
            {
                //using (TransactionScope ts = new TransactionScope())
                //{
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();

                    //Actualizamos el documento venta
                    DocumentoVenta.ActualizaVinculoPedido(IdDocumentoVenta,IdPedido);

                //    ts.Complete();
                //}
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaPromocionProxima(int IdDocumentoVenta, bool FlagPromocionProxima)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVenta.ActualizaPromocionProxima(IdDocumentoVenta, FlagPromocionProxima);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdEmpresa, int IdDocumentoVenta, int IdSituacion)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();

                    //Actualizamos el documento venta
                    DocumentoVenta.ActualizaSituacion(IdEmpresa, IdDocumentoVenta, IdSituacion);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }            
        }

        public void ActualizaSituacionPSE(int IdEmpresa, int IdDocumentoVenta, int IdSituacion,DateTime Fecha, string MensajeOSE, int GrupoBaja, string NumeroTicket, DateTime FecRecepcion, string DocReferencia)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();

                    //Actualizamos el documento venta
                    DocumentoVenta.ActualizaSituacionPSE(IdEmpresa, IdDocumentoVenta, IdSituacion, Fecha, MensajeOSE, GrupoBaja, NumeroTicket, FecRecepcion, DocReferencia);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaMensajeSunat(int IdDocumentoVenta, DateTime Fecha, string Mensaje)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();

                    //Actualizamos el documento venta
                    DocumentoVenta.ActualizaMensajeSunat(IdDocumentoVenta, Fecha, Mensaje);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void GrabarTicketGuia(int IdEmpresa, int IdDocumentoVenta, int IdSituacion, DateTime Fecha, string MensajeOSE, int GrupoBaja)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();

                    //Actualizamos el documento venta
                    DocumentoVenta.GrabarTicket(IdEmpresa, IdDocumentoVenta, IdSituacion, Fecha, MensajeOSE, GrupoBaja);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacionSituacion_FE(int IdEmpresa, int IdDocumentoVenta, int IdSituacion, DateTime Fecha, string MensajeOSE, string pTipoDoc, string pSerie, string pNumero)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();

                    //Actualizamos el documento venta
                    DocumentoVenta.ActualizaSituacionSituacion_FE(IdEmpresa, IdDocumentoVenta, IdSituacion, Fecha, MensajeOSE, pTipoDoc, pSerie, pNumero);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacionContable(int IdEmpresa, int IdDocumentoVenta, int IdSituacionContable)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();

                    //Actualizamos el documento venta
                    DocumentoVenta.ActualizaSituacionContable(IdEmpresa, IdDocumentoVenta, IdSituacionContable);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Copia(int IdDocumentoVenta)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();

                //Actualizamos el documento venta
                DocumentoVenta.Copia(IdDocumentoVenta);

                  ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaDocumentoContado(DocumentoVentaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    int IdEmpresa = 0;
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    List<DocumentoVentaDetalleBE> ListaDocumentoVentaDetalle = null;
                    ListaDocumentoVentaDetalle = new DocumentoVentaDetalleDL().ListaTodosActivo(pItem.IdDocumentoVenta);

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    else
                        IdEmpresa = pItem.IdEmpresa;

                    foreach (DocumentoVentaDetalleBE item in ListaDocumentoVentaDetalle)
                    {
                        //borramos el detalle del documento de venta
                        DocumentoVentaDetalle.Elimina(item);
                    }

                    //Eliminamos el movimiento de caja
                    MovimientoCajaBE objE_MovimientoCaja = null;
                    string NumeroDucumentoVenta = "";
                    NumeroDucumentoVenta = pItem.Serie + "-" + pItem.Numero;
                    objE_MovimientoCaja = new MovimientoCajaDL().SeleccionaNumero(pItem.IdEmpresa, pItem.IdTipoDocumento, NumeroDucumentoVenta);
                    if (objE_MovimientoCaja != null)
                    {
                        MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                        MovimientoCaja.Elimina(objE_MovimientoCaja);
                    }

                    List<DocumentoVentaPagoBE> ListaDocumentoVentaPago = null;
                    ListaDocumentoVentaPago = new DocumentoVentaPagoDL().ListaTodosActivo(IdEmpresa, pItem.IdDocumentoVenta);
                    foreach (DocumentoVentaPagoBE item in ListaDocumentoVentaPago)
                    {
                        //Eliminanos el pago del documento de venta
                        DocumentoVentaPago.Elimina(item);
                    }

                    //Actualiza la anulación del documento de venta
                    DocumentoVenta.ActualizaSituacion(IdEmpresa, pItem.IdDocumentoVenta, Parametros.intDVAnulado);

                    //Eliminamos el Pedido Asociado al documento de venta

                    if (pItem.IdPedido != null)
                    {
                        PedidoDL Pedido = new PedidoDL();
                        PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                        List<PedidoDetalleBE> ListaPedidoDetalle = null;
                        ListaPedidoDetalle = new PedidoDetalleDL().ListaTodosActivo(Convert.ToInt32(pItem.IdPedido));

                        foreach (PedidoDetalleBE item in ListaPedidoDetalle)
                        {
                            //Eliminanos el detalle del pedido
                            PedidoDetalle.Elimina(item);

                            //Eliminar el kardex
                            KardexBE objE_KardexElimina = new KardexBE();
                            KardexDL objDL_KardexElimina = new KardexDL();

                            objE_KardexElimina.IdEmpresa = IdEmpresa;
                            objE_KardexElimina.IdKardex = Convert.ToInt32(item.IdKardex);
                            objE_KardexElimina.Usuario = item.Usuario;
                            objE_KardexElimina.Maquina = item.Maquina;
                            objDL_KardexElimina.Elimina(objE_KardexElimina);

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

                            if (pItem.IdFormaPago == Parametros.intContado)
                            {
                                ////Insertar Kardex
                                //KardexBE objE_Kardex = new KardexBE();
                                //objE_Kardex.IdKardex = 0;
                                //objE_Kardex.IdEmpresa = IdEmpresa;
                                //objE_Kardex.Periodo = pItem.Periodo;
                                //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                                //objE_Kardex.IdAlmacen = IdAlmacen;
                                //objE_Kardex.IdProducto = item.IdProducto;
                                //objE_Kardex.Cantidad = item.Cantidad;
                                //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                                //objE_Kardex.NumeroDocumento = pItem.Numero;
                                //objE_Kardex.Observacion = "Pedido de Venta";
                                //objE_Kardex.TipoMovimiento = "I";
                                //objE_Kardex.MontoUnitarioCompra = item.ValorVenta;
                                //objE_Kardex.PrecioCostoPromedio = 0;
                                //objE_Kardex.MontoTotalCompra = 0;
                                //objE_Kardex.FlagEstado = true;
                                //objE_Kardex.Usuario = pItem.Usuario;
                                //objE_Kardex.Maquina = pItem.Maquina;

                                //KardexBE objE_KardexValorizado = new KardexBE();
                                //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(IdEmpresa, pItem.IdTienda, IdAlmacen, item.IdProducto);

                                //if (objE_KardexValorizado != null)
                                //{
                                //    objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                                //    objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                                //}

                                //KardexDL objDL_Kardex = new KardexDL();
                                //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                                //Verificar el stock
                                List<StockBE> lstStock = new List<StockBE>();
                                StockDL objDL_Stock = new StockDL();
                                lstStock = objDL_Stock.ListaProducto(IdEmpresa, pItem.IdTienda, IdAlmacen, item.IdProducto);
                                if (lstStock.Count > 0)
                                {
                                    //Actualizamos Stock
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock.IdEmpresa = IdEmpresa;
                                    objE_Stock.IdAlmacen = IdAlmacen;
                                    objE_Stock.IdProducto = item.IdProducto;
                                    objE_Stock.ValorIncrementa = item.Cantidad;
                                    objE_Stock.ValorDescuenta = 0;
                                    objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                    objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                    objE_Stock.Usuario = pItem.Usuario;
                                    objE_Stock.Maquina = pItem.Maquina;

                                    objDL_Stock.ActualizaCantidades(objE_Stock);
                                }
                                else
                                {
                                    //Insertamos Stock
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock.IdStock = 0;
                                    objE_Stock.IdEmpresa = IdEmpresa;
                                    objE_Stock.Periodo = pItem.Periodo;
                                    objE_Stock.IdAlmacen = IdAlmacen;
                                    objE_Stock.IdProducto = item.IdProducto;
                                    objE_Stock.Cantidad = item.Cantidad;
                                    objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                    objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                    objE_Stock.FlagEstado = true;
                                    objE_Stock.Usuario = pItem.Usuario;
                                    objE_Stock.Maquina = pItem.Maquina;

                                    objDL_Stock.Inserta(objE_Stock);
                                }
                            }

                            //Actualiza la anulación del pedido
                            Pedido.ActualizaSituacion(IdEmpresa, Convert.ToInt32(pItem.IdPedido), Parametros.intPVAnulado, 0,"", pItem.Usuario, pItem.Maquina);
                           
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion

        #region "Contabilidad"

        public void InsertaContabilidad(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    //Insertar Documento Venta
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = DocumentoVenta.Inserta(pItem);

                    //if (pItem.IdTienda == Parametros.intTiendaUcayali)
                    //{
                    //    pItem.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    //}

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {

                        //Establecemos el almacen correspondiente de acuerdo a la tienda
                        //int IdAlmacen = 0;

                        if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        {
                            if (item.FlagMuestra == true)
                                pItem.IdAlmacen = Parametros.intAlmTiendaUcayali;
                            else
                                pItem.IdAlmacen = Parametros.intAlmCentral;
                        }

                        if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                        {
                            pItem.IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                        }

                        if (pItem.IdTienda == Parametros.intTiendaKonceptos) pItem.IdAlmacen = Parametros.intAlmAnaquelesKonceptos;
                        if (pItem.IdTienda == Parametros.intTiendaPrescott) pItem.IdAlmacen = Parametros.intAlmPrescott;

                        //add 120815
                        item.IdAlmacen = pItem.IdAlmacen;

                        //int IdKardex = 0;
                        ////Insertar Kardex
                        //KardexBE objE_Kardex = new KardexBE();
                        //objE_Kardex.IdKardex = 0;
                        //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                        //objE_Kardex.Periodo = pItem.Periodo;
                        //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        //objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                        //objE_Kardex.IdProducto = item.IdProducto;
                        //objE_Kardex.Cantidad = item.Cantidad;
                        //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                        //objE_Kardex.NumeroDocumento = pItem.Numero;
                        //objE_Kardex.Observacion = "Salida Por Documento de Venta";
                        //objE_Kardex.TipoMovimiento = "S";
                        //objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                        //objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                        //objE_Kardex.MontoTotalCompra = item.ValorVenta;
                        //objE_Kardex.FlagEstado = true;
                        //objE_Kardex.Usuario = pItem.Usuario;
                        //objE_Kardex.Maquina = pItem.Maquina;

                        //KardexBE objE_KardexValorizado = new KardexBE();
                        //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                        //if (objE_KardexValorizado != null)
                        //{
                        //    objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                        //    objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                        //}

                        //KardexDL objDL_Kardex = new KardexDL();
                        //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = 0;
                            objE_Stock.ValorDescuenta = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0; // objE_Kardex.PrecioCostoPromedio;
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
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }

                        //Insertamos el detalle del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        item.IdKardex = 0; // IdKardex;
                        DocumentoVentaDetalle.Inserta(item);
                    }

                    #region "Nota Credito"
                    /*
                                        //En caso que sea nota de credito
                                        if (pItem.IdTipoDocumento == Parametros.intTipoDocNotaCredito)
                                        {
                                            //Generación del estado de cuenta en caso devoluciones en caso de mayoristas

                                            //Traemos los datos del pedido para especificar el cliente principal
                                            #region "por pedido"
                                            if (pItem.IdPedido != null)
                                            {
                                                PedidoBE objE_Pedido = null;
                                                objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));

                                                if (objE_Pedido != null)
                                                {
                                                    if (objE_Pedido.IdTipoCliente == Parametros.intTipClienteMayorista || objE_Pedido.IdClasificacionCliente == Parametros.intBlack)
                                                    {
                                                        //Datos del estado de cuenta
                                                        EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                                        EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();

                                                        objE_EstadoCuenta.IdEstadoCuenta = 0;
                                                        objE_EstadoCuenta.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                                                        objE_EstadoCuenta.Periodo = pItem.Periodo;
                                                        objE_EstadoCuenta.IdCliente = objE_Pedido.IdCliente;
                                                        objE_EstadoCuenta.NumeroDocumento = "SD " + pItem.NumeroDevolucion;
                                                        objE_EstadoCuenta.FechaCredito = pItem.Fecha;
                                                        objE_EstadoCuenta.FechaDeposito = null;
                                                        objE_EstadoCuenta.Concepto = "DEVOLUCION" + " NC " + pItem.Serie + "-" + pItem.Numero;
                                                        objE_EstadoCuenta.FechaVencimiento = null;
                                                        objE_EstadoCuenta.Importe = pItem.TotalVentaDolares;
                                                        objE_EstadoCuenta.ImporteAnt = pItem.TotalVentaDolares;
                                                        //    objE_EstadoCuenta.ImporteAnt = pItem.Total;
                                                        //if (pItem.IdMoneda == Parametros.intSoles)
                                                        //{
                                                        //    objE_EstadoCuenta.Importe = pItem.Total / objE_Pedido.TipoCambio;
                                                        //    objE_EstadoCuenta.ImporteAnt = pItem.Total / objE_Pedido.TipoCambio;
                                                        //}
                                                        //else
                                                        //{
                                                        //    objE_EstadoCuenta.Importe = pItem.Total;
                                                        //    objE_EstadoCuenta.ImporteAnt = pItem.Total;
                                                        //}

                                                        objE_EstadoCuenta.TipoMovimiento = "A";
                                                        objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVenta;
                                                        objE_EstadoCuenta.FlagEstado = true;
                                                        objE_EstadoCuenta.Usuario = pItem.Usuario;
                                                        objE_EstadoCuenta.Maquina = pItem.Maquina;

                                                        objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);
                                                    }
                                                }

                                            }
                                            #endregion

                                            #region "por Boleta Factura o Ticket"
                                            if (pItem.IdPedido == null)
                                            {
                                                //PedidoBE objE_Pedido = null;
                                                //objE_Pedido = new PedidoDL().Selecciona(Convert.ToInt32(pItem.IdPedido));
                                                DocumentoVentaBE objE_DocumentoVenta = null;
                                                objE_DocumentoVenta = new DocumentoVentaBL().Selecciona(Convert.ToInt32(pItem.IdDocumentoVenta));

                                                if (objE_DocumentoVenta != null)
                                                {
                                                    if (objE_DocumentoVenta.IdTipoCliente == Parametros.intTipClienteMayorista || objE_DocumentoVenta.IdClasificacionCliente == Parametros.intBlack)
                                                    {
                                                        //Datos del estado de cuenta
                                                        EstadoCuentaBE objE_EstadoCuenta = new EstadoCuentaBE();
                                                        EstadoCuentaBL objBL_EstadoCuenta = new EstadoCuentaBL();

                                                        objE_EstadoCuenta.IdEstadoCuenta = 0;
                                                        objE_EstadoCuenta.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                                                        objE_EstadoCuenta.Periodo = pItem.Periodo;
                                                        objE_EstadoCuenta.IdCliente = objE_DocumentoVenta.IdCliente;
                                                        objE_EstadoCuenta.NumeroDocumento = "SD " + pItem.NumeroDevolucion;
                                                        objE_EstadoCuenta.FechaCredito = pItem.Fecha;
                                                        objE_EstadoCuenta.FechaDeposito = null;
                                                        objE_EstadoCuenta.Concepto = "DEVOLUCION" + " NC " + pItem.Serie + "-" + pItem.Numero;
                                                        objE_EstadoCuenta.FechaVencimiento = null;
                                                        objE_EstadoCuenta.Importe = pItem.TotalVentaDolares;
                                                        objE_EstadoCuenta.ImporteAnt = pItem.TotalVentaDolares;
                                                        //    objE_EstadoCuenta.ImporteAnt = pItem.Total;
                                                        //if (pItem.IdMoneda == Parametros.intSoles)
                                                        //{
                                                        //    objE_EstadoCuenta.Importe = pItem.Total / objE_Pedido.TipoCambio;
                                                        //    objE_EstadoCuenta.ImporteAnt = pItem.Total / objE_Pedido.TipoCambio;
                                                        //}
                                                        //else
                                                        //{
                                                        //    objE_EstadoCuenta.Importe = pItem.Total;
                                                        //    objE_EstadoCuenta.ImporteAnt = pItem.Total;
                                                        //}

                                                        objE_EstadoCuenta.TipoMovimiento = "A";
                                                        objE_EstadoCuenta.IdDocumentoVenta = IdDocumentoVenta;
                                                        objE_EstadoCuenta.FlagEstado = true;
                                                        objE_EstadoCuenta.Usuario = pItem.Usuario;
                                                        objE_EstadoCuenta.Maquina = pItem.Maquina;

                                                        objBL_EstadoCuenta.Inserta(objE_EstadoCuenta);
                                                    }
                                                }

                                            }
                                            #endregion
                                        }*/
                    #endregion

                    if(pItem.IdTipoDocumento==Parametros.intTipoDocBoletaElectronica|| pItem.IdTipoDocumento == Parametros.intTipoDocFacturaElectronica|| pItem.IdTipoDocumento == Parametros.intTipoDocNotaCreditoElectronica)
                    {
                        //Actualizamos la numeración del documento //ADD 230718
                        NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                        objDL_NumeracionDocumento.ActualizaCorrelativoSerie(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Serie);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaContabilidad(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Establecemos el almacen correspondiente de acuerdo a la tienda
                            //int IdAlmacen = 0;

                            if (pItem.IdTienda == Parametros.intTiendaUcayali)
                            {
                                if (item.FlagMuestra == true)
                                    pItem.IdAlmacen = Parametros.intAlmTiendaUcayali;
                                else
                                    pItem.IdAlmacen = Parametros.intAlmCentral;
                            }

                            if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                            {
                                pItem.IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                            }

                            if (pItem.IdTienda == Parametros.intTiendaKonceptos) pItem.IdAlmacen = Parametros.intAlmAnaquelesKonceptos;

                            //-------------------------------------
                            int IdKardex = 0;
                            ////Insertar Kardex
                            //KardexBE objE_Kardex = new KardexBE();
                            //objE_Kardex.IdKardex = 0;
                            //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            //objE_Kardex.Periodo = pItem.Periodo;
                            //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            //objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                            //objE_Kardex.IdProducto = item.IdProducto;
                            //objE_Kardex.Cantidad = item.Cantidad;
                            //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                            //objE_Kardex.NumeroDocumento = pItem.Numero;
                            //objE_Kardex.Observacion = "Salida Por Documento de Venta";
                            //objE_Kardex.TipoMovimiento = "S";
                            //objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                            //objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                            //objE_Kardex.MontoTotalCompra = item.ValorVenta;
                            //objE_Kardex.FlagEstado = true;
                            //objE_Kardex.Usuario = pItem.Usuario;
                            //objE_Kardex.Maquina = pItem.Maquina;

                            //KardexBE objE_KardexValorizado = new KardexBE();
                            //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                            //if (objE_KardexValorizado != null)
                            //{
                            //    objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                            //    objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                            //}

                            //KardexDL objDL_Kardex = new KardexDL();
                            //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = pItem.IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = 0;
                                objE_Stock.ValorDescuenta = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;//objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.ActualizaCantidades(objE_Stock);
                            }
                            else
                            {
                                //Insertamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdStock = 0;
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = pItem.IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;//objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }

                            //Insertamos el detalle del documento de venta
                            item.IdDocumentoVenta = pItem.IdDocumentoVenta;
                            item.IdKardex = IdKardex;
                            DocumentoVentaDetalle.Inserta(item);
                        }
                        else
                        {
                            ////Actualizar Kardex
                            //KardexBE objE_Kardex = new KardexBE();
                            //objE_Kardex.IdKardex = Convert.ToInt32(item.IdKardex);
                            //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            //objE_Kardex.Periodo = pItem.Periodo;
                            //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            //objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                            //objE_Kardex.IdProducto = item.IdProducto;
                            //objE_Kardex.Cantidad = item.Cantidad;
                            //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                            //objE_Kardex.NumeroDocumento = pItem.Numero;
                            //objE_Kardex.Observacion = "Salida Por Documento de Venta";
                            //objE_Kardex.TipoMovimiento = "S";
                            //objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                            //objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                            //objE_Kardex.MontoTotalCompra = item.ValorVenta;
                            //objE_Kardex.FlagEstado = true;
                            //objE_Kardex.Usuario = pItem.Usuario;
                            //objE_Kardex.Maquina = pItem.Maquina;

                            //KardexBE objE_KardexValorizado = new KardexBE();
                            //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                            //if (objE_KardexValorizado != null)
                            //{
                            //    decimal dmlPCP = 0;
                            //    decimal dmlCostoTotal = 0;

                            //    if (objE_KardexValorizado.Saldo != 0)
                            //    {
                            //        //Calcula Precio Costo Promedio
                            //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                            //        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;

                            //        objE_Kardex.PrecioCostoPromedio = dmlPCP;
                            //        objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                            //    }

                            //}
                            //else
                            //{
                            //    objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                            //}

                            //KardexDL objDL_Kardex = new KardexDL();
                            //objDL_Kardex.Actualiza(objE_Kardex);

                            //Actualizar Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = item.Cantidad;
                            objE_Stock.ValorDescuenta = item.CantidadAnt;
                            objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            StockDL objDL_Stock = new StockDL();
                            objDL_Stock.ActualizaCantidades(objE_Stock);

                            //Actualizamos el detalle del documento venta
                            DocumentoVentaDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos el documento venta
                    DocumentoVenta.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaContabilidad(DocumentoVentaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    int IdEmpresa = 0;
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();

                    List<DocumentoVentaDetalleBE> ListaDocumentoVentaDetalle = null;
                    ListaDocumentoVentaDetalle = new DocumentoVentaDetalleDL().ListaTodosActivo(pItem.IdDocumentoVenta);

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    else
                        IdEmpresa = pItem.IdEmpresa;

                    foreach (DocumentoVentaDetalleBE item in ListaDocumentoVentaDetalle)
                    {
                        int IdKardex = 0;
                        ////Insertar Kardex
                        //KardexBE objE_Kardex = new KardexBE();
                        //objE_Kardex.IdKardex = 0;
                        //objE_Kardex.IdEmpresa = IdEmpresa;
                        //objE_Kardex.Periodo = pItem.Periodo;
                        //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        //objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                        //objE_Kardex.IdProducto = item.IdProducto;
                        //objE_Kardex.Cantidad = item.Cantidad;
                        //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                        //objE_Kardex.NumeroDocumento = pItem.Numero;
                        //objE_Kardex.Observacion = "Ingreso por Anulación de Documento de Venta";
                        //objE_Kardex.TipoMovimiento = "I";
                        //objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                        //objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                        //objE_Kardex.MontoTotalCompra = item.ValorVenta;
                        //objE_Kardex.FlagEstado = true;
                        //objE_Kardex.Usuario = pItem.Usuario;
                        //objE_Kardex.Maquina = pItem.Maquina;

                        //KardexBE objE_KardexValorizado = new KardexBE();
                        //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                        //if (objE_KardexValorizado != null)
                        //{
                        //    objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                        //    objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                        //}

                        //KardexDL objDL_Kardex = new KardexDL();
                        //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = item.Cantidad;
                            objE_Stock.ValorDescuenta = 0;
                            objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;//objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.ActualizaCantidades(objE_Stock);
                        }
                        else
                        {
                            //Insertamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdStock = 0;
                            objE_Stock.IdEmpresa = IdEmpresa;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;//objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }

                        //borramos el detalle del documento de venta
                        DocumentoVentaDetalle.Elimina(item);
                    }

                    //Actualiza la anulación del documento de venta
                    DocumentoVenta.ActualizaSituacion(IdEmpresa, pItem.IdDocumentoVenta, Parametros.intDVAnulado);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaEmpresaTraslado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaEmpresaTraslado(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaGuiaEmpresaTraslado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaGuiaEmpresaTraslado(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaFisico(DocumentoVentaBE pItem)//int IdDocumentoVenta)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    int IdEmpresa = 0;

                    //Elimina QUe no deje Rastro
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVenta.EliminaFisico(pItem);

                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();

                    List<DocumentoVentaDetalleBE> ListaDocumentoVentaDetalle = null;
                    ListaDocumentoVentaDetalle = new DocumentoVentaDetalleDL().ListaTodosActivo(pItem.IdDocumentoVenta);

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    else
                        IdEmpresa = pItem.IdEmpresa;

                    //foreach (DocumentoVentaDetalleBE item in ListaDocumentoVentaDetalle)
                    //{
                    //    int IdKardex = 0;
                    //    //Insertar Kardex
                    //    KardexBE objE_Kardex = new KardexBE();
                    //    objE_Kardex.IdKardex = 0;
                    //    objE_Kardex.IdEmpresa = IdEmpresa;
                    //    objE_Kardex.Periodo = pItem.Periodo;
                    //    objE_Kardex.FechaMovimiento = Convert.ToDateTime(Parametros.dtFechaHoraServidor);
                    //    objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                    //    objE_Kardex.IdProducto = item.IdProducto;
                    //    objE_Kardex.Cantidad = item.Cantidad;
                    //    objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                    //    objE_Kardex.NumeroDocumento = pItem.Numero;
                    //    objE_Kardex.Observacion = "Ingreso por Eliminación de Documento de Venta";
                    //    objE_Kardex.TipoMovimiento = "I";
                    //    objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                    //    objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                    //    objE_Kardex.MontoTotalCompra = item.ValorVenta;
                    //    objE_Kardex.FlagEstado = true;
                    //    objE_Kardex.Usuario = pItem.Usuario;
                    //    objE_Kardex.Maquina = pItem.Maquina;

                    //    KardexBE objE_KardexValorizado = new KardexBE();
                    //    objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                    //    if (objE_KardexValorizado != null)
                    //    {
                    //        objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                    //        objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                    //    }

                    //    KardexDL objDL_Kardex = new KardexDL();
                    //    IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                    //    //Verificar el stock
                    //    List<StockBE> lstStock = new List<StockBE>();
                    //    StockDL objDL_Stock = new StockDL();
                    //    lstStock = objDL_Stock.ListaProducto(IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);
                    //    if (lstStock.Count > 0)
                    //    {
                    //        //Actualizamos Stock
                    //        StockBE objE_Stock = new StockBE();
                    //        objE_Stock.IdEmpresa = IdEmpresa;
                    //        objE_Stock.IdAlmacen = pItem.IdAlmacen;
                    //        objE_Stock.IdProducto = item.IdProducto;
                    //        objE_Stock.ValorIncrementa = item.Cantidad;
                    //        objE_Stock.ValorDescuenta = 0;
                    //        objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                    //        objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                    //        objE_Stock.Usuario = pItem.Usuario;
                    //        objE_Stock.Maquina = pItem.Maquina;

                    //        objDL_Stock.ActualizaCantidades(objE_Stock);
                    //    }
                    //    else
                    //    {
                    //        //Insertamos Stock
                    //        StockBE objE_Stock = new StockBE();
                    //        objE_Stock.IdStock = 0;
                    //        objE_Stock.IdEmpresa = IdEmpresa;
                    //        objE_Stock.Periodo = pItem.Periodo;
                    //        objE_Stock.IdAlmacen = pItem.IdAlmacen;
                    //        objE_Stock.IdProducto = item.IdProducto;
                    //        objE_Stock.Cantidad = item.Cantidad;
                    //        objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                    //        objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                    //        objE_Stock.FlagEstado = true;
                    //        objE_Stock.Usuario = pItem.Usuario;
                    //        objE_Stock.Maquina = pItem.Maquina;

                    //        objDL_Stock.Inserta(objE_Stock);
                    //    }

                    //}



                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 InsertaDocumentoContadoPagoVarios(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle, List<MovimientoCajaBE> pListaCajaBE, List<DocumentoVentaPagoBE> pListaDocumentoVentaPago, int IdDocumentoNC)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    PagosDL Pagos = new PagosDL();

                    //Insertar Documento Venta
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = DocumentoVenta.Inserta(pItem);

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                        int IdKardex = 0;
                        //Insertar Kardex
                        /*KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = 0;
                        objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                        objE_Kardex.Periodo = pItem.Periodo;
                        objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                        objE_Kardex.IdProducto = item.IdProducto;
                        objE_Kardex.Cantidad = item.Cantidad;
                        objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                        objE_Kardex.NumeroDocumento = pItem.Numero;
                        objE_Kardex.Observacion = "Salida Por Documento de Venta - Autoservicio";
                        objE_Kardex.TipoMovimiento = "S";
                        objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                        objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                        objE_Kardex.MontoTotalCompra = item.ValorVenta;
                        objE_Kardex.FlagEstado = true;
                        objE_Kardex.Usuario = pItem.Usuario;
                        objE_Kardex.Maquina = pItem.Maquina;

                        KardexBE objE_KardexValorizado = new KardexBE();
                        objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                        if (objE_KardexValorizado != null)
                        {
                            objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                            objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                        }

                        KardexDL objDL_Kardex = new KardexDL();
                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = 0;
                            objE_Stock.ValorDescuenta = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.ActualizaCantidades(objE_Stock);
                        }
                        else
                        {
                            //Insertamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdStock = 0;
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = pItem.IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }

                        //Insertamos el detalle del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        item.IdKardex = IdKardex;
                        DocumentoVentaDetalle.Inserta(item);
                    }

                    //Insertamos el movimiento de caja
                    foreach (MovimientoCajaBE item in pListaCajaBE)
                    {
                        //Insertamos el detalle movimientoCaja
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        MovimientoCaja.Inserta(item);
                    }


                    foreach (DocumentoVentaPagoBE item in pListaDocumentoVentaPago)
                    {
                        //Insertamos el pago del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        DocumentoVentaPago.Inserta(item);
                    }

                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoSerie(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Serie);

                    //Actualiza la anulación del pedido
                    PedidoDL Pedido = new PedidoDL();
                    Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado, 0,"", pItem.Usuario, pItem.Maquina);

                    ////Verifica nota Credito
                    //if (NumeroNotaCredito.Length > 1)
                    //{
                    //    Pagos.ActualizaNotaCredito(NumeroNotaCredito, IdDocumentoVenta);
                    //}

                    //Actualizar Caja a Nota Credito
                    if(IdDocumentoNC>0)
                    {
                        MovimientoCaja.ActualizaReferencia(pItem.IdEmpresa, IdDocumentoVenta, IdDocumentoNC);
                    }

                    ts.Complete();

                    return IdDocumentoVenta;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 InsertaDocumentoContadoPagoVariosAutoservicios(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle, List<MovimientoCajaBE> pListaCajaBE, List<DocumentoVentaPagoBE> pListaDocumentoVentaPago, int IdDocumentoNC, bool NumeracionAutomatica)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    PagosDL Pagos = new PagosDL();

                    //Insertar Documento Venta
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = DocumentoVenta.Inserta(pItem);

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                        //Insertamos el detalle del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        item.IdKardex = null;
                        DocumentoVentaDetalle.Inserta(item);
                    }

                    //Insertamos el movimiento de caja
                    foreach (MovimientoCajaBE item in pListaCajaBE)
                    {
                        //Insertamos el detalle movimientoCaja
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        MovimientoCaja.Inserta(item);
                    }


                    foreach (DocumentoVentaPagoBE item in pListaDocumentoVentaPago)
                    {
                        //Insertamos el pago del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        DocumentoVentaPago.Inserta(item);
                    }

                    if (NumeracionAutomatica == true)
                    {
                        NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                        objDL_NumeracionDocumento.ActualizaCorrelativoSerie(pItem.IdEmpresa, pItem.IdTipoDocumento, pItem.Serie);                    
                    }

                    //Actualiza la anulación del pedido
                    PedidoDL Pedido = new PedidoDL();
                    Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado, 0,"", pItem.Usuario, pItem.Maquina);

                    ////Verifica nota Credito
                    //if (NumeroNotaCredito.Length > 1)
                    //{
                    //    Pagos.ActualizaNotaCredito(NumeroNotaCredito, IdDocumentoVenta);
                    //}

                    //Actualizar Caja a Nota Credito
                    if (IdDocumentoNC > 0)
                    {
                        MovimientoCaja.ActualizaReferencia(pItem.IdEmpresa, IdDocumentoVenta, IdDocumentoNC);
                    }

                    ts.Complete();

                    return IdDocumentoVenta;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion

        #region "Creditos y Cobranzas"

        public void InsertaCredito(EstadoCuentaBE objEstadoCuenta, SeparacionBE objSeparacion)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    if (objEstadoCuenta != null)
                    {
                        EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();
                        //objEstadoCuenta.IdCotizacion = IdCotizacion;
                        EstadoCuenta.Inserta(objEstadoCuenta);
                        
                        ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                        ClienteCredito.ActualizaLineaCreditoUtilizada(Parametros.intEmpresaId, objEstadoCuenta.IdCliente, objEstadoCuenta.Importe, 0, objEstadoCuenta.IdMotivo);
                    }

                    if (objSeparacion != null)
                    {
                        SeparacionDL Separacion = new SeparacionDL();
                        //objSeparacion.IdCotizacion = IdCotizacion;
                        Separacion.Inserta(objSeparacion);

                        //ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                        //ClienteCredito.ActualizaLineaCreditoUtilizada(Parametros.intEmpresaId, objEstadoCuenta.IdCliente, objEstadoCuenta.Importe, 0, objEstadoCuenta.IdMotivo);
                    }

                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocFacturaCredito, Parametros.intPeriodo);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 InsertaCredito2(EstadoCuentaBE objEstadoCuenta, SeparacionBE objSeparacion)
        {
            try
            {
                int IdEstadoCuenta = 0;
                using (TransactionScope ts = new TransactionScope())
                {
                    if (objEstadoCuenta != null)
                    {
                        EstadoCuentaDL EstadoCuenta = new EstadoCuentaDL();

                        IdEstadoCuenta = EstadoCuenta.Inserta2(objEstadoCuenta);

                        ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                        ClienteCredito.ActualizaLineaCreditoUtilizada(Parametros.intEmpresaId, objEstadoCuenta.IdCliente, objEstadoCuenta.Importe, 0, objEstadoCuenta.IdMotivo);
                    }

                    if (objSeparacion != null)
                    {
                        SeparacionDL Separacion = new SeparacionDL();
                         IdEstadoCuenta = Separacion.Inserta_Sep(objSeparacion);

                        //ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                        //ClienteCredito.ActualizaLineaCreditoUtilizada(Parametros.intEmpresaId, objEstadoCuenta.IdCliente, objEstadoCuenta.Importe, 0, objEstadoCuenta.IdMotivo);
                    }

                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocFacturaCredito, Parametros.intPeriodo);

                    ts.Complete();

                    return IdEstadoCuenta;
                }


            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaCreditoComisionDiseñador(EstadoCuentaComisionBE objEstadoCuentaComision)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {

                    if (objEstadoCuentaComision != null)
                    {
                        EstadoCuentaComisionDL EstadoCuentaComision = new EstadoCuentaComisionDL();
                        //objEstadoCuentaComision.IdCotizacion = IdCotizacion;
                        EstadoCuentaComision.Inserta(objEstadoCuentaComision);

                        //ClienteCreditoDL ClienteCredito = new ClienteCreditoDL();
                        //ClienteCredito.ActualizaLineaCreditoUtilizada(Parametros.intEmpresaId, objEstadoCuenta.IdCliente, objEstadoCuenta.Importe, 0, objEstadoCuenta.IdMotivo);
                    }

                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intEmpresaId, Parametros.intTipoDocSaldoFavorDiseño, Parametros.intPeriodo);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        #endregion


        public void InsertaDocumentoContadoEmergency(DocumentoVentaBE pItem, List<DocumentoVentaDetalleBE> pListaDocumentoVentaDetalle, MovimientoCajaBE pCajaBE, List<DocumentoVentaPagoBE> pListaDocumentoVentaPago)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                    DocumentoVentaDetalleDL DocumentoVentaDetalle = new DocumentoVentaDetalleDL();
                    DocumentoVentaPagoDL DocumentoVentaPago = new DocumentoVentaPagoDL();

                    if (pItem.IdTipoDocumento == Parametros.intTipoDocTicketBoleta || pItem.IdTipoDocumento == Parametros.intTipoDocTicketFactura)
                    {
                        PromocionProximaBE objE_PromocionProxima = null;
                        objE_PromocionProxima = new PromocionProximaBL().SeleccionaActivo(pItem.IdTienda, pItem.IdFormaPago, pItem.IdTipoCliente, pItem.Total);//pItem.IdTipoCliente);
                        if (objE_PromocionProxima != null)
                            pItem.IdPromocionProxima = objE_PromocionProxima.IdPromocionProxima;
                    }

                    //Insertar Documento Venta
                    int IdDocumentoVenta = 0;
                    IdDocumentoVenta = DocumentoVenta.Inserta(pItem);

                    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                    {
                        pItem.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                    }

                    foreach (DocumentoVentaDetalleBE item in pListaDocumentoVentaDetalle)
                    {
                        /*int IdKardex = 0;
                        //Insertar Kardex
                        KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = 0;
                        objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                        objE_Kardex.Periodo = pItem.Periodo;
                        objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        objE_Kardex.IdAlmacen = pItem.IdAlmacen;
                        objE_Kardex.IdProducto = item.IdProducto;
                        objE_Kardex.Cantidad = item.Cantidad;
                        objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                        objE_Kardex.NumeroDocumento = pItem.Numero;
                        objE_Kardex.Observacion = "Salida Por Documento de Venta - Contado";
                        objE_Kardex.TipoMovimiento = "S";
                        objE_Kardex.MontoUnitarioCompra = item.PrecioVenta;
                        objE_Kardex.PrecioCostoPromedio = item.PrecioVenta;
                        objE_Kardex.MontoTotalCompra = item.ValorVenta;
                        objE_Kardex.FlagEstado = true;
                        objE_Kardex.Usuario = pItem.Usuario;
                        objE_Kardex.Maquina = pItem.Maquina;

                        KardexBE objE_KardexValorizado = new KardexBE();
                        objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);

                        if (objE_KardexValorizado != null)
                        {
                            objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                            objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                        }

                        KardexDL objDL_Kardex = new KardexDL();
                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

                        ////Verificar el stock
                        //List<StockBE> lstStock = new List<StockBE>();
                        //StockDL objDL_Stock = new StockDL();
                        //lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacen, item.IdProducto);
                        //if (lstStock.Count > 0)
                        //{
                        //    //Actualizamos Stock
                        //    StockBE objE_Stock = new StockBE();
                        //    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        //    objE_Stock.IdAlmacen = pItem.IdAlmacen;
                        //    objE_Stock.IdProducto = item.IdProducto;
                        //    objE_Stock.ValorIncrementa = 0;
                        //    objE_Stock.ValorDescuenta = item.Cantidad;
                        //    objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                        //    objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                        //    objE_Stock.Usuario = pItem.Usuario;
                        //    objE_Stock.Maquina = pItem.Maquina;

                        //    objDL_Stock.ActualizaCantidades(objE_Stock);
                        //}
                        //else
                        //{
                        //    //Insertamos Stock
                        //    StockBE objE_Stock = new StockBE();
                        //    objE_Stock.IdStock = 0;
                        //    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        //    objE_Stock.Periodo = pItem.Periodo;
                        //    objE_Stock.IdAlmacen = pItem.IdAlmacen;
                        //    objE_Stock.IdProducto = item.IdProducto;
                        //    objE_Stock.Cantidad = item.Cantidad;
                        //    objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                        //    objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                        //    objE_Stock.FlagEstado = true;
                        //    objE_Stock.Usuario = pItem.Usuario;
                        //    objE_Stock.Maquina = pItem.Maquina;

                        //    objDL_Stock.Inserta(objE_Stock);
                        //}

                        //Insertamos el detalle del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        //item.IdKardex = IdKardex;
                        DocumentoVentaDetalle.Inserta(item);
                    }

                    //Insertamos el movimiento de caja
                    MovimientoCajaDL MovimientoCaja = new MovimientoCajaDL();
                    pCajaBE.IdDocumentoVenta = IdDocumentoVenta;
                    MovimientoCaja.Inserta(pCajaBE);

                    foreach (DocumentoVentaPagoBE item in pListaDocumentoVentaPago)
                    {
                        //Insertamos el pago del documento de venta
                        item.IdDocumentoVenta = IdDocumentoVenta;
                        DocumentoVentaPago.Inserta(item);
                    }


                    //Actualiza la anulación del pedido
                    PedidoDL Pedido = new PedidoDL();
                    Pedido.ActualizaSituacion(Parametros.intIdPanoramaDistribuidores, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado, 0, "", pItem.Usuario, pItem.Maquina);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaPendientePSE(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaPendientePSE(IdEmpresa, IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaPendienteBajaFE(int IdEmpresa, int IdTipoDocumento)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaPendienteBajaFE(IdEmpresa, IdTipoDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<DocumentoVentaBE> ListaPendienteBajaBE(int IdEmpresa, int IdTipoDocumento,int IdDocumentoVenta)
        {
            try
            {
                DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();
                return DocumentoVenta.ListaPendienteBajaBE(IdEmpresa, IdTipoDocumento, IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
