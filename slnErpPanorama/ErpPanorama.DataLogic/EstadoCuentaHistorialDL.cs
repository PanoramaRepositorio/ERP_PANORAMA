using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class EstadoCuentaHistorialDL
    {
        public EstadoCuentaHistorialDL() { }

        public void Inserta(EstadoCuentaHistorialBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaHistorial_Inserta");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaHistorial", DbType.Int32, pItem.IdEstadoCuentaHistorial);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFechaCredito", DbType.DateTime, pItem.FechaCredito);
            db.AddInParameter(dbCommand, "pFechaDeposito", DbType.DateTime, pItem.FechaDeposito);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdCotizacion", DbType.Int32, pItem.IdCotizacion);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pObservacionElimina", DbType.String, pItem.ObservacionElimina);
            db.AddInParameter(dbCommand, "pObservacionOrigen", DbType.String, pItem.ObservacionOrigen);
            db.AddInParameter(dbCommand, "pTipoRegistro", DbType.String, pItem.TipoRegistro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(EstadoCuentaHistorialBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaHistorial_Actualiza");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaHistorial", DbType.Int32, pItem.IdEstadoCuentaHistorial);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFechaCredito", DbType.DateTime, pItem.FechaCredito);
            db.AddInParameter(dbCommand, "pFechaDeposito", DbType.DateTime, pItem.FechaDeposito);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdCotizacion", DbType.Int32, pItem.IdCotizacion);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pObservacionElimina", DbType.String, pItem.ObservacionElimina);
            db.AddInParameter(dbCommand, "pObservacionOrigen", DbType.String, pItem.ObservacionOrigen);
            db.AddInParameter(dbCommand, "pTipoRegistro", DbType.String, pItem.TipoRegistro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EstadoCuentaHistorialBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaHistorial_Elimina");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaHistorial", DbType.Int32, pItem.IdEstadoCuentaHistorial);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<EstadoCuentaHistorialBE> ListaTodosActivo(int IdEmpresa, int IdMotivo, string TipoRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaHistorial_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pTipoRegistro", DbType.String, TipoRegistro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaHistorialBE> EstadoCuentaHistoriallist = new List<EstadoCuentaHistorialBE>();
            EstadoCuentaHistorialBE EstadoCuentaHistorial;
            while (reader.Read())
            {
                EstadoCuentaHistorial = new EstadoCuentaHistorialBE();
                EstadoCuentaHistorial.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaHistorial.IdEstadoCuentaHistorial = Int32.Parse(reader["IdEstadoCuentaHistorial"].ToString());
                EstadoCuentaHistorial.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaHistorial.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaHistorial.NumeroDocumentoCliente = reader["NumeroDocumentoCliente"].ToString();
                EstadoCuentaHistorial.DescCliente = reader["DescCliente"].ToString();
                EstadoCuentaHistorial.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaHistorial.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                EstadoCuentaHistorial.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuentaHistorial.Concepto = reader["Concepto"].ToString();
                EstadoCuentaHistorial.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaHistorial.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaHistorial.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaHistorial.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaHistorial.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaHistorial.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaHistorial.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuentaHistorial.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaHistorial.NumeroPedido = reader["NumeroPedido"].ToString();
                EstadoCuentaHistorial.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaHistorial.Observacion = reader["Observacion"].ToString();
                EstadoCuentaHistorial.ObservacionElimina = reader["ObservacionElimina"].ToString();
                EstadoCuentaHistorial.ObservacionOrigen = reader["ObservacionOrigen"].ToString();
                EstadoCuentaHistorial.FechaElimina = DateTime.Parse(reader["FechaElimina"].ToString());
                EstadoCuentaHistorial.TipoRegistro = reader["TipoRegistro"].ToString();
                EstadoCuentaHistorial.Usuario = reader["Usuario"].ToString();
                EstadoCuentaHistorial.Maquina = reader["Maquina"].ToString();
                EstadoCuentaHistorial.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                EstadoCuentaHistoriallist.Add(EstadoCuentaHistorial);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaHistoriallist;
        }

        public List<EstadoCuentaHistorialBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta, int IdMotivo, string TipoRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaHistorial_ListaFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pTipoRegistro", DbType.String, TipoRegistro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaHistorialBE> EstadoCuentaHistoriallist = new List<EstadoCuentaHistorialBE>();
            EstadoCuentaHistorialBE EstadoCuentaHistorial;
            while (reader.Read())
            {
                EstadoCuentaHistorial = new EstadoCuentaHistorialBE();
                EstadoCuentaHistorial.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaHistorial.IdEstadoCuentaHistorial = Int32.Parse(reader["IdEstadoCuentaHistorial"].ToString());
                EstadoCuentaHistorial.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaHistorial.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaHistorial.NumeroDocumentoCliente = reader["NumeroDocumentoCliente"].ToString();
                EstadoCuentaHistorial.DescCliente = reader["DescCliente"].ToString();
                EstadoCuentaHistorial.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaHistorial.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                EstadoCuentaHistorial.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuentaHistorial.Concepto = reader["Concepto"].ToString();
                EstadoCuentaHistorial.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaHistorial.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaHistorial.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaHistorial.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaHistorial.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaHistorial.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaHistorial.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuentaHistorial.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaHistorial.NumeroPedido = reader["NumeroPedido"].ToString();
                EstadoCuentaHistorial.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaHistorial.Observacion = reader["Observacion"].ToString();
                EstadoCuentaHistorial.ObservacionElimina = reader["ObservacionElimina"].ToString();
                EstadoCuentaHistorial.ObservacionOrigen = reader["ObservacionOrigen"].ToString();
                EstadoCuentaHistorial.FechaElimina = DateTime.Parse(reader["FechaElimina"].ToString());
                EstadoCuentaHistorial.TipoRegistro = reader["TipoRegistro"].ToString();
                EstadoCuentaHistorial.Usuario = reader["Usuario"].ToString();
                EstadoCuentaHistorial.Maquina = reader["Maquina"].ToString();
                EstadoCuentaHistorial.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                EstadoCuentaHistoriallist.Add(EstadoCuentaHistorial);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaHistoriallist;
        }

    }
}
