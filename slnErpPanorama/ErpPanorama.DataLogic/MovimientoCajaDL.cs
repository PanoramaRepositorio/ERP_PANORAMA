using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MovimientoCajaDL
    {
        public MovimientoCajaDL() { }

        public Int32 Inserta(MovimientoCajaBE pItem)
        {
            Int32 intIdMovimientoCaja = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_Inserta");

            db.AddOutParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdCondicionPago", DbType.Int32, pItem.IdCondicionPago);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pTipoTarjeta", DbType.String, pItem.TipoTarjeta);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pImporteSoles", DbType.Decimal, pItem.ImporteSoles);
            db.AddInParameter(dbCommand, "pImporteDolares", DbType.Decimal, pItem.ImporteDolares);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdPago", DbType.Int32, pItem.IdPago);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdMotivoAnulacion", DbType.Int32, pItem.IdMotivoAnulacion);
            db.AddInParameter(dbCommand, "pNumeroCondicion", DbType.String, pItem.NumeroCondicion);
            db.AddInParameter(dbCommand, "pNumeroCupon", DbType.String, pItem.NumeroCupon);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdPersonaAutoriza", DbType.Int32, pItem.IdPersonaAutoriza);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, pItem.IdSolicitudPrestamo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento2", DbType.Int32, pItem.IdTipoDocumento2);
            db.AddInParameter(dbCommand, "pNumeroDocumento2", DbType.String, pItem.NumeroDocumento2);
            db.AddInParameter(dbCommand, "pPlaca", DbType.String, pItem.Placa);
            db.AddInParameter(dbCommand, "pFlagRetiroCliente", DbType.String, pItem.FlagRetiroCliente);
            db.AddInParameter(dbCommand, "pUsuarioRegistro", DbType.String, pItem.UsuarioRegistro);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pUsuarioModifica", DbType.String, pItem.UsuarioModifica);
            db.AddInParameter(dbCommand, "pFechaModifica", DbType.DateTime, pItem.FechaModifica);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdMovimientoCaja = (int)db.GetParameterValue(dbCommand, "pIdMovimientoCaja");

            return intIdMovimientoCaja;
        }

        public void Actualiza(MovimientoCajaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_Actualiza");

            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdCondicionPago", DbType.Int32, pItem.IdCondicionPago);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pTipoTarjeta", DbType.String, pItem.TipoTarjeta);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pImporteSoles", DbType.Decimal, pItem.ImporteSoles);
            db.AddInParameter(dbCommand, "pImporteDolares", DbType.Decimal, pItem.ImporteDolares);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdPago", DbType.Int32, pItem.IdPago);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdMotivoAnulacion", DbType.Int32, pItem.IdMotivoAnulacion);
            db.AddInParameter(dbCommand, "pNumeroCondicion", DbType.String, pItem.NumeroCondicion);
            db.AddInParameter(dbCommand, "pNumeroCupon", DbType.String, pItem.NumeroCupon);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdPersonaAutoriza", DbType.Int32, pItem.IdPersonaAutoriza);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, pItem.IdSolicitudPrestamo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento2", DbType.Int32, pItem.IdTipoDocumento2);
            db.AddInParameter(dbCommand, "pNumeroDocumento2", DbType.String, pItem.NumeroDocumento2);
            db.AddInParameter(dbCommand, "pPlaca", DbType.String, pItem.Placa);
            db.AddInParameter(dbCommand, "pUsuarioRegistro", DbType.String, pItem.UsuarioRegistro);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pUsuarioModifica", DbType.String, pItem.UsuarioModifica);
            db.AddInParameter(dbCommand, "pFechaModifica", DbType.DateTime, pItem.FechaModifica);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaSerieNumero(int IdEmpresa, int IdDocumentoVenta, string Serie, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_ActualizaNumeroSerie");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaReferencia(int IdEmpresa, int IdDocumentoVenta, int IdDocumentoReferencia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_ActualizaReferencia");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdDocumentoReferencia", DbType.String, IdDocumentoReferencia);

            db.ExecuteNonQuery(dbCommand);

        }


        public void ActualizaEstado(int IdMovimientoCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_ActualizaEstado");

            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, IdMovimientoCaja);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(MovimientoCajaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_Elimina");

            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, pItem.IdMovimientoCaja);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMotivoAnulacion", DbType.Int32, pItem.IdMotivoAnulacion);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public MovimientoCajaBE Selecciona(int IdMovimientoCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_Selecciona");

            db.AddInParameter(dbCommand, "pIdMovimientoCaja", DbType.Int32, IdMovimientoCaja);


            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoCajaBE MovimientoCaja = null;
            while (reader.Read())
            {
                MovimientoCaja = new MovimientoCajaBE();
                MovimientoCaja.IdMovimientoCaja = Int32.Parse(reader["idMovimientoCaja"].ToString());
                MovimientoCaja.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                MovimientoCaja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoTarjeta = reader["TipoTarjeta"].ToString();
                MovimientoCaja.TipoMovimiento = reader["tipoMovimiento"].ToString();
                MovimientoCaja.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.NumeroCondicion = reader["NumeroCondicion"].ToString();
                //MovimientoCaja.IdMovimientoCajaChica = Int32.Parse(reader["IdMovimientoCajaChica"].ToString());

                MovimientoCaja.Concepto = reader["Concepto"].ToString();
                MovimientoCaja.Observacion = reader["Observacion"].ToString();
                MovimientoCaja.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                MovimientoCaja.DescPersona = reader["DescPersona"].ToString();
                MovimientoCaja.IdPersonaAutoriza = Int32.Parse(reader["IdPersonaAutoriza"].ToString());
                MovimientoCaja.DescPersonaAutoriza = reader["DescPersonaAutoriza"].ToString();
                MovimientoCaja.IdDis_ProyectoServicio = Int32.Parse(reader["IdDis_ProyectoServicio"].ToString());
                MovimientoCaja.IdTipoDocumento2 = Int32.Parse(reader["idTipoDocumento2"].ToString());
                MovimientoCaja.CodTipoDocumento2 = reader["CodTipoDocumento2"].ToString();
                MovimientoCaja.NumeroDocumento2 = reader["numeroDocumento2"].ToString();
                MovimientoCaja.Placa = reader["Placa"].ToString();
                MovimientoCaja.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                MovimientoCaja.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaRegistro")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                MovimientoCaja.UsuarioModifica = reader["UsuarioModifica"].ToString();
                MovimientoCaja.FechaModifica = reader.IsDBNull(reader.GetOrdinal("FechaModifica")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaModifica"));
                MovimientoCaja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCaja;
        }

        public MovimientoCajaBE SeleccionaNumero(int IdEmpresa, int IdTipoDocumento, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_SeleccionaNumero");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoCajaBE MovimientoCaja = null;
            while (reader.Read())
            {
                MovimientoCaja = new MovimientoCajaBE();
                MovimientoCaja.IdMovimientoCaja = Int32.Parse(reader["idMovimientoCaja"].ToString());
                MovimientoCaja.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                MovimientoCaja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoTarjeta = reader["TipoTarjeta"].ToString();
                MovimientoCaja.TipoMovimiento = reader["tipoMovimiento"].ToString();
                MovimientoCaja.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.NumeroCondicion = reader["NumeroCondicion"].ToString();

                MovimientoCaja.Concepto = reader["Concepto"].ToString();
                MovimientoCaja.Observacion = reader["Observacion"].ToString();
                MovimientoCaja.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                MovimientoCaja.DescPersona = reader["DescPersona"].ToString();
                MovimientoCaja.IdPersonaAutoriza = Int32.Parse(reader["IdPersonaAutoriza"].ToString());
                MovimientoCaja.DescPersonaAutoriza = reader["DescPersonaAutoriza"].ToString();
                MovimientoCaja.IdDis_ProyectoServicio = Int32.Parse(reader["IdDis_ProyectoServicio"].ToString());
                MovimientoCaja.IdTipoDocumento2 = Int32.Parse(reader["idTipoDocumento2"].ToString());
                MovimientoCaja.CodTipoDocumento2 = reader["CodTipoDocumento2"].ToString();
                MovimientoCaja.NumeroDocumento2 = reader["numeroDocumento2"].ToString();
                MovimientoCaja.Placa = reader["Placa"].ToString();
                MovimientoCaja.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                MovimientoCaja.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaRegistro")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                MovimientoCaja.UsuarioModifica = reader["UsuarioModifica"].ToString();
                MovimientoCaja.FechaModifica = reader.IsDBNull(reader.GetOrdinal("FechaModifica")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaModifica"));
                MovimientoCaja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCaja;
        }

        public MovimientoCajaBE SeleccionaSolicitudPrestamo(int IdSolicitudPrestamo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_SeleccionaSolicitudPrestamo");

            db.AddInParameter(dbCommand, "PIdSolicitudPrestamo", DbType.Int32, IdSolicitudPrestamo);


            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoCajaBE MovimientoCaja = null;
            while (reader.Read())
            {
                MovimientoCaja = new MovimientoCajaBE();
                MovimientoCaja.IdMovimientoCaja = Int32.Parse(reader["idMovimientoCaja"].ToString());
                MovimientoCaja.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                MovimientoCaja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoTarjeta = reader["TipoTarjeta"].ToString();
                MovimientoCaja.TipoMovimiento = reader["tipoMovimiento"].ToString();
                MovimientoCaja.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.NumeroCondicion = reader["NumeroCondicion"].ToString();
                //MovimientoCaja.IdMovimientoCajaChica = Int32.Parse(reader["IdMovimientoCajaChica"].ToString());

                MovimientoCaja.Concepto = reader["Concepto"].ToString();
                MovimientoCaja.Observacion = reader["Observacion"].ToString();
                MovimientoCaja.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                MovimientoCaja.DescPersona = reader["DescPersona"].ToString();
                MovimientoCaja.IdPersonaAutoriza = Int32.Parse(reader["IdPersonaAutoriza"].ToString());
                MovimientoCaja.DescPersonaAutoriza = reader["DescPersonaAutoriza"].ToString();
                MovimientoCaja.IdDis_ProyectoServicio = Int32.Parse(reader["IdDis_ProyectoServicio"].ToString());
                MovimientoCaja.IdTipoDocumento2 = Int32.Parse(reader["idTipoDocumento2"].ToString());
                MovimientoCaja.CodTipoDocumento2 = reader["CodTipoDocumento2"].ToString();
                MovimientoCaja.NumeroDocumento2 = reader["numeroDocumento2"].ToString();

                MovimientoCaja.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                MovimientoCaja.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaRegistro")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                MovimientoCaja.UsuarioModifica = reader["UsuarioModifica"].ToString();
                MovimientoCaja.FechaModifica = reader.IsDBNull(reader.GetOrdinal("FechaModifica")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaModifica"));
                MovimientoCaja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCaja;
        }

        public List<MovimientoCajaBE> ListaPagos(int IdPago)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_ListaPagos");

            db.AddInParameter(dbCommand, "pIdPago", DbType.Int32, IdPago);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoCajaBE> MovimientoCajalist = new List<MovimientoCajaBE>();
            MovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new MovimientoCajaBE();
                MovimientoCaja.IdMovimientoCaja = Int32.Parse(reader["idMovimientoCaja"].ToString());
                MovimientoCaja.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                MovimientoCaja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoTarjeta = reader["TipoTarjeta"].ToString();
                MovimientoCaja.TipoMovimiento = reader["tipoMovimiento"].ToString();
                MovimientoCaja.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                MovimientoCaja.IdPago = Int32.Parse(reader["IdPago"].ToString());
                MovimientoCaja.NumeroCondicion = reader["NumeroCondicion"].ToString();
                MovimientoCaja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<MovimientoCajaBE> ListaFormaPago(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_ListaFormaPago");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoCajaBE> MovimientoCajalist = new List<MovimientoCajaBE>();
            MovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new MovimientoCajaBE();
                MovimientoCaja.IdMovimientoCaja = Int32.Parse(reader["idMovimientoCaja"].ToString());
                MovimientoCaja.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                MovimientoCaja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoTarjeta = reader["TipoTarjeta"].ToString();
                MovimientoCaja.TipoMovimiento = reader["tipoMovimiento"].ToString();
                MovimientoCaja.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                MovimientoCaja.IdPago = Int32.Parse(reader["IdPago"].ToString());
                MovimientoCaja.NumeroCondicion = reader["NumeroCondicion"].ToString();
                MovimientoCaja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }


        public List<MovimientoCajaBE> ListaTodosActivo(int IdCaja, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_ListaTodosActivo");

            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoCajaBE> MovimientoCajalist = new List<MovimientoCajaBE>();
            MovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new MovimientoCajaBE();
                MovimientoCaja.IdMovimientoCaja = Int32.Parse(reader["idMovimientoCaja"].ToString());
                MovimientoCaja.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                MovimientoCaja.Empresa = reader["Empresa"].ToString();
                MovimientoCaja.DescTienda = reader["Tienda"].ToString();
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoTarjeta = reader["TipoTarjeta"].ToString();
                MovimientoCaja.TipoMovimiento = reader["tipoMovimiento"].ToString();
                MovimientoCaja.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                //MovimientoCaja.IdMovimientoCajaChica = Int32.Parse(reader["IdMovimientoCajaChica"].ToString());
                MovimientoCaja.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoCaja.DescMotivoAnulacion = reader["DescMotivoAnulacion"].ToString();
                MovimientoCaja.NumeroCondicion = reader["NumeroCondicion"].ToString();
                MovimientoCaja.Concepto = reader["Concepto"].ToString();
                MovimientoCaja.Observacion = reader["Observacion"].ToString();
                MovimientoCaja.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                MovimientoCaja.DescPersona = reader["DescPersona"].ToString();
                MovimientoCaja.IdPersonaAutoriza = Int32.Parse(reader["IdPersonaAutoriza"].ToString());
                MovimientoCaja.DescPersonaAutoriza = reader["DescPersonaAutoriza"].ToString();
                MovimientoCaja.IdDis_ProyectoServicio = Int32.Parse(reader["IdDis_ProyectoServicio"].ToString());
                MovimientoCaja.IdTipoDocumento2 = Int32.Parse(reader["idTipoDocumento2"].ToString());
                MovimientoCaja.CodTipoDocumento2 = reader["CodTipoDocumento2"].ToString();
                MovimientoCaja.NumeroDocumento2 = reader["numeroDocumento2"].ToString();
                MovimientoCaja.Placa = reader["Placa"].ToString();
                //MovimientoCaja.IdPago = Int32.Parse(reader["IdPago"].ToString());
                MovimientoCaja.IdPago = reader.IsDBNull(reader.GetOrdinal("IdPago")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPago"));
                MovimientoCaja.FlagRetiroCliente = Boolean.Parse(reader["FlagRetiroCliente"].ToString());
                MovimientoCaja.DescSituacionPSE = reader["DescSituacionPSE"].ToString();
                MovimientoCaja.DescSituacionSunat = reader["DescSituacionSunat"].ToString();
                MovimientoCaja.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                MovimientoCaja.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaRegistro")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                MovimientoCaja.UsuarioModifica = reader["UsuarioModifica"].ToString();
                MovimientoCaja.FechaModifica = reader.IsDBNull(reader.GetOrdinal("FechaModifica")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaModifica"));
                MovimientoCaja.UsuarioElimina = reader["UsuarioElimina"].ToString();
                MovimientoCaja.FechaElimina = reader.IsDBNull(reader.GetOrdinal("FechaElimina")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaElimina"));
                MovimientoCaja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }


        public List<MovimientoCajaBE> ListaTodasCajas(int Anio, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_ListaTodasCajas");

            db.AddInParameter(dbCommand, "pAnio", DbType.Int32, Anio);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoCajaBE> MovimientoCajalist = new List<MovimientoCajaBE>();
            MovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new MovimientoCajaBE();
                MovimientoCaja.IdMovimientoCaja = Int32.Parse(reader["idMovimientoCaja"].ToString());
                MovimientoCaja.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                MovimientoCaja.Empresa = reader["Empresa"].ToString();
                MovimientoCaja.DescTienda = reader["Tienda"].ToString();
                MovimientoCaja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoTarjeta = reader["TipoTarjeta"].ToString();
                MovimientoCaja.TipoMovimiento = reader["tipoMovimiento"].ToString();
                MovimientoCaja.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                //MovimientoCaja.IdMovimientoCajaChica = Int32.Parse(reader["IdMovimientoCajaChica"].ToString());
                MovimientoCaja.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoCaja.DescMotivoAnulacion = reader["DescMotivoAnulacion"].ToString();
                MovimientoCaja.NumeroCondicion = reader["NumeroCondicion"].ToString();
                MovimientoCaja.Concepto = reader["Concepto"].ToString();
                MovimientoCaja.Observacion = reader["Observacion"].ToString();
                MovimientoCaja.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                MovimientoCaja.DescPersona = reader["DescPersona"].ToString();
                MovimientoCaja.IdPersonaAutoriza = Int32.Parse(reader["IdPersonaAutoriza"].ToString());
                MovimientoCaja.DescPersonaAutoriza = reader["DescPersonaAutoriza"].ToString();
                MovimientoCaja.IdDis_ProyectoServicio = Int32.Parse(reader["IdDis_ProyectoServicio"].ToString());
                MovimientoCaja.IdTipoDocumento2 = Int32.Parse(reader["idTipoDocumento2"].ToString());
                MovimientoCaja.CodTipoDocumento2 = reader["CodTipoDocumento2"].ToString();
                MovimientoCaja.NumeroDocumento2 = reader["numeroDocumento2"].ToString();
                MovimientoCaja.Placa = reader["Placa"].ToString();
                //MovimientoCaja.IdPago = Int32.Parse(reader["IdPago"].ToString());
                MovimientoCaja.IdPago = reader.IsDBNull(reader.GetOrdinal("IdPago")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdPago"));
                MovimientoCaja.FlagRetiroCliente = Boolean.Parse(reader["FlagRetiroCliente"].ToString());
                MovimientoCaja.DescSituacionPSE = reader["DescSituacionPSE"].ToString();
                MovimientoCaja.DescSituacionSunat = reader["DescSituacionSunat"].ToString();
                MovimientoCaja.UsuarioRegistro = reader["UsuarioRegistro"].ToString();
                MovimientoCaja.FechaRegistro = reader.IsDBNull(reader.GetOrdinal("FechaRegistro")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                MovimientoCaja.UsuarioModifica = reader["UsuarioModifica"].ToString();
                MovimientoCaja.FechaModifica = reader.IsDBNull(reader.GetOrdinal("FechaModifica")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaModifica"));
                MovimientoCaja.UsuarioElimina = reader["UsuarioElimina"].ToString();
                MovimientoCaja.FechaElimina = reader.IsDBNull(reader.GetOrdinal("FechaElimina")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaElimina"));
                MovimientoCaja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<MovimientoCajaBE> ListaDocumentoVenta(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_ListaIdDocumentoVenta");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoCajaBE> MovimientoCajalist = new List<MovimientoCajaBE>();
            MovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new MovimientoCajaBE();
                MovimientoCaja.IdMovimientoCaja = Int32.Parse(reader["idMovimientoCaja"].ToString());
                MovimientoCaja.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                MovimientoCaja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoTarjeta = reader["TipoTarjeta"].ToString();
                MovimientoCaja.TipoMovimiento = reader["tipoMovimiento"].ToString();
                MovimientoCaja.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                MovimientoCaja.NumeroCondicion = reader["NumeroCondicion"].ToString();
                MovimientoCaja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

        public List<MovimientoCajaBE> ListaPedido(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoCaja_ListaPedido");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoCajaBE> MovimientoCajalist = new List<MovimientoCajaBE>();
            MovimientoCajaBE MovimientoCaja;
            while (reader.Read())
            {
                MovimientoCaja = new MovimientoCajaBE();
                MovimientoCaja.IdMovimientoCaja = Int32.Parse(reader["idMovimientoCaja"].ToString());
                MovimientoCaja.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                MovimientoCaja.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                MovimientoCaja.DescCaja = reader["DescCaja"].ToString();
                MovimientoCaja.Fecha = DateTime.Parse(reader["fecha"].ToString());
                MovimientoCaja.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                MovimientoCaja.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoCaja.NumeroDocumento = reader["numeroDocumento"].ToString();
                MovimientoCaja.IdFormaPago = Int32.Parse(reader["idFormaPago"].ToString());
                MovimientoCaja.DescFormaPago = reader["DescFormaPago"].ToString();
                MovimientoCaja.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                MovimientoCaja.DescCondicionPago = reader["DescCondicionPago"].ToString();
                MovimientoCaja.TipoTarjeta = reader["TipoTarjeta"].ToString();
                MovimientoCaja.TipoMovimiento = reader["tipoMovimiento"].ToString();
                MovimientoCaja.IdMoneda = Int32.Parse(reader["idMoneda"].ToString());
                MovimientoCaja.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoCaja.TipoCambio = Decimal.Parse(reader["tipoCambio"].ToString());
                MovimientoCaja.ImporteSoles = Decimal.Parse(reader["importeSoles"].ToString());
                MovimientoCaja.ImporteDolares = Decimal.Parse(reader["importeDolares"].ToString());
                MovimientoCaja.IdDocumentoVenta = Int32.Parse(reader["IdDocumentoVenta"].ToString());
                MovimientoCaja.NumeroCondicion = reader["NumeroCondicion"].ToString();
                MovimientoCaja.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoCajalist.Add(MovimientoCaja);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoCajalist;
        }

    }
}
