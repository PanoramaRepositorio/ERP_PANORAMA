using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMetasLineaProductoDL
    {
        public List<ReporteMetasLineaProductoBE> Listado(int IdLineaProducto, int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaMesVendedorLineaProducto");
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMetasLineaProductoBE> Lista = new List<ReporteMetasLineaProductoBE>();
            ReporteMetasLineaProductoBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteMetasLineaProductoBE();
                Reporte.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Reporte.Mes = Int32.Parse(reader["Mes"].ToString());
                Reporte.DescMes = reader["DescMes"].ToString();
                Reporte.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Reporte.DescVendedor = reader["DescVendedor"].ToString();
                Reporte.ImporteMeta = Decimal.Parse(reader["ImporteMeta"].ToString());
                Reporte.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }

        public List<ReporteMetasLineaProductoBE> ListadoDiario(int IdLineaProducto, int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaDiaVendedorLineaProducto");
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMetasLineaProductoBE> Lista = new List<ReporteMetasLineaProductoBE>();
            ReporteMetasLineaProductoBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteMetasLineaProductoBE();
                Reporte.Item = Int32.Parse(reader["Item"].ToString());
                Reporte.Dia = Int32.Parse(reader["Dia"].ToString());
                Reporte.DescMes = reader["DescMes"].ToString();
                Reporte.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Reporte.DescVendedor = reader["DescVendedor"].ToString();
                Reporte.ImporteMeta = Decimal.Parse(reader["ImporteMeta"].ToString());
                Reporte.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }

    }
}
