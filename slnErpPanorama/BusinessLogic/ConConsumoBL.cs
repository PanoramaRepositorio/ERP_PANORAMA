using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ConConsumoBL
    {
        public List<ConConsumoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ConConsumoDL ConConsumo = new ConConsumoDL();
                return ConConsumo.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ConConsumoBE Selecciona(int IdConConsumo)
        {
            try
            {
                ConConsumoDL ConConsumo = new ConConsumoDL();
                return ConConsumo.Selecciona(IdConConsumo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ConConsumoBE SeleccionaNumero(string IdConTipoComprobantePago, string Serie, string Numero)
        {
            try
            {
                ConConsumoDL ConConsumo = new ConConsumoDL();
                return ConConsumo.SeleccionaNumero(IdConTipoComprobantePago, Serie, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ConConsumoBE pItem)
        {
            try
            {
                ConConsumoDL ConConsumo = new ConConsumoDL();
                ConConsumo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ConConsumoBE pItem)
        {
            try
            {
                ConConsumoDL ConConsumo = new ConConsumoDL();
                ConConsumo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ConConsumoBE pItem)
        {
            try
            {
                ConConsumoDL ConConsumo = new ConConsumoDL();
                ConConsumo.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
