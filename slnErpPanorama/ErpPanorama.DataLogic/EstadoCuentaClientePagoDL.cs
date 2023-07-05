using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class EstadoCuentaClientePagoDL
	{
		public EstadoCuentaClientePagoDL() { }

		public Int32 Inserta(EstadoCuentaClientePagoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_Inserta");

			db.AddOutParameter(dbCommand, "pIdEstadoCuentaClientePago", DbType.Int32, pItem.IdEstadoCuentaClientePago);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
			db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
			db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
			db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
			db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
			db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
			db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
			db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
			db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pUsuarioRegistro", DbType.String, pItem.UsuarioRegistro);
			db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pSaldo", DbType.Decimal, pItem.Saldo);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente ", DbType.Int32, pItem.IdEstadoCuentaCliente);
            db.AddInParameter(dbCommand, "pGrupoPago", DbType.String, pItem.GrupoPago);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdEstadoCuentaClientePago");

			return Id;
		}

		public void Actualiza(EstadoCuentaClientePagoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_Actualiza");

			db.AddInParameter(dbCommand, "pIdEstadoCuentaClientePago", DbType.Int32, pItem.IdEstadoCuentaClientePago);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
			db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
			db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
			db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
			db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
			db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
			db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
			db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
			db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
			db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
			db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pUsuarioRegistro", DbType.String, pItem.UsuarioRegistro);
			db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pSaldo", DbType.Decimal, pItem.Saldo);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente ", DbType.Int32, pItem.IdEstadoCuentaCliente);
            db.AddInParameter(dbCommand, "pGrupoPago", DbType.String, pItem.GrupoPago);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public void ActualizaSaldo(int IdEstadoCuentaClientePago, decimal Saldo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_ActualizaSaldo");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaClientePago", DbType.Int32, IdEstadoCuentaClientePago);
            db.AddInParameter(dbCommand, "pSaldo", DbType.Decimal, Saldo);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EstadoCuentaClientePagoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_Elimina");

			db.AddInParameter(dbCommand, "pIdEstadoCuentaClientePago", DbType.Int32, pItem.IdEstadoCuentaClientePago);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public Int32 EliminaCompensado(EstadoCuentaClientePagoBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_EliminaCompensado");

            db.AddOutParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, pItem.IdEstadoCuentaCliente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pGrupoPago", DbType.String, pItem.GrupoPago);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
            Id = (int)db.GetParameterValue(dbCommand, "pIdEstadoCuentaCliente");

            return Id;
        }

        public List<EstadoCuentaClientePagoBE> ListaTodosActivo(int IdEmpresa, int IdCliente, string TipoMovimiento, int IdSituacion)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<EstadoCuentaClientePagoBE> EstadoCuentaClientePagolist = new List<EstadoCuentaClientePagoBE>();
			EstadoCuentaClientePagoBE EstadoCuentaClientePago;
			while (reader.Read())
			{
				EstadoCuentaClientePago = new EstadoCuentaClientePagoBE();
				EstadoCuentaClientePago.IdEstadoCuentaClientePago = Int32.Parse(reader["IdEstadoCuentaClientePago"].ToString());
				EstadoCuentaClientePago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				EstadoCuentaClientePago.Periodo = Int32.Parse(reader["Periodo"].ToString());
				EstadoCuentaClientePago.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaClientePago.DescCliente = reader["DescCliente"].ToString();
                EstadoCuentaClientePago.NumeroDocumento = reader["NumeroDocumento"].ToString();
				EstadoCuentaClientePago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				EstadoCuentaClientePago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaClientePago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaClientePago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaClientePago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaClientePago.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaClientePago.Importe = Decimal.Parse(reader["Importe"].ToString());
				EstadoCuentaClientePago.TipoMovimiento = reader["TipoMovimiento"].ToString();
				EstadoCuentaClientePago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaClientePago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaClientePago.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaClientePago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaClientePago.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaClientePago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaClientePago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaClientePago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaClientePago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
				EstadoCuentaClientePago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
				EstadoCuentaClientePago.Observacion = reader["Observacion"].ToString();
				EstadoCuentaClientePago.Saldo = Decimal.Parse(reader["Saldo"].ToString());

                EstadoCuentaClientePago.IdEstadoCuentaCliente = Int32.Parse(reader["IdEstadoCuentaCliente"].ToString());
                EstadoCuentaClientePago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaClientePago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				EstadoCuentaClientePagolist.Add(EstadoCuentaClientePago);
			}
			reader.Close();
			reader.Dispose();
			return EstadoCuentaClientePagolist;
		}

        public List<EstadoCuentaClientePagoBE> ListaPagado(int IdEmpresa, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_ListaPagado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaClientePagoBE> EstadoCuentaClientePagolist = new List<EstadoCuentaClientePagoBE>();
            EstadoCuentaClientePagoBE EstadoCuentaClientePago;
            while (reader.Read())
            {
                EstadoCuentaClientePago = new EstadoCuentaClientePagoBE();
                EstadoCuentaClientePago.IdEstadoCuentaClientePago = Int32.Parse(reader["IdEstadoCuentaClientePago"].ToString());
                EstadoCuentaClientePago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaClientePago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaClientePago.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaClientePago.DescCliente = reader["DescCliente"].ToString();
                EstadoCuentaClientePago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaClientePago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaClientePago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaClientePago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaClientePago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaClientePago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaClientePago.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaClientePago.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaClientePago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaClientePago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaClientePago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaClientePago.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaClientePago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaClientePago.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaClientePago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaClientePago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaClientePago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaClientePago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaClientePago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaClientePago.Observacion = reader["Observacion"].ToString();
                EstadoCuentaClientePago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaClientePago.FechaRegistroPago = reader.IsDBNull(reader.GetOrdinal("FechaRegistroPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistroPago"));
                EstadoCuentaClientePago.IdEstadoCuentaCliente = Int32.Parse(reader["IdEstadoCuentaCliente"].ToString());
                EstadoCuentaClientePago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaClientePago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

                EstadoCuentaClientePagolist.Add(EstadoCuentaClientePago);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaClientePagolist;
        }

        public List<EstadoCuentaClientePagoBE> ListaHistorial(int IdEmpresa, int IdEstadoCuentaCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_ListaHistorial");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, IdEstadoCuentaCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaClientePagoBE> EstadoCuentaClientePagolist = new List<EstadoCuentaClientePagoBE>();
            EstadoCuentaClientePagoBE EstadoCuentaClientePago;
            while (reader.Read())
            {
                EstadoCuentaClientePago = new EstadoCuentaClientePagoBE();
                EstadoCuentaClientePago.IdEstadoCuentaClientePago = Int32.Parse(reader["IdEstadoCuentaClientePago"].ToString());
                EstadoCuentaClientePago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaClientePago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaClientePago.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaClientePago.DescCliente = reader["DescCliente"].ToString();
                EstadoCuentaClientePago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaClientePago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaClientePago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaClientePago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaClientePago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaClientePago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaClientePago.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaClientePago.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaClientePago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaClientePago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaClientePago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaClientePago.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaClientePago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaClientePago.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaClientePago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaClientePago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaClientePago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaClientePago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaClientePago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaClientePago.Observacion = reader["Observacion"].ToString();
                EstadoCuentaClientePago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaClientePago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaClientePago.IdEstadoCuentaCliente = Int32.Parse(reader["IdEstadoCuentaCliente"].ToString());
                EstadoCuentaClientePago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaClientePago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

                EstadoCuentaClientePagolist.Add(EstadoCuentaClientePago);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaClientePagolist;
        }

        public EstadoCuentaClientePagoBE Selecciona(int IdEstadoCuentaClientePago)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_Selecciona");
			db.AddInParameter(dbCommand, "pIdEstadoCuentaClientePago", DbType.Int32, IdEstadoCuentaClientePago);

			IDataReader reader = db.ExecuteReader(dbCommand);
			EstadoCuentaClientePagoBE EstadoCuentaClientePago = null;
			while (reader.Read())
			{
				EstadoCuentaClientePago = new EstadoCuentaClientePagoBE();
                EstadoCuentaClientePago.IdEstadoCuentaClientePago = Int32.Parse(reader["IdEstadoCuentaClientePago"].ToString());
                EstadoCuentaClientePago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaClientePago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaClientePago.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaClientePago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaClientePago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaClientePago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaClientePago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaClientePago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaClientePago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaClientePago.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaClientePago.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaClientePago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaClientePago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaClientePago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaClientePago.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaClientePago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaClientePago.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaClientePago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaClientePago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaClientePago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaClientePago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaClientePago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaClientePago.Observacion = reader["Observacion"].ToString();
                EstadoCuentaClientePago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaClientePago.IdEstadoCuentaCliente = Int32.Parse(reader["IdEstadoCuentaCliente"].ToString());
                EstadoCuentaClientePago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaClientePago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return EstadoCuentaClientePago;
		}

        public EstadoCuentaClientePagoBE SeleccionaMovimientoCaja(int? IdMovimientoCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_SeleccionaMovimientoCaja");
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, IdMovimientoCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaClientePagoBE EstadoCuentaClientePago = null;
            while (reader.Read())
            {
                EstadoCuentaClientePago = new EstadoCuentaClientePagoBE();
                EstadoCuentaClientePago.IdEstadoCuentaClientePago = Int32.Parse(reader["IdEstadoCuentaClientePago"].ToString());
                EstadoCuentaClientePago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaClientePago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaClientePago.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaClientePago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaClientePago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaClientePago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaClientePago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaClientePago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaClientePago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaClientePago.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaClientePago.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaClientePago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaClientePago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaClientePago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaClientePago.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaClientePago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaClientePago.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaClientePago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaClientePago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaClientePago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaClientePago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaClientePago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaClientePago.Observacion = reader["Observacion"].ToString();
                EstadoCuentaClientePago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaClientePago.IdEstadoCuentaCliente = Int32.Parse(reader["IdEstadoCuentaCliente"].ToString());
                EstadoCuentaClientePago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaClientePago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaClientePago;
        }

        public EstadoCuentaClientePagoBE SeleccionaUltimo(int IdCliente, int IdEstadoCuentaCliente, string TipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaClientePago_SeleccionaUltimo");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, IdEstadoCuentaCliente);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaClientePagoBE EstadoCuentaClientePago = null;
            while (reader.Read())
            {
                EstadoCuentaClientePago = new EstadoCuentaClientePagoBE();
                EstadoCuentaClientePago.IdEstadoCuentaClientePago = Int32.Parse(reader["IdEstadoCuentaClientePago"].ToString());
                EstadoCuentaClientePago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaClientePago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaClientePago.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaClientePago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaClientePago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaClientePago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaClientePago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaClientePago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaClientePago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaClientePago.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaClientePago.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaClientePago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaClientePago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaClientePago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaClientePago.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaClientePago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaClientePago.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaClientePago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaClientePago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaClientePago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaClientePago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaClientePago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaClientePago.Observacion = reader["Observacion"].ToString();
                EstadoCuentaClientePago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaClientePago.IdEstadoCuentaCliente = Int32.Parse(reader["IdEstadoCuentaCliente"].ToString());
                EstadoCuentaClientePago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaClientePago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaClientePago;
        }


    }
}
