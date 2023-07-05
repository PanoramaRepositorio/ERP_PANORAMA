using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AlertaContratoDL
    {
        public AlertaContratoDL() { }

        public List<AlertaContratoBE> ListaContratos()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Contrato_ListaVencidos");


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AlertaContratoBE> AlertaContratolist = new List<AlertaContratoBE>();
            AlertaContratoBE AlertaContrato;
            while (reader.Read())
            {
                AlertaContrato = new AlertaContratoBE();
                AlertaContrato.ApeNom = (reader["ApeNom"].ToString());
                AlertaContrato.Dni = reader["Dni"].ToString();
                //AlertaContrato.Direccion = reader["Direccion"].ToString();
                AlertaContrato.FechaVen = DateTime.Parse(reader["FechaVen"].ToString());

                AlertaContrato.RazonSocial = reader["RazonSocial"].ToString();
                AlertaContrato.DescTienda = reader["DescTienda"].ToString();
                AlertaContrato.DescArea = reader["DescArea"].ToString();
                AlertaContrato.DescCargo = reader["DescCargo"].ToString();

                AlertaContratolist.Add(AlertaContrato);
            }
            reader.Close();
            reader.Dispose();
            return AlertaContratolist;
        }

    }
}
