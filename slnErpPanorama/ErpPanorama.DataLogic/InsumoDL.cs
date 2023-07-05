using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class InsumoDL
	{
		public InsumoDL() { }

		public Int32 Inserta(InsumoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Insumo_Inserta");

			db.AddOutParameter(dbCommand, "pIdInsumo", DbType.Int32, pItem.IdInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
			db.AddInParameter(dbCommand, "pIdInsumoClasificacion", DbType.Int32, pItem.IdInsumoClasificacion);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, pItem.CodigoBarra);
			db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);
			db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdInsumo");

			return Id;
		}

		public void Actualiza(InsumoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Insumo_Actualiza");

			db.AddInParameter(dbCommand, "pIdInsumo", DbType.Int32, pItem.IdInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
			db.AddInParameter(dbCommand, "pIdInsumoClasificacion", DbType.Int32, pItem.IdInsumoClasificacion);
			db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
			db.AddInParameter(dbCommand, "pCodigoBarra", DbType.String, pItem.CodigoBarra);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
			db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(InsumoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Insumo_Elimina");

			db.AddInParameter(dbCommand, "pIdInsumo", DbType.Int32, pItem.IdInsumo);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<InsumoBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Insumo_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<InsumoBE> Insumolist = new List<InsumoBE>();
			InsumoBE Insumo;
			while (reader.Read())
			{
				Insumo = new InsumoBE();
				Insumo.IdInsumo = Int32.Parse(reader["IdInsumo"].ToString());
				Insumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
				Insumo.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                Insumo.Abreviatura = reader["Abreviatura"].ToString();
                Insumo.IdInsumoClasificacion = Int32.Parse(reader["IdInsumoClasificacion"].ToString());
                Insumo.DescInsumoClasificacion = reader["DescInsumoClasificacion"].ToString();
                Insumo.Descripcion = reader["Descripcion"].ToString();
				Insumo.CodigoBarra = reader["CodigoBarra"].ToString();
				//Insumo.Imagen = (byte[])reader["Imagen"];
                Insumo.Observacion = reader["Observacion"].ToString();
				Insumo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
				Insumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//Insumo.IdInsumo = reader.IsDBNull(reader.GetOrdinal("IdInsumo")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdInsumo"));
				Insumolist.Add(Insumo);
			}
			reader.Close();
			reader.Dispose();
			return Insumolist;
		}

        public List<InsumoBE> ListaTodosInActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Insumo_ListaTodosInActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InsumoBE> Insumolist = new List<InsumoBE>();
            InsumoBE Insumo;
            while (reader.Read())
            {
                Insumo = new InsumoBE();
                Insumo.IdInsumo = Int32.Parse(reader["IdInsumo"].ToString());
                Insumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Insumo.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                Insumo.Abreviatura = reader["Abreviatura"].ToString();
                Insumo.IdInsumoClasificacion = Int32.Parse(reader["IdInsumoClasificacion"].ToString());
                Insumo.DescInsumoClasificacion = reader["DescInsumoClasificacion"].ToString();
                Insumo.Descripcion = reader["Descripcion"].ToString();
                Insumo.CodigoBarra = reader["CodigoBarra"].ToString();
                //Insumo.Imagen = (byte[])reader["Imagen"];
                Insumo.Observacion = reader["Observacion"].ToString();
                Insumo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Insumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //Insumo.IdInsumo = reader.IsDBNull(reader.GetOrdinal("IdInsumo")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdInsumo"));
                Insumolist.Add(Insumo);
            }
            reader.Close();
            reader.Dispose();
            return Insumolist;
        }

        public InsumoBE Selecciona(int IdInsumo)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_Insumo_Selecciona");
			db.AddInParameter(dbCommand, "pIdInsumo", DbType.Int32, IdInsumo);

			IDataReader reader = db.ExecuteReader(dbCommand);
			InsumoBE Insumo = null;
			while (reader.Read())
			{
				Insumo = new InsumoBE();
                Insumo.IdInsumo = Int32.Parse(reader["IdInsumo"].ToString());
                Insumo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Insumo.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                Insumo.Abreviatura = reader["Abreviatura"].ToString();
                Insumo.IdInsumoClasificacion = Int32.Parse(reader["IdInsumoClasificacion"].ToString());
                Insumo.DescInsumoClasificacion = reader["DescInsumoClasificacion"].ToString();
                Insumo.Descripcion = reader["Descripcion"].ToString();
                Insumo.CodigoBarra = reader["CodigoBarra"].ToString();
                Insumo.Imagen = (byte[])reader["Imagen"];
                Insumo.Observacion = reader["Observacion"].ToString();
                Insumo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Insumo.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //Insumo.IdInsumo = reader.IsDBNull(reader.GetOrdinal("IdInsumo")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdInsumo"));
            }
			reader.Close();
			reader.Dispose();
			return Insumo;
		}

	}
}
