using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteFacturaCompraBL
    {
        public List<ReporteFacturaCompraBE> Listado(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                ReporteFacturaCompraDL FacturaCompra = new ReporteFacturaCompraDL();
                return FacturaCompra.Listado(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteFacturaCompraBE> ListadoStock(int IdEmpresa, int IdFacturaCompra)
        {
            try
            {
                ReporteFacturaCompraDL FacturaCompra = new ReporteFacturaCompraDL();
                return FacturaCompra.ListadoStock(IdEmpresa, IdFacturaCompra);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
