using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoClienteDaotDetalleDL
    {
        public List<ReportePedidoClienteDaotDetalleBE> Listado(DateTime FechaDesde, DateTime FechaHasta, int IdEmpresa, int IdCliente, string IdTipoDocumento, string Operador, decimal Valor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoClienteDaotDetalle");
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.String, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pOperador", DbType.String, Operador);
            db.AddInParameter(dbCommand, "pValor", DbType.Decimal, Valor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoClienteDaotDetalleBE> Pedidolist = new List<ReportePedidoClienteDaotDetalleBE>();
            ReportePedidoClienteDaotDetalleBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoClienteDaotDetalleBE();

                Pedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pedido.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Pedido.Serie = reader["Serie"].ToString();
                Pedido.Numero = reader["Numero"].ToString();
                Pedido.DescTipoDocumento = reader["DescTipoDocumento"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
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
