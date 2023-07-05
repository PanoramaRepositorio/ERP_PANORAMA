using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductoBL
    {
        public List<ReporteProductoBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteProductoDL Producto = new ReporteProductoDL();
                return Producto.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

