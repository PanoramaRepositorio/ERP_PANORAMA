using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteFacturaCompraDL
    {
        public List<ReporteFacturaCompraBE> Listado(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptFacturaCompra");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteFacturaCompraBE> FacturaCompralist = new List<ReporteFacturaCompraBE>();
            ReporteFacturaCompraBE FacturaCompra;
            while (reader.Read())
            {
                FacturaCompra = new ReporteFacturaCompraBE();
                FacturaCompra.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                FacturaCompra.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FacturaCompra.Periodo = Int32.Parse(reader["periodo"].ToString());
                FacturaCompra.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                FacturaCompra.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                FacturaCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                FacturaCompra.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                FacturaCompra.DescProveedor = reader["DescProveedor"].ToString();
                FacturaCompra.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                FacturaCompra.FormaPago = reader["FormaPago"].ToString();
                FacturaCompra.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                FacturaCompra.TipoRegistro = reader["tiporegistro"].ToString();
                FacturaCompra.Importe = Decimal.Parse(reader["Importe"].ToString());
                FacturaCompra.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                FacturaCompra.Moneda = reader["Moneda"].ToString();
                FacturaCompra.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                FacturaCompra.CantidadTotal = Int32.Parse(reader["CantidadTotal"].ToString());
                FacturaCompra.Observacion = reader["Observacion"].ToString();
                FacturaCompra.IdFacturaCompraDetalle = Int32.Parse(reader["idFacturaCompraDetalle"].ToString());
                FacturaCompra.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                FacturaCompra.CodigoProveedor = reader["CodigoProveedor"].ToString();
                FacturaCompra.NombreProducto = reader["NombreProducto"].ToString();
                FacturaCompra.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                FacturaCompra.Abreviatura = reader["Abreviatura"].ToString();
                FacturaCompra.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompra.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
                FacturaCompra.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                FacturaCompra.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                FacturaCompralist.Add(FacturaCompra);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompralist;
        }

        public List<ReporteFacturaCompraBE> ListadoStock(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptFacturaCompraStock");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteFacturaCompraBE> FacturaCompralist = new List<ReporteFacturaCompraBE>();
            ReporteFacturaCompraBE FacturaCompra;
            while (reader.Read())
            {
                FacturaCompra = new ReporteFacturaCompraBE();
                FacturaCompra.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                FacturaCompra.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FacturaCompra.Periodo = Int32.Parse(reader["periodo"].ToString());
                FacturaCompra.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                FacturaCompra.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                FacturaCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                FacturaCompra.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                FacturaCompra.DescProveedor = reader["DescProveedor"].ToString();
                FacturaCompra.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                FacturaCompra.FormaPago = reader["FormaPago"].ToString();
                FacturaCompra.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                FacturaCompra.TipoRegistro = reader["tiporegistro"].ToString();
                FacturaCompra.Importe = Decimal.Parse(reader["Importe"].ToString());
                FacturaCompra.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                FacturaCompra.Moneda = reader["Moneda"].ToString();
                FacturaCompra.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                FacturaCompra.CantidadTotal = Int32.Parse(reader["CantidadTotal"].ToString());
                FacturaCompra.Observacion = reader["Observacion"].ToString();
                FacturaCompra.IdFacturaCompraDetalle = Int32.Parse(reader["idFacturaCompraDetalle"].ToString());
                FacturaCompra.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                FacturaCompra.CodigoProveedor = reader["CodigoProveedor"].ToString();
                FacturaCompra.NombreProducto = reader["NombreProducto"].ToString();
                FacturaCompra.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                FacturaCompra.Abreviatura = reader["Abreviatura"].ToString();
                FacturaCompra.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompra.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
                FacturaCompra.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                FacturaCompra.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                FacturaCompra.Stock = Int32.Parse(reader["Stock"].ToString());
                FacturaCompralist.Add(FacturaCompra);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompralist;
        }
    }
}
