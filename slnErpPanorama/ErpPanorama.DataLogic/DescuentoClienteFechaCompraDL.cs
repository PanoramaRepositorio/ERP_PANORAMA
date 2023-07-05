using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DescuentoClienteFechaCompraDL
    {
        public DescuentoClienteFechaCompraDL() { }

        public void Inserta(DescuentoClienteFechaCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteFechaCompra_Inserta");

            db.AddInParameter(dbCommand, "pIdDescuentoClienteFechaCompra", DbType.Int32, pItem.IdDescuentoClienteFechaCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(DescuentoClienteFechaCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteFechaCompra_Actualiza");

            db.AddInParameter(dbCommand, "pIdDescuentoClienteFechaCompra", DbType.Int32, pItem.IdDescuentoClienteFechaCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(DescuentoClienteFechaCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteFechaCompra_Elimina");

            db.AddInParameter(dbCommand, "pIdDescuentoClienteFechaCompra", DbType.Int32, pItem.IdDescuentoClienteFechaCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DescuentoClienteFechaCompraBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteFechaCompra_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescuentoClienteFechaCompraBE> DescuentoClienteFechaCompralist = new List<DescuentoClienteFechaCompraBE>();
            DescuentoClienteFechaCompraBE DescuentoClienteFechaCompra;
            while (reader.Read())
            {
                DescuentoClienteFechaCompra = new DescuentoClienteFechaCompraBE();
                DescuentoClienteFechaCompra.IdDescuentoClienteFechaCompra = Int32.Parse(reader["idDescuentoClienteFechaCompra"].ToString());
                DescuentoClienteFechaCompra.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DescuentoClienteFechaCompra.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                DescuentoClienteFechaCompra.DescTipoCliente = reader["DescTipoCliente"].ToString();
                DescuentoClienteFechaCompra.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                DescuentoClienteFechaCompra.DescFormaPago = reader["DescFormaPago"].ToString();
                DescuentoClienteFechaCompra.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                DescuentoClienteFechaCompra.DescLineaProducto = reader["DescLineaProducto"].ToString();
                DescuentoClienteFechaCompra.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                DescuentoClienteFechaCompra.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescuentoClienteFechaCompra.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                DescuentoClienteFechaCompra.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescuentoClienteFechaCompralist.Add(DescuentoClienteFechaCompra);
            }
            reader.Close();
            reader.Dispose();
            return DescuentoClienteFechaCompralist;
        }

        //public DescuentoClienteFechaCompraBE SeleccionaCodigo(int IdEmpresa, int IdProducto)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteFechaCompra_ProductoSelecciona");
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
        //    db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    DescuentoClienteFechaCompraBE DescuentoClienteFechaCompra = null;
        //    while (reader.Read())
        //    {
        //        DescuentoClienteFechaCompra = new DescuentoClienteFechaCompraBE();
        //        DescuentoClienteFechaCompra.Descuento = Decimal.Parse(reader["Descuento"].ToString());
        //        DescuentoClienteFechaCompra.FechaRecepcion = DateTime.Parse(reader["FechaRecepcion"].ToString());
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return DescuentoClienteFechaCompra;
        //}

    }
}
