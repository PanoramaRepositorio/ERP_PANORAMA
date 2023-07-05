using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class IncidenciaBL
    {
        public List<IncidenciaBE> ListaTodosActivo()
        {
            try
            {
                IncidenciaDL Incidencia = new IncidenciaDL();
                return Incidencia.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<IncidenciaBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                IncidenciaDL Incidencia = new IncidenciaDL();
                return Incidencia.ListaFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<IncidenciaBE> ListaNumero(int Periodo, string Numero)
        {
            try
            {
                IncidenciaDL Incidencia = new IncidenciaDL();
                return Incidencia.ListaNumero(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public IncidenciaBE Selecciona(int IdIncidencia)
        {
            try
            {
                IncidenciaDL Incidencia = new IncidenciaDL();
                return Incidencia.Selecciona(IdIncidencia);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(IncidenciaBE pItem)
        {
            try
            {
                IncidenciaDL Incidencia = new IncidenciaDL();
                Incidencia.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(IncidenciaBE pItem)
        {
            try
            {
                IncidenciaDL Incidencia = new IncidenciaDL();
                Incidencia.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(IncidenciaBE pItem)
        {
            try
            {
                IncidenciaDL Incidencia = new IncidenciaDL();
                Incidencia.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
