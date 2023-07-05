using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class ClienteComercioBL
    {
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		//public List<ClienteComercioBE> ListaTodosActivo(int IdEmpresa, int IdCliente, string TipoMovimiento, int IdSituacion)
		//{
		//	try
		//	{
  //              ClienteComercioDL EstadoCuentaCliente = new ClienteComercioDL();
		//	//	return EstadoCuentaCliente.ListaTodosActivo(IdEmpresa, IdCliente, TipoMovimiento, IdSituacion);
		//	}
		//	catch (Exception ex)
		//	{ throw ex; }
		//}

  //      public List<ClienteComercioBE> ListaPagado(int IdEmpresa, int IdCliente)
  //      {
  //          try
  //          {
  //              ClienteComercioDL EstadoCuentaCliente = new ClienteComercioDL();
  //            //  return EstadoCuentaCliente.ListaPagado(IdEmpresa, IdCliente);
  //          }
  //          catch (Exception ex)
  //          { throw ex; }
  //      }

  //      public ClienteComercioBE Selecciona(int IdEstadoCuentaCliente)
		//{
		//	try
		//	{
  //              ClienteComercioDL EstadoCuentaCliente = new ClienteComercioDL();
		//		return EstadoCuentaCliente.Selecciona(IdEstadoCuentaCliente);
		//	}
		//	catch (Exception ex)
		//	{ throw ex; }
		//}

		public int Inserta(ClienteComercioBE pItem)
		{
			try
			{
                ClienteComercioDL  ClienteComercio = new ClienteComercioDL();
				return ClienteComercio.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(ClienteComercioBE pItem)
		{
			try
			{
                ClienteComercioDL EstadoCuentaCliente = new ClienteComercioDL();
				EstadoCuentaCliente.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}
        public void ActualizaSaldo(int IdEstadoCuentaCliente, decimal Saldo)
        {
            try
            {
                ClienteComercioDL EstadoCuentaCliente = new ClienteComercioDL();
                EstadoCuentaCliente.ActualizaSaldo(IdEstadoCuentaCliente, Saldo);
            }
            catch (Exception ex)
            { throw ex; }
        }

  //      public void Elimina(ClienteComercioBE pItem)
		//{
		//	try
		//	{
  //              ClienteComercioDL EstadoCuentaCliente = new ClienteComercioDL();
		//		EstadoCuentaCliente.Elimina(pItem);
		//	}
		//	catch (Exception ex)
		//	{ throw ex; }
		//}

	}
}
