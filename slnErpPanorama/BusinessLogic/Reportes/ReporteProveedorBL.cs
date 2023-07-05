using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProveedorBL
    {
        public List<ReporteProveedorBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteProveedorDL Proveedor = new ReporteProveedorDL();
                return Proveedor.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
