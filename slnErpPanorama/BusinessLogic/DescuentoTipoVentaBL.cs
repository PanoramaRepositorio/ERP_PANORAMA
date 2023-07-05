using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class DescuentoTipoVentaBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<DescuentoTipoVentaBE> ListaTodosActivo(int IdEmpresa, int IdFormaPago, int IdLineaProducto)
        {
			try
			{
				DescuentoTipoVentaDL DescuentoTipoVenta = new DescuentoTipoVentaDL();
				return DescuentoTipoVenta.ListaTodosActivo(IdEmpresa, IdFormaPago, IdLineaProducto);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public DescuentoTipoVentaBE Selecciona(int IdDescuentoTipoVenta)
		{
			try
			{
				DescuentoTipoVentaDL DescuentoTipoVenta = new DescuentoTipoVentaDL();
				return DescuentoTipoVenta.Selecciona(IdDescuentoTipoVenta);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(DescuentoTipoVentaBE pItem)
		{
			try
			{
				DescuentoTipoVentaDL DescuentoTipoVenta = new DescuentoTipoVentaDL();
				DescuentoTipoVenta.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(DescuentoTipoVentaBE pItem)
		{
			try
			{
				DescuentoTipoVentaDL DescuentoTipoVenta = new DescuentoTipoVentaDL();
				DescuentoTipoVenta.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(DescuentoTipoVentaBE pItem)
		{
			try
			{
				DescuentoTipoVentaDL DescuentoTipoVenta = new DescuentoTipoVentaDL();
				DescuentoTipoVenta.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
