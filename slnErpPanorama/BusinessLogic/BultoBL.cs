using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class BultoBL
    {
        public List<BultoBE> ListaTodosActivo(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaTodosActivo(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaTodosActivoTransferenciaAnaqueles(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaTodosActivoTransferenciaAnaqueles(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaTransferenciaAnaquelesOperadorResumen(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaTransferenciaAnaquelesOperadorResumen(IdEmpresa, IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int ListaRecibidosCount(int IdEmpresa, string pFiltro)
        {
            try
            {
                BultoDL ListaBulto = new BultoDL();
                return ListaBulto.ListaRecibidosCount(IdEmpresa, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaFacturaCompra(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaFacturaCompra(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaRecibidos(int IdEmpresa, string pFiltro, int Pagina, int CantidadRegistro)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaRecibidos(IdEmpresa, pFiltro, Pagina, CantidadRegistro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaRecepcionados(int IdEmpresa, int IdProducto)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaRecepcionados(IdEmpresa, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaUbicacion(int IdEmpresa, int IdAlmacen, int IdSector, int IdBloque)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaUbicacion(IdEmpresa, IdAlmacen, IdSector, IdBloque);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaChequeo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaChequeo(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaNumeroBultoChequeo(int IdEmpresa, string NumeroBulto)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaNumeroBultoChequeo(IdEmpresa, NumeroBulto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public BultoBE SeleccionaChequeo(int IdEmpresa, int IdBulto)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.SeleccionaChequeo(IdEmpresa, IdBulto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public BultoBE Selecciona(int IdEmpresa, int IdBulto, int IdSituacion)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.Selecciona(IdEmpresa, IdBulto, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public BultoBE SeleccionaNumeroBulto(int IdEmpresa, string NumeroBulto, int IdSituacion)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.SeleccionaNumeroBulto(IdEmpresa, NumeroBulto, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaNumeroBulto(int IdEmpresa, string NumeroBulto, int IdSituacion)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaNumeroBulto(IdEmpresa, NumeroBulto, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int ListaTransferidosCount(int IdEmpresa, string pFiltro)
        {
            try
            {
                BultoDL ListaBulto = new BultoDL();
                return ListaBulto.ListaRecibidosCount(IdEmpresa, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaTransferidos(int IdEmpresa, string pFiltro)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaTransferidos(IdEmpresa, pFiltro);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<BultoBE> ListaTransferidosFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ListaTransferidosFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public BultoBE ValidaNumero(int IdEmpresa, int Periodo, int IdAlmacen, int IdSector, string NumeroBulto)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                return Bulto.ValidaNumero(IdEmpresa, Periodo, IdAlmacen, IdSector, NumeroBulto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(BultoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    int IdKardex = 0;
                    //Insertar Kardex
                    //KardexBE objE_Kardex = new KardexBE();
                    //objE_Kardex.IdKardex = 0;
                    //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                    //objE_Kardex.Periodo = pItem.Periodo;
                    //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.FechaIngreso);
                    //objE_Kardex.IdAlmacen = Parametros.intAlmBultos;
                    //objE_Kardex.IdProducto = pItem.IdProducto;
                    //objE_Kardex.Cantidad = pItem.Cantidad;
                    //objE_Kardex.IdTipoDocumento = 24; //Factura Compra
                    //objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                    //objE_Kardex.Observacion = "Ingreso por recepción de bulto de factura de compra";
                    //objE_Kardex.TipoMovimiento = "I";
                    //objE_Kardex.MontoUnitarioCompra = pItem.CostoUnitario;
                    //objE_Kardex.PrecioCostoPromedio = pItem.CostoUnitario;
                    //objE_Kardex.MontoTotalCompra = pItem.CostoUnitario;
                    //objE_Kardex.FlagEstado = true;
                    //objE_Kardex.Usuario = pItem.Usuario;
                    //objE_Kardex.Maquina = pItem.Maquina;

                    //KardexBE objE_KardexValorizado = new KardexBE();
                    //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, 1, Parametros.intAlmBultos, pItem.IdProducto);

                    //if (objE_KardexValorizado != null)
                    //{
                    //    decimal dmlPCP = 0;
                    //    decimal dmlCostoTotal = 0;

                    //    if (objE_KardexValorizado.Saldo != 0)
                    //    {
                    //        //Calcula Precio Costo Promedio
                    //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                    //        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;
                    //    }

                    //    objE_Kardex.PrecioCostoPromedio = dmlPCP;
                    //    objE_Kardex.MontoTotalCompra = dmlCostoTotal;
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
                    lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, 1, Parametros.intAlmBultos, pItem.IdProducto);
                    if (lstStock.Count > 0)
                    {
                        //Actualizamos Stock de Bultos
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.IdAlmacen = Parametros.intAlmBultos;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.ValorIncrementa = pItem.Cantidad;
                        objE_Stock.ValorDescuenta = 0;
                        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.ActualizaCantidades(objE_Stock);
                    }
                    else
                    {
                        //Insertamos Stock de Bultos
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdStock = 0;
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.Periodo = pItem.Periodo;
                        objE_Stock.IdAlmacen = Parametros.intAlmBultos;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.Cantidad = pItem.Cantidad;
                        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                        objE_Stock.FlagEstado = true;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.Inserta(objE_Stock);
                    }
                    //Insertamos la información de bultos la información de bultos
                    BultoDL Bulto = new BultoDL();
                    pItem.IdKardex = IdKardex;
                    Bulto.Inserta(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(BultoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ////Actualizar Kardex
                    //KardexBE objE_Kardex = new KardexBE();
                    //objE_Kardex.IdKardex = Convert.ToInt32(pItem.IdKardex);
                    //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                    //objE_Kardex.Periodo = pItem.Periodo;
                    //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.FechaIngreso);
                    //objE_Kardex.IdAlmacen = Parametros.intAlmBultos;
                    //objE_Kardex.IdProducto = pItem.IdProducto;
                    //objE_Kardex.Cantidad = pItem.Cantidad;
                    //objE_Kardex.IdTipoDocumento = 24; //Factura Compra
                    //objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                    //objE_Kardex.Observacion = "Ingreso por recepción de bulto de factura de compra";
                    //objE_Kardex.TipoMovimiento = "I";
                    //objE_Kardex.MontoUnitarioCompra = pItem.CostoUnitario;
                    //objE_Kardex.PrecioCostoPromedio = pItem.CostoUnitario;
                    //objE_Kardex.MontoTotalCompra = pItem.CostoUnitario;
                    //objE_Kardex.FlagEstado = true;
                    //objE_Kardex.Usuario = pItem.Usuario;
                    //objE_Kardex.Maquina = pItem.Maquina;

                    //KardexBE objE_KardexValorizado = new KardexBE();
                    //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, 1, Parametros.intAlmBultos, pItem.IdProducto);

                    //if (objE_KardexValorizado != null)
                    //{
                    //    decimal dmlPCP = 0;
                    //    decimal dmlCostoTotal = 0;

                    //    if (objE_KardexValorizado.Saldo != 0)
                    //    {
                    //        //Calcula Precio Costo Promedio
                    //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                    //        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;
                    //    }

                    //    objE_Kardex.PrecioCostoPromedio = dmlPCP;
                    //    objE_Kardex.MontoTotalCompra = dmlCostoTotal;
                    //}
                    //else
                    //{
                    //    objE_Kardex.PrecioCostoPromedio = objE_Kardex.PrecioCostoPromedio;
                    //}

                    //KardexDL objDL_Kardex = new KardexDL();
                    //objDL_Kardex.Actualiza(objE_Kardex);

                    //Verificar el stock
                    List<StockBE> lstStock = new List<StockBE>();
                    StockDL objDL_Stock = new StockDL();
                    lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, 1, Parametros.intAlmBultos, pItem.IdProducto);
                    if (lstStock.Count > 0)
                    {
                        //Actualizamos Stock de Bultos
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.ValorIncrementa = pItem.Cantidad;
                        objE_Stock.ValorDescuenta = pItem.CantidadAnt;
                        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.ActualizaCantidades(objE_Stock);
                    }
                    else
                    {
                        //Insertamos Stock de Bultos
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdStock = 0;
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.Periodo = pItem.Periodo;
                        objE_Stock.IdAlmacen = Parametros.intAlmCentral;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.Cantidad = pItem.Cantidad;
                        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                        objE_Stock.FlagEstado = true;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.Inserta(objE_Stock);
                    }

                    //Actualizamos la información de bultos
                    BultoDL Bulto = new BultoDL();
                    Bulto.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaTransito(int IdEmpresa, int IdBulto)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                Bulto.ActualizaTransito(IdEmpresa, IdBulto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizaFactura(BultoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    int IdKardex = 0;
                    //Insertar Kardex
                    //KardexBE objE_Kardex = new KardexBE();
                    //objE_Kardex.IdKardex = 0;
                    //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                    //objE_Kardex.Periodo = pItem.Periodo;
                    //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.FechaIngreso);
                    //objE_Kardex.IdAlmacen = Parametros.intAlmBultos;
                    //objE_Kardex.IdProducto = pItem.IdProducto;
                    //objE_Kardex.Cantidad = pItem.Cantidad;
                    //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                    //objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                    //objE_Kardex.Observacion = "Ingreso por recepción de bulto de factura de compra";
                    //objE_Kardex.TipoMovimiento = "I";
                    //objE_Kardex.MontoUnitarioCompra = pItem.CostoUnitario;
                    //objE_Kardex.PrecioCostoPromedio = pItem.CostoUnitario;
                    //objE_Kardex.MontoTotalCompra = pItem.CostoUnitario;
                    //objE_Kardex.FlagEstado = true;
                    //objE_Kardex.Usuario = pItem.Usuario;
                    //objE_Kardex.Maquina = pItem.Maquina;

                    //KardexBE objE_KardexValorizado = new KardexBE();
                    //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, 1, Parametros.intAlmBultos, pItem.IdProducto);

                    //if (objE_KardexValorizado != null)
                    //{
                    //    decimal dmlPCP = 0;
                    //    decimal dmlCostoTotal = 0;

                    //    if (objE_KardexValorizado.Saldo != 0)
                    //    {
                    //        //Calcula Precio Costo Promedio
                    //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                    //        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;
                    //    }

                    //    objE_Kardex.PrecioCostoPromedio = dmlPCP;
                    //    objE_Kardex.MontoTotalCompra = dmlCostoTotal;
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
                    lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, 1, Parametros.intAlmBultos, pItem.IdProducto);
                    if (lstStock.Count > 0)
                    {
                        //Actualizamos Stock de Bultos
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.IdAlmacen = Parametros.intAlmBultos;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.ValorIncrementa = pItem.Cantidad;
                        objE_Stock.ValorDescuenta = pItem.CantidadAnt;
                        objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.ActualizaCantidades(objE_Stock);
                    }
                    else
                    {
                        //Insertamos Stock de Bultos
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdStock = 0;
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.Periodo = pItem.Periodo;
                        objE_Stock.IdAlmacen = Parametros.intAlmBultos;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.Cantidad = pItem.Cantidad;
                        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                        objE_Stock.FlagEstado = true;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.Inserta(objE_Stock);
                    }

                    //Actualizamos la información de bultos
                    BultoDL Bulto = new BultoDL();
                    pItem.IdKardex = IdKardex;
                    Bulto.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(BultoBE pItem)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                Bulto.ActualizaSituacion(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaUbicacion(BultoBE pItem)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                Bulto.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaDevolucion(BultoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    int IdKardex = 0;
                    ////Insertar Kardex
                    //KardexBE objE_Kardex = new KardexBE();
                    //objE_Kardex.IdKardex = 0;
                    //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                    //objE_Kardex.Periodo = pItem.Periodo;
                    //objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.FechaIngreso);
                    //objE_Kardex.IdAlmacen = Parametros.intAlmBultos;
                    //objE_Kardex.IdProducto = pItem.IdProducto;
                    //objE_Kardex.Cantidad = pItem.Cantidad;
                    //objE_Kardex.IdTipoDocumento = pItem.IdTipoDocumento;
                    //objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                    //objE_Kardex.Observacion = "Ingreso por recepción de bulto de factura de compra";
                    //objE_Kardex.TipoMovimiento = "I";
                    //objE_Kardex.MontoUnitarioCompra = pItem.CostoUnitario;
                    //objE_Kardex.PrecioCostoPromedio = pItem.CostoUnitario;
                    //objE_Kardex.MontoTotalCompra = pItem.CostoUnitario;
                    //objE_Kardex.FlagEstado = true;
                    //objE_Kardex.Usuario = pItem.Usuario;
                    //objE_Kardex.Maquina = pItem.Maquina;

                    //KardexBE objE_KardexValorizado = new KardexBE();
                    //objE_KardexValorizado = new KardexDL().SeleccionaCalculaSaldo(pItem.IdEmpresa, 1, Parametros.intAlmBultos, pItem.IdProducto);

                    //if (objE_KardexValorizado != null)
                    //{
                    //    decimal dmlPCP = 0;
                    //    decimal dmlCostoTotal = 0;

                    //    if (objE_KardexValorizado.Saldo != 0)
                    //    {
                    //        //Calcula Precio Costo Promedio
                    //        dmlPCP = dmlPCP = ((objE_KardexValorizado.Saldo * objE_KardexValorizado.PrecioCostoPromedio) + (objE_Kardex.Cantidad * objE_Kardex.MontoUnitarioCompra)) / (objE_KardexValorizado.Saldo + objE_Kardex.Cantidad);
                    //        dmlCostoTotal = dmlPCP * objE_Kardex.Cantidad;
                    //    }

                    //    objE_Kardex.PrecioCostoPromedio = dmlPCP;
                    //    objE_Kardex.MontoTotalCompra = dmlCostoTotal;
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
                    lstStock = objDL_Stock.ListaProducto(pItem.IdEmpresa, 1, Parametros.intAlmBultos, pItem.IdProducto);
                    if (lstStock.Count > 0)
                    {
                        //Actualizamos Stock de Bultos
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.IdAlmacen = Parametros.intAlmBultos;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.ValorIncrementa = pItem.Cantidad;
                        objE_Stock.ValorDescuenta = pItem.CantidadAnt;
                        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.ActualizaCantidadesSubAlmacen(objE_Stock);
                    }
                    else
                    {
                        //Insertamos Stock de Bultos
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdStock = 0;
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.Periodo = pItem.Periodo;
                        objE_Stock.IdAlmacen = Parametros.intAlmBultos;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.Cantidad = pItem.Cantidad;
                        objE_Stock.PrecioCostoPromedio = 0; // objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                        objE_Stock.FlagEstado = true;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.Inserta(objE_Stock);
                    }

                    //Add 02 jul 2015
                    //Verificar el stock ANAQUELES
                    List<StockBE> lstStock2 = new List<StockBE>();
                    StockDL objDL_Stock2 = new StockDL();
                    lstStock2 = objDL_Stock2.ListaProducto(pItem.IdEmpresa, 1, Parametros.intAlmAnaqueles, pItem.IdProducto);
                    if (lstStock2.Count > 0)
                    {
                        //Actualizamos Stock de Bultos
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.IdAlmacen = Parametros.intAlmAnaqueles;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.ValorIncrementa = 0;//pItem.Cantidad;
                        objE_Stock.ValorDescuenta = pItem.Cantidad; //pItem.CantidadAnt;
                        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0; // objE_Kardex.MontoTotalCompra;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock2.ActualizaCantidadesSubAlmacen(objE_Stock);
                    }
                    else
                    {
                        //Insertamos Stock de Bultos
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdStock = 0;
                        objE_Stock.IdEmpresa = pItem.IdEmpresa;
                        objE_Stock.Periodo = pItem.Periodo;
                        objE_Stock.IdAlmacen = Parametros.intAlmAnaqueles;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.Cantidad = 0;//pItem.Cantidad;
                        objE_Stock.PrecioCostoPromedio = 0;// objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                        objE_Stock.FlagEstado = true;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock2.Inserta(objE_Stock);
                    }


                    //Actualizamos la información de bultos
                    BultoDL Bulto = new BultoDL();
                    pItem.IdKardex = IdKardex;
                    Bulto.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaStockAnaqueles(BultoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    BultoDL Bulto = new BultoDL();
                    ////Bulto.Actualiza(pItem);

                    int IdAlmacen = 0;
                    IdAlmacen = pItem.IdAlmacen;

                    //Verificar el stock
                    List<StockBE> lstStock = new List<StockBE>();
                    StockDL objDL_Stock = new StockDL();
                    lstStock = objDL_Stock.ListaProducto(Parametros.intEmpresaId, Parametros.intTiendaUcayali, IdAlmacen, pItem.IdProducto);
                    if (lstStock.Count > 0)
                    {
                        //Actualizamos Stock
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                        objE_Stock.IdAlmacen = IdAlmacen;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.ValorIncrementa = pItem.Cantidad;
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
                        objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                        objE_Stock.Periodo = pItem.Periodo;
                        objE_Stock.IdAlmacen = IdAlmacen;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.Cantidad = pItem.Cantidad;
                        objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                        objE_Stock.FlagEstado = true;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.Inserta(objE_Stock);
                    }

                    #region "Actualiza Stock Bulto"
                    //Verificar el stock
                    List<StockBE> lstStockBulto = new List<StockBE>();
                    StockDL objDL_StockBulto = new StockDL();
                    lstStockBulto = objDL_Stock.ListaProducto(Parametros.intEmpresaId, Parametros.intTiendaUcayali, Parametros.intAlmBultos, pItem.IdProducto);
                    if (lstStock.Count > 0)
                    {
                        //Actualizamos Stock
                        StockBE objE_Stock = new StockBE();
                        objE_Stock.IdEmpresa = Parametros.intEmpresaId;
                        objE_Stock.IdAlmacen = Parametros.intAlmBultos;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.ValorIncrementa = 0;
                        objE_Stock.ValorDescuenta = pItem.Cantidad;
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
                        objE_Stock.IdAlmacen = Parametros.intAlmBultos;
                        objE_Stock.IdProducto = pItem.IdProducto;
                        objE_Stock.Cantidad = pItem.Cantidad * -1;
                        objE_Stock.PrecioCostoPromedio = 0;//objE_Kardex.PrecioCostoPromedio;
                        objE_Stock.CostoTotal = 0;// objE_Kardex.MontoTotalCompra;
                        objE_Stock.FlagEstado = true;
                        objE_Stock.Usuario = pItem.Usuario;
                        objE_Stock.Maquina = pItem.Maquina;

                        objDL_Stock.Inserta(objE_Stock);
                    }
                    #endregion

                    //Actualizamos Cantidad en Bulto
                    Bulto.ActualizaCantidad(pItem.IdBulto, pItem.Cantidad);


                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaCantidadChequeo(BultoBE pItem)
        {
            try
            {
                BultoDL Bulto = new BultoDL();
                Bulto.ActualizaCantidadChequeo(pItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizaTransferenciaFactura(int IdEmpresa, int IdFacturaCompra, string Maquina)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    TimeSpan.FromMinutes(20);

                    List<BultoBE> mListaBulto = new List<BultoBE>();
                    mListaBulto = new BultoBL().ListaTodosActivo(Parametros.intEmpresaId, IdFacturaCompra);

                    //RECIBIR A ALMACEN DE BULTO
                    BultoBL objBL_Bulto = new BultoBL();
                    foreach (var item in mListaBulto)
                    {
                        //lblMensaje.Text = "Recepcionando bulto...";
                        BultoBE objE_Bulto = new BultoBE();
                        objE_Bulto.IdBulto = item.IdBulto;
                        objE_Bulto.IdEmpresa = item.IdEmpresa;//Parametros.intEmpresaId;
                        objE_Bulto.IdAlmacen = item.IdAlmacen;//Convert.ToInt32(cboAlmacen.EditValue);
                        objE_Bulto.IdSector = 0;//Convert.ToInt32(cboSector.EditValue);
                        objE_Bulto.IdBloque = 0; //Convert.ToInt32(cboBloque.EditValue);
                        objE_Bulto.IdProducto = item.IdProducto;
                        objE_Bulto.NumeroBulto = "ANAQ"; //txtNumeroBulto.Text;
                        objE_Bulto.Agrupacion = item.Agrupacion; //txtAgrupacion.Text;
                        objE_Bulto.IdFacturaCompra = item.IdFacturaCompra;
                        objE_Bulto.PrecioUnitario = item.PrecioUnitario;
                        objE_Bulto.Cantidad = item.Cantidad;//Convert.ToInt32(txtCantidad.EditValue);
                        objE_Bulto.CostoUnitario = item.CostoUnitario; //CostoUnitario;
                        objE_Bulto.FechaIngreso = item.FechaIngreso;// Convert.ToDateTime(deFechaIngreso.DateTime.ToShortDateString());
                        objE_Bulto.IdSituacion = Parametros.intBULRecibido;
                        objE_Bulto.Periodo = item.Periodo; //deFechaIngreso.DateTime.Year;
                        objE_Bulto.IdTipoDocumento = item.IdTipoDocumento; //IdTipoDocumento;
                        objE_Bulto.NumeroDocumento = item.NumeroDocumento; // NumeroDocumento;
                        objE_Bulto.Observacion = "Bulto Recepcionado Automático"; //txtObservacion.Text;
                        objE_Bulto.IdKardex = null;
                        objE_Bulto.FlagEstado = true;
                        objE_Bulto.Maquina = Maquina; //WindowsIdentity.GetCurrent().Name.ToString();
                        objE_Bulto.Usuario = Parametros.strUsuarioLogin;

                        objBL_Bulto.ActualizaFactura(objE_Bulto);
                    }

                    ////TRANSFERENCIA DE BULTO
                    //foreach (var item2 in mListaBulto)
                    //{
                    //    //Establecer Los Datos de Cabecera de la Transferencia del Bulto
                    //    TransferenciaBultoBE objE_TransferenciaBulto = new TransferenciaBultoBE();
                    //    objE_TransferenciaBulto.IdTransferenciaBulto = 0;
                    //    objE_TransferenciaBulto.IdEmpresa = Parametros.intEmpresaId;
                    //    objE_TransferenciaBulto.IdTienda = Parametros.intTiendaId;
                    //    objE_TransferenciaBulto.Periodo = Parametros.intPeriodo;
                    //    objE_TransferenciaBulto.IdTipoDocumento = Parametros.intTipoDocTransferencia;
                    //    objE_TransferenciaBulto.NumeroDocumento = ""; //ObtenerCorrelativo(); For Kardex Bulto;
                    //    objE_TransferenciaBulto.FechaMovimiento = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    //    objE_TransferenciaBulto.IdAlmacenOrigen = Parametros.intAlmBultos;
                    //    objE_TransferenciaBulto.IdAlmacenDestino = Parametros.intAlmAnaqueles;//.intAlmCentralUcayali;
                    //    objE_TransferenciaBulto.Observacion = "Transferencia Automática a Anaqueles";
                    //    objE_TransferenciaBulto.IdMovimientoAlmacenIngreso = 0;
                    //    objE_TransferenciaBulto.IdMovimientoAlmacenSalida = 0;
                    //    objE_TransferenciaBulto.FlagEstado = true;
                    //    objE_TransferenciaBulto.Usuario = Parametros.strUsuarioLogin;
                    //    objE_TransferenciaBulto.Maquina = Maquina; //WindowsIdentity.GetCurrent().Name.ToString();

                    //    List<TransferenciaBultoDetalleBE> lstListaTransferenciaDetalle = new List<TransferenciaBultoDetalleBE>();

                    //    //Establecer los datos del detalle de la transferencia de bultos
                    //    TransferenciaBultoDetalleBE objE_DetalleTransferencia = new TransferenciaBultoDetalleBE();
                    //    objE_DetalleTransferencia.IdTransferenciaBultoDetalle = 0;
                    //    objE_DetalleTransferencia.IdTransferenciaBulto = 0;
                    //    objE_DetalleTransferencia.IdBulto = item2.IdBulto;
                    //    objE_DetalleTransferencia.IdProducto = item2.IdProducto;
                    //    objE_DetalleTransferencia.Cantidad = item2.Cantidad;
                    //    objE_DetalleTransferencia.IdKardexBulto = 0;
                    //    objE_DetalleTransferencia.IdKardex = 0;
                    //    objE_DetalleTransferencia.FlagEstado = true;
                    //    objE_DetalleTransferencia.Abreviatura = item2.Abreviatura;
                    //    objE_DetalleTransferencia.PrecioUnitario = item2.PrecioUnitario;
                    //    objE_DetalleTransferencia.Usuario = Parametros.strUsuarioLogin;
                    //    objE_DetalleTransferencia.Maquina = Maquina; //WindowsIdentity.GetCurrent().Name.ToString();
                    //    objE_DetalleTransferencia.IdEmpresa = Parametros.intEmpresaId;
                    //    lstListaTransferenciaDetalle.Add(objE_DetalleTransferencia);

                    //    //Realizamos la transferencia de bultos
                    //    TransferenciaBultoBL objBL_TransferenciaBulto = new TransferenciaBultoBL();
                    //    objBL_TransferenciaBulto.Inserta(objE_TransferenciaBulto, lstListaTransferenciaDetalle);
                    //}

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Elimina(BultoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //Eliminar el Bulto
                    BultoDL Bulto = new BultoDL();
                    Bulto.Elimina(pItem);

                    //int IdKardex = 0;
                    ////Insertar Kardex
                    //KardexBE objE_Kardex = new KardexBE();
                    //objE_Kardex.IdKardex = 0;
                    //objE_Kardex.IdEmpresa = pItem.IdEmpresa;
                    //objE_Kardex.Periodo = Parametros.intPeriodo;
                    //objE_Kardex.FechaMovimiento = Parametros.dtFechaHoraServidor;
                    //objE_Kardex.IdAlmacen = Parametros.intAlmBultos;
                    //objE_Kardex.IdProducto = pItem.IdProducto;
                    //objE_Kardex.Cantidad = pItem.Cantidad;
                    //objE_Kardex.IdTipoDocumento = 24; //Factura Compra
                    //objE_Kardex.NumeroDocumento = pItem.NumeroDocumento;
                    //objE_Kardex.Observacion = "Salida Por Eliminación de Bulto";
                    //objE_Kardex.TipoMovimiento = "S";
                    //objE_Kardex.MontoUnitarioCompra = pItem.CostoUnitario;
                    //objE_Kardex.PrecioCostoPromedio = pItem.CostoUnitario;
                    //objE_Kardex.MontoTotalCompra = pItem.CostoUnitario;
                    //objE_Kardex.FlagEstado = true;
                    //objE_Kardex.Usuario = pItem.Usuario;
                    //objE_Kardex.Maquina = pItem.Maquina;

                    //KardexDL objDL_Kardex = new KardexDL();
                    //IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                    //Actualizamos Stock de Bultos
                    StockBE objE_Stock = new StockBE();
                    StockDL objDL_Stock = new StockDL();

                    objE_Stock.IdEmpresa = pItem.IdEmpresa;
                    objE_Stock.IdAlmacen = Parametros.intAlmBultos;
                    objE_Stock.IdProducto = pItem.IdProducto;
                    objE_Stock.ValorIncrementa = 0;
                    objE_Stock.ValorDescuenta = pItem.Cantidad;
                    objE_Stock.Usuario = pItem.Usuario;
                    objE_Stock.Maquina = pItem.Maquina;

                    objDL_Stock.ActualizaCantidades(objE_Stock);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

