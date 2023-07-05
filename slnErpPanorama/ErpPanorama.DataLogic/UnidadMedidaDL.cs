using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class UnidadMedidaDL
    {
        public UnidadMedidaDL() { }

        public void Inserta(UnidadMedidaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMedida_Inserta");

            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescUnidadMedida", DbType.String, pItem.DescUnidadMedida);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(UnidadMedidaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMedida_Actualiza");

            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescUnidadMedida", DbType.String, pItem.DescUnidadMedida);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(UnidadMedidaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMedida_Elimina");

            db.AddInParameter(dbCommand, "pIdUnidadMedida", DbType.Int32, pItem.IdUnidadMedida);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<UnidadMedidaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UnidadMedida_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UnidadMedidaBE> UnidadMedidalist = new List<UnidadMedidaBE>();
            UnidadMedidaBE UnidadMedida;
            while (reader.Read())
            {
                UnidadMedida = new UnidadMedidaBE();
                UnidadMedida.IdUnidadMedida = Int32.Parse(reader["idUnidadMedida"].ToString());
                UnidadMedida.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                UnidadMedida.Abreviatura = reader["Abreviatura"].ToString();
                UnidadMedida.DescUnidadMedida = reader["descUnidadMedida"].ToString();
                UnidadMedida.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UnidadMedidalist.Add(UnidadMedida);
            }
            reader.Close();
            reader.Dispose();
            return UnidadMedidalist;
        }
    }
}

