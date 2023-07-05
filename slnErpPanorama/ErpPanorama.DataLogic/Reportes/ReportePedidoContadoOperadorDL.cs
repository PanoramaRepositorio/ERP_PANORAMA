using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoContadoOperadorDL
    {
        public List<ReportePedidoContadoOperadorBE> Listado(int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoContadoOperador");
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            dbCommand.CommandTimeout = 250;

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoContadoOperadorBE> MovimientoPedidolist = new List<ReportePedidoContadoOperadorBE>();
            ReportePedidoContadoOperadorBE MovimientoPedido;
            while (reader.Read())
            {
                MovimientoPedido = new ReportePedidoContadoOperadorBE();
                MovimientoPedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoPedido.Numero = reader["numero"].ToString();
                MovimientoPedido.DescTienda = reader["DescTienda"].ToString();
                MovimientoPedido.DescCliente = reader["DescCliente"].ToString();
                MovimientoPedido.DescFormaPago = reader["descFormaPago"].ToString();
                MovimientoPedido.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoPedido.DescVendedor = reader["DescVendedor"].ToString();
                MovimientoPedido.Total = Decimal.Parse(reader["total"].ToString());
                MovimientoPedido.DescSituacion = reader["DescSituacion"].ToString();
                MovimientoPedido.DescAuxiliar = reader["DescAuxiliar"].ToString();
                MovimientoPedido.TotalCantidadInicial = Int32.Parse(reader["TotalCantidadInicial"].ToString());
                MovimientoPedido.TotalItemsInicial = Int32.Parse(reader["TotalItemsInicial"].ToString());
                MovimientoPedido.TotalCantidad = Int32.Parse(reader["TotalCantidad"].ToString());
                MovimientoPedido.TotalItems = Int32.Parse(reader["TotalItems"].ToString());
                MovimientoPedidolist.Add(MovimientoPedido);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidolist;
        }    
    
    }
}
