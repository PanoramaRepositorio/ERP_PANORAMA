using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PagosDL
    {
        public PagosDL() { }

        public Int32 Inserta(PagosBE pItem)
        {
            Int32 intIdPago = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_Inserta");

            db.AddOutParameter(dbCommand, "pIdPago", DbType.Int32, pItem.IdPago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdCondicionPago", DbType.Int32, pItem.IdCondicionPago);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pImporteSoles", DbType.Decimal, pItem.ImporteSoles);
            db.AddInParameter(dbCommand, "pImporteDolares", DbType.Decimal, pItem.ImporteDolares);
            db.AddInParameter(dbCommand, "pTipoMovimiento ", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, pItem.IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, pItem.IdSolicitudPrestamo);
            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, pItem.IdHoraExtra);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pCodigoGiftCard", DbType.String, pItem.CodigoGiftCard);

            db.ExecuteNonQuery(dbCommand);
            intIdPago = (int)db.GetParameterValue(dbCommand, "pIdPago");
            return intIdPago;
        }

        public void Actualiza(PagosBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_Actualiza");

            db.AddInParameter(dbCommand, "pIdPago", DbType.Int32, pItem.IdPago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdCondicionPago", DbType.Int32, pItem.IdCondicionPago);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pImporteSoles", DbType.Decimal, pItem.ImporteSoles);
            db.AddInParameter(dbCommand, "pImporteDolares", DbType.Decimal, pItem.ImporteDolares);
            db.AddInParameter(dbCommand, "pTipoMovimiento ", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, pItem.IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, pItem.IdSolicitudPrestamo);
            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, pItem.IdHoraExtra);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PagosBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_Elimina");

            db.AddInParameter(dbCommand, "pIdPago", DbType.Int32, pItem.IdPago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaNotaCredito(string NumeroDocumento, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_ActualizaNotaCredito");

            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaProyectoServicio(int IdPago, int IdDis_ProyectoServicio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_ActualizaProyectoServicio");

            db.AddInParameter(dbCommand, "pIdPago", DbType.Int32, IdPago);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);

            db.ExecuteNonQuery(dbCommand);
        }

        public PagosBE Selecciona(int IdEmpresa, int IdPago)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPago", DbType.Int32, IdPago);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            PagosBE Pago = null;
            while (reader.Read())
            {
                Pago = new PagosBE();
                Pago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pago.IdPago = Int32.Parse(reader["idPago"].ToString());
                Pago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Pago.NumeroPedido = reader["NumeroPedido"].ToString();
                Pago.DescCliente = reader["DescCliente"].ToString();
                Pago.CodMonedaPedido = reader["CodMonedaPedido"].ToString();
                Pago.Total = Decimal.Parse(reader["Total"].ToString());
                Pago.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Pago.DescCaja = reader["DescCaja"].ToString();
                Pago.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pago.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pago.CodTipoDocumento = reader["codTipoDocumento"].ToString();
                Pago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pago.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                Pago.DescCondicionPago = reader["DescCondicionPago"].ToString();
                Pago.Concepto = reader["concepto"].ToString();
                Pago.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pago.CodMoneda = reader["CodMoneda"].ToString();
                Pago.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pago.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                Pago.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                Pago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Pago.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                Pago.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Pago.DescVendedor = reader["DescVendedor"].ToString();
                Pago.IdDis_ProyectoServicio = reader.IsDBNull(reader.GetOrdinal("IdDis_ProyectoServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDis_ProyectoServicio"));
                Pago.NumeroProyectoServicio = reader["NumeroProyectoServicio"].ToString();
                Pago.IdDis_ContratoFabricacion = reader.IsDBNull(reader.GetOrdinal("IdDis_ContratoFabricacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDis_ContratoFabricacion"));
                Pago.NumeroContrato = reader["NumeroContrato"].ToString();
                Pago.IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCliente"));
                Pago.IdSolicitudPrestamo = reader.IsDBNull(reader.GetOrdinal("IdSolicitudPrestamo")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSolicitudPrestamo"));
                Pago.IdHoraExtra = reader.IsDBNull(reader.GetOrdinal("IdHoraExtra")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdHoraExtra"));
                Pago.TipoCliente = reader["TipoCliente"].ToString();
                Pago.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pago;
        }

        public PagosBE SeleccionaHoraExtra(int IdEmpresa, int IdHoraExtra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_SeleccionaHoraExtra");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdHoraExtra", DbType.Int32, IdHoraExtra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PagosBE Pago = null;
            while (reader.Read())
            {
                Pago = new PagosBE();
                Pago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pago.IdPago = Int32.Parse(reader["idPago"].ToString());
                Pago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Pago.NumeroPedido = reader["NumeroPedido"].ToString();
                Pago.DescCliente = reader["DescCliente"].ToString();
                Pago.CodMonedaPedido = reader["CodMonedaPedido"].ToString();
                Pago.Total = Decimal.Parse(reader["Total"].ToString());
                Pago.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Pago.DescCaja = reader["DescCaja"].ToString();
                Pago.DescTienda = reader["DescTienda"].ToString();
                Pago.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pago.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pago.CodTipoDocumento = reader["codTipoDocumento"].ToString();
                Pago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pago.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                Pago.DescCondicionPago = reader["DescCondicionPago"].ToString();
                Pago.Concepto = reader["concepto"].ToString();
                Pago.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pago.CodMoneda = reader["CodMoneda"].ToString();
                Pago.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pago.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                Pago.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                Pago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Pago.IdMovimientoCaja = reader.IsDBNull(reader.GetOrdinal("IdMovimientoCaja")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoCaja"));
                Pago.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Pago.DescVendedor = reader["DescVendedor"].ToString();
                Pago.IdDis_ProyectoServicio = reader.IsDBNull(reader.GetOrdinal("IdDis_ProyectoServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDis_ProyectoServicio"));
                Pago.NumeroProyectoServicio = reader["NumeroProyectoServicio"].ToString();
                Pago.IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCliente"));
                Pago.IdSolicitudPrestamo = reader.IsDBNull(reader.GetOrdinal("IdSolicitudPrestamo")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSolicitudPrestamo"));
                Pago.IdHoraExtra = reader.IsDBNull(reader.GetOrdinal("IdHoraExtra")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdHoraExtra"));
                Pago.TipoCliente = reader["TipoCliente"].ToString();
                Pago.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pago;
        }

        public List<PagosBE> ListaTodosActivo(int IdEmpresa, int IdCaja, DateTime Fecha, DateTime FechaHasta, int IdTipoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PagosBE> Pagolist = new List<PagosBE>();
            PagosBE Pago;
            while (reader.Read())
            {
                Pago = new PagosBE();
                Pago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pago.IdPago = Int32.Parse(reader["idPago"].ToString());
                Pago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Pago.NumeroPedido = reader["NumeroPedido"].ToString();
                Pago.DescCliente = reader["DescCliente"].ToString();
                Pago.CodMonedaPedido = reader["CodMonedaPedido"].ToString();
                Pago.Total = Decimal.Parse(reader["Total"].ToString());
                Pago.DescTienda = reader["DescTienda"].ToString();
                Pago.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Pago.DescCaja = reader["DescCaja"].ToString();
                Pago.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pago.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pago.CodTipoDocumento = reader["codTipoDocumento"].ToString();
                Pago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pago.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                Pago.DescCondicionPago = reader["DescCondicionPago"].ToString();
                Pago.Concepto = reader["concepto"].ToString();
                Pago.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pago.CodMoneda = reader["CodMoneda"].ToString();
                Pago.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pago.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                Pago.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                Pago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Pago.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Pago.DescVendedor = reader["DescVendedor"].ToString();
                Pago.IdDis_ProyectoServicio = reader.IsDBNull(reader.GetOrdinal("IdDis_ProyectoServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDis_ProyectoServicio"));
                Pago.NumeroProyectoServicio = reader["NumeroProyectoServicio"].ToString();
                Pago.IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCliente"));
                Pago.TipoCliente = reader["TipoCliente"].ToString();
                Pago.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pago.CodigoGiftCard = reader["CodigoGiftCard"].ToString();

                Pagolist.Add(Pago);
            }
            reader.Close();
            reader.Dispose();
            return Pagolist;
        }

        public List<PagosBE> ListaAsesoria(int IdEmpresa, int IdDis_ProyectoServicio,int IdDis_ContratoFabricacion, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_ListaAsesoria");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PagosBE> Pagolist = new List<PagosBE>();
            PagosBE Pago;
            while (reader.Read())
            {
                Pago = new PagosBE();
                Pago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pago.IdPago = Int32.Parse(reader["idPago"].ToString());
                Pago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Pago.NumeroPedido = reader["NumeroPedido"].ToString();
                Pago.DescCliente = reader["DescCliente"].ToString();
                Pago.CodMonedaPedido = reader["CodMonedaPedido"].ToString();
                Pago.Total = Decimal.Parse(reader["Total"].ToString());
                Pago.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Pago.DescCaja = reader["DescCaja"].ToString();
                Pago.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pago.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pago.CodTipoDocumento = reader["codTipoDocumento"].ToString();
                Pago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pago.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                Pago.DescCondicionPago = reader["DescCondicionPago"].ToString();
                Pago.Concepto = reader["concepto"].ToString();
                Pago.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pago.CodMoneda = reader["CodMoneda"].ToString();
                Pago.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pago.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                Pago.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                Pago.TipoMovimiento = reader["TipoMovimiento"].ToString();
                Pago.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Pago.DescVendedor = reader["DescVendedor"].ToString();
                Pago.IdDis_ProyectoServicio = reader.IsDBNull(reader.GetOrdinal("IdDis_ProyectoServicio")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDis_ProyectoServicio"));
                Pago.NumeroProyectoServicio = reader["NumeroProyectoServicio"].ToString();
                Pago.IdDis_ContratoFabricacion = reader.IsDBNull(reader.GetOrdinal("IdDis_ContratoFabricacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDis_ContratoFabricacion"));
                Pago.NumeroContrato = reader["NumeroContrato"].ToString();
                Pago.IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCliente"));
                Pago.TipoCliente = reader["TipoCliente"].ToString();
                Pago.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pagolist.Add(Pago);
            }
            reader.Close();
            reader.Dispose();
            return Pagolist;
        }



        public PagosBE SeleccionaNumero(int IdEmpresa, int IdTipoDocumento, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_SeleccionaNumero");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PagosBE Pago = null;
            while (reader.Read())
            {
                Pago = new PagosBE();
                Pago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pago.IdPago = Int32.Parse(reader["idPago"].ToString());
                Pago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Pago.NumeroPedido = reader["NumeroPedido"].ToString();
                Pago.DescCliente = reader["DescCliente"].ToString();
                Pago.CodMonedaPedido = reader["CodMonedaPedido"].ToString();
                Pago.Total = Decimal.Parse(reader["Total"].ToString());
                Pago.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Pago.DescCaja = reader["DescCaja"].ToString();
                Pago.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pago.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pago.CodTipoDocumento = reader["codTipoDocumento"].ToString();
                Pago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pago.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                Pago.DescCondicionPago = reader["DescCondicionPago"].ToString();
                Pago.Concepto = reader["concepto"].ToString();
                Pago.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pago.CodMoneda = reader["CodMoneda"].ToString();
                Pago.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pago.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                Pago.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                Pago.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pago;
        }

        public List<PagosBE> ListaNotaCredito(int IdEmpresa, int IdCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_ListaNotaCredito");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PagosBE> Pagolist = new List<PagosBE>();
            PagosBE Pago;
            while (reader.Read())
            {
                Pago = new PagosBE();
                Pago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pago.IdPago = Int32.Parse(reader["idPago"].ToString());
                Pago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Pago.NumeroPedido = reader["NumeroPedido"].ToString();
                Pago.DescCliente = reader["DescCliente"].ToString();
                Pago.CodMonedaPedido = reader["CodMonedaPedido"].ToString();
                Pago.Total = Decimal.Parse(reader["Total"].ToString());
                Pago.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Pago.DescCaja = reader["DescCaja"].ToString();
                Pago.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pago.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pago.CodTipoDocumento = reader["codTipoDocumento"].ToString();
                Pago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pago.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                Pago.DescCondicionPago = reader["DescCondicionPago"].ToString();
                Pago.Concepto = reader["concepto"].ToString();
                Pago.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pago.CodMoneda = reader["CodMoneda"].ToString();
                Pago.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pago.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                Pago.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                Pago.CodTipoDocumentoAntecesor = reader["CodTipoDocumentoAntecesor"].ToString();
                Pago.NumeroAntecesor = reader["NumeroAntecesor"].ToString();
                Pago.CodTipoDocumentoPredecesor = reader["CodTipoDocumentoPredecesor"].ToString();
                Pago.NumeroPredecesor = reader["NumeroPredecesor"].ToString();
                Pago.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Pagolist.Add(Pago);
            }
            reader.Close();
            reader.Dispose();
            return Pagolist;
        }

        public PagosBE SeleccionaNotaCredito(int IdEmpresa, int IdTipoDocumento, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pagos_SeleccionaNotaCredito");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PagosBE Pago = null;
            while (reader.Read())
            {
                Pago = new PagosBE();
                Pago.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Pago.IdPago = Int32.Parse(reader["idPago"].ToString());
                Pago.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Pago.NumeroPedido = reader["NumeroPedido"].ToString();
                Pago.DescCliente = reader["DescCliente"].ToString();
                Pago.CodMonedaPedido = reader["CodMonedaPedido"].ToString();
                Pago.Total = Decimal.Parse(reader["Total"].ToString());
                Pago.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                Pago.DescCaja = reader["DescCaja"].ToString();
                Pago.Fecha = DateTime.Parse(reader["fecha"].ToString());
                Pago.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Pago.CodTipoDocumento = reader["codTipoDocumento"].ToString();
                Pago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Pago.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                Pago.DescCondicionPago = reader["DescCondicionPago"].ToString();
                Pago.Concepto = reader["concepto"].ToString();
                Pago.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                Pago.CodMoneda = reader["CodMoneda"].ToString();
                Pago.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                Pago.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                Pago.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                Pago.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Pago;
        }
    }
}
