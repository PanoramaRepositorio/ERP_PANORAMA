using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteCotizacionDL
    {
        public List<ReporteCotizacionBE> Listado(int IdEmpresa, int IdCotizacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptCotizacion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCotizacion", DbType.Int32, IdCotizacion);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCotizacionBE> Cotizacionlist = new List<ReporteCotizacionBE>();
            ReporteCotizacionBE Cotizacion;
            while (reader.Read())
            {
                Cotizacion = new ReporteCotizacionBE();
                Cotizacion.IdCotizacion = Int32.Parse(reader["IdCotizacion"].ToString());
                Cotizacion.NumeroPedido = reader["NumeroPedido"].ToString();
                Cotizacion.DescFormaPago = reader["DescFormaPago"].ToString();
                Cotizacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cotizacion.DescCliente = reader["DescCliente"].ToString();
                Cotizacion.Direccion = reader["Direccion"].ToString();
                Cotizacion.NumeroCotizacion = reader["numeroCotizacion"].ToString();
                Cotizacion.CodMoneda = reader["CodMoneda"].ToString();
                Cotizacion.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Cotizacion.Total = Decimal.Parse(reader["total"].ToString());
                Cotizacion.Descripcion = reader["Descripcion"].ToString();
                Cotizacion.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Cotizacion.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Cotizacionlist.Add(Cotizacion);
            }
            reader.Close();
            reader.Dispose();
            return Cotizacionlist;
        }
    }
}
