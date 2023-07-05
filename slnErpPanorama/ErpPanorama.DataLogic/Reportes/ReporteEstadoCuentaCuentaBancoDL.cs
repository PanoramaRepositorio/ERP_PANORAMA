using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteEstadoCuentaCuentaBancoDL
    {
        public List<ReporteEstadoCuentaCuentaBancoBE> Listado(int IdEmpresa, int IdCuentaBancoDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuenta_CuentaBanco");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, IdCuentaBancoDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEstadoCuentaCuentaBancoBE> ReporteEstadoCuentaCabeceralist = new List<ReporteEstadoCuentaCuentaBancoBE>();
            ReporteEstadoCuentaCuentaBancoBE ReporteEstadoCuentaCabecera;
            while (reader.Read())
            {
                ReporteEstadoCuentaCabecera = new ReporteEstadoCuentaCuentaBancoBE();
                ReporteEstadoCuentaCabecera.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteEstadoCuentaCabecera.Numero = reader["Numero"].ToString();
                ReporteEstadoCuentaCabecera.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteEstadoCuentaCabecera.DescCliente = reader["descCliente"].ToString();
                ReporteEstadoCuentaCabecera.Direccion = reader["direccion"].ToString();
                ReporteEstadoCuentaCabecera.Importe = Decimal.Parse(reader["Importe"].ToString());
                ReporteEstadoCuentaCabecera.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                ReporteEstadoCuentaCabecera.FechaDeposito = DateTime.Parse(reader["FechaDeposito"].ToString());
                ReporteEstadoCuentaCabecera.Observacion = reader["Observacion"].ToString();
                ReporteEstadoCuentaCabecera.DescBanco = reader["DescBanco"].ToString();
                ReporteEstadoCuentaCabecera.DescMoneda = reader["DescMoneda"].ToString();
                ReporteEstadoCuentaCabecera.NumeroPedido = reader["NumeroPedido"].ToString();
                ReporteEstadoCuentaCabecera.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                ReporteEstadoCuentaCabecera.NumeroPedido = reader["NumeroPedido"].ToString();
                ReporteEstadoCuentaCabecera.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                ReporteEstadoCuentaCabecera.DescFormaPago = reader["DescFormaPago"].ToString();
                ReporteEstadoCuentaCabecera.DescMotivo = reader["DescMotivo"].ToString();
                ReporteEstadoCuentaCabeceralist.Add(ReporteEstadoCuentaCabecera);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEstadoCuentaCabeceralist;
        }
    }
}
