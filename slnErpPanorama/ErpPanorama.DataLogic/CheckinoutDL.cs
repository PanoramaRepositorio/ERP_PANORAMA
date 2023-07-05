using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class CheckinoutDL
    {
        public CheckinoutDL() { }

        public void Inserta(CheckinoutBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_Inserta");

            db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.String, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pflagManual", DbType.Boolean, pItem.flagManual);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(CheckinoutBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_Actualiza");

            db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.String, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pflagManual", DbType.Boolean, pItem.flagManual);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(CheckinoutBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_Elimina");

            db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            //db.AddInParameter(dbCommand, "pflagManual", DbType.Boolean, pItem.flagManual);
            db.ExecuteNonQuery(dbCommand);
        }

        public void SincronizarReloj2(int Dias, bool bElimina)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ImportarSQL");
            db.AddInParameter(dbCommand, "pDesdeDias", DbType.Int32, Dias);
            db.AddInParameter(dbCommand, "pEliminaMarcacion", DbType.Boolean, bElimina);

            dbCommand.CommandTimeout = 500;
            db.ExecuteNonQuery(dbCommand);
        }

        public List<CheckinoutBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CheckinoutBE> Checkinoutlist = new List<CheckinoutBE>();
            CheckinoutBE Checkinout;
            while (reader.Read())
            {
                Checkinout = new CheckinoutBE();
                Checkinout.IdCheckinout = Int32.Parse(reader["idCheckinout"].ToString());
                Checkinout.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Checkinout.RazonSocial = reader["RazonSocial"].ToString();
                Checkinout.Dni = reader["Dni"].ToString();
                Checkinout.ApeNom = reader["ApeNom"].ToString();
                Checkinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Checkinout.Tipo = reader["Tipo"].ToString();
                Checkinout.flagManual = Boolean.Parse(reader["flagManual"].ToString());
                Checkinout.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Checkinoutlist.Add(Checkinout);
            }
            reader.Close();
            reader.Dispose();
            return Checkinoutlist;
        }

        public List<CheckinoutBE> ListaTodosActivoFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ListaTodosActivoFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CheckinoutBE> Checkinoutlist = new List<CheckinoutBE>();
            CheckinoutBE Checkinout;
            while (reader.Read())
            {
                Checkinout = new CheckinoutBE();
                Checkinout.IdCheckinout = Int32.Parse(reader["idCheckinout"].ToString());
                Checkinout.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Checkinout.RazonSocial = reader["RazonSocial"].ToString();
                Checkinout.Dni = reader["Dni"].ToString();
                Checkinout.ApeNom = reader["ApeNom"].ToString();
                Checkinout.FechaHora = DateTime.Parse(reader["Fecha"].ToString());
                Checkinout.Tipo = reader["Tipo"].ToString();
                Checkinout.flagManual = Boolean.Parse(reader["flagManual"].ToString());
                Checkinout.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Checkinout.DescTienda = reader["DescTienda"].ToString();
                Checkinout.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Checkinoutlist.Add(Checkinout);
            }
            reader.Close();
            reader.Dispose();
            return Checkinoutlist;
        }

        public List<CheckinoutBE> ListaMarcacion(string Dni, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ListaMarcacion2");
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CheckinoutBE> Checkinoutlist = new List<CheckinoutBE>();
            CheckinoutBE Checkinout;
            while (reader.Read())
            {
                Checkinout = new CheckinoutBE();
                Checkinout.Dni = reader["Dni"].ToString();
                Checkinout.ApeNom = reader["ApeNom"].ToString();
                Checkinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Checkinout.Ingreso = reader["Ingreso"].ToString();
                Checkinout.SalidaRefrigerio = reader["SalidaRefrigerio"].ToString();
                Checkinout.IngresoRefrigerio = reader["IngresoRefrigerio"].ToString();
                Checkinout.Salida = reader["Salida"].ToString();
                Checkinout.Horas = Int32.Parse(reader["Horas"].ToString());
                Checkinout.Minutos = Int32.Parse(reader["Minutos"].ToString());
                Checkinout.Refrigerio = Int32.Parse(reader["Refrigerio"].ToString());
                Checkinout.Tardanza = Int32.Parse(reader["Tardanza"].ToString());
                Checkinout.HoraExtra = Int32.Parse(reader["HoraExtra"].ToString());
                Checkinout.DescTienda = reader["DescTienda"].ToString();
                Checkinout.DescCargo = reader["DescCargo"].ToString();
                Checkinout.DescArea = reader["DescArea"].ToString();
                Checkinout.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                Checkinout.HorarioIngreso = reader["HorarioIngreso"].ToString();
                Checkinout.HorarioSalida = reader["HorarioSalida"].ToString();
                Checkinout.Updates = Int32.Parse(reader["Updates"].ToString());
                Checkinout.UsuarioModifica = reader["UsuarioModifica"].ToString();
                Checkinoutlist.Add(Checkinout);
            }
            reader.Close();
            reader.Dispose();
            return Checkinoutlist;
        }

        public List<CheckinoutBE> ListaTardanza(string Dni, int IdPersona, DateTime FechaDesde, DateTime FechaHasta, int TipoReporte)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ListaTardanza2");
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CheckinoutBE> Checkinoutlist = new List<CheckinoutBE>();
            CheckinoutBE Checkinout;
            while (reader.Read())
            {
                Checkinout = new CheckinoutBE();
                Checkinout.DescTienda = reader["DescTienda"].ToString();
                Checkinout.Dni = reader["Dni"].ToString();
                Checkinout.ApeNom = reader["ApeNom"].ToString();
                Checkinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Checkinout.Ingreso = reader["Ingreso"].ToString();
                Checkinout.Salida = reader["Salida"].ToString();
                Checkinout.Tardanza = Int32.Parse(reader["Tardanza"].ToString());
                Checkinout.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                Checkinout.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                Checkinout.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
                Checkinout.HorarioIngreso = reader["HorarioIngreso"].ToString();
                Checkinout.HorarioSalida = reader["HorarioSalida"].ToString();
                Checkinoutlist.Add(Checkinout);
            }
            reader.Close();
            reader.Dispose();
            return Checkinoutlist;
        }

        public CheckinoutBE Selecciona(int IdCheckinout)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_Selecciona");
            db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, IdCheckinout);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CheckinoutBE Checkinout = null;
            while (reader.Read())
            {
                Checkinout = new CheckinoutBE();
                Checkinout.IdCheckinout = Int32.Parse(reader["IdCheckinout"].ToString());
                Checkinout.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Checkinout.RazonSocial = reader["RazonSocial"].ToString();
                Checkinout.Dni = reader["Dni"].ToString();
                Checkinout.ApeNom = reader["ApeNom"].ToString();
                Checkinout.FechaHora = DateTime.Parse(reader["Fecha"].ToString());
                Checkinout.Tipo = reader["Tipo"].ToString();
                Checkinout.flagManual = Boolean.Parse(reader["flagManual"].ToString());
                Checkinout.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Checkinout;
        }

        public CheckinoutBE SeleccionaFecha(string Dni, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_SeleccionaFecha");
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CheckinoutBE Checkinout = null;
            while (reader.Read())
            {
                Checkinout = new CheckinoutBE();
                Checkinout.IdCheckinout = Int32.Parse(reader["IdCheckinout"].ToString());
                Checkinout.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Checkinout.RazonSocial = reader["RazonSocial"].ToString();
                Checkinout.Dni = reader["Dni"].ToString();
                Checkinout.ApeNom = reader["ApeNom"].ToString();
                Checkinout.FechaHora = DateTime.Parse(reader["Fecha"].ToString());
                Checkinout.Tipo = reader["Tipo"].ToString();
                Checkinout.flagManual = Boolean.Parse(reader["flagManual"].ToString());
                Checkinout.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Checkinout;
        }

        public CheckinoutBE SeleccionaFechaRecuperacion(string Dni, DateTime Fecha)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_SeleccionaFechaRecupera");
            db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CheckinoutBE Checkinout = null;
            while (reader.Read())
            {
                Checkinout = new CheckinoutBE();
                Checkinout.IdCheckinout = Int32.Parse(reader["IdCheckinout"].ToString());
                Checkinout.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Checkinout.RazonSocial = reader["RazonSocial"].ToString();
                Checkinout.Dni = reader["Dni"].ToString();
                Checkinout.ApeNom = reader["ApeNom"].ToString();
                Checkinout.FechaHora = DateTime.Parse(reader["Fecha"].ToString());
                Checkinout.Tipo = reader["Tipo"].ToString();
                Checkinout.Descanso = reader["Descanso"].ToString();
                Checkinout.flagManual = Boolean.Parse(reader["flagManual"].ToString());
                Checkinout.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Checkinout;
        }

        public void InsertaSimple(CheckinoutBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_InsertaSimple");

            db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
            db.AddInParameter(dbCommand, "pflagManual", DbType.Boolean, pItem.flagManual);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }



    }
    //public class CheckinoutDL
    //{
    //    public CheckinoutDL() { }

    //    public void Inserta(CheckinoutBE pItem)
    //    {
    //        //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        //DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_Inserta");

    //        //db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
    //        //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
    //        //db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
    //        //db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
    //        //db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
    //        //db.AddInParameter(dbCommand, "pIdTienda", DbType.String, pItem.IdTienda);
    //        //db.AddInParameter(dbCommand, "pflagManual", DbType.Boolean, pItem.flagManual);
    //        //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
    //        //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //        //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
    //        //db.ExecuteNonQuery(dbCommand);
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_Inserta");

    //        db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
    //        db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
    //        db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
    //        db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
    //        db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
    //        db.AddInParameter(dbCommand, "pIdTienda", DbType.String, pItem.IdTienda);
    //        db.AddInParameter(dbCommand, "pflagManual", DbType.Boolean, pItem.flagManual);
    //        db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
    //        db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //        db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
    //        db.ExecuteNonQuery(dbCommand);
    //    }

    //    public void Actualiza(CheckinoutBE pItem)
    //    {
    //        //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        //DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_Actualiza");

    //        //db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
    //        //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
    //        //db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
    //        //db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
    //        //db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
    //        //db.AddInParameter(dbCommand, "pIdTienda", DbType.String, pItem.IdTienda);
    //        //db.AddInParameter(dbCommand, "pflagManual", DbType.Boolean, pItem.flagManual);
    //        //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
    //        //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //        //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

    //        //db.ExecuteNonQuery(dbCommand);
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_Actualiza");

    //        db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
    //        db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
    //        db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
    //        db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
    //        db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
    //        db.AddInParameter(dbCommand, "pIdTienda", DbType.String, pItem.IdTienda);
    //        db.AddInParameter(dbCommand, "pflagManual", DbType.Boolean, pItem.flagManual);
    //        db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
    //        db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //        db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

    //        db.ExecuteNonQuery(dbCommand);
    //    }

    //    public void Elimina(CheckinoutBE pItem)
    //    {
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_Elimina");

    //        db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
    //        db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
    //        db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //        db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
    //        //db.AddInParameter(dbCommand, "pflagManual", DbType.Boolean, pItem.flagManual);
    //        db.ExecuteNonQuery(dbCommand);
    //    }

    //    public void SincronizarReloj2(int Dias, bool bElimina)
    //    {
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ImportarSQL");
    //        db.AddInParameter(dbCommand, "pDesdeDias", DbType.Int32, Dias);
    //        db.AddInParameter(dbCommand, "pEliminaMarcacion", DbType.Boolean, bElimina);

    //        dbCommand.CommandTimeout = 500;
    //        db.ExecuteNonQuery(dbCommand);
    //    }

    //    public List<CheckinoutBE> ListaTodosActivo(int IdEmpresa)
    //    {
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ListaTodosActivo");
    //        db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

    //        IDataReader reader = db.ExecuteReader(dbCommand);
    //        List<CheckinoutBE> Checkinoutlist = new List<CheckinoutBE>();
    //        CheckinoutBE Checkinout;
    //        while (reader.Read())
    //        {
    //            Checkinout = new CheckinoutBE();
    //            Checkinout.IdCheckinout = Int32.Parse(reader["idCheckinout"].ToString());
    //            Checkinout.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
    //            Checkinout.RazonSocial = reader["RazonSocial"].ToString();
    //            Checkinout.Dni = reader["Dni"].ToString();
    //            Checkinout.ApeNom = reader["ApeNom"].ToString();
    //            Checkinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
    //            Checkinout.Tipo = reader["Tipo"].ToString();
    //            Checkinout.flagManual = Boolean.Parse(reader["flagManual"].ToString());
    //            Checkinout.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
    //            Checkinoutlist.Add(Checkinout);
    //        }
    //        reader.Close();
    //        reader.Dispose();
    //        return Checkinoutlist;
    //    }

    //    public List<CheckinoutBE> ListaTodosActivoFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
    //    {
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ListaTodosActivoFecha");
    //        db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
    //        db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
    //        db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

    //        IDataReader reader = db.ExecuteReader(dbCommand);
    //        List<CheckinoutBE> Checkinoutlist = new List<CheckinoutBE>();
    //        CheckinoutBE Checkinout;
    //        while (reader.Read())
    //        {
    //            Checkinout = new CheckinoutBE();
    //            Checkinout.IdCheckinout = Int32.Parse(reader["idCheckinout"].ToString());
    //            Checkinout.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
    //            Checkinout.RazonSocial = reader["RazonSocial"].ToString();
    //            Checkinout.Dni = reader["Dni"].ToString();
    //            Checkinout.ApeNom = reader["ApeNom"].ToString();
    //            Checkinout.FechaHora = DateTime.Parse(reader["Fecha"].ToString());
    //            Checkinout.Tipo = reader["Tipo"].ToString();
    //            Checkinout.flagManual = Boolean.Parse(reader["flagManual"].ToString());
    //            Checkinout.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
    //            Checkinout.DescTienda = reader["DescTienda"].ToString();
    //            Checkinout.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
    //            Checkinoutlist.Add(Checkinout);
    //        }
    //        reader.Close();
    //        reader.Dispose();
    //        return Checkinoutlist;
    //    }

    //    public List<CheckinoutBE> ListaMarcacion(string Dni, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
    //    {
    //        //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        //DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ListaMarcacion");
    //        //db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
    //        //db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
    //        //db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
    //        //db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

    //        //IDataReader reader = db.ExecuteReader(dbCommand);
    //        //List<CheckinoutBE> Checkinoutlist = new List<CheckinoutBE>();
    //        //CheckinoutBE Checkinout;
    //        //while (reader.Read())
    //        //{
    //        //    Checkinout = new CheckinoutBE();
    //        //    Checkinout.Dni = reader["Dni"].ToString();
    //        //    Checkinout.ApeNom = reader["ApeNom"].ToString();
    //        //    Checkinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
    //        //    Checkinout.Ingreso = reader["Ingreso"].ToString();
    //        //    Checkinout.SalidaRefrigerio = reader["SalidaRefrigerio"].ToString();
    //        //    Checkinout.IngresoRefrigerio = reader["IngresoRefrigerio"].ToString();
    //        //    Checkinout.Salida = reader["Salida"].ToString();
    //        //    Checkinout.Horas = Int32.Parse(reader["Horas"].ToString());
    //        //    Checkinout.Minutos = Int32.Parse(reader["Minutos"].ToString());
    //        //    Checkinout.Refrigerio = Int32.Parse(reader["Refrigerio"].ToString());
    //        //    Checkinout.Tardanza = Int32.Parse(reader["Tardanza"].ToString());
    //        //    Checkinout.HoraExtra = Int32.Parse(reader["HoraExtra"].ToString());
    //        //    Checkinout.DescTienda = reader["DescTienda"].ToString();
    //        //    Checkinout.DescCargo = reader["DescCargo"].ToString();
    //        //    Checkinout.DescArea = reader["DescArea"].ToString();
    //        //    Checkinout.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
    //        //    Checkinout.HorarioIngreso = reader["HorarioIngreso"].ToString();
    //        //    Checkinout.HorarioSalida = reader["HorarioSalida"].ToString();
    //        //    Checkinout.Updates = Int32.Parse(reader["Updates"].ToString());
    //        //    Checkinout.UsuarioModifica = reader["UsuarioModifica"].ToString();
    //        //    Checkinoutlist.Add(Checkinout);
    //        //}
    //        //reader.Close();
    //        //reader.Dispose();
    //        //return Checkinoutlist;
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ListaMarcacion2");
    //        db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
    //        db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
    //        db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
    //        db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

    //        IDataReader reader = db.ExecuteReader(dbCommand);
    //        List<CheckinoutBE> Checkinoutlist = new List<CheckinoutBE>();
    //        CheckinoutBE Checkinout;
    //        while (reader.Read())
    //        {
    //            Checkinout = new CheckinoutBE();
    //            Checkinout.Dni = reader["Dni"].ToString();
    //            Checkinout.ApeNom = reader["ApeNom"].ToString();
    //            Checkinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
    //            Checkinout.Ingreso = reader["Ingreso"].ToString();
    //            Checkinout.SalidaRefrigerio = reader["SalidaRefrigerio"].ToString();
    //            Checkinout.IngresoRefrigerio = reader["IngresoRefrigerio"].ToString();
    //            Checkinout.Salida = reader["Salida"].ToString();
    //            Checkinout.Horas = Int32.Parse(reader["Horas"].ToString());
    //            Checkinout.Minutos = Int32.Parse(reader["Minutos"].ToString());
    //            Checkinout.Refrigerio = Int32.Parse(reader["Refrigerio"].ToString());
    //            Checkinout.Tardanza = Int32.Parse(reader["Tardanza"].ToString());
    //            Checkinout.HoraExtra = Int32.Parse(reader["HoraExtra"].ToString());
    //            Checkinout.DescTienda = reader["DescTienda"].ToString();
    //            Checkinout.DescCargo = reader["DescCargo"].ToString();
    //            Checkinout.DescArea = reader["DescArea"].ToString();
    //            Checkinout.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
    //            Checkinout.HorarioIngreso = reader["HorarioIngreso"].ToString();
    //            Checkinout.HorarioSalida = reader["HorarioSalida"].ToString();
    //            Checkinout.Updates = Int32.Parse(reader["Updates"].ToString());
    //            Checkinout.UsuarioModifica = reader["UsuarioModifica"].ToString();
    //            Checkinoutlist.Add(Checkinout);
    //        }
    //        reader.Close();
    //        reader.Dispose();
    //        return Checkinoutlist;
    //    }

    //    public List<CheckinoutBE> ListaTardanza(string Dni, int IdPersona, DateTime FechaDesde, DateTime FechaHasta,int TipoReporte)
    //    {
    //        //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        //DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ListaTardanza2");
    //        //db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
    //        //db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
    //        //db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
    //        //db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
    //        //db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

    //        //IDataReader reader = db.ExecuteReader(dbCommand);
    //        //List<CheckinoutBE> Checkinoutlist = new List<CheckinoutBE>();
    //        //CheckinoutBE Checkinout;
    //        //while (reader.Read())
    //        //{
    //        //    Checkinout = new CheckinoutBE();
    //        //    Checkinout.DescTienda = reader["DescTienda"].ToString();
    //        //    Checkinout.Dni = reader["Dni"].ToString();
    //        //    Checkinout.ApeNom = reader["ApeNom"].ToString();
    //        //    Checkinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
    //        //    Checkinout.Ingreso = reader["Ingreso"].ToString();
    //        //    Checkinout.Salida = reader["Salida"].ToString();
    //        //    Checkinout.Tardanza = Int32.Parse(reader["Tardanza"].ToString());
    //        //    Checkinout.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
    //        //    Checkinout.Descuento = Decimal.Parse(reader["Descuento"].ToString());
    //        //    Checkinout.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
    //        //    Checkinout.HorarioIngreso = reader["HorarioIngreso"].ToString();
    //        //    Checkinout.HorarioSalida = reader["HorarioSalida"].ToString();
    //        //    Checkinoutlist.Add(Checkinout);
    //        //}
    //        //reader.Close();
    //        //reader.Dispose();
    //        //return Checkinoutlist;
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_ListaTardanza2");
    //        db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
    //        db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
    //        db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
    //        db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);
    //        db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

    //        IDataReader reader = db.ExecuteReader(dbCommand);
    //        List<CheckinoutBE> Checkinoutlist = new List<CheckinoutBE>();
    //        CheckinoutBE Checkinout;
    //        while (reader.Read())
    //        {
    //            Checkinout = new CheckinoutBE();
    //            Checkinout.DescTienda = reader["DescTienda"].ToString();
    //            Checkinout.Dni = reader["Dni"].ToString();
    //            Checkinout.ApeNom = reader["ApeNom"].ToString();
    //            Checkinout.Fecha = DateTime.Parse(reader["Fecha"].ToString());
    //            Checkinout.Ingreso = reader["Ingreso"].ToString();
    //            Checkinout.Salida = reader["Salida"].ToString();
    //            Checkinout.Tardanza = Int32.Parse(reader["Tardanza"].ToString());
    //            Checkinout.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
    //            Checkinout.Descuento = Decimal.Parse(reader["Descuento"].ToString());
    //            Checkinout.FlagApoyo = Boolean.Parse(reader["FlagApoyo"].ToString());
    //            Checkinout.HorarioIngreso = reader["HorarioIngreso"].ToString();
    //            Checkinout.HorarioSalida = reader["HorarioSalida"].ToString();
    //            Checkinoutlist.Add(Checkinout);
    //        }
    //        reader.Close();
    //        reader.Dispose();
    //        return Checkinoutlist;
    //    }

    //    public CheckinoutBE Selecciona(int IdCheckinout)
    //    {
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_Selecciona");
    //        db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, IdCheckinout);

    //        IDataReader reader = db.ExecuteReader(dbCommand);
    //        CheckinoutBE Checkinout = null;
    //        while (reader.Read())
    //        {
    //            Checkinout = new CheckinoutBE();
    //            Checkinout.IdCheckinout = Int32.Parse(reader["IdCheckinout"].ToString());
    //            Checkinout.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
    //            Checkinout.RazonSocial = reader["RazonSocial"].ToString();
    //            Checkinout.Dni = reader["Dni"].ToString();
    //            Checkinout.ApeNom = reader["ApeNom"].ToString();
    //            Checkinout.FechaHora = DateTime.Parse(reader["Fecha"].ToString());
    //            Checkinout.Tipo = reader["Tipo"].ToString();
    //            Checkinout.flagManual = Boolean.Parse(reader["flagManual"].ToString());
    //            Checkinout.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
    //        }
    //        reader.Close();
    //        reader.Dispose();
    //        return Checkinout;
    //    }

    //    public CheckinoutBE SeleccionaFecha(string Dni, DateTime Fecha)
    //    {
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_SeleccionaFecha");
    //        db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
    //        db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

    //        IDataReader reader = db.ExecuteReader(dbCommand);
    //        CheckinoutBE Checkinout = null;
    //        while (reader.Read())
    //        {
    //            Checkinout = new CheckinoutBE();
    //            Checkinout.IdCheckinout = Int32.Parse(reader["IdCheckinout"].ToString());
    //            Checkinout.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
    //            Checkinout.RazonSocial = reader["RazonSocial"].ToString();
    //            Checkinout.Dni = reader["Dni"].ToString();
    //            Checkinout.ApeNom = reader["ApeNom"].ToString();
    //            Checkinout.FechaHora = DateTime.Parse(reader["Fecha"].ToString());
    //            Checkinout.Tipo = reader["Tipo"].ToString();
    //            Checkinout.flagManual = Boolean.Parse(reader["flagManual"].ToString());
    //            Checkinout.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
    //        }
    //        reader.Close();
    //        reader.Dispose();
    //        return Checkinout;
    //    }

    //    public CheckinoutBE SeleccionaFechaRecuperacion(string Dni, DateTime Fecha)
    //    {
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_SeleccionaFechaRecupera");
    //        db.AddInParameter(dbCommand, "pDni", DbType.String, Dni);
    //        db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, Fecha);

    //        IDataReader reader = db.ExecuteReader(dbCommand);
    //        CheckinoutBE Checkinout = null;
    //        while (reader.Read())
    //        {
    //            Checkinout = new CheckinoutBE();
    //            Checkinout.IdCheckinout = Int32.Parse(reader["IdCheckinout"].ToString());
    //            Checkinout.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
    //            Checkinout.RazonSocial = reader["RazonSocial"].ToString();
    //            Checkinout.Dni = reader["Dni"].ToString();
    //            Checkinout.ApeNom = reader["ApeNom"].ToString();
    //            Checkinout.FechaHora = DateTime.Parse(reader["Fecha"].ToString());
    //            Checkinout.Tipo = reader["Tipo"].ToString();
    //            Checkinout.Descanso = reader["Descanso"].ToString();
    //            Checkinout.flagManual = Boolean.Parse(reader["flagManual"].ToString());
    //            Checkinout.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
    //        }
    //        reader.Close();
    //        reader.Dispose();
    //        return Checkinout;
    //    }

    //    public void InsertaSimple(CheckinoutBE pItem)
    //    {
    //        Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
    //        DbCommand dbCommand = db.GetStoredProcCommand("usp_Checkinout_InsertaSimple");

    //        db.AddInParameter(dbCommand, "pIdCheckinout", DbType.Int32, pItem.IdCheckinout);
    //        db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
    //        db.AddInParameter(dbCommand, "pDni", DbType.String, pItem.Dni);
    //        db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
    //        db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
    //        db.AddInParameter(dbCommand, "pflagManual", DbType.Boolean, pItem.flagManual);
    //        db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
    //        db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
    //        db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
    //        db.ExecuteNonQuery(dbCommand);
    //    }



    //}
}
