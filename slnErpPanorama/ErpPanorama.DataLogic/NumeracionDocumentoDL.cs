using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class NumeracionDocumentoDL
    {
        public NumeracionDocumentoDL() { }

        public void Inserta(NumeracionDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionDocumento_Inserta");

            db.AddInParameter(dbCommand, "pIdNumeracionDocumento", DbType.Int32, pItem.IdNumeracionDocumento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, pItem.Numero);
            db.AddInParameter(dbCommand, "pNumeroCaracter", DbType.Int32, pItem.NumeroCaracter);
            db.AddInParameter(dbCommand, "pFlagFacturacion", DbType.Boolean, pItem.FlagFacturacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(NumeracionDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionDocumento_Actualiza");

            db.AddInParameter(dbCommand, "pIdNumeracionDocumento", DbType.Int32, pItem.IdNumeracionDocumento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, pItem.Numero);
            db.AddInParameter(dbCommand, "pNumeroCaracter", DbType.Int32, pItem.NumeroCaracter);
            db.AddInParameter(dbCommand, "pFlagFacturacion", DbType.Boolean, pItem.FlagFacturacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCorrelativoPeriodo(int IdEmpresa, int IdTipoDocumento, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionDocumento_ActualizarCorrelativoPeriodo");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCorrelativoSerie(int IdEmpresa, int IdTipoDocumento, string Serie)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionDocumento_ActualizarCorrelativoSerie");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(NumeracionDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionDocumento_Elimina");

            db.AddInParameter(dbCommand, "pIdNumeracionDocumento", DbType.Int32, pItem.IdNumeracionDocumento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<NumeracionDocumentoBE> ObtenerCorrelativoPeriodo(int IdEmpresa, int IdTipoDocumento, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionDocumento_ObtenerCorrelativoPeriodo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<NumeracionDocumentoBE> NumeracionDocumentolist = new List<NumeracionDocumentoBE>();
            NumeracionDocumentoBE NumeracionDocumento;
            while (reader.Read())
            {
                NumeracionDocumento = new NumeracionDocumentoBE();
                NumeracionDocumento.IdNumeracionDocumento = Int32.Parse(reader["IdNumeracionDocumento"].ToString());
                NumeracionDocumento.Serie = reader["Serie"].ToString();
                NumeracionDocumento.Numero = Int32.Parse(reader["Numero"].ToString());
                NumeracionDocumento.NumeroCaracter = Int32.Parse(reader["NumeroCaracter"].ToString());
                NumeracionDocumentolist.Add(NumeracionDocumento);
            }
            reader.Close();
            reader.Dispose();
            return NumeracionDocumentolist;
        }

        public List<NumeracionDocumentoBE> ObtenerCorrelativoPeriodo(int IdEmpresa, int IdTienda, int IdTipoDocumento, bool FlagFacturacion, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionDocumento_ObtenerCorrelativoTiendaPeriodo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pFlagFacturacion", DbType.Int32, FlagFacturacion);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<NumeracionDocumentoBE> NumeracionDocumentolist = new List<NumeracionDocumentoBE>();
            NumeracionDocumentoBE NumeracionDocumento;
            while (reader.Read())
            {
                NumeracionDocumento = new NumeracionDocumentoBE();
                NumeracionDocumento.IdNumeracionDocumento = Int32.Parse(reader["IdNumeracionDocumento"].ToString());
                NumeracionDocumento.Serie = reader["Serie"].ToString();
                NumeracionDocumento.Numero = Int32.Parse(reader["Numero"].ToString());
                NumeracionDocumento.NumeroCaracter = Int32.Parse(reader["NumeroCaracter"].ToString());
                NumeracionDocumentolist.Add(NumeracionDocumento);
            }
            reader.Close();
            reader.Dispose();
            return NumeracionDocumentolist;
        }
        public List<NumeracionDocumentoBE> ObtenerCorrelativoSerie(int IdEmpresa, int IdTipoDocumento, string Serie)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionDocumento_ObtenerCorrelativoSerie");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<NumeracionDocumentoBE> NumeracionDocumentolist = new List<NumeracionDocumentoBE>();
            NumeracionDocumentoBE NumeracionDocumento;
            while (reader.Read())
            {
                NumeracionDocumento = new NumeracionDocumentoBE();
                NumeracionDocumento.IdNumeracionDocumento = Int32.Parse(reader["IdNumeracionDocumento"].ToString());
                NumeracionDocumento.Serie = reader["Serie"].ToString();
                NumeracionDocumento.Numero = Int32.Parse(reader["Numero"].ToString());
                NumeracionDocumento.NumeroCaracter = Int32.Parse(reader["NumeroCaracter"].ToString());
                NumeracionDocumentolist.Add(NumeracionDocumento);
            }
            reader.Close();
            reader.Dispose();
            return NumeracionDocumentolist;
        }

        public List<NumeracionDocumentoBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionDocumento_ListaTodosActivo");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<NumeracionDocumentoBE> NumeracionDocumentolist = new List<NumeracionDocumentoBE>();
            NumeracionDocumentoBE NumeracionDocumento;
            while (reader.Read())
            {
                NumeracionDocumento = new NumeracionDocumentoBE();
                NumeracionDocumento.IdNumeracionDocumento = Int32.Parse(reader["idNumeracionDocumento"].ToString());
                NumeracionDocumento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                NumeracionDocumento.RazonSocial = reader["RazonSocial"].ToString();
                NumeracionDocumento.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                NumeracionDocumento.DescTienda = reader["DescTienda"].ToString();
                NumeracionDocumento.Periodo = Int32.Parse(reader["periodo"].ToString());
                NumeracionDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                NumeracionDocumento.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                NumeracionDocumento.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                NumeracionDocumento.Serie = reader["serie"].ToString();
                NumeracionDocumento.Numero = Int32.Parse(reader["numero"].ToString());
                NumeracionDocumento.NumeroCaracter = Int32.Parse(reader["NumeroCaracter"].ToString());
                NumeracionDocumento.FlagFacturacion = Boolean.Parse(reader["FlagFacturacion"].ToString());
                NumeracionDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                NumeracionDocumentolist.Add(NumeracionDocumento);
            }
            reader.Close();
            reader.Dispose();
            return NumeracionDocumentolist;
        }

        public NumeracionDocumentoBE SeleccionaNumero(int IdEmpresa, int IdTipoDocumento, int Periodo, string Serie)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionDocumento_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);

            IDataReader reader = db.ExecuteReader(dbCommand);
            NumeracionDocumentoBE NumeracionDocumento = null;
            while (reader.Read())
            {
                NumeracionDocumento = new NumeracionDocumentoBE();
                NumeracionDocumento.IdNumeracionDocumento = Int32.Parse(reader["idNumeracionDocumento"].ToString());
                NumeracionDocumento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                NumeracionDocumento.RazonSocial = reader["RazonSocial"].ToString();
                NumeracionDocumento.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                NumeracionDocumento.DescTienda = reader["DescTienda"].ToString();
                NumeracionDocumento.Periodo = Int32.Parse(reader["periodo"].ToString());
                NumeracionDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                NumeracionDocumento.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                NumeracionDocumento.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                NumeracionDocumento.Serie = reader["serie"].ToString();
                NumeracionDocumento.Numero = Int32.Parse(reader["numero"].ToString());
                NumeracionDocumento.NumeroCaracter = Int32.Parse(reader["NumeroCaracter"].ToString());
                NumeracionDocumento.FlagFacturacion = Boolean.Parse(reader["FlagFacturacion"].ToString());
                NumeracionDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return NumeracionDocumento;
        }
    }
}
