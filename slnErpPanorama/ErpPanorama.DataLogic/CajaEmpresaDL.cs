using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CajaEmpresaDL
    {
        public CajaEmpresaDL() { }

        public void Inserta(CajaEmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEmpresa_Inserta");

            db.AddInParameter(dbCommand, "pIdCajaEmpresa", DbType.Int32, pItem.IdCajaEmpresa);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdTipoFormato", DbType.Int32, pItem.IdTipoFormato);
            db.AddInParameter(dbCommand, "pSerieBoleta", DbType.String, pItem.SerieBoleta);
            db.AddInParameter(dbCommand, "pSerieFactura", DbType.String, pItem.SerieFactura);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CajaEmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEmpresa_Actualiza");

            db.AddInParameter(dbCommand, "pIdCajaEmpresa", DbType.Int32, pItem.IdCajaEmpresa);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdTipoFormato", DbType.Int32, pItem.IdTipoFormato);
            db.AddInParameter(dbCommand, "pSerieBoleta", DbType.String, pItem.SerieBoleta);
            db.AddInParameter(dbCommand, "pSerieFactura", DbType.String, pItem.SerieFactura);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CajaEmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEmpresa_Elimina");

            db.AddInParameter(dbCommand, "pIdCajaEmpresa", DbType.Int32, pItem.IdCajaEmpresa);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CajaEmpresaBE> ListaTodosActivo(int IdEmpresa, int IdTienda, int IdCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEmpresa_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEmpresaBE> CajaEmpresalist = new List<CajaEmpresaBE>();
            CajaEmpresaBE CajaEmpresa;
            while (reader.Read())
            {
                CajaEmpresa = new CajaEmpresaBE();
                CajaEmpresa.IdCajaEmpresa = Int32.Parse(reader["IdCajaEmpresa"].ToString());
                CajaEmpresa.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaEmpresa.RazonSocial = reader["RazonSocial"].ToString();
                CajaEmpresa.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                CajaEmpresa.DescTienda = reader["DescTienda"].ToString();
                CajaEmpresa.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                CajaEmpresa.DescCaja = reader["DescCaja"].ToString();
                CajaEmpresa.IdTipoFormato = Int32.Parse(reader["IdTipoFormato"].ToString());
                CajaEmpresa.DescTipoFormato = reader["DescTipoFormato"].ToString();
                CajaEmpresa.SerieBoleta = reader["SerieBoleta"].ToString();
                CajaEmpresa.SerieFactura = reader["SerieFactura"].ToString();
                CajaEmpresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaEmpresalist.Add(CajaEmpresa);
            }
            reader.Close();
            reader.Dispose();
            return CajaEmpresalist;
        }

        public List<CajaEmpresaBE> ListaTodosActivosRER(int IdEmpresa, int IdTienda, int IdCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEmpresa_ListaTodosActivosRER");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEmpresaBE> CajaEmpresalist = new List<CajaEmpresaBE>();
            CajaEmpresaBE CajaEmpresa;
            while (reader.Read())
            {
                CajaEmpresa = new CajaEmpresaBE();
                CajaEmpresa.IdCajaEmpresa = Int32.Parse(reader["IdCajaEmpresa"].ToString());
                CajaEmpresa.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaEmpresa.RazonSocial = reader["RazonSocial"].ToString();
                CajaEmpresa.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                CajaEmpresa.DescTienda = reader["DescTienda"].ToString();
                CajaEmpresa.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                CajaEmpresa.DescCaja = reader["DescCaja"].ToString();
                CajaEmpresa.IdTipoFormato = Int32.Parse(reader["IdTipoFormato"].ToString());
                CajaEmpresa.DescTipoFormato = reader["DescTipoFormato"].ToString();
                CajaEmpresa.SerieBoleta = reader["SerieBoleta"].ToString();
                CajaEmpresa.SerieFactura = reader["SerieFactura"].ToString();
                CajaEmpresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaEmpresalist.Add(CajaEmpresa);
            }
            reader.Close();
            reader.Dispose();
            return CajaEmpresalist;
        }

        public CajaEmpresaBE Selecciona (int IdEmpresa, int IdTienda, int IdCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEmpresa_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CajaEmpresaBE CajaEmpresa = null;
            while (reader.Read())
            {
                CajaEmpresa = new CajaEmpresaBE();
                CajaEmpresa.IdCajaEmpresa = Int32.Parse(reader["IdCajaEmpresa"].ToString());
                CajaEmpresa.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaEmpresa.RazonSocial = reader["RazonSocial"].ToString();
                CajaEmpresa.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                CajaEmpresa.DescTienda = reader["DescTienda"].ToString();
                CajaEmpresa.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                CajaEmpresa.DescCaja = reader["DescCaja"].ToString();
                CajaEmpresa.IdTipoFormato = Int32.Parse(reader["IdTipoFormato"].ToString());
                CajaEmpresa.DescTipoFormato = reader["DescTipoFormato"].ToString();
                CajaEmpresa.SerieBoleta = reader["SerieBoleta"].ToString();
                CajaEmpresa.SerieFactura = reader["SerieFactura"].ToString();
                CajaEmpresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CajaEmpresa;
        }
    }
}
