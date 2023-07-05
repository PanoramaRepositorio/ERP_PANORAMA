using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class InmuebleAlquilerDL
    {
        public InmuebleAlquilerDL() { }

        public void Inserta(InmuebleAlquilerBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmuebleAlquiler_Inserta");

            db.AddInParameter(dbCommand, "pIdInmuebleAlquiler", DbType.Int32, pItem.IdInmuebleAlquiler);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdInmueble", DbType.Int32, pItem.IdInmueble);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pPrecioAlquiler", DbType.Decimal, pItem.PrecioAlquiler);
            db.AddInParameter(dbCommand, "pAdelanto", DbType.Decimal, pItem.Adelanto);
            db.AddInParameter(dbCommand, "pGarantia", DbType.Decimal, pItem.Garantia);
            db.AddInParameter(dbCommand, "pDiaPago", DbType.Int32, pItem.DiaPago);
            db.AddInParameter(dbCommand, "pMora", DbType.Decimal, pItem.Mora);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(InmuebleAlquilerBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmuebleAlquiler_Actualiza");

            db.AddInParameter(dbCommand, "pIdInmuebleAlquiler", DbType.Int32, pItem.IdInmuebleAlquiler);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdInmueble", DbType.Int32, pItem.IdInmueble);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pPrecioAlquiler", DbType.Decimal, pItem.PrecioAlquiler);
            db.AddInParameter(dbCommand, "pAdelanto", DbType.Decimal, pItem.Adelanto);
            db.AddInParameter(dbCommand, "pGarantia", DbType.Decimal, pItem.Garantia);
            db.AddInParameter(dbCommand, "pDiaPago", DbType.Int32, pItem.DiaPago);
            db.AddInParameter(dbCommand, "pMora", DbType.Decimal, pItem.Mora);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pFechaRegistro", DbType.DateTime, pItem.FechaRegistro);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(InmuebleAlquilerBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmuebleAlquiler_Elimina");

            db.AddInParameter(dbCommand, "pIdInmuebleAlquiler", DbType.Int32, pItem.IdInmuebleAlquiler);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<InmuebleAlquilerBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmuebleAlquiler_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InmuebleAlquilerBE> InmuebleAlquilerlist = new List<InmuebleAlquilerBE>();
            InmuebleAlquilerBE InmuebleAlquiler;
            while (reader.Read())
            {
                InmuebleAlquiler = new InmuebleAlquilerBE();
                InmuebleAlquiler.IdInmuebleAlquiler = Int32.Parse(reader["idInmuebleAlquiler"].ToString());
                InmuebleAlquiler.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                InmuebleAlquiler.RazonSocial = reader["RazonSocial"].ToString();
                InmuebleAlquiler.IdInmueble = Int32.Parse(reader["IdInmueble"].ToString());
                InmuebleAlquiler.DescInmueble = reader["DescInmueble"].ToString();
                InmuebleAlquiler.DescTipoInmueble = reader["DescTipoInmueble"].ToString();
                InmuebleAlquiler.NomDpto = reader["NomDpto"].ToString();
                InmuebleAlquiler.NomProv = reader["NomProv"].ToString();
                InmuebleAlquiler.NomDist = reader["NomDist"].ToString();
                InmuebleAlquiler.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                InmuebleAlquiler.NumeroDocumento = reader["NumeroDocumento"].ToString();
                InmuebleAlquiler.DescCliente = reader["DescCliente"].ToString();
                InmuebleAlquiler.Direccion = reader["Direccion"].ToString();
                InmuebleAlquiler.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                InmuebleAlquiler.DescMoneda = reader["DescMoneda"].ToString();
                InmuebleAlquiler.PrecioAlquiler = Decimal.Parse(reader["PrecioAlquiler"].ToString());
                InmuebleAlquiler.Adelanto = Decimal.Parse(reader["Adelanto"].ToString());
                InmuebleAlquiler.Garantia = Decimal.Parse(reader["Garantia"].ToString());
                InmuebleAlquiler.DiaPago = Int32.Parse(reader["DiaPago"].ToString());
                InmuebleAlquiler.Mora = Decimal.Parse(reader["Mora"].ToString());
                InmuebleAlquiler.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                InmuebleAlquiler.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                InmuebleAlquiler.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                InmuebleAlquiler.Observacion = reader["Observacion"].ToString();
                InmuebleAlquiler.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InmuebleAlquilerlist.Add(InmuebleAlquiler);
            }
            reader.Close();
            reader.Dispose();
            return InmuebleAlquilerlist;
        }

        public List<InmuebleAlquilerBE> ListaInmuebleCliente(int IdCliente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmuebleAlquiler_ListaInmuebleCliente");
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, IdCliente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<InmuebleAlquilerBE> InmuebleAlquilerlist = new List<InmuebleAlquilerBE>();
            InmuebleAlquilerBE InmuebleAlquiler;
            while (reader.Read())
            {
                InmuebleAlquiler = new InmuebleAlquilerBE();
                InmuebleAlquiler.IdInmuebleAlquiler = Int32.Parse(reader["idInmuebleAlquiler"].ToString());
                InmuebleAlquiler.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                InmuebleAlquiler.RazonSocial = reader["RazonSocial"].ToString();
                InmuebleAlquiler.IdInmueble = Int32.Parse(reader["IdInmueble"].ToString());
                InmuebleAlquiler.DescInmueble = reader["DescInmueble"].ToString();
                InmuebleAlquiler.DescTipoInmueble = reader["DescTipoInmueble"].ToString();
                InmuebleAlquiler.NomDpto = reader["NomDpto"].ToString();
                InmuebleAlquiler.NomProv = reader["NomProv"].ToString();
                InmuebleAlquiler.NomDist = reader["NomDist"].ToString();
                InmuebleAlquiler.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                InmuebleAlquiler.NumeroDocumento = reader["NumeroDocumento"].ToString();
                InmuebleAlquiler.DescCliente = reader["DescCliente"].ToString();
                InmuebleAlquiler.Direccion = reader["Direccion"].ToString();
                InmuebleAlquiler.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                InmuebleAlquiler.DescMoneda = reader["DescMoneda"].ToString();
                InmuebleAlquiler.PrecioAlquiler = Decimal.Parse(reader["PrecioAlquiler"].ToString());
                InmuebleAlquiler.Adelanto = Decimal.Parse(reader["Adelanto"].ToString());
                InmuebleAlquiler.Garantia = Decimal.Parse(reader["Garantia"].ToString());
                InmuebleAlquiler.DiaPago = Int32.Parse(reader["DiaPago"].ToString());
                InmuebleAlquiler.Mora = Decimal.Parse(reader["Mora"].ToString());
                InmuebleAlquiler.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                InmuebleAlquiler.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                InmuebleAlquiler.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                InmuebleAlquiler.Observacion = reader["Observacion"].ToString();
                InmuebleAlquiler.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                InmuebleAlquilerlist.Add(InmuebleAlquiler);
            }
            reader.Close();
            reader.Dispose();
            return InmuebleAlquilerlist;
        }

        public InmuebleAlquilerBE Selecciona(int IdInmuebleAlquiler)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InmuebleAlquiler_Selecciona");
            db.AddInParameter(dbCommand, "pIdInmuebleAlquiler", DbType.Int32, IdInmuebleAlquiler);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InmuebleAlquilerBE InmuebleAlquiler = null;
            while (reader.Read())
            {
                InmuebleAlquiler = new InmuebleAlquilerBE();
                InmuebleAlquiler.IdInmuebleAlquiler = Int32.Parse(reader["idInmuebleAlquiler"].ToString());
                InmuebleAlquiler.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                InmuebleAlquiler.RazonSocial = reader["RazonSocial"].ToString();
                InmuebleAlquiler.IdInmueble = Int32.Parse(reader["IdInmueble"].ToString());
                InmuebleAlquiler.DescInmueble = reader["DescInmueble"].ToString();
                InmuebleAlquiler.DescTipoInmueble = reader["DescTipoInmueble"].ToString();
                InmuebleAlquiler.NomDpto = reader["NomDpto"].ToString();
                InmuebleAlquiler.NomProv = reader["NomProv"].ToString();
                InmuebleAlquiler.NomDist = reader["NomDist"].ToString();
                InmuebleAlquiler.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                InmuebleAlquiler.NumeroDocumento = reader["NumeroDocumento"].ToString();
                InmuebleAlquiler.DescCliente = reader["DescCliente"].ToString();
                InmuebleAlquiler.Direccion = reader["Direccion"].ToString();
                InmuebleAlquiler.IdMoneda = Int32.Parse(reader["IdMoneda"].ToString());
                InmuebleAlquiler.DescMoneda = reader["DescMoneda"].ToString();
                InmuebleAlquiler.PrecioAlquiler = Decimal.Parse(reader["PrecioAlquiler"].ToString());
                InmuebleAlquiler.Adelanto = Decimal.Parse(reader["Adelanto"].ToString());
                InmuebleAlquiler.Garantia = Decimal.Parse(reader["Garantia"].ToString());
                InmuebleAlquiler.DiaPago = Int32.Parse(reader["DiaPago"].ToString());
                InmuebleAlquiler.Mora = Decimal.Parse(reader["Mora"].ToString());
                InmuebleAlquiler.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                InmuebleAlquiler.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                InmuebleAlquiler.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                InmuebleAlquiler.Observacion = reader["Observacion"].ToString();
                InmuebleAlquiler.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return InmuebleAlquiler;
        }
    }
}
