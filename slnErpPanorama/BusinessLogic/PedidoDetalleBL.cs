using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PedidoDetalleBL
    {
        public List<PedidoDetalleBE> ListaTodosActivo(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosActivo(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosActivoWeb(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosActivoWeb(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosActivo_ConsultaWeb(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosActivo_ConsultaWeb(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosActivoDetalleWeb(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return  PedidoDetalle.ListaTodosActivoDetalleWeb(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosActivoChequeo(int IdPedido)
        {
           try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosActivoChequeo(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosActivoChequeoProducto(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosActivoChequeoProducto(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTotalMarca(int IdPedido, int TipoConsulta)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTotalMarca(IdPedido, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosActivoInstalacion(int IdHojaInstalacion, int TipoConsulta)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosActivoInstalacion(IdHojaInstalacion, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosActivoInstalacionPedido(int IdPedido, int TipoConsulta)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosActivoInstalacionPedido(IdPedido, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodos(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodos(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosStock(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosStock(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosActivoActualizado(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosActivoActualizado(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosActivoActualizadoStock(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosActivoActualizadoStock(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PedidoDetalleBE> ListaTodosActivoConsignacion(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.ListaTodosActivoConsignacion(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PedidoDetalleBE SeleccionaPreVentaNavidad(int IdProducto)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.SeleccionaPreVentaNavidad(IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PedidoDetalleBE SeleccionaVariosAlmacenes(int IdPedido)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                return PedidoDetalle.SeleccionaVariosAlmacenes(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PedidoDetalleBE pItem)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                PedidoDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PedidoDetalleBE pItem)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                PedidoDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaChequeo(List<PedidoDetalleBE> pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    foreach (PedidoDetalleBE item in pItem)
                    {
                        PedidoDetalle.ActualizaChequeo(item.IdPedidoDetalle, item.CantidadChequeo);
                    }

                    ts.Complete();

                    //return IdPedido;
                }
            }
            catch (Exception ex)
            { throw ex; }

            //--------------------

            /////--
            //try
            //{
            //    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
            //    PedidoDetalle.ActualizaChequeo(IdPedidoDetalle, Cantidad);
            //}
            //catch (Exception ex)
            //{ throw ex; }
        }

        public void ActualizaChequeoProducto(List<PedidoDetalleBE> pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();

                    foreach (PedidoDetalleBE item in pItem)
                    {
                        PedidoDetalle.ActualizaChequeoProducto(item.IdPedido, item.IdProducto, item.CantidadChequeo);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void ActualizaArmado(int IdPedidoDetalle, bool FlagArmado)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                PedidoDetalle.ActualizaArmado(IdPedidoDetalle, FlagArmado);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaPromocion(int IdPedidoDetalle, int? IdPromocion, int IdTipoCliente, int IdProducto, string DescPromocion)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                PedidoDetalle.ActualizaPromocion(IdPedidoDetalle, IdPromocion, IdTipoCliente, IdProducto, DescPromocion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDescuentoAuditoria(PedidoDetalleBE pItem)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                PedidoDetalle.ActualizaDescuentoAuditoria(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaPersonaServicio(int IdPedidoDetalle, int IdPersonaServicio)
        {
            try
            {
                PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                PedidoDetalle.ActualizaPersonaServicio(IdPedidoDetalle, IdPersonaServicio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PedidoDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Eliminar el detalle del pedido
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                    PedidoDetalle.Elimina(pItem);

                    if (pItem.IdPedidoDetalle != 0)
                    {
                        if (!pItem.FlagPreventa)
                        {
                            int IdKardex = 0;

                            //Establecemos el almacen correspondiente de acuerdo a la tienda
                            int IdAlmacen = 1;

                            if (pItem.IdAlmacen != null || pItem.IdAlmacen > 0) //ADD
                            {
                                IdAlmacen = Convert.ToInt32(pItem.IdAlmacen);
                            }

                            //Usados hasta 14 enero 2015
                            /*if (pItem.IdTienda == Parametros.intTiendaUcayali)
                            {
                                IdAlmacen = Parametros.intAlmCentral;
                            }

                            if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                            {
                                IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                            }*/



                            //if (pItem.IdTienda == Parametros.intTiendaKonceptos) IdAlmacen = Parametros.intAlmAnaquelesKonceptos;

                            //if (pItem.IdPedidoDetalle != 0)
                            //{
                            //Insertar Kardex
                            /*KardexBE objE_Kardex = new KardexBE();
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
                            IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

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
                                objE_Stock.IdProducto = pItem.IdProducto;
                                objE_Stock.Cantidad = pItem.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }

                            if (pItem.IdAlmacen != pItem.IdAlmacenOrigen)
                            {
                                //Movimiento Almacén
                                MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                                MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                                objMovimientoAlmacen.IdMovimientoAlmacenDetalle = Convert.ToInt32(pItem.IdMovimientoAlmacenDetalle);
                                objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                                objMovimientoAlmacen.Periodo = pItem.Periodo;
                                objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                                objMovimientoAlmacen.Numero = "";
                                objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                                objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(pItem.IdAlmacenOrigen);
                                objMovimientoAlmacen.Fecha = pItem.Fecha;
                                objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                                objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                                objMovimientoAlmacen.Referencia = "";
                                objMovimientoAlmacen.Observaciones = "VEND: ";
                                objMovimientoAlmacen.IdAlmacenDestino = pItem.IdAlmacen;
                                objMovimientoAlmacen.IdCliente = 0;
                                objMovimientoAlmacen.FlagEstado = false;
                                objMovimientoAlmacen.Usuario = pItem.Usuario;//Usuario
                                objMovimientoAlmacen.Maquina = pItem.Maquina;
                                objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                                objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                                objMovimientoAlmacen.IdAuxiliar = 0;
                                objMovimientoAlmacen.IdPedido = pItem.IdPedido;
                                objMovimientoAlmacen.IdProducto = pItem.IdProducto;
                                objMovimientoAlmacen.Cantidad = pItem.Cantidad;
                                objMovimientoAlmacen.CantidadAnterior = 0;

                                objBL_MovimientoAlmacen.ActualizaSalidaEntrada(objMovimientoAlmacen);
                            }

                        }
                    }

                    ts.Complete();
                    //}


                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaSinChequear(PedidoDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Eliminar el detalle del pedido
                    PedidoDetalleDL PedidoDetalle = new PedidoDetalleDL();
                    PedidoDetalle.EliminaSinChequear(pItem);

                    //if (pItem.IdPedidoDetalle != 0)
                    //{
                    //    if (!pItem.FlagPreventa)
                    //    {
                    //        int IdKardex = 0;

                    //        //Establecemos el almacen correspondiente de acuerdo a la tienda
                    //        int IdAlmacen = 1;

                    //        if (pItem.IdAlmacen != null || pItem.IdAlmacen > 0) //ADD
                    //        {
                    //            IdAlmacen = Convert.ToInt32(pItem.IdAlmacen);
                    //        }

                    //        //Verificar el stock
                    //        List<StockBE> lstStock = new List<StockBE>();
                    //        StockDL objDL_Stock = new StockDL();
                    //        lstStock = objDL_Stock.ListaProducto(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, IdAlmacen, pItem.IdProducto);
                    //        if (lstStock.Count > 0)
                    //        {
                    //            //Actualizamos Stock
                    //            StockBE objE_Stock = new StockBE();
                    //            objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                    //            objE_Stock.IdAlmacen = IdAlmacen;
                    //            objE_Stock.IdProducto = pItem.IdProducto;
                    //            objE_Stock.ValorIncrementa = pItem.Cantidad;
                    //            objE_Stock.ValorDescuenta = 0;
                    //            objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                    //            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                    //            objE_Stock.Usuario = pItem.Usuario;
                    //            objE_Stock.Maquina = pItem.Maquina;

                    //            objDL_Stock.ActualizaCantidades(objE_Stock);
                    //        }
                    //        else
                    //        {
                    //            //Insertamos Stock
                    //            StockBE objE_Stock = new StockBE();
                    //            objE_Stock.IdStock = 0;
                    //            objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                    //            objE_Stock.Periodo = pItem.Periodo;
                    //            objE_Stock.IdAlmacen = IdAlmacen;
                    //            objE_Stock.IdProducto = pItem.IdProducto;
                    //            objE_Stock.Cantidad = pItem.Cantidad;
                    //            objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                    //            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                    //            objE_Stock.FlagEstado = true;
                    //            objE_Stock.Usuario = pItem.Usuario;
                    //            objE_Stock.Maquina = pItem.Maquina;

                    //            objDL_Stock.Inserta(objE_Stock);
                    //        }

                    //        if (pItem.IdAlmacen != pItem.IdAlmacenOrigen)
                    //        {
                    //            //Movimiento Almacén
                    //            MovimientoAlmacenBL objBL_MovimientoAlmacen = new MovimientoAlmacenBL();
                    //            MovimientoAlmacenBE objMovimientoAlmacen = new MovimientoAlmacenBE();

                    //            objMovimientoAlmacen.IdMovimientoAlmacenDetalle = Convert.ToInt32(pItem.IdMovimientoAlmacenDetalle);
                    //            objMovimientoAlmacen.IdMovimientoAlmacen = 0;//IdMovimientoAlmacen;
                    //            objMovimientoAlmacen.Periodo = pItem.Periodo;
                    //            objMovimientoAlmacen.IdTipoDocumento = pItem.IdTipoDocumento;
                    //            objMovimientoAlmacen.Numero = "";
                    //            objMovimientoAlmacen.IdTipoMovimiento = Parametros.intTipMovSalida;
                    //            objMovimientoAlmacen.IdAlmacenOrigen = Convert.ToInt32(pItem.IdAlmacenOrigen);
                    //            objMovimientoAlmacen.Fecha = pItem.Fecha;
                    //            objMovimientoAlmacen.IdMotivo = Parametros.intMovTranferenciaDirecta;
                    //            objMovimientoAlmacen.NumeroDocumento = pItem.Numero;
                    //            objMovimientoAlmacen.Referencia = "";
                    //            objMovimientoAlmacen.Observaciones = "VEND: ";
                    //            objMovimientoAlmacen.IdAlmacenDestino = pItem.IdAlmacen;
                    //            objMovimientoAlmacen.IdCliente = 0;
                    //            objMovimientoAlmacen.FlagEstado = false;
                    //            objMovimientoAlmacen.Usuario = pItem.Usuario;//Usuario
                    //            objMovimientoAlmacen.Maquina = pItem.Maquina;
                    //            objMovimientoAlmacen.IdEmpresa = pItem.IdEmpresa;
                    //            objMovimientoAlmacen.IdTienda = pItem.IdTienda;
                    //            objMovimientoAlmacen.IdAuxiliar = 0;
                    //            objMovimientoAlmacen.IdPedido = pItem.IdPedido;
                    //            objMovimientoAlmacen.IdProducto = pItem.IdProducto;
                    //            objMovimientoAlmacen.Cantidad = pItem.Cantidad;
                    //            objMovimientoAlmacen.CantidadAnterior = 0;

                    //            objBL_MovimientoAlmacen.ActualizaSalidaEntrada(objMovimientoAlmacen);
                    //        }

                    //    }
                    //}

                    ts.Complete();

                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}


