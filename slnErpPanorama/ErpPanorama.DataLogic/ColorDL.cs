using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ColorDL
    {
        public ColorDL() { }

        //public void Inserta(ColorBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_Material_Inserta");

        //    db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
        //    db.AddInParameter(dbCommand, "pDescMaterial", DbType.String, pItem.DescMaterial);
        //    db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public void Actualiza(ColorBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_Material_Actualiza");

        //    db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
        //    db.AddInParameter(dbCommand, "pDescMaterial", DbType.String, pItem.DescMaterial);
        //    db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public void Elimina(ColorBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_Material_Elimina");

        //    db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
        //    db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        public List<ColorBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Color_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ColorBE> Materiallist = new List<ColorBE>();
            ColorBE Material;
            while (reader.Read())
            {
                Material = new ColorBE();
                Material.IdColor = Int32.Parse(reader["IdColor"].ToString());
                Material.DescColor = reader["DescColor"].ToString();
                Materiallist.Add(Material);
            }
            reader.Close();
            reader.Dispose();
            return Materiallist;
        }

        //public ColorBE SelecionaMaterial(string Descripcion)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_Material_SeleccionaDescMaterial");
        //    db.AddInParameter(dbCommand, "pDescripcion", DbType.String, Descripcion);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    ColorBE Material =null;
        //    while (reader.Read())
        //    {
        //        Material = new ColorBE();
        //        Material.IdMaterial = Int32.Parse(reader["idMaterial"].ToString());
        //        Material.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
        //        Material.DescMaterial = reader["descMaterial"].ToString();
        //        Material.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return Material;
        //}
    }
}
