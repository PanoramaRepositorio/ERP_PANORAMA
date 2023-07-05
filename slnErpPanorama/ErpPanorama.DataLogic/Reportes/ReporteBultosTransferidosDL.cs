using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteBultosTransferidosDL
    {
        public List<ReporteBultosTransferidosBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptBultoTransferidos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List< ReporteBultosTransferidosBE> Lista = new List< ReporteBultosTransferidosBE>();
             ReporteBultosTransferidosBE Reporte;
            while (reader.Read())
            {
                Reporte = new  ReporteBultosTransferidosBE();
                Reporte.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Reporte.NombreProducto = reader["NombreProducto"].ToString();
                Reporte.Abreviatura = reader["Abreviatura"].ToString();
                Reporte.NumeroBulto = reader["NumeroBulto"].ToString();
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.DescSector = reader["DescSector"].ToString();
                Reporte.DescBloque = reader["DescBloque"].ToString();
                Reporte.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Reporte.FechaSalida = DateTime.Parse(reader["FechaSalida"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
