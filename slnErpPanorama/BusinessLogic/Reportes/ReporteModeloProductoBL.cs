using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;


namespace ErpPanorama.BusinessLogic
{
    public class ReporteModeloProductoBL
    {
        public List<ReporteModeloProductoBE> Listado(int IdEmpresa, int IdLineaProducto)
        {
            try
            {
                ReporteModeloProductoDL ModeloProducto = new ReporteModeloProductoDL();
                return ModeloProducto.Listado(IdEmpresa, IdLineaProducto);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}

