using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteEstadoCuentaCabeceraDL
    {
        public List<ReporteEstadoCuentaCabeceraBE> Listado(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuentaCabecera");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo ", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEstadoCuentaCabeceraBE> ReporteEstadoCuentaCabeceralist = new List<ReporteEstadoCuentaCabeceraBE>();
            ReporteEstadoCuentaCabeceraBE ReporteEstadoCuentaCabecera;
            while (reader.Read())
            {
                ReporteEstadoCuentaCabecera = new ReporteEstadoCuentaCabeceraBE();
                ReporteEstadoCuentaCabecera.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteEstadoCuentaCabecera.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteEstadoCuentaCabecera.DescCliente = reader["descCliente"].ToString();
                ReporteEstadoCuentaCabecera.Direccion = reader["direccion"].ToString();
                ReporteEstadoCuentaCabecera.Telefono = reader["telefono"].ToString();
                ReporteEstadoCuentaCabecera.Celular = reader["celular"].ToString();
                ReporteEstadoCuentaCabecera.OtroTelefono = reader["otroTelefono"].ToString();
                ReporteEstadoCuentaCabecera.Email = reader["email"].ToString();
                ReporteEstadoCuentaCabecera.LineaCredito = Decimal.Parse(reader["lineaCredito"].ToString());
                ReporteEstadoCuentaCabecera.LineaCreditoUtilizada = Decimal.Parse(reader["LineaCreditoUtilizada"].ToString());
                ReporteEstadoCuentaCabecera.LineaCreditoDisponible = Decimal.Parse(reader["LineaCreditoDisponible"].ToString());
                ReporteEstadoCuentaCabecera.SaldoAnterior = Decimal.Parse(reader["Garantia"].ToString());
                ReporteEstadoCuentaCabeceralist.Add(ReporteEstadoCuentaCabecera);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEstadoCuentaCabeceralist;
        }
    }
}
