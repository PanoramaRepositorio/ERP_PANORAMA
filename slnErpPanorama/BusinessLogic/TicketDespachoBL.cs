using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class TicketDespachoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<TicketDespachoBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				TicketDespachoDL TicketDespacho = new TicketDespachoDL();
				return TicketDespacho.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<TicketDespachoBE> ListaFecha(int IdEmpresa, DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                TicketDespachoDL TicketDespacho = new TicketDespachoDL();
                return TicketDespacho.ListaFecha(IdEmpresa, FechaInicio, FechaFin);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TicketDespachoBE> ListaFecha(int IdEmpresa, DateTime Fecha)
        {
            try
            {
                TicketDespachoDL TicketDespacho = new TicketDespachoDL();
                return TicketDespacho.ListaFecha(IdEmpresa, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TicketDespachoBE Selecciona(int IdTicketDespacho)
		{
			try
			{
				TicketDespachoDL TicketDespacho = new TicketDespachoDL();
				return TicketDespacho.Selecciona(IdTicketDespacho);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public TicketDespachoBE SeleccionaPedido(int IdPedido)
        {
            try
            {
                TicketDespachoDL TicketDespacho = new TicketDespachoDL();
                return TicketDespacho.SeleccionaPedido(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TicketDespachoBE pItem)
		{
			try
			{

				TicketDespachoDL TicketDespacho = new TicketDespachoDL();
				TicketDespacho.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(TicketDespachoBE pItem)
		{
			try
			{
				TicketDespachoDL TicketDespacho = new TicketDespachoDL();
				TicketDespacho.Actualiza(pItem);

                //if(pItem.IdSituacion ==Parametros.intFacturado)
                //{
                PedidoBL objBL_Pedido = new PedidoBL();
                objBL_Pedido.ActualizaSituacion(pItem.IdEmpresa, pItem.IdPedido, Parametros.intPVDespachado, pItem.IdDespachador, pItem.Usuario, pItem.Maquina);
                //}
                
            }
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(TicketDespachoBE pItem)
		{
			try
			{
				TicketDespachoDL TicketDespacho = new TicketDespachoDL();
				TicketDespacho.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
