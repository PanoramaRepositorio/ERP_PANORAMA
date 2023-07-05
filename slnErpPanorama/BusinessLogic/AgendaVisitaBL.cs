using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AgendaVisitaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }

        public List<AgendaVisitaBE> ListaTodosActivo(int pIdPersona)
        {
            try
            {
                AgendaVisitaDL DocumentoVenta = new AgendaVisitaDL();
                return DocumentoVenta.ListaTodosActivo(pIdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AgendaVisitaBE> ListaFechaVisitas(int pIdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AgendaVisitaDL SolicitudEgreso = new AgendaVisitaDL();
                return SolicitudEgreso.ListaFechaVisitas(pIdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AgendaVisitaBE> ListaFechaVisitasProgramadas(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AgendaVisitaDL SolicitudEgreso = new AgendaVisitaDL();
                return SolicitudEgreso.ListaFechaVisitasProgramadas(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AgendaVisitaBE> ListaVisitasTodas(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AgendaVisitaDL SolicitudEgreso = new AgendaVisitaDL();
                return SolicitudEgreso.ListaVisitasTodas(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AgendaVisitaBE> ListaFechaVisitasValidarFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AgendaVisitaDL SolicitudEgreso = new AgendaVisitaDL();
                return SolicitudEgreso.ListaFechaVisitasValidarFecha(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        // 170323 ->
        public List<AgendaVisitaBE> ListaVisitasPendientes(int IdPersona)
        {
            try
            {
                AgendaVisitaDL SolicitudEgreso = new AgendaVisitaDL();
                return SolicitudEgreso.ListaVisitasPendientes(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AgendaVisitaBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AgendaVisitaDL SolicitudEgreso = new AgendaVisitaDL();
                return SolicitudEgreso.ListaFecha(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }



        public List<AgendaVisitaBE> BuscarSolicitud(string pNumero)
        {
            try
            {
                AgendaVisitaDL DocumentoVenta = new AgendaVisitaDL();
                return DocumentoVenta.BuscarSolicitud(pNumero);
            }
            catch (Exception ex)
            { throw ex; }
        }

 

        public AgendaVisitaBE BuscarVisita(int IdVisita)
        {
            try
            {
                AgendaVisitaDL AgendaVisita = new AgendaVisitaDL();
                return AgendaVisita.BuscarVisita(IdVisita);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AgendaVisitaBE BuscarNumVisita(String NumVisita)
        {
            try
            {
                AgendaVisitaDL AgendaVisita = new AgendaVisitaDL();
                return AgendaVisita.BuscarNumVisita(NumVisita);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AgendaVisitaBE BuscarNumVisitaAsociada(String NumVisita)
        {
            try
            {
                AgendaVisitaDL AgendaVisita = new AgendaVisitaDL();
                return AgendaVisita.BuscarNumVisitaAsociada(NumVisita);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AgendaVisitaBE TotalPagosPendientes(DateTime pFechaInicio, DateTime pFechaFin)
        {
            try
            {
                AgendaVisitaDL PrestamoBanco = new AgendaVisitaDL();
                return PrestamoBanco.TotalPendientePago(pFechaInicio, pFechaFin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AgendaVisitaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AgendaVisitaDL SolicitudEgreso = new AgendaVisitaDL();
                    SolicitudEgreso.EliminaDetalle(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void AnularSolicitud(AgendaVisitaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AgendaVisitaDL SolicitudEgreso = new AgendaVisitaDL();
                    SolicitudEgreso.AnulaSolicitud(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AgendaVisitaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AgendaVisitaDL SolicitudEgreso = new AgendaVisitaDL();

                    string sNumero = "";

                    //Obtenemos el correlativo
                    List<AgendaVisitaBE> mListaNumero = new List<AgendaVisitaBE>();
                    mListaNumero = new AgendaVisitaBL().ObtenerCorrelativoPeriodo(0);
                    if (mListaNumero.Count > 0)
                    {
                        sNumero = AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 8);
                    }
                    pItem.NumAgendaVisita = sNumero;

                    //Insertar en la Solicitud egreso
                    int IdAgendaVisita = 0;
                    IdAgendaVisita = SolicitudEgreso.Inserta(pItem);

                    //foreach (AgendaVisitaDetalleBE item in pListaSolicitudEgresoDetalle)
                    //{
                    //    //Insertamos el detalle de la solicitud
                    //    item.IdSolicitudEgreso = IdSolicitudEgreso;
                    //    SolicitudEgresoDetalle.Inserta(item);
                    //}
                    ts.Complete();

                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AgendaVisitaBE pItem, List<AgendaVisitaDetalleBE> pListaPrestamoBancoDetalle)
        {
            //try
            //{
            //    using (TransactionScope ts = new TransactionScope())
            //    {
            //        AgendaVisitaDL SolicitudEgreso = new AgendaVisitaDL();
            //        AgendaVisitaDetalleDL SolicitudEgresoDetalle = new AgendaVisitaDetalleDL();

            //        foreach (AgendaVisitaDetalleBE item in pListaPrestamoBancoDetalle)
            //        {
            //            if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
            //            {
            //                //  Insertamos el detalle de la solicitud egreso
            //                item.IdSolicitudEgreso = pItem.IdSolicitudEgreso;

            //                SolicitudEgresoDetalle.Inserta(item);
            //            }
            //            else
            //            {
            //                SolicitudEgresoDetalle.Actualiza_E(item);
            //            }
            //        }

            //        //Actualizamos
            //        SolicitudEgreso.Actualiza(pItem);

            //        ts.Complete();
            //    }
            //}
            //catch (Exception ex)
            //{ throw ex; }
        }

        public void ReprogramaVisita(AgendaVisitaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AgendaVisitaDL Visita = new AgendaVisitaDL();
                    AgendaVisitaDetalleDL SolicitudEgresoDetalle = new AgendaVisitaDetalleDL();

                    //Actualizamos
                    Visita.ReprogramaVisita(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void CerrarVisita(AgendaVisitaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AgendaVisitaDL Visita = new AgendaVisitaDL();
                    AgendaVisitaDetalleDL SolicitudEgresoDetalle = new AgendaVisitaDetalleDL();

                    //Actualizamos
                    Visita.CerrarVisita(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void CancelaVisita(AgendaVisitaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AgendaVisitaDL Visita = new AgendaVisitaDL();
                    AgendaVisitaDetalleDL SolicitudEgresoDetalle = new AgendaVisitaDetalleDL();

                    //Actualizamos
                    Visita.CancelaVisita(pItem);

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



        public List<AgendaVisitaBE> ObtenerCorrelativoPeriodo(int Periodo)
        {
            try
            {
                AgendaVisitaDL NumeracionDocumento = new AgendaVisitaDL();
                return NumeracionDocumento.ObtenerCorrelativoPeriodo(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
