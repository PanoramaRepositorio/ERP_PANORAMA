using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EscalaMayoristaBL
    {
        public List<EscalaMayoristaBE> ListaTodosActivo(int IdFamiliaProducto, int IdFormaPago)
        {
            try
            {
                EscalaMayoristaDL DescuentoClienteMayorista = new EscalaMayoristaDL();
                return DescuentoClienteMayorista.ListaTodosActivo(IdFamiliaProducto, IdFormaPago);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EscalaMayoristaBE pItem)
        {
            try
            {
                EscalaMayoristaDL DescuentoClienteMayorista = new EscalaMayoristaDL();
                DescuentoClienteMayorista.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EscalaMayoristaBE pItem)
        {
            try
            {
                EscalaMayoristaDL DescuentoClienteMayorista = new EscalaMayoristaDL();
                DescuentoClienteMayorista.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EscalaMayoristaBE pItem)
        {
            try
            {
                EscalaMayoristaDL DescuentoClienteMayorista = new EscalaMayoristaDL();
                DescuentoClienteMayorista.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
