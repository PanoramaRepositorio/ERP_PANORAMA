using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class EscalaMayoristaPreVentaBL
    {
        public List<EscalaMayoristaBE> ListaTodosActivo(int IdFamiliaProducto, int IdFormaPago)
        {
            try
            {
                EscalaMayoristaPreVentaDL DescuentoClienteMayorista = new EscalaMayoristaPreVentaDL();
                return DescuentoClienteMayorista.ListaTodosActivo(IdFamiliaProducto, IdFormaPago);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EscalaMayoristaBE pItem)
        {
            try
            {
                EscalaMayoristaPreVentaDL DescuentoClienteMayorista = new EscalaMayoristaPreVentaDL();
                DescuentoClienteMayorista.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EscalaMayoristaBE pItem)
        {
            try
            {
                EscalaMayoristaPreVentaDL DescuentoClienteMayorista = new EscalaMayoristaPreVentaDL();
                DescuentoClienteMayorista.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EscalaMayoristaBE pItem)
        {
            try
            {
                EscalaMayoristaPreVentaDL DescuentoClienteMayorista = new EscalaMayoristaPreVentaDL();
                DescuentoClienteMayorista.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
