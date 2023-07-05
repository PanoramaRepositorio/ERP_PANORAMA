using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteEstudioRealizadoDL
    {
        public List<ReporteEstudioRealizadoBE> Listado(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstudioRealizado");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEstudioRealizadoBE> EstudioRealizadolist = new List<ReporteEstudioRealizadoBE>();
            ReporteEstudioRealizadoBE EstudioRealizado;
            while (reader.Read())
            {
                EstudioRealizado = new ReporteEstudioRealizadoBE();
                EstudioRealizado.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstudioRealizado.IdEstudioRealizado = Int32.Parse(reader["idEstudioRealizado"].ToString());
                EstudioRealizado.IdNivelEstudio = Int32.Parse(reader["IdNivelEstudio"].ToString());
                EstudioRealizado.DescNivelEstudio = reader["DescNivelEstudio"].ToString();
                EstudioRealizado.CentroEstudio = reader["CentroEstudio"].ToString();
                EstudioRealizado.GradoObtenido = reader["GradoObtenido"].ToString();
                EstudioRealizado.MesAnioIncio = reader["MesAnioIncio"].ToString();
                EstudioRealizado.MesAnioFin = reader["MesAnioFin"].ToString();
                EstudioRealizado.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                EstudioRealizadolist.Add(EstudioRealizado);
            }
            reader.Close();
            reader.Dispose();
            return EstudioRealizadolist;
        }
    }
}
