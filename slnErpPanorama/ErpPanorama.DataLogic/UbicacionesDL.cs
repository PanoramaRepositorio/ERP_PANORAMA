using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class UbicacionesDL
    {
        public List<UbicacionesBE> ListaUbicaciones()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_RptUbicaciones");
            dbCommand.CommandTimeout = 250;

            IDataReader reader = db.ExecuteReader(dbCommand);

            List<UbicacionesBE> Ubicacioneslist = new List<UbicacionesBE>();
            UbicacionesBE Ubicaciones;
            while (reader.Read())
            {
                Ubicaciones = new UbicacionesBE();

                Ubicaciones.NumeroBulto = reader["NumeroBulto"].ToString();
                Ubicaciones.Almacen = reader["Almacen"].ToString();
                Ubicaciones.Sector = reader["Sector"].ToString();
                Ubicaciones.Bloque = reader["Bloque"].ToString();
                Ubicaciones.Linea = reader["Linea"].ToString();
                Ubicaciones.Sublinea = reader["Sublinea"].ToString();
                Ubicaciones.Hangtag = reader["Hangtag"].ToString();
                Ubicaciones.Codigo = reader["Codigo"].ToString();
                Ubicaciones.Descripcion = reader["Descripcion"].ToString();
                Ubicaciones.Abreviatura = reader["Abreviatura"].ToString();
                Ubicaciones.Stock = Int32.Parse(reader["Stock"].ToString());
                Ubicaciones.Situacion = reader["Situacion"].ToString();
                Ubicaciones.Observacion = reader["Observacion"].ToString();
                Ubicaciones.FecInventario = DateTime.Parse(reader["FecInventario"].ToString());
                Ubicaciones.FechaRecepcion = DateTime.Parse(reader["FechaRecepcion"].ToString());
                Ubicaciones.Ubicacion = reader["Ubicacion"].ToString();

                Ubicacioneslist.Add(Ubicaciones);
            }
            reader.Close();
            reader.Dispose();
            return Ubicacioneslist;
        }

    }
}
