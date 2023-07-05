using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDevolucionesMayoristasRutaDL
    {
        public List<ReporteDevolucionesMayoristasRutaBE> Listado(int IdRuta, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDevolucionesMayoristasRuta");
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, IdRuta);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDevolucionesMayoristasRutaBE> DevolucionesMayoristaslist = new List<ReporteDevolucionesMayoristasRutaBE>();
            ReporteDevolucionesMayoristasRutaBE DevolucionesMayoristas;
            while (reader.Read())
            {
                DevolucionesMayoristas = new ReporteDevolucionesMayoristasRutaBE();
                DevolucionesMayoristas.IdCambio = Int32.Parse(reader["IdCambio"].ToString());
                DevolucionesMayoristas.NumeroPedido = reader["NumeroPedido"].ToString();
                DevolucionesMayoristas.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                DevolucionesMayoristas.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                DevolucionesMayoristas.DescCliente = reader["DescCliente"].ToString();
                DevolucionesMayoristas.NumeroDevolucion = reader["NumeroDevolucion"].ToString();
                DevolucionesMayoristas.FechaDevolucion = DateTime.Parse(reader["FechaDevolucion"].ToString());
                DevolucionesMayoristas.CodMoneda = reader["CodMoneda"].ToString();
                DevolucionesMayoristas.Total = Decimal.Parse(reader["Total"].ToString());
                DevolucionesMayoristas.DescVendedor = reader["DescVendedor"].ToString();
                DevolucionesMayoristas.DescRuta = reader["DescRuta"].ToString();

                DevolucionesMayoristaslist.Add(DevolucionesMayoristas);
            }
            reader.Close();
            reader.Dispose();
            return DevolucionesMayoristaslist;
        }
    }
}
