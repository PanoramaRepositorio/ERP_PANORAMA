using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTipoCambioDL
    {
        public List<ReporteTipoCambioBE> Listado(int IdEmpresa, int IdMoneda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptTipoCambio");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, IdMoneda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTipoCambioBE> TipoCambiolist = new List<ReporteTipoCambioBE>();
            ReporteTipoCambioBE TipoCambio;
            while (reader.Read())
            {
                TipoCambio = new ReporteTipoCambioBE();
                TipoCambio.IdTipoCambio = Int32.Parse(reader["idTipoCambio"].ToString());
                TipoCambio.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                TipoCambio.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                TipoCambio.Moneda = reader["Moneda"].ToString();
                TipoCambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                TipoCambio.Compra = Decimal.Parse(reader["Compra"].ToString());
                TipoCambio.Venta = Decimal.Parse(reader["Venta"].ToString());
                TipoCambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoCambiolist.Add(TipoCambio);
            }
            reader.Close();
            reader.Dispose();
            return TipoCambiolist;
        }
    }
}

