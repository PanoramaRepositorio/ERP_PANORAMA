using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteClienteCumpleanosDL
    {
        public List<ReporteClienteCumpleanosBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdTipoCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("[usp_rptClienteCumpleanos]");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteClienteCumpleanosBE> ClienteCumpleanoslist = new List<ReporteClienteCumpleanosBE>();
            ReporteClienteCumpleanosBE ClienteCumpleanos;
            while (reader.Read())
            {
                ClienteCumpleanos = new ReporteClienteCumpleanosBE();
                ClienteCumpleanos.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                ClienteCumpleanos.DescCliente = reader["descCliente"].ToString();
                ClienteCumpleanos.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                ClienteCumpleanos.FechaAniv = reader.IsDBNull(reader.GetOrdinal("FechaAniv")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAniv"));
                ClienteCumpleanos.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaAniv")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                ClienteCumpleanos.Telefono = reader["telefono"].ToString();
                ClienteCumpleanos.Email = reader["email"].ToString();
                ClienteCumpleanos.DescRuta = reader["DescRuta"].ToString();
                ClienteCumpleanos.Vendedor = reader["Vendedor"].ToString();
                ClienteCumpleanoslist.Add(ClienteCumpleanos);
            }
            reader.Close();
            reader.Dispose();
            return ClienteCumpleanoslist;
        }
    }
}
