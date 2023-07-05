using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class EscalaMayoristaPreVentaDL
    {
        public EscalaMayoristaPreVentaDL()  { }


        public void Inserta(EscalaMayoristaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EscalaMayoristaPreVenta_Inserta");

            db.AddInParameter(dbCommand, "pIdEscalaMayoristaPreVenta", DbType.Int32, pItem.IdEscalaMayoristaPreVenta);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pGeneral", DbType.Boolean, pItem.General);
            db.AddInParameter(dbCommand, "pPrecio_Al", DbType.Decimal, pItem.Precio_Al);
            db.AddInParameter(dbCommand, "pPrecio_Del", DbType.Decimal, pItem.Precio_Del);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pIdUsuario", DbType.Int32, pItem.IdUsuario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(EscalaMayoristaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EscalaMayoristaPreVenta_Actualiza");

            db.AddInParameter(dbCommand, "pIdEscalaMayoristaPreVenta", DbType.Int32, pItem.IdEscalaMayoristaPreVenta);
            db.AddInParameter(dbCommand, "pGeneral", DbType.Boolean, pItem.General);
            db.AddInParameter(dbCommand, "pPrecio_Al", DbType.Decimal, pItem.Precio_Al);
            db.AddInParameter(dbCommand, "pPrecio_Del", DbType.Decimal, pItem.Precio_Del);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pIdUsuario", DbType.Int32, pItem.IdUsuario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EscalaMayoristaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EscalaMayoristaPreVenta_Elimina");

            db.AddInParameter(dbCommand, "pIdEscalaMayoristaPreVenta", DbType.Int32, pItem.IdEscalaMayoristaPreVenta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<EscalaMayoristaBE> ListaTodosActivo(int IdFamiliaProducto, int IdFormaPago)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_EscalaMayoristaPreVenta_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EscalaMayoristaBE> DescuentoClienteMayoristalist = new List<EscalaMayoristaBE>();
            EscalaMayoristaBE eItem;
            while (reader.Read())
            {
                eItem = new EscalaMayoristaBE();
                eItem.IdEscalaMayoristaPreVenta = Int32.Parse(reader["IdEscalaMayoristaPreVenta"].ToString());
                eItem.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                eItem.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                eItem.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                eItem.DescFormaPago = reader["DescFormaPago"].ToString();
                eItem.Precio_Al = Decimal.Parse(reader["Precio_Al"].ToString());
                eItem.Precio_Del = Decimal.Parse(reader["Precio_Del"].ToString());
                eItem.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                eItem.General = Boolean.Parse(reader["General"].ToString());
                eItem.IdUsuarioRegistro = Int32.Parse(reader["IdUsuarioRegistro"].ToString());
                eItem.IdUsuarioModificacion = Int32.Parse(reader["IdUsuarioModificacion"].ToString());
                eItem.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                eItem.FechaModificacion = DateTime.Parse(reader["FechaModificacion"].ToString());
                eItem.DescUsuarioRegistro = reader["DescUsuarioReg"].ToString();
                eItem.DescUsuarioModificacion = reader["DescUsuarioMod"].ToString();
                eItem.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescuentoClienteMayoristalist.Add(eItem);
            }
            reader.Close();
            reader.Dispose();
            return DescuentoClienteMayoristalist;
        }

    }
}
