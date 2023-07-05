using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class GuiaRemisionBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public GuiaRemisionBE Selecciona(int IdEmpresa, int IdGuiaRemision)
        {
            try
            {
                GuiaRemisionDL GuiaRemision = new GuiaRemisionDL();
                return GuiaRemision.Selecciona(IdEmpresa, IdGuiaRemision);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<GuiaRemisionBE> ListaTodosActivo(int IdEmpresa, int Periodo)
        {
            try
            {
                GuiaRemisionDL GuiaRemision = new GuiaRemisionDL();
                return GuiaRemision.ListaTodosActivo(IdEmpresa,Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(GuiaRemisionBE pItem, List<GuiaRemisionDetalleBE> pListaMovimientoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Inserta Guia Remision
                    int IdGuiaRemision = 0;
                    GuiaRemisionDL GuiaRemision = new GuiaRemisionDL();
                    IdGuiaRemision = GuiaRemision.Inserta(pItem);

                    foreach (var item in pListaMovimientoDetalle)
                    {
                        //Verifica el Stock Actual
                        List<StockBE> lstStockActual = null;
                        lstStockActual = new StockDL().ListaProducto(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);

                        if (lstStockActual.Count == 0) // no hay stock
                        {
                            int IdKardex = 0;
                            //Insertar Kardex
                            KardexBE objE_Kardex = new KardexBE();
                            objE_Kardex.IdKardex = 0;
                            objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            objE_Kardex.Periodo = pItem.Periodo;
                            objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            objE_Kardex.IdAlmacen = Parametros.intAlmCentral;
                            objE_Kardex.IdProducto = item.IdProducto;
                            objE_Kardex.Cantidad = item.Cantidad;
                            objE_Kardex.IdTipoDocumento = Parametros.intTipoDocGuiaRemision;
                            objE_Kardex.NumeroDocumento = pItem.Numero;
                            objE_Kardex.Observacion = "Guia de Remisión";
                            objE_Kardex.TipoMovimiento = "S";
                            objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                            objE_Kardex.PrecioCostoPromedio = 0;
                            objE_Kardex.MontoTotalCompra = 0;
                            objE_Kardex.FlagEstado = true;
                            objE_Kardex.Usuario = pItem.Usuario;
                            objE_Kardex.Maquina = pItem.Maquina;

                            KardexBE objE_KardexValorizado = new KardexBE();
                            objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);

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
                            lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
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
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }

                            //Insertar el detalle del movimiento del almacen
                            item.IdKardex = IdKardex;
                            item.IdGuiaRemision = IdGuiaRemision;
                            GuiaRemisionDetalleDL objDL_GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                            objDL_GuiaRemisionDetalle.Inserta(item);
                        }
                        else
                        {
                            if (item.Cantidad > lstStockActual[0].Cantidad)
                            {
                                BultoDL objBulto = new BultoDL();
                                List<BultoBE> lstBultos = null;
                                lstBultos = new BultoDL().ListaRecepcionados(pItem.IdEmpresa, item.IdProducto);
                                if (lstBultos.Count > 0)
                                {
                                    int i = 0;
                                    int StockActual = 0;
                                    StockActual = lstStockActual[0].Cantidad;
                                    while (item.Cantidad > StockActual)
                                    {
                                        //Insertamos en el Kardex de Bulto
                                        int IdKardexBulto = 0;
                                        KardexBultoBE objE_KardexBulto = new KardexBultoBE();
                                        objE_KardexBulto.IdKardexBulto = 0;
                                        objE_KardexBulto.IdEmpresa = pItem.IdEmpresa;
                                        objE_KardexBulto.Periodo = pItem.Periodo;
                                        objE_KardexBulto.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                                        objE_KardexBulto.IdAlmacen = Parametros.intAlmBultos;
                                        objE_KardexBulto.IdBulto = lstBultos[i].IdBulto;
                                        objE_KardexBulto.Cantidad = 1;
                                        objE_KardexBulto.IdTipoDocumento = pItem.IdTipoDocumento;
                                        objE_KardexBulto.NumeroDocumento = pItem.NumeroDocumento;
                                        objE_KardexBulto.Observacion = "Salida por Movimiento de Salidas de Bultos";
                                        objE_KardexBulto.TipoMovimiento = "S";
                                        objE_KardexBulto.MontoUnitarioCompra = lstBultos[i].CostoUnitario;
                                        objE_KardexBulto.PrecioCostoPromedio = 0;
                                        objE_KardexBulto.MontoTotalCompra = 0;
                                        objE_KardexBulto.FlagEstado = true;
                                        objE_KardexBulto.Usuario = pItem.Usuario;
                                        objE_KardexBulto.Maquina = pItem.Maquina;

                                        KardexBultoBE objE_KardexValorizado = new KardexBultoBE();
                                        objE_KardexValorizado = new KardexBultoDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, Parametros.intAlmBultos, item.IdProducto);

                                        if (objE_KardexValorizado != null)
                                        {
                                            decimal dmlPCP = 0;
                                            decimal dmlCostoTotal = 0;

                                            if (objE_KardexValorizado.Saldo != 0)
                                            {
                                                //Calcula Precio Costo Promedio
                                                dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_KardexBulto.Cantidad * objE_KardexBulto.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_KardexBulto.Cantidad);
                                                dmlCostoTotal = dmlPCP * objE_KardexBulto.Cantidad;

                                                objE_KardexBulto.PrecioCostoPromedio = dmlPCP;
                                                objE_KardexBulto.MontoTotalCompra = dmlCostoTotal;
                                            }

                                        }
                                        else
                                        {
                                            objE_KardexBulto.PrecioCostoPromedio = objE_KardexBulto.PrecioCostoPromedio;
                                        }

                                        KardexBultoDL objDL_KardexBulto = new KardexBultoDL();
                                        IdKardexBulto = objDL_KardexBulto.Inserta(objE_KardexBulto);

                                        //Verificar el stock
                                        List<StockBultoBE> lstStockBulto = new List<StockBultoBE>();
                                        StockBultoDL objDL_StockBulto = new StockBultoDL();
                                        lstStockBulto = objDL_StockBulto.ListaProducto(pItem.IdEmpresa, Parametros.intAlmBultos, item.IdProducto);
                                        if (lstStockBulto.Count > 0)
                                        {
                                            //Actualizamos Stock de Bultos
                                            StockBultoBE objE_StockBulto = new StockBultoBE();
                                            objE_StockBulto.IdEmpresa = pItem.IdEmpresa;
                                            objE_StockBulto.IdAlmacen = Parametros.intAlmBultos;
                                            objE_StockBulto.IdProducto = item.IdProducto;
                                            objE_StockBulto.ValorIncrementa = 0;
                                            objE_StockBulto.ValorDescuenta = 1;
                                            objE_StockBulto.PrecioCostoPromedio = objE_KardexBulto.PrecioCostoPromedio;
                                            objE_StockBulto.CostoTotal = objE_KardexBulto.MontoTotalCompra;
                                            objE_StockBulto.Usuario = pItem.Usuario;
                                            objE_StockBulto.Maquina = pItem.Maquina;

                                            objDL_StockBulto.ActualizaCantidades(objE_StockBulto);
                                        }
                                        else
                                        {
                                            //Insertamos Stock de Bultos
                                            StockBultoBE objE_StockBulto = new StockBultoBE();
                                            objE_StockBulto.IdStockBulto = 0;
                                            objE_StockBulto.IdEmpresa = pItem.IdEmpresa;
                                            objE_StockBulto.Periodo = pItem.Periodo;
                                            objE_StockBulto.IdAlmacen = Parametros.intAlmBultos;
                                            objE_StockBulto.IdProducto = item.IdProducto;
                                            objE_StockBulto.Cantidad = 1;
                                            objE_StockBulto.PrecioCostoPromedio = objE_KardexBulto.PrecioCostoPromedio;
                                            objE_StockBulto.CostoTotal = objE_KardexBulto.MontoTotalCompra;
                                            objE_StockBulto.FlagEstado = true;
                                            objE_StockBulto.Usuario = pItem.Usuario;
                                            objE_StockBulto.Maquina = pItem.Maquina;

                                            objDL_StockBulto.Inserta(objE_StockBulto);
                                        }

                                        //Actualizamos la situación del bulto
                                        BultoBE objE_Bulto = new BultoBE();
                                        objE_Bulto.IdEmpresa = item.IdEmpresa;
                                        objE_Bulto.IdBulto = lstBultos[i].IdBulto;
                                        objE_Bulto.IdSituacion = Parametros.intBULTransferido;
                                        objE_Bulto.FechaSalida = Convert.ToDateTime(DateTime.Now.ToShortDateString().ToString());
                                        objE_Bulto.Usuario = item.Usuario;
                                        objE_Bulto.Maquina = item.Maquina;

                                        BultoDL objDL_Bulto = new BultoDL();
                                        objDL_Bulto.ActualizaSituacion(objE_Bulto);

                                        //Insertamos en el Documento Bulto
                                        DocumentoBultoBE objE_DocumentoBulto = new DocumentoBultoBE();
                                        objE_DocumentoBulto.IdDocumentoBulto = 0;
                                        objE_DocumentoBulto.IdEmpresa = pItem.IdEmpresa;
                                        objE_DocumentoBulto.Periodo = pItem.Periodo;
                                        objE_DocumentoBulto.IdTipoDocumento = Parametros.intTipoDocGuiaRemision;
                                        objE_DocumentoBulto.Numero = pItem.Numero;
                                        objE_DocumentoBulto.IdBulto = lstBultos[i].IdBulto;
                                        objE_DocumentoBulto.FlagEstado = true;
                                        objE_DocumentoBulto.Usuario = pItem.Usuario;
                                        objE_DocumentoBulto.Maquina = pItem.Maquina;

                                        DocumentoBultoDL objDL_DocumentoBulto = new DocumentoBultoDL();
                                        objDL_DocumentoBulto.Inserta(objE_DocumentoBulto);

                                        //Insertamos en el Kardex de Producto
                                        int IdKardex = 0;
                                        KardexBE objE_Kardex = new KardexBE();
                                        objE_Kardex.IdKardex = 0;
                                        objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                                        objE_Kardex.Periodo = pItem.Periodo;
                                        objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                                        objE_Kardex.IdAlmacen = Parametros.intAlmCentral;
                                        objE_Kardex.IdProducto = lstBultos[i].IdProducto;
                                        objE_Kardex.Cantidad = lstBultos[i].Cantidad;
                                        objE_Kardex.IdTipoDocumento = Parametros.intTipoDocTransferencia;
                                        objE_Kardex.NumeroDocumento = "000000";
                                        objE_Kardex.Observacion = "Transferencia de almacén";
                                        objE_Kardex.TipoMovimiento = "I";
                                        objE_Kardex.MontoUnitarioCompra = lstBultos[i].PrecioUnitario;
                                        objE_Kardex.PrecioCostoPromedio = lstBultos[i].PrecioUnitario;
                                        objE_Kardex.MontoTotalCompra = lstBultos[i].CostoUnitario;
                                        objE_Kardex.FlagEstado = true;
                                        objE_Kardex.Usuario = pItem.Usuario;
                                        objE_Kardex.Maquina = pItem.Maquina;

                                        KardexBE objE_KardexValorizadoProducto = new KardexBE();
                                        objE_KardexValorizadoProducto = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);

                                        if (objE_KardexValorizadoProducto != null)
                                        {
                                            decimal dmlPCP = 0;
                                            decimal dmlCostoTotal = 0;

                                            if (objE_KardexValorizadoProducto.Saldo != 0)
                                            {
                                                //Calcula Precio Costo Promedio
                                                dmlPCP = dmlPCP = ((objE_KardexValorizadoProducto.Saldo * objE_KardexValorizadoProducto.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizadoProducto.Saldo + objE_Kardex.Cantidad);
                                                dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;

                                                objE_Kardex.PrecioCostoPromedio = dmlPCP;
                                                objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                                            }

                                        }
                                        else
                                        {
                                            objE_Kardex.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                                        }

                                        KardexDL objDL_Kardex = new KardexDL();
                                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                                        //Verificar el stock
                                        List<StockBE> lstStock = new List<StockBE>();
                                        StockDL objDL_Stock = new StockDL();
                                        lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);
                                        if (lstStock.Count > 0)
                                        {
                                            //Actualizamos Stock
                                            StockBE objE_Stock = new StockBE();
                                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                            objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                            objE_Stock.IdProducto = item.IdProducto;
                                            objE_Stock.ValorIncrementa = lstBultos[i].Cantidad;
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
                                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                            objE_Stock.Periodo = pItem.Periodo;
                                            objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                            objE_Stock.IdProducto = item.IdProducto;
                                            objE_Stock.Cantidad = lstBultos[i].Cantidad;
                                            objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                                            objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                                            objE_Stock.FlagEstado = true;
                                            objE_Stock.Usuario = pItem.Usuario;
                                            objE_Stock.Maquina = pItem.Maquina;

                                            objDL_Stock.Inserta(objE_Stock);
                                        }

                                        //Verifica el Stock Actual
                                        List<StockBE> lstStockActualTemp = null;
                                        lstStockActualTemp = new StockDL().ListaProducto(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);
                                        StockActual = lstStockActualTemp[0].Cantidad;
                                        i++;
                                    }
                                }
                                
                                int IdKardexProducto = 0;
                                //Insertar Kardex
                                KardexBE objE_KardexProducto = new KardexBE();
                                objE_KardexProducto.IdKardex = 0;
                                objE_KardexProducto.IdEmpresa = pItem.IdEmpresa;
                                objE_KardexProducto.Periodo = pItem.Periodo;
                                objE_KardexProducto.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                                objE_KardexProducto.IdAlmacen = Parametros.intAlmCentral;
                                objE_KardexProducto.IdProducto = item.IdProducto;
                                objE_KardexProducto.Cantidad = item.Cantidad;
                                objE_KardexProducto.IdTipoDocumento = Parametros.intTipoDocGuiaRemision;
                                objE_KardexProducto.NumeroDocumento = pItem.Numero;
                                objE_KardexProducto.Observacion = "Guia de Remisión";
                                objE_KardexProducto.TipoMovimiento = "S";
                                objE_KardexProducto.MontoUnitarioCompra = item.CostoUnitario;
                                objE_KardexProducto.PrecioCostoPromedio = 0;
                                objE_KardexProducto.MontoTotalCompra = 0;
                                objE_KardexProducto.FlagEstado = true;
                                objE_KardexProducto.Usuario = pItem.Usuario;
                                objE_KardexProducto.Maquina = pItem.Maquina;

                                KardexBE objE_KardexProductoValorizado = new KardexBE();
                                objE_KardexProductoValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);

                                if (objE_KardexProductoValorizado != null)
                                {
                                    objE_KardexProducto.PrecioCostoPromedio = objE_KardexProductoValorizado.PrecioCostoPromedio;
                                    objE_KardexProducto.MontoTotalCompra = objE_KardexProductoValorizado.PrecioCostoPromedio * item.Cantidad;
                                }

                                KardexDL objDL_KardexProducto = new KardexDL();
                                IdKardexProducto = objDL_KardexProducto.Inserta(objE_KardexProducto);

                                //Verificar el stock
                                List<StockBE> lstStockProducto = new List<StockBE>();
                                StockDL objDL_StockProducto = new StockDL();
                                lstStockProducto = objDL_StockProducto.ListaProducto(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);
                                if (lstStockProducto.Count > 0)
                                {
                                    //Actualizamos Stock
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                    objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                    objE_Stock.IdProducto = item.IdProducto;
                                    objE_Stock.ValorIncrementa = 0;
                                    objE_Stock.ValorDescuenta = item.Cantidad;
                                    objE_Stock.PrecioCostoPromedio = objE_KardexProducto.PrecioCostoPromedio;
                                    objE_Stock.CostoTotal = objE_KardexProducto.MontoTotalCompra;
                                    objE_Stock.Usuario = pItem.Usuario;
                                    objE_Stock.Maquina = pItem.Maquina;

                                    objDL_StockProducto.ActualizaCantidades(objE_Stock);
                                }
                                else
                                {
                                    //Insertamos Stock
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock.IdStock = 0;
                                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                    objE_Stock.Periodo = pItem.Periodo;
                                    objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                    objE_Stock.IdProducto = item.IdProducto;
                                    objE_Stock.Cantidad = item.Cantidad;
                                    objE_Stock.PrecioCostoPromedio = objE_KardexProducto.PrecioCostoPromedio;
                                    objE_Stock.CostoTotal = objE_KardexProducto.MontoTotalCompra;
                                    objE_Stock.FlagEstado = true;
                                    objE_Stock.Usuario = pItem.Usuario;
                                    objE_Stock.Maquina = pItem.Maquina;

                                    objDL_StockProducto.Inserta(objE_Stock);
                                }

                                //Insertar el detalle del movimiento del almacen
                                item.IdKardex = IdKardexProducto;
                                item.IdGuiaRemision = IdGuiaRemision;
                                GuiaRemisionDetalleDL objDL_GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                                objDL_GuiaRemisionDetalle.Inserta(item);
                            }
                            else
                            {
                                int IdKardex = 0;
                                //Insertar Kardex
                                KardexBE objE_Kardex = new KardexBE();
                                objE_Kardex.IdKardex = 0;
                                objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                                objE_Kardex.Periodo = pItem.Periodo;
                                objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                                objE_Kardex.IdAlmacen = Parametros.intAlmCentral;
                                objE_Kardex.IdProducto = item.IdProducto;
                                objE_Kardex.Cantidad = item.Cantidad;
                                objE_Kardex.IdTipoDocumento = Parametros.intTipoDocGuiaRemision;
                                objE_Kardex.NumeroDocumento = pItem.Numero;
                                objE_Kardex.Observacion = "Guia de Remisión";
                                objE_Kardex.TipoMovimiento = "S";
                                objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                                objE_Kardex.PrecioCostoPromedio = 0;
                                objE_Kardex.MontoTotalCompra = 0;
                                objE_Kardex.FlagEstado = true;
                                objE_Kardex.Usuario = pItem.Usuario;
                                objE_Kardex.Maquina = pItem.Maquina;

                                KardexBE objE_KardexValorizado = new KardexBE();
                                objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);

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
                                lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);
                                if (lstStock.Count > 0)
                                {
                                    //Actualizamos Stock
                                    StockBE objE_Stock = new StockBE();
                                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                    objE_Stock.IdAlmacen = Parametros.intAlmCentral;
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
                                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                    objE_Stock.Periodo = pItem.Periodo;
                                    objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                    objE_Stock.IdProducto = item.IdProducto;
                                    objE_Stock.Cantidad = item.Cantidad;
                                    objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                                    objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                                    objE_Stock.FlagEstado = true;
                                    objE_Stock.Usuario = pItem.Usuario;
                                    objE_Stock.Maquina = pItem.Maquina;

                                    objDL_Stock.Inserta(objE_Stock);
                                }

                                //Insertar el detalle del movimiento del almacen
                                item.IdKardex = IdKardex;
                                item.IdGuiaRemision = IdGuiaRemision;
                                GuiaRemisionDetalleDL objDL_GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                                objDL_GuiaRemisionDetalle.Inserta(item);
                            }
                        }
                    }

                    //Actualizamos la numeración el documento de salida del movimiento de almacen
                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(pItem.IdEmpresa, Parametros.intTipoDocGuiaRemision, pItem.Periodo);
                    
                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(GuiaRemisionBE pItem, List<GuiaRemisionDetalleBE> pListaMovimientoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (var item in pListaMovimientoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo))
                        {
                            int IdKardex = 0;
                            //Insertar Kardex
                            KardexBE objE_Kardex = new KardexBE();
                            objE_Kardex.IdKardex = 0;
                            objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            objE_Kardex.Periodo = pItem.Periodo;
                            objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            objE_Kardex.IdAlmacen = Parametros.intAlmCentral;
                            objE_Kardex.IdProducto = item.IdProducto;
                            objE_Kardex.Cantidad = item.Cantidad;
                            objE_Kardex.IdTipoDocumento = Parametros.intTipoDocGuiaRemision;
                            objE_Kardex.NumeroDocumento = pItem.Numero;
                            objE_Kardex.Observacion = "Guia de Remisión";
                            objE_Kardex.TipoMovimiento = "S";
                            objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                            objE_Kardex.PrecioCostoPromedio = 0;
                            objE_Kardex.MontoTotalCompra = 0;
                            objE_Kardex.FlagEstado = true;
                            objE_Kardex.Usuario = pItem.Usuario;
                            objE_Kardex.Maquina = pItem.Maquina;

                            KardexBE objE_KardexValorizado = new KardexBE();
                            objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);

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
                            lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);
                            if (lstStock.Count > 0)
                            {
                                //Actualizamos Stock
                                StockBE objE_Stock = new StockBE();
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
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
                                objE_Stock.IdEmpresa = pItem.IdEmpresa;
                                objE_Stock.Periodo = pItem.Periodo;
                                objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                                objE_Stock.IdProducto = item.IdProducto;
                                objE_Stock.Cantidad = item.Cantidad;
                                objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                                objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                                objE_Stock.FlagEstado = true;
                                objE_Stock.Usuario = pItem.Usuario;
                                objE_Stock.Maquina = pItem.Maquina;

                                objDL_Stock.Inserta(objE_Stock);
                            }

                            //Insertar el detalle de la guia de remision
                            item.IdKardex = IdKardex;
                            item.IdGuiaRemision = pItem.IdGuiaRemision;
                            GuiaRemisionDetalleDL objDL_GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                            objDL_GuiaRemisionDetalle.Inserta(item);

                        }
                        else
                        {
                            //Actualizar Kardex
                            KardexBE objE_Kardex = new KardexBE();
                            objE_Kardex.IdKardex = Convert.ToInt32(item.IdKardex);
                            objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                            objE_Kardex.Periodo = pItem.Periodo;
                            objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                            objE_Kardex.IdAlmacen = Parametros.intAlmCentral;
                            objE_Kardex.IdProducto = item.IdProducto;
                            objE_Kardex.Cantidad = item.Cantidad;
                            objE_Kardex.IdTipoDocumento = Parametros.intTipoDocGuiaRemision;
                            objE_Kardex.NumeroDocumento = pItem.Numero;
                            objE_Kardex.Observacion = "Guia de Remisión";
                            objE_Kardex.TipoMovimiento = "S";
                            objE_Kardex.MontoUnitarioCompra = item.CostoUnitario;
                            objE_Kardex.PrecioCostoPromedio = item.CostoUnitario;
                            objE_Kardex.MontoTotalCompra = item.CostoUnitario * item.Cantidad;
                            objE_Kardex.FlagEstado = true;
                            objE_Kardex.Usuario = pItem.Usuario;
                            objE_Kardex.Maquina = pItem.Maquina;

                            KardexBE objE_KardexValorizado = new KardexBE();
                            objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, pItem.IdTiendaRemitente, Parametros.intAlmCentral, item.IdProducto);

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
                                objE_Kardex.PrecioCostoPromedio = item.CostoUnitario; ;
                            }

                            KardexDL objDL_Kardex = new KardexDL();
                            objDL_Kardex.Actualiza(objE_Kardex);

                            //Actualizar Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = pItem.IdEmpresa;
                            objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = item.Cantidad;
                            objE_Stock.ValorDescuenta = item.CantidadAnt;
                            objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            StockDL objDL_Stock = new StockDL();
                            objDL_Stock.ActualizaCantidades(objE_Stock);

                            //Actualizar el detalle de la guia de remision
                            GuiaRemisionDetalleDL objDL_GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                            objDL_GuiaRemisionDetalle.Actualiza(item);
                        }
                    }

                    //Actualizar el movimiento del almacen
                    GuiaRemisionDL GuiaRemision = new GuiaRemisionDL();
                    GuiaRemision.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(GuiaRemisionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Eliminar el movimiento de almacen
                    GuiaRemisionDL GuiaRemision = new GuiaRemisionDL();
                    GuiaRemision.Elimina(pItem);

                    List<GuiaRemisionDetalleBE> lstMovimientoDetalleAlmacen = null;
                    lstMovimientoDetalleAlmacen = new GuiaRemisionDetalleDL().ListaTodosActivo(pItem.IdEmpresa, pItem.IdGuiaRemision);

                    foreach (var item in lstMovimientoDetalleAlmacen)
                    {
                        // Eliminar los detalle del movimiento del almacen
                        GuiaRemisionDetalleDL GuiaRemisionDetalle = new GuiaRemisionDetalleDL();
                        GuiaRemisionDetalle.Elimina(item);

                        //Eliminar el kardex
                        KardexBE objE_Kardex = new KardexBE();
                        KardexDL objDL_Kardex = new KardexDL();

                        objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                        objE_Kardex.IdKardex = Convert.ToInt32(item.IdKardex);
                        objE_Kardex.Usuario = item.Usuario;
                        objE_Kardex.Maquina = item.Maquina;
                        objDL_Kardex.Elimina(objE_Kardex);

                        //Actualizar Stock
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.IdAlmacen = Parametros.intAlmCentral;
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

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
