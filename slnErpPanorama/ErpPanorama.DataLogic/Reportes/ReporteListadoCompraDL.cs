using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteListadoCompraDL
    {
        public List<ReporteListadoCompraBE> Listado(int IdEmpresa, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptListadoCompras");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteListadoCompraBE> Lista = new List<ReporteListadoCompraBE>();
            ReporteListadoCompraBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteListadoCompraBE();
                Reporte.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                Reporte.IdFacturaCompraDetalle = Int32.Parse(reader["IdFacturaCompraDetalle"].ToString());
                Reporte.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Reporte.NombreProducto = reader["NombreProducto"].ToString();
                Reporte.Abreviatura = reader["Abreviatura"].ToString();
                Reporte.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Reporte.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                Reporte.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                Reporte.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Reporte.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Reporte.DescProveedor = reader["DescProveedor"].ToString();
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
