using System;
using System.Collections.Generic;
using System.Text;
using ErpPanorama.BusinessEntity;
using ErpPanorama.DataLogic;
using System.Data;
using System.Transactions;

namespace ErpPanorama.BusinessLogic
{
    public class ReporteCreditoBL
    {
        public List<ReporteCreditoBE> ListadoCreditoVencido(int IdEmpresa,  int IdCliente, DateTime FechaDesde, DateTime FechaHasta, int IdTipoCliente, int IdClasificacionCliente, int IdMotivo, int IdClasificacionClienteCredito, int Moroso)
        {
            try
            {
                ReporteCreditoDL EstadoCuentaNumeroDias = new ReporteCreditoDL();
                return EstadoCuentaNumeroDias.ListadoCreditoVencido(IdEmpresa,  IdCliente, FechaDesde, FechaHasta, IdTipoCliente, IdClasificacionCliente, IdMotivo, IdClasificacionClienteCredito, Moroso);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCreditoBE> ListadoCreditoMensual(int IdEmpresa, int IdMotivo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCreditoDL EstadoCuentaNumeroDias = new ReporteCreditoDL();
                return EstadoCuentaNumeroDias.ListadoCreditoMensual(IdEmpresa, IdMotivo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCreditoBE> ListadoCreditoMensualTodos(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCreditoDL EstadoCuentaNumeroDias = new ReporteCreditoDL();
                return EstadoCuentaNumeroDias.ListadoCreditoMensualTodos(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCreditoBE> ListadoCreditoPagos(int IdEmpresa, int IdMotivo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCreditoDL EstadoCuentaNumeroDias = new ReporteCreditoDL();
                return EstadoCuentaNumeroDias.ListadoCreditoPagos(IdEmpresa,  IdMotivo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }




        public List<ReporteCreditoBE> ListadoMorosos(int IdEmpresa, int IdMotivo, String clasifica)
        {
            try
            {
                ReporteCreditoDL EstadoCuentaNumeroDias = new ReporteCreditoDL();
                return EstadoCuentaNumeroDias.ListadoMorosos(IdEmpresa,  IdMotivo, clasifica );
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
