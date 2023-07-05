using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteSeparacionDetalleDL
    {
        public List<ReporteSeparacionDetalleBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSeparacionDetalle");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSeparacionDetalleBE> ReporteSeparacionDetallelist = new List<ReporteSeparacionDetalleBE>();
            ReporteSeparacionDetalleBE ReporteSeparacionDetalle;
            while (reader.Read())
            {
                ReporteSeparacionDetalle = new ReporteSeparacionDetalleBE();
                ReporteSeparacionDetalle.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteSeparacionDetalle.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteSeparacionDetalle.FechaSeparacion = DateTime.Parse(reader["FechaSeparacion"].ToString());
                ReporteSeparacionDetalle.FechaPago = DateTime.Parse(reader["FechaPago"].ToString());
                ReporteSeparacionDetalle.Concepto = reader["Concepto"].ToString();
                ReporteSeparacionDetalle.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteSeparacionDetalle.TipoMovimiento = reader["TipoMovimiento"].ToString();
                ReporteSeparacionDetalle.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                ReporteSeparacionDetalle.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                ReporteSeparacionDetalle.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                ReporteSeparacionDetallelist.Add(ReporteSeparacionDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ReporteSeparacionDetallelist;
        }
    }
}

