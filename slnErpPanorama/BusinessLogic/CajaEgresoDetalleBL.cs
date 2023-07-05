using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
  
    public class CajaEgresoDetalleBL
    {
        public List<CajaEgresoDetalleBE> ListaTodosActivo(int IdCajaEgreso)
        {
            try
            {
                CajaEgresoDetalleDL CajaEgresoDetalle = new CajaEgresoDetalleDL();
                return CajaEgresoDetalle.ListaTodosActivo(IdCajaEgreso);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(CajaEgresoDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CajaEgresoDetalleDL SolicitudEgreso = new CajaEgresoDetalleDL();
                    CajaEgresoDetalleDL SolicitudEgresoDetalle = new CajaEgresoDetalleDL();

                    string sNumero = "";

                    //Obtenemos el correlativo
                    List<CajaEgresoDetalleBE> mListaNumero = new List<CajaEgresoDetalleBE>();
                    mListaNumero = new CajaEgresoDetalleBL().ObtenerCorrelativoPeriodo(pItem.IdEmpresa, pItem.TipoOperacion);
                    if (mListaNumero.Count > 0)
                    {
                        sNumero = AgregarCaracter((mListaNumero[0].Numero + 1).ToString(), "0", 6);
                    }
                    pItem.NumRecibo = sNumero;

                    //Insertar en la Solicitud egreso
                    int IdCajaEgresoDetalle2 = 0;
                    IdCajaEgresoDetalle2 = SolicitudEgreso.Inserta(pItem);

                    //foreach (SolicitudEgresoDetalleBE item in pListaSolicitudEgresoDetalle)
                    //{
                    //    //Insertamos el detalle de la solicitud
                    //    item.IdSolicitudEgreso = IdSolicitudEgreso;
                    //    SolicitudEgresoDetalle.Inserta(item);
                    //}
 
                    ts.Complete();
                   return IdCajaEgresoDetalle2;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta_DocsEgresos(CajaEgresoDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CajaEgresoDetalleDL SolicitudEgreso = new CajaEgresoDetalleDL();
                    CajaEgresoDetalleDL SolicitudEgresoDetalle = new CajaEgresoDetalleDL();

                    //Insertar en la Solicitud egreso
                    //int IdCajaEgresoDetalle2 = 0;
                    //IdCajaEgresoDetalle2 = 
                     SolicitudEgreso.Inserta_DocsEgresos(pItem);

                    ts.Complete();
                    //return IdCajaEgresoDetalle2;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaEgresoDetalleBE> ObtenerCorrelativoPeriodo(int pIdEmpresa, int pTipoOperacion)
        {
            try
            {
                CajaEgresoDetalleDL Correlativo = new CajaEgresoDetalleDL();
                return Correlativo.ObtenerCorrelativoPeriodo(pIdEmpresa, pTipoOperacion);
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

        public void Actualiza(CajaEgresoDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CajaEgresoDetalleDL CajaEgresoDetalle = new CajaEgresoDetalleDL();

                    //Actualizamos
                    CajaEgresoDetalle.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaRevisa(CajaEgresoDetalleBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CajaEgresoDetalleDL CajaEgresoDetalle = new CajaEgresoDetalleDL();

                    //Actualizamos
                    CajaEgresoDetalle.ActualizaRevisa(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaEgresoDetalleBE> ListadoPrint(int IdCajaEgresoDetalle)
        {
            try
            {
                CajaEgresoDetalleDL reporte = new CajaEgresoDetalleDL();
                return reporte.ListadoPrint(IdCajaEgresoDetalle);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaEgresoDetalleBE> BuscanumEgreso(string pNumEgreso, int pIdCajaEgreso)
        {
            try
            {
                CajaEgresoDetalleDL reporte = new CajaEgresoDetalleDL();
                return reporte.BuscaNumEgreso(pNumEgreso, pIdCajaEgreso);
            }
            catch (Exception ex)
            { throw ex; }
        }




        public List<CajaEgresoBE> ListaTodosActivo(DateTime pFechaDesde, DateTime pFechaHasta, int pIdEmpresa)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                return CajaCierre.ListaTodosActivo(pFechaDesde, pFechaHasta, pIdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaEgresoBE> ListaFechaCaja(DateTime FechaDesde, DateTime FechaHasta, int IdCaja)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                return CajaCierre.ListaFechaCaja(FechaDesde, FechaHasta, IdCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CajaEgresoBE pItem)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                CajaCierre.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CajaEgresoBE pItem)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                CajaCierre.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CajaEgresoBE pItem)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                CajaCierre.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void EliminaFecha(CajaEgresoBE pItem)
        {
            try
            {
                CajaEgresoDL CajaCierre = new CajaEgresoDL();
                CajaCierre.EliminaFecha(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CajaEgresoDetalleBE> ListaTodosEgresos(int pIdCajaEgreso, int pIdCajaEgresoDetalle)
        {
            try
            {
                CajaEgresoDetalleDL CajaCierre = new CajaEgresoDetalleDL();
                return CajaCierre.ListaTodosEgresos(pIdCajaEgreso, pIdCajaEgresoDetalle);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaListaEgresos(List<CajaEgresoDetalleBE> pListaCajaEgresoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CajaEgresoDetalleDL CajaEgresoDetalle = new CajaEgresoDetalleDL();
                    foreach (CajaEgresoDetalleBE item in pListaCajaEgresoDetalle)
                    {
                        //Insertamos egresos
                        CajaEgresoDetalle.Inserta_DocsEgresos(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
