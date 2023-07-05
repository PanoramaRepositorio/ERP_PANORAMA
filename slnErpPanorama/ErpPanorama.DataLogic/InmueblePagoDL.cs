using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class InmueblePagoDL
    {
        public InmueblePagoDL() { }

        public void Inserta(InmueblePagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmueblePago_Inserta");

            db.AddInParameter(dbCommand, "pIdInmueblePago", DbType.Int32, pItem.IdInmueblePago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdInmueble", DbType.Int32, pItem.IdInmueble);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(InmueblePagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmueblePago_Actualiza");

            db.AddInParameter(dbCommand, "pIdInmueblePago", DbType.Int32, pItem.IdInmueblePago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pIdInmueble", DbType.Int32, pItem.IdInmueble);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(InmueblePagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmueblePago_Elimina");

            db.AddInParameter(dbCommand, "pIdInmueblePago", DbType.Int32, pItem.IdInmueblePago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<InmueblePagoBE> ListaTodosActivo(int IdEmpresa, int IdInmueble, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmueblePago_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdInmueble", DbType.Int32, IdInmueble);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InmueblePagoBE> InmueblePagolist = new List<InmueblePagoBE>();
            InmueblePagoBE InmueblePago;
            while (reader.Read())
            {
                InmueblePago = new InmueblePagoBE();
                InmueblePago.IdInmueblePago = Int32.Parse(reader["idInmueblePago"].ToString());
                InmueblePago.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                InmueblePago.RazonSocial = reader["RazonSocial"].ToString();
                InmueblePago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                InmueblePago.Mes = Int32.Parse(reader["Mes"].ToString());
                InmueblePago.DescMes = reader["DescMes"].ToString();
                InmueblePago.IdInmueble = Int32.Parse(reader["IdInmueble"].ToString());
                InmueblePago.DescInmueble = reader["DescInmueble"].ToString();
                InmueblePago.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                InmueblePago.DescCliente = reader["DescCliente"].ToString();
                InmueblePago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                //InmueblePago.FechaPago = DateTime.Parse(reader["FechaPago"].ToString());
                InmueblePago.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                InmueblePago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                InmueblePago.Concepto = reader["Concepto"].ToString();
                InmueblePago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                InmueblePago.DescMoneda = reader["DescMoneda"].ToString();
                InmueblePago.Importe = Decimal.Parse(reader["Importe"].ToString());
                InmueblePago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                InmueblePago.Observacion = reader["Observacion"].ToString();
                InmueblePago.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InmueblePagolist.Add(InmueblePago);
            }
            reader.Close();
            reader.Dispose();
            return InmueblePagolist;
        }

        public List<InmueblePagoBE> ListaClienteInmueble(DateTime FechaDesde, DateTime FechaHasta, int IdInmueble, int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmueblePago_ListaClienteInmueble");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdInmueble", DbType.Int32, IdInmueble);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InmueblePagoBE> InmueblePagolist = new List<InmueblePagoBE>();
            InmueblePagoBE InmueblePago;
            while (reader.Read())
            {
                InmueblePago = new InmueblePagoBE();
                InmueblePago.IdInmueblePago = Int32.Parse(reader["idInmueblePago"].ToString());
                //InmueblePago.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                //InmueblePago.RazonSocial = reader["RazonSocial"].ToString();
                InmueblePago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                InmueblePago.Mes = Int32.Parse(reader["Mes"].ToString());
                InmueblePago.DescMes = reader["DescMes"].ToString();
                InmueblePago.IdInmueble = Int32.Parse(reader["IdInmueble"].ToString());
                //InmueblePago.DescInmueble = reader["DescInmueble"].ToString();
                InmueblePago.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                //InmueblePago.DescCliente = reader["DescCliente"].ToString();
                InmueblePago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                //InmueblePago.FechaPago = DateTime.Parse(reader["FechaPago"].ToString());
                InmueblePago.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                InmueblePago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                InmueblePago.Concepto = reader["Concepto"].ToString();
                //InmueblePago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                //InmueblePago.DescMoneda = reader["DescMoneda"].ToString();
                InmueblePago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                InmueblePago.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                InmueblePago.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                InmueblePago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                //InmueblePago.Observacion = reader["Observacion"].ToString();
                //InmueblePago.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InmueblePagolist.Add(InmueblePago);
            }
            reader.Close();
            reader.Dispose();
            return InmueblePagolist;
        }

        public InmueblePagoBE Selecciona(int IdInmueblePago)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmueblePago_Selecciona");
            db.AddInParameter(dbCommand, "pIdInmueblePago", DbType.Int32, IdInmueblePago);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InmueblePagoBE InmueblePago = null;
            while (reader.Read())
            {
                InmueblePago = new InmueblePagoBE();
                InmueblePago.IdInmueblePago = Int32.Parse(reader["idInmueblePago"].ToString());
                InmueblePago.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                InmueblePago.RazonSocial = reader["RazonSocial"].ToString();
                InmueblePago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                InmueblePago.Mes = Int32.Parse(reader["Mes"].ToString());
                InmueblePago.DescMes = reader["DescMes"].ToString();
                InmueblePago.IdInmueble = Int32.Parse(reader["IdInmueble"].ToString());
                InmueblePago.DescInmueble = reader["DescInmueble"].ToString();
                InmueblePago.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                InmueblePago.DescCliente = reader["DescCliente"].ToString();
                InmueblePago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                //InmueblePago.FechaPago = DateTime.Parse(reader["FechaPago"].ToString());
                InmueblePago.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                InmueblePago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                InmueblePago.Concepto = reader["Concepto"].ToString();
                InmueblePago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                InmueblePago.DescMoneda = reader["DescMoneda"].ToString();
                InmueblePago.Importe = Decimal.Parse(reader["Importe"].ToString());
                InmueblePago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                InmueblePago.Observacion = reader["Observacion"].ToString();
                InmueblePago.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return InmueblePago;
        }
    }
}
