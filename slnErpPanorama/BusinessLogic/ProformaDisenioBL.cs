using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ProformaDisenioBL
    {
         public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<ProformaDisenioBE> ListaTodosActivo(DateTime pFechaInicio, DateTime pFechaFin)
        {
            try
            {
                ProformaDisenioDL DocumentoVenta = new ProformaDisenioDL();
                return DocumentoVenta.ListaTodosActivo(pFechaInicio, pFechaFin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ProformaDisenioBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ProformaDisenioDL ProformaDisenio = new ProformaDisenioDL();
                return ProformaDisenio.ListaFecha(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }



        public List<ProformaDisenioBE> BuscarSolicitud(string pNumero)
        {
            try
            {
                ProformaDisenioDL DocumentoVenta = new ProformaDisenioDL();
                return DocumentoVenta.BuscarSolicitud(pNumero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProformaDisenioBE Buscar_SolicitudEgreso(int IdSolicitud)
        {
            try
            {
                ProformaDisenioDL PrestamoBanco = new ProformaDisenioDL();
                return PrestamoBanco.Buscar_SolicitudEgreso(IdSolicitud);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProformaDisenioBE TotalPagosPendientes(DateTime pFechaInicio, DateTime pFechaFin)
        {
            try
            {
                ProformaDisenioDL PrestamoBanco = new ProformaDisenioDL();
                return PrestamoBanco.TotalPendientePago(pFechaInicio, pFechaFin);
            }
            catch (Exception ex)
            { throw ex; }
        }

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
        public void Elimina(ProformaDisenioBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProformaDisenioDL SolicitudEgreso = new ProformaDisenioDL();

                    //List<SolicitudEgresoDetalleBE> ListaSolicitudDetalle = null;
                    //ListaSolicitudDetalle = new SolicitudEgresoDetalleDL().ListaTodosActivo(pItem.IdSolicitudEgreso);

                    //foreach (SolicitudEgresoDetalleBE item in ListaSolicitudDetalle)
                    //{
                    //    SolicitudEgresoDetalle.Elimina(item);
                    //}

                    SolicitudEgreso.EliminaDetalle(pItem);

                    ts.Complete();
                }


            }
            catch (Exception ex)
            { throw ex; }
        }

        public void AnularSolicitud(ProformaDisenioBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProformaDisenioDL SolicitudEgreso = new ProformaDisenioDL();
                    SolicitudEgreso.AnulaSolicitud(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(ProformaDisenioBE pItem, List<ProformaDisenioDetalleBE> pListaProformaDisenioDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProformaDisenioDL Proformadisenio = new ProformaDisenioDL();
                    ProformaDisenioDetalleDL IdProformadisenioDetalle = new ProformaDisenioDetalleDL();

                    string sNumero = "";

                    //Obtenemos el correlativo
                    List<ProformaDisenioBE> mListaNumero = new List<ProformaDisenioBE>();
                    mListaNumero = new ProformaDisenioBL().ObtenerCorrelativoPeriodo(0);  
                    if (mListaNumero.Count > 0)
                    {
                        sNumero = AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 8);
                    }
                    pItem.NumProformaDisenio = sNumero;

                    //Insertar en la Solicitud egreso
                    int IdProformadisenio = 0;
                    IdProformadisenio = Proformadisenio.Inserta(pItem);
                    foreach (ProformaDisenioDetalleBE item in pListaProformaDisenioDetalle)
                    {
                        //Insertamos el detalle de la solicitud
                        item.IdProformaDisenio = IdProformadisenio;
                        IdProformadisenioDetalle.Inserta(item);
                    }
                    ts.Complete();        
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Actualiza(ProformaDisenioBE pItem, List<ProformaDisenioDetalleBE> pListaPrestamoBancoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProformaDisenioDL SolicitudEgreso = new ProformaDisenioDL();
                    ProformaDisenioDetalleDL SolicitudEgresoDetalle = new ProformaDisenioDetalleDL();

                    foreach (ProformaDisenioDetalleBE item in pListaPrestamoBancoDetalle)
                    {
                        //if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        //{
                        //  //  Insertamos el detalle de la solicitud egreso
                        //    //item.IdSolicitudEgreso = pItem.IdSolicitudEgreso;

                        //    SolicitudEgresoDetalle.Inserta(item);
                        //}
                        //else
                        //{
                        //    SolicitudEgresoDetalle.Actualiza_E(item);
                        //}
                    }

                    //Actualizamos
                    SolicitudEgreso.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaPagos(ProformaDisenioBE pItem, List<ProformaDisenioDetalleBE> pListaPrestamoBancoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ProformaDisenioDL SolicitudEgreso = new ProformaDisenioDL();
                    ProformaDisenioDetalleDL SolicitudEgresoDetalle = new ProformaDisenioDetalleDL();

                    foreach (ProformaDisenioDetalleBE item in pListaPrestamoBancoDetalle)
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

 

        public List<ProformaDisenioBE> ObtenerCorrelativoPeriodo(int Periodo)
        {
            try
            {
                ProformaDisenioDL NumeracionDocumento = new ProformaDisenioDL();
                return NumeracionDocumento.ObtenerCorrelativoPeriodo(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
