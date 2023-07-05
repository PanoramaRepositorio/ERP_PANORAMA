using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class SolicitudInsumoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<SolicitudInsumoBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes)
        {
			try
			{
				SolicitudInsumoDL SolicitudInsumo = new SolicitudInsumoDL();
				return SolicitudInsumo.ListaTodosActivo(IdEmpresa, Periodo, Mes);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public SolicitudInsumoBE Selecciona(int IdSolicitudInsumo)
		{
			try
			{
				SolicitudInsumoDL SolicitudInsumo = new SolicitudInsumoDL();
				return SolicitudInsumo.Selecciona(IdSolicitudInsumo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(SolicitudInsumoBE pItem)
		{
			try
			{
				SolicitudInsumoDL SolicitudInsumo = new SolicitudInsumoDL();
				SolicitudInsumo.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(SolicitudInsumoBE pItem)
		{
			try
			{
				SolicitudInsumoDL SolicitudInsumo = new SolicitudInsumoDL();
				SolicitudInsumo.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(SolicitudInsumoBE pItem)
		{
			try
			{
				SolicitudInsumoDL SolicitudInsumo = new SolicitudInsumoDL();
				SolicitudInsumo.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
