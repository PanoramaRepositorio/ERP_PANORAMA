using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class DescuentoClientePromocionDetalleDL
	{
		public DescuentoClientePromocionDetalleDL() { }

		public void Inserta(DescuentoClientePromocionDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocionDetalle_Inserta");

			db.AddOutParameter(dbCommand, "pIdDescuentoClientePromocionDetalle", DbType.Int32, pItem.IdDescuentoClientePromocionDetalle);
			db.AddInParameter(dbCommand, "pIdDescuentoClientePromocion", DbType.Int32, pItem.IdDescuentoClientePromocion);
			db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
			db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

		}

		public void Actualiza(DescuentoClientePromocionDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocionDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdDescuentoClientePromocionDetalle", DbType.Int32, pItem.IdDescuentoClientePromocionDetalle);
			db.AddInParameter(dbCommand, "pIdDescuentoClientePromocion", DbType.Int32, pItem.IdDescuentoClientePromocion);
			db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
			db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(DescuentoClientePromocionDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocionDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdDescuentoClientePromocionDetalle", DbType.Int32, pItem.IdDescuentoClientePromocionDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

        public void EliminaTodo(DescuentoClientePromocionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocionDetalle_EliminaTodo");

            db.AddInParameter(dbCommand, "pIdDescuentoClientePromocion", DbType.Int32, pItem.IdDescuentoClientePromocion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DescuentoClientePromocionDetalleBE> ListaTodosActivo(int IdDescuentoClientePromocion)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocionDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdDescuentoClientePromocion", DbType.Int32, IdDescuentoClientePromocion);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<DescuentoClientePromocionDetalleBE> DescuentoClientePromocionDetallelist = new List<DescuentoClientePromocionDetalleBE>();
			DescuentoClientePromocionDetalleBE DescuentoClientePromocionDetalle;
			while (reader.Read())
			{
				DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleBE();
				DescuentoClientePromocionDetalle.IdDescuentoClientePromocionDetalle = Int32.Parse(reader["IdDescuentoClientePromocionDetalle"].ToString());
				DescuentoClientePromocionDetalle.IdDescuentoClientePromocion = Int32.Parse(reader["IdDescuentoClientePromocion"].ToString());
				DescuentoClientePromocionDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                DescuentoClientePromocionDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                DescuentoClientePromocionDetalle.NombreProducto = reader["NombreProducto"].ToString();
                DescuentoClientePromocionDetalle.Abreviatura = reader["Abreviatura"].ToString();
				DescuentoClientePromocionDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                DescuentoClientePromocionDetalle.DescuentoActual = Decimal.Parse(reader["DescuentoActual"].ToString());
                DescuentoClientePromocionDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                DescuentoClientePromocionDetalle.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                DescuentoClientePromocionDetalle.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                DescuentoClientePromocionDetalle.AlmacenAndahuaylas = Int32.Parse(reader["AlmacenAndahuaylas"].ToString());
                DescuentoClientePromocionDetalle.AlmacenPrescott = Int32.Parse(reader["AlmacenPrescott"].ToString());
                DescuentoClientePromocionDetalle.AlmacenAviacion = Int32.Parse(reader["AlmacenAviacion"].ToString());
                DescuentoClientePromocionDetalle.AlmacenMegaPlaza = Int32.Parse(reader["AlmacenMegaPlaza"].ToString());
				DescuentoClientePromocionDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                DescuentoClientePromocionDetalle.TipoOper = 4; //Consultar
				//DescuentoClientePromocionDetalle.IdDescuentoClientePromocionDetalle = reader.IsDBNull(reader.GetOrdinal("IdDescuentoClientePromocionDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDescuentoClientePromocionDetalle"));
				DescuentoClientePromocionDetallelist.Add(DescuentoClientePromocionDetalle);
			}
			reader.Close();
			reader.Dispose();
			return DescuentoClientePromocionDetallelist;
		}

		public DescuentoClientePromocionDetalleBE Selecciona(int IdDescuentoClientePromocionDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocionDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdDescuentoClientePromocionDetalle", DbType.Int32, IdDescuentoClientePromocionDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			DescuentoClientePromocionDetalleBE DescuentoClientePromocionDetalle = null;
			while (reader.Read())
			{
				DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleBE();
				DescuentoClientePromocionDetalle.IdDescuentoClientePromocionDetalle = Int32.Parse(reader["IdDescuentoClientePromocionDetalle"].ToString());
				DescuentoClientePromocionDetalle.IdDescuentoClientePromocion = Int32.Parse(reader["IdDescuentoClientePromocion"].ToString());
				DescuentoClientePromocionDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                DescuentoClientePromocionDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                DescuentoClientePromocionDetalle.NombreProducto = reader["NombreProducto"].ToString();
                DescuentoClientePromocionDetalle.Abreviatura = reader["Abreviatura"].ToString();
				DescuentoClientePromocionDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
				DescuentoClientePromocionDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//DescuentoClientePromocionDetalle.IdDescuentoClientePromocionDetalle = reader.IsDBNull(reader.GetOrdinal("IdDescuentoClientePromocionDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDescuentoClientePromocionDetalle"));
			}
			reader.Close();
			reader.Dispose();
			return DescuentoClientePromocionDetalle;
		}

        public DescuentoClientePromocionDetalleBE SeleccionaProducto(int IdDescuentoClientePromocion, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClientePromocionDetalle_SeleccionaProducto");
            db.AddInParameter(dbCommand, "pIdDescuentoClientePromocion", DbType.Int32, IdDescuentoClientePromocion);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DescuentoClientePromocionDetalleBE DescuentoClientePromocionDetalle = null;
            while (reader.Read())
            {
                DescuentoClientePromocionDetalle = new DescuentoClientePromocionDetalleBE();
                DescuentoClientePromocionDetalle.IdDescuentoClientePromocionDetalle = Int32.Parse(reader["IdDescuentoClientePromocionDetalle"].ToString());
                DescuentoClientePromocionDetalle.IdDescuentoClientePromocion = Int32.Parse(reader["IdDescuentoClientePromocion"].ToString());
                DescuentoClientePromocionDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                DescuentoClientePromocionDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                DescuentoClientePromocionDetalle.NombreProducto = reader["NombreProducto"].ToString();
                DescuentoClientePromocionDetalle.Abreviatura = reader["Abreviatura"].ToString();
                DescuentoClientePromocionDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                DescuentoClientePromocionDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //DescuentoClientePromocionDetalle.IdDescuentoClientePromocionDetalle = reader.IsDBNull(reader.GetOrdinal("IdDescuentoClientePromocionDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdDescuentoClientePromocionDetalle"));
            }
            reader.Close();
            reader.Dispose();
            return DescuentoClientePromocionDetalle;
        }

	}
}
