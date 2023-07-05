using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteKardexSalidasDL
    {
        public List< ReporteKardexSalidasBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_ListadoSalidas");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List< ReporteKardexSalidasBE> Lista = new List< ReporteKardexSalidasBE>();
             ReporteKardexSalidasBE Reporte;
            while (reader.Read())
            {
                Reporte = new  ReporteKardexSalidasBE();
                Reporte.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Reporte.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Reporte.DescTienda = reader["DescTienda"].ToString();
                Reporte.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Reporte.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Reporte.NombreProducto = reader["NombreProducto"].ToString();
                Reporte.Abreviatura = reader["Abreviatura"].ToString();
                Reporte.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Reporte.DescSubLinea = reader["DescSubLinea"].ToString();
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }

        
    }
}
