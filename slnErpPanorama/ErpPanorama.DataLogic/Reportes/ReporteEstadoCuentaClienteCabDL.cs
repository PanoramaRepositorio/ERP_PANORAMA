using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteEstadoCuentaClienteCabDL
    {
        public List<ReporteEstadoCuentaClienteCabBE> Listado(int IdEmpresa, int IdCliente, string TipoMovimiento, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuentaClienteCab");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEstadoCuentaClienteCabBE> EstadoCuentaClienteCablist = new List<ReporteEstadoCuentaClienteCabBE>();
            ReporteEstadoCuentaClienteCabBE EstadoCuentaClienteCab;
            while (reader.Read())
            {
                EstadoCuentaClienteCab = new ReporteEstadoCuentaClienteCabBE();
                EstadoCuentaClienteCab.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                EstadoCuentaClienteCab.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaClienteCab.DescCliente = reader["descCliente"].ToString();
                EstadoCuentaClienteCab.Direccion = reader["direccion"].ToString();
                EstadoCuentaClienteCab.Telefono = reader["Telefono"].ToString();
                EstadoCuentaClienteCab.Email = reader["Email"].ToString();
                EstadoCuentaClienteCab.EmailFE = reader["EmailFE"].ToString();
                EstadoCuentaClienteCab.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaClienteCab.TotalDeuda = Decimal.Parse(reader["TotalDeuda"].ToString());
                EstadoCuentaClienteCab.TotalAbono = Decimal.Parse(reader["TotalAbono"].ToString());
                EstadoCuentaClienteCab.TotalVencido = Decimal.Parse(reader["TotalVencido"].ToString());
                EstadoCuentaClienteCab.LineaCredito = Decimal.Parse(reader["lineaCredito"].ToString());
                EstadoCuentaClienteCab.LineaCreditoUtilizada = Decimal.Parse(reader["lineaCreditoUtilizada"].ToString());
                EstadoCuentaClienteCab.LineaCreditoDisponible = Decimal.Parse(reader["lineaCreditoDisponible"].ToString());
                EstadoCuentaClienteCablist.Add(EstadoCuentaClienteCab);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaClienteCablist;
        }
    }
}
