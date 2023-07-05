using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class PromocionBultoDetalleDL
	{
        public PromocionBultoDetalleDL() { }

        public void Inserta(PromocionBultoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBultoDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdPromocionBultoDetalle", DbType.Int32, pItem.IdPromocionBultoDetalle);
            db.AddInParameter(dbCommand, "pIdPromocionBulto", DbType.Int32, pItem.IdPromocionBulto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(PromocionBultoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBultoDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdPromocionBultoDetalle", DbType.Int32, pItem.IdPromocionBultoDetalle);
            db.AddInParameter(dbCommand, "pIdPromocionBulto", DbType.Int32, pItem.IdPromocionBulto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PromocionBultoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBultoDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdPromocionBultoDetalle", DbType.Int32, pItem.IdPromocionBultoDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<PromocionBultoDetalleBE> ListaTodosActivo(int IdPromocionBulto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBultoDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPromocionBulto", DbType.Int32, IdPromocionBulto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionBultoDetalleBE> PromocionBultoDetallelist = new List<PromocionBultoDetalleBE>();
            PromocionBultoDetalleBE PromocionBultoDetalle;
            while (reader.Read())
            {
                PromocionBultoDetalle = new PromocionBultoDetalleBE();
                PromocionBultoDetalle.IdPromocionBultoDetalle = Int32.Parse(reader["IdPromocionBultoDetalle"].ToString());
                PromocionBultoDetalle.IdPromocionBulto = Int32.Parse(reader["IdPromocionBulto"].ToString());
                PromocionBultoDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                PromocionBultoDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PromocionBultoDetalle.NombreProducto = reader["NombreProducto"].ToString();
                PromocionBultoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PromocionBultoDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionBultoDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PromocionBultoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionBultoDetallelist.Add(PromocionBultoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PromocionBultoDetallelist;
        }

        public PromocionBultoDetalleBE Selecciona(int IdPromocionBultoDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBultoDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pIdPromocionBultoDetalle", DbType.Int32, IdPromocionBultoDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PromocionBultoDetalleBE PromocionBultoDetalle = null;
            while (reader.Read())
            {
                PromocionBultoDetalle = new PromocionBultoDetalleBE();
                PromocionBultoDetalle.IdPromocionBultoDetalle = Int32.Parse(reader["IdPromocionBultoDetalle"].ToString());
                PromocionBultoDetalle.IdPromocionBulto = Int32.Parse(reader["IdPromocionBulto"].ToString());
                PromocionBultoDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                PromocionBultoDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PromocionBultoDetalle.NombreProducto = reader["NombreProducto"].ToString();
                PromocionBultoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PromocionBultoDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionBultoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
           }
            reader.Close();
            reader.Dispose();
            return PromocionBultoDetalle;
        }

        public List<PromocionBultoDetalleBE> ListaTipoClienteFormapago(int IdEmpresa, int IdTipoCliente, int IdFormaPago, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionBultoDetalle_ListaTipoClienteFormapago");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionBultoDetalleBE> PromocionBultoDetallelist = new List<PromocionBultoDetalleBE>();
            PromocionBultoDetalleBE PromocionBultoDetalle;
            while (reader.Read())
            {
                PromocionBultoDetalle = new PromocionBultoDetalleBE();
                PromocionBultoDetalle.IdPromocionBultoDetalle = Int32.Parse(reader["IdPromocionBultoDetalle"].ToString());
                PromocionBultoDetalle.IdPromocionBulto = Int32.Parse(reader["IdPromocionBulto"].ToString());
                PromocionBultoDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                PromocionBultoDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PromocionBultoDetalle.NombreProducto = reader["NombreProducto"].ToString();
                PromocionBultoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PromocionBultoDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionBultoDetalle.CantidadBulto = Int32.Parse(reader["CantidadBulto"].ToString());
                PromocionBultoDetalle.CantidadBultos = Int32.Parse(reader["CantidadBultos"].ToString());
                PromocionBultoDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionBultoDetallelist.Add(PromocionBultoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PromocionBultoDetallelist;
        }


	}
}
