using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DocumentoBultoDL
    {
        public DocumentoBultoDL() { }

        public void Inserta(DocumentoBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoBulto_Inserta");

            db.AddInParameter(dbCommand, "pIdDocumentoBulto", DbType.Int32, pItem.IdDocumentoBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(DocumentoBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoBulto_Actualiza");

            db.AddInParameter(dbCommand, "pIdDocumentoBulto", DbType.Int32, pItem.IdDocumentoBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(DocumentoBultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoBulto_Elimina");

            db.AddInParameter(dbCommand, "pIdDocumentoBulto", DbType.Int32, pItem.IdDocumentoBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DocumentoBultoBE> ListaTodosActivo(int IdEmpresa, int Periodo, int IdTipoDocumento, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DocumentoBulto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DocumentoBultoBE> DocumentoBultolist = new List<DocumentoBultoBE>();
            DocumentoBultoBE DocumentoBulto;
            while (reader.Read())
            {
                DocumentoBulto = new DocumentoBultoBE();
                DocumentoBulto.IdDocumentoBulto = Int32.Parse(reader["idDocumentoBulto"].ToString());
                DocumentoBulto.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DocumentoBulto.Periodo = Int32.Parse(reader["periodo"].ToString());
                DocumentoBulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                DocumentoBulto.Numero = reader["Numero"].ToString();
                DocumentoBulto.DescSector = reader["DescSector"].ToString();
                DocumentoBulto.DescBloque = reader["DescBloque"].ToString();
                DocumentoBulto.IdBulto = Int32.Parse(reader["IdBulto"].ToString());
                DocumentoBulto.NumeroBulto = reader["NumeroBulto"].ToString();
                DocumentoBulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                DocumentoBulto.NombreProducto = reader["NombreProducto"].ToString();
                DocumentoBulto.Abreviatura = reader["Abreviatura"].ToString();
                DocumentoBulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                DocumentoBulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DocumentoBultolist.Add(DocumentoBulto);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoBultolist;
        }
    }
}
