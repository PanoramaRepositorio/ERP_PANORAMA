using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ComboDetalleBL
    {
        public List<ComboDetalleBE> ListaTodosActivo(int IdCombo)
        {
            try
            {
                ComboDetalleDL ComboDetalle = new ComboDetalleDL();
                return ComboDetalle.ListaTodosActivo(IdCombo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ComboDetalleBE pItem)
        {
            try
            {
                ComboDetalleDL ComboDetalle = new ComboDetalleDL();
                ComboDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ComboDetalleBE pItem)
        {
            try
            {
                ComboDetalleDL ComboDetalle = new ComboDetalleDL();
                ComboDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ComboDetalleBE pItem)
        {
            try
            {
                ComboDetalleDL ComboDetalle = new ComboDetalleDL();
                ComboDetalle.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
