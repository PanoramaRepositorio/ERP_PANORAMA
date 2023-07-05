using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteProformaDL
    {
        public List<ReporteProformaBE> Listado(int IdProforma)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptProforma");
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, IdProforma);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteProformaBE> Proformalist = new List<ReporteProformaBE>();
            ReporteProformaBE Proforma;
            while (reader.Read())
            {
                Proforma = new ReporteProformaBE();
                Proforma.Ruc = reader["Ruc"].ToString();
                Proforma.RazonSocial = reader["RazonSocial"].ToString();
                Proforma.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Proforma.Numero = reader["numero"].ToString();
                Proforma.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Proforma.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proforma.DescCliente = reader["DescCliente"].ToString();
                Proforma.Direccion = reader["direccion"].ToString();
                Proforma.CodMoneda = reader["CodMoneda"].ToString();
                Proforma.DescMoneda = reader["DescMoneda"].ToString();
                Proforma.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Proforma.DescFormaPago = reader["descFormaPago"].ToString();
                Proforma.DescVendedor = reader["DescVendedor"].ToString();
                Proforma.TotalCantidad = Int32.Parse(reader["totalCantidad"].ToString());
                Proforma.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                Proforma.Igv = Decimal.Parse(reader["igv"].ToString());
                Proforma.PorcentajeImpuesto = Decimal.Parse(reader["porcentajeImpuesto"].ToString());
                Proforma.Total = Decimal.Parse(reader["total"].ToString());
                Proforma.Observacion = reader["observacion"].ToString();
                Proforma.DescSituacion = reader["DescSituacion"].ToString();
                Proforma.Item = Int32.Parse(reader["item"].ToString());
                Proforma.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Proforma.CodigoProveedor = reader["codigoProveedor"].ToString();
                Proforma.NombreProducto = reader["nombreProducto"].ToString();
                Proforma.Abreviatura = reader["Abreviatura"].ToString();
                Proforma.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Proforma.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                Proforma.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                Proforma.Descuento = Decimal.Parse(reader["descuento"].ToString());
                Proforma.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                Proforma.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                Proforma.ObservacionDetalle = reader["ObservacionDetalle"].ToString();
                Proforma.FlagAprobacion = Boolean.Parse(reader["FlagAprobacion"].ToString());
                Proformalist.Add(Proforma);
            }
            reader.Close();
            reader.Dispose();
            return Proformalist;
        }
    }
}
