using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DocumentoVentaDetalleDL
    {
        public DocumentoVentaDetalleDL() { }

        public void Inserta(DocumentoVentaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdDocumentoVentaDetalle", DbType.Int32, pItem.IdDocumentoVentaDetalle);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Double, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pCodAfeIGV", DbType.String, pItem.CodAfeIGV);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pFlagMuestra", DbType.Boolean, pItem.FlagMuestra);
            db.AddInParameter(dbCommand, "pFlagRegalo", DbType.Boolean, pItem.FlagRegalo);
            db.AddInParameter(dbCommand, "pIdPromocion", DbType.Int32, pItem.IdPromocion);
            db.AddInParameter(dbCommand, "pIdPromocion2", DbType.Int32, pItem.IdPromocion2); //ECM
            db.AddInParameter(dbCommand, "pDescPromocion", DbType.String, pItem.DescPromocion); //ECM
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(DocumentoVentaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdDocumentoVentaDetalle", DbType.Int32, pItem.IdDocumentoVentaDetalle);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, pItem.IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Double, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pCodAfeIGV", DbType.String, pItem.CodAfeIGV);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pFlagMuestra", DbType.Boolean, pItem.FlagMuestra);
            db.AddInParameter(dbCommand, "pFlagRegalo", DbType.Boolean, pItem.FlagRegalo);
            db.AddInParameter(dbCommand, "pIdPromocion", DbType.Int32, pItem.IdPromocion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);


        }

        public void Elimina(DocumentoVentaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdDocumentoVentaDetalle", DbType.Int32, pItem.IdDocumentoVentaDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaFisico(DocumentoVentaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_EliminaFisico");

            db.AddInParameter(dbCommand, "pIdDocumentoVentaDetalle", DbType.Int32, pItem.IdDocumentoVentaDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public List<DocumentoVentaDetalleBE> ListaTodosActivo(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaDetalleBE> DocumentoVentaDetallelist = new List<DocumentoVentaDetalleBE>();
            DocumentoVentaDetalleBE DocumentoVentaDetalle;
            while (reader.Read())
            {
                DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                DocumentoVentaDetalle.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVentaDetalle.IdDocumentoVentaDetalle = Int32.Parse(reader["idDocumentoVentaDetalle"].ToString());
                DocumentoVentaDetalle.Item = Int32.Parse(reader["item"].ToString());
                DocumentoVentaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                DocumentoVentaDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                DocumentoVentaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                DocumentoVentaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                DocumentoVentaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                DocumentoVentaDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                DocumentoVentaDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                DocumentoVentaDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                DocumentoVentaDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                DocumentoVentaDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                DocumentoVentaDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                DocumentoVentaDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                DocumentoVentaDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                DocumentoVentaDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                DocumentoVentaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentaDetalle.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                DocumentoVentaDetalle.IdPromocion2 = Int32.Parse(reader["IdPromocion2"].ToString()); //ECM
                DocumentoVentaDetalle.DescPromocion = reader["DescPromocion"].ToString(); //ECM
                DocumentoVentaDetalle.PorcentajePromocionDetalle = Decimal.Parse(reader["PorcentajePromocionDetalle"].ToString()); //ECM
                DocumentoVentaDetallelist.Add(DocumentoVentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }

        public List<DocumentoVentaDetalleBE> ListaTodosActivoFE(int IdEmpresa, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_ListaTodosActivoFE");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaDetalleBE> DocumentoVentaDetallelist = new List<DocumentoVentaDetalleBE>();
            DocumentoVentaDetalleBE DocumentoVentaDetalle;
            while (reader.Read())
            {
                DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                DocumentoVentaDetalle.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVentaDetalle.IdDocumentoVentaDetalle = Int32.Parse(reader["idDocumentoVentaDetalle"].ToString());
                DocumentoVentaDetalle.Item = Int32.Parse(reader["item"].ToString());
                DocumentoVentaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                DocumentoVentaDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                DocumentoVentaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                DocumentoVentaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                DocumentoVentaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                DocumentoVentaDetalle.ValorUnitario = Decimal.Parse(reader["ValorUnitario"].ToString());
                DocumentoVentaDetalle.TotalValor = Decimal.Parse(reader["TotalValor"].ToString());
                DocumentoVentaDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                DocumentoVentaDetalle.TotalUnitario = Decimal.Parse(reader["TotalUnitario"].ToString());
                DocumentoVentaDetalle.ValorUnitDscto = Decimal.Parse(reader["ValorUnitDscto"].ToString());
                DocumentoVentaDetalle.TotalValorUnitDscto = Decimal.Parse(reader["TotalValorUnitDscto"].ToString());
                DocumentoVentaDetalle.Igv = Decimal.Parse(reader["Igv"].ToString());
                DocumentoVentaDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                DocumentoVentaDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                DocumentoVentaDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                DocumentoVentaDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                DocumentoVentaDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                DocumentoVentaDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                DocumentoVentaDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                DocumentoVentaDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                DocumentoVentaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentaDetalle.ICBPER = Decimal.Parse(reader["Icbper"].ToString());

                DocumentoVentaDetallelist.Add(DocumentoVentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }
        public List<DocumentoVentaDetalleBE> ListaTodosActivoFE_RER(int IdEmpresa, int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_ListaTodosActivoFE_RER");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaDetalleBE> DocumentoVentaDetallelist = new List<DocumentoVentaDetalleBE>();
            DocumentoVentaDetalleBE DocumentoVentaDetalle;
            while (reader.Read())
            {
                DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                DocumentoVentaDetalle.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVentaDetalle.IdDocumentoVentaDetalle = Int32.Parse(reader["idDocumentoVentaDetalle"].ToString());
                DocumentoVentaDetalle.Item = Int32.Parse(reader["item"].ToString());
                DocumentoVentaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                DocumentoVentaDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                DocumentoVentaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                DocumentoVentaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                DocumentoVentaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                DocumentoVentaDetalle.ValorUnitario = Decimal.Parse(reader["ValorUnitario"].ToString());
                DocumentoVentaDetalle.TotalValor = Decimal.Parse(reader["TotalValor"].ToString());
                DocumentoVentaDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                DocumentoVentaDetalle.TotalUnitario = Decimal.Parse(reader["TotalUnitario"].ToString());
                DocumentoVentaDetalle.ValorUnitDscto = Decimal.Parse(reader["ValorUnitDscto"].ToString());
                DocumentoVentaDetalle.TotalValorUnitDscto = Decimal.Parse(reader["TotalValorUnitDscto"].ToString());
                DocumentoVentaDetalle.Igv = Decimal.Parse(reader["Igv"].ToString());
                DocumentoVentaDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                DocumentoVentaDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                DocumentoVentaDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                DocumentoVentaDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                DocumentoVentaDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                DocumentoVentaDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                DocumentoVentaDetalle.FlagMuestra = Boolean.Parse(reader["FlagMuestra"].ToString());
                DocumentoVentaDetalle.FlagRegalo = Boolean.Parse(reader["FlagRegalo"].ToString());
                DocumentoVentaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentaDetallelist.Add(DocumentoVentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }


        public List<DocumentoVentaDetalleBE> ListaPedido(int IdDocumentoVenta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_ListaPedido");
            db.AddInParameter(dbCommand, "pIdDocumentoVenta", DbType.Int32, IdDocumentoVenta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaDetalleBE> DocumentoVentaDetallelist = new List<DocumentoVentaDetalleBE>();
            DocumentoVentaDetalleBE DocumentoVentaDetalle;
            while (reader.Read())
            {
                DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                DocumentoVentaDetalle.IdDocumentoVenta = Int32.Parse(reader["idDocumentoVenta"].ToString());
                DocumentoVentaDetalle.IdDocumentoVentaDetalle = Int32.Parse(reader["idDocumentoVentaDetalle"].ToString());
                DocumentoVentaDetalle.Item = Int32.Parse(reader["item"].ToString());
                DocumentoVentaDetalle.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                DocumentoVentaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                DocumentoVentaDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                DocumentoVentaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                DocumentoVentaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                DocumentoVentaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                DocumentoVentaDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                DocumentoVentaDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                DocumentoVentaDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                DocumentoVentaDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                DocumentoVentaDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                DocumentoVentaDetalle.CodAfeIGV = reader["CodAfeIGV"].ToString();
                DocumentoVentaDetalle.TipoCambio = Decimal.Parse(reader["TipoCambio"].ToString());
                DocumentoVentaDetalle.PrecioUnitarioPedido = Decimal.Parse(reader["PrecioUnitarioPedido"].ToString());
                DocumentoVentaDetalle.PrecioVentaPedido = Decimal.Parse(reader["PrecioVentaPedido"].ToString());
                DocumentoVentaDetalle.ValorVentaSoles = Decimal.Parse(reader["ValorVentaSoles"].ToString());
                DocumentoVentaDetalle.ValorVentaDolares = Decimal.Parse(reader["ValorVentaDolares"].ToString());
                DocumentoVentaDetalle.DescPromocion = reader["DescPromocion"].ToString();
                DocumentoVentaDetallelist.Add(DocumentoVentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }

        public List<DocumentoVentaDetalleBE> ListaEmpresaTraslado(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoVentaDetalle_ListaEmpresaTraslado");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoVentaDetalleBE> DocumentoVentaDetallelist = new List<DocumentoVentaDetalleBE>();
            DocumentoVentaDetalleBE DocumentoVentaDetalle;
            while (reader.Read())
            {
                DocumentoVentaDetalle = new DocumentoVentaDetalleBE();
                DocumentoVentaDetalle.Item = Int32.Parse(reader["item"].ToString());
                DocumentoVentaDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DocumentoVentaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                DocumentoVentaDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                DocumentoVentaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                DocumentoVentaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                DocumentoVentaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                DocumentoVentaDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                DocumentoVentaDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                DocumentoVentaDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                DocumentoVentaDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                DocumentoVentaDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                DocumentoVentaDetalle.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                DocumentoVentaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoVentaDetallelist.Add(DocumentoVentaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoVentaDetallelist;
        }

    }
}

