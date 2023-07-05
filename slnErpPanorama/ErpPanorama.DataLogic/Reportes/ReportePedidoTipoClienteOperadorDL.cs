using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePedidoTipoClienteOperadorDL
    {
        public List<ReportePedidoTipoClienteOperadorBE> Listado(int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoGestionMayorista");
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            dbCommand.CommandTimeout = 250;

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePedidoTipoClienteOperadorBE> MovimientoPedidolist = new List<ReportePedidoTipoClienteOperadorBE>();
            ReportePedidoTipoClienteOperadorBE MovimientoPedido;
            while (reader.Read())
            {
                MovimientoPedido = new ReportePedidoTipoClienteOperadorBE();
                MovimientoPedido.Numero = reader["Numero"].ToString();
                MovimientoPedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoPedido.DescTienda = reader["DescTienda"].ToString();
                MovimientoPedido.DescCliente = reader["DescCliente"].ToString();
                MovimientoPedido.DescVendedor = reader["DescVendedor"].ToString();
                MovimientoPedido.DescSituacion = reader["DescSituacion"].ToString();
                MovimientoPedido.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoPedido.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoPedido.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoPedido.Destino = reader["Destino"].ToString();
                MovimientoPedido.Aprobado = Boolean.Parse(reader["Aprobado"].ToString());
                MovimientoPedido.FechaAprobado = reader["FechaAprobado"].ToString();
                MovimientoPedido.Recibido = Boolean.Parse(reader["Recibido"].ToString());
                MovimientoPedido.FechaRecibido = reader["FechaRecibido"].ToString();
                MovimientoPedido.Preparacion = Boolean.Parse(reader["Preparacion"].ToString());
                MovimientoPedido.FechaPreparacion = reader["FechaPreparacion"].ToString();
                MovimientoPedido.Chequeo = Boolean.Parse(reader["Chequeo"].ToString());
                MovimientoPedido.FechaChequeo = reader["FechaChequeo"].ToString();
                MovimientoPedido.EnPT = Boolean.Parse(reader["EnPT"].ToString());
                MovimientoPedido.FechaPT = reader["FechaPT"].ToString();
                MovimientoPedido.RecepcionDocumento = Boolean.Parse(reader["RecepcionDocumento"].ToString());
                MovimientoPedido.FechaRD = reader["FechaRD"].ToString();
                MovimientoPedido.Despachado = Boolean.Parse(reader["Despachado"].ToString());
                MovimientoPedido.FechaDespachado = reader["FechaDespachado"].ToString();
                MovimientoPedido.FechaAnulado = reader["FechaAnulado"].ToString();

                //MovimientoPedido.Aprobado = Boolean.Parse(reader["Aprobado"].ToString());
                //MovimientoPedido.FechaAprobado = DateTime.Parse(reader["FechaAprobado"].ToString());
                //MovimientoPedido.Recibido = Boolean.Parse(reader["Recibido"].ToString());
                //MovimientoPedido.FechaRecibido = DateTime.Parse(reader["FechaRecibido"].ToString());
                //MovimientoPedido.Preparacion = Boolean.Parse(reader["Preparacion"].ToString());
                //MovimientoPedido.FechaPreparacion = DateTime.Parse(reader["FechaPreparacion"].ToString());
                //MovimientoPedido.Chequeo = Boolean.Parse(reader["Chequeo"].ToString());
                //MovimientoPedido.FechaChequeo = DateTime.Parse(reader["FechaChequeo"].ToString());
                //MovimientoPedido.EnPT = Boolean.Parse(reader["EnPT"].ToString());
                //MovimientoPedido.FechaPT = DateTime.Parse(reader["FechaPT"].ToString());
                //MovimientoPedido.RecepcionDocumento = Boolean.Parse(reader["RecepcionDocumento"].ToString());
                //MovimientoPedido.FechaRD = DateTime.Parse(reader["FechaRD"].ToString());
                //MovimientoPedido.Despachado = Boolean.Parse(reader["Despachado"].ToString());
                //MovimientoPedido.FechaDespachado = DateTime.Parse(reader["FechaDespachado"].ToString());
                //MovimientoPedido.FechaAnulado = DateTime.Parse(reader["FechaAnulado"].ToString());



                MovimientoPedido.Observacion = reader["Observacion"].ToString();
                MovimientoPedido.Conductor = reader["Conductor"].ToString();
                MovimientoPedido.TotalCantidadInicial = Int32.Parse(reader["TotalCantidadInicial"].ToString());
                MovimientoPedido.TotalItemsInicial = Int32.Parse(reader["TotalItemsInicial"].ToString());
                MovimientoPedido.TotalCantidad = Int32.Parse(reader["TotalCantidad"].ToString());
                MovimientoPedido.TotalItems = Int32.Parse(reader["TotalItems"].ToString());
                MovimientoPedidolist.Add(MovimientoPedido);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidolist;
        }

        //public List<ReportePedidoTipoClienteOperadorBE> ListadoContado(int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTipoClienteOperador");
        //    db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
        //    db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
        //    db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
        //    dbCommand.CommandTimeout = 250;

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    List<ReportePedidoTipoClienteOperadorBE> MovimientoPedidolist = new List<ReportePedidoTipoClienteOperadorBE>();
        //    ReportePedidoTipoClienteOperadorBE MovimientoPedido;
        //    while (reader.Read())
        //    {
        //        MovimientoPedido = new ReportePedidoTipoClienteOperadorBE();
        //        MovimientoPedido.Fecha = DateTime.Parse(reader["fecha"].ToString());
        //        MovimientoPedido.Numero = reader["numero"].ToString();
        //        MovimientoPedido.DescTienda = reader["DescTienda"].ToString();
        //        MovimientoPedido.DescCliente = reader["DescCliente"].ToString();
        //        MovimientoPedido.DescFormaPago = reader["descFormaPago"].ToString();
        //        MovimientoPedido.CodMoneda = reader["CodMoneda"].ToString();
        //        MovimientoPedido.DescVendedor = reader["DescVendedor"].ToString();
        //        MovimientoPedido.Total = Decimal.Parse(reader["total"].ToString());
        //        MovimientoPedido.DescSituacion = reader["DescSituacion"].ToString();
        //        MovimientoPedido.DescAuxiliar = reader["DescAuxiliar"].ToString();
        //        MovimientoPedido.Cantidad = Int32.Parse( reader["Cantidad"].ToString());
        //        MovimientoPedidolist.Add(MovimientoPedido);
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return MovimientoPedidolist;
        //}    
    
    }
}
