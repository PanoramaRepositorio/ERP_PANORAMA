using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PromocionBultoDetalleBL
	{
        public List<PromocionBultoDetalleBE> ListaTodosActivo(int IdPromocionBulto)
		{
			try
			{
				PromocionBultoDetalleDL PromocionBultoDetalle = new PromocionBultoDetalleDL();
                return PromocionBultoDetalle.ListaTodosActivo(IdPromocionBulto);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<PromocionBultoDetalleBE> ListaTipoClienteFormapago(int IdEmpresa, int IdTipoCliente, int IdFormaPago, DateTime Fecha)
        {
            try
            {
                PromocionBultoDetalleDL PromocionBultoDetalle = new PromocionBultoDetalleDL();
                return PromocionBultoDetalle.ListaTipoClienteFormapago(IdEmpresa, IdTipoCliente, IdFormaPago, Fecha);
            }
            catch (Exception ex)
            { throw ex; }
        }

		public PromocionBultoDetalleBE Selecciona(int IdPromocionBultoDetalle)
		{
			try
			{
				PromocionBultoDetalleDL PromocionBultoDetalle = new PromocionBultoDetalleDL();
				return PromocionBultoDetalle.Selecciona(IdPromocionBultoDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PromocionBultoDetalleBE pItem)
		{
			try
			{
				PromocionBultoDetalleDL PromocionBultoDetalle = new PromocionBultoDetalleDL();
				PromocionBultoDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PromocionBultoDetalleBE pItem)
		{
			try
			{
				PromocionBultoDetalleDL PromocionBultoDetalle = new PromocionBultoDetalleDL();
				PromocionBultoDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PromocionBultoDetalleBE pItem)
		{
			try
			{
				PromocionBultoDetalleDL PromocionBultoDetalle = new PromocionBultoDetalleDL();
				PromocionBultoDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
