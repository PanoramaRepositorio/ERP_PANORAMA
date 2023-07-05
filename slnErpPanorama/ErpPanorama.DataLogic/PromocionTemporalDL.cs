using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PromocionTemporalDL
    {
        public PromocionTemporalDL() { }

        public Int32 Inserta(PromocionTemporalBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporal_Inserta");

            db.AddOutParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, pItem.IdPromocionTemporal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescPromocionTemporal", DbType.String, pItem.DescPromocionTemporal);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, pItem.IdTipoVenta);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pFechaInicioImpresion", DbType.DateTime, pItem.FechaInicioImpresion);
            db.AddInParameter(dbCommand, "pFechaFinImpresion", DbType.DateTime, pItem.FechaFinImpresion);
            db.AddInParameter(dbCommand, "pFlagContado", DbType.Boolean, pItem.FlagContado);
            db.AddInParameter(dbCommand, "pFlagCredito", DbType.Boolean, pItem.FlagCredito);
            db.AddInParameter(dbCommand, "pFlagConsignacion", DbType.Boolean, pItem.FlagConsignacion);
            db.AddInParameter(dbCommand, "pFlagSeparacion", DbType.Boolean, pItem.FlagSeparacion);
            db.AddInParameter(dbCommand, "pFlagContraentrega", DbType.Boolean, pItem.FlagContraentrega);
            db.AddInParameter(dbCommand, "pFlagCopagan", DbType.Boolean, pItem.FlagCopagan);
            db.AddInParameter(dbCommand, "pFlagObsequio", DbType.Boolean, pItem.FlagObsequio);
            db.AddInParameter(dbCommand, "pFlagAsaf", DbType.Boolean, pItem.FlagAsaf);
            db.AddInParameter(dbCommand, "pFlagClienteMayorista", DbType.Boolean, pItem.FlagClienteMayorista);
            db.AddInParameter(dbCommand, "pFlagClienteFinal", DbType.Boolean, pItem.FlagClienteFinal);
            db.AddInParameter(dbCommand, "pFlagUcayali", DbType.Boolean, pItem.FlagUcayali);
            db.AddInParameter(dbCommand, "pFlagAndahuaylas", DbType.Boolean, pItem.FlagAndahuaylas);
            db.AddInParameter(dbCommand, "pFlagPrescott", DbType.Boolean, pItem.FlagPrescott);
            db.AddInParameter(dbCommand, "pFlagAviacion", DbType.Boolean, pItem.FlagAviacion);
            db.AddInParameter(dbCommand, "pFlagMegaplaza", DbType.Boolean, pItem.FlagMegaplaza);
            db.AddInParameter(dbCommand, "pFlagWeb", DbType.Boolean, pItem.FlagWeb);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pFlagAviacion2", DbType.Boolean, pItem.FlagAviacion2);
            db.AddInParameter(dbCommand, "pFlagSanMiguel", DbType.Boolean, pItem.FlagSanMiguel);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdPromocionTemporal");

            return Id;
        }

        public void Actualiza(PromocionTemporalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporal_Actualiza");

            db.AddInParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, pItem.IdPromocionTemporal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescPromocionTemporal", DbType.String, pItem.DescPromocionTemporal);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, pItem.IdTipoVenta);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pFechaInicioImpresion", DbType.DateTime, pItem.FechaInicioImpresion);
            db.AddInParameter(dbCommand, "pFechaFinImpresion", DbType.DateTime, pItem.FechaFinImpresion);
            db.AddInParameter(dbCommand, "pFlagContado", DbType.Boolean, pItem.FlagContado);
            db.AddInParameter(dbCommand, "pFlagCredito", DbType.Boolean, pItem.FlagCredito);
            db.AddInParameter(dbCommand, "pFlagConsignacion", DbType.Boolean, pItem.FlagConsignacion);
            db.AddInParameter(dbCommand, "pFlagSeparacion", DbType.Boolean, pItem.FlagSeparacion);
            db.AddInParameter(dbCommand, "pFlagContraentrega", DbType.Boolean, pItem.FlagContraentrega);
            db.AddInParameter(dbCommand, "pFlagCopagan", DbType.Boolean, pItem.FlagCopagan);
            db.AddInParameter(dbCommand, "pFlagObsequio", DbType.Boolean, pItem.FlagObsequio);
            db.AddInParameter(dbCommand, "pFlagAsaf", DbType.Boolean, pItem.FlagAsaf);
            db.AddInParameter(dbCommand, "pFlagClienteMayorista", DbType.Boolean, pItem.FlagClienteMayorista);
            db.AddInParameter(dbCommand, "pFlagClienteFinal", DbType.Boolean, pItem.FlagClienteFinal);
            db.AddInParameter(dbCommand, "pFlagUcayali", DbType.Boolean, pItem.FlagUcayali);
            db.AddInParameter(dbCommand, "pFlagAndahuaylas", DbType.Boolean, pItem.FlagAndahuaylas);
            db.AddInParameter(dbCommand, "pFlagPrescott", DbType.Boolean, pItem.FlagPrescott);
            db.AddInParameter(dbCommand, "pFlagAviacion", DbType.Boolean, pItem.FlagAviacion);
            db.AddInParameter(dbCommand, "pFlagMegaplaza", DbType.Boolean, pItem.FlagMegaplaza);
            db.AddInParameter(dbCommand, "pFlagWeb", DbType.Boolean, pItem.FlagWeb);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pFlagAviacion2", DbType.Boolean, pItem.FlagAviacion2);
            db.AddInParameter(dbCommand, "pFlagSanMiguel", DbType.Boolean, pItem.FlagSanMiguel);            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PromocionTemporalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporal_Elimina");

            db.AddInParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, pItem.IdPromocionTemporal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaVistaWeb()
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporal_ActualizaVistaWeb");

            db.ExecuteNonQuery(dbCommand);
        }


        public List<PromocionTemporalBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporal_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionTemporalBE> PromocionTemporallist = new List<PromocionTemporalBE>();
            PromocionTemporalBE PromocionTemporal;
            while (reader.Read())
            {
                PromocionTemporal = new PromocionTemporalBE();
                PromocionTemporal.IdPromocionTemporal = Int32.Parse(reader["IdPromocionTemporal"].ToString());
                PromocionTemporal.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionTemporal.RazonSocial = reader["RazonSocial"].ToString();
                PromocionTemporal.DescPromocionTemporal = reader["DescPromocionTemporal"].ToString();
                PromocionTemporal.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionTemporal.DescTipoCliente = reader["DescTipoCliente"].ToString();
                PromocionTemporal.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionTemporal.DescFormaPago = reader["DescFormaPago"].ToString();
                PromocionTemporal.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PromocionTemporal.DescTienda = reader["DescTienda"].ToString();
                PromocionTemporal.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
                PromocionTemporal.DescTipoVenta = reader["DescTipoVenta"].ToString();
                PromocionTemporal.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PromocionTemporal.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PromocionTemporal.FlagContado = Boolean.Parse(reader["FlagContado"].ToString());
                PromocionTemporal.FlagCredito = Boolean.Parse(reader["FlagCredito"].ToString());
                PromocionTemporal.FlagConsignacion = Boolean.Parse(reader["FlagConsignacion"].ToString());
                PromocionTemporal.FlagSeparacion = Boolean.Parse(reader["FlagSeparacion"].ToString());
                PromocionTemporal.FlagContraentrega = Boolean.Parse(reader["FlagContraentrega"].ToString());
                PromocionTemporal.FlagCopagan = Boolean.Parse(reader["FlagCopagan"].ToString());
                PromocionTemporal.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                PromocionTemporal.FlagAsaf = Boolean.Parse(reader["FlagAsaf"].ToString());
                PromocionTemporal.FlagClienteMayorista = Boolean.Parse(reader["FlagClienteMayorista"].ToString());
                PromocionTemporal.FlagClienteFinal = Boolean.Parse(reader["FlagClienteFinal"].ToString());
                PromocionTemporal.FlagUcayali = Boolean.Parse(reader["FlagUcayali"].ToString());
                PromocionTemporal.FlagAndahuaylas = Boolean.Parse(reader["FlagAndahuaylas"].ToString());
                PromocionTemporal.FlagPrescott = Boolean.Parse(reader["FlagPrescott"].ToString());
                PromocionTemporal.FlagAviacion = Boolean.Parse(reader["FlagAviacion"].ToString());
                PromocionTemporal.FlagMegaplaza = Boolean.Parse(reader["FlagMegaplaza"].ToString());
                PromocionTemporal.FlagWeb = Boolean.Parse(reader["FlagWeb"].ToString());
                PromocionTemporal.FechaInicioImpresion = DateTime.Parse(reader["FechaInicioImpresion"].ToString());
                PromocionTemporal.FechaFinImpresion = DateTime.Parse(reader["FechaFinImpresion"].ToString());
                PromocionTemporal.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionTemporal.FlagAviacion2 = Boolean.Parse(reader["FlagAviacion2"].ToString());
                PromocionTemporal.FlagSanMiguel = Boolean.Parse(reader["FlagSanMiguel"].ToString());
                PromocionTemporallist.Add(PromocionTemporal);
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporallist;
        }

        public List<PromocionTemporalBE> ListaFecha(int IdEmpresa, bool FlagEstado, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporal_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Int32, FlagEstado);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionTemporalBE> PromocionTemporallist = new List<PromocionTemporalBE>();
            PromocionTemporalBE PromocionTemporal;
            while (reader.Read())
            {
                PromocionTemporal = new PromocionTemporalBE();
                PromocionTemporal.IdPromocionTemporal = Int32.Parse(reader["IdPromocionTemporal"].ToString());
                PromocionTemporal.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionTemporal.RazonSocial = reader["RazonSocial"].ToString();
                PromocionTemporal.DescPromocionTemporal = reader["DescPromocionTemporal"].ToString();
                PromocionTemporal.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionTemporal.DescTipoCliente = reader["DescTipoCliente"].ToString();
                PromocionTemporal.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionTemporal.DescFormaPago = reader["DescFormaPago"].ToString();
                PromocionTemporal.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PromocionTemporal.DescTienda = reader["DescTienda"].ToString();
                PromocionTemporal.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
                PromocionTemporal.DescTipoVenta = reader["DescTipoVenta"].ToString();
                PromocionTemporal.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PromocionTemporal.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PromocionTemporal.FlagContado = Boolean.Parse(reader["FlagContado"].ToString());
                PromocionTemporal.FlagCredito = Boolean.Parse(reader["FlagCredito"].ToString());
                PromocionTemporal.FlagConsignacion = Boolean.Parse(reader["FlagConsignacion"].ToString());
                PromocionTemporal.FlagSeparacion = Boolean.Parse(reader["FlagSeparacion"].ToString());
                PromocionTemporal.FlagContraentrega = Boolean.Parse(reader["FlagContraentrega"].ToString());
                PromocionTemporal.FlagCopagan = Boolean.Parse(reader["FlagCopagan"].ToString());
                PromocionTemporal.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                PromocionTemporal.FlagAsaf = Boolean.Parse(reader["FlagAsaf"].ToString());
                PromocionTemporal.FlagClienteMayorista = Boolean.Parse(reader["FlagClienteMayorista"].ToString());
                PromocionTemporal.FlagClienteFinal = Boolean.Parse(reader["FlagClienteFinal"].ToString());
                PromocionTemporal.FlagUcayali = Boolean.Parse(reader["FlagUcayali"].ToString());
                PromocionTemporal.FlagAndahuaylas = Boolean.Parse(reader["FlagAndahuaylas"].ToString());
                PromocionTemporal.FlagPrescott = Boolean.Parse(reader["FlagPrescott"].ToString());
                PromocionTemporal.FlagAviacion = Boolean.Parse(reader["FlagAviacion"].ToString());
                PromocionTemporal.FlagMegaplaza = Boolean.Parse(reader["FlagMegaplaza"].ToString());
                PromocionTemporal.FlagWeb = Boolean.Parse(reader["FlagWeb"].ToString());
                PromocionTemporal.FechaInicioImpresion = DateTime.Parse(reader["FechaInicioImpresion"].ToString());
                PromocionTemporal.FechaFinImpresion = DateTime.Parse(reader["FechaFinImpresion"].ToString());
                PromocionTemporal.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionTemporal.FlagAviacion2 = Boolean.Parse(reader["FlagAviacion2"].ToString());
                PromocionTemporal.FlagSanMiguel = Boolean.Parse(reader["FlagSanMiguel"].ToString());

                PromocionTemporallist.Add(PromocionTemporal);
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporallist;
        }

        public List<PromocionTemporalBE> ListaFechaProducto(int IdEmpresa, int IdProducto, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporal_ListaFechaProducto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionTemporalBE> PromocionTemporallist = new List<PromocionTemporalBE>();
            PromocionTemporalBE PromocionTemporal;
            while (reader.Read())
            {
                PromocionTemporal = new PromocionTemporalBE();
                PromocionTemporal.IdPromocionTemporal = Int32.Parse(reader["IdPromocionTemporal"].ToString());
                PromocionTemporal.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionTemporal.RazonSocial = reader["RazonSocial"].ToString();
                PromocionTemporal.DescPromocionTemporal = reader["DescPromocionTemporal"].ToString();
                PromocionTemporal.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionTemporal.DescTipoCliente = reader["DescTipoCliente"].ToString();
                PromocionTemporal.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionTemporal.DescFormaPago = reader["DescFormaPago"].ToString();
                PromocionTemporal.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PromocionTemporal.DescTienda = reader["DescTienda"].ToString();
                PromocionTemporal.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
                PromocionTemporal.DescTipoVenta = reader["DescTipoVenta"].ToString();
                PromocionTemporal.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PromocionTemporal.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PromocionTemporal.FlagContado = Boolean.Parse(reader["FlagContado"].ToString());
                PromocionTemporal.FlagCredito = Boolean.Parse(reader["FlagCredito"].ToString());
                PromocionTemporal.FlagConsignacion = Boolean.Parse(reader["FlagConsignacion"].ToString());
                PromocionTemporal.FlagSeparacion = Boolean.Parse(reader["FlagSeparacion"].ToString());
                PromocionTemporal.FlagContraentrega = Boolean.Parse(reader["FlagContraentrega"].ToString());
                PromocionTemporal.FlagCopagan = Boolean.Parse(reader["FlagCopagan"].ToString());
                PromocionTemporal.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                PromocionTemporal.FlagAsaf = Boolean.Parse(reader["FlagAsaf"].ToString());
                PromocionTemporal.FlagClienteMayorista = Boolean.Parse(reader["FlagClienteMayorista"].ToString());
                PromocionTemporal.FlagClienteFinal = Boolean.Parse(reader["FlagClienteFinal"].ToString());
                PromocionTemporal.FlagUcayali = Boolean.Parse(reader["FlagUcayali"].ToString());
                PromocionTemporal.FlagAndahuaylas = Boolean.Parse(reader["FlagAndahuaylas"].ToString());
                PromocionTemporal.FlagPrescott = Boolean.Parse(reader["FlagPrescott"].ToString());
                PromocionTemporal.FlagAviacion = Boolean.Parse(reader["FlagAviacion"].ToString());
                PromocionTemporal.FlagMegaplaza = Boolean.Parse(reader["FlagMegaplaza"].ToString());
                PromocionTemporal.FlagWeb = Boolean.Parse(reader["FlagWeb"].ToString());
                PromocionTemporal.FechaInicioImpresion = DateTime.Parse(reader["FechaInicioImpresion"].ToString());
                PromocionTemporal.FechaFinImpresion = DateTime.Parse(reader["FechaFinImpresion"].ToString());
                PromocionTemporal.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionTemporal.FlagAviacion2 = Boolean.Parse(reader["FlagAviacion2"].ToString());
                PromocionTemporal.FlagSanMiguel = Boolean.Parse(reader["FlagSanMiguel"].ToString());
                PromocionTemporallist.Add(PromocionTemporal);
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporallist;
        }

        public PromocionTemporalBE Selecciona(int IdPromocionTemporal)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionTemporal_Selecciona");
            db.AddInParameter(dbCommand, "pIdPromocionTemporal", DbType.Int32, IdPromocionTemporal);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PromocionTemporalBE PromocionTemporal = null;
            while (reader.Read())
            {
                PromocionTemporal = new PromocionTemporalBE();
                PromocionTemporal.IdPromocionTemporal = Int32.Parse(reader["IdPromocionTemporal"].ToString());
                PromocionTemporal.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                PromocionTemporal.RazonSocial = reader["RazonSocial"].ToString();
                PromocionTemporal.DescPromocionTemporal = reader["DescPromocionTemporal"].ToString();
                PromocionTemporal.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                PromocionTemporal.DescTipoCliente = reader["DescTipoCliente"].ToString();
                PromocionTemporal.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                PromocionTemporal.DescFormaPago = reader["DescFormaPago"].ToString();
                PromocionTemporal.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PromocionTemporal.DescTienda = reader["DescTienda"].ToString();
                PromocionTemporal.IdTipoVenta = Int32.Parse(reader["IdTipoVenta"].ToString());
                PromocionTemporal.DescTipoVenta = reader["DescTipoVenta"].ToString();
                PromocionTemporal.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                PromocionTemporal.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                PromocionTemporal.FlagContado = Boolean.Parse(reader["FlagContado"].ToString());
                PromocionTemporal.FlagCredito = Boolean.Parse(reader["FlagCredito"].ToString());
                PromocionTemporal.FlagConsignacion = Boolean.Parse(reader["FlagConsignacion"].ToString());
                PromocionTemporal.FlagSeparacion = Boolean.Parse(reader["FlagSeparacion"].ToString());
                PromocionTemporal.FlagContraentrega = Boolean.Parse(reader["FlagContraentrega"].ToString());
                PromocionTemporal.FlagCopagan = Boolean.Parse(reader["FlagCopagan"].ToString());
                PromocionTemporal.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                PromocionTemporal.FlagAsaf = Boolean.Parse(reader["FlagAsaf"].ToString());
                PromocionTemporal.FlagClienteMayorista = Boolean.Parse(reader["FlagClienteMayorista"].ToString());
                PromocionTemporal.FlagClienteFinal = Boolean.Parse(reader["FlagClienteFinal"].ToString());
                PromocionTemporal.FlagUcayali = Boolean.Parse(reader["FlagUcayali"].ToString());
                PromocionTemporal.FlagAndahuaylas = Boolean.Parse(reader["FlagAndahuaylas"].ToString());
                PromocionTemporal.FlagPrescott = Boolean.Parse(reader["FlagPrescott"].ToString());
                PromocionTemporal.FlagAviacion = Boolean.Parse(reader["FlagAviacion"].ToString());
                PromocionTemporal.FlagMegaplaza = Boolean.Parse(reader["FlagMegaplaza"].ToString());
                PromocionTemporal.FlagWeb = Boolean.Parse(reader["FlagWeb"].ToString());
                PromocionTemporal.FechaInicioImpresion = DateTime.Parse(reader["FechaInicioImpresion"].ToString());
                PromocionTemporal.FechaFinImpresion = DateTime.Parse(reader["FechaFinImpresion"].ToString());
                PromocionTemporal.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
             //   PromocionTemporal.FlagAviacion2 = Boolean.Parse(reader["FlagAviacion2"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporal;
        }

    }
}
