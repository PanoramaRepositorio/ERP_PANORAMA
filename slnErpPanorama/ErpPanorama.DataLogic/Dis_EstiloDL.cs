using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_EstiloDL
    {
        public Dis_EstiloDL() { }

        public void Inserta(Dis_EstiloBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Estilo_Inserta");

            db.AddInParameter(dbCommand, "pIdDis_Estilo", DbType.Int32, pItem.IdDis_Estilo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescDis_Estilo", DbType.String, pItem.DescDis_Estilo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Dis_EstiloBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Estilo_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_Estilo", DbType.Int32, pItem.IdDis_Estilo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescDis_Estilo", DbType.String, pItem.DescDis_Estilo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_EstiloBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Estilo_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_Estilo", DbType.Int32, pItem.IdDis_Estilo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_EstiloBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Estilo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_EstiloBE> Dis_Estilolist = new List<Dis_EstiloBE>();
            Dis_EstiloBE Dis_Estilo;
            while (reader.Read())
            {
                Dis_Estilo = new Dis_EstiloBE();
                Dis_Estilo.IdDis_Estilo = Int32.Parse(reader["idDis_Estilo"].ToString());
                Dis_Estilo.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_Estilo.DescDis_Estilo = reader["descDis_Estilo"].ToString();
                Dis_Estilo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_Estilolist.Add(Dis_Estilo);
            }
            reader.Close();
            reader.Dispose();
            return Dis_Estilolist;
        }
    }
}
