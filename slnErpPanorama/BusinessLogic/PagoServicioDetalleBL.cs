using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PagoServicioDetalleBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PagoServicioDetalleBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				PagoServicioDetalleDL PagoServicioDetalle = new PagoServicioDetalleDL();
				return PagoServicioDetalle.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public PagoServicioDetalleBE Selecciona(int IdPagoServicioDetalle)
		{
			try
			{
				PagoServicioDetalleDL PagoServicioDetalle = new PagoServicioDetalleDL();
				return PagoServicioDetalle.Selecciona(IdPagoServicioDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PagoServicioDetalleBE pItem)
		{
			try
			{
				PagoServicioDetalleDL PagoServicioDetalle = new PagoServicioDetalleDL();
				PagoServicioDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PagoServicioDetalleBE pItem)
		{
			try
			{
				PagoServicioDetalleDL PagoServicioDetalle = new PagoServicioDetalleDL();
				PagoServicioDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PagoServicioDetalleBE pItem)
		{
			try
			{
				PagoServicioDetalleDL PagoServicioDetalle = new PagoServicioDetalleDL();
				PagoServicioDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
