using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DescuentoClienteMayoristaBL
    {
        public List<DescuentoClienteMayoristaBE> ListaTodosActivo(int IdEmpresa, int IdFormaPago, int IdLineaProducto)
        {
            try
            {
                DescuentoClienteMayoristaDL DescuentoClienteMayorista = new DescuentoClienteMayoristaDL();
                return DescuentoClienteMayorista.ListaTodosActivo(IdEmpresa,IdFormaPago,IdLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(DescuentoClienteMayoristaBE pItem)
        {
            try
            {
                DescuentoClienteMayoristaDL DescuentoClienteMayorista = new DescuentoClienteMayoristaDL();
                DescuentoClienteMayorista.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DescuentoClienteMayoristaBE pItem)
        {
            try
            {
                DescuentoClienteMayoristaDL DescuentoClienteMayorista = new DescuentoClienteMayoristaDL();
                DescuentoClienteMayorista.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DescuentoClienteMayoristaBE pItem)
        {
            try
            {
                DescuentoClienteMayoristaDL DescuentoClienteMayorista = new DescuentoClienteMayoristaDL();
                DescuentoClienteMayorista.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
