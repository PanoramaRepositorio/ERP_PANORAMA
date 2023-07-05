using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class MovimientoInsumoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<MovimientoInsumoBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				MovimientoInsumoDL MovimientoInsumo = new MovimientoInsumoDL();
				return MovimientoInsumo.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public MovimientoInsumoBE Selecciona(int IdMovimientoInsumo)
		{
			try
			{
				MovimientoInsumoDL MovimientoInsumo = new MovimientoInsumoDL();
				return MovimientoInsumo.Selecciona(IdMovimientoInsumo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(MovimientoInsumoBE pItem)
		{
			try
			{
				MovimientoInsumoDL MovimientoInsumo = new MovimientoInsumoDL();
				MovimientoInsumo.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(MovimientoInsumoBE pItem)
		{
			try
			{
				MovimientoInsumoDL MovimientoInsumo = new MovimientoInsumoDL();
				MovimientoInsumo.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(MovimientoInsumoBE pItem)
		{
			try
			{
				MovimientoInsumoDL MovimientoInsumo = new MovimientoInsumoDL();
				MovimientoInsumo.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
