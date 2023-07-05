using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Promocion2x1DetalleDL
    {
        public Promocion2x1DetalleDL() { }

        public void Inserta(Promocion2x1DetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1Detalle_Inserta");

            db.AddInParameter(dbCommand, "pIdPromocion2x1Detalle", DbType.Int32, pItem.IdPromocion2x1Detalle);
            db.AddInParameter(dbCommand, "pIdPromocion2x1", DbType.Int32, pItem.IdPromocion2x1);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Promocion2x1DetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1Detalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdPromocion2x1Detalle", DbType.Int32, pItem.IdPromocion2x1Detalle);
            db.AddInParameter(dbCommand, "pIdPromocion2x1", DbType.Int32, pItem.IdPromocion2x1);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Promocion2x1DetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1Detalle_Elimina");

            db.AddInParameter(dbCommand, "pIdPromocion2x1Detalle", DbType.Int32, pItem.IdPromocion2x1Detalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void EliminaTodo(Promocion2x1DetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1Detalle_EliminaTodo");

            db.AddInParameter(dbCommand, "pIdPromocion2x1", DbType.Int32, pItem.IdPromocion2x1);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Promocion2x1DetalleBE> ListaTodosActivo(int IdPromocion2x1)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1Detalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPromocion2x1", DbType.Int32, IdPromocion2x1);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Promocion2x1DetalleBE> Promocion2x1Detallelist = new List<Promocion2x1DetalleBE>();
            Promocion2x1DetalleBE Promocion2x1Detalle;
            while (reader.Read())
            {
                Promocion2x1Detalle = new Promocion2x1DetalleBE();
                Promocion2x1Detalle.IdPromocion2x1 = Int32.Parse(reader["IdPromocion2x1"].ToString());
                Promocion2x1Detalle.IdPromocion2x1Detalle = Int32.Parse(reader["IdPromocion2x1Detalle"].ToString());
                Promocion2x1Detalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Promocion2x1Detalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Promocion2x1Detalle.NombreProducto = reader["NombreProducto"].ToString();
                Promocion2x1Detalle.Abreviatura = reader["Abreviatura"].ToString();
                Promocion2x1Detalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                Promocion2x1Detalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Promocion2x1Detalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Promocion2x1Detalle.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Promocion2x1Detalle.Usuario = reader["Usuario"].ToString();
                Promocion2x1Detalle.Maquina = reader["Maquina"].ToString();
                Promocion2x1Detalle.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                Promocion2x1Detalle.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                Promocion2x1Detalle.AlmacenAndahuaylas = Int32.Parse(reader["AlmacenAndahuaylas"].ToString());
                Promocion2x1Detalle.AlmacenPrescott = Int32.Parse(reader["AlmacenPrescott"].ToString());
                Promocion2x1Detalle.AlmacenAviacion = Int32.Parse(reader["AlmacenAviacion"].ToString());
                Promocion2x1Detalle.AlmacenMegaPlaza = Int32.Parse(reader["AlmacenMegaPlaza"].ToString());
                Promocion2x1Detalle.DescLineaProducto = reader["DescLineaProducto"].ToString();
                Promocion2x1Detalle.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                Promocion2x1Detalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Promocion2x1Detallelist.Add(Promocion2x1Detalle);
            }
            reader.Close();
            reader.Dispose();
            return Promocion2x1Detallelist;
        }

        public List<Promocion2x1DetalleBE> ListaTipoClienteFormapago(int IdEmpresa, int IdTipoCliente, int IdFormaPago, string Tipo, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1Detalle_ListaTipoClienteFormapago");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pTipo", DbType.String, Tipo);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Promocion2x1DetalleBE> Promocion2x1Detallelist = new List<Promocion2x1DetalleBE>();
            Promocion2x1DetalleBE Promocion2x1Detalle;
            while (reader.Read())
            {
                Promocion2x1Detalle = new Promocion2x1DetalleBE();
                Promocion2x1Detalle.IdPromocion2x1 = Int32.Parse(reader["IdPromocion2x1"].ToString());
                Promocion2x1Detalle.IdPromocion2x1Detalle = Int32.Parse(reader["IdPromocion2x1Detalle"].ToString());
                Promocion2x1Detalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                //Promocion2x1Detalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                //Promocion2x1Detalle.NombreProducto = reader["NombreProducto"].ToString();
                //Promocion2x1Detalle.Abreviatura = reader["Abreviatura"].ToString();
                Promocion2x1Detalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                Promocion2x1Detalle.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Promocion2x1Detalle.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Promocion2x1Detalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Promocion2x1Detalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Promocion2x1Detallelist.Add(Promocion2x1Detalle);
            }
            reader.Close();
            reader.Dispose();
            return Promocion2x1Detallelist;
        }

        public Promocion2x1DetalleBE SeleccionaProducto(int IdEmpresa, int IdTipoCliente, int IdFormaPago, int IdTienda, int IdProducto, string Tipo, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1Detalle_SeleccionaProducto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pTipo", DbType.String, Tipo);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            Promocion2x1DetalleBE Promocion2x1Detalle = null;
            while (reader.Read())
            {
                Promocion2x1Detalle = new Promocion2x1DetalleBE();
                Promocion2x1Detalle.IdPromocion2x1 = Int32.Parse(reader["IdPromocion2x1"].ToString());
                Promocion2x1Detalle.IdPromocion2x1Detalle = Int32.Parse(reader["IdPromocion2x1Detalle"].ToString());
                Promocion2x1Detalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Promocion2x1Detalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                Promocion2x1Detalle.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                Promocion2x1Detalle.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                Promocion2x1Detalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Promocion2x1Detalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Promocion2x1Detalle;
        }

    }
}
