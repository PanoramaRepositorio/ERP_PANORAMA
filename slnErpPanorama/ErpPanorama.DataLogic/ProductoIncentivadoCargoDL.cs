using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProductoIncentivadoCargoDL
    {
        public ProductoIncentivadoCargoDL() { }

        public void Inserta(ProductoIncentivadoCargoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivadoCargo_Inserta");

            db.AddInParameter(dbCommand, "pIdProductoIncentivadoCargo", DbType.Int32, pItem.IdProductoIncentivadoCargo);
            db.AddInParameter(dbCommand, "pIdProductoIncentivado", DbType.Int32, pItem.IdProductoIncentivado);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ProductoIncentivadoCargoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivadoCargo_Actualiza");

            db.AddInParameter(dbCommand, "pIdProductoIncentivadoCargo", DbType.Int32, pItem.IdProductoIncentivadoCargo);
            db.AddInParameter(dbCommand, "pIdProductoIncentivado", DbType.Int32, pItem.IdProductoIncentivado);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ProductoIncentivadoCargoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivadoCargo_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProductoIncentivadoCargo", DbType.Int32, pItem.IdProductoIncentivadoCargo);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProductoIncentivadoCargoBE> ListaTodosActivo(int IdProductoIncentivado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivadoCargo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdProductoIncentivado", DbType.Int32, IdProductoIncentivado);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoIncentivadoCargoBE> ProductoIncentivadoCargolist = new List<ProductoIncentivadoCargoBE>();
            ProductoIncentivadoCargoBE ProductoIncentivadoCargo;
            while (reader.Read())
            {
                ProductoIncentivadoCargo = new ProductoIncentivadoCargoBE();
                ProductoIncentivadoCargo.IdProductoIncentivadoCargo = Int32.Parse(reader["IdProductoIncentivadoCargo"].ToString());
                ProductoIncentivadoCargo.IdProductoIncentivado = Int32.Parse(reader["IdProductoIncentivado"].ToString());
                ProductoIncentivadoCargo.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                ProductoIncentivadoCargo.DescCargo = reader["DescCargo"].ToString();
                ProductoIncentivadoCargo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ProductoIncentivadoCargo.TipoOper = 4; //Consultar
                ProductoIncentivadoCargolist.Add(ProductoIncentivadoCargo);
            }
            reader.Close();
            reader.Dispose();
            return ProductoIncentivadoCargolist;
        }
    }
}
