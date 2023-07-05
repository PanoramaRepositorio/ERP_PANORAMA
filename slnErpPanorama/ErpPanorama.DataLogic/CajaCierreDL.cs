using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CajaCierreDL
    {
        public CajaCierreDL() { }

        public void Inserta(CajaCierreBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_Inserta");

            db.AddInParameter(dbCommand, "pIdCajaCierre", DbType.Int32, pItem.IdCajaCierre);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pTotalVisa", DbType.Int32, pItem.TotalVisa);
            db.AddInParameter(dbCommand, "pTotalMastercard", DbType.Int32, pItem.TotalMastercard);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CajaCierreBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_Actualiza");

            db.AddInParameter(dbCommand, "pIdCajaCierre", DbType.Int32, pItem.IdCajaCierre);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pTotalVisa", DbType.Int32, pItem.TotalVisa);
            db.AddInParameter(dbCommand, "pTotalMastercard", DbType.Int32, pItem.TotalMastercard);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CajaCierreBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_Elimina");

            db.AddInParameter(dbCommand, "pIdCajaCierre", DbType.Int32, pItem.IdCajaCierre);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaFecha(CajaCierreBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_EliminaFecha");

            db.AddInParameter(dbCommand, "pFecha ", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CajaCierreBE> ListaTodosActivo(int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaCierreBE> CajaCierrelist = new List<CajaCierreBE>();
            CajaCierreBE CajaCierre;
            while (reader.Read())
            {
                CajaCierre = new CajaCierreBE();
                CajaCierre.IdCajaCierre = Int32.Parse(reader["IdCajaCierre"].ToString());
                CajaCierre.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                CajaCierre.DescTienda = reader["DescTienda"].ToString();
                CajaCierre.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                CajaCierre.DescCaja = reader["DescCaja"].ToString();
                CajaCierre.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                CajaCierre.TotalVisa = Int32.Parse(reader["TotalVisa"].ToString());
                CajaCierre.TotalMastercard = Int32.Parse(reader["TotalMastercard"].ToString());
                CajaCierre.Usuario = reader["Usuario"].ToString();
                CajaCierre.Maquina = reader["Maquina"].ToString();
                CajaCierre.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaCierrelist.Add(CajaCierre);
            }
            reader.Close();
            reader.Dispose();
            return CajaCierrelist;
        }

        public List<CajaCierreBE> ListaFechaCaja(DateTime FechaDesde, DateTime FechaHasta, int IdCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_ListaFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaCierreBE> CajaCierrelist = new List<CajaCierreBE>();
            CajaCierreBE CajaCierre;
            while (reader.Read())
            {
                CajaCierre = new CajaCierreBE();
                CajaCierre.IdCajaCierre = Int32.Parse(reader["IdCajaCierre"].ToString());
                CajaCierre.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                CajaCierre.DescTienda = reader["DescTienda"].ToString();
                CajaCierre.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                CajaCierre.DescCaja = reader["DescCaja"].ToString();
                CajaCierre.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                CajaCierre.TotalVisa = Int32.Parse(reader["TotalVisa"].ToString());
                CajaCierre.TotalMastercard = Int32.Parse(reader["TotalMastercard"].ToString());
                CajaCierre.Usuario = reader["Usuario"].ToString();
                CajaCierre.Maquina = reader["Maquina"].ToString();
                CajaCierre.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaCierrelist.Add(CajaCierre);
            }
            reader.Close();
            reader.Dispose();
            return CajaCierrelist;
        }

    }
}
