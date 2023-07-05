using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
     public class ReporteClienteMayoristaRutaBL
    {
        public List<ReporteClienteMayoristaRutaBE> Listado(int IdEmpresa, int IdRuta)
        {
            try
            {
                ReporteClienteMayoristaRutaDL ClienteMayorista = new ReporteClienteMayoristaRutaDL();
                return ClienteMayorista.Listado(IdEmpresa, IdRuta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
