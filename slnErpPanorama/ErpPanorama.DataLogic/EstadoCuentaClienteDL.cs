using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class EstadoCuentaClienteDL
	{
		public EstadoCuentaClienteDL() { }

		public Int32 Inserta(EstadoCuentaClienteBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaCliente_Inserta");

			db.AddOutParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, pItem.IdEstadoCuentaCliente);
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
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdEstadoCuentaCliente");

			return Id;
		}

		public void Actualiza(EstadoCuentaClienteBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaCliente_Actualiza");

			db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, pItem.IdEstadoCuentaCliente);
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
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public void ActualizaSaldo(int IdEstadoCuentaCliente, decimal Saldo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaCliente_ActualizaSaldo");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, IdEstadoCuentaCliente);
            db.AddInParameter(dbCommand, "pSaldo", DbType.Decimal, Saldo);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EstadoCuentaClienteBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaCliente_Elimina");

			db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, pItem.IdEstadoCuentaCliente);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public void EliminaDocumentoVenta(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaCliente_EliminaDocumentoVenta");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.ExecuteNonQuery(dbCommand);
        }

        public List<EstadoCuentaClienteBE> ListaTodosActivo(int IdEmpresa, int IdCliente, string TipoMovimiento, int IdSituacion)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaCliente_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<EstadoCuentaClienteBE> EstadoCuentaClientelist = new List<EstadoCuentaClienteBE>();
			EstadoCuentaClienteBE EstadoCuentaCliente;
			while (reader.Read())
			{
				EstadoCuentaCliente = new EstadoCuentaClienteBE();
				EstadoCuentaCliente.IdEstadoCuentaCliente = Int32.Parse(reader["IdEstadoCuentaCliente"].ToString());
				EstadoCuentaCliente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				EstadoCuentaCliente.Periodo = Int32.Parse(reader["Periodo"].ToString());
				EstadoCuentaCliente.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaCliente.DescCliente = reader["DescCliente"].ToString();
                EstadoCuentaCliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
				EstadoCuentaCliente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				EstadoCuentaCliente.Concepto = reader["Concepto"].ToString();
                EstadoCuentaCliente.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaCliente.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaCliente.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaCliente.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaCliente.Importe = Decimal.Parse(reader["Importe"].ToString());
				EstadoCuentaCliente.TipoMovimiento = reader["TipoMovimiento"].ToString();
				EstadoCuentaCliente.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaCliente.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaCliente.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaCliente.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaCliente.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaCliente.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaCliente.IdPersona = reader.IsDBNull(reader.GetOrdinal("IdPersona")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPersona"));
                EstadoCuentaCliente.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaCliente.PersonaAprueba= reader["PersonaAprueba"].ToString();
                EstadoCuentaCliente.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
				EstadoCuentaCliente.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
				EstadoCuentaCliente.Observacion = reader["Observacion"].ToString();
				EstadoCuentaCliente.Saldo = Decimal.Parse(reader["Saldo"].ToString());
				EstadoCuentaCliente.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				
				EstadoCuentaClientelist.Add(EstadoCuentaCliente);
			}
			reader.Close();
			reader.Dispose();
			return EstadoCuentaClientelist;
		}

        public List<EstadoCuentaClienteBE> ListaPagado(int IdEmpresa, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaCliente_ListaPagado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaClienteBE> EstadoCuentaClientelist = new List<EstadoCuentaClienteBE>();
            EstadoCuentaClienteBE EstadoCuentaCliente;
            while (reader.Read())
            {
                EstadoCuentaCliente = new EstadoCuentaClienteBE();
                EstadoCuentaCliente.IdEstadoCuentaCliente = Int32.Parse(reader["IdEstadoCuentaCliente"].ToString());
                EstadoCuentaCliente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaCliente.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaCliente.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaCliente.DescCliente = reader["DescCliente"].ToString();
                EstadoCuentaCliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaCliente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaCliente.Concepto = reader["Concepto"].ToString();
                EstadoCuentaCliente.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaCliente.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaCliente.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaCliente.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaCliente.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaCliente.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaCliente.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaCliente.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaCliente.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaCliente.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaCliente.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaCliente.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaCliente.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaCliente.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaCliente.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaCliente.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaCliente.Observacion = reader["Observacion"].ToString();
                EstadoCuentaCliente.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaCliente.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaCliente.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

                EstadoCuentaClientelist.Add(EstadoCuentaCliente);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaClientelist;
        }

        public EstadoCuentaClienteBE Selecciona(int IdEstadoCuentaCliente)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaCliente_Selecciona");
			db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, IdEstadoCuentaCliente);

			IDataReader reader = db.ExecuteReader(dbCommand);
			EstadoCuentaClienteBE EstadoCuentaCliente = null;
			while (reader.Read())
			{
				EstadoCuentaCliente = new EstadoCuentaClienteBE();
                EstadoCuentaCliente.IdEstadoCuentaCliente = Int32.Parse(reader["IdEstadoCuentaCliente"].ToString());
                EstadoCuentaCliente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaCliente.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaCliente.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaCliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaCliente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaCliente.Concepto = reader["Concepto"].ToString();
                EstadoCuentaCliente.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaCliente.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaCliente.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaCliente.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaCliente.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaCliente.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaCliente.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaCliente.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaCliente.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaCliente.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaCliente.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaCliente.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaCliente.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaCliente.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaCliente.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaCliente.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaCliente.Observacion = reader["Observacion"].ToString();
                EstadoCuentaCliente.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaCliente.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return EstadoCuentaCliente;
		}

        public EstadoCuentaClienteBE SeleccionaMovimientoCaja(int? IdMovimientoCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaCliente_SeleccionaMovimientoCaja");
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, IdMovimientoCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaClienteBE EstadoCuentaCliente = null;
            while (reader.Read())
            {
                EstadoCuentaCliente = new EstadoCuentaClienteBE();
                EstadoCuentaCliente.IdEstadoCuentaCliente = Int32.Parse(reader["IdEstadoCuentaCliente"].ToString());
                EstadoCuentaCliente.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaCliente.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaCliente.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaCliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaCliente.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaCliente.Concepto = reader["Concepto"].ToString();
                EstadoCuentaCliente.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaCliente.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaCliente.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaCliente.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaCliente.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaCliente.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaCliente.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaCliente.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaCliente.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaCliente.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaCliente.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaCliente.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaCliente.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaCliente.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaCliente.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaCliente.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaCliente.Observacion = reader["Observacion"].ToString();
                EstadoCuentaCliente.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaCliente.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaCliente;
        }

    }
}
