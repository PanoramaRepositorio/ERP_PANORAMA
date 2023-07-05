using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMovimientoAlmacenDL
    {
        public List<ReporteMovimientoAlmacenBE> Listado(int IdEmpresa, int IdMovimientoAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoAlmacen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdMovimientoAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoAlmacenBE> MovimientoAlmacenlist = new List<ReporteMovimientoAlmacenBE>();
            ReporteMovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new ReporteMovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = Int32.Parse(reader["IdAlmacenDestino"].ToString());
                MovimientoAlmacen.IdMovimientoAlmacenDetalle = Int32.Parse(reader["idMovimientoAlmacenDestino"].ToString());
                MovimientoAlmacen.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoAlmacen.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                MovimientoAlmacen.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacen.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacen.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacen.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacen.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                MovimientoAlmacen.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
                MovimientoAlmacen.IdKardex = Int32.Parse(reader["IdKardex"].ToString());
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }
    }
}
