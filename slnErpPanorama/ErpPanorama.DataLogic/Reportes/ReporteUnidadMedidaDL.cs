using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteUnidadMedidaDL
    {
        public List<ReporteUnidadMedidaBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptUnidadMedida");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteUnidadMedidaBE> UnidadMedidalist = new List<ReporteUnidadMedidaBE>();
            ReporteUnidadMedidaBE UnidadMedida;
            while (reader.Read())
            {
                UnidadMedida = new ReporteUnidadMedidaBE();
                UnidadMedida.IdUnidadMedida = Int32.Parse(reader["idUnidadMedida"].ToString());
                UnidadMedida.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                UnidadMedida.Abreviatura = reader["Abreviatura"].ToString();
                UnidadMedida.DescUnidadMedida = reader["descUnidadMedida"].ToString();
                UnidadMedida.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UnidadMedidalist.Add(UnidadMedida);
            }
            reader.Close();
            reader.Dispose();
            return UnidadMedidalist;
        }
    }
}
