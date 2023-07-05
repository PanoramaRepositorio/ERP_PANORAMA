using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class EstadoCuentaDL
    {
        public EstadoCuentaDL() { }

        public void Inserta(EstadoCuentaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_Inserta");

            db.AddInParameter(dbCommand, "pIdEstadoCuenta", DbType.Int32, pItem.IdEstadoCuenta);
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
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdUsuario", DbType.Int32, pItem.IdUsuario);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public Int32 Inserta2(EstadoCuentaBE pItem)
        {
            int nIdEstadoCuenta = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_Inserta");

            db.AddOutParameter(dbCommand, "pIdEstadoCuenta", DbType.Int32, pItem.IdEstadoCuenta);
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
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdUsuario", DbType.Int32, pItem.IdUsuario);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
            nIdEstadoCuenta = (int)db.GetParameterValue(dbCommand, "pIdEstadoCuenta");

            return nIdEstadoCuenta;
        }

        public void Actualiza(EstadoCuentaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_Actualiza");

            db.AddInParameter(dbCommand, "pIdEstadoCuenta", DbType.Int32, pItem.IdEstadoCuenta);
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
            //db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
            //db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EstadoCuentaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_Elimina");

            db.AddInParameter(dbCommand, "pIdEstadoCuenta", DbType.Int32, pItem.IdEstadoCuenta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaDocumento(int IdEmpresa, int Periodo, int IdCliente, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaDocumentoVenta(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_EliminaDocumentoVenta");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaCotizacion(int IdCotizacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_EliminaCotizacion");

            db.AddInParameter(dbCommand, "pIdCotizacion", DbType.Int32, IdCotizacion);
            db.ExecuteNonQuery(dbCommand);
        }

        public List<EstadoCuentaBE> ListaTodosActivo(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaBE> EstadoCuentalist = new List<EstadoCuentaBE>();
            EstadoCuentaBE EstadoCuenta;
            while (reader.Read())
            {
                EstadoCuenta = new EstadoCuentaBE();
                EstadoCuenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuenta.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                EstadoCuenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuenta.Concepto = reader["Concepto"].ToString();
                EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuenta.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuenta.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuenta.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuenta.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuenta.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuenta.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                EstadoCuentalist.Add(EstadoCuenta);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentalist;
        }

        public EstadoCuentaBE Selecciona(int IdEmpresa, int IdEstadoCuenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdEstadoCuenta", DbType.Int32, IdEstadoCuenta);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaBE EstadoCuenta = null;
            while (reader.Read())
            {
                EstadoCuenta = new EstadoCuentaBE();
                EstadoCuenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuenta.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                EstadoCuenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuenta.Concepto = reader["Concepto"].ToString();
                EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuenta.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuenta.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuenta.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuenta.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuenta.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuenta.Observacion = reader["Observacion"].ToString();
                EstadoCuenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuenta;
        }

        public EstadoCuentaBE SeleccionaNumeroDocumento(int Periodo, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_SeleccionaNumeroDocumento");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaBE EstadoCuenta = null;
            while (reader.Read())
            {
                EstadoCuenta = new EstadoCuentaBE();
                EstadoCuenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuenta.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                EstadoCuenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuenta.Concepto = reader["Concepto"].ToString();
                EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuenta.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuenta.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuenta.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuenta.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuenta.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return EstadoCuenta;
        }

        public EstadoCuentaBE SeleccionaMovimientoCaja(int? IdMovimientoCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_SeleccionaMovimientoCaja");
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, IdMovimientoCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaBE EstadoCuenta = null;
            while (reader.Read())
            {
                EstadoCuenta = new EstadoCuentaBE();
                EstadoCuenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuenta.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                EstadoCuenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuenta.Concepto = reader["Concepto"].ToString();
                EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuenta.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuenta.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuenta.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuenta.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuenta.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return EstadoCuenta;
        }

        public EstadoCuentaBE SeleccionaDocumentoVenta(int IdEmpresa, int? IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_SeleccionaDocumentoVenta");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaBE EstadoCuenta = null;
            while (reader.Read())
            {
                EstadoCuenta = new EstadoCuentaBE();
                EstadoCuenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuenta.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                EstadoCuenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuenta.Concepto = reader["Concepto"].ToString();
                EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuenta.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuenta.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuenta.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuenta.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuenta.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return EstadoCuenta;
        }

        public List<EstadoCuentaBE> ListaCliente(DateTime FechaDesde, DateTime FechaHasta, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_ListaCliente");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaBE> EstadoCuentalist = new List<EstadoCuentaBE>();
            EstadoCuentaBE EstadoCuenta;
            while (reader.Read())
            {
                EstadoCuenta = new EstadoCuentaBE();
                EstadoCuenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuenta.Concepto = reader["Concepto"].ToString();
                EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuenta.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                EstadoCuenta.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                EstadoCuenta.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuenta.Usuario = reader["Usuario"].ToString();
                EstadoCuenta.PersonaAprueba = reader["PersonaAprueba"].ToString();
                EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuenta.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuenta.Origen = reader["Origen"].ToString();
                EstadoCuenta.FlagAuditado = Boolean.Parse(reader["FlagAuditado"].ToString());
                EstadoCuentalist.Add(EstadoCuenta);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentalist;
        }

        public List<EstadoCuentaBE> ListaPedido(int IdEmpresa, int IdPedido, string TipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_ListaPedido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaBE> EstadoCuentalist = new List<EstadoCuentaBE>();
            EstadoCuentaBE EstadoCuenta;
            while (reader.Read())
            {
                EstadoCuenta = new EstadoCuentaBE();
                EstadoCuenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuenta.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                EstadoCuenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuenta.Concepto = reader["Concepto"].ToString();
                EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuenta.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuenta.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuenta.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuenta.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuenta.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                EstadoCuentalist.Add(EstadoCuenta);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentalist;
        }

        public List<EstadoCuentaBE> ListaClienteResumen(DateTime FechaDesde, DateTime FechaHasta, int IdEmpresa, int IdTipoCliente, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_ListaClienteResumen");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
           // db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaBE> EstadoCuentalist = new List<EstadoCuentaBE>();
            EstadoCuentaBE EstadoCuenta;
            while (reader.Read())
            {
                EstadoCuenta = new EstadoCuentaBE();
                EstadoCuenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuenta.DescCliente = reader["DescCliente"].ToString();
                //EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuenta.Concepto = reader["Concepto"].ToString();
                //EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                //EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuenta.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuenta.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                EstadoCuenta.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                EstadoCuenta.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuenta.TotalSaldo = Decimal.Parse(reader["TotalSaldo"].ToString());
                EstadoCuenta.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuenta.AbrevClasifica = reader["AbrevClasifica"].ToString();
                EstadoCuenta.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                EstadoCuenta.DescRuta= reader["DescRuta"].ToString();
                EstadoCuenta.DescAsesor= reader["DescAsesor"].ToString();
                EstadoCuenta.NumeroProyecto = reader["NumeroProyecto"].ToString();
                //EstadoCuenta.DescTienda = reader["DescTienda"].ToString();
                EstadoCuenta.Usuario = reader["Usuario"].ToString();
                EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentalist.Add(EstadoCuenta);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentalist;
        }

    }
}

