using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using ErpPanorama.BusinessEntity;
using System.Text;
using System.Data.Common;
using System.Data;

namespace ErpPanorama.DataLogic
{
  public  class EstadoCuentaProveedorPagoDL
    {
        public EstadoCuentaProveedorPagoDL() { }

        public Int32 Inserta(EstadoCuentaProveedorPagoBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedorPago_Inserta");

            db.AddOutParameter(dbCommand, "pIdEstadoCuentaProveedorPago", DbType.Int32, pItem.IdEstadoCuentaProveedorPago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pUsuarioRegistro", DbType.String, pItem.UsuarioRegistro);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pSaldo", DbType.Decimal, pItem.Saldo);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedor ", DbType.Int32, pItem.IdEstadoCuentaProveedor);
            db.AddInParameter(dbCommand, "pGrupoPago", DbType.String, pItem.GrupoPago);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdEstadoCuentaProveedorPago");

            return Id;
        }

        public void Actualiza(EstadoCuentaProveedorPagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedorPago_Actualiza");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedorPago", DbType.Int32, pItem.IdEstadoCuentaProveedorPago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdCuentaBancoDetalle", DbType.Int32, pItem.IdCuentaBancoDetalle);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pUsuarioRegistro", DbType.String, pItem.UsuarioRegistro);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pSaldo", DbType.Decimal, pItem.Saldo);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedor ", DbType.Int32, pItem.IdEstadoCuentaProveedor);
            db.AddInParameter(dbCommand, "pGrupoPago", DbType.String, pItem.GrupoPago);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaSaldo(int IdEstadoCuentaProveedorPago, decimal Saldo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedorPago_ActualizaSaldo");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedorPago", DbType.Int32, IdEstadoCuentaProveedorPago);
            db.AddInParameter(dbCommand, "pSaldo", DbType.Decimal, Saldo);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EstadoCuentaProveedorPagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedorPago_Elimina");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedorPago", DbType.Int32, pItem.IdEstadoCuentaProveedorPago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<EstadoCuentaProveedorPagoBE> ListaTodosActivo(int IdEmpresa, int IdProveedor, string TipoMovimiento, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedorPago_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaProveedorPagoBE> EstadoCuentaProveedorPagolist = new List<EstadoCuentaProveedorPagoBE>();
            EstadoCuentaProveedorPagoBE EstadoCuentaProveedorPago;
            while (reader.Read())
            {
                EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoBE();
                EstadoCuentaProveedorPago.IdEstadoCuentaProveedorPago = Int32.Parse(reader["IdEstadoCuentaProveedorPago"].ToString());
                EstadoCuentaProveedorPago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaProveedorPago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaProveedorPago.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                EstadoCuentaProveedorPago.DescProveedor = reader["DescProveedor"].ToString();
                EstadoCuentaProveedorPago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaProveedorPago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaProveedorPago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaProveedorPago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaProveedorPago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaProveedorPago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaProveedorPago.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaProveedorPago.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaProveedorPago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaProveedorPago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaProveedorPago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaProveedorPago.IdFacturaCompra = reader.IsDBNull(reader.GetOrdinal("IdFacturaCompra")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdFacturaCompra"));
                EstadoCuentaProveedorPago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaProveedorPago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaProveedorPago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaProveedorPago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaProveedorPago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaProveedorPago.Observacion = reader["Observacion"].ToString();
                EstadoCuentaProveedorPago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaProveedorPago.IdEstadoCuentaProveedor = Int32.Parse(reader["IdEstadoCuentaProveedor"].ToString());
                EstadoCuentaProveedorPago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaProveedorPago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                EstadoCuentaProveedorPagolist.Add(EstadoCuentaProveedorPago);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaProveedorPagolist;
        }

        public List<EstadoCuentaProveedorPagoBE> ListaPagado(int IdEmpresa, int IdProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedorPago_ListaPagado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaProveedorPagoBE> EstadoCuentaProveedorPagolist = new List<EstadoCuentaProveedorPagoBE>();
            EstadoCuentaProveedorPagoBE EstadoCuentaProveedorPago;
            while (reader.Read())
            {
                EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoBE();
                EstadoCuentaProveedorPago.IdEstadoCuentaProveedorPago = Int32.Parse(reader["IdEstadoCuentaProveedorPago"].ToString());
                EstadoCuentaProveedorPago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaProveedorPago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaProveedorPago.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                EstadoCuentaProveedorPago.DescProveedor = reader["DescProveedor"].ToString();
                EstadoCuentaProveedorPago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaProveedorPago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaProveedorPago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaProveedorPago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaProveedorPago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaProveedorPago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaProveedorPago.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaProveedorPago.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaProveedorPago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaProveedorPago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaProveedorPago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaProveedorPago.IdFacturaCompra = reader.IsDBNull(reader.GetOrdinal("IdFacturaCompra")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdFacturaCompra"));
                EstadoCuentaProveedorPago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaProveedorPago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaProveedorPago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaProveedorPago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaProveedorPago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaProveedorPago.Observacion = reader["Observacion"].ToString();
                EstadoCuentaProveedorPago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaProveedorPago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaProveedorPago.IdEstadoCuentaProveedor = Int32.Parse(reader["IdEstadoCuentaProveedor"].ToString());
                EstadoCuentaProveedorPago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaProveedorPago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

                EstadoCuentaProveedorPagolist.Add(EstadoCuentaProveedorPago);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaProveedorPagolist;
        }


        public EstadoCuentaProveedorPagoBE Selecciona(int IdEstadoCuentaProveedorPago)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedorPago_Selecciona");
            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedorPago", DbType.Int32, IdEstadoCuentaProveedorPago);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaProveedorPagoBE EstadoCuentaProveedorPago = null;
            while (reader.Read())
            {
                EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoBE();
                EstadoCuentaProveedorPago.IdEstadoCuentaProveedorPago = Int32.Parse(reader["IdEstadoCuentaProveedorPago"].ToString());
                EstadoCuentaProveedorPago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaProveedorPago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaProveedorPago.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                EstadoCuentaProveedorPago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaProveedorPago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaProveedorPago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaProveedorPago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaProveedorPago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaProveedorPago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaProveedorPago.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaProveedorPago.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaProveedorPago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaProveedorPago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaProveedorPago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaProveedorPago.IdFacturaCompra = reader.IsDBNull(reader.GetOrdinal("IdFacturaCompra")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdFacturaCompra"));
                EstadoCuentaProveedorPago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaProveedorPago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaProveedorPago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaProveedorPago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaProveedorPago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaProveedorPago.Observacion = reader["Observacion"].ToString();
                EstadoCuentaProveedorPago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaProveedorPago.IdEstadoCuentaProveedor = Int32.Parse(reader["IdEstadoCuentaProveedor"].ToString());
                EstadoCuentaProveedorPago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaProveedorPago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaProveedorPago;
        }


        public EstadoCuentaProveedorPagoBE SeleccionaUltimo(int IdProveedor, int IdEstadoCuentaProveedor, string TipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedorPago_Selecciona");
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedor", DbType.Int32, IdEstadoCuentaProveedor);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaProveedorPagoBE EstadoCuentaProveedorPago = null;
            while (reader.Read())
            {
                EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoBE();
                EstadoCuentaProveedorPago.IdEstadoCuentaProveedorPago = Int32.Parse(reader["IdEstadoCuentaProveedorPago"].ToString());
                EstadoCuentaProveedorPago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaProveedorPago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaProveedorPago.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                EstadoCuentaProveedorPago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaProveedorPago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaProveedorPago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaProveedorPago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaProveedorPago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaProveedorPago.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaProveedorPago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaProveedorPago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaProveedorPago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaProveedorPago.IdFacturaCompra = reader.IsDBNull(reader.GetOrdinal("IdFacturaCompra")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdFacturaCompra"));
                EstadoCuentaProveedorPago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaProveedorPago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaProveedorPago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaProveedorPago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaProveedorPago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaProveedorPago.Observacion = reader["Observacion"].ToString();
                EstadoCuentaProveedorPago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaProveedorPago.IdEstadoCuentaProveedor = Int32.Parse(reader["IdEstadoCuentaProveedor"].ToString());
                EstadoCuentaProveedorPago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaProveedorPago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaProveedorPago;
        }

        public Int32 EliminaCompensado(EstadoCuentaProveedorPagoBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedorPago_EliminaCompensado");

            db.AddOutParameter(dbCommand, "pIdEstadoCuentaProveedor", DbType.Int32, pItem.IdEstadoCuentaProveedor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pGrupoPago", DbType.String, pItem.GrupoPago);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
            Id = (int)db.GetParameterValue(dbCommand, "pIdEstadoCuentaProveedor");

            return Id;
        }

        public List<EstadoCuentaProveedorPagoBE> ListaHistorial(int IdEmpresa, int IdEstadoCuentaProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedorPago_ListaHistorial");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedor", DbType.Int32, IdEstadoCuentaProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaProveedorPagoBE> EstadoCuentaProveedorPagolist = new List<EstadoCuentaProveedorPagoBE>();
            EstadoCuentaProveedorPagoBE EstadoCuentaProveedorPago;
            while (reader.Read())
            {
                EstadoCuentaProveedorPago = new EstadoCuentaProveedorPagoBE();
                EstadoCuentaProveedorPago.IdEstadoCuentaProveedorPago = Int32.Parse(reader["IdEstadoCuentaProveedorPago"].ToString());
                EstadoCuentaProveedorPago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaProveedorPago.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaProveedorPago.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                EstadoCuentaProveedorPago.DescProveedor = reader["DescProveedor"].ToString();
                EstadoCuentaProveedorPago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaProveedorPago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaProveedorPago.Concepto = reader["Concepto"].ToString();
                EstadoCuentaProveedorPago.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaProveedorPago.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaProveedorPago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuentaProveedorPago.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaProveedorPago.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaProveedorPago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaProveedorPago.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaProveedorPago.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaProveedorPago.IdFacturaCompra = reader.IsDBNull(reader.GetOrdinal("IdFacturaCompra")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdFacturaCompra"));
                EstadoCuentaProveedorPago.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaProveedorPago.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaProveedorPago.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaProveedorPago.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaProveedorPago.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaProveedorPago.Observacion = reader["Observacion"].ToString();
                EstadoCuentaProveedorPago.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaProveedorPago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaProveedorPago.IdEstadoCuentaProveedor = Int32.Parse(reader["IdEstadoCuentaProveedor"].ToString());
                EstadoCuentaProveedorPago.GrupoPago = reader["GrupoPago"].ToString();
                EstadoCuentaProveedorPago.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

                EstadoCuentaProveedorPagolist.Add(EstadoCuentaProveedorPago);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaProveedorPagolist;
        }
    }
}
