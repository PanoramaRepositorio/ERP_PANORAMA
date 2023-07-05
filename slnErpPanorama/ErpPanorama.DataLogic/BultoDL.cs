using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class BultoDL
    {
        public BultoDL() { }

        public void Inserta(BultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_Inserta");

            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdBloque", DbType.Int32, pItem.IdBloque);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNumeroBulto", DbType.String, pItem.NumeroBulto);
            db.AddInParameter(dbCommand, "pAgrupacion", DbType.String, pItem.Agrupacion);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(BultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_Actualiza");

            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, pItem.IdAlmacen);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdBloque", DbType.Int32, pItem.IdBloque);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, pItem.IdProducto);
            db.AddInParameter(dbCommand, "pNumeroBulto", DbType.String, pItem.NumeroBulto);
            db.AddInParameter(dbCommand, "pAgrupacion", DbType.String, pItem.Agrupacion);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, pItem.IdFacturaCompra);
            db.AddInParameter(dbCommand, "pPrecioUnitario", DbType.Decimal, pItem.PrecioUnitario);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, pItem.Cantidad);
            db.AddInParameter(dbCommand, "pCostoUnitario", DbType.Decimal, pItem.CostoUnitario);
            db.AddInParameter(dbCommand, "pFechaIngreso", DbType.DateTime, pItem.FechaIngreso);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pIdKardex", DbType.Int32, pItem.IdKardex);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaSituacion(BultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.FechaSalida);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCantidad(int IdBulto, int Cantidad)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ActualizaCantidad");

            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, IdBulto);
            db.AddInParameter(dbCommand, "pCantidad", DbType.Int32, Cantidad);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaTransito(int IdEmpresa, int IdBulto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ActualizaTransito");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, IdBulto);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaCantidadChequeo(BultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ActualizaCantidadChequeo");

            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
            db.AddInParameter(dbCommand, "pCantidadChequeo", DbType.Int32, pItem.CantidadChequeo);
            db.AddInParameter(dbCommand, "pFechaChequeo", DbType.DateTime, pItem.FechaChequeo);
            db.AddInParameter(dbCommand, "pIdChequeador", DbType.Int32, pItem.IdChequeador);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(BultoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_Elimina");

            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, pItem.IdBulto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina_Producto(int IdEmpresa, int IdBulto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_Elimina_Producto");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, IdBulto);

            db.ExecuteNonQuery(dbCommand);
        }

        public BultoBE Selecciona(int IdEmpresa, int IdBulto, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, IdBulto);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            BultoBE Bulto = null;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Bulto.DescAlmacen = reader["descAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["idSector"].ToString());
                Bulto.DescSector = reader["descSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["idBloque"].ToString());
                Bulto.DescBloque = reader["descBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Bulto.CodigoProveedor = reader["codigoProveedor"].ToString();
                Bulto.NombreProducto = reader["nombreProducto"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["numeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Bulto.Situacion = reader["situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Bulto;
        }

        public List<BultoBE> ListaTodosActivo(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Bulto.DescAlmacen = reader["descAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["idSector"].ToString());
                Bulto.DescSector = reader["descSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["idBloque"].ToString());
                Bulto.DescBloque = reader["descBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Bulto.CodigoProveedor = reader["codigoProveedor"].ToString();
                Bulto.NombreProducto = reader["nombreProducto"].ToString();
                Bulto.Abreviatura = reader["abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["numeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Bulto.Situacion = reader["situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }

        public List<BultoBE> ListaTodosActivoTransferenciaAnaqueles(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaTodosActivoTransferenciaAnaqueles");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Bulto.DescAlmacen = reader["descAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["idSector"].ToString());
                Bulto.DescSector = reader["descSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["idBloque"].ToString());
                Bulto.DescBloque = reader["descBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Bulto.CodigoProveedor = reader["codigoProveedor"].ToString();
                Bulto.NombreProducto = reader["nombreProducto"].ToString();
                Bulto.Abreviatura = reader["abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["numeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Bulto.Situacion = reader["situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }

        public List<BultoBE> ListaTransferenciaAnaquelesOperadorResumen(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaTransferenciaAnaquelesOperadorResumen");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.UsuarioSalida = reader["UsuarioSalida"].ToString();
                Bulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }

        public int ListaRecibidosCount(int IdEmpresa, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaRecibidosCount");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<BultoBE> ListaRecibidos(int IdEmpresa, string pFiltro, int Pagina, int CantidadRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaRecibidos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPagina", DbType.Int32, Pagina);
            db.AddInParameter(dbCommand, "pCantidadRegistro", DbType.Int32, CantidadRegistro);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Bulto.DescAlmacen = reader["DescAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Bulto.DescSector = reader["DescSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                Bulto.DescBloque = reader["DescBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Bulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Bulto.NombreProducto = reader["NombreProducto"].ToString();
                Bulto.Abreviatura = reader["Abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Bulto.Situacion = reader["Situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bulto.FlagTransferencia = false;
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }

        public List<BultoBE> ListaRecepcionados(int IdEmpresa, int IdProducto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaRecepcionados");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProducto", DbType.Int32, IdProducto);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Bulto.DescAlmacen = reader["DescAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Bulto.DescSector = reader["DescSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                Bulto.DescBloque = reader["DescBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Bulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Bulto.NombreProducto = reader["NombreProducto"].ToString();
                Bulto.Abreviatura = reader["Abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Bulto.Situacion = reader["Situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bulto.FlagTransferencia = false;
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }

        public List<BultoBE> ListaFacturaCompra(int IdEmpresa, int IdFacturaCompra)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaFacturaCompra");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdFacturaCompra", DbType.Int32, IdFacturaCompra);


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Bulto.DescAlmacen = reader["DescAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Bulto.DescSector = reader["DescSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                Bulto.DescBloque = reader["DescBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Bulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Bulto.NombreProducto = reader["NombreProducto"].ToString();
                Bulto.Abreviatura = reader["Abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Bulto.Situacion = reader["Situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bulto.FlagTransferencia = false;
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }

        public List<BultoBE> ListaUbicacion(int IdEmpresa, int IdAlmacen, int IdSector, int IdBloque)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaUbicacion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, IdSector);
            db.AddInParameter(dbCommand, "pIdBloque", DbType.Int32, IdBloque);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Bulto.DescAlmacen = reader["DescAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Bulto.DescSector = reader["DescSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                Bulto.DescBloque = reader["DescBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Bulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Bulto.NombreProducto = reader["NombreProducto"].ToString();
                Bulto.Abreviatura = reader["Abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Bulto.Situacion = reader["Situacion"].ToString();
                Bulto.FechaRecepcion = reader.IsDBNull(reader.GetOrdinal("FechaRecepcion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaRecepcion"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bulto.FlagTransferencia = false;
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }

        public List<BultoBE> ListaNumeroBulto(int IdEmpresa, string NumeroBulto, int IdSiUtuacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_SeleccionaNumeroBulto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumeroBulto", DbType.String, NumeroBulto);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.String, IdSiUtuacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto = null;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Bulto.DescAlmacen = reader["descAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["idSector"].ToString());
                Bulto.DescSector = reader["descSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["idBloque"].ToString());
                Bulto.DescBloque = reader["descBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Bulto.CodigoProveedor = reader["codigoProveedor"].ToString();
                Bulto.NombreProducto = reader["nombreProducto"].ToString();
                Bulto.Abreviatura = reader["Abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["numeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Bulto.Situacion = reader["situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.UsuarioSalida = reader["UsuarioSalida"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }

        public List<BultoBE> ListaChequeo(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaChequeo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Bulto.DescAlmacen = reader["DescAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Bulto.DescSector = reader["DescSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                Bulto.DescBloque = reader["DescBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Bulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Bulto.NombreProducto = reader["NombreProducto"].ToString();
                Bulto.Abreviatura = reader["Abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Bulto.Situacion = reader["Situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();

                Bulto.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                Bulto.CantidadChequeo = reader.IsDBNull(reader.GetOrdinal("CantidadChequeo")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CantidadChequeo"));
                Bulto.IdChequeador = reader.IsDBNull(reader.GetOrdinal("IdChequeador")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdChequeador"));
                Bulto.DescChequeador = reader["DescChequeador"].ToString();
                Bulto.PorcentajeChequeo = Decimal.Parse(reader["PorcentajeChequeo"].ToString());
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bulto.FlagTransferencia = false;
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }


        public List<BultoBE> ListaNumeroBultoChequeo(int IdEmpresa, string NumeroBulto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaNumeroBultoChequeo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumeroBulto", DbType.String, NumeroBulto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Bulto.DescAlmacen = reader["DescAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Bulto.DescSector = reader["DescSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                Bulto.DescBloque = reader["DescBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Bulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Bulto.NombreProducto = reader["NombreProducto"].ToString();
                Bulto.Abreviatura = reader["Abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Bulto.Situacion = reader["Situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();

                Bulto.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                Bulto.CantidadChequeo = reader.IsDBNull(reader.GetOrdinal("CantidadChequeo")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CantidadChequeo"));
                Bulto.IdChequeador = reader.IsDBNull(reader.GetOrdinal("IdChequeador")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdChequeador"));
                Bulto.DescChequeador = reader["DescChequeador"].ToString();
                Bulto.PorcentajeChequeo = Decimal.Parse(reader["PorcentajeChequeo"].ToString());
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bulto.FlagTransferencia = false;
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }

        public BultoBE SeleccionaChequeo(int IdEmpresa, int IdBulto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_SeleccionaChequeo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdBulto", DbType.Int32, IdBulto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            BultoBE Bulto = null;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Bulto.DescAlmacen = reader["DescAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Bulto.DescSector = reader["DescSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                Bulto.DescBloque = reader["DescBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Bulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Bulto.NombreProducto = reader["NombreProducto"].ToString();
                Bulto.Abreviatura = reader["Abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Bulto.Situacion = reader["Situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();

                Bulto.FechaChequeo = reader.IsDBNull(reader.GetOrdinal("FechaChequeo")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaChequeo"));
                Bulto.CantidadChequeo = reader.IsDBNull(reader.GetOrdinal("CantidadChequeo")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("CantidadChequeo"));
                Bulto.IdChequeador = reader.IsDBNull(reader.GetOrdinal("IdChequeador")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdChequeador"));
                Bulto.DescChequeador = reader["DescChequeador"].ToString();

                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bulto.FlagTransferencia = false;
            }
            reader.Close();
            reader.Dispose();
            return Bulto;
        }




        public BultoBE SeleccionaNumeroBulto(int IdEmpresa, string NumeroBulto, int IdSiUtuacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_SeleccionaNumeroBulto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pNumeroBulto", DbType.String, NumeroBulto);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.String, IdSiUtuacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            BultoBE Bulto = null;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Bulto.DescAlmacen = reader["descAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["idSector"].ToString());
                Bulto.DescSector = reader["descSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["idBloque"].ToString());
                Bulto.DescBloque = reader["descBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Bulto.CodigoProveedor = reader["codigoProveedor"].ToString();
                Bulto.NombreProducto = reader["nombreProducto"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["numeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Bulto.Situacion = reader["situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.UsuarioSalida = reader["UsuarioSalida"].ToString();
                Bulto.FlagTransito = Boolean.Parse(reader["FlagTransito"].ToString());
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Bulto;
        }

        public BultoBE ValidaNumero(int IdEmpresa, int Periodo, int IdAlmacen, int IdSector, string NumeroBulto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ValidaNumero");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pIdAlmacen", DbType.Int32, IdAlmacen);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, IdSector);
            db.AddInParameter(dbCommand, "pNumeroBulto", DbType.String, NumeroBulto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            BultoBE Bulto = null;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["idAlmacen"].ToString());
                Bulto.DescAlmacen = reader["descAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["idSector"].ToString());
                Bulto.DescSector = reader["descSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["idBloque"].ToString());
                Bulto.DescBloque = reader["descBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["idProducto"].ToString());
                Bulto.CodigoProveedor = reader["codigoProveedor"].ToString();
                Bulto.NombreProducto = reader["nombreProducto"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["idFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["idTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["numeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["precioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.IdSituacion = Int32.Parse(reader["idSituacion"].ToString());
                Bulto.Situacion = reader["situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Bulto;
        }

        public int ListaTransferidosCount(int IdEmpresa, string pFiltro)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaTransferidosdosCount");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }

        public List<BultoBE> ListaTransferidos(int IdEmpresa, string pFiltro)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaTransferidos");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFiltro", DbType.String, pFiltro);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Bulto.DescAlmacen = reader["DescAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Bulto.DescSector = reader["DescSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                Bulto.DescBloque = reader["DescBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Bulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Bulto.NombreProducto = reader["NombreProducto"].ToString();
                Bulto.Abreviatura = reader["Abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.FechaSalida = reader.IsDBNull(reader.GetOrdinal("FechaSalida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                Bulto.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Bulto.Situacion = reader["Situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.UsuarioSalida = reader["UsuarioSalida"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bulto.FlagTransferencia = false;
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }

        public List<BultoBE> ListaTransferidosFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Bulto_ListaTransferidosFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<BultoBE> Bultolist = new List<BultoBE>();
            BultoBE Bulto;
            while (reader.Read())
            {
                Bulto = new BultoBE();
                Bulto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Bulto.IdBulto = Int32.Parse(reader["idBulto"].ToString());
                Bulto.IdAlmacen = Int32.Parse(reader["IdAlmacen"].ToString());
                Bulto.DescAlmacen = reader["DescAlmacen"].ToString();
                Bulto.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Bulto.DescSector = reader["DescSector"].ToString();
                Bulto.IdBloque = Int32.Parse(reader["IdBloque"].ToString());
                Bulto.DescBloque = reader["DescBloque"].ToString();
                Bulto.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                Bulto.CodigoProveedor = reader["CodigoProveedor"].ToString();
                Bulto.NombreProducto = reader["NombreProducto"].ToString();
                Bulto.Abreviatura = reader["Abreviatura"].ToString();
                Bulto.NumeroBulto = reader["numeroBulto"].ToString();
                Bulto.Agrupacion = reader["agrupacion"].ToString();
                Bulto.IdFacturaCompra = Int32.Parse(reader["IdFacturaCompra"].ToString());
                Bulto.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Bulto.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Bulto.PrecioUnitario = Decimal.Parse(reader["PrecioUnitario"].ToString());
                Bulto.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                Bulto.CostoUnitario = Decimal.Parse(reader["CostoUnitario"].ToString());
                Bulto.FechaIngreso = reader.IsDBNull(reader.GetOrdinal("FechaIngreso")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaIngreso"));
                Bulto.FechaSalida = reader.IsDBNull(reader.GetOrdinal("FechaSalida")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSalida"));
                Bulto.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Bulto.Situacion = reader["Situacion"].ToString();
                Bulto.IdKardex = reader.IsDBNull(reader.GetOrdinal("IdKardex")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdKardex"));
                Bulto.Observacion = reader["Observacion"].ToString();
                Bulto.UsuarioSalida = reader["UsuarioSalida"].ToString();
                Bulto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Bulto.FlagTransferencia = false;
                Bultolist.Add(Bulto);
            }
            reader.Close();
            reader.Dispose();
            return Bultolist;
        }
    }
}

