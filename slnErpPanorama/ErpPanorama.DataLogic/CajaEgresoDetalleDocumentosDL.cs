using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CajaEgresoDetalleDocumentosDL
    {
        public CajaEgresoDetalleDocumentosDL() { }
        public List<CajaEgresoDetalleDocumentosBE> ListaTodosActivo(int IdCajaEgresoDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalleDocumentos_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCajaEgresoDetalle", DbType.Int32, IdCajaEgresoDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoDetalleDocumentosBE> CajaEgresoDetalleDocumentoslist = new List<CajaEgresoDetalleDocumentosBE>();
            CajaEgresoDetalleDocumentosBE CajaEgresoDetalleDocumentos;
            while (reader.Read())
            {
                CajaEgresoDetalleDocumentos = new CajaEgresoDetalleDocumentosBE();

                CajaEgresoDetalleDocumentos.IdCajaEgresoDetalle = Int32.Parse(reader["IdCajaEgresoDetalle"].ToString());
                CajaEgresoDetalleDocumentos.IdCajaEgresoDetalleDocumentos = Int32.Parse(reader["IdCajaEgresoDetalleDocumentos"].ToString());
                CajaEgresoDetalleDocumentos.Fecha = reader.IsDBNull(reader.GetOrdinal("FechaRegistro")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRegistro"));
                CajaEgresoDetalleDocumentos.IdArea = Int32.Parse((reader["IdArea"].ToString()));
                CajaEgresoDetalleDocumentos.Area = (reader["Area"].ToString());

                CajaEgresoDetalleDocumentos.NumDocProv = (reader["NumDocProv"].ToString());
                CajaEgresoDetalleDocumentos.DescProv = (reader["DescProv"].ToString());

                CajaEgresoDetalleDocumentos.FechaFactura = reader.IsDBNull(reader.GetOrdinal("FechaFactura")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaFactura"));
                CajaEgresoDetalleDocumentos.Descripcion = (reader["Descripcion"].ToString());

                CajaEgresoDetalleDocumentos.Moneda = (reader["Moneda"].ToString());

                CajaEgresoDetalleDocumentos.DescTipoDocumento = (reader["DescTipoDocumento"].ToString());
                CajaEgresoDetalleDocumentos.NumeroFactura = (reader["NumeroFactura"].ToString());
                CajaEgresoDetalleDocumentos.ImporteFactura = Decimal.Parse(reader["ImporteFactura"].ToString());
                CajaEgresoDetalleDocumentos.ImporteCuarta = Decimal.Parse(reader["ImporteCuarta"].ToString());
                CajaEgresoDetalleDocumentos.ImporteDetraccion = Decimal.Parse(reader["ImporteDetraccion"].ToString());

                CajaEgresoDetalleDocumentos.IdTienda = Int32.Parse((reader["IdTienda"].ToString()));
                CajaEgresoDetalleDocumentos.DescTienda = (reader["DescTienda"].ToString());

                CajaEgresoDetalleDocumentos.IdTipoEgreso = Int32.Parse((reader["IdTipoEgreso"].ToString()));
                CajaEgresoDetalleDocumentos.DescTipoEgreso = (reader["DescTipoEgreso"].ToString());

                CajaEgresoDetalleDocumentoslist.Add(CajaEgresoDetalleDocumentos);
            }
            reader.Close();
            reader.Dispose();
            return CajaEgresoDetalleDocumentoslist;
        }

        public List<CajaEgresoDetalleDocumentosBE> ListaTodosActivoDocumentos(int IdCajaEgreso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalleDocumentos_ListaResumen");
            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, IdCajaEgreso);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoDetalleDocumentosBE> CajaEgresoDetalleDocumentoslist = new List<CajaEgresoDetalleDocumentosBE>();
            CajaEgresoDetalleDocumentosBE CajaEgresoDetalleDocumentos;
            while (reader.Read())
            {
                CajaEgresoDetalleDocumentos = new CajaEgresoDetalleDocumentosBE();

                CajaEgresoDetalleDocumentos.NumRecIndice = reader["NumRecIndice"].ToString();
                CajaEgresoDetalleDocumentos.NumRecibo = reader["numrecibo"].ToString();
                CajaEgresoDetalleDocumentos.Fecha = reader.IsDBNull(reader.GetOrdinal("fecha")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("fecha"));
                CajaEgresoDetalleDocumentos.Recibio = reader["recibio"].ToString();
                CajaEgresoDetalleDocumentos.MontoEgreso2 = reader.IsDBNull(reader.GetOrdinal("montoegreso")) ? (Decimal?)null : reader.GetDecimal(reader.GetOrdinal("montoegreso")); // Decimal.Parse(reader["montoegreso"].ToString());
                CajaEgresoDetalleDocumentos.ImporteDevuelto2 = reader.IsDBNull(reader.GetOrdinal("Devolucion")) ? (Decimal?)null : reader.GetDecimal(reader.GetOrdinal("Devolucion"));   //Decimal.Parse(reader["Devolucion"].ToString());
                CajaEgresoDetalleDocumentos.ImporteAdicional2 = reader.IsDBNull(reader.GetOrdinal("EAdicional")) ? (Decimal?)null : reader.GetDecimal(reader.GetOrdinal("EAdicional"));   //Decimal.Parse(reader["EAdicional"].ToString());

                CajaEgresoDetalleDocumentos.CentroCosto = (reader["CentroCosto"].ToString());
                CajaEgresoDetalleDocumentos.Area = (reader["Area"].ToString());
                CajaEgresoDetalleDocumentos.DescTipoDocumento = (reader["TipoDocumento"].ToString());
                CajaEgresoDetalleDocumentos.SerieFactura = (reader["Seriefactura"].ToString());
                CajaEgresoDetalleDocumentos.NumeroFactura = (reader["numerofactura"].ToString());
                CajaEgresoDetalleDocumentos.FechaFactura = reader.IsDBNull(reader.GetOrdinal("FechaEmision")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmision"));  // DateTime.Parse(reader["FechaEmision"].ToString());
                CajaEgresoDetalleDocumentos.NumDocProv = (reader["RucDni"].ToString());
                CajaEgresoDetalleDocumentos.DescProv = (reader["RazonSocial"].ToString());
                CajaEgresoDetalleDocumentos.Concepto = (reader["Concepto"].ToString());
                CajaEgresoDetalleDocumentos.DescMoneda = (reader["Moneda"].ToString());
                CajaEgresoDetalleDocumentos.ImporteFactura = Decimal.Parse(reader["importefactura"].ToString());

                CajaEgresoDetalleDocumentoslist.Add(CajaEgresoDetalleDocumentos);
            }
            reader.Close();
            reader.Dispose();
            return CajaEgresoDetalleDocumentoslist;
        }

        public List<CajaEgresoDetalleDocumentosBE> ListaTodosActivoEgresos(int IdCajaEgreso, int IdCajaEgresoDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Listado_CajaEgresoDetalleDocumentos_Egresos");
            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, IdCajaEgreso);
            db.AddInParameter(dbCommand, "pIdCajaEgresoDetalle", DbType.Int32, IdCajaEgresoDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CajaEgresoDetalleDocumentosBE> CajaEgresoDetalleDocumentoslist = new List<CajaEgresoDetalleDocumentosBE>();
            CajaEgresoDetalleDocumentosBE CajaEgresoDetalleDocumentos;
            while (reader.Read())
            {
                CajaEgresoDetalleDocumentos = new CajaEgresoDetalleDocumentosBE();

                CajaEgresoDetalleDocumentos.IdCajaEgreso = Int32.Parse(reader["IdCajaEgreso"].ToString());
                CajaEgresoDetalleDocumentos.IdCajaEgresoDetalle = Int32.Parse(reader["IdCajaEgresoDetalle"].ToString());
                CajaEgresoDetalleDocumentos.IdCajaEgresoDetalleDocumentos = Int32.Parse(reader["IdCajaEgresoDetalleDocumentos"].ToString());
                
                CajaEgresoDetalleDocumentos.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CajaEgresoDetalleDocumentos.NumRecibo = reader["NumRecibo"].ToString();
                CajaEgresoDetalleDocumentos.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                CajaEgresoDetalleDocumentos.ImporteEgreso = Decimal.Parse(reader["Monto"].ToString());

                CajaEgresoDetalleDocumentoslist.Add(CajaEgresoDetalleDocumentos);
            }
            reader.Close();
            reader.Dispose();
            return CajaEgresoDetalleDocumentoslist;
        }


        public Int32 Inserta(CajaEgresoDetalleDocumentosBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalleDocumentos_Inserta");

            db.AddOutParameter(dbCommand, "pIdCajaEgresoDetalleDocumentos", DbType.Int32, pItem.IdCajaEgresoDetalleDocumentos);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCajaEgreso", DbType.Int32, pItem.IdCajaEgreso);
            db.AddInParameter(dbCommand, "pIdCajaEgresoDetalle", DbType.Int32, pItem.IdCajaEgresoDetalle);

            db.AddInParameter(dbCommand, "pIdCentroCosto", DbType.Int32, pItem.IdCentroCosto);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pFechaFactura", DbType.DateTime, pItem.FechaFactura);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoDocumentoProv", DbType.Int32, pItem.TipoDocumentoProv);

            db.AddInParameter(dbCommand, "pSerieFactura", DbType.String, pItem.SerieFactura);
            db.AddInParameter(dbCommand, "pNumeroFactura", DbType.String, pItem.NumeroFactura);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pNumDocProv", DbType.String, pItem.NumDocProv);
            db.AddInParameter(dbCommand, "pDescProv", DbType.String, pItem.DescProv);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);

            db.AddInParameter(dbCommand, "pImporteCuarta", DbType.Decimal, pItem.ImporteCuarta);
            db.AddInParameter(dbCommand, "pImporteDetraccion", DbType.Decimal, pItem.ImporteDetraccion);
            db.AddInParameter(dbCommand, "pImporteFactura", DbType.Decimal, pItem.ImporteFactura);
            db.AddInParameter(dbCommand, "pUsuarioCreacion", DbType.String, pItem.UsuarioCreacion);

            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoEgreso", DbType.Int32, pItem.IdTipoEgreso);

            db.ExecuteNonQuery(dbCommand);

            //Id = (int)db.GetParameterValue(dbCommand, "pIdCajaEgresoDetalle");

            return Id;
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

        public void Actualiza(CajaEgresoDetalleDocumentosBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgresoDetalleDocumentos_Actualiza");

            db.AddInParameter(dbCommand, "pIdCajaEgresoDetalleDocumentos", DbType.Int32, pItem.IdCajaEgresoDetalleDocumentos);

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



    }
}
