using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class SolicitudProductoDL
    {
        public SolicitudProductoDL() { }

        public Int32 Inserta(SolicitudProductoBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_Inserta");

            db.AddOutParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFechaSolicitud", DbType.DateTime, pItem.FechaSolicitud);
            db.AddInParameter(dbCommand, "pIdSolicitante", DbType.Int32, pItem.IdSolicitante);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, pItem.IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdTiendaDestino", DbType.Int32, pItem.IdTiendaDestino);
            db.AddInParameter(dbCommand, "pIdAlmacenDestino", DbType.Int32, pItem.IdAlmacenDestino);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFechaEnvio", DbType.DateTime, pItem.FechaEnvio);
            db.AddInParameter(dbCommand, "pFlagEnviado", DbType.Boolean, pItem.FlagEnviado);
            db.AddInParameter(dbCommand, "pFechaImpresion", DbType.DateTime, pItem.FechaImpresion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.AddInParameter(dbCommand, "pIdCausalTransferencia", DbType.Int32, pItem.IdCausalTransferencia);
            db.AddInParameter(dbCommand, "pDocReferencia", DbType.String, pItem.DocReferencia);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdSolicitudProducto");

            return intIdCliente;
        }

        public void Actualiza(SolicitudProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_Actualiza");

            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFechaSolicitud", DbType.DateTime, pItem.FechaSolicitud);
            db.AddInParameter(dbCommand, "pIdSolicitante", DbType.Int32, pItem.IdSolicitante);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, pItem.IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdTiendaDestino", DbType.Int32, pItem.IdTiendaDestino);
            db.AddInParameter(dbCommand, "pIdAlmacenDestino", DbType.Int32, pItem.IdAlmacenDestino);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFechaEnvio", DbType.DateTime, pItem.FechaEnvio);
            db.AddInParameter(dbCommand, "pFlagEnviado", DbType.Boolean, pItem.FlagEnviado);
            db.AddInParameter(dbCommand, "pFechaImpresion", DbType.DateTime, pItem.FechaImpresion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.AddInParameter(dbCommand, "pIdCausalTransferencia", DbType.Int32, pItem.IdCausalTransferencia);
            db.AddInParameter(dbCommand, "pDocReferencia", DbType.String, pItem.DocReferencia);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaEnvio(SolicitudProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_ActualizaEnvio");

            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pFlagEnviado", DbType.Boolean, pItem.FlagEnviado);
           
            db.ExecuteNonQuery(dbCommand);
        }
        public void ActualizaRecibido(SolicitudProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_ActualizaRecibido");

            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaFechaImpresion(SolicitudProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_ActualizaFechaImpresion");

            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(SolicitudProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_Elimina");

            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public SolicitudProductoBE Selecciona(int IdEmpresa, int IdSolicitudProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, IdSolicitudProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudProductoBE SolicitudProducto = null;
            while (reader.Read())
            {
                SolicitudProducto = new SolicitudProductoBE();
                SolicitudProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                SolicitudProducto.IdSolicitudProducto = Int32.Parse(reader["idSolicitudProducto"].ToString());
                SolicitudProducto.Periodo = Int32.Parse(reader["periodo"].ToString());
                SolicitudProducto.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                SolicitudProducto.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudProducto.Numero = reader["numero"].ToString();
                SolicitudProducto.FechaSolicitud = DateTime.Parse(reader["fechaSolicitud"].ToString());
                SolicitudProducto.IdSolicitante = Int32.Parse(reader["idSolicitante"].ToString());
                SolicitudProducto.Solicitante = reader["Solicitante"].ToString();
                SolicitudProducto.IdTiendaOrigen = Int32.Parse(reader["IdTiendaOrigen"].ToString());
                SolicitudProducto.IdAlmacenOrigen = Int32.Parse(reader["idAlmacenOrigen"].ToString());
                SolicitudProducto.DescAlmacen = reader["descAlmacen"].ToString();
                SolicitudProducto.IdTiendaDestino = Int32.Parse(reader["IdTiendaDestino"].ToString());
                SolicitudProducto.DescTiendaDestino = reader["DescTiendaDestino"].ToString();
                SolicitudProducto.IdAlmacenDestino = Int32.Parse(reader["IdAlmacenDestino"].ToString());
                SolicitudProducto.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                SolicitudProducto.Observacion = reader["observacion"].ToString();
                SolicitudProducto.FechaEnvio = reader.IsDBNull(reader.GetOrdinal("FechaEnvio")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEnvio"));
                SolicitudProducto.FlagEnviado = Boolean.Parse(reader["FlagEnviado"].ToString());
                SolicitudProducto.FechaImpresion = reader.IsDBNull(reader.GetOrdinal("FechaImpresion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaImpresion"));
                SolicitudProducto.FechaDelivery = reader.IsDBNull(reader.GetOrdinal("FechaDelivery")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDelivery"));
                SolicitudProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

                SolicitudProducto.IdCausalTransferencia = Int32.Parse(reader["IdCausalTransferencia"].ToString());
                SolicitudProducto.DocReferencia = reader["DocReferencia"].ToString();
                SolicitudProducto.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProducto;
        }

        public SolicitudProductoBE SeleccionaVendedor(int Periodo, String DocReferencia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_SeleccionaVendedor");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pDocReferencia", DbType.String, DocReferencia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudProductoBE SolicitudProducto = null;
            while (reader.Read())
            {
                SolicitudProducto = new SolicitudProductoBE();
                SolicitudProducto.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProducto;
        }

        public SolicitudProductoBE SeleccionaProductos(int Periodo, String DocReferencia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_SeleccionaVendedor");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pDocReferencia", DbType.String, DocReferencia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudProductoBE SolicitudProducto = null;
            while (reader.Read())
            {
                SolicitudProducto = new SolicitudProductoBE();
                SolicitudProducto.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProducto;
        }

        public SolicitudProductoBE SeleccionaNumero(int IdEmpresa, int Periodo, int IdTipoDocumento, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudProductoBE SolicitudProducto = null;
            while (reader.Read())
            {
                SolicitudProducto = new SolicitudProductoBE();
                SolicitudProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                SolicitudProducto.IdSolicitudProducto = Int32.Parse(reader["idSolicitudProducto"].ToString());
                SolicitudProducto.Periodo = Int32.Parse(reader["periodo"].ToString());
                SolicitudProducto.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                SolicitudProducto.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudProducto.Numero = reader["numero"].ToString();
                SolicitudProducto.FechaSolicitud = DateTime.Parse(reader["fechaSolicitud"].ToString());
                SolicitudProducto.IdSolicitante = Int32.Parse(reader["idSolicitante"].ToString());
                SolicitudProducto.Solicitante = reader["Solicitante"].ToString();
                SolicitudProducto.IdAlmacenOrigen = Int32.Parse(reader["idAlmacenOrigen"].ToString());
                SolicitudProducto.DescAlmacen = reader["descAlmacen"].ToString();
                SolicitudProducto.IdTiendaDestino = Int32.Parse(reader["IdTiendaDestino"].ToString());
                SolicitudProducto.DescTiendaDestino = reader["DescTiendaDestino"].ToString();
                SolicitudProducto.IdAlmacenDestino = Int32.Parse(reader["IdAlmacenDestino"].ToString());
                SolicitudProducto.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                SolicitudProducto.Observacion = reader["observacion"].ToString();
                SolicitudProducto.FechaEnvio = reader.IsDBNull(reader.GetOrdinal("FechaEnvio")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEnvio"));
                SolicitudProducto.FlagEnviado = Boolean.Parse(reader["FlagEnviado"].ToString());
                SolicitudProducto.FechaImpresion = reader.IsDBNull(reader.GetOrdinal("FechaImpresion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaImpresion"));
                SolicitudProducto.DescAuxiliar = reader["DescAuxiliar"].ToString();
                SolicitudProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudProducto.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProducto;
        }

        public List<SolicitudProductoBE> ListaTodosActivo(int IdEmpresa,  int Periodo, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudProductoBE> SolicitudProductolist = new List<SolicitudProductoBE>();
            SolicitudProductoBE SolicitudProducto;
            while (reader.Read())
            {
                SolicitudProducto = new SolicitudProductoBE();
                SolicitudProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                SolicitudProducto.IdSolicitudProducto = Int32.Parse(reader["idSolicitudProducto"].ToString());
                SolicitudProducto.Periodo = Int32.Parse(reader["periodo"].ToString());
                SolicitudProducto.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                SolicitudProducto.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                SolicitudProducto.Numero = reader["numero"].ToString();
                SolicitudProducto.FechaSolicitud = DateTime.Parse(reader["fechaSolicitud"].ToString());
                SolicitudProducto.IdSolicitante = Int32.Parse(reader["idSolicitante"].ToString());
                SolicitudProducto.Solicitante = reader["Solicitante"].ToString();
                SolicitudProducto.IdTiendaOrigen = Int32.Parse(reader["IdTiendaOrigen"].ToString());
                SolicitudProducto.IdAlmacenOrigen = Int32.Parse(reader["idAlmacenOrigen"].ToString());
                SolicitudProducto.DescAlmacen = reader["descAlmacen"].ToString();
                SolicitudProducto.IdTiendaDestino = Int32.Parse(reader["IdTiendaDestino"].ToString());
                SolicitudProducto.DescTiendaDestino = reader["DescTiendaDestino"].ToString();
                SolicitudProducto.IdAlmacenDestino = Int32.Parse(reader["IdAlmacenDestino"].ToString());
                SolicitudProducto.DescAlmacenDestino = reader["DescAlmacenDestino"].ToString();
                SolicitudProducto.Observacion = reader["observacion"].ToString();
                SolicitudProducto.FechaEnvio = reader.IsDBNull(reader.GetOrdinal("FechaEnvio")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEnvio"));
                SolicitudProducto.FlagEnviado = Boolean.Parse(reader["FlagEnviado"].ToString());
                SolicitudProducto.FechaRecibido = reader.IsDBNull(reader.GetOrdinal("FechaRecibido")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecibido"));
                SolicitudProducto.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                SolicitudProducto.FechaPicking = reader.IsDBNull(reader.GetOrdinal("FechaPicking")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPicking"));
                SolicitudProducto.PickingNS = Boolean.Parse(reader["PickingNS"].ToString());
                SolicitudProducto.NumeroNS = reader["NumeroNS"].ToString();
                SolicitudProducto.FechaDelivery = reader.IsDBNull(reader.GetOrdinal("FechaDelivery")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDelivery"));
                SolicitudProducto.FechaImpresion = reader.IsDBNull(reader.GetOrdinal("FechaImpresion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaImpresion"));
                SolicitudProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

                SolicitudProducto.Usuario = reader["Usuario"].ToString();
                SolicitudProducto.Causal = reader["Causal"].ToString();

                SolicitudProductolist.Add(SolicitudProducto);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProductolist;
        }

        public void ActualizaAuxiliar(SolicitudProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProducto_ActualizaAuxiliar");

            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pIdAuxiliar", DbType.Int32, pItem.IdAuxiliar);

            db.ExecuteNonQuery(dbCommand);
        }

        public SolicitudProductoBE SeleccionaSolProdPendiente(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ListadoSolPendiente");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudProductoBE SolicitudProducto = null;
            while (reader.Read())
            {
                SolicitudProducto = new SolicitudProductoBE();
                SolicitudProducto.SolPendientes = Int32.Parse(reader["SolPendientes"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProducto;
        }


    }
}

