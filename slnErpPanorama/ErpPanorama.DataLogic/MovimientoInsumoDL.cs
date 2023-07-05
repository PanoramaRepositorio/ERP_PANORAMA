using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class MovimientoInsumoDL
	{
		public MovimientoInsumoDL() { }

		public Int32 Inserta(MovimientoInsumoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoInsumo_Inserta");

			db.AddOutParameter(dbCommand, "pIdMovimientoInsumo", DbType.Int32, pItem.IdMovimientoInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
			db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, pItem.IdTipoMovimiento);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pIdInsumoAlmacenOrigen", DbType.Int32, pItem.IdInsumoAlmacenOrigen);
			db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
			db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
			db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
			db.AddInParameter(dbCommand, "pObservaciones", DbType.String, pItem.Observaciones);
			db.AddInParameter(dbCommand, "pIdInsumoAlmacenDestino", DbType.Int32, pItem.IdInsumoAlmacenDestino);
			db.AddInParameter(dbCommand, "pIdMovimientoInsumoReferencia", DbType.Int32, pItem.IdMovimientoInsumoReferencia);
			db.AddInParameter(dbCommand, "pIdSolicitudInsumo", DbType.Int32, pItem.IdSolicitudInsumo);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pFechaDelivery", DbType.DateTime, pItem.FechaDelivery);
			db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
			db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdMovimientoInsumo");

			return Id;
		}

		public void Actualiza(MovimientoInsumoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoInsumo_Actualiza");

			db.AddInParameter(dbCommand, "pIdMovimientoInsumo", DbType.Int32, pItem.IdMovimientoInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
			db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, pItem.IdTipoMovimiento);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pIdInsumoAlmacenOrigen", DbType.Int32, pItem.IdInsumoAlmacenOrigen);
			db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
			db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
			db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
			db.AddInParameter(dbCommand, "pObservaciones", DbType.String, pItem.Observaciones);
			db.AddInParameter(dbCommand, "pIdInsumoAlmacenDestino", DbType.Int32, pItem.IdInsumoAlmacenDestino);
			db.AddInParameter(dbCommand, "pIdMovimientoInsumoReferencia", DbType.Int32, pItem.IdMovimientoInsumoReferencia);
			db.AddInParameter(dbCommand, "pIdSolicitudInsumo", DbType.Int32, pItem.IdSolicitudInsumo);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pFechaDelivery", DbType.DateTime, pItem.FechaDelivery);
			db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
			db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(MovimientoInsumoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoInsumo_Elimina");

			db.AddInParameter(dbCommand, "pIdMovimientoInsumo", DbType.Int32, pItem.IdMovimientoInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<MovimientoInsumoBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoInsumo_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<MovimientoInsumoBE> MovimientoInsumolist = new List<MovimientoInsumoBE>();
			MovimientoInsumoBE MovimientoInsumo;
			while (reader.Read())
			{
				MovimientoInsumo = new MovimientoInsumoBE();
				MovimientoInsumo.IdMovimientoInsumo = Int32.Parse(reader["IdMovimientoInsumo"].ToString());
				MovimientoInsumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				MovimientoInsumo.Periodo = Int32.Parse(reader["Periodo"].ToString());
				MovimientoInsumo.Numero = reader["Numero"].ToString();
				MovimientoInsumo.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
				MovimientoInsumo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				MovimientoInsumo.IdInsumoAlmacenOrigen = Int32.Parse(reader["IdInsumoAlmacenOrigen"].ToString());
				MovimientoInsumo.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
				MovimientoInsumo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
				MovimientoInsumo.NumeroDocumento = reader["NumeroDocumento"].ToString();
				MovimientoInsumo.Observaciones = reader["Observaciones"].ToString();
				MovimientoInsumo.IdInsumoAlmacenDestino = Int32.Parse(reader["IdInsumoAlmacenDestino"].ToString());
				MovimientoInsumo.IdMovimientoInsumoReferencia = Int32.Parse(reader["IdMovimientoInsumoReferencia"].ToString());
				MovimientoInsumo.IdSolicitudInsumo = Int32.Parse(reader["IdSolicitudInsumo"].ToString());
				MovimientoInsumo.Usuario = reader["Usuario"].ToString();
				MovimientoInsumo.FechaDelivery = DateTime.Parse(reader["FechaDelivery"].ToString());
				MovimientoInsumo.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
				MovimientoInsumo.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
				MovimientoInsumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//MovimientoInsumo.IdMovimientoInsumo = reader.IsDBNull(reader.GetOrdinal("IdMovimientoInsumo")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoInsumo"));
				MovimientoInsumolist.Add(MovimientoInsumo);
			}
			reader.Close();
			reader.Dispose();
			return MovimientoInsumolist;
		}

		public MovimientoInsumoBE Selecciona(int IdMovimientoInsumo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoInsumo_Selecciona");
			db.AddInParameter(dbCommand, "pIdMovimientoInsumo", DbType.Int32, IdMovimientoInsumo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			MovimientoInsumoBE MovimientoInsumo = null;
			while (reader.Read())
			{
				MovimientoInsumo = new MovimientoInsumoBE();
				MovimientoInsumo.IdMovimientoInsumo = Int32.Parse(reader["IdMovimientoInsumo"].ToString());
				MovimientoInsumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				MovimientoInsumo.Periodo = Int32.Parse(reader["Periodo"].ToString());
				MovimientoInsumo.Numero = reader["Numero"].ToString();
				MovimientoInsumo.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
				MovimientoInsumo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				MovimientoInsumo.IdInsumoAlmacenOrigen = Int32.Parse(reader["IdInsumoAlmacenOrigen"].ToString());
				MovimientoInsumo.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
				MovimientoInsumo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
				MovimientoInsumo.NumeroDocumento = reader["NumeroDocumento"].ToString();
				MovimientoInsumo.Observaciones = reader["Observaciones"].ToString();
				MovimientoInsumo.IdInsumoAlmacenDestino = Int32.Parse(reader["IdInsumoAlmacenDestino"].ToString());
				MovimientoInsumo.IdMovimientoInsumoReferencia = Int32.Parse(reader["IdMovimientoInsumoReferencia"].ToString());
				MovimientoInsumo.IdSolicitudInsumo = Int32.Parse(reader["IdSolicitudInsumo"].ToString());
				MovimientoInsumo.Usuario = reader["Usuario"].ToString();
				MovimientoInsumo.FechaDelivery = DateTime.Parse(reader["FechaDelivery"].ToString());
				MovimientoInsumo.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
				MovimientoInsumo.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
				MovimientoInsumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//MovimientoInsumo.IdMovimientoInsumo = reader.IsDBNull(reader.GetOrdinal("IdMovimientoInsumo")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoInsumo"));
			}
			reader.Close();
			reader.Dispose();
			return MovimientoInsumo;
		}

	}
}
