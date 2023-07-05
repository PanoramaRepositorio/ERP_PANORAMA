using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class SolicitudPrestamoDetalleDL
    {
        public SolicitudPrestamoDetalleDL() { }

        public void Inserta(SolicitudPrestamoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamoDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdSolicitudPrestamoDetalle", DbType.Int32, pItem.IdSolicitudPrestamoDetalle);
            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, pItem.IdSolicitudPrestamo);
            db.AddInParameter(dbCommand, "pNumeroCuota", DbType.Int32, pItem.NumeroCuota);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pCapital", DbType.Decimal, pItem.Capital);
            db.AddInParameter(dbCommand, "pInteres", DbType.Decimal, pItem.Interes);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(SolicitudPrestamoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamoDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdSolicitudPrestamoDetalle", DbType.Int32, pItem.IdSolicitudPrestamoDetalle);
            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, pItem.IdSolicitudPrestamo);
            db.AddInParameter(dbCommand, "pNumeroCuota", DbType.Int32, pItem.NumeroCuota);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaPago", DbType.DateTime, pItem.FechaPago);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pCapital", DbType.Decimal, pItem.Capital);
            db.AddInParameter(dbCommand, "pInteres", DbType.Decimal, pItem.Interes);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pTipoMovimiento", DbType.String, pItem.TipoMovimiento);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(SolicitudPrestamoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamoDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdSolicitudPrestamoDetalle", DbType.Int32, pItem.IdSolicitudPrestamoDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<SolicitudPrestamoDetalleBE> ListaTodosActivo(int IdSolicitudPrestamo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamoDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdSolicitudPrestamo", DbType.Int32, IdSolicitudPrestamo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudPrestamoDetalleBE> SolicitudPrestamoDetallelist = new List<SolicitudPrestamoDetalleBE>();
            SolicitudPrestamoDetalleBE SolicitudPrestamoDetalle;
            while (reader.Read())
            {
                SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleBE();
                SolicitudPrestamoDetalle.IdSolicitudPrestamo = Int32.Parse(reader["IdSolicitudPrestamo"].ToString());
                SolicitudPrestamoDetalle.IdSolicitudPrestamoDetalle = Int32.Parse(reader["IdSolicitudPrestamoDetalle"].ToString());
                SolicitudPrestamoDetalle.NumeroCuota = Int32.Parse(reader["NumeroCuota"].ToString());
                SolicitudPrestamoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudPrestamoDetalle.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                SolicitudPrestamoDetalle.Concepto = reader["Concepto"].ToString();
                SolicitudPrestamoDetalle.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                //SolicitudPrestamoDetalle.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                SolicitudPrestamoDetalle.Capital = Decimal.Parse(reader["Capital"].ToString());
                SolicitudPrestamoDetalle.Interes = Decimal.Parse(reader["Interes"].ToString());
                SolicitudPrestamoDetalle.Importe = Decimal.Parse(reader["Importe"].ToString());
                SolicitudPrestamoDetalle.TipoMovimiento = reader["TipoMovimiento"].ToString();
                SolicitudPrestamoDetalle.Usuario = reader["Usuario"].ToString();
                SolicitudPrestamoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                SolicitudPrestamoDetallelist.Add(SolicitudPrestamoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudPrestamoDetallelist;
        }

        public List<SolicitudPrestamoDetalleBE> ListaPersona(DateTime FechaDesde, DateTime FechaHasta, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudPrestamoDetalle_ListaPersona");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudPrestamoDetalleBE> SolicitudPrestamoDetallelist = new List<SolicitudPrestamoDetalleBE>();
            SolicitudPrestamoDetalleBE SolicitudPrestamoDetalle;
            while (reader.Read())
            {
                SolicitudPrestamoDetalle = new SolicitudPrestamoDetalleBE();
                SolicitudPrestamoDetalle.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudPrestamoDetalle.NumeroDocumento = reader["NumeroDocumento"].ToString();
                SolicitudPrestamoDetalle.NumeroCuota = Int32.Parse(reader["NumeroCuota"].ToString());
                SolicitudPrestamoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                SolicitudPrestamoDetalle.FechaPago = reader.IsDBNull(reader.GetOrdinal("FechaPago")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPago"));
                SolicitudPrestamoDetalle.Concepto = reader["Concepto"].ToString();
                SolicitudPrestamoDetalle.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                SolicitudPrestamoDetalle.TipoMovimiento = reader["TipoMovimiento"].ToString();
                SolicitudPrestamoDetalle.Cargo = Decimal.Parse(reader["PrestamoCargo"].ToString());
                SolicitudPrestamoDetalle.Abono = Decimal.Parse(reader["PagoAbono"].ToString());
                SolicitudPrestamoDetalle.Saldo = Decimal.Parse(reader["Saldo"].ToString());
                SolicitudPrestamoDetalle.Usuario = reader["Usuario"].ToString();
                SolicitudPrestamoDetallelist.Add(SolicitudPrestamoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudPrestamoDetallelist;
        }


    }
}
