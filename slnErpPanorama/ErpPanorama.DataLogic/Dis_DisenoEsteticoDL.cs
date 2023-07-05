using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_DisenoEsteticoDL
    {
        public Dis_DisenoEsteticoDL() { }

        public void Inserta(Dis_DisenoEsteticoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoEstetico_Inserta");

            db.AddInParameter(dbCommand, "pIdDis_DisenoEstetico", DbType.Int32, pItem.IdDis_DisenoEstetico);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pObjetivos", DbType.String, pItem.Objetivos);
            db.AddInParameter(dbCommand, "pIdDis_Estilo", DbType.Int32, pItem.IdDis_Estilo);
            db.AddInParameter(dbCommand, "pIdDis_Forma", DbType.Int32, pItem.IdDis_Forma);
            db.AddInParameter(dbCommand, "pDescVolumen", DbType.String, pItem.DescVolumen);
            db.AddInParameter(dbCommand, "pDescTextura", DbType.String, pItem.DescTextura);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
            db.AddInParameter(dbCommand, "pIdDis_TipoColor", DbType.Int32, pItem.IdDis_TipoColor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Dis_DisenoEsteticoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoEstetico_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_DisenoEstetico", DbType.Int32, pItem.IdDis_DisenoEstetico);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pObjetivos", DbType.String, pItem.Objetivos);
            db.AddInParameter(dbCommand, "pIdDis_Estilo", DbType.Int32, pItem.IdDis_Estilo);
            db.AddInParameter(dbCommand, "pIdDis_Forma", DbType.Int32, pItem.IdDis_Forma);
            db.AddInParameter(dbCommand, "pDescVolumen", DbType.String, pItem.DescVolumen);
            db.AddInParameter(dbCommand, "pDescTextura", DbType.String, pItem.DescTextura);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
            db.AddInParameter(dbCommand, "pIdDis_TipoColor", DbType.Int32, pItem.IdDis_TipoColor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_DisenoEsteticoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoEstetico_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_DisenoEstetico", DbType.Int32, pItem.IdDis_DisenoEstetico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_DisenoEsteticoBE> ListaTodosActivo(int IdDis_ProyectoServicio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoEstetico_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_DisenoEsteticoBE> Dis_DisenoEsteticolist = new List<Dis_DisenoEsteticoBE>();
            Dis_DisenoEsteticoBE Dis_DisenoEstetico;
            while (reader.Read())
            {
                Dis_DisenoEstetico = new Dis_DisenoEsteticoBE();
                Dis_DisenoEstetico.IdDis_DisenoEstetico = Int32.Parse(reader["idDis_DisenoEstetico"].ToString());
                Dis_DisenoEstetico.IdDis_ProyectoServicio = Int32.Parse(reader["IdDis_ProyectoServicio"].ToString());
                Dis_DisenoEstetico.Objetivos = reader["Objetivos"].ToString();
                Dis_DisenoEstetico.IdDis_Estilo = Int32.Parse(reader["IdDis_Estilo"].ToString());
                Dis_DisenoEstetico.DescDis_Estilo = reader["DescDis_Estilo"].ToString();
                Dis_DisenoEstetico.IdDis_Forma = Int32.Parse(reader["IdDis_Forma"].ToString());
                Dis_DisenoEstetico.DescDis_Forma = reader["DescDis_Forma"].ToString();
                Dis_DisenoEstetico.DescVolumen = reader["DescVolumen"].ToString();
                Dis_DisenoEstetico.DescTextura = reader["DescTextura"].ToString();
                Dis_DisenoEstetico.IdMaterial = Int32.Parse(reader["IdMaterial"].ToString());
                Dis_DisenoEstetico.DescMaterial = reader["DescMaterial"].ToString();
                Dis_DisenoEstetico.IdDis_TipoColor = Int32.Parse(reader["IdDis_TipoColor"].ToString());
                Dis_DisenoEstetico.DescDis_TipoColor = reader["DescDis_TipoColor"].ToString();
                Dis_DisenoEstetico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_DisenoEstetico.TipoOper = 4; //Consultar
                Dis_DisenoEsteticolist.Add(Dis_DisenoEstetico);
            }
            reader.Close();
            reader.Dispose();
            return Dis_DisenoEsteticolist;
        }
    }
}
