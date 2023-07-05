using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MovimientoAlmacenBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public MovimientoAlmacenBE Selecciona(int IdEmpresa, int IdMovimientoAlmacen)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.Selecciona(IdEmpresa, IdMovimientoAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoAlmacenBE SelFlagUpdBultos(int IdEmpresa, int IdMovimientoAlmacen)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.SelUpdBultos(IdEmpresa, IdMovimientoAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.ListaTodosActivo(IdEmpresa, Periodo, Mes, IdAlmacenOrigen, IdTipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> ListaCodigo(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento, int IdProducto)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.ListaCodigo(IdEmpresa, Periodo, Mes, IdAlmacenOrigen, IdTipoMovimiento, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> ListaPendientes(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento, DateTime pFecInicio, DateTime pFecFin)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.ListaPendientes(IdEmpresa, Periodo, Mes, IdAlmacenOrigen, IdTipoMovimiento, pFecInicio, pFecFin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> ListaPendientesDetalle(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento, DateTime pFecInicio, DateTime pFecFin)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.ListaPendientesDetalle(IdEmpresa, Periodo, Mes, IdAlmacenOrigen, IdTipoMovimiento, pFecInicio, pFecFin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> ListaDetalle(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int IdAlmacenOrigen, int IdTipoMovimiento)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.ListaDetalle(IdEmpresa, FechaDesde, FechaHasta, IdAlmacenOrigen, IdTipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoAlmacenBE SeleccionaTipoDocumento(int IdEmpresa, int IdTipoDocumento, int IdDocumento)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.SeleccionaTipoDocumento(IdEmpresa, IdTipoDocumento, IdDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> SeleccionaNumero(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento, string Numero)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.SeleccionaNumero(IdEmpresa, Periodo, Mes, IdAlmacenOrigen, IdTipoMovimiento, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> ListaNotaSalidaMotivo(int IdEmpresa, int IdAlmacenOrigen, int IdMotivo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.ListaNotaSalidaMotivo(IdEmpresa, IdAlmacenOrigen, IdMotivo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> ListaFechaChequeo(DateTime FechaDesde, DateTime FechaHasta,int IdTipoMovimiento, int TipoConsulta)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return MovimientoAlmacen.ListaFechaChequeo(FechaDesde, FechaHasta,IdTipoMovimiento, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> ListaNumeroChequeo(int Periodo, string Numero, int IdTipoMovimiento)
        {
            try
            {
                MovimientoAlmacenDL Pedido = new MovimientoAlmacenDL();
                return Pedido.ListaNumeroChequeo(Periodo, Numero, IdTipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> ListaNotaSalidaPendientePedido(int IdPedido)
        {
            try
            {
                MovimientoAlmacenDL Pedido = new MovimientoAlmacenDL();
                return Pedido.ListaNotaSalidaPendientePedido(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoAlmacenBE> ListaNotaSalidaPedido(int IdPedido)
        {
            try
            {
                MovimientoAlmacenDL Pedido = new MovimientoAlmacenDL();
                return Pedido.ListaNotaSalidaPedido(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public Int32 Inserta(MovimientoAlmacenBE pItem, List<MovimientoAlmacenDetalleBE> pListaMovimientoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, new System.TimeSpan(0, 30, 0)))
                {
                    //Inserta Movimiento Almacen
                    int IdMovimientoAlmacen = 0;
                    MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                    IdMovimientoAlmacen = MovimientoAlmacen.Inserta(pItem);

                    pItem.IdMovimientoAlmacen = IdMovimientoAlmacen;//add
                    MovimientoAlmacen.ActualizaAuxiliar(pItem);//add

                    foreach (var item in pListaMovimientoDetalle)
                    {
                        if (pItem.IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota de Ingreso
                        {
                            int IdKardex = 0;
                            //Insertar Kardex

                            /*KardexBE objE_Kardex = new KardexBE();
                            objE_Kardex.IdKardex = 0;
                            objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            objE_Kardex.Periodo = pItem.Periodo;
                            objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            objE_Kardex.IdAlmacen = pItem.IdAlmacenOrigen;
                            objE_Kardex.IdProducto = item.IdProducto;
                            objE_Kardex.Cantidad = item.Cantidad;
                            objE_Kardex.IdTipoDocumento = Parametros.intTipoDocNotaIngreso;
                            objE_Kardex.NumeroDocumento = pItem.Numero;
                            objE_Kardex.Observacion = "Ingreso Por Nota de Ingreso";
                            objE_Kardex.TipoMovimiento = "I";
                            objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                            objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                            objE_Kardex.MontoTotalCompra = item.MontoTotal;
                            objE_Kardex.FlagEstado = true;
                            objE_Kardex.Usuario = pItem.Usuario;
                            objE_Kardex.Maquina = pItem.Maquina;

                            KardexBE objE_KardexValorizado = new KardexBE();
                            objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);

                            if (objE_KardexValorizado != null)
                            {
                                decimal dmlPCP = 0;
                                decimal dmlCostoTotal = 0;

                                if (objE_KardexValorizado.Saldo != 0)
                                {
                                    //Calcula Precio Costo Promedio
                                    dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                                    dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;

                                    objE_Kardex.PrecioCostoPromedio = dmlPCP;
                                    objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                                }

                            }
                            else
                            {
                                objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                            }

                            KardexDL objDL_Kardex = new KardexDL();
                            IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

                            //Verificar el stock
                            List<StockBE> lstStock = new List<StockBE>();
                            StockDL objDL_Stock = new StockDL();
                            /*lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {*/
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = item.Cantidad;
                            objE_Stock.ValorDescuenta = 0;
                            objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;
                            objDL_Stock.ActualizaCantidades(objE_Stock);
                            /*}
                            else
                            {
                                //Insertamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdStock = 0;
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }*/
                            //Insertar el detalle del movimiento del almacen
                            item.IdKardex = IdKardex;

                            item.IdMovimientoAlmacen = IdMovimientoAlmacen;
                            MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                            objDL_MovimientoAlmacenDetalle.Inserta(item);


                        }
                        else //Nota de Salida
                        {
                            int IdKardex = 0;

                            //Insertar Kardex
                            /*KardexBE objE_Kardex = new KardexBE();
                            objE_Kardex.IdKardex = 0;
                            objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            objE_Kardex.Periodo = pItem.Periodo;
                            objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            objE_Kardex.IdAlmacen = pItem.IdAlmacenOrigen;
                            objE_Kardex.IdProducto = item.IdProducto;
                            objE_Kardex.Cantidad = item.Cantidad;
                            objE_Kardex.IdTipoDocumento = Parametros.intTipoDocNotaSalida;
                            objE_Kardex.NumeroDocumento = pItem.Numero;
                            objE_Kardex.Observacion = "Salida Por Nota de Salida";
                            objE_Kardex.TipoMovimiento = "S";
                            objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                            objE_Kardex.PrecioCostoPromedio = 0;
                            objE_Kardex.MontoTotalCompra = 0;
                            objE_Kardex.FlagEstado = true;
                            objE_Kardex.Usuario = pItem.Usuario;
                            objE_Kardex.Maquina = pItem.Maquina;

                            KardexBE objE_KardexValorizado = new KardexBE();
                            objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);

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
                            /*lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);
                            if (lstStock.Count > 0)
                            {*/
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = 0;
                            objE_Stock.ValorDescuenta = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.ActualizaCantidades(objE_Stock);
                            /*}
                            else
                            {
                                //Insertamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdStock = 0;
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }*/

                            //Insertar el detalle del movimiento del almacen
                            item.IdKardex = IdKardex;

                            item.IdMovimientoAlmacen = IdMovimientoAlmacen;
                            MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                            objDL_MovimientoAlmacenDetalle.Inserta(item);
                        }
                    }

                    if (pItem.IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota Ingreso //Disable in 061016
                    {
                        //Actualizamos la numeración el documento de ingreso del movimiento de almacen
                        NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                        objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, Parametros.intTipoDocNotaIngreso, pItem.Periodo);

                        //pItem.FlagRecibido = true;
                        if (pItem.IdMovimientoAlmacenReferencia != null)
                        {
                            MovimientoAlmacen.ActualizaRecibido(Convert.ToInt32(pItem.IdMovimientoAlmacenReferencia), true);
                        }
                    }
                    else //Nota Salida
                    {
                        //Actualizamos la numeración el documento de salida del movimiento de almacen
                        NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                        objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, Parametros.intTipoDocNotaSalida, pItem.Periodo);
                    }

                    ts.Complete();
                    return IdMovimientoAlmacen;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MovimientoAlmacenBE pItem, List<MovimientoAlmacenDetalleBE> pListaMovimientoDetalle)

        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaMovimientoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo))
                        {
                            if (pItem.IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota de Ingreso
                            {
                                int IdKardex = 0;
                                
                                //Insertar Kardex
                                /*KardexBE objE_Kardex = new KardexBE();
                                objE_Kardex.IdKardex = 0;
                                objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                                objE_Kardex.Periodo = pItem.Periodo;
                                objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                                objE_Kardex.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Kardex.IdProducto = item.IdProducto;
                                objE_Kardex.Cantidad = item.Cantidad;
                                objE_Kardex.IdTipoDocumento = Parametros.intTipoDocNotaIngreso;
                                objE_Kardex.NumeroDocumento = pItem.Numero;
                                objE_Kardex.Observacion = "Ingreso Por Nota de Ingreso";
                                objE_Kardex.TipoMovimiento = "I";
                                objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                                objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                                objE_Kardex.MontoTotalCompra = item.MontoTotal;
                                objE_Kardex.FlagEstado = true;
                                objE_Kardex.Usuario = pItem.Usuario;
                                objE_Kardex.Maquina = pItem.Maquina;

                                KardexBE objE_KardexValorizado = new KardexBE();
                                objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);

                                if (objE_KardexValorizado != null)
                                {
                                    decimal dmlPCP = 0;
                                    decimal dmlCostoTotal = 0;

                                    if (objE_KardexValorizado.Saldo != 0)
                                    {
                                        //Calcula Precio Costo Promedio
                                        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                                        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;

                                        objE_Kardex.PrecioCostoPromedio = dmlPCP;
                                        objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                                    }
                                }
                                else
                                {
                                    objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                                }

                                KardexDL objDL_Kardex = new KardexDL();
                                IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

                                //Verificar el stock
                                List<StockBE> lstStock = new List<StockBE>();
                                StockDL objDL_Stock = new StockDL();
                                lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);
                                if (lstStock.Count > 0)
                                {
                                    //Actualizamos Stock
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                    objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
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
                                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                    objE_Stock.Periodo = pItem.Periodo;
                                    objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                    objE_Stock.IdProducto = item.IdProducto;
                                    objE_Stock.Cantidad = item.Cantidad;
                                    objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                    objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                    objE_Stock.FlagEstado = true;
                                    objE_Stock.Usuario = pItem.Usuario;
                                    objE_Stock.Maquina = pItem.Maquina;

                                    objDL_Stock.Inserta(objE_Stock);
                                }
                                //Insertar el detalle del movimiento del almacen
                                item.IdKardex = IdKardex;
                                
                                item.IdMovimientoAlmacen = pItem.IdMovimientoAlmacen;
                                MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                                objDL_MovimientoAlmacenDetalle.Inserta(item);


                            }
                            else //Nota de Salida
                            {
                                int IdKardex = 0;
                                
                                //Insertar Kardex
                                /*KardexBE objE_Kardex = new KardexBE();
                                objE_Kardex.IdKardex = 0;
                                objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                                objE_Kardex.Periodo = pItem.Periodo;
                                objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                                objE_Kardex.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Kardex.IdProducto = item.IdProducto;
                                objE_Kardex.Cantidad = item.Cantidad;
                                objE_Kardex.IdTipoDocumento = Parametros.intTipoDocNotaSalida;
                                objE_Kardex.NumeroDocumento = pItem.Numero;
                                objE_Kardex.Observacion = "Nota de Salida de Almacen";
                                objE_Kardex.TipoMovimiento = "S";
                                objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                                objE_Kardex.PrecioCostoPromedio = 0;
                                objE_Kardex.MontoTotalCompra = 0;
                                objE_Kardex.FlagEstado = true;
                                objE_Kardex.Usuario = pItem.Usuario;
                                objE_Kardex.Maquina = pItem.Maquina;

                                KardexBE objE_KardexValorizado = new KardexBE();
                                objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);

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
                                lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);
                                if (lstStock.Count > 0)
                                {
                                    //Actualizamos Stock
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                    objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
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
                                    objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                    objE_Stock.IdProducto = item.IdProducto;
                                    objE_Stock.Cantidad = item.Cantidad;
                                    objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                    objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                    objE_Stock.FlagEstado = true;
                                    objE_Stock.Usuario = pItem.Usuario;
                                    objE_Stock.Maquina = pItem.Maquina;

                                    objDL_Stock.Inserta(objE_Stock);
                                }
                                //Insertar el detalle del movimiento del almacen
                                item.IdKardex = IdKardex;

                                item.IdMovimientoAlmacen = pItem.IdMovimientoAlmacen;
                                MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                                objDL_MovimientoAlmacenDetalle.Inserta(item);
                            }
                        }
                        else
                        {
                            if (pItem.IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota de Ingreso
                            {
                                //Actualizar Kardex

                                /*KardexBE objE_Kardex = new KardexBE();
                                objE_Kardex.IdKardex = Convert.ToInt32(item.IdKardex);
                                objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                                objE_Kardex.Periodo = pItem.Periodo;
                                objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                                objE_Kardex.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Kardex.IdProducto = item.IdProducto;
                                objE_Kardex.Cantidad = item.Cantidad;
                                objE_Kardex.IdTipoDocumento = Parametros.intTipoDocNotaIngreso;
                                objE_Kardex.NumeroDocumento = pItem.Numero;
                                objE_Kardex.Observacion = "Nota de Ingreso de Almacen";
                                objE_Kardex.TipoMovimiento = "I";
                                objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                                objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                                objE_Kardex.MontoTotalCompra = item.MontoTotal;
                                objE_Kardex.FlagEstado = true;
                                objE_Kardex.Usuario = pItem.Usuario;
                                objE_Kardex.Maquina = pItem.Maquina;

                                KardexBE objE_KardexValorizado = new KardexBE();
                                objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);

                                if (objE_KardexValorizado != null)
                                {
                                    decimal dmlPCP = 0;
                                    decimal dmlCostoTotal = 0;

                                    if (objE_KardexValorizado.Saldo != 0)
                                    {
                                        //Calcula Precio Costo Promedio
                                        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                                        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;

                                        objE_Kardex.PrecioCostoPromedio = dmlPCP;
                                        objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                                    }

                                }
                                else
                                {
                                    objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                                }

                                KardexDL objDL_Kardex = new KardexDL();
                                objDL_Kardex.Actualiza(objE_Kardex);*/

                                //Actualizar Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = item.Cantidad;
                                objE_Stock.ValorDescuenta = item.CantidadAnt;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                StockDL objDL_Stock = new StockDL();
                                objDL_Stock.ActualizaCantidades(objE_Stock);
                                //Actualizar el detalle del movimiento del almacen

                                MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                                objDL_MovimientoAlmacenDetalle.Actualiza(item);
                            }
                            else //Nota de Salida
                            {

                                ////Actualizar Kardex
                                //KardexBE objE_Kardex = new KardexBE();
                                //objE_Kardex.IdKardex = Convert.ToInt32(item.IdKardex);
                                //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                                //objE_Kardex.Periodo = pItem.Periodo;
                                //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                                //objE_Kardex.IdAlmacen = pItem.IdAlmacenOrigen;
                                //objE_Kardex.IdProducto = item.IdProducto;
                                //objE_Kardex.Cantidad = item.Cantidad;
                                //objE_Kardex.IdTipoDocumento = Parametros.intTipoDocNotaSalida;
                                //objE_Kardex.NumeroDocumento = pItem.Numero;
                                //objE_Kardex.Observacion = "Nota de Salida de Almacen";
                                //objE_Kardex.TipoMovimiento = "S";
                                //objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                                //objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                                //objE_Kardex.MontoTotalCompra = item.CostoUnitario * item.Cantidad;
                                //objE_Kardex.FlagEstado = true;
                                //objE_Kardex.Usuario = pItem.Usuario;
                                //objE_Kardex.Maquina = pItem.Maquina;

                                //KardexBE objE_KardexValorizado = new KardexBE();
                                //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);

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
                                //    objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                                //}

                                //KardexDL objDL_Kardex = new KardexDL();
                                //objDL_Kardex.Actualiza(objE_Kardex);

                                //Actualizar Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = item.CantidadAnt;
                                objE_Stock.ValorDescuenta = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                StockDL objDL_Stock = new StockDL();
                                objDL_Stock.ActualizaCantidades(objE_Stock);


                                //Actualizar el detalle del movimiento del almacen
                                MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                                objDL_MovimientoAlmacenDetalle.Actualiza(item);
                            }
                        }
                    }
                    //Actualizar el movimiento del almacen
                    MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                    MovimientoAlmacen.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaChequeo(MovimientoAlmacenBE pItem, List<MovimientoAlmacenDetalleBE> pListaMovimientoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaMovimientoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo))
                        {
                            if (pItem.IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota de Ingreso
                            {
                                int IdKardex = 0;

                                //Verificar el stock
                                List<StockBE> lstStock = new List<StockBE>();
                                StockDL objDL_Stock = new StockDL();
                                lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);
                                if (lstStock.Count > 0)
                                {
                                    //Actualizamos Stock
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                    objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
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
                                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                    objE_Stock.Periodo = pItem.Periodo;
                                    objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                    objE_Stock.IdProducto = item.IdProducto;
                                    objE_Stock.Cantidad = item.Cantidad;
                                    objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                    objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                    objE_Stock.FlagEstado = true;
                                    objE_Stock.Usuario = pItem.Usuario;
                                    objE_Stock.Maquina = pItem.Maquina;

                                    objDL_Stock.Inserta(objE_Stock);
                                }
                                //Insertar el detalle del movimiento del almacen
                                item.IdKardex = IdKardex;

                                item.IdMovimientoAlmacen = pItem.IdMovimientoAlmacen;
                                MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                                objDL_MovimientoAlmacenDetalle.Inserta(item);
                            }
                            else //Nota de Salida
                            {
                                int IdKardex = 0;

                                //Verificar el stock
                                List<StockBE> lstStock = new List<StockBE>();
                                StockDL objDL_Stock = new StockDL();
                                lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);
                                if (lstStock.Count > 0)
                                {
                                    //Actualizamos Stock
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                    objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
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
                                    objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                    objE_Stock.IdProducto = item.IdProducto;
                                    objE_Stock.Cantidad = item.Cantidad;
                                    objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                    objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                    objE_Stock.FlagEstado = true;
                                    objE_Stock.Usuario = pItem.Usuario;
                                    objE_Stock.Maquina = pItem.Maquina;

                                    objDL_Stock.Inserta(objE_Stock);
                                }
                                //Insertar el detalle del movimiento del almacen
                                item.IdKardex = IdKardex;

                                item.IdMovimientoAlmacen = pItem.IdMovimientoAlmacen;
                                MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                                objDL_MovimientoAlmacenDetalle.Inserta(item);
                            }
                        }
                        else
                        {
                            if (pItem.IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota de Ingreso
                            {
                                //Actualizar Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = item.Cantidad;
                                objE_Stock.ValorDescuenta = item.CantidadAnt;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                StockDL objDL_Stock = new StockDL();
                                objDL_Stock.ActualizaCantidades(objE_Stock);
                                //Actualizar el detalle del movimiento del almacen

                                MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                                objDL_MovimientoAlmacenDetalle.Actualiza(item);
                            }
                            else //Nota de Salida
                            {
                                //Actualizar Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = item.CantidadAnt;
                                objE_Stock.ValorDescuenta = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                StockDL objDL_Stock = new StockDL();
                                objDL_Stock.ActualizaCantidades(objE_Stock);

                                //Actualizar el detalle del movimiento del almacen
                                MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                                objDL_MovimientoAlmacenDetalle.Actualiza(item);
                            }
                        }
                    }
                    ////Actualizar el movimiento del almacen
                    //MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                    //MovimientoAlmacen.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MovimientoAlmacenBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Eliminar el movimiento de almacen
                    MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                    MovimientoAlmacen.Elimina(pItem);

                    List<MovimientoAlmacenDetalleBE> lstMovimientoDetalleAlmacen = null;
                    lstMovimientoDetalleAlmacen = new MovimientoAlmacenDetalleDL().ListaTodosActivo(pItem.IdEmpresa, pItem.IdMovimientoAlmacen);

                    foreach (var item in lstMovimientoDetalleAlmacen)
                    {
                        // Eliminar los detalle del movimiento del almacen
                        MovimientoAlmacenDetalleDL MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                        MovimientoAlmacenDetalle.Elimina(item);

                        if (pItem.IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota de Ingreso)
                        {
                            /*int IdKardex = 0;
                            //Insertar Kardex
                            
                                KardexBE objE_Kardex = new KardexBE();
                                objE_Kardex.IdKardex = 0;
                                objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                                objE_Kardex.Periodo = Parametros.intPeriodo;
                                objE_Kardex.FechaMovimiento = Parametros.dtFechaHoraServidor;
                                objE_Kardex.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Kardex.IdProducto = item.IdProducto;
                                objE_Kardex.Cantidad = item.Cantidad;
                                objE_Kardex.IdTipoDocumento = Parametros.intTipoDocNotaIngreso;
                                objE_Kardex.NumeroDocumento = pItem.Numero;
                                objE_Kardex.Observacion = "Salida Por Eliminación de Nota de Ingreso";
                                objE_Kardex.TipoMovimiento = "S";
                                objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                                objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                                objE_Kardex.MontoTotalCompra = item.MontoTotal;
                                objE_Kardex.FlagEstado = true;
                                objE_Kardex.Usuario = pItem.Usuario;
                                objE_Kardex.Maquina = pItem.Maquina;

                                KardexDL objDL_Kardex = new KardexDL();
                                IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

                                //Actualizar Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = 0;
                                objE_Stock.ValorDescuenta = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = item.CostoUnitario;
                                objE_Stock.CostoTotal = item.MontoTotal;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                StockDL objDL_Stock = new StockDL();
                                objDL_Stock.ActualizaCantidades(objE_Stock);
                            
                        }
                        else //Nota de Salida
                        {
                            /*int IdKardex = 0;
                            //Insertar Kardex

                                KardexBE objE_Kardex = new KardexBE();
                                objE_Kardex.IdKardex = 0;
                                objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                                objE_Kardex.Periodo = Parametros.intPeriodo;
                                objE_Kardex.FechaMovimiento = Parametros.dtFechaHoraServidor;
                                objE_Kardex.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Kardex.IdProducto = item.IdProducto;
                                objE_Kardex.Cantidad = item.Cantidad;
                                objE_Kardex.IdTipoDocumento = Parametros.intTipoDocNotaIngreso;
                                objE_Kardex.NumeroDocumento = pItem.Numero;
                                objE_Kardex.Observacion = "Ingreso Por Eliminación de Nota de Salida";
                                objE_Kardex.TipoMovimiento = "I";
                                objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                                objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                                objE_Kardex.MontoTotalCompra = item.MontoTotal;
                                objE_Kardex.FlagEstado = true;
                                objE_Kardex.Usuario = pItem.Usuario;
                                objE_Kardex.Maquina = pItem.Maquina;

                                KardexDL objDL_Kardex = new KardexDL();
                                IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

                                //Actualizar Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.ValorIncrementa = item.Cantidad;
                                objE_Stock.ValorDescuenta = 0;
                                objE_Stock.PrecioCostoPromedio = item.CostoUnitario;
                                objE_Stock.CostoTotal = item.MontoTotal;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                StockDL objDL_Stock = new StockDL();
                                objDL_Stock.ActualizaCantidades(objE_Stock);
                            
                        }
                    }

                    if (pItem.IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota Ingreso //Disable in 061016
                    {
                        if (pItem.IdMovimientoAlmacenReferencia != null)
                        {
                            MovimientoAlmacen.ActualizaRecibido(Convert.ToInt32(pItem.IdMovimientoAlmacenReferencia), false);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaChequeador(MovimientoAlmacenBE pItem)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaChequeador(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaEmbalador(MovimientoAlmacenBE pItem)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaEmbalador(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCierrePicking(MovimientoAlmacenBE pItem)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaCierrePicking(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCierreChequeo(MovimientoAlmacenBE pItem)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaCierreChequeo(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCierreEmbalaje(MovimientoAlmacenBE pItem)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaCierreEmbalaje(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCantidadBulto(MovimientoAlmacenBE pItem)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaCantidadBulto(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void CopiarDatosEnvio(int IdPedidoOrigen, int IdPedidoDestino)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.CopiarDatosEnvio(IdPedidoOrigen, IdPedidoDestino);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 InsertaSalidaEntrada(MovimientoAlmacenBE pItem)
        {
            try
            {
                //using (TransactionScope ts = new TransactionScope())
                //{
                //Inserta Movimiento Almacen
                int IdMovimientoAlmacenDetalle = 0;
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                return IdMovimientoAlmacenDetalle = MovimientoAlmacen.InsertaSalidaEntrada(pItem);

                ////pItem.IdMovimientoAlmacen = IdMovimientoAlmacen;//add
                ////MovimientoAlmacen.ActualizaAuxiliar(pItem);//add

                ////foreach (var item in pListaMovimientoDetalle)
                ////{
                ////    if (pItem.IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota de Ingreso
                ////    {
                ////        int IdKardex = 0;
                ////        //Insertar Kardex

                ////        //Verificar el stock
                ////        List<StockBE> lstStock = new List<StockBE>();
                ////        StockDL objDL_Stock = new StockDL();
                ////        /*lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);
                ////        if (lstStock.Count > 0)
                ////        {*/
                ////            //Actualizamos Stock
                ////            StockBE objE_Stock = new StockBE();
                ////            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                ////            objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                ////            objE_Stock.IdProducto = item.IdProducto;
                ////            objE_Stock.ValorIncrementa = item.Cantidad;
                ////            objE_Stock.ValorDescuenta = 0;
                ////            objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                ////            objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                ////            objE_Stock.Usuario = pItem.Usuario;
                ////            objE_Stock.Maquina = pItem.Maquina;
                ////            objDL_Stock.ActualizaCantidades(objE_Stock);

                ////        //Insertar el detalle del movimiento del almacen
                ////        item.IdKardex = IdKardex;

                ////        item.IdMovimientoAlmacen = IdMovimientoAlmacen;
                ////        MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                ////        objDL_MovimientoAlmacenDetalle.Inserta(item);


                ////    }
                ////    else //Nota de Salida
                ////    {
                ////        int IdKardex = 0;

                ////        //Insertar Kardex
                ////        //Verificar el stock
                ////        List<StockBE> lstStock = new List<StockBE>();
                ////        StockDL objDL_Stock = new StockDL();

                ////        //Actualizamos Stock
                ////        StockBE objE_Stock = new StockBE();
                ////        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                ////        objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                ////        objE_Stock.IdProducto = item.IdProducto;
                ////        objE_Stock.ValorIncrementa = 0;
                ////        objE_Stock.ValorDescuenta = item.Cantidad;
                ////        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                ////        objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                ////        objE_Stock.Usuario = pItem.Usuario;
                ////        objE_Stock.Maquina = pItem.Maquina;

                ////        objDL_Stock.ActualizaCantidades(objE_Stock);


                ////        //Insertar el detalle del movimiento del almacen
                ////        item.IdKardex = IdKardex;

                ////        item.IdMovimientoAlmacen = IdMovimientoAlmacen;
                ////        MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalle = new MovimientoAlmacenDetalleDL();
                ////        objDL_MovimientoAlmacenDetalle.Inserta(item);
                ////    }
                ////}

                ////if (pItem.IdTipoMovimiento == Parametros.intTipMovIngreso) //Nota Ingreso
                ////{
                ////    //Actualizamos la numeración el documento de ingreso del movimiento de almacen
                ////    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                ////    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, Parametros.intTipoDocNotaIngreso, pItem.Periodo);
                ////}
                ////else //Nota Salida
                ////{
                ////    //Actualizamos la numeración el documento de salida del movimiento de almacen
                ////    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                ////    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, Parametros.intTipoDocNotaSalida, pItem.Periodo);
                ////}

                //ts.Complete();

                //}
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSalidaEntrada(MovimientoAlmacenBE pItem)
        {
            try
            {
                //using (TransactionScope ts = new TransactionScope())
                //{
                //Inserta Movimiento Almacen
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaSalidaEntrada(pItem);

                //ts.Complete();

                //}
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void ActualizaRecibidoFisico(int IdMovimientoAlmacen, bool FlagRecibidoFisico, string UsuarioRecibidoFisico)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaRecibidoFisico(IdMovimientoAlmacen, FlagRecibidoFisico, UsuarioRecibidoFisico);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaRecibido(int IdMovimientoAlmacen, bool FlagRecibido)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaRecibido(IdMovimientoAlmacen, FlagRecibido);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void ActualizaDespachado(int IdMovimientoAlmacen, bool FlagDespachado)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaDespachado(IdMovimientoAlmacen, FlagDespachado);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaRevision(int IdMovimientoAlmacen, bool FlagRevision, string UsuarioRevision)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizaRevision(IdMovimientoAlmacen, FlagRevision, UsuarioRevision);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizarBultos(int IdNotaSalida, int NroBultos, string pUsuario, int pIdPersona)
        {
            try
            {
                MovimientoAlmacenDL MovimientoAlmacen = new MovimientoAlmacenDL();
                MovimientoAlmacen.ActualizarBultosNS(IdNotaSalida, NroBultos, pUsuario, pIdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
