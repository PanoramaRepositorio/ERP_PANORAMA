using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteNumeracionDocumentoDL
    {
        public List<ReporteNumeracionDocumentoBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptNumeracionDocumento");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteNumeracionDocumentoBE> NumeracionDocumentolist = new List<ReporteNumeracionDocumentoBE>();
            ReporteNumeracionDocumentoBE NumeracionDocumento;
            while (reader.Read())
            {
                NumeracionDocumento = new ReporteNumeracionDocumentoBE();
                NumeracionDocumento.IdNumeracionDocumento = Int32.Parse(reader["idNumeracionDocumento"].ToString());
                NumeracionDocumento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                NumeracionDocumento.Periodo = Int32.Parse(reader["periodo"].ToString());
                NumeracionDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                NumeracionDocumento.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                NumeracionDocumento.Serie = Int32.Parse(reader["serie"].ToString());
                NumeracionDocumento.Numero = Int32.Parse(reader["numero"].ToString());
                NumeracionDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                NumeracionDocumentolist.Add(NumeracionDocumento);
            }
            reader.Close();
            reader.Dispose();
            return NumeracionDocumentolist;
        }
    }
}

