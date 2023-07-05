using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class InsumoAlmacenBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<InsumoAlmacenBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				InsumoAlmacenDL InsumoAlmacen = new InsumoAlmacenDL();
				return InsumoAlmacen.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public InsumoAlmacenBE Selecciona(int IdInsumoAlmacen)
		{
			try
			{
				InsumoAlmacenDL InsumoAlmacen = new InsumoAlmacenDL();
				return InsumoAlmacen.Selecciona(IdInsumoAlmacen);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(InsumoAlmacenBE pItem)
		{
			try
			{
				InsumoAlmacenDL InsumoAlmacen = new InsumoAlmacenDL();
				InsumoAlmacen.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(InsumoAlmacenBE pItem)
		{
			try
			{
				InsumoAlmacenDL InsumoAlmacen = new InsumoAlmacenDL();
				InsumoAlmacen.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(InsumoAlmacenBE pItem)
		{
			try
			{
				InsumoAlmacenDL InsumoAlmacen = new InsumoAlmacenDL();
				InsumoAlmacen.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
