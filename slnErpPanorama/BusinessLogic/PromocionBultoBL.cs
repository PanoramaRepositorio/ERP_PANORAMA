using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PromocionBultoBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PromocionBultoBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				PromocionBultoDL PromocionBulto = new PromocionBultoDL();
				return PromocionBulto.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public PromocionBultoBE Selecciona(int IdPromocionBulto)
		{
			try
			{
				PromocionBultoDL PromocionBulto = new PromocionBultoDL();
				return PromocionBulto.Selecciona(IdPromocionBulto);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public void Inserta(PromocionBultoBE pItem, List<PromocionBultoDetalleBE> pListaPromocionBultoDetalle)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionBultoDL PromocionBulto = new PromocionBultoDL();
                    PromocionBultoDetalleDL PromocionBultoDetalle = new PromocionBultoDetalleDL();

                    int IdPromocionBulto = 0;
                    IdPromocionBulto = PromocionBulto.Inserta(pItem);

                    foreach (PromocionBultoDetalleBE item in pListaPromocionBultoDetalle)
                    {
                        //Insertamos el detalle de la solicitud de producto
                        item.IdPromocionBulto = IdPromocionBulto;
                        PromocionBultoDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }


		}

        public void Actualiza(PromocionBultoBE pItem, List<PromocionBultoDetalleBE> pListaPromocionBultoDetalle)
		{
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PromocionBultoDL PromocionBulto = new PromocionBultoDL();
                    PromocionBultoDetalleDL PromocionBultoDetalle = new PromocionBultoDetalleDL();
                    

                    foreach (PromocionBultoDetalleBE item in pListaPromocionBultoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            //Insertamos el detalle de la solicitud de producto
                            item.IdPromocionBulto = pItem.IdPromocionBulto;
                            PromocionBultoDetalle.Inserta(item);
                        }
                        else
                        {
                            //Actualizamos el detalle de la solicitud de producto
                            PromocionBultoDetalle.Actualiza(item);
                        }
                    }

                    PromocionBulto.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
		}

		public void Elimina(PromocionBultoBE pItem)
		{
			try
			{
				PromocionBultoDL PromocionBulto = new PromocionBultoDL();
				PromocionBulto.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
