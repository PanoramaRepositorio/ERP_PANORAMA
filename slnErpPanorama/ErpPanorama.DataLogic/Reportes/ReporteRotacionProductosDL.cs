using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteRotacionProductosDL
    {
        public List<ReporteRotacionProductosBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptRotacionProductos");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pTipoReporte", DbType.Int32, TipoReporte);
            dbCommand.CommandTimeout = 250;

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteRotacionProductosBE> RotacionProductolist = new List<ReporteRotacionProductosBE>();
            ReporteRotacionProductosBE RotacionProducto;
            while (reader.Read())
            {
                RotacionProducto = new ReporteRotacionProductosBE();
                RotacionProducto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                RotacionProducto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                RotacionProducto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                RotacionProducto.DescProveedor = reader["DescProveedor"].ToString();
                RotacionProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                RotacionProducto.NombreProducto = reader["NombreProducto"].ToString();
                RotacionProducto.Abreviatura = reader["Abreviatura"].ToString();
                RotacionProducto.Cantidad = Convert.ToInt32(reader["Cantidad"].ToString());
                RotacionProducto.Importe = Convert.ToDecimal(reader["Importe"].ToString());
                RotacionProducto.DiasSinRotacion = Convert.ToInt32(reader["DiasSinRotacion"].ToString());
                RotacionProducto.Almacen = reader["Almacen"].ToString();
                RotacionProductolist.Add(RotacionProducto);
            }
            reader.Close();
            reader.Dispose();
            return RotacionProductolist;
        }

        public List<ReporteRotacionProductosBE> ListadoPorTienda(int IdEmpresa, int IdTienda , DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptRotacionProductosPorTienda");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pTipoReporte", DbType.Int32, TipoReporte);
            dbCommand.CommandTimeout = 250;

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteRotacionProductosBE> RotacionProductolist = new List<ReporteRotacionProductosBE>();
            ReporteRotacionProductosBE RotacionProducto;
            while (reader.Read())
            {
                RotacionProducto = new ReporteRotacionProductosBE();
                RotacionProducto.DescTienda = reader["DescTienda"].ToString();
                RotacionProducto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                RotacionProducto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                RotacionProducto.DescModeloProducto = reader["DescModeloProducto"].ToString();
                RotacionProducto.DescProveedor= reader["DescProveedor"].ToString();
                RotacionProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                RotacionProducto.NombreProducto = reader["NombreProducto"].ToString();
                RotacionProducto.Abreviatura = reader["Abreviatura"].ToString();
                RotacionProducto.Cantidad = Convert.ToInt32(reader["Cantidad"].ToString());
                RotacionProducto.Importe = Convert.ToDecimal(reader["Importe"].ToString());
                RotacionProducto.DiasSinRotacion = Convert.ToInt32(reader["DiasSinRotacion"].ToString());
                RotacionProducto.Almacen = reader["Almacen"].ToString();
                RotacionProductolist.Add(RotacionProducto);
            }
            reader.Close();
            reader.Dispose();
            return RotacionProductolist;
        }

    }
}
