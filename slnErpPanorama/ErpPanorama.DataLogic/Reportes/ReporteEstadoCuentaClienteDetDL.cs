using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteEstadoCuentaClienteDetDL
    {
        public List<ReporteEstadoCuentaClienteDetBE> Listado(int IdEmpresa, int IdCliente, string TipoMovimiento, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuentaClienteDet");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEstadoCuentaClienteDetBE> EstadoCuentaClienteDetlist = new List<ReporteEstadoCuentaClienteDetBE>();
            ReporteEstadoCuentaClienteDetBE EstadoCuentaClienteDet;
            while (reader.Read())
            {
                EstadoCuentaClienteDet = new ReporteEstadoCuentaClienteDetBE();
                EstadoCuentaClienteDet.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaClienteDet.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaClienteDet.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaClienteDet.Concepto = reader["Concepto"].ToString();
                EstadoCuentaClienteDet.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                EstadoCuentaClienteDet.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaClienteDet.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaClienteDet.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaClienteDet.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaClienteDet.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaClienteDet.Observacion = reader["Observacion"].ToString();
                EstadoCuentaClienteDet.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaClienteDetlist.Add(EstadoCuentaClienteDet);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaClienteDetlist;
        }
    }
}
