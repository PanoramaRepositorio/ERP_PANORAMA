using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class EstadoCuentaClienteBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<EstadoCuentaClienteBE> ListaTodosActivo(int IdEmpresa, int IdCliente, string TipoMovimiento, int IdSituacion)
		{
			try
			{
				EstadoCuentaClienteDL EstadoCuentaCliente = new EstadoCuentaClienteDL();
				return EstadoCuentaCliente.ListaTodosActivo(IdEmpresa, IdCliente, TipoMovimiento, IdSituacion);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<EstadoCuentaClienteBE> ListaPagado(int IdEmpresa, int IdCliente)
        {
            try
            {
                EstadoCuentaClienteDL EstadoCuentaCliente = new EstadoCuentaClienteDL();
                return EstadoCuentaCliente.ListaPagado(IdEmpresa, IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaClienteBE Selecciona(int IdEstadoCuentaCliente)
		{
			try
			{
				EstadoCuentaClienteDL EstadoCuentaCliente = new EstadoCuentaClienteDL();
				return EstadoCuentaCliente.Selecciona(IdEstadoCuentaCliente);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(EstadoCuentaClienteBE pItem)
		{
			try
			{
				EstadoCuentaClienteDL EstadoCuentaCliente = new EstadoCuentaClienteDL();
				EstadoCuentaCliente.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(EstadoCuentaClienteBE pItem)
		{
			try
			{
				EstadoCuentaClienteDL EstadoCuentaCliente = new EstadoCuentaClienteDL();
				EstadoCuentaCliente.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}
        public void ActualizaSaldo(int IdEstadoCuentaCliente, decimal Saldo)
        {
            try
            {
                EstadoCuentaClienteDL EstadoCuentaCliente = new EstadoCuentaClienteDL();
                EstadoCuentaCliente.ActualizaSaldo(IdEstadoCuentaCliente, Saldo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EstadoCuentaClienteBE pItem)
		{
			try
			{
				EstadoCuentaClienteDL EstadoCuentaCliente = new EstadoCuentaClienteDL();
				EstadoCuentaCliente.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
