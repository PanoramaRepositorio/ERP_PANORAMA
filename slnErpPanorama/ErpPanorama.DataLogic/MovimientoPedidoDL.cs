using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MovimientoPedidoDL
    {
        public MovimientoPedidoDL() { }

        //public void Inserta(MovimientoPedidoBE pItem)
        //{
        //    //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    //DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_Inserta");

        //    //db.AddInParameter(dbCommand, "pIdMeta", DbType.Int32, pItem.IdMeta);
        //    //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
        //    //db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
        //    //db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
        //    //db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
        //    //db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
        //    //db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
        //    //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
        //    //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

        //    //db.ExecuteNonQuery(dbCommand);
        //}

        //public void Actualiza(MovimientoPedidoBE pItem)
        //{
        //    //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    //DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_Actualiza");

        //    //db.AddInParameter(dbCommand, "pIdMeta", DbType.Int32, pItem.IdMeta);
        //    //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
        //    //db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
        //    //db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
        //    //db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
        //    //db.AddInParameter(dbCommand, "pIdCargo", DbType.Int32, pItem.IdCargo);
        //    //db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
        //    //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
        //    //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

        //    //db.ExecuteNonQuery(dbCommand);
        //}

        public List<MovimientoPedidoBE> ListaTodosActivo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int TipoConsulta, int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);
            dbCommand.CommandTimeout = 250;

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoPedidoBE> MovimientoPedidolist = new List<MovimientoPedidoBE>();
            MovimientoPedidoBE MovimientoPedido;
            while (reader.Read())
            {
                MovimientoPedido = new MovimientoPedidoBE();
                MovimientoPedido.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoPedido.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoPedido.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoPedido.Numero = reader["Numero"].ToString();
                MovimientoPedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoPedido.DescTienda = reader["DescTienda"].ToString();
                MovimientoPedido.TipoCliente = reader["TipoCliente"].ToString();

                MovimientoPedido.NumeroDocumento = reader["NumeroDocumento"].ToString();

                MovimientoPedido.DescCliente = reader["DescCliente"].ToString();
                MovimientoPedido.ApeNom = reader["ApeNom"].ToString();

                MovimientoPedido.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());

                MovimientoPedido.Situacion = reader["Situacion"].ToString();
                MovimientoPedido.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());

                MovimientoPedido.FormaPago = reader["FormaPago"].ToString();
                MovimientoPedido.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoPedido.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoPedido.Destino = reader["Destino"].ToString();
                MovimientoPedido.Aprobado = Boolean.Parse(reader["Aprobado"].ToString());
                MovimientoPedido.FechaAprobado = reader.IsDBNull(reader.GetOrdinal("FechaAprobado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaAprobado"));
                MovimientoPedido.Recibido = Boolean.Parse(reader["Recibido"].ToString());
                MovimientoPedido.FechaRecibido = reader.IsDBNull(reader.GetOrdinal("FechaRecibido")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecibido"));
                MovimientoPedido.Preparacion = Boolean.Parse(reader["Preparacion"].ToString());
                MovimientoPedido.FechaPreparacion = reader.IsDBNull(reader.GetOrdinal("FechaPreparacion")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparacion"));
                MovimientoPedido.Preparado = Boolean.Parse(reader["Preparado"].ToString());
                MovimientoPedido.FechaPreparado = reader.IsDBNull(reader.GetOrdinal("FechaPreparado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparado"));
                MovimientoPedido.Chequeo = Boolean.Parse(reader["Chequeo"].ToString());
                MovimientoPedido.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                MovimientoPedido.Chequeado = Boolean.Parse(reader["Chequeado"].ToString());
                MovimientoPedido.FechaChequeado = reader.IsDBNull(reader.GetOrdinal("FechaChequeado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeado"));

                MovimientoPedido.FlagIniCalidad = Boolean.Parse(reader["FlagIniCalidad"].ToString());
                MovimientoPedido.FechaIniCalidad = reader.IsDBNull(reader.GetOrdinal("FechaIniCalidad")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaIniCalidad"));
                MovimientoPedido.FlagFinCalidad = Boolean.Parse(reader["FlagFinCalidad"].ToString());
                MovimientoPedido.FechaFinCalidad = reader.IsDBNull(reader.GetOrdinal("FechaFinCalidad")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaFinCalidad"));

                MovimientoPedido.EnPT = Boolean.Parse(reader["EnPT"].ToString());
                MovimientoPedido.FechaPT = reader.IsDBNull(reader.GetOrdinal("FechaPT")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPT"));
                MovimientoPedido.Embalado = Boolean.Parse(reader["Embalado"].ToString());
                MovimientoPedido.FechaEmbalado = reader.IsDBNull(reader.GetOrdinal("FechaEmbalado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmbalado"));
                MovimientoPedido.RecepcionDocumento = Boolean.Parse(reader["RecepcionDocumento"].ToString());
                MovimientoPedido.FechaRD = reader.IsDBNull(reader.GetOrdinal("FechaRD")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaRD"));
                MovimientoPedido.Despachado = Boolean.Parse(reader["Despachado"].ToString());
                MovimientoPedido.FechaDespachado = reader.IsDBNull(reader.GetOrdinal("FechaDespachado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespachado"));
                MovimientoPedido.OrigenDespacho = reader["OrigenDespacho"].ToString();
                MovimientoPedido.FechaAnulado = reader.IsDBNull(reader.GetOrdinal("FechaAnulado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaAnulado"));
                MovimientoPedido.NumeroDespacho = reader["NumeroDespacho"].ToString();
                MovimientoPedido.FechaDespacho2 = reader.IsDBNull(reader.GetOrdinal("FechaDespacho2")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespacho2"));
                MovimientoPedido.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoPedido.Direccion = reader["Direccion"].ToString();
                MovimientoPedido.DescAgencia = reader["DescAgencia"].ToString();
                MovimientoPedido.Observacion2 = reader["Observacion2"].ToString();
                MovimientoPedido.Observacion = reader["Observacion"].ToString();
                MovimientoPedido.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                MovimientoPedido.Conductor = reader["Conductor"].ToString();
                MovimientoPedido.DescCopiloto = reader["DescCopiloto"].ToString();
                MovimientoPedido.Usuario = reader["Usuario"].ToString();
                MovimientoPedido.Maquina = reader["Maquina"].ToString();
                MovimientoPedido.Despachar = reader["Despachar"].ToString();
                MovimientoPedido.CambioFechaDelivery = Boolean.Parse(reader["CambioFechaDelivery"].ToString());
                MovimientoPedido.UsuarioCambioFecha = reader["UsuarioCambioFecha"].ToString();
                MovimientoPedido.FechaRegistroFacturacion = reader.IsDBNull(reader.GetOrdinal("FechaRegistroFacturacion")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistroFacturacion"));
                MovimientoPedido.TotalPeso = Decimal.Parse(reader["TotalPeso"].ToString());
                MovimientoPedido.Placa = reader["Placa"].ToString();
                MovimientoPedidolist.Add(MovimientoPedido);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidolist;
        }

        public List<MovimientoPedidoBE> ListaNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ListaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoPedidoBE> MovimientoPedidolist = new List<MovimientoPedidoBE>();
            MovimientoPedidoBE MovimientoPedido;
            while (reader.Read())
            {
                MovimientoPedido = new MovimientoPedidoBE();
                MovimientoPedido.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoPedido.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoPedido.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoPedido.Numero = reader["Numero"].ToString();
                MovimientoPedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoPedido.DescTienda = reader["DescTienda"].ToString();
                MovimientoPedido.DescCliente = reader["DescCliente"].ToString();
                MovimientoPedido.ApeNom = reader["ApeNom"].ToString();
                MovimientoPedido.Situacion = reader["Situacion"].ToString();
                MovimientoPedido.FormaPago = reader["FormaPago"].ToString();
                MovimientoPedido.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoPedido.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoPedido.Destino = reader["Destino"].ToString();
                MovimientoPedido.Aprobado = Boolean.Parse(reader["Aprobado"].ToString());
                MovimientoPedido.FechaAprobado = reader.IsDBNull(reader.GetOrdinal("FechaAprobado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaAprobado"));
                MovimientoPedido.Recibido = Boolean.Parse(reader["Recibido"].ToString());
                MovimientoPedido.FechaRecibido = reader.IsDBNull(reader.GetOrdinal("FechaRecibido")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecibido"));
                MovimientoPedido.Preparacion = Boolean.Parse(reader["Preparacion"].ToString());
                MovimientoPedido.FechaPreparacion = reader.IsDBNull(reader.GetOrdinal("FechaPreparacion")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparacion"));
                MovimientoPedido.Preparado = Boolean.Parse(reader["Preparado"].ToString());
                MovimientoPedido.FechaPreparado = reader.IsDBNull(reader.GetOrdinal("FechaPreparado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparado"));
                MovimientoPedido.Chequeo = Boolean.Parse(reader["Chequeo"].ToString());
                MovimientoPedido.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                MovimientoPedido.Chequeado = Boolean.Parse(reader["Chequeado"].ToString());
                MovimientoPedido.FechaChequeado = reader.IsDBNull(reader.GetOrdinal("FechaChequeado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeado"));
                MovimientoPedido.EnPT = Boolean.Parse(reader["EnPT"].ToString());
                MovimientoPedido.FechaPT = reader.IsDBNull(reader.GetOrdinal("FechaPT")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPT"));
                MovimientoPedido.Embalado = Boolean.Parse(reader["Embalado"].ToString());
                MovimientoPedido.FechaEmbalado = reader.IsDBNull(reader.GetOrdinal("FechaEmbalado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmbalado"));
                MovimientoPedido.RecepcionDocumento = Boolean.Parse(reader["RecepcionDocumento"].ToString());
                MovimientoPedido.FechaRD = reader.IsDBNull(reader.GetOrdinal("FechaRD")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaRD"));
                MovimientoPedido.Despachado = Boolean.Parse(reader["Despachado"].ToString());
                MovimientoPedido.FechaDespachado = reader.IsDBNull(reader.GetOrdinal("FechaDespachado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespachado"));
                MovimientoPedido.OrigenDespacho = reader["OrigenDespacho"].ToString();
                MovimientoPedido.FechaAnulado = reader.IsDBNull(reader.GetOrdinal("FechaAnulado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaAnulado"));
                MovimientoPedido.NumeroDespacho = reader["NumeroDespacho"].ToString();
                MovimientoPedido.FechaDespacho2 = reader.IsDBNull(reader.GetOrdinal("FechaDespacho2")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespacho2"));
                MovimientoPedido.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoPedido.Direccion = reader["Direccion"].ToString();
                MovimientoPedido.DescAgencia = reader["DescAgencia"].ToString();
                MovimientoPedido.Observacion2 = reader["Observacion2"].ToString();
                MovimientoPedido.Observacion = reader["Observacion"].ToString();
                MovimientoPedido.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                MovimientoPedido.Conductor = reader["Conductor"].ToString();
                MovimientoPedido.Usuario = reader["Usuario"].ToString();
                MovimientoPedido.Maquina = reader["Maquina"].ToString();
                MovimientoPedido.TotalPeso = Decimal.Parse(reader["PesoKg"].ToString());
                MovimientoPedidolist.Add(MovimientoPedido);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidolist;
        }

        public List<MovimientoPedidoBE> ListaPersonalPickingDisponible(int IdEmpresa, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ListaPersonalPickingDisponible");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoPedidoBE> MovimientoPedidolist = new List<MovimientoPedidoBE>();
            MovimientoPedidoBE MovimientoPedido;
            while (reader.Read())
            {
                MovimientoPedido = new MovimientoPedidoBE();
                MovimientoPedido.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                MovimientoPedido.ApeNom = reader["ApeNom"].ToString();
                MovimientoPedido.DescCargo = reader["DescCargo"].ToString();
                MovimientoPedido.FechaPreparado = reader.IsDBNull(reader.GetOrdinal("FechaPreparado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparado"));
                MovimientoPedido.CantidadPedido = Int32.Parse(reader["CantidadPedido"].ToString());
                MovimientoPedido.Disponible = reader["Disponible"].ToString();
                MovimientoPedidolist.Add(MovimientoPedido);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidolist;
        }

        public MovimientoPedidoBE SeleccionaDespacho(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_SeleccionaDespacho");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoPedidoBE MovimientoPedido = null;
            while (reader.Read())
            {
                MovimientoPedido = new MovimientoPedidoBE();
                MovimientoPedido.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoPedido.NumeroPedido = reader["NumeroPedido"].ToString();
                MovimientoPedido.FormaPago = reader["FormaPago"].ToString();
                MovimientoPedido.CodMoneda = reader["DescCliente"].ToString();
                MovimientoPedido.IdAgencia = Int32.Parse(reader["IdAgencia"].ToString());
                MovimientoPedido.DescAgencia = reader["DescAgencia"].ToString();
                MovimientoPedido.Direccion = reader["Direccion"].ToString();
                MovimientoPedido.IdUbigeoDelivery = reader["IdUbigeoDelivery"].ToString();
                MovimientoPedido.Referencia = reader["Referencia"].ToString();
                MovimientoPedido.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoPedido.IdPrioridad = Int32.Parse(reader["IdPrioridad"].ToString());
                MovimientoPedido.DescPrioridad = reader["DescPrioridad"].ToString();
                MovimientoPedido.IdDestino = Int32.Parse(reader["IdDestino"].ToString());
                MovimientoPedido.DescDestino = reader["DescDestino"].ToString();
                MovimientoPedido.IdPagoFlete = Int32.Parse(reader["IdPagoFlete"].ToString());
                MovimientoPedido.DescPagoFlete = reader["DescPagoFlete"].ToString();
                MovimientoPedido.NumeroDespacho = reader["NumeroDespacho"].ToString();
                MovimientoPedido.FechaDespacho2 = reader.IsDBNull(reader.GetOrdinal("FechaDespacho2")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespacho2"));
                MovimientoPedido.ClaveEnvio = reader["ClaveEnvio"].ToString();
                MovimientoPedido.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoPedido.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoPedido.NumeroPiso = Int32.Parse(reader["NumeroPiso"].ToString());
                MovimientoPedido.Observacion2 = reader["Observacion2"].ToString();
                MovimientoPedido.CambioFechaDelivery = Boolean.Parse(reader["CambioFechaDelivery"].ToString());
                MovimientoPedido.PersonaRecoge = reader["PersonaRecoge"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedido;
        }

        public MovimientoPedidoBE Selecciona(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_Selecciona");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoPedidoBE MovimientoPedido = null;
            while (reader.Read())
            {
                MovimientoPedido = new MovimientoPedidoBE();
                MovimientoPedido.Item = Int32.Parse(reader["Item"].ToString());
                MovimientoPedido.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoPedido.Numero = reader["Numero"].ToString();
                MovimientoPedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoPedido.DescTienda = reader["DescTienda"].ToString();
                MovimientoPedido.DescCliente = reader["DescCliente"].ToString();
                MovimientoPedido.ApeNom = reader["ApeNom"].ToString();
                MovimientoPedido.Situacion = reader["Situacion"].ToString();
                MovimientoPedido.FormaPago = reader["FormaPago"].ToString();
                MovimientoPedido.CodMoneda = reader["CodMoneda"].ToString();
                MovimientoPedido.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoPedido.Destino = reader["Destino"].ToString();
                MovimientoPedido.Aprobado = Boolean.Parse(reader["Aprobado"].ToString());
                MovimientoPedido.FechaAprobado = reader.IsDBNull(reader.GetOrdinal("FechaAprobado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaAprobado"));
                MovimientoPedido.Recibido = Boolean.Parse(reader["Recibido"].ToString());
                MovimientoPedido.FechaRecibido = reader.IsDBNull(reader.GetOrdinal("FechaRecibido")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecibido"));
                MovimientoPedido.Preparacion = Boolean.Parse(reader["Preparacion"].ToString());
                MovimientoPedido.FechaPreparacion = reader.IsDBNull(reader.GetOrdinal("FechaPreparacion")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparacion"));
                MovimientoPedido.Preparado = Boolean.Parse(reader["Preparado"].ToString());
                MovimientoPedido.FechaPreparado = reader.IsDBNull(reader.GetOrdinal("FechaPreparado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparado"));
                MovimientoPedido.Chequeo = Boolean.Parse(reader["Chequeo"].ToString());
                MovimientoPedido.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                MovimientoPedido.Chequeado = Boolean.Parse(reader["Chequeado"].ToString());
                MovimientoPedido.FechaChequeado = reader.IsDBNull(reader.GetOrdinal("FechaChequeado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeado"));
                MovimientoPedido.FlagIniCalidad = Boolean.Parse(reader["FlagIniCalidad"].ToString());
                MovimientoPedido.FechaIniCalidad = reader.IsDBNull(reader.GetOrdinal("FechaIniCalidad")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaIniCalidad"));
                MovimientoPedido.FlagFinCalidad = Boolean.Parse(reader["FlagFinCalidad"].ToString());
                MovimientoPedido.FechaFinCalidad = reader.IsDBNull(reader.GetOrdinal("FechaFinCalidad")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaFinCalidad"));
                MovimientoPedido.EnPT = Boolean.Parse(reader["EnPT"].ToString());
                MovimientoPedido.FechaPT = reader.IsDBNull(reader.GetOrdinal("FechaPT")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaPT"));
                MovimientoPedido.Embalado = Boolean.Parse(reader["Embalado"].ToString());
                MovimientoPedido.FechaEmbalado = reader.IsDBNull(reader.GetOrdinal("FechaEmbalado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmbalado"));
                MovimientoPedido.RecepcionDocumento = Boolean.Parse(reader["RecepcionDocumento"].ToString());
                MovimientoPedido.FechaRD = reader.IsDBNull(reader.GetOrdinal("FechaRD")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaRD"));
                MovimientoPedido.Despachado = Boolean.Parse(reader["Despachado"].ToString());
                MovimientoPedido.FechaDespachado = reader.IsDBNull(reader.GetOrdinal("FechaDespachado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespachado"));
                MovimientoPedido.FechaAnulado = reader.IsDBNull(reader.GetOrdinal("FechaAnulado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaAnulado"));
                MovimientoPedido.FechaDespacho2 = reader.IsDBNull(reader.GetOrdinal("FechaDespacho2")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespacho2"));
                MovimientoPedido.Observacion = reader["Observacion"].ToString();
                MovimientoPedido.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                MovimientoPedido.IdAuxiliar = Int32.Parse(reader["IdAuxiliar"].ToString());
                MovimientoPedido.DescAuxiliar = reader["DescAuxiliar"].ToString();
                MovimientoPedido.Conductor = reader["Conductor"].ToString();
                MovimientoPedido.DescPersonaAprueba = reader["DescPersonaAprueba"].ToString();
                MovimientoPedido.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoPedido.PesoKg = Decimal.Parse(reader["PesoKg"].ToString());
                MovimientoPedido.Usuario = reader["Usuario"].ToString();
                MovimientoPedido.Maquina = reader["Maquina"].ToString();
                MovimientoPedido.FechaHoraServidor = DateTimeOffset.Parse(reader["FechaHoraServidor"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedido;
        }

        public MovimientoPedidoBE SeleccionaChequeo(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_SeleccionaPersonaChequeo");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoPedidoBE MovimientoPedido = null;
            while (reader.Read())
            {
                MovimientoPedido = new MovimientoPedidoBE();
                MovimientoPedido.IdChequeador = Int32.Parse(reader["IdChequeador"].ToString());
                MovimientoPedido.DescChequeador = reader["DescChequeador"].ToString();
                MovimientoPedido.IdAuxiliar = Int32.Parse(reader["IdAuxiliar"].ToString());
                MovimientoPedido.DescAuxiliar = reader["DescAuxiliar"].ToString();
                MovimientoPedido.IdEmbalador = Int32.Parse(reader["IdEmbalador"].ToString());
                MovimientoPedido.DescEmbalador = reader["DescEmbalador"].ToString();
                MovimientoPedido.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoPedido.Preparado = Boolean.Parse(reader["Preparado"].ToString());
                MovimientoPedido.Chequeo = Boolean.Parse(reader["Chequeo"].ToString());
                MovimientoPedido.Chequeado = Boolean.Parse(reader["Chequeado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedido;
        }

        public MovimientoPedidoBE SeleccionaDireccionEnvio(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_SeleccionaDireccionEnvio");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoPedidoBE MovimientoPedido = null;
            while (reader.Read())
            {
                MovimientoPedido = new MovimientoPedidoBE();
                MovimientoPedido.Direccion = reader["Direccion"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedido;
        }


        public void ActualizaSituacion(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdSituacionAlmacen", DbType.Int32, pItem.IdSituacionAlmacen);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pConductor", DbType.String, pItem.Conductor);
            db.AddInParameter(dbCommand, "pIdPersonaCredito", DbType.Int32, pItem.IdPersonaCredito);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaAuxiliar(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaAuxiliar");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdAuxiliar", DbType.Int32, pItem.IdAuxiliar);
            db.AddInParameter(dbCommand, "pOrigen", DbType.Int32, pItem.Origen);


            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaEmbalador(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaEmbalador");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmbalador", DbType.Int32, pItem.IdEmbalador);


            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaDespachador(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaDespachador");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdDespachador", DbType.Int32, pItem.IdDespachador);
            db.AddInParameter(dbCommand, "pCantidadBulto", DbType.Int32, pItem.CantidadBulto);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaOrigenDespacho(int IdPedido, string OrigenDespacho)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaOrigenDespacho");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pOrigenDespacho", DbType.String, OrigenDespacho);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaConductor(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaConductor");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdConductor", DbType.Int32, pItem.IdConductor);
            db.AddInParameter(dbCommand, "pIdCopiloto", DbType.Int32, pItem.IdCopiloto);
            db.AddInParameter(dbCommand, "pIdVehiculo", DbType.Int32, pItem.IdVehiculo);


            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaConductorDespacho(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaConductorDespacho");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdConductor", DbType.Int32, pItem.IdConductor);


            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaChequeador(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaChequeador");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdChequeador", DbType.Int32, pItem.IdChequeador);


            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCierreChequeado(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaCierreChequeado");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pChequeado", DbType.Boolean, pItem.Chequeado);


            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCierrePicking(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaCierrePicking");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdAuxiliar", DbType.Int32, pItem.IdAuxiliar);
            db.AddInParameter(dbCommand, "pPreparado", DbType.Boolean, pItem.Preparado);
            db.AddInParameter(dbCommand, "pFlagCierre", DbType.Boolean, pItem.FlagCierre);

            db.ExecuteNonQuery(dbCommand);
        }
        public void ActualizaCierreCalidad(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaCierreCalidad");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdPersonaCalidad", DbType.Int32, pItem.IdPersonaCalidad);
            db.AddInParameter(dbCommand, "pFlagFinCalidad", DbType.Boolean, pItem.FlagFinCalidad);
            db.AddInParameter(dbCommand, "pFlagCierre", DbType.Boolean, pItem.FlagCierre);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCierreEmbalaje2(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaCierreEmbalaje2");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmbalador", DbType.Int32, pItem.IdEmbalador);
            db.AddInParameter(dbCommand, "pEmbalado", DbType.Boolean, pItem.Embalado);
            db.AddInParameter(dbCommand, "pFlagCierre", DbType.Boolean, pItem.FlagCierre);
            db.AddInParameter(dbCommand, "pCantidadBulto", DbType.Int32, pItem.CantidadBulto);
            db.AddInParameter(dbCommand, "pPeso", DbType.Decimal, pItem.PesoKg);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCierreEmbalaje(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaCierreEmbalaje");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdEmbalador", DbType.Int32, pItem.IdEmbalador);
            db.AddInParameter(dbCommand, "pEnPT", DbType.Boolean, pItem.EnPT);
            db.AddInParameter(dbCommand, "pCantidadBulto", DbType.Int32, pItem.CantidadBulto);


            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaEstado(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaEstado");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pRecibido", DbType.Boolean, pItem.Recibido);
            db.AddInParameter(dbCommand, "pFechaRecibido", DbType.DateTimeOffset, pItem.FechaRecibido);
            db.AddInParameter(dbCommand, "pEnPT", DbType.Boolean, pItem.EnPT);
            db.AddInParameter(dbCommand, "pFechaPT", DbType.DateTimeOffset, pItem.FechaPT);
            db.AddInParameter(dbCommand, "pRecepcionDocumento", DbType.Boolean, pItem.RecepcionDocumento);
            db.AddInParameter(dbCommand, "pFechaRD", DbType.DateTimeOffset, pItem.FechaRD);
            db.AddInParameter(dbCommand, "pDespachado", DbType.Boolean, pItem.Despachado);
            db.AddInParameter(dbCommand, "pFechaDespachado", DbType.DateTimeOffset, pItem.FechaDespachado);
            db.AddInParameter(dbCommand, "pObservacion ", DbType.String, pItem.Observacion);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaObservacion(int IdPedido, string Observacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaObservacion");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pObservacion ", DbType.String, Observacion);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaDespacho(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaDespacho");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdAgencia", DbType.Int32, pItem.IdAgencia);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdUbigeoDelivery", DbType.String, pItem.IdUbigeoDelivery);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pCantidadBulto", DbType.Int32, pItem.CantidadBulto);
            db.AddInParameter(dbCommand, "pIdPrioridad", DbType.Int32, pItem.IdPrioridad);
            db.AddInParameter(dbCommand, "pIdDestino", DbType.Int32, pItem.IdDestino);
            db.AddInParameter(dbCommand, "pIdPagoFlete", DbType.Int32, pItem.IdPagoFlete);
            db.AddInParameter(dbCommand, "pNumeroDespacho", DbType.String, pItem.NumeroDespacho);
            db.AddInParameter(dbCommand, "pFechaDespacho2 ", DbType.DateTime, pItem.FechaDespacho2);
            db.AddInParameter(dbCommand, "pClaveEnvio", DbType.String, pItem.ClaveEnvio);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pNumeroPiso", DbType.String, pItem.NumeroPiso);
            db.AddInParameter(dbCommand, "pObservacion2", DbType.String, pItem.Observacion2);
            db.AddInParameter(dbCommand, "pCambioFechaDelivery", DbType.Boolean, pItem.CambioFechaDelivery);
            db.AddInParameter(dbCommand, "pUsuarioCambioFecha", DbType.String, pItem.UsuarioCambioFecha);
            db.AddInParameter(dbCommand, "pPersonaRecoge", DbType.String, pItem.PersonaRecoge);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCantidadBulto(MovimientoPedidoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_ActualizaCantidadBulto");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pCantidadBulto", DbType.Int32, pItem.CantidadBulto);
            db.AddInParameter(dbCommand, "pPesoKg", DbType.Decimal, pItem.PesoKg);


            db.ExecuteNonQuery(dbCommand);
        }

        public List<MovimientoPedidoBE> ListaPadron(string NumeroRuc)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_BuscarRucPadron");
            db.AddInParameter(dbCommand, "pNumeroRuc", DbType.String, NumeroRuc);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoPedidoBE> MovimientoPedidolist = new List<MovimientoPedidoBE>();
            MovimientoPedidoBE MovimientoPedido;
            while (reader.Read())
            {
                MovimientoPedido = new MovimientoPedidoBE();

                MovimientoPedido.Rucp = reader["Ruc"].ToString();
                MovimientoPedido.RazonSocialP = reader["RazonSocial"].ToString();
                MovimientoPedido.EstadoContribuyentep = reader["EstadoContribuyente"].ToString();
                MovimientoPedido.CondicionDomiciliop = reader["CondicionDomicilio"].ToString();

                MovimientoPedidolist.Add(MovimientoPedido);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidolist;
        }

        public void ActualizaTotalPesoPedido(int pIdPedido, decimal pTotalPesoPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Actualizar_TotalPesoPedido");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pIdPedido);
            db.AddInParameter(dbCommand, "pTotalPesoPedido ", DbType.Decimal, pTotalPesoPedido);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<MovimientoPedidoBE> ListaDuracionProcesos(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptDuracionProcAlmacen");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            dbCommand.CommandTimeout = 250;

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoPedidoBE> MovimientoPedidolist = new List<MovimientoPedidoBE>();
            MovimientoPedidoBE MovimientoPedido;
            while (reader.Read())
            {
                MovimientoPedido = new MovimientoPedidoBE();

                MovimientoPedido.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoPedido.Numero = reader["NumPedido"].ToString();
                MovimientoPedido.FormaPago = reader["FormaPago"].ToString();
                MovimientoPedido.DescCliente = reader["DescCliente"].ToString();

                MovimientoPedido.Departamento = reader["Departamento"].ToString();
                MovimientoPedido.Provincia = reader["Provincia"].ToString();
                MovimientoPedido.Distrito = reader["Distrito"].ToString();
                MovimientoPedido.CantidadPedido = Int32.Parse(reader["TotalCantidadPedido"].ToString());
                MovimientoPedido.FechaAprobado = reader.IsDBNull(reader.GetOrdinal("FechaAprobado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaAprobado"));
                MovimientoPedido.FechaRecibido = reader.IsDBNull(reader.GetOrdinal("FechaRecepcionAlmacen")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcionAlmacen"));
                MovimientoPedido.HoraRecepcion = reader["HoraRecepcionAlmacen"].ToString();

                MovimientoPedido.DescAuxiliar = reader["Pickeador"].ToString();
                MovimientoPedido.DuracionPicking = reader["DuracionPicking"].ToString();
                MovimientoPedido.DescPersonaCalidad = reader["DescPersonaCalidad"].ToString();
                MovimientoPedido.DuracionCalidad = reader["DuracionCalidad"].ToString();
                MovimientoPedido.DescChequeador = reader["Chequeador"].ToString();
                MovimientoPedido.DuracionChequeo = reader["DuracionChequeo"].ToString();

                MovimientoPedido.DescEmbalador = reader["Embalador"].ToString();
                MovimientoPedido.DuracionEmbalado = reader["DuracionEmbalado"].ToString();

                MovimientoPedido.CantidadBulto = Int32.Parse(reader["Bultos"].ToString());
                MovimientoPedido.TotalPeso = Decimal.Parse(reader["Peso"].ToString());
                MovimientoPedido.FechaDespachado = reader.IsDBNull(reader.GetOrdinal("FechaDespachado")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespachado"));
                MovimientoPedido.Despachador = reader["Despachador"].ToString();
                MovimientoPedido.CanalVenta = reader["CanalVenta"].ToString();
                MovimientoPedido.MedioEntrega = reader["MedioEntrega"].ToString();
                MovimientoPedido.TiempoActividad = reader["TiempoActividad"].ToString();
                MovimientoPedido.TiempoEntrega = reader["TiempoEntrega"].ToString();
                MovimientoPedidolist.Add(MovimientoPedido);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidolist;
        }

        public List<MovimientoPedidoBE> CierrePedidos(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptCierrePedidos");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            //  dbCommand.CommandTimeout = 250;

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoPedidoBE> MovimientoPedidolist = new List<MovimientoPedidoBE>();
            MovimientoPedidoBE MovimientoPedido;
            while (reader.Read())
            {
                MovimientoPedido = new MovimientoPedidoBE();

                MovimientoPedido.Fecha = DateTime.Parse(reader["FechaCierrePedido"].ToString());
                MovimientoPedido.FechaDespacho2 = DateTime.Parse(reader["FechaDelivery"].ToString());

                MovimientoPedido.Numero = reader["NumeroPedido"].ToString();
                MovimientoPedido.TipoCliente = reader["TipoCliente"].ToString();
                //MovimientoPedido.FormaPago = reader["FormaPago"].ToString();
                MovimientoPedido.DescCliente = reader["Cliente"].ToString();
                MovimientoPedido.Vendedor = reader["Vendedor"].ToString();
                MovimientoPedido.DescTienda = reader["Tienda"].ToString();
                MovimientoPedido.DescMoneda = reader["Moneda"].ToString();
                MovimientoPedido.Total = Decimal.Parse(reader["Total"].ToString());
                MovimientoPedido.Estado = reader["Estado"].ToString();
                MovimientoPedido.CostoDelivery = Decimal.Parse(reader["CostoDelivery"].ToString());
                MovimientoPedido.Departamento = reader["Departamento"].ToString();
                MovimientoPedido.Provincia = reader["Provincia"].ToString();
                MovimientoPedido.Distrito = reader["Distrito"].ToString();
                MovimientoPedido.NumeroPiso = Int32.Parse(reader["NumeroPiso"].ToString());

                MovimientoPedidolist.Add(MovimientoPedido);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoPedidolist;
        }
        public void ActualizarDescuentoPorCumpleanios(int IdPedido, decimal TotalDscCumpleanios)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Pedido_ActualizarDescuentoPorCumpleanios");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);
            db.AddInParameter(dbCommand, "pTotalDscCumpleanios", DbType.Decimal, TotalDscCumpleanios);

            db.ExecuteNonQuery(dbCommand);
        }


    }
}
