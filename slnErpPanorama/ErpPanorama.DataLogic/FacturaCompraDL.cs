using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class FacturaCompraDL
    {
        public FacturaCompraDL() { }

        public Int32 Inserta(FacturaCompraBE pItem)
        {
            Int32 intIdFacturaCompra = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_Inserta");

            db.AddOutParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdMotivoVenta", DbType.Int32, pItem.IdMotivoVenta);
            db.AddInParameter(dbCommand, "pFechaCompra", DbType.DateTime, pItem.FechaCompra);
            db.AddInParameter(dbCommand, "pFechaRecepcion", DbType.DateTime, pItem.FechaRecepcion);
            db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            db.AddInParameter(dbCommand, "pTipoRegistro", DbType.String, pItem.TipoRegistro);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pImportePorPagar", DbType.Decimal, pItem.ImportePorPagar);
            db.AddInParameter(dbCommand, "pGastosAdministrativos", DbType.Decimal, pItem.GastosAdministrativos);
            db.AddInParameter(dbCommand, "pFlete", DbType.Decimal, pItem.Flete);
            db.AddInParameter(dbCommand, "pIpm", DbType.Decimal, pItem.Ipm);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pAdvalorem", DbType.Decimal, pItem.Advalorem);
            db.AddInParameter(dbCommand, "pPercepcion", DbType.Decimal, pItem.Percepcion);
            db.AddInParameter(dbCommand, "pDerechosPercepcion", DbType.Decimal, pItem.DerechosPercepcion);
            db.AddInParameter(dbCommand, "pDesestiba", DbType.Decimal, pItem.Desestiba);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagNacional", DbType.Boolean, pItem.FlagNacional);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
            db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, pItem.IdSolicitudCompra);
            db.AddInParameter(dbCommand, "pIdSituacionPago", DbType.Int32, pItem.IdSituacionPago);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);

            intIdFacturaCompra = (int)db.GetParameterValue(dbCommand, "pIdFacturaCompra");

            return intIdFacturaCompra;
        }

        public void Actualiza(FacturaCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_Actualiza");

            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdMotivoVenta", DbType.Int32, pItem.IdMotivoVenta);
            db.AddInParameter(dbCommand, "pFechaCompra", DbType.DateTime, pItem.FechaCompra);
            db.AddInParameter(dbCommand, "pFechaRecepcion", DbType.DateTime, pItem.FechaRecepcion);

            db.AddInParameter(dbCommand, "pNroDUA", DbType.String, pItem.NroDUA);
            db.AddInParameter(dbCommand, "pTContenedor", DbType.Int32, pItem.TamañoContenedor);

            db.AddInParameter(dbCommand, "pTipoRegistro", DbType.String, pItem.TipoRegistro);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pGastosAdministrativos", DbType.Decimal, pItem.GastosAdministrativos);
            db.AddInParameter(dbCommand, "pFlete", DbType.Decimal, pItem.Flete);
            db.AddInParameter(dbCommand, "pIpm", DbType.Decimal, pItem.Ipm);
            db.AddInParameter(dbCommand, "pIgv", DbType.Decimal, pItem.Igv);
            db.AddInParameter(dbCommand, "pAdvalorem", DbType.Decimal, pItem.Advalorem);
            db.AddInParameter(dbCommand, "pPercepcion", DbType.Decimal, pItem.Percepcion);
            db.AddInParameter(dbCommand, "pDerechosPercepcion", DbType.Decimal, pItem.DerechosPercepcion);
            db.AddInParameter(dbCommand, "pDesestiba", DbType.Decimal, pItem.Desestiba);

            db.AddInParameter(dbCommand, "pSobreEstadia", DbType.Decimal, pItem.SobreEstadia);

            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pImportePorPagar", DbType.Decimal, pItem.ImportePorPagar);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pTipoCambio", DbType.Decimal, pItem.TipoCambio);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagNacional", DbType.Boolean, pItem.FlagNacional);
            db.AddInParameter(dbCommand, "pFlagRecibido", DbType.Boolean, pItem.FlagRecibido);
            db.AddInParameter(dbCommand, "pIdSolicitudCompra", DbType.Int32, pItem.IdSolicitudCompra);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(FacturaCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_Elimina");

            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaFechaRecepcion(FacturaCompraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_ActualizaFechaRecepcion");

            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pFechaRecepcion", DbType.DateTime, pItem.FechaRecepcion);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.ExecuteNonQuery(dbCommand);
        }
        public void ActualizaSituacionPago(int IdFacturaCompra,int IdSituacionPago,string Maquina,string Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_ActualizaSituacionPago");

            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdSituacionPago", DbType.Int32, IdSituacionPago);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, Maquina);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);

            db.ExecuteNonQuery(dbCommand);
        }

        public FacturaCompraBE Selecciona(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            FacturaCompraBE FacturaCompra = null;
            while (reader.Read())
            {
                FacturaCompra = new FacturaCompraBE();
                FacturaCompra.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                FacturaCompra.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FacturaCompra.Periodo = Int32.Parse(reader["periodo"].ToString());
                FacturaCompra.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                FacturaCompra.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                FacturaCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                FacturaCompra.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                FacturaCompra.DescProveedor = reader["DescProveedor"].ToString();
                FacturaCompra.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                FacturaCompra.FormaPago = reader["FormaPago"].ToString();
                FacturaCompra.IdMotivoVenta= reader.IsDBNull(reader.GetOrdinal("IdMotivoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMotivoVenta"));
                FacturaCompra.MotivoVenta = reader["MotivoVenta"].ToString();
                FacturaCompra.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                FacturaCompra.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                FacturaCompra.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));

                FacturaCompra.NroDUA = reader["NroDUA"].ToString();
                FacturaCompra.TamañoContenedor = Int32.Parse(reader["IdTContenedor"].ToString());

                FacturaCompra.TipoRegistro = reader["TipoRegistro"].ToString();
                FacturaCompra.Importe = Decimal.Parse(reader["Importe"].ToString());
                FacturaCompra.ImportePorPagar = reader.IsDBNull(reader.GetOrdinal("ImportePorPagar")) ? (Decimal?)null : reader.GetDecimal(reader.GetOrdinal("ImportePorPagar"));
                FacturaCompra.GastosAdministrativos= Decimal.Parse(reader["GastosAdministrativos"].ToString());
                FacturaCompra.Flete = Decimal.Parse(reader["Flete"].ToString());
                FacturaCompra.Ipm = Decimal.Parse(reader["Ipm"].ToString());
                FacturaCompra.Igv = Decimal.Parse(reader["Igv"].ToString());
                FacturaCompra.Advalorem = Decimal.Parse(reader["Advalorem"].ToString());
                FacturaCompra.Percepcion = Decimal.Parse(reader["Percepcion"].ToString());
                FacturaCompra.DerechosPercepcion = Decimal.Parse(reader["DerechosPercepcion"].ToString());
                FacturaCompra.Desestiba = Decimal.Parse(reader["Desestiba"].ToString());
                FacturaCompra.SobreEstadia = Decimal.Parse(reader["SobreEstadia"].ToString());
                FacturaCompra.Total = Decimal.Parse(reader["Total"].ToString());
                //FacturaCompra.ImportePorPagar = Decimal.Parse(reader["ImportePorPagar"].ToString());
                FacturaCompra.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                FacturaCompra.Moneda = reader["Moneda"].ToString();
                FacturaCompra.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                FacturaCompra.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompra.Observacion = reader["Observacion"].ToString();
                FacturaCompra.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                FacturaCompra.Usuario = reader["Usuario"].ToString();
                FacturaCompra.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"].ToString());
                FacturaCompra.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                FacturaCompra.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompra;
        }

        public List<FacturaCompraBE> ListaTodosActivo(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraBE> FacturaCompralist = new List<FacturaCompraBE>();
            FacturaCompraBE FacturaCompra;
            while (reader.Read())
            {
                FacturaCompra = new FacturaCompraBE();
                FacturaCompra.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                FacturaCompra.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FacturaCompra.Periodo = Int32.Parse(reader["periodo"].ToString());
                FacturaCompra.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                FacturaCompra.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                FacturaCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                FacturaCompra.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                FacturaCompra.DescProveedor = reader["DescProveedor"].ToString();
                FacturaCompra.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                FacturaCompra.FormaPago = reader["FormaPago"].ToString();
                FacturaCompra.IdMotivoVenta= reader.IsDBNull(reader.GetOrdinal("IdMotivoVenta")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdMotivoVenta"));
                FacturaCompra.MotivoVenta= reader["MotivoVenta"].ToString();
                FacturaCompra.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                FacturaCompra.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                FacturaCompra.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento"));
                FacturaCompra.TipoRegistro = reader["tiporegistro"].ToString();
                //FacturaCompra.Importe = Decimal.Parse(reader["Importe"].ToString());
                FacturaCompra.ImportePorPagar = Decimal.Parse(reader["ImportePorPagar"].ToString());
                FacturaCompra.IdSituacionPago= reader.IsDBNull(reader.GetOrdinal("IdSituacionPago")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdSituacionPago"));
                FacturaCompra.SituacionPago =reader["SituacionPago"].ToString();
                FacturaCompra.GastosAdministrativos = Decimal.Parse(reader["GastosAdministrativos"].ToString());
                FacturaCompra.Flete = Decimal.Parse(reader["Flete"].ToString());

                FacturaCompra.Ipm = Decimal.Parse(reader["Ipm"].ToString());
                FacturaCompra.Igv = Decimal.Parse(reader["Igv"].ToString());
                FacturaCompra.Advalorem = Decimal.Parse(reader["Advalorem"].ToString());
                FacturaCompra.Percepcion = Decimal.Parse(reader["Percepcion"].ToString());

                
                FacturaCompra.Ipm2 = Decimal.Parse(reader["Ipm2"].ToString());
                FacturaCompra.Igv2 = Decimal.Parse(reader["Igv2"].ToString());
                FacturaCompra.Advalorem2 = Decimal.Parse(reader["Advalorem2"].ToString());
                FacturaCompra.Percepcion2 = Decimal.Parse(reader["Percepcion2"].ToString());

                FacturaCompra.DerechosPercepcion = Decimal.Parse(reader["DerechosPercepcion"].ToString());
                FacturaCompra.Desestiba = Decimal.Parse(reader["Desestiba"].ToString());
                FacturaCompra.Desestiba2 = Decimal.Parse(reader["Desestiba2"].ToString());
                FacturaCompra.SobreEstadia = Decimal.Parse(reader["SobreEstadia"].ToString());
                FacturaCompra.Total = Decimal.Parse(reader["Total"].ToString());
                FacturaCompra.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                FacturaCompra.Moneda = reader["Moneda"].ToString();
                FacturaCompra.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                FacturaCompra.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompra.Observacion = reader["Observacion"].ToString();
                FacturaCompra.FlagRecibido = Boolean.Parse(reader["FlagRecibido"].ToString());
                FacturaCompra.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                FacturaCompra.PorcentajeVenta = Decimal.Parse(reader["PorcentajeVenta"].ToString());
                FacturaCompra.CantidadVenta = Int32.Parse(reader["CantidadVenta"].ToString());
                FacturaCompra.ImporteVenta = Decimal.Parse(reader["ImporteVenta"].ToString());
                FacturaCompra.Usuario = reader["Usuario"].ToString();
                FacturaCompra.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                FacturaCompra.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                FacturaCompralist.Add(FacturaCompra);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompralist;
        }

        public List<FacturaCompraBE> ListaProveedor(int IdEmpresa, int IdProveedor, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_ListaProveedor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraBE> FacturaCompralist = new List<FacturaCompraBE>();
            FacturaCompraBE FacturaCompra;
            while (reader.Read())
            {
                FacturaCompra = new FacturaCompraBE();
                FacturaCompra.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                FacturaCompra.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                FacturaCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                FacturaCompralist.Add(FacturaCompra);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompralist;
        }

        public List<FacturaCompraBE> ListadoPendientesProveedor(int IdEmpresa, int IdProveedor, string NumeroDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_ListadoPendientesProveedor");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, IdProveedor);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, NumeroDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraBE> FacturaCompralist = new List<FacturaCompraBE>();
            FacturaCompraBE FacturaCompra;
            while (reader.Read())
            {
                FacturaCompra = new FacturaCompraBE();
                FacturaCompra.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                FacturaCompra.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                FacturaCompra.IdSituacionPago = reader.IsDBNull(reader.GetOrdinal("IdSituacionPago")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdSituacionPago"));
                FacturaCompra.SituacionPago = reader["SituacionPago"].ToString();
                FacturaCompra.FormaPago = reader["FormaPago"].ToString();
                FacturaCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                FacturaCompra.Importe = Decimal.Parse(reader["Importe"].ToString());
                FacturaCompra.ImportePago = Decimal.Parse(reader["ImportePago"].ToString());
                FacturaCompralist.Add(FacturaCompra);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompralist;
        }


        public List<FacturaCompraBE> ListaLineaProductoFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta, int IdTipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_ListaLineaProductoFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pIdTipoReporte", DbType.Int32, IdTipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraBE> FacturaCompralist = new List<FacturaCompraBE>();
            FacturaCompraBE FacturaCompra;
            while (reader.Read())
            {
                FacturaCompra = new FacturaCompraBE();
                FacturaCompra.DescLineaProducto = reader["DescLineaProducto"].ToString();
                FacturaCompra.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                FacturaCompra.Enero = Decimal.Parse(reader["Enero"].ToString());
                FacturaCompra.Febrero = Decimal.Parse(reader["Febrero"].ToString());
                FacturaCompra.Marzo = Decimal.Parse(reader["Marzo"].ToString());
                FacturaCompra.Abril = Decimal.Parse(reader["Abril"].ToString());
                FacturaCompra.Mayo = Decimal.Parse(reader["Mayo"].ToString());
                FacturaCompra.Junio = Decimal.Parse(reader["Junio"].ToString());
                FacturaCompra.Julio = Decimal.Parse(reader["Julio"].ToString());
                FacturaCompra.Agosto = Decimal.Parse(reader["Agosto"].ToString());
                FacturaCompra.Setiembre = Decimal.Parse(reader["Setiembre"].ToString());
                FacturaCompra.Octubre = Decimal.Parse(reader["Octubre"].ToString());
                FacturaCompra.Noviembre = Decimal.Parse(reader["Noviembre"].ToString());
                FacturaCompra.Diciembre = Decimal.Parse(reader["Diciembre"].ToString());
                FacturaCompra.Importe = Decimal.Parse(reader["Importe"].ToString());
                FacturaCompralist.Add(FacturaCompra);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompralist;
        }

        public FacturaCompraBE SeleccionaProducto(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_SeleccionaProducto");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            FacturaCompraBE FacturaCompra = null;
            while (reader.Read())
            {
                FacturaCompra = new FacturaCompraBE();
                FacturaCompra.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                FacturaCompra.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                FacturaCompra.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                FacturaCompra.NumeroDocumento = reader["NumeroDocumento"].ToString();
                FacturaCompra.DescProveedor = reader["DescProveedor"].ToString();
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompra;
        }

        public FacturaCompraBE SeleccionaProductoUltimaCompra(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompra_SeleccionaProductoUltimaCompra");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            FacturaCompraBE FacturaCompra = null;
            while (reader.Read())
            {
                FacturaCompra = new FacturaCompraBE();
                FacturaCompra.FechaCompra = DateTime.Parse(reader["FechaCompra"].ToString());
                FacturaCompra.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                FacturaCompra.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompra;
        }

    }
}
