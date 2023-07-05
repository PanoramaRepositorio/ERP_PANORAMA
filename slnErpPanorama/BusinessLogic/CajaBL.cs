using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CajaBL
    {
        public List<CajaBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            try
            {
                CajaDL Caja = new CajaDL();
                return Caja.ListaTodosActivo(IdEmpresa, IdTienda);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CajaBE pItem)
        {
            try
            {
                CajaDL Caja = new CajaDL();
                Caja.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CajaBE pItem)
        {
            try
            {
                CajaDL Caja = new CajaDL();
                Caja.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CajaBE pItem)
        {
            try
            {
                CajaDL Caja = new CajaDL();
                Caja.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
