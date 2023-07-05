using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class MetaConversionBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<MetaConversionBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				MetaConversionDL MetaConversion = new MetaConversionDL();
				return MetaConversion.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public MetaConversionBE Selecciona(int IdMetaConversion)
		{
			try
			{
				MetaConversionDL MetaConversion = new MetaConversionDL();
				return MetaConversion.Selecciona(IdMetaConversion);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(MetaConversionBE pItem)
		{
			try
			{
				MetaConversionDL MetaConversion = new MetaConversionDL();
				MetaConversion.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(MetaConversionBE pItem)
		{
			try
			{
				MetaConversionDL MetaConversion = new MetaConversionDL();
				MetaConversion.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(MetaConversionBE pItem)
		{
			try
			{
				MetaConversionDL MetaConversion = new MetaConversionDL();
				MetaConversion.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
