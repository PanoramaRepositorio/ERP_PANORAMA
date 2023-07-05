using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TablaDL
    {
        public TablaDL() { }

        public void Inserta(TablaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tabla_Inserta");

            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, pItem.IdTabla);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTabla", DbType.String, pItem.DescTabla);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TablaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tabla_Actualiza");

            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, pItem.IdTabla);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTabla", DbType.String, pItem.DescTabla);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TablaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tabla_Elimina");

            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, pItem.IdTabla);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TablaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tabla_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaBE> Tablalist = new List<TablaBE>();
            TablaBE Tabla;
            while (reader.Read())
            {
                Tabla = new TablaBE();
                Tabla.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tabla.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                Tabla.DescTabla = reader["descTabla"].ToString();
                Tabla.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }

        public List<TablaBE> ListaTodosActivoIO(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tabla_ListaTodosActivoIO");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaBE> Tablalist = new List<TablaBE>();
            TablaBE Tabla;
            while (reader.Read())
            {
                Tabla = new TablaBE();
                Tabla.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tabla.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                Tabla.DescTabla = reader["descTabla"].ToString();
                Tabla.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }

        public List<TablaBE> ListaTodosActivoCentroCosto(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tabla_ListaTodosActivoCentroCosto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaBE> Tablalist = new List<TablaBE>();
            TablaBE Tabla;
            while (reader.Read())
            {
                Tabla = new TablaBE();
                Tabla.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Tabla.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                Tabla.DescTabla = reader["descTabla"].ToString();
                Tabla.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }
    }
}
