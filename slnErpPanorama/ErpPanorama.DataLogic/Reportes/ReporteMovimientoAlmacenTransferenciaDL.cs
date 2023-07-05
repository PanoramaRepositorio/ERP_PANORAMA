using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMovimientoAlmacenTransferenciaDL
    {
        public List<ReporteMovimientoAlmacenTransferenciaBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int IdAlmacenOrigen, int IdAlmacenDestino, bool FlagRecibido, int IdMotivo, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoAlmacenTransferencia");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdAlmacenDestino", DbType.Int32, IdAlmacenDestino);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, FlagRecibido);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            dbCommand.CommandTimeout = 250;
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoAlmacenTransferenciaBE> MovimientoAlmacenlist = new List<ReporteMovimientoAlmacenTransferenciaBE>();
            ReporteMovimientoAlmacenTransferenciaBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new ReporteMovimientoAlmacenTransferenciaBE();
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();
                MovimientoAlmacen.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                MovimientoAlmacen.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacen.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacen.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacen.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public List<ReporteMovimientoAlmacenTransferenciaBE> ListadoResumen(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int IdAlmacenOrigen, int IdAlmacenDestino, bool FlagRecibido, int IdMotivo, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoAlmacenTransferencia");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdAlmacenDestino", DbType.Int32, IdAlmacenDestino);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, FlagRecibido);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoAlmacenTransferenciaBE> MovimientoAlmacenlist = new List<ReporteMovimientoAlmacenTransferenciaBE>();
            ReporteMovimientoAlmacenTransferenciaBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new ReporteMovimientoAlmacenTransferenciaBE();
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                MovimientoAlmacen.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacen.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacen.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacen.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }


    }
}
