using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteSectorBL
    {
        public List<ReporteSectorBE> Listado(int IdEmpresa, int IdTienda, int IdAlmacen)
        {
            try
            {
                ReporteSectorDL Sector = new ReporteSectorDL();
                return Sector.Listado(IdEmpresa,IdTienda,IdAlmacen);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
