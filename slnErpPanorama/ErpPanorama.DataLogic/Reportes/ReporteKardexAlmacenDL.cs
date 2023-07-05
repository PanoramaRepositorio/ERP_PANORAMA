using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteKardexAlmacenDL
    {
        public List<ReporteKardexAlmacenBE> Listado(int IdEmpresa, int IdAlmacen, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Kardex_rptInventarioDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteKardexAlmacenBE> KardexAlmacenlist = new List<ReporteKardexAlmacenBE>();
            ReporteKardexAlmacenBE KardexAlmacen;
            while (reader.Read())
            {
                KardexAlmacen = new ReporteKardexAlmacenBE();
                KardexAlmacen.Id = Int32.Parse(reader["Id"].ToString());
                KardexAlmacen.IdKardex = Int32.Parse(reader["IdKardex"].ToString());
                KardexAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                KardexAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                KardexAlmacen.DescTienda = reader["CodTipoDocumento"].ToString();
                KardexAlmacen.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                KardexAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                KardexAlmacen.CodigoProveedor = reader["CodigoProveedor"].ToString();
                KardexAlmacen.NombreProducto = reader["NombreProducto"].ToString();
                KardexAlmacen.Abreviatura = reader["Abreviatura"].ToString();
                KardexAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                KardexAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                KardexAlmacen.TipoMovimiento = reader["TipoMovimiento"].ToString();
                KardexAlmacen.Observacion = reader["Observacion"].ToString();
                KardexAlmacen.Ingresos = Int32.Parse(reader["Ingresos"].ToString());
                KardexAlmacen.Salidas = Int32.Parse(reader["Salidas"].ToString());
                KardexAlmacen.Stock = Int32.Parse(reader["Stock"].ToString());
                KardexAlmacen.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                KardexAlmacen.Usuario = reader["Usuario"].ToString();
                KardexAlmacenlist.Add(KardexAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return KardexAlmacenlist;
        }
    }
}
