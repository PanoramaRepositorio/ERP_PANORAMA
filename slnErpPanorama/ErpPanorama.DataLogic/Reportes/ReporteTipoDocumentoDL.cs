using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTipoDocumentoDL
    {
        public List<ReporteTipoDocumentoBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptTipoDocumento");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTipoDocumentoBE> TipoDocumentolist = new List<ReporteTipoDocumentoBE>();
            ReporteTipoDocumentoBE TipoDocumento;
            while (reader.Read())
            {
                TipoDocumento = new ReporteTipoDocumentoBE();
                TipoDocumento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TipoDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                TipoDocumento.CodTipoDocumento = reader["codTipoDocumento"].ToString();
                TipoDocumento.DescTipoDocumento = reader["descTipoDocumento"].ToString();
                TipoDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoDocumentolist.Add(TipoDocumento);
            }
            reader.Close();
            reader.Dispose();
            return TipoDocumentolist;
        }
    }
}
