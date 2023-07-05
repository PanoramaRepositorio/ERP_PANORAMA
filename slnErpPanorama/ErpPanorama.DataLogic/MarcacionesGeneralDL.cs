using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MarcacionesGeneralDL
    {
        public MarcacionesGeneralDL() { }


        public List<MarcacionesGeneralBE> ListaTodos(int op, String dni, String pnom, String pfechini, String pfechfin,int area)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_spmarcaciongrupopersonal");

            db.AddInParameter(dbCommand, "op", DbType.Int32, op);
            db.AddInParameter(dbCommand, "pdni", DbType.String, dni);
            db.AddInParameter(dbCommand, "pnom", DbType.String, pnom);
            db.AddInParameter(dbCommand, "pfechini", DbType.String, pfechini);
            db.AddInParameter(dbCommand, "pfechfin", DbType.String, pfechfin);
            db.AddInParameter(dbCommand, "parea", DbType.Int32 , area);

            db.ExecuteNonQuery(dbCommand);
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MarcacionesGeneralBE> Marcacioneslist = new List<MarcacionesGeneralBE>();
            MarcacionesGeneralBE Marcaciones;
            String fecha;
            while (reader.Read())
            {
                Marcaciones = new MarcacionesGeneralBE();
                Marcaciones.dni = (reader["dni"].ToString());
                Marcaciones.ApeNom = (reader["ApeNom"].ToString());
                 fecha= (reader["Fecha"].ToString());
                 Marcaciones.Fecha = fecha.Substring(0, 10);
                Marcaciones.Ingreso = (reader["Ingreso"].ToString());
                Marcaciones.SalidaAlmuerzo = (reader["SalidaAlmuerzo"].ToString());
                Marcaciones.IngresoAlmuerzo = (reader["IngresoAlmuerzo"].ToString());
                Marcaciones.Salida = (reader["Salida"].ToString());
                Marcaciones.PrimerPeriodo = (reader["PrimerPeriodo"].ToString());
                Marcaciones.SegundoPeriodo = (reader["SegundoPeriodo"].ToString());
                Marcaciones.TotalPeriodoTrabajado = (reader["TotalPeriodoTrabajado"].ToString());
                Marcaciones.descarea = reader["DescArea"].ToString();
                Marcaciones.DescTienda = reader["DescTienda"].ToString();
                Marcacioneslist.Add(Marcaciones);
            }
            reader.Close();
            reader.Dispose();
            return Marcacioneslist;
        }


        public List<MarcacionesGeneralBE> Listacombo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_splistararea");

             db.ExecuteNonQuery(dbCommand);
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MarcacionesGeneralBE> Marcacioneslist = new List<MarcacionesGeneralBE>();
            MarcacionesGeneralBE Marcaciones;
        
            while (reader.Read())
            {
                Marcaciones = new MarcacionesGeneralBE();
                Marcaciones.idarea = Int32.Parse(reader["idarea"].ToString());
                Marcaciones.descarea = (reader["descarea"].ToString());
          
                Marcacioneslist.Add(Marcaciones);
            }
            reader.Close();
            reader.Dispose();
            return Marcacioneslist;
        }


    }
}
