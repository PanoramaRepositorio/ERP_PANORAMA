using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class SubLineaProductoDL
    {
        public SubLineaProductoDL() { }

        public void Inserta(SubLineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SubLineaProducto_Inserta");

            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, pItem.IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pDescSubLineaProducto", DbType.String, pItem.DescSubLineaProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(SubLineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SubLineaProducto_Actualiza");

            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, pItem.IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pDescSubLineaProducto", DbType.String, pItem.DescSubLineaProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(SubLineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SubLineaProducto_Elimina");

            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, pItem.IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<SubLineaProductoBE> ListaTodosActivo(int IdEmpresa, int IdLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SubLineaProducto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SubLineaProductoBE> SubLineaProductolist = new List<SubLineaProductoBE>();
            SubLineaProductoBE SubLineaProducto;
            while (reader.Read())
            {
                SubLineaProducto = new SubLineaProductoBE();
                SubLineaProducto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SubLineaProducto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                SubLineaProducto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                SubLineaProducto.IdSubLineaProducto = Int32.Parse(reader["idSubLineaProducto"].ToString());
                SubLineaProducto.DescSubLineaProducto = reader["descSubLineaProducto"].ToString();
                SubLineaProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SubLineaProductolist.Add(SubLineaProducto);
            }
            reader.Close();
            reader.Dispose();
            return SubLineaProductolist;
        }

        public List<SubLineaProductoBE> ListaTodos(int IdEmpresa, int IdLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SubLineaProducto_ListaTodos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SubLineaProductoBE> SubLineaProductolist = new List<SubLineaProductoBE>();
            SubLineaProductoBE SubLineaProducto;
            while (reader.Read())
            {
                SubLineaProducto = new SubLineaProductoBE();
                SubLineaProducto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                SubLineaProducto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                SubLineaProducto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                SubLineaProducto.IdSubLineaProducto = Int32.Parse(reader["idSubLineaProducto"].ToString());
                SubLineaProducto.DescSubLineaProducto = reader["descSubLineaProducto"].ToString();
                SubLineaProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SubLineaProductolist.Add(SubLineaProducto);
            }
            reader.Close();
            reader.Dispose();
            return SubLineaProductolist;
        }

    }
}
