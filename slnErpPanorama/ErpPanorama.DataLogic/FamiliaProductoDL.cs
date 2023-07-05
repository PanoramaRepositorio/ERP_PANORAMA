using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class FamiliaProductoDL
    {
        public FamiliaProductoDL() { }

        public void Inserta(FamiliaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FamiliaProducto_Inserta");

            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescFamiliaProducto", DbType.String, pItem.DescFamiliaProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(FamiliaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FamiliaProducto_Actualiza");

            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescFamiliaProducto", DbType.String, pItem.DescFamiliaProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(FamiliaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FamiliaProducto_Elimina");

            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<FamiliaProductoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FamiliaProducto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FamiliaProductoBE> FamiliaProductolist = new List<FamiliaProductoBE>();
            FamiliaProductoBE FamiliaProducto;
            while (reader.Read())
            {
                FamiliaProducto = new FamiliaProductoBE();
                FamiliaProducto.IdFamiliaProducto = Int32.Parse(reader["idFamiliaProducto"].ToString());
                FamiliaProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FamiliaProducto.DescFamiliaProducto = reader["descFamiliaProducto"].ToString();
                FamiliaProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FamiliaProductolist.Add(FamiliaProducto);
            }
            reader.Close();
            reader.Dispose();
            return FamiliaProductolist;
        }
    }
}
