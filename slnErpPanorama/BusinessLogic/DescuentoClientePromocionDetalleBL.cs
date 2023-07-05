using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class DescuentoClientePromocionDetalleBL
	{
		public List<DescuentoClientePromocionDetalleBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				DescuentoClientePromocionDetalleDL DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleDL();
				return DescuentoClientePromocionDetalle.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public DescuentoClientePromocionDetalleBE Selecciona(int IdDescuentoClientePromocionDetalle)
		{
			try
			{
				DescuentoClientePromocionDetalleDL DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleDL();
				return DescuentoClientePromocionDetalle.Selecciona(IdDescuentoClientePromocionDetalle);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public DescuentoClientePromocionDetalleBE SeleccionaProducto(int IdDescuentoClientePromocion, int IdProducto)
        {
            try
            {
                DescuentoClientePromocionDetalleDL DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleDL();
                return DescuentoClientePromocionDetalle.SeleccionaProducto(IdDescuentoClientePromocion, IdProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

		public void Inserta(DescuentoClientePromocionDetalleBE pItem)
		{
			try
			{
				DescuentoClientePromocionDetalleDL DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleDL();
				DescuentoClientePromocionDetalle.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(DescuentoClientePromocionDetalleBE pItem)
		{
			try
			{
				DescuentoClientePromocionDetalleDL DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleDL();
				DescuentoClientePromocionDetalle.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(DescuentoClientePromocionDetalleBE pItem)
		{
			try
			{
				DescuentoClientePromocionDetalleDL DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleDL();
				DescuentoClientePromocionDetalle.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public void EliminaTodo(DescuentoClientePromocionDetalleBE pItem)
        {
            try
            {
                DescuentoClientePromocionDetalleDL DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleDL();
                DescuentoClientePromocionDetalle.EliminaTodo(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

	}
}
