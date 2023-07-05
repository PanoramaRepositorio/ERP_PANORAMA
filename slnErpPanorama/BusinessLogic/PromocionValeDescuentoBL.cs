using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PromocionValeDescuentoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PromocionValeDescuentoBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
		{
			try
			{
				PromocionValeDescuentoDL PromocionValeDescuento = new PromocionValeDescuentoDL();
				return PromocionValeDescuento.ListaTodosActivo(IdEmpresa, IdTienda);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<PromocionValeDescuentoBE> ListaTodosActivo(int IdPromocionValeDescuento)
        {
            try
            {
                PromocionValeDescuentoDL PromocionValeDescuento = new PromocionValeDescuentoDL();
                return PromocionValeDescuento.ListaTodosActivo(IdPromocionValeDescuento);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PromocionValeDescuentoBE> ListaFecha(int IdEmpresa, int IdTienda, int TipoConsulta)
        {
            try
            {
                PromocionValeDescuentoDL PromocionValeDescuento = new PromocionValeDescuentoDL();
                return PromocionValeDescuento.ListaFecha(IdEmpresa, IdTienda, TipoConsulta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PromocionValeDescuentoBE Selecciona(int IdPromocionValeDescuento)
		{
			try
			{
				PromocionValeDescuentoDL PromocionValeDescuento = new PromocionValeDescuentoDL();
				return PromocionValeDescuento.Selecciona(IdPromocionValeDescuento);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PromocionValeDescuentoBE pItem)
		{
			try
			{
				PromocionValeDescuentoDL PromocionValeDescuento = new PromocionValeDescuentoDL();
				PromocionValeDescuento.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PromocionValeDescuentoBE pItem)
		{
			try
			{
				PromocionValeDescuentoDL PromocionValeDescuento = new PromocionValeDescuentoDL();
				PromocionValeDescuento.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PromocionValeDescuentoBE pItem)
		{
			try
			{
				PromocionValeDescuentoDL PromocionValeDescuento = new PromocionValeDescuentoDL();
				PromocionValeDescuento.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
