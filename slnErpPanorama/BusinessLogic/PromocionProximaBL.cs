using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PromocionProximaBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PromocionProximaBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
		{
			try
			{
				PromocionProximaDL PromocionProxima = new PromocionProximaDL();
				return PromocionProxima.ListaTodosActivo(IdEmpresa, IdTienda);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public PromocionProximaBE Selecciona(int IdPromocionProxima)
		{
			try
			{
				PromocionProximaDL PromocionProxima = new PromocionProximaDL();
				return PromocionProxima.Selecciona(IdPromocionProxima);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public PromocionProximaBE SeleccionaActivo(int IdTienda, int IdFormaPago, int IdTipoCliente, Decimal Total)
        {
            try
            {
                PromocionProximaDL PromocionProxima = new PromocionProximaDL();
                return PromocionProxima.SeleccionaActivo(IdTienda, IdFormaPago, IdTipoCliente, Total);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PromocionProximaBE pItem)
		{
			try
			{
				PromocionProximaDL PromocionProxima = new PromocionProximaDL();
				PromocionProxima.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PromocionProximaBE pItem)
		{
			try
			{
				PromocionProximaDL PromocionProxima = new PromocionProximaDL();
				PromocionProxima.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PromocionProximaBE pItem)
		{
			try
			{
				PromocionProximaDL PromocionProxima = new PromocionProximaDL();
				PromocionProxima.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
