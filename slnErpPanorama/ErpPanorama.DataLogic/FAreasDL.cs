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
    public class FAreasDL
    {
        public List<FAreasBE> Listar(string pBuscar)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_Areas_Listar");
            db.AddInParameter(dbCommand, "pBuscar", DbType.String, pBuscar);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FAreasBE> Tablalist = new List<FAreasBE>();
            FAreasBE Tabla;
            while (reader.Read())
            {
                Tabla = new FAreasBE();
                Tabla.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Tabla.DescArea = reader["DescArea"].ToString();
                Tabla.IdTablaUnidadNegocio = Int32.Parse(reader["IdTablaUnidadNegocio"].ToString());
                Tabla.IdTablaElementoUnidadNegocio = Int32.Parse(reader["IdTablaElementoUnidadNegocio"].ToString());
                Tabla.DescUnidadNegocio = reader["DescUnidadNegocio"].ToString();
                Tabla.IdTablaCentroCosto = Int32.Parse(reader["IdTablaCentroCosto"].ToString());
                Tabla.IdTablaElementoCentroCosto = Int32.Parse(reader["IdTablaElementoCentroCosto"].ToString());
                Tabla.DescCentroCosto = reader["DescCentroCosto"].ToString();
                Tablalist.Add(Tabla);
            }
            reader.Close();
            reader.Dispose();
            return Tablalist;
        }

        public void Inserta(FAreasBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AF_Areas_Insertar");

            db.AddInParameter(dbCommand, "pDescArea", DbType.String, pItem.DescArea);
            db.AddInParameter(dbCommand, "pIdTablaUnidadNegocio", DbType.Int32, pItem.IdTablaUnidadNegocio);
            db.AddInParameter(dbCommand, "pIdTablaElementoUnidadNegocio", DbType.Int32, pItem.IdTablaElementoUnidadNegocio);
            db.AddInParameter(dbCommand, "pIdTablaCentroCosto", DbType.Int32, pItem.IdTablaCentroCosto);
            db.AddInParameter(dbCommand, "pIdTablaElementoCentroCosto", DbType.Int32, pItem.IdTablaElementoCentroCosto);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(FAreasBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_Actualiza");

            //db.AddInParameter(dbCommand, "pIdTablaElemento", DbType.Int32, pItem.IdTablaElemento);
            //db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, pItem.IdTabla);
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
