using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class TempCheckinoutBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<TempCheckinoutBE> ListaFecha(string Dni, DateTime FechaDesde, DateTime FechaHasta)
		{
			try
			{
				TempCheckinoutDL TempCheckinout = new TempCheckinoutDL();
				return TempCheckinout.ListaFecha(Dni, FechaDesde, FechaHasta);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public TempCheckinoutBE Selecciona(int IdTempCheckinout)
		{
			try
			{
				TempCheckinoutDL TempCheckinout = new TempCheckinoutDL();
				return TempCheckinout.Selecciona(IdTempCheckinout);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(TempCheckinoutBE pItem)
		{
			try
			{
				TempCheckinoutDL TempCheckinout = new TempCheckinoutDL();
				TempCheckinout.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(TempCheckinoutBE pItem)
		{
			try
			{
				TempCheckinoutDL TempCheckinout = new TempCheckinoutDL();
				TempCheckinout.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(TempCheckinoutBE pItem)
		{
			try
			{
				TempCheckinoutDL TempCheckinout = new TempCheckinoutDL();
				TempCheckinout.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
