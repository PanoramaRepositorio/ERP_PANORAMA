using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AsesoriaDL
    {
        public AsesoriaDL() { }

        public void Inserta(AsesoriaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Asesoria_Inserta");

            db.AddInParameter(dbCommand, "pIdAsesoria", DbType.Int32, pItem.IdAsesoria);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
            db.AddInParameter(dbCommand, "pFechaContrato", DbType.DateTime, pItem.FechaContrato);
            db.AddInParameter(dbCommand, "pFechaVenta", DbType.DateTime, pItem.FechaVenta);
            db.AddInParameter(dbCommand, "pFechaVisita", DbType.DateTime, pItem.FechaVisita);
            db.AddInParameter(dbCommand, "pFechaEntrega", DbType.DateTime, pItem.FechaEntrega);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(AsesoriaBE pItem)
        {
            //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            //DbCommand dbCommand = db.GetStoredProcCommand("usp_Asesoria_Actualiza");

            //db.AddInParameter(dbCommand, "pIdAsesoria", DbType.Int32, pItem.IdAsesoria);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            //db.AddInParameter(dbCommand, "pDescAsesoria", DbType.String, pItem.DescAsesoria);
            //db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            //db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(AsesoriaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Asesoria_Elimina");

            db.AddInParameter(dbCommand, "pIdAsesoria", DbType.Int32, pItem.IdAsesoria);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<AsesoriaBE> ListaTodosActivo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Asesoria_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AsesoriaBE> Asesorialist = new List<AsesoriaBE>();
            AsesoriaBE Asesoria;
            while (reader.Read())
            {
                Asesoria = new AsesoriaBE();
                Asesoria.IdAsesoria = reader.IsDBNull(reader.GetOrdinal("IdAsesoria")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdAsesoria"));
                Asesoria.IdPedido = reader.IsDBNull(reader.GetOrdinal("IdPedido")) ? (Int32?)null : reader.GetInt32(reader.GetOrdinal("IdPedido"));
                Asesoria.Fecha = reader.IsDBNull(reader.GetOrdinal("Fecha")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha"));
                Asesoria.Numero = reader["Numero"].ToString();
                Asesoria.DescTienda = reader["DescTienda"].ToString();
                Asesoria.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Asesoria.DescCliente = reader["DescCliente"].ToString();
                Asesoria.ApeNom = reader["ApeNom"].ToString();
                Asesoria.IdAsesor = Int32.Parse(reader["IdAsesor"].ToString());
                Asesoria.DescAsesor = reader["DescAsesor"].ToString();
                Asesoria.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Asesoria.Situacion = reader["Situacion"].ToString();
                Asesoria.CodMoneda = reader["CodMoneda"].ToString();
                Asesoria.Total = Decimal.Parse(reader["Total"].ToString());
                Asesoria.FormaPago = reader["FormaPago"].ToString();
                Asesoria.FechaContrato = reader.IsDBNull(reader.GetOrdinal("FechaContrato")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaContrato"));
                Asesoria.FechaVenta = reader.IsDBNull(reader.GetOrdinal("FechaVenta")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVenta"));
                Asesoria.FechaVisita = reader.IsDBNull(reader.GetOrdinal("FechaVisita")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVisita"));
                Asesoria.FechaEntrega = reader.IsDBNull(reader.GetOrdinal("FechaEntrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEntrega"));
                Asesoria.Observacion = reader["Observacion"].ToString();
                Asesoria.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                Asesorialist.Add(Asesoria);
            }
            reader.Close();
            reader.Dispose();
            return Asesorialist;
        }

        public void ActualizaFecha(AsesoriaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Asesoria_ActualizaFecha");

            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, pItem.IdPedido);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
            db.AddInParameter(dbCommand, "pFechaContrato", DbType.DateTime, pItem.FechaContrato);
            db.AddInParameter(dbCommand, "pFechaVenta", DbType.DateTime, pItem.FechaVenta);
            db.AddInParameter(dbCommand, "pFechaVisita", DbType.DateTime, pItem.FechaVisita);
            db.AddInParameter(dbCommand, "pFechaEntrega", DbType.DateTime, pItem.FechaEntrega);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaVinculoPedido(int IdAsesoria, int IdPedido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Asesoria_ActualizaVinculoPedido");

            db.AddInParameter(dbCommand, "pIdAsesoria", DbType.Int32, IdAsesoria);
            db.AddInParameter(dbCommand, "pIdPedido", DbType.Int32, IdPedido);

            db.ExecuteNonQuery(dbCommand);

        }

    }
}
