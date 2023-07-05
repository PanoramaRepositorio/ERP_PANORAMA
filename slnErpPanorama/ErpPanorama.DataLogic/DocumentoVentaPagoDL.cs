using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DocumentoVentaPagoDL
    {
        public void Inserta(DocumentoVentaPagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaPago_Inserta");

            db.AddInParameter(dbCommand, "pIdDocumentoVentaPago", DbType.Int32, pItem.IdDocumentoVentaPago);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdCondicionPago", DbType.Int32, pItem.IdCondicionPago);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, pItem.IdEstadoCuentaCliente);
            db.AddInParameter(dbCommand, "pGrupoPago", DbType.String, pItem.GrupoPago);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(DocumentoVentaPagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaPago_Actualiza");

            db.AddInParameter(dbCommand, "pIdDocumentoVentaPago", DbType.Int32, pItem.IdDocumentoVentaPago);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdCondicionPago", DbType.Int32, pItem.IdCondicionPago);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, pItem.IdEstadoCuentaCliente);
            db.AddInParameter(dbCommand, "pGrupoPago", DbType.String, pItem.GrupoPago);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaSerieNumero(int IdDocumentoVenta, string Serie, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaPago_ActualizaNumeroSerie");

            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pSerie", DbType.String, Serie);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(DocumentoVentaPagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaPago_Elimina");

            db.AddInParameter(dbCommand, "pIdDocumentoVentaPago", DbType.Int32, pItem.IdDocumentoVentaPago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DocumentoVentaPagoBE> ListaTodosActivo(int IdEmpresa, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaPago_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaPagoBE> DocumentoVentaPagolist = new List<DocumentoVentaPagoBE>();
            DocumentoVentaPagoBE DocumentoVentaPago;
            while (reader.Read())
            {
                DocumentoVentaPago = new DocumentoVentaPagoBE();
                DocumentoVentaPago.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVentaPago.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVentaPago.IdDocumentoVentaPago = Int32.Parse(reader["idDocumentoVentaPago"].ToString());
                DocumentoVentaPago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                DocumentoVentaPago.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                DocumentoVentaPago.CodTipoDocumento =reader["CodTipoDocumento"].ToString();
                DocumentoVentaPago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVentaPago.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                DocumentoVentaPago.DescCondicionPago = reader["DescCondicionPago"].ToString();
                DocumentoVentaPago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                DocumentoVentaPago.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVentaPago.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                DocumentoVentaPago.Importe = Decimal.Parse(reader["Importe"].ToString());
                DocumentoVentaPago.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVentaPago.IdEstadoCuentaCliente = reader.IsDBNull(reader.GetOrdinal("IdEstadoCuentaCliente")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdEstadoCuentaCliente"));
                DocumentoVentaPago.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                DocumentoVentaPago.TipoOper = 4; //Consultar
                DocumentoVentaPagolist.Add(DocumentoVentaPago);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaPagolist;
        }

        public List<DocumentoVentaPagoBE> ListaGrupoPago(int IdEmpresa, string GrupoPago, int IdEstadoCuentaCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaPago_ListaGrupoPago");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pGrupoPago", DbType.String, GrupoPago);
            db.AddInParameter(dbCommand, "pIdEstadoCuentaCliente", DbType.Int32, IdEstadoCuentaCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaPagoBE> DocumentoVentaPagolist = new List<DocumentoVentaPagoBE>();
            DocumentoVentaPagoBE DocumentoVentaPago;
            while (reader.Read())
            {
                DocumentoVentaPago = new DocumentoVentaPagoBE();
                DocumentoVentaPago.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoVentaPago.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVentaPago.IdDocumentoVentaPago = Int32.Parse(reader["idDocumentoVentaPago"].ToString());
                DocumentoVentaPago.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                DocumentoVentaPago.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                DocumentoVentaPago.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                DocumentoVentaPago.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DocumentoVentaPago.IdCondicionPago = Int32.Parse(reader["IdCondicionPago"].ToString());
                DocumentoVentaPago.DescCondicionPago = reader["DescCondicionPago"].ToString();
                DocumentoVentaPago.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                DocumentoVentaPago.CodMoneda = reader["CodMoneda"].ToString();
                DocumentoVentaPago.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                DocumentoVentaPago.Importe = Decimal.Parse(reader["Importe"].ToString());
                DocumentoVentaPago.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                DocumentoVentaPago.TipoOper = 4; //Consultar
                DocumentoVentaPagolist.Add(DocumentoVentaPago);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaPagolist;
        }

    }
}
