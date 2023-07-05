using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoVendedorCarteraDL
    {
        public List<ReportePedidoVendedorCarteraBE> Listado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendedorCartera");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoVendedorCarteraBE> Pedidolist = new List<ReportePedidoVendedorCarteraBE>();
            ReportePedidoVendedorCarteraBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoVendedorCarteraBE();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.DescRuta = reader["DescRuta"].ToString();
                Pedido.Vendedor = reader["Vendedor"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.NomDpto = reader["NomDpto"].ToString();
                Pedido.NomProv = reader["NomProv"].ToString();
                Pedido.NomDist = reader["NomDist"].ToString();
                Pedido.Telefono = reader["Telefono"].ToString();
                Pedido.Celular = reader["Celular"].ToString();
                Pedido.OtroTelefono = reader["OtroTelefono"].ToString();
                Pedido.TelefonoAdicional = reader["TelefonoAdicional"].ToString();
                Pedido.Email = reader["Email"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
