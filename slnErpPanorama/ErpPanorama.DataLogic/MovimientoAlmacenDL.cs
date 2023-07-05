using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MovimientoAlmacenDL
    {
        public MovimientoAlmacenDL() { }

        public Int32 Inserta(MovimientoAlmacenBE pItem)
        {
            Int32 intIdMovimientoAlmacen = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_Inserta");

            db.AddOutParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, pItem.IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaDelivery", DbType.DateTime, pItem.FechaDelivery);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, pItem.IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pObservaciones", DbType.String, pItem.Observaciones);
            db.AddInParameter(dbCommand, "pIdAlmacenDestino", DbType.Int32, pItem.IdAlmacenDestino);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenReferencia", DbType.Int32, pItem.IdMovimientoAlmacenReferencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pBultos", DbType.Int32, pItem.Bultos);

            db.AddInParameter(dbCommand, "pIdCausalTransferencia", DbType.Int32, pItem.IdCausalTransferencia);
            db.AddInParameter(dbCommand, "pDocReferencia", DbType.String, pItem.DocReferencia);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);

            db.ExecuteNonQuery(dbCommand);

            intIdMovimientoAlmacen = (int)db.GetParameterValue(dbCommand, "pIdMovimientoAlmacen");

            return intIdMovimientoAlmacen;
        }

        public void Actualiza(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_Actualiza");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, pItem.IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaDelivery", DbType.DateTime, pItem.FechaDelivery);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, pItem.IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pObservaciones", DbType.String, pItem.Observaciones);
            db.AddInParameter(dbCommand, "pIdAlmacenDestino", DbType.Int32, pItem.IdAlmacenDestino);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenReferencia", DbType.Int32, pItem.IdMovimientoAlmacenReferencia);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pBultos", DbType.Int32, pItem.Bultos);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_Elimina");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pObservacionElimina", DbType.String, pItem.ObservacionElimina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public MovimientoAlmacenBE Selecciona(int IdEmpresa, int IdMovimientoAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdMovimientoAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoAlmacenBE MovimientoAlmacen = null;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCliente"));
                MovimientoAlmacen.IdSolicitudProducto = reader.IsDBNull(reader.GetOrdinal("IdSolicitudProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSolicitudProducto"));
                MovimientoAlmacen.IdMovimientoAlmacenReferencia = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenReferencia"));
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                MovimientoAlmacen.FechaDelivery = reader.IsDBNull(reader.GetOrdinal("FechaDelivery")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDelivery"));
                MovimientoAlmacen.IdAuxiliar = Int32.Parse(reader["IdAuxiliar"].ToString());
                MovimientoAlmacen.IdChequeador = Int32.Parse(reader["IdChequeador"].ToString());
                MovimientoAlmacen.IdEmbalador = Int32.Parse(reader["IdEmbalador"].ToString());
                MovimientoAlmacen.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                MovimientoAlmacen.FlagChequeoFinalizado = Boolean.Parse(reader["FlagChequeoFinalizado"].ToString());
                MovimientoAlmacen.Preparado = Boolean.Parse(reader["Preparado"].ToString());
                MovimientoAlmacen.Bultos = Int32.Parse(reader["Bultos"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacen;
        }


        public MovimientoAlmacenBE SelUpdBultos(int IdEmpresa, int IdMovimientoAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_SelUpdBultos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdMovimientoAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoAlmacenBE MovimientoAlmacen = null;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["IdMovimientoAlmacen"].ToString());
                MovimientoAlmacen.FlagUpd = Boolean.Parse(reader["FlagUpd"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacen;
        }



        public List<MovimientoAlmacenBE> ListaTodosActivo(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.Estado = reader["estado"].ToString();
                MovimientoAlmacen.FlagRevision = Boolean.Parse(reader["FlagRevision"].ToString());
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.FlagRecibidoFisico = Boolean.Parse(reader["FlagRecibidoFisico"].ToString());
                MovimientoAlmacen.FechaDelivery = reader.IsDBNull(reader.GetOrdinal("FechaDelivery")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDelivery"));

                MovimientoAlmacen.FlagDespachado = Boolean.Parse(reader["FlagDespachado"].ToString());

                MovimientoAlmacen.FechaDespachado = reader.IsDBNull(reader.GetOrdinal("FechaDespachado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespachado"));
                MovimientoAlmacen.IdMovimientoAlmacenReferencia = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenReferencia"));
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();
                MovimientoAlmacen.UsuarioRecibidoFisico = reader["UsuarioRecibidoFisico"].ToString();
                MovimientoAlmacen.PersonaPicking = reader["PersonaPicking"].ToString();
                MovimientoAlmacen.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoAlmacen.UsuarioElimina = reader["UsuarioElimina"].ToString();
                MovimientoAlmacen.ObservacionElimina = reader["ObservacionElimina"].ToString();
                MovimientoAlmacen.Bultos = Int32.Parse(reader["Bultos"].ToString());

                MovimientoAlmacen.UsuarioUpdBultos = reader["UsuarioUpdBultos"].ToString();

                MovimientoAlmacen.Causal = reader["Causal"].ToString();
                MovimientoAlmacen.DocReferencia = reader["DocReferencia"].ToString();

                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public List<MovimientoAlmacenBE> ListaCodigo(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ListaCodigo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.FlagRecibidoFisico = Boolean.Parse(reader["FlagRecibidoFisico"].ToString());
                MovimientoAlmacen.FechaDelivery = reader.IsDBNull(reader.GetOrdinal("FechaDelivery")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDelivery"));
                MovimientoAlmacen.FlagDespachado = Boolean.Parse(reader["FlagDespachado"].ToString());
                MovimientoAlmacen.FechaDespachado = reader.IsDBNull(reader.GetOrdinal("FechaDespachado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDespachado"));
                MovimientoAlmacen.IdMovimientoAlmacenReferencia = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenReferencia"));
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();
                MovimientoAlmacen.UsuarioRecibidoFisico = reader["UsuarioRecibidoFisico"].ToString();
                MovimientoAlmacen.PersonaPicking = reader["PersonaPicking"].ToString();
                MovimientoAlmacen.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                MovimientoAlmacen.UsuarioElimina = reader["UsuarioElimina"].ToString();

                MovimientoAlmacen.Causal = reader["Causal"].ToString();
                MovimientoAlmacen.DocReferencia = reader["DocReferencia"].ToString();

                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public List<MovimientoAlmacenBE> ListaPendientes(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento, DateTime FecInicio, DateTime FecFin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ListaPendientes");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.Date, FecInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.Date, FecFin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.FlagDespachado = Boolean.Parse(reader["FlagDespachado"].ToString());
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();
                MovimientoAlmacen.DescTienda = reader["Tienda"].ToString();
                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public List<MovimientoAlmacenBE> ListaPendientesDetalle(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento, DateTime FecInicio, DateTime FecFin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ListaPendientesDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.Date, FecInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.Date, FecFin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.FlagDespachado = Boolean.Parse(reader["FlagDespachado"].ToString());
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();
                MovimientoAlmacen.DescTienda = reader["Tienda"].ToString();

                MovimientoAlmacen.Items = Int32.Parse(reader["Item"].ToString());
                MovimientoAlmacen.IdProducto  = Int32.Parse(reader["IdProducto"].ToString());
                MovimientoAlmacen.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacen.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacen.Abreviatura= reader["UM"].ToString();
                MovimientoAlmacen.Cantidad = Int32.Parse(reader["Cantidad"].ToString());

                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public MovimientoAlmacenBE SeleccionaTipoDocumento(int IdEmpresa, int IdTipoDocumento, int IdDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_SeleccionaTipoDocumento");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdDocumento", DbType.Int32, IdDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MovimientoAlmacenBE MovimientoAlmacen = null;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCliente"));
                MovimientoAlmacen.IdSolicitudProducto = reader.IsDBNull(reader.GetOrdinal("IdSolicitudProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSolicitudProducto"));
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                MovimientoAlmacen.IdAuxiliar = Int32.Parse(reader["IdAuxiliar"].ToString());
                MovimientoAlmacen.IdChequeador = Int32.Parse(reader["IdChequeador"].ToString());
                MovimientoAlmacen.IdEmbalador = Int32.Parse(reader["IdEmbalador"].ToString());
                MovimientoAlmacen.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacen;
        }

        public List<MovimientoAlmacenBE> SeleccionaNumero(int IdEmpresa, int Periodo, int Mes, int IdAlmacenOrigen, int IdTipoMovimiento, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.IdCliente = reader.IsDBNull(reader.GetOrdinal("IdCliente")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdCliente"));
                MovimientoAlmacen.IdSolicitudProducto = reader.IsDBNull(reader.GetOrdinal("IdSolicitudProducto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdSolicitudProducto"));
                MovimientoAlmacen.IdMovimientoAlmacenReferencia = reader.IsDBNull(reader.GetOrdinal("IdMovimientoAlmacenReferencia")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdMovimientoAlmacenReferencia"));
                MovimientoAlmacen.FlagRevision = Boolean.Parse(reader["FlagRevision"].ToString());
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.FlagRecibidoFisico = Boolean.Parse(reader["FlagRecibidoFisico"].ToString());
                MovimientoAlmacen.FlagDespachado = Boolean.Parse(reader["FlagDespachado"].ToString());
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();
                MovimientoAlmacen.Preparacion = Boolean.Parse(reader["Preparacion"].ToString());
                MovimientoAlmacen.FechaPreparacion = reader.IsDBNull(reader.GetOrdinal("FechaPreparacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparacion"));
                MovimientoAlmacen.Preparado = Boolean.Parse(reader["Preparado"].ToString());
                MovimientoAlmacen.FechaPreparado = reader.IsDBNull(reader.GetOrdinal("FechaPreparado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparado"));
                MovimientoAlmacen.FlagEmbalaje = Boolean.Parse(reader["FlagEmbalaje"].ToString());
                MovimientoAlmacen.FechaEmbalaje = reader.IsDBNull(reader.GetOrdinal("FechaEmbalaje")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmbalaje"));
                MovimientoAlmacen.FlagEmbalado = Boolean.Parse(reader["FlagEmbalado"].ToString());
                MovimientoAlmacen.FechaEmbalado = reader.IsDBNull(reader.GetOrdinal("FechaEmbalado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmbalado"));
                MovimientoAlmacen.FechaDelivery = reader.IsDBNull(reader.GetOrdinal("FechaDelivery")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDelivery"));
                MovimientoAlmacen.UsuarioElimina = reader["UsuarioElimina"].ToString();
                MovimientoAlmacen.IdAuxiliar = Int32.Parse(reader["IdAuxiliar"].ToString());
                MovimientoAlmacen.IdEmbalador = Int32.Parse(reader["IdEmbalador"].ToString());
                MovimientoAlmacen.Estado = reader["estado"].ToString();
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.Bultos = Int32.Parse(reader["Bultos"].ToString());

                MovimientoAlmacen.UsuarioUpdBultos = reader["UsuarioUpdBultos"].ToString();

                MovimientoAlmacen.Causal =  reader["Causal"].ToString();
                MovimientoAlmacen.DocReferencia = reader["DocReferencia"].ToString();

                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public List<MovimientoAlmacenBE> ListaNotaSalidaMotivo(int IdEmpresa, int IdAlmacenOrigen, int IdMotivo, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ListaNotaSalidaMotivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, IdMotivo);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public List<MovimientoAlmacenBE> ListaDetalle(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int IdAlmacenOrigen, int IdTipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ListaDetalle");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.CodigoProveedor = reader["CodigoProveedor"].ToString();
                MovimientoAlmacen.NombreProducto = reader["NombreProducto"].ToString();
                MovimientoAlmacen.Abreviatura = reader["Abreviatura"].ToString();
                MovimientoAlmacen.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                MovimientoAlmacen.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                MovimientoAlmacen.MontoTotal = Decimal.Parse(reader["MontoTotal"].ToString());
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public List<MovimientoAlmacenBE> ListaFechaChequeo(DateTime FechaDesde, DateTime FechaHasta,int IdTipoMovimiento, int TipoConsulta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ListaFechaChequeado");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pTipoConsulta", DbType.Int32, TipoConsulta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();
                //MovimientoAlmacen.FechaChequeo = DateTime.Parse(reader["FechaChequeo"].ToString());
                MovimientoAlmacen.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                MovimientoAlmacen.Items = Int32.Parse(reader["Items"].ToString());
                MovimientoAlmacen.TotalCantidad = Int32.Parse(reader["TotalCantidad"].ToString());
                MovimientoAlmacen.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                MovimientoAlmacen.PorcentajeChequeo = Decimal.Parse(reader["PorcentajeChequeo"].ToString());
                MovimientoAlmacen.DescPicking = reader["DescPicking"].ToString();
                MovimientoAlmacen.DescChequeador = reader["DescChequeador"].ToString();
                MovimientoAlmacen.DescEmbalador = reader["DescEmbalador"].ToString();
                MovimientoAlmacen.FechaPreparacion = reader.IsDBNull(reader.GetOrdinal("FechaPreparacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparacion"));
                MovimientoAlmacen.FechaPreparado = reader.IsDBNull(reader.GetOrdinal("FechaPreparado")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPreparado"));
                MovimientoAlmacen.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());

                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public List<MovimientoAlmacenBE> ListaNumeroChequeo(int Periodo, string Numero, int IdTipoMovimiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_SeleccionaNumeroChequeo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, IdTipoMovimiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();

                MovimientoAlmacen.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTimeOffset?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                MovimientoAlmacen.Items = Int32.Parse(reader["Items"].ToString());
                MovimientoAlmacen.TotalCantidad = Int32.Parse(reader["TotalCantidad"].ToString());
                MovimientoAlmacen.CantidadChequeo = Int32.Parse(reader["CantidadChequeo"].ToString());
                MovimientoAlmacen.PorcentajeChequeo = Decimal.Parse(reader["PorcentajeChequeo"].ToString());
                MovimientoAlmacen.DescPicking = reader["DescPicking"].ToString();
                MovimientoAlmacen.DescChequeador = reader["DescChequeador"].ToString();
                MovimientoAlmacen.DescEmbalador = reader["DescEmbalador"].ToString();
                MovimientoAlmacen.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());

                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public List<MovimientoAlmacenBE> ListaNotaSalidaPendientePedido(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ListaNotaSalidaPendientePedido");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.FlagRecibidoFisico = Boolean.Parse(reader["FlagRecibidoFisico"].ToString());
                MovimientoAlmacen.FechaDelivery = reader.IsDBNull(reader.GetOrdinal("FechaDelivery")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDelivery"));
                MovimientoAlmacen.DescSituacionPedido = reader["DescSituacionPedido"].ToString();
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();

                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public List<MovimientoAlmacenBE> ListaNotaSalidaPedido(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ListaNotaSalidaPedido");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MovimientoAlmacenBE> MovimientoAlmacenlist = new List<MovimientoAlmacenBE>();
            MovimientoAlmacenBE MovimientoAlmacen;
            while (reader.Read())
            {
                MovimientoAlmacen = new MovimientoAlmacenBE();
                MovimientoAlmacen.IdMovimientoAlmacen = Int32.Parse(reader["idMovimientoAlmacen"].ToString());
                MovimientoAlmacen.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MovimientoAlmacen.Periodo = Int32.Parse(reader["periodo"].ToString());
                MovimientoAlmacen.Numero = reader["Numero"].ToString();
                MovimientoAlmacen.IdTipoMovimiento = Int32.Parse(reader["IdTipoMovimiento"].ToString());
                MovimientoAlmacen.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                MovimientoAlmacen.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                MovimientoAlmacen.DescAlmacen = reader["DescAlmacen"].ToString();
                MovimientoAlmacen.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                MovimientoAlmacen.DescMotivo = reader["DescMotivo"].ToString();
                MovimientoAlmacen.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                MovimientoAlmacen.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                MovimientoAlmacen.NumeroDocumento = reader["NumeroDocumento"].ToString();
                MovimientoAlmacen.Referencia = reader["Referencia"].ToString();
                MovimientoAlmacen.Observaciones = reader["Observaciones"].ToString();
                MovimientoAlmacen.IdAlmacenDestino = reader.IsDBNull(reader.GetOrdinal("IdAlmacenDestino")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAlmacenDestino"));
                MovimientoAlmacen.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                MovimientoAlmacen.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MovimientoAlmacen.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                MovimientoAlmacen.FlagRecibidoFisico = Boolean.Parse(reader["FlagRecibidoFisico"].ToString());
                MovimientoAlmacen.FechaDelivery = reader.IsDBNull(reader.GetOrdinal("FechaDelivery")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDelivery"));
                MovimientoAlmacen.DescSituacionPedido = reader["DescSituacionPedido"].ToString();
                MovimientoAlmacen.Usuario = reader["Usuario"].ToString();

                MovimientoAlmacenlist.Add(MovimientoAlmacen);
            }
            reader.Close();
            reader.Dispose();
            return MovimientoAlmacenlist;
        }

        public void ActualizaAuxiliar(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaAuxiliar");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdAuxiliar", DbType.Int32, pItem.IdAuxiliar);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaChequeador(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaChequeador");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdChequeador", DbType.Int32, pItem.IdChequeador);
            db.AddInParameter(dbCommand, "pFlagChequeoFinalizado", DbType.Boolean, pItem.FlagChequeoFinalizado);
            

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaEmbalador(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaEmbalador");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdEmbalador", DbType.Int32, pItem.IdEmbalador);
            db.AddInParameter(dbCommand, "pCantidadBulto", DbType.Int32, pItem.CantidadBulto);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCierrePicking(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaCierrePicking");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdAuxiliar", DbType.Int32, pItem.IdAuxiliar);
            db.AddInParameter(dbCommand, "pPreparado", DbType.Boolean, pItem.Preparado);
            db.AddInParameter(dbCommand, "pFlagCierre", DbType.Boolean, pItem.FlagCierre);

            db.ExecuteNonQuery(dbCommand);
        }
        public void ActualizaCierreChequeo(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaCierreChequeo");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdChequeador", DbType.Int32, pItem.IdChequeador);
            db.AddInParameter(dbCommand, "pFlagChequeo", DbType.Boolean, pItem.FlagChequeo);
            db.AddInParameter(dbCommand, "pFlagCierre", DbType.Boolean, pItem.FlagCierre);

            db.ExecuteNonQuery(dbCommand);
        }


        public void ActualizaCierreEmbalaje(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaCierreEmbalaje");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdEmbalador", DbType.Int32, pItem.IdEmbalador);
            db.AddInParameter(dbCommand, "pFlagEmbalado", DbType.Boolean, pItem.FlagEmbalado);
            db.AddInParameter(dbCommand, "pCantidadBulto", DbType.Int32, pItem.CantidadBulto);
            db.AddInParameter(dbCommand, "pFlagCierre", DbType.Boolean, pItem.FlagCierre);

            db.ExecuteNonQuery(dbCommand);
        }
        public void ActualizaCantidadBulto(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaCantidadBulto");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pCantidadBulto", DbType.Int32, pItem.CantidadBulto);

            db.ExecuteNonQuery(dbCommand);
        }


        public void CopiarDatosEnvio(int IdPedidoOrigen, int IdPedidoDestino)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoPedido_CopiarDespacho");

            db.AddInParameter(dbCommand, "pIdPedidoOrigen", DbType.Int32, IdPedidoOrigen);
            db.AddInParameter(dbCommand, "pIdPedidoDestino", DbType.Int32, IdPedidoDestino);

            db.ExecuteNonQuery(dbCommand);
        }



        public void ActualizaSalidaEntrada(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaSalidaEntrada");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenDetalle", DbType.Int32, pItem.IdMovimientoAlmacenDetalle);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, pItem.IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, pItem.IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pObservaciones", DbType.String, pItem.Observaciones);
            db.AddInParameter(dbCommand, "pIdAlmacenDestino", DbType.Int32, pItem.IdAlmacenDestino);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCantidadAnterior", DbType.Int32, pItem.CantidadAnterior);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);
        }

        public Int32 InsertaSalidaEntrada(MovimientoAlmacenBE pItem)
        {
            Int32 intIdMovimientoAlmacenDetalle = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_InsertaSalidaEntrada");

            db.AddOutParameter(dbCommand, "pIdMovimientoAlmacenDetalle", DbType.Int32, pItem.IdMovimientoAlmacenDetalle);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdTipoMovimiento", DbType.Int32, pItem.IdTipoMovimiento);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, pItem.IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pObservaciones", DbType.String, pItem.Observaciones);
            db.AddInParameter(dbCommand, "pIdAlmacenDestino", DbType.Int32, pItem.IdAlmacenDestino);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);
            intIdMovimientoAlmacenDetalle = (int)db.GetParameterValue(dbCommand, "pIdMovimientoAlmacenDetalle");

            return intIdMovimientoAlmacenDetalle;

        }

        public void ActualizaFechaDelivery(MovimientoAlmacenBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaFechaDelivery");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, pItem.IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pFechaDelivery", DbType.DateTime, pItem.FechaDelivery);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaRecibidoFisico(int IdMovimientoAlmacen, bool FlagRecibidoFisico, string UsuarioRecibidoFisico)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaRecibidoFisico");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pFlagRecibidoFisico", DbType.Boolean, FlagRecibidoFisico);
            db.AddInParameter(dbCommand, "pUsuarioRecibidoFisico", DbType.String, UsuarioRecibidoFisico);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaRecibido(int IdMovimientoAlmacen, bool FlagRecibido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaRecibido");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, FlagRecibido);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaDespachado(int IdMovimientoAlmacen, bool FlagDespachado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaDespachado");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pFlagDespachado", DbType.Boolean, FlagDespachado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaRevision(int IdMovimientoAlmacen, bool FlagRevision, string UsuarioRevision)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaRevision");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdMovimientoAlmacen);
            db.AddInParameter(dbCommand, "pFlagRevision", DbType.Boolean, FlagRevision);
            db.AddInParameter(dbCommand, "pUsuarioRevision", DbType.String, UsuarioRevision);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizarBultosNS(int IdNotaPedido, int NroBultos, string pUsuario, int pIdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MovimientoAlmacen_ActualizaBultos");

            db.AddInParameter(dbCommand, "pIdMovimientoAlmacen", DbType.Int32, IdNotaPedido);
            db.AddInParameter(dbCommand, "pNroBultos", DbType.Int32, NroBultos);
            db.AddInParameter(dbCommand, "pUsuarioUpdBultos", DbType.String, pUsuario);
            db.AddInParameter(dbCommand, "pIdPersonaUpdBultos", DbType.Int32, pIdPersona);

            db.ExecuteNonQuery(dbCommand);
        }


    }
}
