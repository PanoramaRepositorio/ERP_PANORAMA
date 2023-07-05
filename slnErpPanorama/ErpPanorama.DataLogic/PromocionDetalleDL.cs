using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PromocionDetalleDL
    {
        public PromocionDetalleDL() { }

        public void Inserta(PromocionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdPromocionDetalle", DbType.Int32, pItem.IdPromocionDetalle);
            db.AddInParameter(dbCommand, "pIdPromocion", DbType.Int32, pItem.IdPromocion);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(PromocionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdPromocionDetalle", DbType.Int32, pItem.IdPromocionDetalle);
            db.AddInParameter(dbCommand, "pIdPromocion", DbType.Int32, pItem.IdPromocion);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PromocionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdPromocionDetalle", DbType.Int32, pItem.IdPromocionDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PromocionDetalleBE> ListaTodosActivo(int IdPromocion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPromocion", DbType.Int32, IdPromocion);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionDetalleBE> PromocionDetallelist = new List<PromocionDetalleBE>();
            PromocionDetalleBE PromocionDetalle;
            while (reader.Read())
            {
                PromocionDetalle = new PromocionDetalleBE();
                PromocionDetalle.IdPromocion = Int32.Parse(reader["idPromocion"].ToString());
                PromocionDetalle.IdPromocionDetalle = Int32.Parse(reader["idPromocionDetalle"].ToString());
                PromocionDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PromocionDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PromocionDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PromocionDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PromocionDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                PromocionDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                PromocionDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                PromocionDetalle.TipoOper = 4; //Consultar
                PromocionDetallelist.Add(PromocionDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PromocionDetallelist;
        }
    }
}
