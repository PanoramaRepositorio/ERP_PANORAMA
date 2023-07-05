using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class BancoProductoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<BancoProductoBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				BancoProductoDL BancoProducto = new BancoProductoDL();
				return BancoProducto.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public BancoProductoBE Selecciona(int IdBancoProducto)
		{
			try
			{
				BancoProductoDL BancoProducto = new BancoProductoDL();
				return BancoProducto.Selecciona(IdBancoProducto);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(BancoProductoBE pItem)
		{
			try
			{
				BancoProductoDL BancoProducto = new BancoProductoDL();
				BancoProducto.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(BancoProductoBE pItem)
		{
			try
			{
				BancoProductoDL BancoProducto = new BancoProductoDL();
				BancoProducto.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(BancoProductoBE pItem)
		{
			try
			{
				BancoProductoDL BancoProducto = new BancoProductoDL();
				BancoProducto.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
