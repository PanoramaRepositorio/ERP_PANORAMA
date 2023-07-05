using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class MuestraBL
    {
        public List<MuestraBE> ListaTodosActivo(DateTime Fecha)
        {
            try
            {
                MuestraDL Muestra = new MuestraDL();
                return Muestra.ListaTodosActivo(Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MuestraBE Selecciona(int IdMuestra)
        {
            try
            {
                MuestraDL Muestra = new MuestraDL();
                MuestraBE objEmp = Muestra.Selecciona(IdMuestra);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(MuestraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    MuestraDL Muestra = new MuestraDL();
                    Muestra.Inserta(pItem);

                    ////Insertar Kardex
                    //KardexBE objE_Kardex = new KardexBE();
                    //objE_Kardex.IdKardex = 0;
                    //objE_Kardex.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                    //objE_Kardex.Periodo = Parametros.intPeriodo;
                    //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                    //objE_Kardex.IdAlmacen = Parametros.intAlmTiendaUcayali;
                    //objE_Kardex.IdProducto = pItem.IdProducto;
                    //objE_Kardex.Cantidad = pItem.Cantidad;
                    //objE_Kardex.IdTipoDocumento = Parametros.intTipoDocPedidoVenta;
                    //objE_Kardex.NumeroDocumento = "00000";
                    //objE_Kardex.Observacion = "Salida Por Muestra Vendida";
                    //objE_Kardex.TipoMovimiento = "S";
                    //objE_Kardex.MontoUnitarioCompra = pItem.ValorVenta;
                    //objE_Kardex.PrecioCostoPromedio = 0;
                    //objE_Kardex.MontoTotalCompra = 0;
                    //objE_Kardex.FlagEstado = true;
                    //objE_Kardex.Usuario = pItem.Usuario;
                    //objE_Kardex.Maquina = pItem.Maquina;

                    //KardexBE objE_KardexValorizado = new KardexBE();
                    //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, Parametros.intAlmTiendaUcayali, pItem.IdProducto);

                    //if (objE_KardexValorizado != null)
                    //{
                    //    objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                    //    objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * pItem.Cantidad;
                    //}

                    //int IdKardex = 0;

                    ////KardexDL objDL_Kardex = new KardexDL();
                    ////IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                    ////Verificar el stock
                    //List<StockBE> lstStock = new List<StockBE>();
                    //StockDL objDL_Stock = new StockDL();
                    //lstStock = objDL_Stock.ListaProducto(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, Parametros.intAlmTiendaUcayali, pItem.IdProducto);
                    //if (lstStock.Count > 0)
                    //{
                    //    //Actualizamos Stock
                    //    StockBE objE_Stock = new StockBE();
                    //    objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                    //    objE_Stock.IdAlmacen = Parametros.intAlmTiendaUcayali;
                    //    objE_Stock.IdProducto = pItem.IdProducto;
                    //    objE_Stock.ValorIncrementa = 0;
                    //    objE_Stock.ValorDescuenta = pItem.Cantidad;
                    //    objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                    //    objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                    //    objE_Stock.Usuario = pItem.Usuario;
                    //    objE_Stock.Maquina = pItem.Maquina;

                    //    objDL_Stock.ActualizaCantidades(objE_Stock);
                    //}
                    //else
                    //{
                    //    //Insertamos Stock
                    //    StockBE objE_Stock = new StockBE();
                    //    objE_Stock.IdStock = 0;
                    //    objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                    //    objE_Stock.Periodo = Parametros.intPeriodo;
                    //    objE_Stock.IdAlmacen = Parametros.intAlmTiendaUcayali;
                    //    objE_Stock.IdProducto = pItem.IdProducto;
                    //    objE_Stock.Cantidad = pItem.Cantidad;
                    //    objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                    //    objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                    //    objE_Stock.FlagEstado = true;
                    //    objE_Stock.Usuario = pItem.Usuario;
                    //    objE_Stock.Maquina = pItem.Maquina;

                    //    objDL_Stock.Inserta(objE_Stock);
                    //}


                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MuestraBE pItem)
        {
            try
            {
                MuestraDL Muestra = new MuestraDL();
                Muestra.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MuestraBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                   
                    MuestraBE objE_Muestra = null;
                    objE_Muestra = new MuestraBL().Selecciona(pItem.IdMuestra);

                    if (objE_Muestra != null)
                    {
                        //Insertar Kardex
                        KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = 0;
                        objE_Kardex.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                        objE_Kardex.Periodo = Parametros.intPeriodo;
                        objE_Kardex.FechaMovimiento = Parametros.dtFechaHoraServidor;
                        objE_Kardex.IdAlmacen = Parametros.intAlmTiendaUcayali;
                        objE_Kardex.IdProducto = objE_Muestra.IdProducto;
                        objE_Kardex.Cantidad = objE_Muestra.Cantidad;
                        objE_Kardex.IdTipoDocumento = Parametros.intTipoDocPedidoVenta;
                        objE_Kardex.NumeroDocumento = "00000";
                        objE_Kardex.Observacion = "Ingreso Por Anulación de Muestra Vendida";
                        objE_Kardex.TipoMovimiento = "I";
                        objE_Kardex.MontoUnitarioCompra = objE_Muestra.ValorVenta;
                        objE_Kardex.PrecioCostoPromedio = 0;
                        objE_Kardex.MontoTotalCompra = 0;
                        objE_Kardex.FlagEstado = true;
                        objE_Kardex.Usuario = pItem.Usuario;
                        objE_Kardex.Maquina = pItem.Maquina;

                        KardexBE objE_KardexValorizado = new KardexBE();
                        objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, Parametros.intAlmTiendaUcayali, objE_Muestra.IdProducto);

                        if (objE_KardexValorizado != null)
                        {
                            objE_Kardex.PrecioCostoPromedio = objE_KardexValorizado.PrecioCostoPromedio;
                            objE_Kardex.MontoTotalCompra = objE_KardexValorizado.PrecioCostoPromedio * objE_Muestra.Cantidad;
                        }

                        int IdKardex = 0;

                        KardexDL objDL_Kardex = new KardexDL();
                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(Parametros.intIdPanoramaDistribuidores, pItem.IdTienda, Parametros.intAlmTiendaUcayali, objE_Muestra.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = Parametros.intIdPanoramaDistribuidores;
                            objE_Stock.IdAlmacen = Parametros.intAlmTiendaUcayali;
                            objE_Stock.IdProducto = objE_Muestra.IdProducto;
                            objE_Stock.ValorIncrementa = objE_Muestra.Cantidad;
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
                            objE_Stock.Periodo = Parametros.intPeriodo;
                            objE_Stock.IdAlmacen = Parametros.intAlmTiendaUcayali;
                            objE_Stock.IdProducto = objE_Muestra.IdProducto;
                            objE_Stock.Cantidad = objE_Muestra.Cantidad;
                            objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }
                    }

                    //Anulamos el registro de la muestra
                    MuestraDL Muestra = new MuestraDL();
                    Muestra.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
