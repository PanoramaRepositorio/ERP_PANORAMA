using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class EstadoCuentaComisionDL
	{
		public EstadoCuentaComisionDL() { }

		public Int32 Inserta(EstadoCuentaComisionBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaComision_Inserta");

			db.AddOutParameter(dbCommand, "pIdEstadoCuentaComision", DbType.Int32, pItem.IdEstadoCuentaComision);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
			db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
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
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdEstadoCuentaComision");

			return Id;
		}

		public void Actualiza(EstadoCuentaComisionBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaComision_Actualiza");

			db.AddInParameter(dbCommand, "pIdEstadoCuentaComision", DbType.Int32, pItem.IdEstadoCuentaComision);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
			db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
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
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(EstadoCuentaComisionBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaComision_Elimina");

			db.AddInParameter(dbCommand, "pIdEstadoCuentaComision", DbType.Int32, pItem.IdEstadoCuentaComision);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public List<EstadoCuentaComisionBE> ListaTodosActivo(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaComision_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaComisionBE> EstadoCuentaComisionlist = new List<EstadoCuentaComisionBE>();
            EstadoCuentaComisionBE EstadoCuentaComision;
            while (reader.Read())
            {
                EstadoCuentaComision = new EstadoCuentaComisionBE();
                EstadoCuentaComision.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaComision.IdEstadoCuentaComision = Int32.Parse(reader["IdEstadoCuentaComision"].ToString());
                EstadoCuentaComision.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaComision.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaComision.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaComision.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaComision.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuentaComision.Concepto = reader["Concepto"].ToString();

                EstadoCuentaComision.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));


                EstadoCuentaComision.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaComision.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaComision.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaComision.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaComision.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuentaComision.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaComision.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaComision.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                EstadoCuentaComisionlist.Add(EstadoCuentaComision);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaComisionlist;
        }

        public EstadoCuentaComisionBE Selecciona(int IdEmpresa, int IdEstadoCuentaComision)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaComision_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaComision", DbType.Int32, IdEstadoCuentaComision);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaComisionBE EstadoCuentaComision = null;
            while (reader.Read())
            {
                EstadoCuentaComision = new EstadoCuentaComisionBE();
                EstadoCuentaComision.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaComision.IdEstadoCuentaComision = Int32.Parse(reader["IdEstadoCuentaComision"].ToString());
                EstadoCuentaComision.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaComision.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaComision.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaComision.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaComision.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuentaComision.Concepto = reader["Concepto"].ToString();
                EstadoCuentaComision.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaComision.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaComision.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaComision.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaComision.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaComision.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaComision.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuentaComision.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaComision.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaComision.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaComision;
        }

        public EstadoCuentaComisionBE SeleccionaNumeroDocumento(int Periodo, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaComision_SeleccionaNumeroDocumento");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaComisionBE EstadoCuentaComision = null;
            while (reader.Read())
            {
                EstadoCuentaComision = new EstadoCuentaComisionBE();
                EstadoCuentaComision.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaComision.IdEstadoCuentaComision = Int32.Parse(reader["IdEstadoCuentaComision"].ToString());
                EstadoCuentaComision.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaComision.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaComision.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaComision.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaComision.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuentaComision.Concepto = reader["Concepto"].ToString();
                EstadoCuentaComision.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaComision.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaComision.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaComision.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaComision.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaComision.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaComision.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuentaComision.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaComision.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaComision.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaComision;
        }

        public EstadoCuentaComisionBE SeleccionaMovimientoCaja(int? IdMovimientoCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaComision_SeleccionaMovimientoCaja");
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, IdMovimientoCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaComisionBE EstadoCuentaComision = null;
            while (reader.Read())
            {
                EstadoCuentaComision = new EstadoCuentaComisionBE();
                EstadoCuentaComision.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaComision.IdEstadoCuentaComision = Int32.Parse(reader["IdEstadoCuentaComision"].ToString());
                EstadoCuentaComision.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaComision.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaComision.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaComision.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaComision.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuentaComision.Concepto = reader["Concepto"].ToString();
                EstadoCuentaComision.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaComision.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaComision.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaComision.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaComision.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaComision.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaComision.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuentaComision.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaComision.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaComision.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaComision;
        }

        public List<EstadoCuentaComisionBE> ListaCliente(DateTime FechaDesde, DateTime FechaHasta, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaComision_ListaCliente");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaComisionBE> EstadoCuentaComisionlist = new List<EstadoCuentaComisionBE>();
            EstadoCuentaComisionBE EstadoCuentaComision;
            while (reader.Read())
            {
                EstadoCuentaComision = new EstadoCuentaComisionBE();
                EstadoCuentaComision.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaComision.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaComision.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaComision.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuentaComision.Concepto = reader["Concepto"].ToString();
                EstadoCuentaComision.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaComision.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaComision.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                EstadoCuentaComision.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                EstadoCuentaComision.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaComisionlist.Add(EstadoCuentaComision);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaComisionlist;
        }

        public List<EstadoCuentaComisionBE> ListaPedido(int IdEmpresa, int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaComision_ListaPedido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaComisionBE> EstadoCuentaComisionlist = new List<EstadoCuentaComisionBE>();
            EstadoCuentaComisionBE EstadoCuentaComision;
            while (reader.Read())
            {
                EstadoCuentaComision = new EstadoCuentaComisionBE();
                EstadoCuentaComision.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaComision.IdEstadoCuentaComision = Int32.Parse(reader["IdEstadoCuentaComision"].ToString());
                EstadoCuentaComision.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaComision.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaComision.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaComision.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaComision.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuentaComision.Concepto = reader["Concepto"].ToString();
                EstadoCuentaComision.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaComision.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaComision.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaComision.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaComision.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                EstadoCuentaComision.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
                EstadoCuentaComision.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                EstadoCuentaComision.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                EstadoCuentaComision.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                EstadoCuentaComisionlist.Add(EstadoCuentaComision);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaComisionlist;
        }


	}
}
