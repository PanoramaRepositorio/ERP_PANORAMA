using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoContadoDL
    {
        public List<ReportePedidoContadoBE> Listado(int Periodo, int IdPedido, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoContado");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoContadoBE> Pedidolist = new List<ReportePedidoContadoBE>();
            ReportePedidoContadoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoContadoBE();
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCampana = reader["DescCampana"].ToString();
                Pedido.Serie = reader["serie"].ToString();
                Pedido.Numero = reader["numero"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.Direccion = reader["direccion"].ToString();
                Pedido.NumeroDocumentoAsociado = reader["NumeroDocumentoAsociado"].ToString();
                Pedido.DescClienteAsociado = reader["DescClienteAsociado"].ToString();
                Pedido.DireccionAsociado = reader["DireccionAsociado"].ToString();
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.Observaciones = reader["Observaciones"].ToString();
                Pedido.Item = Int32.Parse(reader["item"].ToString());
                Pedido.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Pedido.CodigoProveedor = reader["codigoProveedor"].ToString();
                Pedido.NombreProducto = reader["nombreProducto"].ToString();
                Pedido.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Pedido.CantidadAnterior = Int32.Parse(reader["CantidadAnterior"].ToString());
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.UbicacionUcayali = reader["UbicacionUcayali"].ToString();
                Pedido.UbicacionAndahuaylas = reader["UbicacionAndahuaylas"].ToString();
                Pedido.UbicacionAviacion = reader["UbicacionAviacion"].ToString();
                Pedido.UbicacionPrescott = reader["UbicacionPrescott"].ToString();
                Pedido.UbicacionSanMiguel = reader["UbicacionSanMiguel"].ToString();

                Pedido.Observacion = reader["Observacion"].ToString();
                Pedido.DescTipoVenta = reader["DescTipoVenta"].ToString();
                Pedido.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Pedido.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                Pedido.DescAlmacen = reader["DescAlmacen"].ToString();
                Pedido.NumeroModificacion = Int32.Parse(reader["NumeroModificacion"].ToString());
                Pedido.FechaDelivery = DateTime.Parse(reader["FechaDelivery"].ToString());
                Pedido.CodigoBarraNumero = null;


                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoContadoBE> ListadoChequeo(int Periodo, int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoChequeo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoContadoBE> Pedidolist = new List<ReportePedidoContadoBE>();
            ReportePedidoContadoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoContadoBE();
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCampana = reader["DescCampana"].ToString();
                Pedido.Serie = reader["serie"].ToString();
                Pedido.Numero = reader["numero"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.Direccion = reader["direccion"].ToString();
                Pedido.NumeroDocumentoAsociado = reader["NumeroDocumentoAsociado"].ToString();
                Pedido.DescClienteAsociado = reader["DescClienteAsociado"].ToString();
                Pedido.DireccionAsociado = reader["DireccionAsociado"].ToString();
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.Observaciones = reader["Observaciones"].ToString();
                Pedido.Item = Int32.Parse(reader["item"].ToString());
                Pedido.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Pedido.CodigoProveedor = reader["codigoProveedor"].ToString();
                Pedido.NombreProducto = reader["nombreProducto"].ToString();
                Pedido.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Pedido.CantidadAnterior = Int32.Parse(reader["CantidadAnterior"].ToString());
                Pedido.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.UbicacionUcayali = reader["UbicacionUcayali"].ToString();
                Pedido.UbicacionAndahuaylas = reader["UbicacionAndahuaylas"].ToString();
                Pedido.Observacion = reader["Observacion"].ToString();
                Pedido.DescTipoVenta = reader["DescTipoVenta"].ToString();
                Pedido.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Pedido.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                Pedido.DescPersonaPicking = reader["DescPersonaPicking"].ToString();
                Pedido.DescPersonaChequeo = reader["DescPersonaChequeo"].ToString();
                Pedido.DescPersonaEmabalaje = reader["DescPersonaEmabalaje"].ToString();
                Pedido.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                Pedido.CodigoBarraNumero = null;
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoContadoBE> ListadoChequeoProducto(int Periodo, int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoChequeoProducto");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoContadoBE> Pedidolist = new List<ReportePedidoContadoBE>();
            ReportePedidoContadoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoContadoBE();
                Pedido.Ruc = reader["Ruc"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescCampana = reader["DescCampana"].ToString();
                Pedido.Serie = reader["serie"].ToString();
                Pedido.Numero = reader["numero"].ToString();
                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.Direccion = reader["direccion"].ToString();
                Pedido.NumeroDocumentoAsociado = reader["NumeroDocumentoAsociado"].ToString();
                Pedido.DescClienteAsociado = reader["DescClienteAsociado"].ToString();
                Pedido.DireccionAsociado = reader["DireccionAsociado"].ToString();
                Pedido.DescFormaPago = reader["descFormaPago"].ToString();
                Pedido.DescVendedor = reader["DescVendedor"].ToString();
                Pedido.DescMotivo = reader["DescMotivo"].ToString();
                Pedido.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Pedido.Despachar = reader["Despachar"].ToString();
                Pedido.Observaciones = reader["Observaciones"].ToString();
                Pedido.Item = Int32.Parse(reader["item"].ToString());
                Pedido.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Pedido.CodigoProveedor = reader["codigoProveedor"].ToString();
                Pedido.NombreProducto = reader["nombreProducto"].ToString();
                Pedido.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Pedido.CantidadAnterior = Int32.Parse(reader["CantidadAnterior"].ToString());
                Pedido.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                Pedido.Abreviatura = reader["Abreviatura"].ToString();
                Pedido.UbicacionUcayali = reader["UbicacionUcayali"].ToString();
                Pedido.UbicacionAndahuaylas = reader["UbicacionAndahuaylas"].ToString();
                Pedido.Observacion = reader["Observacion"].ToString();
                Pedido.DescTipoVenta = reader["DescTipoVenta"].ToString();
                Pedido.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Pedido.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                Pedido.DescPersonaPicking = reader["DescPersonaPicking"].ToString();
                Pedido.DescPersonaChequeo = reader["DescPersonaChequeo"].ToString();
                Pedido.DescPersonaEmabalaje = reader["DescPersonaEmabalaje"].ToString();
                Pedido.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                Pedido.CodigoBarraNumero = null;
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

    }
}
