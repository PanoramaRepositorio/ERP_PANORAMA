using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PaisBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PaisBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				PaisDL Pais = new PaisDL();
				return Pais.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public PaisBE Selecciona(int IdPais)
		{
			try
			{
				PaisDL Pais = new PaisDL();
				return Pais.Selecciona(IdPais);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PaisBE pItem)
		{
			try
			{
				PaisDL Pais = new PaisDL();
				Pais.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PaisBE pItem)
		{
			try
			{
				PaisDL Pais = new PaisDL();
				Pais.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PaisBE pItem)
		{
			try
			{
				PaisDL Pais = new PaisDL();
				Pais.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
