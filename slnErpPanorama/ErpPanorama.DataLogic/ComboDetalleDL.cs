using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ComboDetalleDL
    {
        public ComboDetalleDL() { }

        public void Inserta(ComboDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ComboDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdComboDetalle", DbType.Int32, pItem.IdComboDetalle);
            db.AddInParameter(dbCommand, "pIdCombo", DbType.Int32, pItem.IdCombo);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(ComboDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ComboDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdComboDetalle", DbType.Int32, pItem.IdComboDetalle);
            db.AddInParameter(dbCommand, "pIdCombo", DbType.Int32, pItem.IdCombo);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCodigoProveedor", DbType.String, pItem.CodigoProveedor);
            db.AddInParameter(dbCommand, "pNombreProducto", DbType.String, pItem.NombreProducto);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pPrecioVenta", DbType.Decimal, pItem.PrecioVenta);
            db.AddInParameter(dbCommand, "pValorVenta", DbType.Decimal, pItem.ValorVenta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(ComboDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ComboDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdComboDetalle", DbType.Int32, pItem.IdComboDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ComboDetalleBE> ListaTodosActivo(int IdCombo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ComboDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCombo", DbType.Int32, IdCombo);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ComboDetalleBE> ComboDetallelist = new List<ComboDetalleBE>();
            ComboDetalleBE ComboDetalle;
            while (reader.Read())
            {
                ComboDetalle = new ComboDetalleBE();
                ComboDetalle.IdCombo = Int32.Parse(reader["idCombo"].ToString());
                ComboDetalle.IdComboDetalle = Int32.Parse(reader["idComboDetalle"].ToString());
                ComboDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                ComboDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ComboDetalle.NombreProducto = reader["nombreProducto"].ToString();
                ComboDetalle.Abreviatura = reader["Abreviatura"].ToString();
                ComboDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ComboDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                ComboDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                ComboDetalle.PrecioVenta = Decimal.Parse(reader["PrecioVenta"].ToString());
                ComboDetalle.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                ComboDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                ComboDetalle.TipoOper = 4; //Consultar
                ComboDetallelist.Add(ComboDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ComboDetallelist;
        }

        
    }
}
