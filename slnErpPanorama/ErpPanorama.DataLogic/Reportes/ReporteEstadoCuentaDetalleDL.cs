using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteEstadoCuentaDetalleDL
    {
        public List<ReporteEstadoCuentaDetalleBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuentaDetalle");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEstadoCuentaDetalleBE> ReporteEstadoCuentaDetallelist = new List<ReporteEstadoCuentaDetalleBE>();
            ReporteEstadoCuentaDetalleBE ReporteEstadoCuentaDetalle;
            while (reader.Read())
            {
                ReporteEstadoCuentaDetalle = new ReporteEstadoCuentaDetalleBE();
                ReporteEstadoCuentaDetalle.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteEstadoCuentaDetalle.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteEstadoCuentaDetalle.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                ReporteEstadoCuentaDetalle.FechaDeposito = DateTime.Parse(reader["FechaDeposito"].ToString());
                ReporteEstadoCuentaDetalle.Concepto = reader["Concepto"].ToString();
                ReporteEstadoCuentaDetalle.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteEstadoCuentaDetalle.TipoMovimiento = reader["TipoMovimiento"].ToString();
                ReporteEstadoCuentaDetalle.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                ReporteEstadoCuentaDetalle.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                ReporteEstadoCuentaDetalle.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                ReporteEstadoCuentaDetallelist.Add(ReporteEstadoCuentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEstadoCuentaDetallelist;
        }
    }
}
