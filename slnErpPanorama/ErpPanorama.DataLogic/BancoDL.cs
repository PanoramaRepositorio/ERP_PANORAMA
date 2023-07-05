using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class BancoDL
    {
        public BancoDL() { }

        public void Inserta(BancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Banco_Inserta");

            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescBanco", DbType.String, pItem.DescBanco);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(BancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Banco_Actualiza");

            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescBanco", DbType.String, pItem.DescBanco);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(BancoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Banco_Elimina");

            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<BancoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
           DbCommand dbCommand = db.GetStoredProcCommand("usp_Banco_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BancoBE> Bancolist = new List<BancoBE>();
            BancoBE Banco;
            while (reader.Read())
            {
                Banco = new BancoBE();
                Banco.IdBanco = Int32.Parse(reader["idBanco"].ToString());
                Banco.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Banco.DescBanco = reader["descBanco"].ToString();
                Banco.Abreviatura = reader["Abreviatura"].ToString();
                Banco.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bancolist.Add(Banco);
            }
            reader.Close();
            reader.Dispose();
            return Bancolist;
        }

        public List<BancoBE> ListaFiltro(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            // DbCommand dbCommand = db.GetStoredProcCommand("usp_Banco_ListaTodosActivo");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Banco_ListaFiltro");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BancoBE> Bancolist = new List<BancoBE>();
            BancoBE Banco;
            while (reader.Read())
            {
                Banco = new BancoBE();
                Banco.IdBanco = Int32.Parse(reader["idBanco"].ToString());
                Banco.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Banco.DescBanco = reader["descBanco"].ToString();
                Banco.Abreviatura = reader["Abreviatura"].ToString();
                Banco.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bancolist.Add(Banco);
            }
            reader.Close();
            reader.Dispose();
            return Bancolist;
        }
    }
}
