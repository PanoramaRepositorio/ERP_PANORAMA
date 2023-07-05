using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDocumentoVentaEmpresaSerieDL
    {
        public List<ReporteDocumentoVentaEmpresaSerieBE> Listado(int IdEmpresa, int IdTipoDocumento, string Serie, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDocumentoVentaEmpresaSerieDiario");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaEmpresaSerieBE> ReporteDocumentoVentaEmpresaSerielist = new List<ReporteDocumentoVentaEmpresaSerieBE>();
            ReporteDocumentoVentaEmpresaSerieBE ReporteDocumentoVentaEmpresaSerie;
            while (reader.Read())
            {
                ReporteDocumentoVentaEmpresaSerie = new ReporteDocumentoVentaEmpresaSerieBE();
                ReporteDocumentoVentaEmpresaSerie.RazonSocial = reader["RazonSocial"].ToString();
                ReporteDocumentoVentaEmpresaSerie.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ReporteDocumentoVentaEmpresaSerie.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                ReporteDocumentoVentaEmpresaSerie.Serie = reader["Serie"].ToString();
                ReporteDocumentoVentaEmpresaSerie.Inicio = reader["Inicio"].ToString();
                ReporteDocumentoVentaEmpresaSerie.Fin = reader["Fin"].ToString();
                ReporteDocumentoVentaEmpresaSerie.Numero = reader["Numero"].ToString();
                ReporteDocumentoVentaEmpresaSerie.BaseImponible = Decimal.Parse(reader["BaseImponible"].ToString());
                ReporteDocumentoVentaEmpresaSerie.IGV = Decimal.Parse(reader["IGV"].ToString());
                ReporteDocumentoVentaEmpresaSerie.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                ReporteDocumentoVentaEmpresaSerielist.Add(ReporteDocumentoVentaEmpresaSerie);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoVentaEmpresaSerielist;
        }

        public List<ReporteDocumentoVentaEmpresaSerieBE> ListadoSerieResumen(int IdEmpresa, int IdTipoDocumento, string Serie, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDocumentoVentaEmpresaSerieResumen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaEmpresaSerieBE> ReporteDocumentoVentaEmpresaSerielist = new List<ReporteDocumentoVentaEmpresaSerieBE>();
            ReporteDocumentoVentaEmpresaSerieBE ReporteDocumentoVentaEmpresaSerie;
            while (reader.Read())
            {
                ReporteDocumentoVentaEmpresaSerie = new ReporteDocumentoVentaEmpresaSerieBE();
                ReporteDocumentoVentaEmpresaSerie.RazonSocial = reader["RazonSocial"].ToString();
                ReporteDocumentoVentaEmpresaSerie.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                ReporteDocumentoVentaEmpresaSerie.Serie = reader["Serie"].ToString();
                ReporteDocumentoVentaEmpresaSerie.Inicio = reader["Inicio"].ToString();
                ReporteDocumentoVentaEmpresaSerie.Fin = reader["Fin"].ToString();
                ReporteDocumentoVentaEmpresaSerie.Numero = reader["Numero"].ToString();
                ReporteDocumentoVentaEmpresaSerie.BaseImponible = Decimal.Parse(reader["BaseImponible"].ToString());
                ReporteDocumentoVentaEmpresaSerie.IGV = Decimal.Parse(reader["IGV"].ToString());
                ReporteDocumentoVentaEmpresaSerie.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                ReporteDocumentoVentaEmpresaSerielist.Add(ReporteDocumentoVentaEmpresaSerie);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoVentaEmpresaSerielist;
        }

        public List<ReporteDocumentoVentaEmpresaSerieBE> ListadoTipoDocumento(int IdEmpresa, int IdTipoDocumento,string Serie , DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDocumentoVentaTipoDocumentoResumen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaEmpresaSerieBE> ReporteDocumentoVentaEmpresaSerielist = new List<ReporteDocumentoVentaEmpresaSerieBE>();
            ReporteDocumentoVentaEmpresaSerieBE ReporteDocumentoVentaEmpresaSerie;
            while (reader.Read())
            {
                ReporteDocumentoVentaEmpresaSerie = new ReporteDocumentoVentaEmpresaSerieBE();
                ReporteDocumentoVentaEmpresaSerie.RazonSocial = reader["RazonSocial"].ToString();
                ReporteDocumentoVentaEmpresaSerie.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                ReporteDocumentoVentaEmpresaSerie.BaseImponible = Decimal.Parse(reader["BaseImponible"].ToString());
                ReporteDocumentoVentaEmpresaSerie.IGV = Decimal.Parse(reader["IGV"].ToString());
                ReporteDocumentoVentaEmpresaSerie.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                ReporteDocumentoVentaEmpresaSerielist.Add(ReporteDocumentoVentaEmpresaSerie);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoVentaEmpresaSerielist;
        }


    }
}
