using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class InventarioVisualBloqueDL
    {
        public void Inserta(InventarioVisualBloqueBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisualBloque_Inserta");

            db.AddInParameter(dbCommand, "pIdInventarioVisualBloque", DbType.Int32, pItem.IdInventarioVisualBloque);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescBloque", DbType.String, pItem.DescBloque);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(InventarioVisualBloqueBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisualBloque_Actualiza");

            db.AddInParameter(dbCommand, "pIdInventarioVisualBloque", DbType.Int32, pItem.IdInventarioVisualBloque);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescBloque", DbType.String, pItem.DescBloque);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(InventarioVisualBloqueBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisualBloque_Elimina");

            db.AddInParameter(dbCommand, "pIdInventarioVisualBloque", DbType.Int32, pItem.IdInventarioVisualBloque);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<InventarioVisualBloqueBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisualBloque_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InventarioVisualBloqueBE> InventarioVisualBloquelist = new List<InventarioVisualBloqueBE>();
            InventarioVisualBloqueBE InventarioVisualBloque;
            while (reader.Read())
            {
                InventarioVisualBloque = new InventarioVisualBloqueBE();
                InventarioVisualBloque.IdInventarioVisualBloque = Int32.Parse(reader["IdInventarioVisualBloque"].ToString());
                InventarioVisualBloque.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioVisualBloque.DescTienda = reader["DescTienda"].ToString();
                InventarioVisualBloque.DescBloque = reader["DescBloque"].ToString();
                InventarioVisualBloque.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InventarioVisualBloquelist.Add(InventarioVisualBloque);
            }
            reader.Close();
            reader.Dispose();
            return InventarioVisualBloquelist;
        }

        public List<InventarioVisualBloqueBE> ListaTodosActivoTienda(int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisualBloque_ListaTodosActivoTienda");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InventarioVisualBloqueBE> InventarioVisualBloquelist = new List<InventarioVisualBloqueBE>();
            InventarioVisualBloqueBE InventarioVisualBloque;
            while (reader.Read())
            {
                InventarioVisualBloque = new InventarioVisualBloqueBE();
                InventarioVisualBloque.IdInventarioVisualBloque = Int32.Parse(reader["IdInventarioVisualBloque"].ToString());
                InventarioVisualBloque.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioVisualBloque.DescBloque = reader["DescBloque"].ToString();
                InventarioVisualBloque.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InventarioVisualBloquelist.Add(InventarioVisualBloque);
            }
            reader.Close();
            reader.Dispose();
            return InventarioVisualBloquelist;
        }
    }
}
