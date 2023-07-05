using ErpPanorama.BusinessEntity;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpPanorama.DataLogic
{
    public class TipificacionesDL
    {
        public List<TipificacionesBE> Listar(string Buscartipificacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_Tipificaciones_Listar");
            db.AddInParameter(dbCommand, "pBuscar", DbType.String, Buscartipificacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipificacionesBE> Tablalist = new List<TipificacionesBE>();
            TipificacionesBE Tabla;
            while (reader.Read())
            {
                Tabla = new TipificacionesBE();
                Tabla.IdTipificacion = Int32.Parse(reader["IdTipificacion"].ToString());
                Tabla.CodTipificacion = reader["CodTipificacion"].ToString();
                Tabla.DescTipificacion = reader["DescTipificacion"].ToString();
                Tabla.IdTabla = Int32.Parse(reader["IdTabla"].ToString());
                Tabla.IdTablaElemento = Int32.Parse(reader["IdTablaElemento"].ToString());
                Tabla.DescTipoGestion = reader["DescTipoGestion"].ToString();                
                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }

        public List<TipificacionesBE> ListarPorTipoGestion(string pIdTipoGestion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_Tipificaciones_ListarPorTipoGestion");
            db.AddInParameter(dbCommand, "pIdTipoGestion", DbType.Int32, pIdTipoGestion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipificacionesBE> Tablalist = new List<TipificacionesBE>();
            TipificacionesBE Tabla;
            while (reader.Read())
            {
                Tabla = new TipificacionesBE();
                Tabla.IdTipificacion = Int32.Parse(reader["IdTipificacion"].ToString());
                Tabla.CodTipificacion = reader["CodTipificacion"].ToString();
                Tabla.DescTipificacion = reader["DescTipificacion"].ToString();
                Tabla.IdTabla = Int32.Parse(reader["IdTabla"].ToString());
                Tabla.IdTablaElemento = Int32.Parse(reader["IdTablaElemento"].ToString());
                Tabla.DescTipoGestion = reader["DescTipoGestion"].ToString();
                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }

        public List<TipificacionesBE> ListarIdTipificacion(int pIdTipificacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_Tipificaciones_ListarIdTipificacion");
            db.AddInParameter(dbCommand, "pIdTipificacion", DbType.Int32, pIdTipificacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipificacionesBE> Tablalist = new List<TipificacionesBE>();
            TipificacionesBE Tabla;
            while (reader.Read())
            {
                Tabla = new TipificacionesBE();
                Tabla.IdTabla = Int32.Parse(reader["IdTabla"].ToString());
                Tabla.IdTablaElemento = Int32.Parse(reader["IdTablaElemento"].ToString());
                Tabla.DescTablaElemento = reader["DescTablaElemento"].ToString();
                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }

        public void Inserta(TipificacionesBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_Tipificaciones_Insertar");

            db.AddInParameter(dbCommand, "pDescTipificaciones", DbType.String, pItem.DescTipificacion);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, pItem.IdTabla);
            db.AddInParameter(dbCommand, "pIdTablaElemento", DbType.Int32, pItem.IdTablaElemento);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TipificacionesBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_Actualiza");

            db.AddInParameter(dbCommand, "pIdTablaElemento", DbType.Int32, pItem.IdTablaElemento);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, pItem.IdTabla);
            //db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            //db.AddInParameter(dbCommand, "pDescTablaElemento", DbType.String, pItem.DescTablaElemento);
            //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

    }
}
