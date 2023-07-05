using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDocumentoReferenciaDL
    {
        public List<ReporteDocumentoReferenciaBE> Listado(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaDocReferencia");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDocumentoReferenciaBE> ReporteDocumentoReferencialist = new List<ReporteDocumentoReferenciaBE>();
            ReporteDocumentoReferenciaBE ReporteDocumentoReferencia;
            while (reader.Read())
            {
                ReporteDocumentoReferencia = new ReporteDocumentoReferenciaBE();
                ReporteDocumentoReferencia.NumeroPedido = reader["NumeroPedido"].ToString();
                ReporteDocumentoReferencia.Serie = reader["Serie"].ToString();
                ReporteDocumentoReferencia.Numero = reader["Numero"].ToString();
                ReporteDocumentoReferencia.Fecha = DateTime.Parse(reader["fecha"].ToString());
                ReporteDocumentoReferencia.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteDocumentoReferencia.Referencia = reader["Referencia"].ToString();
                ReporteDocumentoReferencia.FechaReferencia = DateTime.Parse(reader["FechaReferencia"].ToString());
                ReporteDocumentoReferencia.DescCliente = reader["DescCliente"].ToString();
                ReporteDocumentoReferencia.Direccion = reader["direccion"].ToString();
                ReporteDocumentoReferencia.CodMoneda = reader["CodMoneda"].ToString();
                ReporteDocumentoReferencia.DescMoneda = reader["DescMoneda"].ToString();
                ReporteDocumentoReferencia.SubTotal = Decimal.Parse(reader["subTotal"].ToString());
                ReporteDocumentoReferencia.Igv = Decimal.Parse(reader["igv"].ToString());
                ReporteDocumentoReferencia.Total = Decimal.Parse(reader["total"].ToString());
                ReporteDocumentoReferencia.CodigoProveedor = reader["codigoProveedor"].ToString();
                ReporteDocumentoReferencia.NombreProducto = reader["nombreProducto"].ToString();
                ReporteDocumentoReferencia.Abreviatura = reader["Abreviatura"].ToString();
                ReporteDocumentoReferencia.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                ReporteDocumentoReferencia.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                ReporteDocumentoReferencia.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                ReporteDocumentoReferencia.DescVendedor = reader["DescVendedor"].ToString();
                ReporteDocumentoReferencia.DescTipoAplicacion = reader["DescTipoAplicacion"].ToString();

                ReporteDocumentoReferencialist.Add(ReporteDocumentoReferencia);
            }
            reader.Close();
            reader.Dispose();
            return ReporteDocumentoReferencialist;
        }
    }
}
