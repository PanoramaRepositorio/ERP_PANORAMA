using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TransferenciaBultoDL
    {
        public TransferenciaBultoDL() { }

        public Int32 Inserta(TransferenciaBultoBE pItem)
        {
            Int32 intIdTransferenciaBulto = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TransferenciaBulto_Inserta");

            db.AddOutParameter(dbCommand, "pIdTransferenciaBulto", DbType.Int32, pItem.IdTransferenciaBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFechaMovimiento", DbType.DateTime, pItem.FechaMovimiento);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, pItem.IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdAlmacenDestino", DbType.Int32, pItem.IdAlmacenDestino);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenIngreso", DbType.Int32, pItem.IdMovimientoAlmacenIngreso);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenSalida", DbType.Int32, pItem.IdMovimientoAlmacenSalida);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);

            intIdTransferenciaBulto = (int)db.GetParameterValue(dbCommand, "pIdTransferenciaBulto");

            return intIdTransferenciaBulto;
        }

        public void Actualiza(TransferenciaBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TransferenciaBulto_Actualiza");

            db.AddInParameter(dbCommand, "pIdTransferenciaBulto", DbType.Int32, pItem.IdTransferenciaBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pFechaMovimiento", DbType.DateTime, pItem.FechaMovimiento);
            db.AddInParameter(dbCommand, "pIdAlmacenOrigen", DbType.Int32, pItem.IdAlmacenOrigen);
            db.AddInParameter(dbCommand, "pIdAlmacenDestino", DbType.Int32, pItem.IdAlmacenDestino);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenIngreso", DbType.Int32, pItem.IdMovimientoAlmacenIngreso);
            db.AddInParameter(dbCommand, "pIdMovimientoAlmacenSalida", DbType.Int32, pItem.IdMovimientoAlmacenSalida);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);

            
        }

        public void Elimina(TransferenciaBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TransferenciaBulto_Elimina");

            db.AddInParameter(dbCommand, "pIdTransferenciaBulto", DbType.Int32, pItem.IdTransferenciaBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TransferenciaBultoBE> ListaTodosActivo(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TransferenciaBulto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TransferenciaBultoBE> TransferenciaBultolist = new List<TransferenciaBultoBE>();
            TransferenciaBultoBE TransferenciaBulto;
            while (reader.Read())
            {
                TransferenciaBulto = new TransferenciaBultoBE();
                TransferenciaBulto.IdTransferenciaBulto = Int32.Parse(reader["idTransferenciaBulto"].ToString());
                TransferenciaBulto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TransferenciaBulto.Periodo = Int32.Parse(reader["periodo"].ToString());
                TransferenciaBulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                TransferenciaBulto.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                TransferenciaBulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                TransferenciaBulto.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                TransferenciaBulto.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                TransferenciaBulto.AlmacenOrigen = reader["AlmacenOrigen"].ToString();
                TransferenciaBulto.IdAlmacenDestino = Int32.Parse(reader["IdAlmacenDestino"].ToString());
                TransferenciaBulto.AlmacenDestino = reader["AlmacenDestino"].ToString();
                TransferenciaBulto.Observacion = reader["Observacion"].ToString();
                TransferenciaBulto.IdMovimientoAlmacenIngreso = Int32.Parse(reader["IdMovimientoAlmacenIngreso"].ToString());
                TransferenciaBulto.NumeroDocumentoIngreso = reader["NumeroDocumentoIngreso"].ToString();
                TransferenciaBulto.IdMovimientoAlmacenSalida = Int32.Parse(reader["IdMovimientoAlmacenSalida"].ToString());
                TransferenciaBulto.NumeroDocumentoSalida = reader["NumeroDocumentoSalida"].ToString();
                TransferenciaBulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TransferenciaBultolist.Add(TransferenciaBulto);
            }
            reader.Close();
            reader.Dispose();
            return TransferenciaBultolist;
        }

        public TransferenciaBultoBE Selecciona(int IdEmpresa, int IdTransferenciaBulto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TransferenciaBulto_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTransferenciaBulto", DbType.Int32, IdTransferenciaBulto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TransferenciaBultoBE TransferenciaBulto = null;
            while (reader.Read())
            {
                TransferenciaBulto = new TransferenciaBultoBE();
                TransferenciaBulto.IdTransferenciaBulto = Int32.Parse(reader["idTransferenciaBulto"].ToString());
                TransferenciaBulto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TransferenciaBulto.Periodo = Int32.Parse(reader["periodo"].ToString());
                TransferenciaBulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                TransferenciaBulto.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                TransferenciaBulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                TransferenciaBulto.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                TransferenciaBulto.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                TransferenciaBulto.AlmacenOrigen = reader["AlmacenOrigen"].ToString();
                TransferenciaBulto.IdAlmacenDestino = Int32.Parse(reader["IdAlmacenDestino"].ToString());
                TransferenciaBulto.AlmacenDestino = reader["AlmacenDestino"].ToString();
                TransferenciaBulto.Observacion = reader["Observacion"].ToString();
                TransferenciaBulto.IdMovimientoAlmacenIngreso = Int32.Parse(reader["IdMovimientoAlmacenIngreso"].ToString());
                TransferenciaBulto.NumeroDocumentoIngreso = reader["NumeroDocumentoIngreso"].ToString();
                TransferenciaBulto.IdMovimientoAlmacenSalida = Int32.Parse(reader["IdMovimientoAlmacenSalida"].ToString());
                TransferenciaBulto.NumeroDocumentoSalida = reader["NumeroDocumentoSalida"].ToString();
                TransferenciaBulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TransferenciaBulto;
        }

        public List<TransferenciaBultoBE> SeleccionaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TransferenciaBulto_SeleccionaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TransferenciaBultoBE> TransferenciaBultolist = new List<TransferenciaBultoBE>();
            TransferenciaBultoBE TransferenciaBulto;
            while (reader.Read())
            {
                TransferenciaBulto = new TransferenciaBultoBE();
                TransferenciaBulto.IdTransferenciaBulto = Int32.Parse(reader["idTransferenciaBulto"].ToString());
                TransferenciaBulto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TransferenciaBulto.Periodo = Int32.Parse(reader["periodo"].ToString());
                TransferenciaBulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                TransferenciaBulto.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                TransferenciaBulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                TransferenciaBulto.FechaMovimiento = DateTime.Parse(reader["FechaMovimiento"].ToString());
                TransferenciaBulto.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                TransferenciaBulto.AlmacenOrigen = reader["AlmacenOrigen"].ToString();
                TransferenciaBulto.IdAlmacenDestino = Int32.Parse(reader["IdAlmacenDestino"].ToString());
                TransferenciaBulto.AlmacenDestino = reader["AlmacenDestino"].ToString();
                TransferenciaBulto.Observacion = reader["Observacion"].ToString();
                TransferenciaBulto.IdMovimientoAlmacenIngreso = Int32.Parse(reader["IdMovimientoAlmacenIngreso"].ToString());
                TransferenciaBulto.NumeroDocumentoIngreso = reader["NumeroDocumentoIngreso"].ToString();
                TransferenciaBulto.IdMovimientoAlmacenSalida = Int32.Parse(reader["IdMovimientoAlmacenSalida"].ToString());
                TransferenciaBulto.NumeroDocumentoSalida = reader["NumeroDocumentoSalida"].ToString();
                TransferenciaBulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TransferenciaBultolist.Add(TransferenciaBulto);
            }
            reader.Close();
            reader.Dispose();
            return TransferenciaBultolist;
        }
    }
}
