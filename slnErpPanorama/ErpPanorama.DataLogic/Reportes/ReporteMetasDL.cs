using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMetasDL
    {
        public List<ReporteMetasBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptMetas");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMetasBE> Metaslist = new List<ReporteMetasBE>();
            ReporteMetasBE Metas;
            while (reader.Read())
            {
                Metas = new ReporteMetasBE();
                Metas.IdMeta = Int32.Parse(reader["idMeta"].ToString());
                Metas.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Metas.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Metas.Mes = Int32.Parse(reader["Mes"].ToString());
                Metas.NombreMes = reader["NombreMes"].ToString();
                Metas.DescTienda = reader["DescTienda"].ToString();
                Metas.Cargo = reader["Cargo"].ToString();
                Metas.Importe = Decimal.Parse(reader["Importe"].ToString());
                Metas.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Metaslist.Add(Metas);
            }
            reader.Close();
            reader.Dispose();
            return Metaslist;
        }
    }
}
