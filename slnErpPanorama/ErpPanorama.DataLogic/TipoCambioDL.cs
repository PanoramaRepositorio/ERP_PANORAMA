using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TipoCambioDL
    {
        public TipoCambioDL() { }

        public void Inserta(TipoCambioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCambio_Inserta");

            db.AddInParameter(dbCommand, "pIdTipoCambio", DbType.Int32, pItem.IdTipoCambio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pCompra", DbType.Decimal, pItem.Compra);
            db.AddInParameter(dbCommand, "pVenta", DbType.Decimal, pItem.Venta);
            db.AddInParameter(dbCommand, "pCompraSunat", DbType.Decimal, pItem.CompraSunat);
            db.AddInParameter(dbCommand, "pVentaSunat", DbType.Decimal, pItem.VentaSunat);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TipoCambioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCambio_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipoCambio", DbType.Int32, pItem.IdTipoCambio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pCompra", DbType.Decimal, pItem.Compra);
            db.AddInParameter(dbCommand, "pVenta", DbType.Decimal, pItem.Venta);
            db.AddInParameter(dbCommand, "pCompraSunat", DbType.Decimal, pItem.CompraSunat);
            db.AddInParameter(dbCommand, "pVentaSunat", DbType.Decimal, pItem.VentaSunat);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TipoCambioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCambio_Elimina");

            db.AddInParameter(dbCommand, "pIdTipoCambio", DbType.Int32, pItem.IdTipoCambio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public TipoCambioBE Selecciona(int IdEmpresa, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCambio_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoCambioBE TipoCambio = null;
            while (reader.Read())
            {
                TipoCambio = new TipoCambioBE();
                TipoCambio.IdTipoCambio = Int32.Parse(reader["idTipoCambio"].ToString());
                TipoCambio.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                TipoCambio.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                TipoCambio.Moneda = reader["Moneda"].ToString();
                TipoCambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                TipoCambio.Compra = Decimal.Parse(reader["Compra"].ToString());
                TipoCambio.Venta = Decimal.Parse(reader["Venta"].ToString());
                TipoCambio.CompraSunat = Decimal.Parse(reader["CompraSunat"].ToString());
                TipoCambio.VentaSunat = Decimal.Parse(reader["VentaSunat"].ToString());
                TipoCambio.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                TipoCambio.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                TipoCambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoCambio;
        }

        public TipoCambioBE BuscarFecha(int IdEmpresa, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCambio_BuscarFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TipoCambioBE TipoCambio = null;
            while (reader.Read())
            {
                TipoCambio = new TipoCambioBE();
                TipoCambio.IdTipoCambio = Int32.Parse(reader["idTipoCambio"].ToString());
                TipoCambio.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                TipoCambio.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                TipoCambio.Moneda = reader["Moneda"].ToString();
                TipoCambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                TipoCambio.Compra = Decimal.Parse(reader["Compra"].ToString());
                TipoCambio.Venta = Decimal.Parse(reader["Venta"].ToString());
                TipoCambio.CompraSunat = Decimal.Parse(reader["CompraSunat"].ToString());
                TipoCambio.VentaSunat = Decimal.Parse(reader["VentaSunat"].ToString());
                TipoCambio.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                TipoCambio.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                TipoCambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TipoCambio;
        }



        public List<TipoCambioBE> ListaTodosActivo(int IdEmpresa, int IdMoneda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoCambio_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, IdMoneda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoCambioBE> TipoCambiolist = new List<TipoCambioBE>();
            TipoCambioBE TipoCambio;
            while (reader.Read())
            {
                TipoCambio = new TipoCambioBE();
                TipoCambio.IdTipoCambio = Int32.Parse(reader["idTipoCambio"].ToString());
                TipoCambio.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                TipoCambio.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                TipoCambio.Moneda = reader["Moneda"].ToString();
                TipoCambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                TipoCambio.Compra = Decimal.Parse(reader["Compra"].ToString());
                TipoCambio.Venta = Decimal.Parse(reader["Venta"].ToString());
                TipoCambio.CompraSunat = Decimal.Parse(reader["CompraSunat"].ToString());
                TipoCambio.VentaSunat = Decimal.Parse(reader["VentaSunat"].ToString());
                TipoCambio.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                TipoCambio.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                TipoCambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoCambiolist.Add(TipoCambio);
            }
            reader.Close();
            reader.Dispose();
            return TipoCambiolist;
        }
    }
}

