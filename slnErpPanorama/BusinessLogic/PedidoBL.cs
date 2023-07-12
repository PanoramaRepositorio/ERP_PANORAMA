using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PedidoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<PedidoBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int Periodo, int Mes)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaTodosActivo(IdEmpresa, IdTienda, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaContadoAlmacen(int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaContadoAlmacen(IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaContadoAlmacenLiberacionPedido(int IdPedido)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaContadoAlmacenLiberacionNum(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<PedidoBE> ListaContadoAlmacenNumero(int Periodo, string Numero)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaContadoAlmacenNumero(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaCredito(DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaCredito(FechaDesde, FechaHasta, TipoReporte);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaCreditoNumero(int Periodo, string Numero)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaCreditoNumero(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaContado(int IdEmpresa, int IdTienda, DateTime Fecha, int IdSituacion)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaContado(IdEmpresa, IdTienda, Fecha, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaContadoWeb(int IdEmpresa, int IdTienda, DateTime Fecha, int IdSituacion)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaContadoWeb(IdEmpresa, IdTienda, Fecha, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFechaVendedor(DateTime FechaDesde, DateTime FechaHasta, int IdVendedor)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaVendedor(FechaDesde, FechaHasta, IdVendedor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFechaPrePedidosWeb(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaPrePedidosWeb(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<PedidoBE> ListaFechaCliente(DateTime FechaDesde, DateTime FechaHasta, int IdCliente)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaCliente(FechaDesde, FechaHasta, IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaContratoFabricacion(int IdContratoFabricacion)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaContratoFabricacion(IdContratoFabricacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaProyecto(int IdProyecto)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaProyecto(IdProyecto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaClientePorCobrar(int IdCliente)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaClientePorCobrar(IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFecha(FechaDesde, FechaHasta, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFechaResumen(DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaResumen(FechaDesde, FechaHasta, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFechaChequeo(DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaChequeo(FechaDesde, FechaHasta, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFechaArmado(DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaArmado(FechaDesde, FechaHasta, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFechaEstadoCuenta(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaEstadoCuenta(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFechaEstadoCuentaPedido(int Periodo, string Numero)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaEstadoCuentaPedido(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFechaDocumentoEstadoCuenta(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaDocumentoEstadoCuenta(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaDocumentoEstadoCuentaNumero(int Periodo, string Numero)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaDocumentoEstadoCuentaNumero(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaDocumentoEstadoCuentaConcepto(int Periodo, string Concepto)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaDocumentoEstadoCuentaConcepto(Periodo, Concepto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFechaSituacion(DateTime FechaDesde, DateTime FechaHasta, int IdSituacion)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaSituacion(FechaDesde, FechaHasta, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<PedidoBE> ListaFechaCalidad(DateTime FechaDesde, DateTime FechaHasta, int IdSituacion, int TipoConsulta, int Periodo, string Numero)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaCalidad(FechaDesde, FechaHasta, IdSituacion, TipoConsulta, Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaFechaSituacion2(DateTime FechaDesde, DateTime FechaHasta, int IdSituacion)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaSituacion2(FechaDesde, FechaHasta, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<PedidoBE> ListaFechaSituacionAlmacen(DateTime FechaDesde, DateTime FechaHasta, int IdSituacion, int IdSituacionAlmacen)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaFechaSituacionAlmacen(FechaDesde, FechaHasta, IdSituacion, IdSituacionAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PedidoBE Selecciona(int IdPedido)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                PedidoBE objAna = Pedido.Selecciona(IdPedido);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PedidoBE SeleccionaPedidoPrestashop(int IdPedido)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                PedidoBE objAna = Pedido.SeleccionaPedidoPrestashop(IdPedido);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PedidoBE SeleccionaWeb(int IdPedido)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                PedidoBE objAna = Pedido.SeleccionaWeb(IdPedido);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PedidoBE SeleccionaNumero(int Periodo, string Numero)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                PedidoBE objAna = Pedido.SeleccionaNumero(Periodo, Numero);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PedidoBE SeleccionaClientePreventa(int Periodo, int IdCliente)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                PedidoBE objAna = Pedido.SeleccionaClientePreventa(Periodo, IdCliente);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PedidoBE SeleccionaImpresion(int IdPedido)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                PedidoBE objAna = Pedido.SeleccionaImpresion(IdPedido);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PedidoBE SeleccionaSituacion(int IdPedido)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                PedidoBE objAna = Pedido.SeleccionaSituacion(IdPedido);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaNumero(int Periodo, string Numero)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaNumero(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaNumeroChequeo(int Periodo, string Numero)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaNumeroChequeo(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoBE> ListaPedidoClientesMayoristasFecha(DateTime FechaDesde, DateTime FechaHasta, int IdRuta)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                return Pedido.ListaPedidoClientesMayoristasFecha(FechaDesde, FechaHasta, IdRuta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(PedidoBE pItem, List<PedidoDetalleBE> pListaPedidoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    string sNumero = "";

                    //Obtenemos el correlativo
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intPanoraramaDistribuidores, pItem.IdTipoDocumento, Parametros.intPeriodo);
                    

                    if (mListaNumero.Count > 0)
                    {
                        sNumero = AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 7);
                    }

                    //Actualizamos el correlativo de la tabla principal de correlativos
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intPanoraramaDistribuidores, pItem.IdTipoDocumento, pItem.Periodo);
                    //objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intEmpresaId, pItem.IdTipoDocumento, pItem.Periodo);

                    //Insertar en el pedido
                    int IdPedido = 0;
                    pItem.Numero = sNumero;
                    IdPedido = Pedido.Inserta(pItem);

                    foreach (PedidoDetalleBE item in pListaPedidoDetalle)
                    {
                     
                        int IdKardex = 0;

                        //    //Establecemos el almacen correspondiente de acuerdo a la tienda

                        int IdAlmacen = Parametros.intAlmCentral;

                        if (item.IdAlmacen != null || item.IdAlmacen > 0) //ADD
                        {
                            IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                        }

                        #region "Vers Anterior"

                        //int IdAlmacen = 0;

                        /*if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        {
                            //IdAlmacen = Parametros.intAlmCentral;
                            if (item.IdAlmacen == null || item.IdAlmacen == 0)
                                IdAlmacen = Parametros.intAlmCentral;
                            else
                                IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                        }

                        if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                        {
                            IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                        }

                        if (pItem.IdTienda == Parametros.intTiendaKonceptos)
                        {
                            IdAlmacen = Parametros.intAlmAnaquelesKonceptos;
                        }

                        if (pItem.IdTienda == Parametros.intTiendaPrescott)
                        {
                            IdAlmacen = Parametros.intAlmPrescott;
                        }*/


                        //    if (pItem.FlagPreVenta)
                        //    {
                        //        //Insertamos el detalle del pedido
                        //        item.IdPedido = IdPedido;
                        //        item.IdKardex = null;

                        //        PedidoDetalle.Inserta(item);
                        //    }
                        #endregion

                        if (pItem.FlagPreVenta == false)
                        {
                            
                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(Parametros.intEmpresaId, pItem.IdTienda, IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = 0;
                                objE_Stock.ValorDescuenta = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
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
                                objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }

                            if (item.IdAlmacen != item.IdAlmacenOrigen)
                            {
                                //Movimiento Almacén
                                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                                objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                                objMovimientoAlmacen.Periodo = pItem.Periodo;
                                objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                                objMovimientoAlmacen.Numero = "";
                                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                                objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(item.IdAlmacenOrigen); //Convert.ToInt32(cboAlmacen.EditValue);
                                objMovimientoAlmacen.Fecha = pItem.Fecha;
                                objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                                objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                                objMovimientoAlmacen.Referencia = "";
                                objMovimientoAlmacen.Observaciones = "VEND: " + pItem.DescVendedor;
                                objMovimientoAlmacen.IdAlmacenDestino = item.IdAlmacen; //Parametros.intAlmCentralUcayali;
                                objMovimientoAlmacen.IdCliente = pItem.IdCliente == null ? (int?)null : pItem.IdCliente;
                                objMovimientoAlmacen.FlagEstado = true;
                                objMovimientoAlmacen.Usuario = pItem.Usuario;//Usuario
                                objMovimientoAlmacen.Maquina = pItem.Maquina;
                                objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                                objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                                objMovimientoAlmacen.IdAuxiliar = pItem.IdVendedor;
                                objMovimientoAlmacen.IdPedido = IdPedido;
                                objMovimientoAlmacen.IdProducto = item.IdProducto; //add 270516
                                objMovimientoAlmacen.Cantidad = item.Cantidad;

                                item.IdMovimientoAlmacenDetalle = objBL_MovimientoAlmacen.InsertaSalidaEntrada(objMovimientoAlmacen);
                            }

                        }

                        //Insertamos el detalle del pedido
                        item.IdPedido = IdPedido;
                        item.Usuario = pItem.Usuario;
                        item.Maquina = pItem.Maquina;
                        item.IdKardex = null;
                        PedidoDetalle.Inserta(item);
                    }

                    //Actualiza Pedido Situacion
                    if (pItem.bOrigenFlagPreVenta && pItem.IdPedidoReferencia != null)
                    {
                        Pedido.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdPedidoReferencia), Parametros.intPVEnProceso, pItem.IdVendedor, "", pItem.Usuario, pItem.Maquina);
                    }


                    ts.Complete();

                    return IdPedido;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Int32 InsertaWeb(PedidoBE pItem, List<PedidoDetalleBE> pListaPedidoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    string sNumero = "";

                    //Obtenemos el correlativo
                    List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intPanoraramaDistribuidores, pItem.IdTipoDocumento, Parametros.intPeriodo);
                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, pItem.IdTipoDocumento, Parametros.intPeriodo);
                    if (mListaNumero.Count > 0)
                    {
                        sNumero = AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 7);
                    }

                    //Actualizamos el correlativo de la tabla principal de correlativos
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intPanoraramaDistribuidores, pItem.IdTipoDocumento, pItem.Periodo);
                    //objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intEmpresaId, pItem.IdTipoDocumento, pItem.Periodo);

                    //Insertar en el pedido
                    int IdPedido = 0;
                    pItem.Numero = sNumero;
                    IdPedido = Pedido.Inserta_PedidoWEB(pItem);

                    foreach (PedidoDetalleBE item in pListaPedidoDetalle)
                    {
                        //if (pItem.IdFormaPago == Parametros.intContado || pItem.IdFormaPago == Parametros.intConsignacion || pItem.IdFormaPago == Parametros.intSeparacion || pItem.IdFormaPago == Parametros.intCopagan || pItem.IdFormaPago == Parametros.intContraEntrega || pItem.IdFormaPago == Parametros.intObsequio || pItem.IdFormaPago == Parametros.intASAF)
                        //{
                        int IdKardex = 0;

                        //    //Establecemos el almacen correspondiente de acuerdo a la tienda

                        int IdAlmacen = Parametros.intAlmCentral;

                        if (item.IdAlmacen != null || item.IdAlmacen > 0) //ADD
                        {
                            IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                        }

                        #region "Vers Anterior"

                        //int IdAlmacen = 0;

                        /*if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        {
                            //IdAlmacen = Parametros.intAlmCentral;
                            if (item.IdAlmacen == null || item.IdAlmacen == 0)
                                IdAlmacen = Parametros.intAlmCentral;
                            else
                                IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                        }

                        if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                        {
                            IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                        }

                        if (pItem.IdTienda == Parametros.intTiendaKonceptos)
                        {
                            IdAlmacen = Parametros.intAlmAnaquelesKonceptos;
                        }

                        if (pItem.IdTienda == Parametros.intTiendaPrescott)
                        {
                            IdAlmacen = Parametros.intAlmPrescott;
                        }*/


                        //    if (pItem.FlagPreVenta)
                        //    {
                        //        //Insertamos el detalle del pedido
                        //        item.IdPedido = IdPedido;
                        //        item.IdKardex = null;

                        //        PedidoDetalle.Inserta(item);
                        //    }
                        #endregion

                        if (pItem.FlagPreVenta == false)
                        {
                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(Parametros.intEmpresaId, pItem.IdTienda, IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = 0;
                                objE_Stock.ValorDescuenta = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
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
                                objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }

                            if (item.IdAlmacen != item.IdAlmacenOrigen)
                            {
                                //Movimiento Almacén
                                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                                objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                                objMovimientoAlmacen.Periodo = pItem.Periodo;
                                objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                                objMovimientoAlmacen.Numero = "";
                                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                                objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(item.IdAlmacenOrigen); //Convert.ToInt32(cboAlmacen.EditValue);
                                objMovimientoAlmacen.Fecha = pItem.Fecha;
                                objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                                objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                                objMovimientoAlmacen.Referencia = "";
                                objMovimientoAlmacen.Observaciones = "VEND: " + pItem.DescVendedor;
                                objMovimientoAlmacen.IdAlmacenDestino = item.IdAlmacen; //Parametros.intAlmCentralUcayali;
                                objMovimientoAlmacen.IdCliente = pItem.IdCliente == null ? (int?)null : pItem.IdCliente;
                                objMovimientoAlmacen.FlagEstado = true;
                                objMovimientoAlmacen.Usuario = pItem.Usuario;//Usuario
                                objMovimientoAlmacen.Maquina = pItem.Maquina;
                                objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                                objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                                objMovimientoAlmacen.IdAuxiliar = pItem.IdVendedor;
                                objMovimientoAlmacen.IdPedido = IdPedido;
                                objMovimientoAlmacen.IdProducto = item.IdProducto; //add 270516
                                objMovimientoAlmacen.Cantidad = item.Cantidad;

                                item.IdMovimientoAlmacenDetalle = objBL_MovimientoAlmacen.InsertaSalidaEntrada(objMovimientoAlmacen);
                            }

                        }

                        //Insertamos el detalle del pedido
                        item.IdPedido = IdPedido;
                        item.Usuario = pItem.Usuario;
                        item.Maquina = pItem.Maquina;
                        item.IdKardex = null;
                        PedidoDetalle.Inserta(item);
                    }

                    //Actualiza Pedido Situacion
                    if (pItem.bOrigenFlagPreVenta && pItem.IdPedidoReferencia != null)
                    {
                        Pedido.ActualizaSituacion2(pItem.IdEmpresa, Convert.ToInt32(pItem.IdPedidoReferencia), Parametros.intPVEnProceso, pItem.IdVendedor, "", pItem.Usuario, pItem.Maquina);
                    }


                    ts.Complete();

                    return IdPedido;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PedidoBE pItem, List<PedidoDetalleBE> pListaPedidoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    foreach (PedidoDetalleBE item in pListaPedidoDetalle)
                    {
                        //int IdKardex = 0;

                        ////Establecemos el almacen correspondiente de acuerdo a la tienda

                        int IdAlmacen = Parametros.intAlmCentral;

                        if (item.IdAlmacen != null || item.IdAlmacen > 0) //ADD
                        {
                            IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                        }
                        /*int IdAlmacen = 0;

                        if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        {
                            //IdAlmacen = Parametros.intAlmCentral;
                            if (item.IdAlmacen == null || item.IdAlmacen == 0)
                                IdAlmacen = Parametros.intAlmCentral;
                            else
                                IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                        }

                        if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                        {
                            IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                        }

                        if (pItem.IdTienda == Parametros.intTiendaKonceptos)
                        {
                            IdAlmacen = Parametros.intAlmAnaquelesKonceptos;
                        }

                        if (pItem.IdTienda == Parametros.intTiendaPrescott)
                        {
                            IdAlmacen = Parametros.intAlmPrescott;
                        }*/

                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //if (pItem.IdFormaPago == Parametros.intContado || pItem.IdFormaPago == Parametros.intConsignacion || pItem.IdFormaPago == Parametros.intSeparacion || pItem.IdFormaPago == Parametros.intCopagan || pItem.IdFormaPago == Parametros.intContraEntrega || pItem.IdFormaPago == Parametros.intObsequio || pItem.IdFormaPago == Parametros.intASAF)
                            //{
                            //    if (pItem.FlagPreVenta)
                            //    {
                            //        //Insertamos el detalle del pedido
                            //        item.IdPedido = pItem.IdPedido;
                            //        item.IdKardex = null;

                            //        PedidoDetalle.Inserta(item);
                            //    }

                            //    if (pItem.FlagPreVenta == false)
                            //    {
                            //        //Insertar Kardex
                            //        KardexBE objE_Kardex = new KardexBE();
                            //        objE_Kardex.IdKardex = 0;
                            //        objE_Kardex.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                            //        objE_Kardex.Periodo = pItem.Periodo;
                            //        objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            //        objE_Kardex.IdAlmacen = IdAlmacen;
                            //        objE_Kardex.IdProducto = item.IdProducto;
                            //        objE_Kardex.Cantidad = item.Cantidad;
                            //        objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                            //        objE_Kardex.NumeroDocumento = pItem.Numero;
                            //        objE_Kardex.Observacion = "Salida Por Pedido de Venta";
                            //        objE_Kardex.TipoMovimiento = "S";
                            //        objE_Kardex.MontoUnitarioCompra = item.ValorVenta;
                            //        objE_Kardex.PrecioCostoPromedio = 0;
                            //        objE_Kardex.MontoTotalCompra = 0;
                            //        objE_Kardex.FlagEstado = true;
                            //        objE_Kardex.Usuario = pItem.Usuario;
                            //        objE_Kardex.Maquina = pItem.Maquina;

                            //        KardexBE objE_KardexValorizado = new KardexBE();
                            //        objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, IdAlmacen, item.IdProducto);

                            //        if (objE_KardexValorizado != null)
                            //        {
                            //            objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                            //            objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * item.Cantidad;
                            //        }

                            //        KardexDL objDL_Kardex = new KardexDL();
                            //        IdKardex = objDL_Kardex.Inserta(objE_Kardex);



                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = 0;
                                objE_Stock.ValorDescuenta = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
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
                                objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
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

                            if (item.IdAlmacen != item.IdAlmacenOrigen)//add 290916
                            {
                                //Movimiento Almacén
                                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                                objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                                objMovimientoAlmacen.Periodo = pItem.Periodo;
                                objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                                objMovimientoAlmacen.Numero = "";
                                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                                objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(item.IdAlmacenOrigen); //Convert.ToInt32(cboAlmacen.EditValue);
                                objMovimientoAlmacen.Fecha = pItem.Fecha;
                                objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                                objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                                objMovimientoAlmacen.Referencia = "";
                                objMovimientoAlmacen.Observaciones = "VEND: " + pItem.DescVendedor;
                                objMovimientoAlmacen.IdAlmacenDestino = item.IdAlmacen; //Parametros.intAlmCentralUcayali;
                                objMovimientoAlmacen.IdCliente = pItem.IdCliente == null ? (int?)null : pItem.IdCliente;
                                objMovimientoAlmacen.FlagEstado = true;
                                objMovimientoAlmacen.Usuario = pItem.Usuario;//Usuario
                                objMovimientoAlmacen.Maquina = pItem.Maquina;
                                objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                                objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                                objMovimientoAlmacen.IdAuxiliar = pItem.IdVendedor;
                                objMovimientoAlmacen.IdPedido = pItem.IdPedido;
                                objMovimientoAlmacen.IdProducto = item.IdProducto; //add 270516
                                objMovimientoAlmacen.Cantidad = item.Cantidad;

                                item.IdMovimientoAlmacenDetalle = objBL_MovimientoAlmacen.InsertaSalidaEntrada(objMovimientoAlmacen);

                            }


                            //        //Insertamos el detalle del pedido
                            //        item.IdPedido = pItem.IdPedido;
                            //        item.IdKardex = IdKardex;
                            //        PedidoDetalle.Inserta(item);
                            //    }
                            //}

                            ////Cuando el pedido es crédito
                            //if (pItem.IdFormaPago == Parametros.intCredito)
                            //{


                            //Insertamos el detalle del pedido
                            item.IdPedido = pItem.IdPedido;
                            item.IdKardex = null;
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            PedidoDetalle.Inserta(item);
                            //}
                        }
                        else
                        {
                            //if (pItem.IdFormaPago == Parametros.intContado || pItem.IdFormaPago == Parametros.intConsignacion || pItem.IdFormaPago == Parametros.intSeparacion || pItem.IdFormaPago == Parametros.intCopagan || pItem.IdFormaPago == Parametros.intContraEntrega || pItem.IdFormaPago == Parametros.intObsequio || pItem.IdFormaPago == Parametros.intASAF)
                            //{
                            //    if (pItem.FlagPreVenta)
                            //    {
                            //        PedidoDetalle.Actualiza(item);
                            //    }
                            //    else
                            //    {
                            //        //Actualizar Kardex
                            //        KardexBE objE_Kardex = new KardexBE();
                            //        objE_Kardex.IdKardex = Convert.ToInt32(item.IdKardex);
                            //        objE_Kardex.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                            //        objE_Kardex.Periodo = pItem.Periodo;
                            //        objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            //        objE_Kardex.IdAlmacen = IdAlmacen;
                            //        objE_Kardex.IdProducto = item.IdProducto;
                            //        objE_Kardex.Cantidad = item.Cantidad;
                            //        objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                            //        objE_Kardex.NumeroDocumento = pItem.Numero;
                            //        objE_Kardex.Observacion = "Salida Por Pedido de Venta";
                            //        objE_Kardex.TipoMovimiento = "S";
                            //        objE_Kardex.MontoUnitarioCompra = item.ValorVenta;
                            //        objE_Kardex.PrecioCostoPromedio = item.ValorVenta;
                            //        objE_Kardex.MontoTotalCompra = item.ValorVenta;
                            //        objE_Kardex.FlagEstado = true;
                            //        objE_Kardex.Usuario = pItem.Usuario;
                            //        objE_Kardex.Maquina = pItem.Maquina;

                            //        KardexBE objE_KardexValorizado = new KardexBE();
                            //        objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, IdAlmacen, item.IdProducto);

                            //        if (objE_KardexValorizado != null)
                            //        {
                            //            decimal dmlPCP = 0;
                            //            decimal dmlCostoTotal = 0;

                            //            if (objE_KardexValorizado.Saldo != 0)
                            //            {
                            //                //Calcula Precio Costo Promedio
                            //                dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                            //                dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;

                            //                objE_Kardex.PrecioCostoPromedio = dmlPCP;
                            //                objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                            //            }

                            //        }
                            //        else
                            //        {
                            //            objE_Kardex.PrecioCostoPromedio = item.ValorVenta;
                            //        }

                            //        KardexDL objDL_Kardex = new KardexDL();
                            //        objDL_Kardex.Actualiza(objE_Kardex);


                            //Actualizar Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                            objE_Stock.IdAlmacen = IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = item.CantidadAnt;
                            objE_Stock.ValorDescuenta = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            StockDL objDL_Stock = new StockDL();
                            objDL_Stock.ActualizaCantidades(objE_Stock);

                            if (item.IdAlmacen != item.IdAlmacenOrigen)
                            {
                                //Movimiento Almacén
                                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                                objMovimientoAlmacen.IdMovimientoAlmacenDetalle = Convert.ToInt32(item.IdMovimientoAlmacenDetalle);
                                objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                                objMovimientoAlmacen.Periodo = pItem.Periodo;
                                objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                                objMovimientoAlmacen.Numero = "";
                                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                                objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(item.IdAlmacenOrigen); //Convert.ToInt32(cboAlmacen.EditValue);
                                objMovimientoAlmacen.Fecha = pItem.Fecha;
                                objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                                objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                                objMovimientoAlmacen.Referencia = "";
                                objMovimientoAlmacen.Observaciones = "VEND: " + pItem.DescVendedor;
                                objMovimientoAlmacen.IdAlmacenDestino = item.IdAlmacen; //Parametros.intAlmCentralUcayali;
                                objMovimientoAlmacen.IdCliente = pItem.IdCliente == null ? (int?)null : pItem.IdCliente;
                                objMovimientoAlmacen.FlagEstado = true;
                                objMovimientoAlmacen.Usuario = pItem.Usuario;//Usuario
                                objMovimientoAlmacen.Maquina = pItem.Maquina;
                                objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                                objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                                objMovimientoAlmacen.IdAuxiliar = pItem.IdVendedor;
                                objMovimientoAlmacen.IdPedido = pItem.IdPedido;
                                objMovimientoAlmacen.IdProducto = item.IdProducto; //add 270516
                                objMovimientoAlmacen.Cantidad = item.Cantidad;
                                objMovimientoAlmacen.CantidadAnterior = item.CantidadAnt;

                                objBL_MovimientoAlmacen.ActualizaSalidaEntrada(objMovimientoAlmacen);
                            }

                            //actulizar el pedido detalle
                            PedidoDetalle.Actualiza(item);
                            //}
                        }
                    }

                    //Actualizamos el pedido
                    Pedido.Actualiza(pItem);

                    //Verifica si tiene documento detalle para actualizar la situación de los contados
                    if (pItem.IdFormaPago == Parametros.intContado)
                    {
                        List<DocumentoVentaBE> lstDocumento = new List<DocumentoVentaBE>();
                        lstDocumento = new DocumentoVentaBL().ListadoPedido(pItem.IdPedido);
                        if (lstDocumento.Count > 0)
                        {
                            Pedido.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado, 0, "", pItem.Usuario, pItem.Maquina);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void ActualizaWeb(PedidoBE pItem, List<PedidoDetalleBE> pListaPedidoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    foreach (PedidoDetalleBE item in pListaPedidoDetalle)
                    {
                        //int IdKardex = 0;

                        ////Establecemos el almacen correspondiente de acuerdo a la tienda
                        int IdAlmacen = Parametros.intAlmCentral;

                        if (item.IdAlmacen != null || item.IdAlmacen > 0) //ADD
                        {
                            IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                        }

                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = 0;
                                objE_Stock.ValorDescuenta = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
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
                                objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
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

                            if (item.IdAlmacen != item.IdAlmacenOrigen)//add 290916
                            {
                                //Movimiento Almacén
                                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                                objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                                objMovimientoAlmacen.Periodo = pItem.Periodo;
                                objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                                objMovimientoAlmacen.Numero = "";
                                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                                objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(item.IdAlmacenOrigen); //Convert.ToInt32(cboAlmacen.EditValue);
                                objMovimientoAlmacen.Fecha = pItem.Fecha;
                                objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                                objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                                objMovimientoAlmacen.Referencia = "";
                                objMovimientoAlmacen.Observaciones = "VEND: " + pItem.DescVendedor;
                                objMovimientoAlmacen.IdAlmacenDestino = item.IdAlmacen; //Parametros.intAlmCentralUcayali;
                                objMovimientoAlmacen.IdCliente = pItem.IdCliente == null ? (int?)null : pItem.IdCliente;
                                objMovimientoAlmacen.FlagEstado = true;
                                objMovimientoAlmacen.Usuario = pItem.Usuario;//Usuario
                                objMovimientoAlmacen.Maquina = pItem.Maquina;
                                objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                                objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                                objMovimientoAlmacen.IdAuxiliar = pItem.IdVendedor;
                                objMovimientoAlmacen.IdPedido = pItem.IdPedido;
                                objMovimientoAlmacen.IdProducto = item.IdProducto; //add 270516
                                objMovimientoAlmacen.Cantidad = item.Cantidad;

                                item.IdMovimientoAlmacenDetalle = objBL_MovimientoAlmacen.InsertaSalidaEntrada(objMovimientoAlmacen);

                            }

                            //Insertamos el detalle del pedido
                            item.IdPedido = pItem.IdPedido;
                            item.IdKardex = null;
                            item.Usuario = pItem.Usuario;
                            item.Maquina = pItem.Maquina;
                            PedidoDetalle.Inserta(item);
                            //}
                        }
                        else
                        {
                            //Actualizar Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                            objE_Stock.IdAlmacen = IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = item.CantidadAnt;
                            objE_Stock.ValorDescuenta = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            StockDL objDL_Stock = new StockDL();
                            objDL_Stock.ActualizaCantidades(objE_Stock);

                            if (item.IdAlmacen != item.IdAlmacenOrigen)
                            {
                                //Movimiento Almacén
                                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                                objMovimientoAlmacen.IdMovimientoAlmacenDetalle = Convert.ToInt32(item.IdMovimientoAlmacenDetalle);
                                objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                                objMovimientoAlmacen.Periodo = pItem.Periodo;
                                objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                                objMovimientoAlmacen.Numero = "";
                                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                                objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(item.IdAlmacenOrigen); //Convert.ToInt32(cboAlmacen.EditValue);
                                objMovimientoAlmacen.Fecha = pItem.Fecha;
                                objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                                objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                                objMovimientoAlmacen.Referencia = "";
                                objMovimientoAlmacen.Observaciones = "VEND: " + pItem.DescVendedor;
                                objMovimientoAlmacen.IdAlmacenDestino = item.IdAlmacen; //Parametros.intAlmCentralUcayali;
                                objMovimientoAlmacen.IdCliente = pItem.IdCliente == null ? (int?)null : pItem.IdCliente;
                                objMovimientoAlmacen.FlagEstado = true;
                                objMovimientoAlmacen.Usuario = pItem.Usuario;//Usuario
                                objMovimientoAlmacen.Maquina = pItem.Maquina;
                                objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                                objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                                objMovimientoAlmacen.IdAuxiliar = pItem.IdVendedor;
                                objMovimientoAlmacen.IdPedido = pItem.IdPedido;
                                objMovimientoAlmacen.IdProducto = item.IdProducto; //add 270516
                                objMovimientoAlmacen.Cantidad = item.Cantidad;
                                objMovimientoAlmacen.CantidadAnterior = item.CantidadAnt;

                                objBL_MovimientoAlmacen.ActualizaSalidaEntrada(objMovimientoAlmacen);
                            }
                            PedidoDetalle.Actualiza(item);
                        }
                    }

                    //Actualizamos el pedido
                    Pedido.ActualizaWeb(pItem);

                    //Verifica si tiene documento detalle para actualizar la situación de los contados
                    if (pItem.IdFormaPago == Parametros.intContado)
                    {
                        List<DocumentoVentaBE> lstDocumento = new List<DocumentoVentaBE>();
                        lstDocumento = new DocumentoVentaBL().ListadoPedido(pItem.IdPedido);
                        if (lstDocumento.Count > 0)
                        {
                            Pedido.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado, 0, "", pItem.Usuario, pItem.Maquina);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }




        public void ActualizaCabecera(PedidoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();

                    //Actualizamos el pedido
                    Pedido.Actualiza(pItem);

                    //Verifica si tiene documento detalle para actualizar la situación de los contados
                    if (pItem.IdFormaPago == Parametros.intContado)
                    {
                        List<DocumentoVentaBE> lstDocumento = new List<DocumentoVentaBE>();
                        lstDocumento = new DocumentoVentaBL().ListadoPedido(pItem.IdPedido);
                        if (lstDocumento.Count > 0)
                        {
                            Pedido.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdPedido), Parametros.intFacturado, 0, "", pItem.Usuario, pItem.Maquina);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdEmpresa, int IdPedido, int IdSituacion, int IdPersona, string Usuario, string Maquina)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();
                    Pedido.ActualizaSituacion(IdEmpresa, IdPedido, IdSituacion, IdPersona, "x ACTUALIZA SITUACION", Usuario, Maquina);

                    /*if (IdSituacion == Parametros.intPVDespachado)
                    {
                        PedidoBE objE_Pedido = null;
                        objE_Pedido = new PedidoBL().Selecciona(IdPedido);
                        if (objE_Pedido != null)
                        {
                            List<PedidoDetalleBE> mListaPedidoDetalle = null;
                            mListaPedidoDetalle = new PedidoDetalleBL().ListaTodosActivo(IdPedido);

                            foreach (PedidoDetalleBE item in mListaPedidoDetalle)
                            {
                                int IdKardex = 0;

                                //Establecemos el almacen correspondiente de acuerdo a la tienda
                                int IdAlmacen = 0;

                                if (objE_Pedido.IdTienda == Parametros.intTiendaUcayali)
                                {
                                    IdAlmacen = Parametros.intAlmCentral;
                                }

                                if (objE_Pedido.IdTienda == Parametros.intTiendaAndahuaylas)
                                {
                                    IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                                }

                                if (objE_Pedido.IdTienda == Parametros.intTiendaKonceptos) IdAlmacen = Parametros.intAlmAnaquelesKonceptos;

                                //Insertar Kardex
                                KardexBE objE_Kardex = new KardexBE();
                                objE_Kardex.IdKardex = 0;
                                objE_Kardex.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                                objE_Kardex.Periodo = objE_Pedido.Periodo;
                                objE_Kardex.FechaMovimiento = Convert.ToDateTime(objE_Pedido.Fecha);
                                objE_Kardex.IdAlmacen = IdAlmacen;
                                objE_Kardex.IdProducto = item.IdProducto;
                                objE_Kardex.Cantidad = item.Cantidad;
                                objE_Kardex.IdTipoDocumento = objE_Pedido.IdTipoDocumento;
                                objE_Kardex.NumeroDocumento = objE_Pedido.Numero;
                                objE_Kardex.Observacion = "Salida Por Pedido de Venta Crédito";
                                objE_Kardex.TipoMovimiento = "S";
                                objE_Kardex.MontoUnitarioCompra = item.ValorVenta;
                                objE_Kardex.PrecioCostoPromedio = 0;
                                objE_Kardex.MontoTotalCompra = 0;
                                objE_Kardex.FlagEstado = true;
                                objE_Kardex.Usuario = objE_Pedido.Usuario;
                                objE_Kardex.Maquina = objE_Pedido.Maquina;

                                KardexBE objE_KardexValorizado = new KardexBE();
                                objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intIdPanoramaDistribuidores, objE_Pedido.IdTienda, IdAlmacen, item.IdProducto);

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
                                lstStock = objDL_Stock.ListaProducto(Parametros.intIdPanoramaDistribuidores, objE_Pedido.IdTienda, IdAlmacen, item.IdProducto);
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
                                    objE_Stock.Usuario = objE_Pedido.Usuario;
                                    objE_Stock.Maquina = objE_Pedido.Maquina;

                                    objDL_Stock.ActualizaCantidades(objE_Stock);
                                }
                                else
                                {
                                    //Insertamos Stock
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock.IdStock = 0;
                                    objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                                    objE_Stock.Periodo = objE_Pedido.Periodo;
                                    objE_Stock.IdAlmacen = IdAlmacen;
                                    objE_Stock.IdProducto = item.IdProducto;
                                    objE_Stock.Cantidad = item.Cantidad;
                                    objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                                    objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                                    objE_Stock.FlagEstado = true;
                                    objE_Stock.Usuario = objE_Pedido.Usuario;
                                    objE_Stock.Maquina = objE_Pedido.Maquina;

                                    objDL_Stock.Inserta(objE_Stock);
                                }
                            }
                        }

                    }*/

                    PedidoBE objE_Pedido = new PedidoBE();
                    objE_Pedido = Pedido.Selecciona(IdPedido);
                    if (objE_Pedido.IdSituacion == Parametros.intPVAnulado) //add231215
                    {
                        if (IdSituacion == Parametros.intPVGenerado)
                        {
                            PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                            PedidoDetalle.ActualizaEstado(IdPedido);//,2);
                        }
                    }



                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacionAlmacen(int IdEmpresa, int IdPedido, int IdSituacionAlmacen, string Usuario, string Maquina)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                Pedido.ActualizaSituacionAlmacen(IdEmpresa, IdPedido, IdSituacionAlmacen, Usuario, Maquina);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaImpresion(int IdPedido, bool FlagImpresion)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                Pedido.ActualizaImpresion(IdPedido, FlagImpresion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCompraPerfecta(int IdPedido, int IdVendedorTitular, int IdVendedorAsesor, bool FlagCompraPerfecta)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                Pedido.ActualizaCompraPerfecta(IdPedido, IdVendedorTitular, IdVendedorAsesor, FlagCompraPerfecta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaFlagAuditado(int IdPedido, bool FlagAuditado)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                Pedido.ActualizaFlagAuditado(IdPedido, FlagAuditado);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PedidoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    //PedidoDetalle.ActualizaEstado(pItem.IdPedido, 1);//add 30/04/15 --1 Elimina y Hace Backup

                    List<PedidoDetalleBE> ListaPedidoDetalle = null;
                    ListaPedidoDetalle = new PedidoDetalleDL().ListaTodosActivo(pItem.IdPedido);

                    //Copiar Estado Anterior Pedido


                    foreach (PedidoDetalleBE item in ListaPedidoDetalle)
                    {
                        //Eliminanos el detalle del pedido
                        PedidoDetalle.Elimina(item);

                        if (pItem.FlagPreVenta == false)
                        {
                            int IdKardex = 0;   //Comentado desde aqui

                            //Establecemos el almacen correspondiente de acuerdo a la tienda
                            int IdAlmacen = Parametros.intAlmCentral;

                            if (item.IdAlmacen != null || item.IdAlmacen > 0) //ADD
                            {
                                IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                            }

                            //Usados hasta 14 enero 2015
                            /*if (pItem.IdTienda == Parametros.intTiendaUcayali)
                            {
                                IdAlmacen = Parametros.intAlmCentral;
                            }

                            if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                            {
                                IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                            }

                            if (pItem.IdTienda == Parametros.intTiendaKonceptos)
                            {
                                IdAlmacen = Parametros.intAlmAnaquelesKonceptos;
                            }*/

                            //if (pItem.IdFormaPago == Parametros.intContado || pItem.IdFormaPago == Parametros.intConsignacion || pItem.IdFormaPago == Parametros.intSeparacion || pItem.IdFormaPago == Parametros.intCopagan || pItem.IdFormaPago == Parametros.intContraEntrega || pItem.IdFormaPago == Parametros.intObsequio || pItem.IdFormaPago == Parametros.intASAF || pItem.IdFormaPago == Parametros.intCredito)
                            //{
                            //    if (pItem.FlagPreVenta)
                            //    {
                            //        //Actualiza la anulación del pedido
                            //        Pedido.ActualizaSituacion(Parametros.intEmpresaId, pItem.IdPedido, Parametros.intPVAnulado);
                            //    }
                            //    else
                            //    {
                            //Insertar Kardex
                            /*KardexBE objE_Kardex = new KardexBE();
                            objE_Kardex.IdKardex = 0;
                            objE_Kardex.IdEmpresa = Parametros.intEmpresaId;
                            objE_Kardex.Periodo = Parametros.intPeriodo;
                            objE_Kardex.FechaMovimiento = Parametros.dtFechaHoraServidor;
                            objE_Kardex.IdAlmacen = IdAlmacen;
                            objE_Kardex.IdProducto = item.IdProducto;
                            objE_Kardex.Cantidad = item.Cantidad;
                            objE_Kardex.IdTipoDocumento = Parametros.intTipoDocPedidoVenta;
                            objE_Kardex.NumeroDocumento = pItem.Numero;
                            objE_Kardex.Observacion = "Ingreso Por Anulación de Pedido de Venta";
                            objE_Kardex.TipoMovimiento = "I";
                            objE_Kardex.MontoUnitarioCompra = item.ValorVenta;
                            objE_Kardex.PrecioCostoPromedio = 0;
                            objE_Kardex.MontoTotalCompra = 0;
                            objE_Kardex.FlagEstado = true;
                            objE_Kardex.Usuario = pItem.Usuario;
                            objE_Kardex.Maquina = pItem.Maquina;

                            KardexBE objE_KardexValorizado = new KardexBE();
                            objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intEmpresaId, pItem.IdTienda, IdAlmacen, item.IdProducto);

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
                            lstStock = objDL_Stock.ListaProducto(Parametros.intEmpresaId, pItem.IdTienda, IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                                objE_Stock.IdAlmacen = IdAlmacen;
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
                                objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;//objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }

                            if (item.IdAlmacen != item.IdAlmacenOrigen)//add 309016
                            {
                                //Movimiento Almacén
                                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                                objMovimientoAlmacen.IdMovimientoAlmacenDetalle = Convert.ToInt32(item.IdMovimientoAlmacenDetalle);
                                objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                                objMovimientoAlmacen.Periodo = pItem.Periodo;
                                objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                                objMovimientoAlmacen.Numero = "";
                                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                                objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(item.IdAlmacenOrigen);
                                objMovimientoAlmacen.Fecha = pItem.Fecha;
                                objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                                objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                                objMovimientoAlmacen.Referencia = "";
                                objMovimientoAlmacen.Observaciones = "VEND: ";
                                objMovimientoAlmacen.IdAlmacenDestino = item.IdAlmacen;
                                objMovimientoAlmacen.IdCliente = 0;
                                objMovimientoAlmacen.FlagEstado = false;
                                objMovimientoAlmacen.Usuario = pItem.Usuario;
                                objMovimientoAlmacen.Maquina = pItem.Maquina;
                                objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                                objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                                objMovimientoAlmacen.IdAuxiliar = 0;
                                objMovimientoAlmacen.IdPedido = pItem.IdPedido;
                                objMovimientoAlmacen.IdProducto = item.IdProducto;
                                objMovimientoAlmacen.Cantidad = pItem.Cantidad;
                                objMovimientoAlmacen.CantidadAnterior = 0;

                                objBL_MovimientoAlmacen.ActualizaSalidaEntrada(objMovimientoAlmacen);
                            }

                        }
                        //}
                        //}
                        //Hasta Aqui
                    }

                    //Actualiza la anulación del pedido
                    Pedido.ActualizaSituacion(pItem.IdEmpresa, pItem.IdPedido, Parametros.intPVAnulado, 0, pItem.Observacion, pItem.Usuario, pItem.Maquina);
                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
        public void AnularPedidoWeb(PedidoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    List<PedidoDetalleBE> ListaPedidoDetalle = null;
                    ListaPedidoDetalle = new PedidoDetalleDL().ListaTodosActivo(pItem.IdPedido);

                    //Copiar Estado Anterior Pedido
                    foreach (PedidoDetalleBE item in ListaPedidoDetalle)
                    {
                        //Eliminanos detalle del pedido -- asignamos valor false a cada item
                        PedidoDetalle.Elimina(item);

                        if (pItem.FlagPreVenta == false)
                        {
                            int IdKardex = 0;   //Comentado desde aqui

                            //Establecemos el almacen correspondiente de acuerdo a la tienda
                            int IdAlmacen = Parametros.intAlmCentral;

                            if (item.IdAlmacen != null || item.IdAlmacen > 0) //ADD
                            {
                                IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                            }

                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            lstStock = objDL_Stock.ListaProducto(Parametros.intEmpresaId, pItem.IdTienda, IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                                objE_Stock.IdAlmacen = IdAlmacen;
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
                                objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;//objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }

                            if (item.IdAlmacen != item.IdAlmacenOrigen)//add 309016
                            {
                                //Movimiento Almacén
                                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                                objMovimientoAlmacen.IdMovimientoAlmacenDetalle = Convert.ToInt32(item.IdMovimientoAlmacenDetalle);
                                objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                                objMovimientoAlmacen.Periodo = pItem.Periodo;
                                objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                                objMovimientoAlmacen.Numero = "";
                                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                                objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(item.IdAlmacenOrigen);
                                objMovimientoAlmacen.Fecha = pItem.Fecha;
                                objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                                objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                                objMovimientoAlmacen.Referencia = "";
                                objMovimientoAlmacen.Observaciones = "VEND: ";
                                objMovimientoAlmacen.IdAlmacenDestino = item.IdAlmacen;
                                objMovimientoAlmacen.IdCliente = 0;
                                objMovimientoAlmacen.FlagEstado = false;
                                objMovimientoAlmacen.Usuario = pItem.Usuario;
                                objMovimientoAlmacen.Maquina = pItem.Maquina;
                                objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                                objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                                objMovimientoAlmacen.IdAuxiliar = 0;
                                objMovimientoAlmacen.IdPedido = pItem.IdPedido;
                                objMovimientoAlmacen.IdProducto = item.IdProducto;
                                objMovimientoAlmacen.Cantidad = pItem.Cantidad;
                                objMovimientoAlmacen.CantidadAnterior = 0;

                                objBL_MovimientoAlmacen.ActualizaSalidaEntrada(objMovimientoAlmacen);
                            }
                        }
                    }

                    //Actualiza la anulación del pedido
                    Pedido.ActualizaSituacion2(pItem.IdEmpresa, pItem.IdPedido, Parametros.intPVAnulado, 0, pItem.Observacion, pItem.Usuario, pItem.Maquina);
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void AnularPedidoWebPrestashop(PedidoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    //Actualiza la anulación del pedido
                    Pedido.ActualizaSituacionPrestashop(pItem.IdEmpresa, pItem.IdPedidoWeb, Parametros.intPVAnulado, 0, pItem.Observacion, pItem.Usuario, pItem.Maquina);
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Aprobacion(PedidoBE pItem, List<PedidoDetalleBE> pListaPedidoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    //Actualizar Pedido
                    Pedido.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public static string AgregarCaracter(string cadena, string caracter, int digitos)
        {
            string nuevo = "";
            for (int i = 0; i < digitos; i++)
            {
                if (i == 0)
                    nuevo = caracter + cadena;
                else
                    nuevo = caracter + nuevo;
            }
            return nuevo.Substring(nuevo.Length - digitos, digitos);
        }
        public decimal lgDescuentoPorCumpleanios(decimal detotalDsctoCumple, int IdMarca, decimal PorcentajeDescuento, decimal ValorVenta)
        {
            decimal total = detotalDsctoCumple;
            if (PorcentajeDescuento <= new decimal(50))
            {
                if (IdMarca == Parametros.intIdMarcaKira)
                {
                    if (PorcentajeDescuento == new decimal(0))
                    {
                        total = detotalDsctoCumple + ValorVenta * new decimal(0.05);
                    }
                }
                else
                {
                    total = detotalDsctoCumple + ValorVenta * new decimal(0.10);
                }
            }
            else
            {
                total = detotalDsctoCumple;
            }

            return total;
        }
        public Int32 InsertaManual(PedidoBE pItem, List<PedidoDetalleBE> pListaPedidoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDL Pedido = new PedidoDL();
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    string sNumero = "";

                    ////Obtenemos el correlativo
                    //List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intPanoraramaDistribuidores, pItem.IdTipoDocumento, Parametros.intPeriodo);
                    ////mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intEmpresaId, pItem.IdTipoDocumento, Parametros.intPeriodo);
                    //if (mListaNumero.Count > 0)
                    //{
                    //    sNumero = AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 7);
                    //}

                    ////Actualizamos el correlativo de la tabla principal de correlativos
                    //NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    //objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intPanoraramaDistribuidores, pItem.IdTipoDocumento, pItem.Periodo);
                    ////objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intEmpresaId, pItem.IdTipoDocumento, pItem.Periodo);

                    //Insertar en el pedido
                    int IdPedido = 0;
                    //pItem.Numero = sNumero;
                    IdPedido = Pedido.Inserta(pItem);

                    foreach (PedidoDetalleBE item in pListaPedidoDetalle)
                    {
                        //if (pItem.IdFormaPago == Parametros.intContado || pItem.IdFormaPago == Parametros.intConsignacion || pItem.IdFormaPago == Parametros.intSeparacion || pItem.IdFormaPago == Parametros.intCopagan || pItem.IdFormaPago == Parametros.intContraEntrega || pItem.IdFormaPago == Parametros.intObsequio || pItem.IdFormaPago == Parametros.intASAF)
                        //{
                        int IdKardex = 0;

                        //    //Establecemos el almacen correspondiente de acuerdo a la tienda

                        int IdAlmacen = Parametros.intAlmCentral;

                        if (item.IdAlmacen != null || item.IdAlmacen > 0) //ADD
                        {
                            IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                        }

                        #region "Vers Anterior"

                        //int IdAlmacen = 0;

                        /*if (pItem.IdTienda == Parametros.intTiendaUcayali)
                        {
                            //IdAlmacen = Parametros.intAlmCentral;
                            if (item.IdAlmacen == null || item.IdAlmacen == 0)
                                IdAlmacen = Parametros.intAlmCentral;
                            else
                                IdAlmacen = Convert.ToInt32(item.IdAlmacen);
                        }

                        if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                        {
                            IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                        }

                        if (pItem.IdTienda == Parametros.intTiendaKonceptos)
                        {
                            IdAlmacen = Parametros.intAlmAnaquelesKonceptos;
                        }

                        if (pItem.IdTienda == Parametros.intTiendaPrescott)
                        {
                            IdAlmacen = Parametros.intAlmPrescott;
                        }*/


                        //    if (pItem.FlagPreVenta)
                        //    {
                        //        //Insertamos el detalle del pedido
                        //        item.IdPedido = IdPedido;
                        //        item.IdKardex = null;

                        //        PedidoDetalle.Inserta(item);
                        //    }
                        #endregion

                        if (pItem.FlagPreVenta == false)
                        {
                            //Insertar Kardex  --COMENTADO no es Necesario es Directo. *****
                            /*KardexBE objE_Kardex = new KardexBE();
                            objE_Kardex.IdKardex = 0;
                            objE_Kardex.IdEmpresa = Parametros.intEmpresaId;
                            objE_Kardex.Periodo = pItem.Periodo;
                            objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            objE_Kardex.IdAlmacen = IdAlmacen;
                            objE_Kardex.IdProducto = item.IdProducto;
                            objE_Kardex.Cantidad = item.Cantidad;
                            objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                            objE_Kardex.NumeroDocumento = sNumero;
                            objE_Kardex.Observacion = "Salida Por Pedido de Venta";
                            objE_Kardex.TipoMovimiento = "S";
                            objE_Kardex.MontoUnitarioCompra = item.ValorVenta;
                            objE_Kardex.PrecioCostoPromedio = 0;
                            objE_Kardex.MontoTotalCompra = 0;
                            objE_Kardex.FlagEstado = true;
                            objE_Kardex.Usuario = pItem.Usuario;
                            objE_Kardex.Maquina = pItem.Maquina;

                            KardexBE objE_KardexValorizado = new KardexBE();
                            objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intEmpresaId, pItem.IdTienda, IdAlmacen, item.IdProducto);

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
                            lstStock = objDL_Stock.ListaProducto(Parametros.intEmpresaId, pItem.IdTienda, IdAlmacen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = 0;
                                objE_Stock.ValorDescuenta = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
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
                                objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = IdAlmacen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }

                            if (item.IdAlmacen != item.IdAlmacenOrigen)
                            {
                                //Movimiento Almacén
                                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                                objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                                objMovimientoAlmacen.Periodo = pItem.Periodo;
                                objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                                objMovimientoAlmacen.Numero = "";
                                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                                objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(item.IdAlmacenOrigen); //Convert.ToInt32(cboAlmacen.EditValue);
                                objMovimientoAlmacen.Fecha = pItem.Fecha;
                                objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                                objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                                objMovimientoAlmacen.Referencia = "";
                                objMovimientoAlmacen.Observaciones = "VEND: " + pItem.DescVendedor;
                                objMovimientoAlmacen.IdAlmacenDestino = item.IdAlmacen; //Parametros.intAlmCentralUcayali;
                                objMovimientoAlmacen.IdCliente = pItem.IdCliente == null ? (int?)null : pItem.IdCliente;
                                objMovimientoAlmacen.FlagEstado = true;
                                objMovimientoAlmacen.Usuario = pItem.Usuario;//Usuario
                                objMovimientoAlmacen.Maquina = pItem.Maquina;
                                objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                                objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                                objMovimientoAlmacen.IdAuxiliar = pItem.IdVendedor;
                                objMovimientoAlmacen.IdPedido = IdPedido;
                                objMovimientoAlmacen.IdProducto = item.IdProducto; //add 270516
                                objMovimientoAlmacen.Cantidad = item.Cantidad;

                                item.IdMovimientoAlmacenDetalle = objBL_MovimientoAlmacen.InsertaSalidaEntrada(objMovimientoAlmacen);
                            }

                            //        //Insertamos el detalle del pedido
                            //        item.IdPedido = IdPedido;
                            //        item.IdKardex = IdKardex;
                            //        PedidoDetalle.Inserta(item);
                            //    }
                            //}

                            ////Cuando el pedido es crédito
                            //if (pItem.IdFormaPago == Parametros.intCredito)
                            //{
                            //    //Establecemos el almacen correspondiente de acuerdo a la tienda
                            //    int IdAlmacen = 0;

                            //    if (pItem.IdTienda == Parametros.intTiendaUcayali)
                            //    {
                            //        IdAlmacen = Parametros.intAlmCentral;
                            //    }

                            //    if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                            //    {
                            //        IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                            //    }

                            //    if (pItem.IdTienda == Parametros.intTiendaKonceptos) IdAlmacen = Parametros.intAlmAnaquelesKonceptos;


                            //    //Insertamos el detalle del pedido
                            //    item.IdPedido = IdPedido;
                            //    item.IdKardex = null;

                            //    PedidoDetalle.Inserta(item);
                        }

                        //Insertamos el detalle del pedido
                        item.IdPedido = IdPedido;
                        item.Usuario = pItem.Usuario;
                        item.Maquina = pItem.Maquina;
                        item.IdKardex = null;
                        PedidoDetalle.Inserta(item);
                    }

                    //Actualiza Pedido Situacion
                    if (pItem.bOrigenFlagPreVenta && pItem.IdPedidoReferencia != null)
                    {
                        Pedido.ActualizaSituacion(pItem.IdEmpresa, Convert.ToInt32(pItem.IdPedidoReferencia), Parametros.intPVEnProceso, pItem.IdVendedor, "", pItem.Usuario, pItem.Maquina);
                    }


                    ts.Complete();

                    return IdPedido;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualizar_PedidoWeb(int parIdPedidoWeb, int parIdCliente, String parNumeroDocumento, String parDescCliente, String parDireccion, int parFlagCliente)
        {
            try
            {
                PedidoDL Obj = new PedidoDL();

                Obj.Actualizar_PedidoWeb(parIdPedidoWeb, parIdCliente, parNumeroDocumento, parDescCliente, parDireccion, parFlagCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void RegistroPagoPedidoWeb(int parIdPedidoWeb, DateTime parFecPago, String parNumOperacion, String parObs)
        {
            try
            {
                PedidoDL Obj = new PedidoDL();

                Obj.RegistroPagoPedidoWeb(parIdPedidoWeb, parFecPago, parNumOperacion, parObs);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PedidoBE SeleccionaPedidoAsociadoCF(int Periodo, string Numero)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                PedidoBE objAna = Pedido.SeleccionaPedidoAsociadoCF(Periodo, Numero);
                return objAna;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Eliminar_cumpleanios(int IdPedido)
        {
            try
            {
                PedidoDL Pedido = new PedidoDL();
                Pedido.Eliminar_cumpleanios(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }

}

