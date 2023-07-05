using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCajaCajeroDL
    {
        public List<ReporteCajaCajeroBE> Listado(int IdCaja, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptSector");
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCajaCajeroBE> CajaCajerolist = new List<ReporteCajaCajeroBE>();
            ReporteCajaCajeroBE CajaCajero;
            while (reader.Read())
            {
                CajaCajero = new ReporteCajaCajeroBE();
                CajaCajero.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                CajaCajero.Nombres = reader["Nombres"].ToString();
                CajaCajero.Apellidos = reader["Apellidos"].ToString();
                CajaCajero.IdCajaVendedor = Int32.Parse(reader["idCajaVendedor"].ToString());
                CajaCajero.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                CajaCajero.DescCaja = reader["descCaja"].ToString();
                CajaCajero.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaCajerolist.Add(CajaCajero);
            }
            reader.Close();
            reader.Dispose();
            return CajaCajerolist;
        }
    }
}
