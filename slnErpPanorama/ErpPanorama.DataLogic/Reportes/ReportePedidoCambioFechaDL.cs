using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoCambioFechaDL
    {
        public List<ReportePedidoCambioFechaBE> Listado(DateTime FechaDesde, DateTime FechaHasta, Int32 TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoCambioConsignacionFecha");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoCambioFechaBE> ClienteGenerallist = new List<ReportePedidoCambioFechaBE>();
            ReportePedidoCambioFechaBE ClienteGeneral;
            while (reader.Read())
            {
                ClienteGeneral = new ReportePedidoCambioFechaBE();
                ClienteGeneral.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                ClienteGeneral.Numero = reader["Numero"].ToString();
                ClienteGeneral.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ClienteGeneral.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ClienteGeneral.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteGeneral.DescCliente = reader["descCliente"].ToString();
                ClienteGeneral.Direccion = reader["Direccion"].ToString();
                ClienteGeneral.DescFormaPago = reader["DescFormaPago"].ToString();
                ClienteGeneral.DescMoneda = reader["DescMoneda"].ToString();
                ClienteGeneral.TotalCantidad = Int32.Parse(reader["TotalCantidad"].ToString());
                ClienteGeneral.Total = Decimal.Parse(reader["Total"].ToString());
                ClienteGeneral.Observaciones = reader["Observaciones"].ToString();
                ClienteGeneral.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                ClienteGeneral.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ClienteGeneral.NombreProducto = reader["NombreProducto"].ToString();
                ClienteGeneral.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ClienteGeneral.CantidadDevuelto = Int32.Parse(reader["CantidadDevuelto"].ToString());
                ClienteGeneral.Saldo = Int32.Parse(reader["Saldo"].ToString());
                ClienteGeneral.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                ClienteGeneral.Abreviatura = reader["Abreviatura"].ToString();
                ClienteGeneral.Observacion = reader["Observacion"].ToString();
                ClienteGeneral.DescVendedor = reader["DescVendedor"].ToString();
                ClienteGeneral.FechaDevolucion = reader["FechaDevolucion"].ToString();
                ClienteGenerallist.Add(ClienteGeneral);
            }
            reader.Close();
            reader.Dispose();
            return ClienteGenerallist;
        }
    }
}
