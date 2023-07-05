using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class CuentaBancoDetalleCausalBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<CuentaBancoDetalleCausalBE> ListaTodosActivo(string TipoMovimiento)
		{
			try
			{
				CuentaBancoDetalleCausalDL CuentaBancoDetalleCausal = new CuentaBancoDetalleCausalDL();
                return CuentaBancoDetalleCausal.ListaTodosActivo(TipoMovimiento);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public CuentaBancoDetalleCausalBE Selecciona(int IdCuentaBancoDetalleCausal)
		{
			try
			{
				CuentaBancoDetalleCausalDL CuentaBancoDetalleCausal = new CuentaBancoDetalleCausalDL();
				return CuentaBancoDetalleCausal.Selecciona(IdCuentaBancoDetalleCausal);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(CuentaBancoDetalleCausalBE pItem)
		{
			try
			{
				CuentaBancoDetalleCausalDL CuentaBancoDetalleCausal = new CuentaBancoDetalleCausalDL();
				CuentaBancoDetalleCausal.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(CuentaBancoDetalleCausalBE pItem)
		{
			try
			{
				CuentaBancoDetalleCausalDL CuentaBancoDetalleCausal = new CuentaBancoDetalleCausalDL();
				CuentaBancoDetalleCausal.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(CuentaBancoDetalleCausalBE pItem)
		{
			try
			{
				CuentaBancoDetalleCausalDL CuentaBancoDetalleCausal = new CuentaBancoDetalleCausalDL();
				CuentaBancoDetalleCausal.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
