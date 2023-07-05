using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CotizacionDL
    {
        public CotizacionDL() { }

        public Int32 Inserta(CotizacionBE pItem)
        {
            Int32 intIdCotizacion = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cotizacion_Inserta");

            db.AddOutParameter(dbCommand, "pIdCotizacion", DbType.Int32, pItem.IdCotizacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroCotizacion", DbType.String, pItem.NumeroCotizacion);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pFechaCredito", DbType.DateTime, pItem.FechaCredito);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdCotizacion = (int)db.GetParameterValue(dbCommand, "pIdCotizacion");

            return intIdCotizacion;
        }

        public void Actualiza(CotizacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cotizacion_Actualiza");

            db.AddInParameter(dbCommand, "pIdCotizacion", DbType.Int32, pItem.IdCotizacion);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroCotizacion", DbType.String, pItem.NumeroCotizacion);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pFechaCredito", DbType.DateTime, pItem.FechaCredito);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CotizacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cotizacion_Elimina");

            db.AddInParameter(dbCommand, "pIdCotizacion", DbType.Int32, pItem.IdCotizacion);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public CotizacionBE Selecciona(int IdEmpresa, int IdCotizacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cotizacion_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCotizacion", DbType.Int32, IdCotizacion);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            CotizacionBE Cotizacion = null;
            while (reader.Read())
            {
                Cotizacion = new CotizacionBE();
                Cotizacion.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cotizacion.IdCotizacion = Int32.Parse(reader["IdCotizacion"].ToString());
                Cotizacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cotizacion.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Cotizacion.NumeroPedido = reader["NumeroPedido"].ToString();
                Cotizacion.DescFormaPago = reader["DescFormaPago"].ToString();
                Cotizacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cotizacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cotizacion.DescCliente = reader["DescCliente"].ToString();
                Cotizacion.NumeroCotizacion = reader["numeroCotizacion"].ToString();
                Cotizacion.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Cotizacion.CodMoneda = reader["CodMoneda"].ToString();
                Cotizacion.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Cotizacion.Total = Decimal.Parse(reader["total"].ToString());
                Cotizacion.Descripcion = reader["Descripcion"].ToString();
                Cotizacion.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Cotizacion.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Cotizacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Cotizacion;
        }

        public List<CotizacionBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cotizacion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CotizacionBE> Cotizacionlist = new List<CotizacionBE>();
            CotizacionBE Cotizacion;
            while (reader.Read())
            {
                Cotizacion = new CotizacionBE();
                Cotizacion.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cotizacion.IdCotizacion = Int32.Parse(reader["IdCotizacion"].ToString());
                Cotizacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cotizacion.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Cotizacion.NumeroPedido = reader["NumeroPedido"].ToString();
                Cotizacion.DescFormaPago = reader["DescFormaPago"].ToString();
                Cotizacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cotizacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cotizacion.DescCliente = reader["DescCliente"].ToString();
                Cotizacion.NumeroCotizacion = reader["numeroCotizacion"].ToString();
                Cotizacion.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Cotizacion.CodMoneda = reader["CodMoneda"].ToString();
                Cotizacion.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Cotizacion.Total = Decimal.Parse(reader["total"].ToString());
                Cotizacion.Descripcion = reader["Descripcion"].ToString();
                Cotizacion.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Cotizacion.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Cotizacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cotizacionlist.Add(Cotizacion);
            }
            reader.Close();
            reader.Dispose();
            return Cotizacionlist;
        }

        public List<CotizacionBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cotizacion_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CotizacionBE> Cotizacionlist = new List<CotizacionBE>();
            CotizacionBE Cotizacion;
            while (reader.Read())
            {
                Cotizacion = new CotizacionBE();
                Cotizacion.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cotizacion.IdCotizacion = Int32.Parse(reader["IdCotizacion"].ToString());
                Cotizacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cotizacion.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Cotizacion.NumeroPedido = reader["NumeroPedido"].ToString();
                Cotizacion.DescFormaPago = reader["DescFormaPago"].ToString();
                Cotizacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cotizacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cotizacion.DescCliente = reader["DescCliente"].ToString();
                Cotizacion.NumeroCotizacion = reader["numeroCotizacion"].ToString();
                Cotizacion.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Cotizacion.CodMoneda = reader["CodMoneda"].ToString();
                Cotizacion.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Cotizacion.Total = Decimal.Parse(reader["total"].ToString());
                Cotizacion.Descripcion = reader["Descripcion"].ToString();
                Cotizacion.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Cotizacion.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Cotizacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cotizacionlist.Add(Cotizacion);
            }
            reader.Close();
            reader.Dispose();
            return Cotizacionlist;
        }

        public List<CotizacionBE> ListaNumero(int Periodo, string NumeroCotizacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cotizacion_ListaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumeroCotizacion", DbType.String, NumeroCotizacion);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CotizacionBE> Cotizacionlist = new List<CotizacionBE>();
            CotizacionBE Cotizacion;
            while (reader.Read())
            {
                Cotizacion = new CotizacionBE();
                Cotizacion.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cotizacion.IdCotizacion = Int32.Parse(reader["IdCotizacion"].ToString());
                Cotizacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cotizacion.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Cotizacion.NumeroPedido = reader["NumeroPedido"].ToString();
                Cotizacion.DescFormaPago = reader["DescFormaPago"].ToString();
                Cotizacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cotizacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cotizacion.DescCliente = reader["DescCliente"].ToString();
                Cotizacion.NumeroCotizacion = reader["numeroCotizacion"].ToString();
                Cotizacion.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Cotizacion.CodMoneda = reader["CodMoneda"].ToString();
                Cotizacion.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Cotizacion.Total = Decimal.Parse(reader["total"].ToString());
                Cotizacion.Descripcion = reader["Descripcion"].ToString();
                Cotizacion.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Cotizacion.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Cotizacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cotizacionlist.Add(Cotizacion);
            }
            reader.Close();
            reader.Dispose();
            return Cotizacionlist;
        }

        public List<CotizacionBE> ListaPedido(int Periodo, string NumeroPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cotizacion_ListaPedido");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumeroPedido", DbType.String, NumeroPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CotizacionBE> Cotizacionlist = new List<CotizacionBE>();
            CotizacionBE Cotizacion;
            while (reader.Read())
            {
                Cotizacion = new CotizacionBE();
                Cotizacion.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Cotizacion.IdCotizacion = Int32.Parse(reader["IdCotizacion"].ToString());
                Cotizacion.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cotizacion.IdPedido = Int32.Parse(reader["idPedido"].ToString());
                Cotizacion.NumeroPedido = reader["NumeroPedido"].ToString();
                Cotizacion.DescFormaPago = reader["DescFormaPago"].ToString();
                Cotizacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cotizacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cotizacion.DescCliente = reader["DescCliente"].ToString();
                Cotizacion.NumeroCotizacion = reader["numeroCotizacion"].ToString();
                Cotizacion.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Cotizacion.CodMoneda = reader["CodMoneda"].ToString();
                Cotizacion.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Cotizacion.Total = Decimal.Parse(reader["total"].ToString());
                Cotizacion.Descripcion = reader["Descripcion"].ToString();
                Cotizacion.FechaCredito = DateTime.Parse(reader["fechaCredito"].ToString());
                Cotizacion.FechaVencimiento = DateTime.Parse(reader["fechaVencimiento"].ToString());
                Cotizacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cotizacionlist.Add(Cotizacion);
            }
            reader.Close();
            reader.Dispose();
            return Cotizacionlist;
        }
    }
}

