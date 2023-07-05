using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProductividadOperadorVDL
    {
        public List<ReporteProductividadOperadorVBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductividadOperadorV");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductividadOperadorVBE> Lista = new List<ReporteProductividadOperadorVBE>();
            ReporteProductividadOperadorVBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteProductividadOperadorVBE();
                Reporte.NumeroPedido = reader["NumeroPedido"].ToString();
                Reporte.Items = Int32.Parse(reader["Items"].ToString());
                Reporte.TotalCantidad = Int32.Parse(reader["TotalCantidad"].ToString());
                Reporte.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                //Reporte.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Reporte.Tiempo = reader["Tiempo"].ToString();
                Reporte.DescPersona = reader["DescPersona"].ToString();
                Reporte.Tipo = reader["Tipo"].ToString();
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
