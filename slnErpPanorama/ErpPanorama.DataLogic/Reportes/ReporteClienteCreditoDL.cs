using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteClienteCreditoDL
    {
        public List<ReporteClienteCreditoBE> Listado(int IdEmpresa, int IdMotivo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptClienteCredito");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteCreditoBE> ClienteCreditolist = new List<ReporteClienteCreditoBE>();
            ReporteClienteCreditoBE ClienteCredito;
            while (reader.Read())
            {
                ClienteCredito = new ReporteClienteCreditoBE();
                ClienteCredito.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ClienteCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteCredito.DescCliente = reader["descCliente"].ToString();
                ClienteCredito.Direccion = reader["direccion"].ToString();
                ClienteCredito.AbrevClasifica = reader["AbrevClasifica"].ToString();
                ClienteCredito.DescMotivo = reader["DescMotivo"].ToString();
                ClienteCredito.FechaAprobacion = DateTime.Parse(reader["fechaAprobacion"].ToString());
                ClienteCredito.LineaCredito = Decimal.Parse(reader["lineaCredito"].ToString());
                ClienteCredito.LineaCreditoUtilizada = Decimal.Parse(reader["lineaCreditoUtilizada"].ToString());
                ClienteCredito.LineaCreditoDisponible = Decimal.Parse(reader["lineaCreditoDisponible"].ToString());
                ClienteCredito.NumeroDias = Int32.Parse(reader["numeroDias"].ToString());
                ClienteCredito.Garantia = Decimal.Parse(reader["Garantia"].ToString());
                ClienteCredito.Observacion = reader["Observacion"].ToString();
                ClienteCreditolist.Add(ClienteCredito);
            }
            reader.Close();
            reader.Dispose();
            return ClienteCreditolist;
        }
    }
}
