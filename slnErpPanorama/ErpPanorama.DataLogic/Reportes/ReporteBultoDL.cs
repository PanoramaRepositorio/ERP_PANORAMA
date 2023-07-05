using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteBultoDL
    {
        public List<ReporteBultoBE> Listado(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaTransferenciaAnaquelesOperadorResumen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteBultoBE> Lista = new List<ReporteBultoBE>();
            ReporteBultoBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteBultoBE();
                Reporte.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Reporte.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Reporte.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Reporte.DescAlmacen = reader["descAlmacen"].ToString();
                Reporte.IdSector = Int32.Parse(reader["idSector"].ToString());
                Reporte.DescSector = reader["descSector"].ToString();
                Reporte.IdBloque = Int32.Parse(reader["idBloque"].ToString());
                Reporte.DescBloque = reader["descBloque"].ToString();
                Reporte.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Reporte.CodigoProveedor = reader["codigoProveedor"].ToString();
                Reporte.NombreProducto = reader["nombreProducto"].ToString();
                Reporte.Abreviatura = reader["abreviatura"].ToString();
                Reporte.NumeroBulto = reader["numeroBulto"].ToString();
                Reporte.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                Reporte.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Reporte.NumeroDocumento = reader["numeroDocumento"].ToString();
                Reporte.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                Reporte.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Reporte.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Reporte.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Reporte.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Reporte.Situacion = reader["situacion"].ToString();
                Reporte.IdKardexBulto = reader.IsDBNull(reader.GetOrdinal("IdKardexBulto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardexBulto"));
                Reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
