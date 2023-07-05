using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DescuentoClienteFinalDL
    {
        public DescuentoClienteFinalDL() { }

        public void Inserta(DescuentoClienteFinalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteFinal_Inserta");

            db.AddInParameter(dbCommand, "pIdDescuentoClienteFinal", DbType.Int32, pItem.IdDescuentoClienteFinal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdClasificacionCliente", DbType.Int32, pItem.IdClasificacionCliente);
            db.AddInParameter(dbCommand, "pCantidadMinima", DbType.Int32, pItem.CantidadMinima);
            db.AddInParameter(dbCommand, "pCantidadMaxima", DbType.Int32, pItem.CantidadMaxima);
            db.AddInParameter(dbCommand, "pIdTipoPrecio", DbType.Int32, pItem.IdTipoPrecio);
            db.AddInParameter(dbCommand, "pPorDescuento", DbType.Int32, pItem.PorDescuento);
            db.AddInParameter(dbCommand, "pFlagOpcional", DbType.Boolean, pItem.FlagOpcional);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            
            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(DescuentoClienteFinalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteFinal_Actualiza");

            db.AddInParameter(dbCommand, "pIdDescuentoClienteFinal", DbType.Int32, pItem.IdDescuentoClienteFinal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdClasificacionCliente", DbType.Int32, pItem.IdClasificacionCliente);
            db.AddInParameter(dbCommand, "pCantidadMinima", DbType.Int32, pItem.CantidadMinima);
            db.AddInParameter(dbCommand, "pCantidadMaxima", DbType.Int32, pItem.CantidadMaxima);
            db.AddInParameter(dbCommand, "pIdTipoPrecio", DbType.Int32, pItem.IdTipoPrecio);
            db.AddInParameter(dbCommand, "pPorDescuento", DbType.Int32, pItem.PorDescuento);
            db.AddInParameter(dbCommand, "pFlagOpcional", DbType.Boolean, pItem.FlagOpcional);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(DescuentoClienteFinalBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteFinal_Elimina");

            db.AddInParameter(dbCommand, "pIdDescuentoClienteFinal", DbType.Int32, pItem.IdDescuentoClienteFinal);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DescuentoClienteFinalBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescuentoClienteFinal_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescuentoClienteFinalBE> DescuentoClienteFinallist = new List<DescuentoClienteFinalBE>();
            DescuentoClienteFinalBE DescuentoClienteFinal;
            while (reader.Read())
            {
                DescuentoClienteFinal = new DescuentoClienteFinalBE();
                DescuentoClienteFinal.IdDescuentoClienteFinal = Int32.Parse(reader["idDescuentoClienteFinal"].ToString());
                DescuentoClienteFinal.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                DescuentoClienteFinal.IdClasificacionCliente = Int32.Parse(reader["IdClasificacionCliente"].ToString());
                DescuentoClienteFinal.DescClasificacionCliente = reader["DescClasificacionCliente"].ToString();
                DescuentoClienteFinal.CantidadMinima = Int32.Parse(reader["CantidadMinima"].ToString());
                DescuentoClienteFinal.CantidadMaxima = Int32.Parse(reader["CantidadMaxima"].ToString());
                DescuentoClienteFinal.IdTipoPrecio = Int32.Parse(reader["IdTipoPrecio"].ToString());
                DescuentoClienteFinal.DescTipoPrecio = reader["DescTipoPrecio"].ToString();
                DescuentoClienteFinal.PorDescuento = Int32.Parse(reader["PorDescuento"].ToString());
                DescuentoClienteFinal.FlagOpcional = Boolean.Parse(reader["FlagOpcional"].ToString());
                DescuentoClienteFinal.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescuentoClienteFinallist.Add(DescuentoClienteFinal);
            }
            reader.Close();
            reader.Dispose();
            return DescuentoClienteFinallist;
        }
    }
}
