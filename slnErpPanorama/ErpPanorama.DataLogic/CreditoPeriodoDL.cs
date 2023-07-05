using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CreditoPeriodoDL
    {
        public CreditoPeriodoDL() { }

        public List<CreditoPeriodoBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptListaCreditoPeriodo");
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CreditoPeriodoBE> CreditoPeriodolist = new List<CreditoPeriodoBE>();
            CreditoPeriodoBE CreditoPeriodo;
            while (reader.Read())
            {
                CreditoPeriodo = new CreditoPeriodoBE();
                CreditoPeriodo.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                CreditoPeriodo.DescCliente = reader["DescCliente"].ToString();
                CreditoPeriodo.Periodo = Int32.Parse(reader["Periodo"].ToString());
                CreditoPeriodo.Enero = Decimal.Parse(reader["Enero"].ToString());
                CreditoPeriodo.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                CreditoPeriodo.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                CreditoPeriodo.Abril = Decimal.Parse(reader["Abril"].ToString());
                CreditoPeriodo.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                CreditoPeriodo.Junio = Decimal.Parse(reader["Junio"].ToString());
                CreditoPeriodo.Julio = Decimal.Parse(reader["Julio"].ToString());
                CreditoPeriodo.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                CreditoPeriodo.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                CreditoPeriodo.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                CreditoPeriodo.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                CreditoPeriodo.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                CreditoPeriodolist.Add(CreditoPeriodo);
            }
            reader.Close();
            reader.Dispose();
            return CreditoPeriodolist;
        }
    }
}
