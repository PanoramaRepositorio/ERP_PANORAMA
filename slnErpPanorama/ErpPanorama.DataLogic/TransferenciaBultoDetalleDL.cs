using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class TransferenciaBultoDetalleDL
    {
        public TransferenciaBultoDetalleDL() { }

        public void Inserta(TransferenciaBultoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TransferenciaBultoDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdTransferenciaBultoDetalle", DbType.Int32, pItem.IdTransferenciaBultoDetalle);
            db.AddInParameter(dbCommand, "pIdTransferenciaBulto", DbType.Int32, pItem.IdTransferenciaBulto);
            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pIdKardexBulto", DbType.Int32, pItem.IdKardexBulto);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(TransferenciaBultoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TransferenciaBultoDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdTransferenciaBultoDetalle", DbType.Int32, pItem.IdTransferenciaBultoDetalle);
            db.AddInParameter(dbCommand, "pIdTransferenciaBulto", DbType.Int32, pItem.IdTransferenciaBulto);
            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pIdKardexBulto", DbType.Int32, pItem.IdKardexBulto);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TransferenciaBultoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TransferenciaBultoDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdTransferenciaBultoDetalle", DbType.Int32, pItem.IdTransferenciaBultoDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<TransferenciaBultoDetalleBE> ListaTodosActivo(int IdEmpresa, int IdTransferenciaBulto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TransferenciaBultoDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTransferenciaBulto", DbType.Int32, IdTransferenciaBulto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TransferenciaBultoDetalleBE> TransferenciaBultoDetallelist = new List<TransferenciaBultoDetalleBE>();
            TransferenciaBultoDetalleBE TransferenciaBultoDetalle;
            while (reader.Read())
            {
                TransferenciaBultoDetalle = new TransferenciaBultoDetalleBE();
                TransferenciaBultoDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                TransferenciaBultoDetalle.IdTransferenciaBultoDetalle = Int32.Parse(reader["idTransferenciaBultoDetalle"].ToString());
                TransferenciaBultoDetalle.IdTransferenciaBulto = Int32.Parse(reader["IdTransferenciaBulto"].ToString());
                TransferenciaBultoDetalle.IdBulto = Int32.Parse(reader["IdBulto"].ToString());
                TransferenciaBultoDetalle.NumeroBulto = reader["NumeroBulto"].ToString();
                TransferenciaBultoDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                TransferenciaBultoDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                TransferenciaBultoDetalle.NombreProducto = reader["NombreProducto"].ToString();
                TransferenciaBultoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                TransferenciaBultoDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                TransferenciaBultoDetalle.IdKardexBulto = Int32.Parse(reader["IdKardexBulto"].ToString());
                TransferenciaBultoDetalle.IdKardex = Int32.Parse(reader["IdKardex"].ToString());
                TransferenciaBultoDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TransferenciaBultoDetalle.TipoOper = 4; //Consultar
                TransferenciaBultoDetallelist.Add(TransferenciaBultoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return TransferenciaBultoDetallelist;
        }
    }
}
