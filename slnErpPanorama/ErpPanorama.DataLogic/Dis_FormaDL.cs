using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_FormaDL
    {
        public Dis_FormaDL() { }

        public void Inserta(Dis_FormaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Forma_Inserta");

            db.AddInParameter(dbCommand, "pIdDis_Forma", DbType.Int32, pItem.IdDis_Forma);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescDis_Forma", DbType.String, pItem.DescDis_Forma);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Dis_FormaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Forma_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_Forma", DbType.Int32, pItem.IdDis_Forma);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescDis_Forma", DbType.String, pItem.DescDis_Forma);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_FormaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Forma_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_Forma", DbType.Int32, pItem.IdDis_Forma);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_FormaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Forma_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_FormaBE> Dis_Formalist = new List<Dis_FormaBE>();
            Dis_FormaBE Dis_Forma;
            while (reader.Read())
            {
                Dis_Forma = new Dis_FormaBE();
                Dis_Forma.IdDis_Forma = Int32.Parse(reader["idDis_Forma"].ToString());
                Dis_Forma.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_Forma.DescDis_Forma = reader["descDis_Forma"].ToString();
                Dis_Forma.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_Formalist.Add(Dis_Forma);
            }
            reader.Close();
            reader.Dispose();
            return Dis_Formalist;
        }
    }
}
