using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TareoPersonalDL
    {
        public DataTable ObtenerListaTareo(int Periodo, int Mes, int IdPersona, int TipoReporte)
        {
            DataTable dtTmp = new DataTable();

            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Clocking_ListaTareo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            dtTmp.Load(reader);

            reader.Close();
            reader.Dispose();
            return dtTmp;
        }

        public DataTable ObtenerListaTareoCalculado(int Periodo, int Mes, int IdPersona, int TipoReporte)
        {
            DataTable dtTmp = new DataTable();

            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Clocking_ListaTareoCalculado");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pTipoReporte", DbType.Int32, TipoReporte);

            IDataReader reader = db.ExecuteReader(dbCommand);
            dtTmp.Load(reader);
            reader.Close();
            reader.Dispose();

            return dtTmp;
        }
    }
}

//------------------------ ANT. < 130117

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Data.Common;
//using System.Data;
//using System.Data.OleDb;
//using Microsoft.Practices.EnterpriseLibrary.Data;
//using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
//using Microsoft.Practices.EnterpriseLibrary.Common;

//namespace ErpPanorama.DataLogic
//{
//    public class TareoPersonalDL
//    {
//        public DataTable ObtenerListaTareo(int Periodo, int Mes)
//        {
//            DataTable dtTmp = new DataTable();
//            SqlDatabase SqlClient = new SqlDatabase("Data Source=172.16.0.151;Initial Catalog=BD_ERPPanorama;Persist Security Info=True;User ID=sa;Password=pandes2012@");
//            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("usp_Clocking_ListaTareo");

//            SqlClient.AddInParameter(SqlCommand, "@pPeriodo", SqlDbType.Int, Periodo);
//            SqlClient.AddInParameter(SqlCommand, "@pMes", SqlDbType.Int, Mes);
//            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
//            return dtTmp;
//        }

//        public DataTable ObtenerListaTareoCalculado(int Periodo, int Mes)
//        {
//            DataTable dtTmp = new DataTable();
//            SqlDatabase SqlClient = new SqlDatabase("Data Source=172.16.0.151;Initial Catalog=BD_ERPPanorama;Persist Security Info=True;User ID=sa;Password=pandes2012@");
//            DbCommand SqlCommand = SqlClient.GetStoredProcCommand("usp_Clocking_ListaTareoCalculado");

//            SqlClient.AddInParameter(SqlCommand, "@pPeriodo", SqlDbType.Int, Periodo);
//            SqlClient.AddInParameter(SqlCommand, "@pMes", SqlDbType.Int, Mes);
//            dtTmp.Load(SqlClient.ExecuteReader(SqlCommand));
//            return dtTmp;
//        }
//    }
//}

