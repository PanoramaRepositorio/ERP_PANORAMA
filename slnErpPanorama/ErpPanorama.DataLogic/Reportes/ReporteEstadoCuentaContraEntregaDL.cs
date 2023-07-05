using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteEstadoCuentaContraEntregaDL
    {
        public List<ReporteEstadoCuentaContraEntregaBE> Listado(int IdEmpresa, int IdMotivo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuentaContraEntrega");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEstadoCuentaContraEntregaBE> ReporteEstadoCuentaContraEntregalist = new List<ReporteEstadoCuentaContraEntregaBE>();
            ReporteEstadoCuentaContraEntregaBE ReporteEstadoCuentaContraEntrega;
            while (reader.Read())
            {
                ReporteEstadoCuentaContraEntrega = new ReporteEstadoCuentaContraEntregaBE();
                ReporteEstadoCuentaContraEntrega.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteEstadoCuentaContraEntrega.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteEstadoCuentaContraEntrega.DescCliente = reader["descCliente"].ToString();
                ReporteEstadoCuentaContraEntrega.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                ReporteEstadoCuentaContraEntrega.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                ReporteEstadoCuentaContraEntrega.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                ReporteEstadoCuentaContraEntregalist.Add(ReporteEstadoCuentaContraEntrega);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEstadoCuentaContraEntregalist;
        }

    }
}
