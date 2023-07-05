using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ConsultasMarketingDL
    {
        public ConsultasMarketingDL() { }

        public List<ConsultasMarketingBE> ClienteRegistro(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Clientes_Registrados_Fecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ConsultasMarketingBE> Clientelist = new List<ConsultasMarketingBE>();
            ConsultasMarketingBE Cliente;
            while (reader.Read())
            {
                Cliente = new ConsultasMarketingBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.TipoCliente = reader["TipoCliente"].ToString();
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.Nombres = reader["Nombres"].ToString();
                Cliente.ApeMaterno = reader["ApeMaterno"].ToString();
                Cliente.ApePaterno = reader["ApePaterno"].ToString();
                Cliente.Cliente = reader["Cliente"].ToString();
                Cliente.Distrito = reader["Distrito"].ToString();
                Cliente.Direccion = reader["Direccion"].ToString();
                Cliente.Telefono = reader["Telefono"].ToString();
                Cliente.Celular = reader["Celular"].ToString();
                Cliente.OtroTelefono = reader["OtroTelefono"].ToString();
                Cliente.Email = reader["Email"].ToString();
                Cliente.EmailAdicional = reader["EmailAdicional"].ToString();
                Cliente.Encuesta = reader["Encuesta"].ToString();
                Cliente.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                //Cliente.FechaActualizacion = reader.IsDBNull(reader.GetOrdinal("FechaActualización")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaActualización"));
                Cliente.Registro = reader["Registro"].ToString();
                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }

        public List<ConsultasMarketingBE> ClienteReferido(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Lista_ClientesReferidos");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ConsultasMarketingBE> Clientelist = new List<ConsultasMarketingBE>();
            ConsultasMarketingBE Cliente;
            while (reader.Read())
            {
                Cliente = new ConsultasMarketingBE();

                Cliente.NumeroDocumento = reader["Documento"].ToString();
                Cliente.Referido = reader["Referido"].ToString();
                Cliente.NumeroPedido = reader["NumeroPedido"].ToString();
                Cliente.Concepto = reader["Concepto"].ToString();
                Cliente.Compro = reader["Compro"].ToString();
                Cliente.DescTienda = reader["DescTienda"].ToString();

                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }


        public List<ConsultasMarketingBE> ClienteActualizado(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Clientes_Actualizados_Fecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ConsultasMarketingBE> Clientelist = new List<ConsultasMarketingBE>();
            ConsultasMarketingBE Cliente;
            while (reader.Read())
            {
                Cliente = new ConsultasMarketingBE();
                Cliente.IdCliente = Int32.Parse(reader["idCliente"].ToString());
                Cliente.TipoCliente = reader["TipoCliente"].ToString();
                Cliente.AbrevDocumento = reader["AbrevDocumento"].ToString();
                Cliente.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Cliente.Nombres = reader["Nombres"].ToString();
                Cliente.ApeMaterno = reader["ApeMaterno"].ToString();
                Cliente.ApePaterno = reader["ApePaterno"].ToString();
                Cliente.Cliente = reader["Cliente"].ToString();
                Cliente.Distrito = reader["Distrito"].ToString();
                Cliente.Direccion = reader["Direccion"].ToString();
                Cliente.Telefono = reader["Telefono"].ToString();
                Cliente.Celular = reader["Celular"].ToString();
                Cliente.OtroTelefono = reader["OtroTelefono"].ToString();
                Cliente.Email = reader["Email"].ToString();
                Cliente.EmailAdicional = reader["EmailAdicional"].ToString();
                Cliente.Encuesta = reader["Encuesta"].ToString();
                Cliente.FechaRegistro = DateTime.Parse(reader["FechaRegistro"].ToString());
                Cliente.FechaActualizacion = reader.IsDBNull(reader.GetOrdinal("FechaActualización")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaActualización"));
                Cliente.Registro = reader["Registro"].ToString();
                Clientelist.Add(Cliente);
            }
            reader.Close();
            reader.Dispose();
            return Clientelist;
        }

        public List<ConsultasMarketingBE> ClienteCompras(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Clientes_Compras");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ConsultasMarketingBE> ClienteCompraslist = new List<ConsultasMarketingBE>();
            ConsultasMarketingBE ClienteCompras;
            while (reader.Read())
            {
                ClienteCompras = new ConsultasMarketingBE();
                ClienteCompras.Tickets = Int32.Parse(reader["Tickets"].ToString());
                ClienteCompras.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                ClienteCompras.Tienda = reader["Tienda"].ToString();
                ClienteCompras.TipoCliente = reader["TipoCliente"].ToString();
                ClienteCompras.Cliente = reader["Cliente"].ToString();
                ClienteCompras.Distrito = reader["Distrito"].ToString();
                ClienteCompras.Direccion = reader["Direccion"].ToString();
                ClienteCompras.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ClienteCompras.FechaNac = reader.IsDBNull(reader.GetOrdinal("FechaNac")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaNac"));
                ClienteCompras.TipoPersona = reader["TipoPersona"].ToString();
                ClienteCompras.Celular = reader["Celular"].ToString();
                ClienteCompras.Telefono = reader["Telefono"].ToString();
                ClienteCompras.Email = reader["Email"].ToString();
                ClienteCompras.TotalSoles = Decimal.Parse(reader["TotalSoles"].ToString());
                ClienteCompraslist.Add(ClienteCompras);
            }
            reader.Close();
            reader.Dispose();
            return ClienteCompraslist;
        }
        public List<ConsultasMarketingBE> ProductosCompras(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("SP_Productos_Compras");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ConsultasMarketingBE> ProductosCompraslist = new List<ConsultasMarketingBE>();
            ConsultasMarketingBE ProductosCompras;
            while (reader.Read())
            {
                ProductosCompras = new ConsultasMarketingBE();
                ProductosCompras.IdProducto = Int32.Parse(reader["IdProducto"].ToString());
                ProductosCompras.NombreProducto = reader["NombreProducto"].ToString();
                ProductosCompras.LineaProducto = reader["LineaProducto"].ToString();
                ProductosCompras.CodigoProveedor = reader["CodigoProveedor"].ToString();
                ProductosCompras.Cantidad = Int32.Parse(reader["Cantidad"].ToString());
                ProductosCompras.ValorVenta = Decimal.Parse(reader["ValorVenta"].ToString());
                ProductosCompraslist.Add(ProductosCompras);
            }
            reader.Close();
            reader.Dispose();
            return ProductosCompraslist;
        }
    }
}

