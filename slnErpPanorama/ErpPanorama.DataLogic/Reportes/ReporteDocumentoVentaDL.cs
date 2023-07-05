using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDocumentoVentaDL
    {
        public List<ReporteDocumentoVentaBE> Listado(int Periodo, int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaPedido");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaBE> ReporteDocumentoVentalist = new List<ReporteDocumentoVentaBE>();
            ReporteDocumentoVentaBE ReporteDocumentoVenta;
            while (reader.Read())
            {
                ReporteDocumentoVenta = new ReporteDocumentoVentaBE();
                ReporteDocumentoVenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ReporteDocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                ReporteDocumentoVenta.Serie = reader["Serie"].ToString();
                ReporteDocumentoVenta.Numero = reader["Numero"].ToString();
                ReporteDocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                ReporteDocumentoVenta.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteDocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteDocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                ReporteDocumentoVenta.Direccion = reader["direccion"].ToString();
                ReporteDocumentoVenta.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                ReporteDocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                ReporteDocumentoVenta.DescMoneda = reader["DescMoneda"].ToString();
                ReporteDocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                ReporteDocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                ReporteDocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                ReporteDocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                ReporteDocumentoVenta.CodigoProveedor = reader["codigoProveedor"].ToString();
                ReporteDocumentoVenta.NombreProducto = reader["nombreProducto"].ToString();
                ReporteDocumentoVenta.Abreviatura = reader["Abreviatura"].ToString();
                ReporteDocumentoVenta.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                ReporteDocumentoVenta.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                ReporteDocumentoVenta.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                ReporteDocumentoVenta.DescVendedor= reader["DescVendedor"].ToString();
                ReporteDocumentoVenta.PagoNotaCredito = reader["PagoNotaCredito"].ToString();
                ReporteDocumentoVenta.IdPromocionProxima = Int32.Parse(reader["IdPromocionProxima"].ToString());
                ReporteDocumentoVenta.FlagPromocionProxima = Boolean.Parse(reader["FlagPromocionProxima"].ToString());
                ReporteDocumentoVentalist.Add(ReporteDocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoVentalist;
        }

        public List<ReporteDocumentoVentaBE> ListaPedidoDocumento(int Periodo, int IdPedido, int IdTipoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaPedidoDocumento");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaBE> ReporteDocumentoVentalist = new List<ReporteDocumentoVentaBE>();
            ReporteDocumentoVentaBE ReporteDocumentoVenta;
            while (reader.Read())
            {
                ReporteDocumentoVenta = new ReporteDocumentoVentaBE();
                ReporteDocumentoVenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ReporteDocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                ReporteDocumentoVenta.Serie = reader["Serie"].ToString();
                ReporteDocumentoVenta.Numero = reader["Numero"].ToString();
                ReporteDocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                ReporteDocumentoVenta.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteDocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteDocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                ReporteDocumentoVenta.Direccion = reader["direccion"].ToString();
                ReporteDocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                ReporteDocumentoVenta.DescMoneda = reader["DescMoneda"].ToString();
                ReporteDocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                ReporteDocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                ReporteDocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                ReporteDocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                ReporteDocumentoVenta.CodigoProveedor = reader["codigoProveedor"].ToString();
                ReporteDocumentoVenta.NombreProducto = reader["nombreProducto"].ToString();
                ReporteDocumentoVenta.Abreviatura = reader["Abreviatura"].ToString();
                ReporteDocumentoVenta.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                ReporteDocumentoVenta.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                ReporteDocumentoVenta.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                ReporteDocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();
                ReporteDocumentoVenta.PagoNotaCredito = reader["PagoNotaCredito"].ToString();
                ReporteDocumentoVenta.IdPromocionProxima = Int32.Parse(reader["IdPromocionProxima"].ToString());
                ReporteDocumentoVenta.FlagPromocionProxima = Boolean.Parse(reader["FlagPromocionProxima"].ToString());
                ReporteDocumentoVentalist.Add(ReporteDocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoVentalist;
        }

        public List<ReporteDocumentoVentaBE> ListaCodigo(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaCodigo");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaBE> ReporteDocumentoVentalist = new List<ReporteDocumentoVentaBE>();
            ReporteDocumentoVentaBE ReporteDocumentoVenta;
            while (reader.Read())
            {
                ReporteDocumentoVenta = new ReporteDocumentoVentaBE();
                ReporteDocumentoVenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ReporteDocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                ReporteDocumentoVenta.Serie = reader["Serie"].ToString();
                ReporteDocumentoVenta.Numero = reader["Numero"].ToString();
                ReporteDocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                ReporteDocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteDocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                ReporteDocumentoVenta.Direccion = reader["direccion"].ToString();
                ReporteDocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                ReporteDocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                ReporteDocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                ReporteDocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                ReporteDocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                ReporteDocumentoVenta.CodigoProveedor = reader["codigoProveedor"].ToString();
                ReporteDocumentoVenta.NombreProducto = reader["nombreProducto"].ToString();
                ReporteDocumentoVenta.Abreviatura = reader["Abreviatura"].ToString();
                ReporteDocumentoVenta.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                ReporteDocumentoVenta.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                ReporteDocumentoVenta.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                ReporteDocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();

                ReporteDocumentoVentalist.Add(ReporteDocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoVentalist;
        }

        public List<ReporteDocumentoVentaBE> ListadoDocumento(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaDocumento");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaBE> ReporteDocumentoVentalist = new List<ReporteDocumentoVentaBE>();
            ReporteDocumentoVentaBE ReporteDocumentoVenta;
            while (reader.Read())
            {
                ReporteDocumentoVenta = new ReporteDocumentoVentaBE();
                ReporteDocumentoVenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ReporteDocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                ReporteDocumentoVenta.Serie = reader["Serie"].ToString();
                ReporteDocumentoVenta.Numero = reader["Numero"].ToString();
                ReporteDocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                ReporteDocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteDocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                ReporteDocumentoVenta.Direccion = reader["direccion"].ToString();
                ReporteDocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                ReporteDocumentoVenta.DescMoneda = reader["DescMoneda"].ToString();
                ReporteDocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                ReporteDocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                ReporteDocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                ReporteDocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                ReporteDocumentoVenta.CodigoProveedor = reader["codigoProveedor"].ToString();
                ReporteDocumentoVenta.NombreProducto = reader["nombreProducto"].ToString();
                ReporteDocumentoVenta.Abreviatura = reader["Abreviatura"].ToString();
                ReporteDocumentoVenta.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                ReporteDocumentoVenta.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                ReporteDocumentoVenta.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                ReporteDocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();

                ReporteDocumentoVentalist.Add(ReporteDocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoVentalist;
        }

        public List<ReporteDocumentoVentaBE> ListaCliente(int IdEmpresa, int IdCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaCliente");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaBE> ReporteDocumentoVentalist = new List<ReporteDocumentoVentaBE>();
            ReporteDocumentoVentaBE ReporteDocumentoVenta;
            while (reader.Read())
            {
                ReporteDocumentoVenta = new ReporteDocumentoVentaBE();
                ReporteDocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                ReporteDocumentoVenta.Serie = reader["Serie"].ToString();
                ReporteDocumentoVenta.Numero = reader["Numero"].ToString();
                ReporteDocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                ReporteDocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteDocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                ReporteDocumentoVenta.Direccion = reader["direccion"].ToString();
                ReporteDocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                ReporteDocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                ReporteDocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                ReporteDocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                ReporteDocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                ReporteDocumentoVenta.CodigoProveedor = reader["codigoProveedor"].ToString();
                ReporteDocumentoVenta.NombreProducto = reader["nombreProducto"].ToString();
                ReporteDocumentoVenta.Abreviatura = reader["Abreviatura"].ToString();
                ReporteDocumentoVenta.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                ReporteDocumentoVenta.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                ReporteDocumentoVenta.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                ReporteDocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();

                ReporteDocumentoVentalist.Add(ReporteDocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoVentalist;
        }

        public List<ReporteDocumentoVentaBE> ListaGuiaCliente(int IdEmpresa, int IdCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaGuiaCliente");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoVentaBE> ReporteDocumentoVentalist = new List<ReporteDocumentoVentaBE>();
            ReporteDocumentoVentaBE ReporteDocumentoVenta;
            while (reader.Read())
            {
                ReporteDocumentoVenta = new ReporteDocumentoVentaBE();
                ReporteDocumentoVenta.NumeroPedido = reader["NumeroPedido"].ToString();
                ReporteDocumentoVenta.Serie = reader["Serie"].ToString();
                ReporteDocumentoVenta.Numero = reader["Numero"].ToString();
                ReporteDocumentoVenta.Fecha = DateTime.Parse(reader["fecha"].ToString());
                ReporteDocumentoVenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteDocumentoVenta.DescCliente = reader["DescCliente"].ToString();
                ReporteDocumentoVenta.Direccion = reader["direccion"].ToString();
                ReporteDocumentoVenta.CodMoneda = reader["CodMoneda"].ToString();
                ReporteDocumentoVenta.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                ReporteDocumentoVenta.Igv = Decimal.Parse(reader["igv"].ToString());
                ReporteDocumentoVenta.Total = Decimal.Parse(reader["total"].ToString());
                ReporteDocumentoVenta.TotalBruto = Decimal.Parse(reader["TotalBruto"].ToString());
                ReporteDocumentoVenta.CodigoProveedor = reader["codigoProveedor"].ToString();
                ReporteDocumentoVenta.NombreProducto = reader["nombreProducto"].ToString();
                ReporteDocumentoVenta.Abreviatura = reader["Abreviatura"].ToString();
                ReporteDocumentoVenta.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                ReporteDocumentoVenta.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                ReporteDocumentoVenta.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                ReporteDocumentoVenta.DescVendedor = reader["DescVendedor"].ToString();

                ReporteDocumentoVentalist.Add(ReporteDocumentoVenta);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoVentalist;
        }


    }
}
