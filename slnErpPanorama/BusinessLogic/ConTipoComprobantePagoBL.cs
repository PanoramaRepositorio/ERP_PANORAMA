using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ConTipoComprobantePagoBL
    {
        public List<ConTipoComprobantePagoBE> ListaTodosActivo()
        {
            try
            {
                ConTipoComprobantePagoDL ConTipoComprobantePago = new ConTipoComprobantePagoDL();
                return ConTipoComprobantePago.ListaTodosActivo();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ConTipoComprobantePagoBE Selecciona(int IdConTipoComprobantePago)
        {
            try
            {
                ConTipoComprobantePagoDL ConTipoComprobantePago = new ConTipoComprobantePagoDL();
                return ConTipoComprobantePago.Selecciona(IdConTipoComprobantePago);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ConTipoComprobantePagoBE pItem)
        {
            try
            {
                ConTipoComprobantePagoDL ConTipoComprobantePago = new ConTipoComprobantePagoDL();
                ConTipoComprobantePago.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ConTipoComprobantePagoBE pItem)
        {
            try
            {
                ConTipoComprobantePagoDL ConTipoComprobantePago = new ConTipoComprobantePagoDL();
                ConTipoComprobantePago.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ConTipoComprobantePagoBE pItem)
        {
            try
            {
                ConTipoComprobantePagoDL ConTipoComprobantePago = new ConTipoComprobantePagoDL();
                ConTipoComprobantePago.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
