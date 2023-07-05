using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class SolicitudCompraDL
    {
        public SolicitudCompraDL() { }

        public Int32 Inserta(SolicitudCompraBE pItem)
        {
            Int32 intIdSolicitudCompra = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompra_Inserta");

            db.AddOutParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, pItem.IdSolicitudCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pFechaCompra", DbType.DateTime, pItem.FechaCompra);
            db.AddInParameter(dbCommand, "pFechaEmbarque", DbType.DateTime, pItem.FechaEmbarque);
            db.AddInParameter(dbCommand, "pFechaRecepcion", DbType.DateTime, pItem.FechaRecepcion);
            db.AddInParameter(dbCommand, "pTipoRegistro", DbType.String, pItem.TipoRegistro);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pItems", DbType.Int32, pItem.Items);
            db.AddInParameter(dbCommand, "pDiasCredito", DbType.Int32, pItem.DiasCredito);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);

            intIdSolicitudCompra = (int)db.GetParameterValue(dbCommand, "pIdSolicitudCompra");

            return intIdSolicitudCompra;
        }

        public void Actualiza(SolicitudCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompra_Actualiza");

            db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, pItem.IdSolicitudCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pFechaCompra", DbType.DateTime, pItem.FechaCompra);
            db.AddInParameter(dbCommand, "pFechaEmbarque", DbType.DateTime, pItem.FechaEmbarque);
            db.AddInParameter(dbCommand, "pFechaRecepcion", DbType.DateTime, pItem.FechaRecepcion);
            db.AddInParameter(dbCommand, "pTipoRegistro", DbType.String, pItem.TipoRegistro);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pItems", DbType.Int32, pItem.Items);
            db.AddInParameter(dbCommand, "pDiasCredito", DbType.Int32, pItem.DiasCredito);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(SolicitudCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompra_Elimina");

            db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, pItem.IdSolicitudCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaFechaRecepcion(SolicitudCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompra_ActualizaFechaRecepcion");

            db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, pItem.IdSolicitudCompra);
            db.AddInParameter(dbCommand, "pFechaRecepcion", DbType.DateTime, pItem.FechaRecepcion);

            db.ExecuteNonQuery(dbCommand);
        }

        public SolicitudCompraBE Selecciona(int IdEmpresa, int IdSolicitudCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompra_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, IdSolicitudCompra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudCompraBE SolicitudCompra = null;
            while (reader.Read())
            {
                SolicitudCompra = new SolicitudCompraBE();
                SolicitudCompra.IdSolicitudCompra = Int32.Parse(reader["idSolicitudCompra"].ToString());
                SolicitudCompra.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                SolicitudCompra.Periodo = Int32.Parse(reader["periodo"].ToString());
                SolicitudCompra.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudCompra.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                SolicitudCompra.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                SolicitudCompra.DescProveedor = reader["DescProveedor"].ToString();
                SolicitudCompra.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                SolicitudCompra.FormaPago = reader["FormaPago"].ToString();
                SolicitudCompra.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                SolicitudCompra.FechaEmbarque = reader.IsDBNull(reader.GetOrdinal("FechaEmbarque")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmbarque"));
                SolicitudCompra.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                SolicitudCompra.TipoRegistro = reader["tiporegistro"].ToString();
                SolicitudCompra.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudCompra.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                SolicitudCompra.Moneda = reader["Moneda"].ToString();
                SolicitudCompra.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                SolicitudCompra.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudCompra.DiasCredito = Int32.Parse(reader["DiasCredito"].ToString());
                SolicitudCompra.Observacion = reader["Observacion"].ToString();
                SolicitudCompra.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                SolicitudCompra.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                SolicitudCompra.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudCompra;
        }

        public SolicitudCompraBE SeleccionaNumero(int IdProveedor, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompra_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudCompraBE SolicitudCompra = null;
            while (reader.Read())
            {
                SolicitudCompra = new SolicitudCompraBE();
                SolicitudCompra.IdSolicitudCompra = Int32.Parse(reader["idSolicitudCompra"].ToString());
                SolicitudCompra.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                SolicitudCompra.Periodo = Int32.Parse(reader["periodo"].ToString());
                SolicitudCompra.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudCompra.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                SolicitudCompra.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                SolicitudCompra.DescProveedor = reader["DescProveedor"].ToString();
                SolicitudCompra.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                SolicitudCompra.FormaPago = reader["FormaPago"].ToString();
                SolicitudCompra.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                SolicitudCompra.FechaEmbarque = reader.IsDBNull(reader.GetOrdinal("FechaEmbarque")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmbarque"));
                SolicitudCompra.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                SolicitudCompra.TipoRegistro = reader["tiporegistro"].ToString();
                SolicitudCompra.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudCompra.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                SolicitudCompra.Moneda = reader["Moneda"].ToString();
                SolicitudCompra.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                SolicitudCompra.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudCompra.DiasCredito = Int32.Parse(reader["DiasCredito"].ToString());
                SolicitudCompra.Observacion = reader["Observacion"].ToString();
                SolicitudCompra.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                SolicitudCompra.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                SolicitudCompra.NumeroFactura = reader["NumeroFactura"].ToString();
                SolicitudCompra.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudCompra;
        }

        public List<SolicitudCompraBE> ListaTodosActivo(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompra_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudCompraBE> SolicitudCompralist = new List<SolicitudCompraBE>();
            SolicitudCompraBE SolicitudCompra;
            while (reader.Read())
            {
                SolicitudCompra = new SolicitudCompraBE();
                SolicitudCompra.IdSolicitudCompra = Int32.Parse(reader["idSolicitudCompra"].ToString());
                SolicitudCompra.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                SolicitudCompra.Periodo = Int32.Parse(reader["periodo"].ToString());
                SolicitudCompra.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                SolicitudCompra.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                SolicitudCompra.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                SolicitudCompra.DescProveedor = reader["DescProveedor"].ToString();
                SolicitudCompra.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                SolicitudCompra.FormaPago = reader["FormaPago"].ToString();
                SolicitudCompra.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                SolicitudCompra.FechaEmbarque = reader.IsDBNull(reader.GetOrdinal("FechaEmbarque")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmbarque"));
                SolicitudCompra.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                SolicitudCompra.TipoRegistro = reader["tiporegistro"].ToString();
                SolicitudCompra.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudCompra.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                SolicitudCompra.Moneda = reader["Moneda"].ToString();
                SolicitudCompra.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                SolicitudCompra.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudCompra.Items = Int32.Parse(reader["Items"].ToString());
                SolicitudCompra.DiasCredito = Int32.Parse(reader["DiasCredito"].ToString());
                SolicitudCompra.Observacion = reader["Observacion"].ToString();
                SolicitudCompra.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                SolicitudCompra.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                SolicitudCompra.NumeroFactura = reader["NumeroFactura"].ToString();
                SolicitudCompra.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudCompralist.Add(SolicitudCompra);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudCompralist;
        }

        public List<SolicitudCompraBE> ListaProveedor(int IdEmpresa, int IdProveedor, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudCompra_ListaProveedor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudCompraBE> SolicitudCompralist = new List<SolicitudCompraBE>();
            SolicitudCompraBE SolicitudCompra;
            while (reader.Read())
            {
                SolicitudCompra = new SolicitudCompraBE();
                SolicitudCompra.IdSolicitudCompra = Int32.Parse(reader["idSolicitudCompra"].ToString());
                SolicitudCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                SolicitudCompralist.Add(SolicitudCompra);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudCompralist;
        }

    }
}
