using ErpPanorama.BusinessEntity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace ErpPanorama.DataLogic
{
   
    public class EstadoCuentaProveedorDL
    {

        public EstadoCuentaProveedorDL(){}
        public void Inserta(EstadoCuentaProveedorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedor_Inserta");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedor", DbType.Int32, pItem.IdEstadoCuentaProveedor);
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
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.UsuarioRegistro);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(EstadoCuentaProveedorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedor_Actualiza");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedor", DbType.Int32, pItem.IdEstadoCuentaProveedor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMotivo);
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
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EstadoCuentaProveedorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedor_Elimina");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedor", DbType.Int32, pItem.IdEstadoCuentaProveedor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        //public void EliminaDocumento(int IdEmpresa, int Periodo, int IdCliente, string NumeroDocumento)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_Elimina");

        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
        //    db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
        //    db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
        //    db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public void EliminaDocumentoVenta(int IdDocumentoVenta)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_EliminaDocumentoVenta");

        //    db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public void EliminaCotizacion(int IdCotizacion)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_EliminaCotizacion");

        //    db.AddInParameter(dbCommand, "pIdCotizacion", DbType.Int32, IdCotizacion);
        //    db.ExecuteNonQuery(dbCommand);
        //}

        public List<EstadoCuentaProveedorBE> ListaTodosActivo(int IdEmpresa, int IdProveedor,string TipoMovimiento, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String,TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaProveedorBE> EstadoCuentaProveedorlist = new List<EstadoCuentaProveedorBE>();
            EstadoCuentaProveedorBE EstadoCuenta;
            while (reader.Read())
            {
                EstadoCuenta = new EstadoCuentaProveedorBE();
                EstadoCuenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuenta.IdEstadoCuentaProveedor = Int32.Parse(reader["IdEstadoCuentaProveedor"].ToString());
                EstadoCuenta.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                EstadoCuenta.DescProveedor = reader["DescProveedor"].ToString();
                EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuenta.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuenta.Concepto = reader["Concepto"].ToString();
                EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuenta.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuenta.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                EstadoCuenta.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuenta.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuenta.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuenta.IdFacturaCompra = reader.IsDBNull(reader.GetOrdinal("IdFacturaCompra")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdFacturaCompra"));
                EstadoCuenta.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuenta.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuenta.DescPersona = reader["DescPersona"].ToString();
                EstadoCuenta.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuenta.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuenta.Observacion=reader["Observacion"].ToString();
                EstadoCuenta.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                //EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

                EstadoCuentaProveedorlist.Add(EstadoCuenta);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaProveedorlist;
        }

        public EstadoCuentaProveedorBE Selecciona(int IdEmpresa, int IdEstadoCuentaProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedor_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedor", DbType.Int32, IdEstadoCuentaProveedor);

                IDataReader reader = db.ExecuteReader(dbCommand);
            EstadoCuentaProveedorBE EstadoCuentaProveedor = null;
            while (reader.Read())
            {
                EstadoCuentaProveedor = new EstadoCuentaProveedorBE();
                EstadoCuentaProveedor.IdEstadoCuentaProveedor = Int32.Parse(reader["IdEstadoCuentaProveedor"].ToString());
                EstadoCuentaProveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaProveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaProveedor.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaProveedor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                EstadoCuentaProveedor.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaProveedor.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                EstadoCuentaProveedor.Concepto = reader["Concepto"].ToString();
                EstadoCuentaProveedor.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaProveedor.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                EstadoCuentaProveedor.DescMoneda = reader["DescMoneda"].ToString();
                EstadoCuentaProveedor.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaProveedor.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaProveedor.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaProveedor.DescMotivo = reader["DescMotivo"].ToString();
                EstadoCuentaProveedor.IdCuentaBancoDetalle = reader.IsDBNull(reader.GetOrdinal("IdCuentaBancoDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdCuentaBancoDetalle"));
                EstadoCuentaProveedor.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                EstadoCuentaProveedor.DescPersona = reader["DescPersona"].ToString();
                EstadoCuentaProveedor.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                EstadoCuentaProveedor.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                EstadoCuentaProveedor.Observacion = reader["Observacion"].ToString();
                EstadoCuentaProveedor.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                EstadoCuentaProveedor.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentaProveedor;
        }

        //public EstadoCuentaBE SeleccionaNumeroDocumento(int Periodo, string NumeroDocumento)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_SeleccionaNumeroDocumento");
        //    db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
        //    db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    EstadoCuentaBE EstadoCuenta = null;
        //    while (reader.Read())
        //    {
        //        EstadoCuenta = new EstadoCuentaBE();
        //        EstadoCuenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
        //        EstadoCuenta.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
        //        EstadoCuenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
        //        EstadoCuenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
        //        EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
        //        EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
        //        EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
        //        EstadoCuenta.Concepto = reader["Concepto"].ToString();
        //        EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
        //        EstadoCuenta.Importe = Decimal.Parse(reader["Importe"].ToString());
        //        EstadoCuenta.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
        //        EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
        //        EstadoCuenta.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
        //        EstadoCuenta.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
        //        EstadoCuenta.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
        //        EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
        //        EstadoCuenta.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
        //        EstadoCuenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return EstadoCuenta;
        //}

        //public EstadoCuentaBE SeleccionaMovimientoCaja(int? IdMovimientoCaja)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuenta_SeleccionaMovimientoCaja");
        //    db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, IdMovimientoCaja);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    EstadoCuentaBE EstadoCuenta = null;
        //    while (reader.Read())
        //    {
        //        EstadoCuenta = new EstadoCuentaBE();
        //        EstadoCuenta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
        //        EstadoCuenta.IdEstadoCuenta = Int32.Parse(reader["IdEstadoCuenta"].ToString());
        //        EstadoCuenta.Periodo = Int32.Parse(reader["Periodo"].ToString());
        //        EstadoCuenta.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
        //        EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
        //        EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
        //        EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
        //        EstadoCuenta.Concepto = reader["Concepto"].ToString();
        //        EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
        //        EstadoCuenta.Importe = Decimal.Parse(reader["Importe"].ToString());
        //        EstadoCuenta.ImporteAnt = Decimal.Parse(reader["Importe"].ToString());
        //        EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
        //        EstadoCuenta.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
        //        EstadoCuenta.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
        //        EstadoCuenta.IdCotizacion = reader.IsDBNull(reader.GetOrdinal("IdCotizacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCotizacion"));
        //        EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
        //        EstadoCuenta.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
        //        EstadoCuenta.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return EstadoCuenta;
        //}

        public List<EstadoCuentaProveedorBE> ListaProveedor(DateTime FechaDesde, DateTime FechaHasta, int IdProveedor )
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedor_ListaProveedor");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            //db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaProveedorBE> EstadoCuentalist = new List<EstadoCuentaProveedorBE>();
            EstadoCuentaProveedorBE EstadoCuenta;
            while (reader.Read())
            {
                EstadoCuenta = new EstadoCuentaProveedorBE();
                EstadoCuenta.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                EstadoCuenta.IdFacturaCompra= Int32.Parse(reader["IdFacturaCompra"].ToString());
                EstadoCuenta.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuenta.FechaCredito = DateTime.Parse(reader["FechaCredito"].ToString());
                //EstadoCuenta.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuenta.Concepto = reader["Concepto"].ToString();
                EstadoCuenta.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuenta.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuenta.CreditoCargo = Decimal.Parse(reader["CreditoCargo"].ToString());
                EstadoCuenta.PagoAbono = Decimal.Parse(reader["PagoAbono"].ToString());
                EstadoCuenta.Saldo = Decimal.Parse(reader["Saldo"].ToString());
               // EstadoCuenta.Usuario = reader["Usuario"].ToString();
              //  EstadoCuenta.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                //EstadoCuenta.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
              //  EstadoCuenta.Origen = reader["Origen"].ToString();
              //  EstadoCuenta.FlagAuditado = Boolean.Parse(reader["FlagAuditado"].ToString());
                EstadoCuentalist.Add(EstadoCuenta);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentalist;
        }

        public List<EstadoCuentaProveedorBE> ListaFacturaCompra(int IdEmpresa, int IdFacturaCompra, string TipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedor_ListaFacturaCompra");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, TipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EstadoCuentaProveedorBE> EstadoCuentalist = new List<EstadoCuentaProveedorBE>();
            EstadoCuentaProveedorBE EstadoCuentaProveedor;
            while (reader.Read())
            {
                EstadoCuentaProveedor = new EstadoCuentaProveedorBE();
                EstadoCuentaProveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                EstadoCuentaProveedor.IdEstadoCuentaProveedor = Int32.Parse(reader["IdEstadoCuentaProveedor"].ToString());
                EstadoCuentaProveedor.Periodo = Int32.Parse(reader["Periodo"].ToString());
                EstadoCuentaProveedor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                EstadoCuentaProveedor.NumeroDocumento = reader["NumeroDocumento"].ToString();
                EstadoCuentaProveedor.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //EstadoCuentaProveedor.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                EstadoCuentaProveedor.Concepto = reader["Concepto"].ToString();
                EstadoCuentaProveedor.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                EstadoCuentaProveedor.Importe = Decimal.Parse(reader["Importe"].ToString());
                EstadoCuentaProveedor.TipoMovimiento = reader["TipoMovimiento"].ToString();
                EstadoCuentaProveedor.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                EstadoCuentaProveedor.IdFacturaCompra = reader.IsDBNull(reader.GetOrdinal("IdFacturaCompra")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdFacturaCompra"));
                EstadoCuentaProveedor.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                EstadoCuentalist.Add(EstadoCuentaProveedor);
            }
            reader.Close();
            reader.Dispose();
            return EstadoCuentalist;
        }

        public void ActualizaSaldo(int IdEstadoCuentaProveedor, decimal Saldo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EstadoCuentaProveedor_ActualizaSaldo");

            db.AddInParameter(dbCommand, "pIdEstadoCuentaProveedor", DbType.Int32, IdEstadoCuentaProveedor);
            db.AddInParameter(dbCommand, "pSaldo", DbType.Decimal, Saldo);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}
