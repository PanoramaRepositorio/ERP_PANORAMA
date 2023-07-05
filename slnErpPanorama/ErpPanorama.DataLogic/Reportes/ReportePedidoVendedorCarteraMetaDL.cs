using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoVendedorCarteraMetaDL
    {
        public List<ReportePedidoVendedorCarteraMetaBE> Listado (DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorCarteraMeta");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorCarteraMetaBE> Pedidolist = new List<ReportePedidoVendedorCarteraMetaBE>();
            ReportePedidoVendedorCarteraMetaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorCarteraMetaBE();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.DescRuta = reader["DescRuta"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());
                Pedido.AlcanceMeta = decimal.Parse(reader["AlcanceMeta"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoVendedorCarteraMetaBE> ListadoDetalle(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorCarteraMetaDetalle");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorCarteraMetaBE> Pedidolist = new List<ReportePedidoVendedorCarteraMetaBE>();
            ReportePedidoVendedorCarteraMetaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorCarteraMetaBE();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.DescRuta = reader["DescRuta"].ToString();
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescFormaPago = reader["DescFormaPago"].ToString();
                Pedido.FechaPedido = DateTime.Parse(reader["FechaPedido"].ToString());
                Pedido.CodMoneda = reader["CodMoneda"].ToString();
                Pedido.Total = decimal.Parse(reader["Total"].ToString());
                Pedido.FechaFacturacion = DateTime.Parse(reader["FechaFacturacion"].ToString());
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoVendedorCarteraMetaBE> ListadoSueldo(int IdVendedor, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorCarteraMetaSueldo");
            db.AddInParameter(dbCommand, "@pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorCarteraMetaBE> Pedidolist = new List<ReportePedidoVendedorCarteraMetaBE>();
            ReportePedidoVendedorCarteraMetaBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorCarteraMetaBE();
                Pedido.ApeNom = reader["ApeNom"].ToString();
                Pedido.DescRuta = reader["DescRuta"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.TotalPiso = decimal.Parse(reader["TotalPiso"].ToString());
                Pedido.TotalPisoSinIGV = decimal.Parse(reader["TotalPisoSinIGV"].ToString());
                Pedido.TotalFinal = decimal.Parse(reader["TotalFinal"].ToString());
                Pedido.TotalFinalSinIGV = decimal.Parse(reader["TotalFinalSinIGV"].ToString());
                Pedido.ComisionFinal = decimal.Parse(reader["ComisionFinal"].ToString());
                Pedido.TotalCartera = decimal.Parse(reader["TotalCartera"].ToString());
                Pedido.TotalCarteraSinIGV = decimal.Parse(reader["TotalCarteraSinIGV"].ToString());
                Pedido.TotalCarteraPersona = decimal.Parse(reader["TotalCarteraPersona"].ToString());
                Pedido.TotalCarteraPersonaSinIGV = decimal.Parse(reader["TotalCarteraPersonaSinIGV"].ToString());
                Pedido.TotalSinMatch = decimal.Parse(reader["TotalSinMatch"].ToString());
                Pedido.TotalPisoAntes = decimal.Parse(reader["TotalPisoAntes"].ToString());
                Pedido.TotalPisoAntesSinIGV = decimal.Parse(reader["TotalPisoAntesSinIGV"].ToString());
                Pedido.TotalCarteraAntes = decimal.Parse(reader["TotalCarteraAntes"].ToString());
                Pedido.TotalCarteraAntesSinIGV = decimal.Parse(reader["TotalCarteraAntesSinIGV"].ToString());
                Pedido.Meta = decimal.Parse(reader["Meta"].ToString());
                Pedido.AlcanceMeta = decimal.Parse(reader["AlcanceMeta"].ToString());
                Pedido.SueldoBase = decimal.Parse(reader["SueldoBase"].ToString());
                Pedido.Comision = decimal.Parse(reader["Comision"].ToString());
                Pedido.ComisionCliente = decimal.Parse(reader["ComisionCliente"].ToString());
                Pedido.Prospecto = decimal.Parse(reader["Prospecto"].ToString());
                Pedido.ComisionDM5 = decimal.Parse(reader["ComisionDM5"].ToString());
                Pedido.ComisionPiso = decimal.Parse(reader["ComisionPiso"].ToString());
                Pedido.ComisionCartera = decimal.Parse(reader["ComisionCartera"].ToString());
                Pedido.ComisionPersona = decimal.Parse(reader["ComisionPersona"].ToString());
                Pedido.ComisionaPersonaAntes = decimal.Parse(reader["ComisionaPersonaAntes"].ToString());
                Pedido.ComisionMixtaAntes = decimal.Parse(reader["ComisionMixtaAntes"].ToString());
                Pedido.SueldoBruto = decimal.Parse(reader["SueldoBruto"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

    }
}
