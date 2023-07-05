using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTalonDL
    {
        public List<ReporteTalonBE> Listado()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptTalon");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTalonBE> ReporteTalonlist = new List<ReporteTalonBE>();
            ReporteTalonBE ReporteTalon;
            while (reader.Read())
            {
                ReporteTalon = new ReporteTalonBE();
                ReporteTalon.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                ReporteTalon.IdTalon = Int32.Parse(reader["idTalon"].ToString());
                ReporteTalon.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                ReporteTalon.DescCaja = reader["descCaja"].ToString();
                ReporteTalon.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                ReporteTalon.DescTienda = reader["DescTienda"].ToString();
                ReporteTalon.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                ReporteTalon.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                ReporteTalon.IdTipoFormato = Int32.Parse(reader["IdTipoFormato"].ToString());
                ReporteTalon.DescTipoFormato = reader["DescTipoFormato"].ToString();
                ReporteTalon.NumeroSerie = reader["numeroSerie"].ToString();
                ReporteTalon.NumeroAutoriza = reader["numeroAutoriza"].ToString();
                ReporteTalon.SerieImpresora = reader["SerieImpresora"].ToString();
                ReporteTalon.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ReporteTalonlist.Add(ReporteTalon);
            }
            reader.Close();
            reader.Dispose();
            return ReporteTalonlist;
        }
    }
}
