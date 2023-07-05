using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class TurnoDetalleBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<TurnoDetalleBE> ListaTodosActivo(int IdTurno)
		{
			try
			{
				TurnoDetalleDL TurnoDetalle = new TurnoDetalleDL();
				return TurnoDetalle.ListaTodosActivo(IdTurno);
			}
			catch (Exception ex)
			{ throw ex; }
		}
		public List<TurnoDetalleBE> ListaFormato()
		{
			try
			{
				TurnoDetalleDL TurnoDetalle = new TurnoDetalleDL();
				return TurnoDetalle.ListaFormato();
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public TurnoDetalleBE Selecciona(int IdTurnoDetalle)
		{
			try
			{
				TurnoDetalleDL TurnoDetalle = new TurnoDetalleDL();
				return TurnoDetalle.Selecciona(IdTurnoDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(TurnoDetalleBE pItem)
		{
			try
			{
				TurnoDetalleDL TurnoDetalle = new TurnoDetalleDL();
				TurnoDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(TurnoDetalleBE pItem)
		{
			try
			{
				TurnoDetalleDL TurnoDetalle = new TurnoDetalleDL();
				TurnoDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(TurnoDetalleBE pItem)
		{
			try
			{
				TurnoDetalleDL TurnoDetalle = new TurnoDetalleDL();
				TurnoDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
