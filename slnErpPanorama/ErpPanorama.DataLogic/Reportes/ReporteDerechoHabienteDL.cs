using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteDerechoHabienteDL
    {
        public List<ReporteDerechoHabienteBE> Listado(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptDerechoHabiente");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteDerechoHabienteBE> DerechoHabientelist = new List<ReporteDerechoHabienteBE>();
            ReporteDerechoHabienteBE DerechoHabiente;
            while (reader.Read())
            {
                DerechoHabiente = new ReporteDerechoHabienteBE();
                DerechoHabiente.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DerechoHabiente.IdDerechoHabiente = Int32.Parse(reader["idDerechoHabiente"].ToString());
                DerechoHabiente.IdSexo = Int32.Parse(reader["IdSexo"].ToString());
                DerechoHabiente.DescSexo = reader["DescSexo"].ToString();
                DerechoHabiente.IdParentesco = Int32.Parse(reader["IdParentesco"].ToString());
                DerechoHabiente.DescParentesco = reader["DescParentesco"].ToString();
                DerechoHabiente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                DerechoHabiente.ApeNom = reader["ApeNom"].ToString();
                DerechoHabiente.FechaNac = DateTime.Parse(reader["FechaNac"].ToString());
                DerechoHabiente.Ocupacion = reader["Ocupacion"].ToString();
                DerechoHabiente.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                DerechoHabientelist.Add(DerechoHabiente);
            }
            reader.Close();
            reader.Dispose();
            return DerechoHabientelist;
        }
    }
}
