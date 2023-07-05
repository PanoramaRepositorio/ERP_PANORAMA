using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class UbigeoDL
    {
        public UbigeoDL() { }

        public List<UbigeoBE> SeleccionaDepartamento()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_Departamentos");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbigeoBE> Ubigeolist = new List<UbigeoBE>();
            UbigeoBE Ubigeo;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdDepartamento = reader["IdDepartamento"].ToString();
                Ubigeo.NomDpto = reader["NomDpto"].ToString();
                Ubigeolist.Add(Ubigeo);
            }
            reader.Close();
            reader.Dispose();
            return Ubigeolist;
        }

        public List<UbigeoBE> SeleccionaProvincia(string IdDepartamento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_Provincias");
            db.AddInParameter(dbCommand, "@pIdDepartamento", DbType.String, IdDepartamento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbigeoBE> Ubigeolist = new List<UbigeoBE>();
            UbigeoBE Ubigeo;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdProvincia = reader["IdProvincia"].ToString();
                Ubigeo.NomProv = reader["NomProv"].ToString();
                Ubigeolist.Add(Ubigeo);
            }
            reader.Close();
            reader.Dispose();
            return Ubigeolist;
        }

        public List<UbigeoBE> SeleccionaDistrito(string IdDepartamento, string IdProvincia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_Distritos");
            db.AddInParameter(dbCommand, "@pIdDepartamento", DbType.String, IdDepartamento);
            db.AddInParameter(dbCommand, "@pIdProvincia", DbType.String, IdProvincia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbigeoBE> Ubigeolist = new List<UbigeoBE>();
            UbigeoBE Ubigeo;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdDistrito = reader["IdDistrito"].ToString();
                Ubigeo.NomDist = reader["NomDist"].ToString();
                Ubigeolist.Add(Ubigeo);
            }
            reader.Close();
            reader.Dispose();
            return Ubigeolist;
        }

        public List<UbigeoBE> SeleccionaDistritoDelivery(string IdDepartamento, string IdProvincia)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_DistritosDelivery");
            db.AddInParameter(dbCommand, "@pIdDepartamento", DbType.String, IdDepartamento);
            db.AddInParameter(dbCommand, "@pIdProvincia", DbType.String, IdProvincia);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbigeoBE> Ubigeolist = new List<UbigeoBE>();
            UbigeoBE Ubigeo;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdDistrito = reader["IdDistrito"].ToString();
                Ubigeo.NomDist = reader["NomDist"].ToString();
                Ubigeolist.Add(Ubigeo);
            }
            reader.Close();
            reader.Dispose();
            return Ubigeolist;
        }

        public UbigeoBE Selecciona(string IdUbigeo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Ubigeo_Selecciona");
            db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, IdUbigeo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            UbigeoBE Ubigeo = null;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdUbigeo = reader["IdUbigeo"].ToString();
                Ubigeo.IdDepartamento = reader["IdDepartamento"].ToString();
                Ubigeo.IdProvincia = reader["IdProvincia"].ToString();
                Ubigeo.IdDistrito = reader["IdDistrito"].ToString();
                Ubigeo.DescUbigeo = reader["DescUbigeo"].ToString();
          //      Ubigeo.TarifaEnvio = Decimal.Parse(reader["TarifaEnvio"].ToString());
                Ubigeo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Ubigeo;
        }

        public UbigeoBE Selecciona_UbigeoxDistrito(string DesDistrito)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_Ubigeo_NomDistrito");
            db.AddInParameter(dbCommand, "pDesDistro", DbType.String, DesDistrito);

            IDataReader reader = db.ExecuteReader(dbCommand);
            UbigeoBE Ubigeo = null;
            while (reader.Read())
            {
                Ubigeo = new UbigeoBE();
                Ubigeo.IdUbigeo = reader["IdUbigeo"].ToString();
                Ubigeo.IdDepartamento = reader["IdDepartamento"].ToString();
                Ubigeo.IdProvincia = reader["IdProvincia"].ToString();
                Ubigeo.IdDistrito = reader["IdDistrito"].ToString();
                Ubigeo.DescUbigeo = reader["DescUbigeo"].ToString();
                Ubigeo.TarifaEnvio = Decimal.Parse(reader["TarifaEnvio"].ToString());
                Ubigeo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Ubigeo;
        }

        public List<UbigeoBE> Selecciona_UbigeoxDistrito2(string DesDistrito)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Selecciona_Ubigeo_NomDistrito");
            db.AddInParameter(dbCommand, "pDesDistro", DbType.String, DesDistrito.ToUpper());

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UbigeoBE> UbigeoDetallelist = new List<UbigeoBE>();
            UbigeoBE UbigeoDetalle;
            while (reader.Read())
            {
                UbigeoDetalle = new UbigeoBE();

                UbigeoDetalle.IdUbigeo = reader["IdUbigeo"].ToString();
                UbigeoDetalle.IdDepartamento = reader["IdDepartamento"].ToString();
                UbigeoDetalle.IdProvincia = reader["IdProvincia"].ToString();
                UbigeoDetalle.IdDistrito = reader["IdDistrito"].ToString();
                UbigeoDetalle.DescUbigeo = reader["DescUbigeo"].ToString();

                UbigeoDetalle.TarifaEnvio = Convert.ToDecimal( reader["TarifaEnvio"].ToString());


                UbigeoDetallelist.Add(UbigeoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return UbigeoDetallelist;
        }



    }
}
