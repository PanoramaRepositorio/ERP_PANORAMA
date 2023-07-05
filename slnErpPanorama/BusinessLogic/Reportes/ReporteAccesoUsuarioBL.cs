using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteAccesoUsuarioBL
    {
        public List<ReporteAccesoUsuarioBE> Listado()
        {
            try
            {
                ReporteAccesoUsuarioDL accesousuario = new ReporteAccesoUsuarioDL();
                return accesousuario.Listado();
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
