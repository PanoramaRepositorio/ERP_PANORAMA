using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Promocion3x2DL
    {
        public Promocion3x2DL() { }

        public Int32 Inserta(Promocion2x1BE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1_Inserta");

            db.AddOutParameter(dbCommand, "pIdPromocion2x1", DbType.Int32, pItem.IdPromocion2x1);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescPromocion2x1", DbType.String, pItem.DescPromocion2x1);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
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
            db.AddInParameter(dbCommand, "pFlagWeb", DbType.Boolean, pItem.FlagWeb);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            

            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdPromocion2x1");

            return intIdCliente;
        }

        public void Actualiza(Promocion2x1BE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1_Actualiza");

            db.AddInParameter(dbCommand, "pIdPromocion2x1", DbType.Int32, pItem.IdPromocion2x1);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescPromocion2x1", DbType.String, pItem.DescPromocion2x1);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, pItem.IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pTipo", DbType.String, pItem.Tipo);
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
            db.AddInParameter(dbCommand, "pFlagWeb", DbType.Boolean, pItem.FlagWeb);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Promocion2x1BE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1_Elimina");

            db.AddInParameter(dbCommand, "pIdPromocion2x1", DbType.Int32, pItem.IdPromocion2x1);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Promocion3x2BE> ListaTodosActivo(int IdEmpresa, string Tipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion3x2_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pTipo", DbType.String, Tipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Promocion3x2BE> Promocion3x2list = new List<Promocion3x2BE>();
            Promocion3x2BE Promocion3x2;
            while (reader.Read())
            {
                Promocion3x2 = new Promocion3x2BE();
                Promocion3x2.IdPromocion3x2 = Int32.Parse(reader["IdPromocion3x2"].ToString());
                Promocion3x2.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Promocion3x2.RazonSocial = reader["RazonSocial"].ToString();
                Promocion3x2.DescPromocion3x2 = reader["DescPromocion3x2"].ToString();
                Promocion3x2.IdTipoCliente = Int32.Parse(reader["IdTipoCliente"].ToString());
                Promocion3x2.DescTipoCliente = reader["DescTipoCliente"].ToString();
                Promocion3x2.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                Promocion3x2.DescFormaPago = reader["DescFormaPago"].ToString();
                Promocion3x2.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Promocion3x2.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Promocion3x2.Tipo = reader["Tipo"].ToString();
                Promocion3x2.FlagContado = Boolean.Parse(reader["FlagContado"].ToString());
                Promocion3x2.FlagCredito = Boolean.Parse(reader["FlagCredito"].ToString());
                Promocion3x2.FlagConsignacion = Boolean.Parse(reader["FlagConsignacion"].ToString());
                Promocion3x2.FlagSeparacion = Boolean.Parse(reader["FlagSeparacion"].ToString());
                Promocion3x2.FlagContraentrega = Boolean.Parse(reader["FlagContraentrega"].ToString());
                Promocion3x2.FlagCopagan = Boolean.Parse(reader["FlagCopagan"].ToString());
                Promocion3x2.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Promocion3x2.FlagAsaf = Boolean.Parse(reader["FlagAsaf"].ToString());
                Promocion3x2.FlagClienteMayorista = Boolean.Parse(reader["FlagClienteMayorista"].ToString());
                Promocion3x2.FlagClienteFinal = Boolean.Parse(reader["FlagClienteFinal"].ToString());
                Promocion3x2.FlagWeb = Boolean.Parse(reader["FlagWeb"].ToString());
                Promocion3x2.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Promocion3x2list.Add(Promocion3x2);
            }
            reader.Close();
            reader.Dispose();
            return Promocion3x2list;
        }

        public List<Promocion2x1BE> ListaVigente(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Promocion2x1_ListaVigente");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Promocion2x1BE> Promocion2x1list = new List<Promocion2x1BE>();
            Promocion2x1BE Promocion2x1;
            while (reader.Read())
            {
                Promocion2x1 = new Promocion2x1BE();
                Promocion2x1.IdPromocion2x1 = Int32.Parse(reader["IdPromocion2x1"].ToString());
                Promocion2x1.RazonSocial = reader["RazonSocial"].ToString();
                Promocion2x1.DescPromocion2x1 = reader["DescPromocion2x1"].ToString();
                Promocion2x1.FechaInicio = DateTime.Parse(reader["FechaInicio"].ToString());
                Promocion2x1.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Promocion2x1.Tipo = reader["Tipo"].ToString();
                Promocion2x1.FlagContado = Boolean.Parse(reader["FlagContado"].ToString());
                Promocion2x1.FlagCredito = Boolean.Parse(reader["FlagCredito"].ToString());
                Promocion2x1.FlagConsignacion = Boolean.Parse(reader["FlagConsignacion"].ToString());
                Promocion2x1.FlagSeparacion = Boolean.Parse(reader["FlagSeparacion"].ToString());
                Promocion2x1.FlagContraentrega = Boolean.Parse(reader["FlagContraentrega"].ToString());
                Promocion2x1.FlagCopagan = Boolean.Parse(reader["FlagCopagan"].ToString());
                Promocion2x1.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Promocion2x1.FlagAsaf = Boolean.Parse(reader["FlagAsaf"].ToString());
                Promocion2x1.FlagClienteMayorista = Boolean.Parse(reader["FlagClienteMayorista"].ToString());
                Promocion2x1.FlagClienteFinal = Boolean.Parse(reader["FlagClienteFinal"].ToString());
                Promocion2x1.FlagWeb = Boolean.Parse(reader["FlagWeb"].ToString());
                Promocion2x1.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Promocion2x1list.Add(Promocion2x1);
            }
            reader.Close();
            reader.Dispose();
            return Promocion2x1list;
        }

    }
}
