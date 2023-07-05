using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_PiezaDL
    {
        public Dis_PiezaDL() { }

        public void Inserta(Dis_PiezaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Pieza_Inserta");

            db.AddInParameter(dbCommand, "pIdDis_Pieza", DbType.Int32, pItem.IdDis_Pieza);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescDis_Pieza", DbType.String, pItem.DescDis_Pieza);
            db.AddInParameter(dbCommand, "pIdTipoPieza", DbType.Int32, pItem.IdTipoPieza);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Dis_PiezaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Pieza_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_Pieza", DbType.Int32, pItem.IdDis_Pieza);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescDis_Pieza", DbType.String, pItem.DescDis_Pieza);
            db.AddInParameter(dbCommand, "pIdTipoPieza", DbType.Int32, pItem.IdTipoPieza);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_PiezaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Pieza_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_Pieza", DbType.Int32, pItem.IdDis_Pieza);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_PiezaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_Pieza_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_PiezaBE> Dis_Piezalist = new List<Dis_PiezaBE>();
            Dis_PiezaBE Dis_Pieza;
            while (reader.Read())
            {
                Dis_Pieza = new Dis_PiezaBE();
                Dis_Pieza.IdDis_Pieza = Int32.Parse(reader["idDis_Pieza"].ToString());
                Dis_Pieza.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_Pieza.DescDis_Pieza = reader["descDis_Pieza"].ToString();
                Dis_Pieza.IdTipoPieza = Int32.Parse(reader["IdTipoPieza"].ToString());
                Dis_Pieza.DescTipoPieza = reader["DescTipoPieza"].ToString();
                Dis_Pieza.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_Piezalist.Add(Dis_Pieza);
            }
            reader.Close();
            reader.Dispose();
            return Dis_Piezalist;
        }
    }
}
