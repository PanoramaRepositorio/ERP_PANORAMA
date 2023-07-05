using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ConsultasMarketingBL
    {
        public List<ConsultasMarketingBE> ClienteRegistro(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ConsultasMarketingDL ClienteRegistro = new ConsultasMarketingDL();
                return ClienteRegistro.ClienteRegistro(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ConsultasMarketingBE> ClienteReferido(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ConsultasMarketingDL ClienteReferido = new ConsultasMarketingDL();
                return ClienteReferido.ClienteReferido(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ConsultasMarketingBE> ClienteActualizado(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ConsultasMarketingDL ClienteActualizado = new ConsultasMarketingDL();
                return ClienteActualizado.ClienteActualizado(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ConsultasMarketingBE> ClienteCompras(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ConsultasMarketingDL ClienteCompras = new ConsultasMarketingDL();
                return ClienteCompras.ClienteCompras(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<ConsultasMarketingBE> ProductosCompras(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ConsultasMarketingDL ProductosCompras = new ConsultasMarketingDL();
                return ProductosCompras.ProductosCompras(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}