using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class MovimientoInsumoDetalleBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<MovimientoInsumoDetalleBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				MovimientoInsumoDetalleDL MovimientoInsumoDetalle = new MovimientoInsumoDetalleDL();
				return MovimientoInsumoDetalle.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public MovimientoInsumoDetalleBE Selecciona(int IdMovimientoInsumoDetalle)
		{
			try
			{
				MovimientoInsumoDetalleDL MovimientoInsumoDetalle = new MovimientoInsumoDetalleDL();
				return MovimientoInsumoDetalle.Selecciona(IdMovimientoInsumoDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(MovimientoInsumoDetalleBE pItem)
		{
			try
			{
				MovimientoInsumoDetalleDL MovimientoInsumoDetalle = new MovimientoInsumoDetalleDL();
				MovimientoInsumoDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(MovimientoInsumoDetalleBE pItem)
		{
			try
			{
				MovimientoInsumoDetalleDL MovimientoInsumoDetalle = new MovimientoInsumoDetalleDL();
				MovimientoInsumoDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(MovimientoInsumoDetalleBE pItem)
		{
			try
			{
				MovimientoInsumoDetalleDL MovimientoInsumoDetalle = new MovimientoInsumoDetalleDL();
				MovimientoInsumoDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
