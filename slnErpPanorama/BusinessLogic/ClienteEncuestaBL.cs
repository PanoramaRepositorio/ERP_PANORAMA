using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class ClienteEncuestaBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<ClienteEncuestaBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				ClienteEncuestaDL ClienteEncuesta = new ClienteEncuestaDL();
				return ClienteEncuesta.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}
        public List<ClienteEncuestaBE> ListaFecha(int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ClienteEncuestaDL ClienteEncuesta = new ClienteEncuestaDL();
                return ClienteEncuesta.ListaFecha(IdTienda, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public ClienteEncuestaBE Selecciona(int IdCliente)
		{
			try
			{
				ClienteEncuestaDL ClienteEncuesta = new ClienteEncuestaDL();
				return ClienteEncuesta.Selecciona(IdCliente);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(ClienteEncuestaBE pItem)
		{
			try
			{
				ClienteEncuestaDL ClienteEncuesta = new ClienteEncuestaDL();
				ClienteEncuesta.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(ClienteEncuestaBE pItem)
		{
			try
			{
				ClienteEncuestaDL ClienteEncuesta = new ClienteEncuestaDL();
				ClienteEncuesta.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(ClienteEncuestaBE pItem)
		{
			try
			{
				ClienteEncuestaDL ClienteEncuesta = new ClienteEncuestaDL();
				ClienteEncuesta.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
