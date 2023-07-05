using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteComisionJefeProduccionDL
    {
        public List<ReporteComisionJefeProduccionBE> ListadoCalculoComision(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ComisionJefeProduccion");
            db.AddInParameter(dbCommand, "FecInicio", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "FecFin", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteComisionJefeProduccionBE> ComisionList = new List<ReporteComisionJefeProduccionBE>();
            ReporteComisionJefeProduccionBE ComisionJP;
            while (reader.Read())
            {
                ComisionJP = new ReporteComisionJefeProduccionBE();
                ComisionJP.Dni = reader["DNI"].ToString();
                ComisionJP.ApeNom = reader["NOMBRES"].ToString();
                ComisionJP.Cargo = reader["CARGO"].ToString();
                ComisionJP.Sueldo = Decimal.Parse(reader["SUELDO"].ToString());
                ComisionJP.ValorVenta005 = Decimal.Parse(reader["VALORVENTA005"].ToString());
                ComisionJP.ValorVenta0015 = Decimal.Parse(reader["VALORVENTA0015"].ToString());

                ComisionList.Add(ComisionJP);
            }
            reader.Close();
            reader.Dispose();
            return ComisionList;
        }

        public List<ReporteHoraExtraBE> ListadoResumen(DateTime FechaDesde, DateTime FechaHasta, int IdPersona, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptHoraExtra");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteHoraExtraBE> HoraExtralist = new List<ReporteHoraExtraBE>();
            ReporteHoraExtraBE HoraExtra;
            while (reader.Read())
            {
                HoraExtra = new ReporteHoraExtraBE();
                HoraExtra.Dni = reader["Dni"].ToString();
                HoraExtra.ApeNom = reader["ApeNom"].ToString();
                HoraExtra.Importe = Decimal.Parse(reader["Importe"].ToString());
                HoraExtralist.Add(HoraExtra);
            }
            reader.Close();
            reader.Dispose();
            return HoraExtralist;
        }
    }
}
