using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MetasComisionDL
    {
        public MetasComisionDL() { }

        public void Inserta(MetasComisionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasComision_Inserta");

            db.AddInParameter(dbCommand, "pIdMetaComision", DbType.Int32, pItem.IdMetaComision);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pCriterioMinimo", DbType.Decimal, pItem.CriterioMinimo);
            db.AddInParameter(dbCommand, "pCriterioMaximo", DbType.Decimal, pItem.CriterioMaximo);
            db.AddInParameter(dbCommand, "pBono", DbType.Decimal, pItem.Bono);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(MetasComisionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasComision_Actualiza");

            db.AddInParameter(dbCommand, "pIdMetaComision", DbType.Int32, pItem.IdMetaComision);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pCriterioMinimo", DbType.Decimal, pItem.CriterioMinimo);
            db.AddInParameter(dbCommand, "pCriterioMaximo", DbType.Decimal, pItem.CriterioMaximo);
            db.AddInParameter(dbCommand, "pBono", DbType.Decimal, pItem.Bono);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(MetasComisionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasComision_Elimina");

            db.AddInParameter(dbCommand, "pIdMetaComision", DbType.Int32, pItem.IdMetaComision);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<MetasComisionBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasComision_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MetasComisionBE> MetasComisionlist = new List<MetasComisionBE>();
            MetasComisionBE MetasComision;
            while (reader.Read())
            {
                MetasComision = new MetasComisionBE();
                MetasComision.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MetasComision.IdMetaComision = Int32.Parse(reader["IdMetaComision"].ToString());
                MetasComision.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                MetasComision.DescTienda = reader["DescTienda"].ToString();
                MetasComision.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                MetasComision.Cargo = reader["Cargo"].ToString();
                MetasComision.CriterioMinimo = Decimal.Parse(reader["CriterioMinimo"].ToString());
                MetasComision.CriterioMaximo = Decimal.Parse(reader["CriterioMaximo"].ToString());
                MetasComision.Bono = Decimal.Parse(reader["Bono"].ToString());
                MetasComision.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MetasComisionlist.Add(MetasComision);
            }
            reader.Close();
            reader.Dispose();
            return MetasComisionlist;
        }

        public MetasComisionBE Selecciona(int IdEmpresa, int IdMeta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasComision_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMetaComision", DbType.Int32, IdMeta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MetasComisionBE MetasComision = null;
            while (reader.Read())
            {
                MetasComision = new MetasComisionBE();
                MetasComision.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MetasComision.IdMetaComision = Int32.Parse(reader["IdMetaComision"].ToString());
                MetasComision.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                MetasComision.DescTienda = reader["DescTienda"].ToString();
                MetasComision.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                MetasComision.Cargo = reader["Cargo"].ToString();
                MetasComision.CriterioMinimo = Decimal.Parse(reader["CriterioMinimo"].ToString());
                MetasComision.CriterioMaximo = Decimal.Parse(reader["CriterioMaximo"].ToString());
                MetasComision.Bono = Decimal.Parse(reader["Bono"].ToString());
                MetasComision.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MetasComision;
        }
    }
}
