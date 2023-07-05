using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;


namespace ErpPanorama.DataLogic
{
    public class ReporteCreditoDL
    {
        public List<ReporteCreditoBE> ListadoCreditoVencido(int IdEmpresa, int IdCliente, DateTime FechaDesde, DateTime FechaHasta, int IdTipoCliente, int IdClasificacionCliente, int IdMotivo,int IdClasificaClienteCredito, int Moroso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuentaCreditoVencidos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdClasificacionCliente", DbType.Int32, IdClasificacionCliente);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pIdClasificaClienteCredito", DbType.Int32, IdClasificaClienteCredito);
            db.AddInParameter(dbCommand, "pMoroso", DbType.Int32, Moroso);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCreditoBE> ReporteCreditolist = new List<ReporteCreditoBE>();
            ReporteCreditoBE ReporteCredito;
            while (reader.Read())
            {
                ReporteCredito = new ReporteCreditoBE();
                ReporteCredito.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteCredito.DescRuta = reader["DescRuta"].ToString();
                ReporteCredito.DescCliente = reader["descCliente"].ToString();
                ReporteCredito.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                ReporteCredito.NumeroDias = Int32.Parse(reader["NumeroDias"].ToString());
                ReporteCreditolist.Add(ReporteCredito);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCreditolist;
        }

        public List<ReporteCreditoBE> ListadoCreditoMensual(int IdEmpresa, int IdMotivo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuentaCreditoMensual");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCreditoBE> ReporteCreditolist = new List<ReporteCreditoBE>();
            ReporteCreditoBE ReporteCredito;
            while (reader.Read())
            {
                ReporteCredito = new ReporteCreditoBE();
                ReporteCredito.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteCredito.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ReporteCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteCredito.DescCliente = reader["descCliente"].ToString();
                ReporteCredito.Concepto = reader["Concepto"].ToString();
                ReporteCredito.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                ReporteCredito.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteCredito.NumeroDias = Int32.Parse(reader["NumeroDias"].ToString());
                ReporteCredito.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                ReporteCreditolist.Add(ReporteCredito);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCreditolist;
        }

        public List<ReporteCreditoBE> ListadoCreditoMensualTodos(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuentaCreditoMensualTodos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCreditoBE> ReporteCreditolist = new List<ReporteCreditoBE>();
            ReporteCreditoBE ReporteCredito;
            while (reader.Read())
            {
                ReporteCredito = new ReporteCreditoBE();
                ReporteCredito.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteCredito.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ReporteCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteCredito.DescCliente = reader["descCliente"].ToString();
                ReporteCredito.Concepto = reader["Concepto"].ToString();
                ReporteCredito.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                ReporteCredito.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteCredito.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                ReporteCredito.NumeroDias = Int32.Parse(reader["NumeroDias"].ToString());
                ReporteCreditolist.Add(ReporteCredito);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCreditolist;
        }

        public List<ReporteCreditoBE> ListadoCreditoPagos(int IdEmpresa, int IdMotivo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEstadoCuentaCreditoPagos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCreditoBE> ReporteCreditolist = new List<ReporteCreditoBE>();
            ReporteCreditoBE ReporteCredito;
            while (reader.Read())
            {
                ReporteCredito = new ReporteCreditoBE();
                ReporteCredito.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteCredito.AbrevDocumento = reader["AbrevDocumento"].ToString();
                ReporteCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteCredito.DescCliente = reader["descCliente"].ToString();
                ReporteCredito.Concepto = reader["Concepto"].ToString();
                ReporteCredito.NumeroPago = reader["NumeroPago"].ToString();
                ReporteCredito.AbrevFormaPago = reader["AbrevFormaPago"].ToString();
                ReporteCredito.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                ReporteCredito.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ReporteCredito.NumeroDias = Int32.Parse(reader["NumeroDias"].ToString());
                ReporteCredito.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                ReporteCreditolist.Add(ReporteCredito);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCreditolist;
        }

        public List<ReporteCreditoBE> ListadoMorosos(int IdEmpresa, int IdMotivo,String clasifica)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListarClientesMorosos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pclasifica", DbType.String , clasifica);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteCreditoBE> ReporteCreditolist = new List<ReporteCreditoBE>();
            ReporteCreditoBE ReporteCredito;
            while (reader.Read())
            {
                ReporteCredito = new ReporteCreditoBE();
                //ReporteCredito.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                ReporteCredito.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ReporteCredito.DescRuta = reader["DescRuta"].ToString();
                ReporteCredito.DescCliente = reader["descCliente"].ToString();
                ReporteCredito.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                ReporteCredito.NumeroDias = Int32.Parse(reader["NumeroDias"].ToString());
                ReporteCreditolist.Add(ReporteCredito);
            }
            reader.Close();
            reader.Dispose();
            return ReporteCreditolist;
        }



    }
}
