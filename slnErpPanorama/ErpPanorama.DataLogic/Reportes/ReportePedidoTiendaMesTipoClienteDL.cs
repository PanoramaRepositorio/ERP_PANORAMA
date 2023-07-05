using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoTiendaMesTipoClienteDL
    {
        public List<ReportePedidoTiendaMesTipoClienteBE> Listado(int IdEmpresa, int IdPersona, int IdTienda, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaMesTipoCliente");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTiendaMesTipoClienteBE> Pedidolist = new List<ReportePedidoTiendaMesTipoClienteBE>();
            ReportePedidoTiendaMesTipoClienteBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTiendaMesTipoClienteBE();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.Anio = Int32.Parse(reader["Anio"].ToString());
                Pedido.Mes = reader["Mes"].ToString();
                Pedido.TipoCliente = reader["TipoCliente"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoTiendaMesTipoClienteBE> ListadoPorCanalVenta(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaMesTipoClienteCanalVenta");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTiendaMesTipoClienteBE> Pedidolist = new List<ReportePedidoTiendaMesTipoClienteBE>();
            ReportePedidoTiendaMesTipoClienteBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTiendaMesTipoClienteBE();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.Anio = Int32.Parse(reader["Anio"].ToString());
                Pedido.Mes = reader["Mes"].ToString();
                Pedido.TipoCliente = reader["TipoCliente"].ToString();
                Pedido.DescTipoVendedor = reader["DescTipoVendedor"].ToString();
                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoTiendaMesTipoClienteBE> ListadoPorLinea(int IdEmpresa, int IdTienda, int IdLineaProducto, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaMesTipoClienteLineaProducto");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTiendaMesTipoClienteBE> Pedidolist = new List<ReportePedidoTiendaMesTipoClienteBE>();
            ReportePedidoTiendaMesTipoClienteBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTiendaMesTipoClienteBE();
                Pedido.Mes = reader["Mes"].ToString();
                Pedido.DescMes = reader["DescMes"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());
                Pedido.TipoCliente = reader["TipoCliente"].ToString();
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                //Pedido.Enero = decimal.Parse(reader["Enero"].ToString());
                //Pedido.Febrero = decimal.Parse(reader["Febrero"].ToString());
                //Pedido.Marzo = decimal.Parse(reader["Marzo"].ToString());
                //Pedido.Abril = decimal.Parse(reader["Abril"].ToString());
                //Pedido.Mayo = decimal.Parse(reader["Mayo"].ToString());
                //Pedido.Junio = decimal.Parse(reader["Junio"].ToString());
                //Pedido.Julio = decimal.Parse(reader["Julio"].ToString());
                //Pedido.Agosto = decimal.Parse(reader["Agosto"].ToString());
                //Pedido.Setiembre = decimal.Parse(reader["Setiembre"].ToString());
                //Pedido.Octubre = decimal.Parse(reader["Octubre"].ToString());
                //Pedido.Noviembre = decimal.Parse(reader["Noviembre"].ToString());
                //Pedido.Diciembre = decimal.Parse(reader["Diciembre"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoTiendaMesTipoClienteBE> ListadoPorLineaHorizontal(int IdEmpresa, int IdTienda, int IdLineaProducto, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaMesTipoClienteLineaProducto");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTiendaMesTipoClienteBE> Pedidolist = new List<ReportePedidoTiendaMesTipoClienteBE>();
            ReportePedidoTiendaMesTipoClienteBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTiendaMesTipoClienteBE();
                //Pedido.Mes = reader["Mes"].ToString();
                //Pedido.DescMes = reader["DescMes"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.TipoCliente = reader["TipoCliente"].ToString();
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Pedido.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Pedido.Enero = decimal.Parse(reader["Enero"].ToString());
                Pedido.Febrero = decimal.Parse(reader["Febrero"].ToString());
                Pedido.Marzo = decimal.Parse(reader["Marzo"].ToString());
                Pedido.Abril = decimal.Parse(reader["Abril"].ToString());
                Pedido.Mayo = decimal.Parse(reader["Mayo"].ToString());
                Pedido.Junio = decimal.Parse(reader["Junio"].ToString());
                Pedido.Julio = decimal.Parse(reader["Julio"].ToString());
                Pedido.Agosto = decimal.Parse(reader["Agosto"].ToString());
                Pedido.Setiembre = decimal.Parse(reader["Setiembre"].ToString());
                Pedido.Octubre = decimal.Parse(reader["Octubre"].ToString());
                Pedido.Noviembre = decimal.Parse(reader["Noviembre"].ToString());
                Pedido.Diciembre = decimal.Parse(reader["Diciembre"].ToString());
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoTiendaMesTipoClienteBE> ListadoPorLineaCostoHorizontal(int IdEmpresa, int IdTienda, int IdLineaProducto, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaMesTipoClienteLineaProductoCosto");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "@pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "@pIdLineaProducto", DbType.Int32, IdLineaProducto);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "@pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTiendaMesTipoClienteBE> Pedidolist = new List<ReportePedidoTiendaMesTipoClienteBE>();
            ReportePedidoTiendaMesTipoClienteBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTiendaMesTipoClienteBE();
                //Pedido.Mes = reader["Mes"].ToString();
                //Pedido.DescMes = reader["DescMes"].ToString();
                Pedido.RazonSocial = reader["RazonSocial"].ToString();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.TipoCliente = reader["TipoCliente"].ToString();
                Pedido.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Pedido.Enero = decimal.Parse(reader["Enero"].ToString());
                Pedido.Febrero = decimal.Parse(reader["Febrero"].ToString());
                Pedido.Marzo = decimal.Parse(reader["Marzo"].ToString());
                Pedido.Abril = decimal.Parse(reader["Abril"].ToString());
                Pedido.Mayo = decimal.Parse(reader["Mayo"].ToString());
                Pedido.Junio = decimal.Parse(reader["Junio"].ToString());
                Pedido.Julio = decimal.Parse(reader["Julio"].ToString());
                Pedido.Agosto = decimal.Parse(reader["Agosto"].ToString());
                Pedido.Setiembre = decimal.Parse(reader["Setiembre"].ToString());
                Pedido.Octubre = decimal.Parse(reader["Octubre"].ToString());
                Pedido.Noviembre = decimal.Parse(reader["Noviembre"].ToString());
                Pedido.Diciembre = decimal.Parse(reader["Diciembre"].ToString());
                Pedido.TotalSoles = decimal.Parse(reader["TotalSoles"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }

        public List<ReportePedidoTiendaMesTipoClienteBE> ListadoComparativo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaComparativo");
            db.AddInParameter(dbCommand, "@pIdEmpresa", DbType.Int32, IdEmpresa);
            //db.AddInParameter(dbCommand, "@pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "@pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "@pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTiendaMesTipoClienteBE> Pedidolist = new List<ReportePedidoTiendaMesTipoClienteBE>();
            ReportePedidoTiendaMesTipoClienteBE Pedido;
            while (reader.Read())
            {
                Pedido = new ReportePedidoTiendaMesTipoClienteBE();
                Pedido.DescTienda = reader["DescTienda"].ToString();
                Pedido.Id = Int32.Parse(reader["Id"].ToString());
                Pedido.Anio = Int32.Parse(reader["Anio"].ToString());
                Pedido.CF = decimal.Parse(reader["CF"].ToString());
                Pedido.CM = decimal.Parse(reader["CM"].ToString());
                Pedido.CD = decimal.Parse(reader["CD"].ToString());
                Pedido.CE = decimal.Parse(reader["CE"].ToString());

                Pedido.DiferenciaCF = decimal.Parse(reader["DiferenciaCF"].ToString());
                Pedido.DiferenciaCM = decimal.Parse(reader["DiferenciaCM"].ToString());
                Pedido.DiferenciaCD = decimal.Parse(reader["DiferenciaCD"].ToString());
                Pedido.DiferenciaCE = decimal.Parse(reader["DiferenciaCE"].ToString());

                Pedido.DifValCF= decimal.Parse(reader["DifValCF"].ToString());
                Pedido.DifValCM = decimal.Parse(reader["DifValCM"].ToString());
                Pedido.DifValCD = decimal.Parse(reader["DifValCD"].ToString());
                Pedido.DifValCE = decimal.Parse(reader["DifValCE"].ToString());

                Pedido.TotalC = decimal.Parse(reader["TotalC"].ToString());
                Pedido.TotalDif = decimal.Parse(reader["TotalDif"].ToString());
                Pedido.TotalDifVal = decimal.Parse(reader["TotalDifVal"].ToString());
                Pedido.Visitas = decimal.Parse(reader["Visitas"].ToString());
                Pedido.Transaccion = decimal.Parse(reader["Transaccion"].ToString());
                Pedido.Conversion = decimal.Parse(reader["Conversion"].ToString());
                Pedido.TicketPromedio = decimal.Parse(reader["TicketPromedio"].ToString());
                Pedido.VentaTienda = decimal.Parse(reader["VentaTienda"].ToString());
                Pedido.TotalVisitas = decimal.Parse(reader["TotalVisitas"].ToString());
                Pedido.TotalTransaccion = decimal.Parse(reader["TotalTransaccion"].ToString());
                Pedido.TotalConversion = decimal.Parse(reader["TotalConversion"].ToString());
                Pedido.TotalTicketPromedio = decimal.Parse(reader["TotalTicketPromedio"].ToString());

                Pedidolist.Add(Pedido);
            }
            reader.Close();
            reader.Dispose();
            return Pedidolist;
        }


    }
}
