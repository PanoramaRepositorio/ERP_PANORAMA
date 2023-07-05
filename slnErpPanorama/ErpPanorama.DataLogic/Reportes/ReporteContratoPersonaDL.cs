using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteContratoPersonaDL
    {
        public List<ReporteContratoPersonaBE> Listado(int IdContrato)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptContratoPersona");
            db.AddInParameter(dbCommand, "pIdContrato", DbType.Int32, IdContrato);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteContratoPersonaBE> ContratoPersonalist = new List<ReporteContratoPersonaBE>();
            ReporteContratoPersonaBE ContratoPersona;
            while (reader.Read())
            {
                ContratoPersona = new ReporteContratoPersonaBE();
                ContratoPersona.DescTipoContrato = reader["DescTipoContrato"].ToString();
                ContratoPersona.Descripcion = reader["Descripcion"].ToString();
                ContratoPersona.Titulo = reader["Titulo"].ToString();
                ContratoPersona.Cuerpo = reader["Cuerpo"].ToString();
                ContratoPersona.Firma = reader["Firma"].ToString();
                ContratoPersona.Ruc = reader["Ruc"].ToString();
                ContratoPersona.RazonSocial = reader["RazonSocial"].ToString();
                ContratoPersona.NombreGerente = reader["NombreGerente"].ToString();
                ContratoPersona.DniGerente = reader["DniGerente"].ToString();
                ContratoPersona.DireccionEmpresa = reader["DireccionEmpresa"].ToString();
                ContratoPersona.Dni = reader["Dni"].ToString();
                ContratoPersona.ApeNom = reader["ApeNom"].ToString();
                ContratoPersona.Direccion = reader["Direccion"].ToString();
                ContratoPersona.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                ContratoPersona.HoraExtra = Decimal.Parse(reader["HoraExtra"].ToString());
                ContratoPersona.BonSueldo = Decimal.Parse(reader["BonSueldo"].ToString());
                ContratoPersona.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                ContratoPersona.Dias = Int32.Parse(reader["Dias"].ToString());
                ContratoPersona.Meses = Int32.Parse(reader["Meses"].ToString());
                ContratoPersona.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                ContratoPersona.FechaVen = DateTime.Parse(reader["FechaVen"].ToString());
                ContratoPersona.DescCargo = reader["DescCargo"].ToString();
                ContratoPersona.DescArea = reader["DescArea"].ToString();
                ContratoPersona.Horario = reader["Horario"].ToString();

                ContratoPersona.Discapacidad = reader["Discapacidad"].ToString();
                ContratoPersona.SituacionEspecial = reader["SituacionEspecial"].ToString();
                ContratoPersona.ClasificacionPuesto = reader["ClasificacionPuesto"].ToString();
                ContratoPersona.EstadoCivil = reader["EstadoCivil"].ToString();

                ContratoPersona.FechaContratoIni = reader["FechaContratoInicio"].ToString();
                ContratoPersona.FechaContratoFin = reader["FechaContratoFin"].ToString();

                ContratoPersonalist.Add(ContratoPersona);
            }
            reader.Close();
            reader.Dispose();
            return ContratoPersonalist;
        }
    }
}

