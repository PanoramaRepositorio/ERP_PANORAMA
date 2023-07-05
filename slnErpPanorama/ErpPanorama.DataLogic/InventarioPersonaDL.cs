using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class InventarioPersonaDL
    {
        public InventarioPersonaDL() { }

        //public void Inserta(InventarioPersonaBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioPersona_Inserta");

        //    db.AddInParameter(dbCommand, "pIdInventarioPersona", DbType.Int32, pItem.IdInventarioPersona);
        //    db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
        //    db.AddInParameter(dbCommand, "pDescInventarioPersona", DbType.String, pItem.DescInventarioPersona);
        //    db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
        //    db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
        //    db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
        //    db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
        //    db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
        //    db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
        //    db.AddInParameter(dbCommand, "pPaginaWeb", DbType.String, pItem.PaginaWeb);
        //    db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
        //    db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public void Actualiza(InventarioPersonaBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioPersona_Actualiza");

        //    db.AddInParameter(dbCommand, "pIdInventarioPersona", DbType.Int32, pItem.IdInventarioPersona);
        //    db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
        //    db.AddInParameter(dbCommand, "pDescInventarioPersona", DbType.String, pItem.DescInventarioPersona);
        //    db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
        //    db.AddInParameter(dbCommand, "pIdUbigeo", DbType.String, pItem.IdUbigeo);
        //    db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
        //    db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
        //    db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
        //    db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
        //    db.AddInParameter(dbCommand, "pPaginaWeb", DbType.String, pItem.PaginaWeb);
        //    db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
        //    db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public void Elimina(InventarioPersonaBE pItem)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioPersona_Elimina");

        //    db.AddInParameter(dbCommand, "pIdInventarioPersona", DbType.Int32, pItem.IdInventarioPersona);
        //    db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
        //    db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

        //    db.ExecuteNonQuery(dbCommand);
        //}

        //public List<InventarioPersonaBE> ListaTodosActivo()
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioPersona_ListaTodosActivo");
        //    //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
        //    //db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    List<InventarioPersonaBE> InventarioPersonalist = new List<InventarioPersonaBE>();
        //    InventarioPersonaBE InventarioPersona;
        //    while (reader.Read())
        //    {
        //        InventarioPersona = new InventarioPersonaBE();
        //        InventarioPersona.IdInventarioPersona = Int32.Parse(reader["IdInventarioPersona"].ToString());
        //        InventarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
        //        InventarioPersona.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
        //        InventarioPersona.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
        //        InventarioPersonalist.Add(InventarioPersona);
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return InventarioPersonalist;
        //}

        public InventarioPersonaBE Selecciona(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_InventarioPersona_Selecciona");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            InventarioPersonaBE InventarioPersona = null;
            while (reader.Read())
            {
                InventarioPersona = new InventarioPersonaBE();
                InventarioPersona.IdInventarioPersona = Int32.Parse(reader["IdInventarioPersona"].ToString());
                InventarioPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                InventarioPersona.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                InventarioPersona.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return InventarioPersona;
        }
    }
}
