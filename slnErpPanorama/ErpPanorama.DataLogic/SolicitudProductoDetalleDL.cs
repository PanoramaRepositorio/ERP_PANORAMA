using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class SolicitudProductoDetalleDL
    {
        public SolicitudProductoDetalleDL() { }

        public void Inserta(SolicitudProductoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProductoDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdSolicitudProductoDetalle", DbType.Int32, pItem.IdSolicitudProductoDetalle);
            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
            db.AddInParameter(dbCommand, "pMontoTotal", DbType.Decimal, pItem.MontoTotal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(SolicitudProductoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProductoDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdSolicitudProductoDetalle", DbType.Int32, pItem.IdSolicitudProductoDetalle);
            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, pItem.IdSolicitudProducto);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
            db.AddInParameter(dbCommand, "pMontoTotal", DbType.Decimal, pItem.MontoTotal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(SolicitudProductoDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProductoDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdSolicitudProductoDetalle", DbType.Int32, pItem.IdSolicitudProductoDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<SolicitudProductoDetalleBE> ListaTodosActivo(int IdEmpresa, int IdSolicitudProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProductoDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, IdSolicitudProducto);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudProductoDetalleBE> SolicitudProductoDetallelist = new List<SolicitudProductoDetalleBE>();
            SolicitudProductoDetalleBE SolicitudProductoDetalle;
            while (reader.Read())
            {
                SolicitudProductoDetalle = new SolicitudProductoDetalleBE();
                SolicitudProductoDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                SolicitudProductoDetalle.IdSolicitudProducto = Int32.Parse(reader["idSolicitudProducto"].ToString());
                SolicitudProductoDetalle.IdSolicitudProductoDetalle = Int32.Parse(reader["idSolicitudProductoDetalle"].ToString());
                SolicitudProductoDetalle.Item = Int32.Parse(reader["Item"].ToString());
                SolicitudProductoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                SolicitudProductoDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                SolicitudProductoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                SolicitudProductoDetalle.Medida = reader["Medida"].ToString();
                SolicitudProductoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                SolicitudProductoDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudProductoDetalle.Observacion = reader["Observacion"].ToString();
                SolicitudProductoDetalle.DescUbicacion = reader["DescUbicacion"].ToString();
                SolicitudProductoDetalle.CostoUnitario = Decimal.Parse(reader["costoUnitario"].ToString());
                SolicitudProductoDetalle.MontoTotal = Decimal.Parse(reader["montoTotal"].ToString());
                SolicitudProductoDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                SolicitudProductoDetalle.TipoOper = 4; //Consultar
                SolicitudProductoDetallelist.Add(SolicitudProductoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProductoDetallelist;
        }

        public List<SolicitudProductoDetalleBE> ListaTodosImagen(int IdEmpresa, int IdSolicitudProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProductoDetalle_ListaTodosImagen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSolicitudProducto", DbType.Int32, IdSolicitudProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudProductoDetalleBE> SolicitudProductoDetallelist = new List<SolicitudProductoDetalleBE>();
            SolicitudProductoDetalleBE SolicitudProductoDetalle;
            while (reader.Read())
            {
                SolicitudProductoDetalle = new SolicitudProductoDetalleBE();
                SolicitudProductoDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                SolicitudProductoDetalle.IdSolicitudProducto = Int32.Parse(reader["idSolicitudProducto"].ToString());
                SolicitudProductoDetalle.IdSolicitudProductoDetalle = Int32.Parse(reader["idSolicitudProductoDetalle"].ToString());
                SolicitudProductoDetalle.Item = Int32.Parse(reader["Item"].ToString());
                SolicitudProductoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                SolicitudProductoDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                SolicitudProductoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                SolicitudProductoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                SolicitudProductoDetalle.Imagen = (byte[])reader["Imagen"];
                SolicitudProductoDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudProductoDetalle.Observacion = reader["Observacion"].ToString();
                SolicitudProductoDetalle.DescUbicacion = reader["DescUbicacion"].ToString();
                SolicitudProductoDetalle.CostoUnitario = Decimal.Parse(reader["costoUnitario"].ToString());
                SolicitudProductoDetalle.MontoTotal = Decimal.Parse(reader["montoTotal"].ToString());
                SolicitudProductoDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                SolicitudProductoDetalle.TipoOper = 4; //Consultar
                SolicitudProductoDetallelist.Add(SolicitudProductoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProductoDetallelist;
        }

        public List<SolicitudProductoDetalleBE> ListaNumero(int IdEmpresa, int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudProductoDetalle_ListaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudProductoDetalleBE> SolicitudProductoDetallelist = new List<SolicitudProductoDetalleBE>();
            SolicitudProductoDetalleBE SolicitudProductoDetalle;
            while (reader.Read())
            {
                SolicitudProductoDetalle = new SolicitudProductoDetalleBE();
                SolicitudProductoDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                SolicitudProductoDetalle.IdAlmacenOrigen = Int32.Parse(reader["IdAlmacenOrigen"].ToString());
                SolicitudProductoDetalle.IdAlmacenDestino = Int32.Parse(reader["IdAlmacenDestino"].ToString());
                SolicitudProductoDetalle.IdSolicitudProducto = Int32.Parse(reader["idSolicitudProducto"].ToString());
                SolicitudProductoDetalle.IdSolicitudProductoDetalle = Int32.Parse(reader["idSolicitudProductoDetalle"].ToString());
                SolicitudProductoDetalle.Item = Int32.Parse(reader["Item"].ToString());
                SolicitudProductoDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                SolicitudProductoDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                SolicitudProductoDetalle.NombreProducto = reader["nombreProducto"].ToString();
                SolicitudProductoDetalle.Abreviatura = reader["Abreviatura"].ToString();
                SolicitudProductoDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                SolicitudProductoDetalle.Observacion = reader["Observacion"].ToString();
                SolicitudProductoDetalle.CostoUnitario = Decimal.Parse(reader["costoUnitario"].ToString());
                SolicitudProductoDetalle.MontoTotal = Decimal.Parse(reader["montoTotal"].ToString());
                //SolicitudProductoDetalle.IdAuxiliar = Int32.Parse(reader["IdAuxiliar"].ToString());
                SolicitudProductoDetalle.IdAuxiliar = reader.IsDBNull(reader.GetOrdinal("IdAuxiliar")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdAuxiliar"));

                SolicitudProductoDetalle.IdCausalTransferencia = Int32.Parse(reader["IdCausalTransferencia"].ToString());
                SolicitudProductoDetalle.DocReferencia = reader["DocReferencia"].ToString();
                SolicitudProductoDetalle.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());

                SolicitudProductoDetallelist.Add(SolicitudProductoDetalle);
            }
            reader.Close();
            reader.Dispose();
            return SolicitudProductoDetallelist;
        }
    }
}


