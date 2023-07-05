using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteSeparacionCabeceraDL
    {
        public List<ReporteSeparacionCabeceraBE> Listado(int IdEmpresa, int IdCliente, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSeparacionCabecera");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteSeparacionCabeceraBE> ReporteSeparacionCabeceralist = new List<ReporteSeparacionCabeceraBE>();
            ReporteSeparacionCabeceraBE ReporteSeparacionCabecera;
            while (reader.Read())
            {
                ReporteSeparacionCabecera = new ReporteSeparacionCabeceraBE();
                ReporteSeparacionCabecera.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteSeparacionCabecera.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteSeparacionCabecera.DescCliente = reader["descCliente"].ToString();
                ReporteSeparacionCabecera.Direccion = reader["direccion"].ToString();
                ReporteSeparacionCabecera.Telefono = reader["telefono"].ToString();
                ReporteSeparacionCabecera.Celular = reader["celular"].ToString();
                ReporteSeparacionCabecera.OtroTelefono = reader["otroTelefono"].ToString();
                ReporteSeparacionCabecera.Email = reader["email"].ToString();
                ReporteSeparacionCabecera.LineaCredito = Decimal.Parse(reader["lineaCredito"].ToString());
                ReporteSeparacionCabecera.LineaCreditoUtilizada = Decimal.Parse(reader["LineaCreditoUtilizada"].ToString());
                ReporteSeparacionCabecera.LineaCreditoDisponible = Decimal.Parse(reader["LineaCreditoDisponible"].ToString());
                ReporteSeparacionCabecera.SaldoAnterior = Decimal.Parse(reader["Garantia"].ToString());
                ReporteSeparacionCabeceralist.Add(ReporteSeparacionCabecera);
            }
            reader.Close();
            reader.Dispose();
            return ReporteSeparacionCabeceralist;
        }
    }
}
