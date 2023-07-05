using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReportePersonaDL
    {
        public List<ReportePersonaBE> Listado(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptPersonal");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReportePersonaBE> Personallist = new List<ReportePersonaBE>();
            ReportePersonaBE Personal;
            while (reader.Read())
            {
                Personal = new ReportePersonaBE();
                Personal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Personal.IdPersona = Int32.Parse(reader["idPersona"].ToString());
                Personal.Dni = reader["Dni"].ToString();
                Personal.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                Personal.DescSexo = reader["DescSexo"].ToString();
                Personal.Nombres = reader["Nombres"].ToString();
                Personal.Apellidos = reader["Apellidos"].ToString();
                Personal.ApeNom = reader["ApeNom"].ToString();
                Personal.IdCargo = Int32.Parse(reader["IdCargo"].ToString());
                Personal.DescCargo = reader["DescCargo"].ToString();
                Personal.Essalud = reader["Essalud"].ToString();
                Personal.FlagEps = Boolean.Parse(reader["FlagEps"].ToString());
                Personal.FlagSctr = Boolean.Parse(reader["FlagSctr"].ToString());
                Personal.FlagOnp = Boolean.Parse(reader["FlagOnp"].ToString());
                Personal.IdPlaAfp = Int32.Parse(reader["IdPlaAfp"].ToString());
                Personal.DescPlaAfp = reader["DescPlaAfp"].ToString();
                Personal.Brevete = reader["Brevete"].ToString();
                Personal.IdEstadoCivil = Int32.Parse(reader["IdEstadoCivil"].ToString());
                Personal.DescEstadoCivil = reader["DescEstadoCivil"].ToString();
                Personal.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                Personal.IdUbigeo = reader["IdUbigeo"].ToString();
                Personal.NomDpto = reader["NomDpto"].ToString();
                Personal.NomProv = reader["NomProv"].ToString();
                Personal.NomDist = reader["NomDist"].ToString();
                Personal.Direccion = reader["Direccion"].ToString();
                Personal.Telefono = reader["Telefono"].ToString();
                Personal.Celular = reader["Celular"].ToString();
                Personal.TelefonoOtro = reader["TelefonoOtro"].ToString();
                Personal.Email = reader["Email"].ToString();
                Personal.Foto = (byte[])reader["Foto"];
                Personal.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Personal.DescArea = reader["DescArea"].ToString();
                Personal.Observacion = reader["Observacion"].ToString();
                Personal.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());
                Personal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Personallist.Add(Personal);
            }
            reader.Close();
            reader.Dispose();
            return Personallist;
        }
    }
}
