using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class SolicitudEgresoDL
    {
        public SolicitudEgresoDL() { }

        public Int32 Inserta(SolicitudEgresoBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Inserta");

            db.AddOutParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
            db.AddInParameter(dbCommand, "pNumSolicitudEgreso", DbType.String, pItem.NumSolicitudEgreso);
            db.AddInParameter(dbCommand, "pFechaSolicitudEgreso", DbType.DateTime, pItem.FechaSolicitudEgreso);
            db.AddInParameter(dbCommand, "pDescSolicitudEgreso", DbType.String, pItem.DescSolicitudEgreso);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pNumOCompra", DbType.String, pItem.NumOCompra);

            db.AddInParameter(dbCommand, "pNroAbonoInicio", DbType.Int32, pItem.NroAbonoInicio);
            db.AddInParameter(dbCommand, "pNroAbonoFin", DbType.Int32, pItem.NroAbonoFin);

            db.AddInParameter(dbCommand, "pIdTipoEgreso", DbType.Int32, pItem.IdTipoEgreso);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);

            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pRazonSocialFactura", DbType.String, pItem.RazonSocialFactura);

            db.AddInParameter(dbCommand, "pIdCentroCosto", DbType.Int32, pItem.IdCentroCosto);
            db.AddInParameter(dbCommand, "pIdDetalleCentroCosto", DbType.Int32, pItem.IdDetalleCentroCosto);
            db.AddInParameter(dbCommand, "pObs", DbType.String, pItem.Obs);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            db.AddInParameter(dbCommand, "pCuentaContable", DbType.String, pItem.CuentaContable);
            db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);

            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdSolicitudEgreso");

            return Id;
        }

        public void EliminaDetalle(SolicitudEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Elimina");

            db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void AnulaSolicitud(SolicitudEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_AnulaSolicitud");

            db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<SolicitudEgresoBE> ListaTodosActivo(DateTime pFechaInicio, DateTime pFechaFin, int pIdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.Date, pFechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.Date, pFechaFin);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pIdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEgresoBE> DocumentoBultolist = new List<SolicitudEgresoBE>();
            SolicitudEgresoBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new SolicitudEgresoBE();

                SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
                SolicitudEgreso.NumSolicitudEgreso =  (reader["NumSolicitudEgreso"].ToString());
                SolicitudEgreso.FechaSolicitudEgreso = DateTime.Parse( reader["FechaSolicitudEgreso"].ToString());
                SolicitudEgreso.DescSolicitudEgreso =  reader["DescSolicitudEgreso"].ToString();

                SolicitudEgreso.NumeroDocumento = reader["NumeroDocumento"].ToString();
                SolicitudEgreso.DescProveedor = reader["DescProveedor"].ToString();

                SolicitudEgreso.DescBanco = reader["DescBanco"].ToString();
                SolicitudEgreso.Cuenta = reader["Cuenta"].ToString();
                SolicitudEgreso.Moneda = reader["Moneda"].ToString();
                SolicitudEgreso.Solicita = reader["Solicita"].ToString();
                SolicitudEgreso.NumOCompra = reader["NumOCompra"].ToString();
                SolicitudEgreso.NroAbonos = reader["NroAbonos"].ToString();

                SolicitudEgreso.TipoEgreso = reader["TipoEgreso"].ToString();

                SolicitudEgreso.Tienda = reader["Tienda"].ToString();
                SolicitudEgreso.RazonSocialFactura = reader["RazonSocialFactura"].ToString();
                SolicitudEgreso.CentroCosto = reader["CentroCosto"].ToString();
                SolicitudEgreso.Asignar = reader["Asignar"].ToString();
                SolicitudEgreso.Obs = reader["Obs"].ToString();

                SolicitudEgreso.Total = Decimal.Parse(reader["Total"].ToString());
                SolicitudEgreso.Usuario = reader["Usuario"].ToString();
                SolicitudEgreso.Situacion = reader["Situacion"].ToString();

                SolicitudEgreso.Telefono = reader["Telefono"].ToString();
                SolicitudEgreso.Correo = reader["Correo"].ToString();

                DocumentoBultolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoBultolist;
        }

        public List<SolicitudEgresoBE> BuscarSolicitud(string pNumero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_BuscarNumeroSolicitud");
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pNumero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEgresoBE> DocumentoBultolist = new List<SolicitudEgresoBE>();
            SolicitudEgresoBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new SolicitudEgresoBE();

                SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
                SolicitudEgreso.NumSolicitudEgreso = (reader["NumSolicitudEgreso"].ToString());
                SolicitudEgreso.FechaSolicitudEgreso = DateTime.Parse(reader["FechaSolicitudEgreso"].ToString());
                SolicitudEgreso.DescSolicitudEgreso = reader["DescSolicitudEgreso"].ToString();

                SolicitudEgreso.NumeroDocumento = reader["NumeroDocumento"].ToString();
                SolicitudEgreso.DescProveedor = reader["DescProveedor"].ToString();

                SolicitudEgreso.DescBanco = reader["DescBanco"].ToString();
                SolicitudEgreso.Cuenta = reader["Cuenta"].ToString();
                SolicitudEgreso.Moneda = reader["Moneda"].ToString();
                SolicitudEgreso.Solicita = reader["Solicita"].ToString();
                SolicitudEgreso.NumOCompra = reader["NumOCompra"].ToString();
                SolicitudEgreso.NroAbonos = reader["NroAbonos"].ToString();

                SolicitudEgreso.TipoEgreso = reader["TipoEgreso"].ToString();

                SolicitudEgreso.Tienda = reader["Tienda"].ToString();
                SolicitudEgreso.RazonSocialFactura = reader["RazonSocialFactura"].ToString();
                SolicitudEgreso.CentroCosto = reader["CentroCosto"].ToString();
                SolicitudEgreso.Asignar = reader["Asignar"].ToString();
                SolicitudEgreso.Obs = reader["Obs"].ToString();

                SolicitudEgreso.Total = Decimal.Parse(reader["Total"].ToString());
                SolicitudEgreso.Usuario = reader["Usuario"].ToString();
                SolicitudEgreso.Situacion = reader["Situacion"].ToString();

                SolicitudEgreso.Telefono = reader["Telefono"].ToString();
                SolicitudEgreso.Correo = reader["Correo"].ToString();

                DocumentoBultolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoBultolist;
        }
        public List<SolicitudEgresoBE> ObtenerCorrelativoPeriodo(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionSolicitud_ObtenerCorrelativoPeriodo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEgresoBE> NumeracionDocumentolist = new List<SolicitudEgresoBE>();
            SolicitudEgresoBE NumeracionDocumento;
            while (reader.Read())
            {
                NumeracionDocumento = new SolicitudEgresoBE();
                NumeracionDocumento.Numero = Int32.Parse( reader["NumeroSolicitudEgreso"].ToString());
                NumeracionDocumentolist.Add(NumeracionDocumento);
            }
            reader.Close();
            reader.Dispose();
            return NumeracionDocumentolist;

        }

        public SolicitudEgresoBE Buscar_SolicitudEgreso(int IdSolicitudEgreso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Buscar");
            db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, IdSolicitudEgreso);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudEgresoBE SolicitudEgreso = null;
            while (reader.Read())
            {
                SolicitudEgreso = new SolicitudEgresoBE();

                SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
                SolicitudEgreso.NumSolicitudEgreso = (reader["NumSolicitudEgreso"].ToString());
                SolicitudEgreso.FechaSolicitudEgreso = DateTime.Parse(reader["FechaSolicitudEgreso"].ToString());
                SolicitudEgreso.DescSolicitudEgreso = reader["DescSolicitudEgreso"].ToString();

                SolicitudEgreso.NumeroDocumento = reader["NumeroDocumento"].ToString();

                SolicitudEgreso.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                SolicitudEgreso.DescProveedor = reader["DescProveedor"].ToString();

                SolicitudEgreso.IdBanco = Int32.Parse(reader["IdBanco"].ToString());

                SolicitudEgreso.DescBanco = reader["DescBanco"].ToString();
                SolicitudEgreso.Cuenta = reader["Cuenta"].ToString();
                SolicitudEgreso.CCI = reader["CCI"].ToString();
                SolicitudEgreso.Moneda = reader["Moneda"].ToString();
                SolicitudEgreso.IdMoneda = Int32.Parse( reader["IdMoneda"].ToString());

                SolicitudEgreso.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEgreso.Solicita = reader["Solicita"].ToString();
                SolicitudEgreso.NumOCompra = reader["NumOCompra"].ToString();

                SolicitudEgreso.NroAbonoInicio = Int32.Parse(reader["NroAbonoInicio"].ToString());
                SolicitudEgreso.NroAbonoFin = Int32.Parse(reader["NroAbonoFin"].ToString());
                SolicitudEgreso.NroAbonos = reader["NroAbonos"].ToString();

                SolicitudEgreso.IdTipoEgreso = Int32.Parse(reader["IdTipoEgreso"].ToString());
                SolicitudEgreso.TipoEgreso = reader["TipoEgreso"].ToString();

                SolicitudEgreso.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                SolicitudEgreso.Tienda = reader["Tienda"].ToString();

                SolicitudEgreso.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                SolicitudEgreso.RazonSocialFactura = reader["DescCliente"].ToString();

                SolicitudEgreso.IdCentroCosto = Int32.Parse(reader["IdCentroCosto"].ToString());
                SolicitudEgreso.CentroCosto = reader["CentroCosto"].ToString();

                SolicitudEgreso.IdDetalleCentroCosto = Int32.Parse(reader["IdDetalleCentroCosto"].ToString());
                SolicitudEgreso.Asignar = reader["Asignar"].ToString();

                SolicitudEgreso.Obs = reader["Obs"].ToString();

                SolicitudEgreso.Total = Decimal.Parse(reader["Total"].ToString());
                SolicitudEgreso.Usuario = reader["Usuario"].ToString();
                SolicitudEgreso.Situacion = reader["Situacion"].ToString();

                SolicitudEgreso.Telefono = reader["Telefono"].ToString();
                SolicitudEgreso.Correo = reader["Correo"].ToString();

                SolicitudEgreso.CuentaContable = reader["cuentacontable"].ToString();
                SolicitudEgreso.TCambio = Decimal.Parse(reader["TCambio"].ToString());

                SolicitudEgreso.Procedencia = Int32.Parse(reader["Procedencia"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEgreso;
        }


        public SolicitudEgresoBE Buscar_Recibo(string NumRecibo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CajaEgreso_BuscarRecibo");
            db.AddInParameter(dbCommand, "pNumRecibo", DbType.String, NumRecibo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudEgresoBE SolicitudEgreso = null;
            while (reader.Read())
            {
                SolicitudEgreso = new SolicitudEgresoBE();
                SolicitudEgreso.Recibo = reader["Recibo"].ToString();          
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEgreso;
        }


        public SolicitudEgresoBE TotalPendientePago(DateTime pFechaInicio, DateTime pFechaFin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConsultaPagosPendientesSolicitudes");
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pFechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pFechaFin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SolicitudEgresoBE SolicitudEgreso = null;
            while (reader.Read())
            {
                SolicitudEgreso = new SolicitudEgresoBE();

                SolicitudEgreso.Panorama = Decimal.Parse(reader["Panorama"].ToString());
                SolicitudEgreso.Decoratex = Decimal.Parse(reader["Decoratex"].ToString());

                SolicitudEgreso.PanoramaD = Decimal.Parse(reader["PanoramaD"].ToString());
                SolicitudEgreso.DecoratexD = Decimal.Parse(reader["DecoratexD"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEgreso;
        }

        public List<SolicitudEgresoBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_ListaFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEgresoBE> PrestamoBancolist = new List<SolicitudEgresoBE>();
            SolicitudEgresoBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new SolicitudEgresoBE();
                SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
                SolicitudEgreso.FechaAPagar = DateTime.Parse(reader["FechaAPagar"].ToString());
                SolicitudEgreso.NumSolicitudEgreso = reader["NumSolicitudEgreso"].ToString();

                SolicitudEgreso.Solicita = reader["Solicita"].ToString();

                SolicitudEgreso.DescProveedor = reader["Proveedor"].ToString();
                SolicitudEgreso.DescBanco = reader["DescBanco"].ToString();
                SolicitudEgreso.Cuenta = reader["Cuenta"].ToString();
                SolicitudEgreso.RazonSocialFactura = reader["RazonSocialAFacturar"].ToString();
                SolicitudEgreso.DescMoneda = reader["Moneda"].ToString();
                SolicitudEgreso.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());
                SolicitudEgreso.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));

                SolicitudEgreso.UsuarioPago = reader["UsuarioPago"].ToString();

                SolicitudEgreso.CentroCosto = reader["CentroCosto"].ToString();
                SolicitudEgreso.Asignar = reader["Area"].ToString();
                SolicitudEgreso.Tienda = reader["Tienda"].ToString();
                SolicitudEgreso.TipoEgreso = reader["TipoEgreso"].ToString();
                SolicitudEgreso.Situacion = reader["Situacion"].ToString();

                SolicitudEgreso.DescProcedencia = reader["DescProcedencia"].ToString();

                PrestamoBancolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }

        public List<SolicitudEgresoBE> ListaFechaCajaChica(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_ListaFechaCajaChica");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SolicitudEgresoBE> PrestamoBancolist = new List<SolicitudEgresoBE>();
            SolicitudEgresoBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new SolicitudEgresoBE();
                //   SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
                SolicitudEgreso.NombreCaja = reader["NombreCaja"].ToString();
                SolicitudEgreso.NumSolicitudEgreso = reader["NumSolicitud"].ToString();
                SolicitudEgreso.Solicita = reader["Recibio"].ToString();
                SolicitudEgreso.TipoDocumento = reader["TipoDocumento"].ToString();
                SolicitudEgreso.RucProveedor = reader["Ruc"].ToString();
                SolicitudEgreso.DescProveedor = reader["Proveedor"].ToString();
                SolicitudEgreso.RazonSocialFactura = reader["RazonSocialAFacturar"].ToString();

                SolicitudEgreso.CentroCosto = reader["CentroCosto"].ToString();
                SolicitudEgreso.Asignar = reader["Area"].ToString();
                SolicitudEgreso.Tienda = reader["Tienda"].ToString();
                SolicitudEgreso.TipoEgreso = reader["TipoEgreso"].ToString();
                SolicitudEgreso.DescMoneda = reader["Moneda"].ToString();
                SolicitudEgreso.MontoAbono = Decimal.Parse(reader["Monto"].ToString());

                SolicitudEgreso.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaSolicitud")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaSolicitud"));

               // SolicitudEgreso.FechaAPagar = DateTime.Parse(reader["FechaAPagar"].ToString());

                PrestamoBancolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }


        public void Actualiza(SolicitudEgresoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Actualiza");

            db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
            db.AddInParameter(dbCommand, "pDescSolicitudEgreso", DbType.String, pItem.DescSolicitudEgreso);
            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pNumOCompra", DbType.String, pItem.NumOCompra);

            db.AddInParameter(dbCommand, "pNroAbonoInicio", DbType.Int32, pItem.NroAbonoInicio);
            db.AddInParameter(dbCommand, "pNroAbonoFin", DbType.Int32, pItem.NroAbonoFin);

            db.AddInParameter(dbCommand, "pIdTipoEgreso", DbType.Int32, pItem.IdTipoEgreso);
            db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);

            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pRazonSocialFactura", DbType.String, pItem.RazonSocialFactura);

            db.AddInParameter(dbCommand, "pIdCentroCosto", DbType.Int32, pItem.IdCentroCosto);
            db.AddInParameter(dbCommand, "pIdDetalleCentroCosto", DbType.Int32, pItem.IdDetalleCentroCosto);
            db.AddInParameter(dbCommand, "pObs", DbType.String, pItem.Obs);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);

            db.AddInParameter(dbCommand, "pCuentaContable", DbType.String, pItem.CuentaContable);
            db.AddInParameter(dbCommand, "pTCambio", DbType.Decimal, pItem.TCambio);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}
