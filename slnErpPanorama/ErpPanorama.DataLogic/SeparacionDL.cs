using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class SeparacionDL
    {
        public SeparacionDL() { }

        public void Inserta(SeparacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_Inserta");

            db.AddInParameter(dbCommand, "pIdSeparacion", DbType.Int32, pItem.IdSeparacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFechaSeparacion", DbType.DateTime, pItem.FechaSeparacion);
            db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
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
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public Int32 Inserta_Sep(SeparacionBE pItem)
        {
            int nIdSeparacion = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_Inserta");

            db.AddOutParameter(dbCommand, "pIdSeparacion", DbType.Int32, pItem.IdSeparacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFechaSeparacion", DbType.DateTime, pItem.FechaSeparacion);
            db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
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
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            nIdSeparacion = (int)db.GetParameterValue(dbCommand, "pIdSeparacion");

            return nIdSeparacion;
        }

        public void Actualiza(SeparacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_Actualiza");

            db.AddInParameter(dbCommand, "pIdSeparacion", DbType.Int32, pItem.IdSeparacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFechaSeparacion", DbType.DateTime, pItem.FechaSeparacion);
            db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdCotizacion", DbType.Int32, pItem.IdCotizacion);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(SeparacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_Elimina");

            db.AddInParameter(dbCommand, "pIdSeparacion", DbType.Int32, pItem.IdSeparacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaDocumento(int IdEmpresa, int Periodo, int IdCliente, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaDocumentoVenta(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_EliminaDocumentoVenta");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaCotizacion(int IdCotizacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_EliminaCotizacion");

            db.AddInParameter(dbCommand, "pIdCotizacion", DbType.Int32, IdCotizacion);
            db.ExecuteNonQuery(dbCommand);
        }

        public List<SeparacionBE> ListaTodosActivo(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SeparacionBE> Separacionlist = new List<SeparacionBE>();
            SeparacionBE Separacion;
            while (reader.Read())
            {
                Separacion = new SeparacionBE();
                Separacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Separacion.IdSeparacion = Int32.Parse(reader["IdSeparacion"].ToString());
                Separacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Separacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Separacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Separacion.FechaSeparacion = DateTime.Parse(reader["FechaSeparacion"].ToString());
                Separacion.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                Separacion.Concepto = reader["Concepto"].ToString();
                Separacion.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                Separacion.Importe = Decimal.Parse(reader["Importe"].ToString());
                Separacion.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Separacion.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Separacion.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                Separacion.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                Separacion.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Separacion.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                Separacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Separacionlist.Add(Separacion);
            }
            reader.Close();
            reader.Dispose();
            return Separacionlist;
        }

        public SeparacionBE Selecciona(int IdEmpresa, int IdSeparacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSeparacion", DbType.Int32, IdSeparacion);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            SeparacionBE Separacion = null;
            while (reader.Read())
            {
                Separacion = new SeparacionBE();
                Separacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Separacion.IdSeparacion = Int32.Parse(reader["IdSeparacion"].ToString());
                Separacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Separacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Separacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Separacion.FechaSeparacion = DateTime.Parse(reader["FechaSeparacion"].ToString());
                Separacion.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                Separacion.Concepto = reader["Concepto"].ToString();
                Separacion.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                Separacion.Importe = Decimal.Parse(reader["Importe"].ToString());
                Separacion.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                Separacion.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Separacion.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Separacion.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                Separacion.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                Separacion.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Separacion.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                Separacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return Separacion;
        }

        public SeparacionBE SeleccionaNumeroDocumento(int Periodo, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_SeleccionaNumeroDocumento");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SeparacionBE Separacion = null;
            while (reader.Read())
            {
                Separacion = new SeparacionBE();
                Separacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Separacion.IdSeparacion = Int32.Parse(reader["IdSeparacion"].ToString());
                Separacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Separacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Separacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Separacion.FechaSeparacion = DateTime.Parse(reader["FechaSeparacion"].ToString());
                Separacion.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                Separacion.Concepto = reader["Concepto"].ToString();
                Separacion.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                Separacion.Importe = Decimal.Parse(reader["Importe"].ToString());
                Separacion.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                Separacion.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Separacion.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Separacion.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                Separacion.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                Separacion.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Separacion.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                Separacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Separacion;
        }

        public SeparacionBE SeleccionaDocumentoVenta(int? IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_SeleccionaDocumentoVenta");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SeparacionBE Separacion = null;
            while (reader.Read())
            {
                Separacion = new SeparacionBE();
                Separacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Separacion.IdSeparacion = Int32.Parse(reader["IdSeparacion"].ToString());
                Separacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Separacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Separacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Separacion.FechaSeparacion = DateTime.Parse(reader["FechaSeparacion"].ToString());
                Separacion.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                Separacion.Concepto = reader["Concepto"].ToString();
                Separacion.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                Separacion.Importe = Decimal.Parse(reader["Importe"].ToString());
                Separacion.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                Separacion.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Separacion.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Separacion.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                Separacion.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                Separacion.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Separacion.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                Separacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Separacion;
        }


        public SeparacionBE SeleccionaMovimientoCaja(int? IdMovimientoCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_SeleccionaMovimientoCaja");
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, IdMovimientoCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SeparacionBE Separacion = null;
            while (reader.Read())
            {
                Separacion = new SeparacionBE();
                Separacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Separacion.IdSeparacion = Int32.Parse(reader["IdSeparacion"].ToString());
                Separacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Separacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Separacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Separacion.FechaSeparacion = DateTime.Parse(reader["FechaSeparacion"].ToString());
                Separacion.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                Separacion.Concepto = reader["Concepto"].ToString();
                Separacion.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                Separacion.Importe = Decimal.Parse(reader["Importe"].ToString());
                Separacion.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                Separacion.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Separacion.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Separacion.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                Separacion.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                Separacion.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                Separacion.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Separacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Separacion;
        }

        public List<SeparacionBE> ListaCliente(DateTime FechaDesde, DateTime FechaHasta, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_ListaCliente");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SeparacionBE> Separacionlist = new List<SeparacionBE>();
            SeparacionBE Separacion;
            while (reader.Read())
            {
                Separacion = new SeparacionBE();
                Separacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Separacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Separacion.FechaSeparacion = DateTime.Parse(reader["FechaSeparacion"].ToString());
                Separacion.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                Separacion.Concepto = reader["Concepto"].ToString();
                Separacion.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                Separacion.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Separacion.Cargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                Separacion.Abono = Decimal.Parse(reader["PagoAbono"].ToString());
                Separacion.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                Separacion.Usuario = reader["Usuario"].ToString();
                Separacion.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Separacion.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                Separacion.FlagAuditado = Boolean.Parse(reader["FlagAuditado"].ToString());
                Separacion.Origen = reader["Origen"].ToString();
                Separacionlist.Add(Separacion);
            }
            reader.Close();
            reader.Dispose();
            return Separacionlist;
        }

        public List<SeparacionBE> ListaPedido(int IdEmpresa, int IdPedido, string TipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Separacion_ListaPedido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SeparacionBE> Separacionlist = new List<SeparacionBE>();
            SeparacionBE Separacion;
            while (reader.Read())
            {
                Separacion = new SeparacionBE();
                Separacion.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Separacion.IdSeparacion = Int32.Parse(reader["IdSeparacion"].ToString());
                Separacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Separacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Separacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Separacion.FechaSeparacion = DateTime.Parse(reader["FechaSeparacion"].ToString());
                Separacion.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                Separacion.Concepto = reader["Concepto"].ToString();
                Separacion.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                Separacion.Importe = Decimal.Parse(reader["Importe"].ToString());
                Separacion.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Separacion.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Separacion.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                Separacion.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                Separacion.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Separacion.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                Separacion.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Separacionlist.Add(Separacion);
            }
            reader.Close();
            reader.Dispose();
            return Separacionlist;
        }
    }
}
