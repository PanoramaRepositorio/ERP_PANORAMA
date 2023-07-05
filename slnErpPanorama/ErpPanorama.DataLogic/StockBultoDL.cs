using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class StockBultoDL
    {
        public StockBultoDL() { }

        public void Inserta(StockBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StockBulto_Inserta");

            db.AddInParameter(dbCommand, "pIdStockBulto", DbType.Int32, pItem.IdStockBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioCostoPromedio", DbType.Decimal, pItem.PrecioCostoPromedio);
            db.AddInParameter(dbCommand, "pCostoTotal", DbType.Decimal, pItem.CostoTotal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(StockBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StockBulto_Actualiza");

            db.AddInParameter(dbCommand, "pIdStockBulto", DbType.Int32, pItem.IdStockBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioCostoPromedio", DbType.Decimal, pItem.PrecioCostoPromedio);
            db.AddInParameter(dbCommand, "pCostoTotal", DbType.Decimal, pItem.CostoTotal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCantidades(StockBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StockBulto_ActualizaCantidades");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pValorIncrementa", DbType.Int32, pItem.ValorIncrementa);
            db.AddInParameter(dbCommand, "pValorDescuenta", DbType.Int32, pItem.ValorDescuenta);
            db.AddInParameter(dbCommand, "pPrecioCostoPromedio", DbType.Decimal, pItem.PrecioCostoPromedio);
            db.AddInParameter(dbCommand, "pCostoTotal", DbType.Decimal, pItem.CostoTotal);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(StockBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StockBulto_Elimina");

            db.AddInParameter(dbCommand, "pIdStockBulto", DbType.Int32, pItem.IdStockBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<StockBultoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StockBulto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBultoBE> StockBultolist = new List<StockBultoBE>();
            StockBultoBE StockBulto;
            while (reader.Read())
            {
                StockBulto = new StockBultoBE();
                StockBulto.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                StockBulto.IdStockBulto = Int32.Parse(reader["idStockBulto"].ToString());
                StockBulto.Periodo = Int32.Parse(reader["periodo"].ToString());
                StockBulto.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                StockBulto.DescAlmacen = reader["descAlmacen"].ToString();
                StockBulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                StockBulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                StockBulto.NombreProducto = reader["NombreProducto"].ToString();
                StockBulto.Abreviatura = reader["Abreviatura"].ToString();
                StockBulto.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                StockBulto.PrecioCostoPromedio = Decimal.Parse(reader["precioCostoPromedio"].ToString());
                StockBulto.CostoTotal = Decimal.Parse(reader["costoTotal"].ToString());
                StockBulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                StockBultolist.Add(StockBulto);
            }
            reader.Close();
            reader.Dispose();
            return StockBultolist;
        }

        public List<StockBultoBE> ListaProducto(int IdEmpresa, int IdAlmacen, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_StockBulto_ListaProducto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<StockBultoBE> StockBultolist = new List<StockBultoBE>();
            StockBultoBE StockBulto;
            while (reader.Read())
            {
                StockBulto = new StockBultoBE();
                StockBulto.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                StockBulto.IdStockBulto = Int32.Parse(reader["idStockBulto"].ToString());
                StockBulto.Periodo = Int32.Parse(reader["periodo"].ToString());
                StockBulto.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                StockBulto.DescAlmacen = reader["descAlmacen"].ToString();
                StockBulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                StockBulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                StockBulto.NombreProducto = reader["NombreProducto"].ToString();
                StockBulto.Abreviatura = reader["Abreviatura"].ToString();
                StockBulto.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                StockBulto.PrecioCostoPromedio = Decimal.Parse(reader["PrecioCostoPromedio"].ToString());
                StockBulto.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                StockBulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                StockBultolist.Add(StockBulto);
            }
            reader.Close();
            reader.Dispose();
            return StockBultolist;
        }
    }
}
