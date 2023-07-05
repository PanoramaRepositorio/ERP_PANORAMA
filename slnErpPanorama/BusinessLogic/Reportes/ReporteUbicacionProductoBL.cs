using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteUbicacionProductoBL
    {
        public List<ReporteUbicacionProductoBE> Listado()
        {
            try
            {
                ReporteUbicacionProductoDL UbicacionProducto = new ReporteUbicacionProductoDL();
                return UbicacionProducto.Listado();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

