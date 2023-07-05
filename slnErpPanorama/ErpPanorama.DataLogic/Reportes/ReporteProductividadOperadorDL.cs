using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProductividadOperadorDL
    {
        public List<ReporteProductividadOperadorBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProductividadOperador");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProductividadOperadorBE> Lista = new List<ReporteProductividadOperadorBE>();
            ReporteProductividadOperadorBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteProductividadOperadorBE();
                Reporte.ApeNom = reader["ApeNom"].ToString();
                Reporte.NumeroPedido = reader["NumeroPedido"].ToString();
                Reporte.Items = Int32.Parse(reader["Items"].ToString());
                Reporte.TotalCantidad = Int32.Parse(reader["TotalCantidad"].ToString());
                Reporte.TotalCantidadChequeo = Int32.Parse(reader["TotalCantidadChequeo"].ToString());
                Reporte.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                Reporte.TiempoPicking = reader["TiempoPicking"].ToString();
                Reporte.TiempoChequeo = reader["TiempoChequeo"].ToString();
                Reporte.TiempoEmbalaje = reader["TiempoEmbalaje"].ToString();
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
