using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class SunatErrorFEBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<SunatErrorFEBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				SunatErrorFEDL SunatErrorFE = new SunatErrorFEDL();
				return SunatErrorFE.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public SunatErrorFEBE Selecciona(string Codigo)
		{
			try
			{
				SunatErrorFEDL SunatErrorFE = new SunatErrorFEDL();
				return SunatErrorFE.Selecciona(Codigo);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(SunatErrorFEBE pItem)
		{
			try
			{
				SunatErrorFEDL SunatErrorFE = new SunatErrorFEDL();
				SunatErrorFE.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(SunatErrorFEBE pItem)
		{
			try
			{
				SunatErrorFEDL SunatErrorFE = new SunatErrorFEDL();
				SunatErrorFE.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(SunatErrorFEBE pItem)
		{
			try
			{
				SunatErrorFEDL SunatErrorFE = new SunatErrorFEDL();
				SunatErrorFE.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
