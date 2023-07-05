using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpPanorama.BusinessEntity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoComparativoDL
    {

        public List<ReportePedidoTiendaComparativoBE> Listado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaComparativo");
            db.AddInParameter(dbCommand, "@pIdEmpresa", System.Data.DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTiendaComparativoBE> Pedidolist = new List<ReportePedidoTiendaComparativoBE>();
            ReportePedidoTiendaComparativoBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTiendaComparativoBE();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }
    }
}
