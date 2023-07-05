using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class LineaProductoDL
    {
        public LineaProductoDL() { }

        public void Inserta(LineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LineaProducto_Inserta");

            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, pItem.Numero);
            db.AddInParameter(dbCommand, "pDescLineaProducto", DbType.String, pItem.DescLineaProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(LineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LineaProducto_Actualiza");

            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, pItem.Numero);
            db.AddInParameter(dbCommand, "pDescLineaProducto", DbType.String, pItem.DescLineaProducto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(LineaProductoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LineaProducto_Elimina");

            db.AddInParameter(dbCommand, "pIdLineaProducto", DbType.Int32, pItem.IdLineaProducto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<LineaProductoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LineaProducto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LineaProductoBE> LineaProductolist = new List<LineaProductoBE>();
            LineaProductoBE LineaProducto;
            while (reader.Read())
            {
                LineaProducto = new LineaProductoBE();
                LineaProducto.IdLineaProducto = Int32.Parse(reader["idLineaProducto"].ToString());
                LineaProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                LineaProducto.Numero = Int32.Parse(reader["numero"].ToString());
                LineaProducto.DescLineaProducto = reader["descLineaProducto"].ToString();
                LineaProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                LineaProductolist.Add(LineaProducto);
            }
            reader.Close();
            reader.Dispose();
            return LineaProductolist;
        }


        public List<LineaProductoBE> ListaTodosActivoKardex(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LineaProducto_ListaTodosActivoKardex");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LineaProductoBE> LineaProductolist = new List<LineaProductoBE>();
            LineaProductoBE LineaProducto;
            while (reader.Read())
            {
                LineaProducto = new LineaProductoBE();
                LineaProducto.IdLineaProducto = Int32.Parse(reader["idLineaProducto"].ToString());
                LineaProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                LineaProducto.Numero = Int32.Parse(reader["numero"].ToString());
                LineaProducto.DescLineaProducto = reader["descLineaProducto"].ToString();
                LineaProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                LineaProductolist.Add(LineaProducto);
            }
            reader.Close();
            reader.Dispose();
            return LineaProductolist;
        }


        public List<LineaProductoBE> ListaTodosActivoFamilia(int IdEmpresa, int IdFamiliaProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_LineaProducto_ListaTodosActivoFamilia");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, IdFamiliaProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<LineaProductoBE> LineaProductolist = new List<LineaProductoBE>();
            LineaProductoBE LineaProducto;
            while (reader.Read())
            {
                LineaProducto = new LineaProductoBE();
                LineaProducto.IdLineaProducto = Int32.Parse(reader["idLineaProducto"].ToString());
                LineaProducto.IdFamiliaProducto = Int32.Parse(reader["idFamiliaProducto"].ToString());
                LineaProducto.DescFamiliaProducto = reader["descFamiliaProducto"].ToString();
                LineaProducto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                LineaProducto.Numero = Int32.Parse(reader["numero"].ToString());
                LineaProducto.DescLineaProducto = reader["descLineaProducto"].ToString();
                LineaProducto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                LineaProductolist.Add(LineaProducto);
            }
            reader.Close();
            reader.Dispose();
            return LineaProductolist;
        }

    }
}

