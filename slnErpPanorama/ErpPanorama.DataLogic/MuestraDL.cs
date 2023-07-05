using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MuestraDL
    {
        public MuestraDL() { }

        public void Inserta(MuestraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Muestra_Inserta");

            db.AddInParameter(dbCommand, "pIdMuestra", DbType.Int32, pItem.IdMuestra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(MuestraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Muestra_Actualiza");

            db.AddInParameter(dbCommand, "pIdMuestra", DbType.Int32, pItem.IdMuestra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }


        public void Elimina(MuestraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Muestra_Elimina");

            db.AddInParameter(dbCommand, "pIdMuestra", DbType.Int32, pItem.IdMuestra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public MuestraBE Selecciona(int IdMuestra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Muestra_Selecciona");

            db.AddInParameter(dbCommand, "pIdMuestra", DbType.Int32, IdMuestra);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            MuestraBE Muestra = null;
            while (reader.Read())
            {
                Muestra = new MuestraBE();
                Muestra.IdMuestra = Int32.Parse(reader["idMuestra"].ToString());
                Muestra.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Muestra.RazonSocial = reader["RazonSocial"].ToString();
                Muestra.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Muestra.DescTienda = reader["DescTienda"].ToString();
                Muestra.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Muestra.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Muestra.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Muestra.NombreProducto = reader["NombreProducto"].ToString();
                Muestra.Abreviatura = reader["Abreviatura"].ToString();
                Muestra.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Muestra.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                Muestra.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                Muestra.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Muestra;
        }

        public List<MuestraBE> ListaTodosActivo(DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Muestra_ListaTodosActivo");

            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MuestraBE> Muestralist = new List<MuestraBE>();
            MuestraBE Muestra;
            while (reader.Read())
            {
                Muestra = new MuestraBE();
                Muestra.IdMuestra = Int32.Parse(reader["idMuestra"].ToString());
                Muestra.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Muestra.RazonSocial = reader["RazonSocial"].ToString();
                Muestra.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Muestra.DescTienda = reader["DescTienda"].ToString();
                Muestra.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Muestra.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Muestra.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Muestra.NombreProducto = reader["NombreProducto"].ToString();
                Muestra.Abreviatura = reader["Abreviatura"].ToString();
                Muestra.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Muestra.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Muestra.DescModeloProducto = reader["DescModeloProducto"].ToString();
                Muestra.DescMaterial = reader["DescMaterial"].ToString();
                Muestra.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Muestra.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                Muestra.StockAlmacenUcayali = Decimal.Parse(reader["StockAlmacenUcayali"].ToString());
                Muestra.StockTiendaUcayali = Decimal.Parse(reader["StockTiendaUcayali"].ToString());
                Muestra.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Muestra.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                Muestra.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                Muestra.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Muestralist.Add(Muestra);
            }
            reader.Close();
            reader.Dispose();
            return Muestralist;
        }
    }
}
