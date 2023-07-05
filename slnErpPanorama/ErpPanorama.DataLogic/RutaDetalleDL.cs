using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class RutaDetalleDL
    {
        public RutaDetalleDL() { }

        public void Inserta(RutaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RutaDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdRutaDetalle", DbType.Int32, pItem.IdRutaDetalle);
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, pItem.IdRuta);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(RutaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RutaDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdRutaDetalle", DbType.Int32, pItem.IdRutaDetalle);
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, pItem.IdRuta);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(RutaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RutaDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdRutaDetalle", DbType.Int32, pItem.IdRutaDetalle);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<RutaDetalleBE> ListaTodosActivo(int IdRuta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RutaDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, IdRuta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<RutaDetalleBE> RutaDetallelist = new List<RutaDetalleBE>();
            RutaDetalleBE RutaDetalle;
            while (reader.Read())
            {
                RutaDetalle = new RutaDetalleBE();
                RutaDetalle.IdRutaDetalle = Int32.Parse(reader["IdRutaDetalle"].ToString());
                RutaDetalle.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                RutaDetalle.DescRuta = reader["DescRuta"].ToString();
                RutaDetalle.IdUbigeo = reader["IdUbigeo"].ToString();
                RutaDetalle.NomDpto = reader["NomDpto"].ToString();
                RutaDetalle.NomProv = reader["NomProv"].ToString();
                RutaDetalle.NomDist = reader["NomDist"].ToString();
                RutaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                RutaDetallelist.Add(RutaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return RutaDetallelist;
        }

        public RutaDetalleBE Selecciona(int IdRutaDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RutaDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pIdRutaDetalle", DbType.Int32, IdRutaDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            RutaDetalleBE RutaDetalle=null;
            while (reader.Read())
            {
                RutaDetalle = new RutaDetalleBE();
                RutaDetalle.IdRutaDetalle = Int32.Parse(reader["IdRutaDetalle"].ToString());
                RutaDetalle.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                RutaDetalle.DescRuta = reader["DescRuta"].ToString();
                RutaDetalle.IdUbigeo = reader["IdUbigeo"].ToString();
                RutaDetalle.NomDpto = reader["NomDpto"].ToString();
                RutaDetalle.NomProv = reader["NomProv"].ToString();
                RutaDetalle.NomDist = reader["NomDist"].ToString();
                RutaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return RutaDetalle;
        }

        public RutaDetalleBE SeleccionaUbigeo(string IdUbigeo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_RutaDetalle_SeleccionaUbigeo");
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, IdUbigeo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            RutaDetalleBE RutaDetalle = null;
            while (reader.Read())
            {
                RutaDetalle = new RutaDetalleBE();
                RutaDetalle.IdRutaDetalle = Int32.Parse(reader["IdRutaDetalle"].ToString());
                RutaDetalle.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                RutaDetalle.DescRuta = reader["DescRuta"].ToString();
                RutaDetalle.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                RutaDetalle.DescVendedor = reader["DescVendedor"].ToString();
                RutaDetalle.IdUbigeo = reader["IdUbigeo"].ToString();
                RutaDetalle.NomDpto = reader["NomDpto"].ToString();
                RutaDetalle.NomProv = reader["NomProv"].ToString();
                RutaDetalle.NomDist = reader["NomDist"].ToString();
                RutaDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return RutaDetalle;
        }
    }
}
