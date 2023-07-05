using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class NovioRegaloDetalleDL
    {
        public NovioRegaloDetalleDL() { }

        public Int32 Inserta(NovioRegaloDetalleBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegaloDetalle_Inserta");

            db.AddOutParameter(dbCommand, "pIdNovioRegaloDetalle", DbType.Int32, pItem.IdNovioRegaloDetalle);
            db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, pItem.IdNovioRegalo);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Decimal, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Decimal, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagComprado", DbType.Boolean, pItem.FlagComprado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdNovioRegaloDetalle");

            return Id;
        }

        public void Actualiza(NovioRegaloDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegaloDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdNovioRegaloDetalle", DbType.Int32, pItem.IdNovioRegaloDetalle);
            db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, pItem.IdNovioRegalo);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Decimal, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pPorcentajeDescuento", DbType.Decimal, pItem.PorcentajeDescuento);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagComprado", DbType.Boolean, pItem.FlagComprado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(NovioRegaloDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegaloDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdNovioRegaloDetalle", DbType.Int32, pItem.IdNovioRegaloDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<NovioRegaloDetalleBE> ListaTodosActivo(int IdNovioRegalo,int IdAlmacen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegaloDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdNovioRegalo", DbType.Int32, IdNovioRegalo);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<NovioRegaloDetalleBE> NovioRegaloDetallelist = new List<NovioRegaloDetalleBE>();
            NovioRegaloDetalleBE NovioRegaloDetalle;
            while (reader.Read())
            {
                NovioRegaloDetalle = new NovioRegaloDetalleBE();
                NovioRegaloDetalle.IdNovioRegaloDetalle = Int32.Parse(reader["IdNovioRegaloDetalle"].ToString());
                NovioRegaloDetalle.IdNovioRegalo = Int32.Parse(reader["IdNovioRegalo"].ToString());
                NovioRegaloDetalle.Item = Int32.Parse(reader["Item"].ToString());
                NovioRegaloDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                NovioRegaloDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                NovioRegaloDetalle.NombreProducto = reader["NombreProducto"].ToString();
                NovioRegaloDetalle.Abreviatura = reader["Abreviatura"].ToString();
                NovioRegaloDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                NovioRegaloDetalle.CantidadStock = Int32.Parse(reader["CantidadStock"].ToString());
                NovioRegaloDetalle.CantidadCompra = Int32.Parse(reader["CantidadCompra"].ToString());
                NovioRegaloDetalle.CantidadSaldo = Int32.Parse(reader["CantidadSaldo"].ToString());
                NovioRegaloDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                NovioRegaloDetalle.PorcentajeDescuento = Decimal.Parse(reader["PorcentajeDescuento"].ToString());
                NovioRegaloDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                NovioRegaloDetalle.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                NovioRegaloDetalle.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                NovioRegaloDetalle.Observacion = reader["Observacion"].ToString();
                NovioRegaloDetalle.FlagComprado = Boolean.Parse(reader["FlagComprado"].ToString());
                NovioRegaloDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                NovioRegaloDetalle.TipoOper = 4;
                NovioRegaloDetallelist.Add(NovioRegaloDetalle);
            }
            reader.Close();
            reader.Dispose();
            return NovioRegaloDetallelist;
        }

        public NovioRegaloDetalleBE Selecciona(int IdNovioRegaloDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NovioRegaloDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pIdNovioRegaloDetalle", DbType.Int32, IdNovioRegaloDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            NovioRegaloDetalleBE NovioRegaloDetalle = null;
            while (reader.Read())
            {
                NovioRegaloDetalle = new NovioRegaloDetalleBE();
                NovioRegaloDetalle.IdNovioRegaloDetalle = Int32.Parse(reader["IdNovioRegaloDetalle"].ToString());
                NovioRegaloDetalle.IdNovioRegalo = Int32.Parse(reader["IdNovioRegalo"].ToString());
                NovioRegaloDetalle.Item = Int32.Parse(reader["Item"].ToString());
                NovioRegaloDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                NovioRegaloDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                NovioRegaloDetalle.NombreProducto = reader["NombreProducto"].ToString();
                NovioRegaloDetalle.Abreviatura = reader["Abreviatura"].ToString();
                NovioRegaloDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                NovioRegaloDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                NovioRegaloDetalle.PorcentajeDescuento = Decimal.Parse(reader["PorcentajeDescuento"].ToString());
                NovioRegaloDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                NovioRegaloDetalle.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                NovioRegaloDetalle.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                NovioRegaloDetalle.Observacion = reader["Observacion"].ToString();
                NovioRegaloDetalle.FlagComprado = Boolean.Parse(reader["FlagComprado"].ToString());
                NovioRegaloDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return NovioRegaloDetalle;
        }

    }
}