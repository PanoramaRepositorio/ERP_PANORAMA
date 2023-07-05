using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCajaDL
    {
        public List<ReporteCajaBE> Listado(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCaja");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCajaBE> lista = new List<ReporteCajaBE>();
            ReporteCajaBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteCajaBE();
                reporte.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                reporte.RazonSocial = reader["razonSocial"].ToString();
                reporte.IdTienda = Int32.Parse(reader["idTienda"].ToString());
                reporte.DescTienda = reader["descTienda"].ToString();
                reporte.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                reporte.DescCaja = reader["descCaja"].ToString();
                reporte.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
