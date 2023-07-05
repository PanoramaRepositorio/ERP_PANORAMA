using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDevolucionesMayoristasDL
    {
        public List<ReporteDevolucionesMayoristasBE> Listado(int IdCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDevolucionesMayoristas");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDevolucionesMayoristasBE> DevolucionesMayoristaslist = new List<ReporteDevolucionesMayoristasBE>();
            ReporteDevolucionesMayoristasBE DevolucionesMayoristas;
            while (reader.Read())
            {
                DevolucionesMayoristas = new ReporteDevolucionesMayoristasBE();
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
