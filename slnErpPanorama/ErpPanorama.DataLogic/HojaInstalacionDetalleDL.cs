using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
	public class HojaInstalacionDetalleDL
	{
		public HojaInstalacionDetalleDL() { }

		public Int32 Inserta(HojaInstalacionDetalleBE pItem)
		{
			Int32 Id = 0;
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacionDetalle_Inserta");

			db.AddOutParameter(dbCommand, "pIdHojaInstalacionDetalle", DbType.Int32, pItem.IdHojaInstalacionDetalle);
			db.AddInParameter(dbCommand, "pIdHojaInstalacion", DbType.Int32, pItem.IdHojaInstalacion);
			db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);

			Id = (int)db.GetParameterValue(dbCommand, "pIdHojaInstalacionDetalle");

			return Id;
		}

		public void Actualiza(HojaInstalacionDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacionDetalle_Actualiza");

			db.AddInParameter(dbCommand, "pIdHojaInstalacionDetalle", DbType.Int32, pItem.IdHojaInstalacionDetalle);
			db.AddInParameter(dbCommand, "pIdHojaInstalacion", DbType.Int32, pItem.IdHojaInstalacion);
			db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
			db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public void Elimina(HojaInstalacionDetalleBE pItem)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacionDetalle_Elimina");

			db.AddInParameter(dbCommand, "pIdHojaInstalacionDetalle", DbType.Int32, pItem.IdHojaInstalacionDetalle);
			db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
			db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
			db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

			db.ExecuteNonQuery(dbCommand);
		}

		public List<HojaInstalacionDetalleBE> ListaTodosActivo(int IdHojaInstalacion)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacionDetalle_ListaTodosActivo");
			db.AddInParameter(dbCommand, "pIdHojaInstalacion", DbType.Int32, IdHojaInstalacion);

			IDataReader reader = db.ExecuteReader(dbCommand);
			List<HojaInstalacionDetalleBE> HojaInstalacionDetallelist = new List<HojaInstalacionDetalleBE>();
			HojaInstalacionDetalleBE HojaInstalacionDetalle;
			while (reader.Read())
			{
				HojaInstalacionDetalle = new HojaInstalacionDetalleBE();
				HojaInstalacionDetalle.IdHojaInstalacionDetalle = Int32.Parse(reader["IdHojaInstalacionDetalle"].ToString());
				HojaInstalacionDetalle.IdHojaInstalacion = Int32.Parse(reader["IdHojaInstalacion"].ToString());
				HojaInstalacionDetalle.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                HojaInstalacionDetalle.NumeroPedido = reader["NumeroPedido"].ToString();
                HojaInstalacionDetalle.Total = Decimal.Parse(reader["Total"].ToString());
                HojaInstalacionDetalle.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                HojaInstalacionDetalle.DescSituacion = reader["DescSituacion"].ToString();
                HojaInstalacionDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                HojaInstalacionDetalle.TipoOper = 4;
                //HojaInstalacionDetalle.IdHojaInstalacionDetalle = reader.IsDBNull(reader.GetOrdinal("IdHojaInstalacionDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHojaInstalacionDetalle"));
                HojaInstalacionDetallelist.Add(HojaInstalacionDetalle);
			}
			reader.Close();
			reader.Dispose();
			return HojaInstalacionDetallelist;
		}

		public HojaInstalacionDetalleBE Selecciona(int IdHojaInstalacionDetalle)
		{
			Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
			DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacionDetalle_Selecciona");
			db.AddInParameter(dbCommand, "pIdHojaInstalacionDetalle", DbType.Int32, IdHojaInstalacionDetalle);

			IDataReader reader = db.ExecuteReader(dbCommand);
			HojaInstalacionDetalleBE HojaInstalacionDetalle = null;
			while (reader.Read())
			{
				HojaInstalacionDetalle = new HojaInstalacionDetalleBE();
				HojaInstalacionDetalle.IdHojaInstalacionDetalle = Int32.Parse(reader["IdHojaInstalacionDetalle"].ToString());
				HojaInstalacionDetalle.IdHojaInstalacion = Int32.Parse(reader["IdHojaInstalacion"].ToString());
				HojaInstalacionDetalle.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                HojaInstalacionDetalle.NumeroPedido = reader["NumeroPedido"].ToString();
                HojaInstalacionDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
				//HojaInstalacionDetalle.IdHojaInstalacionDetalle = reader.IsDBNull(reader.GetOrdinal("IdHojaInstalacionDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHojaInstalacionDetalle"));
			}
			reader.Close();
			reader.Dispose();
			return HojaInstalacionDetalle;
		}

        public HojaInstalacionDetalleBE SeleccionaPedido(int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HojaInstalacionDetalle_SeleccionaPedido");
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            IDataReader reader = db.ExecuteReader(dbCommand);
            HojaInstalacionDetalleBE HojaInstalacionDetalle = null;
            while (reader.Read())
            {
                HojaInstalacionDetalle = new HojaInstalacionDetalleBE();
                HojaInstalacionDetalle.IdHojaInstalacionDetalle = Int32.Parse(reader["IdHojaInstalacionDetalle"].ToString());
                HojaInstalacionDetalle.IdHojaInstalacion = Int32.Parse(reader["IdHojaInstalacion"].ToString());
                HojaInstalacionDetalle.IdPedido = Int32.Parse(reader["IdPedido"].ToString());
                HojaInstalacionDetalle.NumeroPedido = reader["NumeroPedido"].ToString();
                HojaInstalacionDetalle.Total = Decimal.Parse(reader["Total"].ToString());
                HojaInstalacionDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                HojaInstalacionDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                //HojaInstalacionDetalle.IdHojaInstalacionDetalle = reader.IsDBNull(reader.GetOrdinal("IdHojaInstalacionDetalle")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdHojaInstalacionDetalle"));
            }
            reader.Close();
            reader.Dispose();
            return HojaInstalacionDetalle;
        }

    }
}
