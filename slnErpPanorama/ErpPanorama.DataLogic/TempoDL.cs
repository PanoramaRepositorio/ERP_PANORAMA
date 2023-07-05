using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TempoDL
    {
        public TempoDL() { }

        public void Inserta(TempoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_sptemporal");

            db.AddInParameter(dbCommand, "Dni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "ApeNom", DbType.String, pItem.ApeNom);
            db.AddInParameter(dbCommand, "Fecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "FechaDesde", DbType.String, pItem.FechaDesde);
            db.AddInParameter(dbCommand, "FechaHasta", DbType.String, pItem.FechaHasta);
            db.AddInParameter(dbCommand, "TiempoTrabajado", DbType.String, pItem.TiempoTrabajado);

            db.ExecuteNonQuery(dbCommand);
        }


        public void Elimina()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_spelimina_Temporal");

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TempoBE> Listado()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("up_splistarTemporal");


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TempoBE> Tempolist = new List<TempoBE>();
            TempoBE Tempo;
            while (reader.Read())
            {
                Tempo = new TempoBE();
                Tempo.Dni = reader["Dni"].ToString();
                Tempo.ApeNom = reader["ApeNom"].ToString();
                Tempo.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Tempo.FechaDesde = (reader["FechaDesde"].ToString());
                Tempo.FechaHasta = (reader["FechaHasta"].ToString());
                Tempo.TiempoTrabajado = (reader["TiempoTrabajado"].ToString());
                Tempolist.Add(Tempo);
            }
            reader.Close();
            reader.Dispose();
            return Tempolist;
        }


    }
}
