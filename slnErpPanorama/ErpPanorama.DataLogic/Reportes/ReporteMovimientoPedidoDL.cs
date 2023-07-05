using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteMovimientoPedidoDL
    {
        public List<ReporteMovimientoPedidoBE> Listado(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_rptDespacho");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteMovimientoPedidoBE> MovimientoPedidolist = new List<ReporteMovimientoPedidoBE>();
            ReporteMovimientoPedidoBE MovimientoPedido;
            while (reader.Read())
            {
                MovimientoPedido = new ReporteMovimientoPedidoBE();
                MovimientoPedido.NumeroPedido = reader["NumeroPedido"].ToString();
                MovimientoPedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoPedido.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoPedido.DescTipoCliente = reader["DescTipoCliente"].ToString();
                MovimientoPedido.NumeroCliente = reader["NumeroCliente"].ToString();
                MovimientoPedido.DescCliente = reader["DescCliente"].ToString();
                MovimientoPedido.DireccionCliente = reader["DireccionCliente"].ToString();
                MovimientoPedido.DescAgencia = reader["DescAgencia"].ToString();
                MovimientoPedido.Direccion = reader["Direccion"].ToString();
                MovimientoPedido.Referencia = reader["Referencia"].ToString();
                MovimientoPedido.NomDpto = reader["NomDpto"].ToString();
                MovimientoPedido.NomProv = reader["NomProv"].ToString();
                MovimientoPedido.NomDist = reader["NomDist"].ToString();
                MovimientoPedido.Telefono = reader["Telefono"].ToString();
                MovimientoPedido.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoPedido.DescPrioridad = reader["DescPrioridad"].ToString();
                MovimientoPedido.DescDestino = reader["DescDestino"].ToString();
                MovimientoPedido.DescPagoFlete = reader["DescPagoFlete"].ToString();
                MovimientoPedido.NumeroDespacho = reader["NumeroDespacho"].ToString();
                MovimientoPedido.FechaDespacho2 = DateTime.Parse(reader["FechaDespacho2"].ToString());
                MovimientoPedido.NumeroPiso = Int32.Parse(reader["NumeroPiso"].ToString());
                MovimientoPedido.Observacion2 = reader["Observacion2"].ToString();
                MovimientoPedido.DescMoneeda = reader["DescMoneeda"].ToString();
                MovimientoPedido.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                MovimientoPedido.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoPedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoPedido.NumeroPiso = Int32.Parse(reader["NumeroPiso"].ToString());
                MovimientoPedido.Importe = Decimal.Parse(reader["Importe"].ToString());
                MovimientoPedido.DescVendedor = reader["DescVendedor"].ToString();
                MovimientoPedido.DescEmbalador = reader["DescEmbalador"].ToString();
                MovimientoPedido.FechaEmbalado = DateTime.Parse(reader["FechaEmbalado"].ToString());
                MovimientoPedido.DescTienda = reader["DescTienda"].ToString();
                MovimientoPedido.DescCaja = reader["DescCaja"].ToString();
                MovimientoPedido.NumeroComprobante = reader["NumeroComprobante"].ToString();

                MovimientoPedido.DeliveryDep = reader["DeliveryDep"].ToString();
                MovimientoPedido.DeliveryProv = reader["DeliveryProv"].ToString();
                MovimientoPedido.DeliveryDist = reader["DeliveryDist"].ToString();
                MovimientoPedido.PersonaRecoge = reader["PersonaRecoge"].ToString();

                MovimientoPedido.Conductor = reader["Conductor"].ToString();
                MovimientoPedido.Copiloto = reader["Copiloto"].ToString();
                MovimientoPedido.Placa = reader["Placa"].ToString();


                MovimientoPedidolist.Add(MovimientoPedido);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidolist;
        }
    }
}
