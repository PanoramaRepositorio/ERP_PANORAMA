using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CambioDetalleBL
    {
        public List<CambioDetalleBE> ListaTodosActivo(int IdCambio)
        {
            try
            {
                CambioDetalleDL CambioDetalle = new CambioDetalleDL();
                return CambioDetalle.ListaTodosActivo(IdCambio);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(CambioDetalleBE pItem)
        {
            try
            {
                CambioDetalleDL CambioDetalle = new CambioDetalleDL();
                CambioDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CambioDetalleBE pItem)
        {
            try
            {
                CambioDetalleDL CambioDetalle = new CambioDetalleDL();
                CambioDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CambioDetalleBE pItem)
        {
            try
            {
                CambioDetalleDL CambioDetalle = new CambioDetalleDL();
                CambioDetalle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
