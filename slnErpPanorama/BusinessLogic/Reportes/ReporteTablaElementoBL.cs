using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTablaElementoBL
    {
        public List<ReporteTablaElementoBE> Listado()
        {
            try
            {
                ReporteTablaElementoDL TablaElemento = new ReporteTablaElementoDL();
                return TablaElemento.Listado();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}