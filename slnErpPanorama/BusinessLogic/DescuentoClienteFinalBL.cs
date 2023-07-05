using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class DescuentoClienteFinalBL
    {
        public List<DescuentoClienteFinalBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                DescuentoClienteFinalDL DescuentoClienteFinal = new DescuentoClienteFinalDL();
                return DescuentoClienteFinal.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(DescuentoClienteFinalBE pItem)
        {
            try
            {
                DescuentoClienteFinalDL DescuentoClienteFinal = new DescuentoClienteFinalDL();
                DescuentoClienteFinal.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(DescuentoClienteFinalBE pItem)
        {
            try
            {
                DescuentoClienteFinalDL DescuentoClienteFinal = new DescuentoClienteFinalDL();
                DescuentoClienteFinal.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(DescuentoClienteFinalBE pItem)
        {
            try
            {
                DescuentoClienteFinalDL DescuentoClienteFinal = new DescuentoClienteFinalDL();
                DescuentoClienteFinal.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
