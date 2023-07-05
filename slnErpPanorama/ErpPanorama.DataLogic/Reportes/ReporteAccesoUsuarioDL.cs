using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteAccesoUsuarioDL
    {
        public List<ReporteAccesoUsuarioBE> Listado()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptAccesoUsuario");
           

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteAccesoUsuarioBE> lista = new List<ReporteAccesoUsuarioBE>();
            ReporteAccesoUsuarioBE reporte = null;
            while (reader.Read())
            {
                reporte = new ReporteAccesoUsuarioBE();
                reporte.IdUser = Int32.Parse(reader["iduser"].ToString());
                reporte.Usuario = reader["usuario"].ToString();
                reporte.Descripcion = reader["Descripcion"].ToString();
                reporte.IdPerfil = Int32.Parse(reader["idperfil"].ToString());
                reporte.DescPerfil = reader["DescPerfil"].ToString();
                reporte.IdMenu = Int32.Parse(reader["idmenu"].ToString());
                reporte.MenuDescripcion = reader["MenuDescripcion"].ToString();
                reporte.FlagLectura = Boolean.Parse(reader["flaglectura"].ToString());
                reporte.FlagAdicion = Boolean.Parse(reader["flagadicion"].ToString());
                reporte.FlagActualizacion = Boolean.Parse(reader["flagactualizacion"].ToString());
                reporte.FlagEliminacion = Boolean.Parse(reader["flageliminacion"].ToString());
                reporte.FlagImpresion = Boolean.Parse(reader["flagimpresion"].ToString());
                lista.Add(reporte);
            }
            reader.Close();
            reader.Dispose();
            return lista;
        }
    }
}
