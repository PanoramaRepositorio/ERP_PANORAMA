using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class FeriadoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<FeriadoBE> ListaTodosActivo(int Periodo)
		{
			try
			{
				FeriadoDL Feriado = new FeriadoDL();
				return Feriado.ListaTodosActivo(Periodo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public FeriadoBE Selecciona(int IdFeriado)
		{
			try
			{
				FeriadoDL Feriado = new FeriadoDL();
				return Feriado.Selecciona(IdFeriado);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(FeriadoBE pItem)
		{
			try
			{
				FeriadoDL Feriado = new FeriadoDL();
				Feriado.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(FeriadoBE pItem)
		{
			try
			{
				FeriadoDL Feriado = new FeriadoDL();
				Feriado.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(FeriadoBE pItem)
		{
			try
			{
				FeriadoDL Feriado = new FeriadoDL();
				Feriado.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
