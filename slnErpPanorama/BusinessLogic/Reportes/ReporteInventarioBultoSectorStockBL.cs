using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteInventarioBultoSectorStockBL
    {
        public List<ReporteInventarioBultoSectorStockBE> Listado(int IdEmpresa, int IdSector)
        {
            try
            {
                ReporteInventarioBultoSectorStockDL Bulto = new ReporteInventarioBultoSectorStockDL();
                return Bulto.Listado(IdEmpresa, IdSector);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
