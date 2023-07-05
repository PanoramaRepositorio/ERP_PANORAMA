using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class DsctoMayoristaFamiliaFormaPagoDL
    {
        public DsctoMayoristaFamiliaFormaPagoDL()  { }


        public void Inserta(DsctoMayoristaFamiliaFormaPagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DsctoMayoristaFamiliaFormaPago_Inserta");

            db.AddInParameter(dbCommand, "pIdDsctoMayoristaFamiliaFormaPago", DbType.Int32, pItem.IdDsctoMayoristaFamiliaFormaPago);
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, pItem.IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, pItem.IdFormaPago);
            db.AddInParameter(dbCommand, "pAdicional", DbType.Boolean, pItem.Adicional);
            db.AddInParameter(dbCommand, "pPrecio_Del", DbType.Decimal, pItem.Precio_Del);
            db.AddInParameter(dbCommand, "pPrecio_Al", DbType.Decimal, pItem.Precio_Al);
            db.AddInParameter(dbCommand, "pDsctoTiendaMayorista", DbType.Decimal, pItem.DsctoTiendaMayorista);
            db.AddInParameter(dbCommand, "pIdUsuario", DbType.Int32, pItem.IdUsuario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(DsctoMayoristaFamiliaFormaPagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DsctoMayoristaFamiliaFormaPago_Actualiza");

            db.AddInParameter(dbCommand, "pIdDsctoMayoristaFamiliaFormaPago", DbType.Int32, pItem.IdDsctoMayoristaFamiliaFormaPago);
            db.AddInParameter(dbCommand, "pAdicional", DbType.Boolean, pItem.Adicional);
            db.AddInParameter(dbCommand, "pPrecio_Del", DbType.Decimal, pItem.Precio_Del);
            db.AddInParameter(dbCommand, "pPrecio_Al", DbType.Decimal, pItem.Precio_Al);
            db.AddInParameter(dbCommand, "pDsctoTiendaMayorista", DbType.Decimal, pItem.DsctoTiendaMayorista);
            db.AddInParameter(dbCommand, "pIdUsuario", DbType.Int32, pItem.IdUsuario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(DsctoMayoristaFamiliaFormaPagoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DsctoMayoristaFamiliaFormaPago_Elimina");

            db.AddInParameter(dbCommand, "pIdDsctoMayoristaFamiliaFormaPago", DbType.Int32, pItem.IdDsctoMayoristaFamiliaFormaPago);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<DsctoMayoristaFamiliaFormaPagoBE> ListaTodosActivo(int IdFamiliaProducto, int IdFormaPago)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DsctoMayoristaFamiliaFormaPago_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdFamiliaProducto", DbType.Int32, IdFamiliaProducto);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DsctoMayoristaFamiliaFormaPagoBE> DescuentoClienteMayoristalist = new List<DsctoMayoristaFamiliaFormaPagoBE>();
            DsctoMayoristaFamiliaFormaPagoBE eItem;
            while (reader.Read())
            {
                eItem = new DsctoMayoristaFamiliaFormaPagoBE();
                eItem.IdDsctoMayoristaFamiliaFormaPago = Int32.Parse(reader["IdDsctoMayoristaFamiliaFormaPago"].ToString());
                eItem.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                eItem.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                eItem.IdFormaPago = Int32.Parse(reader["IdFormaPago"].ToString());
                eItem.DescFormaPago = reader["DescFormaPago"].ToString();
                eItem.Precio_Al = Decimal.Parse(reader["Precio_Al"].ToString());
                eItem.Precio_Del = Decimal.Parse(reader["Precio_Del"].ToString());
                eItem.DsctoTiendaMayorista = Decimal.Parse(reader["DsctoTiendaMayorista"].ToString());
                eItem.Adicional = Boolean.Parse(reader["Adicional"].ToString());
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
