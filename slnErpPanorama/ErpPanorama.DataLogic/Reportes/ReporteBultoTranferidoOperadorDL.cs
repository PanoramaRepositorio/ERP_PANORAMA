using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteBultoTranferidoOperadorDL
    {
        public List<ReporteBultoTranferidoOperadorBE> Listado(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaTransferenciaAnaquelesOperadorResumen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteBultoTranferidoOperadorBE> Lista = new List<ReporteBultoTranferidoOperadorBE>();
            ReporteBultoTranferidoOperadorBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteBultoTranferidoOperadorBE();
                Reporte.UsuarioSalida = reader["UsuarioSalida"].ToString();
                Reporte.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }
    }
}
