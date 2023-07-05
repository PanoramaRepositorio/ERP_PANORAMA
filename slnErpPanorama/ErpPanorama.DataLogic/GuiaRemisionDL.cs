using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class GuiaRemisionDL
    {
        public GuiaRemisionDL() { }

        public Int32 Inserta(GuiaRemisionBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemision_Inserta");

            db.AddOutParameter(dbCommand, "pIdGuiaRemision", DbType.Int32, pItem.IdGuiaRemision);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTiendaRemitente", DbType.Int32, pItem.IdTiendaRemitente);
            db.AddInParameter(dbCommand, "pIdEmpresaDestinatario", DbType.Int32, pItem.IdEmpresaDestinatario);
            db.AddInParameter(dbCommand, "pIdTiendaDestinatario", DbType.Int32, pItem.IdTiendaDestinatario);
            db.AddInParameter(dbCommand, "pDescTransportista", DbType.String, pItem.DescTransportista);
            db.AddInParameter(dbCommand, "pRucTransportista", DbType.String, pItem.RucTransportista);
            db.AddInParameter(dbCommand, "pNumeroLicencia", DbType.String, pItem.NumeroLicencia);
            db.AddInParameter(dbCommand, "pDescVehiculo", DbType.String, pItem.DescVehiculo);
            db.AddInParameter(dbCommand, "pNumeroPlaca", DbType.String, pItem.NumeroPlaca);
            db.AddInParameter(dbCommand, "pIdTipoDocumentoReferencia", DbType.Int32, pItem.IdTipoDocumentoReferencia);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdGuiaRemision");

            return intIdCliente;
        }

        public void Actualiza(GuiaRemisionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemision_Actualiza");

            db.AddInParameter(dbCommand, "pIdGuiaRemision", DbType.Int32, pItem.IdGuiaRemision);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTiendaRemitente", DbType.Int32, pItem.IdTiendaRemitente);
            db.AddInParameter(dbCommand, "pIdEmpresaDestinatario", DbType.Int32, pItem.IdEmpresaDestinatario);
            db.AddInParameter(dbCommand, "pIdTiendaDestinatario", DbType.Int32, pItem.IdTiendaDestinatario);
            db.AddInParameter(dbCommand, "pDescTransportista", DbType.String, pItem.DescTransportista);
            db.AddInParameter(dbCommand, "pRucTransportista", DbType.String, pItem.RucTransportista);
            db.AddInParameter(dbCommand, "pNumeroLicencia", DbType.String, pItem.NumeroLicencia);
            db.AddInParameter(dbCommand, "pDescVehiculo", DbType.String, pItem.DescVehiculo);
            db.AddInParameter(dbCommand, "pNumeroPlaca", DbType.String, pItem.NumeroPlaca);
            db.AddInParameter(dbCommand, "pIdTipoDocumentoReferencia", DbType.Int32, pItem.IdTipoDocumentoReferencia);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(GuiaRemisionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemision_Elimina");

            db.AddInParameter(dbCommand, "pIdGuiaRemision", DbType.Int32, pItem.IdGuiaRemision);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public GuiaRemisionBE Selecciona(int IdEmpresa, int IdGuiaRemision)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemision_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdGuiaRemision", DbType.Int32, IdGuiaRemision);

            IDataReader reader = db.ExecuteReader(dbCommand);
            GuiaRemisionBE GuiaRemision = null;
            while (reader.Read())
            {
                GuiaRemision = new GuiaRemisionBE();
                GuiaRemision.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                GuiaRemision.IdGuiaRemision = Int32.Parse(reader["idGuiaRemision"].ToString());
                GuiaRemision.RazonSocialRemitente = reader["RazonSocialRemitente"].ToString();
                GuiaRemision.Periodo = Int32.Parse(reader["periodo"].ToString());
                GuiaRemision.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                GuiaRemision.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                GuiaRemision.Serie = reader["Serie"].ToString();
                GuiaRemision.Numero = reader["numero"].ToString();
                GuiaRemision.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                GuiaRemision.IdTiendaRemitente = Int32.Parse(reader["IdTiendaRemitente"].ToString());
                GuiaRemision.TiendaRemitente = reader["TiendaRemitente"].ToString();
                GuiaRemision.DireccionRemitente = reader["DireccionRemitente"].ToString();
                GuiaRemision.IdEmpresaDestinatario = Int32.Parse(reader["IdEmpresaDestinatario"].ToString());
                GuiaRemision.RazonSocialDestinatario = reader["RazonSocialRemitente"].ToString();
                GuiaRemision.IdTiendaDestinatario = Int32.Parse(reader["IdTiendaDestinatario"].ToString());
                GuiaRemision.TiendaDestinatario = reader["TiendaDestinatario"].ToString();
                GuiaRemision.DireccionDestinatario = reader["DireccionDestinatario"].ToString();
                GuiaRemision.DescTransportista = reader["DescTransportista"].ToString();
                GuiaRemision.RucTransportista = reader["RucTransportista"].ToString();
                GuiaRemision.NumeroLicencia = reader["NumeroLicencia"].ToString();
                GuiaRemision.DescVehiculo = reader["DescVehiculo"].ToString();
                GuiaRemision.NumeroPlaca = reader["NumeroPlaca"].ToString();
                GuiaRemision.IdTipoDocumentoReferencia = Int32.Parse(reader["IdTipoDocumentoReferencia"].ToString());
                GuiaRemision.CodTipoDocumentoReferencia = reader["CodTipoDocumentoReferencia"].ToString();
                GuiaRemision.NumeroDocumento = reader["NumeroDocumento"].ToString();
                GuiaRemision.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                GuiaRemision.DescMotivo = reader["DescMotivo"].ToString();
                GuiaRemision.Observacion = reader["observacion"].ToString();
                GuiaRemision.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return GuiaRemision;
        }

        public GuiaRemisionBE SeleccionaNumero(int IdEmpresa, int Periodo, int IdTipoDocumento, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemision_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            GuiaRemisionBE GuiaRemision = null;
            while (reader.Read())
            {
                GuiaRemision = new GuiaRemisionBE();
                GuiaRemision.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                GuiaRemision.IdGuiaRemision = Int32.Parse(reader["idGuiaRemision"].ToString());
                GuiaRemision.RazonSocialRemitente = reader["RazonSocialRemitente"].ToString();
                GuiaRemision.Periodo = Int32.Parse(reader["periodo"].ToString());
                GuiaRemision.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                GuiaRemision.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                GuiaRemision.Serie = reader["Serie"].ToString();
                GuiaRemision.Numero = reader["numero"].ToString();
                GuiaRemision.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                GuiaRemision.IdTiendaRemitente = Int32.Parse(reader["IdTiendaRemitente"].ToString());
                GuiaRemision.TiendaRemitente = reader["TiendaRemitente"].ToString();
                GuiaRemision.DireccionRemitente = reader["DireccionRemitente"].ToString();
                GuiaRemision.IdEmpresaDestinatario = Int32.Parse(reader["IdEmpresaDestinatario"].ToString());
                GuiaRemision.RazonSocialDestinatario = reader["RazonSocialRemitente"].ToString();
                GuiaRemision.IdTiendaDestinatario = Int32.Parse(reader["IdTiendaDestinatario"].ToString());
                GuiaRemision.TiendaDestinatario = reader["TiendaDestinatario"].ToString();
                GuiaRemision.DireccionDestinatario = reader["DireccionDestinatario"].ToString();
                GuiaRemision.DescTransportista = reader["DescTransportista"].ToString();
                GuiaRemision.RucTransportista = reader["RucTransportista"].ToString();
                GuiaRemision.NumeroLicencia = reader["NumeroLicencia"].ToString();
                GuiaRemision.DescVehiculo = reader["DescVehiculo"].ToString();
                GuiaRemision.NumeroPlaca = reader["NumeroPlaca"].ToString();
                GuiaRemision.IdTipoDocumentoReferencia = Int32.Parse(reader["IdTipoDocumentoReferencia"].ToString());
                GuiaRemision.CodTipoDocumentoReferencia = reader["CodTipoDocumentoReferencia"].ToString();
                GuiaRemision.NumeroDocumento = reader["NumeroDocumento"].ToString();
                GuiaRemision.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                GuiaRemision.DescMotivo = reader["DescMotivo"].ToString();
                GuiaRemision.Observacion = reader["observacion"].ToString();
                GuiaRemision.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return GuiaRemision;
        }

        public List<GuiaRemisionBE> ListaTodosActivo(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemision_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<GuiaRemisionBE> GuiaRemisionlist = new List<GuiaRemisionBE>();
            GuiaRemisionBE GuiaRemision;
            while (reader.Read())
            {
                GuiaRemision = new GuiaRemisionBE();
                GuiaRemision.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                GuiaRemision.IdGuiaRemision = Int32.Parse(reader["idGuiaRemision"].ToString());
                GuiaRemision.RazonSocialRemitente = reader["RazonSocialRemitente"].ToString();
                GuiaRemision.Periodo = Int32.Parse(reader["periodo"].ToString());
                GuiaRemision.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                GuiaRemision.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                GuiaRemision.Serie = reader["Serie"].ToString();
                GuiaRemision.Numero = reader["numero"].ToString();
                GuiaRemision.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                GuiaRemision.IdTiendaRemitente = Int32.Parse(reader["IdTiendaRemitente"].ToString());
                GuiaRemision.TiendaRemitente = reader["TiendaRemitente"].ToString();
                GuiaRemision.DireccionRemitente = reader["DireccionRemitente"].ToString();
                GuiaRemision.IdEmpresaDestinatario = Int32.Parse(reader["IdEmpresaDestinatario"].ToString());
                GuiaRemision.RazonSocialDestinatario = reader["RazonSocialRemitente"].ToString();
                GuiaRemision.IdTiendaDestinatario = Int32.Parse(reader["IdTiendaDestinatario"].ToString());
                GuiaRemision.TiendaDestinatario = reader["TiendaDestinatario"].ToString();
                GuiaRemision.DireccionDestinatario = reader["DireccionDestinatario"].ToString();
                GuiaRemision.DescTransportista = reader["DescTransportista"].ToString();
                GuiaRemision.RucTransportista = reader["RucTransportista"].ToString();
                GuiaRemision.NumeroLicencia = reader["NumeroLicencia"].ToString();
                GuiaRemision.DescVehiculo = reader["DescVehiculo"].ToString();
                GuiaRemision.NumeroPlaca = reader["NumeroPlaca"].ToString();
                GuiaRemision.IdTipoDocumentoReferencia = Int32.Parse(reader["IdTipoDocumentoReferencia"].ToString());
                GuiaRemision.CodTipoDocumentoReferencia = reader["CodTipoDocumentoReferencia"].ToString();
                GuiaRemision.NumeroDocumento = reader["NumeroDocumento"].ToString();
                GuiaRemision.IdMotivo = Int32.Parse(reader["IdMotivo"].ToString());
                GuiaRemision.DescMotivo = reader["DescMotivo"].ToString();
                GuiaRemision.Observacion = reader["observacion"].ToString();
                GuiaRemision.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                GuiaRemisionlist.Add(GuiaRemision);
            }
            reader.Close();
            reader.Dispose();
            return GuiaRemisionlist;
        }
    }
    
}
