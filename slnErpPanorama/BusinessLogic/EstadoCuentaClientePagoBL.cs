using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class EstadoCuentaClientePagoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<EstadoCuentaClientePagoBE> ListaTodosActivo(int IdEmpresa, int IdCliente, string TipoMovimiento, int IdSituacion)
		{
			try
			{
				EstadoCuentaClientePagoDL EstadoCuentaClientePago = new EstadoCuentaClientePagoDL();
				return EstadoCuentaClientePago.ListaTodosActivo(IdEmpresa, IdCliente, TipoMovimiento, IdSituacion);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<EstadoCuentaClientePagoBE> ListaPagado(int IdEmpresa, int IdCliente)
        {
            try
            {
                EstadoCuentaClientePagoDL EstadoCuentaClientePago = new EstadoCuentaClientePagoDL();
                return EstadoCuentaClientePago.ListaPagado(IdEmpresa, IdCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EstadoCuentaClientePagoBE> ListaHistorial(int IdEmpresa, int IdEstadoCuentaCliente)
        {
            try
            {
                EstadoCuentaClientePagoDL EstadoCuentaClientePago = new EstadoCuentaClientePagoDL();
                return EstadoCuentaClientePago.ListaHistorial(IdEmpresa, IdEstadoCuentaCliente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EstadoCuentaClientePagoBE Selecciona(int IdEstadoCuentaClientePago)
		{
			try
			{
				EstadoCuentaClientePagoDL EstadoCuentaClientePago = new EstadoCuentaClientePagoDL();
				return EstadoCuentaClientePago.Selecciona(IdEstadoCuentaClientePago);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public EstadoCuentaClientePagoBE SeleccionaUltimo(int IdCliente, int IdEstadoCuentaCliente, string TipoMovimiento)
        {
            try
            {
                EstadoCuentaClientePagoDL EstadoCuentaClientePago = new EstadoCuentaClientePagoDL();
                return EstadoCuentaClientePago.SeleccionaUltimo(IdCliente, IdEstadoCuentaCliente, TipoMovimiento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EstadoCuentaClientePagoBE pItem)
		{
			try
			{
				EstadoCuentaClientePagoDL EstadoCuentaClientePago = new EstadoCuentaClientePagoDL();
				EstadoCuentaClientePago.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(EstadoCuentaClientePagoBE pItem)
		{
			try
			{
				EstadoCuentaClientePagoDL EstadoCuentaClientePago = new EstadoCuentaClientePagoDL();
				EstadoCuentaClientePago.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public void ActualizaSaldo(int IdEstadoCuentaClientePago, decimal Saldo)
        {
            try
            {
                EstadoCuentaClientePagoDL EstadoCuentaClientePago = new EstadoCuentaClientePagoDL();
                EstadoCuentaClientePago.ActualizaSaldo(IdEstadoCuentaClientePago, Saldo);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Elimina(EstadoCuentaClientePagoBE pItem)
		{
			try
			{
				EstadoCuentaClientePagoDL EstadoCuentaClientePago = new EstadoCuentaClientePagoDL();
				EstadoCuentaClientePago.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public Int32 EliminaCompensado(EstadoCuentaClientePagoBE pItem)
        {
            try
            {
                int IdEstadoCuentaCliente = 0;
                EstadoCuentaClientePagoDL EstadoCuentaClientePago = new EstadoCuentaClientePagoDL();
                IdEstadoCuentaCliente = EstadoCuentaClientePago.EliminaCompensado(pItem);

                return IdEstadoCuentaCliente;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
