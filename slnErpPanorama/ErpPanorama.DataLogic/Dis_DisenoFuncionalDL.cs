using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_DisenoFuncionalDL
    {
        public Dis_DisenoFuncionalDL() { }

        public void Inserta(Dis_DisenoFuncionalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoFuncional_Inserta");

            db.AddInParameter(dbCommand, "pIdDis_DisenoFuncional", DbType.Int32, pItem.IdDis_DisenoFuncional);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdDis_Ambiente", DbType.Int32, pItem.IdDis_Ambiente);
            db.AddInParameter(dbCommand, "pDescActividad", DbType.String, pItem.DescActividad);
            db.AddInParameter(dbCommand, "pIdDis_Pieza", DbType.Int32, pItem.IdDis_Pieza);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
            db.AddInParameter(dbCommand, "pIdDis_Estilo", DbType.Int32, pItem.IdDis_Estilo);
            db.AddInParameter(dbCommand, "pIdDis_Forma", DbType.Int32, pItem.IdDis_Forma);
            db.AddInParameter(dbCommand, "pDescVolumen", DbType.String, pItem.DescVolumen);
            db.AddInParameter(dbCommand, "pDescTextura", DbType.String, pItem.DescTextura);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Dis_DisenoFuncionalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoFuncional_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_DisenoFuncional", DbType.Int32, pItem.IdDis_DisenoFuncional);
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, pItem.IdDis_ProyectoServicio);
            db.AddInParameter(dbCommand, "pIdDis_Ambiente", DbType.Int32, pItem.IdDis_Ambiente);
            db.AddInParameter(dbCommand, "pDescActividad", DbType.String, pItem.DescActividad);
            db.AddInParameter(dbCommand, "pIdDis_Pieza", DbType.Int32, pItem.IdDis_Pieza);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pIdMaterial", DbType.Int32, pItem.IdMaterial);
            db.AddInParameter(dbCommand, "pIdDis_Estilo", DbType.Int32, pItem.IdDis_Estilo);
            db.AddInParameter(dbCommand, "pIdDis_Forma", DbType.Int32, pItem.IdDis_Forma);
            db.AddInParameter(dbCommand, "pDescVolumen", DbType.String, pItem.DescVolumen);
            db.AddInParameter(dbCommand, "pDescTextura", DbType.String, pItem.DescTextura);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_DisenoFuncionalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoFuncional_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_DisenoFuncional", DbType.Int32, pItem.IdDis_DisenoFuncional);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_DisenoFuncionalBE> ListaTodosActivo(int IdDis_ProyectoServicio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_DisenoFuncional_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdDis_ProyectoServicio", DbType.Int32, IdDis_ProyectoServicio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_DisenoFuncionalBE> Dis_DisenoFuncionallist = new List<Dis_DisenoFuncionalBE>();
            Dis_DisenoFuncionalBE Dis_DisenoFuncional;
            while (reader.Read())
            {
                Dis_DisenoFuncional = new Dis_DisenoFuncionalBE();
                Dis_DisenoFuncional.IdDis_DisenoFuncional = Int32.Parse(reader["idDis_DisenoFuncional"].ToString());
                Dis_DisenoFuncional.IdDis_ProyectoServicio = Int32.Parse(reader["IdDis_ProyectoServicio"].ToString());
                Dis_DisenoFuncional.IdDis_Ambiente = Int32.Parse(reader["IdDis_Ambiente"].ToString());
                Dis_DisenoFuncional.DescDis_Ambiente = reader["DescDis_Ambiente"].ToString();
                Dis_DisenoFuncional.DescActividad = reader["DescActividad"].ToString();
                Dis_DisenoFuncional.IdDis_Pieza = Int32.Parse(reader["IdDis_Pieza"].ToString());
                Dis_DisenoFuncional.DescDis_Pieza = reader["DescDis_Pieza"].ToString();
                Dis_DisenoFuncional.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Dis_DisenoFuncional.IdMaterial = Int32.Parse(reader["IdMaterial"].ToString());
                Dis_DisenoFuncional.DescMaterial = reader["DescMaterial"].ToString();
                Dis_DisenoFuncional.IdDis_Estilo = Int32.Parse(reader["IdDis_Estilo"].ToString());
                Dis_DisenoFuncional.DescDis_Estilo = reader["DescDis_Estilo"].ToString();
                Dis_DisenoFuncional.IdDis_Forma = Int32.Parse(reader["IdDis_Forma"].ToString());
                Dis_DisenoFuncional.DescDis_Forma = reader["DescDis_Forma"].ToString();
                Dis_DisenoFuncional.DescVolumen = reader["DescVolumen"].ToString();
                Dis_DisenoFuncional.DescTextura = reader["DescTextura"].ToString();
                Dis_DisenoFuncional.Observacion = reader["Observacion"].ToString();
                Dis_DisenoFuncional.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_DisenoFuncional.TipoOper = 4; //Consultar
                Dis_DisenoFuncionallist.Add(Dis_DisenoFuncional);
            }
            reader.Close();
            reader.Dispose();
            return Dis_DisenoFuncionallist;
        }
    }
}
