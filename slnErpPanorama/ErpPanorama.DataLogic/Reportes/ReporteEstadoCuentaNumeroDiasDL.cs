using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteEstadoCuentaNumeroDiasDL
    {
        public List<ReporteEstadoCuentaNumeroDiasBE> Listado(int IdEmpresa, int NumeroDias, int IdTipoCliente, int IdClasificacionCliente, int IdMotivo, DateTime fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuentaNumeroDias");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumeroDias", DbType.Int32, NumeroDias);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdClasificacionCliente", DbType.Int32, IdClasificacionCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEstadoCuentaNumeroDiasBE> ReporteEstadoCuentaNumeroDiaslist = new List<ReporteEstadoCuentaNumeroDiasBE>();
            ReporteEstadoCuentaNumeroDiasBE ReporteEstadoCuentaNumeroDias;
            while (reader.Read())
            {
                ReporteEstadoCuentaNumeroDias = new ReporteEstadoCuentaNumeroDiasBE();
                ReporteEstadoCuentaNumeroDias.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteEstadoCuentaNumeroDias.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ReporteEstadoCuentaNumeroDias.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteEstadoCuentaNumeroDias.DescCliente = reader["descCliente"].ToString();
                ReporteEstadoCuentaNumeroDias.NumeroDias = Int32.Parse(reader["NumeroDias"].ToString());
                ReporteEstadoCuentaNumeroDias.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                ReporteEstadoCuentaNumeroDiaslist.Add(ReporteEstadoCuentaNumeroDias);
            }
            reader.Close();
            reader.Dispose();
            return ReporteEstadoCuentaNumeroDiaslist;
        }
    }
}
