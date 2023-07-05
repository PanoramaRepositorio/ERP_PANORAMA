using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_AmbienteDL
    {
        public Dis_AmbienteDL() { }

        public void Inserta(Dis_AmbienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Ambiente_Inserta");

            db.AddInParameter(dbCommand, "pIdDis_Ambiente", DbType.Int32, pItem.IdDis_Ambiente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescDis_Ambiente", DbType.String, pItem.DescDis_Ambiente);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Dis_AmbienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Ambiente_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_Ambiente", DbType.Int32, pItem.IdDis_Ambiente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescDis_Ambiente", DbType.String, pItem.DescDis_Ambiente);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_AmbienteBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Ambiente_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_Ambiente", DbType.Int32, pItem.IdDis_Ambiente);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_AmbienteBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Ambiente_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_AmbienteBE> Dis_Ambientelist = new List<Dis_AmbienteBE>();
            Dis_AmbienteBE Dis_Ambiente;
            while (reader.Read())
            {
                Dis_Ambiente = new Dis_AmbienteBE();
                Dis_Ambiente.IdDis_Ambiente = Int32.Parse(reader["idDis_Ambiente"].ToString());
                Dis_Ambiente.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_Ambiente.DescDis_Ambiente = reader["descDis_Ambiente"].ToString();
                Dis_Ambiente.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_Ambientelist.Add(Dis_Ambiente);
            }
            reader.Close();
            reader.Dispose();
            return Dis_Ambientelist;
        }

    }
}
