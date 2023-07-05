using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProductoIncentivadoDL
    {
        public ProductoIncentivadoDL() { }

        public Int32 Inserta(ProductoIncentivadoBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivado_Inserta");

            db.AddOutParameter(dbCommand, "pIdProductoIncentivado", DbType.Int32, pItem.IdProductoIncentivado);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescProductoIncentivado", DbType.String, pItem.DescProductoIncentivado);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            

            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdProductoIncentivado");

            return intIdCliente;
        }

        public void Actualiza(ProductoIncentivadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivado_Actualiza");

            db.AddInParameter(dbCommand, "pIdProductoIncentivado", DbType.Int32, pItem.IdProductoIncentivado);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescProductoIncentivado", DbType.String, pItem.DescProductoIncentivado);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ProductoIncentivadoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivado_Elimina");

            db.AddInParameter(dbCommand, "pIdProductoIncentivado", DbType.Int32, pItem.IdProductoIncentivado);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProductoIncentivadoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProductoIncentivado_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProductoIncentivadoBE> ProductoIncentivadolist = new List<ProductoIncentivadoBE>();
            ProductoIncentivadoBE ProductoIncentivado;
            while (reader.Read())
            {
                ProductoIncentivado = new ProductoIncentivadoBE();
                ProductoIncentivado.IdProductoIncentivado = Int32.Parse(reader["IdProductoIncentivado"].ToString());
                ProductoIncentivado.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                ProductoIncentivado.DescProductoIncentivado = reader["DescProductoIncentivado"].ToString();
                ProductoIncentivado.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                ProductoIncentivado.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                ProductoIncentivado.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ProductoIncentivadolist.Add(ProductoIncentivado);
            }
            reader.Close();
            reader.Dispose();
            return ProductoIncentivadolist;
        }
    }
}
