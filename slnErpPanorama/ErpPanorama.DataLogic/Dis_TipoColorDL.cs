using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_TipoColorDL
    {
        public Dis_TipoColorDL() { }

        public void Inserta(Dis_TipoColorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_TipoColor_Inserta");

            db.AddInParameter(dbCommand, "pIdDis_TipoColor", DbType.Int32, pItem.IdDis_TipoColor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescDis_TipoColor", DbType.String, pItem.DescDis_TipoColor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Dis_TipoColorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_TipoColor_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_TipoColor", DbType.Int32, pItem.IdDis_TipoColor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescDis_TipoColor", DbType.String, pItem.DescDis_TipoColor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_TipoColorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_TipoColor_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_TipoColor", DbType.Int32, pItem.IdDis_TipoColor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_TipoColorBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_TipoColor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_TipoColorBE> Dis_TipoColorlist = new List<Dis_TipoColorBE>();
            Dis_TipoColorBE Dis_TipoColor;
            while (reader.Read())
            {
                Dis_TipoColor = new Dis_TipoColorBE();
                Dis_TipoColor.IdDis_TipoColor = Int32.Parse(reader["idDis_TipoColor"].ToString());
                Dis_TipoColor.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_TipoColor.DescDis_TipoColor = reader["descDis_TipoColor"].ToString();
                Dis_TipoColor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_TipoColorlist.Add(Dis_TipoColor);
            }
            reader.Close();
            reader.Dispose();
            return Dis_TipoColorlist;
        }
    }
}
