using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class AlmacenPisoDL
	{
		public AlmacenPisoDL() { }

		public Int32 Inserta(AlmacenPisoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_AlmacenPiso_Inserta");

			db.AddOutParameter(dbCommand, "pIdAlmacenPiso", DbType.Int32, pItem.IdAlmacenPiso);
			db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
			db.AddInParameter(dbCommand, "pDescAlmacenPiso", DbType.String, pItem.DescAlmacenPiso);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdAlmacenPiso");

			return Id;
		}

		public void Actualiza(AlmacenPisoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_AlmacenPiso_Actualiza");

			db.AddInParameter(dbCommand, "pIdAlmacenPiso", DbType.Int32, pItem.IdAlmacenPiso);
			db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
			db.AddInParameter(dbCommand, "pDescAlmacenPiso", DbType.String, pItem.DescAlmacenPiso);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(AlmacenPisoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_AlmacenPiso_Elimina");

			db.AddInParameter(dbCommand, "pIdAlmacenPiso", DbType.Int32, pItem.IdAlmacenPiso);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<AlmacenPisoBE> ListaTodosActivo(int IdAlmacen)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_AlmacenPiso_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<AlmacenPisoBE> AlmacenPisolist = new List<AlmacenPisoBE>();
			AlmacenPisoBE AlmacenPiso;
			while (reader.Read())
			{
				AlmacenPiso = new AlmacenPisoBE();
				AlmacenPiso.IdAlmacenPiso = Int32.Parse(reader["IdAlmacenPiso"].ToString());
				AlmacenPiso.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                AlmacenPiso.DescAlmacen = reader["DescAlmacen"].ToString();
                AlmacenPiso.DescAlmacenPiso = reader["DescAlmacenPiso"].ToString();
				AlmacenPiso.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//AlmacenPiso.IdAlmacenPiso = reader.IsDBNull(reader.GetOrdinal("IdAlmacenPiso")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenPiso"));
				AlmacenPisolist.Add(AlmacenPiso);
			}
			reader.Close();
			reader.Dispose();
			return AlmacenPisolist;
		}

		public AlmacenPisoBE Selecciona(int IdAlmacenPiso)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_AlmacenPiso_Selecciona");
			db.AddInParameter(dbCommand, "pIdAlmacenPiso", DbType.Int32, IdAlmacenPiso);

			IDataReader reader = db.ExecuteReader(dbCommand);
			AlmacenPisoBE AlmacenPiso = null;
			while (reader.Read())
			{
				AlmacenPiso = new AlmacenPisoBE();
				AlmacenPiso.IdAlmacenPiso = Int32.Parse(reader["IdAlmacenPiso"].ToString());
				AlmacenPiso.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
				AlmacenPiso.DescAlmacenPiso = reader["DescAlmacenPiso"].ToString();
				AlmacenPiso.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//AlmacenPiso.IdAlmacenPiso = reader.IsDBNull(reader.GetOrdinal("IdAlmacenPiso")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenPiso"));
			}
			reader.Close();
			reader.Dispose();
			return AlmacenPiso;
		}

	}
}
