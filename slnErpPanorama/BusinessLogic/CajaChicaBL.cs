using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class CajaChicaBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<CajaChicaBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
		{
			try
			{
				CajaChicaDL CajaChica = new CajaChicaDL();
				return CajaChica.ListaTodosActivo(IdEmpresa, IdTienda);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public CajaChicaBE Selecciona(int IdCajaChica)
		{
			try
			{
				CajaChicaDL CajaChica = new CajaChicaDL();
				return CajaChica.Selecciona(IdCajaChica);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(CajaChicaBE pItem)
		{
			try
			{
				CajaChicaDL CajaChica = new CajaChicaDL();
				CajaChica.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(CajaChicaBE pItem)
		{
			try
			{
				CajaChicaDL CajaChica = new CajaChicaDL();
				CajaChica.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(CajaChicaBE pItem)
		{
			try
			{
				CajaChicaDL CajaChica = new CajaChicaDL();
				CajaChica.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
