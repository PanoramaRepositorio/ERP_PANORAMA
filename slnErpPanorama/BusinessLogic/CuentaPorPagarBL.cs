using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CuentaPorPagarBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<CuentaPorPagarBE> ListaTodosActivo(DateTime pFechaInicio, DateTime pFechaFin, String pRazonSocial)
        {
            try
            {
                CuentaPorPagarDL DocumentoVenta = new CuentaPorPagarDL();
                return DocumentoVenta.ListaTodosActivo(pFechaInicio, pFechaFin, pRazonSocial);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CuentaPorPagarBE> ListaTodosActivoTodo()
        {
            try
            {
                CuentaPorPagarDL DocumentoVenta = new CuentaPorPagarDL();
                return DocumentoVenta.ListaTodosActivoTodo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        // EDGAR 260123: AGREGAR LISTA POR SITUACION
        public List<CuentaPorPagarBE> ListaPorSituacion(Int32 pIdSituacion)
        {
            try
            {
                CuentaPorPagarDL DocumentoVenta = new CuentaPorPagarDL();
                return DocumentoVenta.ListaPorSituacion(pIdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CuentaPorPagarBE> ListaPorSituacionBloque(Int32 pIdSituacion, String pIndiceBloque)
        {
            try
            {
                CuentaPorPagarDL DocumentoVenta = new CuentaPorPagarDL();
                return DocumentoVenta.ListaPorSituacionBloque(pIdSituacion, pIndiceBloque);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CuentaPorPagarBE> ListaPorBloque(String pIndiceBloque)
        {
            try
            {
                CuentaPorPagarDL DocumentoVenta = new CuentaPorPagarDL();
                return DocumentoVenta.ListaPorBloque(pIndiceBloque);
            }
            catch (Exception ex)
            { throw ex; }
        }
        //

        public List<SolicitudEgresoBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                SolicitudEgresoDL SolicitudEgreso = new SolicitudEgresoDL();
                return SolicitudEgreso.ListaFecha(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudEgresoBE> BuscarSolicitud(string pNumero)
        {
            try
            {
                SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
                return DocumentoVenta.BuscarSolicitud(pNumero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudEgresoBE Buscar_SolicitudEgreso(int IdSolicitud)
        {
            try
            {
                SolicitudEgresoDL PrestamoBanco = new SolicitudEgresoDL();
                return PrestamoBanco.Buscar_SolicitudEgreso(IdSolicitud);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudEgresoBE TotalPagosPendientes(DateTime pFechaInicio, DateTime pFechaFin)
        {
            try
            {
                SolicitudEgresoDL PrestamoBanco = new SolicitudEgresoDL();
                return PrestamoBanco.TotalPendientePago(pFechaInicio, pFechaFin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        #region codigo comentado
        //public List<SolicitudEgresoBE> Lista(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        //{
        //    try
        //    {
        //        SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
        //        return DocumentoVenta.Lista(IdEmpresa, IdTienda, FechaDesde, FechaHasta);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<SolicitudEgresoBE> ListaGeneral(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        //{
        //    try
        //    {
        //        SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
        //        return DocumentoVenta.ListaGeneral(IdEmpresa, FechaDesde, FechaHasta);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<SolicitudEgresoBE> ListaGeneralDetalle(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        //{
        //    try
        //    {
        //        SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
        //        return DocumentoVenta.ListaGeneralDetalle(IdEmpresa, FechaDesde, FechaHasta);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<SolicitudEgresoBE> ListaVendedor(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        //{
        //    try
        //    {
        //        SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
        //        return DocumentoVenta.ListaVendedor(IdVendedor, FechaDesde, FechaHasta);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<SolicitudEgresoBE> ListaSerieNumero(int IdTipoDocumento, string Serie, string Numero)
        //{
        //    try
        //    {
        //        SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
        //        return DocumentoVenta.ListaSerieNumero(IdTipoDocumento, Serie, Numero);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<SolicitudEgresoBE> ListadoPedido(int IdPedido)
        //{
        //    try
        //    {
        //        SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
        //        return DocumentoVenta.ListadoPedido(IdPedido);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<SolicitudEgresoBE> ListadoPedidoConta(int IdPedido)
        //{
        //    try
        //    {
        //        SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
        //        return DocumentoVenta.ListadoPedidoConta(IdPedido);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<SolicitudEgresoBE> ListaDescuentoProxima(int IdCliente, int IdDocumentoVenta)
        //{
        //    try
        //    {
        //        SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
        //        return DocumentoVenta.ListaDescuentoProxima(IdCliente, IdDocumentoVenta);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<SolicitudEgresoBE> ListaMesCumpleanos(int Anio, int Mes, int IdCliente)
        //{
        //    try
        //    {
        //        SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
        //        return DocumentoVenta.ListaMesCumpleanos(Anio,Mes,IdCliente);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}

        //public List<SolicitudEgresoBE> ListaEmpresaPeriodo(int Periodo)
        //{
        //    try
        //    {
        //        SolicitudEgresoDL DocumentoVenta = new SolicitudEgresoDL();
        //        return DocumentoVenta.ListaEmpresaPeriodo(Periodo);
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        #endregion

        public void Elimina(SolicitudEgresoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudEgresoDL SolicitudEgreso = new SolicitudEgresoDL();

                    #region codigo comentado
                    //List<SolicitudEgresoDetalleBE> ListaSolicitudDetalle = null;
                    //ListaSolicitudDetalle = new SolicitudEgresoDetalleDL().ListaTodosActivo(pItem.IdSolicitudEgreso);

                    //foreach (SolicitudEgresoDetalleBE item in ListaSolicitudDetalle)
                    //{
                    //    SolicitudEgresoDetalle.Elimina(item);
                    //}
                    #endregion

                    SolicitudEgreso.EliminaDetalle(pItem);

                    ts.Complete();
                }


            }
            catch (Exception ex)
            { throw ex; }
        }

        public void AnularSolicitud(SolicitudEgresoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudEgresoDL SolicitudEgreso = new SolicitudEgresoDL();
                    SolicitudEgreso.AnulaSolicitud(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        // EDGAR 260123: AGREGAR ANULAR CUENTA POR PAGAR
        public void Anula(CuentaPorPagarBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuentaPorPagarDL SolicitudEgreso = new CuentaPorPagarDL();
                    SolicitudEgreso.Anula(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        #region codigo comentado
        //public void Inserta(SolicitudEgresoBE pItem, List<SolicitudEgresoDetalleBE> pListaSolicitudEgresoDetalle)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            SolicitudEgresoDL SolicitudEgreso = new SolicitudEgresoDL();
        //            SolicitudEgresoDetalleDL SolicitudEgresoDetalle = new SolicitudEgresoDetalleDL();

        //            string sNumero = "";

        //            //Obtenemos el correlativo
        //            List<SolicitudEgresoBE> mListaNumero = new List<SolicitudEgresoBE>();
        //            mListaNumero = new SolicitudEgresoBL().ObtenerCorrelativoPeriodo(0);  
        //            if (mListaNumero.Count > 0)
        //            {
        //                sNumero = AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 8);
        //            }
        //            pItem.NumSolicitudEgreso = sNumero;

        //            //Insertar en la Solicitud egreso
        //            int IdSolicitudEgreso = 0;
        //            IdSolicitudEgreso = SolicitudEgreso.Inserta(pItem);

        //            foreach (SolicitudEgresoDetalleBE item in pListaSolicitudEgresoDetalle)
        //            {
        //                //Insertamos el detalle de la solicitud
        //                item.IdSolicitudEgreso = IdSolicitudEgreso;
        //                SolicitudEgresoDetalle.Inserta(item);
        //            }
        //            ts.Complete();

        //        }
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        #endregion

        // EDGAR 240123: PRUEBA INSERTAR CUENTA A PAGAR -->
        public void Inserta(CuentaPorPagarBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuentaPorPagarDL CuentaPorPagar = new CuentaPorPagarDL();

                    int IdCuentaPagar = 0;
                    IdCuentaPagar = CuentaPorPagar.Inserta(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // EDGAR 250123: AGREGAR LISTADO DE DETRACCIONES CON VALOR -->
        public List<TablaElementoDetraccionBE> ListaTodosActivoDetracciones()
        {
            try
            {
                CuentaPorPagarDL CuentaPorPagar = new CuentaPorPagarDL();
                return CuentaPorPagar.ListaTodosActivoDetracciones();
            }
            catch (Exception ex)
            { throw ex; }
        }

        #region codigo comentado
        //public void Actualiza(SolicitudEgresoBE pItem, List<SolicitudEgresoDetalleBE> pListaPrestamoBancoDetalle)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            SolicitudEgresoDL SolicitudEgreso = new SolicitudEgresoDL();
        //            SolicitudEgresoDetalleDL SolicitudEgresoDetalle = new SolicitudEgresoDetalleDL();

        //            foreach (SolicitudEgresoDetalleBE item in pListaPrestamoBancoDetalle)
        //            {
        //                if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
        //                {
        //                  //  Insertamos el detalle de la solicitud egreso
        //                    item.IdSolicitudEgreso = pItem.IdSolicitudEgreso;

        //                    SolicitudEgresoDetalle.Inserta(item);
        //                }
        //                else
        //                {
        //                    SolicitudEgresoDetalle.Actualiza_E(item);
        //                }
        //            }

        //            //Actualizamos
        //            SolicitudEgreso.Actualiza(pItem);

        //            ts.Complete();
        //        }
        //    }
        //    catch (Exception ex)
        //    { throw ex; }
        //}
        #endregion

        // EDGAR 250123: AGREGAR ACTUALIZAR CUENTAS A PAGAR -->
        public void Actualiza(CuentaPorPagarBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuentaPorPagarDL CuentasPorPagar = new CuentaPorPagarDL();

                    //Actualizamos
                    CuentasPorPagar.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        // EDGAR 260123: AGREGAR CAMBIO DE SITUACION -->
        public void CambiaSituacion(CuentaPorPagarBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuentaPorPagarDL CuentasPorPagar = new CuentaPorPagarDL();

                    //string sNumero = "";

                    ////Obtenemos el correlativo
                    //List<NumeracionDocumentoBE> mListaNumero = new List<NumeracionDocumentoBE>();
                    //mListaNumero = new NumeracionDocumentoBL().ObtenerCorrelativoPeriodo(Parametros.intPanoraramaDistribuidores, 109, Parametros.intPeriodo);
                    //if (mListaNumero.Count > 0)
                    //{
                    //    sNumero = AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 7);
                    //}

                    ////Actualizamos el correlativo de la tabla principal de correlativos
                    //NumeracionDocumentoDL objDL_NumeracionDocumento = new NumeracionDocumentoDL();
                    //objDL_NumeracionDocumento.ActualizaCorrelativoPeriodo(Parametros.intPanoraramaDistribuidores, 109, Parametros.intPeriodo);

                    //Actualizamos
                    CuentasPorPagar.CambiaSituacion(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void VolveraSituacion(CuentaPorPagarBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuentaPorPagarDL CuentasPorPagar = new CuentaPorPagarDL();

                    //Actualizamos
                    CuentasPorPagar.VolverSituacion(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void VolveraSituacion2(CuentaPorPagarBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuentaPorPagarDL CuentasPorPagar = new CuentaPorPagarDL();

                    //Actualizamos
                    CuentasPorPagar.VolverSituacion2(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        // EDGAR 250123: AGREGAR BUSCAR CUENTA PARA PAGAR
        public CuentaPorPagarBE Buscar_CuentaPorPagar(int pIdCuentaPagar)
        {
            try
            {
                CuentaPorPagarDL CuentaPorPagar = new CuentaPorPagarDL();

                CuentaPorPagarBE cuenta = null;
                return cuenta = CuentaPorPagar.Buscar_CuentaPorPagar(pIdCuentaPagar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizaPagos(SolicitudEgresoBE pItem, List<SolicitudEgresoDetalleBE> pListaPrestamoBancoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudEgresoDL SolicitudEgreso = new SolicitudEgresoDL();
                    SolicitudEgresoDetalleDL SolicitudEgresoDetalle = new SolicitudEgresoDetalleDL();

                    foreach (SolicitudEgresoDetalleBE item in pListaPrestamoBancoDetalle)
                    {
                        SolicitudEgresoDetalle.Actualiza_Pagos(item);
                    }

                    //Actualizamos
                    SolicitudEgreso.Actualiza(pItem);

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

        public List<SolicitudEgresoBE> ObtenerCorrelativoPeriodo(int Periodo)
        {
            try
            {
                SolicitudEgresoDL NumeracionDocumento = new SolicitudEgresoDL();
                return NumeracionDocumento.ObtenerCorrelativoPeriodo(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CuentaPorPagarBE GetCorrelativo()
        {
            try
            {
                CuentaPorPagarDL CuentaPorPagar = new CuentaPorPagarDL();

                CuentaPorPagarBE numero = null;
                return numero = CuentaPorPagar.GetCorrelativo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String GetCuentaBN(Int32 IdProveedor)
        {
            try
            {
                CuentaPorPagarDL CuentaPorPagar = new CuentaPorPagarDL();
                return CuentaPorPagar.GetGetCuentaBN(IdProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Decimal GetTCxFechaEmision(DateTime FechaDoc, Int32 IdEmpresa)
        {
            try
            {
                CuentaPorPagarDL CuentaPorPagar = new CuentaPorPagarDL();
                return CuentaPorPagar.GetTCxFechaEmision(FechaDoc, IdEmpresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
