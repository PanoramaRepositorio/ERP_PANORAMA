﻿using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteVentaDataTicketDL
    {
        public DataTable Listado(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            DataTable dtTmp = new DataTable();

            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptVentaDataTicketsPorMes");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            dtTmp.Load(reader);

            reader.Close();
            reader.Dispose();
            return dtTmp;
        }

        public DataTable ListadoVtasDiarias(int IdEmpresa, int IdTienda, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            DataTable dtTmp = new DataTable();

            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptVentaDataTicketsPorMes_lc");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            dtTmp.Load(reader);

            reader.Close();
            reader.Dispose();
            return dtTmp;
        }

    }
}
