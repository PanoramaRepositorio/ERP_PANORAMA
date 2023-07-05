using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteDocumentoVentaElectronicaBL
    {
        public List<ReporteDocumentoVentaElectronicaBE> Listado(int IdDocumentoVenta)
        {
            try
            {
                ReporteDocumentoVentaElectronicaDL reporte = new ReporteDocumentoVentaElectronicaDL();
                return reporte.Listado(IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ReporteDocumentoVentaElectronicaBE> ListadoGuia(int IdDocumentoVenta)
        {
            try
            {
                ReporteDocumentoVentaElectronicaDL reporte = new ReporteDocumentoVentaElectronicaDL();
                return reporte.ListadoGuia(IdDocumentoVenta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
