using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDocumentoReferenciaBL
    {
        public List<ReporteDocumentoReferenciaBE> Listado(int IdDocumentoVenta)
        {
            try
            {
                ReporteDocumentoReferenciaDL ReporteDocumentoReferencia = new ReporteDocumentoReferenciaDL();
                return ReporteDocumentoReferencia.Listado(IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
