using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class PreventaDetalleDL
    {
        public PreventaDetalleDL() { }

        /// <summary>
        /// Inserta un nuevo registro en la tabla PreventaDetalle y registra una auditoría de la operación realizada.
        /// </summary>
        /// <param name="pItem">Objeto PreventaDetalleBE que contiene los datos a insertar.</param>
        public void Inserta(PreventaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PreventaDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdPreventaDetalle", DbType.Int32, pItem.IdPreventaDetalle);
            db.AddInParameter(dbCommand, "pIdPreventa", DbType.Int32, pItem.IdPreventa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Inserta un nuevo registro en la tabla Preventa, registra una auditoría de la operación realizada y devuelve el identificador generado para el nuevo registro.
        /// </summary>
        /// <param name="pItem">Objeto PreventaBE que contiene los datos a insertar.</param>
        /// <returns>El identificador generado para el nuevo registro.</returns>
        public Int32 Inserta(PreventaBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Preventa_Inserta"); // este procedimiento almacenado realiza la inserción de un nuevo registro en la tabla "Preventa", registra una auditoría de la operación realizada y devuelve el identificador generado para el nuevo registro mediante el parámetro de salida @pIdPreventa.

            db.AddOutParameter(dbCommand, "pIdPreventa", DbType.Int32, pItem.IdPreventa);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescPreventa", DbType.String, pItem.DescPreventa);
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pItem.FechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdPreventa");

            return intIdCliente;
        }
        /// <summary>
        /// Actualiza un registro existente en la tabla PreventaDetalle con los datos proporcionados en el objeto PreventaDetalleBE.
        /// </summary>
        /// <param name="pItem">Objeto PreventaDetalleBE que contiene los datos a actualizar.</param>
        public void Actualiza(PreventaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PreventaDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdPreventaDetalle", DbType.Int32, pItem.IdPreventaDetalle);
            db.AddInParameter(dbCommand, "pIdPreventa", DbType.Int32, pItem.IdPreventa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            //db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }
        /// <summary>
        /// Elimina un registro de la tabla PreventaDetalle utilizando el identificador de preventa y la información adicional proporcionada en el objeto PreventaDetalleBE.
        /// </summary>
        /// <param name="pItem">Objeto PreventaDetalleBE que contiene los datos necesarios para la eliminación.</param>
        public void Elimina(PreventaDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PreventaDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdPreventaDetalle", DbType.Int32, pItem.IdPreventaDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Obtiene una lista de detalles de preventa activos basados en el identificador de preventa proporcionado.
        /// </summary>
        /// <param name="IdPreventa">Identificador de la preventa.</param>
        /// <returns>Una lista de objetos PreventaDetalleBE.</returns>
        public List<PreventaDetalleBE> ListaTodosActivo(int IdPreventa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PreventaDetalle_ListaTodosActivo"); // se utiliza para obtener una lista de detalles de preventa activos en función de un identificador de preventa proporcionado
            db.AddInParameter(dbCommand, "pIdPreventa", DbType.Int32, IdPreventa);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PreventaDetalleBE> PreventaDetallelist = new List<PreventaDetalleBE>();
            PreventaDetalleBE PreventaDetalle;
            while (reader.Read())
            {
                PreventaDetalle = new PreventaDetalleBE();
                PreventaDetalle.IdPreventa = Int32.Parse(reader["idPreventa"].ToString());
                PreventaDetalle.IdPreventaDetalle = Int32.Parse(reader["idPreventaDetalle"].ToString());
                PreventaDetalle.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                PreventaDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PreventaDetalle.NombreProducto = reader["nombreProducto"].ToString();
                PreventaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PreventaDetalle.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                PreventaDetalle.CantidadVenta = Int32.Parse(reader["CantidadVenta"].ToString());
                PreventaDetalle.FlagEstado = Boolean.Parse(reader["flagEstado"].ToString());
                PreventaDetalle.TipoOper = 4; //Consultar
                PreventaDetallelist.Add(PreventaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PreventaDetallelist;
        }


        public PreventaDetalleBE Selecciona(int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PreventaDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            PreventaDetalleBE Producto = null;
            while (reader.Read())
            {
                Producto = new PreventaDetalleBE();
                Producto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Producto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Producto.NombreProducto = reader["NombreProducto"].ToString();
                Producto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Producto;
        }

        public int ListaProductoPrecioBusquedaCount(int IdTienda, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PreventaDetalle_ListaProductoPrecioBusCount");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<PreventaDetalleBE> ListaProductoPrecio(int IdTienda, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_PreventaDetalle_ListaProductoPrecio");
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, IdTienda);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<PreventaDetalleBE> PreventaDetallelist = new List<PreventaDetalleBE>();
            PreventaDetalleBE PreventaDetalle;
            while (reader.Read())
            {
                PreventaDetalle = new PreventaDetalleBE();
                PreventaDetalle.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                PreventaDetalle.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                 PreventaDetalle.IdFamiliaProducto = Int32.Parse(reader["IdFamiliaProducto"].ToString());
                PreventaDetalle.IdLineaProducto = Int32.Parse(reader["IdLineaProducto"].ToString());
                PreventaDetalle.IdMarca = Int32.Parse(reader["IdMarca"].ToString());
                PreventaDetalle.DescFamiliaProducto = reader["DescFamiliaProducto"].ToString();
                PreventaDetalle.CodigoProveedor = reader["CodigoProveedor"].ToString();
                PreventaDetalle.NombreProducto = reader["NombreProducto"].ToString();
                PreventaDetalle.Abreviatura = reader["Abreviatura"].ToString();
                PreventaDetalle.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                PreventaDetalle.PrecioAB = Decimal.Parse(reader["PrecioAB"].ToString());
                PreventaDetalle.PrecioCD = Decimal.Parse(reader["PrecioCD"].ToString());
                PreventaDetalle.PrecioABSoles = Decimal.Parse(reader["PrecioABSoles"].ToString());
                PreventaDetalle.PrecioCDSoles = Decimal.Parse(reader["PrecioCDSoles"].ToString());
                PreventaDetalle.Descuento = Decimal.Parse(reader["Descuento"].ToString());
                PreventaDetalle.FlagEscala = Boolean.Parse(reader["FlagEscala"].ToString());
                PreventaDetalle.FlagNacional = Boolean.Parse(reader["FlagNacional"].ToString());
                PreventaDetalle.DescUbicacion = reader["DescUbicacion"].ToString();
                PreventaDetallelist.Add(PreventaDetalle);
            }
            reader.Close();
            reader.Dispose();
            return PreventaDetallelist;
        }


    }
}