using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProductoFotoDL
    {
        public ProductoFotoDL() { }

        public void Inserta(ProductoFotoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoFoto_Inserta");

            db.AddInParameter(dbCommand, "pIdProductoFoto", DbType.Int32, pItem.IdProductoFoto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFrontal", DbType.String, pItem.Frontal);
            db.AddInParameter(dbCommand, "pLateral", DbType.String, pItem.Lateral);
            db.AddInParameter(dbCommand, "pTrasera", DbType.String, pItem.Trasera);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void InsertaProductoProforma(ProductoFotoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoFoto_Inserta");

            db.AddInParameter(dbCommand, "pIdProductoFoto", DbType.Int32, pItem.IdProductoFoto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFrontal", DbType.String, pItem.Frontal);
            db.AddInParameter(dbCommand, "pLateral", DbType.String, pItem.Lateral);
            db.AddInParameter(dbCommand, "pTrasera", DbType.String, pItem.Trasera);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ProductoFotoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoFoto_Actualiza");

            db.AddInParameter(dbCommand, "pIdProductoFoto", DbType.Int32, pItem.IdProductoFoto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFrontal", DbType.String, pItem.Frontal);
            db.AddInParameter(dbCommand, "pLateral", DbType.String, pItem.Lateral);
            db.AddInParameter(dbCommand, "pTrasera", DbType.String, pItem.Trasera);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        //public void Actualiza(ProductoFotoBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoFoto_Actualiza");

        //    db.AddInParameter(dbCommand, "pIdProductoFoto", DbType.Int32, pItem.IdProductoFoto);
        //    db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
        //    db.AddInParameter(dbCommand, "pFrontal", DbType.String, pItem.Frontal);
        //    db.AddInParameter(dbCommand, "pLateral", DbType.String, pItem.Lateral);
        //    db.AddInParameter(dbCommand, "pTrasera", DbType.String, pItem.Trasera);
        //    db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

        //    db.ExecuteNonQuery(dbCommand);
        //}


        public void ActualizaProformaFoto(ProductoFotoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoFoto_Actualiza");

            db.AddInParameter(dbCommand, "pIdProductoFoto", DbType.Int32, pItem.IdProductoFoto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFrontal", DbType.String, pItem.Frontal);
            db.AddInParameter(dbCommand, "pLateral", DbType.String, pItem.Lateral);
            db.AddInParameter(dbCommand, "pTrasera", DbType.String, pItem.Trasera);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void InsertaFoto(ProductoFotoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoFotoProforma_Inserta");

            db.AddInParameter(dbCommand, "pIdProductoFoto", DbType.Int32, pItem.IdProductoFoto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFrontal", DbType.String, pItem.Frontal);
            db.AddInParameter(dbCommand, "pLateral", DbType.String, pItem.Lateral);
            db.AddInParameter(dbCommand, "pTrasera", DbType.String, pItem.Trasera);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void InsertaFotoProforma(ProductoFotoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoFotoProforma_Inserta");

            db.AddInParameter(dbCommand, "pIdProductoFoto", DbType.Int32, pItem.IdProductoFoto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFrontal", DbType.String, pItem.Frontal);
            db.AddInParameter(dbCommand, "pLateral", DbType.String, pItem.Lateral);
            db.AddInParameter(dbCommand, "pTrasera", DbType.String, pItem.Trasera);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ProductoFotoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoFoto_Elimina");

            db.AddInParameter(dbCommand, "pIdProductoFoto", DbType.Int32, pItem.IdProductoFoto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProductoFotoBE> ListaTodosActivo(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoFoto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoFotoBE> ProductoFotolist = new List<ProductoFotoBE>();
            ProductoFotoBE ProductoFoto;
            while (reader.Read())
            {
                ProductoFoto = new ProductoFotoBE();
                ProductoFoto.IdProductoFoto = Int32.Parse(reader["idProductoFoto"].ToString());
                ProductoFoto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoFoto.Frontal = reader["Frontal"].ToString();
                ProductoFoto.Lateral = reader["Lateral"].ToString();
                ProductoFoto.Trasera = reader["Trasera"].ToString();
                ProductoFoto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ProductoFoto.TipoOper = 4; 
                ProductoFotolist.Add(ProductoFoto);
            }
            reader.Close();
            reader.Dispose();
            return ProductoFotolist;
        }

        public ProductoFotoBE Selecciona(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoFoto_Selecciona");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProductoFotoBE ProductoFoto = null;
            while (reader.Read())
            {
                ProductoFoto = new ProductoFotoBE();
                ProductoFoto.IdProductoFoto = Int32.Parse(reader["idProductoFoto"].ToString());
                ProductoFoto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProductoFoto.Frontal = reader["Frontal"].ToString();
                ProductoFoto.Lateral = reader["Lateral"].ToString();
                ProductoFoto.Trasera = reader["Trasera"].ToString();
                ProductoFoto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ProductoFoto.TipoOper = 4;
            }
            reader.Close();
            reader.Dispose();
            return ProductoFoto;
        }
    }
}
