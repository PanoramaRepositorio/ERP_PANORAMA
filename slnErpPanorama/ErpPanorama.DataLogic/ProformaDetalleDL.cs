using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProformaDetalleDL
    {
        public ProformaDetalleDL() { }

        public void Inserta(ProformaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProformaDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdProformaDetalle", DbType.Int32, pItem.IdProformaDetalle);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
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
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagAprobacion", DbType.Boolean, pItem.FlagAprobacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ProformaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProformaDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdProformaDetalle", DbType.Int32, pItem.IdProformaDetalle);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, pItem.IdProforma);
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
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagAprobacion", DbType.Boolean, pItem.FlagAprobacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProformaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProformaDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdProformaDetalle", DbType.Int32, pItem.IdProformaDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public List<ProformaDetalleBE> ListaTodosActivo(int IdEmpresa, int IdProforma)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProformaDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProforma", DbType.Int32, IdProforma);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDetalleBE> ProformaDetallelist = new List<ProformaDetalleBE>();
            ProformaDetalleBE ProformaDetalle;
            while (reader.Read())
            {
                ProformaDetalle = new ProformaDetalleBE();
                ProformaDetalle.IdProforma = Int32.Parse(reader["idProforma"].ToString());
                ProformaDetalle.IdProformaDetalle = Int32.Parse(reader["idProformaDetalle"].ToString());
                ProformaDetalle.Item = Int32.Parse(reader["item"].ToString());
                ProformaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ProformaDetalle.CodigoProveedor = reader["codigoProveedor"].ToString();
                ProformaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                ProformaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                ProformaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                ProformaDetalle.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                ProformaDetalle.PorcentajeDescuento = Decimal.Parse(reader["porcentajeDescuento"].ToString());
                ProformaDetalle.Descuento = Decimal.Parse(reader["descuento"].ToString());
                ProformaDetalle.PrecioVenta = Decimal.Parse(reader["precioVenta"].ToString());
                ProformaDetalle.ValorVenta = Decimal.Parse(reader["valorVenta"].ToString());
                ProformaDetalle.Observacion = reader["Observacion"].ToString();
                ProformaDetalle.FlagAprobacion = Boolean.Parse(reader["FlagAprobacion"].ToString());
                ProformaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ProformaDetallelist.Add(ProformaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ProformaDetallelist;
        }
    }
}
