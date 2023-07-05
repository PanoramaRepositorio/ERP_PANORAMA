using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class SunatConsultaTicketBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<SunatConsultaTicketBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				SunatConsultaTicketDL SunatConsultaTicket = new SunatConsultaTicketDL();
				return SunatConsultaTicket.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<SunatConsultaTicketBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                SunatConsultaTicketDL SunatConsultaTicket = new SunatConsultaTicketDL();
                return SunatConsultaTicket.ListaFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SunatConsultaTicketBE> ListaPendiente(int IdEmpresa)
        {
            try
            {
                SunatConsultaTicketDL SunatConsultaTicket = new SunatConsultaTicketDL();
                return SunatConsultaTicket.ListaPendiente(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SunatConsultaTicketBE Selecciona(int IdSunatConsultaTicket)
		{
			try
			{
				SunatConsultaTicketDL SunatConsultaTicket = new SunatConsultaTicketDL();
				return SunatConsultaTicket.Selecciona(IdSunatConsultaTicket);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(SunatConsultaTicketBE pItem)
		{
			try
			{
				SunatConsultaTicketDL SunatConsultaTicket = new SunatConsultaTicketDL();
				SunatConsultaTicket.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(SunatConsultaTicketBE pItem)
		{
			try
			{
				SunatConsultaTicketDL SunatConsultaTicket = new SunatConsultaTicketDL();
				SunatConsultaTicket.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public void ActualizaMensaje(int IdSunatConsultaTicket, string MensajeTicket)
        {
            try
            {
                SunatConsultaTicketDL SunatConsultaTicket = new SunatConsultaTicketDL();
                SunatConsultaTicket.ActualizaMensaje(IdSunatConsultaTicket, MensajeTicket);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SunatConsultaTicketBE pItem)
		{
			try
			{
				SunatConsultaTicketDL SunatConsultaTicket = new SunatConsultaTicketDL();
				SunatConsultaTicket.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
