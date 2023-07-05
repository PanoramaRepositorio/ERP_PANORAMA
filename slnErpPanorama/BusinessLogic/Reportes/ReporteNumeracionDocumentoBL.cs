using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;


namespace ErpPanorama.BusinessLogic
{
    public class ReporteNumeracionDocumentoBL
    {
        public List<ReporteNumeracionDocumentoBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteNumeracionDocumentoDL NumeracionDocumento = new ReporteNumeracionDocumentoDL();
                return NumeracionDocumento.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
