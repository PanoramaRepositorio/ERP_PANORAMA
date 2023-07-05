using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TopeEmpresaDL
    {
        public TopeEmpresaDL() { }

        public void Inserta(TopeEmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TopeEmpresa_Inserta");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pTope", DbType.Decimal, pItem.Tope);
            db.AddInParameter(dbCommand, "pTopeDiario", DbType.Decimal, pItem.TopeDiario);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TopeEmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TopeEmpresa_Actualiza");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pTope", DbType.Decimal, pItem.Tope);
            db.AddInParameter(dbCommand, "pTopeDiario", DbType.Decimal, pItem.TopeDiario);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TopeEmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TopeEmpresa_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TopeEmpresaBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TopeEmpresa_ListaTodosActivo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TopeEmpresaBE> TopeEmpresalist = new List<TopeEmpresaBE>();
            TopeEmpresaBE TopeEmpresa;
            while (reader.Read())
            {
                TopeEmpresa = new TopeEmpresaBE();
                TopeEmpresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TopeEmpresa.RazonSocial = reader["RazonSocial"].ToString();
                TopeEmpresa.Tope = Decimal.Parse(reader["Tope"].ToString());
                TopeEmpresa.TopeDiario = Decimal.Parse(reader["TopeDiario"].ToString());
                TopeEmpresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TopeEmpresalist.Add(TopeEmpresa);
            }
            reader.Close();
            reader.Dispose();
            return TopeEmpresalist;
        }

         public TopeEmpresaBE Selecciona(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TopeEmpresa_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            IDataReader reader = db.ExecuteReader(dbCommand);
            TopeEmpresaBE TopeEmpresa = null;
            while (reader.Read())
            {
                TopeEmpresa = new TopeEmpresaBE();
                TopeEmpresa.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TopeEmpresa.Tope = Decimal.Parse(reader["Tope"].ToString());
                TopeEmpresa.TopeDiario = Decimal.Parse(reader["TopeDiario"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return TopeEmpresa;
        }
    }
}
