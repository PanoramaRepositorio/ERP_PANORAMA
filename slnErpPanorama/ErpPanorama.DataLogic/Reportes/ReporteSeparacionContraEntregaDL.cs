using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteSeparacionContraEntregaDL
    {
        public List<ReporteSeparacionContraEntregaBE> Listado(int IdEmpresa, int Periodo, int IdMotivo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSeparacionContraEntrega");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSeparacionContraEntregaBE> ReporteSeparacionContraEntregalist = new List<ReporteSeparacionContraEntregaBE>();
            ReporteSeparacionContraEntregaBE ReporteSeparacionContraEntrega;
            while (reader.Read())
            {
                ReporteSeparacionContraEntrega = new ReporteSeparacionContraEntregaBE();
                ReporteSeparacionContraEntrega.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteSeparacionContraEntrega.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteSeparacionContraEntrega.DescCliente = reader["descCliente"].ToString();
                ReporteSeparacionContraEntrega.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                ReporteSeparacionContraEntrega.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                ReporteSeparacionContraEntrega.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                ReporteSeparacionContraEntregalist.Add(ReporteSeparacionContraEntrega);
            }
            reader.Close();
            reader.Dispose();
            return ReporteSeparacionContraEntregalist;
        }
    }
}
