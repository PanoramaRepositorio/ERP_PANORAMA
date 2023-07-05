using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class ModuloDespachoDL
	{
		public ModuloDespachoDL() { }

		public Int32 Inserta(ModuloDespachoBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDespacho_Inserta");

			db.AddOutParameter(dbCommand, "pIdModuloDespacho", DbType.Int32, pItem.IdModuloDespacho);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdDespachador", DbType.Int32, pItem.IdDespachador);
            db.AddInParameter(dbCommand, "pDescModuloDespacho", DbType.String, pItem.DescModuloDespacho);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdModuloDespacho");

			return Id;
		}

		public void Actualiza(ModuloDespachoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDespacho_Actualiza");

			db.AddInParameter(dbCommand, "pIdModuloDespacho", DbType.Int32, pItem.IdModuloDespacho);
			db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdDespachador", DbType.Int32, pItem.IdDespachador);
            db.AddInParameter(dbCommand, "pDescModuloDespacho", DbType.String, pItem.DescModuloDespacho);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(ModuloDespachoBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDespacho_Elimina");

			db.AddInParameter(dbCommand, "pIdModuloDespacho", DbType.Int32, pItem.IdModuloDespacho);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<ModuloDespachoBE> ListaTodosActivo(int IdEmpresa)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDespacho_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<ModuloDespachoBE> ModuloDespacholist = new List<ModuloDespachoBE>();
			ModuloDespachoBE ModuloDespacho;
			while (reader.Read())
			{
				ModuloDespacho = new ModuloDespachoBE();
				ModuloDespacho.IdModuloDespacho = Int32.Parse(reader["IdModuloDespacho"].ToString());
                ModuloDespacho.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ModuloDespacho.DescModuloDespacho = reader["DescModuloDespacho"].ToString();
                ModuloDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                ModuloDespacho.DescDespachador = reader["DescDespachador"].ToString();
                ModuloDespacho.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                ModuloDespacho.DescSituacion = reader["DescSituacion"].ToString();
                ModuloDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //ModuloDespacho.IdModuloDespacho = reader.IsDBNull(reader.GetOrdinal("IdModuloDespacho")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdModuloDespacho"));
                ModuloDespacholist.Add(ModuloDespacho);
			}
			reader.Close();
			reader.Dispose();
			return ModuloDespacholist;
		}

		public ModuloDespachoBE Selecciona(int IdModuloDespacho)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDespacho_Selecciona");
			db.AddInParameter(dbCommand, "pIdModuloDespacho", DbType.Int32, IdModuloDespacho);

			IDataReader reader = db.ExecuteReader(dbCommand);
			ModuloDespachoBE ModuloDespacho = null;
			while (reader.Read())
			{
				ModuloDespacho = new ModuloDespachoBE();
                ModuloDespacho.IdModuloDespacho = Int32.Parse(reader["IdModuloDespacho"].ToString());
                ModuloDespacho.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ModuloDespacho.DescModuloDespacho = reader["DescModuloDespacho"].ToString();
                ModuloDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                ModuloDespacho.DescDespachador = reader["DescDespachador"].ToString();
                ModuloDespacho.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                ModuloDespacho.DescSituacion = reader["DescSituacion"].ToString();
                ModuloDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
			reader.Close();
			reader.Dispose();
			return ModuloDespacho;
		}

        public ModuloDespachoBE SeleccionaDespachador(int IdDespachador)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDespacho_SeleccionaDespachador");
            db.AddInParameter(dbCommand, "pIdDespachador", DbType.Int32, IdDespachador);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ModuloDespachoBE ModuloDespacho = null;
            while (reader.Read())
            {
                ModuloDespacho = new ModuloDespachoBE();
                ModuloDespacho.IdModuloDespacho = Int32.Parse(reader["IdModuloDespacho"].ToString());
                ModuloDespacho.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ModuloDespacho.DescModuloDespacho = reader["DescModuloDespacho"].ToString();
                ModuloDespacho.IdDespachador = Int32.Parse(reader["IdDespachador"].ToString());
                ModuloDespacho.DescDespachador = reader["DescDespachador"].ToString();
                ModuloDespacho.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                ModuloDespacho.DescSituacion = reader["DescSituacion"].ToString();
                ModuloDespacho.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ModuloDespacho;
        }


    }
}
