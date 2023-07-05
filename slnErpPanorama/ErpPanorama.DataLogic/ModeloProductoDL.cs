using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ModeloProductoDL
    {
        public ModeloProductoDL() { }

        public void Inserta(ModeloProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModeloProducto_Inserta");

            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, pItem.IdModeloProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, pItem.IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pDescModeloProducto", DbType.String, pItem.DescModeloProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ModeloProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModeloProducto_Actualiza");

            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, pItem.IdModeloProducto);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, pItem.IdSubLineaProducto);
            db.AddInParameter(dbCommand, "pDescModeloProducto", DbType.String, pItem.DescModeloProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ModeloProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModeloProducto_Elimina");

            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, pItem.IdModeloProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ModeloProductoBE> ListaTodosActivo(int IdEmpresa, int IdLineaProducto, int IdSubLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModeloProducto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, IdSubLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ModeloProductoBE> ModeloProductolist = new List<ModeloProductoBE>();
            ModeloProductoBE ModeloProducto;
            while (reader.Read())
            {
                ModeloProducto = new ModeloProductoBE();
                ModeloProducto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ModeloProducto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                ModeloProducto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ModeloProducto.IdSubLineaProducto = Int32.Parse(reader["IdSubLineaProducto"].ToString());
                ModeloProducto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                ModeloProducto.IdModeloProducto = Int32.Parse(reader["idModeloProducto"].ToString());
                ModeloProducto.DescModeloProducto = reader["descModeloProducto"].ToString();
                ModeloProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ModeloProductolist.Add(ModeloProducto);
            }
            reader.Close();
            reader.Dispose();
            return ModeloProductolist;
        }

        public List<ModeloProductoBE> ListaTodos(int IdEmpresa, int IdLineaProducto, int IdSubLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModeloProducto_ListaTodos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdSubLineaProducto", DbType.Int32, IdSubLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ModeloProductoBE> ModeloProductolist = new List<ModeloProductoBE>();
            ModeloProductoBE ModeloProducto;
            while (reader.Read())
            {
                ModeloProducto = new ModeloProductoBE();
                ModeloProducto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ModeloProducto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                ModeloProducto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ModeloProducto.IdSubLineaProducto = Int32.Parse(reader["IdSubLineaProducto"].ToString());
                ModeloProducto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                ModeloProducto.IdModeloProducto = Int32.Parse(reader["idModeloProducto"].ToString());
                ModeloProducto.DescModeloProducto = reader["descModeloProducto"].ToString();
                ModeloProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ModeloProductolist.Add(ModeloProducto);
            }
            reader.Close();
            reader.Dispose();
            return ModeloProductolist;
        }


        public ModeloProductoBE Selecciona(int IdEmpresa, int IdModeloProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModeloProducto_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, IdModeloProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ModeloProductoBE ModeloProducto = null;
            while (reader.Read())
            {
                ModeloProducto = new ModeloProductoBE();
                ModeloProducto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ModeloProducto.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                ModeloProducto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                ModeloProducto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                ModeloProducto.IdSubLineaProducto = Int32.Parse(reader["IdSubLineaProducto"].ToString());
                ModeloProducto.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                ModeloProducto.IdModeloProducto = Int32.Parse(reader["idModeloProducto"].ToString());
                ModeloProducto.DescModeloProducto = reader["descModeloProducto"].ToString();
                ModeloProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ModeloProducto;
        }


    }
}