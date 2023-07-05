using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class InsumoClasificacionBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<InsumoClasificacionBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				InsumoClasificacionDL InsumoClasificacion = new InsumoClasificacionDL();
				return InsumoClasificacion.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public InsumoClasificacionBE Selecciona(int IdInsumoClasificacion)
		{
			try
			{
				InsumoClasificacionDL InsumoClasificacion = new InsumoClasificacionDL();
				return InsumoClasificacion.Selecciona(IdInsumoClasificacion);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(InsumoClasificacionBE pItem)
		{
			try
			{
				InsumoClasificacionDL InsumoClasificacion = new InsumoClasificacionDL();
				InsumoClasificacion.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(InsumoClasificacionBE pItem)
		{
			try
			{
				InsumoClasificacionDL InsumoClasificacion = new InsumoClasificacionDL();
				InsumoClasificacion.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(InsumoClasificacionBE pItem)
		{
			try
			{
				InsumoClasificacionDL InsumoClasificacion = new InsumoClasificacionDL();
				InsumoClasificacion.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
