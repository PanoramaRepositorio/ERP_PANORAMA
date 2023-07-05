using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;


namespace ErpPanorama.DataLogic
{
    public class FacturaPorCobrarDL
    {
        public List<FacturaPorCobrarBE> ListaTodosActivo(int IdEmpresa, int IdSituacionContable, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVenta_ListaFacturaPorCobrar");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSituacionContable", DbType.Int32, IdSituacionContable);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaPorCobrarBE> FacturaPorCobrarlist = new List<FacturaPorCobrarBE>();
            FacturaPorCobrarBE FacturaPorCobrar;
            while (reader.Read())
            {
                FacturaPorCobrar = new FacturaPorCobrarBE();
                FacturaPorCobrar.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                FacturaPorCobrar.RazonSocial = reader["RazonSocial"].ToString();
                FacturaPorCobrar.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                FacturaPorCobrar.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                FacturaPorCobrar.DescTienda = reader["DescTienda"].ToString();
                FacturaPorCobrar.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                FacturaPorCobrar.NumeroPedido = reader["NumeroPedido"].ToString();
                FacturaPorCobrar.IdSituacionPedido = Int32.Parse(reader["IdSituacionPedido"].ToString());
                FacturaPorCobrar.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                FacturaPorCobrar.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                FacturaPorCobrar.Numero = reader["Numero"].ToString();
                FacturaPorCobrar.IdDocumentoReferencia = reader.IsDBNull(reader.GetOrdinal("IdDocumentoReferencia")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoReferencia"));
                FacturaPorCobrar.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                FacturaPorCobrar.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                FacturaPorCobrar.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                FacturaPorCobrar.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                FacturaPorCobrar.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                FacturaPorCobrar.NumeroDocumento = reader["NumeroDocumento"].ToString();
                FacturaPorCobrar.DescCliente = reader["DescCliente"].ToString();
                FacturaPorCobrar.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                FacturaPorCobrar.DescTipoCliente = reader["DescTipoCliente"].ToString();
                FacturaPorCobrar.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                FacturaPorCobrar.DescRuta = reader["DescRuta"].ToString();
                FacturaPorCobrar.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                FacturaPorCobrar.CodMoneda = reader["CodMoneda"].ToString();
                FacturaPorCobrar.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                FacturaPorCobrar.Total = Decimal.Parse(reader["Total"].ToString());
                FacturaPorCobrar.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                FacturaPorCobrar.DescSituacion = reader["DescSituacion"].ToString();
                FacturaPorCobrar.DescFormaPago = reader["DescFormaPago"].ToString();
                FacturaPorCobrar.DescVendedor = reader["DescVendedor"].ToString();
                FacturaPorCobrar.IdSituacionPSE = Int32.Parse(reader["IdSituacionPSE"].ToString());
                FacturaPorCobrar.DescSituacionPSE = reader["DescSituacionPSE"].ToString();
                FacturaPorCobrar.IdSituacionContable = Int32.Parse(reader["IdSituacionContable"].ToString());
                FacturaPorCobrar.DescSituacionContable = reader["DescSituacionContable"].ToString();
                FacturaPorCobrar.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FacturaPorCobrarlist.Add(FacturaPorCobrar);
            }
            reader.Close();
            reader.Dispose();
            return FacturaPorCobrarlist;
        }

    }
}
