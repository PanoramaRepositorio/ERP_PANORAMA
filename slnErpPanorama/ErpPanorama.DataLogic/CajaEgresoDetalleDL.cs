using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CajaEgresoDetalleDL
    {
        public CajaEgresoDetalleDL() { }
        public List<CajaEgresoDetalleBE> ListaTodosActivo(int IdCajaEgreso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, IdCajaEgreso);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoDetalleBE> CajaEgresoDetallelist = new List<CajaEgresoDetalleBE>();
            CajaEgresoDetalleBE CajaEgresoDetalle;
            while (reader.Read())
            {
                CajaEgresoDetalle = new CajaEgresoDetalleBE();

                CajaEgresoDetalle.IdCajaEgreso = Int32.Parse(reader["IdCajaEgreso"].ToString());
                CajaEgresoDetalle.IdCajaEgresoDetalle = Int32.Parse(reader["IdCajaEgresoDetalle"].ToString());
                CajaEgresoDetalle.TipoOperacion = Int32.Parse(reader["TipoOperacion"].ToString());
                CajaEgresoDetalle.Operacion =  reader["Operacion"].ToString();
                CajaEgresoDetalle.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                CajaEgresoDetalle.NumRecibo = (reader["NumRecibo"].ToString());
                CajaEgresoDetalle.TipoPersona = Int32.Parse(reader["TipoPersona"].ToString());
                CajaEgresoDetalle.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                CajaEgresoDetalle.NumDocumento = (reader["NumDocumento"].ToString());
                CajaEgresoDetalle.Recibio = (reader["Recibio"].ToString());
                CajaEgresoDetalle.Concepto = (reader["Concepto"].ToString());
                CajaEgresoDetalle.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                CajaEgresoDetalle.ImporteIngreso = Decimal.Parse(reader["ImporteIngreso"].ToString());
                CajaEgresoDetalle.ImporteEgreso = Decimal.Parse(reader["ImporteEgreso"].ToString());
                CajaEgresoDetalle.ImporteRendicion = Decimal.Parse(reader["Rendicion"].ToString());
                CajaEgresoDetalle.ImporteDevuelto = Decimal.Parse(reader["ImporteDevuelto"].ToString());
                CajaEgresoDetalle.EAdicional = Decimal.Parse(reader["EAdicional"].ToString());
                CajaEgresoDetalle.PorRendir = Decimal.Parse(reader["PorRendir"].ToString());
                CajaEgresoDetalle.Total = Decimal.Parse(reader["Total"].ToString());
                CajaEgresoDetalle.UsuarioCreacion = (reader["UsuarioCreacion"].ToString());
                CajaEgresoDetalle.FlagEstado = Int32.Parse(reader["FlagEstado"].ToString());
                CajaEgresoDetalle.FlagEAdicional = Boolean.Parse(reader["FlagEAdicional"].ToString());
                CajaEgresoDetalle.FlagRevisa = Boolean.Parse(reader["FlagRevisa"].ToString());

                CajaEgresoDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                CajaEgresoDetalle.IdTipoEgreso = Int32.Parse(reader["IdTipoEgreso"].ToString());

                CajaEgresoDetallelist.Add(CajaEgresoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return CajaEgresoDetallelist;
        }

        public Int32 Inserta(CajaEgresoDetalleBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalle_Inserta");

            db.AddOutParameter(dbCommand, "pIdCajaEgresoDetalle", DbType.Int32, pItem.IdCajaEgresoDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, pItem.IdCajaEgreso);
            db.AddInParameter(dbCommand, "pTipoOperacion", DbType.Int32, pItem.TipoOperacion);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pNumRecibo", DbType.String, pItem.NumRecibo);
            db.AddInParameter(dbCommand, "pTipoPersona", DbType.Int32, pItem.TipoPersona);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pNumDocumento", DbType.String, pItem.NumDocumento);
            db.AddInParameter(dbCommand, "pRecibio", DbType.String, pItem.Recibio);
            db.AddInParameter(dbCommand, "pConcepto", DbType.String, pItem.Concepto);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pUsuarioCreacion", DbType.String, pItem.UsuarioCreacion);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pFlagEAdicional", DbType.Boolean, pItem.FlagEAdicional);

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoEgreso", DbType.Int32, pItem.IdTipoEgreso);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdCajaEgresoDetalle");

            return Id;
        }

        public void Inserta_DocsEgresos(CajaEgresoDetalleBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalleDoc_Egresos_Inserta");

            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, pItem.IdCajaEgreso);
            db.AddInParameter(dbCommand, "pIdCajaEgresoDetalle", DbType.Int32, pItem.IdCajaEgresoDetalle);
            db.AddInParameter(dbCommand, "pIdCajaEgresoDetalleDocumentos", DbType.Int32, pItem.IdCajaEgresoDetalleDocumentos);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumRecibo", DbType.String, pItem.NumRecibo);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CajaEgresoDetalleBE> ObtenerCorrelativoPeriodo(int pIdEmpresa, int pTipoOperacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalle_NumeroRecibo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pIdEmpresa);
            db.AddInParameter(dbCommand, "pTipoOperacion", DbType.Int32, pTipoOperacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoDetalleBE> NumeracionDocumentolist = new List<CajaEgresoDetalleBE>();
            CajaEgresoDetalleBE NumeracionDocumento;
            while (reader.Read())
            {
                NumeracionDocumento = new CajaEgresoDetalleBE();
                NumeracionDocumento.Numero = Int32.Parse(reader["NumRecibo"].ToString());
                NumeracionDocumentolist.Add(NumeracionDocumento);
            }
            reader.Close();
            reader.Dispose();
            return NumeracionDocumentolist;

        }

        public List<CajaEgresoDetalleBE> ListadoPrint(int IdCajaEgresoDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalle_ListadoPrint");
            db.AddInParameter(dbCommand, "pIdCajaEgresoDetalle", DbType.Int32, IdCajaEgresoDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoDetalleBE> Reportelist = new List<CajaEgresoDetalleBE>();
            CajaEgresoDetalleBE Reporte;
            while (reader.Read())
            {
                Reporte = new CajaEgresoDetalleBE();
                Reporte.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Reporte.Empresa = reader["Empresa"].ToString();
                Reporte.Ruc = reader["Ruc"].ToString();
                Reporte.De = reader["De"].ToString();
                Reporte.TipoOperacion = Int32.Parse(reader["TipoOperacion"].ToString());
                Reporte.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Reporte.NumRecibo = reader["NumRecibo"].ToString();
                Reporte.NumDocumento = reader["NumDocumento"].ToString();
                Reporte.Recibio = reader["Recibio"].ToString();
                Reporte.Concepto = reader["Concepto"].ToString();
                Reporte.ImporteTexto = reader["ImporteTexto"].ToString();
                Reporte.Importe = Decimal.Parse(reader["Importe"].ToString());
                Reporte.Referencia = reader["Referencia"].ToString();
                Reporte.NombreCaja = reader["NombreCaja"].ToString();
                Reportelist.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Reportelist;
        }

        public List<CajaEgresoDetalleBE> BuscaNumEgreso(string pNumEgreso, int pIdCajaEgreso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalle_BuscaNumEgreso");
            db.AddInParameter(dbCommand, "pNumEgreso", DbType.String, pNumEgreso);
            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, pIdCajaEgreso);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoDetalleBE> Reportelist = new List<CajaEgresoDetalleBE>();
            CajaEgresoDetalleBE Reporte;
            while (reader.Read())
            {
                Reporte = new CajaEgresoDetalleBE();

                Reporte.TipoPersona = Int32.Parse(reader["TipoPersona"].ToString());
                Reporte.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                Reporte.NumDocumento = reader["NumDocumento"].ToString();
                Reporte.Recibio = reader["Recibio"].ToString();
                //Reporte.FlagEstado = Int32.Parse(reader["FlagEstado"].ToString());

                Reportelist.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Reportelist;
        }

        public void Inserta(CajaEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgreso_Inserta");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pFecApertura", DbType.DateTime, pItem.FecApertura);
            db.AddInParameter(dbCommand, "pSaldoInicial", DbType.Decimal, pItem.SaldoInicial);
            db.AddInParameter(dbCommand, "pUsuarioCreacion", DbType.String, pItem.UsuarioCreacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CajaEgresoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdCajaEgresoDetalle", DbType.Int32, pItem.IdCajaEgresoDetalle);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaRevisa(CajaEgresoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Actualiza_RevisaCajaEgresoDetalle");

            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, pItem.IdCajaEgreso);
            db.AddInParameter(dbCommand, "pIdCajaEgresoDetalle", DbType.Int32, pItem.IdCajaEgresoDetalle);

            db.ExecuteNonQuery(dbCommand);
        }


        public void Elimina(CajaEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_Elimina");

            //db.AddInParameter(dbCommand, "pIdCajaCierre", DbType.Int32, pItem.IdCajaCierre);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaFecha(CajaEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_EliminaFecha");

            //db.AddInParameter(dbCommand, "pFecha ", DbType.DateTime, pItem.Fecha);
            //db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<CajaEgresoBE> ListaTodosActivo(DateTime pFecDesde, DateTime pFecHasta, int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgreso_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, pFecDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, pFecHasta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoBE> CajaCierrelist = new List<CajaEgresoBE>();
            CajaEgresoBE CajaEgreso;
            while (reader.Read())
            {
                CajaEgreso = new CajaEgresoBE();
                CajaEgreso.IdCajaEgreso = Int32.Parse(reader["IdCajaEgreso"].ToString());
                CajaEgreso.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaEgreso.NombreEmpresa = reader["NombreEmpresa"].ToString();
                CajaEgreso.NumCaja =  reader["NumCaja"].ToString();
                CajaEgreso.NombreCaja = reader["NombreCaja"].ToString();
                CajaEgreso.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                CajaEgreso.DescMoneda = reader["Moneda"].ToString();
                CajaEgreso.FecApertura = DateTime.Parse(reader["FecApertura"].ToString());
                CajaEgreso.FecCierre = reader.IsDBNull(reader.GetOrdinal("FecCierre")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FecCierre")); //DateTime.Parse(reader["FecCierre"].ToString());
                CajaEgreso.SaldoInicial = Decimal.Parse(reader["SaldoInicial"].ToString());
                CajaEgreso.Situacion = reader["Situacion"].ToString();
                CajaEgreso.UsuarioCreacion = reader["UsuarioCreacion"].ToString();
                CajaCierrelist.Add(CajaEgreso);
            }
            reader.Close();
            reader.Dispose();
            return CajaCierrelist;
        }

        public List<CajaEgresoBE> ListaFechaCaja(DateTime FechaDesde, DateTime FechaHasta, int IdCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaCierre_ListaFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoBE> CajaCierrelist = new List<CajaEgresoBE>();
            CajaEgresoBE CajaCierre;
            while (reader.Read())
            {
                CajaCierre = new CajaEgresoBE();
                //CajaCierre.IdCajaCierre = Int32.Parse(reader["IdCajaCierre"].ToString());
                //CajaCierre.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                //CajaCierre.DescTienda = reader["DescTienda"].ToString();
                //CajaCierre.IdCaja = Int32.Parse(reader["IdCaja"].ToString());
                //CajaCierre.DescCaja = reader["DescCaja"].ToString();
                //CajaCierre.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                //CajaCierre.TotalVisa = Int32.Parse(reader["TotalVisa"].ToString());
                //CajaCierre.TotalMastercard = Int32.Parse(reader["TotalMastercard"].ToString());
                //CajaCierre.Usuario = reader["Usuario"].ToString();
                //CajaCierre.Maquina = reader["Maquina"].ToString();
                //CajaCierre.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CajaCierrelist.Add(CajaCierre);
            }
            reader.Close();
            reader.Dispose();
            return CajaCierrelist;
        }

        public List<CajaEgresoDetalleBE> ListaTodosEgresos(int pIdCajaEgreso, int pIdCajaEgresoDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgreso_ListaTodosEgresos");
            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, pIdCajaEgreso);
            db.AddInParameter(dbCommand, "pIdCajaEgresoDetalle", DbType.Int32, pIdCajaEgresoDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoDetalleBE> CajaCierrelist = new List<CajaEgresoDetalleBE>();
            CajaEgresoDetalleBE CajaEgresoDetalle;
            while (reader.Read())
            {
                CajaEgresoDetalle = new CajaEgresoDetalleBE();
                CajaEgresoDetalle.IdCajaEgreso = Int32.Parse(reader["IdCajaEgreso"].ToString());
                CajaEgresoDetalle.IdCajaEgresoDetalle = Int32.Parse(reader["IdCajaEgresoDetalle"].ToString());
                CajaEgresoDetalle.NumRecibo = reader["NumRecibo"].ToString();
                CajaEgresoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                CajaEgresoDetalle.DescMoneda = reader["DescMoneda"].ToString();
                CajaEgresoDetalle.Importe = Decimal.Parse(reader["Importe"].ToString());

                CajaCierrelist.Add(CajaEgresoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return CajaCierrelist;
        }

        //public void InsertaEgresos(CajaEgresoDetalleBE pItem)
        //{
        //    Int32 Id = 0;
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalle_Inserta");

        //    db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, pItem.IdCajaEgreso);
        //    db.AddInParameter(dbCommand, "pIdCajaEgresoDetalle", DbType.Int32, pItem.IdCajaEgresoDetalle);
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
        //    db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
        //    db.AddInParameter(dbCommand, "pNumRecibo", DbType.String, pItem.NumRecibo);
        //    db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);

        //    db.ExecuteNonQuery(dbCommand);
        //}


    }
}
