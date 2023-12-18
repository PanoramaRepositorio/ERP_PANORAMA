using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PromocionVolumenDetalleDL
    {

        public void Inserta(PromocionVolumenDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionVolumenDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdPromocionVolumenDetalle", DbType.Int32, pItem.IdPromocionVolumenDetalle);
            db.AddInParameter(dbCommand, "pIdPromocionVolumen", DbType.Int32, pItem.IdPromocionVolumen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pMontoUniXamas", DbType.Decimal, pItem.MontoUniXamas);
            db.AddInParameter(dbCommand, "pMontoSoloXUni", DbType.Decimal, pItem.MontoSoloXUni);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }


        public void Actualiza(PromocionVolumenDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionVolumenDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdPromocionVolumenDetalle", DbType.Int32, pItem.IdPromocionVolumenDetalle);
            db.AddInParameter(dbCommand, "pIdPromocionVolumen", DbType.Int32, pItem.IdPromocionVolumen);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pDescuento", DbType.Decimal, pItem.Descuento);
            db.AddInParameter(dbCommand, "pMontoUniXamas", DbType.Decimal, pItem.MontoUniXamas);
            db.AddInParameter(dbCommand, "pMontoSoloXUni", DbType.Decimal, pItem.MontoSoloXUni);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }



        public List<PromocionVolumenDetalleBE> ListaTodosActivo(int IdPromocionVolumen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionVolumenDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdPromocionVolumen", DbType.Int32, IdPromocionVolumen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionVolumenDetalleBE> PromocionTemporalDetallelist = new List<PromocionVolumenDetalleBE>();
            PromocionVolumenDetalleBE PromocionVolmenDetalle;
            while (reader.Read())
            {
                PromocionVolmenDetalle = new PromocionVolumenDetalleBE();
                PromocionVolmenDetalle.IdPromocionVolumenDetalle = Int32.Parse(reader["IdPromocionVolumenDetalle"].ToString());
                PromocionVolmenDetalle.IdPromocionVolumen = Int32.Parse(reader["IdPromocionVolumen"].ToString());
                PromocionVolmenDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                PromocionVolmenDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PromocionVolmenDetalle.NombreProducto = reader["NombreProducto"].ToString();
                //PromocionVolmenDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PromocionVolmenDetalle.MontoUniXamas = Decimal.Parse(reader["MontoUniXamas"].ToString());
                PromocionVolmenDetalle.MontoSoloXUni = Decimal.Parse(reader["MontoSoloXUni"].ToString());
                PromocionVolmenDetalle.DescLineaProducto = reader["DescLineaProducto"].ToString();
                PromocionVolmenDetalle.DescSubLineaProducto = reader["DescSubLineaProducto"].ToString();
                PromocionVolmenDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                PromocionVolmenDetalle.Precio2 = Decimal.Parse(reader["Precio2"].ToString());
                PromocionVolmenDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionVolmenDetalle.DescuentoActual = Decimal.Parse(reader["DescuentoActual"].ToString());
                PromocionVolmenDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PromocionVolmenDetalle.CantidadCompra = Int32.Parse(reader["CantidadCompra"].ToString());
                PromocionVolmenDetalle.AlmacenCentral = Int32.Parse(reader["AlmacenCentral"].ToString());
                PromocionVolmenDetalle.AlmacenTienda = Int32.Parse(reader["AlmacenTienda"].ToString());
                PromocionVolmenDetalle.AlmacenAndahuaylas = Int32.Parse(reader["AlmacenAndahuaylas"].ToString());
                PromocionVolmenDetalle.AlmacenPrescott = Int32.Parse(reader["AlmacenPrescott"].ToString());
                PromocionVolmenDetalle.AlmacenAviacion = Int32.Parse(reader["AlmacenAviacion"].ToString());
                PromocionVolmenDetalle.AlmacenMegaPlaza = Int32.Parse(reader["AlmacenMegaPlaza"].ToString());
                PromocionVolmenDetalle.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                PromocionVolmenDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
                PromocionVolmenDetalle.AlmacenAviacion2 = Int32.Parse(reader["AlmacenAviacion2"].ToString());
                PromocionVolmenDetalle.AlmacenSanMiguel = Int32.Parse(reader["AlmacenSanMiguel"].ToString());
                PromocionVolmenDetalle.TipoOper = 4;
                PromocionTemporalDetallelist.Add(PromocionVolmenDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporalDetallelist;
        }


        public void EliminaTodo(PromocionVolumenDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionVolumenDetalle_EliminaTodo");

            db.AddInParameter(dbCommand, "pIdPromocionVolumen", DbType.Int32, pItem.IdPromocionVolumen);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(PromocionVolumenDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionVolumenDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdPromocionVolumenDetalle", DbType.Int32, pItem.IdPromocionVolumenDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }


        public PromocionVolumenDetalleBE Selecciona(int IdEmpresa, int IdTipoCliente, int IdFormaPago, int IdTienda, int IdTipoVenta, int IdProducto, bool TraerIdTemDet)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PromocionVolumenDetalle_SeleccionaTipoClienteFormapago");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCliente", DbType.Int32, IdTipoCliente);
            db.AddInParameter(dbCommand, "pIdFormaPago", DbType.Int32, IdFormaPago);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pIdTipoVenta", DbType.Int32, IdTipoVenta);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);
            db.AddInParameter(dbCommand, "pTraerIdTemDet", DbType.Boolean, TraerIdTemDet);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PromocionVolumenDetalleBE PromocionTemporalDetalle = null;
            while (reader.Read())
            {
                PromocionTemporalDetalle = new PromocionVolumenDetalleBE();
                PromocionTemporalDetalle.IdPromocionVolumenDetalle = Int32.Parse(reader["IdPromocionVolumenDetalle"].ToString());
                PromocionTemporalDetalle.IdPromocionVolumen = Int32.Parse(reader["IdPromocionVolumen"].ToString());
                PromocionTemporalDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                PromocionTemporalDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PromocionTemporalDetalle.NombreProducto = reader["NombreProducto"].ToString();
                PromocionTemporalDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PromocionTemporalDetalle.DescLineaProducto = reader["DescLineaProducto"].ToString();
                PromocionTemporalDetalle.Precio = Decimal.Parse(reader["Precio"].ToString());
                PromocionTemporalDetalle.Precio2 = Decimal.Parse(reader["Precio2"].ToString());
                PromocionTemporalDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PromocionTemporalDetalle.DescuentoActual = Decimal.Parse(reader["DescuentoActual"].ToString());
                PromocionTemporalDetalle.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                PromocionTemporalDetalle.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return PromocionTemporalDetalle;
        }



        public List<PromocionVolumenDetalleBE> ObtenerProductosPorDetalle(int IdPromocionVolumen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ObtenerProductosPorDetalle");
            db.AddInParameter(dbCommand, "IdPromocionVolumen", DbType.Int32, IdPromocionVolumen);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionVolumenDetalleBE> listaProductos = new List<PromocionVolumenDetalleBE>();

            while (reader.Read())
            {
                PromocionVolumenDetalleBE producto = new PromocionVolumenDetalleBE();
                producto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                producto.NombreProducto = reader["NombreProducto"].ToString();
                producto.MontoUniXamas = Decimal.Parse(reader["MontoUniXamas"].ToString());
                producto.MontoSoloXUni = Decimal.Parse(reader["MontoSoloXUni"].ToString());
                producto.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                producto.Fecha = DateTime.Parse(reader["FechaRegistro"].ToString());
                producto.FlagEstado = Boolean.Parse(reader["FlagEstado"].ToString());

                listaProductos.Add(producto);
            }

            reader.Close();
            reader.Dispose();
            return listaProductos;
        }

        public List<PromocionVolumenBE> ValidarPromocion(int IdPromocionVolumen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ValidarPromocion");
            db.AddInParameter(dbCommand, "IdPromocionVolumen", DbType.Int32, IdPromocionVolumen);

            IDataReader reader = db.ExecuteReader(dbCommand);

            List<PromocionVolumenBE> listapromo = new List<PromocionVolumenBE>();


            if (reader.Read())
            {
                PromocionVolumenBE promobe = new PromocionVolumenBE();
                promobe.CantidadProductos = Int32.Parse(reader["CantidadProductos"].ToString());
                promobe.FlagAplicaCombinacion = Boolean.Parse(reader["FlagCombinacion"].ToString());
                promobe.FlagAplicaxCodigo = Boolean.Parse(reader["FlagAplicaxCodigo"].ToString());
                promobe.MontoUniXamas = Decimal.Parse(reader["MontoTotalUniXamas"].ToString());
                promobe.MontoSoloXUni = Decimal.Parse(reader["MontoTotalSoloXUni"].ToString());
                listapromo.Add(promobe);
            }

            reader.Close();
            reader.Dispose();
            return listapromo;
        }

        public List<PromocionVolumenDetalleBE> ValidarPromocionIDProducto(int IdPromocionVolumen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ValidarPromocion_IDProducto");
            db.AddInParameter(dbCommand, "IdProducto", DbType.Int32, IdPromocionVolumen);

            IDataReader reader = db.ExecuteReader(dbCommand);

            List<PromocionVolumenDetalleBE> listapromo = new List<PromocionVolumenDetalleBE>();  // Cambiado a List<PromocionVolumenBE>
            if (reader != null)
            {
                while (reader.Read())
                {
                    PromocionVolumenDetalleBE promobedt = new PromocionVolumenDetalleBE();

                    // Verificar si los campos no son nulos antes de convertir
                    promobedt.CantidadProductos = reader["Cantidad_MismoCodigo"] != DBNull.Value
                        ? Int32.Parse(reader["Cantidad_MismoCodigo"].ToString())
                        : 0; // Puedes establecer un valor predeterminado o manejarlo según tus necesidades

                    promobedt.FlagAplicaCombinacion = reader["FlagCombinacion"] != DBNull.Value
                        ? Boolean.Parse(reader["FlagCombinacion"].ToString())
                        : false;

                    promobedt.FlagAplicaxCodigo = reader["FlagAplicaxCodigo"] != DBNull.Value
                        ? Boolean.Parse(reader["FlagAplicaxCodigo"].ToString())
                        : false;

                    promobedt.MontoUniXamas = reader["MontoTotalUniXamas"] != DBNull.Value
                        ? Decimal.Parse(reader["MontoTotalUniXamas"].ToString())
                        : 0;

                    promobedt.MontoSoloXUni = reader["MontoTotalSoloXUni"] != DBNull.Value
                        ? Decimal.Parse(reader["MontoTotalSoloXUni"].ToString())
                        : 0;

                    listapromo.Add(promobedt);
                }

                reader.Close();
                reader.Dispose();
            }

            return listapromo;
        }

        public List<PromocionVolumenDetalleBE> ObtenerIdPromocionPorIdProducto(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ObtenerIdPromocionPorIdproducto");
            db.AddInParameter(dbCommand, "IdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PromocionVolumenDetalleBE> listapro = new List<PromocionVolumenDetalleBE>();
            while (reader.Read())
            {
                PromocionVolumenDetalleBE promo = new PromocionVolumenDetalleBE();
                promo.IdPromocionVolumen = Int32.Parse(reader["IdPromocionVolumen"].ToString());
                listapro.Add(promo);
            }
            reader.Close();
            reader.Dispose();
            return listapro;
        }

        public List<PromocionVolumenDetalleBE> ObtenerProductosPorIdPromocion(int idPromocionVolumen)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbComand = db.GetStoredProcCommand("usp_ObtenerProductosPorDetalle");
            db.AddInParameter(dbComand, "IdPromocionVolumen", DbType.Int32, idPromocionVolumen);

            IDataReader reader = db.ExecuteReader(dbComand);
            List<PromocionVolumenDetalleBE> listaproduc = new List<PromocionVolumenDetalleBE>();
            while (reader.Read())
            {
                PromocionVolumenDetalleBE prod = new PromocionVolumenDetalleBE();
                prod.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                listaproduc.Add(prod);
            }
            reader.Close();
            reader.Dispose();
            return listaproduc;
        }


    }
}
