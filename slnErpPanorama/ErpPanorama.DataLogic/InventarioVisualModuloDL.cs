using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class InventarioVisualModuloDL
    {
        public void Inserta(InventarioVisualModuloBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisualModulo_Inserta");

            db.AddInParameter(dbCommand, "pIdInventarioVisualModulo", DbType.Int32, pItem.IdInventarioVisualModulo);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdInventarioVisualBloque", DbType.Int32, pItem.IdInventarioVisualBloque);
            db.AddInParameter(dbCommand, "pDescModulo", DbType.String, pItem.DescModulo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(InventarioVisualModuloBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisualModulo_Actualiza");

            db.AddInParameter(dbCommand, "pIdInventarioVisualModulo", DbType.Int32, pItem.IdInventarioVisualModulo);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdInventarioVisualBloque", DbType.Int32, pItem.IdInventarioVisualBloque);
            db.AddInParameter(dbCommand, "pDescModulo", DbType.String, pItem.DescModulo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(InventarioVisualModuloBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisualModulo_Elimina");

            db.AddInParameter(dbCommand, "pIdInventarioVisualModulo", DbType.Int32, pItem.IdInventarioVisualModulo);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<InventarioVisualModuloBE> ListaTodosActivo(int IdTienda, int IdInventarioVisualBloque)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioVisualModulo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdInventarioVisualBloque", DbType.Int32, IdInventarioVisualBloque);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InventarioVisualModuloBE> InventarioVisualModulolist = new List<InventarioVisualModuloBE>();
            InventarioVisualModuloBE InventarioVisualModulo;
            while (reader.Read())
            {
                InventarioVisualModulo = new InventarioVisualModuloBE();
                InventarioVisualModulo.IdInventarioVisualModulo = Int32.Parse(reader["IdInventarioVisualModulo"].ToString());
                InventarioVisualModulo.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioVisualModulo.IdInventarioVisualBloque = Int32.Parse(reader["IdInventarioVisualBloque"].ToString());
                InventarioVisualModulo.DescModulo = reader["DescModulo"].ToString();
                InventarioVisualModulo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InventarioVisualModulolist.Add(InventarioVisualModulo);
            }
            reader.Close();
            reader.Dispose();
            return InventarioVisualModulolist;
        }
    }
}
