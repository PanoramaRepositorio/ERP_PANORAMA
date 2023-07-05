using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CambioBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<CambioBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes, int pIdTipoDocumento)
        {
            try
            {
                CambioDL Cambio = new CambioDL();
                return Cambio.ListaTodosActivo(IdEmpresa, Periodo, Mes, pIdTipoDocumento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CambioBE> ListaTodosActivoConsignacion(int IdEmpresa, int Periodo, int Mes)
        {
            try
            {
                CambioDL Cambio = new CambioDL();
                return Cambio.ListaTodosActivoConsignacion(IdEmpresa, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CambioBE> ListaTodosActivoReparacion(int IdEmpresa, int Periodo, int Mes)
        {
            try
            {
                CambioDL Cambio = new CambioDL();
                return Cambio.ListaTodosActivoReparacion(IdEmpresa, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CambioBE> Lista(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                CambioDL Cambio = new CambioDL();
                return Cambio.Lista(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CambioBE Selecciona(int IdEmpresa, int IdCambio)
        {
            try
            {
                CambioDL Cambio = new CambioDL();
                return Cambio.Selecciona(IdEmpresa, IdCambio);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CambioBE SeleccionaNotaCredito(int IdDocumentoVentaNcv)
        {
            try
            {
                CambioDL Cambio = new CambioDL();
                return Cambio.SeleccionaNotaCredito(IdDocumentoVentaNcv);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CambioBE SeleccionaNumero(int IdEmpresa, int Periodo, string Numero)
        {
            try
            {
                CambioDL Cambio = new CambioDL();
                return Cambio.SeleccionaNumero(IdEmpresa, Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CambioBE SeleccionaTipoDocumento(int IdEmpresa, int IdTipoDocumento, string Serie, string Numero)
        {
            try
            {
                CambioDL Cambio = new CambioDL();
                return Cambio.SeleccionaTipoDocumento(IdEmpresa, IdTipoDocumento, Serie, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CambioBE SeleccionaTipoDocumentoNCE(int IdEmpresa, int IdTipoDocumento, string Serie, string Numero)
        {
            try
            {
                CambioDL Cambio = new CambioDL();
                return Cambio.SeleccionaTipoDocumentoNCE(IdEmpresa, IdTipoDocumento, Serie, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CambioBE pItem, List<CambioDetalleBE> pListaCambioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CambioDL Cambio = new CambioDL();
                    CambioDetalleDL CambioDetalle = new CambioDetalleDL();
                    DocumentoVentaDL DocumentoVenta = new DocumentoVentaDL();

                    int IdCambio = 0;
                    IdCambio = Cambio.Inserta(pItem);

                    foreach (CambioDetalleBE item in pListaCambioDetalle)
                    {
                        //Insertamos el detalle del cambio
                        item.IdCambio = IdCambio;
                        CambioDetalle.Inserta(item);
                    }

                    NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intIdPanoramaDistribuidores, pItem.IdTipoDocumento, pItem.Periodo);

                    //DocumentoVenta.ActualizaSituacion(pItem.IdEmpresa, pItem.IdDocumentoVenta, Parametros.intDVAnulado);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CambioBE pItem, List<CambioDetalleBE> pListaCambioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CambioDL Cambio = new CambioDL();
                    CambioDetalleDL CambioDetalle = new CambioDetalleDL();

                    foreach (CambioDetalleBE item in pListaCambioDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdCambio = pItem.IdCambio;
                            CambioDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            CambioDetalle.Actualiza(item);
                        }
                    }

                    Cambio.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCliente(int IdCambio, int IdCliente, string NumeroCliente, string DescCliente)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CambioDL Cambio = new CambioDL();
                    Cambio.ActualizaCliente(IdCambio, IdCliente, NumeroCliente, DescCliente);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaRecibido(CambioBE pItem, List<CambioDetalleBE> pListaCambioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CambioDL Cambio = new CambioDL();
                    CambioDetalleDL CambioDetalle = new CambioDetalleDL();

                    foreach (CambioDetalleBE item in pListaCambioDetalle)
                    {
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

                        if (pItem.IdTipoDocumento == Parametros.intTipoDocReparacion)
                        {
                            IdAlmacen = Parametros.intAlmTaller;
                        }

                        //if (pItem.IdTienda == Parametros.intTiendaAndahuaylas)
                        //{
                        //    IdAlmacen = Parametros.intAlmTiendaAndahuaylas;
                        //}

                        /*int IdKardex = 0;
                        //Insertar Kardex
                        KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = 0;
                        objE_Kardex.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                        objE_Kardex.Periodo = pItem.Periodo;
                        objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        objE_Kardex.IdAlmacen = IdAlmacen;
                        objE_Kardex.IdProducto = item.IdProducto;
                        objE_Kardex.Cantidad = item.Cantidad;
                        objE_Kardex.IdTipoDocumento = Parametros.intTipoDocCambiosDevoluciones;
                        objE_Kardex.NumeroDocumento = pItem.Numero;
                        objE_Kardex.Observacion = "Ingreso Por Devolución de Mercadería";
                        objE_Kardex.TipoMovimiento = "I";
                        objE_Kardex.MontoUnitarioCompra = 0;
                        objE_Kardex.PrecioCostoPromedio = 0;
                        objE_Kardex.MontoTotalCompra = 0;
                        objE_Kardex.FlagEstado = true;
                        objE_Kardex.Usuario = pItem.Usuario;
                        objE_Kardex.Maquina = pItem.Maquina;

                        KardexBE objE_KardexValorizado = new KardexBE();
                        objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intPanoraramaDistribuidores, pItem.IdTienda, IdAlmacen, item.IdProducto);

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
                            objE_Kardex.PrecioCostoPromedio = 0;
                        }

                        KardexDL objDL_Kardex = new KardexDL();
                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);*/

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(Parametros.intPanoraramaDistribuidores, pItem.IdTienda, IdAlmacen, item.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                            objE_Stock.IdAlmacen = IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.ValorIncrementa = item.Cantidad;
                            objE_Stock.ValorDescuenta = 0;
                            objE_Stock.PrecioCostoPromedio = 0;
                            objE_Stock.CostoTotal = 0;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;
                            objDL_Stock.ActualizaCantidades(objE_Stock);
                        }
                        else
                        {
                            //Insertamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdStock = 0;
                            objE_Stock.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = 0;
                            objE_Stock.CostoTotal = 0;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }
                    }

                    Cambio.ActualizaRecibido(pItem.IdEmpresa, pItem.IdCambio, true, pItem.IdPersonaRecibido);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void AnulaRecibido(CambioBE pItem, List<CambioDetalleBE> pListaCambioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CambioDL Cambio = new CambioDL();
                    CambioDetalleDL CambioDetalle = new CambioDetalleDL();

                    foreach (CambioDetalleBE item in pListaCambioDetalle)
                    {
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

                        int IdKardex = 0;
                        //Insertar Kardex
                        KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = 0;
                        objE_Kardex.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                        objE_Kardex.Periodo = pItem.Periodo;
                        objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        objE_Kardex.IdAlmacen = IdAlmacen;
                        objE_Kardex.IdProducto = item.IdProducto;
                        objE_Kardex.Cantidad = item.Cantidad;
                        objE_Kardex.IdTipoDocumento = Parametros.intTipoDocCambiosDevoluciones;
                        objE_Kardex.NumeroDocumento = pItem.Numero;
                        objE_Kardex.Observacion = "Salida Por Anulación de Devolución de Mercadería";
                        objE_Kardex.TipoMovimiento = "S";
                        objE_Kardex.MontoUnitarioCompra = 0;
                        objE_Kardex.PrecioCostoPromedio = 0;
                        objE_Kardex.MontoTotalCompra = 0;
                        objE_Kardex.FlagEstado = true;
                        objE_Kardex.Usuario = pItem.Usuario;
                        objE_Kardex.Maquina = pItem.Maquina;

                        KardexBE objE_KardexValorizado = new KardexBE();
                        objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intPanoraramaDistribuidores, pItem.IdTienda, IdAlmacen, item.IdProducto);

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
                            objE_Kardex.PrecioCostoPromedio = 0;
                        }

                        KardexDL objDL_Kardex = new KardexDL();
                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(Parametros.intPanoraramaDistribuidores, pItem.IdTienda, IdAlmacen, item.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = Parametros.intPanoraramaDistribuidores;
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
                            objE_Stock.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }
                    }

                    Cambio.ActualizaRecibido(pItem.IdEmpresa, pItem.IdCambio, false, pItem.IdPersonaRecibido);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdEmpresa, int IdCambio, bool FlagRecibido, int IdPersonaRecibido)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CambioDL Cambio = new CambioDL();
                    Cambio.ActualizaRecibido(IdEmpresa, IdCambio, FlagRecibido, IdPersonaRecibido);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaAprobado(int IdEmpresa, int IdCambio, bool FlagAprobado, int IdPersonaAprobado)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CambioDL Cambio = new CambioDL();
                    Cambio.ActualizaAprobado(IdEmpresa, IdCambio, FlagAprobado, IdPersonaAprobado);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CambioBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CambioDL Cambio = new CambioDL();
                    CambioDetalleDL CambioDetalle = new CambioDetalleDL();

                    List<CambioDetalleBE> lstCambioDetalle = null;
                    lstCambioDetalle = CambioDetalle.ListaTodosActivo(pItem.IdCambio);

                    foreach (CambioDetalleBE item in lstCambioDetalle)
                    {
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

                        int IdKardex = 0;
                        //Insertar Kardex
                        KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = 0;
                        objE_Kardex.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                        objE_Kardex.Periodo = pItem.Periodo;
                        objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        objE_Kardex.IdAlmacen = IdAlmacen;
                        objE_Kardex.IdProducto = item.IdProducto;
                        objE_Kardex.Cantidad = item.Cantidad;
                        objE_Kardex.IdTipoDocumento = Parametros.intTipoDocCambiosDevoluciones;
                        objE_Kardex.NumeroDocumento = pItem.Numero;
                        objE_Kardex.Observacion = "Salida Por Anulación de Devolución de Mercadería";
                        objE_Kardex.TipoMovimiento = "S";
                        objE_Kardex.MontoUnitarioCompra = 0;
                        objE_Kardex.PrecioCostoPromedio = 0;
                        objE_Kardex.MontoTotalCompra = 0;
                        objE_Kardex.FlagEstado = true;
                        objE_Kardex.Usuario = pItem.Usuario;
                        objE_Kardex.Maquina = pItem.Maquina;

                        KardexBE objE_KardexValorizado = new KardexBE();
                        objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(Parametros.intPanoraramaDistribuidores, pItem.IdTienda, IdAlmacen, item.IdProducto);

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
                            objE_Kardex.PrecioCostoPromedio = 0;
                        }

                        KardexDL objDL_Kardex = new KardexDL();
                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        //Verificar el stock
                        List<StockBE> lstStock = new List<StockBE>();
                        StockDL objDL_Stock = new StockDL();
                        lstStock = objDL_Stock.ListaProducto(Parametros.intPanoraramaDistribuidores, pItem.IdTienda, IdAlmacen, item.IdProducto);
                        if (lstStock.Count > 0)
                        {
                            //Actualizamos Stock
                            StockBE objE_Stock = new StockBE();
                            objE_Stock.IdEmpresa = Parametros.intPanoraramaDistribuidores;
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
                            objE_Stock.IdEmpresa = Parametros.intPanoraramaDistribuidores;
                            objE_Stock.Periodo = pItem.Periodo;
                            objE_Stock.IdAlmacen = IdAlmacen;
                            objE_Stock.IdProducto = item.IdProducto;
                            objE_Stock.Cantidad = item.Cantidad;
                            objE_Stock.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                            objE_Stock.CostoTotal = objE_Kardex.MontoTotalCompra;
                            objE_Stock.FlagEstado = true;
                            objE_Stock.Usuario = pItem.Usuario;
                            objE_Stock.Maquina = pItem.Maquina;

                            objDL_Stock.Inserta(objE_Stock);
                        }

                        CambioDetalle.Elimina(item);
                    }

                    //Eliminamos la solicitud de devolucion
                    Cambio.Elimina(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
