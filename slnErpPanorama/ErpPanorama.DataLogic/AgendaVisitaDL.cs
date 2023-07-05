using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ErpPanorama.BusinessEntity;
using System.Collections.Generic;

namespace ErpPanorama.DataLogic
{
    public class AgendaVisitaDL
    {
        public AgendaVisitaDL() { }

        public Int32 Inserta(AgendaVisitaBE pItem)
        {
            Int32 Id = 0;
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AgendaVisita_Inserta");

            db.AddInParameter(dbCommand, "pNumAgendaVisita", DbType.String, pItem.NumAgendaVisita);
            db.AddInParameter(dbCommand, "pIdAsesor", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdCliente", DbType.Int32, pItem.IdCliente);
            db.AddInParameter(dbCommand, "pFechaAgendaVisita", DbType.DateTime, pItem.FechaAgendaVisita);
            db.AddInParameter(dbCommand, "pLugar", DbType.String, pItem.Lugar);
            db.AddInParameter(dbCommand, "pUbigeo", DbType.String, pItem.Ubigeo);
            db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pAgenda", DbType.String, pItem.Agenda);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pDuracion", DbType.Int32, pItem.Duracion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pFechaAgenda", DbType.DateTime, pItem.FechaAgenda);
            db.AddInParameter(dbCommand, "pPrecioVisita", DbType.Decimal, pItem.PrecioVisita);

            db.AddInParameter(dbCommand, "pNumeroProyecto", DbType.String, pItem.NumeroProyecto);


            db.ExecuteNonQuery(dbCommand);

            // Id = (int)db.GetParameterValue(dbCommand, "pIdAgendaVisita");

            return Id;
        }

        public void EliminaDetalle(AgendaVisitaBE pItem)
        {
            //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            //DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_Elimina");

            //db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);
            //db.ExecuteNonQuery(dbCommand);
        }

        public void AnulaSolicitud(AgendaVisitaBE pItem)
        {
            //Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            //DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_AnulaSolicitud");

            //db.AddInParameter(dbCommand, "pIdSolicitudEgreso", DbType.Int32, pItem.IdSolicitudEgreso);

            //db.ExecuteNonQuery(dbCommand);
        }

        public List<AgendaVisitaBE> ListaTodosActivo(int pIdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            // DbCommand dbCommand = db.GetStoredProcCommand("usp_AgendaVisita_ListaTodosActivo");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Disenio_SeleccionaTodo");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pIdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgendaVisitaBE> AgendaVisitalist = new List<AgendaVisitaBE>();
            AgendaVisitaBE AgendaVisita;
            while (reader.Read())
            {
                AgendaVisita = new AgendaVisitaBE();

                AgendaVisita.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                AgendaVisita.Nombres = (reader["ApeNom"].ToString());
                AgendaVisita.IdTienda = Int32.Parse(reader["IdTienda"].ToString());

                AgendaVisita.Tienda = reader["DescTienda"].ToString();

                AgendaVisita.TotalCancelado = Int32.Parse(reader["TotalCancelados"].ToString());
                AgendaVisita.TotalProgramado = Int32.Parse(reader["TotalProgramado"].ToString());
                AgendaVisita.TotalReProgramado = Int32.Parse(reader["TotalReProgramado"].ToString());
                AgendaVisita.TotalVisitado = Int32.Parse(reader["TotalVisitado"].ToString());

                AgendaVisitalist.Add(AgendaVisita);
            }
            reader.Close();
            reader.Dispose();
            return AgendaVisitalist;
        }

        public List<AgendaVisitaBE> BuscarSolicitud(string pNumero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_BuscarNumeroSolicitud");
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pNumero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgendaVisitaBE> DocumentoBultolist = new List<AgendaVisitaBE>();
            AgendaVisitaBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new AgendaVisitaBE();

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

        //public AgendaVisitaBE BuscarVisita(int pNumerovisita)
        //{
        //    Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
        //    DbCommand dbCommand = db.GetStoredProcCommand("usp_Buscar_NumVisita");
        //    db.AddInParameter(dbCommand, "pIdVisita", DbType.Int32, pNumerovisita);

        //    IDataReader reader = db.ExecuteReader(dbCommand);
        //    AgendaVisitaBE SolicitudEgreso = null;
        //    while (reader.Read())
        //    {
        //        SolicitudEgreso = new AgendaVisitaBE();

        //        //SolicitudEgreso.Panorama = Decimal.Parse(reader["Panorama"].ToString());
        //        //SolicitudEgreso.Decoratex = Decimal.Parse(reader["Decoratex"].ToString());
        //        PrestamoBancolist.Add(SolicitudEgreso);
        //    }
        //    reader.Close();
        //    reader.Dispose();
        //    return SolicitudEgreso;
        //}

        public List<AgendaVisitaBE> ObtenerCorrelativoPeriodo(int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_NumeracionAgendaVisita_ObtenerCorrelativo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgendaVisitaBE> NumeracionDocumentolist = new List<AgendaVisitaBE>();
            AgendaVisitaBE NumeracionDocumento;
            while (reader.Read())
            {
                NumeracionDocumento = new AgendaVisitaBE();
                NumeracionDocumento.Numero = Int32.Parse(reader["NumAgendaVisita"].ToString());
                NumeracionDocumentolist.Add(NumeracionDocumento);
            }
            reader.Close();
            reader.Dispose();
            return NumeracionDocumentolist;

        }

        public AgendaVisitaBE BuscarVisita(int IdVisita)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Buscar_NumVisita");
            db.AddInParameter(dbCommand, "pIdVisita", DbType.Int32, IdVisita);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AgendaVisitaBE Visitas = null;
            while (reader.Read())
            {
                Visitas = new AgendaVisitaBE();

                Visitas.NumAgendaVisita = (reader["NumAgendaVisita"].ToString());
                Visitas.NumeroDocumento = (reader["NumeroDocumento"].ToString());
                Visitas.NumeroProyecto = (reader["NumProyecto"].ToString());

                Visitas.DescCliente = (reader["DescCliente"].ToString());
                Visitas.Lugar = (reader["direccion"].ToString());
                Visitas.Ubigeo = (reader["Ubigeo"].ToString());
                Visitas.Celular = (reader["Celular"].ToString());
                Visitas.Observacion = (reader["Observacion"].ToString());
                Visitas.IdMotivo = Int32.Parse(reader["idmotivovisita"].ToString());
                Visitas.Agenda = (reader["Agenda"].ToString());
                Visitas.FechaAgenda = DateTime.Parse(reader["FechaAgenda"].ToString());

                Visitas.Duracion = Int32.Parse(reader["Duracion"].ToString());
                Visitas.PuntosTratados = (reader["Obs"].ToString());
                Visitas.TiempoTermino = (reader["HoraTermino"].ToString());
                Visitas.RutaArchivo = (reader["RutaArchivo"].ToString());

                Visitas.Nombres = (reader["Nombres"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Visitas;
        }

        public AgendaVisitaBE BuscarNumVisita(String NumVisita)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_BuscarNumeroVisita");
            db.AddInParameter(dbCommand, "pNumVisita", DbType.String, NumVisita);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AgendaVisitaBE Visitas = null;
            while (reader.Read())
            {
                Visitas = new AgendaVisitaBE();

                Visitas.IdAgendaVisita = Int32.Parse((reader["IdAgendaVisita"].ToString()));
                Visitas.NumAgendaVisita = (reader["NumVisita"].ToString());
                Visitas.Hora = (reader["HoraInicio"].ToString());
                Visitas.TiempoTermino = (reader["HoraFin"].ToString());
                Visitas.FechaAgenda = DateTime.Parse(reader["FechaVisita"].ToString());
                Visitas.Nombres = (reader["Disenador"].ToString());
                Visitas.Agenda = (reader["Agenda"].ToString());
                Visitas.DescMotivo = (reader["MotivoVisita"].ToString());
                Visitas.PrecioVisita = Decimal.Parse(reader["PrecioVisita"].ToString());
                Visitas.Situacion = (reader["Situacion"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Visitas;
        }

        public AgendaVisitaBE BuscarNumVisitaAsociada(String NumVisita)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_BuscarNumeroVisitaAsociada");
            db.AddInParameter(dbCommand, "pNumVisita", DbType.String, NumVisita);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AgendaVisitaBE Visitas = null;
            while (reader.Read())
            {
                Visitas = new AgendaVisitaBE();

                Visitas.IdAgendaVisita = Int32.Parse((reader["IdAgendaVisita"].ToString()));
                Visitas.NumAgendaVisita = (reader["NumVisita"].ToString());
                Visitas.Hora = (reader["HoraInicio"].ToString());
                Visitas.TiempoTermino = (reader["HoraFin"].ToString());
                Visitas.FechaAgenda = DateTime.Parse(reader["FechaVisita"].ToString());
                Visitas.Nombres = (reader["Disenador"].ToString());
                Visitas.Agenda = (reader["Agenda"].ToString());
                Visitas.DescMotivo = (reader["MotivoVisita"].ToString());
                Visitas.PrecioVisita = Decimal.Parse(reader["PrecioVisita"].ToString());
                Visitas.Situacion = (reader["Situacion"].ToString());
                Visitas.NumeroProyecto = (reader["NumeroProyecto"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Visitas;
        }

        public AgendaVisitaBE TotalPendientePago(DateTime pFechaInicio, DateTime pFechaFin)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ConsultaPagosPendientesSolicitudes");
            db.AddInParameter(dbCommand, "pFechaInicio", DbType.DateTime, pFechaInicio);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pFechaFin);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AgendaVisitaBE SolicitudEgreso = null;
            while (reader.Read())
            {
                SolicitudEgreso = new AgendaVisitaBE();

                //SolicitudEgreso.Panorama = Decimal.Parse(reader["Panorama"].ToString());
                //SolicitudEgreso.Decoratex = Decimal.Parse(reader["Decoratex"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return SolicitudEgreso;
        }

        public List<AgendaVisitaBE> ListaFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_SolicitudEgreso_ListaFecha");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgendaVisitaBE> PrestamoBancolist = new List<AgendaVisitaBE>();
            AgendaVisitaBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new AgendaVisitaBE();
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


        public List<AgendaVisitaBE> ListaFechaVisitas(int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Listar_Visitas");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            db.AddInParameter(dbCommand, "pFechaInicioVisita", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaFinVisita", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgendaVisitaBE> PrestamoBancolist = new List<AgendaVisitaBE>();
            AgendaVisitaBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new AgendaVisitaBE();

                SolicitudEgreso.IdAgendaVisita = Int32.Parse(reader["IdAgendaVisita"].ToString());
                SolicitudEgreso.NumAgendaVisita = reader["NumAgendaVisita"].ToString();
                SolicitudEgreso.NumeroProyecto = reader["NumProyecto"].ToString();
                SolicitudEgreso.FechaAgendaVisita = DateTime.Parse(reader["FechaAgendaVisita"].ToString());
                SolicitudEgreso.FechaAgenda = DateTime.Parse(reader["FechaAgenda"].ToString());
                SolicitudEgreso.Hora = reader["Hora"].ToString();

                SolicitudEgreso.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEgreso.Disenadora = reader["Nombres"].ToString();

                SolicitudEgreso.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                SolicitudEgreso.DescCliente = reader["DescCliente"].ToString();

                SolicitudEgreso.Lugar = reader["direccion"].ToString();
                SolicitudEgreso.Distrito = reader["distrito"].ToString();
                SolicitudEgreso.Celular = reader["celular"].ToString();
                SolicitudEgreso.Agenda = reader["Agenda"].ToString();
                SolicitudEgreso.Duracion = Int32.Parse(reader["Duracion"].ToString());

                SolicitudEgreso.IdMotivo = Int32.Parse(reader["idmotivovisita"].ToString());
                SolicitudEgreso.DescMotivo = reader["Motivo"].ToString();
                SolicitudEgreso.Observacion = reader["Observacion"].ToString();

                SolicitudEgreso.Tienda = reader["Tienda"].ToString();
                SolicitudEgreso.Situacion = reader["Situacion"].ToString();

                SolicitudEgreso.RutaArchivo = reader["RutaArchivo"].ToString();
                SolicitudEgreso.TiempoTermino = reader["HoraTermino"].ToString();

                SolicitudEgreso.PrecioVisita = Decimal.Parse(reader["PrecioVisita"].ToString());
                PrestamoBancolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }

        public List<AgendaVisitaBE> ListaFechaVisitasProgramadas(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Listar_VisitasPendientes");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgendaVisitaBE> PrestamoBancolist = new List<AgendaVisitaBE>();
            AgendaVisitaBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new AgendaVisitaBE();

                SolicitudEgreso.IdAgendaVisita = Int32.Parse(reader["IdAgendaVisita"].ToString());
                SolicitudEgreso.NumAgendaVisita = reader["NumAgendaVisita"].ToString();
                SolicitudEgreso.DiaSemana = reader["DiaSemana"].ToString();
                SolicitudEgreso.FechaAgenda = DateTime.Parse(reader["FechaAgenda"].ToString());
                SolicitudEgreso.Hora = reader["Hora"].ToString();

                SolicitudEgreso.Disenadora = reader["Nombres"].ToString();

                SolicitudEgreso.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                SolicitudEgreso.DescCliente = reader["DescCliente"].ToString();

                SolicitudEgreso.Lugar = reader["direccion"].ToString();
                SolicitudEgreso.Distrito = reader["distrito"].ToString();
                SolicitudEgreso.Celular = reader["celular"].ToString();
                SolicitudEgreso.Agenda = reader["Agenda"].ToString();

                SolicitudEgreso.DescMotivo = reader["Motivo"].ToString();
                SolicitudEgreso.Observacion = reader["Observacion"].ToString();

                SolicitudEgreso.Tienda = reader["Tienda"].ToString();
                SolicitudEgreso.Situacion = reader["Situacion"].ToString();

                PrestamoBancolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }

        public List<AgendaVisitaBE> ListaVisitasTodas(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Listar_VisitasTodas");
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgendaVisitaBE> PrestamoBancolist = new List<AgendaVisitaBE>();
            AgendaVisitaBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new AgendaVisitaBE();

                SolicitudEgreso.IdAgendaVisita = Int32.Parse(reader["IdAgendaVisita"].ToString());
                SolicitudEgreso.NumAgendaVisita = reader["NumAgendaVisita"].ToString();
                SolicitudEgreso.NumeroProyecto = reader["NumProyecto"].ToString();
                SolicitudEgreso.DiaSemana = reader["DiaSemana"].ToString();
                SolicitudEgreso.FechaAgenda = DateTime.Parse(reader["FechaAgenda"].ToString());
                SolicitudEgreso.Hora = reader["Hora"].ToString();

                SolicitudEgreso.Disenadora = reader["Nombres"].ToString();

                SolicitudEgreso.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                SolicitudEgreso.DescCliente = reader["DescCliente"].ToString();

                SolicitudEgreso.Lugar = reader["direccion"].ToString();
                SolicitudEgreso.Distrito = reader["distrito"].ToString();
                SolicitudEgreso.Celular = reader["celular"].ToString();
                SolicitudEgreso.Agenda = reader["Agenda"].ToString();

                SolicitudEgreso.DescMotivo = reader["Motivo"].ToString();
                SolicitudEgreso.Observacion = reader["Observacion"].ToString();

                SolicitudEgreso.Tienda = reader["Tienda"].ToString();
                SolicitudEgreso.Situacion = reader["Situacion"].ToString();

                PrestamoBancolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }

        public void ReprogramaVisita(AgendaVisitaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AgendaVisita_Actualiza");

            db.AddInParameter(dbCommand, "pIdAgendaVisita", DbType.Int32, pItem.IdAgendaVisita);
            db.AddInParameter(dbCommand, "pLugar", DbType.String, pItem.Lugar);
            db.AddInParameter(dbCommand, "pUbigeo", DbType.String, pItem.Ubigeo);
            db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pIdMotivo", DbType.Int32, pItem.IdMotivo);
            db.AddInParameter(dbCommand, "pAgenda", DbType.String, pItem.Agenda);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);

            db.AddInParameter(dbCommand, "pFechaAgenda", DbType.DateTime, pItem.FechaAgenda);

            db.ExecuteNonQuery(dbCommand);
        }

        public void CerrarVisita(AgendaVisitaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AgendaVisita_Cerrar");

            db.AddInParameter(dbCommand, "pIdAgendaVisita", DbType.Int32, pItem.IdAgendaVisita);
            db.AddInParameter(dbCommand, "pPuntosTratados", DbType.String, pItem.PuntosTratados);
            db.AddInParameter(dbCommand, "pTiempoTermino", DbType.String, pItem.TiempoTermino);
            db.AddInParameter(dbCommand, "pRutaArchivo", DbType.String, pItem.RutaArchivo);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.ExecuteNonQuery(dbCommand);
        }

        public void CancelaVisita(AgendaVisitaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AgendaVisita_Cancela");

            db.AddInParameter(dbCommand, "pIdAgendaVisita", DbType.Int32, pItem.IdAgendaVisita);
            db.AddInParameter(dbCommand, "pDescCancelacion", DbType.String, pItem.DescCancelacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);

            db.ExecuteNonQuery(dbCommand);
        }

        // 170323 ->
        public List<AgendaVisitaBE> ListaFechaVisitasValidarFecha(DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Listar_Visitas_Validar_Fecha");
            db.AddInParameter(dbCommand, "pFechaInicioVisita", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaFinVisita", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgendaVisitaBE> PrestamoBancolist = new List<AgendaVisitaBE>();
            AgendaVisitaBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new AgendaVisitaBE();

                SolicitudEgreso.IdAgendaVisita = Int32.Parse(reader["IdAgendaVisita"].ToString());
                SolicitudEgreso.NumAgendaVisita = reader["NumAgendaVisita"].ToString();
                SolicitudEgreso.FechaAgendaVisita = DateTime.Parse(reader["FechaAgendaVisita"].ToString());
                SolicitudEgreso.FechaAgenda = DateTime.Parse(reader["FechaAgenda"].ToString());
                SolicitudEgreso.Hora = reader["Hora"].ToString();

                SolicitudEgreso.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEgreso.Disenadora = reader["Nombres"].ToString();

                SolicitudEgreso.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                SolicitudEgreso.DescCliente = reader["DescCliente"].ToString();

                SolicitudEgreso.Lugar = reader["direccion"].ToString();
                SolicitudEgreso.Distrito = reader["distrito"].ToString();
                SolicitudEgreso.Celular = reader["celular"].ToString();
                SolicitudEgreso.Agenda = reader["Agenda"].ToString();
                SolicitudEgreso.Duracion = Int32.Parse(reader["Duracion"].ToString());

                SolicitudEgreso.IdMotivo = Int32.Parse(reader["idmotivovisita"].ToString());
                SolicitudEgreso.DescMotivo = reader["Motivo"].ToString();
                SolicitudEgreso.Observacion = reader["Observacion"].ToString();

                SolicitudEgreso.Tienda = reader["Tienda"].ToString();
                SolicitudEgreso.Situacion = reader["Situacion"].ToString();

                SolicitudEgreso.RutaArchivo = reader["RutaArchivo"].ToString();
                SolicitudEgreso.TiempoTermino = reader["HoraTermino"].ToString();

                SolicitudEgreso.PrecioVisita = Decimal.Parse(reader["PrecioVisita"].ToString());
                PrestamoBancolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }

        // 170323 ->
        public List<AgendaVisitaBE> ListaVisitasPendientes(int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnErpPanoramaBD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Listar_Visitas_Pendientes");
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AgendaVisitaBE> PrestamoBancolist = new List<AgendaVisitaBE>();
            AgendaVisitaBE SolicitudEgreso;
            while (reader.Read())
            {
                SolicitudEgreso = new AgendaVisitaBE();

                SolicitudEgreso.IdAgendaVisita = Int32.Parse(reader["IdAgendaVisita"].ToString());
                SolicitudEgreso.NumAgendaVisita = reader["NumAgendaVisita"].ToString();
               // SolicitudEgreso.StrFechaAgenda = Convert.ToDateTime(reader["FechaAgenda"].ToString()).ToString("dd/MM/yy HH:mm");
                SolicitudEgreso.StrFechaAgenda = Convert.ToDateTime(reader["FechaAgenda"].ToString()).ToString("dd/MM/yyyy");
                SolicitudEgreso.Hora = reader["Hora"].ToString();

                SolicitudEgreso.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                SolicitudEgreso.Disenadora = reader["Nombres"].ToString();

                SolicitudEgreso.IdCliente = Int32.Parse(reader["IdCliente"].ToString());
                SolicitudEgreso.DescCliente = reader["DescCliente"].ToString();

                SolicitudEgreso.Agenda = reader["Agenda"].ToString();
                SolicitudEgreso.Duracion = Int32.Parse(reader["Duracion"].ToString());
                PrestamoBancolist.Add(SolicitudEgreso);
            }
            reader.Close();
            reader.Dispose();
            return PrestamoBancolist;
        }
    }
}
