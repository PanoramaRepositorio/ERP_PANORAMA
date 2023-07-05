using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class SolicitudInsumoDetalleBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<SolicitudInsumoDetalleBE> ListaTodosActivo(int IdSolicitudInsumo)
		{
			try
			{
				SolicitudInsumoDetalleDL SolicitudInsumoDetalle = new SolicitudInsumoDetalleDL();
				return SolicitudInsumoDetalle.ListaTodosActivo(IdSolicitudInsumo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public SolicitudInsumoDetalleBE Selecciona(int IdSolicitudInsumoDetalle)
		{
			try
			{
				SolicitudInsumoDetalleDL SolicitudInsumoDetalle = new SolicitudInsumoDetalleDL();
				return SolicitudInsumoDetalle.Selecciona(IdSolicitudInsumoDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(SolicitudInsumoDetalleBE pItem)
		{
			try
			{
				SolicitudInsumoDetalleDL SolicitudInsumoDetalle = new SolicitudInsumoDetalleDL();
				SolicitudInsumoDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(SolicitudInsumoDetalleBE pItem)
		{
			try
			{
				SolicitudInsumoDetalleDL SolicitudInsumoDetalle = new SolicitudInsumoDetalleDL();
				SolicitudInsumoDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(SolicitudInsumoDetalleBE pItem)
		{
			try
			{
				SolicitudInsumoDetalleDL SolicitudInsumoDetalle = new SolicitudInsumoDetalleDL();
				SolicitudInsumoDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
