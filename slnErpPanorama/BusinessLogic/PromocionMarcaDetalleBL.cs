using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PromocionMarcaDetalleBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PromocionMarcaDetalleBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				PromocionMarcaDetalleDL PromocionMarcaDetalle = new PromocionMarcaDetalleDL();
				return PromocionMarcaDetalle.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public PromocionMarcaDetalleBE Selecciona(int IdPromocionMarcaDetalle)
		{
			try
			{
				PromocionMarcaDetalleDL PromocionMarcaDetalle = new PromocionMarcaDetalleDL();
				return PromocionMarcaDetalle.Selecciona(IdPromocionMarcaDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PromocionMarcaDetalleBE pItem)
		{
			try
			{
				PromocionMarcaDetalleDL PromocionMarcaDetalle = new PromocionMarcaDetalleDL();
				PromocionMarcaDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PromocionMarcaDetalleBE pItem)
		{
			try
			{
				PromocionMarcaDetalleDL PromocionMarcaDetalle = new PromocionMarcaDetalleDL();
				PromocionMarcaDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PromocionMarcaDetalleBE pItem)
		{
			try
			{
				PromocionMarcaDetalleDL PromocionMarcaDetalle = new PromocionMarcaDetalleDL();
				PromocionMarcaDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
