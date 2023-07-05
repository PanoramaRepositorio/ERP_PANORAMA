using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DsctoMayoristaFamiliaFormaPagoBL
    {
        public List<DsctoMayoristaFamiliaFormaPagoBE> ListaTodosActivo(int IdFamiliaProducto, int IdFormaPago)
        {
            try
            {
                DsctoMayoristaFamiliaFormaPagoDL DescuentoClienteMayorista = new DsctoMayoristaFamiliaFormaPagoDL();
                return DescuentoClienteMayorista.ListaTodosActivo(IdFamiliaProducto, IdFormaPago);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(DsctoMayoristaFamiliaFormaPagoBE pItem)
        {
            try
            {
                DsctoMayoristaFamiliaFormaPagoDL DescuentoClienteMayorista = new DsctoMayoristaFamiliaFormaPagoDL();
                DescuentoClienteMayorista.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DsctoMayoristaFamiliaFormaPagoBE pItem)
        {
            try
            {
                DsctoMayoristaFamiliaFormaPagoDL DescuentoClienteMayorista = new DsctoMayoristaFamiliaFormaPagoDL();
                DescuentoClienteMayorista.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DsctoMayoristaFamiliaFormaPagoBE pItem)
        {
            try
            {
                DsctoMayoristaFamiliaFormaPagoDL DescuentoClienteMayorista = new DsctoMayoristaFamiliaFormaPagoDL();
                DescuentoClienteMayorista.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
