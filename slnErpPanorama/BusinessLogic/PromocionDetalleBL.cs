using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class PromocionDetalleBL
    {
        public List<PromocionDetalleBE> ListaTodosActivo(int IdPromocion)
        {
            try
            {
                PromocionDetalleDL PromocionDetalle = new PromocionDetalleDL();
                return PromocionDetalle.ListaTodosActivo(IdPromocion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PromocionDetalleBE pItem)
        {
            try
            {
                PromocionDetalleDL PromocionDetalle = new PromocionDetalleDL();
                PromocionDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PromocionDetalleBE pItem)
        {
            try
            {
                PromocionDetalleDL PromocionDetalle = new PromocionDetalleDL();
                PromocionDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PromocionDetalleBE pItem)
        {
            try
            {
                PromocionDetalleDL PromocionDetalle = new PromocionDetalleDL();
                PromocionDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
