using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class TicketBL
    {
        public List<TicketBE> ListaTodosActivo()
        {
            try
            {
                TicketDL Ticket = new TicketDL();
                return Ticket.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TicketBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                TicketDL Ticket = new TicketDL();
                return Ticket.ListaFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TicketBE> ListaNumero(int Periodo, string Numero)
        {
            try
            {
                TicketDL Ticket = new TicketDL();
                return Ticket.ListaNumero(Periodo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TicketBE Selecciona(int IdTicket)
        {
            try
            {
                TicketDL Ticket = new TicketDL();
                return Ticket.Selecciona(IdTicket);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TicketBE pItem)
        {
            try
            {
                TicketDL Ticket = new TicketDL();
                Ticket.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TicketBE pItem)
        {
            try
            {
                TicketDL Ticket = new TicketDL();
                Ticket.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TicketBE pItem)
        {
            try
            {
                TicketDL Ticket = new TicketDL();
                Ticket.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
