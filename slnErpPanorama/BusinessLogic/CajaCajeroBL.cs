using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class CajaCajeroBL
    {
        public List<CajaCajeroBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdCaja)
        {
            try
            {
                CajaCajeroDL CajaCajero = new CajaCajeroDL();
                return CajaCajero.ListaTodosActivo(IdEmpresa, IdTienda, IdCaja);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CajaCajeroBE pItem)
        {
            try
            {
                CajaCajeroDL CajaCajero = new CajaCajeroDL();
                CajaCajero.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CajaCajeroBE pItem)
        {
            try
            {
                CajaCajeroDL CajaCajero = new CajaCajeroDL();
                CajaCajero.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CajaCajeroBE pItem)
        {
            try
            {
                CajaCajeroDL CajaCajero = new CajaCajeroDL();
                CajaCajero.Elimina(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
