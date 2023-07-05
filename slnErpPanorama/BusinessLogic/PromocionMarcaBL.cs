using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class PromocionMarcaBL
	{
		public enum Operacion
		{
			Nuevo = 1,
			Modificar = 2,
			Eliminar = 3,
			Consultar = 4
		}

		public List<PromocionMarcaBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				PromocionMarcaDL PromocionMarca = new PromocionMarcaDL();
				return PromocionMarca.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<PromocionMarcaBE> ListaFecha(int IdEmpresa)
        {
            try
            {
                PromocionMarcaDL PromocionMarca = new PromocionMarcaDL();
                return PromocionMarca.ListaFecha(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PromocionMarcaBE Selecciona(int IdPromocionMarca)
		{
			try
			{
				PromocionMarcaDL PromocionMarca = new PromocionMarcaDL();
				return PromocionMarca.Selecciona(IdPromocionMarca);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(PromocionMarcaBE pItem)
		{
			try
			{
				PromocionMarcaDL PromocionMarca = new PromocionMarcaDL();
				PromocionMarca.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(PromocionMarcaBE pItem)
		{
			try
			{
				PromocionMarcaDL PromocionMarca = new PromocionMarcaDL();
				PromocionMarca.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(PromocionMarcaBE pItem)
		{
			try
			{
				PromocionMarcaDL PromocionMarca = new PromocionMarcaDL();
				PromocionMarca.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
