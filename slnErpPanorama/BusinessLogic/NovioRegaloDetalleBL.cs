using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class NovioRegaloDetalleBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<NovioRegaloDetalleBE> ListaTodosActivo(int IdNovioRegalo,int IdAlmacen)
		{
			try
			{
				NovioRegaloDetalleDL NovioRegaloDetalle = new NovioRegaloDetalleDL();
				return NovioRegaloDetalle.ListaTodosActivo(IdNovioRegalo, IdAlmacen);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public NovioRegaloDetalleBE Selecciona(int IdNovioRegaloDetalle)
		{
			try
			{
				NovioRegaloDetalleDL NovioRegaloDetalle = new NovioRegaloDetalleDL();
				return NovioRegaloDetalle.Selecciona(IdNovioRegaloDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(NovioRegaloDetalleBE pItem)
		{
			try
			{
				NovioRegaloDetalleDL NovioRegaloDetalle = new NovioRegaloDetalleDL();
				NovioRegaloDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(NovioRegaloDetalleBE pItem)
		{
			try
			{
				NovioRegaloDetalleDL NovioRegaloDetalle = new NovioRegaloDetalleDL();
				NovioRegaloDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(NovioRegaloDetalleBE pItem)
		{
			try
			{
				NovioRegaloDetalleDL NovioRegaloDetalle = new NovioRegaloDetalleDL();
				NovioRegaloDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
