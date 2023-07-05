using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProformaDisenioDetalleDL
    {
        public ProformaDisenioDetalleDL() { }

        public Int32 Inserta(ProformaDisenioDetalleBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProformaDisenioDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdProformaDisenio", DbType.Int32, pItem.IdProformaDisenio);
            db.AddOutParameter(dbCommand, "pIdProformaDisenioDetalle", DbType.Int32, pItem.IdProformaDisenioDetalle);
            db.AddInParameter(dbCommand, "pIdSituacionProducto", DbType.Int32, pItem.IdSituacionProducto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);

            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pModelo", DbType.String, pItem.Modelo);
            db.AddInParameter(dbCommand, "pMedida", DbType.String, pItem.Medida);
            db.AddInParameter(dbCommand, "pMaterial", DbType.String, pItem.Material);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);

            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);

            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);

            db.ExecuteNonQuery(dbCommand);
            Id = (int)db.GetParameterValue(dbCommand, "pIdProformaDisenioDetalle");

            return Id;
        }


        public void Actualiza_E(ProformaDisenioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgresoDetalle_Actualiza_E");

            //db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
            //db.AddInParameter(dbCommand, "pIdSolicitudEgresoDetalle", DbType.Int32, pItem.IdSolicitudEgresoDetalle);
            //db.AddInParameter(dbCommand, "pNumeroAbono", DbType.Int32, pItem.NumeroAbono);
            //db.AddInParameter(dbCommand, "pFechaPagoSolicitada", DbType.DateTime, Convert.ToDateTime(pItem.FechaPagoSolicitada) == Convert.ToDateTime("01/01/0001") ? (DateTime?)null : pItem.FechaPagoSolicitada);   // pItem.FechaPagoSolicitada
            //db.AddInParameter(dbCommand, "pMontoAbono", DbType.Decimal, pItem.MontoAbono);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza_Pagos(ProformaDisenioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgresoDetalle_ActualizaPagos");

            //db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
            //db.AddInParameter(dbCommand, "pIdSolicitudEgresoDetalle", DbType.Int32, pItem.IdSolicitudEgresoDetalle);

            //db.AddInParameter(dbCommand, "pFechaDeposito", DbType.DateTime, Convert.ToDateTime(pItem.FechaDeposito) == Convert.ToDateTime("01/01/0001") ? (DateTime?)null : pItem.FechaDeposito);   // pItem.FechaPagoSolicitada
            //db.AddInParameter(dbCommand, "pFechaIngresoAlmacen", DbType.DateTime, Convert.ToDateTime(pItem.FechaIngresoAlmacen) == Convert.ToDateTime("01/01/0001") ? (DateTime?)null : pItem.FechaIngresoAlmacen);
            //db.AddInParameter(dbCommand, "pFechaRecepcionFactura", DbType.DateTime, Convert.ToDateTime(pItem.FechaRecepcionFactura) == Convert.ToDateTime("01/01/0001") ? (DateTime?)null : pItem.FechaRecepcionFactura);

            //db.AddInParameter(dbCommand, "pTipoDocumento", DbType.Int32, pItem.TipDocumento);
            //db.AddInParameter(dbCommand, "pSerie", DbType.String, pItem.Serie);
            //db.AddInParameter(dbCommand, "pNumeroFactura", DbType.String, pItem.NumeroFactura);

            //db.AddInParameter(dbCommand, "pMontoFactura", DbType.Decimal, pItem.MontoFactura);

            //db.AddInParameter(dbCommand, "pFechaEmisionFactura", DbType.DateTime, Convert.ToDateTime(pItem.FechaEmisionFactura) == Convert.ToDateTime("01/01/0001") ? (DateTime?)null : pItem.FechaEmisionFactura);
            //db.AddInParameter(dbCommand, "pRutaArchivo", DbType.String, pItem.RutaArchivo);

            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pfname", DbType.String, pItem.fname);
            //db.AddInParameter(dbCommand, "pfcontent", DbType.Binary, pItem.fcontent);
            //db.AddInParameter(dbCommand, "ptipo", DbType.String, pItem.tipo);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ProformaDisenioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_Elimina");

            //db.AddInParameter(dbCommand, "pIdDocumentoVentaDetalle", DbType.Int32, pItem.IdDocumentoVentaDetalle);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaFisico(ProformaDisenioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_EliminaFisico");

            //db.AddInParameter(dbCommand, "pIdDocumentoVentaDetalle", DbType.Int32, pItem.IdDocumentoVentaDetalle);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProformaDisenioDetalleBE> ListaTodosActivo(int IdSolicitudEgreso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgresoDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, IdSolicitudEgreso);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDisenioDetalleBE> DocumentoVentaDetallelist = new List<ProformaDisenioDetalleBE>();
            ProformaDisenioDetalleBE DocumentoVentaDetalle;
            while (reader.Read())
            {
                DocumentoVentaDetalle = new ProformaDisenioDetalleBE();

                //DocumentoVentaDetalle.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
                //DocumentoVentaDetalle.IdSolicitudEgresoDetalle = Int32.Parse(reader["IdSolicitudEgresoDetalle"].ToString());
                //DocumentoVentaDetalle.NumeroAbono = Int32.Parse(reader["NumeroAbono"].ToString());
                //DocumentoVentaDetalle.FechaPagoSolicitada = reader.IsDBNull(reader.GetOrdinal("FechaPagoSolicitada")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPagoSolicitada"));
                ////DocumentoVentaDetalle.FechaPagoSolicitada = DateTime.Parse(reader["FechaPagoSolicitada"].ToString());
                //DocumentoVentaDetalle.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());
                ////DocumentoVentaDetalle.FechaDeposito2 = DateTime.Parse(reader["FechaDeposito"].ToString());
                //DocumentoVentaDetalle.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
                //DocumentoVentaDetalle.FechaIngresoAlmacen = reader.IsDBNull(reader.GetOrdinal("FechaIngresoAlmacen")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngresoAlmacen"));
                //DocumentoVentaDetalle.FechaRecepcionFactura = reader.IsDBNull(reader.GetOrdinal("FechaRecepcionFactura")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcionFactura"));
                //DocumentoVentaDetalle.NumeroFactura =  (reader["NumeroFactura"].ToString());
                //DocumentoVentaDetalle.MontoFactura = Decimal.Parse(reader["MontoFactura"].ToString());
                //DocumentoVentaDetalle.FechaEmisionFactura = reader.IsDBNull(reader.GetOrdinal("FechaEmisionFactura")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmisionFactura"));
                //DocumentoVentaDetalle.RutaArchivo = (reader["RutaArchivo"].ToString());

                //DocumentoVentaDetalle.Serie = (reader["SerieProv"].ToString());
                //DocumentoVentaDetalle.TipDocumento = Int32.Parse((reader["TipoDocumentoProv"].ToString()));

                DocumentoVentaDetallelist.Add(DocumentoVentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }

        public List<ProformaDisenioDetalleBE> ListaTodosActivoFE(int IdEmpresa, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_ListaTodosActivoFE");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDisenioDetalleBE> DocumentoVentaDetallelist = new List<ProformaDisenioDetalleBE>();
            ProformaDisenioDetalleBE DocumentoVentaDetalle;
            while (reader.Read())
            {
                DocumentoVentaDetalle = new ProformaDisenioDetalleBE();
                //DocumentoVentaDetalle.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                //DocumentoVentaDetalle.IdDocumentoVentaDetalle = Int32.Parse(reader["idDocumentoVentaDetalle"].ToString());
                //DocumentoVentaDetalle.Item = Int32.Parse(reader["item"].ToString());
                //DocumentoVentaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                //DocumentoVentaDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                //DocumentoVentaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                //DocumentoVentaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                //DocumentoVentaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                //DocumentoVentaDetalle.ValorUnitario = Decimal.Parse(reader["ValorUnitario"].ToString());
                //DocumentoVentaDetalle.TotalValor = Decimal.Parse(reader["TotalValor"].ToString());
                //DocumentoVentaDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                //DocumentoVentaDetalle.TotalUnitario = Decimal.Parse(reader["TotalUnitario"].ToString());
                //DocumentoVentaDetalle.ValorUnitDscto = Decimal.Parse(reader["ValorUnitDscto"].ToString());
                //DocumentoVentaDetalle.TotalValorUnitDscto = Decimal.Parse(reader["TotalValorUnitDscto"].ToString());
                //DocumentoVentaDetalle.Igv = Decimal.Parse(reader["Igv"].ToString());
                //DocumentoVentaDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                //DocumentoVentaDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                //DocumentoVentaDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                //DocumentoVentaDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                //DocumentoVentaDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                //DocumentoVentaDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                //DocumentoVentaDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                //DocumentoVentaDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                //DocumentoVentaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentaDetallelist.Add(DocumentoVentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }
        public List<ProformaDisenioDetalleBE> ListaTodosActivoFE_RER(int IdEmpresa, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_ListaTodosActivoFE_RER");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDisenioDetalleBE> DocumentoVentaDetallelist = new List<ProformaDisenioDetalleBE>();
            ProformaDisenioDetalleBE DocumentoVentaDetalle;
            while (reader.Read())
            {
                DocumentoVentaDetalle = new ProformaDisenioDetalleBE();
                //DocumentoVentaDetalle.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                //DocumentoVentaDetalle.IdDocumentoVentaDetalle = Int32.Parse(reader["idDocumentoVentaDetalle"].ToString());
                //DocumentoVentaDetalle.Item = Int32.Parse(reader["item"].ToString());
                //DocumentoVentaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                //DocumentoVentaDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                //DocumentoVentaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                //DocumentoVentaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                //DocumentoVentaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                //DocumentoVentaDetalle.ValorUnitario = Decimal.Parse(reader["ValorUnitario"].ToString());
                //DocumentoVentaDetalle.TotalValor = Decimal.Parse(reader["TotalValor"].ToString());
                //DocumentoVentaDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                //DocumentoVentaDetalle.TotalUnitario = Decimal.Parse(reader["TotalUnitario"].ToString());
                //DocumentoVentaDetalle.ValorUnitDscto = Decimal.Parse(reader["ValorUnitDscto"].ToString());
                //DocumentoVentaDetalle.TotalValorUnitDscto = Decimal.Parse(reader["TotalValorUnitDscto"].ToString());
                //DocumentoVentaDetalle.Igv = Decimal.Parse(reader["Igv"].ToString());
                //DocumentoVentaDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                //DocumentoVentaDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                //DocumentoVentaDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                //DocumentoVentaDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                //DocumentoVentaDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                //DocumentoVentaDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                //DocumentoVentaDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                //DocumentoVentaDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                //DocumentoVentaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentaDetallelist.Add(DocumentoVentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }


        public List<ProformaDisenioDetalleBE> ListaPedido(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_ListaPedido");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDisenioDetalleBE> DocumentoVentaDetallelist = new List<ProformaDisenioDetalleBE>();
            ProformaDisenioDetalleBE DocumentoVentaDetalle;
            while (reader.Read())
            {
                DocumentoVentaDetalle = new ProformaDisenioDetalleBE();
                //DocumentoVentaDetalle.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                //DocumentoVentaDetalle.IdDocumentoVentaDetalle = Int32.Parse(reader["idDocumentoVentaDetalle"].ToString());
                //DocumentoVentaDetalle.Item = Int32.Parse(reader["item"].ToString());
                //DocumentoVentaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                //DocumentoVentaDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                //DocumentoVentaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                //DocumentoVentaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                //DocumentoVentaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                //DocumentoVentaDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                //DocumentoVentaDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                //DocumentoVentaDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                //DocumentoVentaDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                //DocumentoVentaDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                //DocumentoVentaDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                //DocumentoVentaDetalle.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                //DocumentoVentaDetalle.PrecioUnitarioPedido = Decimal.Parse(reader["PrecioUnitarioPedido"].ToString());
                //DocumentoVentaDetalle.PrecioVentaPedido = Decimal.Parse(reader["PrecioVentaPedido"].ToString());
                //DocumentoVentaDetalle.ValorVentaSoles = Decimal.Parse(reader["ValorVentaSoles"].ToString());
                //DocumentoVentaDetalle.ValorVentaDolares = Decimal.Parse(reader["ValorVentaDolares"].ToString());
                DocumentoVentaDetallelist.Add(DocumentoVentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }

        public List<ProformaDisenioDetalleBE> ListaEmpresaTraslado(int IdEmpresa, DateTime FechaDesde, DateTime  FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_ListaEmpresaTraslado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDisenioDetalleBE> DocumentoVentaDetallelist = new List<ProformaDisenioDetalleBE>();
            ProformaDisenioDetalleBE DocumentoVentaDetalle;
            while (reader.Read())
            {
                DocumentoVentaDetalle = new ProformaDisenioDetalleBE();
                //DocumentoVentaDetalle.Item = Int32.Parse(reader["item"].ToString());
                //DocumentoVentaDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                //DocumentoVentaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                //DocumentoVentaDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                //DocumentoVentaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                //DocumentoVentaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                //DocumentoVentaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                //DocumentoVentaDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                //DocumentoVentaDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                //DocumentoVentaDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                //DocumentoVentaDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                //DocumentoVentaDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                //DocumentoVentaDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                //DocumentoVentaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentaDetallelist.Add(DocumentoVentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }

        public List<ProformaDisenioDetalleBE> ListaSolicitudEgresoDetalle(int IdSolicitudEgreso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgresoDetalle_Listado");
            db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, IdSolicitudEgreso);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDisenioDetalleBE> CuentaBancoDetallelist = new List<ProformaDisenioDetalleBE>();
            ProformaDisenioDetalleBE SolicitudEgresoDetalle;
            while (reader.Read())
            {
                SolicitudEgresoDetalle = new ProformaDisenioDetalleBE();
               // SolicitudEgresoDetalle.IdSolicitudEgresoDetalle = Int32.Parse(reader["IdSolicitudEgresoDetalle"].ToString());
               // SolicitudEgresoDetalle.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
               // SolicitudEgresoDetalle.NumeroAbono = Int32.Parse(reader["NumeroAbono"].ToString());
               // SolicitudEgresoDetalle.FechaPagoSolicitada = reader.IsDBNull(reader.GetOrdinal("FechaPagoSolicitada")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPagoSolicitada"));

               //// SolicitudEgresoDetalle.FechaPagoSolicitada = DateTime.Parse(reader["FechaPagoSolicitada"].ToString());
               // SolicitudEgresoDetalle.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());

               //// SolicitudEgresoDetalle.FechaDeposito = (DateTime)null;  // DateTime.Parse(reader["FechaDeposito"].ToString());
               // SolicitudEgresoDetalle.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));
               // //   SolicitudEgresoDetalle.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));

               // SolicitudEgresoDetalle.FechaIngresoAlmacen = reader.IsDBNull(reader.GetOrdinal("FechaIngresoAlmacen")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngresoAlmacen")); // DateTime.Parse(reader["FechaIngresoAlmacen"].ToString());
               // SolicitudEgresoDetalle.FechaRecepcionFactura = reader.IsDBNull(reader.GetOrdinal("FechaRecepcionFactura")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcionFactura")); // DateTime.Parse(reader["FechaRecepcionFactura"].ToString());

               // SolicitudEgresoDetalle.DescTipDocumento = reader["TipoDocumentoProv"].ToString();
               // SolicitudEgresoDetalle.Serie = reader["SerieProv"].ToString();
               // SolicitudEgresoDetalle.NumeroFactura = reader["NumeroFactura"].ToString();

               // SolicitudEgresoDetalle.MontoFactura = Decimal.Parse(reader["MontoFactura"].ToString());
               // SolicitudEgresoDetalle.FechaEmisionFactura = reader.IsDBNull(reader.GetOrdinal("FechaEmisionFactura")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEmisionFactura"));  //DateTime.Parse(reader["FechaEmisionFactura"].ToString());

               // SolicitudEgresoDetalle.RutaArchivo = reader["RutaArchivo"].ToString();
                CuentaBancoDetallelist.Add(SolicitudEgresoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return CuentaBancoDetallelist;
        }

        public void Actualiza(ProformaDisenioDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PrestamoBancoDetalle_Actualiza");

            //db.AddInParameter(dbCommand, "pIdPrestamoBancoDetalle", DbType.Int32, pItem.IdPrestamoBancoDetalle);
            //db.AddInParameter(dbCommand, "pIdPrestamoBanco", DbType.Int32, pItem.IdPrestamoBanco);
            //db.AddInParameter(dbCommand, "pNumeroCuota", DbType.Int32, pItem.NumeroCuota);
            //db.AddInParameter(dbCommand, "pFechaVencimiento", DbType.DateTime, pItem.FechaVencimiento);
            //db.AddInParameter(dbCommand, "pSaldoPendiente", DbType.Decimal, pItem.SaldoPendiente);
            //db.AddInParameter(dbCommand, "pAmortizacion", DbType.Decimal, pItem.Amortizacion);
            //db.AddInParameter(dbCommand, "pInteres", DbType.Decimal, pItem.Interes);
            //db.AddInParameter(dbCommand, "pEnvioInformacion", DbType.Decimal, pItem.EnvioInformacion);
            //db.AddInParameter(dbCommand, "pDesgravamen", DbType.Decimal, pItem.Desgravamen);
            //db.AddInParameter(dbCommand, "pSeguro", DbType.Decimal, pItem.Seguro);
            //db.AddInParameter(dbCommand, "pTotalPagar", DbType.Decimal, pItem.TotalPagar);
            //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }
    }
}

