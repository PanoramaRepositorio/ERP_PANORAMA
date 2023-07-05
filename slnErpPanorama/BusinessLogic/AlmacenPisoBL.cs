using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class AlmacenPisoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<AlmacenPisoBE> ListaTodosActivo(int IdAlmacen)
		{
			try
			{
				AlmacenPisoDL AlmacenPiso = new AlmacenPisoDL();
				return AlmacenPiso.ListaTodosActivo(IdAlmacen);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public AlmacenPisoBE Selecciona(int IdAlmacenPiso)
		{
			try
			{
				AlmacenPisoDL AlmacenPiso = new AlmacenPisoDL();
				return AlmacenPiso.Selecciona(IdAlmacenPiso);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(AlmacenPisoBE pItem)
		{
			try
			{
				AlmacenPisoDL AlmacenPiso = new AlmacenPisoDL();
				AlmacenPiso.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(AlmacenPisoBE pItem)
		{
			try
			{
				AlmacenPisoDL AlmacenPiso = new AlmacenPisoDL();
				AlmacenPiso.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(AlmacenPisoBE pItem)
		{
			try
			{
				AlmacenPisoDL AlmacenPiso = new AlmacenPisoDL();
				AlmacenPiso.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
