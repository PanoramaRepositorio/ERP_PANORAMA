using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class TempCheckinoutDL
	{
		public TempCheckinoutDL() { }

		public Int32 Inserta(TempCheckinoutBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TempCheckinout_Inserta");

			db.AddOutParameter(dbCommand, "pIdTempCheckinout", DbType.Int32, pItem.IdTempCheckinout);
			db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
			db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pFechaOriginal", DbType.DateTime, pItem.FechaOriginal);
			db.AddInParameter(dbCommand, "pFechaUpdate", DbType.DateTime, pItem.FechaUpdate);
			db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
			db.AddInParameter(dbCommand, "pUsuarioRegistro", DbType.String, pItem.UsuarioRegistro);
			db.AddInParameter(dbCommand, "pMaquinaRegistro", DbType.String, pItem.MaquinaRegistro);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdTempCheckinout");

			return Id;
		}

		public void Actualiza(TempCheckinoutBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TempCheckinout_Actualiza");

			db.AddInParameter(dbCommand, "pIdTempCheckinout", DbType.Int32, pItem.IdTempCheckinout);
			db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
			db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pFechaOriginal", DbType.DateTime, pItem.FechaOriginal);
			db.AddInParameter(dbCommand, "pFechaUpdate", DbType.DateTime, pItem.FechaUpdate);
			db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
			db.AddInParameter(dbCommand, "pUsuarioRegistro", DbType.String, pItem.UsuarioRegistro);
			db.AddInParameter(dbCommand, "pMaquinaRegistro", DbType.String, pItem.MaquinaRegistro);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(TempCheckinoutBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TempCheckinout_Elimina");

			db.AddInParameter(dbCommand, "pIdTempCheckinout", DbType.Int32, pItem.IdTempCheckinout);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<TempCheckinoutBE> ListaFecha(string Dni, DateTime FechaDesde, DateTime FechaHasta)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TempCheckinout_ListaFecha");
			db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
			List<TempCheckinoutBE> TempCheckinoutlist = new List<TempCheckinoutBE>();
			TempCheckinoutBE TempCheckinout;
			while (reader.Read())
			{
				TempCheckinout = new TempCheckinoutBE();
				TempCheckinout.IdTempCheckinout = Int32.Parse(reader["IdTempCheckinout"].ToString());
				TempCheckinout.IdCheckinout = Int32.Parse(reader["IdCheckinout"].ToString());
				TempCheckinout.Dni = reader["Dni"].ToString();
                TempCheckinout.ApeNom = reader["ApeNom"].ToString();
                TempCheckinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				TempCheckinout.FechaOriginal = DateTime.Parse(reader["FechaOriginal"].ToString());
				TempCheckinout.FechaUpdate = DateTime.Parse(reader["FechaUpdate"].ToString());
				TempCheckinout.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
				TempCheckinout.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
				TempCheckinout.MaquinaRegistro = reader["MaquinaRegistro"].ToString();
				TempCheckinout.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//TempCheckinout.IdTempCheckinout = reader.IsDBNull(reader.GetOrdinal("IdTempCheckinout")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTempCheckinout"));
				TempCheckinoutlist.Add(TempCheckinout);
			}
			reader.Close();
			reader.Dispose();
			return TempCheckinoutlist;
		}

		public TempCheckinoutBE Selecciona(int IdTempCheckinout)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_TempCheckinout_Selecciona");
			db.AddInParameter(dbCommand, "pIdTempCheckinout", DbType.Int32, IdTempCheckinout);

			IDataReader reader = db.ExecuteReader(dbCommand);
			TempCheckinoutBE TempCheckinout = null;
			while (reader.Read())
			{
				TempCheckinout = new TempCheckinoutBE();
				TempCheckinout.IdTempCheckinout = Int32.Parse(reader["IdTempCheckinout"].ToString());
				TempCheckinout.IdCheckinout = Int32.Parse(reader["IdCheckinout"].ToString());
				TempCheckinout.Dni = reader["Dni"].ToString();
				TempCheckinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				TempCheckinout.FechaOriginal = DateTime.Parse(reader["FechaOriginal"].ToString());
				TempCheckinout.FechaUpdate = DateTime.Parse(reader["FechaUpdate"].ToString());
				TempCheckinout.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
				TempCheckinout.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
				TempCheckinout.MaquinaRegistro = reader["MaquinaRegistro"].ToString();
				TempCheckinout.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//TempCheckinout.IdTempCheckinout = reader.IsDBNull(reader.GetOrdinal("IdTempCheckinout")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdTempCheckinout"));
			}
			reader.Close();
			reader.Dispose();
			return TempCheckinout;
		}

	}
}
