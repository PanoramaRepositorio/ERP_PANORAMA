using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class FacturaCompraDetalleDL
    {
        public FacturaCompraDetalleDL() { }

        public void Inserta(FacturaCompraDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdFacturaCompraDetalle", DbType.Int32, pItem.IdFacturaCompraDetalle);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNumeroBultos", DbType.Int32, pItem.NumeroBultos);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(FacturaCompraDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdFacturaCompraDetalle", DbType.Int32, pItem.IdFacturaCompraDetalle);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNumeroBultos", DbType.Int32, pItem.NumeroBultos);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pSubTotal", DbType.Decimal, pItem.SubTotal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(FacturaCompraDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdFacturaCompraDetalle", DbType.Int32, pItem.IdFacturaCompraDetalle);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<FacturaCompraDetalleBE> ListaTodosActivo(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraDetalleBE> FacturaCompraDetallelist = new List<FacturaCompraDetalleBE>();
            FacturaCompraDetalleBE FacturaCompraDetalle;
            while (reader.Read())
            {
                FacturaCompraDetalle = new FacturaCompraDetalleBE();
                FacturaCompraDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FacturaCompraDetalle.IdFacturaCompraDetalle = Int32.Parse(reader["idFacturaCompraDetalle"].ToString());
                FacturaCompraDetalle.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                FacturaCompraDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                FacturaCompraDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                FacturaCompraDetalle.NombreProducto = reader["NombreProducto"].ToString();
                FacturaCompraDetalle.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                FacturaCompraDetalle.Abreviatura = reader["Abreviatura"].ToString();
                FacturaCompraDetalle.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
                FacturaCompraDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompraDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                FacturaCompraDetalle.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                FacturaCompraDetalle.CantidadVenta = Int32.Parse(reader["CantidadVenta"].ToString());
                FacturaCompraDetalle.ImporteVenta = Decimal.Parse(reader["ImporteVenta"].ToString());
                FacturaCompraDetalle.Imagen = null;
                //FacturaCompraDetalle.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                //FacturaCompraDetalle.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                //FacturaCompraDetalle.AlmacenAndahuaylas = Int32.Parse(reader["AlmacenAndahuaylas"].ToString());
                //FacturaCompraDetalle.AlmacenOutlet = Int32.Parse(reader["AlmacenOutlet"].ToString());
                //FacturaCompraDetalle.AlmacenPrescott = Int32.Parse(reader["AlmacenPrescott"].ToString());
                //FacturaCompraDetalle.AlmacenAviacion = Int32.Parse(reader["AlmacenAviacion"].ToString());
                //FacturaCompraDetalle.AlmacenMegaPlaza = Int32.Parse(reader["AlmacenMegaPlaza"].ToString());
                //FacturaCompraDetalle.TotalStock = Int32.Parse(reader["TotalStock"].ToString());
                //FacturaCompraDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                FacturaCompraDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FacturaCompraDetalle.TipoOper = 4; //Consultar

                FacturaCompraDetalle.GastosAduanasC = Decimal.Parse(reader["GastosAduanas"].ToString());
                FacturaCompraDetalle.FleteC = Decimal.Parse(reader["Flete"].ToString());
                FacturaCompraDetalle.AdvaloremC = Decimal.Parse(reader["Advalorem"].ToString());
                FacturaCompraDetalle.DesestibaC = Decimal.Parse(reader["Desestiba"].ToString());
                FacturaCompraDetalle.SobreEstadiaC = Decimal.Parse(reader["SobreEstadia"].ToString());
                FacturaCompraDetalle.TotalC = Decimal.Parse(reader["Total"].ToString());
                FacturaCompraDetalle.PUnitarioC = Decimal.Parse(reader["PUnitario"].ToString());
                FacturaCompraDetalle.PesosC = Decimal.Parse(reader["Pesos"].ToString());

                FacturaCompraDetalle.Ipm = Decimal.Parse(reader["Ipm"].ToString());
                FacturaCompraDetalle.Igv = Decimal.Parse(reader["Igv"].ToString());
                FacturaCompraDetalle.Percepcion = Decimal.Parse(reader["Percepcion"].ToString());

                FacturaCompraDetallelist.Add(FacturaCompraDetalle);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompraDetallelist;
        }

        public List<FacturaCompraDetalleBE> ListaTodosImagen(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraDetalle_ListaTodosImagen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraDetalleBE> FacturaCompraDetallelist = new List<FacturaCompraDetalleBE>();
            FacturaCompraDetalleBE FacturaCompraDetalle;
            while (reader.Read())
            {
                FacturaCompraDetalle = new FacturaCompraDetalleBE();
                FacturaCompraDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FacturaCompraDetalle.IdFacturaCompraDetalle = Int32.Parse(reader["idFacturaCompraDetalle"].ToString());
                FacturaCompraDetalle.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                FacturaCompraDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                FacturaCompraDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                FacturaCompraDetalle.NombreProducto = reader["NombreProducto"].ToString();
                FacturaCompraDetalle.Medida = reader["Medida"].ToString();

                FacturaCompraDetalle.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                FacturaCompraDetalle.Abreviatura = reader["Abreviatura"].ToString();
                FacturaCompraDetalle.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
                FacturaCompraDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompraDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                FacturaCompraDetalle.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                FacturaCompraDetalle.CantidadVenta = Int32.Parse(reader["CantidadVenta"].ToString());
                FacturaCompraDetalle.ImporteVenta = Decimal.Parse(reader["ImporteVenta"].ToString());
                FacturaCompraDetalle.Imagen = (byte[])reader["Imagen"];
                FacturaCompraDetalle.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                FacturaCompraDetalle.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                FacturaCompraDetalle.AlmacenAndahuaylas = Int32.Parse(reader["AlmacenAndahuaylas"].ToString());
                FacturaCompraDetalle.AlmacenOutlet = Int32.Parse(reader["AlmacenOutlet"].ToString());
                FacturaCompraDetalle.AlmacenPrescott = Int32.Parse(reader["AlmacenPrescott"].ToString());
                FacturaCompraDetalle.AlmacenAviacion = Int32.Parse(reader["AlmacenAviacion"].ToString());
                FacturaCompraDetalle.AlmacenAviacion2 = Int32.Parse(reader["AlmacenAviacion2"].ToString());
                FacturaCompraDetalle.AlmacenSanMiguel = Int32.Parse(reader["AlmacenSanMiguel"].ToString());
                FacturaCompraDetalle.AlmacenMegaPlaza = Int32.Parse(reader["AlmacenMegaPlaza"].ToString());
                FacturaCompraDetalle.TotalStock = Int32.Parse(reader["TotalStock"].ToString());

                FacturaCompraDetalle.TransAlmacenTienda = Int32.Parse(reader["TransAlmacenTienda"].ToString());
                FacturaCompraDetalle.TransAlmacenAndahuaylas = Int32.Parse(reader["TransAlmacenAndahuaylas"].ToString());
                FacturaCompraDetalle.TransAlmacenPrescott = Int32.Parse(reader["TransAlmacenPrescott"].ToString());
                FacturaCompraDetalle.TransAlmacenAviacion2 = Int32.Parse(reader["TransAlmacenAviacion2"].ToString());
                FacturaCompraDetalle.TransAlmacenSanMiguel = Int32.Parse(reader["TransAlmacenSanMiguel"].ToString());

                //FacturaCompraDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                FacturaCompraDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FacturaCompraDetalle.TipoOper = 4; //Consultar
                FacturaCompraDetallelist.Add(FacturaCompraDetalle);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompraDetallelist;
        }

        public List<FacturaCompraDetalleBE> ListaTodosStock(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraDetalle_ListaTodosStock");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraDetalleBE> FacturaCompraDetallelist = new List<FacturaCompraDetalleBE>();
            FacturaCompraDetalleBE FacturaCompraDetalle;
            while (reader.Read())
            {
                FacturaCompraDetalle = new FacturaCompraDetalleBE();
                FacturaCompraDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FacturaCompraDetalle.IdFacturaCompraDetalle = Int32.Parse(reader["idFacturaCompraDetalle"].ToString());
                FacturaCompraDetalle.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                FacturaCompraDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                FacturaCompraDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                FacturaCompraDetalle.NombreProducto = reader["NombreProducto"].ToString();
                FacturaCompraDetalle.Medida = reader["Medida"].ToString();
                FacturaCompraDetalle.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                FacturaCompraDetalle.Abreviatura = reader["Abreviatura"].ToString();
                FacturaCompraDetalle.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
                FacturaCompraDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompraDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                FacturaCompraDetalle.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                FacturaCompraDetalle.CantidadVenta = Int32.Parse(reader["CantidadVenta"].ToString());
                FacturaCompraDetalle.ImporteVenta = Decimal.Parse(reader["ImporteVenta"].ToString());
                FacturaCompraDetalle.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                FacturaCompraDetalle.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                FacturaCompraDetalle.AlmacenAndahuaylas = Int32.Parse(reader["AlmacenAndahuaylas"].ToString());
                FacturaCompraDetalle.AlmacenOutlet = Int32.Parse(reader["AlmacenOutlet"].ToString());
                FacturaCompraDetalle.AlmacenPrescott = Int32.Parse(reader["AlmacenPrescott"].ToString());
                FacturaCompraDetalle.AlmacenAviacion = Int32.Parse(reader["AlmacenAviacion"].ToString());
                FacturaCompraDetalle.AlmacenAviacion2 = Int32.Parse(reader["AlmacenAviacion2"].ToString());
                FacturaCompraDetalle.AlmacenMegaPlaza = Int32.Parse(reader["AlmacenMegaPlaza"].ToString());
                FacturaCompraDetalle.AlmacenSanMiguel = Int32.Parse(reader["AlmacenSanMiguel"].ToString());
                FacturaCompraDetalle.TotalStock = Int32.Parse(reader["TotalStock"].ToString());
                FacturaCompraDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());

                FacturaCompraDetalle.TransAlmacenTienda = Int32.Parse(reader["TransAlmacenTienda"].ToString());
                FacturaCompraDetalle.TransAlmacenAndahuaylas = Int32.Parse(reader["TransAlmacenAndahuaylas"].ToString());
                FacturaCompraDetalle.TransAlmacenPrescott = Int32.Parse(reader["TransAlmacenPrescott"].ToString());
                FacturaCompraDetalle.TransAlmacenAviacion2 = Int32.Parse(reader["TransAlmacenAviacion2"].ToString());
                FacturaCompraDetalle.TransAlmacenSanMiguel = Int32.Parse(reader["TransAlmacenSanMiguel"].ToString());

                FacturaCompraDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FacturaCompraDetalle.TipoOper = 4; //Consultar

                FacturaCompraDetallelist.Add(FacturaCompraDetalle);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompraDetallelist;
        }

        public List<FacturaCompraDetalleBE> ListaNumero(int IdEmpresa, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraDetalle_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraDetalleBE> FacturaCompraDetallelist = new List<FacturaCompraDetalleBE>();
            FacturaCompraDetalleBE FacturaCompraDetalle;
            while (reader.Read())
            {
                FacturaCompraDetalle = new FacturaCompraDetalleBE();
                FacturaCompraDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FacturaCompraDetalle.IdFacturaCompraDetalle = Int32.Parse(reader["idFacturaCompraDetalle"].ToString());
                FacturaCompraDetalle.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                FacturaCompraDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                FacturaCompraDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                FacturaCompraDetalle.NombreProducto = reader["NombreProducto"].ToString();
                FacturaCompraDetalle.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                FacturaCompraDetalle.Abreviatura = reader["Abreviatura"].ToString();
                FacturaCompraDetalle.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
                FacturaCompraDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompraDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                FacturaCompraDetalle.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                FacturaCompraDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FacturaCompraDetalle.TipoOper = 4; //Consultar
                FacturaCompraDetallelist.Add(FacturaCompraDetalle);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompraDetallelist;
        }

        public List<FacturaCompraDetalleBE> ListaNumeroPrecioABCD(int IdEmpresa, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_FacturaCompraDetalle_SeleccionaNumeroPrecioABCD");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<FacturaCompraDetalleBE> FacturaCompraDetallelist = new List<FacturaCompraDetalleBE>();
            FacturaCompraDetalleBE FacturaCompraDetalle;
            while (reader.Read())
            {
                FacturaCompraDetalle = new FacturaCompraDetalleBE();
                FacturaCompraDetalle.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                FacturaCompraDetalle.IdFacturaCompraDetalle = Int32.Parse(reader["idFacturaCompraDetalle"].ToString());
                FacturaCompraDetalle.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                FacturaCompraDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                FacturaCompraDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                FacturaCompraDetalle.NombreProducto = reader["NombreProducto"].ToString();
                FacturaCompraDetalle.IdUnidadMedida = Int32.Parse(reader["IdUnidadMedida"].ToString());
                FacturaCompraDetalle.Abreviatura = reader["Abreviatura"].ToString();
                FacturaCompraDetalle.NumeroBultos = Int32.Parse(reader["NumeroBultos"].ToString());
                FacturaCompraDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                FacturaCompraDetalle.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                FacturaCompraDetalle.SubTotal = Decimal.Parse(reader["SubTotal"].ToString());
                FacturaCompraDetalle.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                FacturaCompraDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                FacturaCompraDetalle.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                FacturaCompraDetalle.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                FacturaCompraDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                FacturaCompraDetalle.DescuentoAB = Decimal.Parse(reader["DescuentoAB"].ToString());
                FacturaCompraDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                FacturaCompraDetalle.FlagDescuentoAB = Boolean.Parse(reader["FlagDescuentoAB"].ToString());
                FacturaCompraDetalle.TipoOper = 4; //Consultar
                FacturaCompraDetallelist.Add(FacturaCompraDetalle);
            }
            reader.Close();
            reader.Dispose();
            return FacturaCompraDetallelist;
        }
    }
}
