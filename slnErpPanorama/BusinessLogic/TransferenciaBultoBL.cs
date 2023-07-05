using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TransferenciaBultoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<TransferenciaBultoBE> ListaTodosActivo(int IdEmpresa, int Periodo)
        {
            try
            {
                TransferenciaBultoDL TransferenciaBulto = new TransferenciaBultoDL();
                return TransferenciaBulto.ListaTodosActivo(IdEmpresa, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TransferenciaBultoBE> SeleccionaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                TransferenciaBultoDL TransferenciaBulto = new TransferenciaBultoDL();
                return TransferenciaBulto.SeleccionaFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TransferenciaBultoBE Selecciona(int IdEmpresa, int IdTransferenciaBulto)
        {
            try
            {
                TransferenciaBultoDL TransferenciaBulto = new TransferenciaBultoDL();
                return TransferenciaBulto.Selecciona(IdEmpresa, IdTransferenciaBulto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TransferenciaBultoBE pItem, List<TransferenciaBultoDetalleBE> pListaTransferenciaBultoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    TransferenciaBultoDL TransferenciaBulto = new TransferenciaBultoDL();
                    MovimientoAlmacenDL MovimientoAlmnacenSalida = new MovimientoAlmacenDL();
                    MovimientoAlmacenDL MovimientoAlmnacenIngreso = new MovimientoAlmacenDL();
                    NumeracionDocumentoDL  NumeracionDocumentoIngreso = new NumeracionDocumentoDL();
                    NumeracionDocumentoDL NumeracionDocumentoSalida = new NumeracionDocumentoDL();

                    ////Insertamos el movimiento de salida de almacen
                    //string NumeroDocumentoSalida = "";
                    //List<NumeracionDocumentoBE> lstNumeroDocumentoSalida = null;
                    //lstNumeroDocumentoSalida = NumeracionDocumentoSalida.ObtenerCorrelativoPeriodo(pItem.IdEmpresa, Parametros.intTipoDocNotaSalida, pItem.Periodo);
                    //if (lstNumeroDocumentoSalida.Count > 0)
                    //{
                    //    NumeroDocumentoSalida = AgregarCaracter((lstNumeroDocumentoSalida[0].Numero + 1).ToString(), "0", 6);
                    //}

                    ////MovimientoAlmacenBE objE_MovimientoAlmacenSalida = new MovimientoAlmacenBE();
                    ////objE_MovimientoAlmacenSalida.IdMovimientoAlmacen = 0;
                    ////objE_MovimientoAlmacenSalida.IdEmpresa = pItem.IdEmpresa;
                    ////objE_MovimientoAlmacenSalida.Periodo = pItem.Periodo;
                    ////objE_MovimientoAlmacenSalida.Numero = NumeroDocumentoSalida;
                    ////objE_MovimientoAlmacenSalida.IdTipoMovimiento = Parametros.intTipMovSalida;
                    ////objE_MovimientoAlmacenSalida.Fecha = pItem.FechaMovimiento;
                    ////objE_MovimientoAlmacenSalida.IdAlmacen = pItem.IdAlmacenOrigen;
                    ////objE_MovimientoAlmacenSalida.IdMotivo = Parametros.intMovTransferencia;
                    ////objE_MovimientoAlmacenSalida.IdTipoDocumento = pItem.IdTipoDocumento;
                    ////objE_MovimientoAlmacenSalida.NumeroDocumento = pItem.NumeroDocumento;
                    ////objE_MovimientoAlmacenSalida.Referencia = "Transferencia de Bultos";
                    ////objE_MovimientoAlmacenSalida.Observaciones = "";
                    ////objE_MovimientoAlmacenSalida.FlagEstado = true;
                    ////objE_MovimientoAlmacenSalida.Usuario = pItem.Usuario;
                    ////objE_MovimientoAlmacenSalida.Maquina = pItem.Maquina;

                    ////Int32 IdMovimientoAlmacenSalida = 0;
                    ////IdMovimientoAlmacenSalida=MovimientoAlmnacenSalida.Inserta(objE_MovimientoAlmacenSalida);

                    //NumeracionDocumentoSalida.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, Parametros.intTipoDocNotaSalida, pItem.Periodo);

                    ////Insertamos el movimiento de ingreso de almacen
                    //string NumeroDocumentoIngreso = "";
                    //List<NumeracionDocumentoBE> lstNumeroDocumentoIngreso = null;
                    //lstNumeroDocumentoIngreso = NumeracionDocumentoIngreso.ObtenerCorrelativoPeriodo(pItem.IdEmpresa, Parametros.intTipoDocNotaIngreso, pItem.Periodo);
                    //if (lstNumeroDocumentoIngreso.Count > 0)
                    //{
                    //    NumeroDocumentoIngreso = AgregarCaracter((lstNumeroDocumentoIngreso[0].Numero + 1).ToString(), "0", 6);
                    //}

                    ////MovimientoAlmacenBE objE_MovimientoAlmacenIngreso = new MovimientoAlmacenBE();
                    ////objE_MovimientoAlmacenIngreso.IdMovimientoAlmacen = 0;
                    ////objE_MovimientoAlmacenIngreso.IdEmpresa = pItem.IdEmpresa;
                    ////objE_MovimientoAlmacenIngreso.Periodo = pItem.Periodo;
                    ////objE_MovimientoAlmacenIngreso.Numero = NumeroDocumentoIngreso;
                    ////objE_MovimientoAlmacenIngreso.IdTipoMovimiento = Parametros.intTipMovIngreso;
                    ////objE_MovimientoAlmacenIngreso.Fecha = pItem.FechaMovimiento;
                    ////objE_MovimientoAlmacenIngreso.IdAlmacen = pItem.IdAlmacenDestino;
                    ////objE_MovimientoAlmacenIngreso.IdMotivo = Parametros.intMovTransferencia;
                    ////objE_MovimientoAlmacenIngreso.IdTipoDocumento = pItem.IdTipoDocumento;
                    ////objE_MovimientoAlmacenIngreso.NumeroDocumento = pItem.NumeroDocumento;
                    ////objE_MovimientoAlmacenIngreso.Referencia = "Transferencia de Bultos";
                    ////objE_MovimientoAlmacenIngreso.Observaciones = "";
                    ////objE_MovimientoAlmacenIngreso.FlagEstado = true;
                    ////objE_MovimientoAlmacenIngreso.Usuario = pItem.Usuario;
                    ////objE_MovimientoAlmacenIngreso.Maquina = pItem.Maquina;

                    ////Int32 IdMovimientoAlmacenIngreso = 0;
                    ////IdMovimientoAlmacenIngreso = MovimientoAlmnacenSalida.Inserta(objE_MovimientoAlmacenIngreso);

                    //NumeracionDocumentoIngreso.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, Parametros.intTipoDocNotaIngreso, pItem.Periodo);

                    ////Insertamos la cabecera de la tranferencia del bulto
                    ////Int32 intIdTransferenciaBulto = 0;
                    ////pItem.IdMovimientoAlmacenSalida = IdMovimientoAlmacenSalida;
                    ////pItem.IdMovimientoAlmacenIngreso = IdMovimientoAlmacenIngreso;
                    ////intIdTransferenciaBulto = TransferenciaBulto.Inserta(pItem);
                    
                    ////Acualizamos el correlativo del documento.
                    //NumeracionDocumentoDL NumeracionDocumento = new NumeracionDocumentoDL();
                    //NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa,pItem.IdTipoDocumento, pItem.Periodo);

                    int Numero = 1;
                    foreach (var item in pListaTransferenciaBultoDetalle)
                    {
                        ////Insertamos en el Kardex de Bulto
                        //int IdKardexBulto = 0;
                        //KardexBultoBE objE_KardexBulto = new KardexBultoBE();
                        //objE_KardexBulto.IdKardexBulto = 0;
                        //objE_KardexBulto.IdEmpresa = pItem.IdEmpresa;
                        //objE_KardexBulto.Periodo = pItem.Periodo;
                        //objE_KardexBulto.FechaMovimiento = Convert.ToDateTime(pItem.FechaMovimiento);
                        //objE_KardexBulto.IdAlmacen = pItem.IdAlmacenOrigen;
                        //objE_KardexBulto.IdBulto = item.IdBulto;
                        //objE_KardexBulto.Cantidad = 1;
                        //objE_KardexBulto.IdTipoDocumento = Parametros.intTipoDocNotaSalida;
                        //objE_KardexBulto.NumeroDocumento = NumeroDocumentoSalida;
                        //objE_KardexBulto.Observacion = "Salida por Transferencia de Bultos";
                        //objE_KardexBulto.TipoMovimiento = "S";
                        //objE_KardexBulto.MontoUnitarioCompra = item.PrecioUnitario;
                        //objE_KardexBulto.PrecioCostoPromedio = 0;
                        //objE_KardexBulto.MontoTotalCompra = 0;
                        //objE_KardexBulto.FlagEstado = true;
                        //objE_KardexBulto.Usuario = pItem.Usuario;
                        //objE_KardexBulto.Maquina = pItem.Maquina;

                        //KardexBultoBE objE_KardexValorizado = new KardexBultoBE();
                        //objE_KardexValorizado = new KardexBultoDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdAlmacenOrigen, item.IdProducto);

                        //if (objE_KardexValorizado != null)
                        //{
                        //    decimal dmlPCP = 0;
                        //    decimal dmlCostoTotal = 0;

                        //    if (objE_KardexValorizado.Saldo != 0)
                        //    {
                        //        //Calcula Precio Costo Promedio
                        //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_KardexBulto.Cantidad * objE_KardexBulto.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_KardexBulto.Cantidad);
                        //        dmlCostoTotal = dmlPCP * objE_KardexBulto.Cantidad;

                        //        objE_KardexBulto.PrecioCostoPromedio = dmlPCP;
                        //        objE_KardexBulto.MontoTotalCompra = dmlCostoTotal;
                        //    }

                        //}
                        //else
                        //{
                        //    objE_KardexBulto.PrecioCostoPromedio = objE_KardexBulto.PrecioCostoPromedio;
                        //}

                        //KardexBultoDL objDL_KardexBulto = new KardexBultoDL();
                        //IdKardexBulto = objDL_KardexBulto.Inserta(objE_KardexBulto);

                        ////Verificar el stock
                        //List<StockBultoBE> lstStockBulto = new List<StockBultoBE>();
                        //StockBultoDL objDL_StockBulto = new StockBultoDL();
                        //lstStockBulto = objDL_StockBulto.ListaProducto(pItem.IdEmpresa, pItem.IdAlmacenOrigen, item.IdProducto);
                        //if (lstStockBulto.Count > 0)
                        //{
                        //    //Actualizamos Stock de Bultos
                        //    StockBultoBE objE_StockBulto = new StockBultoBE();
                        //    objE_StockBulto.IdEmpresa = pItem.IdEmpresa;
                        //    objE_StockBulto.IdAlmacen = pItem.IdAlmacenOrigen;
                        //    objE_StockBulto.IdProducto = item.IdProducto;
                        //    objE_StockBulto.ValorIncrementa = 0;
                        //    objE_StockBulto.ValorDescuenta = item.Cantidad;
                        //    objE_StockBulto.PrecioCostoPromedio = 0;//objE_KardexBulto.PrecioCostoPromedio;
                        //    objE_StockBulto.CostoTotal = 0;// objE_KardexBulto.MontoTotalCompra;
                        //    objE_StockBulto.Usuario = pItem.Usuario;
                        //    objE_StockBulto.Maquina = pItem.Maquina;

                        //    objDL_StockBulto.ActualizaCantidades(objE_StockBulto);
                        //}
                        //else
                        //{
                        //    //Insertamos Stock de Bultos
                        //    StockBultoBE objE_StockBulto = new StockBultoBE();
                        //    objE_StockBulto.IdStockBulto = 0;
                        //    objE_StockBulto.IdEmpresa = pItem.IdEmpresa;
                        //    objE_StockBulto.Periodo = pItem.Periodo;
                        //    objE_StockBulto.IdAlmacen = pItem.IdAlmacenOrigen;
                        //    objE_StockBulto.IdProducto = item.IdProducto;
                        //    objE_StockBulto.Cantidad = item.Cantidad ;
                        //    objE_StockBulto.PrecioCostoPromedio = 0;//objE_KardexBulto.PrecioCostoPromedio;
                        //    objE_StockBulto.CostoTotal = 0;// objE_KardexBulto.MontoTotalCompra;
                        //    objE_StockBulto.FlagEstado = true;
                        //    objE_StockBulto.Usuario = pItem.Usuario;
                        //    objE_StockBulto.Maquina = pItem.Maquina;

                        //    objDL_StockBulto.Inserta(objE_StockBulto);
                        //}

                        //Insertamos en el Kardex de Producto
                        //int IdKardex = 0;
                        //KardexBE objE_Kardex = new KardexBE();
                        //objE_Kardex.IdKardex = 0;
                        //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                        //objE_Kardex.Periodo = pItem.Periodo;
                        //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.FechaMovimiento);
                        //objE_Kardex.IdAlmacen = pItem.IdAlmacenDestino;
                        //objE_Kardex.IdProducto = item.IdProducto;
                        //objE_Kardex.Cantidad = item.Cantidad;
                        //objE_Kardex.IdTipoDocumento = Parametros.intTipoDocNotaIngreso;
                        //objE_Kardex.NumeroDocumento = NumeroDocumentoIngreso;
                        //objE_Kardex.Observacion = "Nota de Salida de Almacen";
                        //objE_Kardex.TipoMovimiento = "S";
                        //objE_Kardex.MontoUnitarioCompra = item.PrecioUnitario;
                        //objE_Kardex.PrecioCostoPromedio = item.PrecioUnitario;
                        //objE_Kardex.MontoTotalCompra = item.PrecioUnitario * item.Cantidad;
                        //objE_Kardex.FlagEstado = true;
                        //objE_Kardex.Usuario = pItem.Usuario;
                        //objE_Kardex.Maquina = pItem.Maquina;

                        //KardexBE objE_KardexValorizadoProducto = new KardexBE();
                        //objE_KardexValorizadoProducto = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenDestino, item.IdProducto);

                        //if (objE_KardexValorizadoProducto != null)
                        //{
                        //    decimal dmlPCP = 0;
                        //    decimal dmlCostoTotal = 0;

                        //    if (objE_KardexValorizadoProducto.Saldo != 0)
                        //    {
                        //        //Calcula Precio Costo Promedio
                        //        dmlPCP = dmlPCP = ((objE_KardexValorizadoProducto.Saldo * objE_KardexValorizadoProducto.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizadoProducto.Saldo + objE_Kardex.Cantidad);
                        //        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;

                        //        objE_Kardex.PrecioCostoPromedio = dmlPCP;
                        //        objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                        //    }

                        //}
                        //else
                        //{
                        //    objE_Kardex.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                        //}

                        //KardexDL objDL_Kardex = new KardexDL();
                        //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenDestino, item.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacenDestino;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = item.Cantidad;
                            objE_Stock.ValorDescuenta = 0;
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
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = pItem.IdAlmacenDestino;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0; //objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }

                        #region "Actualiza bultos"

                        List<StockBE> lstStockBulto = new List<StockBE>();
                        StockDL objDL_StockBulto = new StockDL();
                        lstStockBulto = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenOrigen, item.IdProducto);
                        if (lstStockBulto.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
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
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = pItem.IdAlmacenOrigen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = 0; //objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }

                        #endregion



                        ////Insertamos el detalle del movimiento de salida
                        //MovimientoAlmacenDetalleBE objE_MovimientoAlmacenDetalleSalida = new MovimientoAlmacenDetalleBE();
                        //objE_MovimientoAlmacenDetalleSalida.IdMovimientoAlmacenDetalle = 0;
                        //objE_MovimientoAlmacenDetalleSalida.IdMovimientoAlmacen = IdMovimientoAlmacenSalida;
                        //objE_MovimientoAlmacenDetalleSalida.Item = Numero;
                        //objE_MovimientoAlmacenDetalleSalida.IdProducto = item.IdProducto;
                        //objE_MovimientoAlmacenDetalleSalida.Cantidad = item.Cantidad;
                        //objE_MovimientoAlmacenDetalleSalida.CostoUnitario = item.PrecioUnitario;
                        //objE_MovimientoAlmacenDetalleSalida.MontoTotal = item.Cantidad * item.PrecioUnitario;
                        //objE_MovimientoAlmacenDetalleSalida.IdKardex = null;
                        //objE_MovimientoAlmacenDetalleSalida.FlagEstado = true;
                        //objE_MovimientoAlmacenDetalleSalida.Usuario = item.Usuario;
                        //objE_MovimientoAlmacenDetalleSalida.Maquina = item.Maquina;
                        //objE_MovimientoAlmacenDetalleSalida.IdEmpresa = item.IdEmpresa;

                        //MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalleSalida = new MovimientoAlmacenDetalleDL();
                        //objDL_MovimientoAlmacenDetalleSalida.Inserta(objE_MovimientoAlmacenDetalleSalida);

                        //Insertamos el detalle del movimiento de ingreso
                        //MovimientoAlmacenDetalleBE objE_MovimientoAlmacenDetalleIngreso = new MovimientoAlmacenDetalleBE();
                        //objE_MovimientoAlmacenDetalleIngreso.IdMovimientoAlmacenDetalle = 0;
                        //objE_MovimientoAlmacenDetalleIngreso.IdMovimientoAlmacen = IdMovimientoAlmacenIngreso;
                        //objE_MovimientoAlmacenDetalleIngreso.Item = Numero;
                        //objE_MovimientoAlmacenDetalleIngreso.IdProducto = item.IdProducto;
                        //objE_MovimientoAlmacenDetalleIngreso.Cantidad = item.Cantidad;
                        //objE_MovimientoAlmacenDetalleIngreso.CostoUnitario = item.PrecioUnitario;
                        //objE_MovimientoAlmacenDetalleIngreso.MontoTotal = item.Cantidad * item.PrecioUnitario;
                        //objE_MovimientoAlmacenDetalleIngreso.IdKardex = IdKardex;
                        //objE_MovimientoAlmacenDetalleIngreso.FlagEstado = true;
                        //objE_MovimientoAlmacenDetalleIngreso.Usuario = item.Usuario;
                        //objE_MovimientoAlmacenDetalleIngreso.Maquina = item.Maquina;
                        //objE_MovimientoAlmacenDetalleIngreso.IdEmpresa = item.IdEmpresa;

                        //MovimientoAlmacenDetalleDL objDL_MovimientoAlmacenDetalleIngreso = new MovimientoAlmacenDetalleDL();
                        //objDL_MovimientoAlmacenDetalleIngreso.Inserta(objE_MovimientoAlmacenDetalleIngreso);

                        ////Insertamos el detalle de la Transferencia
                        //TransferenciaBultoDetalleDL TransFerenciaDetalleBulto = new TransferenciaBultoDetalleDL();
                        //item.IdTransferenciaBulto = intIdTransferenciaBulto;
                        //item.IdKardex = IdKardex;
                        //item.IdKardexBulto = IdKardexBulto;
                        //TransFerenciaDetalleBulto.Inserta(item);

                        //Actualizamos la situación del bulto
                        BultoBE objE_Bulto = new BultoBE();
                        objE_Bulto.IdEmpresa = item.IdEmpresa;
                        objE_Bulto.IdBulto = item.IdBulto;
                        objE_Bulto.IdSituacion = Parametros.intBULTransferido;
                        objE_Bulto.FechaSalida = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
                        objE_Bulto.Usuario = item.Usuario;
                        objE_Bulto.Maquina = item.Maquina;

                        BultoDL objDL_Bulto = new BultoDL();
                        objDL_Bulto.ActualizaSituacion(objE_Bulto);

                        Numero++;
                    }

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TransferenciaBultoBE pItem, List<TransferenciaBultoDetalleBE> pListaTransferenciaBultoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    TransferenciaBultoDL TransferenciaBulto = new TransferenciaBultoDL();
                

                    //Actualizamos la factura de compra
                    TransferenciaBulto.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TransferenciaBultoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    TransferenciaBultoDL TransferenciaBulto = new TransferenciaBultoDL();
                    //Eliminar la transferencia del bulto
                    TransferenciaBulto.Elimina(pItem);

                    //Listar Los Detalle de la Transferencia del Bulto
                    List<TransferenciaBultoDetalleBE> pListaTransferenciaDetalle = null;
                    pListaTransferenciaDetalle = new TransferenciaBultoDetalleDL().ListaTodosActivo(pItem.IdEmpresa, pItem.IdTransferenciaBulto);

                    foreach (var item in pListaTransferenciaDetalle)
                    {
                        //Elimina los detalle de la transferencia del bulto
                        TransferenciaBultoDetalleDL TransferenciaBultoDetalle = new TransferenciaBultoDetalleDL();
                        TransferenciaBultoDetalle.Elimina(item);

                        //Insertamos en el Kardex de Bulto
                        //int IdKardexBulto = 0;
                        //KardexBultoBE objE_KardexBulto = new KardexBultoBE();
                        //objE_KardexBulto.IdKardexBulto = 0;
                        //objE_KardexBulto.IdEmpresa = pItem.IdEmpresa;
                        //objE_KardexBulto.Periodo = pItem.Periodo;
                        //objE_KardexBulto.FechaMovimiento = Convert.ToDateTime(pItem.FechaMovimiento);
                        //objE_KardexBulto.IdAlmacen = pItem.IdAlmacenOrigen;
                        //objE_KardexBulto.IdBulto = item.IdBulto;
                        //objE_KardexBulto.Cantidad = 1;
                        //objE_KardexBulto.IdTipoDocumento = pItem.IdTipoDocumento;
                        //objE_KardexBulto.NumeroDocumento = pItem.NumeroDocumento;
                        //objE_KardexBulto.Observacion = "Ingreso Por Anulación Transferencia de Bultos";
                        //objE_KardexBulto.TipoMovimiento = "I";
                        //objE_KardexBulto.MontoUnitarioCompra = item.CostoUnitario;
                        //objE_KardexBulto.PrecioCostoPromedio = item.CostoUnitario;
                        //objE_KardexBulto.MontoTotalCompra = item.CostoUnitario;
                        //objE_KardexBulto.FlagEstado = true;
                        //objE_KardexBulto.Usuario = pItem.Usuario;
                        //objE_KardexBulto.Maquina = pItem.Maquina;

                        //KardexBultoBE objE_KardexValorizado = new KardexBultoBE();
                        //objE_KardexValorizado = new KardexBultoDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdAlmacenOrigen, item.IdProducto);

                        //if (objE_KardexValorizado != null)
                        //{
                        //    decimal dmlPCP = 0;
                        //    decimal dmlCostoTotal = 0;

                        //    if (objE_KardexValorizado.Saldo != 0)
                        //    {
                        //        //Calcula Precio Costo Promedio
                        //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_KardexBulto.Cantidad * objE_KardexBulto.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_KardexBulto.Cantidad);
                        //        dmlCostoTotal = dmlPCP * objE_KardexBulto.Cantidad;

                        //        objE_KardexBulto.PrecioCostoPromedio = dmlPCP;
                        //        objE_KardexBulto.MontoTotalCompra = dmlCostoTotal;
                        //    }

                        //}
                        //else
                        //{
                        //    objE_KardexBulto.PrecioCostoPromedio = objE_KardexBulto.PrecioCostoPromedio;
                        //}

                        //KardexBultoDL objDL_KardexBulto = new KardexBultoDL();
                        //IdKardexBulto = objDL_KardexBulto.Inserta(objE_KardexBulto);

                        ////Verificar el stock
                        //StockBultoDL objDL_StockBulto = new StockBultoDL();
                        
                        ////Actualizamos Stock de Bultos
                        //StockBultoBE objE_StockBulto = new StockBultoBE();
                        //objE_StockBulto.IdEmpresa = pItem.IdEmpresa;
                        //objE_StockBulto.IdAlmacen = pItem.IdAlmacenOrigen;
                        //objE_StockBulto.IdProducto = item.IdProducto;
                        //objE_StockBulto.ValorIncrementa = 1;
                        //objE_StockBulto.ValorDescuenta = 0;
                        //objE_StockBulto.PrecioCostoPromedio = objE_KardexBulto.PrecioCostoPromedio;
                        //objE_StockBulto.CostoTotal = objE_KardexBulto.MontoTotalCompra;
                        //objE_StockBulto.Usuario = pItem.Usuario;
                        //objE_StockBulto.Maquina = pItem.Maquina;
                        //objDL_StockBulto.ActualizaCantidades(objE_StockBulto);

                        ////Insertamos en el Kardex de Producto
                        //int IdKardex = 0;
                        //KardexBE objE_Kardex = new KardexBE();
                        //objE_Kardex.IdKardex = 0;
                        //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                        //objE_Kardex.Periodo = pItem.Periodo;
                        //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.FechaMovimiento);
                        //objE_Kardex.IdAlmacen = pItem.IdAlmacenDestino;
                        //objE_Kardex.IdProducto = item.IdProducto;
                        //objE_Kardex.Cantidad = item.Cantidad;
                        //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                        //objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                        //objE_Kardex.Observacion = "Salida Por Anulación por Transferencia de Bultos";
                        //objE_Kardex.TipoMovimiento = "S";
                        //objE_Kardex.MontoUnitarioCompra = 0;
                        //objE_Kardex.PrecioCostoPromedio = 0;
                        //objE_Kardex.MontoTotalCompra = 0;
                        //objE_Kardex.FlagEstado = true;
                        //objE_Kardex.Usuario = pItem.Usuario;
                        //objE_Kardex.Maquina = pItem.Maquina;

                        //KardexDL objDL_Kardex = new KardexDL();
                        //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        ////Verificar el stock
                        //List<StockBE> lstStock = new List<StockBE>();
                        //StockDL objDL_Stock = new StockDL();
                        //lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTienda, pItem.IdAlmacenDestino, item.IdProducto);
                        //if (lstStock.Count > 0)
                        //{
                        //    //Actualizamos Stock
                        //    StockBE objE_Stock = new StockBE();
                        //    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        //    objE_Stock.IdAlmacen = pItem.IdAlmacenDestino;
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
                        //    objE_Stock.IdAlmacen = pItem.IdAlmacenDestino;
                        //    objE_Stock.IdProducto = item.IdProducto;
                        //    objE_Stock.Cantidad = item.Cantidad;
                        //    objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                        //    objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                        //    objE_Stock.FlagEstado = true;
                        //    objE_Stock.Usuario = pItem.Usuario;
                        //    objE_Stock.Maquina = pItem.Maquina;

                        //    objDL_Stock.Inserta(objE_Stock);
                        //}

                        //Actualizamos la situación del bulto
                        BultoBE objE_Bulto = new BultoBE();
                        objE_Bulto.IdEmpresa = item.IdEmpresa;
                        objE_Bulto.IdBulto = item.IdBulto;
                        objE_Bulto.IdSituacion = Parametros.intBULRecibido;
                        objE_Bulto.FechaSalida = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
                        objE_Bulto.Usuario = item.Usuario;
                        objE_Bulto.Maquina = item.Maquina;

                        BultoDL objDL_Bulto = new BultoDL();
                        objDL_Bulto.ActualizaSituacion(objE_Bulto);
                        
                    }

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
    }
}
