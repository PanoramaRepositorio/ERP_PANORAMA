using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTicketVendedorDL
    {
        public List<ReporteTicketVendedorBE> Listado(Int32 IdTienda, DateTime FechaDesde, DateTime FechaHasta, Int32 TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptTicketPromedioVendedor");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTicketVendedorBE> reportelist = new List<ReporteTicketVendedorBE>();
            ReporteTicketVendedorBE reporte;
            while (reader.Read())
            {
                reporte = new ReporteTicketVendedorBE();
                reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                reporte.DescTienda = reader["DescTienda"].ToString();
                reporte.DescVendedor = reader["DescVendedor"].ToString();
                reporte.Cargo = reader["Cargo"].ToString();
                reporte.Tickets = Int32.Parse(reader["Tickets"].ToString());
                reporte.TotalVentaAl75 = Decimal.Parse(reader["TotalVentaAl75"].ToString());
                reporte.TotalVentaAl100 = Decimal.Parse(reader["TotalVentaAl100"].ToString());
                reporte.TotalVentaFabrica = Decimal.Parse(reader["TotalVentaFabrica"].ToString());
                reporte.TotalVentaFinal = Decimal.Parse(reader["TotalVentaFinal"].ToString());
                reporte.TotalVenta = Decimal.Parse(reader["TotalVenta"].ToString());
                reporte.TicketPromedio = Decimal.Parse(reader["TicketPromedio"].ToString());
                reporte.Participacion = Decimal.Parse(reader["Participacion"].ToString());
                reportelist.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return reportelist;
        }

        public List<ReporteTicketVendedorBE> ListadoCartera(Int32 IdTienda, DateTime FechaDesde, DateTime FechaHasta, Int32 TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptTicketPromedioVendedorCartera");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTicketVendedorBE> reportelist = new List<ReporteTicketVendedorBE>();
            ReporteTicketVendedorBE reporte;
            while (reader.Read())
            {
                reporte = new ReporteTicketVendedorBE();
                reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                reporte.DescVendedor = reader["DescVendedor"].ToString();
                reporte.Tickets = Int32.Parse(reader["Tickets"].ToString());

                reporte.TotalVentaAl75 = Decimal.Parse(reader["TotalVentaAl75"].ToString());
                reporte.TotalVentaAl100 = Decimal.Parse(reader["TotalVentaAl100"].ToString());
                reporte.TotalVentaFabrica = Decimal.Parse(reader["TotalVentaFabrica"].ToString());
                reporte.TotalVentaFinal = Decimal.Parse(reader["TotalVentaFinal"].ToString());

                reporte.TotalVenta = Decimal.Parse(reader["TotalVenta"].ToString());
                reporte.TicketPromedio = Decimal.Parse(reader["TicketPromedio"].ToString());
                reporte.Participacion = Decimal.Parse(reader["Participacion"].ToString());
                reportelist.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return reportelist;
        }
    }
}
