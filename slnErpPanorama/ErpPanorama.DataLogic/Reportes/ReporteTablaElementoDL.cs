using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTablaElementoDL
    {
        public List<ReporteTablaElementoBE> Listado()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptTablaElemento");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTablaElementoBE> TablaElementolist = new List<ReporteTablaElementoBE>();
            ReporteTablaElementoBE TablaElemento;
            while (reader.Read())
            {
                TablaElemento = new ReporteTablaElementoBE();
                TablaElemento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TablaElemento.IdTablaElemento = Int32.Parse(reader["idTablaElemento"].ToString());
                TablaElemento.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                TablaElemento.DescTabla = reader["descTabla"].ToString();
                TablaElemento.Abreviatura = reader["Abreviatura"].ToString();
                TablaElemento.DescTablaElemento = reader["descTablaElemento"].ToString();
                TablaElemento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TablaElementolist.Add(TablaElemento);
            }
            reader.Close();
            reader.Dispose();
            return TablaElementolist;
        }
    }
}
