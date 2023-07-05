using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class HojaInstalacionDetalleBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<HojaInstalacionDetalleBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				HojaInstalacionDetalleDL HojaInstalacionDetalle = new HojaInstalacionDetalleDL();
				return HojaInstalacionDetalle.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public HojaInstalacionDetalleBE Selecciona(int IdHojaInstalacionDetalle)
		{
			try
			{
				HojaInstalacionDetalleDL HojaInstalacionDetalle = new HojaInstalacionDetalleDL();
				return HojaInstalacionDetalle.Selecciona(IdHojaInstalacionDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public HojaInstalacionDetalleBE SeleccionaPedido(int IdPedido)
        {
            try
            {
                HojaInstalacionDetalleDL HojaInstalacionDetalle = new HojaInstalacionDetalleDL();
                return HojaInstalacionDetalle.SeleccionaPedido(IdPedido);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(HojaInstalacionDetalleBE pItem)
		{
			try
			{
				HojaInstalacionDetalleDL HojaInstalacionDetalle = new HojaInstalacionDetalleDL();
				HojaInstalacionDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(HojaInstalacionDetalleBE pItem)
		{
			try
			{
				HojaInstalacionDetalleDL HojaInstalacionDetalle = new HojaInstalacionDetalleDL();
				HojaInstalacionDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(HojaInstalacionDetalleBE pItem)
		{
			try
			{
				HojaInstalacionDetalleDL HojaInstalacionDetalle = new HojaInstalacionDetalleDL();
				HojaInstalacionDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
