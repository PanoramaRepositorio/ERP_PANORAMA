using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteSeparacionCabeceraBL
    {
        public List<ReporteSeparacionCabeceraBE> Listado(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            try
            {
                ReporteSeparacionCabeceraDL SeparacionCabecera = new ReporteSeparacionCabeceraDL();
                return SeparacionCabecera.Listado(IdEmpresa, IdCliente, IdMotivo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
