using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AreaDL
    {
        public AreaDL() { }

        public void Inserta(AreaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_Inserta");

            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescArea", DbType.String, pItem.DescArea);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(AreaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_Actualiza");

            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescArea", DbType.String, pItem.DescArea);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(AreaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_Elimina");

            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<AreaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AreaBE> Arealist = new List<AreaBE>();
            AreaBE Area;
            while (reader.Read())
            {
                Area = new AreaBE();
                Area.IdArea = Int32.Parse(reader["idArea"].ToString());
                Area.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Area.DescArea = reader["descArea"].ToString();
                Area.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Arealist.Add(Area);
            }
            reader.Close();
            reader.Dispose();
            return Arealist;
        }

        public AreaBE Selecciona(int IdEmpresa, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AreaBE Area = null;
            while (reader.Read())
            {
                Area = new AreaBE();
                Area.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Area.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Area.DescArea = reader["DescArea"].ToString();
                Area.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Area;
        }
    }
}
