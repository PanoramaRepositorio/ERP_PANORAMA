using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;


namespace ErpPanorama.BusinessLogic
{
   public class UbicacionesBL
    {
        public List<UbicacionesBE> ListaUbicaciones()
        {
            try
            {
                UbicacionesDL MovimientoPedido = new UbicacionesDL();
                return MovimientoPedido.ListaUbicaciones();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
