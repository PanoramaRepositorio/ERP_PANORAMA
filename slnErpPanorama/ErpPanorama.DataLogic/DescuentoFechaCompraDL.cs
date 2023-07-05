using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DescuentoFechaCompraDL
    {
        public DescuentoFechaCompraDL() { }

        public void Inserta(DescuentoFechaCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoFechaCompra_Inserta");

            db.AddInParameter(dbCommand, "pIdDescuentoFechaCompra", DbType.Int32, pItem.IdDescuentoFechaCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(DescuentoFechaCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoFechaCompra_Actualiza");

            db.AddInParameter(dbCommand, "pIdDescuentoFechaCompra", DbType.Int32, pItem.IdDescuentoFechaCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(DescuentoFechaCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoFechaCompra_Elimina");

            db.AddInParameter(dbCommand, "pIdDescuentoFechaCompra", DbType.Int32, pItem.IdDescuentoFechaCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DescuentoFechaCompraBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoFechaCompra_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescuentoFechaCompraBE> DescuentoFechaCompralist = new List<DescuentoFechaCompraBE>();
            DescuentoFechaCompraBE DescuentoFechaCompra;
            while (reader.Read())
            {
                DescuentoFechaCompra = new DescuentoFechaCompraBE();
                DescuentoFechaCompra.IdDescuentoFechaCompra = Int32.Parse(reader["idDescuentoFechaCompra"].ToString());
                DescuentoFechaCompra.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DescuentoFechaCompra.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                DescuentoFechaCompra.DescLineaProducto = reader["DescLineaProducto"].ToString();
                DescuentoFechaCompra.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                DescuentoFechaCompra.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescuentoFechaCompra.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                DescuentoFechaCompra.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescuentoFechaCompralist.Add(DescuentoFechaCompra);
            }
            reader.Close();
            reader.Dispose();
            return DescuentoFechaCompralist;
        }

        public DescuentoFechaCompraBE SeleccionaCodigo(int IdEmpresa, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoFechaCompra_ProductoSelecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DescuentoFechaCompraBE DescuentoFechaCompra = null;
            while (reader.Read())
            {
                DescuentoFechaCompra = new DescuentoFechaCompraBE();
                DescuentoFechaCompra.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                DescuentoFechaCompra.FechaRecepcion = DateTime.Parse(reader["FechaRecepcion"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DescuentoFechaCompra;
        }

    }
}
