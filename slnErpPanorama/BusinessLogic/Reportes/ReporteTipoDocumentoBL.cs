using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteTipoDocumentoBL
    {
        public List<ReporteTipoDocumentoBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteTipoDocumentoDL TipoDocumento = new ReporteTipoDocumentoDL();
                return TipoDocumento.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

