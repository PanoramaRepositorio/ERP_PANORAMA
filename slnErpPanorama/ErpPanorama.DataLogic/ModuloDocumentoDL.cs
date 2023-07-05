using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ModuloDocumentoDL
    {
        public ModuloDocumentoDL() { }

        public void Inserta(ModuloDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDocumento_Inserta");

            db.AddInParameter(dbCommand, "pIdModuloDocumento", DbType.Int32, pItem.IdModuloDocumento);
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, pItem.IdModulo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ModuloDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDocumento_Actualiza");

            db.AddInParameter(dbCommand, "pIdModuloDocumento", DbType.Int32, pItem.IdModuloDocumento);
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, pItem.IdModulo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ModuloDocumentoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDocumento_Elimina");

            db.AddInParameter(dbCommand, "pIdModuloDocumento", DbType.Int32, pItem.IdModuloDocumento);
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, pItem.IdModulo);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ModuloDocumentoBE> ListaTodosActivo(int IdModulo, int IdTipoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDocumento_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, IdModulo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ModuloDocumentoBE> ModuloDocumentolist = new List<ModuloDocumentoBE>();
            ModuloDocumentoBE ModuloDocumento;
            while (reader.Read())
            {
                ModuloDocumento = new ModuloDocumentoBE();
                ModuloDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ModuloDocumento.DescTipoDocumento = reader["descTipoDocumento"].ToString();
                ModuloDocumento.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                ModuloDocumento.IdModuloDocumento = Int32.Parse(reader["idModuloDocumento"].ToString());
                ModuloDocumento.IdModulo = Int32.Parse(reader["IdModulo"].ToString());
                ModuloDocumento.DescModulo = reader["descModulo"].ToString();
                ModuloDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ModuloDocumentolist.Add(ModuloDocumento);
            }
            reader.Close();
            reader.Dispose();
            return ModuloDocumentolist;
        }

        public List<ModuloDocumentoBE> ListaNotaIngreso(int IdModulo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDocumento_ListaNotaIngreso");
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, IdModulo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ModuloDocumentoBE> ModuloDocumentolist = new List<ModuloDocumentoBE>();
            ModuloDocumentoBE ModuloDocumento;
            while (reader.Read())
            {
                ModuloDocumento = new ModuloDocumentoBE();
                ModuloDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ModuloDocumento.DescTipoDocumento = reader["descTipoDocumento"].ToString();
                ModuloDocumento.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                ModuloDocumento.IdModuloDocumento = Int32.Parse(reader["idModuloDocumento"].ToString());
                ModuloDocumento.IdModulo = Int32.Parse(reader["IdModulo"].ToString());
                ModuloDocumento.DescModulo = reader["descModulo"].ToString();
                ModuloDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ModuloDocumentolist.Add(ModuloDocumento);
            }
            reader.Close();
            reader.Dispose();
            return ModuloDocumentolist;
        }

        public List<ModuloDocumentoBE> ListaNotaSalida(int IdModulo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDocumento_ListaNotaSalida");
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, IdModulo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ModuloDocumentoBE> ModuloDocumentolist = new List<ModuloDocumentoBE>();
            ModuloDocumentoBE ModuloDocumento;
            while (reader.Read())
            {
                ModuloDocumento = new ModuloDocumentoBE();
                ModuloDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ModuloDocumento.DescTipoDocumento = reader["descTipoDocumento"].ToString();
                ModuloDocumento.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                ModuloDocumento.IdModuloDocumento = Int32.Parse(reader["idModuloDocumento"].ToString());
                ModuloDocumento.IdModulo = Int32.Parse(reader["IdModulo"].ToString());
                ModuloDocumento.DescModulo = reader["descModulo"].ToString();
                ModuloDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ModuloDocumentolist.Add(ModuloDocumento);
            }
            reader.Close();
            reader.Dispose();
            return ModuloDocumentolist;
        }

        public List<ModuloDocumentoBE> ListaVentas(int IdModulo, int IdTipoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDocumento_ListaVenta");
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, IdModulo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ModuloDocumentoBE> ModuloDocumentolist = new List<ModuloDocumentoBE>();
            ModuloDocumentoBE ModuloDocumento;
            while (reader.Read())
            {
                ModuloDocumento = new ModuloDocumentoBE();
                ModuloDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ModuloDocumento.DescTipoDocumento = reader["descTipoDocumento"].ToString();
                ModuloDocumento.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                ModuloDocumento.IdModuloDocumento = Int32.Parse(reader["idModuloDocumento"].ToString());
                ModuloDocumento.IdModulo = Int32.Parse(reader["IdModulo"].ToString());
                ModuloDocumento.DescModulo = reader["descModulo"].ToString();
                ModuloDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ModuloDocumentolist.Add(ModuloDocumento);
            }
            reader.Close();
            reader.Dispose();
            return ModuloDocumentolist;
        }
        public List<ModuloDocumentoBE> ListaVentasNC(int IdModulo, int IdTipoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDocumento_ListaVentaNC");
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, IdModulo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ModuloDocumentoBE> ModuloDocumentolist = new List<ModuloDocumentoBE>();
            ModuloDocumentoBE ModuloDocumento;
            while (reader.Read())
            {
                ModuloDocumento = new ModuloDocumentoBE();
                ModuloDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ModuloDocumento.DescTipoDocumento = reader["descTipoDocumento"].ToString();
                ModuloDocumento.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                ModuloDocumento.IdModuloDocumento = Int32.Parse(reader["idModuloDocumento"].ToString());
                ModuloDocumento.IdModulo = Int32.Parse(reader["IdModulo"].ToString());
                ModuloDocumento.DescModulo = reader["descModulo"].ToString();
                ModuloDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ModuloDocumentolist.Add(ModuloDocumento);
            }
            reader.Close();
            reader.Dispose();
            return ModuloDocumentolist;
        }

        public List<ModuloDocumentoBE> ListaDevolucion(int IdModulo, int IdTipoDocumento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ModuloDocumento_ListaDevolucion");
            db.AddInParameter(dbCommand, "pIdModulo", DbType.Int32, IdModulo);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, IdTipoDocumento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ModuloDocumentoBE> ModuloDocumentolist = new List<ModuloDocumentoBE>();
            ModuloDocumentoBE ModuloDocumento;
            while (reader.Read())
            {
                ModuloDocumento = new ModuloDocumentoBE();
                ModuloDocumento.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                ModuloDocumento.DescTipoDocumento = reader["descTipoDocumento"].ToString();
                ModuloDocumento.CodTipoDocumento = reader["CodTipoDocumento"].ToString();
                ModuloDocumento.IdModuloDocumento = Int32.Parse(reader["idModuloDocumento"].ToString());
                ModuloDocumento.IdModulo = Int32.Parse(reader["IdModulo"].ToString());
                ModuloDocumento.DescModulo = reader["descModulo"].ToString();
                ModuloDocumento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ModuloDocumentolist.Add(ModuloDocumento);
            }
            reader.Close();
            reader.Dispose();
            return ModuloDocumentolist;
        }
    }
}

