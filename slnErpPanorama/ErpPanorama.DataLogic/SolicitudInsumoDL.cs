using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class SolicitudInsumoDL
	{
		public SolicitudInsumoDL() { }

		public Int32 Inserta(SolicitudInsumoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudInsumo_Inserta");

			db.AddOutParameter(dbCommand, "pIdSolicitudInsumo", DbType.Int32, pItem.IdSolicitudInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
			db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
			db.AddInParameter(dbCommand, "pFechaSolicitud", DbType.DateTime, pItem.FechaSolicitud);
			db.AddInParameter(dbCommand, "pIdInsumoAlmacenOrigen", DbType.Int32, pItem.IdInsumoAlmacenOrigen);
			db.AddInParameter(dbCommand, "pIdInsumoAlmacenDestino", DbType.Int32, pItem.IdInsumoAlmacenDestino);
			db.AddInParameter(dbCommand, "pIdSolicitante", DbType.Int32, pItem.IdSolicitante);
			db.AddInParameter(dbCommand, "pFlagEnviado", DbType.Boolean, pItem.FlagEnviado);
			db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
			db.AddInParameter(dbCommand, "pFechaDelivery", DbType.DateTime, pItem.FechaDelivery);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdSolicitudInsumo");

			return Id;
		}

		public void Actualiza(SolicitudInsumoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudInsumo_Actualiza");

			db.AddInParameter(dbCommand, "pIdSolicitudInsumo", DbType.Int32, pItem.IdSolicitudInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
			db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
			db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
			db.AddInParameter(dbCommand, "pFechaSolicitud", DbType.DateTime, pItem.FechaSolicitud);
			db.AddInParameter(dbCommand, "pIdInsumoAlmacenOrigen", DbType.Int32, pItem.IdInsumoAlmacenOrigen);
			db.AddInParameter(dbCommand, "pIdInsumoAlmacenDestino", DbType.Int32, pItem.IdInsumoAlmacenDestino);
			db.AddInParameter(dbCommand, "pIdSolicitante", DbType.Int32, pItem.IdSolicitante);
			db.AddInParameter(dbCommand, "pFlagEnviado", DbType.Boolean, pItem.FlagEnviado);
			db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
			db.AddInParameter(dbCommand, "pFechaDelivery", DbType.DateTime, pItem.FechaDelivery);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(SolicitudInsumoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudInsumo_Elimina");

			db.AddInParameter(dbCommand, "pIdSolicitudInsumo", DbType.Int32, pItem.IdSolicitudInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<SolicitudInsumoBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudInsumo_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<SolicitudInsumoBE> SolicitudInsumolist = new List<SolicitudInsumoBE>();
			SolicitudInsumoBE SolicitudInsumo;
			while (reader.Read())
			{
				SolicitudInsumo = new SolicitudInsumoBE();
				SolicitudInsumo.IdSolicitudInsumo = Int32.Parse(reader["IdSolicitudInsumo"].ToString());
				SolicitudInsumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				SolicitudInsumo.Periodo = Int32.Parse(reader["Periodo"].ToString());
				SolicitudInsumo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudInsumo.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudInsumo.Numero = reader["Numero"].ToString();
				SolicitudInsumo.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
				SolicitudInsumo.IdInsumoAlmacenOrigen = Int32.Parse(reader["IdInsumoAlmacenOrigen"].ToString());
                SolicitudInsumo.DescInsumoAlmacen = reader["DescInsumoAlmacen"].ToString();
                SolicitudInsumo.IdInsumoAlmacenDestino = Int32.Parse(reader["IdInsumoAlmacenDestino"].ToString());
                SolicitudInsumo.DescInsumoAlmacenDestino = reader["DescInsumoAlmacenDestino"].ToString();
                SolicitudInsumo.IdSolicitante = Int32.Parse(reader["IdSolicitante"].ToString());
                SolicitudInsumo.Solicitante = reader["Solicitante"].ToString();
                SolicitudInsumo.FlagEnviado = Boolean.Parse(reader["FlagEnviado"].ToString());
				SolicitudInsumo.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
				SolicitudInsumo.FechaDelivery = DateTime.Parse(reader["FechaDelivery"].ToString());
				SolicitudInsumo.Observacion = reader["Observacion"].ToString();
				SolicitudInsumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				SolicitudInsumolist.Add(SolicitudInsumo);
			}
			reader.Close();
			reader.Dispose();
			return SolicitudInsumolist;
		}

		public SolicitudInsumoBE Selecciona(int IdSolicitudInsumo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudInsumo_Selecciona");
			db.AddInParameter(dbCommand, "pIdSolicitudInsumo", DbType.Int32, IdSolicitudInsumo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			SolicitudInsumoBE SolicitudInsumo = null;
			while (reader.Read())
			{
				SolicitudInsumo = new SolicitudInsumoBE();
                SolicitudInsumo.IdSolicitudInsumo = Int32.Parse(reader["IdSolicitudInsumo"].ToString());
                SolicitudInsumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SolicitudInsumo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                SolicitudInsumo.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudInsumo.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudInsumo.Numero = reader["Numero"].ToString();
                SolicitudInsumo.FechaSolicitud = DateTime.Parse(reader["FechaSolicitud"].ToString());
                SolicitudInsumo.IdInsumoAlmacenOrigen = Int32.Parse(reader["IdInsumoAlmacenOrigen"].ToString());
                SolicitudInsumo.DescInsumoAlmacen = reader["DescInsumoAlmacen"].ToString();
                SolicitudInsumo.IdInsumoAlmacenDestino = Int32.Parse(reader["IdInsumoAlmacenDestino"].ToString());
                SolicitudInsumo.DescInsumoAlmacenDestino = reader["DescInsumoAlmacenDestino"].ToString();
                SolicitudInsumo.IdSolicitante = Int32.Parse(reader["IdSolicitante"].ToString());
                SolicitudInsumo.Solicitante = reader["Solicitante"].ToString();
                SolicitudInsumo.FlagEnviado = Boolean.Parse(reader["FlagEnviado"].ToString());
                SolicitudInsumo.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                SolicitudInsumo.FechaDelivery = DateTime.Parse(reader["FechaDelivery"].ToString());
                SolicitudInsumo.Observacion = reader["Observacion"].ToString();
                SolicitudInsumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return SolicitudInsumo;
		}

	}
}
