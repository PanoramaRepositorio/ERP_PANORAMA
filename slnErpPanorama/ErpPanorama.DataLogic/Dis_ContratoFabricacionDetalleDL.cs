using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_ContratoFabricacionDetalleDL
    {
        public void Inserta(Dis_ContratoFabricacionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacionDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacionDetalle", DbType.Int32, pItem.IdDis_ContratoFabricacionDetalle);
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, pItem.IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pModelo", DbType.String, pItem.Modelo);
            db.AddInParameter(dbCommand, "pMedida", DbType.String, pItem.Medida);
            db.AddInParameter(dbCommand, "pMaterial", DbType.String, pItem.Material);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);
            db.AddInParameter(dbCommand, "pFlagObsequio", DbType.Boolean, pItem.FlagObsequio);
            db.AddInParameter(dbCommand, "pFlagModificado", DbType.Boolean, pItem.FlagModificado);
            db.AddInParameter(dbCommand, "pFlagAprobado", DbType.Boolean, pItem.FlagAprobado);
            db.AddInParameter(dbCommand, "pDiasProduccion", DbType.Int32, pItem.DiasProduccion);
            db.AddInParameter(dbCommand, "pFechaEntrega", DbType.DateTime, pItem.FechaEntrega);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(Dis_ContratoFabricacionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacionDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacionDetalle", DbType.Int32, pItem.IdDis_ContratoFabricacionDetalle);
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, pItem.IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pModelo", DbType.String, pItem.Modelo);
            db.AddInParameter(dbCommand, "pMedida", DbType.String, pItem.Medida);
            db.AddInParameter(dbCommand, "pMaterial", DbType.String, pItem.Material);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pImagen", DbType.Binary, pItem.Imagen);
            db.AddInParameter(dbCommand, "pFlagObsequio", DbType.Boolean, pItem.FlagObsequio);
            db.AddInParameter(dbCommand, "pFlagModificado", DbType.Boolean, pItem.FlagModificado);
            db.AddInParameter(dbCommand, "pFlagAprobado", DbType.Boolean, pItem.FlagAprobado);
            db.AddInParameter(dbCommand, "pDiasProduccion", DbType.Int32, pItem.DiasProduccion);
            db.AddInParameter(dbCommand, "pFechaEntrega", DbType.DateTime, pItem.FechaEntrega);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_ContratoFabricacionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacionDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacionDetalle", DbType.Int32, pItem.IdDis_ContratoFabricacionDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_ContratoFabricacionDetalleBE> ListaTodosActivo(int IdDis_ContratoFabricacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacionDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, IdDis_ContratoFabricacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_ContratoFabricacionDetalleBE> Dis_ContratoFabricacionDetallelist = new List<Dis_ContratoFabricacionDetalleBE>();
            Dis_ContratoFabricacionDetalleBE Dis_ContratoFabricacionDetalle;
            while (reader.Read())
            {
                Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBE();
                Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacionDetalle = Int32.Parse(reader["IdDis_ContratoFabricacionDetalle"].ToString());
                Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacion = Int32.Parse(reader["IdDis_ContratoFabricacion"].ToString());
                Dis_ContratoFabricacionDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Dis_ContratoFabricacionDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Dis_ContratoFabricacionDetalle.NombreProducto = reader["NombreProducto"].ToString();
                Dis_ContratoFabricacionDetalle.Abreviatura = reader["Abreviatura"].ToString();
                Dis_ContratoFabricacionDetalle.Modelo = reader["Modelo"].ToString();
                Dis_ContratoFabricacionDetalle.Medida = reader["Medida"].ToString();
                Dis_ContratoFabricacionDetalle.Material = reader["Material"].ToString();
                Dis_ContratoFabricacionDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Dis_ContratoFabricacionDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                Dis_ContratoFabricacionDetalle.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                Dis_ContratoFabricacionDetalle.Imagen = (byte[])reader["Imagen"];
                Dis_ContratoFabricacionDetalle.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Dis_ContratoFabricacionDetalle.FlagModificado = Boolean.Parse(reader["FlagModificado"].ToString());
                Dis_ContratoFabricacionDetalle.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Dis_ContratoFabricacionDetalle.DiasProduccion = Int32.Parse(reader["DiasProduccion"].ToString());
                Dis_ContratoFabricacionDetalle.FechaEntrega = reader.IsDBNull(reader.GetOrdinal("FechaEntrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEntrega"));
                Dis_ContratoFabricacionDetalle.Observacion = reader["Observacion"].ToString();
                Dis_ContratoFabricacionDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_ContratoFabricacionDetalle.TipoOper = 4; //Consultar
                Dis_ContratoFabricacionDetallelist.Add(Dis_ContratoFabricacionDetalle);
            }
            reader.Close();
            reader.Dispose();
            return Dis_ContratoFabricacionDetallelist;
        }

        public List<Dis_ContratoFabricacionDetalleBE> ListaSinFoto(int IdDis_ContratoFabricacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacionDetalle_ListaSinFoto");
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, IdDis_ContratoFabricacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_ContratoFabricacionDetalleBE> Dis_ContratoFabricacionDetallelist = new List<Dis_ContratoFabricacionDetalleBE>();
            Dis_ContratoFabricacionDetalleBE Dis_ContratoFabricacionDetalle;
            while (reader.Read())
            {
                Dis_ContratoFabricacionDetalle = new Dis_ContratoFabricacionDetalleBE();
                Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacionDetalle = Int32.Parse(reader["IdDis_ContratoFabricacionDetalle"].ToString());
                Dis_ContratoFabricacionDetalle.IdDis_ContratoFabricacion = Int32.Parse(reader["IdDis_ContratoFabricacion"].ToString());
                Dis_ContratoFabricacionDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Dis_ContratoFabricacionDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Dis_ContratoFabricacionDetalle.NombreProducto = reader["NombreProducto"].ToString();
                Dis_ContratoFabricacionDetalle.Abreviatura = reader["Abreviatura"].ToString();
                Dis_ContratoFabricacionDetalle.Modelo = reader["Modelo"].ToString();
                Dis_ContratoFabricacionDetalle.Medida = reader["Medida"].ToString();
                Dis_ContratoFabricacionDetalle.Material = reader["Material"].ToString();
                Dis_ContratoFabricacionDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Dis_ContratoFabricacionDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                Dis_ContratoFabricacionDetalle.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                Dis_ContratoFabricacionDetalle.FlagObsequio = Boolean.Parse(reader["FlagObsequio"].ToString());
                Dis_ContratoFabricacionDetalle.FlagModificado = Boolean.Parse(reader["FlagModificado"].ToString());
                Dis_ContratoFabricacionDetalle.FlagAprobado = Boolean.Parse(reader["FlagAprobado"].ToString());
                Dis_ContratoFabricacionDetalle.DiasProduccion = Int32.Parse(reader["DiasProduccion"].ToString());
                Dis_ContratoFabricacionDetalle.FechaEntrega = reader.IsDBNull(reader.GetOrdinal("FechaEntrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEntrega"));
                Dis_ContratoFabricacionDetalle.Observacion = reader["Observacion"].ToString();
                Dis_ContratoFabricacionDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_ContratoFabricacionDetalle.TipoOper = 4; //Consultar
                Dis_ContratoFabricacionDetallelist.Add(Dis_ContratoFabricacionDetalle);
            }
            reader.Close();
            reader.Dispose();
            return Dis_ContratoFabricacionDetallelist;
        }



    }
}
