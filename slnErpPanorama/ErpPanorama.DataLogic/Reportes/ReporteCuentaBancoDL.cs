using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCuentaBancoDL
    {
        public List<ReporteCuentaBancoBE> Listado(int IdEmpresa, int IdBanco)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCuentaBanco");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, IdBanco);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCuentaBancoBE> CuentaBancolist = new List<ReporteCuentaBancoBE>();
            ReporteCuentaBancoBE CuentaBanco;
            while (reader.Read())
            {
                CuentaBanco = new ReporteCuentaBancoBE();
                CuentaBanco.IdCuentaBanco = Int32.Parse(reader["idCuentaBanco"].ToString());
                CuentaBanco.IdBanco = Int32.Parse(reader["idBanco"].ToString());
                CuentaBanco.DescBanco = reader["descBanco"].ToString();
                CuentaBanco.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                CuentaBanco.RazonSocial = reader["razonSocial"].ToString();
                CuentaBanco.NumeroCuenta = reader["numeroCuenta"].ToString();
                CuentaBanco.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                CuentaBanco.Moneda = reader["Moneda"].ToString();
                CuentaBanco.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CuentaBancolist.Add(CuentaBanco);
            }
            reader.Close();
            reader.Dispose();
            return CuentaBancolist;
        }
    }
}
