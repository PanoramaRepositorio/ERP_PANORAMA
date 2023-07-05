using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class AlmacenMotivoMovimientoBL
    {
        public List<AlmacenMotivoMovimientoBE> ListaTodosActivo(int IdAlmacen)
        {
            try
            {
                AlmacenMotivoMovimientoDL AlmacenMotivoMovimiento = new AlmacenMotivoMovimientoDL();
                return AlmacenMotivoMovimiento.ListaTodosActivo(IdAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
