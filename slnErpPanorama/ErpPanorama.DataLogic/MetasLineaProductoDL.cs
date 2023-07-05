using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class MetasLineaProductoDL
    {
        public MetasLineaProductoDL() { }

        public void Inserta(MetasLineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasLineaProducto_Inserta");

            db.AddInParameter(dbCommand, "pIdMetasLineaProducto", DbType.Int32, pItem.IdMetasLineaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(MetasLineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasLineaProducto_Actualiza");

            db.AddInParameter(dbCommand, "pIdMetasLineaProducto", DbType.Int32, pItem.IdMetasLineaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pImporte", DbType.Decimal, pItem.Importe);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(MetasLineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasLineaProducto_Elimina");

            db.AddInParameter(dbCommand, "pIdMetasLineaProducto", DbType.Int32, pItem.IdMetasLineaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<MetasLineaProductoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasLineaProducto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MetasLineaProductoBE> MetasLineaProductolist = new List<MetasLineaProductoBE>();
            MetasLineaProductoBE MetasLineaProducto;
            while (reader.Read())
            {
                MetasLineaProducto = new MetasLineaProductoBE();
                MetasLineaProducto.IdMetasLineaProducto = Int32.Parse(reader["idMetasLineaProducto"].ToString());
                MetasLineaProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MetasLineaProducto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                MetasLineaProducto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                MetasLineaProducto.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                MetasLineaProducto.DescVendedor = reader["DescVendedor"].ToString();
                MetasLineaProducto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MetasLineaProducto.Mes = Int32.Parse(reader["Mes"].ToString());
                MetasLineaProducto.NombreMes = reader["NombreMes"].ToString();
                MetasLineaProducto.Importe = Decimal.Parse(reader["Importe"].ToString());
                MetasLineaProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                MetasLineaProductolist.Add(MetasLineaProducto);
            }
            reader.Close();
            reader.Dispose();
            return MetasLineaProductolist;
        }

        public MetasLineaProductoBE Selecciona(int IdEmpresa, int IdMetasLineaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_MetasLineaProducto_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdMetasLineaProducto", DbType.Int32, IdMetasLineaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            MetasLineaProductoBE MetasLineaProducto = null;
            while (reader.Read())
            {
                MetasLineaProducto = new MetasLineaProductoBE();
                MetasLineaProducto.IdMetasLineaProducto = Int32.Parse(reader["idMetasLineaProducto"].ToString());
                MetasLineaProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                MetasLineaProducto.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                MetasLineaProducto.DescLineaProducto = reader["DescLineaProducto"].ToString();
                MetasLineaProducto.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                MetasLineaProducto.DescVendedor = reader["DescVendedor"].ToString();
                MetasLineaProducto.Periodo = Int32.Parse(reader["Periodo"].ToString());
                MetasLineaProducto.Mes = Int32.Parse(reader["Mes"].ToString());
                MetasLineaProducto.NombreMes = reader["NombreMes"].ToString();
                MetasLineaProducto.Importe = Decimal.Parse(reader["Importe"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return MetasLineaProducto;
        }
    }
}
