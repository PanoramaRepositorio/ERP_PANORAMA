using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoCargoCreditoDL
    {
        public List<ReportePedidoCargoCreditoBE> Listado(int IdEmpresa, int IdEstadoCuenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoCargoCredito");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pIdEstadoCuenta", DbType.Int32, IdEstadoCuenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoCargoCreditoBE> Pedidolist = new List<ReportePedidoCargoCreditoBE>();
            ReportePedidoCargoCreditoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoCargoCreditoBE();
                Pedido.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
                Pedido.NumeroPedido = reader["NumeroPedido"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.Direccion = reader["Direccion"].ToString();
                Pedido.NumeroCredito = reader["NumeroCredito"].ToString();
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pedido.Total = Decimal.Parse(reader["total"].ToString());
                Pedido.Descripcion = reader["Descripcion"].ToString();
                Pedido.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Pedido.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
