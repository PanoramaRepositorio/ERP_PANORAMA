using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteTiendaTipoClienteMetaDL
    {
        public List<ReporteTiendaTipoClienteMetaBE> Listado(int IdTienda, int IdTipoCliente, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoTiendaTipoClienteMeta");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTiendaTipoClienteMetaBE> lista = new List<ReporteTiendaTipoClienteMetaBE>();
            ReporteTiendaTipoClienteMetaBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteTiendaTipoClienteMetaBE();
                reporte.Dia = reader["Dia"].ToString();
                reporte.DiaMes = Int32.Parse(reader["DiaMes"].ToString());
                reporte.Fecha1 = DateTime.Parse(reader["Fecha1"].ToString());
                reporte.Importe1 = Decimal.Parse(reader["Importe1"].ToString());
                reporte.Porcentaje = Decimal.Parse(reader["Porcentaje"].ToString());
                reporte.Fecha2 = DateTime.Parse(reader["Fecha2"].ToString());
                reporte.ImporteFinal = Decimal.Parse(reader["ImporteFinal"].ToString());
                reporte.ImporteMayorista = Decimal.Parse(reader["ImporteMayorista"].ToString());
                reporte.Importe2 = Decimal.Parse(reader["Importe2"].ToString());
                reporte.Meta = Decimal.Parse(reader["Meta"].ToString());
                reporte.Cumplimiento = Decimal.Parse(reader["Cumplimiento"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }

        public List<ReporteTiendaTipoClienteMetaBE> ListadoVendedor(int IdEmpresa, int IdTienda, int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPedidoVendendedorMeta");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteTiendaTipoClienteMetaBE> lista = new List<ReporteTiendaTipoClienteMetaBE>();
            ReporteTiendaTipoClienteMetaBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteTiendaTipoClienteMetaBE();
                reporte.Dia = reader["Dia"].ToString();
                reporte.DiaMes = Int32.Parse(reader["DiaMes"].ToString());
                reporte.DescVendedor = reader["DescVendedor"].ToString();
                reporte.DescCargo = reader["DescCargo"].ToString();
                reporte.DescTienda = reader["DescTienda"].ToString();
                reporte.Fecha1 = DateTime.Parse(reader["Fecha1"].ToString());
                reporte.Importe1 = Decimal.Parse(reader["Importe1"].ToString());
                reporte.Porcentaje = Decimal.Parse(reader["Porcentaje"].ToString());
                reporte.Fecha2 = DateTime.Parse(reader["Fecha2"].ToString());
                //reporte.ImporteFinal = Decimal.Parse(reader["ImporteFinal"].ToString());
                //reporte.ImporteMayorista = Decimal.Parse(reader["ImporteMayorista"].ToString());
                reporte.Importe2 = Decimal.Parse(reader["Importe2"].ToString());
                reporte.Meta = Decimal.Parse(reader["Meta"].ToString());
                reporte.Cumplimiento = Decimal.Parse(reader["Cumplimiento"].ToString());
                reporte.CantidadCliente = Int32.Parse(reader["CantidadCliente"].ToString());
                reporte.TicketPromedio = Decimal.Parse(reader["TicketPromedio"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }

    }
}
