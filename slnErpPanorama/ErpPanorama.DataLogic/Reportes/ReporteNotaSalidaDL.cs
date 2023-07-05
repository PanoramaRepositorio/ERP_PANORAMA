using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteNotaSalidaDL
    {
        public ReporteNotaSalidaDL() { }

        public List<ReporteNotaSalidaBE> Listado(int IdEmpresa, int IdMovimientoAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMovimientoAlmacen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdMovimientoAlmacen);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteNotaSalidaBE> MovimientoAlmacenlist = new List<ReporteNotaSalidaBE>();
            ReporteNotaSalidaBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new ReporteNotaSalidaBE();
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["IdMovimientoAlmacen"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoAlmacen.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacen.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacen.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacen.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacen.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                MovimientoAlmacen.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
                MovimientoAlmacen.UbicacionUcayali = reader["UbicacionUcayali"].ToString();
                MovimientoAlmacen.UbicacionAndahuaylas = reader["UbicacionAndahuaylas"].ToString();
                MovimientoAlmacen.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoAlmacen.FechaDelivery = DateTime.Parse(reader["FechaDelivery"].ToString());
                MovimientoAlmacen.Bultos = Int32.Parse(reader["Bultos"].ToString());
                MovimientoAlmacen.UsuarioUpdBultos = reader["UsuarioUpdBultos"].ToString();
                
                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }
    }
}
