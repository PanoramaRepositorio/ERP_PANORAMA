using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteProductoCatalogoBL
    {
        public List<ReporteProductoCatalogoBE> Listado(int IdEmpresa)
        {
            try
            {
                ReporteProductoCatalogoDL Producto = new ReporteProductoCatalogoDL();
                return Producto.Listado(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
