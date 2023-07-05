using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class LiquidacionProductoDL
    {
       public LiquidacionProductoDL() { }

        public void Inserta(LiquidacionProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LiquidacionProducto_Inserta");

            db.AddInParameter(dbCommand, "pIdLiquidacionProducto", DbType.Int32, pItem.IdLiquidacionProducto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(LiquidacionProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LiquidacionProducto_Actualiza");

            db.AddInParameter(dbCommand, "pIdLiquidacionProducto", DbType.Int32, pItem.IdLiquidacionProducto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(LiquidacionProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LiquidacionProducto_Elimina");

            db.AddInParameter(dbCommand, "pIdLiquidacionProducto", DbType.Int32, pItem.IdLiquidacionProducto);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaModelo(int IdModeloProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LiquidacionProducto_EliminaModelo");

            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, IdModeloProducto);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<LiquidacionProductoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LiquidacionProducto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LiquidacionProductoBE> LiquidacionProductolist = new List<LiquidacionProductoBE>();
            LiquidacionProductoBE LiquidacionProducto;
            while (reader.Read())
            {
                LiquidacionProducto = new LiquidacionProductoBE();
                LiquidacionProducto.IdLiquidacionProducto = Int32.Parse(reader["IdLiquidacionProducto"].ToString());
                LiquidacionProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                LiquidacionProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                LiquidacionProducto.NombreProducto = reader["NombreProducto"].ToString();
                LiquidacionProducto.Abreviatura = reader["Abreviatura"].ToString();
                LiquidacionProducto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                LiquidacionProducto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                LiquidacionProducto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                LiquidacionProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                LiquidacionProductolist.Add(LiquidacionProducto);
            }
            reader.Close();
            reader.Dispose();
            return LiquidacionProductolist;
        }

        public List<LiquidacionProductoBE> ListaModeloProducto(int IdModeloProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LiquidacionProducto_ListaModelo");
            db.AddInParameter(dbCommand, "pIdModeloProducto", DbType.Int32, IdModeloProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LiquidacionProductoBE> LiquidacionProductolist = new List<LiquidacionProductoBE>();
            LiquidacionProductoBE LiquidacionProducto;
            while (reader.Read())
            {
                LiquidacionProducto = new LiquidacionProductoBE();
                LiquidacionProducto.IdLiquidacionProducto = Int32.Parse(reader["IdLiquidacionProducto"].ToString());
                LiquidacionProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                LiquidacionProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                LiquidacionProducto.NombreProducto = reader["NombreProducto"].ToString();
                LiquidacionProducto.Abreviatura = reader["Abreviatura"].ToString();
                LiquidacionProducto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                LiquidacionProducto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                LiquidacionProducto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                LiquidacionProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                LiquidacionProductolist.Add(LiquidacionProducto);
            }
            reader.Close();
            reader.Dispose();
            return LiquidacionProductolist;
        }

        public LiquidacionProductoBE Selecciona(int IdLiquidacionProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LiquidacionProducto_Selecciona");
            db.AddInParameter(dbCommand, "pIdLiquidacionProducto", DbType.Int32, IdLiquidacionProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            LiquidacionProductoBE LiquidacionProducto = null;
            while (reader.Read())
            {
                LiquidacionProducto = new LiquidacionProductoBE();
                LiquidacionProducto.IdLiquidacionProducto = Int32.Parse(reader["IdLiquidacionProducto"].ToString());
                LiquidacionProducto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                LiquidacionProducto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                LiquidacionProducto.NombreProducto = reader["NombreProducto"].ToString();
                LiquidacionProducto.Abreviatura = reader["Abreviatura"].ToString();
                LiquidacionProducto.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                LiquidacionProducto.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                LiquidacionProducto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                LiquidacionProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return LiquidacionProducto;
        }
    }
}
