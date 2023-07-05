using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_ContratoAsesoriaDL
    {
       public Dis_ContratoAsesoriaDL() { }

        public void Inserta(Dis_ContratoAsesoriaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoAsesoria_Inserta");

            db.AddInParameter(dbCommand, "pIdDis_ContratoAsesoria", DbType.Int32, pItem.IdDis_ContratoAsesoria);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pTitulo", DbType.String, pItem.Titulo);
            db.AddInParameter(dbCommand, "pCuerpoSustantivo", DbType.String, pItem.CuerpoSustantivo);
            db.AddInParameter(dbCommand, "pProcedimiento", DbType.String, pItem.Procedimiento);
            db.AddInParameter(dbCommand, "pPlazoCosto", DbType.String, pItem.PlazoCosto);
            db.AddInParameter(dbCommand, "pPublicidad", DbType.String, pItem.Publicidad);
            db.AddInParameter(dbCommand, "pVersion", DbType.String, pItem.Version);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Dis_ContratoAsesoriaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoAsesoria_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_ContratoAsesoria", DbType.Int32, pItem.IdDis_ContratoAsesoria);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescripcion", DbType.String, pItem.Descripcion);
            db.AddInParameter(dbCommand, "pTitulo", DbType.String, pItem.Titulo);
            db.AddInParameter(dbCommand, "pCuerpoSustantivo", DbType.String, pItem.CuerpoSustantivo);
            db.AddInParameter(dbCommand, "pProcedimiento", DbType.String, pItem.Procedimiento);
            db.AddInParameter(dbCommand, "pPlazoCosto", DbType.String, pItem.PlazoCosto);
            db.AddInParameter(dbCommand, "pPublicidad", DbType.String, pItem.Publicidad);
            db.AddInParameter(dbCommand, "pVersion", DbType.String, pItem.Version);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_ContratoAsesoriaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoAsesoria_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_ContratoAsesoria", DbType.Int32, pItem.IdDis_ContratoAsesoria);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_ContratoAsesoriaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoAsesoria_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            //db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_ContratoAsesoriaBE> Dis_ContratoAsesorialist = new List<Dis_ContratoAsesoriaBE>();
            Dis_ContratoAsesoriaBE Dis_ContratoAsesoria;
            while (reader.Read())
            {
                Dis_ContratoAsesoria = new Dis_ContratoAsesoriaBE();
                Dis_ContratoAsesoria.IdDis_ContratoAsesoria = Int32.Parse(reader["IdDis_ContratoAsesoria"].ToString());
                Dis_ContratoAsesoria.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Dis_ContratoAsesoria.RazonSocial = reader["RazonSocial"].ToString();
                Dis_ContratoAsesoria.Descripcion = reader["Descripcion"].ToString();
                Dis_ContratoAsesoria.Titulo = reader["Titulo"].ToString();
                Dis_ContratoAsesoria.CuerpoSustantivo = reader["CuerpoSustantivo"].ToString();
                Dis_ContratoAsesoria.Procedimiento = reader["Procedimiento"].ToString();
                Dis_ContratoAsesoria.PlazoCosto = reader["PlazoCosto"].ToString();
                Dis_ContratoAsesoria.Publicidad = reader["Publicidad"].ToString();
                Dis_ContratoAsesoria.Version = reader["Version"].ToString();
                Dis_ContratoAsesoria.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Dis_ContratoAsesoria.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_ContratoAsesorialist.Add(Dis_ContratoAsesoria);
            }
            reader.Close();
            reader.Dispose();
            return Dis_ContratoAsesorialist;
        }

        public Dis_ContratoAsesoriaBE Selecciona(int IdDis_ContratoAsesoria)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoAsesoria_Selecciona");
            db.AddInParameter(dbCommand, "pIdDis_ContratoAsesoria", DbType.Int32, IdDis_ContratoAsesoria);

            IDataReader reader = db.ExecuteReader(dbCommand);
            Dis_ContratoAsesoriaBE Dis_ContratoAsesoria = null;
            while (reader.Read())
            {
                Dis_ContratoAsesoria = new Dis_ContratoAsesoriaBE();
                Dis_ContratoAsesoria.IdDis_ContratoAsesoria = Int32.Parse(reader["IdDis_ContratoAsesoria"].ToString());
                Dis_ContratoAsesoria.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Dis_ContratoAsesoria.RazonSocial = reader["RazonSocial"].ToString();
                Dis_ContratoAsesoria.Descripcion = reader["Descripcion"].ToString();
                Dis_ContratoAsesoria.Titulo = reader["Titulo"].ToString();
                Dis_ContratoAsesoria.CuerpoSustantivo = reader["CuerpoSustantivo"].ToString();
                Dis_ContratoAsesoria.Procedimiento = reader["Procedimiento"].ToString();
                Dis_ContratoAsesoria.PlazoCosto = reader["PlazoCosto"].ToString();
                Dis_ContratoAsesoria.Publicidad = reader["Publicidad"].ToString();
                Dis_ContratoAsesoria.Version = reader["Version"].ToString();
                Dis_ContratoAsesoria.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Dis_ContratoAsesoria.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Dis_ContratoAsesoria;
        }
    }
}
