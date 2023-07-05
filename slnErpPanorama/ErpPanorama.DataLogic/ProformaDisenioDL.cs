using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class ProformaDisenioDL
    {
        public ProformaDisenioDL() { }

        public Int32 Inserta(ProformaDisenioBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProformaDisenio_Inserta");

            db.AddOutParameter(dbCommand, "pIdProformaDisenio", DbType.Int32, pItem.IdProformaDisenio);
            db.AddInParameter(dbCommand, "pNumProformaDisenio", DbType.String, pItem.NumProformaDisenio);
            db.AddInParameter(dbCommand, "pFechaProformaDisenio", DbType.Date, pItem.FechaProformaDisenio);
            db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pDireccionCliente", DbType.String, pItem.DireccionCliente);
            db.AddInParameter(dbCommand, "pCorreoEnvio", DbType.String, pItem.CorreoEnvio);
            db.AddInParameter(dbCommand, "pReferencia", DbType.String, pItem.Referencia);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdAsesor);
            db.AddInParameter(dbCommand, "pIdVendedor", DbType.Int32, pItem.IdVendedor);
            db.AddInParameter(dbCommand, "pIdTipoProformaDisenio", DbType.Int32, pItem.IdTipoProformaDisenio);
            db.AddInParameter(dbCommand, "pUsuarioCreacion", DbType.String, pItem.UsuarioCreacion);
            db.AddInParameter(dbCommand, "pUsuarioModificacion", DbType.String, pItem.UsuarioModificacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pObs", DbType.String, pItem.Obs);
            db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            db.ExecuteNonQuery(dbCommand);

            Id = (int)db.GetParameterValue(dbCommand, "pIdProformaDisenio");

            return Id;
        }

        public void EliminaDetalle(ProformaDisenioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Elimina");

         //   db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            //db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void AnulaSolicitud(ProformaDisenioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_AnulaSolicitud");

            //db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);

            db.ExecuteNonQuery(dbCommand);
        }

        public List<ProformaDisenioBE> ListaTodosActivo(DateTime pFechaInicio, DateTime pFechaFin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ProformaDisenio_Listar");
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.Date, pFechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.Date, pFechaFin);
            //db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pIdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDisenioBE> DocumentoBultolist = new List<ProformaDisenioBE>();
            ProformaDisenioBE ProformaDisenio;
            while (reader.Read())
            {
                ProformaDisenio = new ProformaDisenioBE();

                ProformaDisenio.IdProformaDisenio = Int32.Parse(reader["IdProformaDisenio"].ToString());
                ProformaDisenio.NumProformaDisenio =  (reader["NumProformaDisenio"].ToString());
                ProformaDisenio.FechaProformaDisenio = DateTime.Parse( reader["FechaProformaDisenio"].ToString());
                ProformaDisenio.TipoProforma =  reader["TipoProforma"].ToString();

                ProformaDisenio.NumeroDocumento = reader["NumeroDocumento"].ToString();
                ProformaDisenio.NombreCliente = reader["NombreCliente"].ToString();

                ProformaDisenio.CorreoEnvio = reader["CorreoEnvio"].ToString();
                ProformaDisenio.NombreVendedor = reader["Vendedor"].ToString();
                ProformaDisenio.NombreAsesor = reader["Asesor"].ToString();
                ProformaDisenio.DescMoneda = reader["Moneda"].ToString();

                ProformaDisenio.Total = Decimal.Parse(reader["Total"].ToString());
                ProformaDisenio.UsuarioCreacion = reader["UsuarioCreacion"].ToString();
                ProformaDisenio.Obs = reader["Obs"].ToString();
                //ProformaDisenio.FechaAprobacion = DateTime.Parse(reader["FechaAprobacion"].ToString());
                ProformaDisenio.Enviado = Int32.Parse(reader["Enviado"].ToString());
                ProformaDisenio.Situacion = reader["Situacion"].ToString();

                DocumentoBultolist.Add(ProformaDisenio);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoBultolist;
        }

        public List<ProformaDisenioBE> BuscarSolicitud(string pNumero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_BuscarNumeroSolicitud");
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pNumero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDisenioBE> DocumentoBultolist = new List<ProformaDisenioBE>();
            ProformaDisenioBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new ProformaDisenioBE();

                //SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
                //SolicitudEgreso.NumSolicitudEgreso = (reader["NumSolicitudEgreso"].ToString());
                //SolicitudEgreso.FechaSolicitudEgreso = DateTime.Parse(reader["FechaSolicitudEgreso"].ToString());
                //SolicitudEgreso.DescSolicitudEgreso = reader["DescSolicitudEgreso"].ToString();

                //SolicitudEgreso.NumeroDocumento = reader["NumeroDocumento"].ToString();
                //SolicitudEgreso.DescProveedor = reader["DescProveedor"].ToString();

                //SolicitudEgreso.DescBanco = reader["DescBanco"].ToString();
                //SolicitudEgreso.Cuenta = reader["Cuenta"].ToString();
                //SolicitudEgreso.Moneda = reader["Moneda"].ToString();
                //SolicitudEgreso.Solicita = reader["Solicita"].ToString();
                //SolicitudEgreso.NumOCompra = reader["NumOCompra"].ToString();
                //SolicitudEgreso.NroAbonos = reader["NroAbonos"].ToString();

                //SolicitudEgreso.TipoEgreso = reader["TipoEgreso"].ToString();

                //SolicitudEgreso.Tienda = reader["Tienda"].ToString();
                //SolicitudEgreso.RazonSocialFactura = reader["RazonSocialFactura"].ToString();
                //SolicitudEgreso.CentroCosto = reader["CentroCosto"].ToString();
                //SolicitudEgreso.Asignar = reader["Asignar"].ToString();
                //SolicitudEgreso.Obs = reader["Obs"].ToString();

                //SolicitudEgreso.Total = Decimal.Parse(reader["Total"].ToString());
                //SolicitudEgreso.Usuario = reader["Usuario"].ToString();
                //SolicitudEgreso.Situacion = reader["Situacion"].ToString();

                //SolicitudEgreso.Telefono = reader["Telefono"].ToString();
                //SolicitudEgreso.Correo = reader["Correo"].ToString();

                DocumentoBultolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return DocumentoBultolist;
        }
        public List<ProformaDisenioBE> ObtenerCorrelativoPeriodo(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumProformaDisenio_ObtenerCorrelativo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDisenioBE> NumeracionDocumentolist = new List<ProformaDisenioBE>();
            ProformaDisenioBE NumeracionDocumento;
            while (reader.Read())
            {
                NumeracionDocumento = new ProformaDisenioBE();
                NumeracionDocumento.Numero = Int32.Parse(reader["NumProformaDisenio"].ToString());
                NumeracionDocumentolist.Add(NumeracionDocumento);
            }
            reader.Close();
            reader.Dispose();
            return NumeracionDocumentolist;

        }

        public ProformaDisenioBE Buscar_SolicitudEgreso(int IdSolicitudEgreso)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Buscar");
            db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, IdSolicitudEgreso);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProformaDisenioBE SolicitudEgreso = null;
            while (reader.Read())
            {
                SolicitudEgreso = new ProformaDisenioBE();

                //SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
                //SolicitudEgreso.NumSolicitudEgreso = (reader["NumSolicitudEgreso"].ToString());
                //SolicitudEgreso.FechaSolicitudEgreso = DateTime.Parse(reader["FechaSolicitudEgreso"].ToString());
                //SolicitudEgreso.DescSolicitudEgreso = reader["DescSolicitudEgreso"].ToString();

                //SolicitudEgreso.NumeroDocumento = reader["NumeroDocumento"].ToString();

                //SolicitudEgreso.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                //SolicitudEgreso.DescProveedor = reader["DescProveedor"].ToString();

                //SolicitudEgreso.IdBanco = Int32.Parse(reader["IdBanco"].ToString());

                //SolicitudEgreso.DescBanco = reader["DescBanco"].ToString();
                //SolicitudEgreso.Cuenta = reader["Cuenta"].ToString();
                //SolicitudEgreso.CCI = reader["CCI"].ToString();
                //SolicitudEgreso.Moneda = reader["Moneda"].ToString();
                //SolicitudEgreso.IdMoneda = Int32.Parse( reader["IdMoneda"].ToString());

                //SolicitudEgreso.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                //SolicitudEgreso.Solicita = reader["Solicita"].ToString();
                //SolicitudEgreso.NumOCompra = reader["NumOCompra"].ToString();

                //SolicitudEgreso.NroAbonoInicio = Int32.Parse(reader["NroAbonoInicio"].ToString());
                //SolicitudEgreso.NroAbonoFin = Int32.Parse(reader["NroAbonoFin"].ToString());
                //SolicitudEgreso.NroAbonos = reader["NroAbonos"].ToString();

                //SolicitudEgreso.IdTipoEgreso = Int32.Parse(reader["IdTipoEgreso"].ToString());
                //SolicitudEgreso.TipoEgreso = reader["TipoEgreso"].ToString();

                //SolicitudEgreso.IdTienda = Int32.Parse(reader["IdTienda"].ToString());
                //SolicitudEgreso.Tienda = reader["Tienda"].ToString();

                //SolicitudEgreso.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                //SolicitudEgreso.RazonSocialFactura = reader["DescCliente"].ToString();

                //SolicitudEgreso.IdCentroCosto = Int32.Parse(reader["IdCentroCosto"].ToString());
                //SolicitudEgreso.CentroCosto = reader["CentroCosto"].ToString();

                //SolicitudEgreso.IdDetalleCentroCosto = Int32.Parse(reader["IdDetalleCentroCosto"].ToString());
                //SolicitudEgreso.Asignar = reader["Asignar"].ToString();

                //SolicitudEgreso.Obs = reader["Obs"].ToString();

                //SolicitudEgreso.Total = Decimal.Parse(reader["Total"].ToString());
                //SolicitudEgreso.Usuario = reader["Usuario"].ToString();
                //SolicitudEgreso.Situacion = reader["Situacion"].ToString();

                //SolicitudEgreso.Telefono = reader["Telefono"].ToString();
                //SolicitudEgreso.Correo = reader["Correo"].ToString();

                //SolicitudEgreso.CuentaContable = reader["cuentacontable"].ToString();  
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEgreso;
        }

        public ProformaDisenioBE TotalPendientePago(DateTime pFechaInicio, DateTime pFechaFin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConsultaPagosPendientesSolicitudes");
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pFechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pFechaFin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProformaDisenioBE SolicitudEgreso = null;
            while (reader.Read())
            {
                SolicitudEgreso = new ProformaDisenioBE();

                //SolicitudEgreso.Panorama = Decimal.Parse(reader["Panorama"].ToString());
                //SolicitudEgreso.Decoratex = Decimal.Parse(reader["Decoratex"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEgreso;
        }

        public List<ProformaDisenioBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_ListaFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProformaDisenioBE> PrestamoBancolist = new List<ProformaDisenioBE>();
            ProformaDisenioBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new ProformaDisenioBE();
                //SolicitudEgreso.IdSolicitudEgreso = Int32.Parse(reader["IdSolicitudEgreso"].ToString());
                //SolicitudEgreso.FechaAPagar = DateTime.Parse(reader["FechaAPagar"].ToString());
                //SolicitudEgreso.NumSolicitudEgreso = reader["NumSolicitudEgreso"].ToString();

                //SolicitudEgreso.Solicita = reader["Solicita"].ToString();

                //SolicitudEgreso.DescProveedor = reader["Proveedor"].ToString();
                //SolicitudEgreso.DescBanco = reader["DescBanco"].ToString();
                //SolicitudEgreso.Cuenta = reader["Cuenta"].ToString();
                //SolicitudEgreso.RazonSocialFactura = reader["RazonSocialAFacturar"].ToString();
                //SolicitudEgreso.DescMoneda = reader["Moneda"].ToString();
                //SolicitudEgreso.MontoAbono = Decimal.Parse(reader["MontoAbono"].ToString());
                //SolicitudEgreso.FechaDeposito = reader.IsDBNull(reader.GetOrdinal("FechaDeposito")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaDeposito"));

                //   SolicitudEgreso.UsuarioPago = reader["UsuarioPago"].ToString();

                PrestamoBancolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }


        public void Actualiza(ProformaDisenioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Actualiza");

            //db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
            //db.AddInParameter(dbCommand, "pDescSolicitudEgreso", DbType.String, pItem.DescSolicitudEgreso);
            //db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            //db.AddInParameter(dbCommand, "pIdBanco", DbType.Int32, pItem.IdBanco);
            //db.AddInParameter(dbCommand, "pIdMoneda", DbType.Int32, pItem.IdMoneda);
            //db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            //db.AddInParameter(dbCommand, "pNumOCompra", DbType.String, pItem.NumOCompra);

            //db.AddInParameter(dbCommand, "pNroAbonoInicio", DbType.Int32, pItem.NroAbonoInicio);
            //db.AddInParameter(dbCommand, "pNroAbonoFin", DbType.Int32, pItem.NroAbonoFin);

            //db.AddInParameter(dbCommand, "pIdTipoEgreso", DbType.Int32, pItem.IdTipoEgreso);
            //db.AddInParameter(dbCommand, "pIdTienda", DbType.Int32, pItem.IdTienda);

            //db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            //db.AddInParameter(dbCommand, "pRazonSocialFactura", DbType.String, pItem.RazonSocialFactura);

            //db.AddInParameter(dbCommand, "pIdCentroCosto", DbType.Int32, pItem.IdCentroCosto);
            //db.AddInParameter(dbCommand, "pIdDetalleCentroCosto", DbType.Int32, pItem.IdDetalleCentroCosto);
            //db.AddInParameter(dbCommand, "pObs", DbType.String, pItem.Obs);
            //db.AddInParameter(dbCommand, "pTotal", DbType.Decimal, pItem.Total);
            //db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);

            //db.AddInParameter(dbCommand, "pCuentaContable", DbType.String, pItem.CuentaContable);
            db.ExecuteNonQuery(dbCommand);
        }

    }
}
