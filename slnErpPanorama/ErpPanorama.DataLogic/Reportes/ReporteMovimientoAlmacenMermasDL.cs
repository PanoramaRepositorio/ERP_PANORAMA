using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMovimientoAlmacenMermasDL
    {
        public List<ReporteMovimientoAlmacenMermasBE> ListadoMermas(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMermas");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoAlmacenMermasBE> MovimientoAlmacenlist = new List<ReporteMovimientoAlmacenMermasBE>();
            ReporteMovimientoAlmacenMermasBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new ReporteMovimientoAlmacenMermasBE();
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacen.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacen.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacen.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacen.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                MovimientoAlmacen.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                MovimientoAlmacen.DescLineaProducto = reader["DescLineaProducto"].ToString();
                MovimientoAlmacen.DescProveedor = reader["DescProveedor"].ToString();
                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }
    }
}
