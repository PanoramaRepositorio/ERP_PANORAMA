using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;
using ErpPanorama.BusinessEntity.Reportes;

namespace ErpPanorama.DataLogic.Reportes
{
  public  class ReporteNotaSalidaDetDL
    {
        public ReporteNotaSalidaDetDL() {   }

        public List<ReporteNotaSalidaDetBE> ListaReporte(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ListaReporte");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteNotaSalidaDetBE> MovimientoAlmacenlist = new List<ReporteNotaSalidaDetBE>();
            ReporteNotaSalidaDetBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new ReporteNotaSalidaDetBE();
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
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.Estado = reader["estado"].ToString();
                MovimientoAlmacen.FlagRevision = Boolean.Parse(reader["FlagRevision"].ToString());
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.FlagRecibidoFisico = Boolean.Parse(reader["FlagRecibidoFisico"].ToString());
                MovimientoAlmacen.FechaDelivery = reader.IsDBNull(reader.GetOrdinal("FechaDelivery")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDelivery"));
                MovimientoAlmacen.FlagDespachado = Boolean.Parse(reader["FlagDespachado"].ToString());
                MovimientoAlmacen.FechaDespachado = reader.IsDBNull(reader.GetOrdinal("FechaDespachado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespachado"));
                MovimientoAlmacen.IdMovimientoAlmacenReferencia = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenReferencia"));
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();
                MovimientoAlmacen.UsuarioRecibidoFisico = reader["UsuarioRecibidoFisico"].ToString();
                MovimientoAlmacen.PersonaPicking = reader["PersonaPicking"].ToString();
                MovimientoAlmacen.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoAlmacen.UsuarioElimina = reader["UsuarioElimina"].ToString();
                MovimientoAlmacen.ObservacionElimina = reader["ObservacionElimina"].ToString();


                MovimientoAlmacen.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoAlmacen.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                MovimientoAlmacen.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacen.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacen.AbreviaturaProd = reader["AbreviaturaProd"].ToString();
                MovimientoAlmacen.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacen.CantidadAnt = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacen.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                MovimientoAlmacen.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
                MovimientoAlmacen.Observacion = reader["Observacion"].ToString();



                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

    }
}
