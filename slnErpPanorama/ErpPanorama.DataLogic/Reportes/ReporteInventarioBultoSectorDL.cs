using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ReporteInventarioBultoSectorDL
    {
        public List<ReporteInventarioBultoSectorBE> Listado(int IdEmpresa, int IdSector)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInventarioBultoSector");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, IdSector);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInventarioBultoSectorBE> Lista = new List<ReporteInventarioBultoSectorBE>();
            ReporteInventarioBultoSectorBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteInventarioBultoSectorBE();
                Reporte.DescSector = reader["DescSector"].ToString();
                Reporte.CodigoProveedor = reader["codigoProveedor"].ToString();
                Reporte.NombreProducto = reader["nombreProducto"].ToString();
                Reporte.Abreviatura = reader["abreviatura"].ToString();
                Reporte.Bulto = Int32.Parse(reader["Bulto"].ToString());
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.DescUbicacion = reader["DescUbicacion"].ToString();
                Reporte.CantidadTiendaUcayali = Int32.Parse(reader["CantidadTiendaUcayali"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }

        public List<ReporteInventarioBultoSectorBE> ListadoRecibido(int IdEmpresa, int IdSector)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptBultoRecibido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, IdSector);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInventarioBultoSectorBE> Lista = new List<ReporteInventarioBultoSectorBE>();
            ReporteInventarioBultoSectorBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteInventarioBultoSectorBE();
                Reporte.DescSector = reader["DescSector"].ToString();
                Reporte.DescBloque = reader["DescBloque"].ToString();
                Reporte.NumeroBulto = reader["NumeroBulto"].ToString();
                Reporte.CodigoProveedor = reader["codigoProveedor"].ToString();
                Reporte.NombreProducto = reader["nombreProducto"].ToString();
                Reporte.Abreviatura = reader["abreviatura"].ToString();
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.FechaIngreso = DateTime.Parse(reader["FechaIngreso"].ToString());

                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }

        public List<ReporteInventarioBultoSectorBE> ListadoBultoAnaqueles(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptInventarioBultoAnaqueles");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteInventarioBultoSectorBE> Lista = new List<ReporteInventarioBultoSectorBE>();
            ReporteInventarioBultoSectorBE Reporte;
            while (reader.Read())
            {
                Reporte = new ReporteInventarioBultoSectorBE();
                Reporte.DescSector = reader["DescSector"].ToString();
                Reporte.CodigoProveedor = reader["codigoProveedor"].ToString();
                Reporte.NombreProducto = reader["nombreProducto"].ToString();
                Reporte.Abreviatura = reader["abreviatura"].ToString();
                Reporte.Bulto = Int32.Parse(reader["Bulto"].ToString());
                Reporte.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Reporte.DescUbicacion = reader["DescUbicacion"].ToString();
                Reporte.CantidadTiendaUcayali = Int32.Parse(reader["CantidadTiendaUcayali"].ToString());
                Lista.Add(Reporte);
            }
            reader.Close();
            reader.Dispose();
            return Lista;
        }


    }
}
