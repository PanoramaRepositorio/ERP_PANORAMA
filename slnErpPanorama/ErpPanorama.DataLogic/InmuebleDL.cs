using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class InmuebleDL
    {
       public InmuebleDL() { }

        public void Inserta(InmuebleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inmueble_Inserta");

            db.AddInParameter(dbCommand, "pIdInmueble", DbType.Int32, pItem.IdInmueble);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoInmueble", DbType.Int32, pItem.IdTipoInmueble);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pDescInmueble", DbType.String, pItem.DescInmueble);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pPrecioAlquiler", DbType.Decimal, pItem.PrecioAlquiler);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(InmuebleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inmueble_Actualiza");

            db.AddInParameter(dbCommand, "pIdInmueble", DbType.Int32, pItem.IdInmueble);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoInmueble", DbType.Int32, pItem.IdTipoInmueble);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
            db.AddInParameter(dbCommand, "pDescInmueble", DbType.String, pItem.DescInmueble);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pPrecioAlquiler", DbType.Decimal, pItem.PrecioAlquiler);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(InmuebleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inmueble_Elimina");

            db.AddInParameter(dbCommand, "pIdInmueble", DbType.Int32, pItem.IdInmueble);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<InmuebleBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inmueble_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InmuebleBE> Inmueblelist = new List<InmuebleBE>();
            InmuebleBE Inmueble;
            while (reader.Read())
            {
                Inmueble = new InmuebleBE();
                Inmueble.IdInmueble = Int32.Parse(reader["IdInmueble"].ToString());
                Inmueble.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Inmueble.RazonSocial = reader["RazonSocial"].ToString();
                Inmueble.IdTipoInmueble = Int32.Parse(reader["IdTipoInmueble"].ToString());
                Inmueble.DescTipoInmueble = reader["DescTipoInmueble"].ToString();
                Inmueble.Direccion = reader["Direccion"].ToString();
                Inmueble.IdUbigeo = reader["IdUbigeo"].ToString();
                Inmueble.NomDpto = reader["NomDpto"].ToString();
                Inmueble.NomProv = reader["NomProv"].ToString();
                Inmueble.NomDist = reader["NomDist"].ToString();
                Inmueble.DescInmueble = reader["DescInmueble"].ToString();
                Inmueble.PrecioVenta = Decimal.Parse (reader["PrecioVenta"].ToString());
                Inmueble.PrecioAlquiler = Decimal.Parse(reader["PrecioAlquiler"].ToString());
                //Inmueble.Imagen = (byte[])reader["Imagen"];
                Inmueble.Observacion = reader["Observacion"].ToString();
                Inmueble.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Inmueblelist.Add(Inmueble);
            }
            reader.Close();
            reader.Dispose();
            return Inmueblelist;
        }

        public InmuebleBE Selecciona(int IdInmueble)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Inmueble_Selecciona");
            db.AddInParameter(dbCommand, "pIdInmueble", DbType.Int32, IdInmueble);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InmuebleBE Inmueble = null;
            while (reader.Read())
            {
                Inmueble = new InmuebleBE();
                Inmueble.IdInmueble = Int32.Parse(reader["IdInmueble"].ToString());
                Inmueble.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Inmueble.RazonSocial = reader["RazonSocial"].ToString();
                Inmueble.IdTipoInmueble = Int32.Parse(reader["IdTipoInmueble"].ToString());
                Inmueble.DescTipoInmueble = reader["DescTipoInmueble"].ToString();
                Inmueble.Direccion = reader["Direccion"].ToString();
                Inmueble.IdUbigeo = reader["IdUbigeo"].ToString();
                Inmueble.NomDpto = reader["NomDpto"].ToString();
                Inmueble.NomProv = reader["NomProv"].ToString();
                Inmueble.NomDist = reader["NomDist"].ToString();
                Inmueble.DescInmueble = reader["DescInmueble"].ToString();
                Inmueble.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                Inmueble.PrecioAlquiler = Decimal.Parse(reader["PrecioAlquiler"].ToString());
                Inmueble.Imagen = (byte[])reader["Imagen"];
                Inmueble.Observacion = reader["Observacion"].ToString();
                Inmueble.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Inmueble;
        }
    }
}
