using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class Dis_ContratoFabricacionDL
    {
        public Dis_ContratoFabricacionDL() { }

        public Int32 Inserta(Dis_ContratoFabricacionBE pItem)
        {
            Int32 intIdCliente = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_Inserta");

            db.AddOutParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, pItem.IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdVendedor2", DbType.Int32, pItem.IdVendedor2);
            db.AddInParameter(dbCommand, "pFechaEntrega", DbType.DateTime, pItem.FechaEntrega);
            db.AddInParameter(dbCommand, "pFechaProduccion", DbType.DateTime, pItem.FechaProduccion);
            db.AddInParameter(dbCommand, "pIdProyecto", DbType.Int32, pItem.IdProyecto);
            db.AddInParameter(dbCommand, "pPiso", DbType.Int32, pItem.Piso);
            db.AddInParameter(dbCommand, "pRutaArchivo", DbType.String, pItem.RutaArchivo);
            db.AddInParameter(dbCommand, "pPorcentajeAvance", DbType.Decimal, pItem.PorcentajeAvance);
            db.AddInParameter(dbCommand, "pFlagCerrado", DbType.Boolean, pItem.FlagCerrado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdCliente = (int)db.GetParameterValue(dbCommand, "pIdDis_ContratoFabricacion");

            return intIdCliente;
        }

        public void Actualiza(Dis_ContratoFabricacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_Actualiza");

            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, pItem.IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pFecha", DbType.DateTime, pItem.Fecha);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pDescCliente", DbType.String, pItem.DescCliente);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdVendedor2", DbType.Int32, pItem.IdVendedor2);
            db.AddInParameter(dbCommand, "pFechaEntrega", DbType.DateTime, pItem.FechaEntrega);
            db.AddInParameter(dbCommand, "pFechaProduccion", DbType.DateTime, pItem.FechaProduccion);
            db.AddInParameter(dbCommand, "pIdProyecto", DbType.Int32, pItem.IdProyecto);
            db.AddInParameter(dbCommand, "pPiso", DbType.Int32, pItem.Piso);
            db.AddInParameter(dbCommand, "pRutaArchivo", DbType.String, pItem.RutaArchivo);
            db.AddInParameter(dbCommand, "pPorcentajeAvance", DbType.Decimal, pItem.PorcentajeAvance);
            db.AddInParameter(dbCommand, "pFlagCerrado", DbType.Boolean, pItem.FlagCerrado);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(Dis_ContratoFabricacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_Elimina");

            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, pItem.IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<Dis_ContratoFabricacionBE> ListaTodosActivo(int IdEmpresa, int IdVendedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, IdVendedor);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_ContratoFabricacionBE> Dis_ContratoFabricacionlist = new List<Dis_ContratoFabricacionBE>();
            Dis_ContratoFabricacionBE Dis_ContratoFabricacion;
            while (reader.Read())
            {
                Dis_ContratoFabricacion = new Dis_ContratoFabricacionBE();
                Dis_ContratoFabricacion.IdDis_ContratoFabricacion = Int32.Parse(reader["IdDis_ContratoFabricacion"].ToString());
                Dis_ContratoFabricacion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_ContratoFabricacion.Numero = reader["Numero"].ToString();
                Dis_ContratoFabricacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Dis_ContratoFabricacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Dis_ContratoFabricacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Dis_ContratoFabricacion.DescCliente = reader["DescCliente"].ToString();
                Dis_ContratoFabricacion.Direccion = reader["Direccion"].ToString();
                Dis_ContratoFabricacion.Referencia = reader["Referencia"].ToString();
                Dis_ContratoFabricacion.Email = reader["Email"].ToString();
                Dis_ContratoFabricacion.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Dis_ContratoFabricacion.DescVendedor = reader["DescVendedor"].ToString();
                Dis_ContratoFabricacion.IdVendedor2 = reader.IsDBNull(reader.GetOrdinal("IdVendedor2")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdVendedor2"));
                Dis_ContratoFabricacion.DescVendedor2 = reader["DescVendedor2"].ToString();
                //Dis_ContratoFabricacion.FechaEntrega =DateTime.Parse(reader["FechaEntrega"].ToString());
                //Dis_ContratoFabricacion.IdProyecto = Int32.Parse(reader["IdProyecto"].ToString());

                Dis_ContratoFabricacion.FechaEntrega = reader.IsDBNull(reader.GetOrdinal("FechaEntrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEntrega"));
                Dis_ContratoFabricacion.FechaProduccion = reader.IsDBNull(reader.GetOrdinal("FechaProduccion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaProduccion"));
                Dis_ContratoFabricacion.IdProyecto = reader.IsDBNull(reader.GetOrdinal("IdProyecto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProyecto"));
                Dis_ContratoFabricacion.NumeroProyecto = reader["NumeroProyecto"].ToString();
                Dis_ContratoFabricacion.PorcentajeAvance = Decimal.Parse(reader["PorcentajeAvance"].ToString());
                Dis_ContratoFabricacion.FechaCotizacion = reader.IsDBNull(reader.GetOrdinal("FechaCotizacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaCotizacion"));
                Dis_ContratoFabricacion.FechaPrimerAbono = reader.IsDBNull(reader.GetOrdinal("FechaPrimerAbono")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPrimerAbono"));
                Dis_ContratoFabricacion.FechaAtencion = reader.IsDBNull(reader.GetOrdinal("FechaAtencion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAtencion"));
                Dis_ContratoFabricacion.UsuarioAtencion = reader["UsuarioAtencion"].ToString();
                Dis_ContratoFabricacion.FlagCerrado = Boolean.Parse(reader["FlagCerrado"].ToString());
                Dis_ContratoFabricacion.Distrito = reader["Distrito"].ToString();
                Dis_ContratoFabricacion.TotalPedido = Decimal.Parse(reader["TotalPedido"].ToString());
                Dis_ContratoFabricacion.TotalContrato= Decimal.Parse(reader["TotalContrato"].ToString());
                Dis_ContratoFabricacion.FechaPedido = reader.IsDBNull(reader.GetOrdinal("FechaPedido")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPedido"));
                Dis_ContratoFabricacion.FlagInstalaTermina = Boolean.Parse(reader["FlagInstalaTermina"].ToString());
                Dis_ContratoFabricacion.FlagEncuestaPostVenta = Boolean.Parse(reader["FlagEncuestaPostVenta"].ToString());
                Dis_ContratoFabricacion.FlagConforme = Boolean.Parse(reader["FlagConforme"].ToString());
                Dis_ContratoFabricacion.FlagEncuestaCerrada = Boolean.Parse(reader["FlagEncuestaCerrada"].ToString());
                Dis_ContratoFabricacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_ContratoFabricacionlist.Add(Dis_ContratoFabricacion);
            }
            reader.Close();
            reader.Dispose();
            return Dis_ContratoFabricacionlist;
        }

        public List<Dis_ContratoFabricacionBE> ListaProyecto(int IdEmpresa, int IdProyecto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_ListaProyecto");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdProyecto", DbType.Int32, IdProyecto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_ContratoFabricacionBE> Dis_ContratoFabricacionlist = new List<Dis_ContratoFabricacionBE>();
            Dis_ContratoFabricacionBE Dis_ContratoFabricacion;
            while (reader.Read())
            {
                Dis_ContratoFabricacion = new Dis_ContratoFabricacionBE();
                Dis_ContratoFabricacion.IdDis_ContratoFabricacion = Int32.Parse(reader["IdDis_ContratoFabricacion"].ToString());
                Dis_ContratoFabricacion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_ContratoFabricacion.Numero = reader["Numero"].ToString();
                Dis_ContratoFabricacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Dis_ContratoFabricacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Dis_ContratoFabricacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Dis_ContratoFabricacion.DescCliente = reader["DescCliente"].ToString();
                Dis_ContratoFabricacion.Direccion = reader["Direccion"].ToString();
                Dis_ContratoFabricacion.Referencia = reader["Referencia"].ToString();
                Dis_ContratoFabricacion.Email = reader["Email"].ToString();
                Dis_ContratoFabricacion.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Dis_ContratoFabricacion.DescVendedor = reader["DescVendedor"].ToString();
                Dis_ContratoFabricacion.IdVendedor2 = reader.IsDBNull(reader.GetOrdinal("IdVendedor2")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdVendedor2"));
                Dis_ContratoFabricacion.DescVendedor2 = reader["DescVendedor2"].ToString();
                Dis_ContratoFabricacion.FechaEntrega = reader.IsDBNull(reader.GetOrdinal("FechaEntrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEntrega"));
                Dis_ContratoFabricacion.FechaProduccion = reader.IsDBNull(reader.GetOrdinal("FechaProduccion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaProduccion"));
                Dis_ContratoFabricacion.FechaAtencion = reader.IsDBNull(reader.GetOrdinal("FechaAtencion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAtencion"));
                Dis_ContratoFabricacion.IdProyecto = reader.IsDBNull(reader.GetOrdinal("IdProyecto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProyecto"));
                Dis_ContratoFabricacion.NumeroProyecto = reader["NumeroProyecto"].ToString();
                Dis_ContratoFabricacion.Piso = Int32.Parse(reader["Piso"].ToString());
                Dis_ContratoFabricacion.RutaArchivo = reader["RutaArchivo"].ToString();
                Dis_ContratoFabricacion.UsuarioAtencion = reader["UsuarioAtencion"].ToString();
                Dis_ContratoFabricacion.FlagCerrado = Boolean.Parse(reader["FlagCerrado"].ToString());
                Dis_ContratoFabricacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_ContratoFabricacionlist.Add(Dis_ContratoFabricacion);
            }
            reader.Close();
            reader.Dispose();
            return Dis_ContratoFabricacionlist;
        }

        public List<Dis_ContratoFabricacionBE> ListaTracking(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_ListaTracking");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<Dis_ContratoFabricacionBE> Dis_ContratoFabricacionlist = new List<Dis_ContratoFabricacionBE>();
            Dis_ContratoFabricacionBE Dis_ContratoFabricacion;
            while (reader.Read())
            {
                Dis_ContratoFabricacion = new Dis_ContratoFabricacionBE();
                Dis_ContratoFabricacion.IdDis_ContratoFabricacion = Int32.Parse(reader["IdDis_ContratoFabricacion"].ToString());
                Dis_ContratoFabricacion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_ContratoFabricacion.NumeroProyecto = reader["NumeroProyecto"].ToString();
                Dis_ContratoFabricacion.FechaProyecto = reader.IsDBNull(reader.GetOrdinal("FechaProyecto")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaProyecto"));

                Dis_ContratoFabricacion.FechaVencimiento = reader.IsDBNull(reader.GetOrdinal("FechaVencimiento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVencimiento")); 
                Dis_ContratoFabricacion.FechaVisita = reader.IsDBNull(reader.GetOrdinal("FechaVisita")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaVisita"));
                Dis_ContratoFabricacion.EncuestaVisita = reader["EncuestaVisita"].ToString();
                Dis_ContratoFabricacion.NumeroContrato = reader["NumeroContrato"].ToString();
                Dis_ContratoFabricacion.FechaContrato = DateTime.Parse(reader["FechaContrato"].ToString());
                Dis_ContratoFabricacion.FechaAprueba = reader.IsDBNull(reader.GetOrdinal("FechaAprueba")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAprueba"));
                Dis_ContratoFabricacion.FechaPresupuesto = reader.IsDBNull(reader.GetOrdinal("FechaPresupuesto")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaPresupuesto"));
                Dis_ContratoFabricacion.FechaApPresupuesto = reader.IsDBNull(reader.GetOrdinal("FechaApPresupuesto")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaApPresupuesto"));
                Dis_ContratoFabricacion.FechaFabricacion = reader.IsDBNull(reader.GetOrdinal("FechaFabricacion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaFabricacion"));
                Dis_ContratoFabricacion.FechaEntrega = reader.IsDBNull(reader.GetOrdinal("FechaEntrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEntrega"));
                Dis_ContratoFabricacion.FechaProduccion = reader.IsDBNull(reader.GetOrdinal("FechaProduccion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaProduccion"));
                Dis_ContratoFabricacion.PorcentajeAvance = Int32.Parse(reader["PorcentajeAvance"].ToString());
                Dis_ContratoFabricacion.EncuestaFinal = reader["EncuestaFinal"].ToString();
                Dis_ContratoFabricacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Dis_ContratoFabricacion.DescCliente = reader["DescCliente"].ToString();
                Dis_ContratoFabricacion.Direccion = reader["Direccion"].ToString();
                Dis_ContratoFabricacion.Referencia = reader["Referencia"].ToString();
                Dis_ContratoFabricacion.Email = reader["Email"].ToString();
                //Dis_ContratoFabricacion.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Dis_ContratoFabricacion.DescVendedor = reader["DescVendedor"].ToString();
                //Dis_ContratoFabricacion.IdVendedor2 = reader.IsDBNull(reader.GetOrdinal("IdVendedor2")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdVendedor2"));
                Dis_ContratoFabricacion.DescVendedor2 = reader["DescVendedor2"].ToString();
                Dis_ContratoFabricacion.Piso = Int32.Parse(reader["Piso"].ToString());
                Dis_ContratoFabricacion.RutaArchivo = reader["RutaArchivo"].ToString();
                //Dis_ContratoFabricacion.FlagCerrado = Boolean.Parse(reader["FlagCerrado"].ToString());

                //Dis_ContratoFabricacion.FechaEntrega = reader.IsDBNull(reader.GetOrdinal("FechaEntrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEntrega"));
                Dis_ContratoFabricacion.IdProyecto = reader.IsDBNull(reader.GetOrdinal("IdProyecto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProyecto"));
                Dis_ContratoFabricacion.NumeroProyecto = reader["NumeroProyecto"].ToString();
                Dis_ContratoFabricacion.DescSituacion = reader["DescSituacion"].ToString();
                Dis_ContratoFabricacion.FlagCerrado = Boolean.Parse(reader["FlagCerrado"].ToString());
                Dis_ContratoFabricacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Dis_ContratoFabricacionlist.Add(Dis_ContratoFabricacion);
            }
            reader.Close();
            reader.Dispose();
            return Dis_ContratoFabricacionlist;
        }

        public Dis_ContratoFabricacionBE Selecciona(int IdDis_ContratoFabricacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_Selecciona");
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, IdDis_ContratoFabricacion);
            IDataReader reader = db.ExecuteReader(dbCommand);

            Dis_ContratoFabricacionBE Dis_ContratoFabricacion = null;
            while (reader.Read())
            {
                Dis_ContratoFabricacion = new Dis_ContratoFabricacionBE();
                Dis_ContratoFabricacion.IdDis_ContratoFabricacion = Int32.Parse(reader["IdDis_ContratoFabricacion"].ToString());
                Dis_ContratoFabricacion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_ContratoFabricacion.Numero = reader["Numero"].ToString();
                Dis_ContratoFabricacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Dis_ContratoFabricacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Dis_ContratoFabricacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Dis_ContratoFabricacion.DescCliente = reader["DescCliente"].ToString();
                Dis_ContratoFabricacion.Direccion = reader["Direccion"].ToString();
                Dis_ContratoFabricacion.Referencia = reader["Referencia"].ToString();
                Dis_ContratoFabricacion.Email = reader["Email"].ToString();
                Dis_ContratoFabricacion.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Dis_ContratoFabricacion.DescVendedor = reader["DescVendedor"].ToString();
                Dis_ContratoFabricacion.IdVendedor2 = reader.IsDBNull(reader.GetOrdinal("IdVendedor2")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdVendedor2"));
                Dis_ContratoFabricacion.DescVendedor2 = reader["DescVendedor2"].ToString();
                Dis_ContratoFabricacion.FechaEntrega = reader.IsDBNull(reader.GetOrdinal("FechaEntrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEntrega"));
                Dis_ContratoFabricacion.FechaProduccion = reader.IsDBNull(reader.GetOrdinal("FechaProduccion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaProduccion"));
                Dis_ContratoFabricacion.FechaAtencion = reader.IsDBNull(reader.GetOrdinal("FechaAtencion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaAtencion"));
                Dis_ContratoFabricacion.IdProyecto = reader.IsDBNull(reader.GetOrdinal("IdProyecto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProyecto"));
                Dis_ContratoFabricacion.NumeroProyecto = reader["NumeroProyecto"].ToString();
                Dis_ContratoFabricacion.Piso = Int32.Parse(reader["Piso"].ToString());
                Dis_ContratoFabricacion.RutaArchivo = reader["RutaArchivo"].ToString();
                Dis_ContratoFabricacion.UsuarioAtencion = reader["UsuarioAtencion"].ToString();
                Dis_ContratoFabricacion.FlagCerrado = Boolean.Parse(reader["FlagCerrado"].ToString());
                Dis_ContratoFabricacion.FlagInstalaTermina = Boolean.Parse(reader["FlagInstalaTermina"].ToString());
                Dis_ContratoFabricacion.FlagEncuestaPostVenta = Boolean.Parse(reader["FlagEncuestaPostVenta"].ToString());
                Dis_ContratoFabricacion.FlagConforme = Boolean.Parse(reader["FlagConforme"].ToString());
                Dis_ContratoFabricacion.FlagEncuestaCerrada = Boolean.Parse(reader["FlagEncuestaCerrada"].ToString());
                Dis_ContratoFabricacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Dis_ContratoFabricacion;
        }

        public Dis_ContratoFabricacionBE SeleccionaNumero(int Periodo, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);
            IDataReader reader = db.ExecuteReader(dbCommand);

            Dis_ContratoFabricacionBE Dis_ContratoFabricacion = null;
            while (reader.Read())
            {
                Dis_ContratoFabricacion = new Dis_ContratoFabricacionBE();
                Dis_ContratoFabricacion.IdDis_ContratoFabricacion = Int32.Parse(reader["IdDis_ContratoFabricacion"].ToString());
                Dis_ContratoFabricacion.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Dis_ContratoFabricacion.Numero = reader["Numero"].ToString();
                Dis_ContratoFabricacion.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                Dis_ContratoFabricacion.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                Dis_ContratoFabricacion.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Dis_ContratoFabricacion.DescCliente = reader["DescCliente"].ToString();
                Dis_ContratoFabricacion.Direccion = reader["Direccion"].ToString();
                Dis_ContratoFabricacion.Referencia = reader["Referencia"].ToString();
                Dis_ContratoFabricacion.Email = reader["Email"].ToString();
                Dis_ContratoFabricacion.IdVendedor = Int32.Parse(reader["IdVendedor"].ToString());
                Dis_ContratoFabricacion.DescVendedor = reader["DescVendedor"].ToString();
                Dis_ContratoFabricacion.IdVendedor2 = reader.IsDBNull(reader.GetOrdinal("IdVendedor2")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdVendedor2"));
                Dis_ContratoFabricacion.DescVendedor2 = reader["DescVendedor2"].ToString();
                Dis_ContratoFabricacion.FechaEntrega = reader.IsDBNull(reader.GetOrdinal("FechaEntrega")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaEntrega"));
                Dis_ContratoFabricacion.FechaProduccion = reader.IsDBNull(reader.GetOrdinal("FechaProduccion")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaProduccion"));
                Dis_ContratoFabricacion.IdProyecto = reader.IsDBNull(reader.GetOrdinal("IdProyecto")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("IdProyecto"));
                Dis_ContratoFabricacion.NumeroProyecto = reader["NumeroProyecto"].ToString();
                Dis_ContratoFabricacion.Piso = Int32.Parse(reader["Piso"].ToString());
                Dis_ContratoFabricacion.RutaArchivo = reader["RutaArchivo"].ToString();
                Dis_ContratoFabricacion.FlagCerrado = Boolean.Parse(reader["FlagCerrado"].ToString());
                Dis_ContratoFabricacion.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Dis_ContratoFabricacion;
        }

        public void ActualizaCerrado(int IdDis_ContratoFabricacion, bool FlagCerrado)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_ActualizaCerrado");

            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pFlagCerrado", DbType.Int32, FlagCerrado);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaAtender(int IdDis_ContratoFabricacion, string Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_ActualizaAtender");

            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, Usuario);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void ActualizaEncuesta(Dis_ContratoFabricacionBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Dis_ContratoFabricacion_ActualizaEncuesta");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdDis_ContratoFabricacion", DbType.Int32, pItem.IdDis_ContratoFabricacion);
            db.AddInParameter(dbCommand, "pFlagInstalaTermina", DbType.Boolean, pItem.FlagInstalaTermina);
            db.AddInParameter(dbCommand, "pFlagEncuestaPostVenta", DbType.Boolean, pItem.FlagEncuestaPostVenta);
            db.AddInParameter(dbCommand, "pFlagConforme", DbType.Boolean, pItem.FlagConforme);
            db.AddInParameter(dbCommand, "pFlagEncuestaCerrada", DbType.Boolean, pItem.FlagEncuestaCerrada);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

    }
}
