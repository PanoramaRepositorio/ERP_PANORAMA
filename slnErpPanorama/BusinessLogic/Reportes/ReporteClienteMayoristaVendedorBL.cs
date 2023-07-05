using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteClienteMayoristaVendedorBL
    {
        public List<ReporteClienteMayoristaVendedorBE> Listado(int IdEmpresa, int IdVendedor, int IdSituacion)
        {
            try
            {
                ReporteClienteMayoristaVendedorDL ClienteMayorista = new ReporteClienteMayoristaVendedorDL();
                return ClienteMayorista.Listado(IdEmpresa, IdVendedor, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteClienteMayoristaVendedorBE> ListadoAsociado(int IdEmpresa, int IdVendedor, int IdSituacion, int Periodo)
        {
            try
            {
                ReporteClienteMayoristaVendedorDL ClienteMayorista = new ReporteClienteMayoristaVendedorDL();
                return ClienteMayorista.ListadoAsociado(IdEmpresa, IdVendedor,IdSituacion, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<ReporteClienteMayoristaVendedorBE> ListadoCompra(int IdEmpresa, int IdVendedor,int IdSituacion , DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteClienteMayoristaVendedorDL ClienteMayorista = new ReporteClienteMayoristaVendedorDL();
                return ClienteMayorista.ListadoCompra(IdEmpresa, IdVendedor,IdSituacion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
        
    }
}
