using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class FacturaCompraInsumoDetalleBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<FacturaCompraInsumoDetalleBE> ListaTodosActivo(int IdFacturaCompraInsumo)
		{
			try
			{
				FacturaCompraInsumoDetalleDL FacturaCompraInsumoDetalle = new FacturaCompraInsumoDetalleDL();
				return FacturaCompraInsumoDetalle.ListaTodosActivo(IdFacturaCompraInsumo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public FacturaCompraInsumoDetalleBE Selecciona(int IdFacturaCompraInsumoDetalle)
		{
			try
			{
				FacturaCompraInsumoDetalleDL FacturaCompraInsumoDetalle = new FacturaCompraInsumoDetalleDL();
				return FacturaCompraInsumoDetalle.Selecciona(IdFacturaCompraInsumoDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(FacturaCompraInsumoDetalleBE pItem)
		{
			try
			{
				FacturaCompraInsumoDetalleDL FacturaCompraInsumoDetalle = new FacturaCompraInsumoDetalleDL();
				FacturaCompraInsumoDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(FacturaCompraInsumoDetalleBE pItem)
		{
			try
			{
				FacturaCompraInsumoDetalleDL FacturaCompraInsumoDetalle = new FacturaCompraInsumoDetalleDL();
				FacturaCompraInsumoDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(FacturaCompraInsumoDetalleBE pItem)
		{
			try
			{
				FacturaCompraInsumoDetalleDL FacturaCompraInsumoDetalle = new FacturaCompraInsumoDetalleDL();
				FacturaCompraInsumoDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
