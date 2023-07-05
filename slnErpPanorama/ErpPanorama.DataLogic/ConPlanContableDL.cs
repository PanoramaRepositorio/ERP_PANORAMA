using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ConPlanContableDL
    {
        public ConPlanContableDL() { }

        public void Inserta(ConPlanContableBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConPlanContable_Inserta");

            db.AddInParameter(dbCommand, "pIdConPlanContable", DbType.Int32, pItem.IdConPlanContable);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ConPlanContableBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConPlanContable_Actualiza");

            db.AddInParameter(dbCommand, "pIdConPlanContable", DbType.Int32, pItem.IdConPlanContable);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ConPlanContableBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConPlanContable_Elimina");

            db.AddInParameter(dbCommand, "pIdConPlanContable", DbType.Int32, pItem.IdConPlanContable);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ConPlanContableBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConPlanContable_ListaTodosActivo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ConPlanContableBE> ConPlanContablelist = new List<ConPlanContableBE>();
            ConPlanContableBE ConPlanContable;
            while (reader.Read())
            {
                ConPlanContable = new ConPlanContableBE();
                ConPlanContable.IdConPlanContable = Int32.Parse(reader["IdConPlanContable"].ToString());
                ConPlanContable.Codigo = reader["Codigo"].ToString();
                ConPlanContable.Descripcion = reader["Descripcion"].ToString();
                ConPlanContable.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                ConPlanContablelist.Add(ConPlanContable);
            }
            reader.Close();
            reader.Dispose();
            return ConPlanContablelist;
        }

        public ConPlanContableBE Selecciona(int IdConPlanContable)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConPlanContable_Selecciona");
            db.AddInParameter(dbCommand, "pIdConPlanContable", DbType.Int32, IdConPlanContable);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ConPlanContableBE ConPlanContable = null;
            while (reader.Read())
            {
                ConPlanContable = new ConPlanContableBE();
                ConPlanContable.IdConPlanContable = Int32.Parse(reader["IdConPlanContable"].ToString());
                ConPlanContable.Codigo = reader["Codigo"].ToString();
                ConPlanContable.Descripcion = reader["Descripcion"].ToString();
                ConPlanContable.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ConPlanContable;
        }
    }
}
