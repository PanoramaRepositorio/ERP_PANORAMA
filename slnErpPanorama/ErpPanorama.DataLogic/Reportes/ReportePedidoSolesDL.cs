using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoSolesDL
    {
        public List<ReportePedidoSolesBE> Listado(int Periodo, int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoDetalleSoles");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoSolesBE> Pedidolist = new List<ReportePedidoSolesBE>();
            ReportePedidoSolesBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoSolesBE();
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Serie = reader["serie"].ToString();
                Pedido.Numero = reader["numero"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.Direccion = reader["direccion"].ToString();
                Pedido.AbrevDomicilio = reader["AbrevDomicilio"].ToString();
                Pedido.NomDpto = reader["NomDpto"].ToString();
                Pedido.NomProv = reader["NomProv"].ToString();
                Pedido.NomDist = reader["NomDist"].ToString();
                Pedido.NumeroDocumentoAsociado = reader["NumeroDocumentoAsociado"].ToString();
                Pedido.DescClienteAsociado = reader["DescClienteAsociado"].ToString();
                Pedido.DireccionAsociado = reader["DireccionAsociado"].ToString();
                //Pedido.DescClienteAsociado = reader["DescClienteAsociado"].ToString();
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Pedido.Observacion = reader["Observacion"].ToString();
                Pedido.Item = Int32.Parse(reader["item"].ToString());
                Pedido.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Pedido.CodigoProveedor = reader["codigoProveedor"].ToString();
                Pedido.NombreProducto = reader["nombreProducto"].ToString();
                Pedido.Medida = reader["Medida"].ToString();
                Pedido.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.PrecioUnitario = decimal.Parse(reader["PrecioUnitario"].ToString());
                Pedido.PorcentajeDescuento = decimal.Parse(reader["PorcentajeDescuento"].ToString());
                Pedido.PrecioVenta = decimal.Parse(reader["PrecioVenta"].ToString());
                Pedido.ValorVenta = decimal.Parse(reader["ValorVenta"].ToString());
                Pedido.Total = decimal.Parse(reader["Total"].ToString());
                Pedido.FlagPreVenta = bool.Parse(reader["FlagPreVenta"].ToString());
                Pedido.PrecioUnitarioDolares = decimal.Parse(reader["PrecioUnitarioDolares"].ToString());
                Pedido.PrecioVentaDolares = decimal.Parse(reader["PrecioVentaDolares"].ToString());
                Pedido.ValorVentaDolares = decimal.Parse(reader["ValorVentaDolares"].ToString());
                Pedido.TotalDolares = decimal.Parse(reader["TotalDolares"].ToString());
                Pedido.CodigoBarraNumero = null;
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
