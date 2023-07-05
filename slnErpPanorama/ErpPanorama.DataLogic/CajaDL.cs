using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CajaDL
    {
        public CajaDL() { }

        public void Inserta(CajaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Caja_Inserta");

            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescCaja", DbType.String, pItem.DescCaja);
            db.AddInParameter(dbCommand, "pMac", DbType.String, pItem.Mac);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pFlagVenta", DbType.Boolean, pItem.FlagVenta);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CajaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Caja_Actualiza");

            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pDescCaja", DbType.String, pItem.DescCaja);
            db.AddInParameter(dbCommand, "pMac", DbType.String, pItem.Mac);
            db.AddInParameter(dbCommand, "pFlagVenta", DbType.Boolean, pItem.FlagVenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CajaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Caja_Elimina");

            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CajaBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Caja_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaBE> Cajalist = new List<CajaBE>();
            CajaBE Caja;
            while (reader.Read())
            {
                Caja = new CajaBE();
                Caja.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Caja.RazonSocial = reader["RazonSocial"].ToString();
                Caja.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Caja.DescTienda = reader["DescTienda"].ToString();
                Caja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                Caja.DescCaja = reader["descCaja"].ToString();
                Caja.Mac = reader["Mac"].ToString();
                Caja.FlagVenta = Boolean.Parse(reader["FlagVenta"].ToString());
                Caja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cajalist.Add(Caja);
            }
            reader.Close();
            reader.Dispose();
            return Cajalist;
        }
    }
}
