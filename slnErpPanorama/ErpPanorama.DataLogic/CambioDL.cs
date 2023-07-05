using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CambioDL
    {
        public CambioDL() { }

        public Int32 Inserta(CambioBE pItem)
        {
            Int32 intIdCambio = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_Inserta");

            db.AddOutParameter(dbCommand, "pIdCambio", DbType.Int32, pItem.IdCambio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdTipoCambio", DbType.Int32, pItem.IdTipoCambio);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pNumeroPedido", DbType.String, pItem.NumeroPedido);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdTipoDocumentoVenta", DbType.Int32, pItem.IdTipoDocumentoVenta);
            db.AddInParameter(dbCommand, "pSerieDocumentoVenta", DbType.String, pItem.SerieDocumentoVenta);
            db.AddInParameter(dbCommand, "pNumeroDocumentoVenta", DbType.String, pItem.NumeroDocumentoVenta);
            db.AddInParameter(dbCommand, "pFechaVenta", DbType.DateTime, pItem.FechaVenta);
            db.AddInParameter(dbCommand, "pCodMoneda", DbType.String, pItem.CodMoneda);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroCliente", DbType.String, pItem.NumeroCliente);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pIdSupervisor", DbType.Int32, pItem.IdSupervisor);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagAprobado", DbType.Boolean, pItem.FlagAprobado);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
            db.AddInParameter(dbCommand, "pIdTipoAplicacion", DbType.Int32, pItem.IdTipoAplicacion);
            db.AddInParameter(dbCommand, "pFlagReajuste", DbType.Boolean, pItem.FlagReajuste);
            db.AddInParameter(dbCommand, "pCodigoNC", DbType.String, pItem.CodigoNC);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);

            intIdCambio = (int)db.GetParameterValue(dbCommand, "pIdCambio");

            return intIdCambio;

        }

        public void Actualiza(CambioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_Actualiza");

            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, pItem.IdCambio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdTipoCambio", DbType.Int32, pItem.IdTipoCambio);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pNumeroPedido", DbType.String, pItem.NumeroPedido);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdTipoDocumentoVenta", DbType.Int32, pItem.IdTipoDocumentoVenta);
            db.AddInParameter(dbCommand, "pSerieDocumentoVenta", DbType.String, pItem.SerieDocumentoVenta);
            db.AddInParameter(dbCommand, "pNumeroDocumentoVenta", DbType.String, pItem.NumeroDocumentoVenta);
            db.AddInParameter(dbCommand, "pFechaVenta", DbType.DateTime, pItem.FechaVenta);
            db.AddInParameter(dbCommand, "pCodMoneda", DbType.String, pItem.CodMoneda);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroCliente", DbType.String, pItem.NumeroCliente);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pIdSupervisor", DbType.Int32, pItem.IdSupervisor);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagAprobado", DbType.Boolean, pItem.FlagAprobado);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
            db.AddInParameter(dbCommand, "pIdTipoAplicacion", DbType.Int32, pItem.IdTipoAplicacion);
            db.AddInParameter(dbCommand, "pFlagReajuste", DbType.Boolean, pItem.FlagReajuste);
            db.AddInParameter(dbCommand, "pCodigoNC", DbType.String, pItem.CodigoNC);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCliente(int IdCambio, int IdCliente, string NumeroCliente, string DescCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_ActualizaCliente");

            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, IdCambio);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);
            db.AddInParameter(dbCommand, "pNumeroCliente", DbType.String, NumeroCliente);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, DescCliente);
            

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaRecibido(int IdEmpresa, int IdCambio, bool FlagRecibido, int IdPersonaRecibido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_ActualizaRecibido");

            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, IdCambio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, FlagRecibido);
            db.AddInParameter(dbCommand, "pIdPersonaRecibido", DbType.Int32, IdPersonaRecibido);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaAprobado(int IdEmpresa, int IdCambio, bool FlagAprobado, int IdPersonaAprobado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_ActualizaAprobado");

            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, IdCambio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFlagAprobado", DbType.Boolean, FlagAprobado);
            db.AddInParameter(dbCommand, "pIdPersonaAprobado", DbType.Int32, IdPersonaAprobado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaNotaCredito(int IdEmpresa, int IdCambio,int IdDocumentoVenta, string NumeroNotaCredito)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_ActualizaNotaCredito");

            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, IdCambio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pNumeroNotaCredito", DbType.String, NumeroNotaCredito);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CambioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_Elimina");

            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, pItem.IdCambio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CambioBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes, int pIdTipoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pIdTipoDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CambioBE> Cambiolist = new List<CambioBE>();
            CambioBE Cambio;
            while (reader.Read())
            {
                Cambio = new CambioBE();
                Cambio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Cambio.RazonSocial = reader["RazonSocial"].ToString();
                Cambio.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Cambio.IdCambio = Int32.Parse(reader["idCambio"].ToString());
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cambio.IdTipoCambio = Int32.Parse(reader["IdTipoCambio"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.IdTipoDocumentoVenta = Int32.Parse(reader["IdTipoDocumentoVenta"].ToString());
                Cambio.SerieDocumentoVenta = reader["SerieDocumentoVenta"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.IdSupervisor = Int32.Parse(reader["IdSupervisor"].ToString());
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Cambio.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                Cambio.NumeroNotaCredito = reader["NumeroNotaCredito"].ToString();
                Cambio.DescTipoAplicacion = reader["DescTipoAplicacion"].ToString();
                Cambio.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Cambio.Usuario = reader["Usuario"].ToString();
                Cambio.FlagReajuste = Boolean.Parse(reader["FlagReajuste"].ToString());
                Cambio.CodigoNC = reader["CodigoNC"].ToString();
                Cambio.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Cambio.Motivo = reader["Motivo"].ToString();
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cambiolist.Add(Cambio);
            }
            reader.Close();
            reader.Dispose();
            return Cambiolist;
        }

        public List<CambioBE> ListaTodosActivoConsignacion(int IdEmpresa, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_ListaTodosActivoConsignacion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CambioBE> Cambiolist = new List<CambioBE>();
            CambioBE Cambio;
            while (reader.Read())
            {
                Cambio = new CambioBE();
                Cambio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Cambio.RazonSocial = reader["RazonSocial"].ToString();
                Cambio.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Cambio.IdCambio = Int32.Parse(reader["idCambio"].ToString());
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cambio.IdTipoCambio = Int32.Parse(reader["IdTipoCambio"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.IdTipoDocumentoVenta = Int32.Parse(reader["IdTipoDocumentoVenta"].ToString());
                Cambio.SerieDocumentoVenta = reader["SerieDocumentoVenta"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.IdSupervisor = Int32.Parse(reader["IdSupervisor"].ToString());
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Cambio.UsuarioAprobado = reader["UsuarioAprobado"].ToString();
                Cambio.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                Cambio.UsuarioRecibido = reader["UsuarioRecibido"].ToString();
                Cambio.NumeroNotaCredito = reader["NumeroNotaCredito"].ToString();
                Cambio.CodigoNC = reader["CodigoNC"].ToString();
                Cambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cambiolist.Add(Cambio);
            }
            reader.Close();
            reader.Dispose();
            return Cambiolist;
        }

        public List<CambioBE> ListaTodosActivoReparacion(int IdEmpresa, int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_ListaTodosActivoReparacion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CambioBE> Cambiolist = new List<CambioBE>();
            CambioBE Cambio;
            while (reader.Read())
            {
                Cambio = new CambioBE();
                Cambio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Cambio.RazonSocial = reader["RazonSocial"].ToString();
                Cambio.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Cambio.IdCambio = Int32.Parse(reader["idCambio"].ToString());
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cambio.IdTipoCambio = Int32.Parse(reader["IdTipoCambio"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.IdTipoDocumentoVenta = Int32.Parse(reader["IdTipoDocumentoVenta"].ToString());
                Cambio.SerieDocumentoVenta = reader["SerieDocumentoVenta"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.IdSupervisor = Int32.Parse(reader["IdSupervisor"].ToString());
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Cambio.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                Cambio.NumeroNotaCredito = reader["NumeroNotaCredito"].ToString();
                Cambio.CodigoNC = reader["CodigoNC"].ToString();
                Cambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cambiolist.Add(Cambio);
            }
            reader.Close();
            reader.Dispose();
            return Cambiolist;
        }

        public List<CambioBE> Lista(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_Lista");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CambioBE> Cambiolist = new List<CambioBE>();
            CambioBE Cambio;
            while (reader.Read())
            {
                Cambio = new CambioBE();
                Cambio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Cambio.RazonSocial = reader["RazonSocial"].ToString();
                Cambio.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Cambio.IdCambio = Int32.Parse(reader["idCambio"].ToString());
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cambio.IdTipoCambio = Int32.Parse(reader["IdTipoCambio"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.IdTipoDocumentoVenta = Int32.Parse(reader["IdTipoDocumentoVenta"].ToString());
                Cambio.SerieDocumentoVenta = reader["SerieDocumentoVenta"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.IdSupervisor = Int32.Parse(reader["IdSupervisor"].ToString());
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Cambio.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                Cambio.NumeroNotaCredito = reader["NumeroNotaCredito"].ToString();
                Cambio.DescTipoAplicacion = reader["DescTipoAplicacion"].ToString();
                Cambio.CodigoNC = reader["CodigoNC"].ToString();
                Cambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cambiolist.Add(Cambio);
            }
            reader.Close();
            reader.Dispose();
            return Cambiolist;
        }

        public CambioBE Selecciona(int IdEmpresa, int IdCambio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCambio", DbType.Int32, IdCambio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CambioBE Cambio = null;
            while (reader.Read())
            {
                Cambio = new CambioBE();
                Cambio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Cambio.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Cambio.IdCambio = Int32.Parse(reader["idCambio"].ToString());
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cambio.IdTipoCambio = Int32.Parse(reader["IdTipoCambio"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                Cambio.IdTipoDocumentoVenta = Int32.Parse(reader["IdTipoDocumentoVenta"].ToString());
                Cambio.SerieDocumentoVenta = reader["SerieDocumentoVenta"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.IdSupervisor = Int32.Parse(reader["IdSupervisor"].ToString());
                Cambio.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Cambio.UsuarioAprobado = reader["UsuarioAprobado"].ToString();
                Cambio.FechaAprobado = reader.IsDBNull(reader.GetOrdinal("FechaAprobado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAprobado"));
                Cambio.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                Cambio.UsuarioRecibido = reader["UsuarioRecibido"].ToString();
                Cambio.FechaRecibido = reader.IsDBNull(reader.GetOrdinal("FechaRecibido")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecibido"));
                Cambio.IdTipoAplicacion = reader.IsDBNull(reader.GetOrdinal("IdTipoAplicacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoAplicacion"));
                Cambio.IdDocumentoVentaNcv = Int32.Parse(reader["IdDocumentoVentaNcv"].ToString());
                Cambio.CodigoNC = reader["CodigoNC"].ToString();
                Cambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                
            }
            reader.Close();
            reader.Dispose();
            return Cambio;
        }

        public CambioBE SeleccionaNotaCredito(int IdDocumentoVentaNcv)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_SeleccionaIdDocumentoVentaNcv");
            db.AddInParameter(dbCommand, "pIdDocumentoVentaNcv", DbType.Int32, IdDocumentoVentaNcv);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CambioBE Cambio = null;
            while (reader.Read())
            {
                Cambio = new CambioBE();
                Cambio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Cambio.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Cambio.IdCambio = Int32.Parse(reader["idCambio"].ToString());
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cambio.IdTipoCambio = Int32.Parse(reader["IdTipoCambio"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                Cambio.IdTipoDocumentoVenta = Int32.Parse(reader["IdTipoDocumentoVenta"].ToString());
                Cambio.SerieDocumentoVenta = reader["SerieDocumentoVenta"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.IdSupervisor = Int32.Parse(reader["IdSupervisor"].ToString());
                Cambio.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Cambio.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                Cambio.IdTipoAplicacion = reader.IsDBNull(reader.GetOrdinal("IdTipoAplicacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoAplicacion"));
                Cambio.IdDocumentoVentaNcv = Int32.Parse(reader["IdDocumentoVentaNcv"].ToString());
                Cambio.CodigoNC = reader["CodigoNC"].ToString();
                Cambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Cambio;
        }

        public CambioBE SeleccionaNumero(int IdEmpresa, int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CambioBE Cambio = null;
            while (reader.Read())
            {
                Cambio = new CambioBE();
                Cambio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Cambio.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Cambio.IdCambio = Int32.Parse(reader["idCambio"].ToString());
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cambio.IdTipoCambio = Int32.Parse(reader["IdTipoCambio"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                //Cambio.IdDocumentoVenta = reader.IsDBNull(reader.GetOrdinal("IdDocumentoVenta")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdDocumentoVenta"));
                Cambio.IdTipoDocumentoVenta = Int32.Parse(reader["IdTipoDocumentoVenta"].ToString());
                Cambio.SerieDocumentoVenta = reader["SerieDocumentoVenta"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.IdSupervisor = Int32.Parse(reader["IdSupervisor"].ToString());
                Cambio.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Cambio.IdTipoAplicacion = reader.IsDBNull(reader.GetOrdinal("IdTipoAplicacion")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdTipoAplicacion"));
                Cambio.CodigoNC = reader["CodigoNC"].ToString();
                Cambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Cambio;
        }

        public CambioBE SeleccionaTipoDocumento(int IdEmpresa, int IdTipoDocumento, string Serie, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_SeleccionaTipoDocumento");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CambioBE Cambio = null;
            while (reader.Read())
            {
                Cambio = new CambioBE();
                Cambio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Cambio.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Cambio.IdCambio = Int32.Parse(reader["idCambio"].ToString());
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cambio.IdTipoCambio = Int32.Parse(reader["IdTipoCambio"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.IdTipoDocumentoVenta = Int32.Parse(reader["IdTipoDocumentoVenta"].ToString());
                Cambio.SerieDocumentoVenta = reader["SerieDocumentoVenta"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.IdSupervisor = Int32.Parse(reader["IdSupervisor"].ToString());
                Cambio.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Cambio.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                Cambio.CodigoNC = reader["CodigoNC"].ToString();
                Cambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cambio.Motivo = reader["Motivo"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return Cambio;
        }

        public CambioBE SeleccionaTipoDocumentoNCE(int IdEmpresa, int IdTipoDocumento, string Serie, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cambios_SeleccionaTipoDocumentoNCE");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CambioBE Cambio = null;
            while (reader.Read())
            {
                Cambio = new CambioBE();
                Cambio.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Cambio.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Cambio.IdCambio = Int32.Parse(reader["idCambio"].ToString());
                Cambio.DescTienda = reader["DescTienda"].ToString();
                Cambio.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Cambio.Numero = reader["Numero"].ToString();
                Cambio.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Cambio.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Cambio.IdTipoCambio = Int32.Parse(reader["IdTipoCambio"].ToString());
                Cambio.DescTipoCambio = reader["DescTipoCambio"].ToString();
                Cambio.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Cambio.NumeroPedido = reader["NumeroPedido"].ToString();
                Cambio.IdTipoDocumentoVenta = Int32.Parse(reader["IdTipoDocumentoVenta"].ToString());
                Cambio.SerieDocumentoVenta = reader["SerieDocumentoVenta"].ToString();
                Cambio.NumeroDocumentoVenta = reader["NumeroDocumentoVenta"].ToString();
                Cambio.FechaVenta = DateTime.Parse(reader["FechaVenta"].ToString());
                Cambio.CodMoneda = reader["CodMoneda"].ToString();
                Cambio.Total = Decimal.Parse(reader["Total"].ToString());
                Cambio.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Cambio.NumeroCliente = reader["NumeroCliente"].ToString();
                Cambio.DescCliente = reader["DescCliente"].ToString();
                Cambio.IdSupervisor = Int32.Parse(reader["IdSupervisor"].ToString());
                Cambio.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                Cambio.DescSupervisor = reader["DescSupervisor"].ToString();
                Cambio.Observacion = reader["Observacion"].ToString();
                Cambio.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Cambio.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                Cambio.CodigoNC = reader["CodigoNC"].ToString();
                Cambio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cambio.IdDocumentoVentaNcv = Int32.Parse(reader["IdDocumentoVentaNCV"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Cambio;
        }

    }
}
