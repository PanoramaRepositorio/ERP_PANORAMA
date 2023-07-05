using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TipoDocumentoDL
    {
        public TipoDocumentoDL() { }

        public void Inserta(TipoDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDocumento_Inserta");

            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pCodTipoDocumento", DbType.String, pItem.CodTipoDocumento);
            db.AddInParameter(dbCommand, "pDescTipoDocumento", DbType.String, pItem.DescTipoDocumento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TipoDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDocumento_Actualiza");

            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pCodTipoDocumento", DbType.String, pItem.CodTipoDocumento);
            db.AddInParameter(dbCommand, "pDescTipoDocumento", DbType.String, pItem.DescTipoDocumento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TipoDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDocumento_Elimina");

            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TipoDocumentoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TipoDocumento_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TipoDocumentoBE> TipoDocumentolist = new List<TipoDocumentoBE>();
            TipoDocumentoBE TipoDocumento;
            while (reader.Read())
            {
                TipoDocumento = new TipoDocumentoBE();
                TipoDocumento.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TipoDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                TipoDocumento.CodTipoDocumento = reader["codTipoDocumento"].ToString();
                TipoDocumento.DescTipoDocumento = reader["descTipoDocumento"].ToString();
                TipoDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TipoDocumentolist.Add(TipoDocumento);
            }
            reader.Close();
            reader.Dispose();
            return TipoDocumentolist;
        }
    }
}
