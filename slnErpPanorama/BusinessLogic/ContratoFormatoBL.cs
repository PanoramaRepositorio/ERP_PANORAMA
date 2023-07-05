using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
	public class ContratoFormatoBL
	{
		public List<ContratoFormatoBE> ListaTodosActivo(int IdEmpresa)
		{
			try
			{
				ContratoFormatoDL ContratoFormato = new ContratoFormatoDL();
				return ContratoFormato.ListaTodosActivo(IdEmpresa);
			}
			catch (Exception ex)
			{ throw ex; }
		}

        public List<ContratoFormatoBE> ListaFormato(int IdEmpresa)
        {
            try
            {
                ContratoFormatoDL ContratoFormato = new ContratoFormatoDL();
                return ContratoFormato.ListaFormato(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ContratoFormatoBE Selecciona(int IdContratoFormato)
		{
			try
			{
				ContratoFormatoDL ContratoFormato = new ContratoFormatoDL();
				return ContratoFormato.Selecciona(IdContratoFormato);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Inserta(ContratoFormatoBE pItem)
		{
			try
			{
				ContratoFormatoDL ContratoFormato = new ContratoFormatoDL();
				ContratoFormato.Inserta(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Actualiza(ContratoFormatoBE pItem)
		{
			try
			{
				ContratoFormatoDL ContratoFormato = new ContratoFormatoDL();
				ContratoFormato.Actualiza(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

		public void Elimina(ContratoFormatoBE pItem)
		{
			try
			{
				ContratoFormatoDL ContratoFormato = new ContratoFormatoDL();
				ContratoFormato.Elimina(pItem);
			}
			catch (Exception ex)
			{ throw ex; }
		}

	}
}
