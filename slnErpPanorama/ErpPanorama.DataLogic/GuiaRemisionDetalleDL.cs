using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class GuiaRemisionDetalleDL
    {
        public GuiaRemisionDetalleDL() { }

        public void Inserta(GuiaRemisionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemisionDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdGuiaRemisionDetalle", DbType.Int32, pItem.IdGuiaRemisionDetalle);
            db.AddInParameter(dbCommand, "pIdGuiaRemision", DbType.Int32, pItem.IdGuiaRemision);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
            db.AddInParameter(dbCommand, "pMontoTotal", DbType.Decimal, pItem.MontoTotal);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(GuiaRemisionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemisionDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdGuiaRemisionDetalle", DbType.Int32, pItem.IdGuiaRemisionDetalle);
            db.AddInParameter(dbCommand, "pIdGuiaRemision", DbType.Int32, pItem.IdGuiaRemision);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
            db.AddInParameter(dbCommand, "pMontoTotal", DbType.Decimal, pItem.MontoTotal);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(GuiaRemisionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemisionDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdGuiaRemisionDetalle", DbType.Int32, pItem.IdGuiaRemisionDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<GuiaRemisionDetalleBE> ListaTodosActivo(int IdEmpresa, int IdGuiaRemision)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemisionDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdGuiaRemision", DbType.Int32, IdGuiaRemision);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<GuiaRemisionDetalleBE> GuiaRemisionDetallelist = new List<GuiaRemisionDetalleBE>();
            GuiaRemisionDetalleBE GuiaRemisionDetalle;
            while (reader.Read())
            {
                GuiaRemisionDetalle = new GuiaRemisionDetalleBE();
                GuiaRemisionDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                GuiaRemisionDetalle.IdGuiaRemision = Int32.Parse(reader["idGuiaRemision"].ToString());
                GuiaRemisionDetalle.IdGuiaRemisionDetalle = Int32.Parse(reader["idGuiaRemisionDetalle"].ToString());
                GuiaRemisionDetalle.Item = Int32.Parse(reader["Item"].ToString());
                GuiaRemisionDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                GuiaRemisionDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                GuiaRemisionDetalle.NombreProducto = reader["nombreProducto"].ToString();
                GuiaRemisionDetalle.Abreviatura = reader["Abreviatura"].ToString();
                GuiaRemisionDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                GuiaRemisionDetalle.CostoUnitario = Decimal.Parse(reader["costoUnitario"].ToString());
                GuiaRemisionDetalle.MontoTotal = Decimal.Parse(reader["montoTotal"].ToString());
                GuiaRemisionDetalle.IdKardex = Int32.Parse(reader["IdKardex"].ToString());
                GuiaRemisionDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                GuiaRemisionDetalle.TipoOper = 4; //Consultar
                GuiaRemisionDetallelist.Add(GuiaRemisionDetalle);
            }
            reader.Close();
            reader.Dispose();
            return GuiaRemisionDetallelist;
        }

        public List<GuiaRemisionDetalleBE> ListaNumero(int IdEmpresa, int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_GuiaRemisionDetalle_ListaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<GuiaRemisionDetalleBE> GuiaRemisionDetallelist = new List<GuiaRemisionDetalleBE>();
            GuiaRemisionDetalleBE GuiaRemisionDetalle;
            while (reader.Read())
            {
                GuiaRemisionDetalle = new GuiaRemisionDetalleBE();
                GuiaRemisionDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                GuiaRemisionDetalle.IdGuiaRemision = Int32.Parse(reader["idGuiaRemision"].ToString());
                GuiaRemisionDetalle.IdGuiaRemisionDetalle = Int32.Parse(reader["idGuiaRemisionDetalle"].ToString());
                GuiaRemisionDetalle.Item = Int32.Parse(reader["Item"].ToString());
                GuiaRemisionDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                GuiaRemisionDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                GuiaRemisionDetalle.NombreProducto = reader["nombreProducto"].ToString();
                GuiaRemisionDetalle.Abreviatura = reader["Abreviatura"].ToString();
                GuiaRemisionDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                GuiaRemisionDetalle.CostoUnitario = Decimal.Parse(reader["costoUnitario"].ToString());
                GuiaRemisionDetalle.MontoTotal = Decimal.Parse(reader["montoTotal"].ToString());
                GuiaRemisionDetallelist.Add(GuiaRemisionDetalle);
            }
            reader.Close();
            reader.Dispose();
            return GuiaRemisionDetallelist;
        }
    }
}
