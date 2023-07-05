using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoClienteDaotDL
    {
        public List<ReportePedidoClienteDaotBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdEmpresa, int IdCliente, string IdTipoDocumento, string Operador, decimal Valor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoClienteDAOT");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.String, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pOperador", DbType.String, Operador);
            db.AddInParameter(dbCommand, "pValor", DbType.Decimal, Valor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoClienteDaotBE> Pedidolist = new List<ReportePedidoClienteDaotBE>();
            ReportePedidoClienteDaotBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoClienteDaotBE();

                Pedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pedido.DescCliente = reader["DescCliente"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
