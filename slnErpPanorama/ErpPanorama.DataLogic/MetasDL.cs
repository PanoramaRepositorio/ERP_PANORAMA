using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MetasDL
    {
        public MetasDL() { }

        public void Inserta(MetasBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Metas_Inserta");

            db.AddInParameter(dbCommand, "pIdMeta", DbType.Int32, pItem.IdMeta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pImporteFinal", DbType.Decimal, pItem.ImporteFinal);
            db.AddInParameter(dbCommand, "pImporteMayorista", DbType.Decimal, pItem.ImporteMayorista);
            db.AddInParameter(dbCommand, "pImporteDiseno", DbType.Decimal, pItem.ImporteDiseno);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(MetasBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Metas_Actualiza");

            db.AddInParameter(dbCommand, "pIdMeta", DbType.Int32, pItem.IdMeta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pImporteFinal", DbType.Decimal, pItem.ImporteFinal);
            db.AddInParameter(dbCommand, "pImporteMayorista", DbType.Decimal, pItem.ImporteMayorista);
            db.AddInParameter(dbCommand, "pImporteDiseno", DbType.Decimal, pItem.ImporteDiseno);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(MetasBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Metas_Elimina");

            db.AddInParameter(dbCommand, "pIdMeta", DbType.Int32, pItem.IdMeta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<MetasBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Metas_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MetasBE> Metaslist = new List<MetasBE>();
            MetasBE Metas;
            while (reader.Read())
            {
                Metas = new MetasBE();
                Metas.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Metas.IdMeta = Int32.Parse(reader["IdMeta"].ToString());
                Metas.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Metas.DescTienda = reader["DescTienda"].ToString();
                Metas.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Metas.Cargo = reader["Cargo"].ToString();
                Metas.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Metas.Mes = Int32.Parse(reader["Mes"].ToString());
                Metas.NombreMes = reader["NombreMes"].ToString();
                Metas.Importe = Decimal.Parse(reader["Importe"].ToString());
                Metas.ImporteFinal = Decimal.Parse(reader["ImporteFinal"].ToString());
                Metas.ImporteMayorista = Decimal.Parse(reader["ImporteMayorista"].ToString());
                Metas.ImporteDiseno = Decimal.Parse(reader["ImporteDiseno"].ToString());
                Metas.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Metaslist.Add(Metas);
            }
            reader.Close();
            reader.Dispose();
            return Metaslist;
        }

        public List<MetasBE> ListaPeriodo(int IdEmpresa, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Metas_ListaPeriodo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MetasBE> Metaslist = new List<MetasBE>();
            MetasBE Metas;
            while (reader.Read())
            {
                Metas = new MetasBE();
                Metas.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Metas.IdMeta = Int32.Parse(reader["IdMeta"].ToString());
                Metas.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Metas.DescTienda = reader["DescTienda"].ToString();
                Metas.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Metas.Cargo = reader["Cargo"].ToString();
                Metas.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Metas.Mes = Int32.Parse(reader["Mes"].ToString());
                Metas.NombreMes = reader["NombreMes"].ToString();
                Metas.Importe = Decimal.Parse(reader["Importe"].ToString());
                Metas.ImporteFinal = Decimal.Parse(reader["ImporteFinal"].ToString());
                Metas.ImporteMayorista = Decimal.Parse(reader["ImporteMayorista"].ToString());
                Metas.ImporteDiseno = Decimal.Parse(reader["ImporteDiseno"].ToString());
                Metas.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Metaslist.Add(Metas);
            }
            reader.Close();
            reader.Dispose();
            return Metaslist;
        }


        public MetasBE Selecciona(int IdEmpresa, int IdMeta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Metas_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMeta", DbType.Int32, IdMeta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MetasBE Metas = null;
            while (reader.Read())
            {
                Metas = new MetasBE();
                Metas.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Metas.IdMeta = Int32.Parse(reader["IdMeta"].ToString());
                Metas.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Metas.DescTienda = reader["DescTienda"].ToString();
                Metas.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Metas.Cargo = reader["Cargo"].ToString();
                Metas.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Metas.Mes = Int32.Parse(reader["Mes"].ToString());
                Metas.NombreMes = reader["NombreMes"].ToString();
                Metas.Importe = Decimal.Parse(reader["Importe"].ToString());
                Metas.ImporteFinal = Decimal.Parse(reader["ImporteFinal"].ToString());
                Metas.ImporteMayorista = Decimal.Parse(reader["ImporteMayorista"].ToString());
                Metas.ImporteDiseno = Decimal.Parse(reader["ImporteDiseno"].ToString());
                Metas.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Metas;
        }

        public MetasBE SeleccionaCargoMes(int IdEmpresa, int IdTienda, int Periodo, int Mes, int IdCargo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Metas_SeleccionaCargoMes");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, IdCargo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MetasBE Metas = null;
            while (reader.Read())
            {
                Metas = new MetasBE();
                Metas.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Metas.IdMeta = Int32.Parse(reader["IdMeta"].ToString());
                Metas.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Metas.DescTienda = reader["DescTienda"].ToString();
                Metas.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Metas.Cargo = reader["Cargo"].ToString();
                Metas.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Metas.Mes = Int32.Parse(reader["Mes"].ToString());
                Metas.NombreMes = reader["NombreMes"].ToString();
                Metas.Importe = Decimal.Parse(reader["Importe"].ToString());
                Metas.ImporteFinal = Decimal.Parse(reader["ImporteFinal"].ToString());
                Metas.ImporteMayorista = Decimal.Parse(reader["ImporteMayorista"].ToString());
                Metas.ImporteDiseno = Decimal.Parse(reader["ImporteDiseno"].ToString());
                Metas.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Metas;
        }

    }
}
