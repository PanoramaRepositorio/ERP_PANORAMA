using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MetasCarteraDL
    {
        public MetasCarteraDL() { }

        public void Inserta(MetasCarteraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasCartera_Inserta");

            db.AddInParameter(dbCommand, "pIdMetasCartera", DbType.Int32, pItem.IdMetasCartera);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, pItem.IdRuta);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(MetasCarteraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasCartera_Actualiza");

            db.AddInParameter(dbCommand, "pIdMetasCartera", DbType.Int32, pItem.IdMetasCartera);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdRuta", DbType.Int32, pItem.IdRuta);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(MetasCarteraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasCartera_Elimina");

            db.AddInParameter(dbCommand, "pIdMetasCartera", DbType.Int32, pItem.IdMetasCartera);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<MetasCarteraBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasCartera_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MetasCarteraBE> MetasCarteralist = new List<MetasCarteraBE>();
            MetasCarteraBE MetasCartera;
            while (reader.Read())
            {
                MetasCartera = new MetasCarteraBE();
                MetasCartera.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                MetasCartera.IdMetasCartera = Int32.Parse(reader["IdMetasCartera"].ToString());
                MetasCartera.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                MetasCartera.DescRuta = reader["DescRuta"].ToString();
                MetasCartera.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MetasCartera.Mes = Int32.Parse(reader["Mes"].ToString());
                MetasCartera.NombreMes = reader["NombreMes"].ToString();
                MetasCartera.Importe = Decimal.Parse(reader["Importe"].ToString());
                MetasCartera.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MetasCarteralist.Add(MetasCartera);
            }
            reader.Close();
            reader.Dispose();
            return MetasCarteralist;
        }

        public MetasCarteraBE Selecciona(int IdEmpresa, int IdMetasCartera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasCartera_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMetasCartera", DbType.Int32, IdMetasCartera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MetasCarteraBE MetasCartera = null;
            while (reader.Read())
            {
                MetasCartera = new MetasCarteraBE();
                MetasCartera.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MetasCartera.IdMetasCartera = Int32.Parse(reader["IdMetasCartera"].ToString());
                MetasCartera.IdRuta = Int32.Parse(reader["IdRuta"].ToString());
                MetasCartera.DescRuta = reader["DescRuta"].ToString();
                MetasCartera.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MetasCartera.Mes = Int32.Parse(reader["Mes"].ToString());
                MetasCartera.NombreMes = reader["NombreMes"].ToString();
                MetasCartera.Importe = Decimal.Parse(reader["Importe"].ToString());
                MetasCartera.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MetasCartera;
        }
    }
}
