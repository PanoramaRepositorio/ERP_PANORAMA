using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoTiendaMesTipoClienteVariacionDL
    {
        public List<ReportePedidoTiendaMesTipoClienteVariacionBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaMesTipoClienteVariacion");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTiendaMesTipoClienteVariacionBE> Pedidolist = new List<ReportePedidoTiendaMesTipoClienteVariacionBE>();
            ReportePedidoTiendaMesTipoClienteVariacionBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTiendaMesTipoClienteVariacionBE();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.DescTiendaAnterior = reader["DescTiendaAnterior"].ToString();
                Pedido.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Pedido.PeriodoAnterior = Decimal.Parse(reader["PeriodoAnterior"].ToString());
                Pedido.PeriodoActual = Decimal.Parse(reader["PeriodoActual"].ToString());
                Pedido.VariacionRelativa = Decimal.Parse(reader["VariacionRelativa"].ToString());
                Pedido.VariacionPorcentual = Decimal.Parse(reader["VariacionPorcentual"].ToString());
                Pedido.Meta = Decimal.Parse(reader["Meta"].ToString());
                Pedido.VariacionRelativaMeta = Decimal.Parse(reader["VariacionRelativaMeta"].ToString());
                Pedido.VariacionPorcentualMeta = Decimal.Parse(reader["VariacionPorcentualMeta"].ToString());
                Pedido.PorcentajeCrecimiento = Decimal.Parse(reader["PorcentajeCrecimiento"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

    }
}
