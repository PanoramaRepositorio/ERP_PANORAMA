using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TalonDL
    {
        public TalonDL() { }

        public void Inserta(TalonBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talon_Inserta");

            db.AddInParameter(dbCommand, "pIdTalon", DbType.Int32, pItem.IdTalon);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdTipoFormato", DbType.Int32, pItem.IdTipoFormato);
            db.AddInParameter(dbCommand, "pIdTamanoHoja", DbType.Int32, pItem.IdTamanoHoja);
            db.AddInParameter(dbCommand, "pNumeroSerie", DbType.String, pItem.NumeroSerie);
            db.AddInParameter(dbCommand, "pNumeroAutoriza", DbType.String, pItem.NumeroAutoriza);
            db.AddInParameter(dbCommand, "pSerieImpresora", DbType.String, pItem.SerieImpresora);
            db.AddInParameter(dbCommand, "pNombreComercial", DbType.String, pItem.NombreComercial);
            db.AddInParameter(dbCommand, "pDireccionFiscal", DbType.String, pItem.DireccionFiscal);
            db.AddInParameter(dbCommand, "pPaginaWeb", DbType.String, pItem.PaginaWeb);
            db.AddInParameter(dbCommand, "pImpresora", DbType.String, pItem.Impresora);
            db.AddInParameter(dbCommand, "pFlagAbrirCajon", DbType.Boolean, pItem.FlagAbrirCajon);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TalonBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talon_Actualiza");

            db.AddInParameter(dbCommand, "pIdTalon", DbType.Int32, pItem.IdTalon);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, pItem.IdCaja);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdTipoFormato", DbType.Int32, pItem.IdTipoFormato);
            db.AddInParameter(dbCommand, "pIdTamanoHoja", DbType.Int32, pItem.IdTamanoHoja);
            db.AddInParameter(dbCommand, "pNumeroSerie", DbType.String, pItem.NumeroSerie);
            db.AddInParameter(dbCommand, "pNumeroAutoriza", DbType.String, pItem.NumeroAutoriza);
            db.AddInParameter(dbCommand, "pSerieImpresora", DbType.String, pItem.SerieImpresora);
            db.AddInParameter(dbCommand, "pNombreComercial", DbType.String, pItem.NombreComercial);
            db.AddInParameter(dbCommand, "pDireccionFiscal", DbType.String, pItem.DireccionFiscal);
            db.AddInParameter(dbCommand, "pPaginaWeb", DbType.String, pItem.PaginaWeb);
            db.AddInParameter(dbCommand, "pImpresora", DbType.String, pItem.Impresora);
            db.AddInParameter(dbCommand, "pFlagAbrirCajon", DbType.Boolean, pItem.FlagAbrirCajon);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TalonBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talon_Elimina");

            db.AddInParameter(dbCommand, "pIdTalon", DbType.Int32, pItem.IdTalon);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TalonBE> ListaTodosActivo(int IdEmpresa, int IdTienda)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talon_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TalonBE> Talonlist = new List<TalonBE>();
            TalonBE Talon;
            while (reader.Read())
            {
                Talon = new TalonBE();
                Talon.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Talon.RazonSocial = reader["RazonSocial"].ToString();
                Talon.IdTalon = Int32.Parse(reader["idTalon"].ToString());
                Talon.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                Talon.DescCaja = reader["descCaja"].ToString();
                Talon.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Talon.DescTienda = reader["DescTienda"].ToString();
                Talon.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Talon.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Talon.IdTipoFormato = Int32.Parse(reader["IdTipoFormato"].ToString());
                Talon.DescTipoFormato = reader["DescTipoFormato"].ToString();
                Talon.IdTamanoHoja = Int32.Parse(reader["IdTamanoHoja"].ToString());
                Talon.DescTamanoHoja = reader["DescTamanoHoja"].ToString();
                Talon.NumeroSerie = reader["numeroSerie"].ToString();
                Talon.NumeroAutoriza = reader["numeroAutoriza"].ToString();
                Talon.SerieImpresora = reader["SerieImpresora"].ToString();
                Talon.DireccionFiscal = reader["DireccionFiscal"].ToString();
                Talon.NombreComercial = reader["NombreComercial"].ToString();
                Talon.PaginaWeb = reader["PaginaWeb"].ToString();
                Talon.Impresora = reader["Impresora"].ToString();
                Talon.FlagAbrirCajon = Boolean.Parse(reader["FlagAbrirCajon"].ToString());
                Talon.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Talonlist.Add(Talon);
            }
            reader.Close();
            reader.Dispose();
            return Talonlist;
        }

        public List<TalonBE> ListaCaja(int IdEmpresa, int IdCaja)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talon_ListaCaja");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TalonBE> Talonlist = new List<TalonBE>();
            TalonBE Talon;
            while (reader.Read())
            {
                Talon = new TalonBE();
                Talon.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Talon.IdTalon = Int32.Parse(reader["idTalon"].ToString());
                Talon.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                Talon.DescCaja = reader["descCaja"].ToString();
                Talon.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Talon.DescTienda = reader["DescTienda"].ToString();
                Talon.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Talon.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Talon.IdTipoFormato = Int32.Parse(reader["IdTipoFormato"].ToString());
                Talon.DescTipoFormato = reader["DescTipoFormato"].ToString();
                Talon.IdTamanoHoja = Int32.Parse(reader["IdTamanoHoja"].ToString());
                Talon.DescTamanoHoja = reader["DescTamanoHoja"].ToString();
                Talon.NumeroSerie = reader["numeroSerie"].ToString();
                Talon.NumeroAutoriza = reader["numeroAutoriza"].ToString();
                Talon.SerieImpresora = reader["SerieImpresora"].ToString();
                Talon.DireccionFiscal = reader["DireccionFiscal"].ToString();
                Talon.NombreComercial = reader["NombreComercial"].ToString();
                Talon.PaginaWeb = reader["PaginaWeb"].ToString();
                Talon.Impresora = reader["Impresora"].ToString();
                Talon.FlagAbrirCajon = Boolean.Parse(reader["FlagAbrirCajon"].ToString());
                Talon.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Talonlist.Add(Talon);
            }
            reader.Close();
            reader.Dispose();
            return Talonlist;
        }

        public TalonBE Selecciona(int IdEmpresa, int IdTienda, int IdTalon)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talon_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdTalon", DbType.Int32, IdTalon);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TalonBE Talon = null;
            while (reader.Read())
            {
                Talon = new TalonBE();
                Talon.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Talon.IdTalon = Int32.Parse(reader["idTalon"].ToString());
                Talon.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                Talon.DescCaja = reader["descCaja"].ToString();
                Talon.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Talon.DescTienda = reader["DescTienda"].ToString();
                Talon.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Talon.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Talon.IdTipoFormato = Int32.Parse(reader["IdTipoFormato"].ToString());
                Talon.DescTipoFormato = reader["DescTipoFormato"].ToString();
                Talon.IdTamanoHoja = Int32.Parse(reader["IdTamanoHoja"].ToString());
                Talon.DescTamanoHoja = reader["DescTamanoHoja"].ToString();
                Talon.NumeroSerie = reader["numeroSerie"].ToString();
                Talon.NumeroAutoriza = reader["numeroAutoriza"].ToString();
                Talon.SerieImpresora = reader["SerieImpresora"].ToString();
                Talon.DireccionFiscal = reader["DireccionFiscal"].ToString();
                Talon.NombreComercial = reader["NombreComercial"].ToString();
                Talon.PaginaWeb = reader["PaginaWeb"].ToString();
                Talon.Impresora = reader["Impresora"].ToString();
                Talon.FlagAbrirCajon = Boolean.Parse(reader["FlagAbrirCajon"].ToString());
                Talon.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Talon;
        }

        public TalonBE SeleccionaCajaDocumento(int IdEmpresa, int IdTienda, int IdCaja, int IdTipoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Talon_SeleccionaCajaDocumento");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdCaja", DbType.Int32, IdCaja);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TalonBE Talon = null;
            while (reader.Read())
            {
                Talon = new TalonBE();
                Talon.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Talon.IdTalon = Int32.Parse(reader["idTalon"].ToString());
                Talon.IdCaja = Int32.Parse(reader["idCaja"].ToString());
                Talon.DescCaja = reader["descCaja"].ToString();
                Talon.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                Talon.DescTienda = reader["DescTienda"].ToString();
                Talon.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Talon.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                Talon.IdTipoFormato = Int32.Parse(reader["IdTipoFormato"].ToString());
                Talon.DescTipoFormato = reader["DescTipoFormato"].ToString();
                Talon.IdTamanoHoja = Int32.Parse(reader["IdTamanoHoja"].ToString());
                Talon.DescTamanoHoja = reader["DescTamanoHoja"].ToString();
                Talon.NumeroSerie = reader["numeroSerie"].ToString();
                Talon.NumeroAutoriza = reader["numeroAutoriza"].ToString();
                Talon.SerieImpresora = reader["SerieImpresora"].ToString();
                Talon.DireccionFiscal = reader["DireccionFiscal"].ToString();
                Talon.NombreComercial = reader["NombreComercial"].ToString();
                Talon.PaginaWeb = reader["PaginaWeb"].ToString();
                Talon.Impresora = reader["Impresora"].ToString();
                Talon.FlagAbrirCajon = Boolean.Parse(reader["FlagAbrirCajon"].ToString());
                Talon.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Talon;
        }
    }
}

